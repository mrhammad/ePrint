using ePrint.usercontrol.settings;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class proof_summary_main : UsercontrolBasePage
    {
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

        public long ProofItemID;
        public int AttachmentID;

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

        public proof_summary_main()
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            item_summary_total module = (item_summary_total)base.LoadControl("~/usercontrol/Item/item_summary_total.ascx");
            module.modulename = this.modulename;
            module.submodulename = this.submodulename;
            module.Module = this.Module;
            module.CompanyID = this.CompanyID;
            module.UserID = this.UserID;
            string[] strArrays = ((Button)sender).ID.Split(new char[] { '\u005F' });
            string str = string.Concat("hdnMainSaveValues_", Convert.ToInt64(strArrays[0]),"_",Convert.ToInt64(strArrays[1]));
            HiddenField hiddenField = (HiddenField)this.plhItems.FindControl(str);
            string[] strArrays1 = this.hdnItemDescs.Value.Split(new char[] { '~' });
            EstimatesBasePage.SaveQtyDescription(Convert.ToInt64(strArrays[0]), strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), this.CompanyID);
            HiddenField hiddenField1 = (HiddenField)this.plhItems.FindControl(string.Concat("hdnItemDescription_", Convert.ToInt64(strArrays[0]), "_", Convert.ToInt64(strArrays[1])));
            string value = hiddenField.Value;
            module.SaveClick("save", value, this.jID, this.InvID, hiddenField1.Value);
            //ProofSaveClick("save", value, this.jID, this.InvID, hiddenField1.Value, this.ProofItemID);

        }
        public void ProofSaveClick(string type, string finalvalues, string JobID, string InvoiceID, string ItemDesc,long ProofItemID)
        {
            string[] strArrays = ItemDesc.Split(new char[] { '\u25AC' });
            EstimateCommonMethods.UpdateProofItemDescriptionInSummary(this.CompanyID, Convert.ToInt64(strArrays[1]), Convert.ToInt64(strArrays[2]), Convert.ToInt64(ProofItemID), strArrays[3].ToString(), strArrays[4].ToString(), Convert.ToBoolean(strArrays[5]), Convert.ToBoolean(strArrays[6]), Convert.ToBoolean(strArrays[7]), strArrays[8].ToString(), strArrays[9].ToString());
            HttpResponse httpResponse1 = base.Response;
            httpResponse1.Redirect(base.Request.Url.ToString());
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
            string str = string.Concat("hdnMainSaveValues_", Convert.ToInt64(strArrays[0]), "_", Convert.ToInt64(strArrays[1]));
            HiddenField hiddenField = (HiddenField)this.plhItems.FindControl(str);
            string[] strArrays1 = this.hdnItemDescs.Value.Split(new char[] { '~' });
            //EstimatesBasePage.SaveQtyDescription(Convert.ToInt64(strArrays[0]), strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), this.CompanyID);
            HiddenField hiddenField1 = (HiddenField)this.plhItems.FindControl(string.Concat("hdnItemDescription_", Convert.ToInt64(strArrays[0]), "_", Convert.ToInt64(strArrays[1])));
            string value = hiddenField.Value;
            //module.SaveClick("save&stay", value, this.jID, this.InvID, hiddenField1.Value);
            //ProofSaveClick("save&stay", value, this.jID, this.InvID, hiddenField1.Value, this.ProofItemID);
            ProofSaveClick("save&stay", value, this.jID, this.InvID, hiddenField1.Value, Convert.ToInt64(strArrays[1]));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            object[] estimateID;
            string[] languageConversion;
            MasterPage master = this.Parent.Page.Master;
            HtmlControl htmlControl = master.FindControl("DivLeftpanel") as HtmlControl;
            HtmlTableCell tdLeftPanel = master.FindControl("tdLeftpanel") as HtmlTableCell;
            HtmlGenericControl contextPanel = master.FindControl("contextPanel") as HtmlGenericControl;
            if (tdLeftPanel != null)
            {
                tdLeftPanel.Visible = false;
            }
            if (htmlControl != null)
            {
                htmlControl.Visible = false;
            }
            if (contextPanel != null)
            {
                contextPanel.Visible = false;
            }
            BaseClass baseClass = new BaseClass();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());

            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hdnIsSortingAllowed.Value = Convert.ToString(row["AllowSorting"]).ToLower();
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
            if (base.Request.Url.ToString().ToLower().Contains("proofs/proof"))
            {
                this.Module = "proof";
                this.Pgtype = "proof";
                this.modulename = "proofs";
                this.submodulename = "proof";
                this.gloobj.setpagename("proof");
                this.pg = "proof";
            }
            this.ViewEstItemID = (long)0;
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
            userID.ProofItemID = this.ProofItemID;
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
            if (this.Module == "proof")
            {
                dataTable1 = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "proof");
            }

            string str = string.Empty;
            long invoiceID = (long)0;
            this.plhStatusList.Controls.Add(new LiteralControl("<table>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<tr>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
            this.plhStatusList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                long num = Convert.ToInt64(dataRow["StatusID"]);
                string str1 = dataRow["StatusTitle"].ToString();
                string str2 = str1.Replace(" ", "ยง");
                str2 = this.objBase.SpecialEncode(str2);
                if (!this.ISdrwastockFrom || !(str == num.ToString()))
                {
                    ControlCollection controls = this.plhStatusList.Controls;
                    if (this.Module.ToLower() != "proof")
                    {
                        estimateID = new object[] { "<a style='color: Black;' href='#' onclick=javascript:EstJobInvStatusSave(", num, ",'", str2, "',", invoiceID, "); >", this.objBase.SpecialDecode(str1), "</a>" };
                    }
                    else
                    {
                        estimateID = new object[] { "<a style='color: Black;' href='#' onclick=javascript:ProofStatusSave(", num, ",'", str2, "',", this.ProofID, "); >", this.objBase.SpecialDecode(str1), "</a>" };
                    }
                    controls.Add(new LiteralControl(string.Concat(estimateID)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhStatusList.Controls;
                    estimateID = new object[] { "<a style='color: Black;' href='#' onclick=javascript:OpenReplenishAllocationPopUp(", this.EstimateID, ",", invoiceID, ",", 0, ",", num.ToString(), "); >", this.objBase.SpecialDecode(str1), "</a>" };
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
            if (this.Pgtype == "proof")
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
                this.ProofItemID = (long)Convert.ToInt32(row4["ProofItemID"]);
                this.AttachmentID = int.Parse(row4["AttachmentID"].ToString());
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
                if (this.modulename.ToLower() == "proofs")
                {
                    this.MainItemNumber = row4["ProofItemNumber"].ToString();
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
                if (this.ParentEstimateType == "X")
                {
                    this.EsttypeName = "Order";
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
                if (this.IsApprovalFeaturesOn && this.EstimateType == "X" && base.Request.Url.ToString().ToLower().Contains("orders/order"))
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

                estimateID = new object[] { "<div id='ddlItemStaus_", this.ProofItemID, "' class='btnstyle' style='width:208px;float:left; padding-top:4px; text-align: left;overflow: hidden;white-space: nowrap;' onmouseover='javascript:OpenItemStatus(", this.ProofItemID, "); return false;' onmouseout='javascript:CloseItemStatus(", this.ProofItemID, "); return false;'>" };
                controls5.Add(new LiteralControl(string.Concat(estimateID)));

                this.plhItems.Controls.Add(new LiteralControl("<div style='width: 185px;  overflow: hidden; white-space:nowrap; float: left;'>"));
                ControlCollection controlCollections5 = this.plhItems.Controls;
                estimateID = new object[] { "<label id='lblItemStatus_", this.ParentEstimateItemID +"_" + this.ProofItemID, "' value='", empty9, "' style='font-size:12px;'>", empty9, "</label>" };
                controlCollections5.Add(new LiteralControl(string.Concat(estimateID)));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("<div style='float: right; padding-top: 5px'>"));
                this.plhItems.Controls.Add(new LiteralControl("<img id='img' src='../images/down_arrow.png'/>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                if (this.OrderItemApprovalStatus != 1 || IsDescriptionStatus)
                {
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='divItemStatusList_", this.ProofItemID, "'></div>")));
                }
                else
                {
                    string str10 = "margin-top:26px;";
                    if (base.Request.Browser.Browser.ToString().ToLower() == "firefox" || base.Request.UserAgent.ToLower().Contains("safari") && !base.Request.UserAgent.ToLower().Contains("chrome"))
                    {
                        str10 = "margin-top:25px;";
                    }
                    ControlCollection controls6 = this.plhItems.Controls;
                    estimateID = new object[] { "<div id='divItemStatusList_", this.ProofItemID, "' onmouseover='javascript:OpenItemStatus(", this.ProofItemID, "); return false;' onmouseout='javascript:CloseItemStatus(", this.ProofItemID, "); return false;'   style='width: 223px; ", str10, " padding:0px;' class='Div_AccountList'>" };
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
                            estimateID = new object[] { "<a style='color: Black' href='#' onclick =javascript:ProofItemStatuS_Update(", Convert.ToInt64(row5["StatusID"]), ",", this.ParentEstimateItemID, ",'", str12, "','", this.ProofID, "','", this.ProofItemID, "'); >", this.objBase.SpecialDecode(row5["StatusTitle"].ToString()), "</a>" };
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
                hiddenField.Value = string.Concat(hiddenField.Value, this.ParentEstimateItemID,"_",this.ProofItemID, "@");
                string empty10 = string.Empty;
                string empty11 = string.Empty;

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
                parentEstimateItemID.ID = string.Concat("itemdetails_quickLinks_", this.ProofItemID);
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
                parentEstimateItemID.AttachmentID = this.AttachmentID;
                parentEstimateItemID.ProofItemID = this.ProofItemID;

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
                    parentEstimateType.ID = string.Concat("UcDigitalSingleItem_", this.ProofItemID);
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
                    module.ID = string.Concat("UcDigitalPadItem_", this.ProofItemID);
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
                    checkSpecialPrivilege.ID = string.Concat("UcDigitalBookletItem_", this.ProofItemID);
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
                else if (this.ParentEstimateType == "L")
                {
                    item_summary_large_item mainType = (item_summary_large_item)base.LoadControl("~/usercontrol/Item/item_summary_large_item.ascx");
                    mainType.ID = string.Concat("UcDigitalLargeItem_", this.ProofItemID);
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
                    isShowDelete.ID = string.Concat("UcLithoSingleItem_", this.ProofItemID);
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
                    isShowJobReRun.ID = string.Concat("UcLithoPadItem_", this.ProofItemID);
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
                    isShowInvRerun.ID = string.Concat("UcLithoBookletItem_", this.ProofItemID);
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
                    salesPersonID.ID = string.Concat("UcLithoNCRItem_", this.ProofItemID);
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
                else if (this.ParentEstimateType == "W")
                {
                    item_summary_warehouse_item usercontrolItemItemSummaryWarehouseItem = (item_summary_warehouse_item)base.LoadControl("~/usercontrol/Item/item_summary_warehouse_item.ascx");
                    usercontrolItemItemSummaryWarehouseItem.ID = string.Concat("UcWarehouseItem_", this.ProofItemID);
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
                    usercontrolItemItemSummaryQuickQuoteItem.ID = string.Concat("UcQuickQuoteItem_", this.ProofItemID);
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
                    usercontrolItemItemSummaryDeliveryCostItem.ID = string.Concat("UcDeliveryCostItem_", this.ProofItemID);
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
                    usercontrolItemItemSummaryOutworkItem.ID = string.Concat("UcOutworkItem_", this.ProofItemID);
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
                    usercontrolItemItemSummaryPricecatalogueItem.ID = string.Concat("UcPriceCatalogueItem_", this.ProofItemID);
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
                    usercontrolItemItemSummaryOthercostItem.ID = string.Concat("UcOtherCostItem_", this.ProofItemID);
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
                    estimateID1.ID = string.Concat("UcPriceCatalogueItem_", this.ProofItemID);
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
                usercontrolItemItemSummaryTotal.ID = string.Concat("UcItemTotal_", this.ProofItemID);
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
                usercontrolItemItemSummaryTotal.ProofItemID = this.ProofItemID;

                this.plhItems.Controls.Add(usercontrolItemItemSummaryTotal);

                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                if (this.Module == "proof")
                {
                    this.plhItems.Controls.Add(new LiteralControl("<td valign='top' style='width:20%;padding-left:10px;height:100%;' >"));
                }
                Boolean IsDescriptionLock = false;

                proof_summary_main.ShowDescriptionOnSummary(this.Pgtype, this.CompanyID, invoiceID, this.ParentEstimateItemID, this.plhItems, str8, this.Isfromactivityhist, this.ProofItemID, IsDescriptionLock);
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhItems.Controls.Add(new LiteralControl("<td colspan='3'>"));
                this.plhItems.Controls.Add(new LiteralControl("<div class='summaryFooter'>"));
                if (objBC.GetUserRolePrivilege("proofs", "isadd") == "true")
                {
                    this.plhItems.Controls.Add(new LiteralControl("<div  style='display: block; float:right;margin-top:3px; width: 255px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='float: left'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_btnstay_", this.ParentEstimateItemID, "' style='display: block'>")));
                    Button button = new Button()
                    {
                        ID = string.Concat(this.ParentEstimateItemID, "_", this.ProofItemID, "_btnStay"),
                        Text = this.objLanguage.GetLanguageConversion("Save_Stay")
                    };
                    button.Attributes["class"] = "button";
                    estimateID = new object[] { "javascript:return CallStayBtn(this.id,'", this.ParentEstimateItemID, "_btnStay',", this.CompanyID, ",'", this.ParentEstimateType, "',", this.EstimateID, ",", num5, ",", num6, ",", ProofItemID, ",", this.ProofID, ")" };
                    button.OnClientClick = string.Concat(estimateID);
                    button.Click += new EventHandler(this.btnSaveStay_Click);
                    if (this.OrderItemApprovalStatus == 1)
                    {

                        this.plhItems.Controls.Add(button);
                        HiddenField hiddenField3 = new HiddenField()
                        {
                            ID = string.Concat("hdnItemDescription_", this.ParentEstimateItemID, "_", this.ProofItemID)
                        };
                        this.plhItems.Controls.Add(hiddenField3);
                    }

                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_stayprocess_", this.ParentEstimateItemID, "' style='display: none; width:70px; height:14px;' class='button'>")));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />")));
                    HiddenField hiddenField4 = new HiddenField()
                    {
                        ID = string.Concat("hdnMainSaveValues_", this.ParentEstimateItemID, "_", this.ProofItemID)
                    };
                    this.plhItems.Controls.Add(hiddenField4);
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("<div style='float: left;padding-left:10px;'>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_btnsave_", this.ParentEstimateItemID, "' style='display: block;'>")));
                    Button button1 = new Button()
                    {
                        ID = string.Concat(this.ParentEstimateItemID, "_", this.ProofItemID, "_btnSave"),
                        Text = this.objLanguage.GetLanguageConversion("Save_Close")
                    };
                    button1.Attributes["class"] = "button";
                    estimateID = new object[] { "javascript:return CallSaveBtn(this.id,'", this.ParentEstimateItemID, "_btnSave',", this.CompanyID, ",'", this.ParentEstimateType, "',", this.EstimateID, ",", num5, ",", num6, ",", this.ProofItemID, ")" };
                    button1.OnClientClick = string.Concat(estimateID);
                    //button1.Click += new EventHandler(this.btnSave_Click);
                    if (this.OrderItemApprovalStatus == 1)
                    {

                        this.plhItems.Controls.Add(button1);
                    }
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_saveprocess_", this.ParentEstimateItemID, "' style='display: none; width:76px; height:14px; margin-top:1px;' class='button'>")));
                    this.plhItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />")));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhItems.Controls.Add(new LiteralControl("</div>"));
                }
               
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                proof_summary_main mainItemCnt = this;
                mainItemCnt.MainItemCnt = mainItemCnt.MainItemCnt + 1;
                this.plhItems.Controls.Add(new LiteralControl("</td>"));
                this.plhItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhItems.Controls.Add(new LiteralControl("</table>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
                this.plhItems.Controls.Add(new LiteralControl("</div>"));
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
        }
        public static void ShowDescriptionOnSummary(string pgType, int CompanyID, long ModuleID, long EstimateItemID, PlaceHolder plh, string itemTitle, string Isfromactivityhist, long ProofItemID, Boolean IsLocking = false)
        {
            BaseClass baseClass = new BaseClass();
            string str = global.strimagepath;
            string empty = string.Empty;
            string empty1 = string.Empty;
            bool flag = false;
            bool flag1 = false;
            string str1 = "visibility:visible;";
            string empty2 = string.Empty;
            string str2 = string.Empty;
            Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            languageClass _languageClass = new languageClass();
            commonClass _commonClass = new commonClass();
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@ProofItemID", (object)ProofItemID) };
            //DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_View", sqlParameter);
            DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_ProofItemDescription_View", sqlParameter);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                flag = Convert.ToBoolean(row["HasPurchaseOrder"]);
                flag1 = Convert.ToBoolean(row["HasDeliveryNote"]);
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                empty1 = Convert.ToString(dataRow["EstimateType"]);
            }
            foreach (DataRow row1 in dataSet.Tables[3].Rows)
            {
                empty2 = row1["SalesPersonID"].ToString();
            }
            plh.Controls.Add(new LiteralControl(string.Concat("<table cellpadding='0' cellspacing='0' align='center' id='tblDescription", EstimateItemID.ToString(), "' width='430px'   border='0'>")));
            plh.Controls.Add(new LiteralControl("<tr>"));
            plh.Controls.Add(new LiteralControl("<td valign='top' align='left' height='25px' >"));
            plh.Controls.Add(new LiteralControl("<div align='left' style='padding-top:15px;' >"));
            plh.Controls.Add(new LiteralControl(string.Concat("<b>&nbsp;&nbsp;", _languageClass.GetLanguageConversion("Customer_Item_Descriptions"), "</b> ")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div  align='right'>"));
            ControlCollection controls = plh.Controls;
            string[] languageConversion = new string[] { "<img style='margin-top: -15px; padding-bottom: 10px;' alt='Img' title='", _languageClass.GetLanguageConversion("Save_Phrase_Book"), "'  Class='book_icon' src='", str, "book.png'  />" };
            controls.Add(new LiteralControl(string.Concat(languageConversion)));
            plh.Controls.Add(new LiteralControl("</div >"));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("</tr>"));
            plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
            plh.Controls.Add(new LiteralControl("<td align='left' valign='top'>"));
            if (empty1 != "O")
            {
                plh.Controls.Add(new LiteralControl("<div style=' border:0px solid red;vertical-align:top; height:auto'>"));
            }
            else
            {
                plh.Controls.Add(new LiteralControl("<div style=' border:0px solid green; height:auto vertical-align:top'>"));
            }
            plh.Controls.Add(new LiteralControl(string.Concat("<table valign='top' cellpadding='0' cellspacing='3' align='center' id='tblDescription_nat", EstimateItemID.ToString(), "' width='450px'  border='0'>")));
            if (Isfromactivityhist.ToLower() == "yes")
            {
                str1 = "visibility:hidden;";
            }

            //var locking = objBase.ReturnRoles_Privileges_Others("locking").ToLower();
            //var IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);

            foreach (DataRow dataRow1 in dataSet.Tables[2].Rows)
            {
                plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
                plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
                string str3 = string.Concat("chk_", ProofItemID.ToString(), "_", dataRow1["FieldName"].ToString());
                if (Isfromactivityhist.ToLower() != "yes" || !IsLocking)
                {
                    ControlCollection controlCollections = plh.Controls;
                    string[] strArrays = new string[] { "<input id='", str3, "'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                }
                else
                {
                    ControlCollection controls1 = plh.Controls;
                    string[] strArrays1 = new string[] { "<input id='", str3, "' disabled='disabled'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("<td valign='top' style='width='100%;'>"));
                object[] estimateItemID = new object[] { "txtlabel_", ProofItemID, "_", dataRow1["FieldName"].ToString() };
                string str4 = string.Concat(estimateItemID);
                if (!IsLocking)
                {
                    ControlCollection controlCollections1 = plh.Controls;
                    string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                else
                {
                    ControlCollection controlCollections1 = plh.Controls;
                    string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20' disabled='disabled'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
                object[] objArray = new object[] { "txt_", ProofItemID, "_", dataRow1["FieldName"].ToString() };
                string str5 = string.Concat(objArray);
                ControlCollection controls2 = plh.Controls;
                object[] estimateItemID1 = new object[] { "<img src='", str, "plus.gif' style='", str1, "'  id='ImgPhrase_", ProofItemID, "_", dataRow1["FieldName"].ToString(), "' onclick=\"javascript:OpenPhraseBook('", dataRow1["PhraseType"].ToString(), "','", str5, "','", ModuleID, "','", dataRow1["PhraseValue"].ToString(), "');return false;\"/>" };
                controls2.Add(new LiteralControl(string.Concat(estimateItemID1)));
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("<td valign='top'>"));
                if (!IsLocking)
                {
                    ControlCollection controlCollections2 = plh.Controls;
                    object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' id='txt_", ProofItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
                }
                else
                {
                    ControlCollection controlCollections2 = plh.Controls;
                    object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' disabled='disabled' id='txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
                }
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("<td>"));
                string str6 = string.Concat("chk_toPhrase_", EstimateItemID.ToString(), "_", dataRow1["PhraseValue"].ToString());
                if (Isfromactivityhist.ToLower() != "yes")
                {
                    plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, " style='margin-left:-2px;' type='checkbox'/>")));
                }
                else
                {
                    plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, "  type='checkbox' style='margin-left:-2px;' disabled='disabled'/>")));
                }
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("</tr>"));
                object obj = empty;
                object[] objArray2 = new object[] { obj, dataRow1["PhraseValue"].ToString(), '£', str3, '\u00B6', str4, '$', str5, '€', str6, 'µ' };
                empty = string.Concat(objArray2);
            }
            plh.Controls.Add(new LiteralControl("<tr>"));
            plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'132px; padding-left:5px;  padding-top:20px;'>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<div style='padding-top:10px;'>", _languageClass.GetLanguageConversion("Accounting_Code"), "</div>")));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'40%;'>"));
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(CompanyID);
            dataTable1 = EstimatesBasePage.Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, empty1, ModuleID);
            plh.Controls.Add(new LiteralControl("<div style='width:'100%;'>"));
            DropDownList dropDownList = new DropDownList()
            {
                DataSource = dataTable,
                ID = string.Concat("ddlAc_Code_", ProofItemID),
                DataValueField = "AccountCodeID",
                DataTextField = "Code"
            };
            AttributeCollection attributes = dropDownList.Attributes;
            object[] companyID = new object[] { "javascript:SaveAccountingcode('", CompanyID, "','", EstimateItemID, "', '", empty1, "',this.value)" };
            attributes.Add("onchange", string.Concat(companyID));
            dropDownList.DataBind();
            if (dataTable1.Rows.Count <= 0)
            {
                dropDownList.Items.Insert(0, new ListItem("---Select---", "Select"));
                dropDownList.SelectedIndex = 0;
            }
            else
            {
                baseClass.SetDDLValue(dropDownList, dataTable1.Rows[0]["AccountCodeID"].ToString());
            }
            dropDownList.Style.Add("width", "98%");
            dropDownList.Style.Add("margin-top", "10px");
            plh.Controls.Add(dropDownList);
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("<td>"));
            plh.Controls.Add(new LiteralControl("</td>"));
            plh.Controls.Add(new LiteralControl("</tr>"));
            plh.Controls.Add(new LiteralControl("</table>"));
            //plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
            //if (empty1 == "O")
            //{
            //    plh.Controls.Add(new LiteralControl("<td valign='top'>"));
            //    plh.Controls.Add(new LiteralControl("<div style='padding:10px 0px 0px 9px; border:0px solid green;'>"));
            //    plh.Controls.Add(new LiteralControl("<span> Copy the item description fields above to:</span>"));
            //    plh.Controls.Add(new LiteralControl("<div  style='padding:4px 0px 0px 0px;'>"));

            //    //Rertieve the settings as 
            //    string IsCopyOutworkDescFieldsToSupplier = "";
            //    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows)
            //    {
            //        if (Convert.ToBoolean(row["CopyOutworkDescFieldsToSupplier"]))
            //        {
            //            IsCopyOutworkDescFieldsToSupplier = " checked='checked'";
            //        }
            //    }

            //    plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_Supplier_", EstimateItemID, "' type='checkbox' " + IsCopyOutworkDescFieldsToSupplier + " /><span>  Supplier request for quote item description fields</span>")));
            //    plh.Controls.Add(new LiteralControl("</div>"));
            //    if (pgType.ToLower() == "job")
            //    {
            //        if (flag)
            //        {
            //            plh.Controls.Add(new LiteralControl("<div >"));
            //            plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_PO_", EstimateItemID, "' type='checkbox' checked='true' /><span>  Purchase order item description fields</span>")));
            //            plh.Controls.Add(new LiteralControl("</div>"));
            //        }
            //        if (flag1)
            //        {
            //            plh.Controls.Add(new LiteralControl("<div >"));
            //            plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_DN_", EstimateItemID, "' type='checkbox' checked='true' /><span>  Delivery note item description fields</span>")));
            //            plh.Controls.Add(new LiteralControl("</div>"));
            //        }
            //    }
            //    plh.Controls.Add(new LiteralControl("</div>"));
            //    plh.Controls.Add(new LiteralControl("</td>"));
            //    plh.Controls.Add(new LiteralControl("</tr>"));
            //}
            str2 = (new BaseClass()).ReturnRoles_Privileges_Others("editrecords");
            if (Isfromactivityhist.ToLower() != "yes")
            {
                plh.Controls.Add(new LiteralControl("<tr>"));
                plh.Controls.Add(new LiteralControl("<td valign='top' align='right' style=' border:0px solid green; padding-right:37px;padding-top:5px'>"));
                if (str2.ToLower() != "his")
                {
                    ControlCollection controls3 = plh.Controls;
                    object[] estimateItemID2 = new object[] { "<input type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
                    controls3.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    ControlCollection controlCollections3 = plh.Controls;
                    object[] estimateItemID3 = new object[] { "<input type='hidden' style='display:none' id='hdnDescButton_", ProofItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
                    controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID3)));
                }
                else if (HttpContext.Current.Session["UserID"].ToString() != empty2)
                {
                    ControlCollection controls4 = plh.Controls;
                    object[] objArray3 = new object[] { "<input style='display:none' type='submit' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
                    controls4.Add(new LiteralControl(string.Concat(objArray3)));
                    ControlCollection controlCollections4 = plh.Controls;
                    object[] estimateItemID4 = new object[] { "<input style='display:none' type='hidden' id='hdnDescButton_", ProofItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
                    controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                }
                else
                {
                    ControlCollection controls5 = plh.Controls;
                    object[] objArray4 = new object[] { "<input  type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
                    controls5.Add(new LiteralControl(string.Concat(objArray4)));
                    ControlCollection controlCollections5 = plh.Controls;
                    object[] estimateItemID5 = new object[] { "<input  type='hidden' style='display:none' id='hdnDescButton_", ProofItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
                    controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                }
                plh.Controls.Add(new LiteralControl("</td>"));
                plh.Controls.Add(new LiteralControl("</tr>"));
            }
            plh.Controls.Add(new LiteralControl("</table>"));
        }


    }
}