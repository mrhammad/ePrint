using ePrint.usercontrol.Item;
using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
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

namespace ePrint.usercontrol.orders
{
    public partial class order_summary : UsercontrolBasePage
    {


        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private SettingsBasePage objSet = new SettingsBasePage();

        private SummaryClass summry = new SummaryClass();

        private commonClass commclass = new commonClass();

        private storeEmail Objemail = new storeEmail();

        private CompanyBasePage objCom = new CompanyBasePage();

        private BasePage objpage = new BasePage();

        private BaseClass objBC = new BaseClass();

        public static languageClass objLanguage;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string Module = string.Empty;

        public string pg = string.Empty;

        public string DateFormat = string.Empty;

        public int CompanyID;

        public int UserID;

        public static int AccountID;

        public long OrderID;

        public long OrderItemID;

        public int StatusID;

        public string Pgtype = string.Empty;

        public string strArr2 = "x";

        private decimal MainItemPriceExcMarkup;

        private decimal MainItemMarkupPrice;

        private decimal adiitionalitemPrice;

        private decimal addItemPriceExcMarkup;

        private decimal addItemMarkupPrice;

        private decimal TotalPriceExcMarkup;

        private decimal TotalMarkupPrice;

        private decimal TotalPriceIncMarkup;

        private decimal OrderItemTax;

        private decimal SellingPrice;

        public long EstimateID;

        public long JobNum;

        private DataTable dtJobCard = new DataTable();

        private string SectionKey = string.Empty;

        private string JobCardDescription = string.Empty;

        private short LineSpacing;

        private string lineBrakes = string.Empty;

        public long EstimateItemID;

        public string activityhist = string.Empty;

        public string CustomerName = string.Empty;

        public string PaperMeasure = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int ISInventoryReduced;

        public static string Ispaidenable;

        public string OrderPayment = "no";

        public string OrderNo = string.Empty;

        public string JobNo = string.Empty;

        public string InvoiceNo = string.Empty;

        public string ConvertedToJob = string.Empty;

        private string InvoiceStatus = string.Empty;

        public string ItemType = string.Empty;

        public bool IsAccountingCode;

        private DateTime TodayDate;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private Hashtable htInventory = new Hashtable();

        public string ShippedTo = string.Empty;

        public long DeliveryAddID;

        public string DelAddType = string.Empty;

        public string Footer = string.Empty;

        public long DelNO;

        public DateTime DeliveyDate = DateTime.Now;

        public DateTime ActualDeliveryDate = DateTime.Now;

        public string RefNo = string.Empty;

        public long DeliveryID;

        public long DeliveryItemID;

        public string StrDelNum = string.Empty;

        public string serverName = ConnectionClass.ServerName;

        public string UserName = string.Empty;

        public string FromeStore = string.Empty;

        public string pagename = string.Empty;

        public long OptionID;

        public string Formula = "";

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        public string HelpText = string.Empty;

        public string[] NewResult;

        public decimal Markup;

        public string FormulaVal = string.Empty;

        public string op1 = "";

        public string op2 = "";

        public string op3 = "";

        public string op4 = "";

        public string op5 = "";

        public string FormulaTagMul = string.Empty;

        public string[] FVsplit;

        public int @set;

        public string strReplace = string.Empty;

        public string Selected_Value = string.Empty;

        private string Div_Content = string.Empty;

        private string Div_ShowContent = string.Empty;

        private string Div_HideContent = string.Empty;

        public int DuplicateChkOrdID;

        private decimal AllItem_TotalPriceExcMarkup;

        private decimal AllItem_TotalMarkupPrice;

        private decimal AllItem_TotalPriceIncMarkup;

        public decimal AllItem_SellingPrice;

        private decimal AllItem_OrderItemTax;

        private decimal AllItem_GrossProfitDollar;

        private decimal AllItem_GrossProfitMargin;

        public bool IsShowCartAddition;

        public decimal TotalTax;

        public decimal SellingPriceInTax;

        public decimal TotalCartAddition_price;

        public decimal AddCartTax;

        public int CartOrdrItemID;

        public int TotalQntityToCart;

        public string strItemTitle = string.Empty;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public int CustomerID;

        public string OrderItemIDs = string.Empty;

        public string EstitemIDs = string.Empty;

        public int SelectedID;

        public long ParentEstimateItemID;

        public bool Check_SpecialPrivilege;

        public string SalesPersonID = string.Empty;

        public long costcentreID;

        public static int ManageStockPermission;

        public string StockCancellationType = string.Empty;

        public string strSecuresitepath = global.SecureSitePath();

        public string ServerName = string.Empty;

        public bool hasOthercost;

        public string DeliveryNotePrefix = ConnectionClass.DeliveryNotePrefix;

        public bool IsDefaultPO;

        private string MeasurementValue = string.Empty;

        private int OrderConvertedToJob;

        private int EstimateConvertedToJob;

        public string sectionid = string.Empty;

        public string companytype = string.Empty;

        private string jobconvertedtoinvoice = string.Empty;

        public string divEstItemsList_Style = string.Empty;

        public string divPO_Style = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long ModuleID;

        public string noofCartItems;

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

        static order_summary()
        {
            order_summary.objLanguage = new languageClass();
            order_summary.AccountID = 0;
            order_summary.Ispaidenable = string.Empty;
            order_summary.ManageStockPermission = 0;
        }

        public order_summary()
        {
        }

        public string Add2and3argumentsFunc(string Newresult, string FormulaVal, string FVsplit0, string FVsplit1)
        {
            if (Newresult.Contains("*"))
            {
                FormulaVal = Convert.ToString(Convert.ToDecimal(this.FVsplit[0]) * Convert.ToDecimal(this.FVsplit[1]));
            }
            if (Newresult.Contains("/"))
            {
                FormulaVal = Convert.ToString(Convert.ToDecimal(this.FVsplit[0]) / Convert.ToDecimal(this.FVsplit[1]));
            }
            if (Newresult.Contains("%"))
            {
                FormulaVal = Convert.ToString(Convert.ToDecimal(this.FVsplit[0]) % Convert.ToDecimal(this.FVsplit[1]));
            }
            if (Newresult.Contains("+"))
            {
                FormulaVal = Convert.ToString(Convert.ToDecimal(this.FVsplit[0]) + Convert.ToDecimal(this.FVsplit[1]));
            }
            if (Newresult.Contains("-"))
            {
                FormulaVal = Convert.ToString(Convert.ToDecimal(this.FVsplit[0]) - Convert.ToDecimal(this.FVsplit[1]));
            }
            return FormulaVal;
        }

        protected void btnorderrerun_onclick(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] module = new object[] { this.strSitepath, "Orders/order_summary_rerun.aspx?type=", this.Module, "&orderid=", this.OrderID, "&estid=", this.hdnEstId.Value };
            response.Redirect(string.Concat(module));
        }

        protected void btnProgrssToJob_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            DateTime now;
            object[] str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            this.JobNum = this.objCom.settings_lastcounter_select(this.CompanyID, "j");
            string str1 = SettingsBasePage.eprint_numbering(this.CompanyID, "J", ConnectionClass.IsHandy);
            string str2 = "no";
            long num = JobBasePage.jobs_insert(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), str1, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, Convert.ToInt32(base.Session["UserID"]), "", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, false, 0, ConnectionClass.IsHandy, null, null, null, null, null);
            if (this.hid_NoofOrdersToProgress.Value == this.hid_NoofOrdersProgressedToJob.Value)
            {
                str2 = "yes";
            }
            if (this.hid_orderItemIDs.Value != "")
            {
                string value = this.hid_orderItemIDs.Value;
                chrArray = new char[] { '»' };
                string[] strArrays = value.Split(chrArray);
                string value1 = this.hid_EstimateItemIDs.Value;
                chrArray = new char[] { '»' };
                string[] strArrays1 = value1.Split(chrArray);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        long num1 = Convert.ToInt64(strArrays1[i]);
                        commonClass _commonClass1 = this.commclass;
                        now = DateTime.Now;
                        JobBasePage.EstimateItems_ProgressToJob(num1, num, false, _commonClass1.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                        DataTable dataTable = EstimatesBasePage.estimate_subitem_select_New(Convert.ToInt64(strArrays1[i]));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            long num2 = Convert.ToInt64(row["EstimateItemID"]);
                            commonClass _commonClass2 = this.commclass;
                            now = DateTime.Now;
                            JobBasePage.EstimateItems_ProgressToJob(num2, num, false, _commonClass2.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                        }
                        OrderBasePage.Progress_toJob(Convert.ToInt64(this.CompanyID), this.OrderID, Convert.ToInt64(strArrays[i]), this.TodayDate, Convert.ToInt64(strArrays1[i]), str2);
                        this.summry.Job_Card_Of_PriceCatalogue(this.CompanyID, Convert.ToInt64(strArrays1[i]), Convert.ToInt64(strArrays[i]));
                    }
                }
            }
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
            {
                empty2 = dataRow["PhraseText"].ToString();
            }
            foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
            {
                empty3 = row1["PhraseText"].ToString();
            }
            EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), empty2, empty3);
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Footer").Rows)
            {
                empty4 = dataRow1["PhraseText"].ToString();
            }
            foreach (DataRow row2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Header").Rows)
            {
                str3 = row2["PhraseText"].ToString();
            }
            foreach (DataRow dataRow2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Instructions").Rows)
            {
                dataRow2["PhraseText"].ToString();
            }
            int num3 = 0;
            foreach (DataRow row3 in SettingsBasePage.Setting_accountingCode_SelectAll(this.CompanyID).Rows)
            {
                num3 = Convert.ToInt32(row3["AccountCodeID"].ToString());
            }
            long num4 = (long)0;
            DataTable dataTable1 = EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
            foreach (DataRow dataRow3 in dataTable1.Rows)
            {
                num4 = Convert.ToInt64(dataRow3["EstimateItemID"]);
            }
            EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), num4, "C");
            long num5 = (long)0;
            int num6 = 0;
            int num7 = 0;
            long num8 = (long)0;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            int jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Awaiting Authorization");
            foreach (DataRow row4 in SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "purchase").Rows)
            {
                jobStatusID = Convert.ToInt32(row4["StatusID"].ToString());
            }
            long num9 = (long)0;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            bool flag = false;
            DataTable dataTable2 = EstimatesBasePage.estimate_RaisePoOrders_Selectitems(Convert.ToInt64(this.hdnEstId.Value));
            foreach (DataRow dataRow4 in dataTable2.Rows)
            {
                string str7 = Convert.ToString(dataRow4["EstimateItemID"]);
                string str8 = string.Concat("chkRaisePO_", str7.Trim());
                CheckBox checkBox = (CheckBox)this.pnlPORaise.FindControl(str8);
                if (checkBox == null || !checkBox.Checked)
                {
                    continue;
                }
                flag = true;
            }
            if (!flag)
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable3 = EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                DataTable dataTable4 = new DataTable();
                foreach (DataRow row5 in dataTable3.Rows)
                {
                    long num10 = Convert.ToInt64(row5["EstimateItemID"]);
                    int num11 = Convert.ToInt32(row5["QtyNumber"]);
                    empty7 = row5["StatusID"].ToString();
                    string str9 = row5["ItemType"].ToString();
                    int num12 = 0;
                    decimal num13 = new decimal(0);
                    long num14 = (long)0;
                    bool flag1 = true;
                    if (string.Compare(str9.ToLower(), "x", true) != 0)
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str9);
                    foreach (DataRow dataRow5 in dataSet.Tables[0].Rows)
                    {
                        long num15 = Convert.ToInt64(dataRow5["PriceCatalogueID"]);
                        num14 = Convert.ToInt64(dataRow5["OrderItemId"]);
                        num12 = Convert.ToInt32(dataRow5["Quantity"]);
                        num13 = Convert.ToDecimal(dataRow5["Price"]);
                        bool flag2 = Convert.ToBoolean(dataRow5["IsStockReplenish"]);
                        bool flag3 = Convert.ToBoolean(dataRow5["IsStockReplenished"]);
                        BaseClass baseClass1 = new BaseClass();
                        string str10 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str11 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str12 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str13 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str14 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                        if (flag2.ToString().ToLower() == "true" && flag3.ToString().ToLower() != "true")
                        {
                            flag1 = false;
                        }
                        if (!(flag2.ToString().ToLower() != "true") || !(flag1.ToString().ToLower() == "true"))
                        {
                            continue;
                        }
                        if (str10 == "j" || str14 == "j")
                        {
                            string str15 = baseClass1.Return_StockManagementSettings("SA_EstoreJobStatusID");
                            string str16 = baseClass1.Return_StockManagementSettings("SA_JobStatusID");
                            if (str15 == empty7.ToString() || str16 == empty7.ToString())
                            {
                                foreach (DataRow row6 in baseClass1.ProductStockType_Select((long)this.CompanyID, num15).Rows)
                                {
                                    if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty1 = baseClass1.StockAllocationProcess((long)this.CompanyID, num15, (long)0, num12, str11, "self", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty1 = baseClass1.StockAllocation_Others((long)this.CompanyID, num15, num12, str11, Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow dataRow6 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num12, true).Rows)
                                        {
                                            empty1 = baseClass1.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow6["KitItemID"].ToString()), num15, num12, str11, "multiple", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                        }
                                    }
                                    else
                                    {
                                        empty1 = baseClass1.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num15, num12, str11, "additional option", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID, this.OrderID, num14);
                                    }
                                }
                            }
                        }
                        else if (str10 == "c" || str10 == "p")
                        {
                            foreach (DataRow row7 in baseClass1.ProductStockType_Select((long)this.CompanyID, num15).Rows)
                            {
                                if (row7["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass1.StockAllocationProcess((long)this.CompanyID, num15, (long)0, num12, str11, "self", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                }
                                else if (row7["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass1.StockAllocation_Others((long)this.CompanyID, num15, num12, str11, Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                }
                                else if (row7["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row7["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow7 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num12, true).Rows)
                                    {
                                        empty1 = baseClass1.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow7["KitItemID"].ToString()), num15, num12, str11, "multiple", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID);
                                    }
                                }
                                else
                                {
                                    empty1 = baseClass1.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num15, num12, str11, "additional option", Convert.ToBoolean(str12), num10, "Job", num13, (long)this.UserID, this.OrderID, num14);
                                }
                            }
                        }
                        if (str13 != "e")
                        {
                            if (!(str13 == "j") || !(baseClass1.Return_StockManagementSettings("SR_JobStatusID") == empty7))
                            {
                                continue;
                            }
                            foreach (DataRow row8 in baseClass1.ProductStockType_Select((long)this.CompanyID, num15).Rows)
                            {
                                base.Session["StockItemType"] = "X";
                                base.Session["ALC_OrderItemId"] = num14.ToString();
                                if (row8["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, num15, (long)0, "self", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num15, "other", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row8["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, num15, (long)0, "multiple", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else
                                {
                                    empty1 = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num15, "additional option", num12, num10, "Job", (long)this.UserID, num13);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dataRow8 in baseClass1.ProductStockType_Select((long)this.CompanyID, num15).Rows)
                            {
                                if (dataRow8["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, num15, (long)0, "self", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else if (dataRow8["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num15, "other", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else if (dataRow8["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow8["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty1 = baseClass1.StockReductionProcess((long)this.CompanyID, num15, (long)0, "multiple", num12, num10, "Job", (long)this.UserID, num13);
                                }
                                else
                                {
                                    empty1 = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num15, "additional option", num12, num10, "Job", (long)this.UserID, num13);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DataSet dataSet1 = new DataSet();
                DataTable dataTable5 = EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                DataTable dataTable6 = new DataTable();
                foreach (DataRow row9 in dataTable5.Rows)
                {
                    string str17 = Convert.ToString(row9["EstimateItemID"]);
                    string str18 = string.Concat("chkRaisePO_", str17.Trim());
                    CheckBox checkBox1 = (CheckBox)this.pnlPORaise.FindControl(str18);
                    long num16 = Convert.ToInt64(row9["EstimateItemID"]);
                    int num17 = Convert.ToInt32(row9["QtyNumber"]);
                    empty7 = row9["StatusID"].ToString();
                    string str19 = row9["ItemType"].ToString();
                    long num18 = (long)0;
                    string empty8 = string.Empty;
                    string empty9 = string.Empty;
                    int num19 = 0;
                    int num20 = 0;
                    decimal num21 = new decimal(0);
                    string pODN = string.Empty;
                    long num22 = (long)0;
                    string empty10 = string.Empty;
                    string empty11 = string.Empty;
                    EstimatesBasePage.GetTaxID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                    EstimatesBasePage.GetTaxRate(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                    long num23 = (long)0;
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    bool flag4 = true;
                    DateTime dateTime = DateTime.Now.AddDays(5);
                    if (checkBox1 == null || !checkBox1.Checked || string.Compare(str19.ToLower(), "x", true) != 0)
                    {
                        continue;
                    }
                    pODN = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num16, "Purchase", ref empty13);
                    dataSet1 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num16, num17, str19);
                    foreach (DataRow dataRow9 in dataSet1.Tables[0].Rows)
                    {
                        long num24 = Convert.ToInt64(dataRow9["PriceCatalogueID"]);
                        num23 = Convert.ToInt64(dataRow9["OrderItemId"]);
                        num18 = (long)0;
                        empty8 = "A";
                        empty9 = "";
                        num19 = Convert.ToInt32(dataRow9["Quantity"]);
                        num20 = Convert.ToInt32(dataRow9["Quantity"]);
                        num21 = Convert.ToDecimal(dataRow9["Price"]);
                        bool flag5 = Convert.ToBoolean(dataRow9["IsStockReplenish"]);
                        bool flag6 = Convert.ToBoolean(dataRow9["IsStockReplenished"]);
                        int num25 = Convert.ToInt32(dataRow9["TotalTaxId"]);
                        decimal num26 = Convert.ToDecimal(dataRow9["TotalTaxRate"]);
                        num22 = Convert.ToInt64(dataRow9["DeliveryAddress"].ToString());
                        empty10 = dataRow9["DeliveryAddressType"].ToString();
                        decimal num27 = (num21 * num26) / new decimal(100);
                        num6 = Convert.ToInt32(dataRow9["SupplierID"].ToString());
                        num7 = Convert.ToInt32(dataRow9["SupplierContactID"].ToString());
                        num8 = Convert.ToInt64(dataRow9["AddressID"].ToString());
                        empty5 = dataRow9["AddressType"].ToString();
                        string str20 = dataRow9["ItemDescription"].ToString();
                        string empty14 = string.Empty;
                        string empty15 = string.Empty;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays2 = str20.Split(chrArray);
                        for (int j = 0; j < (int)strArrays2.Length; j++)
                        {
                            if (j == 10 && strArrays2[j] != "")
                            {
                                string str21 = strArrays2[j];
                                chrArray = new char[] { '»' };
                                string[] strArrays3 = str21.Split(chrArray);
                                for (int k = 0; k < (int)strArrays3.Length; k++)
                                {
                                    if (k == 2)
                                    {
                                        strArrays3[2].ToString();
                                    }
                                }
                            }
                        }
                        dateTime = Convert.ToDateTime(dataRow9["PoReqDate"]);
                        string str22 = "";
                        str5 = (this.lblComments.Text == "" ? "" : this.lblComments.Text.Replace("<br/>", "\n"));
                        string empty16 = string.Empty;
                        DataSet dataSet2 = OrderBasePage.Select_OrderItems_WithAdditionalItems(num23);
                        foreach (DataRow row10 in dataSet2.Tables[1].Rows)
                        {
                            str = new object[] { str22, row10["webothercostName"].ToString(), ":", row10["SelectedValue"], "\n" };
                            str22 = string.Concat(str);
                        }
                        foreach (DataRow dataRow10 in dataSet2.Tables[0].Rows)
                        {
                            empty16 = dataRow10["JobName"].ToString();
                        }
                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(str5), this.objBase.SpecialEncode(empty4), "", this.TodayDate, this.objBase.SpecialEncode(str1), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.TodayDate, (long)0, empty5, Convert.ToInt64(this.hdnEstId.Value), this.objBase.SpecialEncode(str3), num16, this.TodayDate, num22, empty10, 0, (long)0, this.TodayDate, "");
                        EstimateBasePage.Attachments_PO_DN_Copy(Convert.ToInt64(this.hdnEstId.Value), num16, num5, "Purchase");
                        if (empty16 == "")
                        {
                            string.Concat(SummaryClass.Split_ItemDescription(dataRow9["ItemDescription"].ToString()), str22);
                        }
                        else
                        {
                            string[] strArrays4 = new string[] { "Job Name :", empty16, "\n", SummaryClass.Split_ItemDescription(dataRow9["ItemDescription"].ToString()), str22 };
                            string.Concat(strArrays4);
                        }
                        DataTable dataTable7 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num24);
                        if (dataTable7.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                        {
                            num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num18, empty8, empty9, string.Concat(pODN, "\n", str22), Convert.ToDecimal(num19), Convert.ToDecimal(num20), Convert.ToDecimal(num21), num25, Convert.ToDecimal(num27), num3, empty13, false, num16, str19, (long)0, this.UserID, this.TodayDate);
                        }
                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                        {
                            num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num18, empty8, empty9, string.Concat(pODN, "\n", str22), Convert.ToDecimal(num19), Convert.ToDecimal(num20), Convert.ToDecimal(num21), num25, Convert.ToDecimal(num27), num3, empty13, false, num16, str19, (long)0, this.UserID, this.TodayDate);
                        }
                        else if (dataTable7.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                        {
                            num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num18, empty8, empty9, string.Concat(pODN, "\n", str22), Convert.ToDecimal(num19), Convert.ToDecimal(num20), Convert.ToDecimal(num21), num25, Convert.ToDecimal(num27), num3, empty13, false, num16, str19, (long)0, this.UserID, this.TodayDate);
                        }
                        else
                        {
                            foreach (DataRow row11 in PurchaseBasePage.Kit_Details(num24).Rows)
                            {
                                int num28 = num19 * Convert.ToInt16(row11["Quantity"]);
                                DataTable dataTable8 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(row11["KitItemID"]));
                                string str23 = dataTable8.Rows[0]["ItemCode"].ToString();
                                string str24 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(row11["KitItemID"])).Replace("»", "\n");
                                num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, Convert.ToInt64(row11["KitItemID"]), "W", str23, string.Concat(str24, "\n", str22), Convert.ToDecimal(num28), Convert.ToDecimal(num20), Convert.ToDecimal(num21), num25, Convert.ToDecimal(num27), num3, empty13, false, num16, str19, (long)0, this.UserID, this.TodayDate);
                            }
                        }
                        foreach (DataRow dataRow11 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                        {
                            empty11 = dataRow11["PONO"].ToString();
                        }
                        this.objnotes.ModuleName = "Purchase";
                        this.objnotes.Po_number = empty11;
                        this.objnotes.Job_number = this.objBase.SpecialEncode(str1);
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POCreatedFromJob);
                        this.objnotes.ModuleID = num5;
                        this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass3 = this.commclass;
                        now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        if (str6 != "")
                        {
                            str6 = string.Concat(str6, ", ");
                        }
                        str = new object[] { str6, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty11, "</a>" };
                        str6 = string.Concat(str);
                        BaseClass baseClass2 = new BaseClass();
                        string str25 = baseClass2.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str26 = baseClass2.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str27 = baseClass2.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str28 = baseClass2.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str29 = baseClass2.Return_StockManagementSettings("SA_EprintMISJobs");
                        if (flag5.ToString().ToLower() == "true" && flag6.ToString().ToLower() != "true")
                        {
                            flag4 = false;
                        }
                        if (!(flag5.ToString().ToLower() != "true") || !(flag4.ToString().ToLower() == "true"))
                        {
                            continue;
                        }
                        if (str25 == "j" || str29 == "j")
                        {
                            string str30 = baseClass2.Return_StockManagementSettings("SA_EstoreJobStatusID");
                            string str31 = baseClass2.Return_StockManagementSettings("SA_JobStatusID");
                            if (str30 == empty7.ToString() || str31 == empty7.ToString())
                            {
                                foreach (DataRow row12 in baseClass2.ProductStockType_Select((long)this.CompanyID, num24).Rows)
                                {
                                    if (row12["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty1 = baseClass2.StockAllocationProcess((long)this.CompanyID, num24, (long)0, num19, str26, "self", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                        PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                    }
                                    else if (row12["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty1 = baseClass2.StockAllocation_Others((long)this.CompanyID, num24, num19, str26, Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                    }
                                    else if (row12["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row12["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow dataRow12 in PurchaseBasePage.OtherMultipleProductDetails_Select(num24, num19, true).Rows)
                                        {
                                            empty1 = baseClass2.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow12["KitItemID"].ToString()), num24, num19, str26, "multiple", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                        }
                                    }
                                    else
                                    {
                                        empty1 = baseClass2.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num24, num19, str26, "additional option", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID, this.OrderID, num23);
                                        PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                    }
                                }
                            }
                        }
                        else if (str25 == "c" || str25 == "p")
                        {
                            foreach (DataRow row13 in baseClass2.ProductStockType_Select((long)this.CompanyID, num24).Rows)
                            {
                                if (row13["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass2.StockAllocationProcess((long)this.CompanyID, num24, (long)0, num19, str26, "self", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                                else if (row13["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass2.StockAllocation_Others((long)this.CompanyID, num24, num19, str26, Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                }
                                else if (row13["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row13["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow13 in PurchaseBasePage.OtherMultipleProductDetails_Select(num24, num19, true).Rows)
                                    {
                                        empty1 = baseClass2.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow13["KitItemID"].ToString()), num24, num19, str26, "multiple", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID);
                                    }
                                }
                                else
                                {
                                    empty1 = baseClass2.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num24, num19, str26, "additional option", Convert.ToBoolean(str27), num16, "Job", num21, (long)this.UserID, this.OrderID, num23);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                            }
                        }
                        if (str28 != "e")
                        {
                            if (!(str28 == "j") || !(baseClass2.Return_StockManagementSettings("SR_JobStatusID") == empty7))
                            {
                                continue;
                            }
                            foreach (DataRow row14 in baseClass2.ProductStockType_Select((long)this.CompanyID, num24).Rows)
                            {
                                base.Session["StockItemType"] = "X";
                                base.Session["ALC_OrderItemId"] = num23.ToString();
                                if (row14["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, num24, (long)0, "self", num19, num16, "Job", (long)this.UserID, num21);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                                else if (row14["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num24, "other", num19, num16, "Job", (long)this.UserID, num21);
                                }
                                else if (row14["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row14["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, num24, (long)0, "multiple", num19, num16, "Job", (long)this.UserID, num21);
                                }
                                else
                                {
                                    empty1 = baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num24, "additional option", num19, num16, "Job", (long)this.UserID, num21);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dataRow14 in baseClass2.ProductStockType_Select((long)this.CompanyID, num24).Rows)
                            {
                                if (dataRow14["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, num24, (long)0, "self", num19, num16, "Job", (long)this.UserID, num21);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                                else if (dataRow14["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num24, "other", num19, num16, "Job", (long)this.UserID, num21);
                                }
                                else if (dataRow14["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow14["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty1 = baseClass2.StockReductionProcess((long)this.CompanyID, num24, (long)0, "multiple", num19, num16, "Job", (long)this.UserID, num21);
                                }
                                else
                                {
                                    empty1 = baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num24, "additional option", num19, num16, "Job", (long)this.UserID, num21);
                                    PurchaseBasePage.ProgressToJob_StockItem_Update(num24, num9);
                                }
                            }
                        }
                    }
                }
            }
            if (this.chkDeliveryNote.Checked)
            {
                DataTable dataTable9 = EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                foreach (DataRow row15 in dataTable9.Rows)
                {
                    num6 = Convert.ToInt32(row15["CustomerID"].ToString());
                    num7 = Convert.ToInt32(row15["AttentionID"].ToString());
                    this.ShippedTo = row15["ClientName"].ToString();
                    this.DeliveryAddID = Convert.ToInt64(row15["DeliveryAddressID"].ToString());
                    this.DelAddType = row15["DeliveryAddressType"].ToString();
                    this.costcentreID = Convert.ToInt64(row15["costcentreID"]);
                }
                string empty17 = string.Empty;
                string empty18 = string.Empty;
                foreach (DataRow dataRow15 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Footer").Rows)
                {
                    empty17 = dataRow15["PhraseText"].ToString();
                }
                foreach (DataRow row16 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Header").Rows)
                {
                    empty18 = row16["PhraseText"].ToString();
                }
                this.DelNO = this.objCom.settings_lastcounter_select(this.CompanyID, "d");
                long delNO = (long)10000000 + this.DelNO;
                this.StrDelNum = string.Concat(this.DeliveryNotePrefix, delNO.ToString().Substring(1, delNO.ToString().Length - 1));
                commonClass _commonClass4 = this.commclass;
                now = DateTime.Now;
                this.DeliveyDate = _commonClass4.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.RefNo = str1;
                this.OrderNo = this.lbl_CustomerOrderNo.Text;
                long num29 = (long)0;
                int num30 = 0;
                string empty19 = string.Empty;
                string empty20 = string.Empty;
                int jobStatusID1 = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                foreach (DataRow dataRow16 in SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "delivery").Rows)
                {
                    jobStatusID1 = Convert.ToInt32(dataRow16["StatusID"].ToString());
                }
                long num31 = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), num29, "E", num6, num7, this.ShippedTo, this.DeliveryAddID, this.DelAddType, empty17, this.lblComments.Text.Replace("<br/>", "\n"), this.StrDelNum, this.DeliveyDate, this.RefNo, this.OrderNo, false, num30, this.UserID, jobStatusID1, this.TodayDate, this.UserID, this.DelNO, empty18, this.TodayDate, num6, empty19, empty20, Convert.ToDateTime("1900-01-01 00:00:00.000"), this.costcentreID, this.DeliveryNotePrefix);
                foreach (DataRow row17 in JobBasePage.Job_Card_Info_Select_By_JobID(num).Rows)
                {
                    long num32 = Convert.ToInt64(row17["EstimateItemID"]);
                    int num33 = Convert.ToInt32(row17["QtyNumber"]);
                    string str32 = row17["ItemType"].ToString();
                    string empty21 = string.Empty;
                    string pODN1 = string.Empty;
                    long num34 = (long)0;
                    EstimateBasePage.Attachments_PO_DN_Copy(Convert.ToInt64(this.hdnEstId.Value), num32, num31, "DeliveryNote");
                    DataTable dataTable10 = EstimatesBasePage.estimate_delivery_quantity_details_select(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), num32, str32, "job");
                    foreach (DataRow dataRow17 in dataTable10.Rows)
                    {
                        empty21 = dataRow17["Quantity"].ToString();
                        pODN1 = SummaryClass.Split_ItemDescription(dataRow17["RFQDescription"].ToString());
                    }
                    string empty22 = string.Empty;
                    string empty23 = string.Empty;
                    foreach (DataRow row18 in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num32, "X").Rows)
                    {
                        pODN1 = (row18["ItemTitle"].ToString() == "" ? string.Concat(row18["ItemTitle"].ToString(), "\n", pODN1) : string.Concat("Job Name: ", row18["ItemTitle"].ToString(), "\n", pODN1));
                    }
                    pODN1 = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num32, "DeliveryNote", ref empty23);
                    if (str32.ToLower() == "c" || str32.ToLower() == "x")
                    {
                        num33 = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num32);
                        DataSet dataSet3 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num32, num33, str32);
                        DataTable item = dataSet3.Tables[0];
                        if (item.Rows.Count <= 0)
                        {
                            DeliveryBasePage.deliveryitem_insert(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, (long)1, "", (long)0);
                        }
                        else
                        {
                            foreach (DataRow dataRow18 in item.Rows)
                            {
                                long num35 = Convert.ToInt64(dataRow18["PriceCatalogueID"]);
                                DataTable dataTable11 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num35);
                                if (dataTable11.Rows.Count <= 0)
                                {
                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, num35);
                                }
                                else if (dataTable11.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                {
                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, num35);
                                }
                                else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                {
                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, num35);
                                }
                                else if (dataTable11.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                {
                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, num35);
                                }
                                else
                                {
                                    foreach (DataRow row19 in PurchaseBasePage.Kit_Details(num35).Rows)
                                    {
                                        int num36 = Convert.ToInt16(empty21) * Convert.ToInt16(row19["Quantity"]);
                                        string str33 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(row19["KitItemID"])).Replace("»", "\n");
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, num36.ToString(), str33, Convert.ToInt64(row19["KitItemID"].ToString()));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DeliveryBasePage.deliveryitem_insert(this.CompanyID, num34, num31, Convert.ToInt64(this.hdnEstId.Value), num32, str32, empty21, pODN1, (long)1, "", (long)0);
                    }
                }
            }
            long num37 = (long)0;
            string empty24 = string.Empty;
            string empty25 = string.Empty;
            string empty26 = string.Empty;
            DataTable dataTable12 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), "webstoreorder", (long)0);
            foreach (DataRow dataRow19 in dataTable12.Rows)
            {
                empty25 = dataRow19["OrderNo"].ToString();
                empty26 = dataRow19["jobnumber"].ToString();
                empty24 = dataRow19["PONO"].ToString();
                this.StrDelNum = dataRow19["DeliveryNumber"].ToString();
                Convert.ToInt64(dataRow19["PurchaseID"].ToString());
                num37 = Convert.ToInt64(dataRow19["DeliveryID"].ToString());
            }
            this.objnotes.Estimate_number = empty25;
            this.objnotes.ModuleName = "webstoreorder";
            this.objnotes.Po_number = empty24;
            this.objnotes.Delivery_number = this.StrDelNum;
            this.objnotes.Job_number = empty26;
            if (this.chkDeliveryNote.Checked && flag)
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithPOandDel);
                this.objnotes.Po_Attachment = str6;
                this.objnotes.Delivery_Attachment = string.Concat(this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num37);
            }
            else if (!this.chkDeliveryNote.Checked && flag)
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithPO);
                this.objnotes.Po_Attachment = str6;
            }
            else if (this.chkDeliveryNote.Checked && !flag)
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithDel);
                this.objnotes.Delivery_Attachment = string.Concat(this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num37);
            }
            else if (!this.chkDeliveryNote.Checked && !flag)
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithOutPOandDel);
            }
            this.objnotes.ModuleID = Convert.ToInt64(this.hdnEstId.Value);
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass1 = this.objnotes;
            commonClass _commonClass5 = this.commclass;
            now = DateTime.Now;
            _notesclass1.Created_Date = _commonClass5.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.chkDeliveryNote.Checked)
            {
                long num38 = (long)0;
                DataTable dataTable13 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), "", (long)0);
                foreach (DataRow row20 in dataTable13.Rows)
                {
                    empty26 = row20["jobnumber"].ToString();
                    this.StrDelNum = row20["DeliveryNumber"].ToString();
                    num38 = Convert.ToInt64(row20["DeliveryID"].ToString());
                }
                this.objnotes.ModuleName = "Delivery";
                this.objnotes.Delivery_number = this.StrDelNum;
                this.objnotes.Job_number = empty26;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelCreatedFromJob);
                this.objnotes.ModuleID = num38;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass6 = this.commclass;
                now = DateTime.Now;
                _notesclass2.Created_Date = _commonClass6.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            string empty27 = string.Empty;
            if (num != (long)0)
            {
                empty27 = string.Concat("&jID=", num);
            }
            baseClass.Message_Display(string.Concat("Status updated successfully.", empty1), "successfulMsg", this.plhMessage);
            HttpResponse response = base.Response;
            str = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", Convert.ToInt64(this.hdnEstId.Value), empty27 };
            response.Redirect(string.Concat(str));
        }

        protected void btnSaveStatus_OnClick(object sender, EventArgs e)
        {
            EstimateBasePage.Estimate_Status_Update(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), Convert.ToInt32(this.ddlStatus.SelectedItem.Value), this.Module, this.ModuleID);
            string empty = string.Empty;
            if (this.Module.ToLower() == "webstoreorder")
            {
                foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                {
                    empty = row["StatusTitle"].ToString();
                }
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdChangeStatus);
                this.objBC.Message_Display(order_summary.objLanguage.GetLanguageConversion("Order_Status_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            else if (this.Module.ToLower() == "job")
            {
                DataTable dataTable = JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    empty = dataRow["jobstatus"].ToString();
                }
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobChangeStatus);
                this.objBC.Message_Display(order_summary.objLanguage.GetLanguageConversion("Job_Status_Updated_Successfully"), "msg-success", this.plhMessage);
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, order_summary.AccountID, (long)0, "Order Shipping", "Customer");
                foreach (DataRow row1 in customerSelect.Rows)
                {
                    this.StatusID = Convert.ToInt32(row1["StatusID"].ToString());
                }
                if (Convert.ToInt32(this.ddlStatus.SelectedItem.Value) == this.StatusID)
                {
                    long num = (long)0;
                    foreach (DataRow dataRow1 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                    {
                        num = Convert.ToInt64(dataRow1["StoreUserID"]);
                    }
                    this.Objemail.emailOrdersDetails(num, this.OrderID, this.CompanyID, Convert.ToInt32(order_summary.AccountID), "Order Shipping");
                }
            }
            else if (this.Module.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.Invoices_Status_Select(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvChangeStatus);
                this.objBC.Message_Display(order_summary.objLanguage.GetLanguageConversion("Invoice_Status_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.objnotes.ModuleID = Convert.ToInt64(this.hdnEstId.Value);
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.Module.ToLower() == "webstoreorder")
            {
                HttpResponse response = base.Response;
                object[] orderID = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.hdnEstId.Value, "&suc=sta" };
                response.Redirect(string.Concat(orderID));
                return;
            }
            if (this.Module.ToLower() == "job")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.hdnEstId.Value, "&suc=sta" };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.Module.ToLower() == "invoice")
            {
                HttpResponse response1 = base.Response;
                object[] orderID1 = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.hdnEstId.Value, "&suc=sta" };
                response1.Redirect(string.Concat(orderID1));
            }
        }

        protected void btnStay_Click(object sender, EventArgs eventArgs)
        {
            string[] strArrays = this.hid_OtherCostValues.Value.Split(new char[] { ',' });
            EstimatesBasePage.updatetotalTax_and_sellingPrice_forOtherCost(Convert.ToInt64(strArrays[0].ToString()), Convert.ToDecimal(strArrays[1].ToString()), Convert.ToDecimal(strArrays[2].ToString()), Convert.ToInt64(strArrays[3].ToString()), Convert.ToDecimal(strArrays[4].ToString()));
            if (this.Module == "invoice")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.OrderID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.OrderID };
            httpResponse.Redirect(string.Concat(objArray));
        }

        public string DfuncVarification(string[] d, string sym)
        {
            if (!d.GetValue(0).ToString().Contains("+") && !d.GetValue(0).ToString().Contains("-") && !d.GetValue(0).ToString().Contains("*") && !d.GetValue(0).ToString().Contains("/") && !d.GetValue(0).ToString().Contains("%"))
            {
                sym = "0";
            }
            if ((int)d.Length == 2 && (d.GetValue(1).ToString().Contains("+") || d.GetValue(1).ToString().Contains("-") || d.GetValue(1).ToString().Contains("*") || d.GetValue(1).ToString().Contains("/") || d.GetValue(1).ToString().Contains("%")))
            {
                this.@set = 1;
                if (d.GetValue(1).ToString().Contains("*"))
                {
                    d = d.GetValue(1).ToString().Split(new char[] { '*' });
                    sym = "*";
                }
                if (d.GetValue(1).ToString().Contains("/"))
                {
                    d = d.GetValue(1).ToString().Split(new char[] { '/' });
                    sym = "/";
                }
                if (d.GetValue(1).ToString().Contains("%"))
                {
                    d = d.GetValue(1).ToString().Split(new char[] { '%' });
                    sym = "%";
                }
                if (d.GetValue(1).ToString().Contains("+"))
                {
                    d = d.GetValue(1).ToString().Split(new char[] { '+' });
                    sym = "+";
                }
                if (d.GetValue(1).ToString().Contains("-"))
                {
                    d = d.GetValue(1).ToString().Split(new char[] { '-' });
                    sym = "-";
                }
            }
            string empty = string.Empty;
            string str = string.Empty;
            if (d.GetValue(0).ToString().Contains("*"))
            {
                if ((int)d.Length == 1 && d.GetValue(0).ToString().Length > 16)
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '*' });
                }
                else if ((int)d.Length != 1 || d.GetValue(0).ToString().Length > 16)
                {
                    str = d.GetValue(1).ToString();
                    d = d.GetValue(0).ToString().Split(new char[] { '*' });
                }
                else
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '*' });
                }
                sym = "*";
            }
            if (d.GetValue(0).ToString().Contains("/"))
            {
                if ((int)d.Length == 1 && d.GetValue(0).ToString().Length > 16)
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '/' });
                }
                else if ((int)d.Length != 1 || d.GetValue(0).ToString().Length > 16)
                {
                    str = d.GetValue(1).ToString();
                    d = d.GetValue(0).ToString().Split(new char[] { '/' });
                }
                else
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '/' });
                }
                sym = "/";
            }
            if (d.GetValue(0).ToString().Contains("%"))
            {
                if ((int)d.Length == 1 && d.GetValue(0).ToString().Length > 16)
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '%' });
                }
                else if ((int)d.Length != 1 || d.GetValue(0).ToString().Length > 16)
                {
                    str = d.GetValue(1).ToString();
                    d = d.GetValue(0).ToString().Split(new char[] { '%' });
                }
                else
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '%' });
                }
                sym = "%";
            }
            if (d.GetValue(0).ToString().Contains("+"))
            {
                if ((int)d.Length == 1 && d.GetValue(0).ToString().Length > 16)
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '+' });
                }
                else if ((int)d.Length != 1 || d.GetValue(0).ToString().Length > 16)
                {
                    str = d.GetValue(1).ToString();
                    d = d.GetValue(0).ToString().Split(new char[] { '+' });
                }
                else
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '+' });
                }
                sym = "+";
            }
            if (d.GetValue(0).ToString().Contains("-"))
            {
                if ((int)d.Length == 1 && d.GetValue(0).ToString().Length > 16)
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '-' });
                }
                else if ((int)d.Length != 1 || d.GetValue(0).ToString().Length > 16)
                {
                    str = d.GetValue(1).ToString();
                    d = d.GetValue(0).ToString().Split(new char[] { '-' });
                }
                else
                {
                    d = d.GetValue(0).ToString().Split(new char[] { '-' });
                }
                sym = "-";
            }
            if ((int)d.Length == 1)
            {
                empty = string.Concat(Convert.ToString(string.Concat(d[0], "_", 0)), "_", sym);
            }
            if ((int)d.Length == 2)
            {
                if (str != "")
                {
                    string[] strArrays = new string[] { d[0], "_", d[1], "_", str };
                    empty = string.Concat(Convert.ToString(string.Concat(strArrays)), "_", sym);
                }
                else
                {
                    empty = string.Concat(Convert.ToString(string.Concat(d[0], "_", d[1])), "_", sym);
                }
            }
            if ((int)d.Length == 3)
            {
                string[] strArrays1 = new string[] { d[0], "_", d[1], "_", d[2] };
                empty = string.Concat(Convert.ToString(string.Concat(strArrays1)), "_", sym);
            }
            return empty;
        }

        private void Estimate_Additional_Price()
        {
            string[] strArrays;
            if (this.hid_MultipleLenght.Value != "0")
            {
                for (int i = 0; i <= Convert.ToInt16(this.hid_MultipleLenght.Value) - 1; i++)
                {
                    Label label = new Label()
                    {
                        ID = string.Concat("lblMultipleID_", i)
                    };
                    CheckBox checkBox = new CheckBox()
                    {
                        ID = string.Concat("chkMultiple_", i)
                    };
                    DropDownList dropDownList = new DropDownList()
                    {
                        ID = string.Concat("ddlMultiple_", i),
                        CssClass = "dropDownMultiple250"
                    };
                    string value = this.hdnDDLMultiple.Value;
                    string[] strArrays1 = value.Split(new char[] { '~' });
                    string str = strArrays1[0];
                    if (!checkBox.Checked && str == "" && str == "0")
                    {
                        checkBox.Checked = false;
                        label.Text = string.Concat(this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00");
                    }
                    else if (str.ToLower() == "---select---")
                    {
                        checkBox.Checked = false;
                        label.Text = string.Concat(this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00");
                    }
                    else if (str == "" || str == "0")
                    {
                        checkBox.Checked = false;
                        label.Text = string.Concat(this.commclass.GetCurrencyinRequiredFormate("", true), " 0.00");
                    }
                    else
                    {
                        this.FormulaTagMul = strArrays1[0].ToString();
                        for (int j = 0; j <= (int)strArrays1.Length; j++)
                        {
                            this.FormulaTagMul = this.FormulaTagMul.ToLower().Replace("[$totalex.gst$]", this.hid_TotalExTax.Value).Replace("[$totalinc.gst$]", this.hid_TotalIncTax.Value).Replace("[$totalqty$]", this.hid_TotalQty.Value).Replace("[$totalno.ofcartitems$]", this.noofCartItems.ToString());
                            this.FormulaTagMul = this.SplitFormula(this.FormulaTagMul);
                        }
                        string str1 = this.FormulaTagMul.Trim();
                        if (str1.Contains("(") || str1.Contains(")"))
                        {
                            this.strReplace = str1.Replace('(', ' ').Replace(')', ' ');
                            if (!this.strReplace.ToString().Contains("="))
                            {
                                str1 = this.strReplace.ToString().Trim();
                            }
                            else
                            {
                                string[] strArrays2 = this.strReplace.Split(new char[] { '=' });
                                str1 = strArrays2[1].ToString().Trim();
                            }
                        }
                        string[] strArrays3 = str1.Split(new char[] { ' ' });
                        decimal num = new decimal(0);
                        decimal num1 = new decimal(0);
                        decimal num2 = new decimal(0);
                        string empty = string.Empty;
                        string str2 = "";
                        string empty1 = string.Empty;
                        if ((int)strArrays3.Length == 1)
                        {
                            empty1 = this.DfuncVarification(strArrays3, str2);
                            strArrays = empty1.Split(new char[] { '\u005F' });
                            if (!strArrays[0].ToString().Contains("="))
                            {
                                num = Convert.ToDecimal(strArrays[0]);
                            }
                            else
                            {
                                string[] strArrays4 = strArrays[0].Split(new char[] { '=' });
                                num = Convert.ToDecimal(strArrays4[1]);
                            }
                            if (strArrays[1].ToString().Contains("+") || strArrays[1].ToString().Contains("-") || strArrays[1].ToString().Contains("*") || strArrays[1].ToString().Contains("/") || strArrays[1].ToString().Contains("%"))
                            {
                                this.FVsplit = this.SubFuncSplit(strArrays[1]);
                                if ((int)this.FVsplit.Length == 2)
                                {
                                    this.Add2and3argumentsFunc(strArrays[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                                    num1 = Convert.ToDecimal(this.FVsplit[0]);
                                    num2 = Convert.ToDecimal(this.FVsplit[1]);
                                }
                            }
                            else
                            {
                                num1 = Convert.ToDecimal(strArrays[1]);
                            }
                            if ((int)strArrays.Length != 4)
                            {
                                str2 = strArrays[2];
                                if (num1 == new decimal(0))
                                {
                                    empty = Convert.ToString(num);
                                }
                                else if (num2 != new decimal(0))
                                {
                                    string[] str3 = new string[] { Convert.ToString(num), "_", Convert.ToString(num1), "_", Convert.ToString(num2) };
                                    empty = string.Concat(str3);
                                }
                                else
                                {
                                    empty = string.Concat(Convert.ToString(num), "_", Convert.ToString(num1));
                                }
                            }
                            else
                            {
                                num2 = Convert.ToDecimal(strArrays[2]);
                                str2 = strArrays[3];
                                if (num2 == new decimal(0))
                                {
                                    empty = string.Concat(Convert.ToString(num), "_", Convert.ToString(num1));
                                }
                                else
                                {
                                    string[] str4 = new string[] { Convert.ToString(num), "_", Convert.ToString(num1), "_", Convert.ToString(num2) };
                                    empty = string.Concat(str4);
                                }
                            }
                            strArrays3 = empty.Split(new char[] { '\u005F' });
                        }
                        else if ((int)strArrays3.Length == 2)
                        {
                            empty1 = this.DfuncVarification(strArrays3, str2);
                            strArrays = empty1.Split(new char[] { '\u005F' });
                            if (this.@set != 0)
                            {
                                num1 = Convert.ToDecimal(strArrays[1]);
                                try
                                {
                                    num = Convert.ToDecimal(strArrays[0]);
                                }
                                catch
                                {
                                    num = new decimal(0);
                                }
                            }
                            else
                            {
                                num = Convert.ToDecimal(strArrays[0]);
                                try
                                {
                                    num1 = Convert.ToDecimal(strArrays[1]);
                                }
                                catch
                                {
                                    num1 = new decimal(0);
                                }
                            }
                            if ((int)strArrays.Length != 4)
                            {
                                str2 = strArrays[2];
                                empty = (num1 == new decimal(0) ? Convert.ToString(num) : string.Concat(Convert.ToString(num), "_", Convert.ToString(num1)));
                            }
                            else
                            {
                                try
                                {
                                    num2 = Convert.ToDecimal(strArrays[2]);
                                }
                                catch
                                {
                                    num2 = new decimal(0);
                                }
                                str2 = strArrays[3];
                                if (num2 == new decimal(0))
                                {
                                    empty = string.Concat(Convert.ToString(num), "_", Convert.ToString(num1));
                                }
                                else
                                {
                                    string[] str5 = new string[] { Convert.ToString(num), "_", Convert.ToString(num1), "_", Convert.ToString(num2) };
                                    empty = string.Concat(str5);
                                }
                            }
                            strArrays3 = empty.Split(new char[] { '\u005F' });
                        }
                        if (str1 == "")
                        {
                            label.Text = string.Concat(this.commclass.GetCurrencyinRequiredFormate("", true), "0.00");
                        }
                        else
                        {
                            if ((int)strArrays3.Length > 1)
                            {
                                if ((str2 == "*" || strArrays3.GetValue(1).ToString().Trim() == "*" || strArrays3.GetValue(1).ToString().Trim() != "") && str1.Contains("*"))
                                {
                                    char[] chrArray = new char[] { '*' };
                                    this.NewResult = str1.Split(chrArray);
                                    this.SplitFunc("*", this.NewResult);
                                }
                                if ((str2 == "/" || strArrays3.GetValue(1).ToString() == "/" || strArrays3.GetValue(1).ToString() != "") && str1.Contains("/"))
                                {
                                    char[] chrArray1 = new char[] { '/' };
                                    this.NewResult = str1.Split(chrArray1);
                                    this.SplitFunc("/", this.NewResult);
                                }
                                if ((str2 == "%" || strArrays3.GetValue(1).ToString() == "%" || strArrays3.GetValue(1).ToString() != "") && str1.Contains("%"))
                                {
                                    char[] chrArray2 = new char[] { '%' };
                                    this.NewResult = str1.Split(chrArray2);
                                    this.SplitFunc("%", this.NewResult);
                                }
                                if ((str2 == "+" || strArrays3.GetValue(1).ToString() == "+" || strArrays3.GetValue(1).ToString() != "") && str1.Contains("+"))
                                {
                                    char[] chrArray3 = new char[] { '+' };
                                    this.NewResult = str1.Split(chrArray3);
                                    this.SplitFunc("+", this.NewResult);
                                }
                                if ((str2 == "-" || strArrays3.GetValue(1).ToString() == "-" || strArrays3.GetValue(1).ToString() != "") && str1.Contains("-"))
                                {
                                    char[] chrArray4 = new char[] { '-' };
                                    this.NewResult = str1.Split(chrArray4);
                                    this.SplitFunc("-", this.NewResult);
                                }
                                if (strArrays3.GetValue(1).ToString() == "" || (int)strArrays3.Length == 1)
                                {
                                    this.FormulaVal = str1;
                                }
                            }
                            else if ((int)strArrays3.Length == 1)
                            {
                                this.FormulaVal = str1;
                            }
                            decimal num3 = Convert.ToDecimal(this.FormulaVal);
                            decimal num4 = (Convert.ToDecimal(num3) * Convert.ToDecimal(this.Markup)) / new decimal(100);
                            string str6 = Convert.ToString(Convert.ToDecimal(num3) + Convert.ToDecimal(num4));
                            string[] strArrays5 = str6.Split(new char[] { '.' });
                            this.hdn_lblMultiplePrice.Value = string.Concat(Convert.ToString(strArrays5[0]), ".", strArrays5[1].Remove(2));
                        }
                        checkBox.Checked = true;
                    }
                }
            }
        }

        public void IsAcountingCode(int CompanyID, long EstimateItemID, string ItemType, long EstimateID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            ImageButton imageButton = new ImageButton()
            {
                ID = string.Concat("Image_AccountCode_", EstimateItemID),
                ToolTip = "Select New Accounting Code",
                ImageUrl = "~/images/plus.gif"
            };
            object[] estimateItemID = new object[] { "javascript:ShowAccountingCode('", EstimateItemID, "','", ItemType, "','", EstimateID, "');return false;" };
            imageButton.OnClientClick = string.Concat(estimateItemID);
            if (base.Request.Url.AbsoluteUri.Contains("pagename=estore") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
            {
                imageButton.Attributes.Add("style", "display:none;");
            }
            else if (base.Request.Url.AbsoluteUri.Contains("pagename=job") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
            {
                imageButton.Attributes.Add("style", "display:none;");
            }
            else if (!base.Request.Url.AbsoluteUri.Contains("pagename=inv") || !base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
            {
                imageButton.Attributes.Add("style", "display:block;");
            }
            else
            {
                imageButton.Attributes.Add("style", "display:none;");
            }
            DataTable dataTable = new DataTable();
            dataTable = EstimatesBasePage.Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, "X", EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                str = row["Code"].ToString();
                empty1 = "-";
                empty = row["Description"].ToString();
            }
            this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left' style='clear:both; width:100%;border:0px solid green'> "));
            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='float:left;width:200px;'>"));
            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Accounting_Code"), "</div>")));
            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: right; cursor:pointer;'>"));
            this.plhOrderItems.Controls.Add(imageButton);
            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:15%;max-height=18px; padding-top:5px; border: 0px solid green;text-align:right'>"));
            ControlCollection controls = this.plhOrderItems.Controls;
            object[] objArray = new object[] { "<label id='lbl_AccountingCode_", EstimateItemID, "'class='normalText' style='overflow:hidden; cursor:default; max-width:80%; white-space:nowrap;' title='", str, "'>", str, "</label><label id='lblaccounthypen_", EstimateItemID, "'>", empty1, "</label><label id='lbl_AccountingCode_desc_", EstimateItemID, "' class='normalText' style='cursor:default; max-width:98%; overflow:hidden; white-space:nowrap;' title='", empty, "'>", empty, "</label>" };
            controls.Add(new LiteralControl(string.Concat(objArray)));
            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
        }

        private string Load_Tax_Values(int TaxID, int CompanyID, decimal Taxrate)
        {
            string empty = string.Empty;
            if (Taxrate != new decimal(0))
            {
                this.plhOrderItems.Controls.Add(new LiteralControl("<option value='0~0' >0%</option>"));
            }
            else
            {
                this.plhOrderItems.Controls.Add(new LiteralControl("<option value='0~0' selected='selected' >0%</option>"));
            }
            foreach (DataRow row in EstimateBasePage.estimate_summary_tax_bind_2(CompanyID).Rows)
            {
                empty = (string.Concat(row["TaxID"].ToString(), "~", row["TaxRate"].ToString()) == string.Concat(TaxID.ToString(), "~", Taxrate) ? "selected='selected'" : "");
                ControlCollection controls = this.plhOrderItems.Controls;
                string[] str = new string[] { "<option value='", row["TaxID"].ToString(), "~", row["TaxRate"].ToString(), "' ", empty, ">", this.objBase.SpecialDecode(row["TaxName"].ToString()), "</option>" };
                controls.Add(new LiteralControl(string.Concat(str)));
            }
            return this.plhOrderItems.ToString();
        }

        public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhOrderItems, string Type, string ActionType, int SelectedID)
        {
            if (Type != "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "Label";
                plhOrderItems.Controls.Add(ddlMutiple);
            }
            else
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhOrderItems.Controls.Add(ddlMutiple);
            }
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["SelectedID"]) == SelectedID)
                    {
                        ddlMutiple.SelectedIndex = num;
                    }
                    num++;
                }
            }
        }

        protected void Onclick_btnCreatePo(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            int num = Convert.ToInt32(this.hidPoCount.Value);
            for (int i = 0; i <= num - 1; i++)
            {
                string str2 = string.Empty;
                Label label = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", i));
                Label label1 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", i));
                Label label2 = (Label)this.plhpurchase.FindControl(string.Concat("PoOrdItemID_", i));
                PlaceHolder placeHolder = this.plhpurchase;
                object[] text = new object[] { "chkPo_", label.Text, "_", i };
                CheckBox checkBox = (CheckBox)placeHolder.FindControl(string.Concat(text));
                if (checkBox.Checked)
                {
                    this.OrderItemID = Convert.ToInt64(label2.Text);
                    int num1 = 0;
                    long num2 = Convert.ToInt64(label.Text);
                    DataTable dataTable = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        num1 = Convert.ToInt32(row["QtyNumber"]);
                        str = row["JobNumber"].ToString();
                    }
                    DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(this.OrderItemID);
                    foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                    {
                        object[] objArray = new object[] { str2, dataRow["webothercostName"].ToString(), ":", dataRow["SelectedValue"], "\n" };
                        str2 = string.Concat(objArray);
                    }
                    string text1 = label1.Text;
                    DataTable item = dataSet.Tables[0];
                    string empty3 = string.Empty;
                    foreach (DataRow row1 in item.Rows)
                    {
                        empty3 = row1["JobName"].ToString();
                    }
                    this.Purchse_OrderInsert(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), num2, num1, text1, str, (long)0, str2, empty, str1, empty3, out empty1, out empty2);
                    checkBox.Checked = false;
                    empty = empty1;
                    str1 = empty2;
                }
            }
            this.objnotes.PO_Numbers = empty;
            this.objnotes.Item_number = str1;
            this.objnotes.ModuleName = "job";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOCreate);
            this.objnotes.ModuleID = Convert.ToInt64(this.hdnEstId.Value);
            this.objnotes.CustomerName = this.UserName;
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.hid_Po1Count.Value.ToLower() != "yes")
            {
                HttpResponse response = base.Response;
                object[] value = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.hdnEstId.Value, "&ordid=", this.OrderID };
                response.Redirect(string.Concat(value));
                return;
            }
            long num3 = (long)0;
            DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), "", (long)0);
            foreach (DataRow dataRow1 in dataTable1.Rows)
            {
                num3 = Convert.ToInt64(dataRow1["PurchaseID"].ToString());
            }
            HttpResponse httpResponse = base.Response;
            object[] value1 = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.hdnEstId.Value, "&id=", num3, "&ordid=", this.OrderID };
            httpResponse.Redirect(string.Concat(value1));
        }

        protected void OnClick_lnkOrdItemDelete(object sender, EventArgs e)
        {
            string empty = string.Empty;
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = Notes.select_item_number_for_Activity_History(this.EstimateID, Convert.ToInt64(this.hid_delEstimateItemID.Value), this.Module);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["rownumber"].ToString();
                row["EstimateType"].ToString();
            }
            DataTable dataTable1 = Notes.select_item_Title_for_Activity_History(this.CompanyID, this.EstimateID, Convert.ToInt64(this.hid_delEstimateItemID.Value), "x");
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                str1 = dataRow["itemtitle"].ToString();
            }
            if (this.Module == "webstoreorder")
            {
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemDeleted);
            }
            else if (this.Module == "job")
            {
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemDeleted);
            }
            else if (this.Module == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemDeleted);
            }
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.Item_title = str1;
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.hdn_stockBackwarehoue.Value == "yes" || this.StockCancellationType == "a")
            {
                this.summry.Call_Inventory_Adjustment("cancelled-stock", this.EstimateID, this.CompanyID, Convert.ToInt64(this.hid_delEstimateItemID.Value), this.UserID);
            }
            OrderBasePage.Delete_OrderItems((long)this.CompanyID, Convert.ToInt64(this.hid_delOrderItemID.Value), Convert.ToInt64(this.hid_delEstimateItemID.Value));
            string empty2 = string.Empty;
            int num = 0;
            foreach (DataRow row1 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
            {
                empty2 = string.Concat(row1["OrderItemIDs"].ToString(), "±");
            }
            string[] strArrays = empty2.Split(new char[] { '±' });
            this.CartOrdrItemID = Convert.ToInt32(strArrays[0]);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(Convert.ToInt64(strArrays[i]));
                    DataTable item = dataSet.Tables[0];
                    DataTable item1 = dataSet.Tables[1];
                    foreach (DataRow dataRow1 in item.Rows)
                    {
                        this.EstimateItemID = Convert.ToInt64(dataRow1["EstimateItemID"]);
                        this.AddCartTax = Convert.ToDecimal(dataRow1["Tax"]);
                        num = num + Convert.ToInt32(dataRow1["Quantity"]);
                        this.MainItemPriceExcMarkup = Convert.ToDecimal(dataRow1["MainItemPrice"]) - Convert.ToDecimal(dataRow1["MainItemMarkupPrice"]);
                        this.MainItemMarkupPrice = Convert.ToDecimal(dataRow1["MainItemMarkupPrice"]);
                        int num1 = 0;
                        decimal num2 = new decimal(0);
                        decimal num3 = new decimal(0);
                        decimal num4 = new decimal(0);
                        foreach (DataRow row2 in item1.Rows)
                        {
                            num3 = Convert.ToDecimal(row2["TotalPrice"]) - Convert.ToDecimal(row2["MarkupValue"]);
                            num2 = num2 + num3;
                            num4 = num4 + Convert.ToDecimal(row2["MarkupValue"]);
                            num1++;
                        }
                        this.TotalPriceExcMarkup = this.MainItemPriceExcMarkup + num2;
                        this.TotalMarkupPrice = this.MainItemMarkupPrice + num4;
                        this.TotalPriceIncMarkup = this.TotalPriceExcMarkup + this.TotalMarkupPrice;
                        this.OrderItemTax = Convert.ToDecimal(dataRow1["OrderItemTax"]);
                        this.SellingPrice = this.TotalPriceIncMarkup + this.OrderItemTax;
                        order_summary allItemTotalMarkupPrice = this;
                        allItemTotalMarkupPrice.AllItem_TotalMarkupPrice = allItemTotalMarkupPrice.AllItem_TotalMarkupPrice + this.TotalMarkupPrice;
                        order_summary allItemOrderItemTax = this;
                        allItemOrderItemTax.AllItem_OrderItemTax = allItemOrderItemTax.AllItem_OrderItemTax + this.OrderItemTax;
                        order_summary allItemTotalPriceIncMarkup = this;
                        allItemTotalPriceIncMarkup.AllItem_TotalPriceIncMarkup = allItemTotalPriceIncMarkup.AllItem_TotalPriceIncMarkup + this.TotalPriceIncMarkup;
                        order_summary allItemTotalPriceExcMarkup = this;
                        allItemTotalPriceExcMarkup.AllItem_TotalPriceExcMarkup = allItemTotalPriceExcMarkup.AllItem_TotalPriceExcMarkup + this.TotalPriceExcMarkup;
                        order_summary allItemSellingPrice = this;
                        allItemSellingPrice.AllItem_SellingPrice = allItemSellingPrice.AllItem_SellingPrice + this.SellingPrice;
                    }
                }
            }
            DataTable dataTable2 = OrderBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, (long)order_summary.AccountID, "no");
            foreach (DataRow dataRow2 in dataTable2.Rows)
            {
                long num5 = Convert.ToInt64(dataRow2["WebOtherCostID"].ToString());
                DataTable dataTable3 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.OrderID);
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    if ((long)Convert.ToInt32(row3["OptionID"]) == num5)
                    {
                        this.OptionID = (long)Convert.ToInt32(row3["OptionID"]);
                        this.SelectedID = Convert.ToInt32(row3["SelectedID"]);
                    }
                    DataSet dataSet1 = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(num5);
                    DataTable item2 = dataSet1.Tables[0];
                    DataTable item3 = dataSet1.Tables[1];
                    int count = item3.Rows.Count;
                    int num6 = 0;
                    foreach (DataRow dataRow3 in item3.Rows)
                    {
                        if (this.OptionID == num5)
                        {
                            this.Formula = Convert.ToString(dataRow3["FormulaNew"]);
                            if (this.Formula.Contains("[$TotalEx.GST$]") || this.Formula.Contains("[$TotalQty$]") || this.Formula.Contains("[$TotalInc.GST$]") || this.Formula.Contains("[$TotalNo.ofCartItems$]"))
                            {
                                string[] strArrays1 = this.Formula.Split(new char[] { '~' });
                                int num7 = Convert.ToInt32(strArrays1[2]);
                                Convert.ToInt32(dataRow3["SortOrder"]);
                                this.SelectedID = this.SelectedID;
                                string str2 = string.Empty;
                                if (num7 == this.SelectedID)
                                {
                                    dataRow3["Label"].ToString();
                                    this.hdn_SelFormulaID.Value = Convert.ToString(num7);
                                    this.hdnDDLMultiple.Value = this.Formula;
                                    if (this.hid_MultipleLenght.Value != "0")
                                    {
                                        for (int j = 0; j <= Convert.ToInt16(this.hid_MultipleLenght.Value) - 1; j++)
                                        {
                                            string value = this.hdnDDLMultiple.Value;
                                            string[] strArrays2 = value.Split(new char[] { '~' });
                                            string str3 = strArrays2[0];
                                            this.FormulaTagMul = strArrays2[0].ToString();
                                            for (int k = 0; k <= (int)strArrays2.Length; k++)
                                            {
                                                this.FormulaTagMul = this.FormulaTagMul.ToLower().Replace("[$totalex.gst$]", Convert.ToString(this.TotalPriceIncMarkup)).Replace("[$totalinc.gst$]", Convert.ToString(this.SellingPrice)).Replace("[$totalqty$]", Convert.ToString(num)).Replace("[$totalno.ofcartitems$]", this.noofCartItems.ToString());
                                                this.FormulaTagMul = this.SplitFormula(this.FormulaTagMul);
                                            }
                                            OrderBasePage.CartAdditionalValues_Update(this.OrderID, this.OptionID, Convert.ToDecimal(this.FormulaTagMul), this.SelectedID);
                                        }
                                    }
                                }
                            }
                        }
                        num6++;
                    }
                }
            }
            if (this.Module.ToLower() == "webstoreorder")
            {
                HttpResponse response = base.Response;
                object[] orderID = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "&suc=Del" };
                response.Redirect(string.Concat(orderID));
                return;
            }
            if (this.Module.ToLower() == "job")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "&suc=Del" };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.Module.ToLower() == "invoice")
            {
                HttpResponse response1 = base.Response;
                object[] orderID1 = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "&suc=Del" };
                response1.Redirect(string.Concat(orderID1));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] estimateItemID;
            string[] str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.divHeader.Visible = false;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName.ToString();
            }
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
            if (!base.IsPostBack)
            {
                this.btnProgrssToJob.Text = order_summary.objLanguage.GetLanguageConversion("OK");
                this.Label69.Text = order_summary.objLanguage.GetLanguageConversion("Raise_Delivery_Note");
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
                this.hdnOrderID.Value = this.OrderID.ToString();
                base.Session["OrderID"] = this.OrderID;
            }
            if (ConnectionClass.AccountingCode != "" && ConnectionClass.AccountingCode != "n")
            {
                this.IsAccountingCode = true;
            }
            if (base.Request.Params["EstimateID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"]);
                this.hdnEstId.Value = this.EstimateID.ToString();
            }
            if (base.Request.QueryString["acthist"] != null)
            {
                this.activityhist = base.Request.QueryString["acthist"].ToString().ToLower();
                this.pagename = base.Request.QueryString["pagename"].ToString().ToLower();
            }
            this.Check_SpecialPrivilege = this.objBC.Check_SpecialPrivilege_For_User((long)this.UserID, (long)this.CompanyID);
            bool checkSpecialPrivilege = this.Check_SpecialPrivilege;
            if (base.Request.QueryString["FromeStore"] != null)
            {
                this.FromeStore = base.Request.QueryString["FromeStore"].ToString().ToLower();
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                this.pg = "job";
                this.Pgtype = "job";
                this.ModuleID = this.jobID;
                this.div_InvoiceDate.Visible = false;
                if (!(this.pagename == "estore") || !(this.activityhist == "yes"))
                {
                    this.lblOrderNOText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Job_Number"), ":");
                    this.lbl_StatusText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Job_Status"), ":");
                }
                else
                {
                    this.lblOrderNOText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Order_Number"), ":");
                    this.lbl_StatusText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Order_Status"), ":");
                    this.Module = "webstoreorder";
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
                this.pg = "invoice";
                this.Pgtype = "invoice";
                this.ModuleID = this.InvoiceID;
                this.div_InvoiceDate.Visible = false;
                this.lblOrderNOText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Invoice_Number"), ":");
                this.lbl_StatusText.Text = string.Concat(order_summary.objLanguage.GetLanguageConversion("Invoice_Status"), ":");
            }
            else
            {
                this.pg = "webstoreorder";
                this.Module = "webstoreorder";
                this.Pgtype = "webstoreorder";
                this.ModuleID = this.EstimateID;
                this.div_InvoiceDate.Visible = false;
            }
            this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            this.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (this.PaperMeasure != "In.")
            {
                this.MeasurementValue = order_summary.objLanguage.GetLanguageConversion("SquareMeter");
            }
            else
            {
                this.MeasurementValue = order_summary.objLanguage.GetLanguageConversion("SquareFeet");
            }
            order_summary.Ispaidenable = ConnectionClass.IsPaymentEnable.ToString();
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            int count = EstimatesBasePage.EstimateitemIDList_PerEstID(this.EstimateID).Rows.Count;
            this.noofCartItems = count.ToString();
            if (!base.IsPostBack)
            {
                if (this.Module == "invoice")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "invoice");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                else if (this.Module != "job")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "webstoreorder");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                else if (!(this.pagename == "estore") || !(this.FromeStore == "yes") || !(this.activityhist == "yes"))
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "job");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                else
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "webstoreorder");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    if (row["IsDefaultPORaise"].ToString() != "True")
                    {
                        this.IsDefaultPO = false;
                    }
                    else
                    {
                        this.IsDefaultPO = true;
                    }
                    if (row["IsDefaultDeliveryRaise"].ToString() != "True")
                    {
                        this.chkDeliveryNote.Checked = false;
                    }
                    else
                    {
                        this.chkDeliveryNote.Checked = true;
                    }
                }
            }
            foreach (DataRow dataRow in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
            {
                order_summary.AccountID = Convert.ToInt32(dataRow["AccountID"]);
                base.Session["AccountID"] = order_summary.AccountID.ToString();
            }
            commonClass _commonClass1 = this.commclass;
            now = DateTime.Now;
            this.TodayDate = _commonClass1.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            if (base.Request.Params["suc"] != null)
            {
                if (base.Request.Params["suc"].ToString().ToLower() == "del")
                {
                    this.objBC.Message_Display(order_summary.objLanguage.GetLanguageConversion("Item_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["suc"].ToString().ToLower() == "sta")
                {
                    this.objBC.Message_Display(order_summary.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "msg-success", this.plhMessage);
                }
            }
            if (this.EstimateID != (long)0 && this.activityhist.ToLower() == "yes")
            {
                this.ddlStatus.Attributes.Add("disabled", "disabled");
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row1 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                {
                    order_summary.AccountID = Convert.ToInt32(row1["AccountID"]);
                    this.EstimateID = Convert.ToInt64(row1["EstimateID"].ToString());
                    this.hdnEstId.Value = this.EstimateID.ToString();
                    this.lblCustomerName.Text = this.objBase.SpecialDecode(row1["ClientName"].ToString());
                    this.lblAttention.Text = this.objBase.SpecialDecode(row1["ContactName"].ToString());
                    this.lblEstimateTitle.Text = this.objBase.SpecialDecode(row1["OrderTitle"].ToString());
                    this.lblOrderName.Text = this.objBase.SpecialDecode(row1["OrderTitle"].ToString());
                    this.lblorderedby.Text = this.objBase.SpecialDecode(row1["OrderedBy"].ToString());
                    if (row1["EstimateGreeting"].ToString() == "")
                    {
                        this.lblGreeting.Text = this.objBase.SpecialDecode(row1["Greeting"].ToString());
                    }
                    else
                    {
                        this.lblGreeting.Text = this.objBase.SpecialDecode(row1["EstimateGreeting"].ToString());
                    }
                    this.lblCompany.Text = this.objBase.SpecialDecode(row1["DepartmentName"].ToString());
                    this.objBase.SetDDLValue(this.ddlStatus, row1["StatusID"].ToString());
                    this.LblCompanyName.Text = this.objBase.SpecialDecode(row1["ClientName"].ToString());
                    if (this.LblCompanyName.Text.Length > 25)
                    {
                        this.LblCompanyName.Text = string.Concat(this.LblCompanyName.Text.Substring(0, 25), "....");
                    }
                    this.lblCompanyEmail.Text = this.objBase.SpecialDecode(row1["BusinessEmail"].ToString());
                    this.lblAddress.Text = this.objBase.SpecialDecode(row1["ContactAddress"].ToString());
                    this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(row1["BillingAddress"].ToString());
                    this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(row1["ShippingAddress"].ToString());
                    this.lbl_CustomerOrderNo.Text = this.objBase.SpecialDecode(row1["CustomerOrderNo"].ToString());
                    if (row1["SalesPersonName"].ToString() != "")
                    {
                        this.lblSalePerson.Text = this.objBase.SpecialDecode(row1["SalesPersonName"].ToString());
                    }
                    else
                    {
                        this.lblSalePerson.Text = "n/a";
                    }
                    this.lblEstimator.Text = "eStore";
                    this.lblEstimateNo.Text = this.objBase.SpecialDecode(row1["OrderNo"].ToString());
                    this.OrderNo = row1["OrderNo"].ToString();
                    this.lblOrderNo.Text = this.objBase.SpecialDecode(row1["OrderNo"].ToString());
                    this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row1["OrderDate"].ToString(), this.CompanyID, this.UserID, true);
                    this.lblestimatedartwork.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblDeliveryDate.Text = this.commclass.Eprint_return_Date_Before_View(row1["RequiredBy"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblJobDeliveryDate.Text = this.commclass.Eprint_return_Date_Before_View(row1["RequiredBy"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblAccountNo.Text = this.objBase.SpecialDecode(row1["AccountNo"].ToString());
                    this.lblordAccountNo.Text = this.objBase.SpecialDecode(row1["AccountNo"].ToString());
                    this.objBase.SetDDLValue(this.ddlStatus, row1["StatusID"].ToString());
                    this.lblPaymentType.Text = this.objBase.SpecialDecode(row1["PaymentType"].ToString());
                    this.lblPaymentType1.Text = this.objBase.SpecialDecode(row1["PaymentType"].ToString());
                    if (row1["PaymentType"].ToString() == "Credit Card")
                    {
                        this.imgBtn_PaymentDetails.Style.Add("display", "block");
                    }
                    if (row1["PaymentType"].ToString() == "Credit Card" || row1["PaymentType"].ToString() == "PayPal")
                    {
                        this.OrderPayment = "yes";
                    }
                    if (this.Module.ToLower() == "webstoreorder")
                    {
                        if (!Convert.ToBoolean(row1["IsProformaInvoice"]) || !Convert.ToBoolean(row1["ConvertedToJob"]))
                        {
                            this.hdnJIcreated.Value = "0";
                            this.IddivIspaid.Style.Add("display", "none");
                            this.hdnIsPaid.Value = "0";
                        }
                        else
                        {
                            this.hdnJIcreated.Value = "1";
                            decimal num = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["invoiceAmount"]), 0, "", false, false, true, false, true));
                            decimal num1 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                            if (num == num1 || num1 > num)
                            {
                                this.hdnIsPaid.Value = "1";
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "Paid in Full";
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                            else if (num1 == new decimal(0))
                            {
                                this.hdnIsPaid.Value = "0";
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "No";
                                this.divOrderIspaid.Style.Add("display", "none");
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                            else if (num > num1)
                            {
                                this.hdnIsPaid.Value = "1";
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "Partially Paid";
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                        }
                    }
                    if (this.lblEstimateTitle.Text != "" && this.lblEstimateTitle.Text.Length > 50)
                    {
                        this.lblEstimateTitle.Text = this.objBase.SpecialDecode(BaseClass.WrapString(this.lblEstimateTitle.Text, 50));
                        this.lblOrderName.Text = this.objBase.SpecialDecode(BaseClass.WrapString(this.lblEstimateTitle.Text, 50));
                    }
                    if (this.Module == "job")
                    {
                        this.divHeader.Visible = true;
                        this.lblHeader.Text = this.objBase.SpecialDecode(row1["JobHeader"].ToString());
                        this.lblFooter.Text = this.objBase.SpecialDecode(row1["JobFooter"].ToString());
                    }
                    else if (this.Module == "invoice")
                    {
                        this.divHeader.Visible = true;
                        this.lblHeader.Text = this.objBase.SpecialDecode(row1["InvoiceHeader"].ToString());
                        this.lblFooter.Text = this.objBase.SpecialDecode(row1["InvoiceFooter"].ToString());
                    }
                    this.OrderItemIDs = row1["OrderItemIDs"].ToString();
                    if (!Convert.ToBoolean(row1["isCheckDeliveryRequiredBy"]))
                    {
                        this.lblDeliveryDate.Visible = false;
                        this.lblJobDeliveryDate.Visible = false;
                    }
                    if (Convert.ToBoolean(row1["IsProformaInvoice"]) && this.Module == "job")
                    {
                        this.spnProInvNo.InnerHtml = row1["InvoiceNumber"].ToString();
                        this.spnProInvNoInvDele.InnerHtml = row1["InvoiceNumber"].ToString();
                        this.div_DeliveryDate.Visible = false;
                        this.div_InvNumber.Style.Add("display", "block");
                        if (!Convert.ToBoolean(row1["InvIsDeleted"].ToString()))
                        {
                            this.lnkProformaInvoice.Visible = true;
                            this.lnkProformaInvoiceInvDel.Visible = false;
                        }
                        else
                        {
                            this.lnkProformaInvoice.Visible = false;
                            this.lnkProformaInvoiceInvDel.Visible = true;
                        }
                    }
                    this.ConvertedToJob = row1["ConvertedToJob"].ToString();
                    this.lblContactPhone.Text = this.objBase.SpecialDecode(row1["HomeTelephone"].ToString());
                    this.lblContactEmail.Text = this.objBase.SpecialDecode(row1["email"].ToString());
                    this.lblComments.Text = this.objBase.SpecialDecode(row1["Comments"].ToString().Replace("\n", "<br/>"));
                    this.lblcostcentre.Text = this.objBase.SpecialDecode(row1["CostCentreName"].ToString());
                    this.hasOthercost = Convert.ToBoolean(row1["hasOthercost"].ToString());
                }
                this.btnorderrerun.Text = order_summary.objLanguage.GetLanguageConversion("Re_run_Order_Info");
                if (this.Module.ToLower() == "webstoreorder" || this.Module.ToLower() == "job")
                {
                    DataTable dataTable = EstimatesBasePage.estimate_select_summary(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        this.IsShowJobReRun = Convert.ToBoolean(dataRow1["IsConvertedToJob"]);
                        this.IsShowInvRerun = Convert.ToBoolean(dataRow1["IsConvertedToInvoice"]);
                    }
                }
                if (this.Module == "job")
                {
                    this.btnorderrerun.Text = order_summary.objLanguage.GetLanguageConversion("Re_run_Job_Order_Info");
                    DataTable dataTable1 = OrderBasePage.jobOrder_select(this.CompanyID, this.OrderID, Convert.ToInt64(this.hdnEstId.Value));
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        this.div_JobNo.Style.Add("display", "block");
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row2["converteddate"].ToString(), this.CompanyID, this.UserID, false);
                        this.EstimateID = Convert.ToInt64(row2["EstimateID"].ToString());
                        this.hdnEstId.Value = this.EstimateID.ToString();
                        this.lblJobNo.Text = row2["JobNumber"].ToString();
                        this.JobNo = row2["JobNumber"].ToString();
                        this.lblOrderNo.Text = row2["JobNumber"].ToString();
                        this.ddlStatus.SelectedValue = row2["StatusID"].ToString();
                        this.OrderItemIDs = row2["OrderItemIDs"].ToString();
                        if (row2["IsPaid"].ToString() != "1")
                        {
                            this.hdnIsPaid.Value = "0";
                        }
                        else
                        {
                            this.hdnIsPaid.Value = "1";
                        }
                        if (!Convert.ToBoolean(row2["IsProformaInvoice"]) || !Convert.ToBoolean(row2["ConvertedToJob"]))
                        {
                            this.IddivIspaid.Style.Add("display", "none");
                        }
                        else
                        {
                            this.hdnJIcreated.Value = "1";
                            decimal num2 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["invoiceAmount"]), 0, "", false, false, true, false, true));
                            decimal num3 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                            if (num2 == num3 || num3 > num2)
                            {
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "Paid in Full";
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                            else if (num3 != new decimal(0))
                            {
                                if (num2 <= num3)
                                {
                                    continue;
                                }
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "Partially Paid";
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                            else
                            {
                                this.IddivIspaid.Visible = true;
                                this.imgBtn_PaymentDetails.Style.Add("display", "none");
                                this.ChengePaymentMode.Visible = true;
                                this.lblIspaid.Text = "No";
                                this.divOrderIspaid.Style.Add("display", "none");
                                this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice('ijcreated');");
                                this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            }
                        }
                    }
                }
                else if (this.Module.ToLower() == "invoice")
                {
                    this.div_InvoiceDueDate.Style.Add("display", "block");
                    this.btnorderrerun.Text = order_summary.objLanguage.GetLanguageConversion("Re_run_Invoice_Order_Info");
                    DataTable dataTable2 = InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value));
                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow2["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblInvoiceDueDate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow2["invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblInvoiceNo.Text = dataRow2["InvoiceNumber"].ToString();
                        this.InvoiceNo = dataRow2["InvoiceNumber"].ToString();
                        this.lbl_StatusText.Text = "Invoice Status:";
                        this.lblOrderNo.Text = dataRow2["InvoiceNumber"].ToString();
                        this.JobNo = dataRow2["JobNumber"].ToString();
                        this.lblIspaid.Text = dataRow2["IsPaid"].ToString();
                        this.ddlStatus.SelectedValue = dataRow2["StatusID"].ToString();
                        this.IddivIspaid.Visible = true;
                        decimal num4 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["invoiceAmount"]), 0, "", false, false, true, false, true));
                        decimal num5 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                        if ((num4 == num5 || num5 > num4) && this.lblIspaid.Text == "1")
                        {
                            this.ChengePaymentMode.Visible = true;
                            this.lblIspaid.Text = "Paid in Full";
                            this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            this.imgBtn_PaymentDetails.Style.Add("display", "none");
                            this.hdnIsPaid.Value = "1";
                            this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice();");
                        }
                        else if (num4 > num5 && this.lblIspaid.Text == "1")
                        {
                            this.ChengePaymentMode.Visible = true;
                            this.lblIspaid.Text = "Partially Paid";
                            this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            this.imgBtn_PaymentDetails.Style.Add("display", "none");
                            this.hdnIsPaid.Value = "1";
                            this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice();");
                        }
                        else if (num5 == new decimal(0) && this.lblIspaid.Text == "0")
                        {
                            this.divOrderIspaid.Style.Add("display", "none");
                            this.imgBtn_PaymentDetails.Style.Add("display", "none");
                            this.Hyperlink_PaymentDetails.Visible = false;
                            if (!base.Request.Url.AbsoluteUri.Contains("pagename=inv") || !base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                            {
                                this.ChengePaymentMode.Visible = true;
                            }
                            else
                            {
                                this.ChengePaymentMode.Visible = false;
                            }
                            this.lblIspaid.Text = "No";
                            this.ChengePaymentMode.ToolTip = order_summary.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                            this.hdnIsPaid.Value = "0";
                            this.ChengePaymentMode.Attributes.Add("onclick", "javascript:return OpenPaidInvoice();");
                        }
                        if (dataRow2["Status"].ToString().ToLower() != "locked")
                        {
                            this.btn_estimate.Visible = true;
                            this.div_rerun_status.Visible = true;
                        }
                        else
                        {
                            this.InvoiceStatus = "locked";
                            bool flag = false;
                            foreach (DataRow row3 in CompanyBasePage.Select_Isadmin(this.CompanyID, this.UserID).Rows)
                            {
                                flag = Convert.ToBoolean(row3["IsAdmin"].ToString());
                            }
                            if (!flag)
                            {
                                this.ddlStatus.Visible = false;
                                this.lblInvoicestatus.Text = "This invoice is locked";
                                this.lblInvoicestatus.Visible = true;
                            }
                        }
                        this.div_InvNo.Style.Add("display", "block");
                        this.lblJobNo.Text = dataRow2["JobNumber"].ToString();
                        if (this.lblPaymentType.Text == "Credit Card" || this.lblPaymentType.Text == "PayPal")
                        {
                            this.div_JobNo.Style.Add("display", "block");
                        }
                        else
                        {
                            this.divinv_job.Style.Add("display", "block");
                        }
                    }
                }
                int num6 = 0;
                int num7 = 0;
                string orderItemIDs = this.OrderItemIDs;
                chrArray = new char[] { '±' };
                string[] strArrays = orderItemIDs.Split(chrArray);
                this.CartOrdrItemID = Convert.ToInt32(strArrays[0]);
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
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(Convert.ToInt64(strArrays[i]));
                        DataTable item = dataSet.Tables[0];
                        int count1 = item.Rows.Count;
                        DataTable item1 = dataSet.Tables[1];
                        foreach (DataRow dataRow3 in item.Rows)
                        {
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
                            this.EstimateItemID = Convert.ToInt64(dataRow3["EstimateItemID"]);
                            this.AddCartTax = Convert.ToDecimal(dataRow3["Tax"]);
                            string str1 = "";
                            if (Convert.ToBoolean(dataRow3["IsConvertedToJob"]))
                            {
                            }
                            this.Div_Content = string.Concat("Div_OrdrSummaryContent_", strArrays[i]);
                            this.Div_ShowContent = string.Concat("Div_OrdrShowContent_", strArrays[i]);
                            this.Div_HideContent = string.Concat("Div_OrdrHideContent_", strArrays[i]);
                            this.MainItemPriceExcMarkup = Convert.ToDecimal(dataRow3["MainItemPrice"]) - Convert.ToDecimal(dataRow3["MainItemMarkupPrice"]);
                            this.MainItemMarkupPrice = Convert.ToDecimal(dataRow3["MainItemMarkupPrice"]);
                            int num8 = 0;
                            decimal num9 = new decimal(0);
                            decimal num10 = new decimal(0);
                            decimal num11 = new decimal(0);
                            foreach (DataRow row4 in item1.Rows)
                            {
                                num10 = Convert.ToDecimal(row4["TotalPrice"]) - Convert.ToDecimal(row4["MarkupValue"]);
                                num9 = num9 + num10;
                                num11 = num11 + Convert.ToDecimal(row4["MarkupValue"]);
                                num8++;
                            }
                            this.TotalPriceExcMarkup = this.MainItemPriceExcMarkup + num9;
                            this.TotalMarkupPrice = this.MainItemMarkupPrice + num11;
                            this.TotalPriceIncMarkup = this.TotalPriceExcMarkup + this.TotalMarkupPrice;
                            this.OrderItemTax = Convert.ToDecimal(dataRow3["OrderItemTax"]);
                            this.SellingPrice = this.TotalPriceIncMarkup + this.OrderItemTax;
                            order_summary allItemTotalMarkupPrice = this;
                            allItemTotalMarkupPrice.AllItem_TotalMarkupPrice = allItemTotalMarkupPrice.AllItem_TotalMarkupPrice + this.TotalMarkupPrice;
                            order_summary allItemOrderItemTax = this;
                            allItemOrderItemTax.AllItem_OrderItemTax = allItemOrderItemTax.AllItem_OrderItemTax + this.OrderItemTax;
                            order_summary allItemTotalPriceIncMarkup = this;
                            allItemTotalPriceIncMarkup.AllItem_TotalPriceIncMarkup = allItemTotalPriceIncMarkup.AllItem_TotalPriceIncMarkup + this.TotalPriceIncMarkup;
                            order_summary allItemTotalPriceExcMarkup = this;
                            allItemTotalPriceExcMarkup.AllItem_TotalPriceExcMarkup = allItemTotalPriceExcMarkup.AllItem_TotalPriceExcMarkup + this.TotalPriceExcMarkup;
                            order_summary allItemSellingPrice = this;
                            allItemSellingPrice.AllItem_SellingPrice = allItemSellingPrice.AllItem_SellingPrice + this.SellingPrice;
                            empty = dataRow3["CatalogueName"].ToString();
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='width:100%;margin-top:5px;padding:0px'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<h3><a style='border-bottom-width:0px' href='#'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td width='25%'>"));
                            ControlCollection controls = this.plhOrderItems.Controls;
                            estimateItemID = new object[] { "&nbsp;&nbsp;&nbsp;&nbsp;<label id='lblHeaderPanelTitle_", this.EstimateItemID, "' value='", dataRow3["CatalogueName"], "' class='HeaderText' >", this.objBase.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</label><span class='HeaderText'>&nbsp;Detail</span>" };
                            controls.Add(new LiteralControl(string.Concat(estimateItemID)));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td width='25%'>"));
                            ControlCollection controlCollections = this.plhOrderItems.Controls;
                            estimateItemID = new object[] { "<span id='spn_Quantity' class='HeaderText'>Quantity:&nbsp;", Convert.ToDecimal(dataRow3["Quantity"]), "&nbsp;&nbsp;Selling Price (inc. Tax):&nbsp;", this.commclass.GetCurrencyinRequiredFormate("", true), "&nbsp;", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.SellingPrice, 0, "", false, false, true), " </span>" };
                            controlCollections.Add(new LiteralControl(string.Concat(estimateItemID)));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' width='25%' >"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left;padding-left: 5px;'>"));
                            Label label = new Label()
                            {
                                ID = string.Concat("lblItemstatus_", this.EstimateItemID)
                            };
                            label.Font.Bold = true;
                            label.Text = this.lbl_StatusText.Text;
                            this.plhOrderItems.Controls.Add(label);
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left; padding-left: 5px; margin-top: -1px;'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<span id='spnStatusItems'>"));
                            DropDownList dropDownList = new DropDownList()
                            {
                                ID = string.Concat("ddlInduvidualStatus_", this.EstimateItemID)
                            };
                            dropDownList.Style.Add("Height", "18px");
                            dropDownList.Style.Add("Width", "165px");
                            dropDownList.CssClass = "normaltext";
                            if (this.Module == "job")
                            {
                                this.objSet.Bind_Status_new(dropDownList, this.CompanyID, "no", "job");
                                this.objBase.SetDDLValue(dropDownList, dataRow3["JOBItemStatusID"].ToString());
                            }
                            else if (this.Module != "invoice")
                            {
                                this.objSet.Bind_Status_new(dropDownList, this.CompanyID, "no", "webstoreorder");
                                this.objBase.SetDDLValue(dropDownList, dataRow3["EstimateItemStatusID"].ToString());
                            }
                            else
                            {
                                this.objSet.Bind_Status_new(dropDownList, this.CompanyID, "no", "invoice");
                                this.objBase.SetDDLValue(dropDownList, dataRow3["InvocieItemStatusID"].ToString());
                            }
                            dropDownList.Attributes.Add("onchange", string.Concat("javascript:SaveIndividualOrderStatus(this.value,", this.EstimateItemID, ");return false;"));
                            this.plhOrderItems.Controls.Add(dropDownList);
                            HiddenField hiddenField = this.hdnItems;
                            hiddenField.Value = string.Concat(hiddenField.Value, this.EstimateItemID, "@");
                            this.plhOrderItems.Controls.Add(new LiteralControl("</span>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</a></h3>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='padding:10px 0px 10px 10px;margin:0px 0px 0px 0px;'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='Div_OrdrSummaryContent_", strArrays[i], "'  style='display:block; margin:0px;padding:0px' >")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' width='100%' border='0'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div id='activity'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div id='activity-header'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span>", order_summary.objLanguage.GetLanguageConversion("Quick_Links"), "</span>")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            item_summary_quicklinks companyID = (item_summary_quicklinks)base.LoadControl("~/usercontrol/Item/item_summary_quicklinks.ascx");
                            companyID.ID = string.Concat("itemdetails_quickLinks_", this.EstimateItemID);
                            companyID.ParentEstimateItemID = this.EstimateItemID;
                            companyID.UserID = this.UserID;
                            companyID.CompanyID = this.CompanyID;
                            companyID.EstimateID = this.EstimateID;
                            companyID.jobID = this.jobID;
                            companyID.InvoiceID = this.InvoiceID;
                            companyID.jID = this.jID;
                            companyID.InvID = this.InvID;
                            companyID.quicklinksfrom = "item  details";
                            this.plhOrderItems.Controls.Add(companyID);
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top'  style='width:60%; border:0px solid green; padding-left:10px;'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<table id='tblMessage_", this.EstimateItemID, "' align='right' border='0px' width='50%' style='display:none;'>")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<label id='lblMessage_", this.EstimateItemID, "' class='msg-success'>Item updated successfully.</label>")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div ", str1, " style='border:solid 0px red ' >")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left; width: 100%;border:solid 0px green '>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width: 50%;border:solid 0px blue '>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 2px 2px; width: 100%;'>"));
                            ControlCollection controls1 = this.plhOrderItems.Controls;
                            estimateItemID = new object[] { "<span class='HeaderText' id='spnItem_", i, "' style='color:#751717'>Item ", i + 1, " Summary </span>" };
                            controls1.Add(new LiteralControl(string.Concat(estimateItemID)));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;width: 45%;border:solid 0px red '>&nbsp;"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;padding-right:20px'>"));
                            order_summary_action usercontrolOrdersOrderSummaryAction = (order_summary_action)base.LoadControl("~/usercontrol/Orders/order_summary_action.ascx");
                            usercontrolOrdersOrderSummaryAction.ID = string.Concat("UcItemSummary_order_", i);
                            HiddenField hiddenField1 = (HiddenField)usercontrolOrdersOrderSummaryAction.FindControl("HdnEstimateItemID");
                            str = new string[] { this.OrderID.ToString(), "μ", this.hdnEstId.Value.ToString(), "μ", this.EstimateItemID.ToString(), "μ", strArrays[i].ToString(), "μx" };
                            hiddenField1.Value = string.Concat(str);
                            RadContextMenu radContextMenu = (RadContextMenu)usercontrolOrdersOrderSummaryAction.FindControl("rcm_ItemOrder");
                            if (this.Module.ToLower() == "webstoreorder")
                            {
                                if ((int)strArrays.Length > 1)
                                {
                                    radContextMenu.Items[1].Visible = true;
                                }
                                if (!this.IsShowJobReRun)
                                {
                                    this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction);
                                }
                            }
                            else if (this.Module.ToLower() != "job")
                            {
                                if ((int)strArrays.Length > 1)
                                {
                                    radContextMenu.Items[1].Visible = true;
                                }
                                this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction);
                            }
                            else
                            {
                                if ((int)strArrays.Length > 1)
                                {
                                    radContextMenu.Items[1].Visible = true;
                                }
                                if (this.IsShowInvRerun)
                                {
                                    radContextMenu.Items[0].Visible = false;
                                    radContextMenu.Items[1].Visible = false;
                                }
                                this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction);
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;padding-right:20px'>"));
                            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                            {
                                if (base.Request.Browser.Browser.ToLower() != "ie")
                                {
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;margin:0px 0px 0px 6px;'>"));
                                }
                                else
                                {
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;margin:0px 0px 0px 1px;'>"));
                                }
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            string empty2 = string.Empty;
                            string str2 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/order_popup.aspx?OrderItemID=", strArrays[i], "&EstimateID=", this.hdnEstId.Value, "&module=", this.Module, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\"><b>", dataRow3["CatalogueName"], "</b></a>" };
                                empty2 = string.Concat(estimateItemID);
                                this.plhOrderItems.Controls.Add(new LiteralControl("<table border='0' width='99%'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<td width='74%'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(this.objBase.SpecialDecode(empty2)));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                try
                                {
                                    empty2 = dataRow3["CatalogueName"].ToString();
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<table border='0' width='99%'>"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<td width='74%'>"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl(this.objBase.SpecialDecode(empty2)));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                                }
                                catch
                                {
                                }
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<table borser='0'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left' style='width:100%;border:solid 0px blue '> "));
                            if (dataRow3["UploadFile"].ToString() != "" || dataRow3["UploadFile1"].ToString() != "" || dataRow3["UploadFile2"].ToString() != "" || dataRow3["PDFNameFromCart"] != null || dataRow3["PrintReadyFile"].ToString() != "")
                            {
                                int num12 = 0;
                                if (dataRow3["UploadFile"].ToString() != "")
                                {
                                    num12 = 1;
                                }
                                if (dataRow3["UploadFile1"].ToString() != "")
                                {
                                    num12++;
                                }
                                if (dataRow3["UploadFile2"].ToString() != "")
                                {
                                    num12++;
                                }
                                if (dataRow3["PDFNameFromCart"].ToString() != "")
                                {
                                    num12++;
                                }
                                if (dataRow3["PrintReadyFile"].ToString() != "")
                                {
                                    num12++;
                                }
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='width:99%;border:0px solid red; display:block;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left' >"));
                                if (num12 != 0)
                                {
                                    stringBuilder12.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                                    estimateItemID = new object[] { "<div style='float:left;'>Artwork File(s) (", num12, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments(", i, ");' title='Attachments'></div></div>" };
                                    stringBuilder12.Append(string.Concat(estimateItemID));
                                    stringBuilder12.Append("</div>");
                                    estimateItemID = new object[] { global.SecureSitePath(), this.serverName, "/store/", order_summary.AccountID, "/artwork/" };
                                    string str3 = string.Concat(estimateItemID);
                                    stringBuilder12.Append(string.Concat("<div id='div_Summary_Attachments_", i, "' style='display:none;width:100%;height:15px;border:solid 0px green;'>"));
                                    stringBuilder12.Append("<div style='width:50%;border:solid 0px;float:left;'>");
                                    if (dataRow3["UploadFile"].ToString() != "")
                                    {
                                        estimateItemID = new object[] { "<div '><a href=", str3, dataRow3["UploadFile"], " target='_blank'>", dataRow3["UploadFile"].ToString(), "</a></div>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                    }
                                    stringBuilder12.Append("</div>");
                                    stringBuilder12.Append("</div>");
                                    stringBuilder12.Append(string.Concat("<div id='div_Detail_Attachments_", i, "' style='display:block;width:100%;height:15px;border:solid 0px green;'>"));
                                    stringBuilder12.Append("<div style='width:50%;border:solid 0px;float:left;'>");
                                    if (dataRow3["UploadFile"].ToString() != "")
                                    {
                                        estimateItemID = new object[] { "<div><a href=", str3, dataRow3["UploadFile"], " target='_blank'>", dataRow3["UploadFile"].ToString(), "</a></div>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                    }
                                    if (dataRow3["UploadFile1"].ToString() != "")
                                    {
                                        estimateItemID = new object[] { "<div><a href=", str3, dataRow3["UploadFile1"], " target='_blank'>", dataRow3["UploadFile1"].ToString(), "</a></div>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                    }
                                    if (dataRow3["UploadFile2"].ToString() != "")
                                    {
                                        if (dataRow3["UploadFile"].ToString() == "")
                                        {
                                        }
                                        estimateItemID = new object[] { "<div><a href=", str3, dataRow3["UploadFile2"], " target='_blank'>", dataRow3["UploadFile2"].ToString(), "</a></div>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                    }
                                    if (dataRow3["PDFNameFromCart"].ToString() != "")
                                    {
                                        stringBuilder12.Append("<div>");
                                        estimateItemID = new object[] { "<a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", dataRow3["PDFNameFromCart"].ToString(), "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", dataRow3["CatalogueName"], ".pdf</a>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                        stringBuilder12.Append("</div>");
                                    }
                                    if (dataRow3["PrintReadyFile"].ToString() != "")
                                    {
                                        stringBuilder12.Append("<div>");
                                        estimateItemID = new object[] { "<a id='lblPrintReadyFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", dataRow3["PrintReadyFile"].ToString(), "\",", this.CompanyID, ");'>", dataRow3["PrintReadyFile"], "</a>" };
                                        stringBuilder12.Append(string.Concat(estimateItemID));
                                        stringBuilder12.Append("</div>");
                                    }
                                    stringBuilder12.Append("</div>");
                                    stringBuilder12.Append("</div>");
                                    stringBuilder12.Append("<div class='onlyEmpty'></div>");
                                }
                                stringBuilder12.Append("</div>");
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder12.ToString()));
                            }
                            string str4 = "";
                            str4 = "float:left";
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:10px'></div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div style='width:97%;border:solid 0px red;", str4, "'>")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='width:200px;'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Job_Name")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(this.objBase.SpecialDecode(dataRow3["JobName"].ToString()) ?? ""));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:50%;border:0px solid green;' align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='divbtnSummary_", i, "' style='float: left;display:block;'>")));
                            Button button = new Button()
                            {
                                ID = string.Concat("btnSummary_", i),
                                CssClass = "button",
                                Text = "Summary",
                                Visible = false
                            };
                            string.Concat("summary", i.ToString());
                            AttributeCollection attributes = button.Attributes;
                            estimateItemID = new object[] { "javascript:Summary_Detail_Show(", i, ",'summary',", strArrays[i], ");return false;" };
                            attributes.Add("onclick", string.Concat(estimateItemID));
                            this.plhOrderItems.Controls.Add(button);
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='divbtnDetail_", i, "' style='float: left;display:none;'>")));
                            Button button1 = new Button()
                            {
                                ID = string.Concat("btnDetail_", i),
                                CssClass = "button",
                                Text = "Detail"
                            };
                            AttributeCollection attributeCollection = button1.Attributes;
                            estimateItemID = new object[] { "javascript:Summary_Detail_Show(", i, ",'detail',", strArrays[i], ");return false;" };
                            attributeCollection.Add("onclick", string.Concat(estimateItemID));
                            this.plhOrderItems.Controls.Add(button1);
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            if (!(this.InvoiceStatus.ToLower() == "locked") || !(this.Module == "invoice"))
                            {
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='divbtnrerun_", i, "' style='float: left;display:block;padding:0px 0px 0px 5px;'>")));
                            }
                            else
                            {
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='divbtnrerun_", i, "' style='float: left;display:none;padding:0px 0px 0px 5px;'>")));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            if (this.activityhist != null && this.activityhist == "yes" && this.FromeStore == "yes")
                            {
                                this.div_eStore.Attributes.Add("style", "display:block");
                                ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:showSummaryDetail('detail','estinfo');", true);
                            }
                            if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                            {
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left;width:5px;'>&nbsp;</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left; border:0px solid red;'>"));
                                Button button2 = new Button()
                                {
                                    ID = string.Concat("btnItemDescription_", i),
                                    CssClass = "button",
                                    Text = "Item Description",
                                    Visible = false
                                };
                                AttributeCollection attributes1 = button2.Attributes;
                                estimateItemID = new object[] { "javascript:return ShowEstItemDescription('", this.EstimateItemID, "','x', '", this.Pgtype, "');" };
                                attributes1.Add("onclick", string.Concat(estimateItemID));
                                this.plhOrderItems.Controls.Add(button2);
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            order_summary totalQntityToCart = this;
                            totalQntityToCart.TotalQntityToCart = totalQntityToCart.TotalQntityToCart + Convert.ToInt32(dataRow3["Quantity"]);
                            this.hid_TotalQty.Value = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["Quantity"]), 0, "", true, false, true);
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div style='width:67%;border:solid 0px red;", str4, "'>")));
                            if (dataRow3["ManageID"].ToString().Trim() != "" && Convert.ToInt64(dataRow3["ManageID"]) > (long)0)
                            {
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='campaign_tdwidth'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Campaign")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' style='border:solid 0px red;width:50%' align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<Label id='lblCampaign'> ", this.objBase.SpecialDecode(dataRow3["EventName"].ToString()), "</LABEL>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='campaign_tdwidth'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Campaign_Sign_Number")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' style='border:solid 0px red;width:22.5%' align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<Label id='lblCampaignSignNumber' class='camapign_label'> ", this.objBase.SpecialDecode(dataRow3["CampaignSignNumber"].ToString()), "</LABEL>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='width:200px;'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Quantity")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' style='border:solid 0px red;width:22.5%' align='left'>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<Label id='lblquantity' style='text-align:right;width:100%;float:right;'  maxlength='50'> ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["Quantity"]), 0, "", true, false, true), "</LABEL>")));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:17%; border:0px solid red;'>&nbsp;</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.summry.EndTableCreation(stringBuilder);
                            this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                            string str5 = dataRow3["MatrixType"].ToString();
                            decimal num13 = Convert.ToDecimal(dataRow3["Height"]);
                            decimal num14 = Convert.ToDecimal(dataRow3["Width"]);
                            if (str5.ToLower() == "g")
                            {
                                decimal num15 = new decimal(0);
                                num15 = (this.PaperMeasure != "In." ? (num13 * num14) / new decimal(1000000) : (num13 * num14) / new decimal(144));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div style='width:67%;border:solid 0px red;", str4, "'>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='width:200px;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat(order_summary.objLanguage.GetLanguageConversion("Area"), " (", this.MeasurementValue, ")")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' style='border:solid 0px red;width:22.5%' align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<Label id='lblDimension' style='text-align:right;width:100%;float:right;'  maxlength='50'> ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</Label>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:17%; border:0px solid red;'>&nbsp;</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div style='width:67%;border:solid 0px red;", str4, "'>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='width:200px;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat(order_summary.objLanguage.GetLanguageConversion("Dimension_Summary_Page"), this.PaperMeasure)));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box' style='border:solid 0px red;width:22.5%' align='left'>"));
                                ControlCollection controlCollections1 = this.plhOrderItems.Controls;
                                str = new string[] { "<Label id='lblWidthXHeight' style='text-align:right;width:100%;float:right; white-space: pre;'> ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num14, 0, "", false, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</Label>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(str)));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:17%; border:0px solid red;'>&nbsp;</div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width:600px;height:0px; border:0px solid Transparent;'></div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_detail_", i, "' style='display:block;'>")));
                            this.summry.PBReadTopString(stringBuilder1, order_summary.objLanguage.GetLanguageConversion("Total_Cost"), string.Concat("div_ProductPrice_", i));
                            stringBuilder1.Append("<td align='right' width='24%'>");
                            stringBuilder1.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.MainItemPriceExcMarkup), 0, "", false, false, true), "</LABEL>"));
                            stringBuilder1.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder1);
                            this.summry.EndTableCreation(stringBuilder1);
                            this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                            if (num8 != 0)
                            {
                                this.summry.PBReadTopString(stringBuilder2, order_summary.objLanguage.GetLanguageConversion("Additional_Options_Cost"), string.Concat("div_AddItemPrice_", i));
                                stringBuilder2.Append("<td align='right' width='24%'>");
                                stringBuilder2.Append(string.Concat("<Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num9, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder2.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder2);
                                this.summry.EndTableCreation(stringBuilder2);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                            }
                            string empty3 = string.Empty;
                            if (!(this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() == "false") && !this.Check_SpecialPrivilege)
                            {
                                this.summry.PBReadTopString(stringBuilder3, order_summary.objLanguage.GetLanguageConversion("Cost_Price_ex_Markup"), string.Concat("div_TotalPriceExcMarkup_", i));
                                stringBuilder3.Append("<td align='right' width='24%'>");
                                stringBuilder3.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalPriceExcMarkup, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder3.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder3);
                                this.summry.EndTableCreation(stringBuilder3);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                                this.summry.PBReadTopString(stringBuilder4, order_summary.objLanguage.GetLanguageConversion("Markup"), string.Concat("div_TotalMarkupPrice_", i));
                                stringBuilder4.Append("<td align='right' width='24%'>");
                                stringBuilder4.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalMarkupPrice, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder4.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder4);
                                this.summry.EndTableCreation(stringBuilder4);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                            }
                            string empty4 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                            {
                                this.summry.PBReadTopString(stringBuilder5, order_summary.objLanguage.GetLanguageConversion("Cost_Incl_Markup"), string.Concat("div_TotalPriceIncMarkup_", i));
                                stringBuilder5.Append("<td align='right' width='24%'>");
                                stringBuilder5.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalPriceIncMarkup, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder5.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder5);
                                this.summry.EndTableCreation(stringBuilder5);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                            }
                            string empty5 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showtax").ToLower() != "false")
                            {
                                this.summry.PBReadTopString(stringBuilder6, order_summary.objLanguage.GetLanguageConversion("Tax"), string.Concat("div_TotalTaxPrice_", i));
                                stringBuilder6.Append("<td align='right' width='24%'>");
                                stringBuilder6.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OrderItemTax, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder6.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder6);
                                this.summry.EndTableCreation(stringBuilder6);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                            }
                            string empty6 = string.Empty;
                            if (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false")
                            {
                                this.SellingPrice = this.TotalPriceIncMarkup + this.OrderItemTax;
                                this.summry.PBReadTopString(stringBuilder7, string.Concat("<b>", order_summary.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</b>"), string.Concat("div_TotalSellingPrice_", i));
                                stringBuilder7.Append("<td align='right' width='24%'>");
                                stringBuilder7.Append(string.Concat(" <Label style='text-align: right;width:100%; border:0px solid red;'  maxlength='50'> <b>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.SellingPrice, 0, "", false, false, true), "</b></LABEL>"));
                                stringBuilder7.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder7);
                                this.summry.EndTableCreation(stringBuilder7);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            decimal totalPriceIncMarkup = this.TotalPriceIncMarkup - Convert.ToDecimal(this.TotalPriceExcMarkup.ToString().Replace("-", ""));
                            order_summary allItemGrossProfitDollar = this;
                            allItemGrossProfitDollar.AllItem_GrossProfitDollar = allItemGrossProfitDollar.AllItem_GrossProfitDollar + totalPriceIncMarkup;
                            decimal totalPriceIncMarkup1 = new decimal(0);
                            if (this.TotalPriceIncMarkup != new decimal(0))
                            {
                                totalPriceIncMarkup1 = (totalPriceIncMarkup / this.TotalPriceIncMarkup) * new decimal(100);
                            }
                            this.AllItem_GrossProfitMargin = totalPriceIncMarkup1;
                            string str6 = string.Empty;
                            str6 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                            string empty7 = string.Empty;
                            empty7 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                            if ((!(str6.ToLower() == "false") || !(empty7.ToLower() == "false")) && !this.Check_SpecialPrivilege)
                            {
                                string str7 = string.Empty;
                                string empty8 = string.Empty;
                                if (empty7.ToLower() != "false")
                                {
                                    empty8 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    empty8 = "display:none;";
                                }
                                if (str6.ToLower() != "false")
                                {
                                    str7 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                }
                                else
                                {
                                    str7 = "display:none;";
                                }
                                this.summry.PBReadTopString(stringBuilder8, order_summary.objLanguage.GetLanguageConversion("Gross_Profit"), string.Concat("div_GrossProft_", i));
                                stringBuilder8.Append("<td align='right' width='24%' style='border:solid 0px red'>");
                                str = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;'  maxlength='50'><div style='", empty8, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, totalPriceIncMarkup, 0, "", false, false, true), "</div><div style='padding-top:3px;", str7, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, totalPriceIncMarkup1, 0, "", false, false, true), "%</div></LABEL>" };
                                stringBuilder8.Append(string.Concat(str));
                                stringBuilder8.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder8);
                                this.summry.EndTableCreation(stringBuilder8);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder8.ToString()));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_Summary_", i, "' style='display:none;'>")));
                                this.summry.PBReadTopString(stringBuilder9, "Tax", string.Concat("div_TotalTaxPrice_", i));
                                stringBuilder9.Append("<td align='right' width='24%'>");
                                stringBuilder9.Append(string.Concat("<Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OrderItemTax, 0, "", false, false, true), "</LABEL>"));
                                stringBuilder9.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder9);
                                this.summry.EndTableCreation(stringBuilder9);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder9.ToString()));
                                this.summry.PBReadTopString(stringBuilder10, "<b>Selling Price (inc. Tax)</b>", string.Concat("div_TotalSellingPrice_", i));
                                stringBuilder10.Append("<td align='right' width='24%'>");
                                stringBuilder10.Append(string.Concat("<Label style='text-align: right;width:100%;'  maxlength='50'> <b>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.SellingPrice, 0, "", false, false, true), "</b></LABEL>"));
                                stringBuilder10.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder10);
                                this.summry.EndTableCreation(stringBuilder10);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder10.ToString()));
                                this.summry.PBReadTopString(stringBuilder11, "Gross Profit", string.Concat("div_SummaryGrossProft_", i));
                                stringBuilder11.Append("<td align='right' width='24%'>");
                                str = new string[] { "<Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, totalPriceIncMarkup, 0, "", false, false, true), "<div style='padding-top:3px'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, totalPriceIncMarkup1, 0, "", false, false, true), "%</div></LABEL>" };
                                stringBuilder11.Append(string.Concat(str));
                                stringBuilder11.Append("</td>");
                                this.summry.EmptyRowCreation(stringBuilder11);
                                this.summry.EndTableCreation(stringBuilder11);
                                this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder11.ToString()));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            if (this.IsAccountingCode)
                            {
                                this.IsAcountingCode(this.CompanyID, this.EstimateItemID, "X", Convert.ToInt64(this.hdnEstId.Value));
                            }
                            this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                            if (this.Module != "webstoreorder")
                            {
                                continue;
                            }
                            if (!Convert.ToBoolean(dataRow3["IsConvertedToJob"]))
                            {
                                this.plhProgrssChk_list.Controls.Add(new LiteralControl("<div align='left' style='width: 100%; border: solid 0px red;'>"));
                                this.plhProgrssChk_list.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 200px; float: left'>"));
                                ControlCollection controls2 = this.plhProgrssChk_list.Controls;
                                estimateItemID = new object[] { "<span id='spnOrderItemTitle_", num7, "' class='normalText'>", dataRow3["JobName"], "</span></div>" };
                                controls2.Add(new LiteralControl(string.Concat(estimateItemID)));
                                ControlCollection controlCollections2 = this.plhProgrssChk_list.Controls;
                                estimateItemID = new object[] { "<span id='spn_OrderItemID_", num7, "' style='display:none;'>", strArrays[i], "</span><span id='spn_EstimateItemID_", num7, "' style='display:none;'>", dataRow3["EstimateItemID"], "</span><div class='box' style='width: 50%;'>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                                CheckBox checkBox = new CheckBox()
                                {
                                    ID = string.Concat("chkOrderList_", num7),
                                    Checked = true,
                                    Text = string.Concat(this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.SellingPrice, 0, "", false, false, true))
                                };
                                this.plhProgrssChk_list.Controls.Add(checkBox);
                                this.plhProgrssChk_list.Controls.Add(new LiteralControl("</div></div>"));
                                num7++;
                            }
                            this.hid_NoofOrdersToProgress.Value = num7.ToString();
                        }
                    }
                    this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' class='shadow_right'  style='width:40%;padding-top:5px; border:0px solid red;' >"));
                    EstimateCommonMethods.ShowDescriptionOnSummary(this.Pgtype, this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.EstimateItemID, this.plhOrderItems, empty, this.activityhist);
                    this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                    num6 = i;
                }
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                int num18 = 0;
                decimal num19 = new decimal(0);
                long num20 = (long)0;
                int count2 = 0;
                if (this.hasOthercost)
                {
                    DataTable dataTable3 = EstimatesBasePage.Orders_Othercostitem_select(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.Pgtype);
                    num6++;
                    count2 = dataTable3.Rows.Count;
                    foreach (DataRow dataRow4 in dataTable3.Rows)
                    {
                        empty = this.objBase.SpecialDecode(dataRow4["ItemTitle_New"].ToString());
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='width:100%;margin-top:5px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<h3><a style='border-bottom-width:0px' href='#'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td width='54%'>"));
                        ControlCollection controls3 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "&nbsp;&nbsp;&nbsp;&nbsp;<label id='lblHeaderPanelTitle_", dataRow4["estimateitemid"], "' value='", dataRow4["ItemTitle_New"], "' class='HeaderText' >", this.objBase.SpecialDecode(dataRow4["ItemTitle_New"].ToString()), "</label><span class='HeaderText' >&nbsp;", order_summary.objLanguage.GetLanguageConversion("Other_Cost"), " </span><span class='HeaderText'>&nbsp;Detail</span>" };
                        controls3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td width='38%'>"));
                        ControlCollection controlCollections3 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<span id='spn_Quantity' class='HeaderText'>Quantity:&nbsp;", Convert.ToDecimal(dataRow4["TotalQty1"]), "&nbsp;&nbsp;Selling Price (inc. Tax):&nbsp;", this.commclass.GetCurrencyinRequiredFormate("", true), "&nbsp;", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["TotalSellingPrice1"].ToString()), 0, "", false, false, true), " </span>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</a></h3>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='padding:10px 0px 10px 10px;margin:0px 0px 0px 0px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div id='Div_OrdrOthercostContent_", dataRow4["estimateitemid"], "'  style='display:block; margin:0px;padding:0px' >")));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' width='100%' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div id='activity'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div id='activity-header'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span>", order_summary.objLanguage.GetLanguageConversion("Quick_Links"), "</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        item_summary_quicklinks estimateID = (item_summary_quicklinks)base.LoadControl("~/usercontrol/Item/item_summary_quicklinks.ascx");
                        estimateID.ID = string.Concat("itemdetails_quickLinks_Othercost_", this.EstimateItemID);
                        estimateID.ParentEstimateItemID = this.EstimateItemID;
                        estimateID.UserID = this.UserID;
                        estimateID.CompanyID = this.CompanyID;
                        estimateID.EstimateID = this.EstimateID;
                        estimateID.jobID = this.jobID;
                        estimateID.InvoiceID = this.InvoiceID;
                        estimateID.jID = this.jID;
                        estimateID.InvID = this.InvID;
                        estimateID.quicklinksfrom = "other cost";
                        this.plhOrderItems.Controls.Add(estimateID);
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top'  style='width:60%; border:0px solid green;padding-left:10px'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<table id='tblMessage_", dataRow4["estimateitemid"], "' align='right' border='0px' width='50%' style='display:none;'>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<label id='lblMessage_", dataRow4["estimateitemid"], "' class='msg-success'>Item updated successfully.</label>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div  style='border:solid 0px red ' >"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: left; width: 100%;border:solid 0px green '>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:left;width: 50%;border:solid 0px blue '>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 2px 2px; width: 100%;'>"));
                        ControlCollection controls4 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<span class='HeaderText' id='spnItem_", num6 + 1, "' style='color:#751717'>Item ", num6 + 1, " Summary </span>" };
                        controls4.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;width: 45%;border:solid 0px red '>&nbsp;"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;padding-right:20px'>"));
                        order_summary_action usercontrolOrdersOrderSummaryAction1 = (order_summary_action)base.LoadControl("~/usercontrol/Orders/order_summary_action.ascx");
                        usercontrolOrdersOrderSummaryAction1.ID = string.Concat("UcItemSummary_order_", num6 + 1);
                        HiddenField hiddenField2 = (HiddenField)usercontrolOrdersOrderSummaryAction1.FindControl("HdnEstimateItemID");
                        str = new string[] { this.OrderID.ToString(), "μ", this.hdnEstId.Value.ToString(), "μ", dataRow4["estimateitemid"].ToString(), "μ", dataRow4["estimateitemid"].ToString(), "μu" };
                        hiddenField2.Value = string.Concat(str);
                        RadContextMenu radContextMenu1 = (RadContextMenu)usercontrolOrdersOrderSummaryAction1.FindControl("rcm_ItemOrder");
                        if (this.Module.ToLower() == "webstoreorder")
                        {
                            if (count2 > 0)
                            {
                                radContextMenu1.Items[1].Visible = true;
                            }
                            if (!this.IsShowJobReRun)
                            {
                                this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction1);
                            }
                        }
                        else if (this.Module.ToLower() != "job")
                        {
                            if (count2 > 0)
                            {
                                radContextMenu1.Items[1].Visible = true;
                            }
                            this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction1);
                        }
                        else
                        {
                            if (count2 > 0)
                            {
                                radContextMenu1.Items[1].Visible = true;
                            }
                            if (this.IsShowInvRerun)
                            {
                                radContextMenu1.Items[0].Visible = false;
                                radContextMenu1.Items[1].Visible = false;
                            }
                            this.plhOrderItems.Controls.Add(usercontrolOrdersOrderSummaryAction1);
                        }
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both'/>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='bglabel' style='width:200px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Item_Title")));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='box'align='left'>"));
                        ControlCollection controlCollections4 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { " <label id='lblItemTitle_", dataRow4["estimateitemid"], "' value='", empty, "' >", empty, "</label>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both'/>"));
                        DataTable dataTable4 = EstimatesBasePage.estimate_othercost_item_select(this.CompanyID, Convert.ToInt64(dataRow4["estimateitemid"]));
                        DataRow[] dataRowArray = dataTable4.Select("typeid=0");
                        decimal num21 = new decimal(0);
                        decimal num22 = new decimal(0);
                        decimal num23 = new decimal(0);
                        decimal num24 = new decimal(0);
                        decimal num25 = new decimal(0);
                        decimal num26 = new decimal(0);
                        decimal num27 = new decimal(0);
                        DataRow[] dataRowArray1 = dataRowArray;
                        for (int j = 0; j < (int)dataRowArray1.Length; j++)
                        {
                            DataRow dataRow5 = dataRowArray1[j];
                            Convert.ToInt64(dataRow5["EstOtherCostID"]);
                            long num28 = Convert.ToInt64(dataRow5["TypeID"]);
                            dataRow5["ItemTitle"].ToString();
                            string str8 = dataRow5["OthercostName"].ToString();
                            Convert.ToInt64(dataRow5["OtherCostID"]);
                            string str9 = "";
                            decimal num29 = new decimal(0);
                            decimal num30 = new decimal(0);
                            estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=othercost&EstimateItemID=", Convert.ToInt64(dataRow5["EstimateItemID"]), "&TypeID=", num28, "&EstType=U&EstOtherCostID=", dataRow5["EstOthercostID"].ToString(), "&From=U&module=", this.Module, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str8, "</a>" };
                            str9 = string.Concat(estimateItemID);
                            int num31 = Convert.ToInt16(dataRow5["SetupTime"]);
                            decimal num32 = Convert.ToDecimal(dataRow5["HourlyRate"]);
                            decimal num33 = (num31 * num32) / new decimal(60);
                            decimal num34 = Convert.ToDecimal(dataRow5["Cost"]) - num33;
                            decimal num35 = Convert.ToDecimal(dataRow5["Markup"]);
                            decimal num36 = Convert.ToDecimal(dataRow5["MinimumCost"]);
                            decimal num37 = new decimal(0);
                            decimal num38 = new decimal(0);
                            num37 = num34;
                            decimal num39 = (num34 * num35) / new decimal(100);
                            num38 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num37, num35, num36, out num29, out num30, ref num33);
                            num33 = (num31 * num32) / new decimal(60);
                            if (num28 == (long)0)
                            {
                                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:5px'></div>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItem' cellpadding='0' cellspacing='0' border='0'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<td id='tdlbl'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", this.objBase.SpecialDecode(str9), "</div>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' id='tdPrice1' style='text-align: right; width:125px;'>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num38, 0, "", false, false, true, false, true), true), "</span>")));
                                this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                                this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                            }
                        }
                        DataTable dataTable5 = EstimatesBasePage.estimate_item_total_price_details_select(this.CompanyID, Convert.ToInt64(dataRow4["estimateitemid"]), "U");
                        foreach (DataRow row5 in dataTable5.Rows)
                        {
                            num21 = Convert.ToDecimal(row5["TotalCostExMarkup1"]);
                            num22 = Convert.ToDecimal(row5["TotalCostInMarkup1"]);
                            num23 = Convert.ToDecimal(row5["TotalMarkupPrice1"]);
                            num24 = Convert.ToDecimal(row5["TotalTaxPrice1"]);
                            num25 = Convert.ToDecimal(row5["TotalSellingPrice1"]) - Convert.ToDecimal(row5["TotalProfitMarginPrice1"]);
                            if (Convert.ToDecimal(row5["TotalCostInMarkup1"]) > new decimal(0))
                            {
                                num26 = (Convert.ToDecimal(row5["TotalMarkupPrice1"]) / Convert.ToDecimal(row5["TotalCostInMarkup1"])) * new decimal(100);
                            }
                            num27 = Convert.ToDecimal(row5["TotalMarkupPrice1"]);
                            order_summary usercontrolOrdersOrderSummary = this;
                            usercontrolOrdersOrderSummary.AllItem_SellingPrice = usercontrolOrdersOrderSummary.AllItem_SellingPrice + num25;
                            order_summary allItemOrderItemTax1 = this;
                            allItemOrderItemTax1.AllItem_OrderItemTax = allItemOrderItemTax1.AllItem_OrderItemTax + num24;
                            order_summary allItemGrossProfitDollar1 = this;
                            allItemGrossProfitDollar1.AllItem_GrossProfitDollar = allItemGrossProfitDollar1.AllItem_GrossProfitDollar + num27;
                            order_summary allItemTotalPriceIncMarkup1 = this;
                            allItemTotalPriceIncMarkup1.AllItem_TotalPriceIncMarkup = allItemTotalPriceIncMarkup1.AllItem_TotalPriceIncMarkup + num22;
                            num16 = num16 + num22;
                            num17 = num17 + num27;
                            num18 = Convert.ToInt32(row5["TotalTaxID1"]);
                            num19 = Convert.ToDecimal(row5["TotalTaxPercentage1"]);
                            num20 = Convert.ToInt64(row5["estTotalID"]);
                        }
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:5px'></div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemprice' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trqty'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td id='tdlbl'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", dataRow4["TotalQty1"], "</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td id='tdlbl'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Cost_Price_Ex_Markup"), "</div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num21, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td id='tdlbl'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Markup"), "</div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num23, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Cost_Price_Inc_Markup"), "</div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span CsClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num22, 0, "", false, false, true, false, true), true), "</span>")));
                        ControlCollection controls5 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_costInMarkup_", dataRow4["estimateitemid"], "_", num6, "' value='", num22, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Tax"))));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float: right;'>"));
                        estimateItemID = new object[] { "onchange=javascript:Tax_OnChange_forOtherCost(this.value,1,", dataRow4["estimateitemid"], ",", num6, ",", this.UserID, ");" };
                        string str10 = string.Concat(estimateItemID);
                        if (this.activityhist.ToLower() != "yes")
                        {
                            ControlCollection controlCollections5 = this.plhOrderItems.Controls;
                            estimateItemID = new object[] { "<select id='ddlTax_", dataRow4["estimateitemid"], "_", num6, "' class='normaltext' ", str10, " style='width:55px;'>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            ControlCollection controls6 = this.plhOrderItems.Controls;
                            estimateItemID = new object[] { "<select id='ddlTax_", dataRow4["estimateitemid"], "_", num6, "' class='normaltext' ", str10, " style='width:55px;' disabled='disabled'>" };
                            controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        this.plhOrderItems.Controls.Add(new LiteralControl(this.Load_Tax_Values(num18, this.CompanyID, num19) ?? ""));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </select>"));
                        ControlCollection controlCollections6 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxID_", dataRow4["estimateitemid"], "_", num6, "' value='", num18, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls7 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPercentage_", dataRow4["estimateitemid"], "_", num6, "' value='", num19, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div></div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        ControlCollection controlCollections7 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<span id='spnTaxPrice_", dataRow4["estimateitemid"], "_", num6, "' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num24, 0, "", false, false, true, false, true), true), "</span>" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls8 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPrice_", dataRow4["estimateitemid"], "_", num6, "' value='", num24, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'><b>", order_summary.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</b></div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        ControlCollection controlCollections8 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<span id='spnSellingPrice_", dataRow4["estimateitemid"], "_", num6, "' CssClass='normalText'><b>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num25, 0, "", false, false, true, false, true), true), "</b></span>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls9 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPrice_", dataRow4["estimateitemid"], "_", num6, "' value='", num25, "' />" };
                        controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width:200px; clear: both'>", order_summary.objLanguage.GetLanguageConversion("Gross_Profit"), "</div>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td align='left' valign='top' style='border:0px solid green;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num27, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<tr style='text-align:right;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' id='tdPrice1' style='text-align: right; width:125px;'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num26, 0, "", false, false, true, false, true), "%</span>")));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        if (this.IsAccountingCode)
                        {
                            this.IsAcountingCode(this.CompanyID, Convert.ToInt64(dataRow4["estimateitemid"]), "u", Convert.ToInt64(this.hdnEstId.Value));
                        }
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='float:right;padding-right:20px'>"));
                        estimateItemID = new object[] { "onclick=javascript:call_SaveAndStay(this,'", num20, "','", dataRow4["estimateitemid"], "','", num6, "');" };
                        string str11 = string.Concat(estimateItemID);
                        this.plhOrderItems.Controls.Add(new LiteralControl("<table><tr><td style='padding-right:10px'>"));
                        ControlCollection controlCollections9 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='button' class='button' id='btn_SaveStay_", dataRow4["estimateitemid"], "_", num6, "' ", str11, " value='", order_summary.objLanguage.GetLanguageConversion("Save_Stay"), "' />" };
                        controlCollections9.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls10 = this.plhOrderItems.Controls;
                        estimateItemID = new object[] { "<input type='button' class='button' id='btn_Save_", dataRow4["estimateitemid"], "_", num6, "' ", str11, " value='", order_summary.objLanguage.GetLanguageConversion("Save"), "' />" };
                        controls10.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<td valign='top' class='shadow_right'  style='width:40%;padding-top:5px; border:0px solid red;' >"));
                        EstimateCommonMethods.ShowDescriptionOnSummary(this.Pgtype, this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), Convert.ToInt64(dataRow4["estimateitemid"]), this.plhOrderItems, empty, this.activityhist);
                        this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div style='clear:both:margin-top:5px;padding-top:5px'>"));
                        this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                        num6++;
                        order_summary usercontrolOrdersOrderSummary1 = this;
                        usercontrolOrdersOrderSummary1.EstitemIDs = string.Concat(usercontrolOrdersOrderSummary1.EstitemIDs, dataRow4["estimateitemid"], "±");
                    }
                    this.hid_OCestItemIDs.Value = this.EstitemIDs;
                }
                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='width:100%; margin-top:5px;'>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<h3><a style='border-bottom-width:0px' href='#'>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<td width='54%'>"));
                ControlCollection controlCollections10 = this.plhOrderItems.Controls;
                str = new string[] { "&nbsp;&nbsp;<span class='HeaderText' >&nbsp;&nbsp; ", order_summary.objLanguage.GetLanguageConversion("All_Items"), " &nbsp;", order_summary.objLanguage.GetLanguageConversion("Details"), "</span>" };
                controlCollections10.Add(new LiteralControl(string.Concat(str)));
                this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<td width='38%' >"));
                ControlCollection controls11 = this.plhOrderItems.Controls;
                str = new string[] { "<span class='HeaderText'>", order_summary.objLanguage.GetLanguageConversion("Total_Selling_Price_Inc_Tax"), "&nbsp;", this.commclass.GetCurrencyinRequiredFormate("", true), "</span>&nbsp; <span id='TabSellingPrice'  class='HeaderText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AllItem_SellingPrice, 0, "", false, false, true), " </span>" };
                controls11.Add(new LiteralControl(string.Concat(str)));
                this.HdnTab_SellingPrice.Value = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.AllItem_SellingPrice), 0, "", false, false, true);
                this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</a></h3>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<div style='padding:0px 0px 10px 10px;margin:0px 0px 0px 0px;'>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<div  id='Div_AdditionalCartContent' width='60%' style='display:block;  margin:0px 0px 0px 0px; '>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0px' width='60%'>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<tr>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<td>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("<div class='header' style='padding: 0px 2px 6px 2px; width: 100%;'>"));
                this.plhOrderItems.Controls.Add(new LiteralControl(string.Concat("<span class='HeaderText' id='spnAllItems' style='color:#751717'>", order_summary.objLanguage.GetLanguageConversion("All_Items"), "</span>")));
                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                int num40 = 0;
                int num41 = 0;
                decimal num42 = new decimal(0);
                decimal num43 = new decimal(0);
                decimal num44 = new decimal(0);
                decimal num45 = new decimal(0);
                string str12 = "";
                bool flag1 = true;
                StringBuilder stringBuilder15 = new StringBuilder();
                StringBuilder stringBuilder16 = new StringBuilder();
                StringBuilder stringBuilder17 = new StringBuilder();
                StringBuilder stringBuilder18 = new StringBuilder();
                StringBuilder stringBuilder19 = new StringBuilder();
                StringBuilder stringBuilder20 = new StringBuilder();
                DataTable dataTable6 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.OrderID);
                HiddenField hidMultipleLenght = this.hid_MultipleLenght;
                count = dataTable6.Rows.Count;
                hidMultipleLenght.Value = count.ToString();
                if (this.hid_MultipleLenght.Value == "0")
                {
                    if (this.AllItem_TotalPriceIncMarkup != new decimal(0))
                    {
                        this.AllItem_GrossProfitMargin = (this.AllItem_GrossProfitDollar / this.AllItem_TotalPriceIncMarkup) * new decimal(100);
                    }
                    this.summry.PBReadTopString(stringBuilder15, order_summary.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                    stringBuilder15.Append("<td align='right' width='24%'>");
                    stringBuilder15.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AllItem_OrderItemTax, 0, "", false, false, true), "</Label>"));
                    stringBuilder15.Append("</td>");
                    this.summry.EmptyRowCreation(stringBuilder15);
                    this.summry.EndTableCreation(stringBuilder15);
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder15.ToString()));
                    this.summry.PBReadTopString(stringBuilder19, string.Concat("<b>", order_summary.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</b>"), "div_SellingPriceEncTax");
                    stringBuilder19.Append("<td align='right' width='24%'>");
                    stringBuilder19.Append(string.Concat("<Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AllItem_SellingPrice, 0, "", false, false, true), "</Label>"));
                    stringBuilder19.Append("</td>");
                    this.summry.EmptyRowCreation(stringBuilder19);
                    this.summry.EndTableCreation(stringBuilder19);
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder19.ToString()));
                    this.summry.PBReadTopString(stringBuilder17, order_summary.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                    stringBuilder17.Append("<td align='right' width='24%'>");
                    str = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AllItem_GrossProfitDollar, 0, "", false, false, true), "<div style='padding-top:3px'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AllItem_GrossProfitMargin, 0, "", false, false, true), "%</div></LABEL>" };
                    stringBuilder17.Append(string.Concat(str));
                    stringBuilder17.Append("</td>");
                    this.summry.EmptyRowCreation(stringBuilder17);
                    this.summry.EndTableCreation(stringBuilder17);
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder17.ToString()));
                }
                foreach (DataRow row6 in dataTable6.Rows)
                {
                    if (num40 == 0)
                    {
                        this.summry.PBReadTopString(stringBuilder19, order_summary.objLanguage.GetLanguageConversion("Selling_Price_Ex_Tax"), "div_SellingPriceEncTax");
                        stringBuilder19.Append("<td align='right' width='24%'>");
                        stringBuilder19.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["PriceExcTax"]), 0, "", false, false, true), "</Label>"));
                        stringBuilder19.Append("</td>");
                        this.summry.EmptyRowCreation(stringBuilder19);
                        this.summry.EndTableCreation(stringBuilder19);
                        this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder19.ToString()));
                        if (flag1)
                        {
                            stringBuilder20.Append("<div style='border:0px solid red;'>");
                            if (base.Request.Url.AbsoluteUri.Contains("pagename=estore") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                            {
                                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                }
                                else
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                }
                            }
                            else if (base.Request.Url.AbsoluteUri.Contains("pagename=job") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                            {
                                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                }
                                else
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                }
                            }
                            else if (base.Request.Url.AbsoluteUri.Contains("pagename=inv") && base.Request.Url.AbsoluteUri.Contains("FromeStore=yes"))
                            {
                                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px; display:none;'></div></div>"));
                                }
                                else
                                {
                                    stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                                }
                            }
                            else if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                            {
                                stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'><input type='image' id='img_CartAdditional' title='Click to edit cart additional option' src='../images/plus.gif' onclick='javascript:return ShowCartAdditional();' style='border-width:0px;display:block;'></div></div>"));
                            }
                            else
                            {
                                stringBuilder20.Append(string.Concat(" <div class='bglabel' style='float:left;width:200px;'><div style='float: left'>", order_summary.objLanguage.GetLanguageConversion("Edit_Cart_Additional_Option"), "</div><div style='float: right; cursor:pointer;'></div></div>"));
                            }
                            stringBuilder20.Append("</div>");
                            this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                            flag1 = false;
                        }
                    }
                    decimal num46 = new decimal(0);
                    decimal num47 = new decimal(0);
                    string empty9 = string.Empty;
                    int num48 = 0;
                    int length = 0;
                    if (num41 < Convert.ToInt32(this.hid_MultipleLenght.Value))
                    {
                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                        DataTable dataTable7 = OrderBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, (long)order_summary.AccountID, "no");
                        foreach (DataRow dataRow6 in dataTable7.Rows)
                        {
                            long num49 = Convert.ToInt64(dataRow6["WebOtherCostID"].ToString());
                            DataSet dataSet1 = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(num49);
                            DataTable item2 = dataSet1.Tables[0];
                            DataTable item3 = dataSet1.Tables[1];
                            int count3 = item3.Rows.Count;
                            num48++;
                            string empty10 = string.Empty;
                            foreach (DataRow row7 in item2.Rows)
                            {
                                this.MainCalculationtype = row7["MainCalculationType"].ToString();
                                this.HelpText = row7["Description"].ToString().Replace("\n", "<br>");
                                this.OtherCostName = row7["UserFriendlyName"].ToString();
                                try
                                {
                                    this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                                }
                                catch
                                {
                                }
                            }
                            int num50 = 0;
                            foreach (DataRow dataRow7 in item3.Rows)
                            {
                                if (this.MainCalculationtype.ToLower() == "c" && num50 == 0)
                                {
                                    foreach (DataRow row8 in dataTable6.Rows)
                                    {
                                        if (Convert.ToInt32(row8["OptionID"]) != Convert.ToInt32(dataRow6["WebOtherCostID"].ToString()))
                                        {
                                            continue;
                                        }
                                        this.OptionID = (long)Convert.ToInt32(row8["OptionID"]);
                                        this.SelectedID = Convert.ToInt32(row8["SelectedID"]);
                                        num46 = Convert.ToDecimal(row8["MarkupValue"]);
                                        this.Markup = Convert.ToDecimal(row8["Markup"]);
                                        num47 = Convert.ToDecimal(row8["TotalPrice"]);
                                        row8["SelectedValue"].ToString();
                                        Convert.ToDecimal(row8["SelectedPrice"]);
                                        this.Markup = Convert.ToDecimal(row8["Markup"]);
                                        this.hid_TotalExTax.Value = Convert.ToString(Convert.ToDecimal(row6["PriceExcTax"]));
                                        this.hid_TotalIncTax.Value = Convert.ToString(Convert.ToDecimal(this.SellingPrice));
                                        order_summary usercontrolOrdersOrderSummary2 = this;
                                        usercontrolOrdersOrderSummary2.Selected_Value = string.Concat(usercontrolOrdersOrderSummary2.Selected_Value, this.SelectedID, "±");
                                        base.Session["Markup"] = row8["Markup"];
                                        base.Session["TotalExTax"] = row8["PriceExcTax"];
                                        base.Session["TotalIncTax"] = this.SellingPrice;
                                        order_summary totalCartAdditionPrice = this;
                                        totalCartAdditionPrice.TotalCartAddition_price = totalCartAdditionPrice.TotalCartAddition_price + Convert.ToDecimal(row8["TotalPrice"]);
                                    }
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div class='price_table_content' style='width:50%;float:right; display:none;' >"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                                    if (this.OptionID != (long)Convert.ToInt32(dataRow6["WebOtherCostID"].ToString()))
                                    {
                                        ControlCollection controlCollections11 = this.plhOrderItems.Controls;
                                        estimateItemID = new object[] { "<input id='chkMultiple_", num41, "' style='display:none;' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Cart_Onchange_MultipleChoice(", num41, ");'/>" };
                                        controlCollections11.Add(new LiteralControl(string.Concat(estimateItemID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls12 = this.plhOrderItems.Controls;
                                        estimateItemID = new object[] { "<input id='chkMultiple_", num41, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num41, ");'/>" };
                                        controls12.Add(new LiteralControl(string.Concat(estimateItemID)));
                                    }
                                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    this.plhOrderItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle'>"));
                                    if (num41 == 0)
                                    {
                                        num42 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num47, 0, "", false, false, true));
                                    }
                                    if (num41 == 1)
                                    {
                                        num43 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num47, 0, "", false, false, true));
                                    }
                                    if (num41 == 2)
                                    {
                                        num44 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num47, 0, "", false, false, true));
                                    }
                                    if (num41 == 3)
                                    {
                                        num45 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num47, 0, "", false, false, true));
                                    }
                                    estimateItemID = new object[] { num42, "~", num43, "~", num44, "~", num45 };
                                    str12 = Convert.ToString(string.Concat(estimateItemID));
                                    ControlCollection controlCollections12 = this.plhOrderItems.Controls;
                                    estimateItemID = new object[] { "<label id='lblMultipleID_", num41, "' style='display:none'>", dataRow6["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num41, "' style='display:none'></label><label id='lblMultipleMarkup_", num41, "' style='display:none'></label><label id='lblMultiplePrice_", num41, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num47, 0, "", false, false, true), "</label><label id='lblMultipleMarkupValue_", num41, "' style='display:none'>", num46, "</label><label id='lblMultipleSortOrderNo_", num41, "' style='display:none;'>", num48, "</label>" };
                                    controlCollections12.Add(new LiteralControl(string.Concat(estimateItemID)));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                    if (length <= 80)
                                    {
                                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right'>"));
                                    }
                                    else
                                    {
                                        this.plhOrderItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right'>"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList1 = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num41),
                                        CssClass = "dropDownMultiple250"
                                    };
                                    if (this.OptionID != (long)Convert.ToInt32(dataRow6["WebOtherCostID"].ToString()))
                                    {
                                        this.MultipleChoice_DropDownBind(item3, dropDownList1, this.plhOrderItems, dataRow7["CalculationType"].ToString(), "add", 0);
                                    }
                                    else
                                    {
                                        this.MultipleChoice_DropDownBind(item3, dropDownList1, this.plhOrderItems, dataRow7["CalculationType"].ToString(), "edit", this.SelectedID);
                                    }
                                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                                    num41++;
                                }
                                if (this.OptionID == (long)Convert.ToInt32(dataRow6["WebOtherCostID"].ToString()))
                                {
                                    this.Formula = Convert.ToString(dataRow7["FormulaNew"]);
                                    if (this.Formula.Contains("[$TotalEx.GST$]") || this.Formula.Contains("[$TotalQty$]") || this.Formula.Contains("[$TotalInc.GST$]") || this.Formula.Contains("[$TotalNo.ofCartItems$]"))
                                    {
                                        string formula = this.Formula;
                                        chrArray = new char[] { '~' };
                                        string[] strArrays1 = formula.Split(chrArray);
                                        int num51 = Convert.ToInt32(strArrays1[2]);
                                        Convert.ToInt32(dataRow7["SortOrder"]);
                                        this.SelectedID = this.SelectedID;
                                        if (num51 == this.SelectedID)
                                        {
                                            this.hdn_SelFormulaID.Value = Convert.ToString(num51);
                                            this.hdnDDLMultiple.Value = this.Formula;
                                            this.Estimate_Additional_Price();
                                        }
                                    }
                                }
                                num50++;
                            }
                        }
                    }
                    base.Session["SelectedValue"] = this.Selected_Value.ToString();
                    base.Session["Ordered_Quantity"] = this.TotalQntityToCart;
                    this.summry.PBReadTopString(stringBuilder18, row6["SelectedValue"].ToString() ?? "", string.Concat("div_OrderAdditionalOption_", num40));
                    stringBuilder18.Append("<td align='right' width='24%' style='border:0px solid red;'>");
                    chrArray = new char[] { '~' };
                    str12.Split(chrArray);
                    string str13 = row6["SelectedID"].ToString();
                    if (this.hdn_SelFormulaID.Value != str13)
                    {
                        estimateItemID = new object[] { " <Label id='lblMultiplePrice_", num40, "' style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["TotalPrice"]), 0, "", false, false, true), "</Label>" };
                        stringBuilder18.Append(string.Concat(estimateItemID));
                    }
                    else
                    {
                        estimateItemID = new object[] { " <Label id='lblMultiplePrice_", num40, "' style='text-align: right;width:100%;'  maxlength='50'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["TotalPrice"]), 0, "", false, false, true), "</Label>" };
                        stringBuilder18.Append(string.Concat(estimateItemID));
                    }
                    stringBuilder18.Append("</td>");
                    this.summry.EmptyRowCreation(stringBuilder18);
                    this.summry.EndTableCreation(stringBuilder18);
                    if (num40 == 0)
                    {
                        this.TotalTax = (Convert.ToDecimal(row6["OrderIncMarkup"]) * this.AddCartTax) / new decimal(100);
                        this.SellingPriceInTax = (this.TotalTax + Convert.ToDecimal(row6["OrderIncMarkup"])) + Convert.ToDecimal(row6["OthercostPrice"]);
                        this.HdnTab_SellingPrice.Value = Convert.ToString(this.SellingPriceInTax);
                        this.HdnTab_SellingPrice.Value = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.HdnTab_SellingPrice.Value), 0, "", false, false, true);
                        string empty11 = string.Empty;
                        if (this.objBase.ReturnRoles_Privileges_Others("showtax").ToLower() != "false")
                        {
                            this.summry.PBReadTopString(stringBuilder15, order_summary.objLanguage.GetLanguageConversion("Tax"), "div_OrderTotalTax");
                            stringBuilder15.Append("<td align='right' width='24%' style='border:0px solid green;'>");
                            stringBuilder15.Append(string.Concat(" <Label style='text-align: right;width:100%;'  maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalTax, 0, "", false, false, true), "</Label>"));
                            stringBuilder15.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder15);
                            this.summry.EndTableCreation(stringBuilder15);
                        }
                        string empty12 = string.Empty;
                        if (!(this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() == "false") && !this.Check_SpecialPrivilege)
                        {
                            this.summry.PBReadTopString(stringBuilder16, string.Concat("<b>", order_summary.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</b>"), "div_SellingPriceIncTax");
                            stringBuilder16.Append("<td align='right' width='24%' style='border:0px solid red;'>");
                            stringBuilder16.Append(string.Concat(" <Label style='text-align: right;width:100%;' maxlength='50'> ", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.HdnTab_SellingPrice.Value), 0, "", false, false, true), "</Label>"));
                            stringBuilder16.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder16);
                            this.summry.EndTableCreation(stringBuilder16);
                        }
                        decimal num52 = Convert.ToDecimal(row6["OrderTotalMarkupPrice"]);
                        num52 = num52 + num17;
                        decimal num53 = Convert.ToDecimal(row6["OrderIncMarkup"]) + num16;
                        decimal num54 = new decimal(0);
                        if (num53 != new decimal(0))
                        {
                            num54 = (num52 / num53) * new decimal(100);
                        }
                        string empty13 = string.Empty;
                        empty13 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                        string empty14 = string.Empty;
                        empty14 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                        if ((!(empty13.ToLower() == "false") || !(empty14.ToLower() == "false")) && !this.Check_SpecialPrivilege)
                        {
                            string str14 = string.Empty;
                            string empty15 = string.Empty;
                            if (empty14.ToLower() != "false")
                            {
                                empty15 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                empty15 = "display:none;";
                            }
                            if (empty13.ToLower() != "false")
                            {
                                str14 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                str14 = "display:none;";
                            }
                            this.summry.PBReadTopString(stringBuilder17, order_summary.objLanguage.GetLanguageConversion("Gross_Profit"), "div_OrderGrossProft");
                            stringBuilder17.Append("<td align='right' width='24%'>");
                            str = new string[] { " <Label style='text-align: right;width:100%; border:0px solid green;'  maxlength='50'><div style='", empty15, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num52, 0, "", false, false, true), "</div><div style='padding-top:3px;", str14, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num54, 0, "", false, false, true), "%</div></LABEL>" };
                            stringBuilder17.Append(string.Concat(str));
                            stringBuilder17.Append("</td>");
                            this.summry.EmptyRowCreation(stringBuilder17);
                            this.summry.EndTableCreation(stringBuilder17);
                        }
                    }
                    num40++;
                }
                if (dataTable6.Rows.Count > 0)
                {
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder18.ToString()));
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder15.ToString()));
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder16.ToString()));
                    this.plhOrderItems.Controls.Add(new LiteralControl(stringBuilder17.ToString()));
                }
                this.plhOrderItems.Controls.Add(new LiteralControl("</td>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</tr>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</table>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
                this.plhOrderItems.Controls.Add(new LiteralControl("</div>"));
            }
            DataTable dataTable8 = OrderBasePage.jobOrder_select(this.CompanyID, this.OrderID, Convert.ToInt64(this.hdnEstId.Value));
            foreach (DataRow dataRow8 in dataTable8.Rows)
            {
                this.OrderItemIDs = dataRow8["OrderItemIDs"].ToString();
            }
            int num55 = 0;
            string orderItemIDs1 = this.OrderItemIDs;
            chrArray = new char[] { '±' };
            string[] strArrays2 = orderItemIDs1.Split(chrArray);
            for (int k = 0; k < (int)strArrays2.Length; k++)
            {
                if (strArrays2[k] != "")
                {
                    DataSet dataSet2 = OrderBasePage.Select_OrderItems_WithAdditionalItems(Convert.ToInt64(strArrays2[k]));
                    DataTable item4 = dataSet2.Tables[0];
                    DataTable item5 = dataSet2.Tables[1];
                    foreach (DataRow row9 in item4.Rows)
                    {
                        if (this.Module != "job")
                        {
                            continue;
                        }
                        this.EstimateItemID = Convert.ToInt64(row9["EstimateItemID"]);
                        Label label1 = new Label();
                        Label label2 = new Label();
                        Label label3 = new Label();
                        label1.Text = this.EstimateItemID.ToString();
                        label1.ID = string.Concat("PoEstItemID_", num55);
                        label1.Style.Add("display", "none");
                        label2.Text = "x";
                        label2.ID = string.Concat("PoEstType_", num55);
                        label2.Style.Add("display", "none");
                        label3.Text = strArrays2[k].ToString();
                        label3.ID = string.Concat("PoOrdItemID_", num55);
                        label3.Style.Add("display", "none");
                        string str15 = string.Empty;
                        CheckBox checkBox1 = new CheckBox();
                        estimateItemID = new object[] { "chkPo_", this.EstimateItemID, "_", num55 };
                        checkBox1.ID = string.Concat(estimateItemID);
                        checkBox1.Text = row9["JobName"].ToString();
                        DataTable dataTable9 = PurchaseBasePage.purchase_select_by_EstimateItemID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.EstimateItemID, "x", (long)0);
                        foreach (DataRow dataRow9 in dataTable9.Rows)
                        {
                            checkBox1.Enabled = false;
                            str15 = (str15 != "" ? string.Concat(str15, ", ", dataRow9["PONO"].ToString()) : string.Concat(str15, dataRow9["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(checkBox1);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str15.ToString(), "<br/>")));
                        this.plhpurchase.Controls.Add(label1);
                        this.plhpurchase.Controls.Add(label2);
                        this.plhpurchase.Controls.Add(label3);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        num55++;
                    }
                    if (this.Module == "job" && num55 != 0)
                    {
                        int num56 = 0;
                        for (int l = 0; l <= num55 - 1; l++)
                        {
                            Label label4 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", l));
                            Label label5 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", l));
                            PlaceHolder placeHolder = this.plhpurchase;
                            estimateItemID = new object[] { "chkPo_", label4.Text, "_", l };
                            if (((CheckBox)placeHolder.FindControl(string.Concat(estimateItemID))).Enabled)
                            {
                                num56++;
                            }
                        }
                        if (num56 != 0)
                        {
                            this.btnCreatePo.Enabled = true;
                            this.spnPOCreate.Style.Add("display", "block");
                            this.spnNoItemsTocreatePO.Style.Add("display", "none");
                            this.hidPoEnable.Value = "yes";
                        }
                        else
                        {
                            this.btnCreatePo.Enabled = false;
                            this.spnNoItemsTocreatePO.Style.Add("display", "block");
                            this.spnPOCreate.Style.Add("display", "none");
                            this.hidPoEnable.Value = "no";
                        }
                    }
                    this.hidPoCount.Value = num55.ToString();
                }
            }
            string value = this.hid_OCestItemIDs.Value;
            chrArray = new char[] { '±' };
            string[] strArrays3 = value.Split(chrArray);
            if ((int)strArrays3.Length > 0)
            {
                for (int m = 0; m < (int)strArrays3.Length; m++)
                {
                    if (strArrays3[m] != "")
                    {
                        if (this.Module == "job")
                        {
                            this.EstimateItemID = Convert.ToInt64(strArrays3[m].ToString());
                            Label label6 = new Label();
                            Label label7 = new Label();
                            Label label8 = new Label();
                            label6.Text = this.EstimateItemID.ToString();
                            label6.ID = string.Concat("PoEstItemID_", num55);
                            label6.Style.Add("display", "none");
                            label7.Text = "u";
                            label7.ID = string.Concat("PoEstType_", num55);
                            label7.Style.Add("display", "none");
                            label8.Text = strArrays3[m].ToString();
                            label8.ID = string.Concat("PoOrdItemID_", num55);
                            label8.Style.Add("display", "none");
                            string empty16 = string.Empty;
                            CheckBox checkBox2 = new CheckBox();
                            estimateItemID = new object[] { "chkPo_", this.EstimateItemID, "_", num55 };
                            checkBox2.ID = string.Concat(estimateItemID);
                            checkBox2.Text = string.Concat("Other Cost ", m, 1);
                            DataTable dataTable10 = PurchaseBasePage.purchase_select_by_EstimateItemID(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.EstimateItemID, "u", (long)0);
                            foreach (DataRow row10 in dataTable10.Rows)
                            {
                                checkBox2.Enabled = false;
                                empty16 = (empty16 != "" ? string.Concat(empty16, ", ", row10["PONO"].ToString()) : string.Concat(empty16, row10["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox2);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty16.ToString(), "<br/>")));
                            this.plhpurchase.Controls.Add(label6);
                            this.plhpurchase.Controls.Add(label7);
                            this.plhpurchase.Controls.Add(label8);
                            this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        }
                        num55++;
                        this.hidPoCount.Value = num55.ToString();
                    }
                }
                for (int n = 0; n < (int)strArrays3.Length; n++)
                {
                    if (this.Module == "job" && num55 != 0)
                    {
                        int num57 = 0;
                        for (int o = 0; o <= num55 - 1; o++)
                        {
                            Label label9 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", o));
                            Label label10 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", o));
                            PlaceHolder placeHolder1 = this.plhpurchase;
                            estimateItemID = new object[] { "chkPo_", label9.Text, "_", o };
                            if (((CheckBox)placeHolder1.FindControl(string.Concat(estimateItemID))).Enabled)
                            {
                                num57++;
                            }
                        }
                        if (num57 != 0)
                        {
                            this.btnCreatePo.Enabled = true;
                            this.spnPOCreate.Style.Add("display", "block");
                            this.spnNoItemsTocreatePO.Style.Add("display", "none");
                            this.hidPoEnable.Value = "yes";
                        }
                        else
                        {
                            this.btnCreatePo.Enabled = false;
                            this.spnNoItemsTocreatePO.Style.Add("display", "block");
                            this.spnPOCreate.Style.Add("display", "none");
                            this.hidPoEnable.Value = "no";
                        }
                    }
                }
            }
            DataTable dataTable11 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            order_summary.ManageStockPermission = Convert.ToInt32(dataTable11.Rows[0]["ProductStockManagement"]);
            this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            this.Check_SpecialPrivilege = false;
            this.Check_SpecialPrivilege = this.objBC.Check_SpecialPrivilege_For_User((long)this.UserID, (long)this.CompanyID);
            if (EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, Convert.ToInt64(this.hdnEstId.Value), this.Pgtype).Rows.Count > 0)
            {
                Item_Summary_PrintEmail_AllandSeletedItems usercontrolItemItemSummaryPrintEmailAllandSeletedItem = (Item_Summary_PrintEmail_AllandSeletedItems)base.LoadControl("~/usercontrol/Item/Item_Summary_PrintEmail_AllandSeletedItems.ascx");
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.ID = "PrintandEmail_All_SeletedItems";
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateID = Convert.ToInt64(this.hdnEstId.Value);
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.EstimateItemID = this.EstimateItemID;
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Module = "webstoreorder";
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.modulename = "webstoreorder";
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.submodulename = "webstoreorder";
                usercontrolItemItemSummaryPrintEmailAllandSeletedItem.MainType = "";
                this.Plh_PrintandEmail.Controls.Add(usercontrolItemItemSummaryPrintEmailAllandSeletedItem);
            }
            if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
            {
                this.div_costcentre.Style.Add("display", "block");
            }
            this.RadWindow1.Title = order_summary.objLanguage.GetLanguageConversion("Progress_To_Job");
            DataTable dataTable12 = EstimatesBasePage.estimate_RaisePoOrders_Selectitems(Convert.ToInt64(this.hdnEstId.Value));
            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            this.plhRaisePO.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:40%;' >"));
            this.plhRaisePO.Controls.Add(new LiteralControl(order_summary.objLanguage.GetLanguageConversion("Raise_Purchase_Order") ?? ""));
            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            this.plhRaisePO.Controls.Add(new LiteralControl("<div class='OrderRaisepoplcholder' >"));
            foreach (DataRow dataRow10 in dataTable12.Rows)
            {
                long num58 = Convert.ToInt64(dataRow10["EstimateItemID"]);
                this.plhRaisePO.Controls.Add(new LiteralControl(string.Concat("<div id='div_PO_", num58, "'>")));
                CheckBox checkBox3 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", num58),
                    Checked = this.IsDefaultPO,
                    Text = this.objBase.SpecialDecode(dataRow10["ItemTitleValue"].ToString())
                };
                this.plhRaisePO.Controls.Add(checkBox3);
                this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                this.hdnEstItems_All.Value = string.Concat(this.hdnEstItems_All.Value, num58, "§");
            }
            this.divPO_Style = "display: none;";
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='float: left; padding-bottom: 7px;'>"));
            RadioButton radioButton = new RadioButton()
            {
                ID = "RdoBtn_All",
                CausesValidation = false,
                Checked = true
            };
            radioButton.Attributes.Add("onclick", "javascript:ShowEstItemsList('all');");
            this.plhEstItemsList.Controls.Add(radioButton);
            this.plhEstItemsList.Controls.Add(new LiteralControl(string.Concat("</div><div style='padding-top: 2px;'><b>", order_summary.objLanguage.GetLanguageConversion("Progress_All_Items_to_Job"), "</b></div>")));
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='float: left; padding-bottom: 7px;'>"));
            RadioButton radioButton1 = new RadioButton()
            {
                ID = "RdoBtn_Selected",
                CausesValidation = false
            };
            radioButton1.Attributes.Add("onclick", "javascript:ShowEstItemsList('selected');");
            this.plhEstItemsList.Controls.Add(radioButton1);
            this.plhEstItemsList.Controls.Add(new LiteralControl(string.Concat("</div><div style='padding-top: 2px;'><b>", order_summary.objLanguage.GetLanguageConversion("Progress_Selected_Items_to_Job"), "</b></div>")));
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div id='divEstItemsList_Inner' style='overflow-y: auto; max-height: 130px; height: auto; display: none; padding-left: 20px;'>"));
            int num59 = 0;
            DataTable dataTable13 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);
            foreach (DataRow row11 in dataTable13.Rows)
            {
                long num60 = Convert.ToInt64(row11["EstimateItemID"]);
                string str16 = row11["EstimateType"].ToString();
                string str17 = row11["ItemTitle"].ToString();
                if (!base.IsPostBack && Convert.ToInt64(row11["JOBID"]) == (long)0)
                {
                    if (dataTable13.Rows.Count == 1)
                    {
                        HiddenField hiddenField3 = this.hdnEstItemsSelected;
                        estimateItemID = new object[] { this.hdnEstItemsSelected.Value, num60, "»", str16, "»", str17, "±" };
                        hiddenField3.Value = string.Concat(estimateItemID);
                    }
                    this.hdnEstItems.Value = string.Concat(this.hdnEstItems.Value, num60, "»");
                }
                if (Convert.ToInt64(row11["JOBID"]) == (long)0)
                {
                    ControlCollection controls13 = this.plhEstItemsList.Controls;
                    estimateItemID = new object[] { "<div style='padding: 0px 5px 6px 0px; float: left;'><input style='cursor: pointer;' type='checkbox' id='chkEstItems_", num60, "' title='", str17, "' checked='checked' value='", num60, "' /></div>" };
                    controls13.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhEstItemsList.Controls.Add(new LiteralControl(string.Concat("<div style='padding-top: 3px;'>", this.objBase.SpecialDecode(str17), "</div>")));
                    this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
                }
                if (Convert.ToInt64(row11["JOBID"]) != (long)0)
                {
                    continue;
                }
                num59++;
            }
            if (num59 > 0)
            {
                this.plhEstItemsList.Controls.Add(new LiteralControl("</div>"));
                this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='submit' id='btnEstItems_Next' value='Next' class='button' onclick='javascript:EstItemListNext();return false;'/></div>"));
                if (num59 == 1)
                {
                    this.divPO_Style = "";
                    this.divEstItemsList_Style = "display: none;";
                }
            }
        }

        public void Purchse_OrderInsert(int CompanyID, long EstimateID, long EstimateItemID, int QtyNumber, string ItemType, string JobNumber, long EstimateBookletItemID, string webothercostName, string PurchaseOrders, string ItemNumbers, string JobName, out string AllPurchaseOrders, out string AllItemNumbers)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Purchase Footer").Rows)
            {
                str = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Purchase Header").Rows)
            {
                empty = dataRow["PhraseText"].ToString();
            }
            foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                row1["PhraseText"].ToString();
            }
            string jobNumber = JobNumber;
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int jobStatusID = SettingsBasePage.get_jobStatus_ID(CompanyID, "Awaiting Authorization");
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            long num4 = (long)0;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            int num5 = 0;
            int num6 = 0;
            decimal num7 = new decimal(0);
            string pODN = string.Empty;
            long num8 = (long)0;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            empty2 = (this.lblComments.Text == "" ? "" : this.lblComments.Text.Replace("<br/>", "\n"));
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            decimal taxRate = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            DateTime dateTime = DateTime.Now.AddDays(5);
            string empty5 = string.Empty;
            int num9 = 0;
            if (string.Compare(ItemType.ToLower(), "x", true) == 0 || string.Compare(ItemType.ToLower(), "u", true) == 0)
            {
                pODN = this.commclass.ItemDescriptionToPO_DN(CompanyID, EstimateItemID, "Purchase", ref empty5);
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                {
                    long num10 = Convert.ToInt64(dataRow1["PriceCatalogueID"]);
                    int num11 = Convert.ToInt32(dataRow1["TotalTaxId"]);
                    decimal num12 = Convert.ToDecimal(dataRow1["TotalTaxRate"]);
                    num4 = (long)0;
                    empty3 = "A";
                    str3 = "";
                    long num13 = (long)0;
                    num5 = Convert.ToInt32(dataRow1["Quantity"]);
                    if (ItemType.ToLower() == "u")
                    {
                        num5 = 1;
                    }
                    num6 = Convert.ToInt32(dataRow1["Quantity"]);
                    num7 = Convert.ToDecimal(dataRow1["Price"]);
                    num8 = Convert.ToInt64(dataRow1["DeliveryAddress"].ToString());
                    empty4 = dataRow1["DeliveryAddressType"].ToString();
                    decimal num14 = new decimal(0);
                    num1 = Convert.ToInt32(dataRow1["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow1["SupplierContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow1["AddressID"].ToString());
                    str1 = dataRow1["AddressType"].ToString();
                    dateTime = Convert.ToDateTime(dataRow1["PoReqDate"]);
                    if (string.Compare(ItemType.ToLower(), "u", true) == 0)
                    {
                        num13 = Convert.ToInt64(dataRow1["estothercostid"]);
                    }
                    bool flag = Convert.ToBoolean(dataRow1["IsStockReplenish"]);
                    string str5 = dataRow1["ItemDescription"].ToString();
                    string empty6 = string.Empty;
                    string str6 = string.Empty;
                    char[] chrArray = new char[] { 'µ' };
                    string[] strArrays = str5.Split(chrArray);
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (i == 10 && strArrays[i] != "")
                        {
                            string str7 = strArrays[i];
                            chrArray = new char[] { '»' };
                            string[] strArrays1 = str7.Split(chrArray);
                            for (int j = 0; j < (int)strArrays1.Length; j++)
                            {
                                if (j == 2)
                                {
                                    strArrays1[2].ToString();
                                }
                            }
                        }
                    }
                    if (JobName == "")
                    {
                        string.Concat(SummaryClass.Split_ItemDescription(dataRow1["ItemDescription"].ToString()), webothercostName);
                    }
                    else
                    {
                        string[] jobName = new string[] { "Job Name: ", JobName, "\n", SummaryClass.Split_ItemDescription(dataRow1["ItemDescription"].ToString()), webothercostName };
                        string.Concat(jobName);
                    }
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.TodayDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num8, empty4, 0, (long)0, this.TodayDate, "");
                    num14 = (num7 * num12) / new decimal(100);
                    if (string.Compare(ItemType.ToLower(), "x", true) != 0)
                    {
                        num14 = (num7 * taxRate) / new decimal(100);
                        PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty3, str3, string.Concat(pODN, "\n", webothercostName), Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), taxID, Convert.ToDecimal(num14), num9, empty5, false, num13, ItemType, (long)0, this.UserID, this.TodayDate);
                    }
                    else
                    {
                        DataTable dataTable1 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num10);
                        if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                        {
                            PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty3, str3, string.Concat(pODN, "\n", webothercostName), Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num11, Convert.ToDecimal(num14), num9, empty5, false, EstimateItemID, ItemType, (long)0, this.UserID, this.TodayDate);
                        }
                        else if (dataTable1.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                        {
                            PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty3, str3, string.Concat(pODN, "\n", webothercostName), Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num11, Convert.ToDecimal(num14), num9, empty5, false, EstimateItemID, ItemType, (long)0, this.UserID, this.TodayDate);
                        }
                        else
                        {
                            bool flag1 = false;
                            if (flag.ToString().ToLower() == "true")
                            {
                                flag1 = (this.objBase.CheckforStockReplenished(EstimateItemID).ToLower() != "true" ? false : true);
                            }
                            if (dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                            {
                                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty3, str3, string.Concat(pODN, "\n", webothercostName), Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num11, Convert.ToDecimal(num14), num9, empty5, flag1, EstimateItemID, ItemType, (long)0, this.UserID, this.TodayDate);
                            }
                            else
                            {
                                foreach (DataRow row2 in PurchaseBasePage.Kit_Details(num10).Rows)
                                {
                                    int num15 = num5 * Convert.ToInt16(row2["Quantity"]);
                                    DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(row2["KitItemID"]));
                                    string str8 = dataTable2.Rows[0]["ItemCode"].ToString();
                                    string str9 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(row2["KitItemID"])).Replace("»", "\n");
                                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, Convert.ToInt64(row2["KitItemID"]), "W", str8, string.Concat(str9, "\n", webothercostName), Convert.ToDecimal(num15), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num11, Convert.ToDecimal(num14), num9, empty5, flag1, EstimateItemID, ItemType, (long)0, this.UserID, this.TodayDate);
                                }
                            }
                        }
                    }
                    foreach (DataRow dataRow2 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        str4 = dataRow2["PONO"].ToString();
                    }
                    this.objnotes.ModuleName = "purchase";
                    this.objnotes.Po_number = str4;
                    this.objnotes.Job_number = this.objBase.SpecialEncode(jobNumber);
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POCreatedFromJob);
                    this.objnotes.ModuleID = num;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.commclass;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    object[] purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    EstimateBasePage.Attachments_PO_DN_Copy(EstimateID, EstimateItemID, num, "Purchase");
                    string empty7 = string.Empty;
                    foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.Module).Rows)
                    {
                        empty7 = row3["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty7);
                }
            }
            AllPurchaseOrders = PurchaseOrders;
            AllItemNumbers = ItemNumbers;
        }

        private void rcm_ItemOrder_ItemClick(object sender, RadMenuEventArgs e)
        {
        }

        private void ShowButtonAction(object sender, EventArgs e)
        {
        }

        public string SplitFormula(string Formula)
        {
            if (Formula.Contains("*"))
            {
                string[] strArrays = Formula.Split(new char[] { '*' });
                decimal num = decimal.Parse(strArrays[0]);
                decimal num1 = decimal.Parse(strArrays[1]);
                Formula = Convert.ToString(num * num1);
            }
            else if (Formula.Contains("/"))
            {
                string[] strArrays1 = Formula.Split(new char[] { '/' });
                decimal num2 = decimal.Parse(strArrays1[0]);
                decimal num3 = decimal.Parse(strArrays1[1]);
                Formula = Convert.ToString(num2 / num3);
            }
            else if (Formula.Contains("+"))
            {
                string[] strArrays2 = Formula.Split(new char[] { '+' });
                decimal num4 = decimal.Parse(strArrays2[0]);
                decimal num5 = decimal.Parse(strArrays2[1]);
                Formula = Convert.ToString(num4 + num5);
            }
            else if (Formula.Contains("-"))
            {
                string[] strArrays3 = Formula.Split(new char[] { '-' });
                decimal num6 = decimal.Parse(strArrays3[0]);
                decimal num7 = decimal.Parse(strArrays3[1]);
                Formula = Convert.ToString(num6 - num7);
            }
            return Formula;
        }

        public void SplitFunc(string op, string[] NewResult)
        {
            if ((int)NewResult.Length == 1)
            {
                this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]));
            }
            if ((int)NewResult.Length == 2)
            {
                string empty = string.Empty;
                if (op == "*")
                {
                    if (NewResult[1].Contains("*") || NewResult[1].Contains("/") || NewResult[1].Contains("%") || NewResult[1].Contains("+") || NewResult[1].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[1]);
                        if ((int)this.FVsplit.Length == 2)
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) * Convert.ToDecimal(empty));
                        }
                    }
                    else if (NewResult[0].Contains("*") || NewResult[0].Contains("/") || NewResult[0].Contains("%") || NewResult[0].Contains("+") || NewResult[0].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[0]);
                        if (!(this.FVsplit[0] != "0") || (int)this.FVsplit.Length != 2)
                        {
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) * Convert.ToDecimal(NewResult[1]));
                        }
                        else
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[0], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(empty) * Convert.ToDecimal(NewResult[1]));
                        }
                    }
                    else
                    {
                        this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) * Convert.ToDecimal(NewResult[1]));
                    }
                }
                if (op == "/")
                {
                    if (NewResult[1].Contains("*") || NewResult[1].Contains("/") || NewResult[1].Contains("%") || NewResult[1].Contains("+") || NewResult[1].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[1]);
                        if ((int)this.FVsplit.Length == 2)
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) / Convert.ToDecimal(empty));
                        }
                    }
                    else if (NewResult[0].Contains("*") || NewResult[0].Contains("/") || NewResult[0].Contains("%") || NewResult[0].Contains("+") || NewResult[0].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[0]);
                        if (!(this.FVsplit[0] != "0") || (int)this.FVsplit.Length != 2)
                        {
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) / Convert.ToDecimal(NewResult[1]));
                        }
                        else
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[0], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(empty) / Convert.ToDecimal(NewResult[1]));
                        }
                    }
                    else
                    {
                        this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) / Convert.ToDecimal(NewResult[1]));
                    }
                }
                if (op == "%")
                {
                    if (NewResult[1].Contains("*") || NewResult[1].Contains("/") || NewResult[1].Contains("%") || NewResult[1].Contains("+") || NewResult[1].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[1]);
                        if ((int)this.FVsplit.Length == 2)
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) % Convert.ToDecimal(empty));
                        }
                    }
                    else if (NewResult[0].Contains("*") || NewResult[0].Contains("/") || NewResult[0].Contains("%") || NewResult[0].Contains("+") || NewResult[0].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[0]);
                        if (!(this.FVsplit[0] != "0") || (int)this.FVsplit.Length != 2)
                        {
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) % Convert.ToDecimal(NewResult[1]));
                        }
                        else
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[0], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(empty) % Convert.ToDecimal(NewResult[1]));
                        }
                    }
                    else
                    {
                        this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) % Convert.ToDecimal(NewResult[1]));
                    }
                }
                if (op == "+")
                {
                    if (NewResult[1].Contains("*") || NewResult[1].Contains("/") || NewResult[1].Contains("%") || NewResult[1].Contains("+") || NewResult[1].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[1]);
                        if ((int)this.FVsplit.Length == 2)
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) + Convert.ToDecimal(empty));
                        }
                    }
                    else if (NewResult[0].Contains("*") || NewResult[0].Contains("/") || NewResult[0].Contains("%") || NewResult[0].Contains("+") || NewResult[0].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[0]);
                        if (!(this.FVsplit[0] != "0") || (int)this.FVsplit.Length != 2)
                        {
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) + Convert.ToDecimal(NewResult[1]));
                        }
                        else
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[0], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(empty) + Convert.ToDecimal(NewResult[1]));
                        }
                    }
                    else
                    {
                        this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) + Convert.ToDecimal(NewResult[1]));
                    }
                }
                if (op == "-")
                {
                    if (NewResult[1].Contains("*") || NewResult[1].Contains("/") || NewResult[1].Contains("%") || NewResult[1].Contains("+") || NewResult[1].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[1]);
                        if ((int)this.FVsplit.Length == 2)
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[1], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) - Convert.ToDecimal(empty));
                        }
                    }
                    else if (NewResult[0].Contains("*") || NewResult[0].Contains("/") || NewResult[0].Contains("%") || NewResult[0].Contains("+") || NewResult[0].Contains("-"))
                    {
                        this.FVsplit = this.SubFuncSplit(NewResult[0]);
                        if (!(this.FVsplit[0] != "0") || (int)this.FVsplit.Length != 2)
                        {
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) - Convert.ToDecimal(NewResult[1]));
                        }
                        else
                        {
                            empty = this.Add2and3argumentsFunc(NewResult[0], this.FormulaVal, this.FVsplit[0], this.FVsplit[1]);
                            this.FormulaVal = Convert.ToString(Convert.ToDecimal(empty) - Convert.ToDecimal(NewResult[1]));
                        }
                    }
                    else
                    {
                        this.FormulaVal = Convert.ToString(Convert.ToDecimal(NewResult[0]) - Convert.ToDecimal(NewResult[1]));
                    }
                }
            }
            if ((int)NewResult.Length == 3)
            {
                if (op == "*")
                {
                    this.FormulaVal = Convert.ToString((Convert.ToDecimal(NewResult[0]) * Convert.ToDecimal(NewResult[1])) * Convert.ToDecimal(NewResult[2]));
                }
                if (op == "/")
                {
                    this.FormulaVal = Convert.ToString((Convert.ToDecimal(NewResult[0]) / Convert.ToDecimal(NewResult[1])) / Convert.ToDecimal(NewResult[2]));
                }
                if (op == "%")
                {
                    this.FormulaVal = Convert.ToString((Convert.ToDecimal(NewResult[0]) % Convert.ToDecimal(NewResult[1])) % Convert.ToDecimal(NewResult[2]));
                }
                if (op == "+")
                {
                    this.FormulaVal = Convert.ToString((Convert.ToDecimal(NewResult[0]) + Convert.ToDecimal(NewResult[1])) + Convert.ToDecimal(NewResult[2]));
                }
                if (op == "-")
                {
                    this.FormulaVal = Convert.ToString((Convert.ToDecimal(NewResult[0]) - Convert.ToDecimal(NewResult[1])) - Convert.ToDecimal(NewResult[2]));
                }
            }
        }

        public string[] SubFuncSplit(string Newresult)
        {
            string empty = string.Empty;
            if (Newresult.Contains("*") || Newresult.Contains("/") || Newresult.Contains("%") || Newresult.Contains("+") || Newresult.Contains("-"))
            {
                if (Newresult.Contains("*"))
                {
                    char[] chrArray = new char[] { '*' };
                    this.FVsplit = Newresult.Split(chrArray);
                }
                if (Newresult.Contains("/"))
                {
                    char[] chrArray1 = new char[] { '/' };
                    this.FVsplit = Newresult.Split(chrArray1);
                }
                if (Newresult.Contains("%"))
                {
                    char[] chrArray2 = new char[] { '%' };
                    this.FVsplit = Newresult.Split(chrArray2);
                }
                if (Newresult.Contains("+"))
                {
                    char[] chrArray3 = new char[] { '+' };
                    this.FVsplit = Newresult.Split(chrArray3);
                }
                if (Newresult.Contains("-"))
                {
                    char[] chrArray4 = new char[] { '-' };
                    this.FVsplit = Newresult.Split(chrArray4);
                }
            }
            else
            {
                empty = string.Concat(Newresult[0], "_0_0");
                char[] chrArray5 = new char[] { '\u005F' };
                this.FVsplit = empty.Split(chrArray5);
            }
            return this.FVsplit;
        }
    }
}
