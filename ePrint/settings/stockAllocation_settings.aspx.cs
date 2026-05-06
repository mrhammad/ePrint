using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class stockAllocation_settings : BaseClass, IRequiresSessionState
    {
        private SettingsBasePage obj = new SettingsBasePage();

        public int CompanyID;

        public int UserID;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

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

        public stockAllocation_settings()
        {
        }

        protected void btn_Saveonclick(object sender, EventArgs e)
        {
            string str = "";
            int num = 0;
            string str1 = "";
            int num1 = 0;
            string str2 = "";
            int num2 = 0;
            string str3 = "";
            int num3 = 0;
            string str4 = "";
            int num4 = 1;
            int num5 = 0;
            string str5 = "";
            if (this.rdbeprintjobprogressstojob.Checked)
            {
                str = "e";
            }
            if (this.rdbestore_orderplaced.Checked)
            {
                str1 = "p";
            }
            if (this.rdbfifo.Checked)
            {
                str2 = "f";
            }
            else if (this.rdblifo.Checked)
            {
                str2 = "l";
            }
            if (this.chk_onestocklocation.Checked)
            {
                num2 = 1;
            }
            if (this.rdb_sr_estimateprgtojob.Checked)
            {
                str3 = "e";
            }
            else if (this.rdb_sr_jobconvertedinvoice.Checked)
            {
                str3 = "c";
            }
            else if (this.rdb_sr_jobstatus.Checked)
            {
                str3 = "j";
                num3 = Convert.ToInt32(this.ddlstkreduction.SelectedItem.Value);
            }
            else if (this.rdoStockReductionScanFile.Checked)
            {
                str3 = "s";
            }
            if (this.rdbaddstockback.Checked)
            {
                str4 = "a";
            }
            else if (this.rdbdontaddstockback.Checked)
            {
                str4 = "d";
            }
            else if (this.rdbpromptuser.Checked)
            {
                str4 = "p";
            }
           
            //Added by Amin
            if (this.rdbstkreplenishtxt.Checked)
            {
                str5 = "s";
                if (this.ddlreplenishstatus.SelectedIndex != -1)
                {
                    num5 = Convert.ToInt32(this.ddlreplenishstatus.SelectedItem.Value);
                }
            }
            else if (this.rdoStocReplenishScanFile.Checked)
            {
                str5 = "f";
            }

            WebstoreBasePage.stockmanagementsettings_update(str, num, str1, num1, str2, num2, str3, num3, str4, num4, this.CompanyID, this.UserID, num5, str5);
            this.getStockSettingDetails();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/settings/settings.aspx");
        }

        public void getStockSettingDetails()
        {
            int num = 0;
            DataTable dataTable = WebstoreBasePage.stockmanagementsettings_select(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["SA_EprintMISJobs"] != null && row["SA_EprintMISJobs"].ToString().ToLower() == "e")
                    {
                        this.rdbeprintjobprogressstojob.Checked = true;
                    }
                    if (row["SA_EstoreOrdersandJobs"] != null && row["SA_EstoreOrdersandJobs"].ToString().ToLower() == "p")
                    {
                        this.rdbestore_orderplaced.Checked = true;
                    }
                    if (row["SR_StockReductionMethod"] != null)
                    {
                        if (row["SR_StockReductionMethod"].ToString().ToLower() == "f")
                        {
                            this.rdbfifo.Checked = true;
                        }
                        else if (row["SR_StockReductionMethod"].ToString().ToLower() == "l")
                        {
                            this.rdblifo.Checked = true;
                        }
                    }
                    if (Convert.ToInt32(row["SR_IsStockPickFromSingleLoc"]) == 1)
                    {
                        this.chk_onestocklocation.Checked = true;
                    }
                    if (row["SR_WhenStockReduced"] != null)
                    {
                        if (row["SR_WhenStockReduced"].ToString().ToLower() == "e")
                        {
                            this.rdb_sr_estimateprgtojob.Checked = true;
                            this.rdb_sr_jobconvertedinvoice.Checked = false;
                            this.rdb_sr_jobstatus.Checked = false;
                            this.rdoStockReductionScanFile.Checked = false;
                        }
                        else if (row["SR_WhenStockReduced"].ToString().ToLower() == "c")
                        {
                            this.rdb_sr_jobconvertedinvoice.Checked = true;
                            this.rdb_sr_estimateprgtojob.Checked = false;
                            this.rdb_sr_jobstatus.Checked = false;
                            this.rdoStockReductionScanFile.Checked = false;
                        }
                        else if (row["SR_WhenStockReduced"].ToString().ToLower() == "j")
                        {
                            this.rdb_sr_jobstatus.Checked = true;
                            this.setddlval(this.ddlstkreduction, Convert.ToInt32(row["SR_JobStatusID"]));
                            this.rdb_sr_jobconvertedinvoice.Checked = false;
                            this.rdb_sr_estimateprgtojob.Checked = false;
                            this.rdoStockReductionScanFile.Checked = false;
                        }
                        else if (row["SR_WhenStockReduced"].ToString().ToLower() == "s")
                        {
                            this.rdb_sr_jobstatus.Checked = true;
                            this.setddlval(this.ddlstkreduction, Convert.ToInt32(row["SR_JobStatusID"]));
                            this.rdb_sr_jobconvertedinvoice.Checked = false;
                            this.rdb_sr_estimateprgtojob.Checked = false;
                            this.rdoStockReductionScanFile.Checked = true;

                        }
                    }
                    ///////////Added by Amin///////////
                    if (row["SA_WhenStockAdded"] != null)
                    {
                        if (row["SA_WhenStockAdded"].ToString().ToLower() == "f")//Scan file
                        {
                            this.rdoStocReplenishScanFile.Checked = true;
                            this.rdbstkreplenishtxt.Checked = false;
                            this.setddlval(this.ddlreplenishstatus, 0);
                        }

                        else if (row["SA_WhenStockAdded"].ToString().ToLower() == "s")//Status Change
                        {

                            // this.setddlval(this.ddlstkreduction, Convert.ToInt32(row["SR_JobStatusID"]));
                            if (row["Replenish_JobStatusID"] != null)
                            {
                                this.setddlval(this.ddlreplenishstatus, Convert.ToInt32(row["Replenish_JobStatusID"]));
                            }
                            this.rdoStocReplenishScanFile.Checked = false;
                            this.rdbstkreplenishtxt.Checked = true;


                        }
                    }
                    if (row["SC_IfJobCancelled"] != null)
                    {
                        if (row["SC_IfJobCancelled"].ToString().ToLower() == "a")
                        {
                            this.rdbaddstockback.Checked = true;
                            this.rdbdontaddstockback.Checked = false;
                            this.rdbpromptuser.Checked = false;
                        }
                        else if (row["SC_IfJobCancelled"].ToString().ToLower() == "d")
                        {
                            this.rdbdontaddstockback.Checked = true;
                            this.rdbaddstockback.Checked = false;
                            this.rdbpromptuser.Checked = false;
                        }
                        else if (row["SC_IfJobCancelled"].ToString().ToLower() == "p")
                        {
                            this.rdbpromptuser.Checked = true;
                            this.rdbaddstockback.Checked = false;
                            this.rdbdontaddstockback.Checked = false;
                        }
                    }
                    //if (row["Replenish_JobStatusID"] != null)
                    //{
                    //    this.setddlval(this.ddlreplenishstatus, Convert.ToInt32(row["Replenish_JobStatusID"]));
                    //}
                    num = Convert.ToInt32(row["StatusMessage"]);
                }
            }
            if (num != 1)
            {
                this.btn_Save.Enabled = true;
                return;
            }
            this.btn_Save.Attributes.Add("style", "cursor:not-allowed");
            this.btn_Save.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.rdbeprintjobprogressstojob.Text = this.objLanguage.GetLanguageConversion("Estimate_is_progressed_to_a_Job");
            this.rdbestore_orderplaced.Text = this.objLanguage.GetLanguageConversion("An_eStore_orderis_Placed");
            this.rdbfifo.Text = this.objLanguage.GetLanguageConversion("FIFO");
            this.rdblifo.Text = this.objLanguage.GetLanguageConversion("LIFO");
            this.chk_onestocklocation.Text = this.objLanguage.GetLanguageConversion("Pick_the_stock_from_one_location");
            this.rdb_sr_estimateprgtojob.Text = this.objLanguage.GetLanguageConversion("Estimate_or_eStore_Order_is_progressed_to_a_Job");
            this.rdb_sr_jobconvertedinvoice.Text = this.objLanguage.GetLanguageConversion("Job_is_Converted_to_an_Invoice");
            this.rdb_sr_jobstatus.Text = this.objLanguage.GetLanguageConversion("Job_Status_changes_to");
            this.rdbaddstockback.Text = this.objLanguage.GetLanguageConversion("Add_Stock_back_to_the_product");
            this.rdbdontaddstockback.Text = this.objLanguage.GetLanguageConversion("Do_Not_Add_Stock_Back");
            this.rdbpromptuser.Text = this.objLanguage.GetLanguageConversion("Prompt_User_To_Decide_If_Stock_Should_Be_Added_Back_To_The_System");
            this.btn_Cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save_Lock");
            this.rdbstkreplenishtxt.Text = this.objLanguage.GetLanguageConversion("Job_Status_changes_to");
            this.lblstkreplenishtxt.Text = this.objLanguage.GetLanguageConversion("Stock_is_Replenished_When");
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Stock_Management"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), "&nbsp;&nbsp;");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = global.pageTitle("Stock Reduction", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Stock_Management");
            if (!base.IsPostBack)
            {
                this.obj.Bind_Status_new(this.ddlstkreduction, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                this.obj.Bind_Status_new(this.ddlreplenishstatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                this.getStockSettingDetails();
            }
        }

        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
    }
}