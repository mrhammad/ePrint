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
    public partial class item_summary_booklet_item : UsercontrolBasePage
    {
        protected PlaceHolder plhDigiBookletItem;

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

        public int SectionCount;

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

        public long EstItemID_BKN;

        public bool IsShowDelete;

        public bool IsParentItem;

        public bool Check_SpecialPrivilege;

        public bool IsItemCopied;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public static string IsEditOnlyHisRecords;

        public string SalesPersonID = string.Empty;

        public string IsFrom = string.Empty;

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

        static item_summary_booklet_item()
        {
            item_summary_booklet_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_booklet_item()
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
                int countBookletItems = 0;
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
                    this.IsFrom = base.Request.Params["acthist"].ToString();
                }
                string showCalculated = "display:none";
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder1 = new StringBuilder();
                int[] num = new int[4];
                decimal[] numArray = new decimal[4];
                decimal[] num1 = new decimal[4];
                decimal[] paperCostInMarkup1 = new decimal[4];
                decimal[] numArray1 = new decimal[4];
                decimal[] num2 = new decimal[4];
                decimal[] pressCostInMarkup1 = new decimal[4];
                decimal[] numArray2 = new decimal[4];
                decimal[] num3 = new decimal[4];
                decimal[] guillotineCostInMarkup1 = new decimal[4];
                int num4 = 0;
                int num5 = 0;
                DataTable dataTable = new DataTable();
                dataTable = EstimatesBasePage.estimate_booklet_item_select(this.CompanyID, this.EstimateItemID);
                foreach (DataRow row in dataTable.Rows)
                {
                    long num6 = Convert.ToInt64(row["EstTypeID"]);
                    this.QtyCount = Convert.ToInt32(row["QtyCount"]);
                    string str = this.objBase.SpecialDecode(row["ItemTitle_New"].ToString());
                    long num7 = Convert.ToInt64(row["PaperID"]);
                    long num8 = Convert.ToInt64(row["PressID"]);
                    long num9 = Convert.ToInt64(row["GuillotineID"]);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = "display:none";
                    string str3 = "display:none";
                    string str4 = "display:none";
                    string str5 = "display:none";
                    if (this.ParentQtyCount < this.QtyCount)
                    {
                        this.QtyCount = this.ParentQtyCount;
                    }
                    if (this.Module.ToLower() != "estimate")
                    {
                        if (this.QtyNumber == 1)
                        {
                            str2 = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 2)
                        {
                            str3 = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 3)
                        {
                            str4 = "visibility:visible;";
                        }
                        else if (this.QtyNumber == 4)
                        {
                            str5 = "visibility:visible;";
                        }
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                    }
                    else if (this.QtyCount == 1)
                    {
                        this.tblWidth = "42%";
                        this.tblWidth_MinWidth = "min-width:320px;";
                        str2 = "visibility:visible;";
                    }
                    else if (this.QtyCount == 2)
                    {
                        this.tblWidth = "62%";
                        this.tblWidth_MinWidth = "min-width:420px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                    }
                    else if (this.QtyCount == 3)
                    {
                        this.tblWidth = "82%";
                        this.tblWidth_MinWidth = "min-width:520px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                        str4 = "visibility:visible;";
                    }
                    else if (this.QtyCount == 4)
                    {
                        this.tblWidth = "100%";
                        this.tblWidth_MinWidth = "min-width:550px;";
                        str2 = "visibility:visible;";
                        str3 = "visibility:visible;";
                        str4 = "visibility:visible;";
                        str5 = "visibility:visible;";
                    }
                    if (this.Check_SpecialPrivilege)
                    {
                        empty = "Paper";
                        empty1 = "Press";
                        str1 = "Guillotine";
                    }
                    else if (this.IsFrom.ToLower() != "yes")
                    {
                        object[] estimateItemID1 = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=paper&EstimateItemID=", this.EstimateItemID, "&EstimateBookletItemID=", num6, "&EstType=B&From=B&module=", this.Module, "&PaperID=", num7, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\"/>", this.objLanguage.GetLanguageConversion("Paper"), "</a>" };
                        empty = string.Concat(estimateItemID1);
                        object[] objArray = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=press&EstimateItemID=", this.EstimateItemID, "&EstimateBookletItemID=", num6, "&EstType=B&From=B&module=", this.Module, "&PressID=", num8, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\"/>", this.objLanguage.GetLanguageConversion("Press"), "</a>" };
                        empty1 = string.Concat(objArray);
                        object[] estimateItemID11 = new object[] { "<a href='javascript://' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=costview&item=guillotine&EstimateItemID=", this.EstimateItemID, "&EstimateBookletItemID=", num6, "&EstType=B&From=B&module=", this.Module, "&GuillotineID=", num9, "',null,1000,500);SetRadWindow('divrad', 'divBackGroundNew', '200');\"/>", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>" };
                        str1 = string.Concat(estimateItemID11);
                    }
                    else
                    {
                        empty = string.Concat("<a href='#'>", this.objLanguage.GetLanguageConversion("Paper"), "</a>");
                        empty1 = string.Concat("<a href='#'>", this.objLanguage.GetLanguageConversion("Press"), "</a>");
                        str1 = string.Concat("<a href='#'>", this.objLanguage.GetLanguageConversion("Guillotine"), "</a>");
                    }

                    EstimatesItem estimatesItem = new EstimatesItem();
                    estimatesItem = new EstimatesItem();



                    estimatesItem.Qty1 = Convert.ToInt32(row["Qty1"]);
                    estimatesItem.Qty2 = Convert.ToInt32(row["Qty2"]);
                    estimatesItem.Qty3 = Convert.ToInt32(row["Qty3"]);
                    estimatesItem.Qty4 = Convert.ToInt32(row["Qty4"]);
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
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();

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

                    if (num5 == 0)
                    {
                        num[0] = num[0] + Convert.ToInt32(row["Qty1"]);
                        num[1] = num[1] + Convert.ToInt32(row["Qty2"]);
                        num[2] = num[2] + Convert.ToInt32(row["Qty3"]);
                        num[3] = num[3] + Convert.ToInt32(row["Qty4"]);
                    }
                    numArray[0] = numArray[0] + Convert.ToDecimal(row["PaperCostExMarkup1"]);
                    numArray[1] = numArray[1] + Convert.ToDecimal(row["PaperCostExMarkup2"]);
                    numArray[2] = numArray[2] + Convert.ToDecimal(row["PaperCostExMarkup3"]);
                    numArray[3] = numArray[3] + Convert.ToDecimal(row["PaperCostExMarkup4"]);
                    num1[0] = num1[0] + Convert.ToDecimal(row["PaperMarkupPrice1"]);
                    num1[1] = num1[1] + Convert.ToDecimal(row["PaperMarkupPrice2"]);
                    num1[2] = num1[2] + Convert.ToDecimal(row["PaperMarkupPrice3"]);
                    num1[3] = num1[3] + Convert.ToDecimal(row["PaperMarkupPrice4"]);
                    paperCostInMarkup1[0] = paperCostInMarkup1[0] + estimatesItem.PaperCostInMarkup1;
                    paperCostInMarkup1[1] = paperCostInMarkup1[1] + estimatesItem.PaperCostInMarkup2;
                    paperCostInMarkup1[2] = paperCostInMarkup1[2] + estimatesItem.PaperCostInMarkup3;
                    paperCostInMarkup1[3] = paperCostInMarkup1[3] + estimatesItem.PaperCostInMarkup4;
                    numArray1[0] = numArray1[0] + Convert.ToDecimal(row["PressCostExMarkup1"]);
                    numArray1[1] = numArray1[1] + Convert.ToDecimal(row["PressCostExMarkup2"]);
                    numArray1[2] = numArray1[2] + Convert.ToDecimal(row["PressCostExMarkup3"]);
                    numArray1[3] = numArray1[3] + Convert.ToDecimal(row["PressCostExMarkup4"]);
                    num2[0] = num2[0] + Convert.ToDecimal(row["PressMarkupPrice1"]);
                    num2[1] = num2[1] + Convert.ToDecimal(row["PressMarkupPrice2"]);
                    num2[2] = num2[2] + Convert.ToDecimal(row["PressMarkupPrice3"]);
                    num2[3] = num2[3] + Convert.ToDecimal(row["PressMarkupPrice4"]);
                    pressCostInMarkup1[0] = pressCostInMarkup1[0] + estimatesItem.PressCostInMarkup1;
                    pressCostInMarkup1[1] = pressCostInMarkup1[1] + estimatesItem.PressCostInMarkup2;
                    pressCostInMarkup1[2] = pressCostInMarkup1[2] + estimatesItem.PressCostInMarkup3;
                    pressCostInMarkup1[3] = pressCostInMarkup1[3] + estimatesItem.PressCostInMarkup4;
                    numArray2[0] = numArray2[0] + Convert.ToDecimal(row["GuillotineCostExMarkup1"]);
                    numArray2[1] = numArray2[1] + Convert.ToDecimal(row["GuillotineCostExMarkup2"]);
                    numArray2[2] = numArray2[2] + Convert.ToDecimal(row["GuillotineCostExMarkup3"]);
                    numArray2[3] = numArray2[3] + Convert.ToDecimal(row["GuillotineCostExMarkup4"]);
                    num3[0] = num3[0] + Convert.ToDecimal(row["GuillotineMarkupPrice1"]);
                    num3[1] = num3[1] + Convert.ToDecimal(row["GuillotineMarkupPrice2"]);
                    num3[2] = num3[2] + Convert.ToDecimal(row["GuillotineMarkupPrice3"]);
                    num3[3] = num3[3] + Convert.ToDecimal(row["GuillotineMarkupPrice4"]);
                    guillotineCostInMarkup1[0] = guillotineCostInMarkup1[0] + estimatesItem.GuillotineCostInMarkup1;
                    guillotineCostInMarkup1[1] = guillotineCostInMarkup1[1] + estimatesItem.GuillotineCostInMarkup2;
                    guillotineCostInMarkup1[2] = guillotineCostInMarkup1[2] + estimatesItem.GuillotineCostInMarkup3;
                    guillotineCostInMarkup1[3] = guillotineCostInMarkup1[3] + estimatesItem.GuillotineCostInMarkup4;

                    if (this.IsParentItem && num5 == 0)
                    {
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str, "</b></div><div style='clear:both;padding-top:10px'></div>")));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<td style='width: 16%;'>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 200px;'>", this.objLanguage.GetLanguageConversion("Current_Section"), "</div>")));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<td style='width: 84%;'>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<div class='box' style='width:auto;'>"));
                        DataView defaultView = dataTable.DefaultView;
                        string[] strArrays = new string[] { "EstimateBookletItemID", "SectionReference" };
                        DataTable table = defaultView.ToTable(true, strArrays);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                this.plhDigiBookletItem.Controls.Add(new LiteralControl("<div style='float:left;width:30px; border:0px solid red;'>"));
                                object[] objArray1 = new object[] { "onclick=\"javascript:ShowSection_ReEng(this,", this.EstimateItemID, ",'all',", table.Rows.Count, ");return false;\"" };
                                string str6 = string.Concat(objArray1);
                                ControlCollection controls = this.plhDigiBookletItem.Controls;
                                object[] estimateItemID2 = new object[] { "<input type='button' id='btnSection_", this.EstimateItemID, "_All' class='booklet_section_active' style='height:22px' value='All' ", str6, "  />" };
                                controls.Add(new LiteralControl(string.Concat(estimateItemID2)));
                                this.plhDigiBookletItem.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhDigiBookletItem.Controls.Add(new LiteralControl("<div style='float:left;width:auto;padding-left:15px'>"));
                            object[] objArray2 = new object[] { "onclick='javascript:ShowSection_ReEng(this,", this.EstimateItemID, ",", i, ",", table.Rows.Count, ");return false;'" };
                            string str7 = string.Concat(objArray2);
                            ControlCollection controlCollections = this.plhDigiBookletItem.Controls;
                            object[] estimateItemID3 = new object[] { "<input type='button' id='btnSection_", this.EstimateItemID, "_", i, "' class='button'  style='height:22px' value='", table.Rows[i]["SectionReference"].ToString().Replace("'", "`"), "' ", str7, "  />" };
                            controlCollections.Add(new LiteralControl(string.Concat(estimateItemID3)));
                            this.plhDigiBookletItem.Controls.Add(new LiteralControl("</div>"));
                            if (i == 4)
                            {
                                this.plhDigiBookletItem.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            }
                        }
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</table>"));
                    }



                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both;'>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("<tr>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("<td style='width: 16%;' colspan='2'>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl(string.Concat("<div class='ItemName_align' style='word-break: break-word;'><b class='ItemTitle_color'>", str5, "</b></div><div style='clear:both;padding-top:20px'></div>")));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("</td>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("</tr>"));
                    //this.plhDigiBookletItem.Controls.Add(new LiteralControl("</table>"));
                    countBookletItems = countBookletItems + 1;
                    if (countBookletItems == 1)
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
                        object[] estimateItemID;
                        string[] tblWidthMinWidth;
                        char[] chrArray;
                        int count = dataTable2.Rows.Count;

                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0'>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("<td style='width: 100%; vertical-align: top;'>"));
                        stringBuilder1 = new StringBuilder();
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
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl(string.Concat("<span CssClass='normalText'>", stringBuilder1.ToString(), "</span>")));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl(" </td>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDigiBookletItem.Controls.Add(new LiteralControl("</table>"));
                    }
                    if (this.objBase.ReturnRoles_Privileges_Others("showcalculated").ToLower() != "false")
                    {
                        showCalculated = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                    }
                    else
                    {
                        showCalculated = "display:none;";
                    }

                    stringBuilder1 = new StringBuilder();
                    object[] objArray3 = new object[] { "<table id='tblBookletItem_", this.EstimateItemID, "_", num5, "' style='display: none;min-width: 320px;' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    stringBuilder.Append(string.Concat(objArray3));
                    stringBuilder.Append("<tr id='trQuantity'>");
                    stringBuilder.Append("<td id='tdlbl' style='width: 16%'>");
                    stringBuilder.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Finished_Quantity"), "</div>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str2, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnQuantity1_"+ this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty1, "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str3, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty2, "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str4, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' runat='server' CssClass='normalText'>", estimatesItem.Qty3, "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str5, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty4, "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append("</tr>");
                    //stringBuilder.Append("<tr id='trPaper'>");
                    stringBuilder.Append(string.Concat("<tr id='trPaper' style='", showCalculated, "'>"));
                    stringBuilder.Append("<td id='tdlbl' style='width: 16%'>");
                    stringBuilder.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty, "</div>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%; ", str2, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; ", str3, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; ", str4, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", str5, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PaperCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append("</tr>");
                    //stringBuilder.Append("<tr id='trPress'>");
                    stringBuilder.Append(string.Concat("<tr id='trPress' style='", showCalculated, "'>"));
                    stringBuilder.Append("<td id='tdlbl' style='width: 16%'>");
                    stringBuilder.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", empty1, "</div>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", str2, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPressPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", str3, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPressPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", str4, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPressPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", str5, "'>"));
                    stringBuilder.Append(string.Concat("<span ID='spnPressPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.PressCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>"));
                    stringBuilder.Append(" </td>");
                    stringBuilder.Append("</tr>");
                    if (num9 > (long)0)
                    {
                        //stringBuilder.Append("<tr id='trGuillotine'>");
                        stringBuilder.Append(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>"));
                        stringBuilder.Append("<td id='tdlbl' style='width: 16%'>");
                        stringBuilder.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", str1, "</div>"));
                        stringBuilder.Append(" </td>");
                        stringBuilder.Append(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", str2, "'>"));
                        stringBuilder.Append(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup1, 0, "", false, false, true, false, true), true), "</span>"));
                        stringBuilder.Append(" </td>");
                        stringBuilder.Append(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", str3, "'>"));
                        stringBuilder.Append(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup2, 0, "", false, false, true, false, true), true), "</span>"));
                        stringBuilder.Append(" </td>");
                        stringBuilder.Append(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", str4, "'>"));
                        stringBuilder.Append(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup3, 0, "", false, false, true, false, true), true), "</span>"));
                        stringBuilder.Append(" </td>");
                        stringBuilder.Append(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", str5, "'>"));
                        stringBuilder.Append(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GuillotineCostInMarkup4, 0, "", false, false, true, false, true), true), "</span>"));
                        stringBuilder.Append(" </td>");
                        stringBuilder.Append("</tr>");
                        num4++;
                    }
                    stringBuilder.Append("</table>");
                    if (num5 + 1 == dataTable.Rows.Count)
                    {
                        object[] estimateItemID4 = new object[] { "<table id='tblBookletItem_", this.EstimateItemID, "_All' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                        stringBuilder1.Append(string.Concat(estimateItemID4));
                        stringBuilder1.Append("<tr id='trQuantity'>");
                        stringBuilder1.Append("<td id='tdlbl' style='width: 16%'>");
                        stringBuilder1.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Finished_Quantity"), "</div>"));
                        stringBuilder1.Append(" </td>");
                        stringBuilder1.Append(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str2, "'>"));
                        stringBuilder1.Append(string.Concat("<span ID='spnQuantity1_" + this.EstimateItemID + "' CssClass='normalText'>", num[0], "</span>"));
                        stringBuilder1.Append(" </td>");
                        stringBuilder1.Append(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str3, "'>"));
                        stringBuilder1.Append(string.Concat("<span ID='spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", num[1], "</span>"));
                        stringBuilder1.Append(" </td>");
                        stringBuilder1.Append(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str4, "'>"));
                        stringBuilder1.Append(string.Concat("<span ID='spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", num[2], "</span>"));
                        stringBuilder1.Append(" </td>");
                        stringBuilder1.Append(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str5, "'>"));
                        stringBuilder1.Append(string.Concat("<span ID='spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", num[3], "</span>"));
                        stringBuilder1.Append(" </td>");
                        stringBuilder1.Append("</tr>");
                        if (this.IsParentItem)
                        {
                            var locking = "";
                            var ignorelocking = "";
                            var IsJobLocked = false;
                            if (this.Module.ToLower() == "job")
                            {
                                locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                                ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                                IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                            }

                            stringBuilder1.Append("<tr id='trQtydescription'>");
                            stringBuilder1.Append("<td id='tdlbl' style='width: 16%'>");
                            stringBuilder1.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-top:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>"));
                            stringBuilder1.Append("</td>");
                            stringBuilder1.Append(string.Concat("<td align='right' style='width: 21%; ", str2, "'>"));
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                stringBuilder1.Append(string.Concat(objArray4));
                            }
                            else
                            {
                                object[] objArray4 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                                stringBuilder1.Append(string.Concat(objArray4));
                            }
                            stringBuilder1.Append("</td>");
                            stringBuilder1.Append(string.Concat("<td align='right' style='width: 21%; ", str3, "'>"));
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] estimateItemID5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                stringBuilder1.Append(string.Concat(estimateItemID5));
                            }
                            else
                            {
                                object[] estimateItemID5 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                                stringBuilder1.Append(string.Concat(estimateItemID5));
                            }
                            stringBuilder1.Append("</td>");
                            stringBuilder1.Append(string.Concat("<td align='right' style='width: 21%; ", str4, "'>"));
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] objArray5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                stringBuilder1.Append(string.Concat(objArray5));
                            }
                            else
                            {
                                object[] objArray5 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                                stringBuilder1.Append(string.Concat(objArray5));
                            }
                            stringBuilder1.Append("</td>");
                            stringBuilder1.Append(string.Concat("<td align='right' style='width: 21%; ", str5, "'>"));
                            if (IsJobLocked && ignorelocking != "true")
                            {
                                object[] estimateItemID6 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                stringBuilder1.Append(string.Concat(estimateItemID6));
                            }
                            else
                            {
                                object[] estimateItemID6 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                                stringBuilder1.Append(string.Concat(estimateItemID6));
                            }
                            stringBuilder1.Append("</td>");
                            stringBuilder1.Append("</tr>");
                        }
                        if (this.Module.ToLower() != "proof")
                        {
                            //stringBuilder1.Append("<tr id='trPaper'>");
                            stringBuilder.Append(string.Concat("<tr id='trPaper' style='", showCalculated, "'>"));
                            stringBuilder1.Append("<td id='tdlbl' style='width: 16%'>");
                            stringBuilder1.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Paper"), "</div>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPaper1' style='text-align: right; width: 21%; ", str2, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, paperCostInMarkup1[0], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPaper2' style='text-align: right; width: 21%; ", str3, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPaperPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, paperCostInMarkup1[1], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPaper3' style='text-align: right; width: 21%; ", str4, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPaperPrice13' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, paperCostInMarkup1[2], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat(" <td id='tdPaper4' style='text-align: right; width: 21%; ", str5, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPaperPrice14' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, paperCostInMarkup1[3], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append("</tr>");
                            //stringBuilder1.Append("<tr id='trPress'>");
                            stringBuilder.Append(string.Concat("<tr id='trPress' style='", showCalculated, "'>"));
                            stringBuilder1.Append("<td id='tdlbl' style='width: 16%'>");
                            stringBuilder1.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Press"), "</div>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPress1' style='text-align: right; width: 21%; ", str2, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPressPrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, pressCostInMarkup1[0], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPress2' style='text-align: right; width: 21%; ", str3, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPressPrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, pressCostInMarkup1[1], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat("<td id='tdPress3' style='text-align: right; width: 21%; ", str4, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPressPrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, pressCostInMarkup1[2], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append(string.Concat(" <td id='tdPress4' style='text-align: right; width: 21%; ", str5, "'>"));
                            stringBuilder1.Append(string.Concat("<span ID='spnPressPrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, pressCostInMarkup1[3], 0, "", false, false, true, false, true), true), "</span>"));
                            stringBuilder1.Append(" </td>");
                            stringBuilder1.Append("</tr>");
                            if (num4 > 0)
                            {
                                //stringBuilder1.Append("<tr id='trGuillotine'>");
                                stringBuilder.Append(string.Concat("<tr id='trGuillotine' style='", showCalculated, "'>"));
                                stringBuilder1.Append("<td id='tdlbl' style='width: 16%'>");
                                stringBuilder1.Append(string.Concat("<div class='bglabelItem_summary' style='width: 150px; clear: both'>", this.objLanguage.GetLanguageConversion("Guillotine"), "</div>"));
                                stringBuilder1.Append(" </td>");
                                stringBuilder1.Append(string.Concat("<td id='tdGuillotine1' style='text-align: right; width: 21%; ", str2, "'>"));
                                stringBuilder1.Append(string.Concat("<span ID='spnGuillotinePrice1' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, guillotineCostInMarkup1[0], 0, "", false, false, true, false, true), true), "</span>"));
                                stringBuilder1.Append(" </td>");
                                stringBuilder1.Append(string.Concat("<td id='tdGuillotine2' style='text-align: right; width: 21%; ", str3, "'>"));
                                stringBuilder1.Append(string.Concat("<span ID='spnGuillotinePrice2' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, guillotineCostInMarkup1[1], 0, "", false, false, true, false, true), true), "</span>"));
                                stringBuilder1.Append(" </td>");
                                stringBuilder1.Append(string.Concat("<td id='tdGuillotine3' style='text-align: right; width: 21%; ", str4, "'>"));
                                stringBuilder1.Append(string.Concat("<span ID='spnGuillotinePrice3' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, guillotineCostInMarkup1[2], 0, "", false, false, true, false, true), true), "</span>"));
                                stringBuilder1.Append(" </td>");
                                stringBuilder1.Append(string.Concat(" <td id='tdGuillotine4' style='text-align: right; width: 21%; ", str5, "'>"));
                                stringBuilder1.Append(string.Concat("<span ID='spnGuillotinePrice4' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, guillotineCostInMarkup1[3], 0, "", false, false, true, false, true), true), "</span>"));
                                stringBuilder1.Append(" </td>");
                                stringBuilder1.Append("</tr>");
                            }
                            stringBuilder1.Append("</table>");
                        }
                    }
                    num5++;
                }
                this.plhDigiBookletItem.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                this.plhDigiBookletItem.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            }
            else
            {
                var locking = "";
                var ignorelocking = "";
                var IsJobLocked = false;
                StringBuilder stringBuilder1 = new StringBuilder();
                if (this.Module.ToLower() == "job")
                {
                    locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                    ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                    IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                }
                DataTable dataTable = EstimatesBasePage.estimate_booklet_item_select(this.CompanyID, this.EstimateItemID);
                foreach (DataRow row in dataTable.Rows)
                {

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
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray4 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        stringBuilder1.Append(string.Concat(objArray4));
                    }
                    else
                    {
                        object[] objArray4 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        stringBuilder1.Append(string.Concat(objArray4));
                    }

                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        stringBuilder1.Append(string.Concat(estimateItemID5));
                    }
                    else
                    {
                        object[] estimateItemID5 = new object[] { "<input type='text' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        stringBuilder1.Append(string.Concat(estimateItemID5));
                    }

                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray5 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        stringBuilder1.Append(string.Concat(objArray5));
                    }
                    else
                    {
                        object[] objArray5 = new object[] { "<input type='text' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        stringBuilder1.Append(string.Concat(objArray5));
                    }

                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID6 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        stringBuilder1.Append(string.Concat(estimateItemID6));
                    }
                    else
                    {
                        object[] estimateItemID6 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        stringBuilder1.Append(string.Concat(estimateItemID6));
                    }
                    this.plhDigiBookletItem.Controls.Add(new LiteralControl(stringBuilder1.ToString()));

                }

            }
        }
    }
}