using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.settings
{
    public partial class system_autodeliveryalert_email : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public static int CompanyID;

        public static int UserID;

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        private BaseClass objBass = new BaseClass();

        public languageClass objLangauge = new languageClass();

        public string ServerName = ConnectionClass.ServerName;

        public static int ddlSelectedValue;

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

        static system_autodeliveryalert_email()
        {
        }

      

        public void BindSignature()
        {
            system_autodeliveryalert_email.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailsignature_title_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", system_autodeliveryalert_email.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.ddlSignature.DataSource = dataSet;
            this.ddlSignature.DataTextField = "FooterTitle";
            this.ddlSignature.DataValueField = "EmailFooterID";
            this.ddlSignature.DataBind();
            this.ddlSignature.Items.Insert(0, "--- Select ---");
            this.ddlSignature.Items[0].Text = "--- Select ---";
            this.ddlSignature.Items[0].Value = "0";
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["Isdefault"].ToString().ToLower() != "true")
                {
                    system_autodeliveryalert_email.ddlSelectedValue = 0;
                }
                else
                {
                    this.objBass.SetDDLValue(this.ddlSignature, row["EmailFooterID"].ToString());
                    system_autodeliveryalert_email.ddlSelectedValue = Convert.ToInt16(row["EmailFooterID"]);
                    break;
                }
            }
        }

        protected void BindStatus()
        {
            DataTable dataTable = this.DeliveryStatusBindTable();
            this.ddlStatus.DataSource = dataTable;
            this.ddlStatus.DataTextField = "StatusTitle";
            this.ddlStatus.DataValueField = "StatusID";
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, "Select");
            this.ddlStatus.Items[0].Text = "----Select----";
            this.ddlStatus.Items[0].Value = "0";
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings/system_autodeliveryalert_email.aspx");
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridDataItem item in this.grdAutoJobAlert.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkEmailBodyId1");
                num = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SettingsBasePage.autojobalert_delete(system_autodeliveryalert_email.CompanyID, num);
            }
            this.GetAutoDeliveryalertdetails();
            this.grdAutoJobAlert.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (!(this.lblemail.Text != "") || !(this.hdntypesave.Value.ToLower() == "edit"))
            {
                int num = 0;
                SettingsBasePage.system_autoDeliveryalert_email(system_autodeliveryalert_email.CompanyID, system_autodeliveryalert_email.UserID, Convert.ToInt32(this.ddlStatus.SelectedValue), this.txtSubject.Text, this.RadEditor1.Content.ToString(), Convert.ToInt32(this.ddlSignature.SelectedValue), Convert.ToInt32(this.chkEnabled.Checked), base.SpecialEncode(this.txt_cc.Text), base.SpecialEncode(this.txt_bcc.Text), Convert.ToInt32(num.ToString()));
            }
            else
            {
                SettingsBasePage.system_autoDeliveryalert_email(system_autodeliveryalert_email.CompanyID, system_autodeliveryalert_email.UserID, Convert.ToInt32(this.ddlStatus.SelectedValue), this.txtSubject.Text, this.RadEditor1.Content.ToString(), Convert.ToInt32(this.ddlSignature.SelectedValue), Convert.ToInt32(this.chkEnabled.Checked), base.SpecialEncode(this.txt_cc.Text), base.SpecialEncode(this.txt_bcc.Text), Convert.ToInt32(this.lblemail.Text.ToString()));
            }
            this.GetAutoDeliveryalertdetails();
            this.BindSignature();
            this.hiddenEmailID.Value = null;
            base.Message_Display(this.objLanguage.GetLanguageConversion("Autojob_alert__Added_Successfully"), "msg-success", this.plhMessage);
            base.Response.Redirect("~/Settings/system_autodeliveryalert_email.aspx");
        }

        public void GetAutoDeliveryalertdetails()
        {
            DataTable dataTable = SettingsBasePage.AutoDeliveryAlert_select(system_autodeliveryalert_email.CompanyID);
            this.grdAutoJobAlert.DataSource = dataTable;
            this.grdAutoJobAlert.DataBind();
        }

        protected void gridautojobalert_needdatasource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.AutojobAlert_select(system_autodeliveryalert_email.CompanyID);
            this.grdAutoJobAlert.DataSource = dataTable;
        }

        public void gridautojobalert_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaultVal");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkStatus");
                LinkButton linkButton1 = (LinkButton)e.Item.FindControl("lnkSubject");
                Image image = (Image)e.Item.FindControl("imgdefault");
                if (hiddenField.Value.ToLower() != "true")
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
                }
                else
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdAutoJobAlert.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdAutoJobAlert.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected DataTable DeliveryStatusBindTable()
        {
            return SettingsBasePage.AutoDeliveryAlert_SelectStatus(system_autodeliveryalert_email.CompanyID);
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            foreach (GridDataItem item in this.grdAutoJobAlert.MasterTableView.Items)
            {
                SettingsBasePage.autojobalert_delete(system_autodeliveryalert_email.CompanyID, Convert.ToInt32(e.CommandArgument));
            }
            this.GetAutoDeliveryalertdetails();
            this.grdAutoJobAlert.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void lnkStatus_onClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataTable dataTable = SettingsBasePage.system_autojobalert(system_autodeliveryalert_email.CompanyID, Convert.ToInt32(linkButton.CommandArgument.ToString()));
            this.txtSubject.Text = dataTable.Rows[0]["Subject"].ToString();
            this.RadEditor1.Content = dataTable.Rows[0]["Body"].ToString();
            this.objBass.SetDDLValue(this.ddlSignature, dataTable.Rows[0]["FooterID"].ToString());
            if (!Convert.ToBoolean(dataTable.Rows[0]["ISEnabled"].ToString()))
            {
                this.chkEnabled.Checked = false;
            }
            else
            {
                this.chkEnabled.Checked = true;
            }
            this.txt_cc.Text = dataTable.Rows[0]["CC"].ToString();
            this.txt_bcc.Text = dataTable.Rows[0]["BCC"].ToString();
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            this.lblemail.Text = linkButton.CommandArgument.ToString();
            DataTable dataTable1 = SettingsBasePage.AutoDeliveryAlert_EditSelectStatus(system_autodeliveryalert_email.CompanyID, Convert.ToInt32(dataTable.Rows[0]["StatusID"].ToString()));
            this.ddlStatus.DataTextField = "StatusTitle";
            this.ddlStatus.DataValueField = "StatusID";
            this.ddlStatus.DataSource = dataTable1;
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, "Select");
            this.ddlStatus.Items[0].Text = "----Select----";
            this.ddlStatus.Items[0].Value = "0";
            this.objBass.SetDDLValue(this.ddlStatus, dataTable.Rows[0]["StatusID"].ToString());
        }

        public void lnkSubject_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataTable dataTable = SettingsBasePage.system_autojobalert(system_autodeliveryalert_email.CompanyID, Convert.ToInt32(linkButton.CommandArgument.ToString()));
            this.txtSubject.Text = dataTable.Rows[0]["Subject"].ToString();
            this.RadEditor1.Content = dataTable.Rows[0]["Body"].ToString();
            this.objBass.SetDDLValue(this.ddlSignature, dataTable.Rows[0]["FooterID"].ToString());
            if (!Convert.ToBoolean(dataTable.Rows[0]["ISEnabled"].ToString()))
            {
                this.chkEnabled.Checked = false;
            }
            else
            {
                this.chkEnabled.Checked = true;
            }
            this.txt_cc.Text = dataTable.Rows[0]["CC"].ToString();
            this.txt_bcc.Text = dataTable.Rows[0]["BCC"].ToString();
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            this.lblemail.Text = linkButton.CommandArgument.ToString();
            DataTable dataTable1 = SettingsBasePage.AutoDeliveryAlert_EditSelectStatus(system_autodeliveryalert_email.CompanyID, Convert.ToInt32(dataTable.Rows[0]["StatusID"].ToString()));
            this.ddlStatus.DataTextField = "StatusTitle";
            this.ddlStatus.DataValueField = "StatusID";
            this.ddlStatus.DataSource = dataTable1;
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, "Select");
            this.ddlStatus.Items[0].Text = "----Select----";
            this.ddlStatus.Items[0].Value = "0";
            this.objBass.SetDDLValue(this.ddlStatus, dataTable.Rows[0]["StatusID"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Text = this.objLangauge.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLangauge.GetLanguageConversion("Save");
            this.grdAutoJobAlert.MasterTableView.NoMasterRecordsText = this.objLangauge.GetLanguageConversion("No_records_to_display");
            this.lnkDeleteStatus.Text = this.objLangauge.GetLanguageConversion("Detele_Selected");
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "hidetype();", true);
            system_autodeliveryalert_email.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            system_autodeliveryalert_email.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            this.grdAutoJobAlert.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.grdAutoJobAlert.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Subject");
            this.grdAutoJobAlert.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Enabled");
            this.grdAutoJobAlert.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            system_autodeliveryalert_email.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email"), "&nbsp;>>&nbsp;", this.objLangauge.GetLanguageConversion("Auto_job_Alert")));
            base.Title = this.objLanguage.convert(global.pageTitle("System Auto Job Alert", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLangauge.GetLanguageConversion("Auto_job_Alert");
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor1.ImageManager.UploadPaths = strArrays1;
            this.RadEditor1.ImageManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.UploadPaths = strArrays1;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays1;
            if (!base.IsPostBack)
            {
                this.GetAutoDeliveryalertdetails();
                this.BindStatus();
                this.BindSignature();
            }
            this.trItemNumber.Visible = true;
            this.trItemTitle.Visible = true;
            this.trItemValueIncTax.Visible = true;
            this.lnkDeleteStatus.Attributes.Add("onclick", "javascript:return CallDelete();");
        }
    }
}
