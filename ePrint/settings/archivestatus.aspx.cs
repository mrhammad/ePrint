using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
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
    public partial class archivestatus : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessageNew;

        //protected UpdatePanel UPMessageNew;

        //protected Label lblEstimate;

        //protected Label lblEstEvent_1;

        //protected Label lblEstEvent_2;

        //protected Label lblEstEvent_3;

        //protected CheckBox chkEst2;

        //protected CheckBox chkEst3;

        //protected DropDownList ddlEst1;

        //protected DropDownList ddlEst2;

        //protected Label lblOrder;

        //protected Label Label2;

        //protected Label Label3;

        //protected Label Label4;

        //protected CheckBox chkorder2;

        //protected CheckBox chkorder3;

        //protected DropDownList ddlorder1;

        //protected DropDownList ddlorder2;

        //protected Label lblJob;

        //protected Label lblJobEvent_1;

        //protected Label lblJobEvent_2;

        //protected CheckBox chkJob2;

        //protected DropDownList ddlJob1;

        //protected DropDownList ddlJob2;

        //protected Label lblInvoice;

        //protected Label lblInvEvent_1;

        //protected Label lblInvEvent_2;

        //protected Label lblInvEvent_3;

        //protected CheckBox chkInv2;

        //protected CheckBox chkInv3;

        //protected DropDownList ddlInvoice1;

        //protected DropDownList ddlInvoice2;

        //protected DropDownList ddlInvoice3;

        //protected Label lblPurchase;

        //protected Label lblPurchaseEvent_1;

        //protected Label lblPurchaseEvent_2;

        //protected Label lblPurchaseEvent_3;

        //protected Label lblPurchaseEvent_4;

        //protected CheckBox chkPur2;

        //protected CheckBox chkPur3;

        //protected CheckBox chkPur4;

        //protected DropDownList ddlPurchase1;

        //protected DropDownList ddlPurchase2;

        //protected DropDownList ddlPurchase3;

        //protected DropDownList ddlPurchase4;

        //protected Label lblDelivery;

        //protected Label lblDeliveryEvent_1;

        //protected Label lblDeliveryEvent_2;

        //protected CheckBox chkDeli2;

        //protected DropDownList ddlDelivery1;

        //protected DropDownList ddlDelivery2;

        //protected Button btnSave;

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        private BasePage objPage = new BasePage();

        private BaseClass objBC = new BaseClass();

        public string sitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public DataTable dtstatus_def = new DataTable();

        public languageClass objLanguage = new languageClass();

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

        public archivestatus()
        {
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            long num = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            int num1 = 0;
            foreach (DataRow row in SettingsBasePage.ArchiveStatus_Edit((long)this.CompanyID).Rows)
            {
                if (row["Event"].ToString() == "Archive_Estimate")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlEst1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Estimate_Progress_to_job")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkEst2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlEst2.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Prompt_User_To_Archive_Estimate")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkEst3.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, (long)0, num1);
                }
                if (row["Event"].ToString() == "Archive_Job")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlJob1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Job_Progress_to_Invoice")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkJob2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlJob2.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Archive_Invoice")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlInvoice1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Mark_Invoice_Paid")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkInv2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlInvoice2.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Export_Invoice_to_Accounting")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkInv3.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlInvoice3.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Archive_Purchase")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlPurchase1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Mark_Invoice_Received")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkPur2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlPurchase2.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Mark_Goods_Received")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkPur3.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlPurchase3.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Export_Purchase_to_Accounting")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkPur4.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlPurchase4.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Archive_Delivery_Note")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlDelivery1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Mark_Goods_Delivered")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkDeli2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlDelivery2.SelectedValue), num1);
                }
                if (row["Event"].ToString() == "Archive_Order")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlorder1.SelectedValue), 0);
                }
                if (row["Event"].ToString() == "Order_Progress_Job")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    num1 = (!this.chkorder2.Checked ? 0 : 1);
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, (long)Convert.ToInt16(this.ddlorder2.SelectedValue), num1);
                }

                if (row["Event"].ToString() == "Lock Job")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlLock.SelectedValue), 0);
                }

                if (row["Event"].ToString() == "UnLock Job")
                {
                    empty = row["Module"].ToString();
                    str = row["Event"].ToString();
                    num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                    SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, Convert.ToInt64(this.ddlUnlock.SelectedValue), 0);
                }

                if (row["Event"].ToString() != "Prompt_User_To_Archive_Order")
                {
                    continue;
                }
                empty = row["Module"].ToString();
                str = row["Event"].ToString();
                num = Convert.ToInt64(row["ArchiveStatusID"].ToString());
                num1 = (!this.chkorder3.Checked ? 0 : 1);
                SettingsBasePage.ArchiveStatus_Update(Convert.ToInt64(this.Session["CompanyID"].ToString()), num, empty, str, (long)0, num1);
            }
            this.objBC.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Update");
            this.btnSave.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnSaveprocess');");
            global.pageName = "setting";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Archive_Status")));
            base.Title = global.pageTitle("Archive Status", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Archive_Status");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string empty = string.Empty;
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_new(this.ddlEst1, this.CompanyID, "Do Nothing", "estimate");
                this.objSet.Bind_Status_new(this.ddlEst2, this.CompanyID, "Do Nothing", "estimate");
                this.objSet.Bind_Status_new(this.ddlorder1, this.CompanyID, "Do Nothing", "webstoreorder");
                this.objSet.Bind_Status_new(this.ddlorder2, this.CompanyID, "Do Nothing", "webstoreorder");
                this.objSet.Bind_Status_new(this.ddlJob1, this.CompanyID, "Do Nothing", "job");
                this.objSet.Bind_Status_new(this.ddlJob2, this.CompanyID, "Do Nothing", "job");
                this.objSet.Bind_Status_new(this.ddlInvoice1, this.CompanyID, "Do Nothing", "invoice");
                this.objSet.Bind_Status_new(this.ddlInvoice2, this.CompanyID, "Do Nothing", "invoice");
                this.objSet.Bind_Status_new(this.ddlInvoice3, this.CompanyID, "Do Nothing", "invoice");
                this.objSet.Bind_Status_new(this.ddlPurchase1, this.CompanyID, "Do Nothing", "purchase");
                this.objSet.Bind_Status_new(this.ddlPurchase2, this.CompanyID, "Do Nothing", "purchase");
                this.objSet.Bind_Status_new(this.ddlPurchase3, this.CompanyID, "Do Nothing", "purchase");
                this.objSet.Bind_Status_new(this.ddlPurchase4, this.CompanyID, "Do Nothing", "purchase");
                this.objSet.Bind_Status_new(this.ddlDelivery1, this.CompanyID, "Do Nothing", "delivery");
                this.objSet.Bind_Status_new(this.ddlDelivery2, this.CompanyID, "Do Nothing", "delivery");
                this.objSet.Bind_Status_new(this.ddlLock, this.CompanyID, "Not Enabled", "job");
                this.objSet.Bind_Status_new(this.ddlUnlock, this.CompanyID, "Not Enabled", "job");

                (new BaseClass()).SetDDLText(this.ddlInvoice2, "Locked");
            }
            BaseClass baseClass = new BaseClass();
            this.lblEstimate.Text = base.SpecialDecode(baseClass.ReturnScreenName("ESTIMATES", 2, "p"));
            this.lblOrder.Text = base.SpecialDecode(baseClass.ReturnScreenName("WEBSTOREORDER", 2, "p"));
            this.lblJob.Text = base.SpecialDecode(baseClass.ReturnScreenName("JOBS", 2, "p"));
            this.lblInvoice.Text = base.SpecialDecode(baseClass.ReturnScreenName("INVOICES", 2, "p"));
            this.lblPurchase.Text = base.SpecialDecode(baseClass.ReturnScreenName("PURCHASES", 2, "p"));
            this.lblDelivery.Text = base.SpecialDecode(baseClass.ReturnScreenName("DELIVERYNOTE", 2, "p"));
            DataTable dataTable = SettingsBasePage.ArchiveStatus_Edit((long)this.CompanyID);
            if (!base.IsPostBack)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Event"].ToString() == "Estimate_Progress_to_job")
                    {
                        this.chkEst2.Checked = true;
                    }
                    if (row["Event"].ToString() == "Job_Progress_to_Invoice")
                    {
                        this.chkJob2.Checked = true;
                    }
                    if (row["Event"].ToString() == "Order_Progress_Job")
                    {
                        this.chkorder2.Checked = true;
                    }
                    if (row["Event"].ToString() == "Prompt_User_To_Archive_Estimate")
                    {
                        this.chkEst3.Checked = true;
                    }
                    if (row["Event"].ToString() == "Prompt_User_To_Archive_Order")
                    {
                        this.chkorder3.Checked = true;
                    }
                    if (row["StatusID"].ToString() != null)
                    {
                        if (row["Event"].ToString() == "Archive_Estimate")
                        {
                            this.ddlEst1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Estimate_Progress_to_job")
                        {
                            this.ddlEst2.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Archive_Job")
                        {
                            this.ddlJob1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Job_Progress_to_Invoice")
                        {
                            this.ddlJob2.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Archive_Invoice")
                        {
                            this.ddlInvoice1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Paid")
                        {
                            this.ddlInvoice2.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Export_Invoice_to_Accounting")
                        {
                            this.ddlInvoice3.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Archive_Purchase")
                        {
                            this.ddlPurchase1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Received")
                        {
                            this.ddlPurchase2.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Received")
                        {
                            this.ddlPurchase3.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Export_Purchase_to_Accounting")
                        {
                            this.ddlPurchase4.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Archive_Delivery_Note")
                        {
                            this.ddlDelivery1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Delivered")
                        {
                            this.ddlDelivery2.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Archive_Order")
                        {
                            this.ddlorder1.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "Order_Progress_Job")
                        {
                            this.ddlorder2.SelectedValue = row["StatusID"].ToString();
                        }

                        if (row["Event"].ToString() == "Lock Job")
                        {
                            this.ddlLock.SelectedValue = row["StatusID"].ToString();
                        }
                        if (row["Event"].ToString() == "UnLock Job")
                        {
                            this.ddlUnlock.SelectedValue = row["StatusID"].ToString();
                        }

                    }
                    if (row["IsArchive"].ToString().ToLower() != "true")
                    {
                        if (row["Event"].ToString() == "Estimate_Progress_to_job")
                        {
                            this.chkEst2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Job_Progress_to_Invoice")
                        {
                            this.chkJob2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Paid")
                        {
                            this.chkInv2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Export_Invoice_to_Accounting")
                        {
                            this.chkInv3.Checked = false;
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Received")
                        {
                            this.chkPur2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Received")
                        {
                            this.chkPur3.Checked = false;
                        }
                        if (row["Event"].ToString() == "Export_Purchase_to_Accounting")
                        {
                            this.chkPur4.Checked = false;
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Delivered")
                        {
                            this.chkDeli2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Order_Progress_Job")
                        {
                            this.chkorder2.Checked = false;
                        }
                        if (row["Event"].ToString() == "Prompt_User_To_Archive_Estimate")
                        {
                            this.chkEst3.Checked = false;
                        }
                        if (row["Event"].ToString() != "Prompt_User_To_Archive_Order")
                        {
                            continue;
                        }
                        this.chkorder3.Checked = false;
                    }
                    else
                    {
                        if (row["Event"].ToString() == "Estimate_Progress_to_job")
                        {
                            this.chkEst2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Job_Progress_to_Invoice")
                        {
                            this.chkJob2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Paid")
                        {
                            this.chkInv2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Export_Invoice_to_Accounting")
                        {
                            this.chkInv3.Checked = true;
                        }
                        if (row["Event"].ToString() == "Mark_Invoice_Received")
                        {
                            this.chkPur2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Received")
                        {
                            this.chkPur3.Checked = true;
                        }
                        if (row["Event"].ToString() == "Export_Purchase_to_Accounting")
                        {
                            this.chkPur4.Checked = true;
                        }
                        if (row["Event"].ToString() == "Mark_Goods_Delivered")
                        {
                            this.chkDeli2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Order_Progress_Job")
                        {
                            this.chkorder2.Checked = true;
                        }
                        if (row["Event"].ToString() == "Prompt_User_To_Archive_Estimate")
                        {
                            this.chkEst3.Checked = true;
                        }
                        if (row["Event"].ToString() != "Prompt_User_To_Archive_Order")
                        {
                            continue;
                        }
                        this.chkorder3.Checked = true;
                    }
                }
            }
        }
    }
}