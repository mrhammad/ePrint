using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class inventorystockreduction : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private Global gloobj = new Global();

        private SettingsBasePage obj = new SettingsBasePage();

        public int CompanyID;

        public int UserID;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public inventorystockreduction()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/settings/settings.aspx");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            if (this.rdoJob.Checked)
            {
                Convert.ToInt32(this.ddlJobStatus.SelectedValue.ToString());
                empty = "j";
            }
            else if (this.rdoEstimate.Checked)
            {
                empty = "e";
            }
            else if (this.rdoInvoice.Checked)
            {
                empty = "i";
            }
            if (this.rdoCancellationAction.Items[0].Selected)
            {
                str = "a";
            }
            else if (this.rdoCancellationAction.Items[1].Selected)
            {
                str = "n";
            }
            else if (this.rdoCancellationAction.Items[2].Selected)
            {
                str = "p";
            }
            SettingsBasePage.Settings_inventoryStockReduction_insert_update((long)this.CompanyID, empty, Convert.ToInt32(this.ddlJobStatus.SelectedValue.ToString()), str, Convert.ToInt32(num));
            base.Message_Display(this.objlang.GetLanguageConversion("Inventory_Stock_Reduction_Saved_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnCancelprocess');");
            this.rdoEstimate.Text = this.objLanguage.GetLanguageConversion("An_Estimate_Is_Progressed_To_Job");
            this.rdoJob.Text = this.objLanguage.GetLanguageConversion("When_Job_Status_Is_Changed_To");
            this.rdoInvoice.Text = this.objLanguage.GetLanguageConversion("When_Job_Is_Progressed_To_An_Invoice");
            this.rdoCancellationAction.Items[0].Text = this.objLanguage.GetLanguageConversion("Add_Stock_Back_To_The_Inventory_If_The_Stock_Has_Already_Been_Reduced");
            this.rdoCancellationAction.Items[1].Text = this.objLanguage.GetLanguageConversion("Do_Not_Add_Stock_Back_To_The_Inventory");
            this.rdoCancellationAction.Items[2].Text = this.objLanguage.GetLanguageConversion("Prompt_User_To_Decide_If_Stock_Should_Be_Added_Back_To_The_System");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Stock_Reduction")));
            base.Title = this.objLanguage.convert(global.pageTitle("Stock Reduction", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Stock_Reduction");
            DataTable dataTable = new DataTable();
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            int num = 0;
            dataTable = SettingsBasePage.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            if (!base.IsPostBack)
            {
                this.obj.Bind_Status_new(this.ddlJobStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                if (dataTable.Rows != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["StockReduces"].ToString() == "e")
                        {
                            this.rdoEstimate.Checked = true;
                            this.rdoJob.Checked = false;
                            this.rdoInvoice.Checked = false;
                        }
                        if (row["StockReduces"].ToString() == "j")
                        {
                            this.rdoEstimate.Checked = false;
                            this.rdoJob.Checked = true;
                            this.rdoInvoice.Checked = false;
                            this.ddlJobStatus.SelectedValue = row["JobStatusChange"].ToString();
                        }
                        if (row["StockReduces"].ToString() == "i")
                        {
                            this.rdoEstimate.Checked = false;
                            this.rdoJob.Checked = false;
                            this.rdoInvoice.Checked = true;
                        }
                        if (row["CanceledJob"].ToString() == "a")
                        {
                            this.rdoCancellationAction.Items[0].Selected = true;
                        }
                        if (row["CanceledJob"].ToString() == "n")
                        {
                            this.rdoCancellationAction.Items[1].Selected = true;
                        }
                        if (row["CanceledJob"].ToString() == "p")
                        {
                            this.rdoCancellationAction.Items[2].Selected = true;
                        }
                        num = Convert.ToInt32(row["StatusMsg"]);
                    }
                }
            }
            if (num != 1)
            {
                this.btnSave.Enabled = true;
            }
            else
            {
                this.btnSave.Attributes.Add("style", "cursor:not-allowed");
                this.btnSave.Enabled = false;
            }
            if (base.Request.Params["ty"] != null && base.Request.Params["ty"].ToString() == "up")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Stock_Reduction_Saved_Successfully"), "msg-success", this.plhMessage);
            }
        }
    }
}