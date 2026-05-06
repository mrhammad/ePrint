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
    public partial class item_summary_litho_single_item : UsercontrolBasePage
    {
        protected PlaceHolder plhLithoSingleItem;

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass commclass = new commonClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public languageClass objlanguage = new languageClass();

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

        static item_summary_litho_single_item()
        {
            item_summary_litho_single_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_litho_single_item()
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
                string str = "display:none";
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
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
                        str = "visibility:visible;";
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
                        str1 = "visibility:visible;";
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
                        str2 = "visibility:visible;";
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
                        str3 = "visibility:visible;";
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
                    str = "visibility:visible;";
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
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
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
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
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
                    str = "visibility:visible;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
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
                foreach (DataRow row in EstimatesBasePage.estimate_litho_single_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    long num = Convert.ToInt64(row["EstTypeID"]);
                    string str4 = this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    string str5 = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    long num1 = Convert.ToInt64(row["GuillotineID"]);
                    long num2 = Convert.ToInt64(row["PaperID"]);
                    long num3 = Convert.ToInt64(row["PressID"]);
                    long num4 = Convert.ToInt64(row["PlateID"]);
                    bool flag = Convert.ToBoolean(row["MakeReadyPerPlateCheck"]);
                    bool flag1 = Convert.ToBoolean(row["WashupChargePerColourCheck"]);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = "Paper";
                        empty1 = "Press";
                        empty2 = "Guillotine";
                        empty3 = "Ink";
                        empty4 = "Plates";
                        empty5 = "Make Ready";
                        empty6 = "Wash Up";
                    }
                    else if (this.IsParentItem)
                    {
                        if (this.IsFromActHist.ToLower() != "yes")
                        {
                            estimateItemID = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PaperID=", num2, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Paper"), "</a>" };
                            empty = string.Concat(estimateItemID);
                            object[] objArray = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Press"), "</a>" };
                            empty1 = string.Concat(objArray);
                            object[] estimateItemID1 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&GuillotineID=", num1, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Guillotine"), "</a>" };
                            empty2 = string.Concat(estimateItemID1);
                            object[] objArray1 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=ink&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=SPL&module=", this.Module, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Ink"), "</a>" };
                            empty3 = string.Concat(objArray1);
                            object[] estimateItemID2 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=plates&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=Li&module=", this.Module, "&PlateID=", num4, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Plates"), "</a>" };
                            empty4 = string.Concat(estimateItemID2);
                            object[] objArray2 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=makeready&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=Li&module=", this.Module, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Make_Ready"), "</a>" };
                            empty5 = string.Concat(objArray2);
                            object[] estimateItemID3 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=washup&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&From=Li&module=", this.Module, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">", this.objlanguage.GetLanguageConversion("Wash_Up"), "</a>" };
                            empty6 = string.Concat(estimateItemID3);
                        }
                        else
                        {
                            empty = "<a href='#' name='SPLPaper' >Paper</a>";
                            empty1 = "<a href='#' name='SPLPress' >Press</a>";
                            empty2 = "<a href='#' name='SPLGuillotine'>Guillotine</a>";
                            empty3 = "<a href='#' name='SPLInk'>Ink</a>";
                            empty4 = "<a href='#' name='SPLInk'>Plates</a>";
                            empty5 = "<a href='#' name='SPLInk' >Make Ready</a>";
                            empty6 = "<a href='#' name='SPLInk'>Wash Up</a>";
                        }
                    }
                    else if (this.IsFromActHist.ToLower() != "yes")
                    {
                        object[] objArray3 = new object[] { "<a href='javascript://' name='SPLPaper' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PaperID=", num2, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Paper</a>" };
                        empty = string.Concat(objArray3);
                        object[] estimateItemID4 = new object[] { "<a href='javascript://' name='SPLPress' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Press</a>" };
                        empty1 = string.Concat(estimateItemID4);
                        object[] objArray4 = new object[] { "<a href='javascript://' name='SPLGuillotine' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&GuillotineID=", num1, "',1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Guillotine</a>" };
                        empty2 = string.Concat(objArray4);
                        object[] estimateItemID5 = new object[] { "<a href='javascript://' name='SPLInk' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=ink&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=SPL&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PressID=", num3, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Ink</a>" };
                        empty3 = string.Concat(estimateItemID5);
                        object[] objArray5 = new object[] { "<a href='javascript://' name='SPLPlates' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=plates&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=Li&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "&PlateID=", num4, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Plates</a>" };
                        empty4 = string.Concat(objArray5);
                        object[] estimateItemID6 = new object[] { "<a href='javascript://' name='SPLMakeReady' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=makeready&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=Li&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Make Ready</a>" };
                        empty5 = string.Concat(estimateItemID6);
                        object[] objArray6 = new object[] { "<a href='javascript://' name='SPLWashUp' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=washup&EstimateItemID=", this.EstimateItemID, "&TypeID=", num, "&EstType=", this.EstType, "&&From=Li&module=", this.Module, "&ParentEstimateItemID=", this.ParentEstimateItemID, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\">Wash Up</a>" };
                        empty6 = string.Concat(objArray6);
                    }
                    else
                    {
                        empty = "<a href='#' name='SPLPaper'>Paper</a>";
                        empty1 = "<a href='#' name='SPLPress'>Press</a>";
                        empty2 = "<a href='#' name='SPLGuillotine'>Guillotine</a>";
                        empty3 = "<a href='#' name='SPLInk'>Ink</a>";
                        empty4 = "<a href='#' name='SPLInk'>Plates</a>";
                        empty5 = "<a href='#' name='SPLInk'>Make Ready</a>";
                        empty6 = "<a href='#' name='SPLInk'>Wash Up</a>";
                    }

                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem = new EstimatesItem();


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
                    estimatesItem.InkCostExMarkup1 = Convert.ToDecimal(row["InkCostExMarkup1"]);
                    estimatesItem.InkCostExMarkup2 = Convert.ToDecimal(row["InkCostExMarkup2"]);
                    estimatesItem.InkCostExMarkup3 = Convert.ToDecimal(row["InkCostExMarkup3"]);
                    estimatesItem.InkCostExMarkup4 = Convert.ToDecimal(row["InkCostExMarkup4"]);
                    estimatesItem.InkMarkupPrice1 = Convert.ToDecimal(row["InkMarkupPrice1"]);
                    estimatesItem.InkMarkupPrice2 = Convert.ToDecimal(row["InkMarkupPrice2"]);
                    estimatesItem.InkMarkupPrice3 = Convert.ToDecimal(row["InkMarkupPrice3"]);
                    estimatesItem.InkMarkupPrice4 = Convert.ToDecimal(row["InkMarkupPrice4"]);
                    estimatesItem.InkCostInMarkup1 = estimatesItem.InkCostExMarkup1 + estimatesItem.InkMarkupPrice1;
                    estimatesItem.InkCostInMarkup2 = estimatesItem.InkCostExMarkup2 + estimatesItem.InkMarkupPrice2;
                    estimatesItem.InkCostInMarkup3 = estimatesItem.InkCostExMarkup3 + estimatesItem.InkMarkupPrice3;
                    estimatesItem.InkCostInMarkup4 = estimatesItem.InkCostExMarkup4 + estimatesItem.InkMarkupPrice4;
                    estimatesItem.PlatesCostExMarkup1 = Convert.ToDecimal(row["PlatesCostExMarkup1"]);
                    estimatesItem.PlatesCostExMarkup2 = Convert.ToDecimal(row["PlatesCostExMarkup2"]);
                    estimatesItem.PlatesCostExMarkup3 = Convert.ToDecimal(row["PlatesCostExMarkup3"]);
                    estimatesItem.PlatesCostExMarkup4 = Convert.ToDecimal(row["PlatesCostExMarkup4"]);
                    estimatesItem.PlatesMarkupPrice1 = Convert.ToDecimal(row["PlatesMarkupPrice1"]);
                    estimatesItem.PlatesMarkupPrice2 = Convert.ToDecimal(row["PlatesMarkupPrice2"]);
                    estimatesItem.PlatesMarkupPrice3 = Convert.ToDecimal(row["PlatesMarkupPrice3"]);
                    estimatesItem.PlatesMarkupPrice4 = Convert.ToDecimal(row["PlatesMarkupPrice4"]);
                    estimatesItem.PlatesCostInMarkup1 = estimatesItem.PlatesCostExMarkup1 + estimatesItem.PlatesMarkupPrice1;
                    estimatesItem.PlatesCostInMarkup2 = estimatesItem.PlatesCostExMarkup2 + estimatesItem.PlatesMarkupPrice2;
                    estimatesItem.PlatesCostInMarkup3 = estimatesItem.PlatesCostExMarkup3 + estimatesItem.PlatesMarkupPrice3;
                    estimatesItem.PlatesCostInMarkup4 = estimatesItem.PlatesCostExMarkup4 + estimatesItem.PlatesMarkupPrice4;
                    estimatesItem.MakeReadyCostExMarkup1 = Convert.ToDecimal(row["MakeReadyCostExMarkup1"]);
                    estimatesItem.MakeReadyCostExMarkup2 = Convert.ToDecimal(row["MakeReadyCostExMarkup2"]);
                    estimatesItem.MakeReadyCostExMarkup3 = Convert.ToDecimal(row["MakeReadyCostExMarkup3"]);
                    estimatesItem.MakeReadyCostExMarkup4 = Convert.ToDecimal(row["MakeReadyCostExMarkup4"]);
                    estimatesItem.MakeReadyMarkupPrice1 = Convert.ToDecimal(row["MakeReadyMarkupPrice1"]);
                    estimatesItem.MakeReadyMarkupPrice2 = Convert.ToDecimal(row["MakeReadyMarkupPrice2"]);
                    estimatesItem.MakeReadyMarkupPrice3 = Convert.ToDecimal(row["MakeReadyMarkupPrice3"]);
                    estimatesItem.MakeReadyMarkupPrice4 = Convert.ToDecimal(row["MakeReadyMarkupPrice4"]);
                    estimatesItem.MakeReadyCostInMarkup1 = estimatesItem.MakeReadyCostExMarkup1 + estimatesItem.MakeReadyMarkupPrice1;
                    estimatesItem.MakeReadyCostInMarkup2 = estimatesItem.MakeReadyCostExMarkup2 + estimatesItem.MakeReadyMarkupPrice2;
                    estimatesItem.MakeReadyCostInMarkup3 = estimatesItem.MakeReadyCostExMarkup3 + estimatesItem.MakeReadyMarkupPrice3;
                    estimatesItem.MakeReadyCostInMarkup4 = estimatesItem.MakeReadyCostExMarkup4 + estimatesItem.MakeReadyMarkupPrice4;
                    estimatesItem.WashUpCostExMarkup1 = Convert.ToDecimal(row["WashUpCostExMarkup1"]);
                    estimatesItem.WashUpCostExMarkup2 = Convert.ToDecimal(row["WashUpCostExMarkup2"]);
                    estimatesItem.WashUpCostExMarkup3 = Convert.ToDecimal(row["WashUpCostExMarkup3"]);
                    estimatesItem.WashUpCostExMarkup4 = Convert.ToDecimal(row["WashUpCostExMarkup4"]);
                    estimatesItem.WashUpMarkupPrice1 = Convert.ToDecimal(row["WashUpMarkupPrice1"]);
                    estimatesItem.WashUpMarkupPrice2 = Convert.ToDecimal(row["WashUpMarkupPrice2"]);
                    estimatesItem.WashUpMarkupPrice3 = Convert.ToDecimal(row["WashUpMarkupPrice3"]);
                    estimatesItem.WashUpMarkupPrice4 = Convert.ToDecimal(row["WashUpMarkupPrice4"]);
                    estimatesItem.WashUpCostInMarkup1 = estimatesItem.WashUpCostExMarkup1 + estimatesItem.WashUpMarkupPrice1;
                    estimatesItem.WashUpCostInMarkup2 = estimatesItem.WashUpCostExMarkup2 + estimatesItem.WashUpMarkupPrice2;
                    estimatesItem.WashUpCostInMarkup3 = estimatesItem.WashUpCostExMarkup3 + estimatesItem.WashUpMarkupPrice3;
                    estimatesItem.WashUpCostInMarkup4 = estimatesItem.WashUpCostExMarkup4 + estimatesItem.WashUpMarkupPrice4;
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
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td align='left' style='width: 100%;'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<div class='bglabelItem_summary'  style='width:150px; clear:both;'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<img alt='Img' title='Sheet Fed Offset: Single'  src='", this.strImagepath, "bullet-blue.png' class='Blue_bullet'  />")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<div style='float:left;'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<div class='additionaloptiontext'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span >", str5, "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<div class='Edit_DeleteIcon' >"));
                        if (this.IsFromActHist.ToLower() == "yes")
                        {
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("&nbsp;"));
                        }
                        else if (this.Module.ToLower() == "estimate")
                        {
                            if (!this.IsShowJobReRun)
                            {
                                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=F&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType };
                                string str6 = string.Concat(estimateID);
                                string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                                if (str7.ToLower() == "true" || str7 == "")
                                {
                                    ControlCollection controls = this.plhLithoSingleItem.Controls;
                                    tblWidthMinWidth = new string[] { "<a href=", str6, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                    controls.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                                }
                                string str8 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString());
                                if (str8.ToLower() == "true" || str8 == "")
                                {
                                    ControlCollection controlCollections = this.plhLithoSingleItem.Controls;
                                    object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections = this.plhLithoSingleItem.Controls;
                                    object[] estType = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(estType)));
                                }
                                this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (this.Module.ToLower() == "job")
                        {
                            if (!this.IsShowInvRerun)
                            {
                                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=F&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, this.jID, this.InvID };
                                string str9 = string.Concat(estimateID1);
                                string str10 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                                if (str10.ToLower() == "true" || str10 == "")
                                {
                                    ControlCollection controls1 = this.plhLithoSingleItem.Controls;
                                    string[] strArrays = new string[] { "<a href=", str9, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                    controls1.Add(new LiteralControl(string.Concat(strArrays)));
                                }
                                string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                                string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                                if (str11.ToLower() == "true" || str11 == "")
                                {
                                    ControlCollection controlCollections1 = this.plhLithoSingleItem.Controls;
                                    object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                }
                                else if (strRemove.Trim() == "1")
                                {
                                    ControlCollection controlCollections1 = this.plhLithoSingleItem.Controls;
                                    object[] estType1 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(estType1)));
                                }
                                this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (this.Module.ToLower() != "order")
                        {
                            object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=F&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType, this.jID, this.InvID };
                            string str12 = string.Concat(estimateID2);
                            string str131 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                            if (str131.ToLower() == "true" || str131 == "")
                            {
                                ControlCollection controls2 = this.plhLithoSingleItem.Controls;
                                string[] strArrays1 = new string[] { "<a href=", str12, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls2.Add(new LiteralControl(string.Concat(strArrays1)));
                            }
                            string str141 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                            if (str141.ToLower() == "true" || str141 == "")
                            {
                                ControlCollection controlCollections2 = this.plhLithoSingleItem.Controls;
                                estimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections2 = this.plhLithoSingleItem.Controls;
                                estimateItemID = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(estimateItemID)));
                            }
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (!this.IsShowJobReRun)
                        {
                            object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=F&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=", this.MainType };
                            string str151 = string.Concat(estimateID3);
                            string str161 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString());
                            if (str161.ToLower() == "true" || str161 == "")
                            {
                                ControlCollection controls3 = this.plhLithoSingleItem.Controls;
                                string[] strArrays2 = new string[] { "<a href=", str151, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;" };
                                controls3.Add(new LiteralControl(string.Concat(strArrays2)));
                            }
                            string str171 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString());
                            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString());
                            if (str171.ToLower() == "true" || str171 == "")
                            {
                                ControlCollection controlCollections3 = this.plhLithoSingleItem.Controls;
                                object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(estType2)));
                            }
                            else if (strRemove.Trim() == "1")
                            {
                                ControlCollection controlCollections3 = this.plhLithoSingleItem.Controls;
                                object[] estType2 = new object[] { "&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(estType2)));
                            }
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    else
                    {
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both; '>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str4, "</b></div><div style='clear:both;padding-top:10px'></div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</table>"));
                    }
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
                    //object[] estimateItemID;
                    //string[] tblWidthMinWidth;
                    char[] chrArray;
                    int count = dataTable2.Rows.Count;

                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
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
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("</table>"));

                    ControlCollection controls4 = this.plhLithoSingleItem.Controls;
                    tblWidthMinWidth = new string[] { "<table id='tblLithoSingleItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objlanguage.GetLanguageConversion("Finished_Quantity"), "</div>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str, "'>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str2, "'>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str3, "'>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                    if (this.IsParentItem)
                    {
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trQtyDescription'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objlanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc1' style='text-align: right; width: 21%; ", str, "'>")));
                        ControlCollection controlCollections4 = this.plhLithoSingleItem.Controls;
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
                            controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            estimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                            controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc2' style='text-align: right; width: 21%; ", str1, "'>")));
                        ControlCollection controls5 = this.plhLithoSingleItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                            controls5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            estimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                            controls5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc3' style='text-align: right; width: 21%; ", str2, "'>")));
                        ControlCollection controlCollections5 = this.plhLithoSingleItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                            controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                            controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQtydesc4' style='text-align: right; width: 21%; ", str3, "'>")));
                        ControlCollection controls6 = this.plhLithoSingleItem.Controls;
                        if (IsJobLocked && ignorelocking != "true")
                        {
                            estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                            controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                            controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                    }
                    if (this.objBase.ReturnRoles_Privileges_Others("showcalculated").ToLower() != "false")
                    {
                        showCalculated = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        showCalculated = "display:none;";
                    }
                    if (this.Module.ToLower() != "proof")
                    {
                        //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trPaper'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPaper' style='", showCalculated, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty, "</div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trInk'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trInk' style='", showCalculated, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty3, "</div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdInk3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdInk4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnInkPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.InkCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trPress'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPress' style='", showCalculated, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty1, "</div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPressPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        if (num1 > (long)0)
                        {
                            //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trGuillotine'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty2, "</div>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        }
                        //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trPlates'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trPlates' style='", showCalculated, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty4, "</div>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPlates1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPlatesPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PlatesCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPlates2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPlatesPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PlatesCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPlates3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPlatesPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PlatesCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdPlates4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPlatesPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PlatesCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        if (flag)
                        {
                            //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trMakeReady'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trMakeReady' style='", showCalculated, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty5, "</div>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdMakeReady1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMakeReadyPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MakeReadyCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdMakeReady2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMakeReadyPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MakeReadyCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdMakeReady3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMakeReadyPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MakeReadyCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdMakeReady4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnMakeReadyPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MakeReadyCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        }
                        if (flag1)
                        {
                            //this.plhLithoSingleItem.Controls.Add(new LiteralControl("<tr id='trWashUp'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<tr id='trWashUp' style='", showCalculated, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty6, "</div>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWashUp1' style='text-align: right; width: 21%; ", strDimension1, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnWashUpPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.WashUpCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWashUp2' style='text-align: right; width: 21%; ", strDimension2, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnWashUpPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.WashUpCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdWashUp3' style='text-align: right; width: 21%; ", strDimension3, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnWashUpPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.WashUpCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdWashUp4' style='text-align: right; width: 21%; ", strDimension4, "'>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnWashUpPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.WashUpCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>")));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl(" </td>"));
                            this.plhLithoSingleItem.Controls.Add(new LiteralControl("</tr>"));
                        }
                    }
                    this.plhLithoSingleItem.Controls.Add(new LiteralControl("</table>"));
                }
            }
            else
            {
                object[] estimateItemID;

                foreach (DataRow row in EstimatesBasePage.estimate_litho_single_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    var locking = "";
                    var ignorelocking = "";
                    var IsJobLocked = false;

                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem = new EstimatesItem();


                    estimatesItem.Qty1 = Convert.ToInt32(row["Qty1"]);
                    estimatesItem.Qty2 = Convert.ToInt32(row["Qty2"]);
                    estimatesItem.Qty3 = Convert.ToInt32(row["Qty3"]);
                    estimatesItem.Qty4 = Convert.ToInt32(row["Qty4"]);
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    ControlCollection controlCollections4 = this.plhLithoSingleItem.Controls;
                    if (this.Module.ToLower() == "job")
                    {
                        locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                        ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                        IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                    }
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    ControlCollection controls5 = this.plhLithoSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controls5.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    ControlCollection controlCollections5 = this.plhLithoSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    ControlCollection controls6 = this.plhLithoSingleItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        estimateItemID = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        estimateItemID = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                }
            }
        }
    }
}