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
    public partial class item_summary_quick_quote_item : UsercontrolBasePage
    {
        protected PlaceHolder plhQuickQuoteItem;

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

        public long jobID;

        
        public long EstimateItemID;

        public long TypeID;

        public long ParentEstimateItemID;

        public bool IsShowDelete;

        public bool IsParentItem;

        public bool Check_SpecialPrivilege;

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

        static item_summary_quick_quote_item()
        {
            item_summary_quick_quote_item.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_quick_quote_item()
        {
        }

        private void btnCopyitem_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.IsItemCopied = this.SummaryClassObj.CopyItem(this.EstimateID, Convert.ToInt64(button.CommandName), button.CommandArgument, this.Module, "sss");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Module.ToLower() != "proof")
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string str4 = "display:none";

                if (base.Request.Params["acthist"] != null)
                {
                    this.IsFrom = base.Request.Params["acthist"].ToString();
                }
                if (this.ParentQtyCount < this.QtyCount)
                {
                    this.QtyCount = this.ParentQtyCount;
                }
                if (this.ParentEstimateType.Trim().ToUpper() == "U")
                {
                    this.QtyCount = 1;
                }
                if (this.Module.ToLower() != "estimate")
                {
                    if (this.QtyNumber == 1)
                    {
                        str1 = "visibility:visible;";
                    }
                    else if (this.QtyNumber == 2)
                    {
                        str2 = "visibility:visible;";
                    }
                    else if (this.QtyNumber == 3)
                    {
                        str3 = "visibility:visible;";
                    }
                    else if (this.QtyNumber == 4)
                    {
                        str4 = "visibility:visible;";
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
                    str2 = "visibility:visible;";
                }
                else if (this.QtyCount == 3)
                {
                    this.tblWidth = "82%";
                    this.tblWidth_MinWidth = "min-width:520px;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
                }
                else if (this.QtyCount == 4)
                {
                    this.tblWidth = "100%";
                    this.tblWidth_MinWidth = "min-width:550px;";
                    str1 = "visibility:visible;";
                    str2 = "visibility:visible;";
                    str3 = "visibility:visible;";
                    str4 = "visibility:visible;";
                }
                foreach (DataRow row in EstimatesBasePage.estimate_quick_quote_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    long num = Convert.ToInt64(row["EstTypeID"]);
                    EstimatesItem estimatesItem = new EstimatesItem()
                    {
                        Qty1 = Convert.ToInt32(row["Quantity1"]),
                        Qty2 = Convert.ToInt32(row["Quantity2"]),
                        Qty3 = Convert.ToInt32(row["Quantity3"]),
                        Qty4 = Convert.ToInt32(row["Quantity4"])
                    };
                    string str5 = row["ItemTitle"].ToString();
                    string str6 = row["ItemTitle_New"].ToString();
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    if (!this.IsParentItem)
                    {
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='clear: both'>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<tr>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<td style='width: 16%;'>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<div style='float: left;width: 150px'>"));
                        ControlCollection controls = this.plhQuickQuoteItem.Controls;
                        object[] estimateItemID = new object[] { "<div class='box'><b>Quick Quote</b>&nbsp;<label id='lblItemTitle_", this.EstimateItemID, "' value='", str5, "' style='word-break: break-word;' >", this.objBase.SpecialDecode(str6), "</label></div>" };
                        controls.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<div style='width: 3%;float: left' align='right'>"));
                        if (this.Module.ToLower() == "estimate")
                        {
                            if (!this.IsShowJobReRun)
                            {
                                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=P&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                                string str7 = string.Concat(estimateID);
                                ControlCollection controlCollections = this.plhQuickQuoteItem.Controls;
                                object[] estType = new object[] { "<a href=", str7, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                                controlCollections.Add(new LiteralControl(string.Concat(estType)));
                            }
                        }
                        else if (this.Module.ToLower() != "job")
                        {
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=P&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            string str8 = string.Concat(objArray);
                            ControlCollection controls1 = this.plhQuickQuoteItem.Controls;
                            object[] estType1 = new object[] { "<a href=", str8, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                            controls1.Add(new LiteralControl(string.Concat(estType1)));
                        }
                        else if (!this.IsShowInvRerun)
                        {
                            object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=edit&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&esttype=P&parentestitemid=", this.ParentEstimateItemID, "&parentesttype=", this.ParentEstimateType, "&subedit=y&maintype=edit" };
                            string str9 = string.Concat(estimateID1);
                            ControlCollection controlCollections1 = this.plhQuickQuoteItem.Controls;
                            object[] objArray1 = new object[] { "<a href=", str9, "><img src=", this.strImagepath, "edit.gif border=0 title='Edit' width=10px height=10px style='cursor: pointer;' /></a>&nbsp;<a href='#' onclick=RemoveSubItems('", this.EstType, "','", this.EstimateItemID, "','", num, "','", this.EstimateID, "','", this.Module.ToString(), "','", this.ParentEstimateItemID, "');><img src=", this.strImagepath, "delete.gif border=0 title=Remove  width=10px height=10px /></a></div>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                        }
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</div>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</tr>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</table>"));
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:10px'></div>"));
                    }
                    else
                    {
                        this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<div style='clear:both;padding-top:10px'></div>"));
                    }
                    ControlCollection controls2 = this.plhQuickQuoteItem.Controls;
                    string[] tblWidthMinWidth = new string[] { "<table id='tblQuickQuoteItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controls2.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<tr id='trQuantity'>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-bottom:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Finished_Quantity"), "</div>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%; ", str1, "'>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity1' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity1_"+this.EstimateItemID+"' CssClass='normalText'>", estimatesItem.Qty1, "</span>")));

                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str2, "'>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity2' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity2_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty2, "</span>")));

                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str3, "'>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity3' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity3_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty3, "</span>")));

                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQty4' style='text-align: right; width: 21%; ", str4, "'>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span ID='spnQuantity4' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<span hidden ID='hdn_spnQuantity4_" + this.EstimateItemID + "' CssClass='normalText'>", estimatesItem.Qty4, "</span>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</table>"));
                    ControlCollection controlCollections2 = this.plhQuickQuoteItem.Controls;
                    string[] strArrays = new string[] { "<table id='tblQtydescription' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(strArrays)));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<tr id='trQtydesc'>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 150px; margin-bottom:-2px; clear: both'>", this.objLanguage.GetLanguageConversion("Qty_Description"), "</div>")));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc1' style='text-align: right; width: 21%; ", str1, "'>")));
                    ControlCollection controls3 = this.plhQuickQuoteItem.Controls;
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
                        controls3.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc1, "' />" };
                        controls3.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc2' style='text-align: right; width: 21%; ", str2, "'>")));
                    ControlCollection controlCollections3 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text'  id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat("<td id='tdQtydesc3' style='text-align: right; width: 21%; ", str3, "'>")));
                    ControlCollection controls4 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls4.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<input type='text'   id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc3, "' />" };
                        controls4.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(string.Concat(" <td id='tdQtydesc4' style='text-align: right; width: 21%; ", str4, "'>")));
                    ControlCollection controlCollections4 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }
                    else
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl(" </td>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</tr>"));
                    this.plhQuickQuoteItem.Controls.Add(new LiteralControl("</table>"));
                }
            }
            else
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
                foreach (DataRow row in EstimatesBasePage.estimate_quick_quote_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    EstimatesItem estimatesItem = new EstimatesItem()
                    {
                        Qty1 = Convert.ToInt32(row["Quantity1"]),
                        Qty2 = Convert.ToInt32(row["Quantity2"]),
                        Qty3 = Convert.ToInt32(row["Quantity3"]),
                        Qty4 = Convert.ToInt32(row["Quantity4"])
                    };
                    estimatesItem.Qtydesc1 = row["QTYDescription1"].ToString();
                    estimatesItem.Qtydesc2 = row["QTYDescription2"].ToString();
                    estimatesItem.Qtydesc3 = row["QTYDescription3"].ToString();
                    estimatesItem.Qtydesc4 = row["QTYDescription4"].ToString();
                    ControlCollection controls3 = this.plhQuickQuoteItem.Controls;
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
                        object[] estimateItemID1 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls3.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    else
                    {
                        object[] estimateItemID1 = new object[] { "<input type='text' id='txtQtydesc1_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc1, "' />" };
                        controls3.Add(new LiteralControl(string.Concat(estimateItemID1)));
                    }
                    ControlCollection controlCollections3 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    else
                    {
                        object[] estimateItemID2 = new object[] { "<input type='text'  id='txtQtydesc2_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc2, "' />" };
                        controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID2)));
                    }
                    ControlCollection controls4 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] objArray2 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controls4.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<input type='text'   id='txtQtydesc3_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc3, "' />" };
                        controls4.Add(new LiteralControl(string.Concat(objArray2)));
                    }
                    ControlCollection controlCollections4 = this.plhQuickQuoteItem.Controls;
                    if (IsJobLocked && ignorelocking != "true")
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text' readonly='readonly' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }
                    else
                    {
                        object[] estimateItemID3 = new object[] { "<input type='text' id='txtQtydesc4_", this.EstimateItemID, "' class='textboxnew' style='width: 80px;text-align: right;display:none' value='", estimatesItem.Qtydesc4, "' />" };
                        controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID3)));
                    }
                }
                    
            }
        }
    }
}