using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_large_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhLargeItem;

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

        public string StrRedirctPath = string.Empty;

        public bool IsShowDelete;

        public bool IsItemCopied;

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

        static item_summary_large_item()
        {
            item_summary_large_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_large_item()
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
                string str = "display:none";
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string showCalculated = "display:none";
                string showSubItems = "display:none";
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
                }
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
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
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                }
                else if (this.QtyCount == 1)
                {
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                    str = "visibility:visible;";
                }
                else if (this.QtyCount == 2)
                {
                    this.tblWidth = "62%";
                    this.tblWidth_MinWidth = "min-width:420px;";
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
                }
                else if (this.QtyCount == 3)
                {
                    this.tblWidth = "82%";
                    this.tblWidth_MinWidth = "min-width:520px;";
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                }
                else if (this.QtyCount == 4)
                {
                    this.tblWidth = "100%";
                    this.tblWidth_MinWidth = "min-width:550px;";
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
                }
                foreach (DataRow row in EstimatesBasePage.estimate_large_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    long num = Convert.ToInt64(row["EstTypeID"]);
                    string str4 = this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    string str5 = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    long num1 = Convert.ToInt64(row["GuillotineID"]);
                    long num2 = Convert.ToInt64(row["PaperID"]);
                    long num3 = Convert.ToInt64(row["PressID"]);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = "Paper";
                        empty1 = "Press";
                        empty2 = "Guillotine";
                        empty3 = "Ink";
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.IsFromActHist.ToLower() != "yes")
                        {
                            estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num2, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Paper"), "</a>" };
                            empty = string.Concat(estimateItemID);
                            object[] objArray = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Press"), "</a>" };
                            empty1 = string.Concat(objArray);
                            object[] estimateItemID1 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=ink&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Ink"), "</a>" };
                            empty3 = string.Concat(estimateItemID1);
                            object[] objArray1 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&GuillotineID=", num1, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Cutting_Table"), "</a>" };
                            empty2 = string.Concat(objArray1);
                        }
                        else
                        {
                            empty = string.Concat("<a href='#' name='SPLPaper'>", this.objLanguage.GetLanguageConversion("Paper"), "</a>");
                            empty1 = string.Concat("<a href='#' name='SPLPress'>", this.objLanguage.GetLanguageConversion("Press"), "</a>");
                            empty3 = string.Concat("<a href='#' name='SPLInk'>", this.objLanguage.GetLanguageConversion("Ink"), "</a>");
                            empty2 = string.Concat("<a href='#' name='SPLGuillotine'>", this.objLanguage.GetLanguageConversion("Cutting_Table"), "</a>");
                        }
                    }
                    else if (this.IsFromActHist.ToLower() != "yes")
                    {
                        object[] estimateItemID2 = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num2, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Paper"), "</a>" };
                        empty = string.Concat(estimateItemID2);
                        object[] objArray2 = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Press"), "</a>" };
                        empty1 = string.Concat(objArray2);
                        object[] estimateItemID3 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=ink&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Ink"), "</a>" };
                        empty3 = string.Concat(estimateItemID3);
                        object[] objArray3 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&GuillotineID=", num1, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Cutting_Table"), "</a>" };
                        empty2 = string.Concat(objArray3);
                    }
                    else
                    {
                        empty = string.Concat("<a href='#' name='SPLPaper'>", this.objLanguage.GetLanguageConversion("Paper"), "</a>");
                        empty1 = string.Concat("<a href='#' name='SPLPress'>", this.objLanguage.GetLanguageConversion("Press"), "</a>");
                        empty3 = string.Concat("<a href='#' name='SPLInk'>", this.objLanguage.GetLanguageConversion("Ink"), "</a>");
                        empty2 = string.Concat("<a href='#' name='SPLGuillotine'>", this.objLanguage.GetLanguageConversion("Cutting_Table"), "</a>");
                    }
                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem = new EstimatesItem();


                    estimatesItem.Qty1 = BaseClass.CheckIntegerNull(row["Qty1"]);
                    estimatesItem.Qty2 = BaseClass.CheckIntegerNull(row["Qty2"]);
                    estimatesItem.Qty3 = BaseClass.CheckIntegerNull(row["Qty3"]);
                    estimatesItem.Qty4 = BaseClass.CheckIntegerNull(row["Qty4"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    estimatesItem.PressCostExMarkup1 = BaseClass.CheckDecimalNull(row["PressCostExMarkup1"]);
                    estimatesItem.PressCostExMarkup2 = BaseClass.CheckDecimalNull(row["PressCostExMarkup2"]);
                    estimatesItem.PressCostExMarkup3 = BaseClass.CheckDecimalNull(row["PressCostExMarkup3"]);
                    estimatesItem.PressCostExMarkup4 = BaseClass.CheckDecimalNull(row["PressCostExMarkup4"]);
                    estimatesItem.PressMarkupPrice1 = BaseClass.CheckDecimalNull(row["PressMarkupPrice1"]);
                    estimatesItem.PressMarkupPrice2 = BaseClass.CheckDecimalNull(row["PressMarkupPrice2"]);
                    estimatesItem.PressMarkupPrice3 = BaseClass.CheckDecimalNull(row["PressMarkupPrice3"]);
                    estimatesItem.PressMarkupPrice4 = BaseClass.CheckDecimalNull(row["PressMarkupPrice4"]);
                    estimatesItem.PressCostInMarkup1 = estimatesItem.PressCostExMarkup1 + estimatesItem.PressMarkupPrice1;
                    estimatesItem.PressCostInMarkup2 = estimatesItem.PressCostExMarkup2 + estimatesItem.PressMarkupPrice2;
                    estimatesItem.PressCostInMarkup3 = estimatesItem.PressCostExMarkup3 + estimatesItem.PressMarkupPrice3;
                    estimatesItem.PressCostInMarkup4 = estimatesItem.PressCostExMarkup4 + estimatesItem.PressMarkupPrice4;
                    estimatesItem.GuillotineCostExMarkup1 = BaseClass.CheckDecimalNull(row["GuillotineCostExMarkup1"]);
                    estimatesItem.GuillotineCostExMarkup2 = BaseClass.CheckDecimalNull(row["GuillotineCostExMarkup2"]);
                    estimatesItem.GuillotineCostExMarkup3 = BaseClass.CheckDecimalNull(row["GuillotineCostExMarkup3"]);
                    estimatesItem.GuillotineCostExMarkup4 = BaseClass.CheckDecimalNull(row["GuillotineCostExMarkup4"]);
                    estimatesItem.GuillotineMarkupPrice1 = BaseClass.CheckDecimalNull(row["GuillotineMarkupPrice1"]);
                    estimatesItem.GuillotineMarkupPrice2 = BaseClass.CheckDecimalNull(row["GuillotineMarkupPrice2"]);
                    estimatesItem.GuillotineMarkupPrice3 = BaseClass.CheckDecimalNull(row["GuillotineMarkupPrice3"]);
                    estimatesItem.GuillotineMarkupPrice4 = BaseClass.CheckDecimalNull(row["GuillotineMarkupPrice4"]);
                    estimatesItem.GuillotineCostInMarkup1 = estimatesItem.GuillotineCostExMarkup1 + estimatesItem.GuillotineMarkupPrice1;
                    estimatesItem.GuillotineCostInMarkup2 = estimatesItem.GuillotineCostExMarkup2 + estimatesItem.GuillotineMarkupPrice2;
                    estimatesItem.GuillotineCostInMarkup3 = estimatesItem.GuillotineCostExMarkup3 + estimatesItem.GuillotineMarkupPrice3;
                    estimatesItem.GuillotineCostInMarkup4 = estimatesItem.GuillotineCostExMarkup4 + estimatesItem.GuillotineMarkupPrice4;
                    estimatesItem.InkCostExMarkup1 = BaseClass.CheckDecimalNull(row["InkCostExMarkup1"]);
                    estimatesItem.InkCostExMarkup2 = BaseClass.CheckDecimalNull(row["InkCostExMarkup2"]);
                    estimatesItem.InkCostExMarkup3 = BaseClass.CheckDecimalNull(row["InkCostExMarkup3"]);
                    estimatesItem.InkCostExMarkup4 = BaseClass.CheckDecimalNull(row["InkCostExMarkup4"]);
                    estimatesItem.InkMarkupPrice1 = BaseClass.CheckDecimalNull(row["InkMarkupPrice1"]);
                    estimatesItem.InkMarkupPrice2 = BaseClass.CheckDecimalNull(row["InkMarkupPrice2"]);
                    estimatesItem.InkMarkupPrice3 = BaseClass.CheckDecimalNull(row["InkMarkupPrice3"]);
                    estimatesItem.InkMarkupPrice4 = BaseClass.CheckDecimalNull(row["InkMarkupPrice4"]);
                    estimatesItem.InkCostInMarkup1 = estimatesItem.InkCostExMarkup1 + estimatesItem.InkMarkupPrice1;
                    estimatesItem.InkCostInMarkup2 = estimatesItem.InkCostExMarkup2 + estimatesItem.InkMarkupPrice2;
                    estimatesItem.InkCostInMarkup3 = estimatesItem.InkCostExMarkup3 + estimatesItem.InkMarkupPrice3;
                    estimatesItem.InkCostInMarkup4 = estimatesItem.InkCostExMarkup4 + estimatesItem.InkMarkupPrice4;
                    estimatesItem.InvSheets1 = BaseClass.CheckDecimalNull(row["InvSheets1"]);
                    estimatesItem.InvSheets2 = BaseClass.CheckDecimalNull(row["InvSheets2"]);
                    estimatesItem.InvSheets3 = BaseClass.CheckDecimalNull(row["InvSheets3"]);
                    estimatesItem.InvSheets4 = BaseClass.CheckDecimalNull(row["InvSheets4"]);

                    //estimatesItem
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
                    if (!this.IsParentItem)
                    {
                        this.plhLargeItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td style='width:16%;'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Large Format'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet'  />")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext' style='width:135px;'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span >", str5, "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon'>"));
                        if (this.IsFromActHist.ToLower() == "yes")
                        {
                            this.plhLargeItem.Controls.Add(new LiteralControl("&nbsp;"));
                        }
                        else if (this.Module.ToLower() == "estimate")
                        {
                            if (!this.IsShowJobReRun)
                            {
                                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=L&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, "&calcType=", row["calctype"] };
                                string str6 = string.Concat(estimateID);
                                string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                                if (str7.ToLower() == "true" || str7 == "")
                                {
                                    ControlCollection controls = this.plhLargeItem.Controls;
                                    string[] strArrays = new string[] { "&nbsp;<a href=", str6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer; padding-left:10px;' /></a>&nbsp;" };
                                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                                }
                                string str8 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                                if (str8.ToLower() == "true" || str8 == "")
                                {
                                    ControlCollection controlCollections = this.plhLargeItem.Controls;
                                    object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections = this.plhLargeItem.Controls;
                                    object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                }
                                this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (this.Module.ToLower() == "job")
                        {
                            if (!this.IsShowInvRerun)
                            {
                                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=L&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, "&calcType=", row["calctype"], this.jID, this.InvID };
                                string str9 = string.Concat(estimateID1);
                                string str10 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                                if (str10.ToLower() == "true" || str10 == "")
                                {
                                    ControlCollection controls1 = this.plhLargeItem.Controls;
                                    string[] strArrays1 = new string[] { "&nbsp;<a href=", str9, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer; padding-left:10px;' /></a>&nbsp;" };
                                    controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                                }
                                string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                                if (str11.ToLower() == "true" || str11 == "")
                                {
                                    ControlCollection controlCollections1 = this.plhLargeItem.Controls;
                                    object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections1 = this.plhLargeItem.Controls;
                                    object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                }
                                this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (this.Module.ToLower() != "order")
                        {
                            object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=L&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, "&calcType=", row["calctype"], this.jID, this.InvID };
                            string str12 = string.Concat(estimateID2);
                            string str13 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                            if (str13.ToLower() == "true" || str13 == "")
                            {
                                ControlCollection controls2 = this.plhLargeItem.Controls;
                                string[] strArrays2 = new string[] { "&nbsp;<a href=", str12, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer; padding-left:10px;' /></a>&nbsp;" };
                                controls2.Add(new LiteralControl(string.Concat(strArrays2)));
                            }
                            string str14 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                            if (str14.ToLower() == "true" || str14 == "")
                            {
                                ControlCollection controlCollections2 = this.plhLargeItem.Controls;
                                object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(estType2)));
                            }
                            else if(strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections2 = this.plhLargeItem.Controls;
                                object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(estType2)));
                            }
                            this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (!this.IsShowJobReRun)
                        {
                            object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=L&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, "&calcType=", row["calctype"] };
                            string str151 = string.Concat(estimateID3);
                            string str161 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                            if (str161.ToLower() == "true" || str161 == "")
                            {
                                ControlCollection controls3 = this.plhLargeItem.Controls;
                                string[] strArrays3 = new string[] { "&nbsp;<a href=", str151, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer; padding-left:10px;' /></a>&nbsp;" };
                                controls3.Add(new LiteralControl(string.Concat(strArrays3)));
                            }
                            string str171 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                            if (str171.ToLower() == "true" || str171 == "")
                            {
                                ControlCollection controlCollections3 = this.plhLargeItem.Controls;
                                object[] estType3 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(estType3)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections3 = this.plhLargeItem.Controls;
                                object[] estType3 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(estType3)));
                            }
                            this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    else
                    {
                        this.plhLargeItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both; '>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str4, "</b></div><div style='clear:both;padding-top:10px'></div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</table>"));
                    }


                    DataSet dataSet1 = OrderBasePage.Select_OrderItems_WithAdditionalItems1(this.EstimateItemID);
                    DataTable item2 = dataSet1.Tables[0];
                    DataTable dataTable2 = dataSet1.Tables[2];
                    string empty13 = string.Empty;
                    //string str13 = string.Empty;
                    string empty14 = string.Empty;
                    //string str14 = string.Empty;
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
                    //object[] estimateItemID;
                    string[] tblWidthMinWidth1;
                    char[] chrArray;
                    int count = dataTable2.Rows.Count;
                    this.plhLargeItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
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
                            tblWidthMinWidth1 = new string[] { global.SecureSitePath(), this.serverName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                            str16 = string.Concat(tblWidthMinWidth1);
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
                            tblWidthMinWidth1 = new string[] { "<div '><a href='", str16, empty15, "' target='_blank'>", str15, "</a>" };
                            stringBuilder1.Append(string.Concat(tblWidthMinWidth1));
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
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("</table>"));

                    ControlCollection controls4 = this.plhLargeItem.Controls;
                    string[] tblWidthMinWidth = new string[] { "<table id='tblLargeItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Finished_Quantity"), "</div>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str, "'>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnQuantity1_", this.EstimateItemID, "' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnQuantity2_", this.EstimateItemID, "' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str2, "'>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnQuantity3_", this.EstimateItemID, "' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str3, "'>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnQuantity4_", this.EstimateItemID, "' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                    this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));


                    //-------------------------------------------------------------start

                    string lable_sqm = "Item SQM Area";
                    if (row["CalcType"].ToString().ToLower() == "square")
                    {
                        decimal item_sqm_area = 0m;
                        string regionalSettings = (new BasePage()).GetRegionalSettings(CompanyID, "PaperMeasure");
                        if (regionalSettings != "In.")
                        {
                            item_sqm_area = ((Convert.ToDecimal(row["JobHeight"]) / new decimal(1000)) * (Convert.ToDecimal(row["JobWidth"]) / new decimal(1000)));
                        }
                        else
                        {
                            item_sqm_area = ((Convert.ToDecimal(row["JobHeight"]) / new decimal(12)) * (Convert.ToDecimal(row["JobWidth"]) / new decimal(12)));
                            lable_sqm = "Item SQFT Area";
                        }

                        this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trSQM'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", lable_sqm, "</div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSQM1' style='text-align: right; width: 21%; ", str, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnSQM1_", this.EstimateItemID, "' CssClass='normalText'>", Math.Round(item_sqm_area, 4), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSQM2' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnSQM2_", this.EstimateItemID, "' CssClass='normalText'>", Math.Round(item_sqm_area, 4), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdSQM3' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnSQM3_", this.EstimateItemID, "' CssClass='normalText'>", Math.Round(item_sqm_area, 4), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdSQM4' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span id='spnSQM4_", this.EstimateItemID, "' CssClass='normalText'>", Math.Round(item_sqm_area, 4), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));

                    }

                    //-------------------------------------------------------------end

                    if (this.IsParentItem)
                    {

                        this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trQtyDescription'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc1' style='text-align: right; width: 21%; ", str, "'>")));
                        ControlCollection controlCollections4 = this.plhLargeItem.Controls;

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
                            object[] estimateItemID4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                            controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                        }
                        else
                        {
                            object[] estimateItemID4 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                            controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                        }
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));

                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc2' style='text-align: right; width: 21%; ", str1, "'>")));
                        ControlCollection controls5 = this.plhLargeItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                            controls5.Add(new LiteralControl(string.Concat(objArray4)));
                        }
                        else
                        {
                            object[] objArray4 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                            controls5.Add(new LiteralControl(string.Concat(objArray4)));
                        }
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc3' style='text-align: right; width: 21%; ", str2, "'>")));
                        ControlCollection controlCollections5 = this.plhLargeItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            object[] estimateItemID5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                            controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                        }
                        else
                        {
                            object[] estimateItemID5 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                            controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                        }
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQtydesc4' style='text-align: right; width: 21%; ", str3, "'>")));
                        ControlCollection controls6 = this.plhLargeItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            object[] objArray5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                            controls6.Add(new LiteralControl(string.Concat(objArray5)));
                        }
                        else
                        {
                            object[] objArray5 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                            controls6.Add(new LiteralControl(string.Concat(objArray5)));
                        }
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    foreach (DataRow dataRow in EstimatesBasePage.estimate_largeitemMetarals_select(this.EstimateItemID).Rows)
                    {
                        long num4 = Convert.ToInt64(dataRow["MaterialID"]);
                        int num5 = Convert.ToInt32(dataRow["MaterialNo"]);
                        string languageConversion = string.Empty;
                        if (num5 == 1)
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Material_1");
                        }
                        else if (num5 == 2)
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Material_2");
                        }
                        else if (num5 == 3)
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Material_3");
                        }
                        else if (num5 == 4)
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Material_4");
                        }
                        else if (num5 == 5)
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Material_5");
                        }
                        if (this.Check_SpecialPrivilege)
                        {
                            empty = "Paper";
                        }
                        else if (this.IsParentItem)
                        {
                            if (this.IsFromActHist.ToLower() != "yes")
                            {
                                estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num4, "&MaterialNo=", num5, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", languageConversion, "</a>" };
                                empty = string.Concat(estimateItemID);
                            }
                            else
                            {
                                empty = string.Concat("<a href='#' name='SPLPaper'>", languageConversion, "</a>");
                            }
                        }
                        else if (this.IsFromActHist.ToLower() != "yes")
                        {
                            estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num4, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&MaterialNo=", num5, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", languageConversion, "</a>" };
                            empty = string.Concat(estimateItemID);
                        }
                        else
                        {
                            empty = string.Concat("<a href='#' name='SPLPaper'>", languageConversion, "</a>");
                        }
                        estimatesItem.PaperCostExMarkup1 = Convert.ToDecimal(dataRow["MaterialCostExMarkup1"]);
                        estimatesItem.PaperCostExMarkup2 = Convert.ToDecimal(dataRow["MaterialCostExMarkup2"]);
                        estimatesItem.PaperCostExMarkup3 = Convert.ToDecimal(dataRow["MaterialCostExMarkup3"]);
                        estimatesItem.PaperCostExMarkup4 = Convert.ToDecimal(dataRow["MaterialCostExMarkup4"]);
                        estimatesItem.PaperMarkupPrice1 = Convert.ToDecimal(dataRow["MaterialMarkupPrice1"]);
                        estimatesItem.PaperMarkupPrice2 = Convert.ToDecimal(dataRow["MaterialMarkupPrice2"]);
                        estimatesItem.PaperMarkupPrice3 = Convert.ToDecimal(dataRow["MaterialMarkupPrice3"]);
                        estimatesItem.PaperMarkupPrice4 = Convert.ToDecimal(dataRow["MaterialMarkupPrice4"]);
                        estimatesItem.PaperCostInMarkup1 = estimatesItem.PaperCostExMarkup1 + estimatesItem.PaperMarkupPrice1;
                        estimatesItem.PaperCostInMarkup2 = estimatesItem.PaperCostExMarkup2 + estimatesItem.PaperMarkupPrice2;
                        estimatesItem.PaperCostInMarkup3 = estimatesItem.PaperCostExMarkup3 + estimatesItem.PaperMarkupPrice3;
                        estimatesItem.PaperCostInMarkup4 = estimatesItem.PaperCostExMarkup4 + estimatesItem.PaperMarkupPrice4;
                        if (this.objBase.ReturnRoles_Privileges_Others("showcalculated").ToLower() != "false")
                        {
                            showCalculated = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            showCalculated = "display:none;";
                        }
                        //this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trPaper'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPaper' style='", showCalculated, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty, "</div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%; ", str, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    if (this.Module.ToLower() != "proof")
                    {
                        //this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trInk'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trInk' style='", showCalculated, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty3, "</div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk1' style='text-align: right; width: 21%; ", str, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk2' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk3' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdInk4' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                        //this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trPress'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPress' style='", showCalculated, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty1, "</div>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", str, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                        if (num1 > (long)0)
                        {
                            //this.plhLargeItem.Controls.Add(new LiteralControl("<tr id='trGuillotine'>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty2, "</div>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", str, "'>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", str1, "'>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", str2, "'>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", str3, "'>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLargeItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLargeItem.Controls.Add(new LiteralControl("</tr>"));
                        }
                    }
                    this.plhLargeItem.Controls.Add(new LiteralControl("</table>"));
                }
            }
            else
            {
                foreach (DataRow row in EstimatesBasePage.estimate_large_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    var locking = "";
                    var ignorelocking = "";
                    var IsJobLocked = false;
                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem = new EstimatesItem();


                    estimatesItem.Qty1 = BaseClass.CheckIntegerNull(row["Qty1"]);
                    estimatesItem.Qty2 = BaseClass.CheckIntegerNull(row["Qty2"]);
                    estimatesItem.Qty3 = BaseClass.CheckIntegerNull(row["Qty3"]);
                    estimatesItem.Qty4 = BaseClass.CheckIntegerNull(row["Qty4"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    ControlCollection controlCollections4 = this.plhLargeItem.Controls;
                    if (this.Module.ToLower() == "job")
                    {
                        locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                        ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                        IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    }
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                    }
                    else
                    {
                        object[] estimateItemID4 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                    }
                    ControlCollection controls5 = this.plhLargeItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(objArray4)));
                    }
                    else
                    {
                        object[] objArray4 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(objArray4)));
                    }
                    ControlCollection controlCollections5 = this.plhLargeItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                    }
                    else
                    {
                        object[] estimateItemID5 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                    }
                    ControlCollection controls6 = this.plhLargeItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(objArray5)));
                    }
                    else
                    {
                        object[] objArray5 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(objArray5)));
                    }
                }
                   
            }
        }
    }
}