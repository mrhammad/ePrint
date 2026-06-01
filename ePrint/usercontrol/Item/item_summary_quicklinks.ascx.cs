using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.usercontrol.Item
{
    public partial class item_summary_quicklinks : UsercontrolBasePage
    {
        //protected PlaceHolder plhSummaryBtns;

        //protected PlaceHolder plhjobLeftPanel;

        //protected HtmlGenericControl divJobCust;

        //protected HtmlTable tblQL;

        //protected PlaceHolder plhItems;

        //protected HiddenField hdnPCPath;

        //protected HiddenField hdnGetCookiesValue;

        //protected HiddenField hdngetparticularLIid;

        //protected HtmlGenericControl liReRun;

        //protected PlaceHolder plhAction;

        //protected HtmlGenericControl liCopyItem;

        //protected HtmlGenericControl liDeleteItem;

        //protected HtmlGenericControl liEditJobCard;

        //protected HtmlGenericControl liRevartItem;

        //protected PlaceHolder plhAction2;

        //protected HtmlGenericControl RCM_Options;

        //protected PlaceHolder plhSubItems;

        //protected HtmlGenericControl lisheefedDigital;

        //protected HtmlGenericControl lidigitalsingle;

        //protected HtmlGenericControl lidigitalPad;

        //protected HtmlGenericControl lisheetfedOffset;

        //protected HtmlGenericControl lioffsetsingle;

        //protected HtmlGenericControl lioffsetpads;

        //protected HtmlGenericControl liOutwork;

        //protected HtmlGenericControl liProductCatalogue;

        //protected HtmlGenericControl liOtherCost;

        //protected HtmlGenericControl liLargeItems;

        //protected HtmlGenericControl liLinear;

        //protected Label aSqmeter;

        //protected HtmlGenericControl liSqMeter;

        //protected PlaceHolder plhSubItems2;

        //protected HtmlGenericControl liaddItemhead;

        //protected PlaceHolder QL;

        //protected PlaceHolder plhQL;

        //protected PlaceHolder QL2;

        //protected HtmlGenericControl liQl;

        //protected PlaceHolder plhViewJobAllocation;

        //protected HtmlGenericControl liViewJobAllocation;

        //protected PlaceHolder ViewHistory;

        //protected HtmlGenericControl liViewHistory;

        //protected PlaceHolder quote_details;

        //protected HtmlGenericControl quote_dtls;

        //protected HtmlGenericControl div_WebstoreContent;

        //protected Panel pnlLeft;

        //protected HtmlGenericControl Div_RadSplit;

        public languageClass objLangClass = new languageClass();

        private BaseClass objBaseClass = new BaseClass();

        private commonClass commclass = new commonClass();

        public languageClass objLanguage = new languageClass();

        private BasePage objPage = new BasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string quicklinksfrom = string.Empty;

        public long ParentEstimateItemID;

        public string Module = string.Empty;

        public int OrderConvertedToJob;

        public int EstimateConvertedToJob;

        public string sectionid = string.Empty;

        public string companytype = string.Empty;

        private string jobconvertedtoinvoice = string.Empty;

        public string IsFromActHist = string.Empty;

        public string ParentEstimateType = string.Empty;

        public string ItemTitle = string.Empty;

        public bool IsShowDelete;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string IsEditOnlyHisRecords = string.Empty;

        public string SalesPersonID = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public int ManageStockPermission;

        public int SectionCount;

        public int OrderItemApprovalStatus;

        public long EstID;

        private string PaymentType = string.Empty;

        public string SR_WhenStockReduced = string.Empty;

        public long JobItemStatusID;
        public int AttachmentID;
        public long ProofItemID;

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

        public item_summary_quicklinks()
        {
        }

        public void EstimatesTypesfromDwebconfig()
        {
            if (ConnectionClass.SheetFedDigital == null)
            {
                this.lisheefedDigital.Visible = false;
                this.lidigitalsingle.Visible = false;
                this.lidigitalPad.Visible = false;
            }
            else
            {
                if (ConnectionClass.DigitalSingleItem == null)
                {
                    this.lidigitalsingle.Visible = false;
                }
                if (ConnectionClass.DigitalPads == null)
                {
                    this.lidigitalPad.Visible = false;
                }
            }
            if (ConnectionClass.SheetFedOffset == null)
            {
                this.lisheetfedOffset.Visible = false;
                this.lioffsetsingle.Visible = false;
                this.lioffsetpads.Visible = false;
            }
            else
            {
                if (ConnectionClass.OffsetSingleItem == null)
                {
                    this.lioffsetsingle.Visible = false;
                }
                if (ConnectionClass.OffsetPad == null)
                {
                    this.lioffsetpads.Visible = false;
                }
            }
            if (ConnectionClass.LargeFormat == null)
            {
                this.liLargeItems.Visible = false;
                this.liLinear.Visible = false;
                this.liSqMeter.Visible = false;
                this.liTilling.Visible = false;
            }
            else
            {
                if (ConnectionClass.Linear == null)
                {
                    this.liLinear.Visible = false;
                }
                if (ConnectionClass.SquareMeter == null)
                {
                    this.liSqMeter.Visible = false;
                }
                if (ConnectionClass.Tilling == null)
                {
                    this.liTilling.Visible = false;
                }
            }
            if (ConnectionClass.PriceCatalogue == null)
            {
                this.liProductCatalogue.Visible = false;
            }
            if (ConnectionClass.PrintBroker == null)
            {
                this.liOutwork.Visible = false;
            }
            //Add inventory as a sub item
            if (ConnectionClass.Inventory == null)
            {
                this.liInventory.Visible = false;
            }
            if (ConnectionClass.DeliveryCost == null)
            {
                this.liDeliveryCost.Visible = false;
            }
            if (ConnectionClass.OtherCosts != null)
            {
                return;
            }
            this.liOtherCost.Visible = false;
        }

        private void RenderAddSubItemDropdown()
        {
            if (!this.liaddItemhead.Visible)
            {
                return;
            }

            string parentId = this.ParentEstimateItemID.ToString();
            string parentType = this.ParentEstimateType ?? string.Empty;
            StringBuilder sb = new StringBuilder();
            string currentGroup = null;

            string addSubTitle = this.objLanguage.GetLanguageConversion("Add_Sub_Item");
            sb.Append("<div class='eprint-addsub-dropdown eprint-addsub-slot-inner' data-addsub-dropdown='1'>");
            sb.Append("<select class='eprint-addsub-select' id='ddlAddSubItem_");
            sb.Append(HttpUtility.HtmlAttributeEncode(parentId));
            sb.Append("' data-parent-id='");
            sb.Append(HttpUtility.HtmlAttributeEncode(parentId));
            sb.Append("' data-parent-type='");
            sb.Append(HttpUtility.HtmlAttributeEncode(parentType));
            sb.Append("' onchange='eprintRunAddSubItem(this)'>");
            sb.Append("<option value=''>");
            sb.Append(HttpUtility.HtmlEncode(addSubTitle));
            sb.Append("</option>");

            Action<string, bool, string, string> appendOption = (code, show, text, group) =>
            {
                if (!show || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(text))
                {
                    return;
                }
                if (!string.IsNullOrEmpty(group))
                {
                    if (currentGroup != group)
                    {
                        if (currentGroup != null)
                        {
                            sb.Append("</optgroup>");
                        }
                        sb.Append("<optgroup label='");
                        sb.Append(HttpUtility.HtmlAttributeEncode(group));
                        sb.Append("'>");
                        currentGroup = group;
                    }
                }
                else if (currentGroup != null)
                {
                    sb.Append("</optgroup>");
                    currentGroup = null;
                }

                sb.Append("<option value='");
                sb.Append(HttpUtility.HtmlAttributeEncode(code));
                sb.Append("'>");
                sb.Append(HttpUtility.HtmlEncode(text));
                sb.Append("</option>");
            };

            if (this.lisheefedDigital.Visible)
            {
                string digitalGroup = this.objLanguage.GetLanguageConversion("Sheet_Fed_Digital");
                appendOption("S", this.lidigitalsingle.Visible, this.objLanguage.GetLanguageConversion("Single_Item"), digitalGroup);
                appendOption("P", this.lidigitalPad.Visible, this.objLanguage.GetLanguageConversion("Pads"), digitalGroup);
            }

            if (this.lisheetfedOffset.Visible)
            {
                string offsetGroup = this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset");
                appendOption("F", this.lioffsetsingle.Visible, this.objLanguage.GetLanguageConversion("Single_Item"), offsetGroup);
                appendOption("D", this.lioffsetpads.Visible, this.objLanguage.GetLanguageConversion("Pads"), offsetGroup);
            }

            appendOption("O", this.liOutwork.Visible, this.objLanguage.GetLanguageConversion("Outwork"), null);
            appendOption("C", this.liProductCatalogue.Visible, this.objLanguage.GetLanguageConversion("Product_Catalogue"), null);
            appendOption("U", this.liOtherCost.Visible, this.objLanguage.GetLanguageConversion("Other_Cost"), null);
            appendOption("T", this.liDeliveryCost.Visible, this.objLanguage.GetLanguageConversion("Delivery_Cost"), null);

            if (this.liLargeItems.Visible)
            {
                string largeGroup = this.objLanguage.GetLanguageConversion("Large_Format");
                appendOption("L", this.liLinear.Visible, this.objLanguage.GetLanguageConversion("Linear"), largeGroup);
                string sqLabel = !string.IsNullOrEmpty(this.aSqmeter.Text)
                    ? this.aSqmeter.Text.Trim()
                    : this.objLanguage.GetLanguageConversion("Square_Feet");
                appendOption("Sq", this.liSqMeter.Visible, sqLabel, largeGroup);
                appendOption("ti", this.liTilling.Visible, "Tilling", largeGroup);
            }

            appendOption("W", this.liInventory.Visible, this.objLanguage.GetLanguageConversion("Inventory"), null);

            if (currentGroup != null)
            {
                sb.Append("</optgroup>");
            }

            sb.Append("</select></div>");

            this.plhSubItems.Controls.Add(new LiteralControl(sb.ToString()));
            this.HideLegacyAddSubItemList();

            string existingClass = this.liaddItemhead.Attributes["class"] ?? "summary_itemsalign";
            if (existingClass.IndexOf("eprint-addsub-dropdown-mode", StringComparison.OrdinalIgnoreCase) < 0)
            {
                this.liaddItemhead.Attributes["class"] = existingClass + " eprint-addsub-dropdown-mode";
            }
            this.liaddItemhead.Attributes["data-addsub-dropdown"] = "1";
        }

        private void HideLegacyAddSubItemList()
        {
            this.lisheefedDigital.Visible = false;
            this.lidigitalsingle.Visible = false;
            this.lidigitalPad.Visible = false;
            this.lisheetfedOffset.Visible = false;
            this.lioffsetsingle.Visible = false;
            this.lioffsetpads.Visible = false;
            this.liOutwork.Visible = false;
            this.liProductCatalogue.Visible = false;
            this.liOtherCost.Visible = false;
            this.liDeliveryCost.Visible = false;
            this.liLargeItems.Visible = false;
            this.liLinear.Visible = false;
            this.liSqMeter.Visible = false;
            this.liTilling.Visible = false;
            this.liInventory.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {



            DataRow[] dataRowArray;
            int i;
            object[] estimateID;
            string[] languageConversion;
            this.SR_WhenStockReduced = this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
            long invoiceID = (long)0;
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            DataTable dataTable = JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, this.ParentEstimateItemID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
            }
            DataTable dataTable1 = new DataTable();
            if (this.EstimateID > (long)0)
            {
                this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.EstimateID);
                dataTable1 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.EstimateID);
            }
            this.liRevartItem.Visible = false;
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                if (base.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true")
                {
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isrevert", "").Trim().ToLower() == "1")
                    {
                        if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe") || dataTable1.Rows.Count > 0)
                        {
                            this.liRevartItem.Visible = false;
                        }
                        else
                        {
                            this.liRevartItem.Visible = true;
                        }
                    }
                }
                else if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe") || dataTable1.Rows.Count > 0)
                {
                    this.liRevartItem.Visible = false;
                }
                else
                {
                    this.liRevartItem.Visible = true;
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("proofs/proof"))
            {
                this.Module = "proof";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate"))
            {
                this.Module = "estimate";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.Module = "order";
            }
            if (base.Request.Url.ToString() == string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"))
            {
                this.hdnGetCookiesValue.Value = "";
                this.hdngetparticularLIid.Value = "";
                if (base.Response.Cookies["MainTabSelect"] != null)
                {
                    base.Response.Cookies["MainTabSelect"].Value = "";
                }
                if (base.Response.Cookies["SubTabSelect"] != null)
                {
                    base.Response.Cookies["SubTabSelect"].Value = "";
                }
            }
            this.liViewHistory.Visible = false;
            DataTable dataTable2 = new DataTable();
            DataTable dataTable3 = this.objBase.UserAccessRights_OnConditionally((long)this.CompanyID, (long)this.UserID);

            string jobItemsSessionKey = $"JobItems_{this.jobID}";
            string quickLinkSessionKey = $"QuickLink_{this.CompanyID}_{this.jobID}_{this.Module}";


            if (this.Module.ToLower() == "invoice")
            {
                invoiceID = this.InvoiceID;
            }
            else if (this.Module.ToLower() != "job")
            {
                invoiceID = this.EstimateID;
            }
            else
            {
                invoiceID = this.jobID;
                if (this.jobID > (long)0)
                {
                    //dataTable2 = JobsBasePage.Select_All_Job_Item(this.jobID);
                    if (Session[jobItemsSessionKey] != null)
                    {
                        dataTable2 = (DataTable)Session[jobItemsSessionKey];
                    }
                    else
                    {
                        dataTable2 = JobsBasePage.Select_All_Job_Item(this.jobID);
                        Session[jobItemsSessionKey] = dataTable2;
                    }
                }
            }
            DataSet dataSet = new DataSet();
            //dataSet = EstimateBasePage.PC_QuickLinkDetails_Select(this.CompanyID, invoiceID, this.Module);

            if (Session[quickLinkSessionKey] != null)
            {
                dataSet = (DataSet)Session[quickLinkSessionKey];
            }
            else
            {
                dataSet = EstimateBasePage.PC_QuickLinkDetails_Select(this.CompanyID, this.jobID, this.Module);
                Session[quickLinkSessionKey] = dataSet;
            }

            DataTable item = new DataTable();
            DataTable item1 = new DataTable();
            item = dataSet.Tables[0];
            item1 = dataSet.Tables[1];
            if (this.quicklinksfrom == "customer details")
            {
                this.Div_RadSplit.Visible = false;
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    this.divJobCust.Attributes.Add("style", "display:block");
                    this.plhjobLeftPanel.Visible = true;
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div>"));
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    string empty4 = string.Empty;
                    long num = (long)0;
                    bool flag = false;
                    dataRowArray = dataTable3.Select("SectionName='Estimates'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow = dataRowArray[i];
                        flag = Convert.ToBoolean(dataRow["IsDisplay"]);
                    }
                    if (item.Rows.Count > 0)
                    {
                        if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("orders/order") /*&& !base.Request.Url.ToString().ToLower().Contains("proofs/proof")*/)
                        {
                            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                            {
                                if(item.Rows[0]["OrderNo"].ToString().ToLower().Contains("ord-"))
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":&nbsp;")));
                                }
                                else
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":&nbsp;")));
                                }
                            }
                            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                            {
                                this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":&nbsp;")));
                            }
                            foreach (DataRow row1 in item.Rows)
                            {
                                empty = row1["EstimateNumber"].ToString();
                                str = row1["EstimateDate"].ToString();
                                str1 = row1["OrderNo"].ToString();
                                empty1 = row1["OrderDate"].ToString();
                                num = Convert.ToInt64(row1["OrderID"].ToString());
                                this.EstimateID = Convert.ToInt64(row1["OrderID"].ToString());
                                row1["IsForInvoice"].ToString();
                                empty4 = (num == (long)0 ? "" : string.Concat("&ordid=", num));
                                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                                {
                                    if (!flag || !(empty != ""))
                                    {
                                        continue;
                                    }
                                    ControlCollection controls = this.plhjobLeftPanel.Controls;
                                    if (item.Rows[0]["OrderNo"].ToString().ToLower().Contains("ord-"))
                                    {
                                        estimateID = new object[] { "<div><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num, "&estid=", this.EstimateID, "' target='' >", str1, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty1, this.CompanyID, this.UserID, true), "</div>" };
                                    }
                                    else
                                    {
                                        estimateID = new object[] { "<div><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='' >", empty, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(str, this.CompanyID, this.UserID, false), "</div>" };
                                    }
                                    controls.Add(new LiteralControl(string.Concat(estimateID)));
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                                }
                                else
                                {
                                    if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                                    {
                                        continue;
                                    }
                                    bool flag1 = false;
                                    dataRowArray = dataTable3.Select("SectionName='WebstoreOrder'");
                                    for (i = 0; i < (int)dataRowArray.Length; i++)
                                    {
                                        DataRow dataRow1 = dataRowArray[i];
                                        flag1 = Convert.ToBoolean(dataRow1["IsDisplay"]);
                                    }
                                    if (!flag1 || !(str1 != ""))
                                    {
                                        continue;
                                    }
                                    ControlCollection controlCollections = this.plhjobLeftPanel.Controls;
                                    estimateID = new object[] { "<div><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num, "&estid=", this.EstimateID, "' target='' >", str1, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty1, this.CompanyID, this.UserID, true), "</div>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(estimateID)));
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                                }
                            }
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("orders/order"))
                    {
                        if (item1.Rows.Count <= 0)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br>Direct Invoice<br/></div>")));
                        }
                        else
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br>Direct Job<br/></div>")));
                        }
                    }
                    if (item1.Rows.Count > 0)
                    {
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;")));
                            foreach (DataRow row2 in item1.Rows)
                            {
                                this.jobconvertedtoinvoice = row2["isconverted"].ToString();
                                empty2 = row2["JobCreatedDate"].ToString();
                                str2 = row2["JobNumber"].ToString();
                                this.EstimateID = Convert.ToInt64(row2["EstimateID"]);
                                if (row2["JobID"].ToString() != "")
                                {
                                    this.jID = string.Concat("&jID=", row2["JobID"].ToString());
                                }
                                bool flag2 = false;
                                dataRowArray = dataTable3.Select("SectionName='Jobs'");
                                for (i = 0; i < (int)dataRowArray.Length; i++)
                                {
                                    DataRow dataRow2 = dataRowArray[i];
                                    flag2 = Convert.ToBoolean(dataRow2["IsDisplay"]);
                                }
                                if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                                {
                                    if (!flag2 || !(str2 != ""))
                                    {
                                        continue;
                                    }
                                    ControlCollection controls1 = this.plhjobLeftPanel.Controls;
                                    estimateID = new object[] { "<div><a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' target='' onclick=''>", str2, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty2, this.CompanyID, this.UserID, false), "</div>" };
                                    controls1.Add(new LiteralControl(string.Concat(estimateID)));
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                                }
                                else
                                {
                                    if (!base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") || !flag2 || !(str2 != ""))
                                    {
                                        continue;
                                    }
                                    ControlCollection controlCollections1 = this.plhjobLeftPanel.Controls;
                                    estimateID = new object[] { "<div><a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", num, "&estid=", this.EstimateID, this.jID, "' target='' onclick=''>", str2, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty2, this.CompanyID, this.UserID, false), "</div>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(estimateID)));
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                                }
                            }
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                    {
                        if (base.Request.Url.ToString().ToLower().Contains("orders/order"))
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ": <br/></div>")));
                        }
                        else if (item.Rows.Count != 0)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ": <br/></div>")));
                        }
                        else
                        {
                            ControlCollection controls2 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Invoice"), "<br/></div>" };
                            controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ":&nbsp;<br/>")));
                        LinkButton linkButton = new LinkButton();
                        string str4 = string.Empty;
                        linkButton.ID = "lnkjobinvProgress";
                        linkButton.Text = "Create";
                        linkButton.CssClass = "create";
                        string empty5 = string.Empty;
                        string str5 = string.Empty;
                        DataTable dataTable4 = new DataTable();
                        int num1 = 0;
                        if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "order")
                        {
                            dataTable4 = InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstimateID);
                        }
                        else if (this.Module.ToLower() == "job")
                        {
                            dataTable4 = InvoiceBasePage.Invoice_Select_By_JobID(this.CompanyID, this.jobID);
                        }
                        foreach (DataRow row3 in dataTable4.Rows)
                        {
                            empty5 = Convert.ToString(row3["InvoiceNumber"].ToString());
                            str5 = Convert.ToString(row3["CreatedDate"].ToString());
                            num1 = Convert.ToInt16(row3["RemainingItemCount"]);
                            if (row3["InvoiceID"].ToString() != "")
                            {
                                this.InvID = string.Concat("&InvID=", row3["InvoiceID"].ToString());
                            }
                            string empty6 = string.Empty;
                            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx"))
                            {
                                estimateID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?", this.InvID, "&estid=", this.EstimateID };
                                empty6 = string.Concat(estimateID);
                            }
                            else
                            {
                                estimateID = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?", this.InvID, "&estid=", this.EstimateID };
                                empty6 = string.Concat(estimateID);
                            }
                            bool flag3 = false;
                            dataRowArray = dataTable3.Select("SectionName='Invoices'");
                            for (i = 0; i < (int)dataRowArray.Length; i++)
                            {
                                DataRow dataRow3 = dataRowArray[i];
                                flag3 = Convert.ToBoolean(dataRow3["IsDisplay"]);
                            }
                            if (flag3 && empty5 != "")
                            {
                                languageConversion = new string[] { "<a href='", empty6, "' target=''> ", empty5, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(str5, this.CompanyID, this.UserID, false), "<br>" };
                                str4 = string.Concat(languageConversion);
                            }
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(str4.ToString()));
                        }
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                        {
                            bool flag4 = false;
                            bool flag44 = false;
                            dataRowArray = dataTable3.Select("SectionName='Invoices'");
                            for (i = 0; i < (int)dataRowArray.Length; i++)
                            {
                                DataRow dataRow4 = dataRowArray[i];
                                flag4 = Convert.ToBoolean(dataRow4["IsDisplay"]);
                                flag44 = Convert.ToBoolean(dataRow4["IsAdd"]);
                            }
                            if (flag4)
                            {
                                if (!flag44) //&& empty5 == ""
                                {
                                }
                                else
                                {
                                    if (dataTable2.Rows.Count == 1 || dataTable1.Rows.Count > 0 || this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe"))
                                    {
                                        AttributeCollection attributes = linkButton.Attributes;
                                        estimateID = new object[] { "javascript: CheckInvoicePossible_SplitOff(", this.EstimateID, ", 0, 'main',", this.jobID, ",'", this.SR_WhenStockReduced, "'); return false;" };
                                        attributes.Add("onclick", string.Concat(estimateID));
                                        this.plhjobLeftPanel.Controls.Add(linkButton);
                                    }
                                    else if (num1 > 0 || dataTable4.Rows.Count == 0)
                                    {
                                        AttributeCollection attributeCollection = linkButton.Attributes;
                                        estimateID = new object[] { "javascript:return OpenCreateInvoice(", this.EstimateID, ", 0, 'main',", this.jobID, ");" };
                                        attributeCollection.Add("onclick", string.Concat(estimateID));
                                        this.plhjobLeftPanel.Controls.Add(linkButton);
                                    }
                                }
                            }
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    if (ConnectionClass.DeliveryNote != null)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        DataTable dataTable5 = new DataTable();
                        if (this.Module.ToLower() != "invoice")
                        {
                            dataTable5 = (this.Module.ToLower() != "job" ? EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstimateID, (long)0, "") : EstimatesBasePage.estimate_deliverynote_ByJobID_selectall(this.CompanyID, this.jobID));
                        }
                        else
                        {
                            dataTable5 = EstimatesBasePage.Invoice_DeliveryNote_QuickLinks_Select(this.CompanyID, this.InvoiceID, (long)0);
                        }
                        bool flag5 = false;
                        dataRowArray = dataTable3.Select("SectionName='DeliveryNote'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow5 = dataRowArray[i];
                            flag5 = Convert.ToBoolean(dataRow5["IsDisplay"]);
                        }
                        if (dataTable5.Rows.Count > 0)
                        {
                            stringBuilder.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br>"));
                        }
                        else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ": </div>")));
                        }
                        else if (!flag5)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br><a href='#' class='create' onclick='javascript:OpenMultiDeliveryNote();'></a>")));
                        }
                        else
                        {
                            ControlCollection controlCollections2 = this.plhjobLeftPanel.Controls;
                            //languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br><a href='#' class='create' onclick='javascript:OpenMultiDeliveryNote();'>", this.objLangClass.GetLanguageConversion("Create"), "</a>" };
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br><a href='#' class='create' onclick='javascript:OpenDeliveryNoteSelectItems();'>", this.objLangClass.GetLanguageConversion("Create"), "</a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        int num2 = 1;
                        int num3 = 1;
                        foreach (DataRow row4 in dataTable5.Rows)
                        {
                            string str6 = Convert.ToString(row4["DeliveryDate"].ToString());
                            if (dataTable5.Rows.Count <= 1)
                            {
                                estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row4["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty4, this.jID, this.InvID };
                                string str7 = string.Concat(estimateID);
                                if (row4["DeliveryNumber"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ": </div>")));
                                }
                                else if (!flag5)
                                {
                                    stringBuilder.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row4["DeliveryNumber"], "</label>"));
                                }
                                else
                                {
                                    estimateID = new object[] { "<a href='", str7, "' target=''> ", row4["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(str6, this.CompanyID, this.UserID, false) };
                                    stringBuilder.Append(string.Concat(estimateID));
                                }
                            }
                            else
                            {
                                string str8 = "";
                                if (num2 != 1)
                                {
                                    str8 = "<br/>";
                                }
                                estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row4["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty4, this.jID, this.InvID };
                                string str9 = string.Concat(estimateID);
                                if (row4["DeliveryNumber"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ": </div>")));
                                }
                                else if (!flag5)
                                {
                                    estimateID = new object[] { str8, "<label class='normalText' style='cursor: default'> ", row4["DeliveryNumber"], "</label>" };
                                    stringBuilder.Append(string.Concat(estimateID));
                                    num2++;
                                }
                                else
                                {
                                    estimateID = new object[] { str8, "<a href='", str9, "' target=''> ", row4["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(str6, this.CompanyID, this.UserID, false) };
                                    stringBuilder.Append(string.Concat(estimateID));
                                    num2++;
                                }
                            }
                            num3++;
                        }
                        if (dataTable5.Rows.Count > 0 && (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")))
                        {
                            if (!flag5)
                            {
                                stringBuilder.Append("<br/><label  class='create' style='cursor: default'></label>");
                            }
                            else if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                            {
                                //stringBuilder.Append(string.Concat("<br/><a href='#' onclick='javascript:OpenMultiDeliveryNote();' class='create'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                                stringBuilder.Append(string.Concat("<br/><a href='#' onclick='javascript:OpenDeliveryNoteSelectItems();' class='create'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                            }
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    StringBuilder stringBuilder1 = new StringBuilder();
                    DataTable dataTable6 = new DataTable();
                    if (this.Module.ToLower() != "invoice")
                    {
                        dataTable6 = (this.Module.ToLower() != "job" ? EstimateBasePage.purchase_select_by_EstimateID(this.CompanyID, this.EstimateID) : EstimateBasePage.purchase_select_by_JobID(this.CompanyID, this.jobID));
                    }
                    else
                    {
                        dataTable6 = EstimateBasePage.Invoice_Purchase_QuickLinks_Select(this.CompanyID, this.InvoiceID);
                    }
                    bool flag6 = false;
                    bool flag7 = false;
                    dataRowArray = dataTable3.Select("SectionName='Purchases'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow6 = dataRowArray[i];
                        flag6 = Convert.ToBoolean(dataRow6["IsDisplay"]);
                        flag7 = Convert.ToBoolean(dataRow6["IsAdd"]);
                    }
                    if (flag6)
                    {
                        if (dataTable6.Rows.Count > 0)
                        {
                            stringBuilder1.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br>"));
                        }
                        else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":</div> ")));
                        }
                        else if (!flag7)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":&nbsp;")));
                        }
                        else
                        {
                            ControlCollection controls3 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br> <a class='create' href='#' onclick='javascript:CreatePurchase_reeng();'>", this.objLangClass.GetLanguageConversion("Create"), "</a>" };
                            controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        int num4 = 1;
                        int num5 = 1;
                        foreach (DataRow row5 in dataTable6.Rows)
                        {
                            if (dataTable6.Rows.Count <= 1)
                            {
                                estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row5["PurchaseID"].ToString(), empty4, this.jID };
                                string str10 = string.Concat(estimateID);
                                if (row5["PONO"] != null)
                                {
                                    estimateID = new object[] { "<a href='", str10, "' target=''> ", row5["PONO"], "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row5["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder1.Append(string.Concat(estimateID));
                                }
                            }
                            else
                            {
                                string str11 = "";
                                if (num4 != 1)
                                {
                                    str11 = "<br/>";
                                }
                                estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row5["PurchaseID"].ToString(), "&ordid=", this.EstimateID, this.jID };
                                string str12 = string.Concat(estimateID);
                                if (row5["PONO"].ToString() != "")
                                {
                                    languageConversion = new string[] { str11, "<a href='", str12, "' target=''> ", row5["PONO"].ToString(), "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row5["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder1.Append(string.Concat(languageConversion));
                                    num4++;
                                }
                            }
                            num5++;
                        }
                        if (dataTable6.Rows.Count > 0)
                        {
                            string.Concat(this.strSitepath, "Purchase/purchase_add.aspx?type=add&pg=job&estid=", this.EstimateID);
                            if ((base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")) && flag7)
                            {
                                stringBuilder1.Append(string.Concat("<br/><a href='#' class='create' onclick='javascript:CreatePurchase_reeng();'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                            }
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    StringBuilder stringBuilder2 = new StringBuilder();
                    if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
                        string empty7 = string.Empty;
                        DataTable dataTable7 = new DataTable();
                        if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
                        {
                            empty7 = "estimate";
                            dataTable7 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, empty7);
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx"))
                        {
                            empty7 = "job";
                            dataTable7 = EstimatesBasePage.estimate_item_select_reeng_ByJob(this.CompanyID, this.jobID, empty7);
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                        {
                            empty7 = "invoice";
                            dataTable7 = EstimatesBasePage.estimate_item_select_reeng_ByInvoice(this.CompanyID, this.InvoiceID, empty7);
                        }
                        this.hdnPCPath.Value = string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx");
                        stringBuilder2.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Product_Catalogue"), ":<br>"));
                        string empty8 = string.Empty;
                        foreach (DataRow row6 in dataTable7.Rows)
                        {
                            long num6 = (long)Convert.ToInt32(row6["estimateItemID"].ToString());
                            if (row6["EstimateType"].ToString().ToLower() == "x")
                            {
                                continue;
                            }
                            if (row6["EstimateType"].ToString().ToLower() != "o")
                            {
                                if (row6["IsProductCreated"].ToString() != "1")
                                {
                                    estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row6["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num6, ");'>Create</a></div>" };
                                    stringBuilder2.Append(string.Concat(estimateID));
                                    estimateID = new object[] { "<input id='hdnEstType_", num6, "' type='hidden' value='", row6["EstimateType"].ToString(), "~", empty7, "' />" };
                                    stringBuilder2.Append(string.Concat(estimateID));
                                }
                                else
                                {
                                    DataTable dataTable8 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, Convert.ToInt64(row6["EstimateItemID"].ToString()), row6["EstimateType"].ToString());
                                    if (dataTable8.Rows.Count <= 0)
                                    {
                                        estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row6["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num6, ");'>Create</a></div>" };
                                        stringBuilder2.Append(string.Concat(estimateID));
                                        estimateID = new object[] { "<input id='hdnEstType_", num6, "' type='hidden' value='", row6["EstimateType"].ToString(), "~", empty7, "' />" };
                                        stringBuilder2.Append(string.Concat(estimateID));
                                    }
                                    else
                                    {
                                        estimateID = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", dataTable8.Rows[0]["PricecatalogueID"], "&pgFrom=", empty7, "&EstID=", this.EstimateID, "&EstItemID=", Convert.ToInt64(row6["EstimateItemID"].ToString()), this.jID, this.InvID };
                                        empty8 = string.Concat(estimateID);
                                        languageConversion = new string[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left' style='word-break: break-all;'><a href='", empty8, "' target=''>", dataTable8.Rows[0]["ItemCode"].ToString(), "-", this.objBase.SpecialDecode(dataTable8.Rows[0]["CatalogueName"].ToString()), "</a></div>" };
                                        stringBuilder2.Append(string.Concat(languageConversion));
                                    }
                                }
                            }
                            else if (Convert.ToInt64(row6["PIDOutworkType"].ToString() == "" ? "0" : row6["PIDOutworkType"]) != (long)0)
                            {
                                stringBuilder2.Append("");
                            }
                            else if (row6["IsProductCreated"].ToString() != "1")
                            {
                                estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row6["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num6, ");'>Create</a></div>" };
                                stringBuilder2.Append(string.Concat(estimateID));
                                estimateID = new object[] { "<input id='hdnEstType_", num6, "' type='hidden' value='", row6["EstimateType"].ToString(), "~", empty7, "' />" };
                                stringBuilder2.Append(string.Concat(estimateID));
                            }
                            else
                            {
                                DataTable dataTable9 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, Convert.ToInt64(row6["EstimateItemID"].ToString()), row6["EstimateType"].ToString());
                                if (dataTable9.Rows.Count <= 0)
                                {
                                    estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row6["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num6, ");'>Create</a></div>" };
                                    stringBuilder2.Append(string.Concat(estimateID));
                                    estimateID = new object[] { "<input id='hdnEstType_", num6, "' type='hidden' value='", row6["EstimateType"].ToString(), "~", empty7, "' />" };
                                    stringBuilder2.Append(string.Concat(estimateID));
                                }
                                else
                                {
                                    estimateID = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", dataTable9.Rows[0]["PricecatalogueID"], "&pgFrom=", empty7, "&EstID=", this.EstimateID, "&EstItemID=", Convert.ToInt64(row6["EstimateItemID"].ToString()), this.jID, this.InvID };
                                    empty8 = string.Concat(estimateID);
                                    languageConversion = new string[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row6["itemtitle"].ToString()), ":</div><div align='left' style='word-break: break-all;'><a href='", empty8, "' target=''>", dataTable9.Rows[0]["ItemCode"].ToString(), "-", this.objBase.SpecialDecode(dataTable9.Rows[0]["CatalogueName"].ToString()), "</a></div>" };
                                    stringBuilder2.Append(string.Concat(languageConversion));
                                }
                            }
                        }
                        stringBuilder2.Append("</div>");
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div id='activities-all' style='padding-left:5px; background-color: #ECECEC;' ><a href='#' onclick='javascript:ShowNotes();'>", this.objLangClass.GetLanguageConversion("View_History"), "</a></div></div></div>")));
                }
                if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&id=") || base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&pg=job&estid=") || base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit&id="))
                {
                    this.divJobCust.Attributes.Add("style", "display:block");
                    this.plhjobLeftPanel.Visible = true;
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div>"));
                    string empty9 = string.Empty;
                    string empty10 = string.Empty;
                    string str13 = "False";
                    string empty11 = string.Empty;
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    string empty14 = string.Empty;
                    string str14 = string.Empty;
                    string empty15 = string.Empty;
                    string str15 = string.Empty;
                    string empty16 = string.Empty;
                    string str16 = string.Empty;
                    long num7 = (long)0;
                    long num8 = (long)0;
                    if (base.Request.Params["jID"] != null)
                    {
                        num8 = Convert.ToInt64(base.Request.Params["jID"]);
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx"))
                    {
                        if (base.Request.Params["id"] != null)
                        {
                            long num9 = Convert.ToInt64(base.Request.Params["id"].ToString());
                            foreach (DataRow row7 in EstimateBasePage.DeliveryNote_ItemID_Select(num9).Rows)
                            {
                                this.EstimateID = Convert.ToInt64(row7["EstimateID"]);
                            }
                        }
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx") && base.Request.Params["id"] != null)
                    {
                        long num10 = Convert.ToInt64(base.Request.Params["id"].ToString());
                        foreach (DataRow dataRow7 in EstimateBasePage.EstimateItemID_Select(this.CompanyID, this.UserID, num10).Rows)
                        {
                            this.EstimateID = Convert.ToInt64(dataRow7["EstimateID"]);
                        }
                    }
                    foreach (DataRow row8 in JobBasePage.Jobs_Jobcard_Jobdetails_select(this.CompanyID, num8).Rows)
                    {
                        this.sectionid = row8["CustomerID"].ToString();
                        this.companytype = row8["CompanyType"].ToString();
                        empty9 = row8["IsDirectJob"].ToString();
                        str13 = row8["IsForInvoice"].ToString();
                        empty10 = row8["EstimateNumber"].ToString();
                        this.jobconvertedtoinvoice = row8["isconverted"].ToString();
                        empty11 = row8["EstimateDate"].ToString();
                        empty13 = row8["OrderNo"].ToString();
                        empty12 = row8["OrderDate"].ToString();
                        num7 = Convert.ToInt64(row8["OrderID"].ToString());
                        this.EstimateID = Convert.ToInt64(row8["OrderID"]);
                        this.EstimateConvertedToJob = Convert.ToInt32(row8["EstimateConvertedToJob"]);
                        this.OrderConvertedToJob = Convert.ToInt32(row8["OrderConvertedToJob"]);
                        empty14 = row8["JobCreatedDate"].ToString();
                        str14 = row8["JobNumber"].ToString();
                        row8["InvoiceDate"].ToString();
                        row8["InvoiceNumber"].ToString();
                    }
                    empty16 = (num7 == (long)0 ? "" : string.Concat("&ordid=", num7));
                    if (this.EstimateID == (long)0)
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate_Order"), ": </div>")));
                    }
                    else if (empty9 != null && empty9 != "")
                    {
                        bool flag8 = false;
                        dataRowArray = dataTable3.Select("SectionName='Estimates'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow8 = dataRowArray[i];
                            flag8 = Convert.ToBoolean(dataRow8["IsDisplay"]);
                        }
                        if (!Convert.ToBoolean(empty9) && !Convert.ToBoolean(str13))
                        {
                            if (num7 != (long)0)
                            {
                                bool flag9 = false;
                                dataRowArray = dataTable3.Select("SectionName='WebstoreOrder'");
                                for (i = 0; i < (int)dataRowArray.Length; i++)
                                {
                                    DataRow dataRow9 = dataRowArray[i];
                                    flag9 = Convert.ToBoolean(dataRow9["IsDisplay"]);
                                }
                                if (!flag9)
                                {
                                    ControlCollection controlCollections3 = this.plhjobLeftPanel.Controls;
                                    languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><label class='normalText' style='cursor: default'>", empty13, "</label><br/></div>" };
                                    controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                                }
                                else
                                {
                                    ControlCollection controls4 = this.plhjobLeftPanel.Controls;
                                    estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num7, "&estid=", this.EstimateID, this.jID, this.InvID, "' target='' onclick=''>", empty13, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty12, this.CompanyID, this.UserID, false), "</div>" };
                                    controls4.Add(new LiteralControl(string.Concat(estimateID)));
                                }
                            }
                            else if (flag8)
                            {
                                ControlCollection controlCollections4 = this.plhjobLeftPanel.Controls;
                                estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='' onclick=''>", empty10, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty11, this.CompanyID, this.UserID, false), " </div>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(estimateID)));
                            }
                            else
                            {
                                ControlCollection controls5 = this.plhjobLeftPanel.Controls;
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><label class='normalText' style='cursor: default'>", empty10, "</label><br/></div>" };
                                controls5.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                        else if (!flag8)
                        {
                            ControlCollection controlCollections5 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><label class='normalText' style='cursor: default'>", empty10, "</label><br/></div>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else if (empty10 == "")
                        {
                            ControlCollection controls6 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate_Order"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Job"), "<br/></div>" };
                            controls6.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            ControlCollection controlCollections6 = this.plhjobLeftPanel.Controls;
                            estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary.aspx?frm=view&estid=", this.EstimateID, "' target='' onclick=''>", empty10, "</a><br/></div>" };
                            controlCollections6.Add(new LiteralControl(string.Concat(estimateID)));
                        }
                    }
                    bool flag10 = false;
                    dataRowArray = dataTable3.Select("SectionName='Jobs'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow10 = dataRowArray[i];
                        flag10 = Convert.ToBoolean(dataRow10["IsDisplay"]);
                    }
                    if (this.EstimateID == (long)0)
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ": </div>")));
                    }
                    else if (str14 == "")
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ": </div>")));
                    }
                    else if (!flag10)
                    {
                        ControlCollection controls7 = this.plhjobLeftPanel.Controls;
                        languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br><label class='normalText' style='cursor: default'>", str14, "</label><br/></div>" };
                        controls7.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else if (empty13 == "")
                    {
                        ControlCollection controlCollections7 = this.plhjobLeftPanel.Controls;
                        estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br><a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='' onclick=''>", str14, "</a><br/> Date: ", this.commclass.Eprint_return_Date_Before_View(empty14, this.CompanyID, this.UserID, false), "</div>" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateID)));
                    }
                    else
                    {
                        ControlCollection controls8 = this.plhjobLeftPanel.Controls;
                        estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br><a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", num7, "&estid=", this.EstimateID, "' target='' onclick=''>", str14, "</a><br/> Date: ", this.commclass.Eprint_return_Date_Before_View(empty14, this.CompanyID, this.UserID, false), "</div>" };
                        controls8.Add(new LiteralControl(string.Concat(estimateID)));
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit&id=") && ConnectionClass.DeliveryNote != null)
                    {
                        StringBuilder stringBuilder3 = new StringBuilder();
                        DataTable dataTable10 = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstimateID, (long)0, "");
                        bool flag11 = false;
                        dataRowArray = dataTable3.Select("SectionName='DeliveryNote'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow11 = dataRowArray[i];
                            flag11 = Convert.ToBoolean(dataRow11["IsDisplay"]);
                        }
                        if (this.EstimateID != (long)0)
                        {
                            if (dataTable10.Rows.Count <= 0)
                            {
                                this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":&nbsp;none")));
                            }
                            else
                            {
                                stringBuilder3.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br>"));
                            }
                            int num11 = 1;
                            foreach (DataRow row9 in dataTable10.Rows)
                            {
                                if (dataTable10.Rows.Count <= 1)
                                {
                                    estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row9["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty16 };
                                    string str17 = string.Concat(estimateID);
                                    if (row9["DeliveryNumber"] == null)
                                    {
                                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":")));
                                    }
                                    else if (!flag11)
                                    {
                                        stringBuilder3.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row9["DeliveryNumber"], "</label>"));
                                    }
                                    else
                                    {
                                        estimateID = new object[] { "<a href='", str17, "' target=''> ", row9["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row9["DeliveryDate"].ToString()), this.CompanyID, this.UserID, false) };
                                        stringBuilder3.Append(string.Concat(estimateID));
                                    }
                                }
                                else
                                {
                                    string str18 = "";
                                    if (num11 != 1)
                                    {
                                        str18 = "<br/>";
                                    }
                                    estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row9["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty16 };
                                    string str19 = string.Concat(estimateID);
                                    if (row9["DeliveryNumber"] == null)
                                    {
                                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":")));
                                    }
                                    else if (!flag11)
                                    {
                                        estimateID = new object[] { str18, "<label class='normalText' style='cursor: default'> ", row9["DeliveryNumber"], "</label>" };
                                        stringBuilder3.Append(string.Concat(estimateID));
                                        num11++;
                                    }
                                    else
                                    {
                                        estimateID = new object[] { str18, "<a href='", str19, "' target=''> ", row9["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row9["DeliveryDate"].ToString()), this.CompanyID, this.UserID, false) };
                                        stringBuilder3.Append(string.Concat(estimateID));
                                        num11++;
                                    }
                                }
                            }
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                        }
                        else
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br/></div>")));
                        }
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&id=") && !base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&pg=job&estid="))
                    {
                        StringBuilder stringBuilder4 = new StringBuilder();
                        DataTable dataTable11 = EstimateBasePage.purchase_select_by_JobID(this.CompanyID, this.jobID);
                        bool flag12 = false;
                        dataRowArray = dataTable3.Select("SectionName='Purchases'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow12 = dataRowArray[i];
                            flag12 = Convert.ToBoolean(dataRow12["IsDisplay"]);
                        }
                        if (this.EstimateID != (long)0)
                        {
                            if (dataTable11.Rows.Count <= 0)
                            {
                                this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": ")));
                            }
                            else
                            {
                                stringBuilder4.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br>"));
                            }
                            int num12 = 1;
                            int num13 = 1;
                            foreach (DataRow row10 in dataTable11.Rows)
                            {
                                if (dataTable11.Rows.Count <= 1)
                                {
                                    estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row10["PurchaseID"].ToString(), empty16 };
                                    string str20 = string.Concat(estimateID);
                                    if (row10["PONO"] == null)
                                    {
                                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), "r: ")));
                                    }
                                    else if (!flag12)
                                    {
                                        stringBuilder4.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row10["PONO"], "</label>"));
                                    }
                                    else
                                    {
                                        estimateID = new object[] { "<a href='", str20, "' target=''> ", row10["PONO"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row10["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                        stringBuilder4.Append(string.Concat(estimateID));
                                    }
                                }
                                else
                                {
                                    string str21 = "";
                                    if (num12 != 1)
                                    {
                                        str21 = "<br/>";
                                    }
                                    estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row10["PurchaseID"].ToString(), empty16 };
                                    string str22 = string.Concat(estimateID);
                                    if (row10["PONO"] == null)
                                    {
                                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": ")));
                                    }
                                    else if (!flag12)
                                    {
                                        estimateID = new object[] { str21, "<label class='normalText' style='cursor: default'> ", row10["PONO"], "</label>" };
                                        stringBuilder4.Append(string.Concat(estimateID));
                                        num12++;
                                    }
                                    else
                                    {
                                        estimateID = new object[] { str21, "<a href='", str22, "' target=''> ", row10["PONO"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row10["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                        stringBuilder4.Append(string.Concat(estimateID));
                                        num12++;
                                    }
                                }
                                num13++;
                            }
                        }
                        else
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br/></div>")));
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    LinkButton linkButton1 = new LinkButton();
                    string empty17 = string.Empty;
                    bool flag13 = false;
                    dataRowArray = dataTable3.Select("SectionName='Invoices'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow13 = dataRowArray[i];
                        flag13 = Convert.ToBoolean(dataRow13["IsDisplay"]);
                    }
                    DataTable dataTable12 = new DataTable();
                    if (this.Module.ToLower() == "estiamte" || this.Module.ToLower() == "order")
                    {
                        dataTable12 = InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstimateID);
                    }
                    else if (this.Module.ToLower() == "job")
                    {
                        dataTable12 = InvoiceBasePage.Invoice_Select_By_JobID(this.CompanyID, this.jobID);
                    }
                    else if (this.Module.ToLower() == "invoice")
                    {
                        dataTable12 = InvoiceBasePage.Invoice_Select_By_InvoiceID(this.CompanyID, this.InvoiceID);
                    }
                    string empty18 = string.Empty;
                    if (empty13 == "")
                    {
                        empty18 = string.Concat(this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID);
                    }
                    else
                    {
                        estimateID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", num7, this.jID, this.InvID };
                        empty18 = string.Concat(estimateID);
                    }
                    if (this.EstimateID != (long)0)
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ":&nbsp;")));
                        foreach (DataRow row11 in dataTable12.Rows)
                        {
                            if (row11["InvoiceNumber"] == null)
                            {
                                this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ": <br/></div>")));
                            }
                            else if (!flag13)
                            {
                                empty17 = string.Concat("<label class='normalText' style='cursor: default'> ", row11["InvoiceNumber"], "</label><br/>");
                            }
                            else
                            {
                                estimateID = new object[] { "<a href='", empty18, "' target=''> ", row11["InvoiceNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row11["CreatedDate"].ToString()), this.CompanyID, this.UserID, false) };
                                empty17 = string.Concat(estimateID);
                            }
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(empty17.ToString()));
                        dataRowArray = dataTable3.Select("SectionName='Invoices'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow14 = dataRowArray[i];
                            flag13 = Convert.ToBoolean(dataRow14["IsDisplay"]);
                        }
                        if (flag13)
                        {
                            this.plhjobLeftPanel.Controls.Add(linkButton1);
                        }
                        if (empty17 == "")
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(""));
                        }
                    }
                    else
                    {
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ": <br/></div>")));
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div id='activities-all'><a href='#' onclick='javascript:ShowNotes();'>", this.objLangClass.GetLanguageConversion("View_History"), "</a></div></div></div>")));
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    return;
                }
            }
            else if (this.quicklinksfrom == "item  details" || this.quicklinksfrom == "other cost")
            {
                string empty19 = string.Empty;
                if (this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure") != "In.")
                {
                    this.aSqmeter.Text = this.objLangClass.GetLanguageConversion("Sqaure_Meter");
                    this.aSqmeter.Style.Add("Padding-left", "4px");
                }
                else
                {
                    this.aSqmeter.Text = this.objLangClass.GetLanguageConversion("Square_Feet");
                    this.aSqmeter.Style.Add("Padding-left", "4px");
                }
                AttributeCollection attributes1 = this.lidigitalsingle.Attributes;
                estimateID = new object[] { "javascript:CallPage('S','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes1.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributeCollection1 = this.lidigitalPad.Attributes;
                estimateID = new object[] { "javascript:CallPage('P','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeCollection1.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes2 = this.lioffsetsingle.Attributes;
                estimateID = new object[] { "javascript:CallPage('F','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes2.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributeCollection2 = this.lioffsetpads.Attributes;
                estimateID = new object[] { "javascript:CallPage('D','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeCollection2.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes3 = this.liLinear.Attributes;
                estimateID = new object[] { "javascript:CallPage('L','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes3.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributeCollection3 = this.liSqMeter.Attributes;
                estimateID = new object[] { "javascript:CallPage('Sq','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeCollection3.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributeTilling = this.liTilling.Attributes;
                estimateID = new object[] { "javascript:CallPage('ti','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeTilling.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes4 = this.liProductCatalogue.Attributes;
                estimateID = new object[] { "javascript:CallPage('C','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes4.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributeCollection4 = this.liOutwork.Attributes;
                estimateID = new object[] { "javascript:CallPage('O','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeCollection4.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes5 = this.liOtherCost.Attributes;
                estimateID = new object[] { "javascript:CallPage('U','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes5.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes6 = this.liDeliveryCost.Attributes;
                estimateID = new object[] { "javascript:CallPage('T','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributes6.Add("onclick", string.Concat(estimateID));
                //Add inventory as a sub item
                AttributeCollection attributeInventory = this.liInventory.Attributes;
                estimateID = new object[] { "javascript:CallPage('W','", this.ParentEstimateItemID, "','", this.ParentEstimateType, "')" };
                attributeInventory.Add("onclick", string.Concat(estimateID));

                this.EstimatesTypesfromDwebconfig();
                if ((base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")) && this.jobID > (long)0 && (this.ParentEstimateType.ToLower() == "c" || this.ParentEstimateType.ToLower() == "x"))
                {
                    foreach (DataRow row12 in EstimatesBasePage.estimate_price_catalogue_item_select(this.CompanyID, this.ParentEstimateItemID).Rows)
                    {
                        if (this.ManageStockPermission != 1 || !(new BaseClass()).Check_Rerun_Delete_Revert_On_Reduction(Convert.ToInt64(row12["Pricecatalogueid"]), (long)this.CompanyID, this.ParentEstimateItemID, this.EstimateID, row12["DrawStockFrom"].ToString()).ToLower().Contains("false"))
                        {
                            continue;
                        }
                        this.liRevartItem.Visible = false;
                    }
                }
                if (!base.IsPostBack && this.IsFromActHist.ToLower() == "yes")
                {
                    this.liaddItemhead.Style.Add("display", "none");
                    this.RCM_Options.Style.Add("display", "none");
                    this.liReRun.Style.Add("display", "none");
                }
                this.plhSummaryBtns.Controls.Add(new LiteralControl("<div style='margin-right:-3px;'>"));
                string str23 = this.ItemTitle.Replace("\n", "").Replace("\r", "").Replace("'", "");
                this.SectionCount = 2;
                if (this.ParentEstimateType == "S")
                {
                    AttributeCollection attributeCollection5 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection5.Add("onclick", string.Concat(estimateID));
                }
                if (this.ParentEstimateType == "B")
                {
                    AttributeCollection attributes15 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0',", this.SectionCount, ")){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_booklet_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes15.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "P")
                {
                    AttributeCollection attributeCollection6 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pad_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection6.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "R")
                {
                    AttributeCollection attributeCollection6 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0',", this.SectionCount, ")){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_DigitalNCR_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection6.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "L")
                {
                    foreach (DataRow row13 in EstimatesBasePage.estimate_large_item_select(this.CompanyID, this.ParentEstimateItemID).Rows)
                    {
                        AttributeCollection attributes7 = this.liReRun.Attributes;
                        estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit&calcType=", row13["calctype"], "'}" };
                        attributes7.Add("onclick", string.Concat(estimateID));
                    }
                }
                else if (this.ParentEstimateType == "F")
                {
                    AttributeCollection attributeCollection7 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection7.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "D")
                {
                    AttributeCollection attributes8 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_litho_pad_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes8.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "O")
                {
                    AttributeCollection attributeCollection8 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection8.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "C")
                {
                    AttributeCollection attributes9 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes9.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "U")
                {
                    AttributeCollection attributeCollection9 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection9.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "Q")
                {
                    AttributeCollection attributes10 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes10.Add("onclick", string.Concat(estimateID));
                }
                //else if (this.ParentEstimateType == "T")
                //{
                 //   AttributeCollection attributes10 = this.liReRun.Attributes;
                 //   estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_DeliveryCost.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                 //   attributes10.Add("onclick", string.Concat(estimateID));
                //}
                else if (this.ParentEstimateType == "T")
                {
                    this.liReRun.Attributes.Add("style", "display:none;");
                }

                else if (this.ParentEstimateType == "W")
                {
                    AttributeCollection attributeCollection10 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0','0')){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_warehouse.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection10.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "K")
                {
                    AttributeCollection attributes11 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0',", this.SectionCount, ")){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_litho_booklet_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes11.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "N")
                {
                    AttributeCollection attributeCollection11 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0',", this.SectionCount, ")){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_NCR_item.aspx?type=edit&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributeCollection11.Add("onclick", string.Concat(estimateID));
                }
                else if (this.ParentEstimateType == "X")
                {
                    AttributeCollection attributes12 = this.liReRun.Attributes;
                    estimateID = new object[] { "javascript:if(ChkforSubitemLock(", this.ParentEstimateItemID, ",'", this.ParentEstimateType.Trim(), "','0',", this.SectionCount, ")){window.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_productcatalogue.aspx?type=edit&ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID, "&EstItemID=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType.Trim(), "&frm=sum&maintype=edit'}" };
                    attributes12.Add("onclick", string.Concat(estimateID));
                }
                AttributeCollection attributeCollection12 = this.liCopyItem.Attributes;
                estimateID = new object[] { "javascript:EstimateItemsCopy('", this.EstimateID, "','", this.ParentEstimateItemID, "','", this.ParentEstimateType.Trim(), "','", this.Module, "','", this.JobItemStatusID, "');" };
                attributeCollection12.Add("onclick", string.Concat(estimateID));
                AttributeCollection attributes13 = this.liDeleteItem.Attributes;
                estimateID = new object[] { "javascript:EstimateItemsDelete('", this.CompanyID, "','", this.ParentEstimateItemID, "', '", this.ParentEstimateType.Trim(), "','", this.EstimateID, "','", this.Module, "','", str23, "','", this.jobID, "');" };
                attributes13.Add("onclick", string.Concat(estimateID));
                this.liEditJobCard.Attributes.Add("onclick", string.Concat("javascript:return ShowJobCard('", this.ParentEstimateItemID, "');"));


                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                {
                    AttributeCollection attributeCollection13 = this.liRevartItem.Attributes;
                    estimateID = new object[] { "javascript:RevertJobItems_reeng('order','", this.ParentEstimateItemID, "','", this.EstimateID, "','", this.jobID, "');" };
                    attributeCollection13.Add("onclick", string.Concat(estimateID));
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx"))
                {
                    AttributeCollection attributes14 = this.liRevartItem.Attributes;
                    estimateID = new object[] { "javascript:RevertJobItems_reeng('estimate','", this.ParentEstimateItemID, "','", this.EstimateID, "','", this.jobID, "');" };
                    attributes14.Add("onclick", string.Concat(estimateID));
                }
                if (this.IsShowDelete)
                {
                    this.liDeleteItem.Visible = false;
                }
                this.RCM_Options.Visible = false;
                if (this.Module.ToLower() == "order" || this.Module.ToLower() == "estimate" || this.Module.ToLower() == "invoice")
                {
                    this.liEditJobCard.Visible = false;
                }
                if (this.Module.ToLower() == "estimate")
                {
                    if (this.IsShowJobReRun || this.IsShowInvRerun)
                    {
                        this.liaddItemhead.Visible = false;
                        this.liReRun.Visible = false;
                        this.liDeleteItem.Visible = false;
                    }
                }
                else if (this.Module.ToLower() == "job")
                {


                    this.liEditJobCard.Visible = true;
                    if (this.IsShowInvRerun)
                    {
                        this.liaddItemhead.Visible = false;
                        this.liReRun.Visible = false;
                        this.liDeleteItem.Visible = false;
                    }



                }
                if (this.ParentEstimateType.ToLower() == "q")
                {
                    this.liaddItemhead.Visible = false;
                }
                this.plhSummaryBtns.Controls.Add(this.Div_RadSplit);
                this.plhSummaryBtns.Controls.Add(new LiteralControl("</div>"));
                this.plhSummaryBtns.Controls.Add(new LiteralControl("<div>"));
                if (this.Module.ToLower() == "estimate")
                {
                    Button button = new Button()
                    {
                        ID = string.Concat("btnItemDetails_", this.ParentEstimateItemID),
                        CssClass = "button",
                        Text = "Item Details",
                        Visible = false
                    };
                    AttributeCollection attributeCollection14 = button.Attributes;
                    estimateID = new object[] { "javascript:return ShowEstItemDetails('", this.ParentEstimateItemID, "','", this.ParentEstimateType.Trim(), "');" };
                    attributeCollection14.Add("onclick", string.Concat(estimateID));
                    this.plhSummaryBtns.Controls.Add(button);
                }
                else if (this.Module.ToLower() != "job")
                {
                    this.plhItems.Controls.Add(new LiteralControl("&nbsp;"));
                }
                else
                {
                    Button button1 = new Button()
                    {
                        ID = string.Concat("btnJobCard_", this.ParentEstimateItemID),
                        CssClass = "button",
                        Text = "Job Card",
                        Visible = false
                    };
                    button1.Attributes.Add("onclick", string.Concat("javascript:return ShowJobCard('", this.ParentEstimateItemID, "');"));
                    this.plhSummaryBtns.Controls.Add(button1);
                }
                this.IsEditOnlyHisRecords = this.objBaseClass.ReturnRoles_Privileges_Others("editrecords");
                if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
                {
                    string str24 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                    if (str24.Trim().ToLower() == "false")
                    {
                        this.Div_RadSplit.Visible = false;
                        this.liReRun.Visible = false;
                        this.liCopyItem.Visible = false;
                        this.liEditJobCard.Visible = false;
                    }
                    else if (this.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != this.SalesPersonID)
                    {
                        this.liReRun.Visible = false;
                    }
                    string str25 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                    if (str25.Trim().ToLower() == "false")
                    {
                        //this.liDeleteItem.Visible = false;
                        if (strRemove.Trim().ToLower() == "1")
                        {
                            this.liDeleteItem.Visible = true;
                        }
                        else
                        {
                            this.liDeleteItem.Visible = false;
                        }
                    }
                    if (base.Session["CustomAccessRight"].ToString().ToLower() == "true" && str24.Trim().ToLower() != "true" && str25.Trim().ToLower() != "true")
                    {
                        this.liaddItemhead.Visible = false;
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
                {
                    string str26 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                    if (str26.Trim().ToLower() == "false")
                    {
                        this.Div_RadSplit.Visible = false;
                        this.liReRun.Visible = false;
                        this.liCopyItem.Visible = false;
                        this.liEditJobCard.Visible = false;
                    }
                    else if (this.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != this.SalesPersonID)
                    {
                        this.liReRun.Visible = false;
                    }
                    string str27 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                    if (str27.Trim().ToLower() == "false")
                    {
                        //this.liDeleteItem.Visible = false;
                        if (strRemove.Trim().ToLower() == "1")
                        {
                            this.liDeleteItem.Visible = true;
                        }
                        else
                        {
                            this.liDeleteItem.Visible = false;
                        }
                    }
                    if (base.Session["CustomAccessRight"].ToString().ToLower() == "true" && str26.Trim().ToLower() != "true" && str27.Trim().ToLower() != "true")
                    {
                        this.liaddItemhead.Visible = false;
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
                {
                    string str28 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                    if (str28.Trim().ToLower() == "false")
                    {
                        this.Div_RadSplit.Visible = false;
                        this.liReRun.Visible = false;
                        this.liCopyItem.Visible = false;
                        this.liEditJobCard.Visible = false;
                    }
                    else if (this.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != this.SalesPersonID)
                    {
                        this.liReRun.Visible = false;
                    }
                    string str29 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                    if (str29.Trim().ToLower() == "false")
                    {
                        //this.liDeleteItem.Visible = false;
                        if (strRemove.Trim().ToLower() == "1")
                        {
                            this.liDeleteItem.Visible = true;
                        }
                        else
                        {
                            this.liDeleteItem.Visible = false;
                        }
                    }
                    if (base.Session["CustomAccessRight"].ToString().ToLower() == "true" && str28.Trim().ToLower() != "true" && str29.Trim().ToLower() != "true")
                    {
                        this.liaddItemhead.Visible = false;
                    }
                    if (this.ParentEstimateType.Trim().ToLower() == "x")
                    {
                        this.liCopyItem.Visible = false;
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("orders/"))
                {
                    string str30 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                    if (str30.Trim().ToLower() == "false")
                    {
                        this.Div_RadSplit.Visible = false;
                        this.liReRun.Visible = false;
                        this.liCopyItem.Visible = false;
                        this.liEditJobCard.Visible = false;
                    }
                    string str31 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                    if (str31.Trim().ToLower() == "false")
                    {
                        //this.liDeleteItem.Visible = false;
                        if (strRemove.Trim().ToLower() == "1")
                        {
                            this.liDeleteItem.Visible = true;
                        }
                        else
                        {
                            this.liDeleteItem.Visible = false;
                        }
                    }
                    if (base.Session["CustomAccessRight"].ToString().ToLower() == "true" && str30.Trim().ToLower() != "true" && str31.Trim().ToLower() != "true")
                    {
                        this.liaddItemhead.Visible = false;
                    }
                    if (this.OrderItemApprovalStatus != 1)
                    {
                        this.RCM_Options.Visible = false;
                        this.liReRun.Visible = false;
                        this.liaddItemhead.Visible = false;
                    }
                }
                this.plhSummaryBtns.Controls.Add(new LiteralControl("</div>"));
                this.plhSummaryBtns.Controls.Add(new LiteralControl("</td>"));
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    this.plhQL.Controls.Add(new LiteralControl("<div id='divqlItems' align='left' >"));
                    this.plhQL.Controls.Add(new LiteralControl("<div>"));
                    string empty20 = string.Empty;
                    string str32 = "False";
                    string empty21 = string.Empty;
                    string empty22 = string.Empty;
                    string empty23 = string.Empty;
                    string empty24 = string.Empty;
                    string empty25 = string.Empty;
                    string empty26 = string.Empty;
                    string empty27 = string.Empty;
                    string empty28 = string.Empty;
                    string empty29 = string.Empty;
                    long num14 = (long)0;
                    long num15 = (long)0;
                    long num16 = (long)0;
                    foreach (DataRow row14 in dataTable.Rows)
                    {
                        bool flag14 = Convert.ToBoolean(row14["IsDirectJob"]);
                        empty20 = flag14.ToString();
                        flag14 = Convert.ToBoolean(row14["IsDirectInvoice"]);
                        str32 = flag14.ToString();
                        empty21 = row14["EstimateItemNumber"].ToString();
                        empty22 = row14["EstimateDate"].ToString();
                        this.EstimateID = Convert.ToInt64(row14["EstimateID"]);
                        empty24 = row14["OrderItemNumber"].ToString();
                        empty23 = row14["OrderDate"].ToString();
                        num16 = Convert.ToInt64(row14["OrderID"]);
                        empty26 = row14["JobItemNumber"].ToString();
                        empty25 = row14["JobCreatedDate"].ToString();
                        num14 = Convert.ToInt64(row14["JobID"]);
                        row14["InvoiceItemNumber"].ToString();
                        row14["InvoiceDate"].ToString();
                        num15 = Convert.ToInt64(row14["InvoiceID"]);
                        if (num14 != (long)0)
                        {
                            this.jID = string.Concat("&jID=", num14);
                        }
                        if (num15 != (long)0)
                        {
                            this.InvID = string.Concat("&InvID=", num15.ToString());
                        }
                        if (empty20.ToLower() != "true")
                        {
                            continue;
                        }
                        this.liRevartItem.Visible = false;
                    }
                    empty29 = (num16 == (long)0 ? "" : string.Concat("&ordid=", num16));
                    if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("orders/order"))
                    {
                        bool flag15 = false;
                        dataRowArray = dataTable3.Select("SectionName='Estimates'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow15 = dataRowArray[i];
                            flag15 = Convert.ToBoolean(dataRow15["IsDisplay"]);
                        }
                        if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                        {
                            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                            {
                                bool flag16 = false;
                                dataRowArray = dataTable3.Select("SectionName='WebstoreOrder'");
                                for (i = 0; i < (int)dataRowArray.Length; i++)
                                {
                                    DataRow dataRow16 = dataRowArray[i];
                                    flag16 = Convert.ToBoolean(dataRow16["IsDisplay"]);
                                }
                                if (flag16)
                                {
                                    if (empty24 == "")
                                    {
                                        this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":&nbsp;</div>")));
                                    }
                                    else if (!empty24.ToLower().Contains("direct"))
                                    {
                                        ControlCollection controlCollections8 = this.plhQL.Controls;
                                        estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num16, "&estid=", this.EstimateID, "' target='' onclick=''>", empty24, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty23, this.CompanyID, this.UserID, true), "</div>" };
                                        controlCollections8.Add(new LiteralControl(string.Concat(estimateID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls9 = this.plhQL.Controls;
                                        languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br>", empty24, "<br/></div>" };
                                        controls9.Add(new LiteralControl(string.Concat(languageConversion)));
                                    }
                                }
                                this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.EstimateID);
                                if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe"))
                                {
                                    this.liCopyItem.Visible = false;
                                }
                            }
                        }
                        else if (flag15)
                        {
                            if (empty21 == "")
                            {
                                this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":&nbsp;</div>")));
                            }
                            else if (!empty21.ToLower().Contains("direct"))
                            {
                                ControlCollection controlCollections9 = this.plhQL.Controls;
                                estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "' target='' onclick=''>", empty21, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, this.UserID, false), "</div>" };
                                controlCollections9.Add(new LiteralControl(string.Concat(estimateID)));
                            }
                            else
                            {
                                ControlCollection controls10 = this.plhQL.Controls;
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br>", empty21, "<br/></div>" };
                                controls10.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                    {
                        if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                        {
                            bool flag17 = false;
                            dataRowArray = dataTable3.Select("SectionName='Jobs'");
                            for (i = 0; i < (int)dataRowArray.Length; i++)
                            {
                                DataRow dataRow17 = dataRowArray[i];
                                flag17 = Convert.ToBoolean(dataRow17["IsDisplay"]);
                            }
                            if (flag17)
                            {
                                if (empty26 != "")
                                {
                                    if (!empty26.ToLower().Contains("direct"))
                                    {
                                        ControlCollection controlCollections10 = this.plhQL.Controls;
                                        estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", num16, "&estid=", this.EstimateID, this.jID, "' target='' >", empty26, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty25, this.CompanyID, this.UserID, false), "</div>" };
                                        controlCollections10.Add(new LiteralControl(string.Concat(estimateID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls11 = this.plhQL.Controls;
                                        languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Invoice"), "<br/></div>" };
                                        controls11.Add(new LiteralControl(string.Concat(languageConversion)));
                                    }
                                }
                                //else if (this.PaymentType.Contains("Braintree Credit Card") || this.PaymentType.Contains("Paypal") || dataTable1.Rows.Count > 0)
                                //{
                                //    this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ": </div>")));
                                //}
                                else if (this.OrderItemApprovalStatus == 1 && base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx"))
                                {
                                    ControlCollection controlCollections11 = this.plhQL.Controls;
                                    languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br/><a href='#' class='create' onclick='javascript:ShowProgressToJob_Individual(", this.ParentEstimateItemID.ToString(), ");return false;'>Create</a></div>" };
                                    controlCollections11.Add(new LiteralControl(string.Concat(languageConversion)));
                                }
                            }
                        }
                    }
                    else if (str32.ToLower() != "false")
                    {
                        ControlCollection controls12 = this.plhQL.Controls;
                        languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Invoice"), "<br/></div>" };
                        controls12.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else
                    {
                        bool flag18 = false;
                        dataRowArray = dataTable3.Select("SectionName='Jobs'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow18 = dataRowArray[i];
                            flag18 = Convert.ToBoolean(dataRow18["IsDisplay"]);
                        }
                        if (flag18)
                        {
                            if (empty26 != "")
                            {
                                if (!empty26.ToLower().Contains("direct"))
                                {
                                    ControlCollection controlCollections12 = this.plhQL.Controls;
                                    estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' target=''>", empty26, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty25, this.CompanyID, this.UserID, false), "</div>" };
                                    controlCollections12.Add(new LiteralControl(string.Concat(estimateID)));
                                }
                                else
                                {
                                    ControlCollection controls13 = this.plhQL.Controls;
                                    languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Invoice"), "<br/></div>" };
                                    controls13.Add(new LiteralControl(string.Concat(languageConversion)));
                                }
                            }
                            else if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
                            {
                                this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;</div>")));
                            }
                            else
                            {
                                ControlCollection controlCollections13 = this.plhQL.Controls;
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":<br/><a href='#' class='create' onclick='javascript:ShowProgressToJob_Individual(", this.ParentEstimateItemID.ToString(), ");return false;'>Create</a></div>" };
                                controlCollections13.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("proof_summary.aspx"))
                    {
                        ControlCollection controlCollections21 = this.plhQL.Controls;
                        if (empty21 == "Direct Job")
                        {
                            //languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID.ToString(), "&EstItemID=", this.ParentEstimateItemID.ToString(), "' target='' onclick=''>", empty21, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, this.UserID, false), "</div>" };
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br>", empty21, "<br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, this.UserID, false), "</div>" };
                            controlCollections21.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(empty24))
                            {
                                //languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID.ToString(), "&EstItemID=", this.ParentEstimateItemID.ToString(), "' target='' onclick=''>", empty21, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, this.UserID, false), "</div>" };
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID.ToString(), "&EstItemID=", this.ParentEstimateItemID.ToString(), "' target='' onclick=''>", empty21, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, this.UserID, false), "</div>" };
                                controlCollections21.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                            else
                            {
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num16.ToString(), "&estid=", this.EstimateID.ToString(), "' target='' onclick=''>", empty24, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty23, this.CompanyID, this.UserID, true), "</div>" };
                                controlCollections21.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                        ControlCollection controlCollections22 = this.plhQL.Controls;
                        //estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", num16, "&estid=", this.EstimateID, this.jID, "' target='' >", empty26, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty25, this.CompanyID, this.UserID, false), "</div>" };
                        estimateID = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=" + this.EstimateID + "" + this.jID + "&EstItemID=" + this.ParentEstimateItemID.ToString() + "", "' target='' >", empty26, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty25, this.CompanyID, this.UserID, false), "</div>" };
                        controlCollections22.Add(new LiteralControl(string.Concat(estimateID)));
                    }
                    if ((base.Request.Url.ToString().ToLower().Contains("estimates/") || base.Request.Url.ToString().ToLower().Contains("orders/")) && num14 > (long)0)
                    {
                        this.liCopyItem.Visible = false;
                        this.liReRun.Visible = false;
                        this.liDeleteItem.Visible = false;
                        this.liaddItemhead.Visible = false;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("jobs/") && num15 > (long)0)
                    {
                        this.liCopyItem.Visible = false;
                        this.liReRun.Visible = false;
                        this.liDeleteItem.Visible = false;
                        this.liaddItemhead.Visible = false;
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                    {
                        LinkButton linkButton2 = new LinkButton();
                        string empty30 = string.Empty;
                        linkButton2.ID = string.Concat("lnkjobInvoice_", this.ParentEstimateItemID);
                        linkButton2.Text = "Create";
                        linkButton2.CssClass = "create";
                        string empty31 = string.Empty;
                        string empty32 = string.Empty;
                        long num17 = (long)0;
                        foreach (DataRow row15 in InvoiceBasePage.Invoice_Select_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID).Rows)
                        {
                            empty31 = row15["InvoiceItemNumber"].ToString();
                            empty32 = Convert.ToString(row15["CreatedDate"].ToString());
                            num17 = Convert.ToInt64(row15["InvoiceID"]);
                        }
                        if (empty31 != "")
                        {
                            linkButton2.Visible = false;
                            this.liRevartItem.Visible = false;
                        }
                        string empty33 = string.Empty;
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx"))
                        {
                            estimateID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?InvID=", num17, "&estid=", this.EstimateID };
                            empty33 = string.Concat(estimateID);
                        }
                        else
                        {
                            estimateID = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?InvID=", num17, "&estid=", this.EstimateID };
                            empty33 = string.Concat(estimateID);
                        }
                        bool flag19 = false;
                        bool flag199 = false;
                        dataRowArray = dataTable3.Select("SectionName='Invoices'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow19 = dataRowArray[i];
                            flag19 = Convert.ToBoolean(dataRow19["IsDisplay"]);
                            flag199 = Convert.ToBoolean(dataRow19["isAdd"]);
                        }
                        if (flag19)
                        {
                            if (!flag199 && empty31 == "")
                            {
                            }
                            else
                            {
                                this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ":&nbsp;<br/>")));
                                if (empty31 == "")
                                {
                                    linkButton2.Enabled = true;
                                    if (dataTable2.Rows.Count == 1 || dataTable1.Rows.Count > 0 || this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe"))
                                    {
                                        AttributeCollection attributes15 = linkButton2.Attributes;
                                        estimateID = new object[] { "javascript: CheckInvoicePossible_SplitOff(", this.EstimateID, ", ", this.ParentEstimateItemID, ", 'main',", this.jobID, ",'", this.SR_WhenStockReduced, "'); return false;" };
                                        attributes15.Add("onclick", string.Concat(estimateID));
                                    }
                                    else
                                    {
                                        AttributeCollection attributeCollection15 = linkButton2.Attributes;
                                        estimateID = new object[] { "javascript:return OpenCreateInvoice(", this.EstimateID, ", ", this.ParentEstimateItemID, ", 'main',", this.jobID, ");" };
                                        attributeCollection15.Add("onclick", string.Concat(estimateID));
                                    }
                                    if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx")
                                        || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                                    {
                                        this.plhQL.Controls.Add(linkButton2);
                                    }
                                }
                                else
                                {
                                    languageConversion = new string[] { "<a href='", empty33, "' target=''> ", empty31, "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(empty32, this.CompanyID, this.UserID, false), "<br>" };
                                    empty30 = string.Concat(languageConversion);
                                }
                                this.plhQL.Controls.Add(new LiteralControl(empty30.ToString()));
                                this.plhQL.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                    if (ConnectionClass.DeliveryNote != null)
                    {
                        StringBuilder stringBuilder5 = new StringBuilder();
                        DataTable dataTable13 = EstimatesBasePage.estimate_deliverynote_onitemid_selectIndividual(this.CompanyID, this.EstimateID, this.ParentEstimateItemID);
                        bool flag20 = false;
                        dataRowArray = dataTable3.Select("SectionName='DeliveryNote'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow20 = dataRowArray[i];
                            flag20 = Convert.ToBoolean(dataRow20["IsDisplay"]);
                        }
                        if (dataTable13.Rows.Count > 0)
                        {
                            stringBuilder5.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br>"));
                        }
                        else if (!flag20)
                        {
                            ControlCollection controls14 = this.plhQL.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br><a href='#' class='create' onclick='javascript:OpenDeliveryNoteSelectItems();'>", this.objLangClass.GetLanguageConversion("Create"), "</a></div>" };
                            controls14.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ": </div>")));
                        }
                        int num18 = 1;
                        int num19 = 1;
                        foreach (DataRow row16 in dataTable13.Rows)
                        {
                            string str33 = Convert.ToString(row16["DeliveryDate"].ToString());
                            if (dataTable13.Rows.Count <= 1)
                            {
                                estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row16["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty29, this.jID, this.InvID };
                                string str34 = string.Concat(estimateID);
                                if (row16["DeliveryNumber"] == null)
                                {
                                    this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ": </div>")));
                                }
                                else if (!flag20)
                                {
                                    stringBuilder5.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row16["DeliveryNumber"], "</label>"));
                                }
                                else
                                {
                                    estimateID = new object[] { "<a href='", str34, "' target=''> ", row16["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(str33, this.CompanyID, this.UserID, false) };
                                    stringBuilder5.Append(string.Concat(estimateID));
                                }
                            }
                            else
                            {
                                string str35 = "";
                                if (num18 != 1)
                                {
                                    str35 = "<br/>";
                                }
                                estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row16["DeliveryID"].ToString(), "&estid=", this.EstimateID, empty29, this.jID, this.InvID };
                                string str36 = string.Concat(estimateID);
                                if (row16["DeliveryNumber"] == null)
                                {
                                    this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), "</div>")));
                                }
                                else if (!flag20)
                                {
                                    estimateID = new object[] { str35, "<label class='normalText' style='cursor: default'> ", row16["DeliveryNumber"], "</label>" };
                                    stringBuilder5.Append(string.Concat(estimateID));
                                    num18++;
                                }
                                else
                                {
                                    estimateID = new object[] { str35, "<a href='", str36, "' target=''> ", row16["DeliveryNumber"], "</a><br>Date:", this.commclass.Eprint_return_Date_Before_View(str33, this.CompanyID, this.UserID, false) };
                                    stringBuilder5.Append(string.Concat(estimateID));
                                    num18++;
                                }
                            }
                            num19++;
                        }
                        if (dataTable13.Rows.Count > 0 && (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")))
                        {
                            if (!flag20)
                            {
                                stringBuilder5.Append("<br/><label  class='create' style='cursor: default'></label>");
                            }
                            else if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                            {
                                //stringBuilder5.Append(string.Concat("<br/><a href='#' onclick='javascript:OpenMultiDeliveryNote();' class='create'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                                stringBuilder5.Append(string.Concat("<br/><a href='#' onclick='javascript:OpenDeliveryNoteSelectItems();' class='create'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                            }
                        }
                        this.plhQL.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                    }
                    StringBuilder stringBuilder6 = new StringBuilder();
                    DataTable dataTable14 = EstimateBasePage.purchaseItem_select_by_estimateid(this.CompanyID, this.ParentEstimateItemID);
                    bool flag21 = false;
                    bool flag22 = false;
                    dataRowArray = dataTable3.Select("SectionName='Purchases'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow21 = dataRowArray[i];
                        flag21 = Convert.ToBoolean(dataRow21["IsDisplay"]);
                        flag22 = Convert.ToBoolean(dataRow21["IsAdd"]);
                    }
                    if (flag21)
                    {
                        if (dataTable14.Rows.Count > 0)
                        {
                            stringBuilder6.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br>"));
                        }
                        else if (flag22)
                        {
                            ControlCollection controlCollections14 = this.plhQL.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br> <a class='create' href='#' onclick='javascript:CreatePurchase_reeng();'>", this.objLangClass.GetLanguageConversion("Create"), "</a></div>" };
                            controlCollections14.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": </div> ")));
                        }
                        int num20 = 1;
                        int num21 = 1;
                        foreach (DataRow row17 in dataTable14.Rows)
                        {
                            if (dataTable14.Rows.Count <= 1)
                            {
                                estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row17["PurchaseID"].ToString(), empty29, this.jID };
                                string str37 = string.Concat(estimateID);
                                if (row17["PONO"] == null)
                                {
                                    this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":&nbsp;none</div> ")));
                                }
                                else
                                {
                                    estimateID = new object[] { "<a href='", str37, "' target=''> ", row17["PONO"], "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row17["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder6.Append(string.Concat(estimateID));
                                }
                            }
                            else
                            {
                                string str38 = "";
                                if (num20 != 1)
                                {
                                    str38 = "<br/>";
                                }
                                estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", row17["PurchaseID"].ToString(), empty29, this.jID };
                                string str39 = string.Concat(estimateID);
                                if (row17["PONO"] == null)
                                {
                                    this.plhQL.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": </div> ")));
                                }
                                else
                                {
                                    estimateID = new object[] { str38, "<a href='", str39, "' target=''> ", row17["PONO"], "</a><br/>Date: ", this.commclass.Eprint_return_Date_Before_View(Convert.ToString(row17["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder6.Append(string.Concat(estimateID));
                                    num20++;
                                }
                            }
                            num21++;
                        }
                        //Ticket # 71166  
                        if (dataTable14.Rows.Count > 0)
                        {
                            if ((base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")) && flag22)
                            {
                                stringBuilder6.Append(string.Concat("<br/><a href='#' class='create' onclick='javascript:CreatePurchase_reeng();'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                            }
                        }
                        //if (dataTable14.Rows.Count > 0)
                        //{
                        //    string.Concat(this.strSitepath, "Purchase/purchase_add.aspx?type=add&pg=job&estid=", this.EstimateID);
                        //    if ((base.Request.Url.ToString().ToLower().Contains("jobs/job_summarjavascript:OpenMultiDeliveryNotey_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx")) && flag22)
                        //    {
                        //        stringBuilder6.Append(string.Concat("<br/><a href='#' class='create' onclick='javascript:CreatePurchase_reeng();'>", this.objLangClass.GetLanguageConversion("Create_More"), "</a>"));
                        //    }
                        //}

                        this.plhQL.Controls.Add(new LiteralControl(stringBuilder6.ToString()));

                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                    }
                    StringBuilder stringBuilder7 = new StringBuilder();
                    if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                    {
                        string empty34 = string.Empty;
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx"))
                        {
                            empty34 = "job";
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                        {
                            empty34 = "invoice";
                        }
                        this.hdnPCPath.Value = string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx");
                        stringBuilder7.Append(string.Concat("<div class='activity-list' style='padding-left:10px';>", this.objLangClass.GetLanguageConversion("Product_Catalogue"), ":<br>"));
                        string empty35 = string.Empty;
                        DataTable dataTable15 = EstimatesBasePage.estimateitemselect_reeng(this.CompanyID, this.ParentEstimateItemID, this.Module);
                        foreach (DataRow row18 in dataTable15.Rows)
                        {
                            long num22 = (long)Convert.ToInt32(row18["estimateItemID"].ToString());
                            if (row18["EstimateType"].ToString().ToLower() == "x")
                            {
                                continue;
                            }
                            if (row18["EstimateType"].ToString().ToLower() != "o")
                            {
                                if (row18["IsProductCreated"].ToString() != "1")
                                {
                                    estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row18["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num22, ");'>Create</a></div>" };
                                    stringBuilder7.Append(string.Concat(estimateID));
                                    estimateID = new object[] { "<input id='hdnEstType_", num22, "' type='hidden' value='", row18["EstimateType"].ToString(), "~", empty34, "' />" };
                                    stringBuilder7.Append(string.Concat(estimateID));
                                }
                                else
                                {
                                    DataTable dataTable16 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, Convert.ToInt64(row18["EstimateItemID"].ToString()), row18["EstimateType"].ToString());
                                    if (dataTable16.Rows.Count <= 0)
                                    {
                                        estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row18["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num22, ");'>Create</a></div>" };
                                        stringBuilder7.Append(string.Concat(estimateID));
                                        estimateID = new object[] { "<input id='hdnEstType_", num22, "' type='hidden' value='", row18["EstimateType"].ToString(), "~", empty34, "' />" };
                                        stringBuilder7.Append(string.Concat(estimateID));
                                    }
                                    else
                                    {
                                        estimateID = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", dataTable16.Rows[0]["PricecatalogueID"], "&pgFrom=", empty34, "&EstID=", this.EstimateID, "&EstItemID=", Convert.ToInt64(row18["EstimateItemID"].ToString()), this.jID, this.InvID };
                                        empty35 = string.Concat(estimateID);
                                        languageConversion = new string[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left' style='word-break: break-all;'><a href='", empty35, "' target=''>", dataTable16.Rows[0]["ItemCode"].ToString(), "-", this.objBase.SpecialDecode(dataTable16.Rows[0]["CatalogueName"].ToString()), "</a></div>" };
                                        stringBuilder7.Append(string.Concat(languageConversion));
                                    }
                                }
                            }
                            else if (Convert.ToInt64(row18["PIDOutworkType"].ToString() == "" ? "0" : row18["PIDOutworkType"]) != (long)0)
                            {
                                stringBuilder7.Append("");
                            }
                            else if (row18["IsProductCreated"].ToString() != "1")
                            {
                                estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row18["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num22, ");'>Create</a></div>" };
                                stringBuilder7.Append(string.Concat(estimateID));
                                estimateID = new object[] { "<input id='hdnEstType_", num22, "' type='hidden' value='", row18["EstimateType"].ToString(), "~", empty34, "' />" };
                                stringBuilder7.Append(string.Concat(estimateID));
                            }
                            else
                            {
                                DataTable dataTable17 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, Convert.ToInt64(row18["EstimateItemID"].ToString()), row18["EstimateType"].ToString());
                                if (dataTable17.Rows.Count <= 0)
                                {
                                    estimateID = new object[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left'><a href='#' class='create' onclick='javascript:Open_ProductCatalogue(", row18["estimateItemID"].ToString(), ",", this.EstimateID.ToString(), ",", num22, ");'>Create</a></div>" };
                                    stringBuilder7.Append(string.Concat(estimateID));
                                    estimateID = new object[] { "<input id='hdnEstType_", num22, "' type='hidden' value='", row18["EstimateType"].ToString(), "~", empty34, "' />" };
                                    stringBuilder7.Append(string.Concat(estimateID));
                                }
                                else
                                {
                                    estimateID = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", dataTable17.Rows[0]["PricecatalogueID"], "&pgFrom=", empty34, "&EstID=", this.EstimateID, "&EstItemID=", Convert.ToInt64(row18["EstimateItemID"].ToString()), this.jID, this.InvID };
                                    empty35 = string.Concat(estimateID);
                                    languageConversion = new string[] { "<div align='left' style='word-break: break-all;'>", this.objBase.SpecialDecode(row18["itemtitle"].ToString()), ":</div><div align='left' style='word-break: break-all;'><a href='", empty35, "' target=''>", dataTable17.Rows[0]["ItemCode"].ToString(), "-", this.objBase.SpecialDecode(dataTable17.Rows[0]["CatalogueName"].ToString()), "</a></div>" };
                                    stringBuilder7.Append(string.Concat(languageConversion));
                                }
                            }
                        }
                        stringBuilder7.Append("</div>");
                        this.plhQL.Controls.Add(new LiteralControl(stringBuilder7.ToString()));

                        if (commonClass.CheckProofPermission())
                        {
                            if (objBaseClass.GetUserRolePrivilege("proofs", "isdisplay") == "true")
                            {
                                if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "job")
                                {
                                    DataTable dt = EstimateBasePage.Get_Proofed_WebLink(this.ParentEstimateItemID);
                                    int attachment_count = EstimateBasePage.Get_AttachmentCount(this.ParentEstimateItemID);
                                    ControlCollection controls25 = this.plhQL.Controls;
                                    if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "job")
                                    {
                                        string _languageConversion = string.Empty;
                                        if (dt.Rows.Count < attachment_count)
                                        {
                                            //languageConversion = new string[] { "<div class='activity-list'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:OpenProofs(", CompanyID.ToString(), ",", EstimateID.ToString(), ");'>", "Create", "</a>" };
                                            languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:popup_attachments(" + EstimateID.ToString() + "," + this.jobID + ");'>", "Create", "</a>" };
                                            controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                        }
                                        else if (attachment_count == 0)
                                        {
                                            //languageConversion = new string[] { "<div class='activity-list'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:OpenProofs(", CompanyID.ToString(), ",", EstimateID.ToString(), ");'>", "Create", "</a>" };
                                            languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px;'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:popup_attachments(" + EstimateID.ToString() + ", " + this.jobID + ");'>", "Create", "</a>" };
                                            controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                        }
                                    }
                                    else
                                    {
                                        languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px;'>", "Proofs", ":" };
                                        controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                    }
                                    string[] languageConversion1;
                                    if (attachment_count > 0)
                                    {
                                        if (dt.Rows.Count < attachment_count)
                                        {
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                languageConversion1 = new string[] { "<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                                                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                                            }
                                        }
                                        else
                                        {
                                            this.plhQL.Controls.Add(new LiteralControl("<div class='activity-list' style='padding-left:10px;'> Proofs:"));
                                            foreach (DataRow dr in dt.Rows)
                                            {

                                                languageConversion1 = new string[] { "<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                                                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                                            }
                                            this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }


                                    StringBuilder stringBuilder20 = new StringBuilder();
                                    this.plhQL.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                                    if (dt.Rows.Count < attachment_count)
                                    {
                                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                    }
                                    else if (attachment_count == 0)
                                    {
                                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                    }

                                }

                            }

                        }


                    }
                    if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "order")
                    {
                        int num23 = EstimateBasePage.SubItemType_ByParentItemID_Select(this.ParentEstimateItemID);
                        if (this.ParentEstimateType == "O" || num23 > 0)
                        {
                            string empty36 = string.Empty;
                            this.quote_dtls.Visible = true;
                            if (this.Module.ToLower() != "order")
                            {
                                empty36 = string.Concat(this.strSitepath, "estimates/estimate_quotedetails_panel.aspx");
                                ControlCollection controls15 = this.quote_details.Controls;
                                estimateID = new object[] { "<div style='width: 100%;  padding:12px ;margin-left:-3px;' ><a href='", empty36, "?estid=", this.EstimateID, "&estitemID=", this.ParentEstimateItemID, "&Module=", this.Module, "'style='color:#000;font-size:11px; Font-weight: bold; class='HeaderText'' >", this.objLangClass.GetLanguageConversion("Quote_Details"), "</a></div>" };
                                controls15.Add(new LiteralControl(string.Concat(estimateID)));
                            }
                            else
                            {
                                empty36 = string.Concat(this.strSitepath, "orders/order_quotedetails_panel.aspx");
                                ControlCollection controlCollections15 = this.quote_details.Controls;
                                estimateID = new object[] { "<div  style='width: 100%;  padding:12px ;margin-left:-3px;'><a href='", empty36, "?estid=", this.EstimateID, "&estitemID=", this.ParentEstimateItemID, "&Module=", this.Module, "'style='color:#000;font-size:11px; Font-weight: bold;class='HeaderText'' >", this.objLangClass.GetLanguageConversion("Quote_Details"), "</a></div>" };
                                controlCollections15.Add(new LiteralControl(string.Concat(estimateID)));
                            }
                        }

                        if (commonClass.CheckProofPermission())
                        {
                            if (objBaseClass.GetUserRolePrivilege("proofs", "isdisplay") == "true")
                            {
                                if (this.Module.ToLower() == "order")
                                {
                                    DataTable dt = EstimateBasePage.Get_Proofed_WebLink(this.ParentEstimateItemID);
                                    int attachment_count = EstimateBasePage.Get_AttachmentCount(this.ParentEstimateItemID);
                                    ControlCollection controls25 = this.plhQL.Controls;
                                    if (this.Module.ToLower() == "order")
                                    {
                                        string _languageConversion = string.Empty;
                                        if (dt.Rows.Count < attachment_count)
                                        {
                                            //languageConversion = new string[] { "<div class='activity-list'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:OpenProofs(", CompanyID.ToString(), ",", EstimateID.ToString(), ");'>", "Create", "</a>" };
                                            languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px;'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:popup_attachments(" + EstimateID.ToString() + "," + this.jobID + ");'>", "Create", "</a>" };
                                            controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                        }
                                        else if (attachment_count == 0)
                                        {
                                            //languageConversion = new string[] { "<div class='activity-list'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:OpenProofs(", CompanyID.ToString(), ",", EstimateID.ToString(), ");'>", "Create", "</a>" };
                                            languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px;'>", "Proofs", ":<br><a href='#' class='create' onclick='javascript:popup_attachments(" + EstimateID.ToString() + ", " + this.jobID + ");'>", "Create", "</a>" };
                                            controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                        }
                                    }
                                    else
                                    {
                                        languageConversion = new string[] { "<div class='activity-list' style='padding-left:10px;'>", "Proofs", ":" };
                                        controls25.Add(new LiteralControl(string.Concat(languageConversion)));
                                    }
                                    string[] languageConversion1;
                                    if (attachment_count > 0)
                                    {
                                        if (dt.Rows.Count < attachment_count)
                                        {
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                languageConversion1 = new string[] { "<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                                                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                                            }
                                        }
                                        else
                                        {
                                            this.plhQL.Controls.Add(new LiteralControl("<div class='activity-list' style='padding-left:10px;'> Proofs:"));
                                            foreach (DataRow dr in dt.Rows)
                                            {

                                                languageConversion1 = new string[] { "<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                                                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                                            }
                                            this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }


                                    StringBuilder stringBuilder20 = new StringBuilder();
                                    this.plhQL.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                                    if (dt.Rows.Count < attachment_count)
                                    {
                                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                    }
                                    else if (attachment_count == 0)
                                    {
                                        this.plhQL.Controls.Add(new LiteralControl("</div>"));
                                    }
                                }

                            }

                        }

                    }
                    this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.EstimateID);
                    if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe"))
                    {
                        this.liCopyItem.Visible = false;
                    }
                }
                if (this.RCM_Options.Visible)
                {
                    ControlCollection controls16 = this.plhAction.Controls;
                    estimateID = new object[] { "<h1 id='Action_", this.ParentEstimateItemID, "' onclick='javascript:rotatearrow(", this.ParentEstimateItemID, ",1)' class='summary_font12px'>" };
                    controls16.Add(new LiteralControl(string.Concat(estimateID)));
                    this.plhAction.Controls.Add(new LiteralControl(string.Concat("<label ID='lblappearence' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Item_Options"), "</label>")));
                    this.plhAction.Controls.Add(new LiteralControl("<div style='float: right; padding-top: 3px;'>"));
                    ControlCollection controlCollections16 = this.plhAction.Controls;
                    estimateID = new object[] { "<img id='imgup1_", this.ParentEstimateItemID, "'  class='one' src='", this.strImagepath, "ArrowUP.GIF' />" };
                    controlCollections16.Add(new LiteralControl(string.Concat(estimateID)));
                    ControlCollection controls17 = this.plhAction.Controls;
                    estimateID = new object[] { "<img id='imgdown1_", this.ParentEstimateItemID, "'  class='one' src='", this.strImagepath, "ArrowDown.gif' style='display: none'>" };
                    controls17.Add(new LiteralControl(string.Concat(estimateID)));
                    this.plhAction.Controls.Add(new LiteralControl("</div></h1>"));
                    this.plhAction.Controls.Add(new LiteralControl(string.Concat("<ul id='Ul5_", this.ParentEstimateItemID, "' class='Summary_panelitems'>")));
                    this.plhAction2.Controls.Add(new LiteralControl("</ul>"));
                }
                this.RenderAddSubItemDropdown();
                ControlCollection controls19 = this.QL.Controls;
                if (base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    estimateID = new object[] { "<h1 id='QL_", this.ParentEstimateItemID, "" + this.ProofItemID + "'  onclick='javascript:proof_rotatearrow(", this.ParentEstimateItemID , "" + this.ProofItemID + "", ",4)' class='summary_font12px'>" };
                    controls19.Add(new LiteralControl(string.Concat(estimateID)));
                    this.QL.Controls.Add(new LiteralControl(string.Concat("<label ID='lblql' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Quick_Links"), "</label>")));
                    this.QL.Controls.Add(new LiteralControl("<div style='float: right; padding-top: 3px;'>"));
                    ControlCollection controlCollections19 = this.QL.Controls;
                    estimateID = new object[] { "<img id='imgup4_", this.ParentEstimateItemID, "" + this.ProofItemID + "'  class='four' src='", this.strImagepath, "ArrowUP.GIF' />" };
                    controlCollections19.Add(new LiteralControl(string.Concat(estimateID)));
                    ControlCollection controls20 = this.QL.Controls;
                    estimateID = new object[] { "<img id='imgdown4_", this.ParentEstimateItemID, "" + this.ProofItemID + "'  class='four' src='", this.strImagepath, "ArrowDown.gif' style='display: none'>" };
                    controls20.Add(new LiteralControl(string.Concat(estimateID)));
                    this.QL.Controls.Add(new LiteralControl("</div></h1>"));
                    this.QL.Controls.Add(new LiteralControl(string.Concat("<ul id='Ul3_", this.ParentEstimateItemID, "" + this.ProofItemID + "' class='Summary_panelitems' style='width: 100%; padding: 0px;'>")));
                    this.QL2.Controls.Add(new LiteralControl("</ul>"));

                }
                else
                {
                    estimateID = new object[] { "<h1 id='QL_", this.ParentEstimateItemID, "'  onclick='javascript:rotatearrow(", this.ParentEstimateItemID, ",4)' class='summary_font12px'>" };
                    controls19.Add(new LiteralControl(string.Concat(estimateID)));
                    this.QL.Controls.Add(new LiteralControl(string.Concat("<label ID='lblql' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Quick_Links"), "</label>")));
                    this.QL.Controls.Add(new LiteralControl("<div style='float: right; padding-top: 3px;'>"));
                    ControlCollection controlCollections19 = this.QL.Controls;
                    estimateID = new object[] { "<img id='imgup4_", this.ParentEstimateItemID, "'  class='four' src='", this.strImagepath, "ArrowUP.GIF' />" };
                    controlCollections19.Add(new LiteralControl(string.Concat(estimateID)));
                    ControlCollection controls20 = this.QL.Controls;
                    estimateID = new object[] { "<img id='imgdown4_", this.ParentEstimateItemID, "'  class='four' src='", this.strImagepath, "ArrowDown.gif' style='display: none'>" };
                    controls20.Add(new LiteralControl(string.Concat(estimateID)));
                    this.QL.Controls.Add(new LiteralControl("</div></h1>"));
                    this.QL.Controls.Add(new LiteralControl(string.Concat("<ul id='Ul3_", this.ParentEstimateItemID, "' class='Summary_panelitems' style='width: 100%; padding: 0px;'>")));
                    this.QL2.Controls.Add(new LiteralControl("</ul>"));

                }
                DataTable dataTable18 = EstimatesBasePage.estimate_price_catalogue_item_select(this.CompanyID, this.ParentEstimateItemID);
                //if (dataTable18.Rows.Count > 0 && Convert.ToBoolean(dataTable18.Rows[0]["IsStockItem"]) && (this.ParentEstimateType.ToLower() == "c" || this.ParentEstimateType.ToLower() == "x") && this.Module.ToLower() == "job" && Convert.ToInt64(dataTable18.Rows[0]["JobID"]) > (long)0 && !Convert.ToBoolean(dataTable18.Rows[0]["IsStockReplenishItem"]) && InvoiceBasePage.CheckAllocationExist(Convert.ToInt64(dataTable18.Rows[0]["JobID"]), this.ParentEstimateItemID))
                if (dataTable18.Rows.Count > 0 && Convert.ToBoolean(dataTable18.Rows[0]["IsStockItem"]) && (this.ParentEstimateType.ToLower() == "c" || this.ParentEstimateType.ToLower() == "x") && this.Module.ToLower() == "job" && Convert.ToInt64(dataTable18.Rows[0]["JobID"]) > (long)0)
                {
                    this.liViewJobAllocation.Visible = true;
                    string str40 = dataTable18.Rows[0]["Job_Item_Number"].ToString().Trim();
                    ControlCollection controlCollections20 = this.plhViewJobAllocation.Controls;
                    estimateID = new object[] { "<h1 id='div_PriceCatalogueAllocationDetail_", this.ParentEstimateItemID, "' title=", str40, " onclick = 'javascript: OpenJobAllocationPopUp(", this.EstimateID, ",", this.jobID, ",", this.ParentEstimateItemID, ",", dataTable18.Rows[0]["Quantity"].ToString(), ",", dataTable18.Rows[0]["Pricecatalogueid"].ToString(), ",this.id); return false;'  class='summary_font12px'>" };
                    controlCollections20.Add(new LiteralControl(string.Concat(estimateID)));
                    this.plhViewJobAllocation.Controls.Add(new LiteralControl(string.Concat("<label ID='lblql' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("View_Stock"), "</label>")));
                    this.plhViewJobAllocation.Controls.Add(new LiteralControl("</h1>"));
                }
                ControlCollection controls21 = this.ViewHistory.Controls;
                if (base.Request.Url.ToString().ToLower().Contains("proofs/") || base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    estimateID = new object[] { "<h1 id='ViewHistory_", this.ProofItemID, "'  onclick='javascript:ShowNotes_PerItem(", this.ProofItemID, ")' class='summary_font12px'>" };
                    controls21.Add(new LiteralControl(string.Concat(estimateID)));
                    this.ViewHistory.Controls.Add(new LiteralControl(string.Concat("<label ID='lblql' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Item_History"), "</label>")));
                    this.ViewHistory.Controls.Add(new LiteralControl("</h1>"));
                }
                else
                {
                    estimateID = new object[] { "<h1 id='ViewHistory_", this.ParentEstimateItemID, "'  onclick='javascript:ShowNotes_PerItem(", this.ParentEstimateItemID, ")' class='summary_font12px'>" };
                    controls21.Add(new LiteralControl(string.Concat(estimateID)));
                    this.ViewHistory.Controls.Add(new LiteralControl(string.Concat("<label ID='lblql' class='HeaderText'>&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Item_History"), "</label>")));
                    this.ViewHistory.Controls.Add(new LiteralControl("</h1>"));
                }
                
                if (base.Session["CustomAccessRight"].ToString().ToLower() == "true")
                {
                    if (base.Request.Url.ToString().ToLower().Contains("orders/"))
                    {
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            this.liReRun.Visible = false;
                            this.liCopyItem.Visible = false;
                            this.liEditJobCard.Visible = false;
                            this.liaddItemhead.Visible = false;
                        }
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            //this.liDeleteItem.Visible = false;
                            if (strRemove.Trim() == "1")
                            {
                                this.liDeleteItem.Visible = true;
                            }
                            else
                            {
                                this.liDeleteItem.Visible = false;
                            }
                        }
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("proofs/"))
                    {
                        this.liChangeFile.Visible = true;
                        this.liManualApprove.Visible = true;
                        this.liManualReject.Visible = true;
                        this.liReRun.Visible = false;
                        this.liCopyItem.Visible = false;
                        this.liEditJobCard.Visible = false;
                        this.liaddItemhead.Visible = false;
                        this.liDeleteItem.Visible = false;
                        string estimateOrJob = string.Empty;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            estimateOrJob = row["EstimateItemNumber"].ToString();
                        }
                        //if(this.EstID == 0)
                        //{
                        //    this.liChangeFile.Attributes.Add("onclick", string.Concat("javascript:ShowProofAttachments('", this.jobID, "','job','", this.AttachmentID, "');"));
                        //}
                        //else
                        //{
                        //    this.liChangeFile.Attributes.Add("onclick", string.Concat("javascript:ShowProofAttachments('", this.EstID, "','estimate','", this.AttachmentID, "');"));
                        //}
                        
                        Uri uri = new Uri(base.Request.Url.ToString());

                        var queryParams = HttpUtility.ParseQueryString(uri.Query);
                        string estid = queryParams["estid"];
                        string proofID = queryParams["ProofID"];
                        string customerID = EstimateBasePage.GetEstimateCustomerID(this.CompanyID,Convert.ToInt64(estid));
                        string hostName = uri.Host;
                        if(objBaseClass.GetUserRolePrivilege("proofs", "isadd") == "true")
                        {
                            this.liManualApprove.Attributes.Add("onclick", string.Concat("javascript:ChangeProofStatus('", estid, "','Approved','", this.AttachmentID, "','", proofID, "','", this.ProofItemID, "','", this.ParentEstimateItemID, "','", customerID, "','", hostName, "');"));
                            this.liManualReject.Attributes.Add("onclick", string.Concat("javascript:ChangeProofStatus('", estid, "','Rejected','", this.AttachmentID, "','", proofID, "','", this.ProofItemID, "','", this.ParentEstimateItemID, "','", customerID, "','", hostName, "');"));

                            this.liChangeFile.Attributes.Add("onclick", string.Concat("javascript:ShowProofAttachments('", this.EstID, "','estimate','", this.AttachmentID, "','", this.jID, "','", this.ProofItemID, "');"));
                        }
                        else
                        {
                            this.liChangeFile.Visible = false;
                            this.liManualApprove.Visible = false;
                            this.liManualReject.Visible = false;
                        }
                        //if (estimateOrJob == "Direct Job")
                        //{
                        //    this.liChangeFile.Attributes.Add("onclick", string.Concat("javascript:ShowProofAttachments('", this.jobID, "','job','", this.AttachmentID, "');"));
                        //}
                        //else
                        //{
                        //    this.liChangeFile.Attributes.Add("onclick", string.Concat("javascript:ShowProofAttachments('", this.EstID, "','estimate','", this.AttachmentID, "');"));
                        //}

                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
                    {
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            this.liReRun.Visible = false;
                            this.liCopyItem.Visible = false;
                            this.liEditJobCard.Visible = false;
                            this.liaddItemhead.Visible = false;
                        }
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            //this.liDeleteItem.Visible = false;
                            if (strRemove.Trim() == "1")
                            {
                                this.liDeleteItem.Visible = true;
                            }
                            else
                            {
                                this.liDeleteItem.Visible = false;
                            }
                        }
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
                    {
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            this.liReRun.Visible = false;
                            this.liCopyItem.Visible = false;
                            this.liEditJobCard.Visible = false;
                            this.liaddItemhead.Visible = false;
                        }
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            //this.liDeleteItem.Visible = false;
                            if (strRemove.Trim() == "1")
                            {
                                this.liDeleteItem.Visible = true;
                            }
                            else
                            {
                                this.liDeleteItem.Visible = false;
                            }
                        }
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
                    {
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            this.liReRun.Visible = false;
                            this.liCopyItem.Visible = false;
                            this.liEditJobCard.Visible = false;
                            this.liaddItemhead.Visible = false;
                        }
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                        {
                            //this.liDeleteItem.Visible = false;
                            if (strRemove.Trim() == "1")
                            {
                                this.liDeleteItem.Visible = true;
                            }
                            else
                            {
                                this.liDeleteItem.Visible = false;
                            }
                        }
                    }
                }
                if (!this.liCopyItem.Visible && !this.liEditJobCard.Visible && !this.liDeleteItem.Visible && !this.liRevartItem.Visible && this.RCM_Options.Visible)
                {
                    this.RCM_Options.Visible = false;
                }
            }
        }
    }
}