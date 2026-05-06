using AjaxControlToolkit;
using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.ProductCatalogue
{
    public partial class ProductCatalogueItem_Stock : System.Web.UI.UserControl
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public static commonClass comm;

        public static ArrayList fieldnames;

        public int CompanyID;

        public int UserID;

        private DataTable dtsearch = new DataTable();

        public static int ProductCatalogueID;

        public string DateFormat = "mm/dd/yyyy";

        public static string ProductTitle;

        public static string WhereCondition;

        public static int MainTotalStock;

        private Global gloobj = new Global();

        public string pg = string.Empty;

        public string PageType = "productcatalogue";

        private BaseClass objbaseclass = new BaseClass();

        public static languageClass objLanguage;

        public static string stockparam;

        public static string headertype;

        public static string AdditionalHeaderType;

        private StringBuilder strBuildAdditional = new StringBuilder();

        public static string Price;

        public string validationmsg = string.Empty;

        public string PB = string.Empty;

        public int totalrows = 2;

        public string strSitepath = global.sitePath();

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

        static ProductCatalogueItem_Stock()
        {
            ProductCatalogueItem_Stock.comm = new commonClass();
            ProductCatalogueItem_Stock.fieldnames = new ArrayList();
            ProductCatalogueItem_Stock.ProductCatalogueID = 0;
            ProductCatalogueItem_Stock.ProductTitle = string.Empty;
            ProductCatalogueItem_Stock.WhereCondition = string.Empty;
            ProductCatalogueItem_Stock.MainTotalStock = 0;
            ProductCatalogueItem_Stock.objLanguage = new languageClass();
            ProductCatalogueItem_Stock.stockparam = "";
            ProductCatalogueItem_Stock.headertype = "";
            ProductCatalogueItem_Stock.AdditionalHeaderType = "";
            ProductCatalogueItem_Stock.Price = 0.ToString();
        }

        public ProductCatalogueItem_Stock()
        {
        }

        public void AdditionalAdjustments()
        {
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            this.hdnfld.Value = dataTable.Rows.Count.ToString();
            DataTable dataTable1 = WebstoreBasePage.pricecataloguestock_additional_select(ProductCatalogueItem_Stock.ProductCatalogueID);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tbladditionaladjustment' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr style='width:100%;background-color: #DDDDDD;position:relative'>");
            stringBuilder.Append("<td style='width: 6%;' align='left'>");
            stringBuilder.Append(string.Concat("<span style='padding-left:1px;'>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Alter"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 6%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Stock_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 6%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Total_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 6%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Allocated_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 6%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Available_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;  padding-left:20px' align='Left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Name"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Value"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 6%; padding-right:20px;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Price"), "<span>"));
            stringBuilder.Append("</td>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                stringBuilder.Append("<td style='width: 6%;' align='left'>");
                stringBuilder.Append(string.Concat("<span>", dataTable.Rows[i]["screenName"], "<span>"));
                stringBuilder.Append("</td>");
            }
            stringBuilder.Append("</tr>");
            for (int j = 0; j < dataTable1.Rows.Count; j++)
            {
                string str = "";
                str = (j % 2 != 0 ? "#EFEFEF" : "");
                string lower = dataTable1.Rows[j]["IsBackOrder"].ToString().ToLower();
                object[] objArray = new object[] { "<tr id='", j, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 6%;' align='left'>");
                object[] languageConversion = new object[] { "<select type='list' style='width:65px;height:19px;' id='ddlplusminus", j, "' onchange='javascript: EnableLocationFields(this.id,", j + 1, ",tbladditionaladjustment,hdn_totalqty", j, ",hdn_availQty", j, "); return false;'><option>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Select"), "</option><option>Move</option><option>+</option><option>-</option></select>" };
                stringBuilder.Append(string.Concat(languageConversion));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 6%;' align='left'>");
                object[] objArray1 = new object[] { "<input id='txtadjustqty", j, "' type='text' style='width:80px;text-align:right' value='0' onkeyup='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ",ddlplusminus", j, ",", lower, ",hdn_availQty", j, ");' onblur='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ",ddlplusminus", j, ",", lower, ",hdn_availQty", j, ");' class='textboxnew' />" };
                stringBuilder.Append(string.Concat(objArray1));
                object[] item = new object[] { "<input type='hidden' id='hdn_stockadditionalID", j, "' value='", dataTable1.Rows[j]["PricecatalogueStockAdditionalid"], "' />" };
                stringBuilder.Append(string.Concat(item));
                object[] item1 = new object[] { "<input type='hidden' id='hdn_totalqty", j, "' value='", dataTable1.Rows[j]["OpeningStock"], "' />" };
                stringBuilder.Append(string.Concat(item1));
                object[] item2 = new object[] { "<input type='hidden' id='hdnadjchoiceid", j, "' value='", dataTable1.Rows[j]["ChoiceID"], "' />" };
                stringBuilder.Append(string.Concat(item2));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 6%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable1.Rows[j]["OpeningStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 6%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable1.Rows[j]["AllocatedStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 6%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable1.Rows[j]["AvailableStock"], "</div>"));
                object[] objArray2 = new object[] { "<input type='hidden' id='hdn_availQty", j, "' value='", dataTable1.Rows[j]["AvailableStock"], "' />" };
                stringBuilder.Append(string.Concat(objArray2));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 11%; padding-left:20px' align='left'>");
                stringBuilder.Append(string.Concat("<div> ", dataTable1.Rows[j]["OptionName"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 8%;' align='left'>");
                stringBuilder.Append(string.Concat("<div>", dataTable1.Rows[j]["OptionValue"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 6%; padding-right:20px'  align='right'>");
                stringBuilder.Append(string.Concat("<div>", ProductCatalogueItem_Stock.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable1.Rows[j]["Price"].ToString()), 6, "", false, false, false), " </div>"));
                stringBuilder.Append("</td>");
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                {
                    stringBuilder.Append("<td style='width:9%;' align:'left'>");
                    object[] objArray3 = new object[] { "<input id='txt_Adjustment_Location_", j + 1, "' disabled type='text' style='width:125px;text-align:left' text='", dataTable1.Rows[j]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' value='", dataTable1.Rows[j]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' autocomplete='off'  onkeyup=javascript:GetLocationDetails(this,'hdn_Adjustment_locationid_", j + 1, "','Warehouse','", this.CompanyID, "','1',event);  onclick=javascript:GetLocationDetails(this,'hdn_Adjustment_locationid_", j + 1, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdn_Adjustment_locationid_", j + 1, ");'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray3));
                    object[] str1 = new object[] { "<input type='hidden' id='hdn_Adjustment_locationid_", j + 1, "' value='", dataTable1.Rows[j]["LocationID"].ToString(), "' />" };
                    stringBuilder.Append(string.Concat(str1));
                    stringBuilder.Append("</div></td>");
                }
                int num = 0;
                int num1 = 2;
                while (num1 < dataTable.Rows.Count + 2)
                {
                    if (num >= dataTable.Rows.Count)
                    {
                        continue;
                    }
                    for (int k = 2; k <= 6; k++)
                    {
                        if (dataTable.Rows[num]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", k))
                        {
                            stringBuilder.Append("<td style='width: 6%;' align='left'>");
                            object[] item3 = new object[] { "<input id='txt_Adjustment_customfield_", j + 1, "_", k, "' disabled type='text'  text='", dataTable1.Rows[j][string.Concat("Customfield", k)], "' value='", dataTable1.Rows[j][string.Concat("Customfield", k)], "' style='width:125px;text-align:left'  class='textboxnew' />" };
                            stringBuilder.Append(string.Concat(item3));
                            stringBuilder.Append("</div></td>");
                        }
                    }
                    num++;
                    num1++;
                }
                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnwebother' value='", dataTable1.Rows[j]["WebStoreOtherCostID"], "'>"));
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table >");
            this.plhadditionaladjustments.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public void Additionalpopupdetails()
        {
            DataTable dataTable = WebstoreBasePage.pricecataloguestock_additional_select(ProductCatalogueItem_Stock.ProductCatalogueID);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tbladditionalpopup' style='width:100%;border-collapse:collapse;z-index:999999;position:absoloute' cellpadding='4px' cellspacing='4px'  border='0px' >");
            stringBuilder.Append("<tr style='width:100%;background-color: #EEEEEE;'>");
            stringBuilder.Append("<td style='width: 10%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Name"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 7%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Value"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 5%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Current_Stock"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 5%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Allocated_Stock"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 5%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Available_Stock"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            if (dataTable.Rows.Count <= 0)
            {
                this.btnaddionalstocklevel.Visible = false;
            }
            else
            {
                this.btnaddionalstocklevel.Visible = true;
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string str = "";
                str = (i % 2 != 0 ? "#DDDDDD" : "");
                object[] objArray = new object[] { "<tr id='", i, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 10%;' align='left'>");
                stringBuilder.Append(string.Concat("<div> ", dataTable.Rows[i]["OptionName"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 7%;' align='left'>");
                stringBuilder.Append(string.Concat("<div>", dataTable.Rows[i]["OptionValue"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 5%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable.Rows[i]["OpeningStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 5%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable.Rows[i]["AllocatedStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 5%;' align='right'>");
                stringBuilder.Append(string.Concat("<div>", dataTable.Rows[i]["AvailableStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table >");
            this.plhadditionalstockdetails.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public void bindinventory(int ProductCatalogueID)
        {
            this.grdInventoryHistory.PagerStyle.AlwaysVisible = true;
            this.grdInventoryHistory.DataSource = this.GridBind(ProductCatalogueID, this.grdInventoryHistory.PageSize, this.grdInventoryHistory.CurrentPageIndex + 1, ProductCatalogueItem_Stock.WhereCondition);
        }

        protected void btninventory_onclick(object sender, EventArgs e)
        {
            this.bindinventory(ProductCatalogueItem_Stock.ProductCatalogueID);
        }

        protected void btnStockSave_Click(object sender, EventArgs e)
        {
            this.FinalSave("save");
        }

        protected void btnStockStay_Click(object sender, EventArgs e)
        {
            this.FinalSave("savestay");
        }

        public void callDrawFromAdditionalOptions()
        {
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            this.hdnfld.Value = dataTable.Rows.Count.ToString();
            SqlCommand sqlCommand = new SqlCommand("PC_SelectedAddtionalAddmore_Select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Companyid", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@PriceCatalogueID", ProductCatalogueItem_Stock.ProductCatalogueID);
            sqlCommand.Parameters.AddWithValue("actiontype", ProductCatalogueItem_Stock.AdditionalHeaderType);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter.Fill(dataTable1);
            this.totalrows = dataTable1.Rows.Count;
            if (ProductCatalogueItem_Stock.AdditionalHeaderType.ToLower() != "added")
            {
                this.strBuildAdditional.Append("<div>");
            }
            else
            {
                this.strBuildAdditional.Append("<div id='adddiv' style='display:none'>");
            }
            this.strBuildAdditional.Append("<table id='tbladditional' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            int num = 0;
            if (dataTable1.Rows.Count > 0)
            {
                if (ProductCatalogueItem_Stock.AdditionalHeaderType.ToLower() == "added")
                {
                    this.createadditionalheader();
                    this.div_addlnk.Style.Add("display", "block");
                }
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    if (ProductCatalogueItem_Stock.AdditionalHeaderType.ToLower() == "opening")
                    {
                        if (num != 0)
                        {
                            num = Convert.ToInt32(dataTable1.Rows[i]["WebOtherCostId"]);
                            if (i < dataTable1.Rows.Count - 1 && num != Convert.ToInt32(dataTable1.Rows[i - 1]["WebOtherCostId"]))
                            {
                                StringBuilder stringBuilder = this.strBuildAdditional;
                                object[] objArray = new object[] { "<tr style='width:100%;height:35px;border-top:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;border-right:2px solid white;border-left:2px solid white'><td colspan='2' style='width:200px'><label ><input type='checkbox' id='chkadd", num, "' onclick='javascript:validateadditionaloptioncheck(this.id);'  value='", num, "'  style='margin-left:-1px'/>", this.objbaseclass.SpecialDecode(dataTable1.Rows[i + 1]["WebOtherCostName"].ToString()), "</label></td><td></td></td></tr>" };
                                stringBuilder.Append(string.Concat(objArray));
                                this.createadditionalheader();
                            }
                        }
                        else
                        {
                            num = Convert.ToInt32(dataTable1.Rows[i]["WebOtherCostId"]);
                            StringBuilder stringBuilder1 = this.strBuildAdditional;
                            object[] objArray1 = new object[] { "<tr style='width:100.2%;height:35px;border-top:1px solid white;border-bottom:1px solid #CCCCCC;border-right:2px solid white;border-left:1px solid white'><td colspan='2' style='width:200px'><label><input type='checkbox' id='chkadd", num, "' onclick='javascript:validateadditionaloptioncheck(this.id);' checked='true'  value='", num, "' style='margin-left:-1px'/>", this.objbaseclass.SpecialDecode(dataTable1.Rows[i]["WebOtherCostName"].ToString()), "</label></td><td></td></td></tr>" };
                            stringBuilder1.Append(string.Concat(objArray1));
                            this.hdnmainwebothercostid.Value = num.ToString();
                            this.createadditionalheader();
                        }
                    }
                    string str = "";
                    str = (i % 2 != 0 ? "#EFEFEF" : "");
                    StringBuilder stringBuilder2 = this.strBuildAdditional;
                    object[] objArray2 = new object[] { "<tr id='", i, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px; border-left:1px solid #CCCCCC;border-right:1px solid #CCCCCC; '>" };
                    stringBuilder2.Append(string.Concat(objArray2));
                    this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
                    StringBuilder stringBuilder3 = this.strBuildAdditional;
                    object[] item = new object[] { "<input id='txtoptionname", i, "'type='text' style='width:100px;text-align:left' disabled='true' value='", dataTable1.Rows[i]["WebOtherCostName"], "' class='textboxnew' />" };
                    stringBuilder3.Append(string.Concat(item));
                    this.strBuildAdditional.Append("</td>");
                    this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
                    StringBuilder stringBuilder4 = this.strBuildAdditional;
                    object[] objArray3 = new object[] { "<input id='txtoptionvalue", i, "'type='text' style='width:100px;text-align:left' disabled='true'  value='", this.objbaseclass.SpecialEncode(dataTable1.Rows[i]["Label"].ToString()), "'   class='textboxnew' />" };
                    stringBuilder4.Append(string.Concat(objArray3));
                    this.strBuildAdditional.Append("</td>");
                    this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
                    this.strBuildAdditional.Append(string.Concat("<input id='txtopnstockadditional", i, "'type='text' style='width:100px;text-align:right' onblur='javascript:checkforInteger(this.id,this.value);' class='textboxnew' value='0'/>"));
                    this.strBuildAdditional.Append("</td>");
                    this.strBuildAdditional.Append("<td>");
                    StringBuilder stringBuilder5 = this.strBuildAdditional;
                    object[] price = new object[] { "<input id='txtadditionalprice", i, "'type='text' style='width:100px;text-align:right' value='", ProductCatalogueItem_Stock.Price, "' onblur='javascript:pricetodecimal(this,", i, ");' class='textboxnew'  />" };
                    stringBuilder5.Append(string.Concat(price));
                    this.strBuildAdditional.Append("</td>");
                    this.strBuildAdditional.Append("<td>");
                    StringBuilder stringBuilder6 = this.strBuildAdditional;
                    object[] dateFormat = new object[] { "<input id='txtstkdate", i, "'type='text' style='width:100px;text-align:left' value='", null, null, null, null };
                    commonClass _commonClass = ProductCatalogueItem_Stock.comm;
                    DateTime now = DateTime.Now;
                    dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                    dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                    dateFormat[5] = this.DateFormat;
                    dateFormat[6] = "');  class='textboxnew'  />";
                    stringBuilder6.Append(string.Concat(dateFormat));
                    this.strBuildAdditional.Append("</td>");
                    int num1 = 0;
                    if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                    {
                        this.strBuildAdditional.Append("<td style='width:14%;' align:'left'>");
                        this.strBuildAdditional.Append("<span style='margin-right:5px'>");
                        StringBuilder stringBuilder7 = this.strBuildAdditional;
                        object[] objArray4 = new object[] { "<img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='", this.strImagepath, "plus.gif' onclick=javascript:addstocklocation(", i, ",'w'); />" };
                        stringBuilder7.Append(string.Concat(objArray4));
                        this.strBuildAdditional.Append("</span>");
                        StringBuilder stringBuilder8 = this.strBuildAdditional;
                        object[] value = new object[] { "<input id='txtWhLocation", i, "'type='text' style='width:110px;text-align:left' autocomplete='off' value='", this.hdnDefaultStockLocation.Value, "'  onclick=javascript:GetLocationDetails(this,'hdnWhlocationid", i, "','Warehouse','", this.CompanyID, "','1',event);   onkeyup=javascript:GetLocationDetails(this,'hdnWhlocationid", i, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdnWhlocationid", i, ");'   class='textboxnew' />" };
                        stringBuilder8.Append(string.Concat(value));
                        StringBuilder stringBuilder9 = this.strBuildAdditional;
                        object[] value1 = new object[] { "<input type='hidden' id='hdnWhlocationid", i, "' value='", this.hdnDefaultLocationValue.Value, "' />" };
                        stringBuilder9.Append(string.Concat(value1));
                        this.strBuildAdditional.Append("</td>");
                        num1 = 1;
                    }
                    for (int j = 0; j < dataTable.Rows.Count - num1; j++)
                    {
                        this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
                        this.strBuildAdditional.Append(string.Concat("<input id='txtcustomfield", j, "'type='text' style='width:95px;text-align:left' class='textboxnew' />"));
                        this.strBuildAdditional.Append("</td>");
                    }
                    this.strBuildAdditional.Append("<td align='center' style='width: 8%'>");
                    StringBuilder stringBuilder10 = this.strBuildAdditional;
                    object[] objArray5 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", i, ",'tbladditional'); />" };
                    stringBuilder10.Append(string.Concat(objArray5));
                    this.strBuildAdditional.Append("</td>");
                    this.strBuildAdditional.Append(string.Concat("<input type='hidden' id='hdnwebother' value='", dataTable1.Rows[i]["WebOtherCostID"], "'>"));
                    StringBuilder stringBuilder11 = this.strBuildAdditional;
                    object[] item1 = new object[] { "<input type='hidden' id='hdnchoiceid", i, "' value='", dataTable1.Rows[i]["ChoiceID"], "'>" };
                    stringBuilder11.Append(string.Concat(item1));
                    this.strBuildAdditional.Append("</tr>");
                }
                this.strBuildAdditional.Append("</table>");
                this.strBuildAdditional.Append("</div>");
                this.plhadditionaloptions.Controls.Add(new LiteralControl(this.strBuildAdditional.ToString()));
            }
        }

        public void callotherproducts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblother' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr  style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Item_Code"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Item_Title"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Stock_to_be_adjusted_against_1_unit"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%;' align='center'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Action"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            for (int i = 1; i < 3; i++)
            {
                string str = "";
                str = (i % 2 != 0 ? "" : "#EFEFEF");
                object[] objArray = new object[] { "<tr id='", i, "' style='width:100%;background-color:", str, "'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 10%;' align='left'>");
                object[] companyID = new object[] { "<input  id='txtitemcode", i, "' type='text' style='width:165px;text-align:left' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle", i, "');  class='textboxnew' />" };
                stringBuilder.Append(string.Concat(companyID));
                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnOtherKitItemID", i, "' value='0' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 18%;' align='left'>");
                stringBuilder.Append(string.Concat("<input id='txtitemtitle", i, "' type='text' disabled='true' style='width:365px;text-align:left'  class='textboxnew' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 4%;' align='left'>");
                stringBuilder.Append(string.Concat("<input type='text' style='width:75px;text-align:right' id='txtunit", i, "' onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'  value='1' class='textboxnew' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td align='center' style='width: 8%'>");
                object[] objArray1 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", i, ",'tblother');  />" };
                stringBuilder.Append(string.Concat(objArray1));
                stringBuilder.Append("</td>");
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");
            this.plhdrawotherproducts.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            base.Session["SearchProd_History"] = null;
            ProductCatalogueItem_Stock.WhereCondition = "";
            foreach (GridColumn column in this.grdInventoryHistory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.grdInventoryHistory.MasterTableView.FilterExpression = string.Empty;
            this.bindinventory(ProductCatalogueItem_Stock.ProductCatalogueID);
            this.grdInventoryHistory.MasterTableView.Rebind();
        }

        public void createadditionalheader()
        {
            ProductCatalogueItem_Stock.fieldnames.Clear();
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            this.hdnfld.Value = dataTable.Rows.Count.ToString();
            this.strBuildAdditional.Append("<tr style='width:100%;background-color: #DDDDDD;  border-left:1px solid #CCCCCC;border-right:1px solid #CCCCCC;'>");
            this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
            this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Name"), "<span>"));
            this.strBuildAdditional.Append("</td>");
            this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
            this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Option_Value"), "<span>"));
            this.strBuildAdditional.Append("</td>");
            this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
            if (ProductCatalogueItem_Stock.AdditionalHeaderType.ToLower() == "opening")
            {
                this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Opening_Stock"), "<span>"));
            }
            else
            {
                this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Quantity"), "<span>"));
            }
            this.strBuildAdditional.Append("</td>");
            this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
            this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Price"), "<span>"));
            this.strBuildAdditional.Append("</td>");
            this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
            this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Date"), "<span>"));
            this.strBuildAdditional.Append("</td>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProductCatalogueItem_Stock.fieldnames.Add(dataTable.Rows[i]["datafieldname"].ToString().ToLower().Trim());
                this.strBuildAdditional.Append("<td style='width: 9%;' align='left'>");
                this.strBuildAdditional.Append(string.Concat("<span>", dataTable.Rows[i]["screenName"], "<span>"));
                this.strBuildAdditional.Append("</td>");
            }
            this.strBuildAdditional.Append("<td style='width: 8%;' align='center'>");
            this.strBuildAdditional.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Action"), "<span>"));
            this.strBuildAdditional.Append("</td>");
            this.strBuildAdditional.Append("</tr>");
        }

        public void Createmultipleproducts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblmultiple' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr  style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Item_Code"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Item_Title"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='center'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Default"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%;' align='center'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Action"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            for (int i = 1; i < 3; i++)
            {
                string str = "";
                str = (i % 2 != 0 ? "" : "#EFEFEF");
                object[] objArray = new object[] { "<tr id='", i, "' style='width:100%;background-color:", str, "'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 10%;' align='left'>");
                object[] companyID = new object[] { "<input  id='txtitemcodemultiple", i, "' type='text' style='width:165px;text-align:left' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID", i, "','txtitemtitlemultiple", i, "','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID", i, "','txtitemtitlemultiple", i, "','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitlemultiple", i, "');  class='textboxnew' />" };
                stringBuilder.Append(string.Concat(companyID));
                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnOtherMultipleKitItemID", i, "' value='0' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 18%;' align='left'>");
                stringBuilder.Append(string.Concat("<input id='txtitemtitlemultiple", i, "' type='text' disabled='true' style='width:365px;text-align:left'  class='textboxnew' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 4%;' align='center'>");
                stringBuilder.Append(string.Concat("<input type='checkbox' onclick=javascript:chkothermultipledefault(this.id);  id='chkdefault", i, "' />"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td align='center' style='width: 8%'>");
                object[] objArray1 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", i, ",'tblmultiple');  />" };
                stringBuilder.Append(string.Concat(objArray1));
                stringBuilder.Append("</td>");
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");
            this.plhothermultiple.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                Convert.ToInt32(row["Roundoff"].ToString());
            }
            base.Session["SearchProd_History"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && ProductCatalogueItem_Stock.WhereCondition != "")
                {
                    ProductCatalogueItem_Stock.WhereCondition = string.Concat(ProductCatalogueItem_Stock.WhereCondition, " and ");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(ProductCatalogueItem_Stock.WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(ProductCatalogueItem_Stock.WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(ProductCatalogueItem_Stock.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(ProductCatalogueItem_Stock.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = ProductCatalogueItem_Stock.WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItem_Stock.WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return ProductCatalogueItem_Stock.WhereCondition;
        }

        public void FinalSave(string pagetype)
        {
            char[] chrArray;
            if (base.Session["CompanyID"] == null && base.Session["UserID"] == null)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
            }
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            if (base.Request.Params["action"] == "edit")
            {
                try
                {
                    num3 = Convert.ToInt32(base.Request.Params["id"].ToString());
                }
                catch (Exception exception)
                {
                    base.Response.Redirect(string.Concat(this.strSitePath, "ProductCatalogue/pricecatalogue.aspx"));
                }
            }
            if (this.ddldrawstockfrom.SelectedItem.Value.ToLower() == "self")
            {
                empty = "S";
                if (this.chkReorderLevelEveryTime.Checked)
                {
                    str = "E";
                }
                else if (this.chkReorderLevelDaily.Checked)
                {
                    str = "D";
                }
                else if (this.chkReorderLevelWeekly.Checked)
                {
                    str = "W";
                }
                else if (this.rdoNone.Checked)
                {
                    str = "N";
                }
                ArrayList arrayLists = new ArrayList();
                if (this.ddlstkactivity.SelectedItem.Value.ToLower() == "add")
                {
                    string str1 = WebstoreBasePage.pricecataloguestock_actiontype_check((long)num3, "self");
                    if (num3 != 0)
                    {
                        string value = this.hdnstockselfdetails.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays = value.Split(chrArray);
                        for (int i = 0; i < (int)strArrays.Length - 1; i++)
                        {
                            if (strArrays[i] != "")
                            {
                                arrayLists.Clear();
                                string str2 = "";
                                string str3 = "";
                                string str4 = "";
                                string str5 = "";
                                string str6 = "";
                                string str7 = "";
                                string str8 = "";
                                string strNotes = "";
                                decimal num4 = new decimal(0);
                                DateTime date = DateTime.Now.Date;
                                string str9 = strArrays[i];
                                chrArray = new char[] { '±' };
                                string[] strArrays1 = str9.Split(chrArray);
                                for (int j = 0; j < (int)strArrays1.Length; j++)
                                {
                                    if (strArrays1[j] != "")
                                    {
                                        string str10 = strArrays1[j];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays2 = str10.Split(chrArray);
                                        if (string.Compare(strArrays2[0], "openstock", true) == 0)
                                        {
                                            if (strArrays2[1].ToString().Trim() != "")
                                            {
                                                str2 = strArrays2[1];
                                            }
                                        }
                                        else if (string.Compare(strArrays2[0], "price", true) == 0)
                                        {
                                            num4 = Convert.ToDecimal(strArrays2[1]);
                                        }
                                        else if (string.Compare(strArrays2[0], "Notes", true) == 0)
                                        {
                                            strNotes = strArrays2[1];
                                        }
                                        else if (string.Compare(strArrays2[0], "date", true) == 0)
                                        {
                                            if (strArrays2[1] != "")
                                            {
                                                string format = (new BasePage()).GetRegionalSettings(Convert.ToInt32(this.Session["CompanyID"]), "Dateformat");
                                                DateTime dt;
                                                if (format == "mm/dd/yyyy")
                                                    dt = DateTime.Parse(strArrays2[1], System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                                else
                                                    dt = DateTime.Parse(strArrays2[1], System.Globalization.CultureInfo.GetCultureInfo("en-gb"));

                                                strArrays2[1] = dt.ToString();

                                                string str11 = ProductCatalogueItem_Stock.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ProductCatalogueItem_Stock.comm.Eprint_return_Date_Before_View(strArrays2[1], this.CompanyID, this.UserID, true));
                                                date = Convert.ToDateTime(str11);
                                            }
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames.Count > 0)
                                        {
                                            arrayLists.Add(strArrays2[1]);
                                        }
                                    }
                                }
                                int num5 = 0;
                                while (num5 < ProductCatalogueItem_Stock.fieldnames.Count)
                                {
                                    if (num5 >= arrayLists.Count)
                                    {
                                        continue;
                                    }
                                    if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield1")
                                    {
                                        str3 = arrayLists[num5].ToString().Trim();
                                    }
                                    else if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield2")
                                    {
                                        str4 = arrayLists[num5].ToString().Trim();
                                    }
                                    else if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield3")
                                    {
                                        str5 = arrayLists[num5].ToString().Trim();
                                    }
                                    else if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield4")
                                    {
                                        str6 = arrayLists[num5].ToString().Trim();
                                    }
                                    else if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield5")
                                    {
                                        str7 = arrayLists[num5].ToString().Trim();
                                    }
                                    else if (ProductCatalogueItem_Stock.fieldnames[num5].ToString().ToLower().Trim() == "customfield6")
                                    {
                                        str8 = arrayLists[num5].ToString().Trim();
                                    }
                                    num5++;
                                }
                                if (str2.ToString().Trim() != "")
                                {
                                    WebstoreBasePage.pricecataloguestock_self_insert(num3, Convert.ToInt32(str2), str3, str4, str5, str6, str7, str8, num4, this.UserID, date, str1, "", strNotes);
                                    this.objbaseclass.UpdateKitProduct_StockLevels((long)num3, Convert.ToInt32(str2), "add");
                                }
                            }
                        }
                    }
                }
                else if (this.ddlstkactivity.SelectedValue.ToLower() == "adjustments")
                {
                    if (num3 != 0)
                    {
                        string str12 = "";
                        string str13 = "";
                        string str14 = "";
                        string str15 = "";
                        string str16 = "";
                        string str17 = "";
                        string value1 = this.hdnstockadjustment.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays3 = value1.Split(chrArray);
                        for (int k = 0; k < (int)strArrays3.Length; k++)
                        {
                            if (strArrays3[k] != "")
                            {
                                arrayLists.Clear();
                                long num6 = (long)0;
                                int num7 = 0;
                                string strNotes = "";
                                char chr = '+';
                                string str18 = strArrays3[k];
                                chrArray = new char[] { '±' };
                                string[] strArrays4 = str18.Split(chrArray);
                                for (int l = 0; l < (int)strArrays4.Length; l++)
                                {
                                    if (strArrays4[l] != "")
                                    {
                                        string str19 = strArrays4[l];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays5 = str19.Split(chrArray);
                                        if (string.Compare(strArrays5[0], "stockselfid", true) == 0)
                                        {
                                            num6 = Convert.ToInt64(strArrays5[1]);
                                        }

                                        else if (string.Compare(strArrays5[0], "Notes", true) == 0)
                                        {
                                            strNotes = strArrays5[1];
                                        }

                                        else if (string.Compare(strArrays5[0], "adjustqty", true) == 0)
                                        {
                                            string str20 = strArrays5[1];
                                            chrArray = new char[] { '~' };
                                            string[] strArrays6 = str20.Split(chrArray);
                                            chr = Convert.ToChar(strArrays6[0].ToString());
                                            num7 = Convert.ToInt32(strArrays6[1]);
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames.Count > 0 && chr == 'M')
                                        {
                                            string str21 = strArrays4[l];
                                            chrArray = new char[] { '»' };
                                            arrayLists.Add(str21.Split(chrArray)[1]);
                                        }
                                    }
                                }
                                int num8 = 0;
                                if (chr != 'M' || arrayLists.Count <= 0)
                                {
                                    WebstoreBasePage.pricecataloguestock_adjustments_update(num6, chr, num7, (long)num3, (long)this.UserID, this.ddladjustment.SelectedItem.Text, "", "", "", "", "", "", strNotes);
                                }
                                else
                                {
                                    while (num8 < ProductCatalogueItem_Stock.fieldnames.Count)
                                    {
                                        if (num8 >= arrayLists.Count)
                                        {
                                            continue;
                                        }
                                        if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield1")
                                        {
                                            str12 = arrayLists[num8].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield2")
                                        {
                                            str13 = arrayLists[num8].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield3")
                                        {
                                            str14 = arrayLists[num8].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield4")
                                        {
                                            str15 = arrayLists[num8].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield5")
                                        {
                                            str16 = arrayLists[num8].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num8].ToString().ToLower().Trim() == "customfield6")
                                        {
                                            str17 = arrayLists[num8].ToString().Trim();
                                        }
                                        num8++;
                                    }
                                    WebstoreBasePage.pricecataloguestock_adjustments_update(num6, chr, num7, (long)num3, (long)this.UserID, this.ddladjustment.SelectedItem.Text, str12, str13, str14, str15, str16, str17, strNotes);
                                }
                                this.objbaseclass.UpdateKitProduct_StockLevels((long)num3, Convert.ToInt32(num7), "adjusted");
                            }
                        }
                    }
                }
                else if (this.ddlstkactivity.SelectedItem.Value.ToLower() == "release" && Convert.ToInt32(this.txtrefqty.Text) != 0)
                {
                    this.objbaseclass.ManuallyStockReductionProcess(Convert.ToInt64(this.hdnEstimateID.Value), Convert.ToInt64(ProductCatalogueItem_Stock.ProductCatalogueID), (long)this.CompanyID, Convert.ToInt32(this.txtrefqty.Text), (long)this.UserID);
                    this.objbaseclass.UpdateKitProduct_StockLevels((long)num3, Convert.ToInt32(this.txtrefqty.Text), "Released");
                }
            }
            else if (this.ddldrawstockfrom.SelectedItem.Value.ToLower() == "otherproducts")
            {
                empty = "O";
                if (num3 != 0)
                {
                    string str22 = WebstoreBasePage.pricecataloguestock_actiontype_check((long)num3, "other");
                    string value2 = this.hdnOtherProductDetails.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays7 = value2.Split(chrArray);
                    for (int m = 0; m < (int)strArrays7.Length; m++)
                    {
                        if (strArrays7[m] != "")
                        {
                            long num9 = (long)0;
                            int num10 = 0;
                            string str23 = strArrays7[m];
                            chrArray = new char[] { '±' };
                            string[] strArrays8 = str23.Split(chrArray);
                            for (int n = 0; n < (int)strArrays8.Length; n++)
                            {
                                string str24 = strArrays8[n];
                                chrArray = new char[] { '»' };
                                string[] strArrays9 = str24.Split(chrArray);
                                if (string.Compare(strArrays9[0], "kititemid", true) == 0)
                                {
                                    if (strArrays9[1] != "")
                                    {
                                        num9 = Convert.ToInt64(strArrays9[1]);
                                    }
                                }
                                else if (string.Compare(strArrays9[0], "unit", true) == 0)
                                {
                                    num10 = Convert.ToInt32(strArrays9[1]);
                                }
                            }
                            WebstoreBasePage.pricecataloguestock_other_insert(ProductCatalogueItem_Stock.ProductCatalogueID, num9, num10, this.UserID);
                        }
                    }
                    int num11 = this.objbaseclass.Check_MaxKit_Availability((long)ProductCatalogueItem_Stock.ProductCatalogueID, 0);
                    WebstoreBasePage.pricecataloguestock_Quantity_Update((long)ProductCatalogueItem_Stock.ProductCatalogueID, num11, num11, 0);
                    if (str22.ToLower() == "opening")
                    {
                        this.objbaseclass.StockAllocationManagementHistory_Save((long)0, (long)ProductCatalogueItem_Stock.ProductCatalogueID, str22, "Opening stock Added", num11, 0, 0, 0, (long)this.UserID, (long)0);
                    }
                    else if (str22.ToLower() == "added")
                    {
                        this.objbaseclass.StockAllocationManagementHistory_Save((long)0, (long)ProductCatalogueItem_Stock.ProductCatalogueID, str22, "Stock Added Manually", num11, 0, 0, 0, (long)this.UserID, (long)0);
                    }
                }
            }
            else if (this.ddldrawstockfrom.SelectedItem.Value.ToLower() == "additionaloptions")
            {
                ArrayList arrayLists1 = new ArrayList();
                string str25 = "";
                string str26 = "";
                string str27 = "";
                string str28 = "";
                string str29 = "";
                string str30 = "";
                string str31 = "";
                string str32 = "";
                string str33 = "";
                empty = "A";
                if (this.ddl_additionalactivity.SelectedItem.Value.ToLower() == "add")
                {
                    if (num3 != 0)
                    {
                        string str34 = WebstoreBasePage.pricecataloguestock_actiontype_checkAdditional((long)ProductCatalogueItem_Stock.ProductCatalogueID);
                        string value3 = this.hdnAdditionalOptionDetails.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays10 = value3.Split(chrArray);
                        for (int o = 0; o < (int)strArrays10.Length - 1; o++)
                        {
                            if (strArrays10[o] != "")
                            {
                                arrayLists1.Clear();
                                int num12 = 0;
                                decimal num13 = new decimal(0);
                                DateTime dateTime = DateTime.Now.Date;
                                int num14 = 0;
                                string str35 = strArrays10[o];
                                chrArray = new char[] { '±' };
                                string[] strArrays11 = str35.Split(chrArray);
                                for (int p = 0; p < (int)strArrays11.Length; p++)
                                {
                                    if (strArrays11[p] != "")
                                    {
                                        string str36 = strArrays11[p];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays12 = str36.Split(chrArray);
                                        if (string.Compare(strArrays12[0], "optionname", true) == 0)
                                        {
                                            if (strArrays12[1] != "")
                                            {
                                                str25 = strArrays12[1].ToString();
                                            }
                                        }
                                        else if (string.Compare(strArrays12[0], "optionvalue", true) == 0)
                                        {
                                            str26 = strArrays12[1].ToString();
                                        }
                                        else if (string.Compare(strArrays12[0], "openstock", true) == 0)
                                        {
                                            if (strArrays12[1].ToString().Trim() != "")
                                            {
                                                str27 = strArrays12[1];
                                            }
                                        }
                                        else if (string.Compare(strArrays12[0], "webother", true) == 0)
                                        {
                                            num12 = Convert.ToInt32(strArrays12[1]);
                                        }
                                        else if (string.Compare(strArrays12[0], "price", true) == 0)
                                        {
                                            num13 = Convert.ToDecimal(strArrays12[1]);
                                        }
                                        else if (string.Compare(strArrays12[0], "choiceid", true) == 0)
                                        {
                                            num14 = Convert.ToInt32(strArrays12[1]);
                                        }
                                        else if (string.Compare(strArrays12[0], "date", true) == 0)
                                        {
                                            if (strArrays12[1] != "")
                                            {
                                                string str37 = ProductCatalogueItem_Stock.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ProductCatalogueItem_Stock.comm.Eprint_return_Date_Before_View(strArrays12[1], this.CompanyID, this.UserID, true));
                                                dateTime = Convert.ToDateTime(str37);
                                            }
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames.Count > 0)
                                        {
                                            arrayLists1.Add(strArrays12[1]);
                                        }
                                    }
                                }
                                if (ProductCatalogueItem_Stock.fieldnames.Count == arrayLists1.Count)
                                {
                                    int num15 = 0;
                                    while (num15 < ProductCatalogueItem_Stock.fieldnames.Count)
                                    {
                                        if (num15 >= arrayLists1.Count)
                                        {
                                            continue;
                                        }
                                        if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield1")
                                        {
                                            str28 = arrayLists1[num15].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield2")
                                        {
                                            str29 = arrayLists1[num15].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield3")
                                        {
                                            str30 = arrayLists1[num15].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield4")
                                        {
                                            str31 = arrayLists1[num15].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield5")
                                        {
                                            str32 = arrayLists1[num15].ToString().Trim();
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames[num15].ToString().ToLower().Trim() == "customfield6")
                                        {
                                            str33 = arrayLists1[num15].ToString().Trim();
                                        }
                                        num15++;
                                    }
                                    if (str27.ToString().Trim() != "")
                                    {
                                        if (str34.ToLower() != "opening")
                                        {
                                            WebstoreBasePage.pricecataloguestock_additional_insert(num3, str25, str26, Convert.ToInt32(str27), str28, str29, str30, str31, str32, str33, num12, this.UserID, dateTime, num13, str34, num14, "");
                                        }
                                        else if (num12 == Convert.ToInt32(this.hdnmainwebothercostid.Value))
                                        {
                                            WebstoreBasePage.pricecataloguestock_additional_insert(num3, str25, str26, Convert.ToInt32(str27), str28, str29, str30, str31, str32, str33, num12, this.UserID, dateTime, num13, str34, num14, "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.ddl_additionalactivity.SelectedItem.Value.ToLower() == "adjustments")
                {
                    if (num3 != 0)
                    {
                        string value4 = this.hdnAdditionalStockAdjustment.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays13 = value4.Split(chrArray);
                        for (int q = 0; q < (int)strArrays13.Length; q++)
                        {
                            if (strArrays13[q] != "")
                            {
                                arrayLists1.Clear();
                                char chr1 = '+';
                                long num16 = (long)0;
                                int num17 = 0;
                                long num18 = (long)0;
                                string str38 = strArrays13[q];
                                chrArray = new char[] { '±' };
                                string[] strArrays14 = str38.Split(chrArray);
                                for (int r = 0; r < (int)strArrays14.Length; r++)
                                {
                                    if (strArrays14[r] != "")
                                    {
                                        string str39 = strArrays14[r];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays15 = str39.Split(chrArray);
                                        if (string.Compare(strArrays15[0], "additionalstockID", true) == 0)
                                        {
                                            num16 = Convert.ToInt64(strArrays15[1]);
                                        }
                                        else if (string.Compare(strArrays15[0], "adjustqty", true) == 0)
                                        {
                                            string str40 = strArrays15[1];
                                            chrArray = new char[] { '~' };
                                            string[] strArrays16 = str40.Split(chrArray);
                                            chr1 = Convert.ToChar(strArrays16[0].ToString());
                                            num17 = Convert.ToInt32(strArrays16[1]);
                                        }
                                        else if (string.Compare(strArrays15[0], "choiceid", true) == 0)
                                        {
                                            num18 = Convert.ToInt64(strArrays15[1]);
                                        }
                                        else if (ProductCatalogueItem_Stock.fieldnames.Count > 0 && chr1 == 'M')
                                        {
                                            string str41 = strArrays14[r];
                                            chrArray = new char[] { '»' };
                                            arrayLists1.Add(str41.Split(chrArray)[1]);
                                        }
                                    }
                                }
                                if (ProductCatalogueItem_Stock.fieldnames.Count != arrayLists1.Count)
                                {
                                    WebstoreBasePage.pricecataloguestock_AdditionalAdjustments_update(num16, chr1, num17, (long)num3, (long)this.UserID, this.ddladditionaladjtype.SelectedItem.Text, num18, "", "", "", "", "", "");
                                }
                                else
                                {
                                    int num19 = 0;
                                    if (chr1 != 'M' || arrayLists1.Count <= 0)
                                    {
                                        WebstoreBasePage.pricecataloguestock_AdditionalAdjustments_update(num16, chr1, num17, (long)num3, (long)this.UserID, this.ddladditionaladjtype.SelectedItem.Text, num18, "", "", "", "", "", "");
                                    }
                                    else
                                    {
                                        while (num19 < ProductCatalogueItem_Stock.fieldnames.Count)
                                        {
                                            if (num19 >= arrayLists1.Count)
                                            {
                                                continue;
                                            }
                                            if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield1")
                                            {
                                                str28 = arrayLists1[num19].ToString().Trim();
                                            }
                                            else if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield2")
                                            {
                                                str29 = arrayLists1[num19].ToString().Trim();
                                            }
                                            else if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield3")
                                            {
                                                str30 = arrayLists1[num19].ToString().Trim();
                                            }
                                            else if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield4")
                                            {
                                                str31 = arrayLists1[num19].ToString().Trim();
                                            }
                                            else if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield5")
                                            {
                                                str32 = arrayLists1[num19].ToString().Trim();
                                            }
                                            else if (ProductCatalogueItem_Stock.fieldnames[num19].ToString().ToLower().Trim() == "customfield6")
                                            {
                                                str33 = arrayLists1[num19].ToString().Trim();
                                            }
                                            num19++;
                                        }
                                        WebstoreBasePage.pricecataloguestock_AdditionalAdjustments_update(num16, chr1, num17, (long)num3, (long)this.UserID, this.ddladditionaladjtype.SelectedItem.Text, num18, str28, str29, str30, str31, str32, str33);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.ddl_additionalactivity.SelectedItem.Value.ToLower() == "release" && Convert.ToInt32(this.txtadditionalrefrenceqty.Text) != 0)
                {
                    this.objbaseclass.ManuallyStockReductionProcessForAdditionalOption(Convert.ToInt64(this.hdnEstimateID.Value), Convert.ToInt64(ProductCatalogueItem_Stock.ProductCatalogueID), (long)this.CompanyID, Convert.ToInt32(this.txtadditionalrefrenceqty.Text), (long)this.UserID);
                }
            }
            else if (this.ddldrawstockfrom.SelectedItem.Value.ToLower() == "othermultiple")
            {
                ArrayList arrayLists2 = new ArrayList();
                empty = "M";
                if (num3 != 0)
                {
                    SqlCommand sqlCommand = new SqlCommand("PC_Pricecataloguestock_othermultiple_delete", (new commonClass()).openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@PricecatalogueID", ProductCatalogueItem_Stock.ProductCatalogueID);
                    sqlCommand.ExecuteNonQuery();
                    string value5 = this.hdnOtherMutipleDetails.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays17 = value5.Split(chrArray);
                    for (int s = 0; s < (int)strArrays17.Length; s++)
                    {
                        if (strArrays17[s] != "")
                        {
                            int num20 = 0;
                            long num21 = (long)0;
                            string str42 = strArrays17[s];
                            chrArray = new char[] { '±' };
                            string[] strArrays18 = str42.Split(chrArray);
                            for (int t = 0; t < (int)strArrays18.Length; t++)
                            {
                                string str43 = strArrays18[t];
                                chrArray = new char[] { '»' };
                                string[] strArrays19 = str43.Split(chrArray);
                                if (string.Compare(strArrays19[0], "kititemid", true) == 0)
                                {
                                    if (strArrays19[1] != "")
                                    {
                                        num21 = Convert.ToInt64(strArrays19[1]);
                                    }
                                }
                                else if (string.Compare(strArrays19[0], "default", true) == 0)
                                {
                                    num20 = Convert.ToInt32(strArrays19[1]);
                                }
                            }
                            WebstoreBasePage.pricecataloguestock_othermultiple_insert(ProductCatalogueItem_Stock.ProductCatalogueID, num21, num20, this.UserID);
                        }
                    }
                }
            }
            else if (this.ddldrawstockfrom.SelectedItem.Value.ToLower() == "simplestock")
            {
                empty = "P";
                num = Convert.ToInt32(txtSimpleQuantity.Text);
                num2 = Convert.ToInt32(txtSimpleQuantity.Text);
            }
            bool detail = false;
            if (this.chkMultiDetail.Checked)
            {
                detail = true;
            }
            WebstoreBasePage.pricecataloguestock_stockdetails_update(num3, empty, Convert.ToInt32(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), str, this.txtemail.Text, num, num1, num2, detail);
            if (pagetype.ToLower() != "save")
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "common/common_popup.aspx?type=stockedit&action=edit&id=", num3));
            }
            else
            {
                if (base.Request.Params["managestock"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().close();", true);
                    return;
                }
                if (base.Request.Params["managestock"].ToString().ToLower() == "yes")
                {
                    Type type = base.GetType();
                    object[] objArray = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitePath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num3, "&page=g';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(objArray), true);
                    return;
                }
            }
        }

        public void getadditionaloptiondetails()
        {
            int j;
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            this.hdnfld.Value = dataTable.Rows.Count.ToString();
            DataTable dataTable1 = WebstoreBasePage.pricecataloguestock_additional_select(ProductCatalogueItem_Stock.ProductCatalogueID);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tbladditional' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 9%;' align='left'>");
            stringBuilder.Append("<span>Option Name<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='left'>");
            stringBuilder.Append("<span>Option Value<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='left'>");
            if (ProductCatalogueItem_Stock.AdditionalHeaderType.ToLower() == "opening")
            {
                stringBuilder.Append("<span>Opening Stock<span>");
            }
            else
            {
                stringBuilder.Append("<span>Quantity<span>");
            }
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='left'>");
            stringBuilder.Append("<span>Price<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='left'>");
            stringBuilder.Append("<span>Date<span>");
            stringBuilder.Append("</td>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                stringBuilder.Append("<td style='width: 9%;' align='left'>");
                stringBuilder.Append(string.Concat("<span>", dataTable.Rows[i]["screenName"], "<span>"));
                stringBuilder.Append("</td>");
            }
            stringBuilder.Append("<td style='width: 8%;' align='center'>");
            stringBuilder.Append("<span>Action<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            if (dataTable1.Rows.Count == 0)
            {
                this.callDrawFromAdditionalOptions();
                return;
            }
            for (j = 0; j < dataTable1.Rows.Count; j++)
            {
                string str = "";
                str = (j % 2 != 0 ? "#EFEFEF" : "");
                object[] objArray = new object[] { "<tr id='", j, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 9%;' align='left'>");
                object[] item = new object[] { "<input id='txtoptionname", j, "'type='text' style='width:100px;text-align:left' disabled='true' value='", dataTable1.Rows[j]["OptionName"], "' class='textboxnew' />" };
                stringBuilder.Append(string.Concat(item));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 9%;' align='left'>");
                object[] item1 = new object[] { "<input id='txtoptionvalue", j, "'type='text' style='width:100px;text-align:left' disabled='true' value='", dataTable1.Rows[j]["OptionValue"], "' class='textboxnew' />" };
                stringBuilder.Append(string.Concat(item1));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 9%;' align='left'>");
                object[] objArray1 = new object[] { "<input id='txtopnstock", j, "'type='text' style='width:100px;text-align:left'  value='", dataTable1.Rows[j]["OpeningStock"], "' class='textboxnew' />" };
                stringBuilder.Append(string.Concat(objArray1));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td>");
                object[] objArray2 = new object[] { "<input id='txtadditionalprice", j, "'type='text' style='width:100px;text-align:right' value='", ProductCatalogueItem_Stock.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable1.Rows[j]["Price"].ToString()), 6, "", false, false, false), "'  onblur='javascript:pricetodecimal(this,", j, ");' class='textboxnew'  />" };
                stringBuilder.Append(string.Concat(objArray2));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td>");
                object[] objArray3 = new object[] { "<input id='txtstkdate", j, "'type='text' style='width:100px;text-align:left' value='", ProductCatalogueItem_Stock.comm.Eprint_return_Date_Before_View(dataTable1.Rows[j]["StockEntryDate"].ToString(), this.CompanyID, this.UserID, false), "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');  class='textboxnew'  />" };
                stringBuilder.Append(string.Concat(objArray3));
                stringBuilder.Append("</td>");
                int num = 2;
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                {
                    stringBuilder.Append("<td style='width:15%;' align:'left'>");
                    stringBuilder.Append("<span style='margin-right:5px'>");
                    object[] objArray4 = new object[] { "<img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='", this.strImagepath, "plus.gif' onclick=javascript:addstocklocation(", j, ",'w'); />" };
                    stringBuilder.Append(string.Concat(objArray4));
                    stringBuilder.Append("</span>");
                    object[] objArray5 = new object[] { "<input id='txtWhLocation", j, "'type='text' style='width:100px;text-align:left' autocomplete='off'  value='", this.objbaseclass.SpecialDecode(dataTable1.Rows[j]["LocationName"].ToString()), "' onclick=javascript:GetLocationDetails(this,'hdnWhlocationid", j, "','Warehouse','", this.CompanyID, "','1',event);    onkeyup=javascript:GetLocationDetails(this,'hdnWhlocationid", j, "','Warehouse','", this.CompanyID, "','1',event);   class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray5));
                    object[] value = new object[] { "<input type='hidden' id='hdnWhlocationid", j, "' value='", this.hdnDefaultLocationValue.Value, "' />" };
                    stringBuilder.Append(string.Concat(value));
                    stringBuilder.Append("</td>");
                    num = 3;
                }
                int num1 = 0;
                int num2 = 2;
                while (num2 < dataTable.Rows.Count + 2)
                {
                    if (num1 >= dataTable.Rows.Count)
                    {
                        continue;
                    }
                    for (int k = 2; k <= 6; k++)
                    {
                        if (dataTable.Rows[num1]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", k))
                        {
                            stringBuilder.Append("<td style='width: 13%;' align='left'>");
                            object[] item2 = new object[] { "<input id='txtcustomfield", num2 - num, "' type='text' style='width:95px;text-align:left' value='", dataTable1.Rows[j][string.Concat("Customfield", k)], "'  class='textboxnew' />" };
                            stringBuilder.Append(string.Concat(item2));
                            stringBuilder.Append("</td>");
                        }
                    }
                    num1++;
                    num2++;
                }
                stringBuilder.Append("<td align='center' style='width: 8%'>");
                object[] objArray6 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", j, ",'tbladditional'); />" };
                stringBuilder.Append(string.Concat(objArray6));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<input type='hidden' id='hdnwebother' value='", dataTable1.Rows[j]["WebStoreOtherCostID"], "'>"));
                stringBuilder.Append("</tr>");
            }
            SqlCommand sqlCommand = new SqlCommand("PC_SelectedAddtionalAddmore_Select", (new commonClass()).conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Pricecatalogueid", ProductCatalogueItem_Stock.ProductCatalogueID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable dataTable2 = dataSet.Tables[0];
            if (dataTable2.Rows.Count > 0)
            {
                int num3 = 0;
                for (int l = j; l < dataTable2.Rows.Count + j; l++)
                {
                    string str1 = "";
                    str1 = (l % 2 != 0 ? "#EFEFEF" : "");
                    object[] objArray7 = new object[] { "<tr id='", l, "' style='background-color:", str1, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                    stringBuilder.Append(string.Concat(objArray7));
                    stringBuilder.Append("<td style='width: 9%;' align='left'>");
                    object[] objArray8 = new object[] { "<input id='txtoptionname", l, "'type='text' style='width:100px;text-align:left' disabled='true' value='", this.objbaseclass.SpecialDecode(dataTable2.Rows[num3]["WebOtherCostName"].ToString()), "' class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray8));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 9%;' align='left'>");
                    object[] item3 = new object[] { "<input id='txtoptionvalue", l, "'type='text' style='width:100px;text-align:left' disabled='true' value='", dataTable2.Rows[num3]["Label"], "' class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(item3));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 9%;' align='left'>");
                    stringBuilder.Append(string.Concat("<input id='txtopnstock", l, "'type='text' style='width:100px;text-align:left' class='textboxnew' />"));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td>");
                    object[] objArray9 = new object[] { "<input id='txtadditionalprice", l, "'type='text' style='width:100px;text-align:right' value='0.000' onblur='javascript:pricetodecimal(this,", j, ");' class='textboxnew'  />" };
                    stringBuilder.Append(string.Concat(objArray9));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td>");
                    object[] dateFormat = new object[] { "<input id='txtstkdate", l, "'type='text' style='width:100px;text-align:left' value='", null, null, null, null };
                    commonClass _commonClass = ProductCatalogueItem_Stock.comm;
                    DateTime now = DateTime.Now;
                    dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                    dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                    dateFormat[5] = this.DateFormat;
                    dateFormat[6] = "');  class='textboxnew'  />";
                    stringBuilder.Append(string.Concat(dateFormat));
                    stringBuilder.Append("</td>");
                    int num4 = 0;
                    if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                    {
                        stringBuilder.Append("<td style='width:14%;' align:'left'>");
                        stringBuilder.Append("<span style='margin-right:5px'>");
                        object[] objArray10 = new object[] { "<img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='", this.strImagepath, "plus.gif' onclick=javascript:addstocklocation(", l, ",'w'); />" };
                        stringBuilder.Append(string.Concat(objArray10));
                        stringBuilder.Append("</span>");
                        object[] value1 = new object[] { "<input id='txtWhLocation", l, "'type='text' style='width:100px;text-align:left' autocomplete='off'   value='", this.hdnDefaultStockLocation.Value, "' onclick=javascript:GetLocationDetails(this,'hdnWhlocationid", l, "','Warehouse','", this.CompanyID, "','1',event);   onkeyup=javascript:GetLocationDetails(this,'hdnWhlocationid", l, "','Warehouse','", this.CompanyID, "','1',event);   class='textboxnew' />" };
                        stringBuilder.Append(string.Concat(value1));
                        object[] value2 = new object[] { "<input type='hidden' id='hdnWhlocationid", l, "' value='", this.hdnDefaultLocationValue.Value, "' />" };
                        stringBuilder.Append(string.Concat(value2));
                        stringBuilder.Append("</td>");
                        num4 = 1;
                    }
                    for (int m = 0; m < dataTable.Rows.Count - num4; m++)
                    {
                        stringBuilder.Append("<td style='width: 9%;' align='left'>");
                        stringBuilder.Append(string.Concat("<input id='txtcustomfield", m, "'type='text' style='width:95px;text-align:left' class='textboxnew' />"));
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("<td align='center' style='width: 8%'>");
                    object[] objArray11 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", l, ",'tbladditional'); />" };
                    stringBuilder.Append(string.Concat(objArray11));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append(string.Concat("<input type='hidden' id='hdnwebother' value='", dataTable2.Rows[num3]["WebOtherCostID"], "'>"));
                    stringBuilder.Append("</tr>");
                    num3++;
                }
            }
            stringBuilder.Append("</table>");
            this.plhadditionaloptions.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public void getalldetails()
        {
            if (base.Request.Url.ToString().ToLower().Contains("edit") && base.Request.Params["id"] != 0.ToString())
            {
                DataTable dataTable = WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, ProductCatalogueItem_Stock.ProductCatalogueID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtReorderLevel.Text = row["ReorderAlertLevel"].ToString();
                    this.txtReorderQty.Text = row["ReorderQuantity"].ToString();
                    this.txtemail.Text = row["AlertUserEmail"].ToString();
                    this.chkMultiDetail.Checked = Convert.ToBoolean(row["IsEnableSubDetail"]);
                    if (row["DrawStockFrom"].ToString() != "O")
                    {
                        this.txtcurrentstock.Text = row["TotalQuantity"].ToString();
                        this.txtavailstock.Text = row["AvailableQuantity"].ToString();
                        this.txtallocatedstock.Text = row["AllocatedQuantity"].ToString();
                        TextBox str = this.txtproductionquantity;
                        int num = Convert.ToInt32(row["ProductionQuantity"]);
                        str.Text = num.ToString();
                    }
                    ProductCatalogueItem_Stock.ProductTitle = row["ItemTitle"].ToString();
                    this.Parent.Page.Title = string.Concat(global.pageTitle(this.objbaseclass.SpecialDecode(row["ItemTitle"].ToString()), int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()), "  Stock");
                    if (row["DrawStockFrom"] != null)
                    {
                        if (row["DrawStockFrom"].ToString() == "S")
                        {
                            this.lbldrawstocktext.Style.Add("display", "block");
                            this.lbldrawstocktext.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("This_Product");
                            this.ddldrawstockfrom.SelectedIndex = 1;
                            this.ddldrawstockfrom.Style.Add("display", "none");
                            this.ddlstkactivity.SelectedIndex = 0;
                        }
                        else if (row["DrawStockFrom"].ToString() == "O")
                        {
                            this.grdInventoryHistory.Columns[4].Visible = false;
                            this.grdInventoryHistory.Columns[5].Visible = false;
                            this.grdInventoryHistory.Columns[6].Visible = false;
                            this.tdlblallocatedstock.Style.Add("display", "none");
                            this.tdtxtallocatedstock.Style.Add("display", "none");
                            this.tdtxtcurrentstock.Style.Add("display", "none");
                            this.tdlblcurrentstockstock.Style.Add("display", "none");
                            this.tdlblproductionqty.Style.Add("display", "none");
                            this.tdtxtproductionqty.Style.Add("display", "none");
                            int num1 = this.objbaseclass.Check_MaxKit_Availability((long)ProductCatalogueItem_Stock.ProductCatalogueID, 0);
                            this.txtavailstock.Text = num1.ToString();
                            this.div_fieldset.Style.Add("width", "74%");
                            this.lbldrawstocktext.Style.Add("display", "block");
                            this.lbldrawstocktext.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Products");
                            this.ddldrawstockfrom.SelectedIndex = 2;
                            this.ddldrawstockfrom.Style.Add("display", "none");
                            this.div_fieldset.Style.Add("width", "30%");
                        }
                        else if (row["DrawStockFrom"].ToString() == "A")
                        {
                            this.lbldrawstocktext.Style.Add("display", "block");
                            this.lbldrawstocktext.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Additional_Options");
                            this.ddldrawstockfrom.SelectedIndex = 3;
                            this.ddldrawstockfrom.Style.Add("display", "none");
                            this.ddl_additionalactivity.SelectedIndex = 0;
                        }
                        else if (row["DrawStockFrom"].ToString() == "P")//SimpleStock
                        {
                            this.txtSimpleQuantity.Text = row["AvailableQuantity"].ToString();
                        }
                        else if (row["DrawStockFrom"].ToString() != "M")
                        {
                            this.ddlstkactivity.Items[1].Attributes.Add("disabled", "disabled");
                            this.ddlstkactivity.Items[2].Attributes.Add("disabled", "disabled");
                            this.ddl_additionalactivity.Items[1].Attributes.Add("disabled", "disabled");
                            this.ddl_additionalactivity.Items[2].Attributes.Add("disabled", "disabled");
                        }
                        else
                        {
                            this.lbldrawstocktext.Style.Add("display", "block");
                            this.lbldrawstocktext.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Multiple_Existing_Products");
                            this.ddldrawstockfrom.SelectedIndex = 4;
                            this.ddldrawstockfrom.Style.Add("display", "none");
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:stockonchange('ctl00_ContentPlaceHolder1_ctl00_rdbdraw');", true);
                    if (row["AlertUser"].ToString() == "E")
                    {
                        this.chkReorderLevelEveryTime.Checked = true;
                        this.chkReorderLevelDaily.Checked = false;
                        this.chkReorderLevelWeekly.Checked = false;
                        this.rdoNone.Checked = false;
                    }
                    else if (row["AlertUser"].ToString() == "D")
                    {
                        this.chkReorderLevelDaily.Checked = true;
                        this.chkReorderLevelWeekly.Checked = false;
                        this.chkReorderLevelEveryTime.Checked = false;
                        this.rdoNone.Checked = false;
                    }
                    else if (row["AlertUser"].ToString() == "N")
                    {

                        this.rdoNone.Checked = true;
                        this.chkReorderLevelEveryTime.Checked = false;
                        this.chkReorderLevelDaily.Checked = false;
                        this.chkReorderLevelWeekly.Checked = false;
                    }
                    else if (row["AlertUser"].ToString() == "W")
                    {
                        this.chkReorderLevelWeekly.Checked = true;
                        this.chkReorderLevelDaily.Checked = false;
                        this.chkReorderLevelEveryTime.Checked = false;
                        this.rdoNone.Checked = false;
                    }
                    else
                    {
                        this.rdoNone.Checked = true;
                        this.chkReorderLevelEveryTime.Checked = false;
                        this.chkReorderLevelDaily.Checked = false;
                        this.chkReorderLevelWeekly.Checked = false;
                    }
                }
                if (dataTable.Rows[0]["DrawStockFrom"].ToString() == "O")
                {
                    this.getotherproductdetails();
                    this.div_currentstock.Style.Add("display", "block");
                    return;
                }
                if (dataTable.Rows[0]["DrawStockFrom"].ToString() == "A")
                {
                    this.callDrawFromAdditionalOptions();
                    this.div_currentstock.Style.Add("display", "block");
                    this.AdditionalAdjustments();
                    this.Additionalpopupdetails();
                    return;
                }
                if (dataTable.Rows[0]["DrawStockFrom"].ToString() == "S")
                {
                    this.LoadSelfAdd();
                    this.SelfAdjustment();
                    this.div_currentstock.Style.Add("display", "block");
                    return;
                }
                if (dataTable.Rows[0]["DrawStockFrom"].ToString() == "M")
                {
                    this.getothermultipledetails();
                    return;
                }
                if (dataTable.Rows[0]["DrawStockFrom"].ToString() == "P")
                {
                    this.div_currentstock.Style.Add("display", "none");
                    this.div_stockactivity.Style.Add("display", "none");
                    this.divStockAdjustment.Style.Add("display", "none");
                    this.lbldrawstocktext.Style.Add("display", "block");
                    this.lbldrawstocktext.Text = "Simple Stock";
                    this.ddldrawstockfrom.SelectedIndex = 5;
                    this.ddldrawstockfrom.Style.Add("display", "none");
                    this.lnkviewhistory.Style.Add("display", "none");
                    this.lnkView_ProductCatalougeitemStockHistory.Style.Add("display", "none");
                    tblSimpleStock.Style.Add("display", "block");
                    return;
                }
                this.getotherproductdetails();
                this.callDrawFromAdditionalOptions();
                this.LoadSelfAdd();
                this.Createmultipleproducts();
            }
        }

        public void getothermultipledetails()
        {
            DataTable dataTable = WebstoreBasePage.Pricecataloguestock_Othermultiple_select((long)ProductCatalogueItem_Stock.ProductCatalogueID);
            if (dataTable.Rows.Count == 0)
            {
                this.Createmultipleproducts();
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblmultiple' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr  style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Code<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Title<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='left'>");
            stringBuilder.Append("<span>Default<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%;' align='center'>");
            stringBuilder.Append("<span>Action<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string str = "";
                str = (i % 2 != 0 ? "#EFEFEF" : "");
                object[] objArray = new object[] { "<tr id='", i, "e' style='width:100%;background-color:", str, "'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("<td style='width: 11%;' align='left'>");
                object[] str1 = new object[] { "<input  id='txtitemcodemultiple", i, "e' type='text' style='width:165px;text-align:left' autocomplete='off' value='", dataTable.Rows[i]["ItemCode"].ToString(), "'  onkeyup=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID", i, "e','txtitemtitlemultiple", i, "e','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID", i, "e','txtitemtitlemultiple", i, "e','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitlemultiple", i, "e');  class='textboxnew' />" };
                stringBuilder.Append(string.Concat(str1));
                object[] item = new object[] { "<input type='hidden' id='hdnOtherMultipleKitItemID", i, "e' value='", dataTable.Rows[i]["KitItemID"], "' />" };
                stringBuilder.Append(string.Concat(item));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 11%;' align='left'>");
                string str2 = this.objbaseclass.SpecialDecode(dataTable.Rows[i]["ItemTitle"].ToString());
                str2 = str2.Replace("'", "`");
                object[] objArray1 = new object[] { "<input id='txtitemtitlemultiple", i, "e' type='text' value='", str2, "' disabled='true' style='width:365px;text-align:left'  class='textboxnew' />" };
                stringBuilder.Append(string.Concat(objArray1));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td style='width: 4%;' align='center'>");
                if (!Convert.ToBoolean(dataTable.Rows[i]["IsDefault"]))
                {
                    stringBuilder.Append(string.Concat("<input type='checkbox'  id='chkdefault", i, "e'   onclick=javascript:chkothermultipledefault(this.id); />"));
                }
                else
                {
                    stringBuilder.Append(string.Concat("<input type='checkbox' id='chkdefault", i, "e' checked='checked'  onclick=javascript:chkothermultipledefault(this.id); />"));
                }
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td align='center' style='width: 8%'>");
                if (!Convert.ToBoolean(dataTable.Rows[i]["IsDefault"]))
                {
                    object[] objArray2 = new object[] { "<img style='cursor:pointer;height:10px;width:10px;' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_RowEdit('", i, "e','tblmultiple');  />" };
                    stringBuilder.Append(string.Concat(objArray2));
                }
                else
                {
                    stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px;cursor:not-allowed' src='", this.strImagepath, "delete.gif' border='0' title='Remove'   />"));
                }
                stringBuilder.Append("</td>");
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");
            this.plhothermultiple.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public void getotherproductdetails()
        {
            DataTable dataTable = WebstoreBasePage.pricecatalogue_other_select(ProductCatalogueItem_Stock.ProductCatalogueID);
            if (dataTable.Rows.Count == 0)
            {
                this.callotherproducts();
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblother' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr  style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Code<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Title<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='left'>");
            stringBuilder.Append("<span>Stock to be adjusted against 1 unit<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%;' align='center'>");
            stringBuilder.Append("<span>Action<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            if (dataTable.Rows.Count == 0)
            {
                this.callotherproducts();
                return;
            }
            DataTable dt = WebstoreBasePage.OtherProductStockAllocationExist(this.CompanyID,ProductCatalogueItem_Stock.ProductCatalogueID);
            string allocationExist = string.Empty;
            foreach(DataRow dr in dt.Rows)
            {
                allocationExist = dr["allocation_exist"].ToString();
            }
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                string str = "";
                str = (i % 2 != 0 ? "" : "#EFEFEF");
                if(allocationExist == "1")
                {
                    object[] objArray = new object[] { "<tr id='", i, "' style='width:100%;background-color:", str, "'>" };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("<td style='width: 10%;' align='left'>");
                    object[] item = new object[] { "<input  id='txtitemcode", i, "' type='text' disabled='disable' style='width:165px;text-align:left' value='", dataTable.Rows[i - 1]["ItemCode"], "' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle", i, "');  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(item));
                    object[] item1 = new object[] { "<input type='hidden' id='hdnOtherKitItemID", i, "' value='", dataTable.Rows[i - 1]["KitItemID"], "' />" };
                    stringBuilder.Append(string.Concat(item1));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 18%;' align='left'>");
                    object[] objArray1 = new object[] { "<input id='txtitemtitle", i, "' type='text' disabled='true' style='width:365px;text-align:left' value='", dataTable.Rows[i - 1]["ItemTitle"], "'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray1));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 4%;' align='left'>");
                    object[] item2 = new object[] { "<input type='text' style='width:75px;text-align:right' disabled='true' id='txtunit", i, "'  onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'   value='", dataTable.Rows[i - 1]["Quantity"], "' class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(item2));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td align='center' style='width: 8%'>");
                    stringBuilder.Append(string.Concat("<img style='cursor:not-allowed;height:10px;width:10px; disabled:true; ' src='", this.strImagepath, "delete.gif' border='0' title='Remove'   />"));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                }
                else
                {
                    object[] objArray = new object[] { "<tr id='", i, "' style='width:100%;background-color:", str, "'>" };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("<td style='width: 10%;' align='left'>");
                    //object[] item = new object[] { "<input  id='txtitemcode", i, "' type='text' disabled='disable' style='width:165px;text-align:left' value='", dataTable.Rows[i - 1]["ItemCode"], "' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle", i, "');  class='textboxnew' />" };
                    object[] item = new object[] { "<input  id='txtitemcode", i, "' type='text' disabled='disable' style='width:165px;text-align:left' value='", dataTable.Rows[i - 1]["ItemCode"], "' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID", i, "','txtitemtitle", i, "','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle", i, "');  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(item));
                    object[] item1 = new object[] { "<input type='hidden' id='hdnOtherKitItemID", i, "' value='", dataTable.Rows[i - 1]["KitItemID"], "' />" };
                    stringBuilder.Append(string.Concat(item1));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 18%;' align='left'>");
                    //object[] objArray1 = new object[] { "<input id='txtitemtitle", i, "' type='text' disabled='true' style='width:365px;text-align:left' value='", dataTable.Rows[i - 1]["ItemTitle"], "'  class='textboxnew' />" };
                    object[] objArray1 = new object[] { "<input id='txtitemtitle", i, "' type='text' disabled='true' style='width:365px;text-align:left' value='", dataTable.Rows[i - 1]["ItemTitle"], "'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray1));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='width: 4%;' align='left'>");
                    //object[] item2 = new object[] { "<input type='text' style='width:75px;text-align:right' disabled='true' id='txtunit", i, "'  onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'   value='", dataTable.Rows[i - 1]["Quantity"], "' class='textboxnew' />" };
                    object[] item2 = new object[] { "<input type='text' style='width:75px;text-align:right' disabled='true' id='txtunit", i, "'  onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'   value='", dataTable.Rows[i - 1]["Quantity"], "' class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(item2));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td align='center' style='width: 8%'>");
                    //stringBuilder.Append(string.Concat("<img style='cursor:not-allowed;height:10px;width:10px; disabled:true; ' src='", this.strImagepath, "delete.gif' border='0' title='Remove'   />"));
                    stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px; ' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", i, ",'tblother');delete_other(", dataTable.Rows[i - 1]["id"] , ")   /> "));
                    //stringBuilder.Append(string.Concat( "<asp:ImageButton", " ID='btnDelete", i, "'", " runat='server'"," ImageUrl='", this.strImagepath, "delete.gif'"," Width='10px'"," Height='10px'", " ToolTip='Remove'"," OnClick='btnDelete_Click'",  " CommandArgument='", dataTable.Rows[i - 1]["id"] , "'", " />"));
                    //stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px; ' src='", this.strImagepath, "edit.gif' border='0' title='Edit' onclick=javascript:edit_other(", dataTable.Rows[i - 1]["id"], ",", dataTable.Rows[i - 1]["KitItemID"], ",", dataTable.Rows[i - 1]["ItemCode"], ",'", dataTable.Rows[i - 1]["ItemTitle"], "',", dataTable.Rows[i - 1]["Quantity"], ",", this.CompanyID, ");   />"));
                    //stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px; ' src='", this.strImagepath, "edit.gif' border='0' title='Edit' onclick='javascript:edit_other(", dataTable.Rows[i - 1]["id"], ",", dataTable.Rows[i - 1]["KitItemID"], ",", "'", dataTable.Rows[i - 1]["ItemCode"], "'", ",'", dataTable.Rows[i - 1]["ItemTitle"], "',", dataTable.Rows[i - 1]["Quantity"], ",", this.CompanyID, ");' />"));
                    stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px;' src='", this.strImagepath, "edit.gif' border='0' title='Edit' onclick=\"javascript:edit_other(", dataTable.Rows[i - 1]["id"], ",", dataTable.Rows[i - 1]["KitItemID"], ",'", dataTable.Rows[i - 1]["ItemCode"], "','", dataTable.Rows[i - 1]["ItemTitle"], "',", dataTable.Rows[i - 1]["Quantity"], ",", this.CompanyID, ");\" />"));


                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                }
                
            }
            stringBuilder.Append("</table>");
            this.plhdrawotherproducts.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            if (allocationExist == "1")
            {
                this.lnkbtnadd.Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                this.lnkbtnadd.Attributes.CssStyle.Add("display", "block");
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ImageButton btnDelete = (ImageButton)sender;
            string commandArgument = btnDelete.CommandArgument;
            WebstoreBasePage.pricecataloguestock_other_delete(int.Parse(commandArgument));
        }

        protected void DeleteItem(string id)
        {
            WebstoreBasePage.pricecataloguestock_other_delete(int.Parse(id));
        }
        protected void grdInventoryHistory_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objbaseclass.ReplaceSingleQuote(item.Text);
                ProductCatalogueItem_Stock.WhereCondition = "";
                if (str.Trim().ToLower() == "templatecolumn0" || str.Trim().ToLower() == "templatecolumn")
                {
                    str = "CreatedDate";
                }
                if (str.Trim().ToLower() == "templatecolumn1")
                {
                    str = "UserName";
                }
                if (str.Trim().ToLower() == "templatecolumn2")
                {
                    str = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Description");
                }
                if (str.Trim().ToLower() == "templatecolumn3")
                {
                    str = "JobNumber";
                }
                if (base.Session["SearchProd_History"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["SearchProd_History"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["SearchProd_History"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", str, "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] first = new object[] { str, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(first);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { str, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                base.Session["SearchProd_History"] = this.dtsearch;
                ProductCatalogueItem_Stock.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(ProductCatalogueItem_Stock.ProductCatalogueID, this.grdInventoryHistory.PageSize, 1, ProductCatalogueItem_Stock.WhereCondition);
            }
        }

        protected void grdInventoryHistory_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string[] strArrays;
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label green = (Label)e.Item.FindControl("lblDescription");
                Label red = (Label)e.Item.FindControl("lblCustomDescription");
                Label label = (Label)e.Item.FindControl("lblreferenceno");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_jobnumber");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_estimateid");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_orderid");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_deliveryid");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_actiontype");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdnUser");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_jobid");
                Label label1 = (Label)e.Item.FindControl("lblUserName");
                label1.Text = this.objbaseclass.SpecialDecode(hiddenField5.Value);
                string[] strArrays1 = green.Text.ToString().Split(new char[] { '#' });
                green.Text = green.Text.ToString().Replace("#", " ");
                string value = hiddenField.Value;
                char[] chrArray = new char[] { '~' };
                label.Text = value.Split(chrArray)[0];
                if ((int)strArrays1.Length > 1)
                {
                    string str = strArrays1[0];
                    string str1 = strArrays1[1];
                    if (hiddenField.Value.Contains("JOB"))
                    {
                        if (hiddenField1.Value != "" && hiddenField6.Value != "")
                        {
                            strArrays = hiddenField.Value.Split(new char[] { '~' });
                            if (strArrays[1] == "0")
                            {
                                object[] objArray = new object[] { str, "<a href='", this.strSitePath, "jobs/job_summary_reeng.aspx?frm=view&estid=", hiddenField1.Value, "&jID=", hiddenField6.Value, "' target='_blank' style='color:Blue'>", '#', strArrays[0], "</a>" };
                                green.Text = string.Concat(objArray);
                            }
                            else if (strArrays[1] == "1")
                            {
                                green.Text = string.Concat(str, '#', strArrays[0]);
                            }
                        }
                    }
                    else if (hiddenField.Value.Contains("ORD"))
                    {
                        if (hiddenField2.Value != "")
                        {
                            strArrays = hiddenField.Value.Split(new char[] { '~' });
                            if (strArrays[1] == "0")
                            {
                                object[] value1 = new object[] { str, "<a href='", this.strSitePath, "orders/order_summary.aspx?frm=view&ordid=", hiddenField2.Value, "&estid=", hiddenField1.Value, "' target='_blank' style='color:Blue'>", '#', strArrays[0], "</a>" };
                                green.Text = string.Concat(value1);
                            }
                            else if (strArrays[1] == "1")
                            {
                                green.Text = string.Concat(str, '#', strArrays[0]);
                            }
                        }
                    }
                    else if (hiddenField.Value.Contains("DEL") && hiddenField3.Value != "")
                    {
                        strArrays = hiddenField.Value.Split(new char[] { '~' });
                        if (strArrays[1] == "0")
                        {
                            object[] objArray1 = new object[] { str, "<a href='", this.strSitePath, "delivery/delivery_add.aspx?type=edit&id=", hiddenField3.Value, "' target='_blank' style='color:Blue'>", '#', strArrays[0], "</a>" };
                            green.Text = string.Concat(objArray1);
                        }
                        else if (strArrays[1] == "1")
                        {
                            green.Text = string.Concat(str, '#', strArrays[0]);
                        }
                    }
                }
                if (hiddenField4.Value.ToLower() == "allocated")
                {
                    green.ForeColor = ColorTranslator.FromHtml("#FF8000");
                    red.ForeColor = ColorTranslator.FromHtml("#FF8000");
                }
                else if (hiddenField4.Value.ToLower() == "released")
                {
                    green.ForeColor = Color.Green;
                    red.ForeColor = Color.Green;
                }
                else if (hiddenField4.Value.ToLower() == "adjusted")
                {
                    green.ForeColor = Color.Red;
                    red.ForeColor = Color.Red;
                }
                DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
                Label str2 = (Label)e.Item.FindControl("lblDate");
                DateTime dateTime = Convert.ToDateTime(str2.Text);
                str2.Text = Convert.ToString(dateTime.ToString("MM/dd/yyyy hh:mm tt"));
                string text = str2.Text;
                char[] chrArray1 = new char[] { ' ' };
                string str3 = text.Split(chrArray1)[0];
                string text1 = str2.Text;
                char[] chrArray2 = new char[] { ' ' };
                string str4 = text1.Split(chrArray2)[1];
                string text2 = str2.Text;
                char[] chrArray3 = new char[] { ' ' };
                string str5 = text2.Split(chrArray3)[2];
                string str6 = ProductCatalogueItem_Stock.comm.Eprint_return_Date_Before_View(str2.Text, this.CompanyID, this.UserID, false);
                object[] objArray2 = new object[] { str6, ' ', str4, ' ', str5 };
                str2.Text = string.Concat(objArray2);
                string str7 = "";
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (dataTable.Rows[i]["DataFieldName"].ToString().ToLower().Trim() == string.Concat("customfield", j))
                        {
                            HiddenField hiddenField7 = (HiddenField)e.Item.FindControl(string.Concat("hdn_Customdescription", j));
                            if (hiddenField7.Value != "")
                            {
                                str7 = string.Concat(str7, dataTable.Rows[i]["ScreenName"].ToString(), ": ", hiddenField7.Value);
                                if (i < dataTable.Rows.Count - 1)
                                {
                                    str7 = string.Concat(str7, "  ");
                                }
                            }
                        }
                    }
                }
                red.Text = this.objbaseclass.SpecialDecode(str7);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdInventoryHistory.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdInventoryHistory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("items_in"), " {1} ", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void grdInventoryHistory_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.grdInventoryHistory.AllowCustomPaging = true;
            DataSet dataSet = this.GridBind(ProductCatalogueItem_Stock.ProductCatalogueID, this.grdInventoryHistory.PageSize, this.grdInventoryHistory.CurrentPageIndex + 1, ProductCatalogueItem_Stock.WhereCondition);
            this.grdInventoryHistory.DataSource = dataSet.Tables[0];
        }

        protected void grdInventoryHistory_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.grdInventoryHistory.CurrentPageIndex = e.NewPageIndex;
            this.bindinventory(ProductCatalogueItem_Stock.ProductCatalogueID);
        }

        public DataSet GridBind(int ProductCatalogueID, int PageSize, int PageNumber, string WhereCondition)
        {
            this.grdInventoryHistory.AllowCustomPaging = true;
            DataSet dataSet = WebstoreBasePage.pricecataloguestock_history_select((long)ProductCatalogueID, PageSize, PageNumber, WhereCondition);
            this.grdInventoryHistory.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                this.grdInventoryHistory.VirtualItemCount = 0;
                this.grdInventoryHistory.AllowCustomPaging = false;
            }
            return dataSet;
        }

        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            DataSet dataSet = WebstoreBasePage.pricecataloguestock_history_select((long)ProductCatalogueItem_Stock.ProductCatalogueID, 0, 0, ProductCatalogueItem_Stock.WhereCondition);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("User Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Reference No");
            dataTable.Columns.Add("Transaction Quantity");
            dataTable.Columns.Add("Current Stock");
            dataTable.Columns.Add("Allocated Stock");
            dataTable.Columns.Add("Available Stock");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string str = row["Description"].ToString();
                string[] strArrays = row["Description"].ToString().Split(new char[] { '#' });
                string str1 = row["JobNumber"].ToString();
                char[] chrArray = new char[] { '~' };
                string str2 = str1.Split(chrArray)[0];
                if ((int)strArrays.Length > 1)
                {
                    str = string.Concat(strArrays[0].ToString(), '#', row["JobNumber"].ToString());
                }
                object[] item = new object[] { row["CreatedDate"], row["UserName"], str, str2, row["Quantity"], row["StockInHand"], row["AllocatedStock"], row["AvailableStock"] };
                dataTable.Rows.Add(item);
            }
            WebExport webExport = new WebExport();
            webExport.WebExportDetails(dataTable, WebExport.ExportFormat.Excel, string.Concat(ProductCatalogueItem_Stock.ProductTitle, "-History.xls"), ",");
        }

        public void LoadSelfAdd()
        {
            ProductCatalogueItem_Stock.fieldnames.Clear();
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            this.hdnfld.Value = dataTable.Rows.Count.ToString();
            int num = 0;
            int num1 = 5;
            int num2 = 5;
            if (dataTable.Rows.Count <= 0 || !dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim().Contains("customfield1"))
            {
                this.hdnloc.Value = "no";
                num2 = 100;
            }
            else
            {
                this.hdnloc.Value = "yes";
                int count = dataTable.Rows.Count;
            }
            if (dataTable.Rows.Count == 1)
            {
                num = 320;
                num1 = 70;
            }
            if (dataTable.Rows.Count == 2)
            {
                num = 300;
            }
            if (dataTable.Rows.Count == 3)
            {
                num = 225;
            }
            if (dataTable.Rows.Count == 4)
            {
                num = 185;
                num1 = 5;
            }
            if (dataTable.Rows.Count == 5)
            {
                num = 150;
            }
            if (dataTable.Rows.Count == 6)
            {
                num = 130;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblstock' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr style='width:80%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 5%;' align='left'>");
            if (ProductCatalogueItem_Stock.headertype.ToLower() == "opening")
            {
                stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Opening_Stock"), "<span>"));
            }
            else
            {
                stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Quantity"), "<span>"));
            }
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 7%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Unit_Cost"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 7%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Date"), "<span>"));
            stringBuilder.Append("</td>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProductCatalogueItem_Stock.fieldnames.Add(dataTable.Rows[i]["datafieldname"].ToString().ToLower().Trim());
                stringBuilder.Append(string.Concat("<td style='width: ", num1, "%;' align='left'>"));
                stringBuilder.Append(string.Concat("<span>", dataTable.Rows[i]["screenName"], "<span>"));
                stringBuilder.Append("</td>");
            }

            stringBuilder.Append("<td style='width: 10%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Notes"), "<span>"));
            stringBuilder.Append("</td>");

            stringBuilder.Append(string.Concat("<td style='width: ", num2, "%;' align='right'>"));
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Action"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            for (int j = 1; j < 3; j++)
            {
                string str = "";
                if (j != 0)
                {
                    str = (j % 2 != 0 ? "" : "#EFEFEF");
                    object[] objArray = new object[] { "<tr id='", j, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("<td style='width: 11%;' align='left'>");
                    stringBuilder.Append(string.Concat("<input id='txtopnstock", j, "' type='text' style='width:75px;text-align:right' onblur='javascript:checkforInteger(this.id,this.value);' class='textboxnew' value='0' />"));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td align='left' style='width: 8%'>");
                    object[] price = new object[] { "<input id='txtprice' type='text' style='width:75px;text-align:right' value='", ProductCatalogueItem_Stock.Price, "' onblur='javascript:pricetodecimal(this,", j, ");'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(price));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td>");
                    object[] dateFormat = new object[] { "<input id='txtstkdate", j, "'type='text' style='width:75px;text-align:left' value='", null, null, null, null };
                    commonClass _commonClass = ProductCatalogueItem_Stock.comm;
                    DateTime now = DateTime.Now;
                    dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                    dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                    dateFormat[5] = this.DateFormat;
                    dateFormat[6] = "');  class='textboxnew'  />";
                    stringBuilder.Append(string.Concat(dateFormat));
                    stringBuilder.Append("</td>");
                    int num3 = 1;
                    if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                    {
                        stringBuilder.Append("<td align='left' style='width:35%'>");
                        stringBuilder.Append("<span style='margin-right:5px'>");
                        object[] objArray1 = new object[] { "<img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='", this.strImagepath, "plus.gif' onclick=javascript:addstocklocation(", j, ",'s'); />" };
                        stringBuilder.Append(string.Concat(objArray1));
                        stringBuilder.Append("</span>");
                        object[] value = new object[] { "<input id='txtLocation", j, "'  type='text' style='width:", num, "px;text-align:left' value='", this.hdnDefaultStockLocation.Value, "' autocomplete='off'  onkeyup=javascript:GetLocationDetails(this,'hdnlocationid", j, "','Warehouse','", this.CompanyID, "','1',event);  onclick=javascript:GetLocationDetails(this,'hdnlocationid", j, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdnlocationid", j, ");'  class='textboxnew' />" };
                        stringBuilder.Append(string.Concat(value));
                        object[] value1 = new object[] { "<input type='hidden' id='hdnlocationid", j, "' value='", this.hdnDefaultLocationValue.Value, "' />" };
                        stringBuilder.Append(string.Concat(value1));
                        stringBuilder.Append("</td>");
                        num3 = 2;
                    }
                    int num4 = 2;
                    for (int k = num3; k <= dataTable.Rows.Count; k++)
                    {
                        stringBuilder.Append("<td style='width: 12%;' align='left'>");
                        object[] objArray2 = new object[] { "<input id='txtcustomfield", num4, "' type='text' style='width:", num, "px;text-align:left'  class='textboxnew' />" };
                        stringBuilder.Append(string.Concat(objArray2));
                        stringBuilder.Append("</td>");
                        num4++;
                    }

                    stringBuilder.Append("<td style='width: 12%;' align='left'>");
                    object[] objArray4 = new object[] { "<input id='txtNotes", "' type='text' style='width:", num, "px;text-align:left'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray4));
                    stringBuilder.Append("</td>");

                    stringBuilder.Append("<td align='right' style='width: 8%;padding-right:15px'>");
                    object[] objArray3 = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", j, ",'tblstock'); />" };
                    stringBuilder.Append(string.Concat(objArray3));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                }
            }
            stringBuilder.Append("</table>");
            this.plhstock.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdInventoryHistory.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["__EVENTTARGET"] == "DeleteItem")
            {
                string id = Request["__EVENTARGUMENT"];
                DeleteItem(id);
            }
            this.btnaddionalstocklevel.Visible = false;
            if (base.Request.Params["managestock"] != null && base.Request.Params["managestock"].ToString().ToLower() == "yes")
            {
                ProductCatalogueItem_Stock.stockparam = "yes";
            }
            this.validationmsg = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Select_Operator_Validation_Msg");
            this.rdbdraw.Items[0].Text = "This Product";
            this.rdbdraw.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Products");
            this.rdbdraw.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Additional_Options");
            this.rdbdraw.Items[3].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Multiple_Existing_Products");
            this.ddldrawstockfrom.Items[0].Text = string.Concat("------------ ", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Select"), " ------------");
            this.ddldrawstockfrom.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("This_Product");
            this.ddldrawstockfrom.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Products");
            this.ddldrawstockfrom.Items[3].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Additional_Options");
            this.ddldrawstockfrom.Items[4].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Other_Multiple_Existing_Products");
            this.ddldrawstockfrom.Items[5].Text = "Simple Stock";
            this.lbldrawstock.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Draw_Stock_From");
            this.chkReorderLevelDaily.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Once_Per_Day_Until_The_Stock_Is_Replenished");
            this.chkReorderLevelWeekly.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Once_Every_7_Days_Until_The_Stock_Is_Replenished");
            this.rdoNone.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Dont_Alert_Users");
            this.chkReorderLevelEveryTime.Text = "Once only";
            this.grdInventoryHistory.Columns[0].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Date");
            this.grdInventoryHistory.Columns[1].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("User_Name");
            this.grdInventoryHistory.Columns[2].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Description");
            this.grdInventoryHistory.Columns[3].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Reference_No");
            this.grdInventoryHistory.Columns[4].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Transaction_Quantity");
            this.grdInventoryHistory.Columns[5].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Quantity_on_Hand");
            this.grdInventoryHistory.Columns[6].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Allocated_Stock");
            this.grdInventoryHistory.Columns[7].HeaderText = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Available_Stock");
            this.ddlstkactivity.Items[0].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Add");
            this.ddlstkactivity.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Release");
            this.ddlstkactivity.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Adjustments");
            this.ddl_additionalactivity.Items[0].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Add");
            this.ddl_additionalactivity.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Release");
            this.ddl_additionalactivity.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Adjustments");
            this.ddladjustment.Items[0].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Damaged");
            this.ddladjustment.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Returned");
            this.ddladjustment.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Loss_In_Transit");
            this.ddladjustment.Items[3].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Stock_Recalculation");
            this.ddladjustment.Items[4].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Others");
            this.ddladditionaladjtype.Items[0].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Damaged");
            this.ddladditionaladjtype.Items[1].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Returned");
            this.ddladditionaladjtype.Items[2].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Loss_In_Transet");
            this.ddladditionaladjtype.Items[3].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Stock_Recalculation");
            this.ddladditionaladjtype.Items[4].Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Others");
            this.btnStockSave.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Save");
            this.btnStockStay.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Save_Stay");
            this.imgback.Text = ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Back");
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            this.gloobj.setpagename("productcatalogue");
            this.PB = base.IsPostBack.ToString().ToLower();
            ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:stockonchange('ctl00_ContentPlaceHolder1_ctl00_rdbdraw');", true);
            this.txtavailstock.Enabled = false;
            this.txtallocatedstock.Enabled = false;
            this.txtcurrentstock.Enabled = false;
            this.txtproductionquantity.Enabled = false;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.div_stockactivity.Style.Add("display", "block");
            if (base.Request.Params["id"] != null && base.Request.Params["id"].ToString() != "")
            {
                ProductCatalogueItem_Stock.ProductCatalogueID = Convert.ToInt32(base.Request.Params["id"].ToString());
            }
            ProductCatalogueItem_Stock.headertype = WebstoreBasePage.pricecataloguestock_actiontype_check((long)ProductCatalogueItem_Stock.ProductCatalogueID, "self");
            ProductCatalogueItem_Stock.AdditionalHeaderType = WebstoreBasePage.pricecataloguestock_actiontype_checkAdditional((long)ProductCatalogueItem_Stock.ProductCatalogueID);
            DataTable dataTable = WebstoreBasePage.settings_Product_CatalogueQty_Select(Convert.ToInt64(ProductCatalogueItem_Stock.ProductCatalogueID));
            if (dataTable.Rows.Count > 0)
            {
                ProductCatalogueItem_Stock.Price = ProductCatalogueItem_Stock.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable.Rows[0]["Price"].ToString()), 6, "", false, false, false);
            }
            if (!base.IsPostBack)
            {
                DataTable dataCheck = WebstoreBasePage.settings_Product_Matrix_EnableCheck(Convert.ToInt64(ProductCatalogueItem_Stock.ProductCatalogueID));
                if (dataCheck.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dataCheck.Rows[0]["IsEnableSubDetail"]))
                    {
                        this.chkMultiDetail.Checked = true;
                    }
                }
            }
            if (!base.IsPostBack)
            {
                base.Session["SearchProd_History"] = null;
                this.grdInventoryHistory.PageSize = 50;
                ProductCatalogueItem_Stock.WhereCondition = "";
            }
            this.txtjobref.Attributes.Add("autocomplete", "off");
            this.txtjobref.Attributes.Add("onclick", string.Concat("javascript:GetProductJobList(this,'JobList','", ProductCatalogueItem_Stock.ProductCatalogueID, "','1',event)"));
            this.txtjobref.Attributes.Add("onkeyup", string.Concat("javascript:GetProductJobList(this,'JobList','", ProductCatalogueItem_Stock.ProductCatalogueID, "','1',event)"));
            this.txtadditionalrelease.Attributes.Add("autocomplete", "off");
            this.txtadditionalrelease.Attributes.Add("onclick", string.Concat("javascript:GetProductJobList(this,'JobList','", ProductCatalogueItem_Stock.ProductCatalogueID, "','1',event)"));
            this.txtadditionalrelease.Attributes.Add("onkeyup", string.Concat("javascript:GetProductJobList(this,'JobList','", ProductCatalogueItem_Stock.ProductCatalogueID, "','1',event)"));
            SqlCommand sqlCommand = new SqlCommand("PC_DefaultStockLocation_Select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.hdnDefaultLocationValue.Value = sqlDataReader[0].ToString();
                this.hdnDefaultStockLocation.Value = sqlDataReader[1].ToString();
            }
            this.getalldetails();
            if (!base.IsPostBack)
            {
                string str = "";
                if (base.Session["SearchProd_History"] != null)
                {
                    DataTable item = (DataTable)base.Session["SearchProd_History"];
                    str = this.FilterFunction(item);
                }
                this.GridBind(ProductCatalogueItem_Stock.ProductCatalogueID, this.grdInventoryHistory.PageSize, 1, str);
            }
            this.btnStockStay.Attributes.Add("onclick", "javascript:var a=finalvalidatemail();if(a) a = CallSelectedOption('ctl00_ContentPlaceHolder1_ctl00_rdbdraw','saveandstay');if(a)loadingimage(this.id,'div_stayprocess');return a;");
            this.btnStockSave.Attributes.Add("onclick", "javascript:var a=finalvalidatemail();if(a) a = CallSelectedOption('ctl00_ContentPlaceHolder1_ctl00_rdbdraw','save');if(a)loadingimage(this.id,'div_saveprocess'); return a;");
        }

        public void SelfAdjustment()
        {
            StringBuilder stringBuilder = new StringBuilder();
            ProductCatalogueItem_Stock.fieldnames.Clear();
            DataTable dataTable = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            DataTable dataTable1 = WebstoreBasePage.pricecataloguestock_self_select(ProductCatalogueItem_Stock.ProductCatalogueID);
            int num = 0;
            int num1 = 5;
            if (dataTable.Rows.Count == 1)
            {
                num = 320;
                num1 = 50;
            }
            if (dataTable.Rows.Count == 2)
            {
                num = 300;
            }
            if (dataTable.Rows.Count == 3)
            {
                num = 225;
            }
            if (dataTable.Rows.Count == 4)
            {
                num = 185;
            }
            if (dataTable.Rows.Count == 5)
            {
                num = 130;
            }
            if (dataTable.Rows.Count == 6)
            {
                num = 110;
            }
            stringBuilder.Append("<table id='tblselfedit' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 6%;' align='left'>");
            stringBuilder.Append(string.Concat("<span style='padding-left:1px;'>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Alter"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Stock_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 9%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Total_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 10%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Allocated_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 10%;' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Available_Quantity"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 8%; padding-right:20px' align='right'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Unit_Cost"), "<span>"));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 10%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Date"), "<span>"));
            stringBuilder.Append("</td>");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProductCatalogueItem_Stock.fieldnames.Add(dataTable.Rows[i]["datafieldname"].ToString().ToLower().Trim());
                stringBuilder.Append(string.Concat("<td style='width: ", num1, "%;' align='left'>"));
                stringBuilder.Append(string.Concat("<span>", dataTable.Rows[i]["screenName"], "<span>"));
                stringBuilder.Append("</td>");
            }
            if (dataTable.Rows.Count == 0)
            {
                stringBuilder.Append("<td style='width: 50%;' align='left'>");
                stringBuilder.Append("</td>");
            }

            stringBuilder.Append("<td style='width: 10%;' align='left'>");
            stringBuilder.Append(string.Concat("<span>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Notes"), "<span>"));
            stringBuilder.Append("</td>");

            stringBuilder.Append("</tr>");
            for (int j = 0; j < dataTable1.Rows.Count; j++)
            {
                string str = "";
                str = (j % 2 == 0 ? "" : "#EFEFEF");
                string str1 = "";
                if (Convert.ToInt64(dataTable1.Rows[j]["AvailableStock"]) < (long)0)
                {
                    str1 = "color:#f00000;";
                }
                string lower = dataTable1.Rows[j]["IsBackOrder"].ToString().ToLower();
                object[] objArray = new object[] { "<tr id='", j, "' style='background-color:", str, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append(string.Concat("<td style='width: 5%;", str1, "' align='left'>"));
                object[] languageConversion = new object[] { "<select type='list' style='width:65px;height:19px;", str1, "' id='ddlplusminus", j, "' onchange='javascript: EnableLocationFields(this.id,", j + 1, ",tblselfedit,hdn_totalqty", j, ",hdn_availQty", j, "); return false;'><option>", ProductCatalogueItem_Stock.objLanguage.GetLanguageConversion("Select"), "</option><option>Move</option><option>+</option><option>-</option></select>" };
                stringBuilder.Append(string.Concat(languageConversion));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<td style='width: 9%;padding-right:5px;", str1, "' align='right'>"));
                object[] objArray1 = new object[] { "<input id='txtadjustqty", j, "' type='text' style='width:70px;text-align:right;", str1, "' value='0' onkeyup='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ",ddlplusminus", j, ",", lower, ",hdn_availQty", j, ");'  onblur='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ",ddlplusminus", j, ",", lower, ",hdn_availQty", j, ");' class='textboxnew' />" };
                stringBuilder.Append(string.Concat(objArray1));
                object[] item = new object[] { "<input type='hidden' id='hdn_stockselfID", j, "' value='", dataTable1.Rows[j]["PricecatalogueStockID"], "' />" };
                stringBuilder.Append(string.Concat(item));
                object[] item1 = new object[] { "<input type='hidden' id='hdn_totalqty", j, "' value='", dataTable1.Rows[j]["OpeningStock"], "' />" };
                stringBuilder.Append(string.Concat(item1));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<td style='width: 9%;", str1, "' align='right'>"));
                object[] item2 = new object[] { "<div align='right'><label id='lblopningstock", j, "'> ", dataTable1.Rows[j]["OpeningStock"], "</label></div>" };
                stringBuilder.Append(string.Concat(item2));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<td style='width: 10%;", str1, "' align='right'>"));
                stringBuilder.Append(string.Concat("<div align='right'>", dataTable1.Rows[j]["AllocatedStock"], "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<td style='width: 10%;", str1, "' align='right'>"));
                stringBuilder.Append(string.Concat("<div align='right'>", dataTable1.Rows[j]["AvailableStock"], "</div>"));
                object[] objArray2 = new object[] { "<input type='hidden' id='hdn_availQty", j, "' value='", dataTable1.Rows[j]["AvailableStock"], "' />" };
                stringBuilder.Append(string.Concat(objArray2));
                stringBuilder.Append("</td>");
                stringBuilder.Append(string.Concat("<td align='right' style='width: 8%; padding-right:20px;", str1, "'>"));
                stringBuilder.Append(string.Concat("<div>", ProductCatalogueItem_Stock.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable1.Rows[j]["Price"].ToString()), 6, "", false, false, false), "</div>"));
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td>");
                object[] objArray3 = new object[] { "<input id='txtstkdate", j, "'type='text' style='width:80px;text-align:left' disabled='disabled' value='", ProductCatalogueItem_Stock.comm.Eprint_return_Date_Before_View(dataTable1.Rows[j]["StockEntryDate"].ToString(), this.CompanyID, this.UserID, false), "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');  class='textboxnew'  />" };
                stringBuilder.Append(string.Concat(objArray3));
                stringBuilder.Append("</td>");
                int num2 = 0;
                int num3 = 1;
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                {
                    stringBuilder.Append(string.Concat("<td style='width:10%;margin-left:6px;", str1, "' align:'left' >"));
                    stringBuilder.Append("<div>");
                    object[] objArray4 = new object[] { "<input id='txt_Adjustment_Location_", j + 1, "' disabled type='text' style='width:", num, "px;text-align:left;", str1, "' text='", dataTable1.Rows[j]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' value='", dataTable1.Rows[j]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' autocomplete='off'  onkeyup=javascript:GetLocationDetails(this,'hdn_Adjustment_locationid_", j + 1, "','Warehouse','", this.CompanyID, "','1',event);  onclick=javascript:GetLocationDetails(this,'hdn_Adjustment_locationid_", j + 1, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdn_Adjustment_locationid_", j + 1, ");'  class='textboxnew' />" };
                    stringBuilder.Append(string.Concat(objArray4));
                    object[] str2 = new object[] { "<input type='hidden' id='hdn_Adjustment_locationid_", j + 1, "' value='", dataTable1.Rows[j]["LocationID"].ToString(), "' />" };
                    stringBuilder.Append(string.Concat(str2));
                    stringBuilder.Append("</div></td>");
                    num2 = 1;
                    num3 = 2;
                }
                while (num3 < dataTable.Rows.Count + 1)
                {
                    if (num2 >= dataTable.Rows.Count)
                    {
                        continue;
                    }
                    for (int k = 2; k <= 6; k++)
                    {
                        if (dataTable.Rows[num2]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", k))
                        {
                            stringBuilder.Append(string.Concat("<td style='width:8%;", str1, "' align='left'>"));
                            stringBuilder.Append("<div>");
                            object[] item3 = new object[] { "<input id='txt_Adjustment_customfield_", j + 1, "_", k, "' disabled type='text'  text='", dataTable1.Rows[j][string.Concat("Customfield", k)], "' value='", dataTable1.Rows[j][string.Concat("Customfield", k)], "' style='width:", num, "px;text-align:left;", str1, "'  class='textboxnew' />" };
                            stringBuilder.Append(string.Concat(item3));
                            stringBuilder.Append("</div></td>");
                        }
                    }
                    num2++;
                    num3++;
                }

                stringBuilder.Append(string.Concat("<td style='width:8%;", str1, "' align='left'>"));
                stringBuilder.Append("<div>");
                object[] item4 = new object[] { "<input id='txtNotes", j, "' type='text' style='width:", num, "px;text-align:left'  class='textboxnew' />" };
                stringBuilder.Append(string.Concat(item4));
                stringBuilder.Append("</div></td>");

                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");
            this.plhAdjustments.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
    }
}