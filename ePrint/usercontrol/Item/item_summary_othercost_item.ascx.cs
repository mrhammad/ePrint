using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_othercost_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhOtherCostItem;

        //protected HiddenField hdnOtherCostDetails;

        //protected HiddenField hdnestothercostid;

        //protected HiddenField hdnParentItemID;

        //protected HiddenField hdnEstimateItemID;

        //protected HiddenField hdnModule;

        //protected HiddenField hdnParentItemType;

        //protected HiddenField hid_PressID;

        //protected HiddenField hid_PaperID;

        //protected HiddenField hid_GuillotineID;

        //protected HiddenField hdnOtherCostValues;

        //protected HiddenField hdn_IsOthercostsavedFromPopUp;

        //protected HiddenField hdnEditOtherCostValues;

        //protected LinkButton lnkOtherCostFromSummary;

        //protected RadScriptBlock test;

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass commclass = new commonClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int QtyCount;

        public int ParentQtyCount;

        public int QtyNumber;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string EstType = string.Empty;

        public string ParentEstimateType = string.Empty;

        public string MainType = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public long TypeID;

        public long ParentEstimateItemID;

        public bool IsParentItem;

        public bool Check_SpecialPrivilege;

        public bool IsItemCopied;

        public string StrRedirctPath = string.Empty;

        private DataRow[] drOtherCostRows;

        public bool IsShowDelete;

        private long OtherCostID;

        private long EstOtherCostID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private decimal Zonemarkup;

        private commonClass objJava = new commonClass();

        private decimal finalsellingprice;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string IsFromActHist = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public string SalesPersonID = string.Empty;

        public static string IsEditOnlyHisRecords;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string serverName = ConnectionClass.ServerName;
        public int AccountID;
        public string PDFToURLPath = string.Empty;
        public string strSecuresitepath = global.SecureSitePath();
        public string PageType = string.Empty;
        public string ModuleType = string.Empty;
        public long ModuleID;

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

        static item_summary_othercost_item()
        {
            item_summary_othercost_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_othercost_item()
        {
        }

        private void btnCopyitem_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.IsItemCopied = this.SummaryClassObj.CopyItem(this.EstimateID, Convert.ToInt64(button.CommandName), button.CommandArgument, this.Module, "sss");
        }

        private void Call_Delete_Other_Variable()
        {
            EstimateBasePage.estimate_othercost_variableqty_delete(this.CompanyID, this.EstOtherCostID);
        }

        private void Est_OtherCost_Insert(long ItemID, string EstType, long EstimateItemID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string value = this.hdnEditOtherCostValues.Value;
            char[] chrArray = new char[] { 'µ' };
            string[] strArrays = value.Split(chrArray);
            foreach (DataRow row in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, EstimateItemID, "U").Rows)
            {
                empty = row["itemtitle"].ToString();
            }
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                long num = (long)0;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                decimal num1 = new decimal(0);
                string empty2 = string.Empty;
                string str2 = string.Empty;
                decimal num2 = new decimal(0);
                string empty3 = string.Empty;
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                int num16 = 0;
                decimal num17 = new decimal(0);
                decimal num18 = new decimal(0);
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                int num21 = 0;
                int num22 = 0;
                DateTime now = DateTime.Now;
                num21 = Convert.ToInt32(base.Session["UserID"].ToString());
                string str3 = string.Empty;
                string empty4 = string.Empty;
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                decimal num23 = new decimal(0);
                decimal num24 = new decimal(0);
                decimal num25 = new decimal(0);
                decimal num26 = new decimal(0);
                decimal num27 = new decimal(0);
                decimal num28 = new decimal(0);
                int num29 = 0;
                decimal num35 = new decimal(0);
                string str6 = strArrays[i];
                chrArray = new char[] { '±' };
                string[] strArrays1 = str6.Split(chrArray);
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string str7 = strArrays1[j];
                    chrArray = new char[] { '»' };
                    string[] strArrays2 = str7.Split(chrArray);
                    if (string.Compare(strArrays2[0], "EstOtherCostID", true) == 0)
                    {
                        if (strArrays2[0].ToString() == "0")
                        {
                            this.EstOtherCostID = (long)0;
                            num22 = 0;
                        }
                        else
                        {
                            this.EstOtherCostID = Convert.ToInt64(strArrays2[1].ToString());
                            num22 = Convert.ToInt32(base.Session["UserID"].ToString());
                        }
                    }
                    if (string.Compare(strArrays2[0], "OtherCostID", true) == 0)
                    {
                        num = Convert.ToInt64(strArrays2[1].ToString());
                    }
                    if (string.Compare(strArrays2[0], "OtherCostName", true) == 0)
                    {
                        strArrays2[1].ToString();
                    }
                    if (string.Compare(strArrays2[0], "CalculationType", true) == 0)
                    {
                        str1 = strArrays2[1].ToString();
                    }
                    if (string.Compare(strArrays2[0], "Minimum", true) == 0)
                    {
                        num1 = Convert.ToDecimal(strArrays2[1].ToString());
                    }
                    if (string.Compare(strArrays2[0], "Description", true) == 0)
                    {
                        empty2 = strArrays2[1].ToString();
                    }
                    if (str1 == "t" || str1 == "q")
                    {
                        if (string.Compare(strArrays2[0], "DefaultQtyType", true) == 0)
                        {
                            str2 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FixedQty", true) == 0)
                        {
                            num2 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "VariableQty", true) == 0)
                        {
                            empty3 = strArrays2[1].ToString();
                        }
                    }
                    if (str1 == "t")
                    {
                        if (string.Compare(strArrays2[0], "HourlyRate", true) == 0)
                        {
                            num3 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SetUpTime", true) == 0)
                        {
                            num4 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Hours", true) == 0)
                        {
                            num5 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Passes", true) == 0)
                        {
                            num6 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            num7 = Convert.ToDecimal(strArrays2[1].ToString());
                            num8 = Convert.ToDecimal(strArrays2[1].ToString());
                            num9 = Convert.ToDecimal(strArrays2[1].ToString());
                            num10 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "HourlyRunSpeed", true) == 0)
                        {
                            num11 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice", true) == 0)
                        {
                            num35 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            num17 = Convert.ToDecimal(strArrays2[1].ToString());

                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                    else if (str1 == "q")
                    {
                        if (string.Compare(strArrays2[0], "UnitRate", true) == 0)
                        {
                            num12 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate1", true) == 0)
                        {
                            num26 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate2", true) == 0)
                        {
                            num27 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate3", true) == 0)
                        {
                            num28 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity", true) == 0)
                        {
                            num5 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity1", true) == 0)
                        {
                            num23 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity2", true) == 0)
                        {
                            num24 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity3", true) == 0)
                        {
                            num25 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            num7 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup1", true) == 0)
                        {
                            num8 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup2", true) == 0)
                        {
                            num9 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup3", true) == 0)
                        {
                            num10 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "SetUpTime", true) == 0)
                        {
                            num4 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "HourlyRate", true) == 0)
                        {
                            num3 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            num17 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost1", true) == 0)
                        {
                            num18 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost2", true) == 0)
                        {
                            num19 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost3", true) == 0)
                        {
                            num20 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                    else if (str1 == "f" || str1 == "m")
                    {
                        if (string.Compare(strArrays2[0], "Formula", true) == 0)
                        {
                            str3 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag", true) == 0)
                        {
                            empty4 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag1", true) == 0)
                        {
                            str4 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag2", true) == 0)
                        {
                            empty5 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag3", true) == 0)
                        {
                            str5 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num7 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num8 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num9 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num10 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num17 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num18 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num19 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num20 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                    if (num6 != 1 && num6 != 0)
                        num17 = num35;
                }
                DataTable dataTable = new DataTable();
                if (string.Compare(EstType, "B", true) == 0)
                {
                    dataTable = EstimateBasePage.booklet_sectionID_select(this.CompanyID, ItemID);
                    int num30 = 0;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (num29 == num30)
                        {
                            Convert.ToInt64(dataRow["EstimateBookletitemID"]);
                        }
                        num30++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "N", true) == 0)
                {
                    dataTable = EstimatesBasePage.lithoncr_item_select_othercostasadditional(this.CompanyID, ItemID);
                    int num31 = 0;
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (num29 == num31)
                        {
                            Convert.ToInt64(row1["EstimateLithoNcritemID"]);
                        }
                        num31++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "K", true) == 0)
                {
                    dataTable = EstimatesBasePage.lithobooklet_item_select_othercostasadditional(this.CompanyID, ItemID);
                    int num32 = 0;
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        if (num29 == num32)
                        {
                            Convert.ToInt64(dataRow1["EstimateLithoBookletItemID"]);
                        }
                        num32++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "S", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Single_Item_Select_By_EstimateItemID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "P", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Summary_Pad_Item_By_EstimateItem_ID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "L", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Summary_Large_Item_By_EstimateItem_ID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "F", true) == 0)
                {
                    dataTable = EstimatesBasePage.litho_estimate_select(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "D", true) == 0)
                {
                    dataTable = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "O", true) == 0)
                {
                    dataTable = EstimateBasePage.Estimate_Summary_Outwork_Select_By_EstimateItemID(this.CompanyID, EstimateItemID);
                }
                try
                {
                    DataTable dataTable1 = EstimatesBasePage.estimate_othercost_ProfitTax_select(EstimateItemID, Convert.ToInt64(this.EstOtherCostID));
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        num13 = Convert.ToDecimal(row2["ProfitMargin"]);
                        num15 = Convert.ToDecimal(row2["Tax"]);
                        num16 = Convert.ToInt32(row2["TaxID"]);
                    }
                    long num33 = EstimateBasePage.estimate_othercost_insert(this.CompanyID, this.EstOtherCostID, EstType.ToUpper(), ItemID, EstimateItemID, num, str1, num5, num3, num12, num4, num11, num6, num17, num1, num7, this.Objclss.ReplaceSingleQuote(empty), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(empty2), num13, num14, num15, num21, num22, now, str, str3, empty4, ItemID, num29, num18, num19, num20, num8, num9, num10, str4, empty5, str5, num26, num27, num28, num23, num24, num25, num16, (long)0);
                    base.Session["Othercostdescription"] = this.Objclss.ReplaceSingleQuote(empty2);
                    if (EstType.ToUpper() == "C")
                    {
                        EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, EstimateItemID, EstType.ToUpper(), ItemID);
                    }
                    this.EstOtherCostID = (this.EstOtherCostID == (long)0 ? num33 : this.EstOtherCostID);
                    if (string.Compare(str1, "f", true) == 0 || string.Compare(str1, "m", true) == 0)
                    {
                        this.Insert_OtherVariableQty(EstType.ToUpper(), EstimateItemID, this.EstOtherCostID, str1, str2, num2, empty3, num3, num4, num12, num7, num11, num6, num5, str3, empty4, dataTable, num29, ItemID, str4, empty5, str5, num17, num18, num19, num20);
                    }
                    else
                    {
                        this.Insert_OtherVariableQty_new(EstType.ToUpper(), EstimateItemID, this.EstOtherCostID, str1, str2, num2, empty3, num3, num4, num12, num7, num11, num6, num5, str3, empty4, dataTable, num29, ItemID, num17, num18, num19, num20, num26, num27, num28, num8, num9, num10, num23, num24, num25);
                    }
                }
                catch (Exception exception)
                {
                }
            }
        }

        public void Insert_OtherVariableQty(string EstType, long EstimateItemID, long EstOtherCostID, string CalculationType, string DefaultQtyType, decimal FixedQty, string VariableQty, decimal HourlyRate, decimal SetUpTime, decimal UnitRate, decimal Markup, decimal HourlyRunSpeed, decimal Passes, decimal HoursOrQuantity, string Formula, string FormulaTag, DataTable dtSec, int SectionNo, long SectionID, string FormulaTag1, string FormulaTag2, string FormulaTag3, decimal Cost, decimal Cost1, decimal Cost2, decimal Cost3)
        {
            long num = (long)0;
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            str = (string.Compare(EstType, "B", true) == 0 || string.Compare(EstType, "N", true) == 0 || string.Compare(EstType, "K", true) == 0 ? EstimatesBasePage.estimates_quantity_select(this.CompanyID, this.EstBookletItemID, EstType) : EstimatesBasePage.estimates_quantity_select(this.CompanyID, EstimateItemID, EstType));
            char[] chrArray = new char[] { '#' };
            string[] strArrays = str.Split(chrArray);
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            long num1 = (long)0;
            int num2 = 0;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str2 = strArrays[i];
                chrArray = new char[] { '$' };
                string[] strArrays1 = str2.Split(chrArray);
                if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                {
                    num1 = Convert.ToInt64(strArrays1[0]);
                    num2 = Convert.ToInt32(strArrays1[2]);
                    long num3 = (long)0;
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    decimal num10 = new decimal(0);
                    decimal num11 = new decimal(0);
                    decimal num12 = new decimal(0);
                    long num13 = (long)0;
                    decimal num14 = new decimal(0);
                    decimal num15 = new decimal(0);
                    decimal num16 = new decimal(0);
                    decimal num17 = new decimal(0);
                    decimal num18 = new decimal(0);
                    decimal num19 = new decimal(0);
                    decimal num20 = new decimal(0);
                    decimal num21 = new decimal(0);
                    decimal num22 = new decimal(0);
                    decimal num23 = new decimal(0);
                    decimal num24 = new decimal(0);
                    string empty4 = string.Empty;
                    string str4 = string.Empty;
                    decimal num25 = new decimal(0);
                    decimal num26 = new decimal(0);
                    decimal num27 = new decimal(0);
                    decimal num28 = new decimal(0);
                    decimal num29 = new decimal(0);
                    decimal num30 = new decimal(0);
                    decimal num31 = new decimal(0);
                    decimal num32 = new decimal(0);
                    decimal num33 = new decimal(0);
                    decimal num34 = new decimal(0);
                    decimal num35 = new decimal(0);
                    decimal num36 = new decimal(0);
                    decimal num37 = new decimal(0);
                    decimal count = new decimal(0);
                    count = count + dtSec.Rows.Count;
                    decimal num38 = new decimal(0);
                    decimal num39 = new decimal(0);
                    decimal num40 = new decimal(0);
                    decimal num41 = new decimal(0);
                    decimal num42 = new decimal(0);
                    decimal num43 = new decimal(0);
                    decimal num44 = new decimal(0);
                    decimal num45 = new decimal(0);
                    decimal num46 = new decimal(0);
                    decimal num47 = new decimal(0);
                    decimal num48 = new decimal(0);
                    decimal num49 = new decimal(0);
                    decimal num50 = new decimal(0);
                    decimal num51 = new decimal(0);
                    decimal num52 = new decimal(0);
                    decimal num53 = new decimal(0);
                    decimal num54 = new decimal(0);
                    int num55 = 0;
                    bool flag = false;
                    foreach (DataRow row in dtSec.Rows)
                    {
                        if (EstType.ToLower() != "o")
                        {
                            if (string.Compare(EstType, "B", true) == 0)
                            {
                                this.EstBookletSectionID = Convert.ToInt64(row["EstimateBookletItemID"]);
                                num27 = Convert.ToDecimal(row["NoOfSignatures"]);
                                Convert.ToDecimal(row["PagesPerSignature"]);
                                num28 = Convert.ToDecimal(row["NoOfPagesInSection"]);
                                flag = (SectionID != Convert.ToInt64(row["EstimateBookletItemID"]) ? false : true);
                            }
                            else if (string.Compare(EstType, "K", true) != 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                this.EstBookletSectionID = Convert.ToInt64(row["EstimateLithoBookletItemID"]);
                                num27 = Convert.ToDecimal(row["NoOfSignatures"]);
                                Convert.ToDecimal(row["PagesPerSignature"]);
                                num28 = Convert.ToDecimal(row["NoOfPagesInSection"]);
                                flag = (SectionID != Convert.ToInt64(row["EstimateLithoBookletItemID"]) ? false : true);
                            }
                            if (string.Compare(EstType, "N", true) == 0)
                            {
                                num53 = Convert.ToDecimal(row["NcrPartsPerSet"]);
                                num54 = Convert.ToDecimal(row["NcrSetsPerPad"]);
                            }
                            num25 = Convert.ToDecimal(row["Setupspoilage"]);
                            num26 = Convert.ToDecimal(row["RunningSpoilage"]);
                            str3 = row["PressType"].ToString();
                            empty2 = row["Colour"].ToString();
                            empty3 = row["SideColor"].ToString();
                            num37 = num37 + num28;
                            if (flag)
                            {
                                foreach (DataRow dataRow in EstimatesBasePage.Estimate_Summary_Calculation_Select_By_EstimateItem_ID(this.CompanyID, EstimateItemID, this.EstBookletSectionID).Rows)
                                {
                                    num3 = Convert.ToInt64(dataRow["EstimateCalculationID"]);
                                    num4 = Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                                    num5 = Convert.ToDecimal(dataRow["PaperWeight"]);
                                    num6 = Convert.ToDecimal(dataRow["PaperMarkup"]);
                                    num7 = Convert.ToDecimal(dataRow["PressMarkUp"]);
                                    num8 = Convert.ToDecimal(dataRow["PressSetupCharge"]);
                                    num9 = Convert.ToDecimal(dataRow["PressMinimumRunningCharge"]);
                                    str3 = dataRow["PressType"].ToString();
                                    num10 = Convert.ToDecimal(dataRow["BlackChargeableRate"]);
                                    num11 = Convert.ToDecimal(dataRow["ColorChargeableRate"]);
                                    num12 = Convert.ToDecimal(dataRow["NoOfChargeableSheets"]);
                                    num13 = Convert.ToInt64(dataRow["SpeedWeightTableID"]);
                                    num14 = Convert.ToDecimal(dataRow["HourlyCharge"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourLow"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourMedium"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourHigh"]);
                                    num15 = Convert.ToDecimal(dataRow["GuillotineSetupCharge"]);
                                    num16 = Convert.ToDecimal(dataRow["GuillotineMinimumRunningCharge"]);
                                    num17 = Convert.ToDecimal(dataRow["GuillotineMarkUp"]);
                                    num18 = Convert.ToDecimal(dataRow["GuillotineCostPerCut"]);
                                    num19 = Convert.ToDecimal(dataRow["GuillotinePaperWeight1"]);
                                    num20 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat1"]);
                                    num21 = Convert.ToDecimal(dataRow["GuillotinePaperWeight2"]);
                                    num22 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat2"]);
                                    num23 = Convert.ToDecimal(dataRow["GuillotinePaperWeight3"]);
                                    num24 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat3"]);
                                    dataRow["OneSqCmInkCost"].ToString();
                                    Convert.ToDecimal(dataRow["InkMarkup"]);
                                }
                            }
                            decimal num56 = new decimal(0);
                            string str5 = "";
                            if (string.Compare(EstType, "B", true) == 0)
                            {
                                str5 = (string.Compare(row["BookletFormat"].ToString(), "Portrait", true) != 0 ? "L" : "P");
                                num29 = num27;
                                decimal num57 = new decimal(0);
                                num34 = EstimateBasePage.Booklet_Print_Sheet_Calculation(num2, num27, num25, num26, out num57);
                                num33 = num34 - num57;
                                num52 = num57;
                                num51 = num26;
                            }
                            else if (string.Compare(EstType, "K", true) == 0)
                            {
                                str5 = (string.Compare(row["BookletFormat"].ToString(), "Portrait", true) != 0 ? "L" : "P");
                                num29 = num27;
                                decimal num58 = new decimal(0);
                                num34 = EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(num2, num27, num25, num26, out num58);
                                num33 = num34 - num58;
                                num52 = num58;
                                num51 = num26;
                            }
                            else if (string.Compare(EstType, "N", true) != 0)
                            {
                                if (string.Compare(row["PrintLayout"].ToString(), "P", true) != 0)
                                {
                                    str5 = "L";
                                    num29 = Convert.ToInt32(row["LandscapeValue"]);
                                }
                                else
                                {
                                    str5 = "P";
                                    num29 = Convert.ToInt32(row["PortraitValue"]);
                                }
                                decimal num59 = new decimal(0);
                                num34 = EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num29, num25, num26, out num59);
                                num33 = num34 - num59;
                                num52 = num59;
                                num51 = num26;
                            }
                            else
                            {
                                if (string.Compare(row["PrintLayout"].ToString(), "P", true) != 0)
                                {
                                    str5 = "L";
                                    num29 = Convert.ToInt32(row["LandscapeValue"]);
                                }
                                else
                                {
                                    str5 = "P";
                                    num29 = Convert.ToInt32(row["PortraitValue"]);
                                }
                                decimal num60 = new decimal(0);
                                num34 = EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(num2, num54, num25, num26, out num60);
                                num33 = num34 - num60;
                                num52 = num60;
                                num51 = num26;
                            }
                            num35 = num35 + num33;
                            num36 = num36 + num34;
                            decimal num61 = num34;
                            if (flag)
                            {
                                num49 = num34 * num4;
                                num49 = this.ReturnExact2Decimal(num49);
                                num50 = num49 + ((num49 * num6) / new decimal(100));
                                num50 = this.ReturnExact2Decimal(num50);
                                num30 = num28;
                                num31 = num33;
                                num32 = num34;
                                if (string.Compare(str3, "C", true) == 0)
                                {
                                    num41 = EstimateBasePage.PressCostPerClick(num61, (empty2 == "color" ? num11 : num10), num12);
                                    num41 = this.ReturnExact2Decimal(num41);
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num62 = EstimateBasePage.PressCostPerClick(num61, (empty3 == "color" ? num11 : num10), num12);
                                        num41 = num41 + this.ReturnExact2Decimal(num62);
                                    }
                                }
                                else if (str3 == "S")
                                {
                                    decimal num63 = new decimal(0);
                                    num41 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num61, num5, num14, num13, empty2, num8, num9, num7, ref num63);
                                    num38 = num14;
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num64 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num61, num5, num14, num13, empty3, num8, num9, num7, ref num63);
                                        num41 = num41 + num64;
                                        num41 = this.ReturnExact2Decimal(num41);
                                    }
                                }
                                else if (str3 == "Z")
                                {
                                    decimal num65 = new decimal(0);
                                    decimal num66 = Convert.ToInt32(num34);
                                    if (!Convert.ToBoolean(row["CalculationType"]))
                                    {
                                        foreach (DataRow row1 in EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, num3, num66, empty2).Rows)
                                        {
                                            int num67 = Convert.ToInt32(row1["ChargeableSheets"]);
                                            decimal num68 = Convert.ToDecimal(row1["ChargeableRate"]);
                                            num65 = (num68 / num67) * num66;
                                        }
                                    }
                                    else
                                    {
                                        num65 = EstimatesBasePage.Click_Charge_Zone_Cost(this.CompanyID, num3, num66, empty2, ref this.Zonemarkup);
                                    }
                                    num41 = num65;
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num69 = new decimal(0);
                                        if (!Convert.ToBoolean(row["CalculationType"]))
                                        {
                                            foreach (DataRow dataRow1 in EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, num3, num66, empty3).Rows)
                                            {
                                                int num70 = Convert.ToInt32(dataRow1["ChargeableSheets"]);
                                                decimal num71 = Convert.ToDecimal(dataRow1["ChargeableRate"]);
                                                num69 = (num71 / num70) * num66;
                                            }
                                        }
                                        else
                                        {
                                            num69 = EstimatesBasePage.Click_Charge_Zone_Cost(this.CompanyID, num3, num66, empty3, ref this.Zonemarkup);
                                        }
                                        num41 = num41 + num69;
                                        num41 = this.ReturnExact2Decimal(num41);
                                    }
                                }
                                num41 = num41 + num8;
                                num41 = this.ReturnExact2Decimal(num41);
                                if (num9 > num41)
                                {
                                    num41 = num9;
                                }
                                num42 = num41 + ((num41 * num7) / new decimal(100));
                                num42 = this.ReturnExact2Decimal(num42);
                                num39 = num41;
                                num40 = num42;
                                if (num5 <= num19)
                                {
                                    num56 = num20;
                                }
                                else if (num5 <= num21)
                                {
                                    num56 = num22;
                                }
                                else if (num5 <= num23 || num5 > num23)
                                {
                                    num56 = num24;
                                }
                                if (Convert.ToBoolean(row["IsFirstTrim"]))
                                {
                                    decimal num72 = Convert.ToDecimal(row["Height"]);
                                    decimal num73 = Convert.ToDecimal(row["Width"]);
                                    decimal num74 = Convert.ToDecimal(row["SheetHeight"]);
                                    decimal num75 = Convert.ToDecimal(row["SheetWidth"]);
                                    decimal num76 = Convert.ToDecimal(row["BasisWeight"]);
                                    decimal num77 = new decimal(0);
                                    num43 = EstimateBasePage.Guillotine_First_Trim_Cut(num72, num73, num74, num75, num76, str5, num61, num19, num20, num21, num22, num23, num24, ref num77);
                                    num44 = num18 * num43;
                                    num44 = this.ReturnExact2Decimal(num44);
                                }
                                if (Convert.ToBoolean(row["IsSecondTrim"]))
                                {
                                    num45 = EstimateBasePage.Guillotine_Calculation(this.CompanyID, num61, num56, num29, num15, num16, num17, num18, Convert.ToBoolean(row["IsIncludeGutters"]), num2, ref num46, ref num47);
                                    num45 = this.ReturnExact2Decimal(num45);
                                }
                                if (Convert.ToBoolean(row["IsSecondTrim"]) || Convert.ToBoolean(row["IsFirstTrim"]))
                                {
                                    decimal num78 = (num44 + num45) + num15;
                                    num78 = this.ReturnExact2Decimal(num78);
                                    num48 = (num16 <= num78 ? num78 : num16);
                                    num48 = this.ReturnExact2Decimal(num48);
                                }
                            }
                        }
                        num55++;
                    }
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    string str6 = string.Empty;
                    string empty7 = string.Empty;
                    string str7 = string.Empty;
                    string empty8 = string.Empty;
                    string str8 = string.Empty;
                    if (FormulaTag != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays2 = FormulaTag.Split(chrArray);
                        empty6 = strArrays2[1].ToString();
                        str6 = strArrays2[1].ToString();
                        empty7 = strArrays2[0].ToString();
                        if (i == 0)
                        {
                            this.Question_Find_In_Formula(empty6, strArrays2[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag1 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays3 = FormulaTag1.Split(chrArray);
                        strArrays3[0] = (strArrays3[0].ToString() != "0" ? strArrays3[0].ToString() : empty7);
                        strArrays3[0].ToString();
                        if (i == 1)
                        {
                            this.Question_Find_In_Formula(strArrays3[1].ToString(), strArrays3[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag2 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays4 = FormulaTag2.Split(chrArray);
                        strArrays4[0] = (strArrays4[0].ToString() != "0" ? strArrays4[0].ToString() : empty7);
                        strArrays4[0].ToString();
                        if (i == 2)
                        {
                            this.Question_Find_In_Formula(strArrays4[1].ToString(), strArrays4[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag3 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays5 = FormulaTag3.Split(chrArray);
                        strArrays5[0] = (strArrays5[0].ToString() != "0" ? strArrays5[0].ToString() : empty7);
                        strArrays5[0].ToString();
                        if (i == 3)
                        {
                            this.Question_Find_In_Formula(strArrays5[1].ToString(), strArrays5[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    for (int j = 0; j < arrayLists.Count; j++)
                    {
                        try
                        {
                            empty6 = empty6.Replace(arrayLists[j].ToString(), arrayLists1[j].ToString());
                        }
                        catch (Exception exception)
                        {
                        }
                    }
                    foreach (DataRow row2 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                    {
                        empty5 = row2["Key"].ToString();
                        if (EstType != "B" && EstType != "K")
                        {
                            if (EstType == "P")
                            {
                                if (!(empty5.ToLower() == "number of leaves per pad") && empty5.ToLower() == "number of pads")
                                {
                                    empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                                }
                            }
                            else if (EstType == "N")
                            {
                                if (empty5.ToLower() == "parts per set")
                                {
                                    empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num53, 0, "", false, false, false));
                                }
                                else if (empty5.ToLower() == "sets per pad")
                                {
                                    empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num54, 0, "", false, false, false));
                                }
                            }
                        }
                        else if (empty5.ToLower() == "booklet quantity required")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "pages in this section only")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num30, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "number of sections")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, count, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "total number of pages (all sections)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num37, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity this section (excluding spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num31, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity this section (including spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num32, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity all sections (excluding spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num35, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity all sections (including spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num36, 0, "", false, false, false));
                        }
                        if (empty5.ToLower() == "guillotine bundles")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num46, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "guillotine cost per cut")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num18, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "number of cuts in first trim")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num43, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "number of cuts in second trim")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num47, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "press hourly charge")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num38, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "total press cost price")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num39, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "total press selling price")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num40, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity (excluding spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num31, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "print sheet quantity (including spoilage)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num32, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "finished job quantity")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "paper basis weight (gsm)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num5, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "paper cost (excluding markup)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num49, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() == "paper cost (including markup)")
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num50, 0, "", false, false, false));
                        }
                        else if (empty5.ToLower() != "spoilage percentage used")
                        {
                            empty6 = (empty5.ToLower() != "spoilage sheets used" ? empty6.Replace(empty5, "0") : empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Math.Ceiling(num52), 0, "", false, false, false)));
                        }
                        else
                        {
                            empty6 = empty6.Replace(empty5, this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num51, 0, "", false, false, false));
                        }
                    }
                    string str9 = empty6;
                    empty = empty6;
                    decimal num79 = (new MathParser()).Calculate(str9);
                    decimal num80 = Convert.ToDecimal(num79.ToString());
                    decimal cost = new decimal(0);
                    string empty9 = string.Empty;
                    if (i == 0)
                    {
                        if (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() != "yes")
                        {
                            cost = num80;
                            empty = empty6;
                        }
                        else
                        {
                            cost = Cost;
                            chrArray = new char[] { '\u00B6' };
                            empty = FormulaTag.Split(chrArray)[0].ToString();
                        }
                    }
                    else if (i == 1)
                    {
                        if (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() != "yes")
                        {
                            cost = num80;
                            empty = empty6;
                        }
                        else
                        {
                            cost = Cost1;
                            chrArray = new char[] { '\u00B6' };
                            empty = FormulaTag1.Split(chrArray)[0].ToString();
                        }
                    }
                    else if (i == 2)
                    {
                        if (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() != "yes")
                        {
                            cost = num80;
                            empty = empty6;
                        }
                        else
                        {
                            cost = Cost2;
                            chrArray = new char[] { '\u00B6' };
                            empty = FormulaTag2.Split(chrArray)[0].ToString();
                        }
                    }
                    else if (i == 3)
                    {
                        if (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() != "yes")
                        {
                            cost = num80;
                            empty = empty6;
                        }
                        else
                        {
                            cost = Cost3;
                            chrArray = new char[] { '\u00B6' };
                            empty = FormulaTag3.Split(chrArray)[0].ToString();
                        }
                    }
                    stringBuilder.Append(string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, cost, 0, "", false, false, false), "±"));
                    empty9 = string.Concat(empty, "¶", str6);
                    if (i == 0)
                    {
                        this.Call_Delete_Other_Variable();
                    }
                    EstimatesBasePage.estimate_othercost_variableqty_insert(this.CompanyID, num, EstOtherCostID, num1, new decimal(0), cost, EstType, empty, num2, i, empty9);
                    EstimatesBasePage.othercost_formula_tag_update(this.CompanyID, EstOtherCostID, EstimateItemID, "", (int)strArrays.Length);
                }
                else if (i == 0)
                {
                    this.Call_Delete_Other_Variable();
                }
                if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                {
                    EstimateBasePage.othercost_formula_value_update(this.CompanyID, EstimateItemID, stringBuilder.ToString());
                }
            }
        }

        public void Insert_OtherVariableQty_new(string EstType, long EstimateItemID, long EstOtherCostID, string CalculationType, string DefaultQtyType, decimal FixedQty, string VariableQty, decimal HourlyRate, decimal SetUpTime, decimal UnitRate, decimal Markup, decimal HourlyRunSpeed, decimal Passes, decimal HoursOrQuantity, string Formula, string FormulaTag, DataTable dtSec, int SectionNo, long SectionID, decimal Cost, decimal Cost1, decimal Cost2, decimal Cost3, decimal UnitRate1, decimal UnitRate2, decimal UnitRate3, decimal Markup1, decimal Markup2, decimal Markup3, decimal HoursOrQuantity1, decimal HoursOrQuantity2, decimal HoursOrQuantity3)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            long num = (long)0;
            long num1 = (long)0;
            string empty1 = string.Empty;
            empty1 = (string.Compare(EstType, "B", true) == 0 || string.Compare(EstType, "N", true) == 0 || string.Compare(EstType, "K", true) == 0 ? EstimatesBasePage.estimates_quantity_select(this.CompanyID, this.EstBookletItemID, EstType) : EstimatesBasePage.estimates_quantity_select(this.CompanyID, EstimateItemID, EstType));
            string[] strArrays = empty1.Split(new char[] { '#' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '$' });
                if (Convert.ToInt32((int)strArrays1.Length) > 0)
                {
                    int num2 = Convert.ToInt32(strArrays1[2]);
                    int num3 = Convert.ToInt32(strArrays1[2]);
                    if (CalculationType == "q")
                    {
                        if (i == 0)
                        {
                            num2 = (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() == "yes" ? Convert.ToInt32(HoursOrQuantity) : num2);
                        }
                        else if (i == 1)
                        {
                            num2 = (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() == "yes" ? Convert.ToInt32(HoursOrQuantity1) : num2);
                        }
                        else if (i == 2)
                        {
                            num2 = (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() == "yes" ? Convert.ToInt32(HoursOrQuantity2) : num2);
                        }
                        else if (i == 3)
                        {
                            num2 = (this.hdn_IsOthercostsavedFromPopUp.Value.ToLower() == "yes" ? Convert.ToInt32(HoursOrQuantity3) : num2);
                        }
                    }
                    if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                    {
                        num1 = Convert.ToInt64(strArrays1[0].ToString());
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        bool flag = false;
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        string str1 = string.Empty;
                        decimal num11 = new decimal(0);
                        decimal num12 = new decimal(0);
                        string empty2 = string.Empty;
                        long sectionID = (long)0;
                        decimal num13 = new decimal(0);
                        decimal num14 = new decimal(0);
                        decimal num15 = new decimal(0);
                        if (CalculationType == "t")
                        {
                            sectionID = SectionID;
                            DataTable dataTable = EstimatesBasePage.estimate_othercost_press_details_select((long)this.CompanyID, EstimateItemID, EstType, sectionID);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (EstType == "S" || EstType == "P" || EstType == "F" || EstType == "D" || EstType == "L")
                                {
                                    flag = (row["PrintLayout"].ToString() == "P" ? true : false);
                                    num9 = Convert.ToDecimal(row["PortraitValue"].ToString());
                                    num10 = Convert.ToDecimal(row["LandscapeValue"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    row["Colour"].ToString();
                                    Convert.ToBoolean(row["IsDoublesided"].ToString());
                                    Convert.ToInt64(row["paperID"].ToString());
                                }
                                if (EstType == "N")
                                {
                                    Convert.ToDecimal(row["NcrPartsPerSet"].ToString());
                                    num13 = Convert.ToDecimal(row["NcrSetsPerPad"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    row["Colour"].ToString();
                                    Convert.ToBoolean(row["IsDoublesided"].ToString());
                                    Convert.ToInt64(row["paperID"].ToString());
                                }
                                if (EstType == "B")
                                {
                                    Convert.ToDecimal(row["NoOfPagesInSection"].ToString());
                                    Convert.ToDecimal(row["NoOfSections"].ToString());
                                    num12 = Convert.ToDecimal(row["NoOfSignatures"].ToString());
                                    Convert.ToDecimal(row["TotalPagesAllSections"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    row["Colour"].ToString();
                                    Convert.ToBoolean(row["IsDoublesided"].ToString());
                                    Convert.ToInt64(row["paperID"].ToString());
                                }
                                if (EstType == "K")
                                {
                                    Convert.ToDecimal(row["NoOfPagesInSection"].ToString());
                                    Convert.ToDecimal(row["NoOfSections"].ToString());
                                    num12 = Convert.ToDecimal(row["NoOfSignatures"].ToString());
                                    Convert.ToDecimal(row["TotalPagesAllSections"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    row["Colour"].ToString();
                                    Convert.ToBoolean(row["IsDoublesided"].ToString());
                                    Convert.ToInt64(row["paperID"].ToString());
                                }
                                if (!(EstType == "P") && !(EstType == "D"))
                                {
                                    continue;
                                }
                                num11 = Convert.ToDecimal(row["LeavesPerPad"].ToString());
                            }
                            if (EstType == "P" || EstType == "D")
                            {
                                num8 = (!flag ? Convert.ToDecimal(num10) : Convert.ToDecimal(num9));
                                decimal num16 = new decimal(0);
                                EstimatesBasePage.PrintSheets_Calculation_For_PadItem(num2, num11, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num16);
                                num6 = Convert.ToDecimal(num2);
                                num7 = Convert.ToDecimal(num2 + num16);
                            }
                            else if (EstType == "B")
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num17 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimateBasePage.Booklet_Print_Sheet_Calculation(num2, Convert.ToInt32(num12), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num17);
                                num7 = num6 + Convert.ToDecimal(num17);
                            }
                            else if (EstType == "K")
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num18 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(num2, Convert.ToInt32(num12), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num18);
                                num7 = num6 + Convert.ToDecimal(num18);
                            }
                            else if (EstType != "N")
                            {
                                num8 = (!flag ? Convert.ToDecimal(num10) : Convert.ToDecimal(num9));
                                decimal num19 = new decimal(0);
                                EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num19);
                                num6 = Convert.ToDecimal(num2);
                                num7 = Convert.ToDecimal(num2 + num19);
                            }
                            else
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num20 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(num2, Convert.ToInt32(num13), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num20);
                                num7 = num6 + Convert.ToDecimal(num20);
                            }
                            if (EstType == "P" || EstType == "D")
                            {
                                if (num8 != new decimal(0))
                                {
                                    decimal num21 = new decimal(0);
                                    num15 = Convert.ToDecimal(EstimatesBasePage.PrintSheets_Calculation_For_PadItem(num2, num11, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num21));
                                    num14 = num15 - Convert.ToDecimal(num21);
                                }
                            }
                            else if (EstType == "B")
                            {
                                decimal num22 = new decimal(0);
                                num15 = Convert.ToDecimal(EstimatesBasePage.Booklet_Print_Sheet_Calculation(Convert.ToInt32(num2), num12, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num22));
                                num14 = num15 - Convert.ToDecimal(num22);
                            }
                            else if (EstType == "K")
                            {
                                decimal num23 = new decimal(0);
                                num15 = Convert.ToDecimal(EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(Convert.ToInt32(num2), num12, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num23));
                                num14 = num15 - Convert.ToDecimal(num23);
                            }
                            else if (EstType == "N")
                            {
                                decimal num24 = new decimal(0);
                                num15 = Convert.ToDecimal(EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(Convert.ToInt32(num2), num13, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num24));
                                num14 = num15 - Convert.ToDecimal(num24);
                            }
                            else if (num8 != new decimal(0))
                            {
                                decimal num25 = new decimal(0);
                                num15 = Convert.ToDecimal(EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num25));
                                num14 = num15 - Convert.ToDecimal(num25);
                            }
                        }
                        decimal hoursOrQuantity = new decimal(0);
                        decimal unitRate = new decimal(0);
                        decimal num26 = new decimal(0);
                        if (CalculationType == "q")
                        {
                            if (DefaultQtyType != "f")
                            {
                                if (DefaultQtyType == "v")
                                {
                                    hoursOrQuantity = HoursOrQuantity;
                                }
                            }
                            else if (i == 0)
                            {
                                hoursOrQuantity = HoursOrQuantity;
                            }
                            else if (i == 1)
                            {
                                hoursOrQuantity = (HoursOrQuantity1 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity1);
                            }
                            else if (i == 2)
                            {
                                hoursOrQuantity = (HoursOrQuantity2 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity2);
                            }
                            else if (i == 3)
                            {
                                hoursOrQuantity = (HoursOrQuantity3 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity3);
                            }
                            decimal hourlyRate = new decimal(0);
                            decimal markup = new decimal(0);
                            if (i == 0)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup) / new decimal(100);
                                num26 = (unitRate + markup) + hourlyRate;
                            }
                            else if (i == 1)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate1 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup1) / new decimal(100);
                                num26 = (unitRate + markup) + hourlyRate;
                            }
                            else if (i == 2)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate2 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup2) / new decimal(100);
                                num26 = (unitRate + markup) + hourlyRate;
                            }
                            else if (i == 3)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate3 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup3) / new decimal(100);
                                num26 = (unitRate + markup) + hourlyRate;
                            }
                            num26 = unitRate;
                        }
                        else if (CalculationType == "t")
                        {
                            if (DefaultQtyType == "f")
                            {
                                hoursOrQuantity = HoursOrQuantity;
                            }
                            else if (DefaultQtyType == "v")
                            {
                                if (VariableQty == "1")
                                {
                                    decimal hourlyRunSpeed = num14 / HourlyRunSpeed;
                                    hoursOrQuantity = Convert.ToDecimal(hourlyRunSpeed.ToString("N2"));
                                }
                                if (VariableQty == "2")
                                {
                                    decimal hourlyRunSpeed1 = num15 / HourlyRunSpeed;
                                    hoursOrQuantity = Convert.ToDecimal(hourlyRunSpeed1.ToString("N2"));
                                }
                                if (VariableQty == "3")
                                {
                                    decimal hourlyRunSpeed2 = num6 / HourlyRunSpeed;
                                    hoursOrQuantity = Convert.ToDecimal(hourlyRunSpeed2.ToString("N2"));
                                }
                                if (VariableQty == "4")
                                {
                                    decimal hourlyRunSpeed3 = num7 / HourlyRunSpeed;
                                    hoursOrQuantity = Convert.ToDecimal(hourlyRunSpeed3.ToString("N2"));
                                }
                                if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "job")
                                {
                                    if (EstType == "S" || EstType == "L" || EstType == "B" || EstType == "P" || EstType == "F" || EstType == "D" || EstType == "K")
                                    {
                                        if (VariableQty == "4" || VariableQty == "5")
                                        {
                                            if (i == 0)
                                            {
                                                hoursOrQuantity = HoursOrQuantity;
                                            }
                                            else if (i == 1)
                                            {
                                                if (Session["HourlyQty2"] != null)
                                                {
                                                    hoursOrQuantity = Convert.ToDecimal(Session["HourlyQty2"].ToString());
                                                }
                                            }
                                            else if (i == 2)
                                            {
                                                if (Session["HourlyQty3"] != null)
                                                {
                                                    hoursOrQuantity = Convert.ToDecimal(Session["HourlyQty3"].ToString());
                                                }
                                            }
                                            else if (i == 3)
                                            {
                                                if (Session["HourlyQty4"] != null)
                                                {
                                                    hoursOrQuantity = Convert.ToDecimal(Session["HourlyQty4"].ToString());
                                                }
                                            }
                                        }
                                    }

                                }

                            }
                            decimal hourlyRate1 = (HourlyRate * SetUpTime) / new decimal(60);
                            decimal hourlyRate2 = HourlyRate * hoursOrQuantity;
                            unitRate = hourlyRate2 * Passes;
                            decimal markup1 = (hourlyRate2 * Markup) / new decimal(100);
                            this.finalsellingprice = hourlyRate2 * Passes;
                            num26 = this.finalsellingprice;
                        }
                        if (i == 0)
                        {
                            this.Call_Delete_Other_Variable();
                        }
                        decimal cost = new decimal(0);
                        if (i == 0)
                        {
                            cost = Cost;
                        }
                        else if (i == 1)
                        {
                            cost = Cost1;
                        }
                        else if (i == 2)
                        {
                            cost = Cost2;
                        }
                        else if (i == 3)
                        {
                            cost = Cost3;
                        }
                        if (CalculationType == "t" && DefaultQtyType == "f")
                        {
                            cost = Cost;
                        }
                        if (CalculationType == "q")
                        {
                            cost = num26;
                        }
                        EstimatesBasePage.estimate_othercost_variableqty_insert(this.CompanyID, num, EstOtherCostID, num1, hoursOrQuantity, cost, EstType, empty, num3, i, "");
                    }
                    else if (i == 0)
                    {
                        this.Call_Delete_Other_Variable();
                    }
                    if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                    {
                        EstimateBasePage.othercost_formula_value_update(this.CompanyID, EstimateItemID, stringBuilder.ToString());
                    }
                }
            }
        }

        protected void lnkOtherCostFromSummary_Click(object sender, EventArgs e)
        {
            long num = (long)0;
            DataTable dataTable = EstimatesBasePage.Estimate_SingleItem_Subitem_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
            foreach (DataRow row in dataTable.Rows)
            {
                num = Convert.ToInt64(row["EstSPBWOUCitemID"].ToString());
            }
            this.Est_OtherCost_Insert(num, this.ParentEstimateType, this.ParentEstimateItemID);
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            string empty = string.Empty;
            if (this.modulename == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (empty.ToString().ToLower() == "yes")
                {
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            if (empty.ToString().ToLower() == "yes")
            {
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            HttpResponse httpResponse2 = base.Response;
            object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            httpResponse2.Redirect(string.Concat(objArray2));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Module.ToLower() != "proof")
            {
                DataRow[] dataRowArray;
                object[] parentEstimateItemID;
                string[] tblWidthMinWidth;
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                string empty = string.Empty;
                string str = "display:none";
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string showSubItems = "display:none";
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
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
                }
                this.hdnParentItemID.Value = this.ParentEstimateItemID.ToString();
                this.hdnParentItemType.Value = this.ParentEstimateType.ToString();
                this.hdnModule.Value = this.Module;
                if (this.ParentQtyCount <= this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                if (this.QtyCount == 0)
                {
                    this.QtyCount = 1;
                }
                if (this.Module.ToLower() != "estimate")
                {
                    string empty12 = string.Empty;
                    empty12 = this.objBase.ReturnRoles_Privileges_Others("showadditional");
                    if (this.QtyNumber == 1)
                    {
                        str = "visibility:visible;";
                        if (!(empty12.ToLower() == "false"))
                        {
                            str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 2)
                    {
                        str1 = "visibility:visible;";
                        if (!(empty12.ToLower() == "false"))
                        {
                            str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str1 = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 3)
                    {
                        str2 = "visibility:visible;";
                        if (!(empty12.ToLower() == "false"))
                        {
                            str2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str2 = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 4)
                    {
                        str3 = "visibility:visible;";
                        if (!(empty12.ToLower() == "false"))
                        {
                            str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str3 = "display:none;";
                        }
                    }
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                }
                else if (this.QtyCount == 1)
                {
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                    //str = "visibility:visible;";
                    if (!(this.objBase.ReturnRoles_Privileges_Others("showadditional").ToLower() == "false"))
                    {
                        str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        str = "display:none;";
                    }
                }
                else if (this.QtyCount == 2)
                {
                    this.tblWidth = "62%";
                    this.tblWidth_MinWidth = "min-width:420px;";
                    //str = "visibility:visible;";
                    //str1 = "visibility:visible;";
                    if (!(this.objBase.ReturnRoles_Privileges_Others("showadditional").ToLower() == "false"))
                    {
                        str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        str = "display:none;";
                        str1 = "display:none;";
                    }
                }
                else if (this.QtyCount == 3)
                {
                    this.tblWidth = "82%";
                    this.tblWidth_MinWidth = "min-width:520px;";
                    //str = "visibility:visible;";
                    //str1 = "visibility:visible;";
                    //str2 = "visibility:visible;";
                    if (!(this.objBase.ReturnRoles_Privileges_Others("showadditional").ToLower() == "false"))
                    {
                        str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        str = "display:none;";
                        str1 = "display:none;";
                        str2 = "display:none;";
                    }
                }
                else if (this.QtyCount == 4)
                {
                    this.tblWidth = "100%";
                    this.tblWidth_MinWidth = "min-width:550px;";
                    //str = "visibility:visible;";
                    //str1 = "visibility:visible;";
                    //str2 = "visibility:visible;";
                    //str3 = "visibility:visible;";
                    if (!(this.objBase.ReturnRoles_Privileges_Others("showadditional").ToLower() == "false"))
                    {
                        str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        str = "display:none;";
                        str1 = "display:none;";
                        str2 = "display:none;";
                        str3 = "display:none;";
                    }
                }
                this.plhOtherCostItem.Controls.Clear();
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                long num2 = (long)0;
                bool flag = true;
                EstimatesItem estimatesItem = new EstimatesItem();
                DataTable dataTable = new DataTable();
                if (!this.IsParentItem)
                {
                    dataTable = EstimatesBasePage.estimate_othercost_item_select(this.CompanyID, this.ParentEstimateItemID);
                    dataRowArray = dataTable.Select(string.Concat("EstOtherCostID=", this.EstimateItemID));
                }
                else
                {
                    dataTable = EstimatesBasePage.estimate_othercost_item_select(this.CompanyID, this.EstimateItemID);
                    dataRowArray = dataTable.Select("typeid=0");
                }
                DataRow[] dataRowArray1 = dataRowArray;
                for (int i = 0; i < (int)dataRowArray1.Length; i++)
                {
                    DataRow dataRow = dataRowArray1[i];
                    this.EstOtherCostID = Convert.ToInt64(dataRow["EstOtherCostID"]);
                    this.hdnestothercostid.Value = this.EstOtherCostID.ToString();
                    this.hdnEstimateItemID.Value = this.EstimateItemID.ToString();
                    num2 = Convert.ToInt64(dataRow["TypeID"]);
                    string str4 = dataRow["ItemTitle_New"].ToString();
                    string str5 = dataRow["OthercostName"].ToString();
                    this.OtherCostID = Convert.ToInt64(dataRow["OtherCostID"]);
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = str5;
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.ParentEstimateType == "U")
                        {
                            if (this.IsFromActHist.ToLower() != "yes")
                            {
                                parentEstimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=othercost&EstimateItemID=", this.ParentEstimateItemID, this.jID, this.InvID, "&TypeID=0&EstType=U&EstOtherCostID=", dataRow["EstOthercostID"].ToString(), "&From=U&module=", this.Module, "&EstimateID=", this.EstimateID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str5, "</a>" };
                                empty = string.Concat(parentEstimateItemID);
                            }
                            else
                            {
                                empty = string.Concat("<a href='#'>", str5, "</a>");
                            }
                        }
                        else if (this.IsFromActHist.ToLower() != "yes")
                        {
                            object[] objArray = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=othercost&EstimateItemID=", this.ParentEstimateItemID, this.jID, this.InvID, "&TypeID=", dataRow["EstOtherCostID"].ToString(), "&EstType=U&EstOtherCostID=", dataRow["EstOthercostID"].ToString(), "&From=U&module=", this.Module, "&EstimateID=", this.EstimateID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str5, "</a>" };
                            empty = string.Concat(objArray);
                        }
                        else
                        {
                            empty = string.Concat("<a href='#'>", str5, "</a>");
                        }
                    }
                    else if (this.ParentEstimateType == "U")
                    {
                        if (this.IsFromActHist.ToLower() != "yes")
                        {
                            object[] parentEstimateItemID1 = new object[] { "<a href='javascript://' name='SPLOther'  onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=othecost&EstimateItemID=", this.ParentEstimateItemID, this.jID, this.InvID, "&TypeID=", dataRow["TypeID"].ToString(), "&EstType=", this.ParentEstimateType, "&EstOtherCostID=", dataRow["EstOtherCostID"].ToString(), "&From=U&module=", this.Module, "&EstimateID=", this.EstimateID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str5, "</a>" };
                            empty = string.Concat(parentEstimateItemID1);
                        }
                        else
                        {
                            empty = string.Concat("<a href='#'>", str5, "</a>");
                        }
                    }
                    else if (this.IsFromActHist.ToLower() != "yes")
                    {
                        object[] objArray1 = new object[] { "<a href='javascript://' name='SPLOther'  onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=othecost&EstimateItemID=", this.ParentEstimateItemID, this.jID, this.InvID, "&TypeID=", dataRow["TypeID"].ToString(), "&EstType=", this.ParentEstimateType, "&EstOtherCostID=", dataRow["EstOthercostID"].ToString(), "&From=IU&module=", this.Module, "&EstimateID=", this.EstimateID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str5, "</a>" };
                        empty = string.Concat(objArray1);
                    }
                    else
                    {
                        empty = string.Concat("<a href='#'>", str5, "</a>");
                    }
                    int num3 = Convert.ToInt16(dataRow["SetupTime"]);
                    decimal num4 = Convert.ToDecimal(dataRow["HourlyRate"]);
                    decimal num5 = (num3 * num4) / new decimal(60);
                    decimal num6 = Convert.ToDecimal(dataRow["Cost"]) - num5;
                    decimal num7 = Convert.ToDecimal(dataRow["Cost1"]) - num5;
                    decimal num8 = Convert.ToDecimal(dataRow["Cost2"]) - num5;
                    decimal num9 = Convert.ToDecimal(dataRow["Cost3"]) - num5;
                    estimatesItem.Qtydesc1 = dataRow["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = dataRow["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = dataRow["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = dataRow["QTYDescription4"].ToString();
                    decimal num10 = Convert.ToDecimal(dataRow["Markup"]);
                    decimal num11 = Convert.ToDecimal(dataRow["Markup1"]);
                    decimal num12 = Convert.ToDecimal(dataRow["Markup2"]);
                    decimal num13 = Convert.ToDecimal(dataRow["Markup3"]);
                    decimal num14 = Convert.ToDecimal(dataRow["MinimumCost"]);
                    decimal num15 = new decimal(0);
                    decimal num16 = new decimal(0);
                    decimal num17 = new decimal(0);
                    decimal num18 = new decimal(0);
                    decimal num19 = new decimal(0);
                    decimal num20 = new decimal(0);
                    decimal num21 = new decimal(0);
                    decimal num22 = new decimal(0);
                    num15 = num6;
                    num17 = num7;
                    num19 = num8;
                    num21 = num9;
                    decimal num23 = (num6 * num10) / new decimal(100);
                    decimal num24 = (num7 * num11) / new decimal(100);
                    decimal num25 = (num8 * num12) / new decimal(100);
                    decimal num26 = (num9 * num13) / new decimal(100);
                    num16 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num15, num10, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num18 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num17, num11, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num20 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num19, num12, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num22 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num21, num13, num14, out num, out num1, ref num5);
                    estimatesItem.CostPriceInMarkup1 = num16;
                    estimatesItem.CostPriceInMarkup2 = num18;
                    estimatesItem.CostPriceInMarkup3 = num20;
                    estimatesItem.CostPriceInMarkup4 = num22;
                    if (this.Module.ToLower() == "order")
                    {
                        this.ModuleType = "order";
                        this.PageType = "webstoreorder";
                        this.ModuleID = this.EstimateID;
                    }
                    if (this.Module.ToLower() == "invoice")
                    {
                        this.ModuleType = "invoice";
                        this.PageType = "invoice";
                        this.ModuleID = this.InvoiceID;
                    }
                    if (this.Module.ToLower() == "estimate")
                    {
                        this.ModuleType = "estimate";
                        this.PageType = "estimate";
                        this.ModuleID = this.EstimateID;
                    }
                    if (this.Module.ToLower() == "job")
                    {
                        this.ModuleType = "job";
                        this.PageType = "job";
                        this.ModuleID = this.jobID;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                    {
                        this.ModuleType = "order";
                        this.PageType = "job";
                        this.ModuleID = this.jobID;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                    {
                        this.ModuleType = "order";
                        this.PageType = "invoice";
                        this.ModuleID = this.InvoiceID;
                    }
                    if (num2 != (long)0)
                    {
                        if (!this.IsParentItem)
                        {
                            if (this.objBase.ReturnRoles_Privileges_Others("showsubitems").ToLower() != "false")
                            {
                                showSubItems = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                showSubItems = "display:none;";
                            }
                            if (this.QtyNumber == 1)
                            {
                                str = showSubItems;
                            }
                            else if (this.QtyNumber == 2)
                            {
                                str1 = showSubItems;
                            }
                            else if (this.QtyNumber == 3)
                            {
                                str2 = showSubItems;
                            }
                            else if (this.QtyNumber == 4)
                            {
                                str3 = showSubItems;
                            }
                            else if (this.QtyNumber == 0)
                            {
                                str = showSubItems;
                            }

                        }
                        else
                        {
                            showSubItems = "visibility: visible;";
                        }
                        ControlCollection controls = this.plhOtherCostItem.Controls;
                        tblWidthMinWidth = new string[] { "<table id='tblOthercostItem' width='", this.tblWidth, "' valign='top' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                        controls.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                        //this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPrice' style='text-align:right;", showSubItems, "'>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='text-align: left; width:16%'>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Other Cost'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet' />")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext' style='width:140px;'>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span >", this.objBase.SpecialDecode(empty), "</span>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon'>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<div>"));
                        DataTable dataTable1 = EstimatesBasePage.estimate_othercost_press_details_select((long)this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType, (long)1);
                        foreach (DataRow row in dataTable1.Rows)
                        {
                            this.hid_PressID.Value = row["PressID"].ToString();
                            this.hid_PaperID.Value = row["PaperID"].ToString();
                            this.hid_GuillotineID.Value = row["GuillotineID"].ToString();
                        }
                        this.hdnOtherCostDetails.Value = EstimateBasePage.PC_estimates_othercost_select_byOtherCostID(this.CompanyID, this.OtherCostID);
                        this.hdnOtherCostValues.Value = EstimatesBasePage.estimate_othercost_select_new(this.CompanyID, this.ParentEstimateType, num2, "sub");
                        if (this.IsFromActHist.ToLower() == "yes")
                        {
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("&nbsp;"));
                        }
                        else if (this.Module.ToLower() == "estimate")
                        {
                            if (!this.IsShowJobReRun)
                            {
                                parentEstimateItemID = new object[] { this.strSitepath, "common/edit_other_cost_from_summary.aspx?TypeID=", num2, "+&Module=", this.Module, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=U&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subitem=s" };
                                string str6 = string.Concat(parentEstimateItemID);
                                string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                                if (str7.ToLower() == "true" || str7 == "")
                                {
                                    ControlCollection controlCollections = this.plhOtherCostItem.Controls;
                                    tblWidthMinWidth = new string[] { "&nbsp; <img src='", this.strImagepath, "edit.gif' border='0' onclick=\"javascript:EditOthercost('", str6, "','", this.hdnOtherCostDetails.ClientID, "')\" title='Edit' width='10px' height='10px' style='cursor: pointer;' />&nbsp;" };
                                    controlCollections.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                                }
                                string str8 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                                if (str8.ToLower() == "true" || str8 == "")
                                {
                                    ControlCollection controls1 = this.plhOtherCostItem.Controls;
                                    parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controls1.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controls1 = this.plhOtherCostItem.Controls;
                                    parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controls1.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                }
                            }
                        }
                        else if (this.Module.ToLower() == "job")
                        {
                            if (!this.IsShowInvRerun)
                            {
                                parentEstimateItemID = new object[] { this.strSitepath, "common/edit_other_cost_from_summary.aspx?TypeID=", num2, "+&Module=", this.Module, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=U&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subitem=s" };
                                string str9 = string.Concat(parentEstimateItemID);
                                string str10 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                                if (str10.ToLower() == "true" || str10 == "")
                                {
                                    ControlCollection controlCollections1 = this.plhOtherCostItem.Controls;
                                    tblWidthMinWidth = new string[] { "&nbsp; <img src='", this.strImagepath, "edit.gif' border='0' onclick=\"javascript:EditOthercost('", str9, "','", this.hdnOtherCostDetails.ClientID, "')\" title='Edit' width='10px' height='10px' style='cursor: pointer;' />&nbsp;" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                                }
                                string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                                if (str11.ToLower() == "true" || str11 == "")
                                {
                                    ControlCollection controls2 = this.plhOtherCostItem.Controls;
                                    parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controls2.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controls2 = this.plhOtherCostItem.Controls;
                                    parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controls2.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                }
                            }
                        }
                        else if (this.Module.ToLower() != "order")
                        {
                            parentEstimateItemID = new object[] { this.strSitepath, "common/edit_other_cost_from_summary.aspx?TypeID=", num2, "+&Module=", this.Module, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=U&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subitem=s" };
                            string str12 = string.Concat(parentEstimateItemID);
                            string str13 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                            if (str13.ToLower() == "true" || str13 == "")
                            {
                                ControlCollection controlCollections2 = this.plhOtherCostItem.Controls;
                                tblWidthMinWidth = new string[] { "&nbsp;<img src='", this.strImagepath, "edit.gif' border='0' onclick=\"javascript:EditOthercost('", str12, "','", this.hdnOtherCostDetails.ClientID, "')\" title='Edit' width='10px' height='10px' style='cursor: pointer;' />&nbsp;" };
                                controlCollections2.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            string str14 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                            if (str14.ToLower() == "true" || str14 == "")
                            {
                                ControlCollection controls3 = this.plhOtherCostItem.Controls;
                                parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls3.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controls2 = this.plhOtherCostItem.Controls;
                                parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls2.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                            }
                        }
                        else if (!this.IsShowJobReRun)
                        {
                            parentEstimateItemID = new object[] { this.strSitepath, "common/edit_other_cost_from_summary.aspx?TypeID=", num2, "+&Module=", this.Module, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=U&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subitem=s" };
                            string str15 = string.Concat(parentEstimateItemID);
                            string str16 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                            if (str16.ToLower() == "true" || str16 == "")
                            {
                                ControlCollection controlCollections3 = this.plhOtherCostItem.Controls;
                                tblWidthMinWidth = new string[] { "&nbsp; <img src='", this.strImagepath, "edit.gif' border='0' onclick=\"javascript:EditOthercost('", str15, "','", this.hdnOtherCostDetails.ClientID, "')\" title='Edit' width='10px' height='10px' style='cursor: pointer;' />&nbsp;" };
                                controlCollections3.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            string str17 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                            if (str17.ToLower() == "true" || str17 == "")
                            {
                                ControlCollection controls4 = this.plhOtherCostItem.Controls;
                                parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls4.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controls4 = this.plhOtherCostItem.Controls;
                                parentEstimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.ParentEstimateItemID, "','", this.EstOtherCostID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls4.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                            }
                        }
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice1' style='text-align: right; width:21%; ", str, "'>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup1, 0, "", false, false, true), true), "</span>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice2' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup2, 0, "", false, false, true), true), "</span>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice3' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup3, 0, "", false, false, true), true), "</span>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat(" <td valign='top' id='tdPrice4' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup4, 0, "", false, false, true), true), "</span>")));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    else
                    {
                        if (flag)
                        {
                            if (this.IsParentItem)
                            {

                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both; '>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", this.objBase.SpecialDecode(str4), "</b></div><div style='clear:both;padding-top:10px'></div>")));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("</td>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));

                                DataSet dataSet1 = OrderBasePage.Select_OrderItems_WithAdditionalItems1(this.EstimateItemID);
                                DataTable item2 = dataSet1.Tables[0];
                                DataTable dataTable2 = dataSet1.Tables[2];
                                string empty13 = string.Empty;
                                string str13 = string.Empty;
                                string empty14 = string.Empty;
                                string str14 = string.Empty;
                                string empty15 = string.Empty;
                                string str15 = string.Empty;
                                string empty16 = string.Empty;
                                bool flag2 = false;
                                bool flag3 = false;
                                bool flag4 = false;
                                string str16 = string.Empty;
                                string empty17 = string.Empty;
                                string str17 = string.Empty;
                                string empty18 = string.Empty;
                                object[] estimateItemID;
                                //string[] tblWidthMinWidth;
                                char[] chrArray;
                                int count = dataTable2.Rows.Count;

                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                                StringBuilder stringBuilder1 = new StringBuilder();
                                stringBuilder1.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                                stringBuilder1.Append(string.Concat("<div style='float:left;'>Artwork File(s) (", count, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments_Order();' title='Attachments'></div></div>"));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append(string.Concat("<div id='div_Summary_Attachments_", this.EstimateItemID, "' style='display:none;width:100%;height:15px;border:solid 0px green;'>"));
                                stringBuilder1.Append("<div style='width:50%;border:solid 0px;float:left;'>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append(string.Concat("<div id='div_Detail_Attachments_", this.EstimateItemID, "' style='display:block;width:100%;border:solid 0px green;'>"));
                                stringBuilder1.Append("<div style='width:50%;border:solid 0px;float:left;margin-left:20px;'>");
                                foreach (DataRow row2 in dataTable2.Rows)
                                {
                                    empty15 = row2["FileName"].ToString();
                                    str15 = row2["OriginalFileName"].ToString();
                                    empty16 = row2["ReportFileName"].ToString();
                                    flag2 = Convert.ToBoolean(row2["isEdtiablePDF"]);
                                    flag3 = Convert.ToBoolean(row2["IsPrintReadyFile"]);
                                    flag4 = Convert.ToBoolean(row2["IsFromStoreAttach"]);
                                    str17 = row2["PreviewType"].ToString();
                                    empty18 = row2["ImageNameFromCart"].ToString();
                                    if (!flag4)
                                    {
                                        tblWidthMinWidth = new string[] { global.SecureSitePath(), this.serverName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                                        str16 = string.Concat(tblWidthMinWidth);
                                    }
                                    else
                                    {
                                        estimateItemID = new object[] { global.SecureSitePath(), this.serverName, "/store/", this.AccountID, "/artwork/" };
                                        str16 = string.Concat(estimateItemID);
                                    }
                                    if (flag2 && (str17.ToLower() == "pdf" || str17.ToLower() == "pdfimg"))
                                    {
                                        estimateItemID = new object[] { "<div><a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", empty14, "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", empty17, "</a></div>" };
                                        stringBuilder1.Append(string.Concat(estimateItemID));
                                    }
                                    else if (!flag3)
                                    {
                                        tblWidthMinWidth = new string[] { "<div '><a href='", str16, empty15, "' target='_blank'>", str15, "</a>" };
                                        stringBuilder1.Append(string.Concat(tblWidthMinWidth));
                                        if (empty16 != "")
                                        {
                                            stringBuilder1.Append(string.Concat("<br><a href='", str16, empty16, "' target='_blank'>Report File.pdf</a>"));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    else
                                    {
                                        stringBuilder1.Append("<div>");
                                        estimateItemID = new object[] { "<a id='lblPrintReadyFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", empty15, "\",", this.CompanyID, ");'>", str15, "</a>" };
                                        stringBuilder1.Append(string.Concat(estimateItemID));
                                        if (empty16 != "")
                                        {
                                            estimateItemID = new object[] { "<br><a id='lblPRReportFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", empty16, "\",", this.CompanyID, ");'>Report File.pdf</a>" };
                                            stringBuilder1.Append(string.Concat(estimateItemID));
                                        }
                                        stringBuilder1.Append("</div>");
                                    }
                                    if (!(str17.ToLower() == "pdfimg") && !(str17.ToLower() == "img"))
                                    {
                                        continue;
                                    }
                                    if (str15.Contains(".pdf"))
                                    {
                                        chrArray = new char[] { '.' };
                                        string[] strArrays1 = str15.Split(chrArray);
                                        str15 = string.Concat(strArrays1[0], ".png");
                                    }
                                    this.PDFToURLPath = global.SecureSitePath();
                                    this.Imgpreview.Attributes.Add("onclick", string.Concat("javascript:downloadImage_click(", this.AccountID, ")"));
                                    this.Imgpreview.Attributes.Add("src", string.Concat(" ", this.strImagepath, "downloadImage.png"));
                                    stringBuilder1.Append("<div>");
                                    estimateItemID = new object[] { "<a id='lblImage' style='color:#103593;cursor:pointer;'  onclick='javascript:Pdf_ImagPopup(\"", empty18, "\",", this.AccountID, ",\"", global.SecureSitePath(), "\");'>", str15, "</a>" };
                                    stringBuilder1.Append(string.Concat(estimateItemID));
                                    stringBuilder1.Append("</div>");
                                }
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div style='padding-bottom:10px;' class='onlyEmpty'></div>");
                                this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));

                                if (this.Module.ToLower() != "proof")
                                {
                                    foreach (DataRow row1 in EstimatesBasePage.Select_OtherCostItemQty(this.EstimateID, this.EstimateItemID).Rows)
                                    {
                                        ControlCollection controlCollections4 = this.plhOtherCostItem.Controls;
                                        tblWidthMinWidth = new string[] { "<table id='tblOthercostItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                                        controlCollections4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Quantity"), "  </div>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<td align='left' valign='top' style='width: 84%; border:0px solid green;'>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' width='100%' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice1' style='text-align: right; width:21%; ", str, "'>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", row1["QTY1"].ToString(), "</span>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice2' style='text-align: right; width: 21%; ", str1, "'>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice2' CssClass='normalText'>", row1["QTY2"].ToString(), "</span>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice3' style='text-align: right; width: 21%; ", str2, "'>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice3' CssClass='normalText'>", row1["QTY3"].ToString(), "</span>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat(" <td valign='top' id='tdPrice4' style='text-align: right; width: 21%; ", str3, "'>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice4' CssClass='normalText'>", row1["QTY4"].ToString(), "</span>")));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                        this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                                    }
                                    ControlCollection controls5 = this.plhOtherCostItem.Controls;
                                    string[] strArrays = new string[] { "<table id='tblQtydescription' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                                    controls5.Add(new LiteralControl(string.Concat(strArrays)));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trQtydescription'>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "  </div>")));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("<td align='right' style='width: 84%;'>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("<table id='tblQtydescriptionItem' width='100%' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trqty' style='text-align:right;'>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdqty1' style='text-align: right; width:21%; ", str, "'>")));
                                    ControlCollection controlCollections5 = this.plhOtherCostItem.Controls;
                                    var locking = "";
                                    var ignorelocking = "";
                                    var IsJobLocked = false;
                                    if (this.Module.ToLower() == "job")
                                    {
                                        locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                                        ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                                        IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                                    }
                                    if (IsJobLocked && ignorelocking != "true")
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                        controlCollections5.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    else
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                        controlCollections5.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdqty2' style='text-align: right; width: 21%; ", str1, "'>")));
                                    ControlCollection controls6 = this.plhOtherCostItem.Controls;
                                    if (IsJobLocked && ignorelocking != "true")
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                        controls6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    else
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                        controls6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdqty3' style='text-align: right; width: 21%; ", str2, "'>")));
                                    ControlCollection controlCollections6 = this.plhOtherCostItem.Controls;
                                    if (IsJobLocked && ignorelocking != "true")
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                        controlCollections6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    else
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                        controlCollections6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat(" <td valign='top' id='tdqty4' style='text-align: right; width: 21%; ", str3, "'>")));
                                    ControlCollection controls7 = this.plhOtherCostItem.Controls;
                                    if (IsJobLocked && ignorelocking != "true")
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                        controls7.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    else
                                    {
                                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                        controls7.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                                    }
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                                    this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                                }
                            }
                            flag = false;
                        }
                        if (this.Module.ToLower() != "proof")
                        {
                            ControlCollection controlCollections7 = this.plhOtherCostItem.Controls;
                            tblWidthMinWidth = new string[] { "<table id='tblOthercostItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                            controlCollections7.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                            if (this.IsParentItem)
                            {
                                this.plhOtherCostItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objBase.SpecialDecode(empty), "</div>")));
                                this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            }
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("<td align='left' valign='top' style='width: 84%; border:0px solid green;'>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("<table id='tblOthercostItemQty' width='100%' valign='top' cellpadding='0' cellspacing='0' border='0'>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("<tr id='trPrice' style='text-align:right;'>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice1' style='text-align: right; width:21%; ", str, "'>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup1, 0, "", false, false, true), true), "</span>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice2' style='text-align: right; width: 21%; ", str1, "'>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup2, 0, "", false, false, true), true), "</span>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='tdPrice3' style='text-align: right; width: 21%; ", str2, "'>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup3, 0, "", false, false, true), true), "</span>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat(" <td valign='top' id='tdPrice4' style='text-align: right; width: 21%; ", str3, "'>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup4, 0, "", false, false, true), true), "</span>")));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("</tr>"));
                            this.plhOtherCostItem.Controls.Add(new LiteralControl("</table>"));
                        }
                    }
                }
            }
            else
            {
                DataRow[] dataRowArray;
                object[] parentEstimateItemID;
                EstimatesItem estimatesItem = new EstimatesItem();
                DataTable dataTable = new DataTable();
                if (!this.IsParentItem)
                {
                    dataTable = EstimatesBasePage.estimate_othercost_item_select(this.CompanyID, this.ParentEstimateItemID);
                    dataRowArray = dataTable.Select(string.Concat("EstOtherCostID=", this.EstimateItemID));
                }
                else
                {
                    dataTable = EstimatesBasePage.estimate_othercost_item_select(this.CompanyID, this.EstimateItemID);
                    dataRowArray = dataTable.Select("typeid=0");
                }
                DataRow[] dataRowArray1 = dataRowArray;
                for (int i = 0; i < (int)dataRowArray1.Length; i++)
                {
                    DataRow dataRow = dataRowArray1[i];
                    estimatesItem.Qtydesc1 = dataRow["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = dataRow["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = dataRow["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = dataRow["QTYDescription4"].ToString();
                    ControlCollection controlCollections5 = this.plhOtherCostItem.Controls;
                    var locking = "";
                    var ignorelocking = "";
                    var IsJobLocked = false;
                    if (this.Module.ToLower() == "job")
                    {
                        locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                        ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                        IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    }
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    else
                    {
                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    ControlCollection controls6 = this.plhOtherCostItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    else
                    {
                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    ControlCollection controlCollections6 = this.plhOtherCostItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        parentEstimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    else
                    {
                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    ControlCollection controls7 = this.plhOtherCostItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        parentEstimateItemID = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                    else
                    {
                        parentEstimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(parentEstimateItemID)));
                    }
                }

            }
        }

        private decimal PressCostPerClick(decimal PrintSheets, decimal ChargeableRate, decimal ChargeableSheets)
        {
            decimal num = new decimal(0);
            num = ChargeableRate / Convert.ToDecimal(ChargeableSheets);
            return num * PrintSheets;
        }

        public void Question_Find_In_Formula(string strFormula, string formulaValue, ref ArrayList AL11, ref ArrayList AL22)
        {
            try
            {
                strFormula = strFormula.Replace("(", "").Replace(")", "");
                strFormula = strFormula.Replace("-", "µ").Replace("/", "µ");
                strFormula = strFormula.Replace("*", "µ").Replace("%", "µ");
                strFormula = strFormula.Replace("^", "µ").Replace("+", "µ");
                string[] strArrays = strFormula.Split(new char[] { 'µ' });
                formulaValue = formulaValue.Replace("(", "").Replace(")", "");
                formulaValue = formulaValue.Replace("-", "µ").Replace("/", "µ");
                formulaValue = formulaValue.Replace("*", "µ").Replace("%", "µ");
                formulaValue = formulaValue.Replace("^", "µ").Replace("+", "µ");
                string[] strArrays1 = formulaValue.Split(new char[] { 'µ' });
                int num = 0;
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Contains("Q::"))
                    {
                        AL11.Insert(num, strArrays[i]);
                        AL22.Insert(num, strArrays1[i]);
                    }
                    if (strArrays[i].Contains("Matrix"))
                    {
                        AL11.Insert(num, strArrays[i]);
                        AL22.Insert(num, strArrays1[i]);
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        public decimal ReturnExact2Decimal(decimal Amount)
        {
            return Amount;
        }
    }
}