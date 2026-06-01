using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.EstimatesNew;
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
using System.Web.UI.WebControls;
namespace ePrint.usercontrol.Item
{
    public partial class item_summary_single_item : UsercontrolBasePage
    {
        //protected PlaceHolder plhDigiSingleItem;

        //protected PlaceHolder plhSubItems;

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

        public string StrRedirctPath = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public long TypeID;

        public long ParentEstimateItemID;

        public bool IsParentItem;

        public bool Check_SpecialPrivilege;

        public bool IsItemCopied;

        public bool IsShowDelete;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public string IsFromActHist = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string SalesPersonID = string.Empty;

        public static string IsEditOnlyHisRecords;
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

        static item_summary_single_item()
        {
            item_summary_single_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_single_item()
        {
        }

        private void btnCopyitem_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            this.IsItemCopied = this.SummaryClassObj.CopyItem(this.EstimateID, Convert.ToInt64(linkButton.CommandName), linkButton.CommandArgument, this.Module, "sss");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Module.ToLower() != "proof")
            {
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
                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFromActHist = base.Request.Params["acthist"].ToString();
                }
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string str4 = "display:none";
                string strDimension1 = "display:none";
                string strDimension2 = "display:none";
                string strDimension3 = "display:none";
                string strDimension4 = "display:none";
                string showCalculated = "display:none";
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                if (this.Module.ToLower() != "estimate")
                {
                    if (this.QtyNumber == 1)
                    {
                        str1 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                        {
                            strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension1 = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 2)
                    {
                        str2 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                        {
                            strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension2 = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 3)
                    {
                        str3 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                        {
                            strDimension3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension3 = "display:none;";
                        }
                    }
                    else if (this.QtyNumber == 4)
                    {
                        str4 = "visibility:visible;";
                        if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                        {
                            strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            strDimension4 = "display:none;";
                        }
                    }
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                }
                else if (this.QtyCount == 1)
                {
                    this.tblWidth = "42%";
                    this.tblWidth_MinWidth = "min-width:320px;";
                    str1 = "visibility:visible;";
                    if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                    {
                        strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        strDimension1 = "display:none;";
                    }
                }
                else if (this.QtyCount == 2)
                {
                    this.tblWidth = "62%";
                    this.tblWidth_MinWidth = "min-width:420px;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                    {
                        strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        strDimension1 = "display:none;";
                        strDimension2 = "display:none;";
                    }
                }
                else if (this.QtyCount == 3)
                {
                    this.tblWidth = "82%";
                    this.tblWidth_MinWidth = "min-width:520px;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
                    if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                    {
                        strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        strDimension1 = "display:none;";
                        strDimension2 = "display:none;";
                        strDimension3 = "display:none;";
                    }
                }
                else if (this.QtyCount == 4)
                {
                    this.tblWidth = "100%";
                    this.tblWidth_MinWidth = "min-width:550px;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
                    str4 = "visibility:visible;";
                    if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                    {
                        strDimension1 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension2 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension3 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        strDimension4 = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        strDimension1 = "display:none;";
                        strDimension2 = "display:none;";
                        strDimension3 = "display:none;";
                        strDimension4 = "display:none;";
                    }
                }
                int num = 0;
                DataTable dataTable = new DataTable();
                dataTable = EstimatesBasePage.estimate_single_item_select(this.CompanyID, this.EstimateItemID);
                foreach (DataRow row in dataTable.Rows)
                {
                    long num1 = Convert.ToInt64(row["EstTypeID"]);
                    string str5 = this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    string str6 = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    long num2 = Convert.ToInt64(row["PaperID"]);
                    long num3 = Convert.ToInt64(row["PressID"]);
                    long num4 = Convert.ToInt64(row["GuillotineID"]);
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = "Paper";
                        str = "Press";
                        empty1 = "Guillotine";
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.IsFromActHist.ToLower() != "yes")
                        {
                            object[] estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num2, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Paper"), "</a>" };
                            empty = string.Concat(estimateItemID);
                            object[] objArray = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Press"), "</a>" };
                            str = string.Concat(objArray);
                            object[] estimateItemID1 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&GuillotineID=", num4, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>" };
                            empty1 = string.Concat(estimateItemID1);
                        }
                        else
                        {
                            empty = string.Concat("<a href='#' name='SPLPaper'>", this.objLanguage.GetLanguageConversion("Paper"), "</a>");
                            str = string.Concat("<a href='#' name='SPLPress'>", this.objLanguage.GetLanguageConversion("Press"), "</a>");
                            empty1 = string.Concat("<a href='#' name='SPLGuillotine'>", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>");
                        }
                    }
                    else if (this.IsFromActHist.ToLower() != "yes")
                    {
                        object[] objArray1 = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PaperID=", num2, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Paper"), "</a>" };
                        empty = string.Concat(objArray1);
                        object[] estimateItemID2 = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Press"), "</a>" };
                        str = string.Concat(estimateItemID2);
                        object[] objArray2 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num1, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&GuillotineID=", num4, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>" };
                        empty1 = string.Concat(objArray2);
                    }
                    else
                    {
                        empty = string.Concat("<a href='#' name='SPLPaper'>", this.objLanguage.GetLanguageConversion("Paper"), "</a>");
                        str = string.Concat("<a href='#' name='SPLPress'>", this.objLanguage.GetLanguageConversion("Press"), "</a>");
                        empty1 = string.Concat("<a href='#' name='SPLGuillotine'>", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>");
                    }
                    EstimatesItem estimatesItem = new EstimatesItem();

                    estimatesItem.Qty1 = Convert.ToInt32(row["Qty1"]);
                    estimatesItem.Qty2 = Convert.ToInt32(row["Qty2"]);
                    estimatesItem.Qty3 = Convert.ToInt32(row["Qty3"]);
                    estimatesItem.Qty4 = Convert.ToInt32(row["Qty4"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    estimatesItem.PaperCostExMarkup1 = Convert.ToDecimal(row["PaperCostExMarkup1"]);
                    estimatesItem.PaperCostExMarkup2 = Convert.ToDecimal(row["PaperCostExMarkup2"]);
                    estimatesItem.PaperCostExMarkup3 = Convert.ToDecimal(row["PaperCostExMarkup3"]);
                    estimatesItem.PaperCostExMarkup4 = Convert.ToDecimal(row["PaperCostExMarkup4"]);
                    estimatesItem.PaperMarkupPrice1 = Convert.ToDecimal(row["PaperMarkupPrice1"]);
                    estimatesItem.PaperMarkupPrice2 = Convert.ToDecimal(row["PaperMarkupPrice2"]);
                    estimatesItem.PaperMarkupPrice3 = Convert.ToDecimal(row["PaperMarkupPrice3"]);
                    estimatesItem.PaperMarkupPrice4 = Convert.ToDecimal(row["PaperMarkupPrice4"]);
                    estimatesItem.PaperCostInMarkup1 = estimatesItem.PaperCostExMarkup1 + estimatesItem.PaperMarkupPrice1;
                    estimatesItem.PaperCostInMarkup2 = estimatesItem.PaperCostExMarkup2 + estimatesItem.PaperMarkupPrice2;
                    estimatesItem.PaperCostInMarkup3 = estimatesItem.PaperCostExMarkup3 + estimatesItem.PaperMarkupPrice3;
                    estimatesItem.PaperCostInMarkup4 = estimatesItem.PaperCostExMarkup4 + estimatesItem.PaperMarkupPrice4;
                    estimatesItem.PressCostExMarkup1 = Convert.ToDecimal(row["PressCostExMarkup1"]);
                    estimatesItem.PressCostExMarkup2 = Convert.ToDecimal(row["PressCostExMarkup2"]);
                    estimatesItem.PressCostExMarkup3 = Convert.ToDecimal(row["PressCostExMarkup3"]);
                    estimatesItem.PressCostExMarkup4 = Convert.ToDecimal(row["PressCostExMarkup4"]);
                    estimatesItem.PressMarkupPrice1 = Convert.ToDecimal(row["PressMarkupPrice1"]);
                    estimatesItem.PressMarkupPrice2 = Convert.ToDecimal(row["PressMarkupPrice2"]);
                    estimatesItem.PressMarkupPrice3 = Convert.ToDecimal(row["PressMarkupPrice3"]);
                    estimatesItem.PressMarkupPrice4 = Convert.ToDecimal(row["PressMarkupPrice4"]);
                    estimatesItem.PressCostInMarkup1 = estimatesItem.PressCostExMarkup1 + estimatesItem.PressMarkupPrice1;
                    estimatesItem.PressCostInMarkup2 = estimatesItem.PressCostExMarkup2 + estimatesItem.PressMarkupPrice2;
                    estimatesItem.PressCostInMarkup3 = estimatesItem.PressCostExMarkup3 + estimatesItem.PressMarkupPrice3;
                    estimatesItem.PressCostInMarkup4 = estimatesItem.PressCostExMarkup4 + estimatesItem.PressMarkupPrice4;
                    estimatesItem.GuillotineCostExMarkup1 = Convert.ToDecimal(row["GuillotineCostExMarkup1"]);
                    estimatesItem.GuillotineCostExMarkup2 = Convert.ToDecimal(row["GuillotineCostExMarkup2"]);
                    estimatesItem.GuillotineCostExMarkup3 = Convert.ToDecimal(row["GuillotineCostExMarkup3"]);
                    estimatesItem.GuillotineCostExMarkup4 = Convert.ToDecimal(row["GuillotineCostExMarkup4"]);
                    estimatesItem.GuillotineMarkupPrice1 = Convert.ToDecimal(row["GuillotineMarkupPrice1"]);
                    estimatesItem.GuillotineMarkupPrice2 = Convert.ToDecimal(row["GuillotineMarkupPrice2"]);
                    estimatesItem.GuillotineMarkupPrice3 = Convert.ToDecimal(row["GuillotineMarkupPrice3"]);
                    estimatesItem.GuillotineMarkupPrice4 = Convert.ToDecimal(row["GuillotineMarkupPrice4"]);
                    estimatesItem.GuillotineCostInMarkup1 = estimatesItem.GuillotineCostExMarkup1 + estimatesItem.GuillotineMarkupPrice1;
                    estimatesItem.GuillotineCostInMarkup2 = estimatesItem.GuillotineCostExMarkup2 + estimatesItem.GuillotineMarkupPrice2;
                    estimatesItem.GuillotineCostInMarkup3 = estimatesItem.GuillotineCostExMarkup3 + estimatesItem.GuillotineMarkupPrice3;
                    estimatesItem.GuillotineCostInMarkup4 = estimatesItem.GuillotineCostExMarkup4 + estimatesItem.GuillotineMarkupPrice4;

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
                        this.plhSubItems.Controls.Add(new LiteralControl("<table valign='top' width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<tr>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<td valign='top' style='width: 20%;'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:160px; clear:both;'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Sheet Fed Digital: Single'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet' />")));
                        this.plhSubItems.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<div class='additionaloptiontext'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span >", str6, "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon'>"));
                        if (this.IsFromActHist.ToLower() != "yes")
                        {
                            if (this.Module.ToLower() == "estimate")
                            {
                                if (!this.IsShowJobReRun)
                                {
                                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=S&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                                    string str7 = string.Concat(estimateID);
                                    string str8 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                                    if (str8.ToLower() == "true" || str8 == "")
                                    {
                                        ControlCollection controls = this.plhSubItems.Controls;
                                        string[] strArrays = new string[] { "<a href=", str7, "><img src=", this.strImagepath, "edit.gif   border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                                    }
                                    string str9 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                                    if (str9.ToLower() == "true" || str9 == "")
                                    {
                                        ControlCollection controlCollections = this.plhSubItems.Controls;
                                        object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                                        controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                    }
                                    else if (strRemove.Trim() == "1")
                                    {
                                        ControlCollection controlCollections = this.plhSubItems.Controls;
                                        object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                                        controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                    }
                                    this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            else if (this.Module.ToLower() == "job")
                            {
                                if (!this.IsShowInvRerun)
                                {
                                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=S&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                                    string str10 = string.Concat(estimateID1);
                                    string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                                    if (str11.ToLower() == "true" || str11 == "")
                                    {
                                        ControlCollection controls1 = this.plhSubItems.Controls;
                                        string[] strArrays1 = new string[] { "<a href=", str10, "><img src=", this.strImagepath, "edit.gif   border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                        controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                                    }
                                    string str12 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                                    string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                                    if (str12.ToLower() == "true" || str12 == "")
                                    {
                                        ControlCollection controlCollections1 = this.plhSubItems.Controls;
                                        object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                        controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                    }
                                    else if (strRemove.Trim() == "1")
                                    {
                                        ControlCollection controlCollections1 = this.plhSubItems.Controls;
                                        object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                        controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                    }
                                    this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            else if (this.Module.ToLower() != "order")
                            {
                                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=S&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit", this.jID, this.InvID };
                                string str13 = string.Concat(estimateID2);
                                string str14 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                                if (str14.ToLower() == "true" || str14 == "")
                                {
                                    ControlCollection controls2 = this.plhSubItems.Controls;
                                    string[] strArrays2 = new string[] { "<a href=", str13, "><img src=", this.strImagepath, "edit.gif   border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                    controls2.Add(new LiteralControl(string.Concat(strArrays2)));
                                }
                                string str15 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                                if (str15.ToLower() == "true" || str15 == "")
                                {
                                    ControlCollection controlCollections2 = this.plhSubItems.Controls;
                                    object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections2.Add(new LiteralControl(string.Concat(estType2)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections2 = this.plhSubItems.Controls;
                                    object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections2.Add(new LiteralControl(string.Concat(estType2)));
                                }
                                this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (!this.IsShowJobReRun)
                            {
                                object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=S&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                                string str16 = string.Concat(estimateID3);
                                string str17 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                                if (str17.ToLower() == "true" || str17 == "")
                                {
                                    ControlCollection controls3 = this.plhSubItems.Controls;
                                    string[] strArrays3 = new string[] { "<a href=", str16, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                    controls3.Add(new LiteralControl(string.Concat(strArrays3)));
                                }
                                string str18 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                                if (str18.ToLower() == "true" || str18 == "")
                                {
                                    ControlCollection controlCollections3 = this.plhSubItems.Controls;
                                    object[] estType3 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections3.Add(new LiteralControl(string.Concat(estType3)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections3 = this.plhSubItems.Controls;
                                    object[] estType3 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num1, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections3.Add(new LiteralControl(string.Concat(estType3)));
                                }
                                this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</div>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</tr>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</table>"));
                        if (this.objBase.ReturnRoles_Privileges_Others("showcalculated").ToLower() != "false")
                        {
                            showCalculated = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                        }
                        else
                        {
                            showCalculated = "display:none;";
                        }
                        ControlCollection controls4 = this.plhSubItems.Controls;
                        string[] tblWidthMinWidth = new string[] { "<table id='tblSingleItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                        controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        this.plhSubItems.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 160px; clear: both'>Finished Quantity</div>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty1, "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty2, "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty3, "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str4, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty4, "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</tr>"));
                        //this.plhSubItems.Controls.Add(new LiteralControl("<tr id='trPaper'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<tr id='trPaper' style='", showCalculated, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", empty, "</div>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%; ", str1, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", str4, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</tr>"));
                        //this.plhSubItems.Controls.Add(new LiteralControl("<tr id='trPress'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<tr id='trPress' style='", showCalculated, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", str, "</div>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", str1, " '>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", str2, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", str3, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice3' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", str4, "'>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice4' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                        this.plhSubItems.Controls.Add(new LiteralControl("</tr>"));
                        if (num4 > (long)0)
                        {
                            //this.plhSubItems.Controls.Add(new LiteralControl("<tr id='trGuillotine'>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>")));
                            this.plhSubItems.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", empty1, "</div>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", str1, "'>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", str2, "'>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", str3, "'>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", str4, "'>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhSubItems.Controls.Add(new LiteralControl(" </td>"));
                            this.plhSubItems.Controls.Add(new LiteralControl("</tr>"));
                        }
                        this.plhSubItems.Controls.Add(new LiteralControl("</table>"));
                    }
                    else
                    {
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both;'>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str5, "</b></div><div style='clear:both;padding-top:20px'></div>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</table>"));

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
                        string[] tblWidthMinWidth;
                        char[] chrArray;
                        int count = dataTable2.Rows.Count;

                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
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
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</table>"));

                        ControlCollection controlCollections4 = this.plhDigiSingleItem.Controls;
                        string[] tblWidthMinWidth1 = new string[] { "<table id='tblSingleItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='margin-top:-10px;", this.tblWidth_MinWidth, "'>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(tblWidthMinWidth1)));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", this.objLanguage.GetLanguageConversion("Finished_Quantity"), "</div>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;", str1, ";'>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty1, "</span>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%;", str2, ";'>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty2, "</span>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%;", str3, ";'>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty3, "</span>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%;", str4, ";'>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText_summarypage'>", estimatesItem.Qty4, "</span>")));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        if (this.IsParentItem)
                        {

                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr id='trQtydescription'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str1, "'>")));
                            ControlCollection controls5 = this.plhDigiSingleItem.Controls;
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
                                object[] estimateItemID3 = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                controls5.Add(new LiteralControl(string.Concat(estimateItemID3)));
                            }
                            else
                            {
                                object[] estimateItemID3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew eprint-field-readonly' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                controls5.Add(new LiteralControl(string.Concat(estimateItemID3)));
                            }
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str2, "'>")));
                            ControlCollection controlCollections5 = this.plhDigiSingleItem.Controls;
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] objArray3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                controlCollections5.Add(new LiteralControl(string.Concat(objArray3)));
                            }
                            else
                            {
                                object[] objArray3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew eprint-field-readonly' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                controlCollections5.Add(new LiteralControl(string.Concat(objArray3)));
                            }
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str3, "'>")));
                            ControlCollection controls6 = this.plhDigiSingleItem.Controls;
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] estimateItemID4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                controls6.Add(new LiteralControl(string.Concat(estimateItemID4)));
                            }
                            else
                            {
                                object[] estimateItemID4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew eprint-field-readonly' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                controls6.Add(new LiteralControl(string.Concat(estimateItemID4)));
                            }
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td align='right' style='width: 21%; ", str4, "'>")));
                            ControlCollection controlCollections6 = this.plhDigiSingleItem.Controls;
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                controlCollections6.Add(new LiteralControl(string.Concat(objArray4)));
                            }
                            else
                            {
                                object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew eprint-field-readonly' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                controlCollections6.Add(new LiteralControl(string.Concat(objArray4)));
                            }
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        }
                        if (this.Module.ToLower() != "proof")
                        {
                            if (this.objBase.ReturnRoles_Privileges_Others("showcalculated").ToLower() != "false")
                            {
                                showCalculated = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                            }
                            else
                            {
                                showCalculated = "display:none;";
                            }
                            //this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr id='trPaper'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPaper' style='", showCalculated, "'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%; border:0px solid red;'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", empty, "</div>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%;border:0px solid red; ", strDimension1, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; border:0px solid red; ", strDimension2, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; border:0px solid red; ", strDimension3, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; border:0px solid red; ", strDimension4, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                            //this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr id='trPress'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPress' style='", showCalculated, "'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", str, "</div>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", strDimension2, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice3' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", strDimension4, ";'>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice4' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                            if (num4 > (long)0)
                            {
                                //this.plhDigiSingleItem.Controls.Add(new LiteralControl("<tr id='trGuillotine'>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", empty1, "</div>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", strDimension1, ";'>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", strDimension2, ";'>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", strDimension3, ";'>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", strDimension4, ";'>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText_summarypage'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl(" </td>"));
                                this.plhDigiSingleItem.Controls.Add(new LiteralControl("</tr>"));
                            }
                        }
                        this.plhDigiSingleItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    num++;
                }
            }
            else
            {
                ControlCollection controls5 = this.plhDigiSingleItem.Controls;
                var ignorelocking = "";
                var IsJobLocked = false;
                var locking = "";
                if (this.Module.ToLower() == "job")
                {
                    locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                    ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                    IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                }
                DataTable dataTable = EstimatesBasePage.estimate_single_item_select(this.CompanyID, this.EstimateItemID);
                foreach (DataRow row in dataTable.Rows)
                {
                    EstimatesItem estimatesItem = new EstimatesItem();

                    estimatesItem.Qty1 = Convert.ToInt32(row["Qty1"]);
                    estimatesItem.Qty2 = Convert.ToInt32(row["Qty2"]);
                    estimatesItem.Qty3 = Convert.ToInt32(row["Qty3"]);
                    estimatesItem.Qty4 = Convert.ToInt32(row["Qty4"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();

                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text'  readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }
                    else
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }

                    ControlCollection controlCollections5 = this.plhDigiSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(objArray3)));
                    }
                    else
                    {
                        object[] objArray3 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(objArray3)));
                    }
                    ControlCollection controls6 = this.plhDigiSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(estimateItemID4)));
                    }
                    else
                    {
                        object[] estimateItemID4 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(estimateItemID4)));
                    }

                    ControlCollection controlCollections6 = this.plhDigiSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(objArray4)));
                    }
                    else
                    {
                        object[] objArray4 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections6.Add(new LiteralControl(string.Concat(objArray4)));
                    }
                }
            }
        }
    }
}