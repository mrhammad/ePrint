using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.EstimatesNew;
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


namespace ePrint.usercontrol.Item
{
    public partial class item_summary_pricecatalogue_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhPriceCatalogueItem;

        //protected HtmlImage Imgpreview;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass commclass = new commonClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string serverName = ConnectionClass.ServerName;

        public int CompanyID;

        public int UserID;

        public string strSecuresitepath = global.SecureSitePath();

        public int QtyCount;

        public int ParentQtyCount;

        public int QtyNumber;

        public string Module = string.Empty;

        public string PageType = string.Empty;

        public long ModuleID;

        public string ModuleType = string.Empty;

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

        public bool IsShowDelete;

        public long EstimateAdditionalItemID;

        public string CalculationType = string.Empty;

        public long SelectedID;

        public string SelectedValue = string.Empty;

        public string Decoration = string.Empty;

        public decimal CostPriceEXcMarkup1;

        public decimal CostPriceEXcMarkup2;

        public decimal CostPriceEXcMarkup3;

        public decimal CostPriceEXcMarkup4;

        public decimal MarkupPercentage1;

        public decimal MarkupPercentage2;

        public decimal MarkupPercentage3;

        public decimal MarkupPercentage4;

        public decimal MarkupValue1;

        public decimal MarkupValue2;

        public decimal MarkupValue3;

        public decimal MarkupValue4;

        public int SortOrderNo;

        public decimal SelectedPrice1;

        public decimal SelectedPrice2;

        public decimal SelectedPrice3;

        public decimal SelectedPrice4;

        public string EstimateOtherCostName = string.Empty;

        public decimal MarkUp;

        public decimal MarkUpValue;

        public decimal SelectedPrice;

        public decimal TotalIncMarkup1;

        public decimal TotalIncMarkup2;

        public decimal TotalIncMarkup3;

        public decimal TotalIncMarkup4;

        public decimal TotalEXcMarkup1;

        public decimal TotalEXcMarkup2;

        public decimal TotalEXcMarkup3;

        public decimal TotalEXcMarkup4;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string IsFromActHist = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        private string MeasurementValue = string.Empty;

        private string MeasurementValue_Sq = string.Empty;

        public string SalesPersonID = string.Empty;

        public static string IsEditOnlyHisRecords;

        public static int ManageStockPermission;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        private string Item_Type = string.Empty;

        private string Artfile1 = string.Empty;

        private string Artfile2 = string.Empty;

        private string ArtfileLink1 = string.Empty;

        private string ArtfileLink2 = string.Empty;

        public string itemcode = string.Empty;

        public string PDFToURLPath = string.Empty;

        public int AccountID;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        static item_summary_pricecatalogue_item()
        {
            item_summary_pricecatalogue_item.IsEditOnlyHisRecords = string.Empty;
            item_summary_pricecatalogue_item.ManageStockPermission = 0;
        }

        public item_summary_pricecatalogue_item()
        {
        }

        private void btnCopyitem_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.IsItemCopied = this.SummaryClassObj.CopyItem(this.EstimateID, Convert.ToInt64(button.CommandName), button.CommandArgument, this.Module, "sss");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Module.ToLower() != "proof")
            {
                object[] estimateItemID;
                string[] tblWidthMinWidth;
                char[] chrArray;
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                string empty = string.Empty;
                string str = string.Empty;
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
                }
                if (!base.IsPostBack)
                {
                    DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
                    item_summary_pricecatalogue_item.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
                }
                string empty1 = string.Empty;
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
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string str4 = "display:none";
                string strDimension1 = "display:none";
                string strDimension2 = "display:none";
                string strDimension3 = "display:none";
                string strDimension4 = "display:none";
                string strShow1 = "display:none";
                string strShow2 = "display:none";
                string strShow3 = "display:none";
                string strShow4 = "display:none";
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                int num = 0;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                decimal num1 = new decimal(0);
                EstimatesItem estimatesItem = new EstimatesItem();
                this.MeasurementValue = this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
                if (this.MeasurementValue != "In.")
                {
                    this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareMeter");
                }
                else
                {
                    this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareFeet");
                }
                foreach (DataRow row in EstimatesBasePage.estimate_price_catalogue_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    Convert.ToInt64(row["EstimateID"]);
                    long num2 = Convert.ToInt64(row["EstTypeID"]);
                    this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    empty3 = (!this.objBase.SpecialDecode(row["ItemTitle"].ToString()).Contains("<br/>") ? this.objBase.SpecialDecode(row["CatalogueName"].ToString()) : this.objBase.SpecialDecode(row["ItemTitle"].ToString()));
                    int num3 = Convert.ToInt32(row["Quantity"].ToString());
                    string str6 = row["QTYDescription"].ToString();
                    num1 = Convert.ToInt32(row["MultipleOf"]);
                    decimal num4 = Convert.ToDecimal(row["Markup"]);
                    decimal num5 = Convert.ToDecimal(row["Price"]);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    string str7 = row["MatrixType"].ToString();
                    estimatesItem.MatrixType = str7;
                    decimal num8 = Convert.ToDecimal(row["Height"]);
                    decimal num9 = Convert.ToDecimal(row["Width"]);
                    num = Convert.ToInt32(row["QtyNumber"]);
                    this.ArtfileLink1 = row["Artfile1"].ToString().Trim();
                    this.ArtfileLink2 = row["Artfile2"].ToString().Trim();
                    this.itemcode = this.objBase.SpecialDecode(row["ItemCode"].ToString());
                    if (this.Check_SpecialPrivilege)
                    {
                        empty1 = empty3;
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.IsFromActHist.ToLower() == "yes")
                        {
                            empty1 = string.Concat("<a href='#'>", this.objBase.SpecialDecode(empty3), "</a>");
                        }
                        else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
                        {
                            estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=catalogue&EstimateItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&TypeID=", num2, "&From=C&module=", this.Module, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                            empty1 = string.Concat(estimateItemID);
                        }
                        else
                        {
                            estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/order_popup.aspx?OrderItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&module=webstoreorder',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                            empty1 = string.Concat(estimateItemID);
                        }
                    }
                    else if (this.IsFromActHist.ToLower() == "yes")
                    {
                        empty1 = string.Concat("<a href='#'>", this.objBase.SpecialDecode(empty3), "</a>");
                    }
                    else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
                    {
                        estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=catalogue&EstimateItemID=", this.EstimateItemID, "&TypeID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&EstType=", this.EstType, "&From=C&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                        empty1 = string.Concat(estimateItemID);
                    }
                    else
                    {
                        estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/order_popup.aspx?OrderItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&module=webstoreorder',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                        empty1 = string.Concat(estimateItemID);
                    }
                    if (!string.IsNullOrEmpty(this.ArtfileLink1.Trim().ToString()) && this.ArtfileLink1.Trim().ToString().Length > 0)
                    {
                        this.Artfile1 = string.Concat("<a href='", this.ArtfileLink1, "' target='_blank' \"> Art file 1 </a>");
                    }
                    if (!string.IsNullOrEmpty(this.ArtfileLink2.Trim().ToString()) && this.ArtfileLink2.Trim().ToString().Length > 0)
                    {
                        this.Artfile2 = string.Concat("<a href='", this.ArtfileLink2, "' target='_blank' \"> Art file 2 </a>");
                    }
                    empty4 = (!Convert.ToBoolean(row["IsSides"]) ? "no" : "yes");
                    if (ConnectionClass.ServerName.ToLower() != "handyenvelopes" && ConnectionClass.ServerName.ToLower() != "handyexpress")
                    {
                        empty5 = num1.ToString();
                    }
                    else if (num1 != new decimal(2))
                    {
                        empty5 = "Single";
                    }
                    else
                    {
                        num1 = Convert.ToDecimal(1.5);
                        empty5 = "Double";
                    }
                    num6 = (num4 * num5) / new decimal(100);
                    num7 = num6 + num5;
                    if (num1 != new decimal(0))
                    {
                        num7 = num7 * num1;
                        num6 = num6 * num1;
                    }
                    estimatesItem.MultipleOf = num1;
                    if (this.Module.ToLower() != "estimate")
                    {
                        string empty12 = string.Empty;
                        empty12 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                        string empty13 = string.Empty;
                        empty13 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                        if (this.QtyNumber == 1)
                        {
                            strShow1 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension1 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension1 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 2)
                        {
                            strShow2 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension2 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension2 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 3)
                        {
                            strShow3 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension3 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension3 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 4)
                        {
                            strShow4 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension4 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension4 = "visibility:visible;";
                            }
                        }
                        if (num == 1)
                        {
                            estimatesItem.Qty1 = num3;
                            estimatesItem.Qtydesc1 = str6;
                            estimatesItem.CostPriceExMarkup1 = num5;
                            estimatesItem.MarkupPrice1 = num6;
                            estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension1 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension1 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width1 = num9;
                                estimatesItem.Height1 = num8;
                            }
                        }
                        else if (num == 2)
                        {
                            estimatesItem.Qty2 = num3;
                            estimatesItem.Qtydesc2 = str6;
                            estimatesItem.CostPriceExMarkup2 = num5;
                            estimatesItem.MarkupPrice2 = num6;
                            estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension2 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension2 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width2 = num9;
                                estimatesItem.Height2 = num8;
                            }
                        }
                        else if (num == 3)
                        {
                            estimatesItem.Qty3 = num3;
                            estimatesItem.Qtydesc3 = str6;
                            estimatesItem.CostPriceExMarkup3 = num5;
                            estimatesItem.MarkupPrice3 = num6;
                            estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension3 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension3 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width3 = num9;
                                estimatesItem.Height3 = num8;
                            }
                        }
                        else if (num == 4)
                        {
                            estimatesItem.Qty4 = num3;
                            estimatesItem.Qtydesc4 = str6;
                            estimatesItem.CostPriceExMarkup4 = num5;
                            estimatesItem.MarkupPrice4 = num6;
                            estimatesItem.CostPriceInMarkup4 = estimatesItem.CostPriceExMarkup4 + estimatesItem.MarkupPrice4;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension4 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension4 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width4 = num9;
                                estimatesItem.Height4 = num8;
                            }
                        }
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                    }
                    else if (num == 1)
                    {
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                        strShow1 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension1 = "display:none;";
                        }
                        str1 = "visibility:visible;";
                        estimatesItem.Qty1 = num3;
                        estimatesItem.Qtydesc1 = str6;
                        estimatesItem.CostPriceExMarkup1 = num5;
                        estimatesItem.MarkupPrice1 = num6;
                        estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension1 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension1 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width1 = num9;
                        estimatesItem.Height1 = num8;
                    }
                    else if (num == 2)
                    {
                        this.tblWidth = "62%";
                        this.tblWidth_MinWidth = "min-width:420px;";
                        strShow2 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension2 = "display:none;";
                        }
                        str2 = "visibility:visible;";
                        estimatesItem.Qty2 = num3;
                        estimatesItem.Qtydesc2 = str6;
                        estimatesItem.CostPriceExMarkup2 = num5;
                        estimatesItem.MarkupPrice2 = num6;
                        estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension2 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension2 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width2 = num9;
                        estimatesItem.Height2 = num8;
                    }
                    else if (num != 3)
                    {
                        if (num != 4)
                        {
                            continue;
                        }
                        this.tblWidth = "100%";
                        this.tblWidth_MinWidth = "min-width:550px;";
                        strShow4 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension4 = "display:none;";
                        }
                        str4 = "visibility:visible;";
                        estimatesItem.Qty4 = num3;
                        estimatesItem.Qtydesc4 = str6;
                        estimatesItem.CostPriceExMarkup4 = num5;
                        estimatesItem.MarkupPrice4 = num6;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension4 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension4 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width4 = num9;
                        estimatesItem.Height4 = num8;
                    }
                    else
                    {
                        this.tblWidth = "82%";
                        this.tblWidth_MinWidth = "min-width:520px;";
                        strShow3 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str3 = "display:none;";
                        }
                        strDimension3 = "visibility:visible;";
                        estimatesItem.Qty3 = num3;
                        estimatesItem.Qtydesc3 = str6;
                        estimatesItem.CostPriceExMarkup3 = num5;
                        estimatesItem.MarkupPrice3 = num6;
                        estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension3 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension3 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width3 = num9;
                        estimatesItem.Height3 = num8;
                    }
                }
                if (!this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Product Catalogue'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet'/>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(empty1 ?? ""));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon'>"));
                    string empty6 = string.Empty;
                    if (this.IsFromActHist.ToLower() == "yes")
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    }
                    else if (this.Module.ToLower() == "estimate")
                    {
                        if (!this.IsShowJobReRun)
                        {
                            estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            empty6 = string.Concat(estimateItemID);
                            empty = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isedit", this.Page.Request.Url.ToString());
                            str = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                            if (empty.Trim().ToLower() == "true" || empty == "")
                            {
                                ControlCollection controls = this.plhPriceCatalogueItem.Controls;
                                tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            if (str.Trim().ToLower() == "true" || str == "")
                            {
                                ControlCollection controlCollections = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                        }
                    }
                    else if (this.Module.ToLower() == "order")
                    {
                        this.ModuleType = "order";
                        if (!this.IsShowJobReRun)
                        {
                            estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            empty6 = string.Concat(estimateItemID);
                            empty = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isedit", this.Page.Request.Url.ToString());
                            str = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                            if (empty.Trim().ToLower() == "true" || empty == "")
                            {
                                ControlCollection controls1 = this.plhPriceCatalogueItem.Controls;
                                tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls1.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            if (str.Trim().ToLower() == "true" || str == "")
                            {
                                ControlCollection controlCollections1 = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections1 = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                        }
                    }
                    else if (this.Module.ToLower() != "job")
                    {
                        estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                        empty6 = string.Concat(estimateItemID);
                        empty = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isedit", this.Page.Request.Url.ToString());
                        str = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                        if (empty.Trim().ToLower() == "true" || empty == "")
                        {
                            ControlCollection controls2 = this.plhPriceCatalogueItem.Controls;
                            tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controls2.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        }
                        if (str.Trim().ToLower() == "true" || str == "")
                        {
                            ControlCollection controlCollections2 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else if (strRemove.Trim() == "1")
                        {
                            ControlCollection controlCollections2 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                    }
                    else if (!this.IsShowInvRerun)
                    {
                        estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                        empty6 = string.Concat(estimateItemID);
                        empty = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isedit", this.Page.Request.Url.ToString());
                        str = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                        if (empty.Trim().ToLower() == "true" || empty == "")
                        {
                            ControlCollection controls3 = this.plhPriceCatalogueItem.Controls;
                            tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controls3.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        }
                        if (str.Trim().ToLower() == "true" || str == "")
                        {
                            ControlCollection controlCollections3 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else if(strRemove.Trim() == "1")
                        {
                            ControlCollection controlCollections3 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div id='div_subitemcode' class='bglabelItem_summary'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(this.itemcode ?? ""));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                }
                else
                {
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
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table id='tblPriceCatalogueItem' width='100%' cellpadding='0' cellspacing='0' border='0'><tr id='trCatalogueName'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%' colspan='2'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogueLinkID' style='clear: both; padding-top:10px;'><b>", empty1, "</b></div><div style='clear:both;padding-top:5px'></div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<tr><td><b> ", this.itemcode, " </b> <div style='clear:both;padding-top:10px'></div></td></tr>")));
                    if (this.Module.ToLower() == "order" && this.Module.ToLower() == "job" && (ConnectionClass.ServerName.ToLower() == "smpaus" || ConnectionClass.ServerName.ToLower() == "smpaustest" || ConnectionClass.ServerName.ToLower().Contains("prelive")))
                    {
                        this.Item_Type = EstimatesBasePage.GetEstimateType_EstimateItemID(this.EstimateItemID);
                        if (this.Item_Type.ToLower() == "x")
                        {
                            if (!string.IsNullOrEmpty(this.Artfile1.Trim().ToString()) && this.Artfile1.ToString().Length > 0)
                            {
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl_ArtFile1' style='width: 16%' colspan='2'>"));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogue_ArtFile1' style='clear: both;'><b>", this.Artfile1, "</b></div>")));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                            }
                            if (!string.IsNullOrEmpty(this.Artfile2.Trim().ToString()) && this.Artfile2.ToString().Length > 0)
                            {
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl_ArtFile2' style='width: 16%' colspan='2'>"));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogue_ArtFile1' style='clear: both;'><b>", this.Artfile2, "</b></div>")));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                            }
                        }
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                }
                if (!this.IsParentItem || !(this.ModuleType.ToLower() == "order"))
                {
                    DataTable dataTable1 = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
                    if (this.IsParentItem && Convert.ToBoolean(dataTable1.Rows[0]["AllowPrintReadyFile"]))
                    {
                        DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems1(this.EstimateItemID);
                        DataTable item = dataSet.Tables[0];
                        DataTable item1 = dataSet.Tables[2];
                        string empty7 = string.Empty;
                        string empty8 = string.Empty;
                        string str8 = string.Empty;
                        string empty9 = string.Empty;
                        string str9 = string.Empty;
                        string empty10 = string.Empty;
                        string str10 = string.Empty;
                        bool flag = false;
                        bool flag1 = false;
                        string empty11 = string.Empty;
                        string str11 = string.Empty;
                        string empty12 = string.Empty;
                        string str12 = string.Empty;
                        foreach (DataRow dataRow in item.Rows)
                        {
                            dataRow["JobName"].ToString();
                            str8 = dataRow["PDFNameFromCart"].ToString();
                            dataRow["PrintReadyFile"].ToString();
                            dataRow["CatalogueName"].ToString();
                            this.AccountID = Convert.ToInt32(dataRow["AccountID"]);
                            str11 = dataRow["OriginalNamePdfFromcart"].ToString();
                        }
                        int count = item1.Rows.Count;
                        if (count != 0)
                        {

                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                            stringBuilder.Append(string.Concat("<div style='float:left;'>Artwork File(s) (", count, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments_Order();' title='Attachments'></div></div>"));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(string.Concat("<div id='div_Summary_Attachments_", this.EstimateItemID, "' style='display:none;width:100%;height:15px;border:solid 0px green;'>"));
                            stringBuilder.Append("<div style='width:50%;border:solid 0px;float:left;'>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(string.Concat("<div id='div_Detail_Attachments_", this.EstimateItemID, "' style='display:block;width:100%;border:solid 0px green;'>"));
                            stringBuilder.Append("<div style='width:50%;border:solid 0px;float:left;margin-left:20px;'>");
                            foreach (DataRow row1 in item1.Rows)
                            {
                                str9 = row1["FileName"].ToString();
                                empty10 = row1["OriginalFileName"].ToString();
                                str10 = row1["ReportFileName"].ToString();
                                flag = Convert.ToBoolean(row1["isEdtiablePDF"]);
                                flag1 = Convert.ToBoolean(row1["IsPrintReadyFile"]);
                                Convert.ToBoolean(row1["IsFromStoreAttach"]);
                                empty12 = row1["PreviewType"].ToString();
                                str12 = row1["ImageNameFromCart"].ToString();
                                tblWidthMinWidth = new string[] { global.SecureSitePath(), this.serverName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                                empty11 = string.Concat(tblWidthMinWidth);
                                if (flag && (empty12.ToLower() == "pdf" || empty12.ToLower() == "pdfimg"))
                                {
                                    estimateItemID = new object[] { "<div><a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", str8, "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", str11, "</a></div>" };
                                    stringBuilder.Append(string.Concat(estimateItemID));
                                }
                                else if (!flag1)
                                {
                                    tblWidthMinWidth = new string[] { "<div '><a href='", empty11, str9, "' target='_blank'>", empty10, "</a>" };
                                    stringBuilder.Append(string.Concat(tblWidthMinWidth));
                                    if (str10 != "")
                                    {
                                        stringBuilder.Append(string.Concat("<br><a href='", empty11, str10, "' target='_blank'>Report File.pdf</a>"));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                else
                                {
                                    stringBuilder.Append("<div>");
                                    estimateItemID = new object[] { "<a id='lblPrintReadyFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", str9, "\",", this.CompanyID, ");'>", empty10, "</a>" };
                                    stringBuilder.Append(string.Concat(estimateItemID));
                                    if (str10 != "")
                                    {
                                        estimateItemID = new object[] { "<br><a id='lblPRReportFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", str10, "\",", this.CompanyID, ");'>Report File.pdf</a>" };
                                        stringBuilder.Append(string.Concat(estimateItemID));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                if (!(empty12.ToLower() == "pdfimg") && !(empty12.ToLower() == "img"))
                                {
                                    continue;
                                }
                                if (empty10.Contains(".pdf"))
                                {
                                    chrArray = new char[] { '.' };
                                    string[] strArrays = empty10.Split(chrArray);
                                    empty10 = string.Concat(strArrays[0], ".png");
                                }
                                this.PDFToURLPath = global.SecureSitePath();
                                this.Imgpreview.Attributes.Add("onclick", string.Concat("javascript:downloadImage_click(", this.AccountID, ")"));
                                this.Imgpreview.Attributes.Add("src", string.Concat(" ", this.strImagepath, "downloadImage.png"));
                                stringBuilder.Append("<div>");
                                estimateItemID = new object[] { "<a id='lblImage' style='color:#103593;cursor:pointer;'  onclick='javascript:Pdf_ImagPopup(\"", str12, "\",", this.AccountID, ",\"", global.SecureSitePath(), "\");'>", empty10, "</a>" };
                                stringBuilder.Append(string.Concat(estimateItemID));
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div style='padding-bottom:10px;' class='onlyEmpty'></div>");
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder.ToString(), "</span>")));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));

                        }
                    }
                    ControlCollection controls4 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<table id='tblPriceCatalogueItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                }
                else
                {
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
                    foreach (DataRow dataRow1 in item2.Rows)
                    {
                        empty13 = dataRow1["JobName"].ToString();
                        empty14 = dataRow1["PDFNameFromCart"].ToString();
                        dataRow1["PrintReadyFile"].ToString();
                        dataRow1["CatalogueName"].ToString();
                        this.AccountID = Convert.ToInt32(dataRow1["AccountID"]);
                        empty17 = dataRow1["OriginalNamePdfFromcart"].ToString();
                    }
                    int count1 = dataTable2.Rows.Count;
                    if (count1 != 0)
                    {

                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                        StringBuilder stringBuilder1 = new StringBuilder();
                        stringBuilder1.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                        stringBuilder1.Append(string.Concat("<div style='float:left;'>Artwork File(s) (", count1, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments_Order();' title='Attachments'></div></div>"));
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
                                //estimateItemID = new object[] { "<div class=\"attachments_orders_editable\"><a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", empty14, "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", empty17, "</a></div>" };
                                estimateItemID = new object[] { "<div><a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", empty14, "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", empty17, "</a></div>" };
                                stringBuilder1.Append(string.Concat(estimateItemID));
                            }
                            else if (!flag3)
                            {
                                //tblWidthMinWidth = new string[] { "<div class=\"attachments_orders_editable\" '><a href='", str16, empty15, "' target='_blank'>", str15, "</a>" };
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
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    ControlCollection controlCollections4 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<table id='tblPriceCatalogueItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Job_Name"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", empty13, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td style='text-align: right; width: 21%;", str4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;", strShow1, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%;", strShow2, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%;", strShow3, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%;", strShow4, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                if (estimatesItem.MatrixType.ToLower() == "g")
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trDimension'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    ControlCollection controls5 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 200px; clear: both'>", this.objLanguage.GetLanguageConversion("Area"), " (", this.MeasurementValue_Sq, ")</div>" };
                    controls5.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension1, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension1, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension2, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension2, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%;", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension3, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension3, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension4, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension4, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trWidth'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 200px; margin-top:-2; clear: both'>", this.objLanguage.GetLanguageConversion("Dimension_Summary_Page"), this.MeasurementValue, "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth1' style='text-align: right; width: 21%;", strDimension1, ";'>")));
                    ControlCollection controlCollections5 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth1' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width1, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height1, 0, "", false, false, true, false, true), "</span>" };
                    controlCollections5.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    ControlCollection controls6 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth2' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width2, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height2, 0, "", false, false, true, false, true), "</span>" };
                    controls6.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth3' style='text-align: right; width: 21%;", strDimension3, ";'>")));
                    ControlCollection controlCollections6 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth3' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width3, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height3, 0, "", false, false, true, false, true), "</span>" };
                    controlCollections6.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdWidth4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    ControlCollection controls7 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth4' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width4, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height4, 0, "", false, false, true, false, true), "</span>" };
                    controls7.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem && ((ConnectionClass.ServerName.ToLower() == "handyenvelopes" || ConnectionClass.ServerName.ToLower() == "handyexpress") && empty4 == "yes" || estimatesItem.MultipleOf > new decimal(0)))
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trMultipleOf'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    if (ConnectionClass.ServerName.ToLower() == "handyenvelopes" || ConnectionClass.ServerName.ToLower() == "handyexpress")
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Sides"), "</div>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Multiple_Of"), "</div>")));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdMultipleOf1' style='text-align: right; width: 21%;", strShow1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf1' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%;", strShow2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf2' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%;", strShow3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf3' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", strShow4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf4' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trQtydescription'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow1, "'>")));
                    ControlCollection controlCollections7 = this.plhPriceCatalogueItem.Controls;
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
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow2, "'>")));
                    ControlCollection controls8 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow3, "'>")));
                    ControlCollection controlCollections8 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow4, "'>")));
                    ControlCollection controls9 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (!this.Check_SpecialPrivilege && !(ConnectionClass.ServerName.ToLower() == "handyenvelopes") && !(ConnectionClass.ServerName.ToLower() == "handyexpress"))
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trCostforeachset'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width:16%'>"));
                    if (!this.IsParentItem)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 150px; clear: both'>Price</div>"));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 150px; clear: both'>Cost for each set</div>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdCostforeachset4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                int num10 = 1;
                this.Item_Type = EstimatesBasePage.GetEstimateType_EstimateItemID(this.EstimateItemID);
                DataTable dataTable3 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
                foreach (DataRow dataRow2 in dataTable3.Rows)
                {
                    this.EstimateAdditionalItemID = Convert.ToInt64(dataRow2["EstimateAdditionalItemID"]);
                    this.CalculationType = Convert.ToString(dataRow2["CalculationType"]);
                    this.SelectedID = Convert.ToInt64(dataRow2["SelectedID"]);
                    if(this.CalculationType.ToLower() == "l" || this.CalculationType.ToLower() == "c")
                    {
                        if(!string.IsNullOrEmpty(dataRow2["FreeTextQuestionLong"].ToString()))
                        {
                            this.SelectedValue = this.objBase.SpecialDecode(dataRow2["FreeTextQuestionLong"].ToString());
                        }
                        else
                        {
                            this.SelectedValue = this.objBase.SpecialDecode(dataRow2["SelectedValue"].ToString());
                        }
                    }
                    else
                    {
                        this.SelectedValue = this.objBase.SpecialDecode(dataRow2["SelectedValue"].ToString());
                    }
                    this.SelectedValue = this.SelectedValue.Replace("¶Yes", "");
                    this.SelectedValue = this.SelectedValue.Replace("¶No", "");
                    this.SortOrderNo = Convert.ToInt32(dataRow2["SortOrderNo"]);
                    this.EstimateOtherCostName = this.objBase.SpecialDecode(dataRow2["EstimateOtherCostName"].ToString());
                    this.TotalEXcMarkup1 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup1"]);
                    this.TotalEXcMarkup2 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup2"]);
                    this.TotalEXcMarkup3 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup3"]);
                    this.TotalEXcMarkup4 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup4"]);
                    if (num10 == 1)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 16%'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both; font-style: bold;font-weight: bold;'>Product ", this.objLanguage.GetLanguageConversion("Additional_Items"), "</div>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 21%;", str1, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 21%;", str2, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 21%;", str3, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 21%;", str4, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    decimal num11 = Convert.ToDecimal(dataRow2["SelectedPrice1"]);
                    if (this.Item_Type.ToLower() == "x")
                    {
                        num11 = Convert.ToDecimal(dataRow2["CostPriceInMarkup1"]) - Convert.ToDecimal(dataRow2["MarkupValue1"]);
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 190px !important; clear: both; font-style: bold; padding-left: 15px;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Other Cost'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet' />")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext' style='width:170px; white-space: pre-wrap;'>"));

                    /////////////////
                    string displayHtml;
                    string estimateName = this.EstimateOtherCostName.Trim();

                    if (this.SelectedValue.Length > 100)
                    {
                        string shortText = this.SelectedValue.Substring(0, 100);
                        string uniqueId = Guid.NewGuid().ToString("N");

                        displayHtml = string.Format(@"<span style='font-weight: bold;'>{0}:</span><span id='short_{1}'>{2}<br /><a href='javascript:void(0);' onclick='toggleText(""{1}"")' style='color:blue; font-weight: bold;'>See more</a></span><span id='full_{1}' style='display:none;'>{3}<br /><a href='javascript:void(0);' onclick='toggleText(""{1}"")' style='color:blue; font-weight: bold;'>See less</a></span>",
       estimateName,uniqueId,shortText,this.SelectedValue);
                    }
                    else
                    {
                        displayHtml = string.Format("<span style='font-weight: bold;'>{0}:</span> {1}", estimateName, this.SelectedValue);
                    }
                    ////////////////

                    //string str18 = string.Concat("<span style='font-weight: bold;'>", this.EstimateOtherCostName.Trim(), ":</span> ", this.SelectedValue);
                    string str18 = displayHtml;
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span>", str18, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 21%;", str1, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal1' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 21%;", str2, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice2"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal2' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 21%;", str3, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice3"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal3' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 21%;", str4, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice4"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal4' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    num10++;
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trTotalCost'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Total_Cost"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup1 + (estimatesItem.CostPriceExMarkup1 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost2' style='text-align: right; width: 21%; ", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup2 + (estimatesItem.CostPriceExMarkup2 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup3 + (estimatesItem.CostPriceExMarkup3 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdTotalCost4' style='text-align: right; width: 21%; ", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup4 + (estimatesItem.CostPriceExMarkup4 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
            }
            else
            {

                object[] estimateItemID;
                string[] tblWidthMinWidth;
                char[] chrArray;
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                string empty = string.Empty;
                string str = string.Empty;
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
                }
                if (!base.IsPostBack)
                {
                    DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
                    item_summary_pricecatalogue_item.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
                }
                string empty1 = string.Empty;
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
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string str4 = "display:none";
                string strDimension1 = "display:none";
                string strDimension2 = "display:none";
                string strDimension3 = "display:none";
                string strDimension4 = "display:none";
                string strShow1 = "display:none";
                string strShow2 = "display:none";
                string strShow3 = "display:none";
                string strShow4 = "display:none";
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                int num = 0;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                decimal num1 = new decimal(0);
                EstimatesItem estimatesItem = new EstimatesItem();
                this.MeasurementValue = this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
                if (this.MeasurementValue != "In.")
                {
                    this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareMeter");
                }
                else
                {
                    this.MeasurementValue_Sq = this.objLanguage.GetLanguageConversion("SquareFeet");
                }
                foreach (DataRow row in EstimatesBasePage.estimate_price_catalogue_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    Convert.ToInt64(row["EstimateID"]);
                    long num2 = Convert.ToInt64(row["EstTypeID"]);
                    this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    empty3 = (!this.objBase.SpecialDecode(row["ItemTitle"].ToString()).Contains("<br/>") ? this.objBase.SpecialDecode(row["CatalogueName"].ToString()) : this.objBase.SpecialDecode(row["ItemTitle"].ToString()));
                    int num3 = Convert.ToInt32(row["Quantity"].ToString());
                    string str6 = row["QTYDescription"].ToString();
                    num1 = Convert.ToInt32(row["MultipleOf"]);
                    decimal num4 = Convert.ToDecimal(row["Markup"]);
                    decimal num5 = Convert.ToDecimal(row["Price"]);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    string str7 = row["MatrixType"].ToString();
                    estimatesItem.MatrixType = str7;
                    decimal num8 = Convert.ToDecimal(row["Height"]);
                    decimal num9 = Convert.ToDecimal(row["Width"]);
                    num = Convert.ToInt32(row["QtyNumber"]);
                    this.ArtfileLink1 = row["Artfile1"].ToString().Trim();
                    this.ArtfileLink2 = row["Artfile2"].ToString().Trim();
                    this.itemcode = this.objBase.SpecialDecode(row["ItemCode"].ToString());
                    if (this.Check_SpecialPrivilege)
                    {
                        empty1 = empty3;
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.IsFromActHist.ToLower() == "yes")
                        {
                            empty1 = string.Concat("<a href='#'>", this.objBase.SpecialDecode(empty3), "</a>");
                        }
                        else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
                        {
                            estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=catalogue&EstimateItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&TypeID=", num2, "&From=C&module=", this.Module, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                            empty1 = string.Concat(estimateItemID);
                        }
                        else
                        {
                            estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/order_popup.aspx?OrderItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&module=webstoreorder',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                            empty1 = string.Concat(estimateItemID);
                        }
                    }
                    else if (this.IsFromActHist.ToLower() == "yes")
                    {
                        empty1 = string.Concat("<a href='#'>", this.objBase.SpecialDecode(empty3), "</a>");
                    }
                    else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
                    {
                        estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=catalogue&EstimateItemID=", this.EstimateItemID, "&TypeID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&EstType=", this.EstType, "&From=C&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                        empty1 = string.Concat(estimateItemID);
                    }
                    else
                    {
                        estimateItemID = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/order_popup.aspx?OrderItemID=", this.EstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "&module=webstoreorder',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objBase.SpecialDecode(empty3), "</a>" };
                        empty1 = string.Concat(estimateItemID);
                    }
                    if (!string.IsNullOrEmpty(this.ArtfileLink1.Trim().ToString()) && this.ArtfileLink1.Trim().ToString().Length > 0)
                    {
                        this.Artfile1 = string.Concat("<a href='", this.ArtfileLink1, "' target='_blank' \"> Art file 1 </a>");
                    }
                    if (!string.IsNullOrEmpty(this.ArtfileLink2.Trim().ToString()) && this.ArtfileLink2.Trim().ToString().Length > 0)
                    {
                        this.Artfile2 = string.Concat("<a href='", this.ArtfileLink2, "' target='_blank' \"> Art file 2 </a>");
                    }
                    empty4 = (!Convert.ToBoolean(row["IsSides"]) ? "no" : "yes");
                    if (ConnectionClass.ServerName.ToLower() != "handyenvelopes" && ConnectionClass.ServerName.ToLower() != "handyexpress")
                    {
                        empty5 = num1.ToString();
                    }
                    else if (num1 != new decimal(2))
                    {
                        empty5 = "Single";
                    }
                    else
                    {
                        num1 = Convert.ToDecimal(1.5);
                        empty5 = "Double";
                    }
                    num6 = (num4 * num5) / new decimal(100);
                    num7 = num6 + num5;
                    if (num1 != new decimal(0))
                    {
                        num7 = num7 * num1;
                        num6 = num6 * num1;
                    }
                    estimatesItem.MultipleOf = num1;
                    if (this.Module.ToLower() != "estimate")
                    {
                        string empty12 = string.Empty;
                        empty12 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                        string empty13 = string.Empty;
                        empty13 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                        if (this.QtyNumber == 1)
                        {
                            strShow1 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension1 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension1 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 2)
                        {
                            strShow2 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension2 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension2 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 3)
                        {
                            strShow3 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension3 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension3 = "visibility:visible;";
                            }
                        }
                        else if (this.QtyNumber == 4)
                        {
                            strShow4 = "visibility:visible;";
                            if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                            {
                                strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                strDimension4 = "display:none;";
                            }
                            if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                            {
                                str4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                                //strDimension4 = "visibility:visible;";
                            }
                        }
                        if (num == 1)
                        {
                            estimatesItem.Qty1 = num3;
                            estimatesItem.Qtydesc1 = str6;
                            estimatesItem.CostPriceExMarkup1 = num5;
                            estimatesItem.MarkupPrice1 = num6;
                            estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension1 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension1 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width1 = num9;
                                estimatesItem.Height1 = num8;
                            }
                        }
                        else if (num == 2)
                        {
                            estimatesItem.Qty2 = num3;
                            estimatesItem.Qtydesc2 = str6;
                            estimatesItem.CostPriceExMarkup2 = num5;
                            estimatesItem.MarkupPrice2 = num6;
                            estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension2 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension2 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width2 = num9;
                                estimatesItem.Height2 = num8;
                            }
                        }
                        else if (num == 3)
                        {
                            estimatesItem.Qty3 = num3;
                            estimatesItem.Qtydesc3 = str6;
                            estimatesItem.CostPriceExMarkup3 = num5;
                            estimatesItem.MarkupPrice3 = num6;
                            estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension3 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension3 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width3 = num9;
                                estimatesItem.Height3 = num8;
                            }
                        }
                        else if (num == 4)
                        {
                            estimatesItem.Qty4 = num3;
                            estimatesItem.Qtydesc4 = str6;
                            estimatesItem.CostPriceExMarkup4 = num5;
                            estimatesItem.MarkupPrice4 = num6;
                            estimatesItem.CostPriceInMarkup4 = estimatesItem.CostPriceExMarkup4 + estimatesItem.MarkupPrice4;
                            if (str7.ToLower() == "g")
                            {
                                if (this.MeasurementValue != "In.")
                                {
                                    estimatesItem.Dimension4 = (num8 * num9) / new decimal(1000000);
                                }
                                else
                                {
                                    estimatesItem.Dimension4 = (num8 * num9) / new decimal(144);
                                }
                                estimatesItem.Width4 = num9;
                                estimatesItem.Height4 = num8;
                            }
                        }
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                    }
                    else if (num == 1)
                    {
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                        strShow1 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension1 = "display:none;";
                        }
                        str1 = "visibility:visible;";
                        estimatesItem.Qty1 = num3;
                        estimatesItem.Qtydesc1 = str6;
                        estimatesItem.CostPriceExMarkup1 = num5;
                        estimatesItem.MarkupPrice1 = num6;
                        estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension1 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension1 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width1 = num9;
                        estimatesItem.Height1 = num8;
                    }
                    else if (num == 2)
                    {
                        this.tblWidth = "62%";
                        this.tblWidth_MinWidth = "min-width:420px;";
                        strShow2 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension2 = "display:none;";
                        }
                        str2 = "visibility:visible;";
                        estimatesItem.Qty2 = num3;
                        estimatesItem.Qtydesc2 = str6;
                        estimatesItem.CostPriceExMarkup2 = num5;
                        estimatesItem.MarkupPrice2 = num6;
                        estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension2 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension2 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width2 = num9;
                        estimatesItem.Height2 = num8;
                    }
                    else if (num != 3)
                    {
                        if (num != 4)
                        {
                            continue;
                        }
                        this.tblWidth = "100%";
                        this.tblWidth_MinWidth = "min-width:550px;";
                        strShow4 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension4 = "display:none;";
                        }
                        str4 = "visibility:visible;";
                        estimatesItem.Qty4 = num3;
                        estimatesItem.Qtydesc4 = str6;
                        estimatesItem.CostPriceExMarkup4 = num5;
                        estimatesItem.MarkupPrice4 = num6;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension4 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension4 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width4 = num9;
                        estimatesItem.Height4 = num8;
                    }
                    else
                    {
                        this.tblWidth = "82%";
                        this.tblWidth_MinWidth = "min-width:520px;";
                        strShow3 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                        {
                            str3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            str3 = "display:none;";
                        }
                        strDimension3 = "visibility:visible;";
                        estimatesItem.Qty3 = num3;
                        estimatesItem.Qtydesc3 = str6;
                        estimatesItem.CostPriceExMarkup3 = num5;
                        estimatesItem.MarkupPrice3 = num6;
                        estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                        if (str7.ToLower() != "g")
                        {
                            continue;
                        }
                        if (this.MeasurementValue != "In.")
                        {
                            estimatesItem.Dimension3 = (num8 * num9) / new decimal(1000000);
                        }
                        else
                        {
                            estimatesItem.Dimension3 = (num8 * num9) / new decimal(144);
                        }
                        estimatesItem.Width3 = num9;
                        estimatesItem.Height3 = num8;
                    }
                }
                if (!this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Product Catalogue'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet'/>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(empty1 ?? ""));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon'>"));
                    string empty6 = string.Empty;
                    if (this.IsFromActHist.ToLower() == "yes")
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    }
                    else if (this.Module.ToLower() == "estimate")
                    {
                        if (!this.IsShowJobReRun)
                        {
                            estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            empty6 = string.Concat(estimateItemID);
                            empty = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isedit", this.Page.Request.Url.ToString());
                            str = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                            if (empty.Trim().ToLower() == "true" || empty == "")
                            {
                                ControlCollection controls = this.plhPriceCatalogueItem.Controls;
                                tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            if (str.Trim().ToLower() == "true" || str == "")
                            {
                                ControlCollection controlCollections = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                        }
                    }
                    else if (this.Module.ToLower() == "order")
                    {
                        this.ModuleType = "order";
                        if (!this.IsShowJobReRun)
                        {
                            estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            empty6 = string.Concat(estimateItemID);
                            empty = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isedit", this.Page.Request.Url.ToString());
                            str = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                            if (empty.Trim().ToLower() == "true" || empty == "")
                            {
                                ControlCollection controls1 = this.plhPriceCatalogueItem.Controls;
                                tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls1.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                            }
                            if (str.Trim().ToLower() == "true" || str == "")
                            {
                                ControlCollection controlCollections1 = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections1 = this.plhPriceCatalogueItem.Controls;
                                estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                        }
                    }
                    else if (this.Module.ToLower() != "job")
                    {
                        estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                        empty6 = string.Concat(estimateItemID);
                        empty = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isedit", this.Page.Request.Url.ToString());
                        str = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                        if (empty.Trim().ToLower() == "true" || empty == "")
                        {
                            ControlCollection controls2 = this.plhPriceCatalogueItem.Controls;
                            tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controls2.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        }
                        if (str.Trim().ToLower() == "true" || str == "")
                        {
                            ControlCollection controlCollections2 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else if (strRemove.Trim() == "1")
                        {
                            ControlCollection controlCollections2 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                    }
                    else if (!this.IsShowInvRerun)
                    {
                        estimateItemID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=C&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                        empty6 = string.Concat(estimateItemID);
                        empty = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isedit", this.Page.Request.Url.ToString());
                        str = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                        if (empty.Trim().ToLower() == "true" || empty == "")
                        {
                            ControlCollection controls3 = this.plhPriceCatalogueItem.Controls;
                            tblWidthMinWidth = new string[] { "<a href=", empty6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controls3.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        }
                        if (str.Trim().ToLower() == "true" || str == "")
                        {
                            ControlCollection controlCollections3 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else if (strRemove.Trim() == "1")
                        {
                            ControlCollection controlCollections3 = this.plhPriceCatalogueItem.Controls;
                            estimateItemID = new object[] { "<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", this.TypeID, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div id='div_subitemcode' class='bglabelItem_summary'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(this.itemcode ?? ""));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
                }
                else
                {
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
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table id='tblPriceCatalogueItem' width='100%' cellpadding='0' cellspacing='0' border='0' style='display:none'><tr id='trCatalogueName'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%' colspan='2'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogueLinkID' style='clear: both; padding-top:10px;'><b>", empty1, "</b></div><div style='clear:both;padding-top:5px'></div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<tr><td><b> ", this.itemcode, " </b> <div style='clear:both;padding-top:10px'></div></td></tr>")));
                    if (this.Module.ToLower() == "order" && this.Module.ToLower() == "job" && (ConnectionClass.ServerName.ToLower() == "smpaus" || ConnectionClass.ServerName.ToLower() == "smpaustest" || ConnectionClass.ServerName.ToLower().Contains("prelive")))
                    {
                        this.Item_Type = EstimatesBasePage.GetEstimateType_EstimateItemID(this.EstimateItemID);
                        if (this.Item_Type.ToLower() == "x")
                        {
                            if (!string.IsNullOrEmpty(this.Artfile1.Trim().ToString()) && this.Artfile1.ToString().Length > 0)
                            {
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl_ArtFile1' style='width: 16%' colspan='2'>"));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogue_ArtFile1' style='clear: both;'><b>", this.Artfile1, "</b></div>")));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                            }
                            if (!string.IsNullOrEmpty(this.Artfile2.Trim().ToString()) && this.Artfile2.ToString().Length > 0)
                            {
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl_ArtFile2' style='width: 16%' colspan='2'>"));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div id='div_PriceCatalogue_ArtFile1' style='clear: both;'><b>", this.Artfile2, "</b></div>")));
                                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td></tr>"));
                            }
                        }
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                }
                if (!this.IsParentItem || !(this.ModuleType.ToLower() == "order"))
                {
                    DataTable dataTable1 = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
                    if (this.IsParentItem && Convert.ToBoolean(dataTable1.Rows[0]["AllowPrintReadyFile"]))
                    {
                        DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems1(this.EstimateItemID);
                        DataTable item = dataSet.Tables[0];
                        DataTable item1 = dataSet.Tables[2];
                        string empty7 = string.Empty;
                        string empty8 = string.Empty;
                        string str8 = string.Empty;
                        string empty9 = string.Empty;
                        string str9 = string.Empty;
                        string empty10 = string.Empty;
                        string str10 = string.Empty;
                        bool flag = false;
                        bool flag1 = false;
                        string empty11 = string.Empty;
                        string str11 = string.Empty;
                        string empty12 = string.Empty;
                        string str12 = string.Empty;
                        foreach (DataRow dataRow in item.Rows)
                        {
                            dataRow["JobName"].ToString();
                            str8 = dataRow["PDFNameFromCart"].ToString();
                            dataRow["PrintReadyFile"].ToString();
                            dataRow["CatalogueName"].ToString();
                            this.AccountID = Convert.ToInt32(dataRow["AccountID"]);
                            str11 = dataRow["OriginalNamePdfFromcart"].ToString();
                        }
                        int count = item1.Rows.Count;
                        if (count != 0)
                        {

                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' style='display:none' cellpadding='0' cellspacing='0' border='0'>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                            stringBuilder.Append(string.Concat("<div style='float:left;'>Artwork File(s) (", count, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments_Order();' title='Attachments'></div></div>"));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(string.Concat("<div id='div_Summary_Attachments_", this.EstimateItemID, "' style='display:none;width:100%;height:15px;border:solid 0px green;'>"));
                            stringBuilder.Append("<div style='width:50%;border:solid 0px;float:left;'>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(string.Concat("<div id='div_Detail_Attachments_", this.EstimateItemID, "' style='display:block;width:100%;border:solid 0px green;'>"));
                            stringBuilder.Append("<div style='width:50%;border:solid 0px;float:left;margin-left:20px;'>");
                            foreach (DataRow row1 in item1.Rows)
                            {
                                str9 = row1["FileName"].ToString();
                                empty10 = row1["OriginalFileName"].ToString();
                                str10 = row1["ReportFileName"].ToString();
                                flag = Convert.ToBoolean(row1["isEdtiablePDF"]);
                                flag1 = Convert.ToBoolean(row1["IsPrintReadyFile"]);
                                Convert.ToBoolean(row1["IsFromStoreAttach"]);
                                empty12 = row1["PreviewType"].ToString();
                                str12 = row1["ImageNameFromCart"].ToString();
                                tblWidthMinWidth = new string[] { global.SecureSitePath(), this.serverName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                                empty11 = string.Concat(tblWidthMinWidth);
                                if (flag && (empty12.ToLower() == "pdf" || empty12.ToLower() == "pdfimg"))
                                {
                                    estimateItemID = new object[] { "<div><a id='lblPdfName' style='color:#103593;cursor:pointer;' onclick=javascript:OpenAttach('", str8, "','", this.serverName, "',", this.CompanyID, ",'", global.SecureSitePath(), "');>", str11, "</a></div>" };
                                    stringBuilder.Append(string.Concat(estimateItemID));
                                }
                                else if (!flag1)
                                {
                                    tblWidthMinWidth = new string[] { "<div '><a href='", empty11, str9, "' target='_blank'>", empty10, "</a>" };
                                    stringBuilder.Append(string.Concat(tblWidthMinWidth));
                                    if (str10 != "")
                                    {
                                        stringBuilder.Append(string.Concat("<br><a href='", empty11, str10, "' target='_blank'>Report File.pdf</a>"));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                else
                                {
                                    stringBuilder.Append("<div>");
                                    estimateItemID = new object[] { "<a id='lblPrintReadyFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", str9, "\",", this.CompanyID, ");'>", empty10, "</a>" };
                                    stringBuilder.Append(string.Concat(estimateItemID));
                                    if (str10 != "")
                                    {
                                        estimateItemID = new object[] { "<br><a id='lblPRReportFile' style='color:#103593;cursor:pointer;' onclick='javascript:PrintReady_Open(\"", str10, "\",", this.CompanyID, ");'>Report File.pdf</a>" };
                                        stringBuilder.Append(string.Concat(estimateItemID));
                                    }
                                    stringBuilder.Append("</div>");
                                }
                                if (!(empty12.ToLower() == "pdfimg") && !(empty12.ToLower() == "img"))
                                {
                                    continue;
                                }
                                if (empty10.Contains(".pdf"))
                                {
                                    chrArray = new char[] { '.' };
                                    string[] strArrays = empty10.Split(chrArray);
                                    empty10 = string.Concat(strArrays[0], ".png");
                                }
                                this.PDFToURLPath = global.SecureSitePath();
                                this.Imgpreview.Attributes.Add("onclick", string.Concat("javascript:downloadImage_click(", this.AccountID, ")"));
                                this.Imgpreview.Attributes.Add("src", string.Concat(" ", this.strImagepath, "downloadImage.png"));
                                stringBuilder.Append("<div>");
                                estimateItemID = new object[] { "<a id='lblImage' style='color:#103593;cursor:pointer;'  onclick='javascript:Pdf_ImagPopup(\"", str12, "\",", this.AccountID, ",\"", global.SecureSitePath(), "\");'>", empty10, "</a>" };
                                stringBuilder.Append(string.Concat(estimateItemID));
                                stringBuilder.Append("</div>");
                            }
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("<div style='padding-bottom:10px;' class='onlyEmpty'></div>");
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder.ToString(), "</span>")));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                            this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));

                        }
                    }
                    ControlCollection controls4 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<table id='tblPriceCatalogueItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0'  style='display:none;", this.tblWidth_MinWidth, "'>" };
                    controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                }
                else
                {
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
                    foreach (DataRow dataRow1 in item2.Rows)
                    {
                        empty13 = dataRow1["JobName"].ToString();
                        empty14 = dataRow1["PDFNameFromCart"].ToString();
                        dataRow1["PrintReadyFile"].ToString();
                        dataRow1["CatalogueName"].ToString();
                        this.AccountID = Convert.ToInt32(dataRow1["AccountID"]);
                        empty17 = dataRow1["OriginalNamePdfFromcart"].ToString();
                    }
                    int count1 = dataTable2.Rows.Count;
                    if (count1 != 0)
                    {

                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                        StringBuilder stringBuilder1 = new StringBuilder();
                        stringBuilder1.Append("<div class='bglabel' style='width:200px;border:solid 0px blue;float:left;'>");
                        stringBuilder1.Append(string.Concat("<div style='float:left;'>Artwork File(s) (", count1, " Attachments) </div><div align='right' ><img src='../images/plus.gif' style='cursor:pointer;' onclick='ShowAttachments_Order();' title='Attachments'></div></div>"));
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
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    ControlCollection controlCollections4 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<table id='tblPriceCatalogueItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='display:none;", this.tblWidth_MinWidth, "'>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Job_Name"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", empty13, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; width: 21%;", str3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td style='text-align: right; width: 21%;", str4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<span CssClass='normalText'></span>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;", strShow1, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%;", strShow2, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%;", strShow3, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%;", strShow4, ";'>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));

                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                if (estimatesItem.MatrixType.ToLower() == "g")
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trDimension'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    ControlCollection controls5 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 200px; clear: both'>", this.objLanguage.GetLanguageConversion("Area"), " (", this.MeasurementValue_Sq, ")</div>" };
                    controls5.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension1, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension1, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension2, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension2, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%;", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension3, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension3, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension4, 0, "", false, false, true, false, true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Dimension4, 0, "", false, false, true, false, true), "</span>")));

                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trWidth'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 200px; margin-top:-2; clear: both'>", this.objLanguage.GetLanguageConversion("Dimension_Summary_Page"), this.MeasurementValue, "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth1' style='text-align: right; width: 21%;", strDimension1, ";'>")));
                    ControlCollection controlCollections5 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth1' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width1, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height1, 0, "", false, false, true, false, true), "</span>" };
                    controlCollections5.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    ControlCollection controls6 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth2' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width2, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height2, 0, "", false, false, true, false, true), "</span>" };
                    controls6.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWidth3' style='text-align: right; width: 21%;", strDimension3, ";'>")));
                    ControlCollection controlCollections6 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth3' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width3, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height3, 0, "", false, false, true, false, true), "</span>" };
                    controlCollections6.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdWidth4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    ControlCollection controls7 = this.plhPriceCatalogueItem.Controls;
                    tblWidthMinWidth = new string[] { "<span ID='spnWidth4' CssClass='normalText' >", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Width4, 0, "", false, false, true, false, true), " X ", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.Height4, 0, "", false, false, true, false, true), "</span>" };
                    controls7.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem && ((ConnectionClass.ServerName.ToLower() == "handyenvelopes" || ConnectionClass.ServerName.ToLower() == "handyexpress") && empty4 == "yes" || estimatesItem.MultipleOf > new decimal(0)))
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trMultipleOf'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    if (ConnectionClass.ServerName.ToLower() == "handyenvelopes" || ConnectionClass.ServerName.ToLower() == "handyexpress")
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Sides"), "</div>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Multiple_Of"), "</div>")));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdMultipleOf1' style='text-align: right; width: 21%;", strShow1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf1' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%;", strShow2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf2' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%;", strShow3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf3' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", strShow4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMultipleOf4' CssClass='normalText'>", empty5, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trQtydescription'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow1, "'>")));
                    ControlCollection controlCollections7 = this.plhPriceCatalogueItem.Controls;
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
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow2, "'>")));
                    ControlCollection controls8 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow3, "'>")));
                    ControlCollection controlCollections8 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", strShow4, "'>")));
                    ControlCollection controls9 = this.plhPriceCatalogueItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (!this.Check_SpecialPrivilege && !(ConnectionClass.ServerName.ToLower() == "handyenvelopes") && !(ConnectionClass.ServerName.ToLower() == "handyexpress"))
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trCostforeachset'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width:16%'>"));
                    if (!this.IsParentItem)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 150px; clear: both'>Price</div>"));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 150px; clear: both'>Cost for each set</div>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset2' style='text-align: right; width: 21%;", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdCostforeachset3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdCostforeachset4' style='text-align: right; width: 21%;", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnCostforeachset4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                int num10 = 1;
                this.Item_Type = EstimatesBasePage.GetEstimateType_EstimateItemID(this.EstimateItemID);
                DataTable dataTable3 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
                foreach (DataRow dataRow2 in dataTable3.Rows)
                {
                    this.EstimateAdditionalItemID = Convert.ToInt64(dataRow2["EstimateAdditionalItemID"]);
                    this.CalculationType = Convert.ToString(dataRow2["CalculationType"]);
                    this.SelectedID = Convert.ToInt64(dataRow2["SelectedID"]);
                    this.SelectedValue = this.objBase.SpecialDecode(dataRow2["SelectedValue"].ToString());
                    this.SelectedValue = this.SelectedValue.Replace("¶Yes", "");
                    this.SelectedValue = this.SelectedValue.Replace("¶No", "");
                    this.SortOrderNo = Convert.ToInt32(dataRow2["SortOrderNo"]);
                    this.EstimateOtherCostName = this.objBase.SpecialDecode(dataRow2["EstimateOtherCostName"].ToString());
                    this.TotalEXcMarkup1 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup1"]);
                    this.TotalEXcMarkup2 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup2"]);
                    this.TotalEXcMarkup3 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup3"]);
                    this.TotalEXcMarkup4 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup4"]);
                    if (num10 == 1)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 16%'>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both; font-style: bold;font-weight: bold;'>Product ", this.objLanguage.GetLanguageConversion("Additional_Items"), "</div>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 21%;", str1, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 21%;", str2, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 21%;", str3, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 21%;", str4, ";'>")));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    decimal num11 = Convert.ToDecimal(dataRow2["SelectedPrice1"]);
                    if (this.Item_Type.ToLower() == "x")
                    {
                        num11 = Convert.ToDecimal(dataRow2["CostPriceInMarkup1"]) - Convert.ToDecimal(dataRow2["MarkupValue1"]);
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 190px !important; clear: both; font-style: bold; padding-left: 15px;'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Other Cost'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet' />")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext' style='width:170px; white-space: pre-wrap;'>"));
                    string str18 = string.Concat(this.EstimateOtherCostName.Trim(), ": ", this.SelectedValue);
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span>", str18, "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 21%;", str1, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num11, 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal1' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 21%;", str2, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice2"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal2' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 21%;", str3, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice3"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal3' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 21%;", str4, ";'>")));
                    if (!(dataRow2["ParentWebOtherCostID"].ToString() == "0") || !(dataRow2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["SelectedPrice4"]), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    else
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPriceCatAddOptCostTotal4' style='display:none;' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, new decimal(0), 0, "", false, false, true, false, true), true), "</span>")));
                    }
                    if (dataTable3.Rows.Count == num10)
                    {
                        this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<br/>"));
                    }
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                    num10++;
                }
                if (this.IsParentItem)
                {
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<tr id='trTotalCost'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Total_Cost"), "</div>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup1 + (estimatesItem.CostPriceExMarkup1 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost2' style='text-align: right; width: 21%; ", strDimension2, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup2 + (estimatesItem.CostPriceExMarkup2 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdTotalCost3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup3 + (estimatesItem.CostPriceExMarkup3 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdTotalCost4' style='text-align: right; width: 21%; ", strDimension4, ";'>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnTotalCost4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalEXcMarkup4 + (estimatesItem.CostPriceExMarkup4 * num1), 0, "", false, false, true, false, true), true), "</span>")));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</tr>"));
                }
                this.plhPriceCatalogueItem.Controls.Add(new LiteralControl("</table>"));
            }
        }
    }
}