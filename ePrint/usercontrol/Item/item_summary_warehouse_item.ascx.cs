using nmsCommon;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.EstimatesNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_warehouse_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhWarehouseItem;

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

        public long jobID;

        public long TypeID;

        public long ParentEstimateItemID;

        public bool IsParentItem;

        public bool Check_SpecialPrivilege;

        public bool IsShowDelete;

        public bool IsItemCopied;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string IsFrom = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public string SalesPersonID = string.Empty;

        public static string IsEditOnlyHisRecords;

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

        static item_summary_warehouse_item()
        {
            item_summary_warehouse_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_warehouse_item()
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
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = "display:none";
                string str6 = "display:none";
                string str7 = "display:none";
                string str8 = "display:none";
                string showSubItems = "display:none";

                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFrom = base.Request.Params["acthist"].ToString();
                }
                if (this.Module.ToLower() != "estimate")
                {
                    if (this.QtyNumber == 1)
                    {
                        str1 = "visibility:visible;";
                    }
                    else if (this.QtyNumber != 2 && this.QtyNumber != 3)
                    {
                        int qtyNumber = this.QtyNumber;
                        str8 = "visibility:visible;";
                    }
                    else if (this.QtyNumber == 2)
                    {
                        str6 = "visibility:visible;";
                    }
                    else if (this.QtyNumber == 3)
                    {
                        str7 = "visibility:visible;";
                    }
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                }
                else if (this.QtyCount == 1)
                {
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                    str1 = "visibility:visible;";
                }
                else if (this.QtyCount == 2)
                {
                    this.tblWidth = "62%";
                    this.tblWidth_MinWidth = "min-width:420px;";
                    str1 = "visibility:visible;";
                    str6 = "visibility:visible;";
                }
                else if (this.QtyCount == 3)
                {
                    this.tblWidth = "82%";
                    this.tblWidth_MinWidth = "min-width:520px;";
                    str1 = "visibility:visible;";
                    str6 = "visibility:visible;";
                    str7 = "visibility:visible;";
                }
                else if (this.QtyCount == 4)
                {
                    this.tblWidth = "100%";
                    this.tblWidth_MinWidth = "min-width:550px;";
                    str1 = "visibility:visible;";
                    str6 = "visibility:visible;";
                    str7 = "visibility:visible;";
                    str8 = "visibility:visible;";

                }
                long num = (long)0;
                string str2 = "";
                string empty2 = string.Empty;
                if (base.Request.Url.ToString().Contains("InvID") && base.Request.QueryString["InvID"] != "")
                {
                    empty2 = string.Concat("&InvID=", base.Request.QueryString["InvID"].ToString());
                }
                if (base.Request.Url.ToString().Contains("jID") && base.Request.QueryString["jID"] != "")
                {
                    str2 = string.Concat("&jID=", base.Request.QueryString["jID"].ToString());
                    this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
                }
                if (base.Request.Url.ToString().Contains("estid") && base.Request.QueryString["estid"] != "")
                {
                    num = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
                }
                foreach (DataRow row in EstimatesBasePage.estimate_warehouse_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    long num1 = Convert.ToInt64(row["EstTypeID"]);

                    EstimatesItem estimatesItem = new EstimatesItem();

                    estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.CostPriceExMarkup1 = Convert.ToDecimal(row["CostPriceExMarkup"]);
                    estimatesItem.MarkupPrice1 = Convert.ToDecimal(row["MarkupPrice"]);
                    estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;

                    int Qty2 = Convert.ToInt32(row["Quantity2"]);
                    Decimal CostPriceExMarkup2 = Convert.ToDecimal(row["CostPriceExMarkup2"]);
                    Decimal MarkupPrice2 = Convert.ToDecimal(row["MarkupPrice2"]);
                    Decimal CostPriceInMarkup2 = CostPriceExMarkup2 + MarkupPrice2;

                    int Qty3 = Convert.ToInt32(row["Quantity3"]);
                    Decimal CostPriceExMarkup3 = Convert.ToDecimal(row["CostPriceExMarkup3"]);
                    Decimal MarkupPrice3 = Convert.ToDecimal(row["MarkupPrice3"]);
                    Decimal CostPriceInMarkup3 = CostPriceExMarkup3 + MarkupPrice3;

                    int Qty4 = Convert.ToInt32(row["Quantity4"]);
                    Decimal CostPriceExMarkup4 = Convert.ToDecimal(row["CostPriceExMarkup4"]);
                    Decimal MarkupPrice4 = Convert.ToDecimal(row["MarkupPrice4"]);
                    Decimal CostPriceInMarkup4 = CostPriceExMarkup4 + MarkupPrice4;



                    string str3 = row["ItemTitle_New"].ToString();
                    string str4 = this.objBase.SpecialDecode(row["WarehouseName"].ToString());
                    str3 = str4;
                    string empty3 = string.Empty;
                    if (this.Check_SpecialPrivilege)
                    {
                        empty3 = str4;
                    }
                    else if (this.IsFrom.ToLower() != "yes")
                    {
                        object[] estimateItemID;
                        if (this.Module.ToLower() != "estimate")
                        {
                            estimateItemID = new object[] { "<a href='#' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=warehouse&EstimateItemID=", this.EstimateItemID, "&TypeID=", row["EstWarehouseItemID"].ToString(), "&From=W&EstimateID=", num, "&module=", this.Module, str2, empty2, "&QtyNumber=", this.QtyNumber, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str4, "</a>" };
                        }
                        else
                        {
                            estimateItemID = new object[] { "<a href='#' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=warehouse&EstimateItemID=", this.EstimateItemID, "&TypeID=", row["EstWarehouseItemID"].ToString(), "&From=W&EstimateID=", num, "&module=", this.Module, str2, empty2, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", str4, "</a>" };
                        }
                        empty3 = string.Concat(estimateItemID);
                    }
                    else
                    {
                        empty3 = string.Concat("<a href='#'>", str4, "</a>");
                    }
                    if (!this.IsParentItem)
                    {
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<td style='width: 16%;padding-top:5px'>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<div style='float: left;width: 140px;'>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<b>Inventory</b></div>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<div style='float: left' align='right'>"));
                        object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_warehouse.aspx?type=edit&estid=", num, "&EstItemID=", this.EstimateItemID, "&esttype=W&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                        string str5 = string.Concat(objArray);
                        ControlCollection controls = this.plhWarehouseItem.Controls;
                        object[] estType = new object[] { "<a href=", str5, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", num, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                        controls.Add(new LiteralControl(string.Concat(estType)));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</table>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:10px'></div>"));
                    }
                    else
                    {
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both; '>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str3, "</b></div><div style='clear:both;padding-top:10px'></div>")));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhWarehouseItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    ControlCollection controlCollections = this.plhWarehouseItem.Controls;
                    string[] tblWidthMinWidth = new string[] { "<table id='tblQuickQuoteItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controlCollections.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right;white-space: nowrap; width:21%; border:0px solid red; ", str1, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "'  CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right;white-space: nowrap; width:21%; border:0px solid red; ", str6, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "'   CssClass='normalText'>", Qty2, "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right;white-space: nowrap; width:21%; border:0px solid red; ", str7, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "'   CssClass='normalText'>", Qty3, "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty4' style='text-align: right;white-space: nowrap; width:21%; border:0px solid red; ", str8, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "'  CssClass='normalText'>", Qty4, "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<tr id='trQtydescription' style='display:none'>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc1' style='text-align: right;white-space: nowrap; width:100%; border:0px solid red; ", str1, "'>")));
                    ControlCollection controls1 = this.plhWarehouseItem.Controls;
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
                        object[] estimateItemID1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; margin-right:-10px;' value='", estimatesItem.Qtydesc1, "' />" };
                        controls1.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; margin-right:-10px;' value='", estimatesItem.Qtydesc1, "' />" };
                        controls1.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdQtydesc2' style='text-align: right; width: 21%;'>&nbsp;"));
                    ControlCollection controlCollections1 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdQtydesc3' style='text-align: right; width: 21%;'>&nbsp;"));
                    ControlCollection controls2 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls2.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls2.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdQtydesc4' style='text-align: right; width: 21%;'>&nbsp;"));
                    ControlCollection controlCollections2 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections2.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections2.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
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
                        if (this.QtyNumber == 0)
                        {
                            str1 = showSubItems;
                        }
                    }
                    else
                    {
                        showSubItems = "visibility: visible;";
                    }
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                    //this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPrice' style='", showSubItems, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty3, "</div>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice1' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup1, 0, "", false, false, false, false, false),true), "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice2' style='text-align: right; width: 21%; ", str6, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CostPriceInMarkup2, 0, "", false, false, false, false, false),true), "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice3' style='text-align: right; width: 21%; ", str7, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice3'  CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CostPriceInMarkup3, 0, "", false, false, false, false, false),true), "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice4' style='text-align: right; width: 21%; ", str8, "'>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CostPriceInMarkup4, 0, "", false, false, false, false, false),true), "</span>")));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhWarehouseItem.Controls.Add(new LiteralControl("</table>"));
                }
            }
            else
            {
                ControlCollection controls1 = this.plhWarehouseItem.Controls;
                foreach (DataRow row in EstimatesBasePage.estimate_warehouse_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
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
                        object[] estimateItemID1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; margin-right:-10px;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls1.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; margin-right:-10px;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls1.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    ControlCollection controlCollections1 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    ControlCollection controls2 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls2.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls2.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    ControlCollection controlCollections2 = this.plhWarehouseItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections2.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right; display: none;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections2.Add(new LiteralControl(string.Concat(objArray2)));
                    }

                }
            }
        }
    }
}