using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class Common_ReplenishItemAllocation : System.Web.UI.Page, IRequiresSessionState
    {

        public static languageClass objLanguage;

        private BaseClass objbaseclass = new BaseClass();

        public static ArrayList fieldnames;

        public static commonClass comm;

        private BaseClass objBaseClass = new BaseClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CompanyID;

        public int UserID;

        public long EstimateItemID;

        public long JobID;

        public long EstimateID;

        public long ReplenishStatusID;

        public string IsFrom = "job";

        public long ReplenishPurchaseID;

        public long ReplenishModuleID;

        public string SaveType = string.Empty;

        public string PurchaseNotes = string.Empty;

        public int roundoff;

        public string ReplenishStatusTitle = string.Empty;

        public string DateFormat = "mm/dd/yyyy";      
        
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

        static Common_ReplenishItemAllocation()
        {
            Common_ReplenishItemAllocation.objLanguage = new languageClass();
            Common_ReplenishItemAllocation.fieldnames = new ArrayList();
            Common_ReplenishItemAllocation.comm = new commonClass();
        }

        public Common_ReplenishItemAllocation()
        {
        }

        public void getalldetails()
        {
            this.LoadSelfAdd();
        }

        protected void lnkbtn_Replenish_Save_Click(object sender, EventArgs e)
        {
            string str = this.hdnstockselfdetails.Value.Substring(0, this.hdnstockselfdetails.Value.Length - 1);
            if (!string.IsNullOrEmpty(str.ToString().Trim()))
            {
                string[] strArrays = str.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i].ToString().Trim()))
                    {
                        string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '±' });
                        string empty = string.Empty;
                        string empty1 = string.Empty;
                        string str1 = string.Empty;
                        string empty2 = string.Empty;
                        string str2 = string.Empty;
                        string empty3 = string.Empty;
                        int num = 0;
                        int num1 = 0;
                        int num2 = 0;
                        int num3 = 0;
                        decimal num4 = new decimal(0);                        
                        string date = "";
                       
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            string str3 = strArrays1[j].ToString();
                            char[] chrArray = new char[] { '»' };
                            if (str3.Split(chrArray)[0] != "openstock")
                            {
                                string str4 = strArrays1[j].ToString();
                                char[] chrArray1 = new char[] { '»' };
                                if (str4.Split(chrArray1)[0] != "ProductCatalogueID")
                                {
                                    string str5 = strArrays1[j].ToString();
                                    char[] chrArray2 = new char[] { '»' };
                                    if (str5.Split(chrArray2)[0] != "EstimateItemID")
                                    {
                                        string str6 = strArrays1[j].ToString();
                                        char[] chrArray3 = new char[] { '»' };
                                        if (str6.Split(chrArray3)[0] != "PurchaseItemID")
                                        {
                                            string str7 = strArrays1[j].ToString();
                                            char[] chrArray4 = new char[] { '»' };
                                            if (str7.Split(chrArray4)[0] != "price")
                                            {
                                                string str8 = strArrays1[j].ToString();
                                                char[] chrArray5 = new char[] { '»' };

                                                // date selector
                                                if (str7.Split(chrArray4)[0] != "date")
                                                {
                                                    string strdate = strArrays1[j].ToString();
                                                    char[] chrArraydate = new char[] { '»' };

                                                if (str8.Split(chrArray5)[0] != "customfield1")
                                                {
                                                    string str9 = strArrays1[j].ToString();
                                                    char[] chrArray6 = new char[] { '»' };
                                                    if (str9.Split(chrArray6)[0] != "customfield2")
                                                    {
                                                        string str10 = strArrays1[j].ToString();
                                                        char[] chrArray7 = new char[] { '»' };
                                                        if (str10.Split(chrArray7)[0] != "customfield3")
                                                        {
                                                            string str11 = strArrays1[j].ToString();
                                                            char[] chrArray8 = new char[] { '»' };
                                                            if (str11.Split(chrArray8)[0] != "customfield4")
                                                            {
                                                                string str12 = strArrays1[j].ToString();
                                                                char[] chrArray9 = new char[] { '»' };
                                                                if (str12.Split(chrArray9)[0] != "customfield5")
                                                                {
                                                                    string str13 = strArrays1[j].ToString();
                                                                    char[] chrArray10 = new char[] { '»' };
                                                                    if (str13.Split(chrArray10)[0] == "customfield6")
                                                                    {
                                                                        string str14 = strArrays1[j].ToString();
                                                                        char[] chrArray11 = new char[] { '»' };
                                                                        empty3 = Convert.ToString(str14.Split(chrArray11)[1]);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    string str15 = strArrays1[j].ToString();
                                                                    char[] chrArray12 = new char[] { '»' };
                                                                    str2 = Convert.ToString(str15.Split(chrArray12)[1]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                string str16 = strArrays1[j].ToString();
                                                                char[] chrArray13 = new char[] { '»' };
                                                                empty2 = Convert.ToString(str16.Split(chrArray13)[1]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string str17 = strArrays1[j].ToString();
                                                            char[] chrArray14 = new char[] { '»' };
                                                            str1 = Convert.ToString(str17.Split(chrArray14)[1]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str18 = strArrays1[j].ToString();
                                                        char[] chrArray15 = new char[] { '»' };
                                                        empty1 = Convert.ToString(str18.Split(chrArray15)[1]);
                                                    }
                                                }
                                                else
                                                {
                                                    string str19 = strArrays1[j].ToString();
                                                    char[] chrArray16 = new char[] { '»' };
                                                    empty = Convert.ToString(str19.Split(chrArray16)[1]);
                                                }
                                            }
                                                // date selector
                                            else
                                            {
                                                string strdate = strArrays1[j].ToString();
                                                char[] chrArraydate = new char[] { '»' };
                                                date = Convert.ToString(strdate.Split(chrArraydate)[1]);
                                            }
                                            
                                            }
                                            else
                                            {
                                                string str20 = strArrays1[j].ToString();
                                                char[] chrArray17 = new char[] { '»' };
                                                num4 = Convert.ToDecimal(str20.Split(chrArray17)[1]);
                                            }
                                        }
                                        else
                                        {
                                            string str21 = strArrays1[j].ToString();
                                            char[] chrArray18 = new char[] { '»' };
                                            num3 = Convert.ToInt32(str21.Split(chrArray18)[1]);
                                        }
                                    }
                                    else
                                    {
                                        string str22 = strArrays1[j].ToString();
                                        char[] chrArray19 = new char[] { '»' };
                                        num2 = Convert.ToInt32(str22.Split(chrArray19)[1]);
                                    }
                                }
                                else
                                {
                                    string str23 = strArrays1[j].ToString();
                                    char[] chrArray20 = new char[] { '»' };
                                    num = Convert.ToInt32(str23.Split(chrArray20)[1]);
                                }
                            }
                            else
                            {
                                string str24 = strArrays1[j].ToString();
                                char[] chrArray21 = new char[] { '»' };
                                num1 = Convert.ToInt32(str24.Split(chrArray21)[1]);
                            }
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(num1)) && num1 != 0 && !string.IsNullOrEmpty(empty) && empty != "0")
                        {
                            //this.pricecataloguestock_self_insert_popup(num, num1, empty, empty1, str1, empty2, str2, empty3, num4, "", this.PurchaseNotes, (long)num2, (long)num3);
                            this.pricecataloguestock_self_insert_popup(num, num1, empty, empty1, str1, empty2, str2, empty3, num4, Convert.ToString(date), this.PurchaseNotes, (long)num2, (long)num3);
                        }
                    }
                }
            }
            this.hdnstockselfdetails.Value = "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript: ReplenishWindow_Close();", true);
        }

        protected void lnkbtn_Replenish_SaveandStay_Click(object sender, EventArgs e)
        {
            string str = this.hdnstockselfdetails.Value.Substring(0, this.hdnstockselfdetails.Value.Length - 1);
            long num = (long)0;
            if (!string.IsNullOrEmpty(str.ToString().Trim()))
            {
                string[] strArrays = str.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i].ToString().Trim()))
                    {
                        string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '±' });
                        string empty = string.Empty;
                        string empty1 = string.Empty;
                        string str1 = string.Empty;
                        string empty2 = string.Empty;
                        string str2 = string.Empty;
                        string empty3 = string.Empty;
                        int num1 = 0;
                        int num2 = 0;
                        int num3 = 0;
                        decimal num4 = new decimal(0);
                        string date = "";
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            string str3 = strArrays1[j].ToString();
                            char[] chrArray = new char[] { '»' };
                            if (str3.Split(chrArray)[0] != "openstock")
                            {
                                string str4 = strArrays1[j].ToString();
                                char[] chrArray1 = new char[] { '»' };
                                if (str4.Split(chrArray1)[0] != "ProductCatalogueID")
                                {
                                    string str5 = strArrays1[j].ToString();
                                    char[] chrArray2 = new char[] { '»' };
                                    if (str5.Split(chrArray2)[0] != "EstimateItemID")
                                    {
                                        string str6 = strArrays1[j].ToString();
                                        char[] chrArray3 = new char[] { '»' };
                                        if (str6.Split(chrArray3)[0] != "PurchaseItemID")
                                        {
                                            string str7 = strArrays1[j].ToString();
                                            char[] chrArray4 = new char[] { '»' };
                                            if (str7.Split(chrArray4)[0] != "price")
                                            {
                                                string str8 = strArrays1[j].ToString();
                                                char[] chrArray5 = new char[] { '»' };
                                                // date selector
                                                if (str7.Split(chrArray4)[0] != "date")
                                                {
                                                    string strdate = strArrays1[j].ToString();
                                                    char[] chrArraydate = new char[] { '»' };
                                                    if (str8.Split(chrArray5)[0] != "customfield1")
                                                    {
                                                        string str9 = strArrays1[j].ToString();
                                                        char[] chrArray6 = new char[] { '»' };
                                                        if (str9.Split(chrArray6)[0] != "customfield2")
                                                        {
                                                            string str10 = strArrays1[j].ToString();
                                                            char[] chrArray7 = new char[] { '»' };
                                                            if (str10.Split(chrArray7)[0] != "customfield3")
                                                            {
                                                                string str11 = strArrays1[j].ToString();
                                                                char[] chrArray8 = new char[] { '»' };
                                                                if (str11.Split(chrArray8)[0] != "customfield4")
                                                                {
                                                                    string str12 = strArrays1[j].ToString();
                                                                    char[] chrArray9 = new char[] { '»' };
                                                                    if (str12.Split(chrArray9)[0] != "customfield5")
                                                                    {
                                                                        string str13 = strArrays1[j].ToString();
                                                                        char[] chrArray10 = new char[] { '»' };
                                                                        if (str13.Split(chrArray10)[0] == "customfield6")
                                                                        {
                                                                            string str14 = strArrays1[j].ToString();
                                                                            char[] chrArray11 = new char[] { '»' };
                                                                            empty3 = Convert.ToString(str14.Split(chrArray11)[1]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        string str15 = strArrays1[j].ToString();
                                                                        char[] chrArray12 = new char[] { '»' };
                                                                        str2 = Convert.ToString(str15.Split(chrArray12)[1]);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    string str16 = strArrays1[j].ToString();
                                                                    char[] chrArray13 = new char[] { '»' };
                                                                    empty2 = Convert.ToString(str16.Split(chrArray13)[1]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                string str17 = strArrays1[j].ToString();
                                                                char[] chrArray14 = new char[] { '»' };
                                                                str1 = Convert.ToString(str17.Split(chrArray14)[1]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string str18 = strArrays1[j].ToString();
                                                            char[] chrArray15 = new char[] { '»' };
                                                            empty1 = Convert.ToString(str18.Split(chrArray15)[1]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str19 = strArrays1[j].ToString();
                                                        char[] chrArray16 = new char[] { '»' };
                                                        empty = Convert.ToString(str19.Split(chrArray16)[1]);
                                                    }
                                                }
                                                else
                                                {
                                                    string strdate = strArrays1[j].ToString();
                                                    char[] chrArraydate = new char[] { '»' };
                                                    date = Convert.ToString(strdate.Split(chrArraydate)[1]);
                                                }
                                            }
                                            else
                                            {
                                                string str20 = strArrays1[j].ToString();
                                                char[] chrArray17 = new char[] { '»' };
                                                num4 = Convert.ToDecimal(str20.Split(chrArray17)[1]);
                                            }
                                        }
                                        else
                                        {
                                            string str21 = strArrays1[j].ToString();
                                            char[] chrArray18 = new char[] { '»' };
                                            num3 = Convert.ToInt32(str21.Split(chrArray18)[1]);
                                        }
                                    }
                                    else
                                    {
                                        string str22 = strArrays1[j].ToString();
                                        char[] chrArray19 = new char[] { '»' };
                                        num = (long)Convert.ToInt32(str22.Split(chrArray19)[1]);
                                    }
                                }
                                else
                                {
                                    string str23 = strArrays1[j].ToString();
                                    char[] chrArray20 = new char[] { '»' };
                                    num1 = Convert.ToInt32(str23.Split(chrArray20)[1]);
                                }
                            }
                            else
                            {
                                string str24 = strArrays1[j].ToString();
                                char[] chrArray21 = new char[] { '»' };
                                num2 = Convert.ToInt32(str24.Split(chrArray21)[1]);
                            }
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(num2)) && num2 != 0 && !string.IsNullOrEmpty(empty) && empty != "0")
                        {
                            //this.pricecataloguestock_self_insert_popup(num1, num2, empty, empty1, str1, empty2, str2, empty3, num4, "", "", num, (long)num3);
                            this.pricecataloguestock_self_insert_popup(num1, num2, empty, empty1, str1, empty2, str2, empty3, num4, Convert.ToString(date), this.PurchaseNotes, num, (long)num3);
                        }
                    }
                }
            }
            this.hdnstockselfdetails.Value = "";
            base.Response.Redirect(base.Request.Url.ToString());
        }

        public void LoadSelfAdd()
        {
            object[] item;
            string[] str;
            int num = 0;
            string empty = string.Empty;
            bool flag = false;
            DataTable dataTable = new DataTable();
            dataTable = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, this.ReplenishModuleID, this.EstimateItemID, this.IsFrom);
            DataTable dataTable1 = WebstoreBasePage.stockcustomfields_select(this.CompanyID);
            int count = 0;
            int num1 = 425;
            int num2 = 0;
            int num3 = 5;
            int num4 = 5;
            if (dataTable1.Rows.Count <= 0 || !dataTable1.Rows[0]["datafieldname"].ToString().ToLower().Trim().Contains("customfield1"))
            {
                this.hdnloc_BackOrder_Allocation.Value = "no";
                count = 26;
                num4 = 100;
            }
            else
            {
                this.hdnloc_BackOrder_Allocation.Value = "yes";
                count = 20 + dataTable1.Rows.Count + 1;
            }
            if (dataTable1.Rows.Count == 1)
            {
                num2 = 320;
                num3 = 50;
            }
            if (dataTable1.Rows.Count == 2)
            {
                num2 = 300;
            }
            if (dataTable1.Rows.Count == 3)
            {
                num2 = 225;
            }
            if (dataTable1.Rows.Count == 4)
            {
                num2 = 185;
            }
            if (dataTable1.Rows.Count == 5)
            {
                num2 = 140;
            }
            if (dataTable1.Rows.Count == 6)
            {
                num2 = 120;
            }
            if (this.IsFrom != "purchase")
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DrawStockFrom"].ToString().ToLower() != "s")
                    {
                        continue;
                    }
                    flag = true;
                    break;
                }
                if (flag)
                {
                    empty = "<div id='accordion'>";
                    this.plhstock.Controls.Add(new LiteralControl(empty.ToString()));
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        Common_ReplenishItemAllocation.fieldnames.Clear();
                        DataTable dataTable2 = WebstoreBasePage.pricecataloguestock_self_select(Convert.ToInt32(dataRow["PriceCatalogueID"]));
                        count = 5;
                        //stringBuilder.Append("<h3 id='divAdvancedApprovers' runat='server'> <a href='#' id='firstTab' class='linkbtn'>"); modification
                        stringBuilder.Append("<h3 id='divAdvancedApprovers' runat='server'> <a id='firstTab' class='linkbtn'>");
                        string[] strArrays = new string[] { "<table><tr><td><label class='HeaderText' style='word-break:break-word;'> Item Title: ", dataRow["ItemTitle"].ToString(), " | Item Code: ", dataRow["ItemCode"].ToString(), " </td><td class='HeaderText' align='right'>Quantity: ", dataRow["Quantity"].ToString(), "</label></td></tr>" };
                        stringBuilder.Append(string.Concat(strArrays));
                        stringBuilder.Append("</table></a> </h3>");
                        stringBuilder.Append("<div id='divAdvancedApproversDetails' runat='server' class='undertable borderWithoutTop ClassHeight192px'>");
                        object[] objArray = new object[] { "<table id='tblSelfStock_Replenish", dataRow["PriceCatalogueID"].ToString(), "_", num, "' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >" };
                        stringBuilder.Append(string.Concat(objArray));
                        stringBuilder.Append("<tr style='width:100%;background-color: #DDDDDD;'>");
                        stringBuilder.Append("<td style='width:1%;' align='left'>");
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_Ordered"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("<td style='width:1%;' align='left'>");
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Balance_Due"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("<td style='width:1%;' align='left'>");
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_Received"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append(string.Concat("<td style='width: ", count, "%;' align='right'>"));
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_onHand"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("<td style='width: 12%;' align='right'>");
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Allocated_Quantity"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append(string.Concat("<td style='width: ", count, "%;' align='right'>"));
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Available_Quantity"), "<span>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append(string.Concat("<td style='width: ", count, "%; ' align='right'>"));
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Unit_Cost"), "<span>"));
                        stringBuilder.Append("</td>");
                        // date selector
                        stringBuilder.Append(string.Concat("<td style='width: 1%;' align='center'>"));
                        stringBuilder.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Date"), "<span>"));
                        stringBuilder.Append("</td>");

                        //stringBuilder.Append("<td>");
                        //StringBuilder stringBuilder6 = stringBuilder;
                        //object[] dateFormat = new object[] { "<input id='txtstkdate", 0, "'type='text' style='width:100px;text-align:left' value='", null, null, null, null };
                        //commonClass _commonClass = Common_ReplenishItemAllocation.comm;
                        //DateTime now = DateTime.Now;
                        //dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                        //dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                        //dateFormat[5] = this.DateFormat;
                        //dateFormat[6] = "');  class='textboxnew'  />";
                        //stringBuilder6.Append(string.Concat(dateFormat));
                        //stringBuilder.Append("</td>");

                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            Common_ReplenishItemAllocation.fieldnames.Add(dataTable1.Rows[i]["datafieldname"].ToString().ToLower().Trim());
                            stringBuilder.Append(string.Concat("<td style='width:", num3, "%;' align='left'>"));
                            stringBuilder.Append(string.Concat("<span>", dataTable1.Rows[i]["screenName"], "<span>"));
                            stringBuilder.Append("</td>");
                        }
                        stringBuilder.Append(string.Concat("<td style='width: ", num4, "%;padding: 10px; align='left'>"));
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("</tr>");
                        for (int j = 0; j < dataTable2.Rows.Count; j++)
                        {
                            this.hdnfld_BackOrder_Allocation.Value = "";
                            string str1 = "";
                            str1 = (j % 2 == 0 ? "" : "#EFEFEF");
                            string str2 = "";
                            if (Convert.ToInt64(dataTable2.Rows[j]["AvailableStock"]) < (long)0)
                            {
                                str2 = "color:#f00000;";
                            }
                            string lower = dataTable2.Rows[j]["IsBackOrder"].ToString().ToLower();
                            object[] objArray1 = new object[] { "<tr id='", j, "' style='background-color:", str1, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                            stringBuilder.Append(string.Concat(objArray1));
                            stringBuilder.Append(string.Concat("<td style='width: 5%;", str2, "' align='left'>"));
                            object[] item10 = new object[] { "<div align='left'><label id='lblorderedqty", j, "'> ", dataRow["Quantity"].ToString(), "</label></div>" };
                            stringBuilder.Append(string.Concat(item10));
                            stringBuilder.Append("</td>");
                            stringBuilder.Append(string.Concat("<td style='width: 9%;", str2, "' align='right'>"));
                            string qty1 = dataRow["Quantity"].ToString();
                            string qty2 = dataRow["GoodsReceived"].ToString();
                            int balanceqty = int.Parse(qty1) - int.Parse(qty2);
                            object[] item11 = new object[] { "<div align='left'><label id='lblbalanceqty", j, "'> ", balanceqty.ToString(), "</label></div>" };
                            stringBuilder.Append(string.Concat(item11));
                            stringBuilder.Append("</td>");

                            stringBuilder.Append(string.Concat("<td style='width: 1%;", str2, "' align='right'>"));
                            item = new object[] { "<input id='txtadjustqty", j, "' type='text' style='width:80px;text-align:right;", str2, "' value='0' onkeyup='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ");' onblur='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", j, ",", lower, ");' class='textboxnew' />" };
                            stringBuilder.Append(string.Concat(item));
                            item = new object[] { "<input type='hidden' id='hdn_stockselfID", j, "' value='", dataTable2.Rows[j]["PricecatalogueStockID"], "' />" };
                            stringBuilder.Append(string.Concat(item));
                            item = new object[] { "<input type='hidden' id='hdn_totalqty", j, "' value='", dataTable2.Rows[j]["OpeningStock"], "' />" };
                            stringBuilder.Append(string.Concat(item));
                            str = new string[] { "<input type='hidden' id='hdnActualOrderedQty", dataRow["PriceCatalogueID"].ToString(), "' value='", dataRow["Quantity"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(str));
                            str = new string[] { "<input type='hidden' id='hdn_Selected_EstimateItemID", dataRow["PriceCatalogueID"].ToString(), "' value='", dataRow["EstimateItemID"].ToString(), "' />" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</td>");

                            stringBuilder.Append(string.Concat("<td style='width: 9%;", str2, "' align='right'>"));
                            item = new object[] { "<div align='right'><label id='lblopningstock", j, "'> ", dataTable2.Rows[j]["OpeningStock"], "</label></div>" };
                            stringBuilder.Append(string.Concat(item));
                            stringBuilder.Append("</td>");
                            stringBuilder.Append(string.Concat("<td style='width: 10%;", str2, "' align='right'>"));
                            stringBuilder.Append(string.Concat("<div align='right'>", dataTable2.Rows[j]["AllocatedStock"], "</div>"));
                            stringBuilder.Append("</td>");
                            stringBuilder.Append(string.Concat("<td style='width: 10%;", str2, "' align='right'>"));
                            stringBuilder.Append(string.Concat("<div align='right'>", dataTable2.Rows[j]["AvailableStock"], "</div>"));
                            item = new object[] { "<input type='hidden' id='hdn_availQty", j, "' value='", dataTable2.Rows[j]["AvailableStock"], "' />" };
                            stringBuilder.Append(string.Concat(item));
                            stringBuilder.Append("</td>");
                            stringBuilder.Append(string.Concat("<td align='right' style='width: 8%; padding-right:20px;", str2, "'>"));
                            str = new string[] { "<div>", Common_ReplenishItemAllocation.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable2.Rows[j]["Price"].ToString()), 6, "", false, false, false), "</div><input type='hidden' id='hdnPrice", dataRow["PriceCatalogueID"].ToString(), "' value='", Common_ReplenishItemAllocation.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable2.Rows[j]["Price"].ToString()), 6, "", false, false, false), "' />" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</td>");
                            // date selector
                            stringBuilder.Append("<td>");
                            StringBuilder stringBuilder6 = stringBuilder;
                            object[] dateFormat = new object[] { "<input id='txtstkdate", 0, "'type='text' style='width:100px;text-align:left' disabled='disabled' value='", null, null, null, null };
                            commonClass _commonClass = Common_ReplenishItemAllocation.comm;
                            //DateTime now = DateTime.Now;
                            DateTime now = Convert.ToDateTime(dataTable2.Rows[j]["StockEntryDate"]);
                            dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                            dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                            dateFormat[5] = this.DateFormat;
                            dateFormat[6] = "');  class='textboxnew'  />";
                            stringBuilder6.Append(string.Concat(dateFormat));
                            stringBuilder.Append("</td>");
                            int num5 = 0;
                            int num6 = 1;
                            if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                            {
                                stringBuilder.Append(string.Concat("<td style='width:5%;margin-left:6px;", str2, "' align:'left' >"));
                                stringBuilder.Append("<div>");
                                item = new object[] { "<input id='txtLocation", j + 1, "' disabled type='text' style='width:", num2, "px;text-align:left' text='", dataTable2.Rows[j]["LocationName"].ToString().Trim().Replace("'", "&#39;").Replace("\"", "&#34;"), "' value='", dataTable2.Rows[j]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' autocomplete='off'  onkeyup=javascript:GetLocationDetails(this,'hdnlocationid", j + 1, "','Warehouse','", this.CompanyID, "','1',event);  onclick=javascript:GetLocationDetails(this,'hdnlocationid", j + 1, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdnlocationid", j + 1, ");'  class='textboxnew' />" };
                                stringBuilder.Append(string.Concat(item));
                                item = new object[] { "<input type='hidden' id='hdnlocationid", j + 1, "' value='", dataTable2.Rows[j]["LocationID"].ToString(), "' />" };
                                stringBuilder.Append(string.Concat(item));
                                stringBuilder.Append("</div></td>");
                                num5 = 1;
                                num6 = 2;
                            }
                            while (num6 < dataTable1.Rows.Count + 1)
                            {
                                if (num5 >= dataTable1.Rows.Count)
                                {
                                    continue;
                                }
                                for (int k = 2; k <= 6; k++)
                                {
                                    if (dataTable1.Rows[num5]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", k))
                                    {
                                        if (!string.IsNullOrEmpty(this.hdnfld_BackOrder_Allocation.Value.Trim()))
                                        {
                                            HiddenField hdnfldBackOrderAllocation = this.hdnfld_BackOrder_Allocation;
                                            hdnfldBackOrderAllocation.Value = string.Concat(hdnfldBackOrderAllocation.Value, ",", Convert.ToString(dataTable1.Rows[num5]["StockFieldId"]));
                                        }
                                        else
                                        {
                                            this.hdnfld_BackOrder_Allocation.Value = string.Concat("1,", Convert.ToString(dataTable1.Rows[num5]["StockFieldId"]));
                                        }
                                        stringBuilder.Append(string.Concat("<td style='width:8%;", str2, "' align='left'>"));
                                        stringBuilder.Append("<div>");
                                        item = new object[] { "<input id='txtcustomfield", k, "_", j + 1, "' disabled type='text'  text='", dataTable2.Rows[j][string.Concat("Customfield", k)], "' value='", dataTable2.Rows[j][string.Concat("Customfield", k)], "' style='width:", num2, "px;text-align:left'  class='textboxnew' />" };
                                        stringBuilder.Append(string.Concat(item));
                                        stringBuilder.Append("</div></td>");
                                    }
                                }
                                num5++;
                                num6++;
                            }
                            stringBuilder.Append("<td style='width: 5%;padding: 10px; align='left'>");
                            stringBuilder.Append("</td>");
                            stringBuilder.Append("</tr>");
                        }
                        num1 = 0;
                        if (dataTable1.Rows.Count == 6)
                        {
                            num1 = 15;
                        }
                        int num7 = 10;
                        if (dataTable1.Rows.Count == 5)
                        {
                            num7 = 11;
                        }
                        stringBuilder.Append(string.Concat("<tr><td colspan='", num7, "' align = 'right'>"));
                        item = new object[] { "<span style='float: right; width: 35%; margin-right: -", num1, "%;'><a href=javascript:void(null); onclick=javascript: AllocationPopUp1('", dataRow["PriceCatalogueID"].ToString(), "'); return false;'>View Stock |</a><a href=javascript:void(null); onclick=addingrowself('tblSelfStock_Replenish", dataRow["PriceCatalogueID"].ToString(), "_", num, "','hdnfld_BackOrder_Allocation',", dataRow["PriceCatalogueID"].ToString(), ",", dataRow["Quantity"].ToString(), ",", dataRow["EstimateItemID"].ToString(), ",", dataRow["PurchaseItemID"], ");> Add Location</a></span>" };
                        stringBuilder.Append(string.Concat(item));
                        stringBuilder.Append("</td></tr>");
                        stringBuilder.Append("<tr><td colspan='20' align='left'>");
                        stringBuilder.Append("<div style='height: 10px;' class='onlyEmpty'></div>");
                        stringBuilder.Append("<table style='float: right;' ><tr><td align='right'>");
                        if (this.EstimateItemID == (long)0 && dataTable.Rows.Count > 1)
                        {
                            stringBuilder.Append(string.Concat("<div id='div_btn_SaveandStayReplenishAllocation", num, "' style='float:right'>"));
                            item = new object[] { "<input id='btn_SaveandStayReplenishAllocation", dataRow["PriceCatalogueID"].ToString(), "' type='submit' class='button' value='Save and Stay' onclick='javascript: return getSelfStockDetails(tblSelfStock_Replenish", dataRow["PriceCatalogueID"].ToString(), "_", num, ",", dataRow["PriceCatalogueID"].ToString(), ",this.id,", num, ",", dataRow["Quantity"].ToString(), ");'/>" };
                            stringBuilder.Append(string.Concat(item));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(string.Concat("<div id='div_stayprocess", num, "' class='loadingdivbtn' style='display: none; width: 96px; '>"));
                            stringBuilder.Append(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />"));
                            stringBuilder.Append("</div>");
                        }
                        stringBuilder.Append("</td><td align='left'>");
                        stringBuilder.Append(string.Concat("<div id='div_btn_SaveReplenishAllocation", num, "'>"));
                        item = new object[] { "<input id='btn_SaveReplenishAllocation", dataRow["PriceCatalogueID"].ToString(), "' type='submit' class='button' value='Save and Close' onclick='javascript: return getSelfStockDetails(tblSelfStock_Replenish", dataRow["PriceCatalogueID"].ToString(), "_", num, ",", dataRow["PriceCatalogueID"].ToString(), ",this.id,", num, ",", dataRow["Quantity"].ToString(), ");'/>" };
                        stringBuilder.Append(string.Concat(item));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append(string.Concat("<div id='div_saveprocess", num, "' class='loadingdivbtn' style='display: none; width:100px;'>"));
                        stringBuilder.Append(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td></tr></table>");
                        stringBuilder.Append("</td></tr>");
                        stringBuilder.Append("</table>");
                        stringBuilder.Append("</div>");
                        this.plhstock.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        num++;
                    }
                    empty = "</div>";
                    this.plhstock.Controls.Add(new LiteralControl(empty.ToString()));
                }
                return;
            }
            empty = "<div id='accordion'>";
            this.plhstock.Controls.Add(new LiteralControl(empty.ToString()));
            foreach (DataRow row1 in dataTable.Rows)
            {
                item = new object[] { "Stock added through Purchase order  <a style='cursor:pointer;color:blue;' href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", this.ReplenishModuleID, "' target='_blank'>", "#", row1["PONO"].ToString(), "</a>" };
                this.PurchaseNotes = string.Concat(item);
                StringBuilder stringBuilder1 = new StringBuilder();
                Common_ReplenishItemAllocation.fieldnames.Clear();
                DataTable dataTable3 = WebstoreBasePage.pricecataloguestock_self_select(Convert.ToInt32(row1["WarehouseItemID"]));
                count = 5;
                //stringBuilder1.Append("<h3 id='divAdvancedApprovers' runat='server'> <a href='#' id='firstTab' class='linkbtn'>");modification
                stringBuilder1.Append("<h3 id='divAdvancedApprovers' runat='server'> <a id='firstTab' class='linkbtn'>");
                stringBuilder1.Append(string.Concat("<table><tr><td class='HeaderText' style='word-break:break-word;width: 1000px;'> Item Title: ", row1["ItemTitle"].ToString(), " | Item Code: ", row1["ItemCode"].ToString(), "</td>"));
                stringBuilder1.Append(string.Concat("<td class='HeaderText' align='right'>Quantity: ", row1["Quantity"].ToString(), "</td></tr>"));
                stringBuilder1.Append("</table></a> </h3>");
                stringBuilder1.Append("<div id='divAdvancedApproversDetails' runat='server' class='undertable borderWithoutTop ClassHeight192px'>");
                object[] objArray2 = new object[] { "<table id='tblSelfStock_Replenish", row1["WarehouseItemID"].ToString(), "_", num, "' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >" };
                stringBuilder1.Append(string.Concat(objArray2));
                stringBuilder1.Append("<tr style='width:100%;background-color: #DDDDDD;'>");
                stringBuilder1.Append("<td style='width:1%;' align='left'>");
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_Ordered"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append("<td style='width:1%;' align='left'>");
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Balance_Due"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append("<td style='width:1%;' align='left'>");
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_Received"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append(string.Concat("<td style='width: ", count, "%;' align='right'>"));
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Quantity_onHand"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append("<td style='width: 12%;' align='right'>");
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Allocated_Quantity"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append(string.Concat("<td style='width: ", count, "%;' align='right'>"));
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Available_Quantity"), "<span>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append(string.Concat("<td style='width: ", count, "%; ' align='right'>"));
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Unit_Cost"), "<span>"));
                stringBuilder1.Append("</td>");
                // date selector
                stringBuilder1.Append(string.Concat("<td style='width: ", count, "%;' align='center'>"));
                stringBuilder1.Append(string.Concat("<span>", Common_ReplenishItemAllocation.objLanguage.GetLanguageConversion("Date"), "<span>"));
                stringBuilder1.Append("</td>");

                //stringBuilder1.Append("<td>");
                //StringBuilder stringBuilder6 = stringBuilder1;
                //object[] dateFormat = new object[] { "<input id='txtstkdate", 0, "'type='text' style='width:100px;text-align:left' value='", null, null, null, null };
                //commonClass _commonClass = Common_ReplenishItemAllocation.comm;
                //DateTime now = DateTime.Now;
                //dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                //dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                //dateFormat[5] = this.DateFormat;
                //dateFormat[6] = "');  class='textboxnew'  />";
                //stringBuilder6.Append(string.Concat(dateFormat));
                //stringBuilder1.Append("</td>");
                for (int l = 0; l < dataTable1.Rows.Count; l++)
                {
                    Common_ReplenishItemAllocation.fieldnames.Add(dataTable1.Rows[l]["datafieldname"].ToString().ToLower().Trim());
                    stringBuilder1.Append(string.Concat("<td style='width:", num3, "%;' align='left'>"));
                    stringBuilder1.Append(string.Concat("<span>", dataTable1.Rows[l]["screenName"], "<span>"));
                    stringBuilder1.Append("</td>");
                }
                stringBuilder1.Append(string.Concat("<td style='width: ", num4, "%;padding: 10px; align='left'>"));
                stringBuilder1.Append("</td>");
                stringBuilder1.Append("</tr>");
                for (int m = 0; m < dataTable3.Rows.Count; m++)
                {
                    this.hdnfld_BackOrder_Allocation.Value = "";
                    string str3 = "";
                    str3 = (m % 2 == 0 ? "" : "#EFEFEF");
                    string str4 = "";
                    if (Convert.ToInt64(dataTable3.Rows[m]["AvailableStock"]) < (long)0)
                    {
                        str4 = "color:#f00000;";
                    }
                    string lower1 = dataTable3.Rows[m]["IsBackOrder"].ToString().ToLower();
                    object[] objArray3 = new object[] { "<tr id='", m, "' style='background-color:", str3, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                    stringBuilder1.Append(string.Concat(objArray3));
                    stringBuilder1.Append(string.Concat("<td style='width: 9%;", str4, "' align='right'>"));
                    object[] item10 = new object[] { "<div align='left'><label id='lblorderedqty", m, "'> ", row1["Quantity"].ToString(), "</label></div>" };
                    stringBuilder1.Append(string.Concat(item10));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td style='width: 9%;", str4, "' align='right'>"));
                    string qty1 = row1["Quantity"].ToString();
                    string qty2 = row1["GoodsReceived"].ToString();
                    int balanceqty = int.Parse(qty1) - int.Parse(qty2);
                    object[] item11 = new object[] { "<div align='left'><label id='lblbalanceqty", m, "'> ", balanceqty.ToString(), "</label></div>" };
                    stringBuilder1.Append(string.Concat(item11));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td style='width: 5%;", str4, "' align='left'>"));
                    object[] objArray4 = new object[] { "<input id='txtadjustqty", m, "' type='text' style='width:80px;text-align:right;", str4, "' value='0' onkeyup='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", m, ");' onblur='javascript:checkforIntegerSelf(this.id,this.value,hdn_totalqty", m, ",", lower1, ");' class='textboxnew' />" };
                    stringBuilder1.Append(string.Concat(objArray4));
                    object[] item1 = new object[] { "<input type='hidden' id='hdn_stockselfID", m, "' value='", dataTable3.Rows[m]["PricecatalogueStockID"], "' />" };
                    stringBuilder1.Append(string.Concat(item1));
                    object[] item2 = new object[] { "<input type='hidden' id='hdn_totalqty", m, "' value='", dataTable3.Rows[m]["OpeningStock"], "' />" };
                    stringBuilder1.Append(string.Concat(item2));
                    str = new string[] { "<input type='hidden' id='hdnActualOrderedQty", row1["WarehouseItemID"].ToString(), "' value='", row1["Quantity"].ToString(), "' />" };
                    stringBuilder1.Append(string.Concat(str));
                    string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_Selected_EstimateItemID", row1["WarehouseItemID"].ToString(), "' value='", row1["EstimateItemID"].ToString(), "' />" };
                    stringBuilder1.Append(string.Concat(strArrays1));
                    string[] strArrays2 = new string[] { "<input type='hidden' id='hdn_Selected_PurchaseItemID", row1["WarehouseItemID"].ToString(), "' value='", row1["PurchaseItemID"].ToString(), "' />" };
                    stringBuilder1.Append(string.Concat(strArrays2));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td style='width: 9%;", str4, "' align='right'>"));
                    object[] item3 = new object[] { "<div align='right'><label id='lblopningstock", m, "'> ", dataTable3.Rows[m]["OpeningStock"], "</label></div>" };
                    stringBuilder1.Append(string.Concat(item3));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td style='width: 10%;", str4, "' align='right'>"));
                    stringBuilder1.Append(string.Concat("<div align='right'>", dataTable3.Rows[m]["AllocatedStock"], "</div>"));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td style='width: 10%;", str4, "' align='right'>"));
                    stringBuilder1.Append(string.Concat("<div align='right'>", dataTable3.Rows[m]["AvailableStock"], "</div>"));
                    object[] item4 = new object[] { "<input type='hidden' id='hdn_availQty", m, "' value='", dataTable3.Rows[m]["AvailableStock"], "' />" };
                    stringBuilder1.Append(string.Concat(item4));
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append(string.Concat("<td align='right' style='width: 8%; padding-right:20px;", str4, "'>"));
                    string[] strArrays3 = new string[] { "<div>", Common_ReplenishItemAllocation.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable3.Rows[m]["Price"].ToString()), 6, "", false, false, false), "</div><input type='hidden' id='hdnPrice", row1["WarehouseItemID"].ToString(), "' value='", Common_ReplenishItemAllocation.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable3.Rows[m]["Price"].ToString()), 6, "", false, false, false), "' />" };
                    stringBuilder1.Append(string.Concat(strArrays3));
                    stringBuilder1.Append("</td>");
                    // date selector
                    stringBuilder1.Append("<td>");
                    StringBuilder stringBuilder6 = stringBuilder1;
                    object[] dateFormat = new object[] { "<input id='txtstkdate", 0, "'type='text' style='width:100px;text-align:left' disabled='disabled' value='", null, null, null, null };
                    commonClass _commonClass = Common_ReplenishItemAllocation.comm;
                    //DateTime now = DateTime.Now;
                    DateTime now = Convert.ToDateTime(dataTable3.Rows[m]["StockEntryDate"]);
                    dateFormat[3] = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                    dateFormat[4] = "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'";
                    dateFormat[5] = this.DateFormat;
                    dateFormat[6] = "');  class='textboxnew'  />";
                    stringBuilder6.Append(string.Concat(dateFormat));
                    stringBuilder1.Append("</td>");
                    int num8 = 0;
                    int num9 = 1;
                    if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                    {
                        stringBuilder1.Append(string.Concat("<td style='width:5%;margin-left:6px;", str4, "' align:'left' >"));
                        stringBuilder1.Append("<div>");
                        object[] objArray5 = new object[] { "<input id='txtLocation", m + 1, "' disabled type='text' style='width:", num2, "px;text-align:left;", str4, "' text='", dataTable3.Rows[m]["LocationName"].ToString().Trim().Replace("'", "&#39;").Replace("\"", "&#34;"), "' value='", dataTable3.Rows[m]["LocationName"].ToString().Replace("'", "&#39;").Replace("\"", "&#34;"), "' autocomplete='off'  onkeyup=javascript:GetLocationDetails(this,'hdnlocationid", m + 1, "','Warehouse','", this.CompanyID, "','1',event);  onclick=javascript:GetLocationDetails(this,'hdnlocationid", m + 1, "','Warehouse','", this.CompanyID, "','1',event); onblur='javascript:chkloc(this.value,hdnlocationid", m + 1, ");'  class='textboxnew' />" };
                        stringBuilder1.Append(string.Concat(objArray5));
                        object[] str5 = new object[] { "<input type='hidden' id='hdnlocationid", m + 1, "' value='", dataTable3.Rows[m]["LocationID"].ToString(), "' />" };
                        stringBuilder1.Append(string.Concat(str5));
                        stringBuilder1.Append("</div></td>");
                        num8 = 1;
                        num9 = 2;
                    }
                    while (num9 < dataTable1.Rows.Count + 1)
                    {
                        if (num8 >= dataTable1.Rows.Count)
                        {
                            continue;
                        }
                        for (int n = 2; n <= 6; n++)
                        {
                            if (dataTable1.Rows[num8]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", n))
                            {
                                if (!string.IsNullOrEmpty(this.hdnfld_BackOrder_Allocation.Value.Trim()))
                                {
                                    HiddenField hiddenField = this.hdnfld_BackOrder_Allocation;
                                    hiddenField.Value = string.Concat(hiddenField.Value, ",", Convert.ToString(dataTable1.Rows[num8]["StockFieldId"]));
                                }
                                else
                                {
                                    this.hdnfld_BackOrder_Allocation.Value = string.Concat("1,", Convert.ToString(dataTable1.Rows[num8]["StockFieldId"]));
                                }
                                stringBuilder1.Append(string.Concat("<td style='width:8%;", str4, "' align='left'>"));
                                stringBuilder1.Append("<div>");
                                object[] item5 = new object[] { "<input id='txtcustomfield", n, "_", m + 1, "' disabled type='text'  text='", dataTable3.Rows[m][string.Concat("Customfield", n)], "' value='", dataTable3.Rows[m][string.Concat("Customfield", n)], "' style='width:", num2, "px;text-align:left;", str4, "'  class='textboxnew' />" };
                                stringBuilder1.Append(string.Concat(item5));
                                stringBuilder1.Append("</div></td>");
                            }
                        }
                        num8++;
                        num9++;
                    }
                    stringBuilder1.Append("<td style='width: 5%;padding: 10px; align='left'>");
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append("</tr>");
                }
                if (this.hdnfld_BackOrder_Allocation.Value == "")
                {
                    int num8 = 0;
                    int num9 = 1;
                    if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["datafieldname"].ToString().ToLower().Trim() == "customfield1")
                    {
                        num8 = 1;
                        num9 = 2;
                    }
                    while (num9 < dataTable1.Rows.Count + 1)
                    {
                        if (num8 >= dataTable1.Rows.Count)
                        {
                            continue;
                        }
                        for (int n = 2; n <= 6; n++)
                        {
                            if (dataTable1.Rows[num8]["datafieldname"].ToString().ToLower().Trim() == string.Concat("customfield", n))
                            {
                                if (!string.IsNullOrEmpty(this.hdnfld_BackOrder_Allocation.Value.Trim()))
                                {
                                    HiddenField hiddenField = this.hdnfld_BackOrder_Allocation;
                                    hiddenField.Value = string.Concat(hiddenField.Value, ",", Convert.ToString(dataTable1.Rows[num8]["StockFieldId"]));
                                }
                                else
                                {
                                    this.hdnfld_BackOrder_Allocation.Value = string.Concat("1,", Convert.ToString(dataTable1.Rows[num8]["StockFieldId"]));
                                }
                            }
                        }
                        num8++;
                        num9++;
                    }

                }
                num1 = 0;
                if (dataTable1.Rows.Count == 6)
                {
                    num1 = 15;
                }
                int num10 = 10;
                if (dataTable1.Rows.Count == 5)
                {
                    num10 = 11;
                }
                stringBuilder1.Append(string.Concat("<tr><td colspan='", num10, "' align = 'right'>"));
                object[] str6 = new object[] { "<span style='float: right; width: 35%; margin-right: -", num1, "%;'><a href=javascript:void(null); onclick=javascript:AllocationPopUp1('", row1["PriceCatalogueID"].ToString(), "');return false;'>View Stock |</a><a href=javascript:void(null); onclick=addingrowself('tblSelfStock_Replenish", row1["WarehouseItemID"].ToString(), "_", num, "','hdnfld_BackOrder_Allocation',", row1["WarehouseItemID"].ToString(), ",", row1["Quantity"].ToString(), ",", row1["EstimateItemID"].ToString(), ",", row1["PurchaseItemID"], ");> Add Location</a></span>" };
                stringBuilder1.Append(string.Concat(str6));
                stringBuilder1.Append("</td></tr>");
                stringBuilder1.Append("<tr><td colspan='20' align='left'>");
                stringBuilder1.Append("<div style='height: 10px;' class='onlyEmpty'></div>");
                stringBuilder1.Append("<table style='float: right;' ><tr><td align='right'>");
                if (dataTable.Rows.Count > 1)
                {
                    stringBuilder1.Append(string.Concat("<div id='div_btn_SaveandStayReplenishAllocation", num, "' style='float:right'>"));
                    object[] objArray6 = new object[] { "<input id='btn_SaveandStayReplenishAllocation", row1["WarehouseItemID"].ToString(), "' type='submit' class='button' value='Save and Stay' onclick='javascript: return getSelfStockDetails(tblSelfStock_Replenish", row1["WarehouseItemID"].ToString(), "_", num, ",", row1["WarehouseItemID"].ToString(), ",this.id,", num, ",", row1["Quantity"].ToString(), ",", row1["GoodsReceived"].ToString(), ");'/>" };
                    stringBuilder1.Append(string.Concat(objArray6));
                    stringBuilder1.Append("</div>");
                    stringBuilder1.Append(string.Concat("<div id='div_stayprocess", num, "' class='loadingdivbtn' style='display: none; width: 96px; '>"));
                    stringBuilder1.Append(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />"));
                    stringBuilder1.Append("</div>");
                }
                stringBuilder1.Append("</td><td align='left'>");
                stringBuilder1.Append(string.Concat("<div id='div_btn_SaveReplenishAllocation", num, "'>"));
                object[] str7 = new object[] { "<input id='btn_SaveReplenishAllocation", row1["WarehouseItemID"].ToString(), "' type='submit' class='button' value='Save and Close' onclick='javascript: return getSelfStockDetails(tblSelfStock_Replenish", row1["WarehouseItemID"].ToString(), "_", num, ",", row1["WarehouseItemID"].ToString(), ",this.id,", num, ",", row1["Quantity"].ToString(), ",", row1["GoodsReceived"].ToString(), ");'/>" };
                stringBuilder1.Append(string.Concat(str7));
                stringBuilder1.Append("</div>");
                stringBuilder1.Append(string.Concat("<div id='div_saveprocess", num, "' class='loadingdivbtn' style='display: none; width:100px;'>"));
                stringBuilder1.Append(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' />"));
                stringBuilder1.Append("</div>");
                stringBuilder1.Append("</td></tr></table>");
                stringBuilder1.Append("</td></tr>");
                stringBuilder1.Append("</table>");
                stringBuilder1.Append("</div>");
                this.plhstock.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                num++;
            }
            empty = "</div>";
            this.plhstock.Controls.Add(new LiteralControl(empty.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {           

            if (this.Session["CompanyID"] == null || this.Session["UserID"] == null)
            {
                this.objbaseclass.Session_Check();
            }
            base.Title = Common_ReplenishItemAllocation.objLanguage.convert("Stock Replenishment");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["EstimateItemID"] != null && base.Request.Params["EstimateItemID"].ToString() != "")
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"].ToString().Trim());
            }
            if (base.Request.Params["JobID"] != null)
            {
                if (base.Request.Params["JobID"].ToString() != "")
                {
                    this.JobID = Convert.ToInt64(base.Request.Params["JobID"].ToString().Trim());
                    this.ReplenishModuleID = Convert.ToInt64(base.Request.Params["JobID"].ToString().Trim());
                }
            }
            else if (base.Request.Params["jID"] != null && base.Request.Params["jID"].ToString() != "")
            {
                this.JobID = Convert.ToInt64(base.Request.Params["jID"].ToString().Trim());
                this.ReplenishModuleID = Convert.ToInt64(base.Request.Params["jID"].ToString().Trim());
            }
            if (base.Request.Params["EstimateID"] != null && base.Request.Params["EstimateID"].ToString() != "")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"].ToString().Trim());
            }
            if (base.Request.Params["ReplenishStatusID"] != null && base.Request.Params["ReplenishStatusID"].ToString() != "")
            {
                this.ReplenishStatusID = Convert.ToInt64(base.Request.Params["ReplenishStatusID"].ToString().Trim());
            }
            if (base.Request.Params["IsFrom"] != null && base.Request.Params["IsFrom"].ToString() != "")
            {
                this.IsFrom = Convert.ToString(base.Request.Params["IsFrom"].ToString().Trim());
            }
            if (base.Request.Params["ReplenishPurchaseID"] != null && base.Request.Params["ReplenishPurchaseID"].ToString() != "")
            {
                this.ReplenishPurchaseID = Convert.ToInt64(base.Request.Params["ReplenishPurchaseID"].ToString().Trim());
                this.ReplenishModuleID = Convert.ToInt64(base.Request.Params["ReplenishPurchaseID"].ToString().Trim());
            }
            if (base.Request.Params["SaveType"] != null && base.Request.Params["SaveType"].ToString() != "")
            {
                this.SaveType = Convert.ToString(base.Request.Params["SaveType"].ToString().Trim());
            }
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.roundoff = Convert.ToInt32(row["Roundoff"].ToString());
            }
            if (this.JobID > (long)0 && this.ReplenishStatusID > (long)0)
            {
                foreach (DataRow dataRow in SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "job").Rows)
                {
                    if (Convert.ToInt64(dataRow["StatusID"]) != this.ReplenishStatusID)
                    {
                        continue;
                    }
                    this.ReplenishStatusTitle = Convert.ToString(dataRow["StatusTitle"]);
                    break;
                }
            }
            // get default location and date
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
            this.DateFormat = Convert.ToString(Session["DateFormat"]);
            this.hdnDateFormat.Value = this.DateFormat;
            DateTime now = DateTime.Now;
            //this.hdnTodate.Value = Convert.ToString(now);
            this.hdnTodate.Value = comm.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);

            this.getalldetails();
           
        }

        public void pricecataloguestock_self_insert_popup(int PricecatalogueID, int openingstock, string Customfield1, string Customfield2, string Customfield3, string Customfield4, string Customfield5, string Customfield6, decimal Price, string popupdate, string PurchaseNotes, long EstimateItemID, long ReplenishPurchaseItemID)
        {
            string regionalSettings = (new BasePage()).GetRegionalSettings(this.CompanyID, "Dateformat");
            commonClass _commonClass = new commonClass();
            // ticket 110655
            DateTime dt;
            if (regionalSettings == "mm/dd/yyyy")
                dt = DateTime.Parse(popupdate, System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            else
                dt = DateTime.Parse(popupdate, System.Globalization.CultureInfo.GetCultureInfo("en-gb"));

            string str = WebstoreBasePage.pricecataloguestock_actiontype_check((long)PricecatalogueID, "self");
            //DateTime now = DateTime.Now;
            //string str1 = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(regionalSettings, _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            string str1 = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(regionalSettings, _commonClass.Eprint_return_Date_Before_View(dt.ToString(), this.CompanyID, this.UserID, true));
            DateTime dateTime = Convert.ToDateTime(str1);
            string empty = string.Empty;
            if (this.CompanyID > 0 && this.JobID > (long)0)
            {
                foreach (DataRow row in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.JobID).Rows)
                {
                    empty = row["JobNumber"].ToString();
                }
            }
            bool isStockReplenishItem = this.objbaseclass.Replenished_EstimateItem_IsStockReplenishItem(EstimateItemID);
            if (this.IsFrom != "purchase" || isStockReplenishItem == true)
            {
                object[] itemNew = new object[] { "Stock added through Stock Replenishment for Job  <a style='cursor:pointer;color:blue;' href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&amp;estid=", this.EstimateID, "&amp;jID=",this.JobID ,"' target='_blank'>", "#", empty, "</a>" };
                this.PurchaseNotes = string.Concat(itemNew);
                //WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Price, this.UserID, dateTime, str, string.Concat("Stock added through Stock Replenishment for Job #", empty),"");
                WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Price, this.UserID, dateTime, str, this.PurchaseNotes, "");
                this.objBaseClass.GoodsAdded_updateestimateitem(EstimateItemID, openingstock); //modification
                this.objBaseClass.Replenished_updatepurchaseitem(EstimateItemID);
                if (ReplenishPurchaseItemID != (long)0)
                {
                    this.objBaseClass.GoodsAdded_updatepurchaseitem(ReplenishPurchaseItemID, openingstock);
                }
            }
            else
            {
                WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Price, this.UserID, dateTime, str, PurchaseNotes,"");
                this.objBaseClass.GoodsAdded_updatepurchaseitem(ReplenishPurchaseItemID, openingstock);
                if (EstimateItemID != (long)0)
                {
                    this.objBaseClass.Replenished_updatepurchaseitem(EstimateItemID);
                    return;
                }
            }
        }
    }
}