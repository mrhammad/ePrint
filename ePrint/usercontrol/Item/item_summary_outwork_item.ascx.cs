using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.EstimatesNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_outwork_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhOutworkItem;

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

        public bool IsShowDelete;

        public bool IsShowCol1;

        public bool IsShowCol2;

        public bool IsShowCol3;

        public bool IsShowCol4;

        public bool IsShowOW1;

        public bool IsShowOW2;

        public bool IsShowOW3;

        public bool IsShowOW4;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string IsFromActHist = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public string SupplierQuoteWidth = string.Empty;

        public static string IsEditOnlyHisRecords;

        public string SalesPersonID = string.Empty;

        public int Count_Item;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        static item_summary_outwork_item()
        {
            item_summary_outwork_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_outwork_item()
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
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
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
                string empty = string.Empty;
                string str = "display:none";
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string showSuppliername = "display:none";
                string showPrice = "display:none";
                string showSubItems = "display:none";
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                int num = 0;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                long num1 = (long)0;
                EstimatesItem estimatesItem = new EstimatesItem();
                foreach (DataRow row in EstimatesBasePage.estimate_outwork_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    num1 = Convert.ToInt64(row["EstTypeID"]);
                    empty1 = this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    row["ItemTitle"].ToString();
                    num = Convert.ToInt32(row["QuantityNumber"]);
                    row["CostingType"].ToString();
                    decimal num2 = new decimal(0);
                    num2 = (row["CostingType"].ToString().ToLower() != "u" ? Convert.ToDecimal(row["Cost"]) + Convert.ToDecimal(row["DeliveryCost"]) : (Convert.ToDecimal(row["Cost"]) * Convert.ToDecimal(row["Quantity"])) + Convert.ToDecimal(row["DeliveryCost"]));
                    decimal num3 = new decimal(0);
                    decimal num4 = Convert.ToDecimal(row["MarkupValue"]);
                    num3 = (string.Compare(row["MarkUpType"].ToString(), "P", true) != 0 ? num4 : (num2 * num4) / new decimal(100));
                    if (this.Module.ToLower() != "estimate")
                    {
                        if (this.QtyNumber == 1)
                        {
                            str = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 2)
                        {
                            str1 = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 3)
                        {
                            str2 = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 4)
                        {
                            str3 = "visibility:visible;";
                        }
                        if (num == 1)
                        {
                            estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc1 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName1 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo1 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost1 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType1 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup1 = num2;
                            estimatesItem.MarkupPrice1 = num3;
                            estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                        }
                        else if (num == 2)
                        {
                            estimatesItem.Qty2 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc2 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName2 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo2 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost2 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType2 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup2 = num2;
                            estimatesItem.MarkupPrice2 = num3;
                            estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                        }
                        else if (num == 3)
                        {
                            estimatesItem.Qty3 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc3 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName3 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo3 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost3 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType3 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup3 = num2;
                            estimatesItem.MarkupPrice3 = num3;
                            estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                        }
                        else if (num == 4)
                        {
                            estimatesItem.Qty4 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc4 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName4 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo4 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost4 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType4 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup4 = num2;
                            estimatesItem.MarkupPrice4 = num3;
                            estimatesItem.CostPriceInMarkup4 = estimatesItem.CostPriceExMarkup4 + estimatesItem.MarkupPrice4;
                        }
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                    }
                    else if (Convert.ToInt32(row["QuantityNumber"]) == 1)
                    {
                        this.QtyCount = Convert.ToInt32(row["Quantity"]);
                        this.IsShowOW1 = Convert.ToBoolean(row["IsSelected"]);
                        if (this.IsShowOW1)
                        {
                            if (this.IsParentItem)
                            {
                                str = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 1 || this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str = "visibility:visible;";
                            }
                            estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc1 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName1 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo1 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost1 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType1 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup1 = num2;
                            estimatesItem.MarkupPrice1 = num3;
                            estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                        }
                        else if (row["SupplierSelected"].ToString().ToLower() == "no")
                        {
                            if (this.IsParentItem)
                            {
                                str = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 1 || this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str = "visibility:visible;";
                            }
                            estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc1 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName1 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo1 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost1 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType1 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup1 = num2;
                            estimatesItem.MarkupPrice1 = num3;
                            estimatesItem.CostPriceInMarkup1 = estimatesItem.CostPriceExMarkup1 + estimatesItem.MarkupPrice1;
                        }
                        if (this.IsParentItem)
                        {
                            this.tblWidth = "42%";
                            this.tblWidth_MinWidth = "min-width:320px;";
                            this.SupplierQuoteWidth = "500px;";
                        }
                        else if (this.ParentQtyCount == 1 || this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                        {
                            this.tblWidth = "42%";
                            this.tblWidth_MinWidth = "min-width:320px;";
                        }
                    }
                    else if (Convert.ToInt32(row["QuantityNumber"]) == 2)
                    {
                        this.QtyCount = Convert.ToInt32(row["Quantity"]);
                        this.IsShowOW2 = Convert.ToBoolean(row["IsSelected"]);
                        if (this.IsShowOW2)
                        {
                            if (this.IsParentItem)
                            {
                                str1 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str1 = "visibility:visible;";
                            }
                            estimatesItem.Qty2 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc2 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName2 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo2 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost2 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType2 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup2 = num2;
                            estimatesItem.MarkupPrice2 = num3;
                            estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                        }
                        else if (row["SupplierSelected"].ToString().ToLower() == "no")
                        {
                            if (this.IsParentItem)
                            {
                                str1 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str1 = "visibility:visible;";
                            }
                            estimatesItem.Qty2 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc2 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName2 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo2 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost2 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType2 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup2 = num2;
                            estimatesItem.MarkupPrice2 = num3;
                            estimatesItem.CostPriceInMarkup2 = estimatesItem.CostPriceExMarkup2 + estimatesItem.MarkupPrice2;
                        }
                        if (this.IsParentItem)
                        {
                            this.tblWidth = "62%";
                            this.tblWidth_MinWidth = "min-width:420px;";
                            this.SupplierQuoteWidth = "500px;";
                        }
                        else if (this.ParentQtyCount == 2 || this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                        {
                            this.tblWidth = "62%";
                            this.tblWidth_MinWidth = "min-width:420px;";
                        }
                    }
                    else if (Convert.ToInt32(row["QuantityNumber"]) == 3)
                    {
                        this.QtyCount = Convert.ToInt32(row["Quantity"]);
                        this.IsShowOW3 = Convert.ToBoolean(row["IsSelected"]);
                        if (this.IsShowOW3)
                        {
                            if (this.IsParentItem)
                            {
                                str2 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str2 = "visibility:visible;";
                            }
                            estimatesItem.Qty3 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc3 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName3 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo3 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost3 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType3 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup3 = num2;
                            estimatesItem.MarkupPrice3 = num3;
                            estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                        }
                        else if (row["SupplierSelected"].ToString().ToLower() == "no")
                        {
                            if (this.IsParentItem)
                            {
                                str2 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                            {
                                str2 = "visibility:visible;";
                            }
                            estimatesItem.Qty3 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc3 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName3 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo3 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost3 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType3 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup3 = num2;
                            estimatesItem.MarkupPrice3 = num3;
                            estimatesItem.CostPriceInMarkup3 = estimatesItem.CostPriceExMarkup3 + estimatesItem.MarkupPrice3;
                        }
                        if (this.IsParentItem)
                        {
                            this.tblWidth = "82%";
                            this.tblWidth_MinWidth = "min-width:520px;";
                            this.SupplierQuoteWidth = "300px;";
                        }
                        else if (this.ParentQtyCount == 3 || this.ParentQtyCount == 4)
                        {
                            this.tblWidth = "82%";
                            this.tblWidth_MinWidth = "min-width:520px;";
                        }
                    }
                    else if (Convert.ToInt32(row["QuantityNumber"]) == 4)
                    {
                        this.QtyCount = Convert.ToInt32(row["Quantity"]);
                        this.IsShowOW4 = Convert.ToBoolean(row["IsSelected"]);
                        if (this.IsShowOW4)
                        {
                            if (this.IsParentItem)
                            {
                                str3 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 4)
                            {
                                str3 = "visibility:visible;";
                            }
                            estimatesItem.Qty4 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc4 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName4 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo4 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost4 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType4 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup4 = num2;
                            estimatesItem.MarkupPrice4 = num3;
                            estimatesItem.CostPriceInMarkup4 = estimatesItem.CostPriceExMarkup4 + estimatesItem.MarkupPrice4;
                        }
                        else if (row["SupplierSelected"].ToString().ToLower() == "no")
                        {
                            if (this.IsParentItem)
                            {
                                str3 = "visibility:visible;";
                            }
                            else if (this.ParentQtyCount == 4)
                            {
                                str3 = "visibility:visible;";
                            }
                            estimatesItem.Qty4 = Convert.ToInt32(row["Quantity"]);
                            estimatesItem.Qtydesc4 = row["QTYDescription"].ToString();
                            estimatesItem.SupplierName4 = row["SupplierName"].ToString();
                            estimatesItem.SupplierQuoteNo4 = row["SupplierRefNo"].ToString();
                            estimatesItem.OutworkDeliveryCost4 = Convert.ToDecimal(row["DeliveryCost"]);
                            estimatesItem.OutworkMarkupType4 = row["MarkupType"].ToString();
                            estimatesItem.CostPriceExMarkup4 = num2;
                            estimatesItem.MarkupPrice4 = num3;
                            estimatesItem.CostPriceInMarkup4 = estimatesItem.CostPriceExMarkup4 + estimatesItem.MarkupPrice4;
                        }
                        if (this.IsParentItem)
                        {
                            this.tblWidth = "100%";
                            this.tblWidth_MinWidth = "min-width:550px;";
                            this.SupplierQuoteWidth = "300px;";
                        }
                        else if (this.ParentQtyCount == 4)
                        {
                            this.tblWidth = "100%";
                            this.tblWidth_MinWidth = "min-width:550px;";
                        }
                    }
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = empty1;
                    }
                    else if (this.IsFromActHist.ToLower() != "yes")
                    {
                        estimateItemID = new object[] { "<a href='javascript://' name='SPLOut' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=SPL&EstimateItemID=", this.EstimateItemID, "&TypeID=0&EstType=O&From=IO&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&EstimateID=", this.EstimateID, this.jID, this.InvID, "',null,1000,500).setSize(1035, 555);SetRadWindow('divrad', 'divBackGroundNew', '200');\"> ", empty1, "</a>" };
                        empty = string.Concat(estimateItemID);
                    }
                    else
                    {
                        empty = string.Concat("<a href='#' name='SPLOut'> ", empty1, "</a>");
                    }
                }
                if (!this.IsParentItem)
                {
                    ControlCollection controls = this.plhOutworkItem.Controls;
                    string[] tblWidthMinWidth = new string[] { "<table width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='clear: both;", this.tblWidth_MinWidth, "'>" };
                    controls.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<td align='left' style='width: 100%;'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Outwork'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet' />")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<div>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span >", empty, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon' style='margin-left:0px;'>"));
                    string empty3 = string.Empty;
                    if (this.IsFromActHist.ToLower() == "yes")
                    {
                        this.plhOutworkItem.Controls.Add(new LiteralControl("&nbsp;"));
                    }
                    else if (this.Module.ToLower() == "estimate")
                    {
                        if (!this.IsShowJobReRun)
                        {
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=O&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&sectionid=0&maintype=edit" };
                            empty3 = string.Concat(estimateID);
                            string str4 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                            if (str4.ToLower() == "true" || str4 == "")
                            {
                                ControlCollection controlCollections = this.plhOutworkItem.Controls;
                                string[] strArrays = new string[] { "&nbsp;<a href=", empty3, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                            }
                            string str5 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                            if (str5.ToLower() == "true" || str5 == "")
                            {
                                ControlCollection controls1 = this.plhOutworkItem.Controls;
                                object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls1.Add(new LiteralControl(string.Concat(estType)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controls1 = this.plhOutworkItem.Controls;
                                object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls1.Add(new LiteralControl(string.Concat(estType)));
                            }
                            this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (this.Module.ToLower() == "job")
                    {
                        if (!this.IsShowInvRerun)
                        {
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=O&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&sectionid=0&maintype=edit", this.jID, this.InvID };
                            empty3 = string.Concat(objArray);
                            string str6 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                            if (str6.ToLower() == "true" || str6 == "")
                            {
                                ControlCollection controlCollections1 = this.plhOutworkItem.Controls;
                                string[] strArrays1 = new string[] { "&nbsp;<a href=", empty3, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                            }
                            string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                            if (str7.ToLower() == "true" || str7 == "")
                            {
                                ControlCollection controls2 = this.plhOutworkItem.Controls;
                                object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls2.Add(new LiteralControl(string.Concat(estType1)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controls2 = this.plhOutworkItem.Controls;
                                object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controls2.Add(new LiteralControl(string.Concat(estType1)));
                            }
                            this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (this.Module.ToLower() != "order")
                    {
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=O&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&sectionid=0&maintype=edit", this.jID, this.InvID };
                        empty3 = string.Concat(estimateID1);
                        string str8 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                        if (str8.ToLower() == "true" || str8 == "")
                        {
                            ControlCollection controlCollections2 = this.plhOutworkItem.Controls;
                            string[] strArrays2 = new string[] { "&nbsp;<a href=", empty3, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controlCollections2.Add(new LiteralControl(string.Concat(strArrays2)));
                        }
                        string str9 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                        if (str9.ToLower() == "true" || str9 == "")
                        {
                            ControlCollection controls3 = this.plhOutworkItem.Controls;
                            object[] objArray1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controls3.Add(new LiteralControl(string.Concat(objArray1)));
                        }
                        else if (strRemove.Trim() == "1")
                        {
                            ControlCollection controls3 = this.plhOutworkItem.Controls;
                            object[] objArray1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controls3.Add(new LiteralControl(string.Concat(objArray1)));
                        }
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    }
                    else if (!this.IsShowJobReRun)
                    {
                        object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=O&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&sectionid=0&maintype=edit" };
                        empty3 = string.Concat(estimateID2);
                        string str10 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                        if (str10.ToLower() == "true" || str10 == "")
                        {
                            ControlCollection controlCollections3 = this.plhOutworkItem.Controls;
                            string[] strArrays3 = new string[] { "&nbsp;<a href=", empty3, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                            controlCollections3.Add(new LiteralControl(string.Concat(strArrays3)));
                        }
                        string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                        string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                        if (str11.ToLower() == "true" || str11 == "")
                        {
                            ControlCollection controls4 = this.plhOutworkItem.Controls;
                            object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controls4.Add(new LiteralControl(string.Concat(estType2)));
                        }
                        else if (strRemove.Trim() == "1")
                        {
                            ControlCollection controls4 = this.plhOutworkItem.Controls;
                            object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                            controls4.Add(new LiteralControl(string.Concat(estType2)));
                        }
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                    if (this.IsFromActHist.ToLower() != "yes" && this.Module.ToLower() == "estimate")
                    {
                        DataTable dataTable = new DataTable();
                        DataTable item = new DataTable();
                        DataSet dataSet = new DataSet();
                        Database database = CustomDatabaseFactory.CreateDatabase(this.commclass.strConnection);
                        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SupplierQuote_EmailSentCount");
                        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, this.EstimateItemID);
                        dataSet = database.ExecuteDataSet(storedProcCommand);
                        dataTable = dataSet.Tables[0];
                        item = dataSet.Tables[1];
                        int num5 = Convert.ToInt16(dataTable.Rows[0]["TotalPending"]);
                        int num6 = Convert.ToInt16(dataTable.Rows[0]["Totalsent"]);
                        int num7 = num5 + num6;
                        this.plhOutworkItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("<td>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px;'>", this.objLanguage.GetLanguageConversion("Supplier_Quote_Stats"), "</div>")));
                        ControlCollection controlCollections4 = this.plhOutworkItem.Controls;
                        object[] countItem = new object[] { "<div style='padding-left:5px; width:500px;'><label style='cursor:pointer' OnClick=javascript:QuoteDetailsOpen(", this.Count_Item, ");>", this.objLanguage.GetLanguageConversion("Emailed"), ": ", dataTable.Rows[0]["Totalsent"].ToString(), " of ", num7, " &nbsp;&nbsp;&nbsp; ", this.objLanguage.GetLanguageConversion("Responses"), ": ", item.Rows[0]["TotalRecieved"].ToString(), "</label>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(countItem)));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</table>"));
                }
                else
                {
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    ControlCollection controls5 = this.plhOutworkItem.Controls;
                    string[] tblWidthMinWidth1 = new string[] { "<table width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='clear: both;", this.tblWidth_MinWidth, "'>" };
                    controls5.Add(new LiteralControl(string.Concat(tblWidthMinWidth1)));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", empty1, "</b></div><div style='clear:both;padding-top:10px'></div>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                    if (this.Module.ToLower() == "estimate")
                    {
                        DataTable dataTable1 = new DataTable();
                        DataTable item1 = new DataTable();
                        DataSet dataSet1 = new DataSet();
                        Database database1 = CustomDatabaseFactory.CreateDatabase(this.commclass.strConnection);
                        DbCommand dbCommand = database1.GetStoredProcCommand("PC_SupplierQuote_EmailSentCount");
                        database1.AddInParameter(dbCommand, "@EstimateItemID", DbType.Int64, this.ParentEstimateItemID);
                        dataSet1 = database1.ExecuteDataSet(dbCommand);
                        dataTable1 = dataSet1.Tables[0];
                        item1 = dataSet1.Tables[1];
                        int num8 = Convert.ToInt16(dataTable1.Rows[0]["TotalPending"]);
                        int num9 = Convert.ToInt16(dataTable1.Rows[0]["Totalsent"]);
                        int num10 = num8 + num9;
                        this.plhOutworkItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("<td style='width: 16%;'>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 200px'>", this.objLanguage.GetLanguageConversion("Supplier_Quote_Stats"), "</div>")));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("<td align='left'>"));
                        ControlCollection controlCollections5 = this.plhOutworkItem.Controls;
                        object[] supplierQuoteWidth = new object[] { "<div style=width:", this.SupplierQuoteWidth, "padding-left:5px;'><label style='cursor:pointer' OnClick=javascript:QuoteDetailsOpen(", this.Count_Item, ");>", this.objLanguage.GetLanguageConversion("Emailed"), ": ", dataTable1.Rows[0]["Totalsent"].ToString(), " of ", num10, " &nbsp;&nbsp;&nbsp; ", this.objLanguage.GetLanguageConversion("Responses"), ": ", item1.Rows[0]["TotalRecieved"].ToString(), "</label>" };
                        controlCollections5.Add(new LiteralControl(string.Concat(supplierQuoteWidth)));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</table>"));
                }
                ControlCollection controls6 = this.plhOutworkItem.Controls;
                string[] tblWidthMinWidth2 = new string[] { "<table id='tblOutworkItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='margin-top:-1px; word-break: break-word;", this.tblWidth_MinWidth, "'>" };
                controls6.Add(new LiteralControl(string.Concat(tblWidthMinWidth2)));
                if (this.objBase.ReturnRoles_Privileges_Others("showsuppliername").ToLower() != "false")
                {
                    showSuppliername = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    showSuppliername = "display:none;";
                }
                //this.plhOutworkItem.Controls.Add(new LiteralControl("<tr id='trSupplierName'>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trSupplierName' style='", showSuppliername, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Supplier_Name"), "</div>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierName1' style='text-align: right; width: 21%; ", str, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText' width:100%; style=' border:0px solid red;'><b>", this.objBase.SpecialDecode(estimatesItem.SupplierName1), "</b></span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierName2' style='text-align: right; width: 21%; ", str1, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'><b>", this.objBase.SpecialDecode(estimatesItem.SupplierName2), "</b></span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierName3' style='text-align: right; width: 21%; ", str2, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'><b>", this.objBase.SpecialDecode(estimatesItem.SupplierName3), "</b></span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdSupplierName4' style='text-align: right; width: 21%; ", str3, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'><b>", this.objBase.SpecialDecode(estimatesItem.SupplierName4), "</b></span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                if (this.IsParentItem)
                {
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<tr id='trSupplierQuoteNo'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-5px;  clear: both'>", this.objLanguage.GetLanguageConversion("Supp_Quote"), "</div>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierQuoteNo1' style='text-align: right; width: 21%; ", str, " '>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.SupplierQuoteNo1, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierQuoteNo2' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.SupplierQuoteNo2, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSupplierQuoteNo3' style='text-align: right; width: 21%; ", str2, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.SupplierQuoteNo3, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdSupplierQuoteNo4' style='text-align: right; width: 21%; ", str3, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.SupplierQuoteNo4, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem)
                {
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str2, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str3, "'>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                }
                if (this.IsParentItem)
                {
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<tr id='trQtydescription'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str, "'>")));
                    ControlCollection controlCollections6 = this.plhOutworkItem.Controls;

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
                        object[] estimateItemID1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str1, "'>")));
                    ControlCollection controls7 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str2, "'>")));
                    ControlCollection controlCollections7 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str3, "'>")));
                    ControlCollection controls8 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</td>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                }
                this.plhOutworkItem.Controls.Add(new LiteralControl("<tr id='trPrice'>"));
                //this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPrice' style='", showSubItems, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
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
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-5px; clear: both'>", this.objLanguage.GetLanguageConversion("Price"), "</div>")));
                }
                else
                {
                    showSubItems = "visibility: visible;";
                    this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' margin-top:-5px;  style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Price"), "</div>")));
                }
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice1' style='text-align: right; width: 21%; ", str, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPricePrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice2' style='text-align: right; width: 21%; ", str1, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPricePrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPrice3' style='text-align: right; width: 21%; ", str2, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPricePrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPrice4' style='text-align: right; width: 21%; ", str3, "'>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPricePrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                this.plhOutworkItem.Controls.Add(new LiteralControl(" </td>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl("</tr>"));
                this.plhOutworkItem.Controls.Add(new LiteralControl("</table>"));
            }
            else
            {
                object[] estimateItemID;
                ControlCollection controlCollections6 = this.plhOutworkItem.Controls;
                EstimatesItem estimatesItem = new EstimatesItem();
                int num = 0;
                foreach (DataRow row in EstimatesBasePage.estimate_outwork_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    var locking = "";
                    var ignorelocking = "";
                    var IsJobLocked = false;
                    num = Convert.ToInt32(row["QuantityNumber"]);
                    if (this.Module.ToLower() == "job")
                    {
                        locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();

                        ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();

                        IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    }
                    if (num == 1)
                    {
                        estimatesItem.Qty1 = Convert.ToInt32(row["Quantity"]);
                        estimatesItem.Qtydesc1 = row["QTYDescription"].ToString();
                    }
                    else if (num == 2)
                    {
                        estimatesItem.Qty2 = Convert.ToInt32(row["Quantity"]);
                        estimatesItem.Qtydesc2 = row["QTYDescription"].ToString();
                    }
                    else if (num == 3)
                    {
                        estimatesItem.Qty3 = Convert.ToInt32(row["Quantity"]);
                        estimatesItem.Qtydesc3 = row["QTYDescription"].ToString();
                    }
                    else if (num == 4)
                    {
                        estimatesItem.Qty4 = Convert.ToInt32(row["Quantity"]);
                        estimatesItem.Qtydesc4 = row["QTYDescription"].ToString();
                    }
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    ControlCollection controls7 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls7.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    ControlCollection controlCollections7 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    ControlCollection controls8 = this.plhOutworkItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none ' value='", estimatesItem.Qtydesc4, "' />" };
                        controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                }

            }

        }
    }
}
