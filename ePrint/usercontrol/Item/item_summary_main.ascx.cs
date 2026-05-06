using ePrint.usercontrol.settings;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Services;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_main : UsercontrolBasePage
    {
        //protected usercontrol_settings_Loading ucLoading;

        //protected HiddenField hdnaccordionIndex;

        //protected HiddenField hdnIsProducttype;

        //protected HiddenField hdnIsinventoryBack;

        //protected HiddenField hdndeleteparm;

        //protected HiddenField hdnPrntEstItmIDs;

        //protected ScriptManagerProxy SMproxy;

        //protected notes UCActivityHistory;

        //protected UpdatePanel UpdatePanel1;

        //protected Button Rdbtn_CopyEstimate;

        //protected DropDownList ddlCopyEstimate;

        //protected PlaceHolder plhcrmbuttons;

        //protected HtmlTable tblforCrm;

        //protected HtmlGenericControl div_forCrm;

        //protected Label lbl_EstimateNo;

        //protected PlaceHolder plhMessage;

        //protected Label lblUpdateMsg;

        //protected UpdatePanel UPMessage;

        //protected itemsummary_moreoptions ucMore;

        //protected Label lblText;

        //protected Label LblCompanyName;

        //protected Label lblEstNoText;

        //protected Label lblEstJobInvNo;

        //protected HtmlGenericControl divstatus;

        //protected HiddenField hdnReduceStockTypeForCancelled;

        //protected HiddenField hdn_SelectedStatusID;

        //protected Label lblStatusTitle;

        //protected Image imgArrow;

        //protected HtmlGenericControl ddlStatus;

        //protected PlaceHolder plhStatusList;

        //protected HtmlGenericControl Div_StatusList;

        //protected PlaceHolder plhdetailsqicklinks;

        //protected PlaceHolder plhCustomerInfo;

        //public PlaceHolder plhItems;

        //protected HiddenField hdnItems;

        //protected HiddenField hdnPCPath;

        //protected HtmlGenericControl divSupplierQuote;

        //protected RadWindowManager RadWindowManager1;

        //protected PlaceHolder plhProgressToJob;

        //protected PlaceHolder plhProgressToInvoice;

        //protected PlaceHolder plhRaisePO;

        //protected PlaceHolder Plh_PrintandEmail;

        //protected Item_Summary_CopytoNew_SameCustomer UCItemSummaryCopy;

        //protected HiddenField hid_OtherCostValues_Load;

        //protected HiddenField hid_EstimateItemID;

        //protected HiddenField hid_EstimateType;

        //protected HiddenField hid_PressID;

        //protected HiddenField hid_PaperID;

        //protected HiddenField hid_GuillotineID;

        //protected HiddenField hid_OtherCostValuesFromTB;

        //protected HiddenField hdnOtherCostValues;

        //protected HiddenField hdnEditOtherCostValues;

        //protected HiddenField hid_BookletSectionID;

        //protected HiddenField hdn_IsOthercostsavedFromPopUp;

        //protected HiddenField hdnOtherCostSequenceIDs;

        //protected HiddenField hdnItemDescs;

        //protected HiddenField hdnHieght;

        //protected HiddenField hdn_EstItemIDforPODEL_Delete;

        //protected HiddenField hdn_ImgClosebtn;

        //protected ImageButton ImageButton1;

        //protected RadioButton rdb_Delete_Invoice;

        //protected RadioButton rdb_Delete_Invoice_All;

        //protected Button btn_Delete_Invoice;

        //protected Button btn_Delete_Cancel;

        //protected Label lbl_note;

        //protected RadioButton rdb_Delete_Job;

        //protected RadioButton rdb_Delete_Job_All;

        //protected Button btn_Delete_JOb;

        //protected Button btn_cancel;

        //protected ImageButton ImageButton2;

        //protected Label lbl_PODEL_Delete_Note;

        //protected CheckBox Chk_DeletePO;

        //protected CheckBox Chk_DeleteDN;

        //protected Button btn_DeletePODEL;

        //protected HtmlGenericControl revert2;

        private SummaryClass summry = new SummaryClass();

        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public int RowsCount;

        public long jobID;

        public long InvoiceID;

        public long ProofID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string Module_Type = string.Empty;

        public long ParentEstimateItemID;

        public long EstimateItemID;

        public string pg = string.Empty;

        public string Module = string.Empty;

        public string Pgtype = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string ParentEstimateType = string.Empty;

        public string EstimateType = string.Empty;

        public string MainType = string.Empty;

        public bool Check_SpecialPrivilege;

        public string RedirectPath = string.Empty;

        private string Div_Content = string.Empty;

        private string Div_ShowContent = string.Empty;

        private string Div_HideContent = string.Empty;

        public string Div_Content_first = string.Empty;

        public string EsttypeName = string.Empty;

        private EstimatesItem EstItem = new EstimatesItem();

        private commonClass commclass = new commonClass();

        public decimal SubTotal;

        public string StrSubTotal = string.Empty;

        public long ViewEstItemID;

        private bool falg = true;

        public long EstItemID_BKN;

        public bool IsShowDelete;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        private string EstStatus = string.Empty;

        public string Isfromactivityhist = string.Empty;

        public int CustomerID;

        public string pagename = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int MainItemCnt;

        public string cpyItm = string.Empty;

        public languageClass objLangClass = new languageClass();

        public long EstimateItemID_ForSave;

        public string SalesPersonID = string.Empty;

        public string IDs = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string tab = string.Empty;

        public string StockCancellationType = string.Empty;

        public int ManageStockPermission;

        public string IsFromActHist = string.Empty;

        public string IsEditOnlyHisRecords = string.Empty;

        private int OrderConvertedToJob;

        private int EstimateConvertedToJob;

        public string sectionid = string.Empty;

        public string companytype = string.Empty;

        private string jobconvertedtoinvoice = string.Empty;

        public string MainItemNumber = string.Empty;

        public int OrderItemApprovalStatus;

        public long CartOrdrItemID;

        public string IsFromeStore = string.Empty;

        public bool IsApprovalFeaturesOn;

        public int BackOrder;

        public int StockProduct;

        private DataTable dtIsReplenish = new DataTable();

        private bool ISdrwastockFrom;

        public long JobItemStatusID;

        public Boolean EstimateItemsLocked;

        public string EstimateItems;

        //item_summary_main _item = null;

        //UsercontrolBasePage _base = new UsercontrolBasePage();
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

        public item_summary_main()
        {

        }

        //public item_summary_main(item_summary_main _item)
        //{
        //    _item = this;
        //    //_base = (UsercontrolBasePage)base;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            item_summary_total module = (item_summary_total)base.LoadControl("~/usercontrol/Item/item_summary_total.ascx");
            module.modulename = this.modulename;
            module.submodulename = this.submodulename;
            module.Module = this.Module;
            module.CompanyID = this.CompanyID;
            module.UserID = this.UserID;
            string[] strArrays = ((Button)sender).ID.Split(new char[] { '\u005F' });
            string str = string.Concat("hdnMainSaveValues_", Convert.ToInt64(strArrays[0]));
            HiddenField hiddenField = (HiddenField)this.plhItems.FindControl(str);
            string[] strArrays1 = this.hdnItemDescs.Value.Split(new char[] { '~' });
            EstimatesBasePage.SaveQtyDescription(Convert.ToInt64(strArrays[0]), strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), this.CompanyID);
            HiddenField hiddenField1 = (HiddenField)this.plhItems.FindControl(string.Concat("hdnItemDescription_", Convert.ToInt64(strArrays[0])));
            string value = hiddenField.Value;
            module.SaveClick("save", value, this.jID, this.InvID, hiddenField1.Value);
        }

        private void btnSaveStay_Click(object sender, EventArgs e)
        {
            item_summary_total module = (item_summary_total)base.LoadControl("~/usercontrol/Item/item_summary_total.ascx");
            module.modulename = this.modulename;
            module.submodulename = this.submodulename;
            module.Module = this.Module;
            module.CompanyID = this.CompanyID;
            module.UserID = this.UserID;
            string[] strArrays = ((Button)sender).ID.Split(new char[] { '\u005F' });
            string str = string.Concat("hdnMainSaveValues_", Convert.ToInt64(strArrays[0]));
            HiddenField hiddenField = (HiddenField)this.plhItems.FindControl(str);
            string[] strArrays1 = this.hdnItemDescs.Value.Split(new char[] { '~' });
            EstimatesBasePage.SaveQtyDescription(Convert.ToInt64(strArrays[0]), strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), this.CompanyID);
            HiddenField hiddenField1 = (HiddenField)this.plhItems.FindControl(string.Concat("hdnItemDescription_", Convert.ToInt64(strArrays[0])));
            string value = hiddenField.Value;
            module.SaveClick("save&stay", value, this.jID, this.InvID, hiddenField1.Value);
        }

        protected void Message_Display(string strMsg, string cssclass, PlaceHolder plh)
        {
            plh.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/message_display.ascx");
            plh.Controls.Add(userControl);
            Timer timer = (Timer)userControl.FindControl("TimerMessage");
            Label label = (Label)userControl.FindControl("lblMessage");
            ((Panel)userControl.FindControl("pnlMessage")).CssClass = cssclass;
            label.Text = strMsg;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            object[] estimateID;
            string[] languageConversion;
            MasterPage master = this.Parent.Page.Master;
            HtmlControl htmlControl = (HtmlControl)master.FindControl("DivLeftpanel");
            ((HtmlTableCell)master.FindControl("tdLeftpanel")).Visible = false;
            htmlControl.Visible = false;
            BaseClass baseClass = new BaseClass();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.lbl_note.Text = this.objLanguage.GetLanguageConversion("By_deleteing_the_job_its_corresponding_invoice_will_be_deleted");
            this.lbl_PODEL_Delete_Note.Text = this.objLanguage.GetLanguageConversion("Please_select_below_option_for_deleting_Purchase_Order_and_DeliveryNote");
            this.btn_DeletePODEL.Text = this.objLanguage.GetLanguageConversion("Continue");
            this.Chk_DeletePO.Text = this.objLangClass.GetLanguageConversion("Delete_POs_Related_to_this_Job");
            this.Chk_DeleteDN.Text = this.objLangClass.GetLanguageConversion("Delete_Delivery_notes_Related_to_this_Job");





            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hdnIsSortingAllowed.Value = Convert.ToString(row["AllowSorting"]).ToLower();
            }
            if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
            {
                this.rdb_Delete_Job_All.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_its_corresponding_Estimate_Estimate_Item");
                this.rdb_Delete_Job.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_keep_Estimate_live");
            }
            else
            {
                this.rdb_Delete_Job_All.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_its_corresponding_Order_Item");
                this.rdb_Delete_Job.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_keep_Order_live");
            }
            if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
            {
                this.rdb_Delete_Invoice_All.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_its_corresponding_Estimate_Job");
                this.rdb_Delete_Invoice.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_keep_Job_Estimate_live");
            }
            else
            {
                this.rdb_Delete_Job_All.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_its_corresponding_Order");
                this.rdb_Delete_Job.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_keep_Order_live");
            }
            if (base.Request.Browser.Browser.ToString().ToLower() == "firefox")
            {
                this.Div_StatusList.Attributes.Add("style", "width: 223px; padding: 0px; margin-top: -2px;");
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            this.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            this.StockCancellationType = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
            base.Session["TemplateHTML"] = null;
            base.Session["TemplateControlList"] = null;
            base.Session["TemplateTable"] = null;
            base.Session["isSplit"] = null;
            base.Session["TemplateID"] = null;
            base.Session["TempNameLastCounter"] = null;
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.QueryString["ProofID"] != null)
            {
                this.ProofID = Convert.ToInt64(base.Request.Params["ProofID"]);
            }

            if (base.Request.QueryString["Module_Type"] != null)
            {
                this.Module_Type = base.Request.Params["Module_Type"].ToString();
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.Params["acthist"] != null)
            {
                this.IsFromActHist = base.Request.Params["acthist"].ToString();
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString().ToLower() == "copitem")
                {
                    this.cpyItm = base.Request.Params["suc"].ToString();
                }
                if (base.Request.Params["acthist"] != null)
                {
                    this.Isfromactivityhist = base.Request.Params["acthist"].ToString();
                    this.pagename = base.Request.QueryString["pagename"].ToString().ToLower();
                }
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "subdel")
                    {
                        this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Additional_Item_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                else if (base.Request.Params["frmcopyitem"] != null && base.Request.Params["frmcopyitem"].ToString().ToLower() == "yes")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("New_Item_Copied_Successfully"), "msg-success", this.plhMessage);
                }
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                this.Pgtype = "job";
                this.modulename = "jobs";
                this.submodulename = "job";
                this.gloobj.setpagename("job");
                this.pg = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
                this.Pgtype = "invoice";
                this.modulename = "invoice";
                this.submodulename = "invoice";
                this.gloobj.setpagename("invoice");
                this.pg = "invoice";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate"))
            {
                this.Module = "estimate";
                this.Pgtype = "estimate";
                this.modulename = "estimates";
                this.submodulename = "estimate";
                this.gloobj.setpagename("estimate");
                this.pg = "estimate";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.Module = "order";
                this.Pgtype = "order";
                this.modulename = "orders";
                this.submodulename = "order";
                this.gloobj.setpagename("order");
                this.pg = "order";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("proofs/proof"))
            {
                this.Module = "proof";
                this.Pgtype = "proof";
                this.modulename = "proofs";
                this.submodulename = "proof";
                this.gloobj.setpagename("proof");
                this.pg = "proof";
            }
            this.ViewEstItemID = (long)0;
            if (!base.IsPostBack && base.Request.Params["suc"] != null)
            {
                if (base.Request.Params["suc"].ToString().ToLower() == "cop" && this.Module.ToLower() == "estimate")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Estimate_Copied_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["suc"].ToString().ToLower() == "cop" && this.Module.ToLower() == "order")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Order_Copied_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["suc"].ToString().ToLower() == "copj")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Job_Copied_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["suc"].ToString().ToLower() == "copi")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Invoice_Copied_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "copn")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Estimate_Copied_To_New_Customer_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "copjn")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Job_Copied_To_New_Customer_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "copin")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Invoice_Copied_To_New_Customer_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "del")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Item_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "subdel")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Additional_Item_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "stae")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Estimate_Status_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "staj")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Job_Status_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "stai")
                {
                    this.objBC.Message_Display(this.objLangClass.GetLanguageConversion("Invoice_Status_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                if (base.Request.Params["suc"].ToString().ToLower() == "copitem")
                {
                    this.Message_Display(this.objLangClass.GetLanguageConversion("Item_Copied_Successfully"), "msg-success", this.plhMessage);
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "myscript", "MessageDisplay();", true);
                }
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.Params["maintype"] != null)
            {
                this.MainType = base.Request.Params["maintype"].ToString();
            }
            this.RedirectPath = string.Concat(this.strSitepath, this.modulename, "/", this.submodulename);
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
            {
                this.IsFromeStore = "yes";
            }
            else
            {
                this.IsFromeStore = "no";
            }
            this.Check_SpecialPrivilege = false;
            string empty = string.Empty;
            //if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "true")
            if (this.objBase.ReturnRoles_Privileges_Others("isspecialprivilege").ToLower() == "true")
            {
                this.Check_SpecialPrivilege = true;
            }
            else
            {
                this.Check_SpecialPrivilege = false;
            }
            this.plhItems.Controls.Clear();
            item_summary_quicklinks userID = (item_summary_quicklinks)base.LoadControl("~/usercontrol/Item/item_summary_quicklinks.ascx");
            userID.ID = "custdetails_quickLinks";
            userID.UserID = this.UserID;
            userID.CompanyID = this.CompanyID;
            userID.EstimateID = this.EstimateID;
            userID.jobID = this.jobID;
            userID.InvoiceID = this.InvoiceID;
            userID.jID = this.jID;
            userID.InvID = this.InvID;
            userID.quicklinksfrom = "customer details";

            this.plhdetailsqicklinks.Controls.Add(userID);
            Item_Summary_CustomerDetails usercontrolItemItemSummaryCustomerDetail = (Item_Summary_CustomerDetails)base.LoadControl("~/usercontrol/Item/Item_Summary_CustomerDetails.ascx");
            if (this.Module != "invoice")
            {
                usercontrolItemItemSummaryCustomerDetail.ID = string.Concat("UcCustomerDetail_", this.EstimateID);
            }
            else
            {
                usercontrolItemItemSummaryCustomerDetail.ID = string.Concat("UcCustomerDetail_", 0);
            }
            this.plhCustomerInfo.Controls.Add(usercontrolItemItemSummaryCustomerDetail);
            DataTable dataTable1 = new DataTable();
            if (this.Module == "job")
            {
                dataTable1 = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "job");
            }
            else if(this.Module == "proof")
            {
                dataTable1 = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "proof");
            }
            else if (this.Module != "invoice")
            {
                dataTable1 = (this.Module != "order" ? SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "estimate") : SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "webstoreorder"));
            }
            else
            {
                dataTable1 = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "invoice");
            }
            string str = string.Empty;
            long invoiceID = (long)0;
            if (this.Module.ToLower() != "job")
            {
                invoiceID = (this.Module.ToLower() != "invoice" ? this.EstimateID : this.InvoiceID);
            }
            else
            {
                str = this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
                this.dtIsReplenish = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, this.jobID, (long)0, "job");
                foreach (DataRow row in this.dtIsReplenish.Rows)
                {
                    if (row["DrawStockFrom"].ToString().ToLower() != "s")
                    {
                        continue;
                    }
                    this.ISdrwastockFrom = true;
                    break;
                }
                invoiceID = this.jobID;
            }
            this.plhStatusList.Controls.Add(new LiteralControl("<table>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<tr>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                long num = Convert.ToInt64(dataRow["StatusID"]);
                string str1 = dataRow["StatusTitle"].ToString();
                string colorcode = dataRow["StatusColorCode"].ToString();
                string str2 = str1.Replace(" ", "ยง");
                str2 = this.objBase.SpecialEncode(str2);
                if (!this.ISdrwastockFrom || !(str == num.ToString()))
                {
                    ControlCollection controls = this.plhStatusList.Controls;
                    if (this.Module.ToLower() != "proof")
                    {
                        estimateID = new object[] { "<a style='color: Black; background-color:", colorcode, " !important; ' href='#' onclick=javascript:EstJobInvStatusSave(", num, ",'", str2, "',", invoiceID, "); >", this.objBase.SpecialDecode(str1), "</a>" };
                    }
                    else
                    {
                        estimateID = new object[] { "<a style='color: Black;background-color:", colorcode, " !important; ' href='#' onclick=javascript:ProofStatusSave(", num, ",'", str2, "',", this.ProofID, "); >", this.objBase.SpecialDecode(str1), "</a>" };
                    }
                    controls.Add(new LiteralControl(string.Concat(estimateID)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhStatusList.Controls;
                    estimateID = new object[] { "<a style='color: Black;background-color:", colorcode, " !important; ' href='#' onclick=javascript:OpenReplenishAllocationPopUp(", this.EstimateID, ",", invoiceID, ",", 0, ",", num.ToString(), "); >", this.objBase.SpecialDecode(str1), "</a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(estimateID)));
                }
            }
            this.plhStatusList.Controls.Add(new LiteralControl("</div>"));
            this.plhStatusList.Controls.Add(new LiteralControl("</tr>"));
            this.plhStatusList.Controls.Add(new LiteralControl("</td>"));
            this.plhStatusList.Controls.Add(new LiteralControl("</table>"));
            if (this.EstimateID != (long)0)
            {
                foreach (DataRow row1 in EstimatesBasePage.EstimateitemIDList_PerEstID(this.EstimateID).Rows)
                {
                    this.IDs = string.Concat(this.IDs, row1["EstimateItemID"].ToString(), ",");
                }
                foreach (DataRow dataRow1 in EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                {
                    this.CustomerID = Convert.ToInt32(dataRow1["CustomerID"].ToString());
                }
                if (this.Isfromactivityhist.ToLower() == "yes")
                {
                    this.div_forCrm.Style.Add("display", "block");
                    this.ddlStatus.Attributes.Add("disabled", "disabled");
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    if (this.Module.ToLower() == "estimate")
                    {
                        estimateID = new object[] { "<a href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.CustomerID, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstimateID, "' target='_blank'><span class='button'>Print/Email</span></a>" };
                        empty1 = string.Concat(estimateID);
                        estimateID = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='_blank'><span class='button'>Go to Estimate Summary</span></a>" };
                        empty2 = string.Concat(estimateID);
                    }
                    else if (this.Module.ToLower() == "job")
                    {
                        this.Rdbtn_CopyEstimate.Text = "Copy Job";
                        estimateID = new object[] { "<a href='", this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.CustomerID, "&sectionname=Job&type=Customer&page=Job&EstID=", this.EstimateID, "' target='_blank'><span class='button'>Print/Email</span></a>" };
                        empty1 = string.Concat(estimateID);
                        string empty3 = string.Empty;
                        if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "true")
                        {
                            estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='_blank'><span class='button'>Go to Job Summary</span></a>" };
                            empty2 = string.Concat(estimateID);
                        }
                    }
                    else if (this.Module.ToLower() == "invoice")
                    {
                        this.Rdbtn_CopyEstimate.Text = "Copy Invoice";
                        estimateID = new object[] { "<a href='", this.strSitepath, "invoice/templates_view1.aspx?sectionid=", this.CustomerID, "&sectionname=Invoice&type=Customer&page=Invoice&EstID=", this.EstimateID, "' target='_blank'><span class='button'>Print/Email</span></a>" };
                        empty1 = string.Concat(estimateID);
                        string str3 = string.Empty;
                        if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() == "true")
                        {
                            estimateID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='_blank'><span class='button'>Go to Invoice Summary</span></a>" };
                            empty2 = string.Concat(estimateID);
                        }
                    }
                    else if (this.Module.ToLower() == "order")
                    {
                        this.Rdbtn_CopyEstimate.Text = "Copy Order";
                    }
                    string empty4 = string.Empty;
                    baseClass.ReturnRoles_Privileges_ForGrid("clients", "printoremail", this.Page.Request.Url.ToString());
                    string str4 = baseClass.ReturnRoles_Privileges_ForGrid("clients", "printoremail", this.Page.Request.Url.ToString());
                    string str5 = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isview", this.Page.Request.Url.ToString());
                    this.plhcrmbuttons.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    if (str4 != "0" && str4 != "2")
                    {
                        this.plhcrmbuttons.Controls.Add(new LiteralControl(empty1));
                    }
                    this.plhcrmbuttons.Controls.Add(new LiteralControl("</div>"));
                    this.plhcrmbuttons.Controls.Add(new LiteralControl("<div style='float: left; padding-left:15px;'>"));
                    if (str5.Trim().ToLower() == "true")
                    {
                        this.plhcrmbuttons.Controls.Add(new LiteralControl(empty2));
                    }
                    this.plhcrmbuttons.Controls.Add(new LiteralControl("</div>"));
                }
            }
            if (this.Module.ToLower() == "job")
            {
                foreach (DataRow row2 in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.jobID).Rows)
                {
                    this.lblEstNoText.Text = string.Concat(this.objLangClass.GetLanguageConversion("Job_Number"), ":");
                    this.lblEstJobInvNo.Text = this.objBase.SpecialDecode(row2["JobNumber"].ToString());
                    this.EstStatus = row2["Status"].ToString();
                    this.lblStatusTitle.Text = this.objBase.SpecialDecode(row2["jobstatus"].ToString());
                    if (this.lblStatusTitle.Text.Length > 25)
                    {
                        this.lblStatusTitle.Text = this.lblStatusTitle.Text;
                    }
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(row2["clientName"].ToString());
                    this.SalesPersonID = row2["SalesPerson"].ToString();
                    if (this.LblCompanyName.Text.Length <= 25)
                    {
                        continue;
                    }
                    this.LblCompanyName.Text = this.LblCompanyName.Text;
                }
            }
            if (this.Module.ToLower() == "estimate")
            {
                foreach (DataRow dataRow2 in EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                {
                    this.lblEstNoText.Text = string.Concat(this.objLangClass.GetLanguageConversion("Estimate_Number"), ":");
                    this.lblEstJobInvNo.Text = dataRow2["EstimateNumber"].ToString();
                    this.EstStatus = dataRow2["StatusTitle"].ToString();
                    this.lblStatusTitle.Text = this.objBase.SpecialDecode(dataRow2["StatusTitle"].ToString());
                    if (this.lblStatusTitle.Text.Length > 25)
                    {
                        this.lblStatusTitle.Text = this.lblStatusTitle.Text;
                    }
                    this.SalesPersonID = dataRow2["SalesPerson"].ToString();
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(dataRow2["clientName"].ToString());
                    if (this.LblCompanyName.Text.Length <= 25)
                    {
                        continue;
                    }
                    this.LblCompanyName.Text = this.LblCompanyName.Text;
                }
            }
            if (this.Module.ToLower() == "invoice")
            {
                foreach (DataRow row3 in InvoiceBasePage.Invoice_Select_By_InvoiceID(this.CompanyID, this.InvoiceID).Rows)
                {
                    this.lblEstNoText.Text = string.Concat(this.objLangClass.GetLanguageConversion("Invoice_Number"), ":");
                    this.lblEstJobInvNo.Text = row3["InvoiceNumber"].ToString();
                    this.EstStatus = row3["Status"].ToString();
                    this.lblStatusTitle.Text = this.objBase.SpecialDecode(row3["Status"].ToString());
                    if (this.lblStatusTitle.Text.Length > 25)
                    {
                        this.lblStatusTitle.Text = this.lblStatusTitle.Text;
                    }
                    this.SalesPersonID = row3["SalesPerson"].ToString();
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(row3["clientName"].ToString());
                    if (this.LblCompanyName.Text.Length <= 25)
                    {
                        continue;
                    }
                    this.LblCompanyName.Text = this.LblCompanyName.Text;
                }
            }
            if (this.Module.ToLower() == "order")
            {
                foreach (DataRow dataRow3 in EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                {
                    this.lblEstNoText.Text = string.Concat(this.objLangClass.GetLanguageConversion("Order_Number"), ":");
                    this.lblEstJobInvNo.Text = dataRow3["SystemOrderNumber"].ToString();
                    this.EstStatus = dataRow3["StatusTitle"].ToString();
                    this.lblStatusTitle.Text = this.objBase.SpecialDecode(dataRow3["StatusTitle"].ToString());
                    if (this.lblStatusTitle.Text.Length > 25)
                    {
                        this.lblStatusTitle.Text = this.lblStatusTitle.Text;
                    }
                    this.SalesPersonID = dataRow3["SalesPerson"].ToString();
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(dataRow3["clientName"].ToString());
                    if (this.LblCompanyName.Text.Length <= 25)
                    {
                        continue;
                    }
                    this.LblCompanyName.Text = this.LblCompanyName.Text;
                }
            }
            if (this.Module.ToLower() == "proof")
            {
                foreach (DataRow dataRow2 in EstimatesBasePage.PC_Proof_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                {
                    this.lblEstNoText.Text = "Proof Number";
                    this.lblEstJobInvNo.Text = dataRow2["ProofNumber"].ToString();
                    this.EstStatus = dataRow2["StatusTitle"].ToString();
                    this.lblStatusTitle.Text = this.objBase.SpecialDecode(dataRow2["StatusTitle"].ToString());
                    if (this.lblStatusTitle.Text.Length > 25)
                    {
                        this.lblStatusTitle.Text = this.lblStatusTitle.Text;
                    }
                    this.SalesPersonID = dataRow2["SalesPerson"].ToString();
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(dataRow2["clientName"].ToString());
                    if (this.LblCompanyName.Text.Length <= 25)
                    {
                        continue;
                    }
                    this.LblCompanyName.Text = this.LblCompanyName.Text;
                }
            }
            string empty5 = string.Empty;
            long num1 = (long)0;
            string empty6 = string.Empty;
            DataTable dataTable2 = new DataTable();
            if (this.Pgtype == "estimate")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);
            }
            else if (this.Pgtype == "job")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng_ByJob(this.CompanyID, this.jobID, this.Pgtype);

            }
            else if (this.Pgtype == "invoice")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng_ByInvoice(this.CompanyID, this.InvoiceID, this.Pgtype);
            }
            else if (this.Pgtype == "order")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);
            }
            else if (this.Pgtype == "proof")
            {
                dataTable2 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.ProofID, this.Pgtype);
            }
            this.RowsCount = dataTable2.Rows.Count;
            string str6 = "";
            string str7 = "";
            if (this.RowsCount == 1)
            {
                this.IsShowDelete = true;
                str6 = " style='min-height: 32px;' ";
                str7 = " padding-top: 10px; ";
            }
            int num2 = 1;
            this.hdnaccordionIndex.Value = "0";
            int num3 = 0;
            long num4 = (long)0;

            foreach (DataRow row4 in dataTable2.Rows)
            {
                if (Convert.ToInt64(row4["JOBID"]) <= (long)0)
                {
                    this.IsShowJobReRun = false;
                }
                else
                {
                    this.IsShowJobReRun = true;
                }
                if (Convert.ToInt64(row4["InvoiceID"]) <= (long)0)
                {
                    this.IsShowInvRerun = false;
                }
                else
                {
                    this.IsShowInvRerun = true;
                }
                this.ParentEstimateItemID = (long)Convert.ToInt32(row4["EstimateItemID"]);

                this.hdnPrntEstItmIDs.Value = string.Concat(this.hdnPrntEstItmIDs.Value, this.ParentEstimateItemID, "ยง");
                EstimateItems = string.Concat(EstimateItems, this.ParentEstimateItemID, "ยง");
                if (num3 == 0)
                {
                    this.CartOrdrItemID = this.ParentEstimateItemID;
                }
                if (base.Request.QueryString["EstItemID"] == null)
                {
                    this.hdnaccordionIndex.Value = "0";
                }
                else if (Convert.ToInt64(base.Request.QueryString["EstItemID"]) == this.ParentEstimateItemID)
                {
                    this.hdnaccordionIndex.Value = num2.ToString();
                }
                num2++;
                this.ParentEstimateType = row4["EstimateType"].ToString();
                int num5 = Convert.ToInt32(row4["QtyCount"]);
                bool flag = Convert.ToBoolean(row4["IsParentItem"]);
                int num6 = Convert.ToInt32(row4["SectionCount"]);
                string str8 = this.objBase.SpecialDecode(row4["ItemTitle"].ToString());
                try
                {
                    int num7 = Convert.ToInt32(row4["TotalQty1"]);
                    empty5 = num7.ToString();
                    num4 = num4 + (long)Convert.ToInt32(row4["TotalQty1"].ToString());
                    base.Session["Ordered_Quantity"] = num4;
                    if (empty5 == "0")
                    {
                        empty5 = "n/a";
                    }
                }
                catch
                {
                }
                try
                {
                    this.SubTotal = Convert.ToDecimal(row4["TotalSubTotal1"]);
                }
                catch
                {
                }
                if (this.modulename.ToLower() == "estimates")
                {
                    this.MainItemNumber = row4["EstimateItemNumber"].ToString();
                }
                else if (this.modulename.ToLower() == "proofs")
                {
                    this.MainItemNumber = row4["ProofItemNumber"].ToString();
                }
                else if (this.modulename.ToLower() == "jobs")
                {
                    this.MainItemNumber = row4["JobItemNumber"].ToString();
                    this.BackOrder = Convert.ToInt32(row4["BackOrder"]);
                    this.StockProduct = Convert.ToInt32(row4["IsStockProduct"]); ///////Modification by Bilal warehouse stage 1
                }
                else if (this.modulename.ToLower() != "orders")
                {
                    this.MainItemNumber = row4["InvoiceItemNumber"].ToString();
                    //this.MainItemNumber = row4["JobItemNumber"].ToString();
                    this.BackOrder = Convert.ToInt32(row4["BackOrder"]);
                    this.StockProduct = Convert.ToInt32(row4["IsStockProduct"]); ///////Modification by Bilal warehouse stage 1
                }
                else
                {
                    this.MainItemNumber = row4["OrderItemNumber"].ToString();
                    this.BackOrder = Convert.ToInt32(row4["BackOrder"]);
                    this.StockProduct = Convert.ToInt32(row4["IsStockProduct"]);
                }
                DataTable dataTable3 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
                foreach (DataRow dataRow4 in dataTable3.Rows)
                {
                    if (dataRow4["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                    {
                        this.IsApprovalFeaturesOn = true;
                    }
                    else
                    {
                        this.IsApprovalFeaturesOn = false;
                    }
                }
                string empty7 = string.Empty;
                if (this.Pgtype == "order")
                {
                    num1 = Convert.ToInt64(row4["ApproveStatus"]);
                    this.EstimateType = row4["EstimateType"].ToString();
                    if (num1 == (long)0)
                    {
                        empty6 = "Awaiting Approval";
                        empty7 = "orange";
                    }
                    if (num1 == (long)1)
                    {
                        empty6 = "Approved";
                        empty7 = "green";
                    }
                    if (num1 == (long)2)
                    {
                        empty6 = " Rejected";
                        empty7 = "red";
                    }
                }
                this.OrderItemApprovalStatus = OrderBasePage.OrderItemApprovalStatus_Select(this.ParentEstimateItemID);
                Loading usercontrolSettingsLoading = (Loading)base.LoadControl("~/usercontrol/settings/Loading.ascx");
                usercontrolSettingsLoading.ID = string.Concat("UCLoadingControl_", this.ParentEstimateItemID);
                this.StrSubTotal = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.SubTotal, 0, "", false, false, true, false, false), true);
                int num8 = 0;
                string empty8 = string.Empty;
                empty8 = "style = 'display: none;'";
                if (this.ParentEstimateType == "S")
                {
                    this.EsttypeName = "Sheet Fed Digital: Single";
                }
                if (this.ParentEstimateType == "P")
                {
                    this.EsttypeName = "Sheet Fed Digital: Pad";
                }
                if (this.ParentEstimateType == "B")
                {
                    this.EsttypeName = "Sheet Fed Digital: Booklet";
                }
                if (this.ParentEstimateType == "R")
                {
                    this.EsttypeName = "Sheet Fed Digital: NCR";
                }
                if (this.ParentEstimateType == "F")
                {
                    this.EsttypeName = "Sheet Fed Offset: Single";
                }
                if (this.ParentEstimateType == "K")
                {
                    this.EsttypeName = "Sheet Fed Offset: Booklet";
                }
                if (this.ParentEstimateType == "N")
                {
                    this.EsttypeName = "Sheet Fed Offset: NCR";
                }
                if (this.ParentEstimateType == "D")
                {
                    this.EsttypeName = "Sheet Fed Offset: Pad";
                }
                if (this.ParentEstimateType == "L")
                {
                    this.EsttypeName = "Large Format";
                }
                if (this.ParentEstimateType == "C")
                {
                    this.EsttypeName = "Product Catalogue";
                }
                if (this.ParentEstimateType == "O")
                {
                    this.EsttypeName = "Outwork";
                }
                if (this.ParentEstimateType == "U")
                {
                    this.EsttypeName = this.objLanguage.GetLanguageConversion("Other_Cost");
                }
                if (this.ParentEstimateType == "W")
                {
                    this.EsttypeName = this.objLanguage.GetLanguageConversion("Inventory");
                }
                if (this.ParentEstimateType == "Q")
                {
                    this.EsttypeName = "Quick Quote";
                }
                if (this.ParentEstimateType == "T")
                {
                    this.EsttypeName = "Delivery Cost";
                }
                if (this.ParentEstimateType == "X")
                {
                    this.EsttypeName = "Order";
                }
                if (this.Module.ToLower() == "job" || this.Module.ToLower() == "invoice")
                {
                    num8 = JobsBasePage.job_quantity_number_select(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
                }
                if (this.Module.ToLower() == "order")
                {
                    num8 = 1;
                }
                if (this.Module.ToLower() == "proof")
                {
                    num8 = 1;
                }
                this.Div_Content = string.Concat("Div_Content_", this.ParentEstimateItemID);
                this.Div_ShowContent = string.Concat("Div_ShowContent_", this.ParentEstimateItemID);
                this.Div_HideContent = string.Concat("Div_HideContent_", this.ParentEstimateItemID);
                this.plhItems.Controls.Add(new LiteralControl("<div class='sortingdivs' style='width:100%;margin-top:5px' data-number='" + Convert.ToInt32(row4["Estimate_Item_Number"]) + "' id='" + this.ParentEstimateItemID + "' data-value='sortable'>"));
                ControlCollection controls1 = this.plhItems.Controls;
                languageConversion = new string[] { "<h3 class='sortingdivs' data-number='" + Convert.ToInt32(row4["Estimate_Item_Number"]) + "' id='" + this.ParentEstimateItemID + "' data-value='sortable' ", str6, "><a style='border-bottom-width:0px; ", str7, "' href='#'>" };
                controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0'  border='0' width='100%' >"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td style='width: 185px;'>"));
                ControlCollection controlCollections1 = this.plhItems.Controls;
                estimateID = new object[] { "<label id='lblItem_Number", this.ParentEstimateItemID, "' value='", this.MainItemNumber, "' class='HeaderText'>", this.MainItemNumber, "</label>" };
                controlCollections1.Add(new LiteralControl(string.Concat(estimateID)));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("<td style='width: 26%;'>"));
                if (this.BackOrder == 1 && this.StockProduct == 1)
                {
                    ControlCollection controls2 = this.plhItems.Controls;
                    estimateID = new object[] { "<label id='lblHeaderPanelTitle_", this.ParentEstimateItemID, "' class='HeaderText' style='word-break: break-word;'>", str8, "</label><span class='HeaderText' ></span><span class='HeaderText' >&nbsp;(Stock Back Order) </span>" };
                    controls2.Add(new LiteralControl(string.Concat(estimateID)));
                }
                else if (this.StockProduct != 1)
                {
                    ControlCollection controlCollections2 = this.plhItems.Controls;
                    estimateID = new object[] { "<label id='lblHeaderPanelTitle_", this.ParentEstimateItemID, "' class='HeaderText' style='word-break: break-word;'>", str8, "</label><span class='HeaderText' ></span><span class='HeaderText' >&nbsp;(", this.EsttypeName, ") </span>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(estimateID)));
                }
                else
                {
                    ControlCollection controls3 = this.plhItems.Controls;
                    estimateID = new object[] { "<label id='lblHeaderPanelTitle_", this.ParentEstimateItemID, "' class='HeaderText' style='word-break: break-word;'>", str8, "</label><span class='HeaderText' ></span><span class='HeaderText' >&nbsp;(Stock Order) </span>" };
                    controls3.Add(new LiteralControl(string.Concat(estimateID)));
                }
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("<td align='left'>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='float:left; width:170px;'>"));
                ControlCollection controlCollections3 = this.plhItems.Controls;
                languageConversion = new string[] { "<span class='HeaderText' style='vertical-align: top'>", this.objLangClass.GetLanguageConversion("Quantity1"), ":</span>&nbsp;<span style='vertical-align: top; white-space:nowrap;'> ", empty5, "</span>" };
                controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));

                if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false" && (this.Module.ToLower() != "proof"))
                {
                    this.plhItems.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                }

                else
                {
                    this.plhItems.Controls.Add(new LiteralControl("<div style='float:left;display:none;'>"));

                }
                ControlCollection controls4 = this.plhItems.Controls;
                languageConversion = new string[] { "<span class='HeaderText' style='vertical-align: top'>", this.objLangClass.GetLanguageConversion("Sub_Total"), ":</span>&nbsp;<span style='vertical-align: top'>", this.StrSubTotal, "</span>" };
                controls4.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                if (this.IsApprovalFeaturesOn && (this.EstimateType == "X" || this.EstimateType == "T") && base.Request.Url.ToString().ToLower().Contains("orders/order"))
                {
                    this.plhItems.Controls.Add(new LiteralControl("<td style='width: 188px;'>"));
                    ControlCollection controlCollections4 = this.plhItems.Controls;
                    estimateID = new object[] { "<label id='ApprovalStatus", this.ParentEstimateItemID, "' value='", this.MainItemNumber, "' class='HeaderText' style='color: ", empty7, ";'>", empty6, "</label>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(estimateID)));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhItems.Controls.Add(new LiteralControl("<td align='left' style='width: 251px;'>"));
                string empty9 = string.Empty;
                empty9 = this.objBase.SpecialDecode(row4["ItemStatusTitle"].ToString());
                string str9 = "";
                if (this.RowsCount == 1)
                {
                    str9 = "display: none;";
                }
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span id='spnStatusItems' style='", str9, "'>")));
                ControlCollection controls5 = this.plhItems.Controls;
                var IsDescriptionStatus = false;
                if (this.Module.ToLower() == "job")
                {
                    invoiceID = this.jobID;
                    var locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                    var IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    string status = SettingsBasePage.PC_select_ProductEditingOption_Status(CompanyID);
                    var ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                    if (IsJobLocked == true && ignorelocking != "true" && (status == "LockEditingDescStatus"))
                    {
                        IsDescriptionStatus = true;
                        this.ddlStatus.Attributes.Remove("onmouseover");
                        this.ddlStatus.Attributes.Remove("onmouseout");
                    }
                    if (IsJobLocked == true && ignorelocking != "true")
                    {
                        EstimateItemsLocked = true;
                    }

                }

                estimateID = new object[] { "<div id='ddlItemStaus_", this.ParentEstimateItemID, "' class='btnstyle' style='width:208px;float:left; padding-top:4px; text-align: left;overflow: hidden;white-space: nowrap;' onmouseover='javascript:OpenItemStatus(", this.ParentEstimateItemID, "); return false;' onmouseout='javascript:CloseItemStatus(", this.ParentEstimateItemID, "); return false;'>" };
                controls5.Add(new LiteralControl(string.Concat(estimateID)));

                this.plhItems.Controls.Add(new LiteralControl("<div style='width: 185px;  overflow: hidden; white-space:nowrap; float: left;'>"));
                ControlCollection controlCollections5 = this.plhItems.Controls;
                estimateID = new object[] { "<label id='lblItemStatus_", this.ParentEstimateItemID, "' value='", empty9, "' style='font-size:12px;'>", empty9, "</label>" };
                controlCollections5.Add(new LiteralControl(string.Concat(estimateID)));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='float: right; padding-top: 5px'>"));
                this.plhItems.Controls.Add(new LiteralControl("<img id='img' src='../images/down_arrow.png'/>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                if (this.OrderItemApprovalStatus != 1 || IsDescriptionStatus)
                {
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='divItemStatusList_", this.ParentEstimateItemID, "'></div>")));
                }
                else
                {
                    string str10 = "margin-top:26px;";
                    if (base.Request.Browser.Browser.ToString().ToLower() == "firefox" || base.Request.UserAgent.ToLower().Contains("safari") && !base.Request.UserAgent.ToLower().Contains("chrome"))
                    {
                        str10 = "margin-top:25px;";
                    }
                    ControlCollection controls6 = this.plhItems.Controls;
                    estimateID = new object[] { "<div id='divItemStatusList_", this.ParentEstimateItemID, "' onmouseover='javascript:OpenItemStatus(", this.ParentEstimateItemID, "); return false;' onmouseout='javascript:CloseItemStatus(", this.ParentEstimateItemID, "); return false;'   style='width: 223px; ", str10, " padding:0px;' class='Div_AccountList'>" };
                    controls6.Add(new LiteralControl(string.Concat(estimateID)));
                    this.plhItems.Controls.Add(new LiteralControl("<table>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
                    foreach (DataRow row5 in dataTable1.Rows)
                    {
                        string str11 = row5["StatusTitle"].ToString();
                        string str12 = str11.Replace(" ", "ยง");
                        str12 = this.objBase.SpecialEncode(str12);
                        ControlCollection controlCollections6 = this.plhItems.Controls;
                        if (this.Module.ToLower() == "proof")
                        {
                            estimateID = new object[] { "<a style='color: Black' href='#' onclick =javascript:ProofItemStatuS_Update(", Convert.ToInt64(row5["StatusID"]), ",", this.ParentEstimateItemID, ",'", str12, "','", this.ProofID, "'); >", this.objBase.SpecialDecode(row5["StatusTitle"].ToString()), "</a>" };
                            controlCollections6.Add(new LiteralControl(string.Concat(estimateID)));
                        }
                        else if (!(this.Module.ToLower() == "job") || !Convert.ToBoolean(row4["IsStockReplenishItem"].ToString()) || Convert.ToBoolean(row4["IsStockReplenished"].ToString()) || !(row4["DrawStockFrom"].ToString().ToLower() == "s") || this.dtIsReplenish.Rows.Count <= 0 || !(str == row5["StatusID"].ToString()))
                        {
                            estimateID = new object[] { "<a style='color: Black' href='#' onclick =javascript:EstJobInvIduvidualItemStatuS_Update(", Convert.ToInt64(row5["StatusID"]), ",", this.ParentEstimateItemID, ",'", str12, "'); >", this.objBase.SpecialDecode(row5["StatusTitle"].ToString()), "</a>" };
                            controlCollections6.Add(new LiteralControl(string.Concat(estimateID)));
                        }
                        else
                        {
                            ControlCollection controls7 = this.plhItems.Controls;
                            estimateID = new object[] { "<a style='color: Black' href='#' onclick =javascript:OpenReplenishAllocationPopUp(", this.EstimateID, ",", invoiceID, ",", this.ParentEstimateItemID, ",", row5["StatusID"].ToString(), "); >", this.objBase.SpecialDecode(row5["StatusTitle"].ToString()), "</a>" };
                            controls7.Add(new LiteralControl(string.Concat(estimateID)));
                        }
                    }
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhItems.Controls.Add(new LiteralControl("</span>"));
                HiddenField hiddenField = this.hdnItems;
                hiddenField.Value = string.Concat(hiddenField.Value, this.ParentEstimateItemID, "@");
                string empty10 = string.Empty;
                string empty11 = string.Empty;
                if (this.Module == "job")
                {
                    if (row4["IsJobItemStatusLocked"].ToString().ToLower() != "true")
                    {
                        empty11 = "block";
                        empty10 = "none";
                    }
                    else
                    {
                        empty10 = "block";
                        empty11 = "none";
                    }
                }
                else if (this.Module == "invoice")
                {
                    if (row4["IsInvoiceItemStatusLocked"].ToString().ToLower() != "true")
                    {
                        empty11 = "block";
                        empty10 = "none";
                    }
                    else
                    {
                        empty10 = "block";
                        empty11 = "none";
                    }
                }
                else if (this.Module == "order")
                {
                    if (row4["IsItemStatusLocked"].ToString().ToLower() != "true")
                    {
                        empty11 = "block";
                        empty10 = "none";
                    }
                    else
                    {
                        empty10 = "block";
                        empty11 = "none";
                    }
                }
                else if (row4["IsItemStatusLocked"].ToString().ToLower() != "true")
                {
                    empty11 = "block";
                    empty10 = "none";
                }
                else
                {
                    empty10 = "block";
                    empty11 = "none";
                }
                if (this.Module != "proof")
                {
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; ", str9, "'>")));
                    this.plhItems.Controls.Add(new LiteralControl("<span id='spnStatusUnLock'>"));
                    ImageButton imageButton = new ImageButton()
                    {
                        ID = string.Concat("imgLockStatus_", this.ParentEstimateItemID),
                        ImageUrl = string.Concat(this.strImagepath, "lockclosed.png"),
                        ToolTip = "Click here to unlock Status"
                    };
                    imageButton.Attributes.Add("hieght", "20px");
                    imageButton.Attributes.Add("width", "20px");
                    imageButton.Style.Add("display", empty10);
                    estimateID = new object[] { "javascript:UnLockItemStatus('", this.ParentEstimateItemID, "','", this.Module, "')" };
                    imageButton.OnClientClick = string.Concat(estimateID);
                    this.plhItems.Controls.Add(imageButton);
                    this.plhItems.Controls.Add(new LiteralControl("</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; ", str9, "'>")));
                    this.plhItems.Controls.Add(new LiteralControl("<span id='spnStatusLock'>"));
                    ImageButton imageButton1 = new ImageButton()
                    {
                        ID = string.Concat("imgLockOpenStatus_", this.ParentEstimateItemID),
                        ImageUrl = string.Concat(this.strImagepath, "lockopen.png"),
                        ToolTip = "Click here to lock Status"
                    };
                    imageButton1.Attributes.Add("hieght", "20px");
                    imageButton1.Attributes.Add("width", "20px");
                    imageButton1.Style.Add("display", empty11);
                    HiddenField hiddenField1 = new HiddenField()
                    {
                        ID = string.Concat("hdnLock_", this.ParentEstimateItemID)
                    };
                    if (this.Module == "job")
                    {
                        hiddenField1.Value = row4["IsJobItemStatusLocked"].ToString();
                    }
                    else if (this.Module == "invoice")
                    {
                        hiddenField1.Value = row4["IsInvoiceItemStatusLocked"].ToString();
                    }
                    else if (this.Module != "order")
                    {
                        hiddenField1.Value = row4["IsItemStatusLocked"].ToString();
                    }
                    else
                    {
                        hiddenField1.Value = row4["IsItemStatusLocked"].ToString();
                    }
                    hiddenField1.Value = "false";
                    this.plhItems.Controls.Add(hiddenField1);
                    HiddenField hiddenField2 = new HiddenField()
                    {
                        ID = string.Concat("hdnapprovestatus_", this.ParentEstimateItemID),
                        Value = this.OrderItemApprovalStatus.ToString()
                    };
                    this.plhItems.Controls.Add(hiddenField2);
                    estimateID = new object[] { "javascript:LockItemStatus('", this.ParentEstimateItemID, "','", this.Module, "')" };
                    imageButton1.OnClientClick = string.Concat(estimateID);
                    if (this.OrderItemApprovalStatus == 1)
                    {
                        this.plhItems.Controls.Add(imageButton1);
                    }
                    this.plhItems.Controls.Add(new LiteralControl("</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
      
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</a></h3>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px;margin-top:-1px; overflow: hidden;'>"));
                ControlCollection controlCollections7 = this.plhItems.Controls;
                estimateID = new object[] { "<div id='overlay_", this.ParentEstimateItemID, "' class='web_dialog_overlay_Address' ", empty8, ">" };
                controlCollections7.Add(new LiteralControl(string.Concat(estimateID)));
                this.plhItems.Controls.Add(new LiteralControl("<div style='height:1%;'>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div  ", empty8, ">")));
                this.plhItems.Controls.Add(new LiteralControl("<span style='color: Lime; font-weight: bold; font-size: 12px; padding-left: 19%;'>Sent for Quote</span>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' width='100%' border='0'>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top'>"));
                if (this.ViewEstItemID == this.ParentEstimateItemID)
                {
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='Div_Content_BKN_", this.ParentEstimateItemID, "' style='display:block; border:0px solid red;'>")));
                }
                else
                {
                    this.ViewEstItemID = this.ParentEstimateItemID;
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='Div_Content_", this.ParentEstimateItemID, "' style='display:block; border:0px solid green; margin-bottom:-10px;'>")));
                }
                this.plhItems.Controls.Add(new LiteralControl("<div style='clear:both'/>"));
                this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' width='100%' border='0'>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='border-right:1px solid gray; min-width:170px; width:170px;  padding-bottom:32px; '>"));
                item_summary_quicklinks parentEstimateItemID = (item_summary_quicklinks)base.LoadControl("~/usercontrol/Item/item_summary_quicklinks.ascx");
                parentEstimateItemID.ID = string.Concat("itemdetails_quickLinks_", this.ParentEstimateItemID);
                parentEstimateItemID.ParentEstimateItemID = this.ParentEstimateItemID;
                parentEstimateItemID.UserID = this.UserID;
                parentEstimateItemID.CompanyID = this.CompanyID;
                parentEstimateItemID.EstimateID = this.EstimateID;
                parentEstimateItemID.jobID = this.jobID;
                parentEstimateItemID.InvoiceID = this.InvoiceID;
                parentEstimateItemID.jID = this.jID;
                parentEstimateItemID.InvID = this.InvID;
                parentEstimateItemID.IsFromActHist = this.IsFromActHist;
                parentEstimateItemID.ParentEstimateType = this.ParentEstimateType;
                parentEstimateItemID.ItemTitle = str8;
                parentEstimateItemID.IsShowDelete = this.IsShowDelete;
                parentEstimateItemID.IsShowJobReRun = this.IsShowJobReRun;
                parentEstimateItemID.IsShowInvRerun = this.IsShowInvRerun;
                parentEstimateItemID.IsEditOnlyHisRecords = this.IsEditOnlyHisRecords;
                parentEstimateItemID.SalesPersonID = this.SalesPersonID;
                parentEstimateItemID.Module = this.Module;
                parentEstimateItemID.modulename = this.modulename;
                parentEstimateItemID.submodulename = this.submodulename;
                parentEstimateItemID.ManageStockPermission = this.ManageStockPermission;
                parentEstimateItemID.JobItemStatusID = (long)Convert.ToInt32(row4["JobItemStatusID"]);
                parentEstimateItemID.quicklinksfrom = "item  details";
                parentEstimateItemID.OrderItemApprovalStatus = this.OrderItemApprovalStatus;

                this.plhItems.Controls.Add(parentEstimateItemID);
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='padding-left:20px;'>"));
                this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' width='100%' border='0'>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='width:100%; '>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<table cellpadding='0' cellspacing='0' id='tblMessage_", this.ParentEstimateItemID, "' align='right' border='0' width='63%' style='display:none;'>")));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' align='left' >"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<label id='lblMessage_", this.ParentEstimateItemID, "' class='msg-success'>Item updated successfully.</label>")));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='clear:both'/>"));
                if (this.ParentEstimateType == "S")
                {
                    item_summary_single_item parentEstimateType = (item_summary_single_item)base.LoadControl("~/usercontrol/Item/item_summary_single_item.ascx");
                    parentEstimateType.ID = string.Concat("UcDigitalSingleItem_", this.ParentEstimateItemID);
                    parentEstimateType.EstimateID = this.EstimateID;
                    parentEstimateType.EstimateItemID = this.ParentEstimateItemID;
                    parentEstimateType.EstType = this.ParentEstimateType;
                    parentEstimateType.Module = this.Module;
                    parentEstimateType.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    parentEstimateType.QtyCount = num5;
                    parentEstimateType.ParentEstimateItemID = this.ParentEstimateItemID;
                    parentEstimateType.ParentEstimateType = this.ParentEstimateType;
                    parentEstimateType.IsParentItem = flag;
                    parentEstimateType.ParentQtyCount = num5;
                    parentEstimateType.modulename = this.modulename;
                    parentEstimateType.submodulename = this.submodulename;
                    parentEstimateType.MainType = this.MainType;
                    parentEstimateType.QtyNumber = num8;
                    parentEstimateType.IsShowDelete = this.IsShowDelete;
                    parentEstimateType.IsShowJobReRun = this.IsShowJobReRun;
                    parentEstimateType.IsShowInvRerun = this.IsShowInvRerun;
                    parentEstimateType.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(parentEstimateType);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "P")
                {
                    item_summary_pad_item module = (item_summary_pad_item)base.LoadControl("~/usercontrol/Item/item_summary_pad_item.ascx");
                    module.ID = string.Concat("UcDigitalPadItem_", this.ParentEstimateItemID);
                    module.EstimateID = this.EstimateID;
                    module.EstimateItemID = this.ParentEstimateItemID;
                    module.EstType = this.ParentEstimateType;
                    module.Module = this.Module;
                    module.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    module.QtyCount = num5;
                    module.ParentEstimateItemID = this.ParentEstimateItemID;
                    module.ParentEstimateType = this.ParentEstimateType;
                    module.IsParentItem = flag;
                    module.ParentQtyCount = num5;
                    module.modulename = this.modulename;
                    module.submodulename = this.submodulename;
                    module.MainType = this.MainType;
                    module.QtyNumber = num8;
                    module.IsShowDelete = this.IsShowDelete;
                    module.IsShowJobReRun = this.IsShowJobReRun;
                    module.IsShowInvRerun = this.IsShowInvRerun;
                    module.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(module);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "B")
                {
                    item_summary_booklet_item checkSpecialPrivilege = (item_summary_booklet_item)base.LoadControl("~/usercontrol/Item/item_summary_booklet_item.ascx");
                    checkSpecialPrivilege.ID = string.Concat("UcDigitalBookletItem_", this.ParentEstimateItemID);
                    checkSpecialPrivilege.EstimateID = this.EstimateID;
                    checkSpecialPrivilege.EstimateItemID = this.ParentEstimateItemID;
                    checkSpecialPrivilege.EstType = this.ParentEstimateType;
                    checkSpecialPrivilege.Module = this.Module;
                    checkSpecialPrivilege.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    checkSpecialPrivilege.QtyCount = num5;
                    checkSpecialPrivilege.SectionCount = num6;
                    checkSpecialPrivilege.ParentEstimateItemID = this.ParentEstimateItemID;
                    checkSpecialPrivilege.ParentEstimateType = this.ParentEstimateType;
                    checkSpecialPrivilege.IsParentItem = flag;
                    checkSpecialPrivilege.ParentQtyCount = num5;
                    checkSpecialPrivilege.modulename = this.modulename;
                    checkSpecialPrivilege.submodulename = this.submodulename;
                    checkSpecialPrivilege.MainType = this.MainType;
                    checkSpecialPrivilege.QtyNumber = num8;
                    checkSpecialPrivilege.IsShowDelete = this.IsShowDelete;
                    checkSpecialPrivilege.IsShowJobReRun = this.IsShowJobReRun;
                    checkSpecialPrivilege.IsShowInvRerun = this.IsShowInvRerun;
                    checkSpecialPrivilege.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(checkSpecialPrivilege);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "R")
                {
                    item_summary_DigitalNCR_item salesPersonID = (item_summary_DigitalNCR_item)base.LoadControl("~/usercontrol/Item/item_summary_DigitalNCR_item.ascx");
                    salesPersonID.ID = string.Concat("UcDigitalNCRItem_", this.ParentEstimateItemID);
                    salesPersonID.EstimateID = this.EstimateID;
                    salesPersonID.EstimateItemID = this.ParentEstimateItemID;
                    salesPersonID.EstType = this.ParentEstimateType;
                    salesPersonID.Module = this.Module;
                    salesPersonID.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    salesPersonID.QtyCount = num5;
                    salesPersonID.SectionCount = num6;
                    salesPersonID.ParentEstimateItemID = this.ParentEstimateItemID;
                    salesPersonID.ParentEstimateType = this.ParentEstimateType;
                    salesPersonID.IsParentItem = flag;
                    salesPersonID.ParentQtyCount = num5;
                    salesPersonID.modulename = this.modulename;
                    salesPersonID.submodulename = this.submodulename;
                    salesPersonID.MainType = this.MainType;
                    salesPersonID.QtyNumber = num8;
                    salesPersonID.IsShowDelete = this.IsShowDelete;
                    salesPersonID.IsShowJobReRun = this.IsShowJobReRun;
                    salesPersonID.IsShowInvRerun = this.IsShowInvRerun;
                    salesPersonID.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(salesPersonID);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "L")
                {
                    item_summary_large_item mainType = (item_summary_large_item)base.LoadControl("~/usercontrol/Item/item_summary_large_item.ascx");
                    mainType.ID = string.Concat("UcDigitalLargeItem_", this.ParentEstimateItemID);
                    mainType.EstimateID = this.EstimateID;
                    mainType.EstimateItemID = this.ParentEstimateItemID;
                    mainType.EstType = this.ParentEstimateType;
                    mainType.Module = this.Module;
                    mainType.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    mainType.QtyCount = num5;
                    mainType.ParentEstimateItemID = this.ParentEstimateItemID;
                    mainType.ParentEstimateType = this.ParentEstimateType;
                    mainType.IsParentItem = flag;
                    mainType.ParentQtyCount = num5;
                    mainType.modulename = this.modulename;
                    mainType.submodulename = this.submodulename;
                    mainType.MainType = this.MainType;
                    mainType.QtyNumber = num8;
                    mainType.IsShowDelete = this.IsShowDelete;
                    mainType.IsShowJobReRun = this.IsShowJobReRun;
                    mainType.IsShowInvRerun = this.IsShowInvRerun;
                    mainType.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(mainType);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "F")
                {
                    item_summary_litho_single_item isShowDelete = (item_summary_litho_single_item)base.LoadControl("~/usercontrol/Item/item_summary_litho_single_item.ascx");
                    isShowDelete.ID = string.Concat("UcLithoSingleItem_", this.ParentEstimateItemID);
                    isShowDelete.EstimateID = this.EstimateID;
                    isShowDelete.EstimateItemID = this.ParentEstimateItemID;
                    isShowDelete.EstType = this.ParentEstimateType;
                    isShowDelete.Module = this.Module;
                    isShowDelete.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    isShowDelete.QtyCount = num5;
                    isShowDelete.ParentEstimateItemID = this.ParentEstimateItemID;
                    isShowDelete.ParentEstimateType = this.ParentEstimateType;
                    isShowDelete.IsParentItem = flag;
                    isShowDelete.ParentQtyCount = num5;
                    isShowDelete.modulename = this.modulename;
                    isShowDelete.submodulename = this.submodulename;
                    isShowDelete.MainType = this.MainType;
                    isShowDelete.QtyNumber = num8;
                    isShowDelete.IsShowDelete = this.IsShowDelete;
                    isShowDelete.IsShowJobReRun = this.IsShowJobReRun;
                    isShowDelete.IsShowInvRerun = this.IsShowInvRerun;
                    isShowDelete.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(isShowDelete);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "D")
                {
                    item_summary_litho_pad_item isShowJobReRun = (item_summary_litho_pad_item)base.LoadControl("~/usercontrol/Item/item_summary_litho_pad_item.ascx");
                    isShowJobReRun.ID = string.Concat("UcLithoPadItem_", this.ParentEstimateItemID);
                    isShowJobReRun.EstimateID = this.EstimateID;
                    isShowJobReRun.EstimateItemID = this.ParentEstimateItemID;
                    isShowJobReRun.EstType = this.ParentEstimateType;
                    isShowJobReRun.Module = this.Module;
                    isShowJobReRun.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    isShowJobReRun.QtyCount = num5;
                    isShowJobReRun.ParentEstimateItemID = this.ParentEstimateItemID;
                    isShowJobReRun.ParentEstimateType = this.ParentEstimateType;
                    isShowJobReRun.IsParentItem = flag;
                    isShowJobReRun.ParentQtyCount = num5;
                    isShowJobReRun.modulename = this.modulename;
                    isShowJobReRun.submodulename = this.submodulename;
                    isShowJobReRun.MainType = this.MainType;
                    isShowJobReRun.QtyNumber = num8;
                    isShowJobReRun.IsShowDelete = this.IsShowDelete;
                    isShowJobReRun.IsShowJobReRun = this.IsShowJobReRun;
                    isShowJobReRun.IsShowInvRerun = this.IsShowInvRerun;
                    isShowJobReRun.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(isShowJobReRun);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "K")
                {
                    item_summary_litho_booklet_item isShowInvRerun = (item_summary_litho_booklet_item)base.LoadControl("~/usercontrol/Item/item_summary_litho_booklet_item.ascx");
                    isShowInvRerun.ID = string.Concat("UcLithoBookletItem_", this.ParentEstimateItemID);
                    isShowInvRerun.EstimateID = this.EstimateID;
                    isShowInvRerun.EstimateItemID = this.ParentEstimateItemID;
                    isShowInvRerun.EstType = this.ParentEstimateType;
                    isShowInvRerun.Module = this.Module;
                    isShowInvRerun.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    isShowInvRerun.QtyCount = num5;
                    isShowInvRerun.SectionCount = num6;
                    isShowInvRerun.ParentEstimateItemID = this.ParentEstimateItemID;
                    isShowInvRerun.ParentEstimateType = this.ParentEstimateType;
                    isShowInvRerun.IsParentItem = flag;
                    isShowInvRerun.ParentQtyCount = num5;
                    isShowInvRerun.modulename = this.modulename;
                    isShowInvRerun.submodulename = this.submodulename;
                    isShowInvRerun.MainType = this.MainType;
                    isShowInvRerun.QtyNumber = num8;
                    isShowInvRerun.IsShowDelete = this.IsShowDelete;
                    isShowInvRerun.IsShowJobReRun = this.IsShowJobReRun;
                    isShowInvRerun.IsShowInvRerun = this.IsShowInvRerun;
                    isShowInvRerun.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(isShowInvRerun);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "N")
                {
                    item_summary_ncr_item salesPersonID = (item_summary_ncr_item)base.LoadControl("~/usercontrol/Item/item_summary_ncr_item.ascx");
                    salesPersonID.ID = string.Concat("UcLithoNCRItem_", this.ParentEstimateItemID);
                    salesPersonID.EstimateID = this.EstimateID;
                    salesPersonID.EstimateItemID = this.ParentEstimateItemID;
                    salesPersonID.EstType = this.ParentEstimateType;
                    salesPersonID.Module = this.Module;
                    salesPersonID.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    salesPersonID.QtyCount = num5;
                    salesPersonID.SectionCount = num6;
                    salesPersonID.ParentEstimateItemID = this.ParentEstimateItemID;
                    salesPersonID.ParentEstimateType = this.ParentEstimateType;
                    salesPersonID.IsParentItem = flag;
                    salesPersonID.ParentQtyCount = num5;
                    salesPersonID.modulename = this.modulename;
                    salesPersonID.submodulename = this.submodulename;
                    salesPersonID.MainType = this.MainType;
                    salesPersonID.QtyNumber = num8;
                    salesPersonID.IsShowDelete = this.IsShowDelete;
                    salesPersonID.IsShowJobReRun = this.IsShowJobReRun;
                    salesPersonID.IsShowInvRerun = this.IsShowInvRerun;
                    salesPersonID.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(salesPersonID);
                    this.hdnIsinventoryBack.Value = "true";
                }
                else if (this.ParentEstimateType == "W")
                {
                    item_summary_warehouse_item usercontrolItemItemSummaryWarehouseItem = (item_summary_warehouse_item)base.LoadControl("~/usercontrol/Item/item_summary_warehouse_item.ascx");
                    usercontrolItemItemSummaryWarehouseItem.ID = string.Concat("UcWarehouseItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryWarehouseItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryWarehouseItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryWarehouseItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryWarehouseItem.Module = this.Module;
                    usercontrolItemItemSummaryWarehouseItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryWarehouseItem.QtyCount = num5;
                    usercontrolItemItemSummaryWarehouseItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryWarehouseItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryWarehouseItem.IsParentItem = flag;
                    usercontrolItemItemSummaryWarehouseItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryWarehouseItem.modulename = this.modulename;
                    usercontrolItemItemSummaryWarehouseItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryWarehouseItem.MainType = this.MainType;
                    usercontrolItemItemSummaryWarehouseItem.QtyNumber = num8;
                    usercontrolItemItemSummaryWarehouseItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryWarehouseItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryWarehouseItem.IsShowInvRerun = this.IsShowInvRerun;
                    usercontrolItemItemSummaryWarehouseItem.SalesPersonID = this.SalesPersonID;
                    usercontrolItemItemSummaryWarehouseItem.jobID = jobID;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryWarehouseItem);
                }
                else if (this.ParentEstimateType == "Q")
                {
                    item_summary_quick_quote_item usercontrolItemItemSummaryQuickQuoteItem = (item_summary_quick_quote_item)base.LoadControl("~/usercontrol/Item/item_summary_quick_quote_item.ascx");
                    usercontrolItemItemSummaryQuickQuoteItem.ID = string.Concat("UcQuickQuoteItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryQuickQuoteItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryQuickQuoteItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryQuickQuoteItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryQuickQuoteItem.Module = this.Module;
                    usercontrolItemItemSummaryQuickQuoteItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryQuickQuoteItem.QtyCount = num5;
                    usercontrolItemItemSummaryQuickQuoteItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryQuickQuoteItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryQuickQuoteItem.IsParentItem = flag;
                    usercontrolItemItemSummaryQuickQuoteItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryQuickQuoteItem.modulename = this.modulename;
                    usercontrolItemItemSummaryQuickQuoteItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryQuickQuoteItem.MainType = this.MainType;
                    usercontrolItemItemSummaryQuickQuoteItem.QtyNumber = num8;
                    usercontrolItemItemSummaryQuickQuoteItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryQuickQuoteItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryQuickQuoteItem.IsShowInvRerun = this.IsShowInvRerun;
                    usercontrolItemItemSummaryQuickQuoteItem.jobID = jobID;
                    usercontrolItemItemSummaryQuickQuoteItem.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryQuickQuoteItem);
                }
                else if (this.ParentEstimateType == "T")
                {
                    item_summary_DeliveryCost_item usercontrolItemItemSummaryDeliveryCostItem = (item_summary_DeliveryCost_item)base.LoadControl("~/usercontrol/Item/item_summary_DeliveryCost_item.ascx");
                    usercontrolItemItemSummaryDeliveryCostItem.ID = string.Concat("UcDeliveryCostItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryDeliveryCostItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryDeliveryCostItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryDeliveryCostItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryDeliveryCostItem.Module = this.Module;
                    usercontrolItemItemSummaryDeliveryCostItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryDeliveryCostItem.QtyCount = num5;
                    usercontrolItemItemSummaryDeliveryCostItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryDeliveryCostItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryDeliveryCostItem.IsParentItem = flag;
                    usercontrolItemItemSummaryDeliveryCostItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryDeliveryCostItem.modulename = this.modulename;
                    usercontrolItemItemSummaryDeliveryCostItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryDeliveryCostItem.MainType = this.MainType;
                    usercontrolItemItemSummaryDeliveryCostItem.QtyNumber = num8;
                    usercontrolItemItemSummaryDeliveryCostItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryDeliveryCostItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryDeliveryCostItem.IsShowInvRerun = this.IsShowInvRerun;
                    usercontrolItemItemSummaryDeliveryCostItem.jobID = jobID;
                    usercontrolItemItemSummaryDeliveryCostItem.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryDeliveryCostItem);
                }
                else if (this.ParentEstimateType == "O")
                {
                    item_summary_outwork_item usercontrolItemItemSummaryOutworkItem = (item_summary_outwork_item)base.LoadControl("~/usercontrol/Item/item_summary_outwork_item.ascx");
                    usercontrolItemItemSummaryOutworkItem.ID = string.Concat("UcOutworkItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryOutworkItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryOutworkItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryOutworkItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryOutworkItem.Module = this.Module;
                    usercontrolItemItemSummaryOutworkItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryOutworkItem.QtyCount = num5;
                    usercontrolItemItemSummaryOutworkItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryOutworkItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryOutworkItem.IsParentItem = flag;
                    usercontrolItemItemSummaryOutworkItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryOutworkItem.modulename = this.modulename;
                    usercontrolItemItemSummaryOutworkItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryOutworkItem.MainType = this.MainType;
                    usercontrolItemItemSummaryOutworkItem.QtyNumber = num8;
                    usercontrolItemItemSummaryOutworkItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryOutworkItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryOutworkItem.IsShowInvRerun = this.IsShowInvRerun;
                    usercontrolItemItemSummaryOutworkItem.Count_Item = num3;
                    usercontrolItemItemSummaryOutworkItem.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryOutworkItem);
                    if (this.Module.ToLower() == "estimate" && base.Request.QueryString["tab"] != null && base.Request.QueryString["tab"] != "" && base.Request.QueryString["tab"].ToString() == "Q")
                    {
                        this.tab = "Q";
                    }
                    num3++;
                }
                else if (this.ParentEstimateType == "C")
                {
                    item_summary_pricecatalogue_item usercontrolItemItemSummaryPricecatalogueItem = (item_summary_pricecatalogue_item)base.LoadControl("~/usercontrol/Item/item_summary_pricecatalogue_item.ascx");
                    usercontrolItemItemSummaryPricecatalogueItem.ID = string.Concat("UcPriceCatalogueItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryPricecatalogueItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryPricecatalogueItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryPricecatalogueItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryPricecatalogueItem.Module = this.Module;
                    usercontrolItemItemSummaryPricecatalogueItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryPricecatalogueItem.QtyCount = num5;
                    usercontrolItemItemSummaryPricecatalogueItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryPricecatalogueItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryPricecatalogueItem.IsParentItem = flag;
                    usercontrolItemItemSummaryPricecatalogueItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryPricecatalogueItem.modulename = this.modulename;
                    usercontrolItemItemSummaryPricecatalogueItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryPricecatalogueItem.MainType = this.MainType;
                    usercontrolItemItemSummaryPricecatalogueItem.QtyNumber = num8;
                    usercontrolItemItemSummaryPricecatalogueItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryPricecatalogueItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryPricecatalogueItem.IsShowInvRerun = this.IsShowInvRerun;
                    usercontrolItemItemSummaryPricecatalogueItem.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryPricecatalogueItem);
                    this.hdnIsProducttype.Value = "true";
                }
                else if (this.ParentEstimateType == "U")
                {
                    item_summary_othercost_item usercontrolItemItemSummaryOthercostItem = (item_summary_othercost_item)base.LoadControl("~/usercontrol/Item/item_summary_othercost_item.ascx");
                    usercontrolItemItemSummaryOthercostItem.ID = string.Concat("UcOtherCostItem_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryOthercostItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryOthercostItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryOthercostItem.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryOthercostItem.Module = this.Module;
                    usercontrolItemItemSummaryOthercostItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryOthercostItem.QtyCount = num5;
                    usercontrolItemItemSummaryOthercostItem.ParentEstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryOthercostItem.ParentEstimateType = this.ParentEstimateType;
                    usercontrolItemItemSummaryOthercostItem.IsParentItem = flag;
                    usercontrolItemItemSummaryOthercostItem.ParentQtyCount = num5;
                    usercontrolItemItemSummaryOthercostItem.modulename = this.modulename;
                    usercontrolItemItemSummaryOthercostItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryOthercostItem.MainType = this.MainType;
                    usercontrolItemItemSummaryOthercostItem.QtyNumber = num8;
                    usercontrolItemItemSummaryOthercostItem.IsShowDelete = this.IsShowDelete;
                    usercontrolItemItemSummaryOthercostItem.IsShowJobReRun = this.IsShowJobReRun;
                    usercontrolItemItemSummaryOthercostItem.IsShowInvRerun = this.IsShowInvRerun;
                    this.plhItems.Controls.Add(usercontrolItemItemSummaryOthercostItem);
                }
                else if (this.ParentEstimateType.ToLower() == "x")
                {
                    item_summary_pricecatalogue_item estimateID1 = (item_summary_pricecatalogue_item)base.LoadControl("~/usercontrol/Item/item_summary_pricecatalogue_item.ascx");
                    estimateID1.ID = string.Concat("UcPriceCatalogueItem_", this.ParentEstimateItemID);
                    estimateID1.EstimateID = this.EstimateID;
                    estimateID1.EstimateItemID = this.ParentEstimateItemID;
                    estimateID1.EstType = this.ParentEstimateType;
                    estimateID1.Module = this.Module;
                    estimateID1.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    estimateID1.QtyCount = num5;
                    estimateID1.ParentEstimateItemID = this.ParentEstimateItemID;
                    estimateID1.ParentEstimateType = this.ParentEstimateType;
                    estimateID1.IsParentItem = flag;
                    estimateID1.ParentQtyCount = num5;
                    estimateID1.modulename = this.modulename;
                    estimateID1.submodulename = this.submodulename;
                    estimateID1.MainType = this.MainType;
                    estimateID1.QtyNumber = num8;
                    estimateID1.IsShowDelete = this.IsShowDelete;
                    estimateID1.IsShowJobReRun = this.IsShowJobReRun;
                    estimateID1.IsShowInvRerun = this.IsShowInvRerun;
                    estimateID1.SalesPersonID = this.SalesPersonID;
                    this.plhItems.Controls.Add(estimateID1);
                    this.hdnIsProducttype.Value = "true";
                }
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='width:100%;'>"));

                if (this.Module != "proof")
                {
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div align='left' id='div_SubItems_", this.ParentEstimateItemID, "' style='width: 100%; border:0px solid red; margin-top:2px; float:left;'  >")));
                DataTable dataTable4 = EstimatesBasePage.estimate_subitem_select(this.EstimateID, this.ParentEstimateItemID);
                if (dataTable4.Rows.Count > 0)
                {
                    this.plhItems.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='float: left; width:160px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<b>", this.objLangClass.GetLanguageConversion("Additional_Items"), "</b>")));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
                int num9 = 0;
                foreach (DataRow dataRow5 in dataTable4.Rows)
                {
                    this.EstimateItemID = (long)Convert.ToInt32(dataRow5["EstimateItemID"]);
                    this.EstimateType = dataRow5["EstimateType"].ToString();
                    int num10 = Convert.ToInt32(dataRow5["QtyCount"].ToString());
                    bool flag1 = Convert.ToBoolean(dataRow5["IsParentItem"]);
                    if (this.EstimateType == "S")
                    {
                        item_summary_single_item estimateItemID = (item_summary_single_item)base.LoadControl("~/usercontrol/Item/item_summary_single_item.ascx");
                        estimateItemID.ID = string.Concat("UcSubDigitalSingleItem_", this.EstimateItemID);
                        estimateItemID.EstimateID = this.EstimateID;
                        estimateItemID.EstimateItemID = this.EstimateItemID;
                        estimateItemID.EstType = this.EstimateType;
                        estimateItemID.Module = this.Module;
                        estimateItemID.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        estimateItemID.QtyCount = num10;
                        estimateItemID.ParentEstimateItemID = this.ParentEstimateItemID;
                        estimateItemID.ParentEstimateType = this.ParentEstimateType;
                        estimateItemID.IsParentItem = flag1;
                        estimateItemID.ParentQtyCount = num5;
                        estimateItemID.modulename = this.modulename;
                        estimateItemID.submodulename = this.submodulename;
                        estimateItemID.MainType = this.MainType;
                        estimateItemID.QtyNumber = num8;
                        estimateItemID.IsShowJobReRun = this.IsShowJobReRun;
                        estimateItemID.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(estimateItemID);
                        this.hdnIsinventoryBack.Value = "true";
                    }
                    else if (this.EstimateType == "P")
                    {
                        item_summary_pad_item estimateType = (item_summary_pad_item)base.LoadControl("~/usercontrol/Item/item_summary_pad_item.ascx");
                        estimateType.ID = string.Concat("UcDigitalPadItem_", this.EstimateItemID);
                        estimateType.EstimateID = this.EstimateID;
                        estimateType.EstimateItemID = this.EstimateItemID;
                        estimateType.EstType = this.EstimateType;
                        estimateType.Module = this.Module;
                        estimateType.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        estimateType.QtyCount = num10;
                        estimateType.ParentEstimateItemID = this.ParentEstimateItemID;
                        estimateType.ParentEstimateType = this.ParentEstimateType;
                        estimateType.IsParentItem = flag1;
                        estimateType.ParentQtyCount = num5;
                        estimateType.modulename = this.modulename;
                        estimateType.submodulename = this.submodulename;
                        estimateType.MainType = this.MainType;
                        estimateType.QtyNumber = num8;
                        estimateType.IsShowJobReRun = this.IsShowJobReRun;
                        estimateType.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(estimateType);
                        this.hdnIsinventoryBack.Value = "true";
                    }
                    else if (this.EstimateType == "L")
                    {
                        item_summary_large_item usercontrolItemItemSummaryLargeItem = (item_summary_large_item)base.LoadControl("~/usercontrol/Item/item_summary_large_item.ascx");
                        usercontrolItemItemSummaryLargeItem.ID = string.Concat("UcDigitalLargeItem_", this.EstimateItemID);
                        usercontrolItemItemSummaryLargeItem.EstimateID = this.EstimateID;
                        usercontrolItemItemSummaryLargeItem.EstimateItemID = this.EstimateItemID;
                        usercontrolItemItemSummaryLargeItem.EstType = this.EstimateType;
                        usercontrolItemItemSummaryLargeItem.Module = this.Module;
                        usercontrolItemItemSummaryLargeItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        usercontrolItemItemSummaryLargeItem.QtyCount = num10;
                        usercontrolItemItemSummaryLargeItem.ParentEstimateItemID = this.ParentEstimateItemID;
                        usercontrolItemItemSummaryLargeItem.ParentEstimateType = this.ParentEstimateType;
                        usercontrolItemItemSummaryLargeItem.IsParentItem = flag1;
                        usercontrolItemItemSummaryLargeItem.ParentQtyCount = num5;
                        usercontrolItemItemSummaryLargeItem.modulename = this.modulename;
                        usercontrolItemItemSummaryLargeItem.submodulename = this.submodulename;
                        usercontrolItemItemSummaryLargeItem.MainType = this.MainType;
                        usercontrolItemItemSummaryLargeItem.QtyNumber = num8;
                        usercontrolItemItemSummaryLargeItem.IsShowJobReRun = this.IsShowJobReRun;
                        usercontrolItemItemSummaryLargeItem.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(usercontrolItemItemSummaryLargeItem);
                        this.hdnIsinventoryBack.Value = "true";
                    }
                    else if (this.EstimateType == "F")
                    {
                        item_summary_litho_single_item usercontrolItemItemSummaryLithoSingleItem = (item_summary_litho_single_item)base.LoadControl("~/usercontrol/Item/item_summary_litho_single_item.ascx");
                        usercontrolItemItemSummaryLithoSingleItem.ID = string.Concat("UcLithoSingleItem_", this.EstimateItemID);
                        usercontrolItemItemSummaryLithoSingleItem.EstimateID = this.EstimateID;
                        usercontrolItemItemSummaryLithoSingleItem.EstimateItemID = this.EstimateItemID;
                        usercontrolItemItemSummaryLithoSingleItem.EstType = this.EstimateType;
                        usercontrolItemItemSummaryLithoSingleItem.Module = this.Module;
                        usercontrolItemItemSummaryLithoSingleItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        usercontrolItemItemSummaryLithoSingleItem.QtyCount = num10;
                        usercontrolItemItemSummaryLithoSingleItem.ParentEstimateItemID = this.ParentEstimateItemID;
                        usercontrolItemItemSummaryLithoSingleItem.ParentEstimateType = this.ParentEstimateType;
                        usercontrolItemItemSummaryLithoSingleItem.IsParentItem = flag1;
                        usercontrolItemItemSummaryLithoSingleItem.ParentQtyCount = num5;
                        usercontrolItemItemSummaryLithoSingleItem.modulename = this.modulename;
                        usercontrolItemItemSummaryLithoSingleItem.submodulename = this.submodulename;
                        usercontrolItemItemSummaryLithoSingleItem.MainType = this.MainType;
                        usercontrolItemItemSummaryLithoSingleItem.QtyNumber = num8;
                        usercontrolItemItemSummaryLithoSingleItem.IsShowJobReRun = this.IsShowJobReRun;
                        usercontrolItemItemSummaryLithoSingleItem.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(usercontrolItemItemSummaryLithoSingleItem);
                        this.hdnIsinventoryBack.Value = "true";
                    }
                    else if (this.EstimateType == "D")
                    {
                        item_summary_litho_pad_item usercontrolItemItemSummaryLithoPadItem = (item_summary_litho_pad_item)base.LoadControl("~/usercontrol/Item/item_summary_litho_pad_item.ascx");
                        usercontrolItemItemSummaryLithoPadItem.ID = string.Concat("UcLithoPadItem_", this.EstimateItemID);
                        usercontrolItemItemSummaryLithoPadItem.EstimateID = this.EstimateID;
                        usercontrolItemItemSummaryLithoPadItem.EstimateItemID = this.EstimateItemID;
                        usercontrolItemItemSummaryLithoPadItem.EstType = this.EstimateType;
                        usercontrolItemItemSummaryLithoPadItem.Module = this.Module;
                        usercontrolItemItemSummaryLithoPadItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        usercontrolItemItemSummaryLithoPadItem.QtyCount = num10;
                        usercontrolItemItemSummaryLithoPadItem.ParentEstimateItemID = this.ParentEstimateItemID;
                        usercontrolItemItemSummaryLithoPadItem.ParentEstimateType = this.ParentEstimateType;
                        usercontrolItemItemSummaryLithoPadItem.IsParentItem = flag1;
                        usercontrolItemItemSummaryLithoPadItem.ParentQtyCount = num5;
                        usercontrolItemItemSummaryLithoPadItem.modulename = this.modulename;
                        usercontrolItemItemSummaryLithoPadItem.submodulename = this.submodulename;
                        usercontrolItemItemSummaryLithoPadItem.MainType = this.MainType;
                        usercontrolItemItemSummaryLithoPadItem.QtyNumber = num8;
                        usercontrolItemItemSummaryLithoPadItem.IsShowJobReRun = this.IsShowJobReRun;
                        usercontrolItemItemSummaryLithoPadItem.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(usercontrolItemItemSummaryLithoPadItem);
                        this.hdnIsinventoryBack.Value = "true";
                    }
                    else if (this.EstimateType == "O")
                    {
                        item_summary_outwork_item estimateItemID1 = (item_summary_outwork_item)base.LoadControl("~/usercontrol/Item/item_summary_outwork_item.ascx");
                        estimateItemID1.ID = string.Concat("UcOutworkItem_", this.EstimateItemID);
                        estimateItemID1.EstimateID = this.EstimateID;
                        estimateItemID1.EstimateItemID = this.EstimateItemID;
                        estimateItemID1.EstType = this.EstimateType;
                        estimateItemID1.Module = this.Module;
                        estimateItemID1.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        estimateItemID1.QtyCount = num10;
                        estimateItemID1.ParentEstimateItemID = this.ParentEstimateItemID;
                        estimateItemID1.ParentEstimateType = this.ParentEstimateType;
                        estimateItemID1.IsParentItem = flag1;
                        estimateItemID1.ParentQtyCount = num5;
                        estimateItemID1.modulename = this.modulename;
                        estimateItemID1.submodulename = this.submodulename;
                        estimateItemID1.MainType = this.MainType;
                        estimateItemID1.QtyNumber = num8;
                        estimateItemID1.IsShowJobReRun = this.IsShowJobReRun;
                        estimateItemID1.IsShowInvRerun = this.IsShowInvRerun;
                        estimateItemID1.Count_Item = num3;
                        this.plhItems.Controls.Add(estimateItemID1);
                        if (this.Module.ToLower() == "estimate")
                        {
                            DataTable dataTable5 = new DataTable();
                            EstimateBasePage.SuplrQt_EstItmID_perEstID(this.EstimateItemID);
                            if (base.Request.QueryString["tab"] != null && base.Request.QueryString["tab"] != "" && base.Request.QueryString["tab"].ToString() == "Q")
                            {
                                this.tab = "Q";
                            }
                        }
                        num3++;
                    }
                    else if (this.EstimateType == "C")
                    {
                        item_summary_pricecatalogue_item estimateType1 = (item_summary_pricecatalogue_item)base.LoadControl("~/usercontrol/Item/item_summary_pricecatalogue_item.ascx");
                        estimateType1.ID = string.Concat("UcPriceCatalogueItem_", this.EstimateItemID);
                        estimateType1.EstimateID = this.EstimateID;
                        estimateType1.EstimateItemID = this.EstimateItemID;
                        estimateType1.EstType = this.EstimateType;
                        estimateType1.Module = this.Module;
                        estimateType1.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        estimateType1.QtyCount = num10;
                        estimateType1.ParentEstimateItemID = this.ParentEstimateItemID;
                        estimateType1.ParentEstimateType = this.ParentEstimateType;
                        estimateType1.IsParentItem = flag1;
                        estimateType1.ParentQtyCount = num5;
                        estimateType1.modulename = this.modulename;
                        estimateType1.submodulename = this.submodulename;
                        estimateType1.MainType = this.MainType;
                        estimateType1.QtyNumber = num8;
                        estimateType1.IsShowJobReRun = this.IsShowJobReRun;
                        estimateType1.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(estimateType1);
                        this.hdnIsProducttype.Value = "true";
                    }
                    //Add inventory as a sub item
                    else if (this.EstimateType == "W")
                    {
                        //item_summary_pricecatalogue_item estimateType1 = (item_summary_pricecatalogue_item)base.LoadControl("~/usercontrol/Item/item_summary_pricecatalogue_item.ascx");
                        item_summary_warehouse_item estimateType1 = (item_summary_warehouse_item)base.LoadControl("~/usercontrol/Item/item_summary_warehouse_item.ascx");
                        estimateType1.ID = string.Concat("UcWarehouseItem_", this.EstimateItemID);
                        estimateType1.EstimateID = this.EstimateID;
                        estimateType1.EstimateItemID = this.EstimateItemID;
                        estimateType1.EstType = this.EstimateType;
                        estimateType1.Module = this.Module;
                        estimateType1.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        estimateType1.QtyCount = num10;
                        estimateType1.ParentEstimateItemID = this.ParentEstimateItemID;
                        estimateType1.ParentEstimateType = this.ParentEstimateType;
                        estimateType1.IsParentItem = flag1;
                        estimateType1.ParentQtyCount = num5;
                        estimateType1.modulename = this.modulename;
                        estimateType1.submodulename = this.submodulename;
                        estimateType1.MainType = this.MainType;
                        estimateType1.QtyNumber = num8;
                        estimateType1.IsShowJobReRun = this.IsShowJobReRun;
                        estimateType1.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(estimateType1);
                        this.hdnIsProducttype.Value = "true";
                    }
                    else if (this.EstimateType == "U")
                    {
                        item_summary_othercost_item module1 = (item_summary_othercost_item)base.LoadControl("~/usercontrol/Item/item_summary_othercost_item.ascx");
                        module1.ID = string.Concat("UcOtherCostItem_", this.EstimateItemID);
                        module1.EstimateID = this.EstimateID;
                        module1.EstimateItemID = this.EstimateItemID;
                        module1.EstType = this.EstimateType;
                        module1.Module = this.Module;
                        module1.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        module1.QtyCount = num10;
                        module1.ParentEstimateItemID = this.ParentEstimateItemID;
                        module1.ParentEstimateType = this.ParentEstimateType;
                        module1.IsParentItem = flag1;
                        module1.ParentQtyCount = num5;
                        module1.modulename = this.modulename;
                        module1.submodulename = this.submodulename;
                        module1.MainType = this.MainType;
                        module1.QtyNumber = num8;
                        module1.IsShowJobReRun = this.IsShowJobReRun;
                        module1.IsShowInvRerun = this.IsShowInvRerun;
                        this.plhItems.Controls.Add(module1);
                    }
                    num9++;
                }
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                if (this.ParentEstimateType != "Q")
                {
                    this.plhItems.Controls.Add(new LiteralControl("<div  class='onlyEmpty'>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
                if (this.Module != "proof")
                {
                    item_summary_total usercontrolItemItemSummaryTotal = (item_summary_total)base.LoadControl("~/usercontrol/Item/item_summary_total.ascx");
                    usercontrolItemItemSummaryTotal.ID = string.Concat("UcItemTotal_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryTotal.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryTotal.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryTotal.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryTotal.Module = this.Module;
                    usercontrolItemItemSummaryTotal.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryTotal.QtyCount = num5;
                    usercontrolItemItemSummaryTotal.SectionCount = num6;
                    usercontrolItemItemSummaryTotal.modulename = this.modulename;
                    usercontrolItemItemSummaryTotal.submodulename = this.submodulename;
                    usercontrolItemItemSummaryTotal.QtyNumber = num8;

                    this.plhItems.Controls.Add(usercontrolItemItemSummaryTotal);
                }
                    //else
                    //{

                    //    item_proof_detail usercontrolItemItemSummaryTotal = (item_proof_detail)base.LoadControl("~/usercontrol/Item/item_summary_total.ascx");
                    //    //item_proof_detail usercontrolItemItemSummaryTotal = (item_proof_detail)base.LoadControl("~/usercontrol/Item/item_proof_detail.ascx");
                    //    usercontrolItemItemSummaryTotal.ID = string.Concat("UcItemTotal_", this.ParentEstimateItemID);
                    //    usercontrolItemItemSummaryTotal.EstimateID = this.EstimateID;
                    //    usercontrolItemItemSummaryTotal.EstimateItemID = this.ParentEstimateItemID;
                    //    usercontrolItemItemSummaryTotal.EstType = this.ParentEstimateType;
                    //    usercontrolItemItemSummaryTotal.Module = this.Module;
                    //    usercontrolItemItemSummaryTotal.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    //    usercontrolItemItemSummaryTotal.QtyCount = num5;
                    //    usercontrolItemItemSummaryTotal.SectionCount = num6;
                    //    usercontrolItemItemSummaryTotal.modulename = this.modulename;
                    //    usercontrolItemItemSummaryTotal.submodulename = this.submodulename;
                    //    usercontrolItemItemSummaryTotal.QtyNumber = num8;

                    //    this.plhItems.Controls.Add(usercontrolItemItemSummaryTotal);
                    //}
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count && this.Module != "invoice")
                {
                    item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob = (item_summary_progress_to_job)base.LoadControl("~/usercontrol/Item/item_summary_progress_to_job.ascx");
                    usercontrolItemItemSummaryProgressToJob.ID = "UcProgressToJob";
                    usercontrolItemItemSummaryProgressToJob.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryProgressToJob.Module = this.Module;
                    usercontrolItemItemSummaryProgressToJob.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryProgressToJob.modulename = this.modulename;
                    usercontrolItemItemSummaryProgressToJob.submodulename = this.submodulename;
                    usercontrolItemItemSummaryProgressToJob.MainType = this.MainType;
                    this.plhProgressToJob.Controls.Add(usercontrolItemItemSummaryProgressToJob);
                }
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count)
                {
                    Item_Summary_CopytoNew_SameCustomer usercontrolItemItemSummaryCopytoNewSameCustomer = (Item_Summary_CopytoNew_SameCustomer)base.LoadControl("~/usercontrol/Item/Item_Summary_CopytoNew_SameCustomer.ascx");
                    usercontrolItemItemSummaryCopytoNewSameCustomer.ID = "UcCopyItemCustomer";
                    usercontrolItemItemSummaryCopytoNewSameCustomer.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryCopytoNewSameCustomer.Module = this.Module;
                    usercontrolItemItemSummaryCopytoNewSameCustomer.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryCopytoNewSameCustomer.modulename = this.modulename;
                    usercontrolItemItemSummaryCopytoNewSameCustomer.submodulename = this.submodulename;
                    usercontrolItemItemSummaryCopytoNewSameCustomer.MainType = this.MainType;
                }
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count)
                {
                    Item_summary_ProgressTo_Invoice usercontrolItemItemSummaryProgressToInvoice = (Item_summary_ProgressTo_Invoice)base.LoadControl("~/usercontrol/Item/Item_summary_ProgressTo_Invoice.ascx");
                    usercontrolItemItemSummaryProgressToInvoice.ID = "UcProgressToInvoice";
                    usercontrolItemItemSummaryProgressToInvoice.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryProgressToInvoice.Module = this.Module;
                    usercontrolItemItemSummaryProgressToInvoice.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryProgressToInvoice.modulename = this.modulename;
                    usercontrolItemItemSummaryProgressToInvoice.submodulename = this.submodulename;
                    usercontrolItemItemSummaryProgressToInvoice.MainType = this.MainType;
                    this.plhProgressToInvoice.Controls.Add(usercontrolItemItemSummaryProgressToInvoice);
                }
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count)
                {
                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob = (Item_Summary_RaisePO_From_Job)base.LoadControl("~/usercontrol/Item/Item_Summary_RaisePO_From_Job.ascx");
                    usercontrolItemItemSummaryRaisePOFromJob.ID = "UCRaisePO";
                    usercontrolItemItemSummaryRaisePOFromJob.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryRaisePOFromJob.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryRaisePOFromJob.Module = this.Module;
                    usercontrolItemItemSummaryRaisePOFromJob.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryRaisePOFromJob.modulename = this.modulename;
                    usercontrolItemItemSummaryRaisePOFromJob.submodulename = this.submodulename;
                    usercontrolItemItemSummaryRaisePOFromJob.MainType = this.MainType;
                    this.plhRaisePO.Controls.Add(usercontrolItemItemSummaryRaisePOFromJob);
                }
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count)
                {
                    Item_Summary_PrintEmail_AllandSeletedItems usercontrolItemItemSummaryPrintEmailAllandSeletedItem = (Item_Summary_PrintEmail_AllandSeletedItems)base.LoadControl("~/usercontrol/Item/Item_Summary_PrintEmail_AllandSeletedItems.ascx");
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.ID = "PrintandEmail_All_SeletedItems";
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.InvoiceID = this.InvoiceID;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Module = this.Module;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.modulename = this.modulename;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.submodulename = this.submodulename;
                    usercontrolItemItemSummaryPrintEmailAllandSeletedItem.MainType = this.MainType;
                    this.Plh_PrintandEmail.Controls.Add(usercontrolItemItemSummaryPrintEmailAllandSeletedItem);
                    // delivery note select items
                    //Item_Delivery_Note_AllSelectedItems usercontrolItemDeliveryNoteAllandSeletedItem = (Item_Delivery_Note_AllSelectedItems)base.LoadControl("~/usercontrol/Item/Item_Delivery_Note_AllSelectedItems.ascx");
                    //usercontrolItemDeliveryNoteAllandSeletedItem.ID = "DeliveryNote_All_SeletedItems";
                    //usercontrolItemDeliveryNoteAllandSeletedItem.EstimateID = this.EstimateID;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.InvoiceID = this.InvoiceID;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.EstimateItemID = this.ParentEstimateItemID;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.Module = this.Module;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.modulename = this.modulename;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.submodulename = this.submodulename;
                    //usercontrolItemDeliveryNoteAllandSeletedItem.MainType = this.MainType;
                    //this.Plh_DelSelectItems.Controls.Add(usercontrolItemDeliveryNoteAllandSeletedItem);
                }
                // delivery note select items
                if (this.MainItemCnt + 1 == dataTable2.Rows.Count && this.Module == "job")
                {

                    Item_Delivery_Note_AllSelectedItems usercontrolItemDeliveryNoteAllandSeletedItem = (Item_Delivery_Note_AllSelectedItems)base.LoadControl("~/usercontrol/Item/Item_Delivery_Note_AllSelectedItems.ascx");
                    usercontrolItemDeliveryNoteAllandSeletedItem.ID = "DeliveryNote_All_SeletedItems";
                    usercontrolItemDeliveryNoteAllandSeletedItem.EstimateID = this.EstimateID;
                    usercontrolItemDeliveryNoteAllandSeletedItem.InvoiceID = this.InvoiceID;
                    usercontrolItemDeliveryNoteAllandSeletedItem.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemDeliveryNoteAllandSeletedItem.Module = this.Module;
                    usercontrolItemDeliveryNoteAllandSeletedItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemDeliveryNoteAllandSeletedItem.modulename = this.modulename;
                    usercontrolItemDeliveryNoteAllandSeletedItem.submodulename = this.submodulename;
                    usercontrolItemDeliveryNoteAllandSeletedItem.MainType = this.MainType;
                    this.Plh_DelSelectItems.Controls.Add(usercontrolItemDeliveryNoteAllandSeletedItem);
                }

                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    if (this.MainItemCnt + 1 == dataTable2.Rows.Count)
                    {
                        Item_Summary_PrintEmail_AllandSeletedItems usercontrolItemItemSummaryPrintEmailAllandSeletedItem = (Item_Summary_PrintEmail_AllandSeletedItems)base.LoadControl("~/usercontrol/Item/Item_Summary_PrintEmail_AllandSeletedItems.ascx");
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.ID = "PrintandEmail_All_SeletedItems";
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateID = this.EstimateID;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.InvoiceID = this.InvoiceID;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateItemID = this.ParentEstimateItemID;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Module = this.Module;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.modulename = this.modulename;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.submodulename = this.submodulename;
                        usercontrolItemItemSummaryPrintEmailAllandSeletedItem.MainType = this.MainType;
                        this.Plh_PrintandEmail.Controls.Add(usercontrolItemItemSummaryPrintEmailAllandSeletedItem);
                    }

                    item_proof_detail usercontrolItemItemSummaryTotal = (item_proof_detail)base.LoadControl("~/usercontrol/Item/item_proof_detail.ascx");
                    usercontrolItemItemSummaryTotal.ID = string.Concat("UcItemTotal_", this.ParentEstimateItemID);
                    usercontrolItemItemSummaryTotal.EstimateID = this.EstimateID;
                    usercontrolItemItemSummaryTotal.EstimateItemID = this.ParentEstimateItemID;
                    usercontrolItemItemSummaryTotal.EstType = this.ParentEstimateType;
                    usercontrolItemItemSummaryTotal.Module = this.Module;
                    usercontrolItemItemSummaryTotal.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                    usercontrolItemItemSummaryTotal.QtyCount = num5;
                    usercontrolItemItemSummaryTotal.SectionCount = num6;
                    usercontrolItemItemSummaryTotal.modulename = this.modulename;
                    usercontrolItemItemSummaryTotal.submodulename = this.submodulename;
                    usercontrolItemItemSummaryTotal.QtyNumber = num8;

                    this.plhItems.Controls.Add(usercontrolItemItemSummaryTotal);

                }
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                if (this.Module == "proof")
                {
                    this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='width:20%;padding-left:10px;height:100%;' >"));
                }
                else
                {
                this.plhItems.Controls.Add(new LiteralControl("<td valign='top' class='shadow_right' style='width:20%;padding-left:10px;height:100%;' >"));
                }
                Boolean IsDescriptionLock = false;
                if (this.Module.ToLower() == "job")
                {
                    invoiceID = this.jobID;
                    var locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                    var ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                    var IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    string status = SettingsBasePage.PC_select_ProductEditingOption_Status(CompanyID);
                    if (IsJobLocked == true && ignorelocking != "true" && (status == "LockEditingDescStatus" || status == "LockEditingDesc"))
                    {
                        IsDescriptionLock = true;
                    }

                    if (IsJobLocked)
                    {
                        lblLocked.Text = "[Locked Job]";

                    }
                    else
                    {
                        lblLocked.Text = "";
                    }

                }
                if (this.Module.ToLower() == "invoice")
                {
                    invoiceID = this.InvoiceID;
                }
                if (this.Module.ToLower() == "orders" || this.Module.ToLower() == "estimates")
                {
                    invoiceID = this.EstimateID;
                }

                EstimateCommonMethods.ShowDescriptionOnSummary(this.Pgtype, this.CompanyID, invoiceID, this.ParentEstimateItemID, this.plhItems, str8, this.Isfromactivityhist, IsDescriptionLock);
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td colspan='3'>"));
                this.plhItems.Controls.Add(new LiteralControl("<div class='summaryFooter'>"));
                this.plhItems.Controls.Add(new LiteralControl("<div  style='display: block; float:right;margin-top:3px; width: 255px;'>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='float: left'>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_btnstay_", this.ParentEstimateItemID, "' style='display: block'>")));
                Button button = new Button()
                {
                    ID = string.Concat(this.ParentEstimateItemID, "_btnStay"),
                    Text = this.objLanguage.GetLanguageConversion("Save_Stay")
                };
                button.Attributes["class"] = "button";
                estimateID = new object[] { "javascript:return CallStayBtn(this.id,'", this.ParentEstimateItemID, "_btnStay',", this.CompanyID, ",'", this.ParentEstimateType, "',", this.EstimateID, ",", num5, ",", num6, ")" };
                button.OnClientClick = string.Concat(estimateID);
                button.Click += new EventHandler(this.btnSaveStay_Click);
                if (this.OrderItemApprovalStatus == 1)
                {

                    if (this.Module.ToLower() == "job")
                    {

                        if (this.ReturnRoles_Privileges_ForGrid_New("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "true")
                        {
                            this.plhItems.Controls.Add(button);
                            HiddenField hiddenField3 = new HiddenField()
                            {
                                ID = string.Concat("hdnItemDescription_", this.ParentEstimateItemID)
                            };
                            this.plhItems.Controls.Add(hiddenField3);
                        }


                    }

                    else
                    {
                        this.plhItems.Controls.Add(button);
                        HiddenField hiddenField3 = new HiddenField()
                        {
                            ID = string.Concat("hdnItemDescription_", this.ParentEstimateItemID)
                        };
                        this.plhItems.Controls.Add(hiddenField3);
                    }
                }
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_stayprocess_", this.ParentEstimateItemID, "' style='display: none; width:70px; height:14px;' class='button'>")));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />")));
                HiddenField hiddenField4 = new HiddenField()
                {
                    ID = string.Concat("hdnMainSaveValues_", this.ParentEstimateItemID)
                };
                this.plhItems.Controls.Add(hiddenField4);
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='float: left;padding-left:10px;'>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_btnsave_", this.ParentEstimateItemID, "' style='display: block;'>")));
                Button button1 = new Button()
                {
                    ID = string.Concat(this.ParentEstimateItemID, "_btnSave"),
                    Text = this.objLanguage.GetLanguageConversion("Save_Close")
                };
                button1.Attributes["class"] = "button";
                estimateID = new object[] { "javascript:return CallSaveBtn(this.id,'", this.ParentEstimateItemID, "_btnSave',", this.CompanyID, ",'", this.ParentEstimateType, "',", this.EstimateID, ",", num5, ",", num6, ")" };
                button1.OnClientClick = string.Concat(estimateID);
                button1.Click += new EventHandler(this.btnSave_Click);
                if (this.OrderItemApprovalStatus == 1)
                {
                    if (this.Module.ToLower() == "job")
                    {
                        if (this.ReturnRoles_Privileges_ForGrid_New("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "true")
                        {
                            this.plhItems.Controls.Add(button1);
                        }
                    }
                    else
                    {

                        this.plhItems.Controls.Add(button1);
                    }
                }
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_saveprocess_", this.ParentEstimateItemID, "' style='display: none; width:76px; height:14px; margin-top:1px;' class='button'>")));
                this.plhItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />")));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                item_summary_main mainItemCnt = this;
                mainItemCnt.MainItemCnt = mainItemCnt.MainItemCnt + 1;
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
            {
                this.Module_Type = "order";
            }
            if (base.Request.Url.ToString().ToLower().Contains("order_summary"))
            {
                this.Module_Type = "order";
            }
            if (this.Module == "order" || this.Module_Type == "order" || this.Module == "estimate" || this.Module == "job" || this.Module == "invoice")
            {
                if (base.Request.QueryString["EstItemID"] == null && Convert.ToInt64(base.Request.QueryString["EstItemID"]) == (long)0)
                {
                    this.hdnaccordionIndex.Value = num2.ToString();
                }
                DataTable dataTable6 = new DataTable();
                //if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng"))
                {
                    //dataTable6 = (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary") ? OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, (long)0) : OrderBasePage.JobInvoiceAllItemDetails_select(this.InvoiceID, "Invoice"));
                    dataTable6 = (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng") ? OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, (long)0) : OrderBasePage.JobInvoiceAllItemDetails_select(this.InvoiceID, "Invoice"));
                }
                else
                {
                    dataTable6 = OrderBasePage.JobInvoiceAllItemDetails_select(this.jobID, "Job");
                    //string EstimateID = base.Request.QueryString["estid"] ?? this.jobID.ToString();
                    //dataTable6 = OrderBasePage.JobInvoiceAllItemDetails_select(long.Parse(EstimateID), "Job");
                }

                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                string empty12 = string.Empty;

                decimal num22 = new decimal(0);
                decimal num23 = new decimal(0);
                decimal num24 = new decimal(0);
                decimal num25 = new decimal(0);
                decimal num26 = new decimal(0);
                string empty17 = string.Empty;

                decimal num27 = new decimal(0);
                decimal num28 = new decimal(0);
                decimal num29 = new decimal(0);
                decimal num30 = new decimal(0);
                decimal num31 = new decimal(0);
                string empty18 = string.Empty;

                decimal num32 = new decimal(0);
                decimal num33 = new decimal(0);
                decimal num34 = new decimal(0);
                decimal num35 = new decimal(0);
                decimal num36 = new decimal(0);
                string empty19 = string.Empty;

                decimal num37 = new decimal(0);
                decimal num38 = new decimal(0);
                decimal num39 = new decimal(0);
                decimal num40 = new decimal(0);

                DataTable dataTable8 = new DataTable();
                if (this.Module == "estimate")
                {
                    int maxQuantityCount = Convert.ToInt32(dataTable2.Compute("max([QtyCount])", string.Empty));
                    string str2 = "display:none";
                    string str3 = "display:none";
                    string str4 = "display:none";
                    string str5 = "display:none";
                    var tblWidth = string.Empty;
                    var tblWidth_MinWidth = string.Empty;
                    if (maxQuantityCount == 1)
                    {
                        tblWidth = "42%";
                        tblWidth_MinWidth = "min-width:320px;";
                        str2 = "visibility:visible;";
                    }
                    else if (maxQuantityCount == 2)
                    {
                        tblWidth = "62%";
                        tblWidth_MinWidth = "min-width:420px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                    }
                    else if (maxQuantityCount == 3)
                    {
                        tblWidth = "82%";
                        tblWidth_MinWidth = "min-width:520px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                        str4 = "visibility:visible;";
                    }
                    else if (maxQuantityCount == 4)
                    {
                        tblWidth = "100%";
                        tblWidth_MinWidth = "min-width:550px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                        str4 = "visibility:visible;";
                        str5 = "visibility:visible;";
                    }
                    dataTable8 = EstimatesBasePage.estimate_summary_select(this.EstimateID, "estimate");
                    foreach (DataRow row8 in dataTable8.Rows)
                    {
                        num25 = Convert.ToDecimal(row8["AllItem_TotalPriceIncMarkup2"]);
                        num24 = Convert.ToDecimal(row8["AllItem_GrossProfitDollar2"]);
                        num26 = Convert.ToDecimal(row8["AllItem_OrderItemTax2"]);
                        num22 = Convert.ToDecimal(row8["AllItem_SellingPrice2"]);
                      

                        num30 = Convert.ToDecimal(row8["AllItem_TotalPriceIncMarkup3"]);
                        num29 = Convert.ToDecimal(row8["AllItem_GrossProfitDollar3"]);
                        num31 = Convert.ToDecimal(row8["AllItem_OrderItemTax3"]);
                        num27 = Convert.ToDecimal(row8["AllItem_SellingPrice3"]);

                        num35 = Convert.ToDecimal(row8["AllItem_TotalPriceIncMarkup4"]);
                        num34 = Convert.ToDecimal(row8["AllItem_GrossProfitDollar4"]);
                        num36 = Convert.ToDecimal(row8["AllItem_OrderItemTax4"]);
                        num32 = Convert.ToDecimal(row8["AllItem_SellingPrice4"]);

                        num38 = Convert.ToDecimal(row8["AllItem_CostExMarkup2"]);
                        num39 = Convert.ToDecimal(row8["AllItem_CostExMarkup3"]);
                        num40 = Convert.ToDecimal(row8["AllItem_CostExMarkup4"]);
                   

                    }
                    if (dataTable6.Rows.Count > 0)
                    {
                        num11 = Convert.ToDecimal(dataTable6.Rows[0]["OrderPriceIncTax"]);
                        num14 = Convert.ToDecimal(dataTable6.Rows[0]["PriceExcTax"]);
                    }
                    else if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        DataTable dataTable7 = new DataTable();
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng"))
                        {
                            dataTable7 = (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary") ? OrderBasePage.Order_AllItemsDetails_Select(this.EstimateID, "order") : OrderBasePage.Order_AllItemsDetails_Select(this.InvoiceID, "Invoice"));
                        }
                        else
                        {
                            dataTable7 = OrderBasePage.Order_AllItemsDetails_Select(this.jobID, "Job");
                        }
                        foreach (DataRow row6 in dataTable7.Rows)
                        {
                            num14 = Convert.ToDecimal(row6["AllItem_TotalPriceIncMarkup"]);
                            num13 = Convert.ToDecimal(row6["AllItem_GrossProfitDollar"]);
                            num15 = Convert.ToDecimal(row6["AllItem_OrderItemTax"]);
                            num11 = Convert.ToDecimal(row6["AllItem_SellingPrice"]);
                            num37 = Convert.ToDecimal(row6["AllItem_CostExMarkup"]);
                        }
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                    {
                        foreach (DataRow dataRow6 in OrderBasePage.Order_select(this.CompanyID, this.EstimateID).Rows)
                        {
                            base.Session["AccountID"] = Convert.ToInt32(dataRow6["AccountID"]);
                        }
                        foreach (DataRow row7 in EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                        {
                            empty12 = row7["eStoreComments"].ToString();
                        }
                    }
                    this.plhItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:5px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<h3 style='height:35px;'><a style='border-bottom-width:0px; padding-top:10px;' href='#'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                    //this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td style='width: 185px;max-width:1px;min-width:120px'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText'>", this.objLanguage.GetLanguageConversion("All_Items_Details"), "</span> ")));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span style='margin-left:27%' class='HeaderText'>Quantity 1</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                    {
                        this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    }
                    else
                    {
                        this.plhItems.Controls.Add(new LiteralControl("<td style='display:none;'>"));

                    }
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText' style='margin-left:24%'>Total All Items (Ex. Tax):&nbsp;</span><span id='TabSellingPrice' style='vertical-align:middle;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num14, 0, "", false, false, true), " </span>")));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td style='width:250px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span></span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //Quantity2
                    //this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:8%;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 2</span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<td style='width:10%;'>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 2</span>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='width:15%;'>"));
                    //}
                    //else
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='display:none;'>"));

                    //}
                    //this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText'>Total All Items (Ex. Tax):&nbsp;</span><span id='TabSellingPrice' style='vertical-align:middle;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num25, 0, "", false, false, true), " </span>")));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:250px;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span></span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    //Quantity3
                    //this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:8%;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 3</span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<td style='width:10%;'>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 3</span>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='width:15%;'>"));
                    //}
                    //else
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='display:none;'>"));

                    //}
                    //this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText'>Total All Items (Ex. Tax):&nbsp;</span><span id='TabSellingPrice' style='vertical-align:middle;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num30, 0, "", false, false, true), " </span>")));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:250px;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span></span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    //Quantity4
                    //this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:8%;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 4</span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<td style='width:10%;'>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("<span  class='HeaderText'>Quantity 4</span>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='width:15%;'>"));
                    //}
                    //else
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<td style='display:none;'>"));

                    //}
                    //this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText'>Total All Items (Ex. Tax):&nbsp;</span><span id='TabSellingPrice' style='vertical-align:middle;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num35, 0, "", false, false, true), " </span>")));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<td style='width:250px;'>"));
                    //this.plhItems.Controls.Add(new LiteralControl("<span></span>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    ////this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    //this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhItems.Controls.Add(new LiteralControl("</a></h3>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;margin-top: -1px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent' width='100%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='100%'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td width='350px'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText' id='spnAllItems'>", this.objLanguage.GetLanguageConversion("All_Items"), "</span> <span class='HeaderText'>Quantity 1</span>")));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable6.Rows.Count > 0)
                    {
                        this.plhItems.Controls.Add(new LiteralControl("<div style='float: left; position: absolute; margin-left: 38%; margin-top: 21px;'>"));
                        this.plhItems.Controls.Add(new LiteralControl("<div class='bglabel' style='float: left; width: 200px; margin-right: 10px;'>"));
                        this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span>", this.objLanguage.GetLanguageConversion("Comments"), "</span>")));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhItems.Controls.Add(new LiteralControl("<div style='float: left; width: 450px;position: absolute;margin-left: 54%;margin-top: 25px;'>"));
                        this.plhItems.Controls.Add(new LiteralControl(string.Concat("<label>", dataTable6.Rows[0]["eStoreComments"].ToString().Replace("\n", "<br />"), "</label>")));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    }
                    int num16 = 0;
                    decimal num17 = new decimal(0);
                    bool flag2 = true;
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringBuilder1 = new StringBuilder();
                    StringBuilder stringBuilder2 = new StringBuilder();
                    StringBuilder stringBuilder3 = new StringBuilder();
                    StringBuilder stringBuilder4 = new StringBuilder();
                    StringBuilder stringBuilder5 = new StringBuilder();
                    StringBuilder stringBuilder6 = new StringBuilder();
                    StringBuilder stringBuilder7 = new StringBuilder();
                    StringBuilder stringBuilder8 = new StringBuilder();

                    StringBuilder stringBuilder9 = new StringBuilder();
                    StringBuilder stringBuilder10 = new StringBuilder();
                    StringBuilder stringBuilder11 = new StringBuilder();
                    StringBuilder stringBuilder12 = new StringBuilder();
                    StringBuilder stringBuilder13 = new StringBuilder();

                    StringBuilder stringBuilder14 = new StringBuilder();
                    StringBuilder stringBuilder15 = new StringBuilder();
                    StringBuilder stringBuilder16 = new StringBuilder();
                    StringBuilder stringBuilder17 = new StringBuilder();
                    StringBuilder stringBuilder18 = new StringBuilder();

                    StringBuilder stringBuilder19 = new StringBuilder();
                    StringBuilder stringBuilder20 = new StringBuilder();
                    StringBuilder stringBuilder21 = new StringBuilder();
                    StringBuilder stringBuilder22 = new StringBuilder();
                    StringBuilder stringBuilder23 = new StringBuilder();

                    StringBuilder stringBuilder24 = new StringBuilder();
                    StringBuilder stringBuilder25 = new StringBuilder();
                    StringBuilder stringBuilder26 = new StringBuilder();
                    StringBuilder stringBuilder27 = new StringBuilder();

                    if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        if (num14 != new decimal(0))
                        {
                            num12 = (num13 / num14) * new decimal(100);
                        }
                        //this.summry.EstoreCommentsStyle(stringBuilder6, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        //stringBuilder6.Append("<td style='position: absolute;margin-top: 150px;' align='left' width='400px'>");
                        //stringBuilder6.Append(string.Concat("<Label style='width:100%;' CssClass='normalText' maxlength='50'> ", empty12.Replace("\n", "<br />"), "</Label>"));
                        //stringBuilder6.Append("</td>");
                        //this.summry.EndTableCreation(stringBuilder6);
                        //this.plhItems.Controls.Add(new LiteralControl(stringBuilder6.ToString()));


                        this.summry.PBReadTopString1(stringBuilder24, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder24.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder24.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder24.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num37, 0, "", false, false, true), "</Label>"));
                        stringBuilder24.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder24);
                        this.summry.EndTableCreation(stringBuilder24);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder24.ToString()));





                        this.summry.PBReadTopString1(stringBuilder7, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_OrderItemExTax");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder7.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder7.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder7.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num14, 0, "", false, false, true), "</Label>"));
                        stringBuilder7.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder7);
                        this.summry.EndTableCreation(stringBuilder7);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                        this.summry.PBReadTopString1(stringBuilder, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                        stringBuilder.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</Label>"));
                        stringBuilder.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder);
                        this.summry.EndTableCreation(stringBuilder);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.summry.PBReadTopString1(stringBuilder4, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceEncTax");
                        stringBuilder4.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder4.Append(string.Concat("<Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' CssClass='normalText' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true), "</Label>"));
                        stringBuilder4.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder4);
                        this.summry.EndTableCreation(stringBuilder4);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                        this.summry.PBReadTopString1(stringBuilder2, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                        stringBuilder2.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        languageConversion = new string[] { " <Label style='text-align: right;width:100%;cursor:default; border:0px solid green;'CssClass='normalText'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "<div style='padding-top:3px;margin-right: -5px;'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "%</div></LABEL>" };
                        stringBuilder2.Append(string.Concat(languageConversion));
                        stringBuilder2.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder2);
                        this.summry.EndTableCreation(stringBuilder2);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                        this.summry.EstoreCommentsStyle1(stringBuilder6, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        stringBuilder6.Append("<td style='position: absolute' align='left' width='400px'>");
                        stringBuilder6.Append(string.Concat("<Label style='width:100%;cursor:default;' CssClass='normalText' maxlength='50'> ", empty12.Replace("\n", "<br />"), "</Label>"));
                        stringBuilder6.Append("</td>");
                        this.summry.EndTableCreation(stringBuilder6);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                    }
                    foreach (DataRow dataRow7 in dataTable6.Rows)
                    {
                        if (num16 == 0)
                        {
                            this.summry.PBReadTopString(stringBuilder4, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_SellingPriceEncTax");
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder4.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                            }
                            else
                            {
                                stringBuilder4.Append("<td style='display:none;' align='right' width='24%'>");

                            }
                            stringBuilder4.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["OrderIncMarkup"]), 0, "", false, false, true), "</Label>"));
                            stringBuilder4.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder4);
                            this.summry.EndTableCreation(stringBuilder4);
                            this.plhItems.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                            if (flag2)
                            {
                                stringBuilder5.Append("<div style='border:0px solid red;'>");
                                if (base.Request.Url.AbsoluteUri.Contains("pagename=estore") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (base.Request.Url.AbsoluteUri.Contains("pagename=job") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (base.Request.Url.AbsoluteUri.Contains("pagename=inv") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                                {
                                    stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                }
                                else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                                {
                                    if (OrderBasePage.OrderConvertedToJob(this.EstimateID).ToLower() != "true")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left;font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px;display:block;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left;font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                stringBuilder5.Append("</div>");
                                this.plhItems.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                                flag2 = false;
                            }
                        }
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                        {
                            this.summry.PBReadTopString(stringBuilder3, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Cart_Additional_Option"), "</Label>"), string.Concat("div_OrderAdditionalOption_", num16));
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                            }
                            else
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;display:none;'>");

                            }
                            estimateID = new object[] { " <Label id='lblMultiplePrice_", num16, "' style='text-align: right;width:100%;'  maxlength='50'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]), 0, "", false, false, true), "</Label>" };
                            stringBuilder3.Append(string.Concat(estimateID));
                            stringBuilder3.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder3);
                            this.summry.EndTableCreation(stringBuilder3);
                        }
                        else
                        {
                            string empty13 = string.Empty;
                            this.PBReadTopStringForadditionaloptions(stringBuilder3, string.Concat(" <Label id='lblAllItemDetailsOrderAdditionalOption' style='padding-left:20px;'>", dataRow7["SelectedValue"].ToString(), "</Label>"), string.Concat("div_OrderAdditionalOption_", num16));
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                            }
                            else
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;display:none;'>");

                            }
                            estimateID = new object[] { " <Label id='lblMultiplePrice_", num16, "' style='text-align: right;width:100%;'  maxlength='50'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["TotalPrice"]), 0, "", false, false, true), "</Label>" };
                            stringBuilder3.Append(string.Concat(estimateID));
                            stringBuilder3.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder3);
                            this.summry.EndTableCreation(stringBuilder3);
                        }
                        int count = dataTable6.Rows.Count;
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                        {
                            num17 = (num16 != 0 ? num17 + Convert.ToDecimal(dataRow7["TotalPrice"]) : Convert.ToDecimal(dataRow7["TotalPrice"]) + Convert.ToDecimal(dataRow7["OrderIncMarkup"]));
                            if (count == num16 + 1)
                            {
                                this.summry.PBReadTopString(stringBuilder8, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</Label>"), "div_OrderItemSubtotal");
                                stringBuilder8.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder8.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num17, 0, "", false, false, true), "</Label>"));
                                stringBuilder8.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder8);
                                this.summry.EndTableCreation(stringBuilder8);
                            }
                        }
                        else if (Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]) > new decimal(0))
                        {
                            num17 = Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]) + Convert.ToDecimal(dataRow7["OrderIncMarkup"]);
                            if (count == num16 + 1)
                            {
                                this.summry.PBReadTopString(stringBuilder8, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</Label>"), "div_OrderItemSubtotal");
                                stringBuilder8.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder8.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num17, 0, "", false, false, true), "</Label>"));
                                stringBuilder8.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder8);
                                this.summry.EndTableCreation(stringBuilder8);
                            }
                        }
                        if (num16 == 0)
                        {
                            decimal num18 = Convert.ToDecimal(dataRow7["OrderTotalTax"]);
                            string str13 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showtax").ToLower() != "false")
                            {
                                this.summry.PBReadTopString(stringBuilder, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                                stringBuilder.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num18, 0, "", false, false, true), "</Label>"));
                                stringBuilder.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder);
                                this.summry.EndTableCreation(stringBuilder);
                            }
                            string empty14 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false" && !this.Check_SpecialPrivilege)
                            {
                                this.summry.PBReadTopString(stringBuilder1, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceIncTax");
                                stringBuilder1.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                                stringBuilder1.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true), "</Label>"));
                                stringBuilder1.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder1);
                                this.summry.EndTableCreation(stringBuilder1);
                            }
                            decimal num19 = Convert.ToDecimal(dataRow7["OrderGrossProfitPercentage"]);
                            decimal num20 = Convert.ToDecimal(dataRow7["OrderIncMarkup"]);
                            decimal num21 = new decimal(0);
                            if (num20 != new decimal(0))
                            {
                                num21 = (num19 / num20) * new decimal(100);
                            }
                            string str14 = string.Empty;
                            str14 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                            string empty15 = string.Empty;
                            empty15 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                            if (str14.ToLower() != "false" && empty15.ToLower() != "false" && !this.Check_SpecialPrivilege)
                            {
                                string str15 = string.Empty;
                                string empty16 = string.Empty;
                                if (empty15.ToLower() != "false")
                                {
                                    empty16 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    empty16 = "display:none;";
                                }
                                if (str14.ToLower() != "false")
                                {
                                    str15 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    str15 = "display:none;";
                                }
                                this.summry.PBReadTopString(stringBuilder2, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                                stringBuilder2.Append("<td align='right' width='24%'style='padding-top:5px;'>");
                                languageConversion = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;'  maxlength='50'><div style='", empty16, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num19, 0, "", false, false, true), "</div><div style='padding-top:3px;", str15, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num21, 0, "", false, false, true), "%</div></LABEL>" };
                                stringBuilder2.Append(string.Concat(languageConversion));
                                stringBuilder2.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder2);
                                this.summry.EndTableCreation(stringBuilder2);
                            }
                        }
                        num16++;
                    }
                    if (dataTable6.Rows.Count > 0)
                    {
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder8.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                    }
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    //Quantity2

                    this.plhItems.Controls.Add(new LiteralControl("<td width='350px'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:-15px; " + str3 + "'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;margin-top: -1px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent2' width='60%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='100%'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span class='HeaderText' id='spnAllItems2'>Quantity 2</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        if (num25 != new decimal(0))
                        {
                            num23 = (num24 / num25) * new decimal(100);
                        }
                        //this.summry.EstoreCommentsStyle(stringBuilder9, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments2");
                        //stringBuilder9.Append("<td style='position: absolute;margin-top: 150px;' align='left' width='400px'>");
                        //stringBuilder9.Append(string.Concat("<Label style='width:100%;' CssClass='normalText' maxlength='50'> ", empty17.Replace("\n", "<br />"), "</Label>"));
                        //stringBuilder9.Append("</td>");
                        //this.summry.EndTableCreation(stringBuilder9);
                        //this.plhItems.Controls.Add(new LiteralControl(stringBuilder9.ToString()));

                        this.summry.PBReadTopString1(stringBuilder25, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup2");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder25.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder25.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder25.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'   maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num38, 0, "", false, false, true), "</Label>"));
                        stringBuilder25.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder25);
                        this.summry.EndTableCreation(stringBuilder25);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder25.ToString()));




                        this.summry.PBReadTopString1(stringBuilder10, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_OrderItemExTax2");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder10.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder10.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder10.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'   maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num25, 0, "", false, false, true), "</Label>"));
                        stringBuilder10.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder10);
                        this.summry.EndTableCreation(stringBuilder10);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder10.ToString()));
                        this.summry.PBReadTopString1(stringBuilder11, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax2");
                        stringBuilder11.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder11.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num26, 0, "", false, false, true), "</Label>"));
                        stringBuilder11.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder11);
                        this.summry.EndTableCreation(stringBuilder11);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder11.ToString()));
                        this.summry.PBReadTopString1(stringBuilder12, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceEncTax2");
                        stringBuilder12.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder12.Append(string.Concat("<Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' CssClass='normalText' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num22, 0, "", false, false, true), "</Label>"));
                        stringBuilder12.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder12);
                        this.summry.EndTableCreation(stringBuilder12);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder12.ToString()));
                        this.summry.PBReadTopString1(stringBuilder13, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft2");
                        stringBuilder13.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        languageConversion = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;cursor:default;'CssClass='normalText'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num24, 0, "", false, false, true), "<div style='padding-top:3px;margin-right: -5px;'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num23, 0, "", false, false, true), "%</div></LABEL>" };
                        stringBuilder13.Append(string.Concat(languageConversion));
                        stringBuilder13.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder13);
                        this.summry.EndTableCreation(stringBuilder13);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder13.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl("</td>"));

                        this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));


                    }
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    //Quantity3
                    this.plhItems.Controls.Add(new LiteralControl("<td width='350px'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:-15px;" + str4 + "'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;margin-top: -1px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent3' width='100%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='100%'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span class='HeaderText' id='spnAllItems'>Quantity 3</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        if (num30 != new decimal(0))
                        {
                            num28 = (num29 / num30) * new decimal(100);
                        }
                        //this.summry.EstoreCommentsStyle(stringBuilder14, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        //stringBuilder14.Append("<td style='position: absolute;margin-top: 150px;' align='left' width='400px'>");
                        //stringBuilder14.Append(string.Concat("<Label style='width:100%;' CssClass='normalText' maxlength='50'> ", empty18.Replace("\n", "<br />"), "</Label>"));
                        //stringBuilder14.Append("</td>");
                        //this.summry.EndTableCreation(stringBuilder14);
                        //this.plhItems.Controls.Add(new LiteralControl(stringBuilder14.ToString()));

                        this.summry.PBReadTopString1(stringBuilder26, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder26.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder26.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder26.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num39, 0, "", false, false, true), "</Label>"));
                        stringBuilder26.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder26);
                        this.summry.EndTableCreation(stringBuilder26);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder26.ToString()));




                        this.summry.PBReadTopString1(stringBuilder15, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_OrderItemExTax");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder15.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder15.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder15.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num30, 0, "", false, false, true), "</Label>"));
                        stringBuilder15.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder15);
                        this.summry.EndTableCreation(stringBuilder15);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder15.ToString()));
                        this.summry.PBReadTopString1(stringBuilder16, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                        stringBuilder16.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder16.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num31, 0, "", false, false, true), "</Label>"));
                        stringBuilder16.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder16);
                        this.summry.EndTableCreation(stringBuilder16);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder16.ToString()));
                        this.summry.PBReadTopString1(stringBuilder17, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceEncTax");
                        stringBuilder17.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder17.Append(string.Concat("<Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' CssClass='normalText' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num27, 0, "", false, false, true), "</Label>"));
                        stringBuilder17.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder17);
                        this.summry.EndTableCreation(stringBuilder17);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder17.ToString()));
                        this.summry.PBReadTopString1(stringBuilder18, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                        stringBuilder18.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        languageConversion = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;cursor:default;'CssClass='normalText'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num29, 0, "", false, false, true), "<div style='padding-top:3px;margin-right: -5px;'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num28, 0, "", false, false, true), "%</div></LABEL>" };
                        stringBuilder18.Append(string.Concat(languageConversion));
                        stringBuilder18.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder18);
                        this.summry.EndTableCreation(stringBuilder18);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder18.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));

                    }
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    //Quantity4
                    this.plhItems.Controls.Add(new LiteralControl("<td width='350px'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:-15px;" + str5 + "'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;margin-top: -1px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent4' width='100%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='100%'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span class='HeaderText' id='spnAllItems'>Quantity 4</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        if (num35 != new decimal(0))
                        {
                            num33 = (num34 / num35) * new decimal(100);
                        }
                        //this.summry.EstoreCommentsStyle(stringBuilder19, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        //stringBuilder19.Append("<td style='position: absolute;margin-left: 54px;' align='left' width='400px'>");
                        //stringBuilder19.Append(string.Concat("<Label style='width:100%;' CssClass='normalText' maxlength='50'> ", empty19.Replace("\n", "<br />"), "</Label>"));
                        //stringBuilder19.Append("</td>");
                        //this.summry.EndTableCreation(stringBuilder19);
                        //this.plhItems.Controls.Add(new LiteralControl(stringBuilder19.ToString()));


                        this.summry.PBReadTopString1(stringBuilder27, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder27.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder27.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder27.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num40, 0, "", false, false, true), "</Label>"));
                        stringBuilder27.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder27);
                        this.summry.EndTableCreation(stringBuilder27);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder27.ToString()));



                        this.summry.PBReadTopString1(stringBuilder20, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_OrderItemExTax");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder20.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder20.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder20.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num35, 0, "", false, false, true), "</Label>"));
                        stringBuilder20.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder20);
                        this.summry.EndTableCreation(stringBuilder20);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                        this.summry.PBReadTopString1(stringBuilder21, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                        stringBuilder21.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder21.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num36, 0, "", false, false, true), "</Label>"));
                        stringBuilder21.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder21);
                        this.summry.EndTableCreation(stringBuilder21);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder21.ToString()));
                        this.summry.PBReadTopString1(stringBuilder22, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceEncTax");
                        stringBuilder22.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        stringBuilder22.Append(string.Concat("<Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' CssClass='normalText' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num32, 0, "", false, false, true), "</Label>"));
                        stringBuilder22.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder22);
                        this.summry.EndTableCreation(stringBuilder22);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder22.ToString()));
                        this.summry.PBReadTopString1(stringBuilder23, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                        stringBuilder23.Append("<td style='padding-top:5px;padding-left:10px;' align='right' width='24%'>");
                        languageConversion = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;cursor:default;'CssClass='normalText'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num34, 0, "", false, false, true), "<div style='padding-top:3px;margin-right: -5px;'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num33, 0, "", false, false, true), "%</div></LABEL>" };
                        stringBuilder23.Append(string.Concat(languageConversion));
                        stringBuilder23.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder23);
                        this.summry.EndTableCreation(stringBuilder23);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder23.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhItems.Controls.Add(new LiteralControl("</div>"));


                    }
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));

                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    if (dataTable6.Rows.Count > 0)
                    {
                        num11 = Convert.ToDecimal(dataTable6.Rows[0]["OrderPriceIncTax"]);
                        num14 = Convert.ToDecimal(dataTable6.Rows[0]["PriceExcTax"]);
                    }
                    else if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        DataTable dataTable7 = new DataTable();
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                        {
                            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                            {
                                dataTable7 = OrderBasePage.Order_AllItemsDetails_Select(this.InvoiceID, "Invoice");
                            }
                            else
                            {
                                dataTable7 = (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng") ? OrderBasePage.Order_AllItemsDetails_Select(this.EstimateID, "order") : OrderBasePage.Order_AllItemsDetails_Select(this.InvoiceID, "Invoice"));
                            }
                            //dataTable7 = (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng") ? OrderBasePage.Order_AllItemsDetails_Select(this.EstimateID, "order") : OrderBasePage.Order_AllItemsDetails_Select(this.InvoiceID, "Invoice"));

                        }
                        else
                        {
                            dataTable7 = OrderBasePage.Order_AllItemsDetails_Select(this.jobID, "Job");
                        }
                        foreach (DataRow row6 in dataTable7.Rows)
                        {
                            num14 = Convert.ToDecimal(row6["AllItem_TotalPriceIncMarkup"]);
                            num13 = Convert.ToDecimal(row6["AllItem_GrossProfitDollar"]);
                            num15 = Convert.ToDecimal(row6["AllItem_OrderItemTax"]);
                            num11 = Convert.ToDecimal(row6["AllItem_SellingPrice"]);
                            num37 = Convert.ToDecimal(row6["AllItem_CostExMarkup"]);
                            empty12 = row6["eStoreComments"].ToString();
                        }
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                    {
                        foreach (DataRow dataRow6 in OrderBasePage.Order_select(this.CompanyID, this.EstimateID).Rows)
                        {
                            base.Session["AccountID"] = Convert.ToInt32(dataRow6["AccountID"]);
                        }
                        foreach (DataRow row7 in EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID).Rows)
                        {
                            empty12 = row7["eStoreComments"].ToString();
                        }
                    }
                    this.plhItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:5px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<h3 style='height:32px;'><a style='border-bottom-width:0px; padding-top:10px;' href='#'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td style='width:185px; min-width:120px'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText'>", this.objLanguage.GetLanguageConversion("All_Items_Details"), "</span>")));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span class='HeaderText'>Quantity 1</span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                    {
                        this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    }
                    else
                    {
                        this.plhItems.Controls.Add(new LiteralControl("<td style='display:none;'>"));

                    }
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText' style='margin-left:19%'>Total All Items (Ex. Tax):&nbsp;</span><span id='TabSellingPrice' style='vertical-align:middle;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num14, 0, "", false, false, true), " </span>")));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td style='width:250px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<span></span>"));
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhItems.Controls.Add(new LiteralControl("</a></h3>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;margin-top: -1px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent' width='60%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                    this.plhItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='60%'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("<td>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText' id='spnAllItems'>", this.objLanguage.GetLanguageConversion("All_Items"), "</span>")));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    //if (dataTable6.Rows.Count > 0)
                    //{
                    //    this.plhItems.Controls.Add(new LiteralControl("<div style='float: left; position: absolute; margin-top: 158px;'>"));
                    //    this.plhItems.Controls.Add(new LiteralControl("<div class='bglabel' style='float: left; width: 200px; margin-right: 10px;'>"));
                    //    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<span>", this.objLanguage.GetLanguageConversion("Comments"), "</span>")));
                    //    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plhItems.Controls.Add(new LiteralControl("<div style='float: left; width: 450px;position: absolute;margin-left: 21%;margin-top: 163px;'>"));
                    //    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<label>", dataTable6.Rows[0]["eStoreComments"].ToString().Replace("\n", "<br />"), "</label>")));
                    //    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    //}

                    int num16 = 0;
                    decimal num17 = new decimal(0);
                    bool flag2 = true;
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringBuilder1 = new StringBuilder();
                    StringBuilder stringBuilder2 = new StringBuilder();
                    StringBuilder stringBuilder3 = new StringBuilder();
                    StringBuilder stringBuilder4 = new StringBuilder();
                    StringBuilder stringBuilder5 = new StringBuilder();
                    StringBuilder stringBuilder6 = new StringBuilder();
                    StringBuilder stringBuilder7 = new StringBuilder();
                    StringBuilder stringBuilder8 = new StringBuilder();

                    StringBuilder stringBuilder9 = new StringBuilder();
                    StringBuilder stringBuilder10 = new StringBuilder();
                    StringBuilder stringBuilder11 = new StringBuilder();
                    StringBuilder stringBuilder12 = new StringBuilder();
                    StringBuilder stringBuilder13 = new StringBuilder();

                    StringBuilder stringBuilder14 = new StringBuilder();
                    StringBuilder stringBuilder15 = new StringBuilder();
                    StringBuilder stringBuilder16 = new StringBuilder();
                    StringBuilder stringBuilder17 = new StringBuilder();
                    StringBuilder stringBuilder18 = new StringBuilder();

                    StringBuilder stringBuilder19 = new StringBuilder();
                    StringBuilder stringBuilder20 = new StringBuilder();
                    StringBuilder stringBuilder21 = new StringBuilder();
                    StringBuilder stringBuilder22 = new StringBuilder();
                    StringBuilder stringBuilder23 = new StringBuilder();

                    StringBuilder stringBuilder24 = new StringBuilder();
                    StringBuilder stringBuilder25 = new StringBuilder();


                    if (dataTable6.Rows.Count.ToString() == "0")
                    {
                        if (num14 != new decimal(0))
                        {
                            num12 = (num13 / num14) * new decimal(100);
                        }

                        this.summry.PBReadTopString(stringBuilder25, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder25.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder25.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder25.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num37, 0, "", false, false, true), "</Label>"));
                        stringBuilder25.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder25);
                        this.summry.EndTableCreation(stringBuilder25);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder25.ToString()));





                        this.summry.PBReadTopString(stringBuilder7, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_OrderItemExTax");
                        if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                        {
                            stringBuilder7.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                        }
                        else
                        {
                            stringBuilder7.Append("<td style='display:none;' align='right' width='24%'>");

                        }
                        stringBuilder7.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num14, 0, "", false, false, true), "</Label>"));
                        stringBuilder7.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder7);
                        this.summry.EndTableCreation(stringBuilder7);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                        this.summry.PBReadTopString(stringBuilder, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                        stringBuilder.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                        stringBuilder.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</Label>"));
                        stringBuilder.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder);
                        this.summry.EndTableCreation(stringBuilder);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.summry.PBReadTopString(stringBuilder4, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceEncTax");
                        stringBuilder4.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                        stringBuilder4.Append(string.Concat("<Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' CssClass='normalText' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true), "</Label>"));
                        stringBuilder4.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder4);
                        this.summry.EndTableCreation(stringBuilder4);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                        this.summry.PBReadTopString(stringBuilder2, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                        stringBuilder2.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                        languageConversion = new string[] { " <Label style='text-align: right;width:100%;cursor:default; border:0px solid green;'CssClass='normalText'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "<div style='padding-top:3px;margin-right: -5px;'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "%</div></LABEL>" };
                        stringBuilder2.Append(string.Concat(languageConversion));
                        stringBuilder2.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder2);
                        this.summry.EndTableCreation(stringBuilder2);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                        this.summry.EstoreCommentsStyle(stringBuilder6, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        stringBuilder6.Append("<td style='position: absolute;margin-left: 54px;' align='left' width='400px'>");
                        stringBuilder6.Append(string.Concat("<Label style='width:100%;cursor:default;' CssClass='normalText' maxlength='50'> ", empty12.Replace("\n", "<br />"), "</Label>"));
                        stringBuilder6.Append("</td>");
                        this.summry.EndTableCreation(stringBuilder6);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                    }
                    foreach (DataRow dataRow7 in dataTable6.Rows)
                    {
                        if (num16 == 0)
                        {


                            this.summry.PBReadTopString(stringBuilder25, "Cost Price Ex.Markup", "div_OrderItemCostExMarkup");
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder25.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                            }
                            else
                            {
                                stringBuilder25.Append("<td style='display:none;' align='right' width='24%'>");

                            }
                            stringBuilder25.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["AllItem_CostExMarkup"]), 0, "", false, false, true), "</Label>"));
                            stringBuilder25.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder25);
                            this.summry.EndTableCreation(stringBuilder25);
                            this.plhItems.Controls.Add(new LiteralControl(stringBuilder25.ToString()));



                            this.summry.PBReadTopString(stringBuilder4, this.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_SellingPriceEncTax");
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder4.Append("<td style='padding-top:5px;' align='right' width='24%'>");
                            }
                            else
                            {
                                stringBuilder4.Append("<td style='display:none;' align='right' width='24%'>");

                            }
                            stringBuilder4.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["OrderIncMarkup"]), 0, "", false, false, true), "</Label>"));
                            stringBuilder4.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder4);
                            this.summry.EndTableCreation(stringBuilder4);
                            this.plhItems.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                            if (flag2)
                            {
                                stringBuilder5.Append("<div style='border:0px solid red;'>");
                                if (base.Request.Url.AbsoluteUri.Contains("pagename=estore") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (base.Request.Url.AbsoluteUri.Contains("pagename=job") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (base.Request.Url.AbsoluteUri.Contains("pagename=inv") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                                {
                                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                else if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                                {
                                    stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                }
                                else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng"))
                                {
                                    if (OrderBasePage.OrderConvertedToJob(this.EstimateID).ToLower() != "true")
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left;font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px;display:block;'></div></div>"));
                                    }
                                    else
                                    {
                                        stringBuilder5.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left;font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                    }
                                }
                                stringBuilder5.Append("</div>");
                                this.plhItems.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                                flag2 = false;
                            }
                        }
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng"))
                        {
                            this.summry.PBReadTopString(stringBuilder3, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Cart_Additional_Option"), "</Label>"), string.Concat("div_OrderAdditionalOption_", num16));
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                            }
                            else
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;display:none;'>");

                            }
                            estimateID = new object[] { " <Label id='lblMultiplePrice_", num16, "' style='text-align: right;width:100%;cursor:default;'  maxlength='50'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]), 0, "", false, false, true), "</Label>" };
                            stringBuilder3.Append(string.Concat(estimateID));
                            stringBuilder3.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder3);
                            this.summry.EndTableCreation(stringBuilder3);
                        }
                        else
                        {
                            string empty13 = string.Empty;
                            this.PBReadTopStringForadditionaloptions(stringBuilder3, string.Concat(" <Label id='lblAllItemDetailsOrderAdditionalOption' style='padding-left:20px;'>", dataRow7["SelectedValue"].ToString(), "</Label>"), string.Concat("div_OrderAdditionalOption_", num16));
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false")
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                            }
                            else
                            {
                                stringBuilder3.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;display:none;'>");

                            }
                            estimateID = new object[] { " <Label id='lblMultiplePrice_", num16, "' style='text-align: right;width:100%;cursor:default;'  maxlength='50'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow7["TotalPrice"]), 0, "", false, false, true), "</Label>" };
                            stringBuilder3.Append(string.Concat(estimateID));
                            stringBuilder3.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder3);
                            this.summry.EndTableCreation(stringBuilder3);
                        }
                        int count = dataTable6.Rows.Count;
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng"))
                        {
                            num17 = (num16 != 0 ? num17 + Convert.ToDecimal(dataRow7["TotalPrice"]) : Convert.ToDecimal(dataRow7["TotalPrice"]) + Convert.ToDecimal(dataRow7["OrderIncMarkup"]));
                            if (count == num16 + 1)
                            {
                                this.summry.PBReadTopString(stringBuilder8, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</Label>"), "div_OrderItemSubtotal");
                                stringBuilder8.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder8.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num17, 0, "", false, false, true), "</Label>"));
                                stringBuilder8.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder8);
                                this.summry.EndTableCreation(stringBuilder8);
                            }
                        }
                        else if (Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]) > new decimal(0))
                        {
                            num17 = Convert.ToDecimal(dataRow7["OrderItemShippingPrice"]) + Convert.ToDecimal(dataRow7["OrderIncMarkup"]);
                            if (count == num16 + 1)
                            {
                                this.summry.PBReadTopString(stringBuilder8, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</Label>"), "div_OrderItemSubtotal");
                                stringBuilder8.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder8.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num17, 0, "", false, false, true), "</Label>"));
                                stringBuilder8.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder8);
                                this.summry.EndTableCreation(stringBuilder8);
                            }
                        }
                        if (num16 == 0)
                        {
                            decimal num18 = Convert.ToDecimal(dataRow7["OrderTotalTax"]);
                            string str13 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showtax").ToLower() != "false")
                            {
                                this.summry.PBReadTopString(stringBuilder, this.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                                stringBuilder.Append("<td align='right' width='24%' style='border:0px solid green;padding-top:5px;'>");
                                stringBuilder.Append(string.Concat(" <Label style='text-align: right;width:100%;cursor:default;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num18, 0, "", false, false, true), "</Label>"));
                                stringBuilder.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder);
                                this.summry.EndTableCreation(stringBuilder);
                            }
                            string empty14 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false" && !this.Check_SpecialPrivilege)
                            {
                                this.summry.PBReadTopString(stringBuilder1, string.Concat("<Label  style='font-weight: bold;'>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</Label>"), "div_SellingPriceIncTax");
                                stringBuilder1.Append("<td align='right' width='24%' style='border:0px solid red;padding-top:5px;'>");
                                stringBuilder1.Append(string.Concat(" <Label style='text-align: right;width:100%;font-weight: bold;cursor:default;' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true), "</Label>"));
                                stringBuilder1.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder1);
                                this.summry.EndTableCreation(stringBuilder1);
                            }
                            decimal num19 = Convert.ToDecimal(dataRow7["OrderGrossProfitPercentage"]);
                            decimal num20 = Convert.ToDecimal(dataRow7["OrderIncMarkup"]);
                            decimal num21 = new decimal(0);
                            if (num20 != new decimal(0))
                            {
                                num21 = (num19 / num20) * new decimal(100);
                            }
                            string str14 = string.Empty;
                            str14 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                            string empty15 = string.Empty;
                            empty15 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                            if (str14.ToLower() != "false" && empty15.ToLower() != "false" && !this.Check_SpecialPrivilege)
                            {
                                string str15 = string.Empty;
                                string empty16 = string.Empty;
                                if (empty15.ToLower() != "false")
                                {
                                    empty16 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    empty16 = "display:none;";
                                }
                                if (str14.ToLower() != "false")
                                {
                                    str15 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    str15 = "display:none;";
                                }
                                this.summry.PBReadTopString(stringBuilder2, this.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                                stringBuilder2.Append("<td align='right' width='24%'style='padding-top:5px;'>");
                                languageConversion = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;cursor:default;'  maxlength='50'><div style='", empty16, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num19, 0, "", false, false, true), "</div><div style='padding-top:3px;", str15, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num21, 0, "", false, false, true), "%</div></LABEL>" };
                                stringBuilder2.Append(string.Concat(languageConversion));
                                stringBuilder2.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder2);
                                this.summry.EndTableCreation(stringBuilder2);
                            }
                        }
                        num16++;
                    }
                    if (dataTable6.Rows.Count > 0)
                    {
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder8.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                        this.summry.EstoreCommentsStyle(stringBuilder24, this.objLanguage.GetLanguageConversion("Comments"), "div_EstoreComments");
                        stringBuilder24.Append("<td style='position: absolute;margin-left: 54px;' align='left' width='400px'>");
                        stringBuilder24.Append(string.Concat("<Label style='width:100%;' CssClass='normalText' maxlength='50'> ", dataTable6.Rows[0]["eStoreComments"].ToString().Replace("\n", "<br />"), "</Label>"));
                        stringBuilder24.Append("</td>");
                        this.summry.EndTableCreation(stringBuilder24);
                        this.plhItems.Controls.Add(new LiteralControl(stringBuilder24.ToString()));

                    }
                    this.plhItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }

            }


            bool flag_1 = true;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                //this.hdnIsSortingAllowed.Value = Convert.ToString(row["AllowSorting"]).ToLower();
                if (Convert.ToString(row["chkSumCondensedView"]) == "0")
                {
                    flag_1 = false;
                }
                else
                {
                    flag_1 = true;
                }
            }


            if (this.Module == "estimate" || this.Module == "job" || this.Module == "invoice")
            {
                if (base.Request.QueryString["EstItemID"] == null)
                {
                    //this.hdnaccordionIndex.Value = "0";
                    if (!flag_1)
                    {
                        this.hdnaccordionIndex.Value = "1";
                    }
                }
            }
        }

        public void PBReadTopStringForadditionaloptions(StringBuilder Strbud, string title, string DivID)
        {
            if (title == "Gross Profit")
            {
                Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
                Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;height:25px'>");
                Strbud.Append(title ?? "");
                Strbud.Append("</div>");
                Strbud.Append("<div style='float:left;width:65%;border:solid 0px blue'>");
                Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='99%' >");
                Strbud.Append("<tr>");
                return;
            }
            Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
            Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green; margin-top: -2px;'>");
            Strbud.Append(title ?? "");
            Strbud.Append("</div>");
            Strbud.Append("<div style='float:left;width:65%;border:solid 0px blue'>");
            Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='100%' >");
            Strbud.Append("<tr>");
        }

        protected string ReturnRoles_Privileges_ForGrid_New(string module, string fieldName, string Path)
        {
            string empty = string.Empty;
            try
            {
                if (this.Session["CustomAccessRight"] != null && this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true" && this.Session["Roles_Privileges_Tabs"] != null)
                {
                    DataTable item = (DataTable)this.Session["Roles_Privileges_Tabs"];
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["sectionName"].ToString().Trim().ToLower() != module)
                        {
                            continue;
                        }
                        foreach (DataColumn column in item.Columns)
                        {
                            if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                            {
                                continue;
                            }
                            empty = row[column.ColumnName].ToString();
                        }
                    }
                }
                else if (this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "false")
                {
                    DataTable item = (DataTable)this.Session["Roles_Privileges_Tabs"];
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["sectionName"].ToString().Trim().ToLower() != module)
                        {
                            continue;
                        }
                        foreach (DataColumn column in item.Columns)
                        {
                            if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                            {
                                continue;
                            }
                            empty = row[column.ColumnName].ToString();
                        }
                    }
                }
            }
            catch
            {
            }
            return empty;
        }



    }

}