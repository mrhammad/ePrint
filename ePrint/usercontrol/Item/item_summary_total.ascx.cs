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
    public partial class item_summary_total : UsercontrolBasePage
    {
        //protected PlaceHolder plhItemTotal;

        //protected Button btnSave;

        //protected Button btnStay;

        //protected HiddenField hdnSaveValues;

        //protected HiddenField hdnProfitmarginvalue;

        //protected HiddenField hdnProfitMarginInPrice;

        //protected HiddenField hdnSutotalold;

        //protected HiddenField hdnTaxPrice;

        //protected HiddenField hdn_Description;

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass commclass = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public int QtyCount;

        public int SectionCount;

        public int QtyNumber;

        private decimal DefaultTaxrate;

        private int DefaultTaxID;

        public bool Check_SpecialPrivilege;

        public bool UnitOfMeasureKey;

        public bool IsShowOW1;

        public bool IsShowOW2;

        public bool IsShowOW3;

        public bool IsShowOW4;

        public string IsFromActHist = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public bool IsAccountingCode;

        public int OrderItemApprovalStatus;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string btnType = string.Empty;

        public string SaveValues = string.Empty;

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

        static item_summary_total()
        {
            item_summary_total.SalesPersonID = string.Empty;
            item_summary_total.IsEditOnlyHisRecords = string.Empty;
        }

        public item_summary_total()
        {
        }

        protected void btnStay_Click(object sender, EventArgs e)
        {
            char[] chrArray;
            string value;
            string[] str;
            object[] invID;
            string[] strArrays = new string[0];
            if (this.SaveValues.ToString() == "")
            {
                string value1 = this.hdnSaveValues.Value;
                chrArray = new char[] { '|' };
                strArrays = value1.Split(chrArray);
            }
            else
            {
                string saveValues = this.SaveValues;
                chrArray = new char[] { '|' };
                strArrays = saveValues.Split(chrArray);
            }
            long num = (long)0;
            long num1 = (long)0;
            string empty = string.Empty;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str1 = strArrays[i];
                chrArray = new char[] { '~' };
                string[] strArrays1 = str1.Split(chrArray);
                long num2 = Convert.ToInt64(strArrays1[2]);
                if (num2 != (long)-999)
                {
                    item_summary itemSummary = new item_summary();
                    num1 = Convert.ToInt64(strArrays1[0]);
                    num = Convert.ToInt64(strArrays1[1]);
                    string str2 = strArrays1[3].ToString();
                    DataTable dataTable = EstimatesBasePage.estimate_item_total_price_details_select(this.CompanyID, num, str2);
                    this.hdnTaxPrice.Value = "";
                    this.hdnSutotalold.Value = "";
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (num2 != (long)-999 && num2 == (long)0)
                        {
                            HiddenField hiddenField = this.hdnProfitmarginvalue;
                            hiddenField.Value = string.Concat(hiddenField.Value, Convert.ToDecimal(row["TotalProfitMarginPercentage1"]), "^");
                        }
                        if (num2 != (long)0 && num2 != (long)-999)
                        {
                            HiddenField hiddenField1 = this.hdnProfitmarginvalue;
                            value = hiddenField1.Value;
                            str = new string[] { value, row["TotalProfitMarginPercentage1"].ToString(), "~", row["SectionID"].ToString(), "^" };
                            hiddenField1.Value = string.Concat(str);
                        }
                        if (num2 != (long)-999 && num2 == (long)0)
                        {
                            HiddenField hiddenField2 = this.hdnProfitMarginInPrice;
                            hiddenField2.Value = string.Concat(hiddenField2.Value, Convert.ToDecimal(row["TotalProfitMarginPrice1"]), "^");
                        }
                        if (num2 != (long)0 && num2 != (long)-999)
                        {
                            HiddenField hiddenField3 = this.hdnProfitMarginInPrice;
                            value = hiddenField3.Value;
                            str = new string[] { value, row["TotalProfitMarginPrice1"].ToString(), "~", row["SectionID"].ToString(), "^" };
                            hiddenField3.Value = string.Concat(str);
                        }
                        if (num2 != (long)-999 && num2 == (long)0)
                        {
                            HiddenField hiddenField4 = this.hdnSutotalold;
                            hiddenField4.Value = string.Concat(hiddenField4.Value, Convert.ToDecimal(row["TotalSubTotal1"]), "^");
                        }
                        if (num2 != (long)0 && num2 != (long)-999)
                        {
                            HiddenField hiddenField5 = this.hdnSutotalold;
                            value = hiddenField5.Value;
                            str = new string[] { value, row["TotalSubTotal1"].ToString(), "~", row["SectionID"].ToString(), "^" };
                            hiddenField5.Value = string.Concat(str);
                        }
                        if (num2 != (long)-999 && num2 == (long)0)
                        {
                            HiddenField hiddenField6 = this.hdnTaxPrice;
                            hiddenField6.Value = string.Concat(hiddenField6.Value, Convert.ToDecimal(row["TotalTaxPrice1"]), "^");
                        }
                        if (num2 == (long)0 || num2 == (long)-999)
                        {
                            continue;
                        }
                        HiddenField hiddenField7 = this.hdnTaxPrice;
                        value = hiddenField7.Value;
                        str = new string[] { value, row["TotalTaxPrice1"].ToString(), "~", row["SectionID"].ToString(), "^" };
                        hiddenField7.Value = string.Concat(str);
                    }
                    decimal num3 = Convert.ToDecimal(strArrays1[4]);
                    if (this.hdnProfitmarginvalue.Value != "" && this.hdnSutotalold.Value != "")
                    {
                        if (num2 != (long)0)
                        {
                            string str3 = this.hdnProfitmarginvalue.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays2 = str3.Split(chrArray);
                            for (int j = 0; j < (int)strArrays2.Length - 1; j++)
                            {
                                string str4 = strArrays2[j];
                                chrArray = new char[] { '~' };
                                string[] strArrays3 = str4.Split(chrArray);
                                if (Convert.ToDecimal(this.ToDecimal(strArrays3[0].Trim())) != num3 && Convert.ToInt64(strArrays3[1]) == num2)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Profit margin(%)", "ProfitMargin", Convert.ToString(this.ToDecimal(strArrays3[0].Trim())), Convert.ToString(num3), str2);
                                }
                            }
                        }
                        else
                        {
                            string str5 = this.hdnProfitmarginvalue.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays4 = str5.Split(chrArray);
                            for (int k = 0; k < (int)strArrays4.Length - 1; k++)
                            {
                                if (Convert.ToDecimal(this.ToDecimal(strArrays4[k].Trim())) != num3)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Profit margin(%)", "ProfitMargin", Convert.ToString(this.ToDecimal(strArrays4[k].Trim())), Convert.ToString(num3), str2);
                                }
                            }
                        }
                    }
                    decimal num4 = Convert.ToDecimal(strArrays1[5]);
                    decimal num5 = Convert.ToDecimal(strArrays1[6]);
                    decimal num6 = Convert.ToDecimal(strArrays1[7]);
                    decimal num7 = Convert.ToDecimal(strArrays1[8]);
                    if (this.hdnProfitMarginInPrice.Value != "")
                    {
                        if (num2 != (long)0)
                        {
                            string str6 = this.hdnProfitMarginInPrice.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays5 = str6.Split(chrArray);
                            for (int l = 0; l < (int)strArrays5.Length - 1; l++)
                            {
                                string str7 = strArrays5[l];
                                chrArray = new char[] { '~' };
                                string[] strArrays6 = str7.Split(chrArray);
                                if (Convert.ToDecimal(this.ToDecimal(strArrays6[0].Trim())) != num7 && Convert.ToInt64(strArrays6[1]) == num2)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Profit margin($)", "ProfitMarginPrice", Convert.ToString(this.ToDecimal(strArrays6[0].Trim())), Convert.ToString(num7), str2);
                                }
                            }
                        }
                        else
                        {
                            string str8 = this.hdnProfitMarginInPrice.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays7 = str8.Split(chrArray);
                            for (int m = 0; m < (int)strArrays7.Length - 1; m++)
                            {
                                if (Convert.ToDecimal(this.ToDecimal(strArrays7[m].Trim())) != num7)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Profit margin($)", "ProfitMarginPrice", Convert.ToString(this.ToDecimal(strArrays7[m].Trim())), Convert.ToString(num7), str2);
                                }
                            }
                        }
                    }
                    decimal num8 = Convert.ToDecimal(strArrays1[9]);
                    decimal num9 = Convert.ToDecimal(strArrays1[10]);
                    decimal num10 = Convert.ToDecimal(strArrays1[11]);
                    decimal num11 = Convert.ToDecimal(strArrays1[12]);
                    if (this.hdnSutotalold.Value != "")
                    {
                        if (num2 != (long)0)
                        {
                            string str9 = this.hdnSutotalold.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays8 = str9.Split(chrArray);
                            for (int n = 0; n < (int)strArrays8.Length - 1; n++)
                            {
                                string str10 = strArrays8[n];
                                chrArray = new char[] { '~' };
                                string[] strArrays9 = str10.Split(chrArray);
                                if (Convert.ToDecimal(this.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(strArrays9[0].Trim()), 2, "", false, false, true))) != num11 && Convert.ToInt64(strArrays9[1]) == num2)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "SubTotal", "SubTotal", Convert.ToString(this.ToDecimal(strArrays9[0].Trim())), Convert.ToString(num11), str2);
                                }
                            }
                        }
                        else
                        {
                            string str11 = this.hdnSutotalold.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays10 = str11.Split(chrArray);
                            for (int o = 0; o < (int)strArrays10.Length - 1; o++)
                            {
                                if (Convert.ToDecimal(this.ToDecimal(strArrays10[o].Trim())) != num11)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "SubTotal", "SubTotal", Convert.ToString(this.ToDecimal(strArrays10[o].Trim())), Convert.ToString(num11), str2);
                                }
                            }
                        }
                    }
                    decimal num12 = Convert.ToDecimal(strArrays1[13]);
                    decimal num13 = Convert.ToDecimal(strArrays1[14]);
                    decimal num14 = Convert.ToDecimal(strArrays1[15]);
                    int num15 = Convert.ToInt32(strArrays1[16]);
                    int num16 = Convert.ToInt32(strArrays1[17]);
                    int num17 = Convert.ToInt32(strArrays1[18]);
                    int num18 = Convert.ToInt32(strArrays1[19]);
                    decimal num19 = Convert.ToDecimal(strArrays1[20]);
                    decimal num20 = Convert.ToDecimal(strArrays1[21]);
                    decimal num21 = Convert.ToDecimal(strArrays1[22]);
                    decimal num22 = Convert.ToDecimal(strArrays1[23]);
                    decimal num23 = Convert.ToDecimal(strArrays1[24]);
                    if (this.hdnTaxPrice.Value != "")
                    {
                        if (num2 != (long)0)
                        {
                            string str12 = this.hdnTaxPrice.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays11 = str12.Split(chrArray);
                            for (int p = 0; p < (int)strArrays11.Length - 1; p++)
                            {
                                string str13 = strArrays11[p];
                                chrArray = new char[] { '~' };
                                string[] strArrays12 = str13.Split(chrArray);
                                if (Convert.ToDecimal(this.ToDecimal(strArrays12[0].Trim())) != num23 && Convert.ToInt64(strArrays12[1]) == num2)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Tax", "Tax", Convert.ToString(this.ToDecimal(strArrays12[0].Trim())), Convert.ToString(num23), str2);
                                }
                            }
                        }
                        else
                        {
                            string str14 = this.hdnTaxPrice.Value.ToString();
                            chrArray = new char[] { '\u005E' };
                            string[] strArrays13 = str14.Split(chrArray);
                            for (int q = 0; q < (int)strArrays13.Length - 1; q++)
                            {
                                if (Convert.ToDecimal(this.ToDecimal(strArrays13[q].Trim())) != num23)
                                {
                                    this.itemTitle_update_activity_history_insert(Convert.ToString(num), "Tax", "Tax", Convert.ToString(this.ToDecimal(strArrays13[q].Trim())), Convert.ToString(num23), str2);
                                }
                            }
                        }
                    }
                    decimal num24 = Convert.ToDecimal(strArrays1[25]);
                    decimal num25 = Convert.ToDecimal(strArrays1[26]);
                    decimal num26 = Convert.ToDecimal(strArrays1[27]);
                    decimal num27 = Convert.ToDecimal(strArrays1[28]);
                    decimal num28 = Convert.ToDecimal(strArrays1[29]);
                    decimal num29 = Convert.ToDecimal(strArrays1[30]);
                    decimal num30 = Convert.ToDecimal(strArrays1[31]);
                    decimal num31 = Convert.ToDecimal(strArrays1[32]);
                    decimal num32 = Convert.ToDecimal(strArrays1[33]);
                    decimal num33 = Convert.ToDecimal(strArrays1[34]);
                    decimal num34 = Convert.ToDecimal(strArrays1[35]);
                    decimal num35 = Convert.ToDecimal(strArrays1[36]);
                    decimal num36 = Convert.ToDecimal(strArrays1[37]);
                    decimal num37 = Convert.ToDecimal(strArrays1[38]);
                    decimal num38 = Convert.ToDecimal(strArrays1[39]);
                    bool flag = Convert.ToBoolean(strArrays1[40]);
                    decimal SQM1 = Convert.ToDecimal(strArrays1[41]);
                    decimal SQM2 = Convert.ToDecimal(strArrays1[42]);
                    decimal SQM3 = Convert.ToDecimal(strArrays1[43]);
                    decimal SQM4 = Convert.ToDecimal(strArrays1[44]);

                    decimal SubTotalUnitPrice1 = Convert.ToDecimal(strArrays1[45]);
                    decimal SubTotalUnitPrice2 = Convert.ToDecimal(strArrays1[46]);
                    decimal SubTotalUnitPrice3 = Convert.ToDecimal(strArrays1[47]);
                    decimal SubTotalUnitPrice4 = Convert.ToDecimal(strArrays1[48]);
                    itemSummary.SaveItemPriceDetails(num1, num, num2, str2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, num13, num14, num15, num16, num17, num18, num19, num20, num21, num22, num23, num24, num25, num26, num27, num28, num29, num30, num31, num32, num33, num34, num35, num36, num37, num38, flag, SQM1, SQM2, SQM3, SQM4, SubTotalUnitPrice1, SubTotalUnitPrice2, SubTotalUnitPrice3, SubTotalUnitPrice4);
                }
                else
                {
                    empty = strArrays[i].ToString();
                }
            }
            if (empty.Length > 0)
            {
                chrArray = new char[] { '~' };
                string[] strArrays14 = empty.Split(chrArray);
                item_summary itemSummary1 = new item_summary();
                num1 = Convert.ToInt64(strArrays14[0]);
                num = Convert.ToInt64(strArrays14[1]);
                string str15 = strArrays14[3].ToString();
                decimal num39 = Convert.ToDecimal(strArrays14[4]);
                decimal num40 = Convert.ToDecimal(strArrays14[5]);
                decimal num41 = Convert.ToDecimal(strArrays14[6]);
                decimal num42 = Convert.ToDecimal(strArrays14[7]);
                decimal num43 = Convert.ToDecimal(strArrays14[8]);
                decimal num44 = Convert.ToDecimal(strArrays14[9]);
                decimal num45 = Convert.ToDecimal(strArrays14[10]);
                decimal num46 = Convert.ToDecimal(strArrays14[11]);
                decimal num47 = Convert.ToDecimal(strArrays14[12]);
                decimal num48 = Convert.ToDecimal(strArrays14[13]);
                decimal num49 = Convert.ToDecimal(strArrays14[14]);
                decimal num50 = Convert.ToDecimal(strArrays14[15]);
                int num51 = Convert.ToInt32(strArrays14[16]);
                int num52 = Convert.ToInt32(strArrays14[17]);
                int num53 = Convert.ToInt32(strArrays14[18]);
                int num54 = Convert.ToInt32(strArrays14[19]);
                decimal num55 = Convert.ToDecimal(strArrays14[20]);
                decimal num56 = Convert.ToDecimal(strArrays14[21]);
                decimal num57 = Convert.ToDecimal(strArrays14[22]);
                decimal num58 = Convert.ToDecimal(strArrays14[23]);
                decimal num59 = Convert.ToDecimal(strArrays14[24]);
                decimal num60 = Convert.ToDecimal(strArrays14[25]);
                decimal num61 = Convert.ToDecimal(strArrays14[26]);
                decimal num62 = Convert.ToDecimal(strArrays14[27]);
                decimal num63 = Convert.ToDecimal(strArrays14[28]);
                decimal num64 = Convert.ToDecimal(strArrays14[29]);
                decimal num65 = Convert.ToDecimal(strArrays14[30]);
                decimal num66 = Convert.ToDecimal(strArrays14[31]);
                decimal num67 = Convert.ToDecimal(strArrays14[32]);
                decimal num68 = Convert.ToDecimal(strArrays14[33]);
                decimal num69 = Convert.ToDecimal(strArrays14[34]);
                decimal num70 = Convert.ToDecimal(strArrays14[35]);
                decimal num71 = Convert.ToDecimal(strArrays14[36]);
                decimal num72 = Convert.ToDecimal(strArrays14[37]);
                decimal num73 = Convert.ToDecimal(strArrays14[38]);
                decimal num74 = Convert.ToDecimal(strArrays14[39]);
                bool flag1 = Convert.ToBoolean(strArrays14[40]);
                decimal SQM1 = Convert.ToDecimal(strArrays14[41]);
                decimal SQM2 = Convert.ToDecimal(strArrays14[42]);
                decimal SQM3 = Convert.ToDecimal(strArrays14[43]);
                decimal SQM4 = Convert.ToDecimal(strArrays14[44]);

                decimal SubTotalUnitPrice1 = Convert.ToDecimal(strArrays14[45]);
                decimal SubTotalUnitPrice2 = Convert.ToDecimal(strArrays14[46]);
                decimal SubTotalUnitPrice3 = Convert.ToDecimal(strArrays14[47]);
                decimal SubTotalUnitPrice4 = Convert.ToDecimal(strArrays14[48]);
                itemSummary1.SaveItemPriceDetails(num1, num, (long)-999, str15, num39, num40, num41, num42, num43, num44, num45, num46, num47, num48, num49, num50, num51, num52, num53, num54, num55, num56, num57, num58, num59, num60, num61, num62, num63, num64, num65, num66, num67, num68, num69, num70, num71, num72, num73, num74, flag1, SQM1, SQM2, SQM3, SQM4, SubTotalUnitPrice1, SubTotalUnitPrice2, SubTotalUnitPrice3, SubTotalUnitPrice4);
            }
            if (!string.IsNullOrEmpty(this.hdn_Description.Value))
            {
                string str16 = this.hdn_Description.Value.ToString();
                chrArray = new char[] { '\u25AC' };
                string[] strArrays15 = str16.Split(chrArray);
                EstimateCommonMethods.EditUpdateIDescriptionsInSummary(Convert.ToInt32(strArrays15[0]), Convert.ToInt64(strArrays15[1]), Convert.ToInt64(strArrays15[2]), strArrays15[3].ToString(), strArrays15[4].ToString(), Convert.ToBoolean(strArrays15[5]), Convert.ToBoolean(strArrays15[6]), Convert.ToBoolean(strArrays15[7]), strArrays15[8].ToString(), strArrays15[9].ToString());
            }
            if (this.btnType.ToLower() == "save")
            {
                if (this.modulename == "jobs")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, this.modulename, "/jobs_view.aspx"));
                    return;
                }
                if (this.modulename.ToLower() == "order")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "Orders/", this.submodulename, "_view.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "Estimates/proofs.aspx"));
                    return;
                }
                HttpResponse response = base.Response;
                str = new string[] { this.strSitepath, this.modulename, "/", this.submodulename, "_view.aspx" };
                response.Redirect(string.Concat(str));
                return;
            }
            if (this.modulename.Contains("order"))
            {
                HttpResponse httpResponse = base.Response;
                invID = new object[] { this.strSitepath, "orders/order_summary.aspx?ordid=", num1, "&estid=", num1, "&EstItemID=", num, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(invID));
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
            {
                HttpResponse response1 = base.Response;
                invID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?ordid=", num1, "&estid=", num1, "&EstItemID=", num, this.jID, this.InvID };
                response1.Redirect(string.Concat(invID));
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
            {
                HttpResponse httpResponse1 = base.Response;
                invID = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?ordid=", num1, "&estid=", num1, "&EstItemID=", num, this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(invID));
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
            {
                HttpResponse httpResponse1 = base.Response;
                httpResponse1.Redirect(base.Request.Url.ToString());
                return;
            }
            HttpResponse response2 = base.Response;
            invID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", num1, "&EstItemID=", num, this.jID, this.InvID };
            response2.Redirect(string.Concat(invID));
        }

        private void itemTitle_update_activity_history_insert(string EstimateItemID, string ItemTitle, string UpadteTag, string Old_Value, string New_Value, string EstType)
        {
            string empty = string.Empty;
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            string str = string.Empty;
            if (this.Module == "estimate")
            {
                DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                foreach (DataRow row in dataTable.Rows)
                {
                    str = row["Estimatenumber"].ToString();
                }
                DataTable dataTable1 = Notes.select_item_number_for_Activity_History(this.EstimateID, Convert.ToInt64(EstimateItemID), this.Module);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    empty = dataRow["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty;
                this.objnotes.Item_title = ItemTitle;
                this.objnotes.Estimate_number = str;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.Old_Item_title = Old_Value;
                this.objnotes.New_Item_title = New_Value;
                try
                {
                    this.objnotes.Old_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_ProfitMargin = Convert.ToString(Convert.ToDecimal(New_Value));
                    }
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    this.objnotes.New_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_TaxRate = Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true)));
                    }
                }
                catch
                {
                }
                if (UpadteTag == "ItemTitle")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemTitleEdit);
                }
                else if (UpadteTag == "Tax")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTax);
                }
                else if (UpadteTag == "SubTotal")
                {
                    if (EstType == "U" || EstType == "W")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubTotalForOthers);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubTotal);
                    }
                }
                else if (UpadteTag == "ProfitMargin")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProMargin);
                }
                else if (UpadteTag == "ProfitMarginPrice")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProMarginPrice);
                }
            }
            else if (this.Module == "job")
            {
                DataTable dataTable2 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    str = row1["jobnumber"].ToString();
                }
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(this.jobID, Convert.ToInt64(EstimateItemID), this.Module);
                foreach (DataRow dataRow1 in dataTable3.Rows)
                {
                    empty = dataRow1["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty;
                this.objnotes.Item_title = ItemTitle;
                this.objnotes.ModuleName = "job";
                this.objnotes.Job_number = str;
                this.objnotes.Old_Item_title = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true);
                this.objnotes.New_Item_title = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true);
                try
                {
                    this.objnotes.Old_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))) != "0")
                    {
                        this.objnotes.New_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_ProfitMargin = Convert.ToString(Convert.ToDecimal(New_Value));
                    }
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    this.objnotes.New_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_TaxRate = Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true)));
                    }
                }
                catch
                {
                }
                if (UpadteTag == "ItemTitle")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemTitleEdit);
                }
                else if (UpadteTag == "Tax")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTax);
                }
                else if (UpadteTag == "SubTotal")
                {
                    if (EstType == "U" || EstType == "W")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubTotalForOthers);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubTotal);
                    }
                }
                else if (UpadteTag == "ProfitMargin")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProMargin);
                }
                else if (UpadteTag == "ProfitMarginPrice")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProMarginPrice);
                }
            }
            else if (this.Module == "invoice")
            {
                DataTable dataTable4 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                foreach (DataRow row2 in dataTable4.Rows)
                {
                    str = row2["invoicenumber"].ToString();
                }
                DataTable dataTable5 = Notes.select_item_number_for_Activity_History(this.InvoiceID, Convert.ToInt64(EstimateItemID), this.Module);
                foreach (DataRow dataRow2 in dataTable5.Rows)
                {
                    empty = dataRow2["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty;
                this.objnotes.Item_title = ItemTitle;
                this.objnotes.Invoice_number = str;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.Old_Item_title = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true);
                this.objnotes.New_Item_title = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true);
                try
                {
                    this.objnotes.Old_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_ProfitMargin = Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true)));
                    }
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    this.objnotes.New_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_TaxRate = Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true)));
                    }
                }
                catch
                {
                }
                if (UpadteTag == "ItemTitle")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemTitleEdit);
                }
                else if (UpadteTag == "Tax")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTax);
                }
                else if (UpadteTag == "SubTotal")
                {
                    if (EstType == "U" || EstType == "W")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvSubTotalForOthers);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvSubTotal);
                    }
                }
                else if (UpadteTag == "ProfitMargin")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvProMargin);
                }
                else if (UpadteTag == "ProfitMarginPrice")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvProMarginPrice);
                }
            }
            else if (this.Module == "order")
            {
                DataTable dataTable6 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                foreach (DataRow row3 in dataTable6.Rows)
                {
                    str = row3["Estimatenumber"].ToString();
                }
                DataTable dataTable7 = Notes.select_item_number_for_Activity_History(this.EstimateID, Convert.ToInt64(EstimateItemID), this.Module);
                foreach (DataRow dataRow3 in dataTable7.Rows)
                {
                    empty = dataRow3["rownumber"].ToString();
                }
                this.objnotes.Item_number = empty;
                this.objnotes.Item_title = ItemTitle;
                this.objnotes.Estimate_number = str;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.Old_Item_title = Old_Value;
                this.objnotes.New_Item_title = New_Value;
                try
                {
                    this.objnotes.Old_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_ProfitMargin = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_ProfitMargin = Convert.ToString(Convert.ToDecimal(New_Value));
                    }
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    this.objnotes.New_Subtotal = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                }
                catch
                {
                }
                try
                {
                    this.objnotes.Old_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Old_Value), 2, "", false, false, true))));
                    if (Convert.ToString(Convert.ToDecimal(New_Value)) != "0")
                    {
                        this.objnotes.New_TaxRate = this.commclass.ToRemoveDecimalPlacesIfZero(Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true))));
                    }
                    else
                    {
                        this.objnotes.New_TaxRate = Convert.ToString(Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(New_Value), 2, "", false, false, true)));
                    }
                }
                catch
                {
                }
                if (UpadteTag == "ItemTitle")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderItemTitleEdit);
                }
                else if (UpadteTag == "Tax")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTax);
                }
                else if (UpadteTag == "SubTotal")
                {
                    if (EstType == "U" || EstType == "W")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderSubTotalForOthers);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderSubTotal);
                    }
                }
                else if (UpadteTag == "ProfitMargin")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderProMargin);
                }
                else if (UpadteTag == "ProfitMarginPrice")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderProMarginPrice);
                }
            }
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = Convert.ToInt64(EstimateItemID);
            this.objN.NotesAdd(this.objnotes);
        }

        private string Load_Tax_Values(int TaxID, int CompanyID, decimal Taxrate)
        {
            string empty = string.Empty;
            foreach (DataRow row in EstimateBasePage.estimate_summary_tax_bind_2(CompanyID).Rows)
            {
                empty = (string.Concat(row["TaxID"].ToString(), "~", row["TaxRate"].ToString()) == string.Concat(TaxID.ToString(), "~", Taxrate) ? "selected='selected'" : "");
                ControlCollection controls = this.plhItemTotal.Controls;
                string[] str = new string[] { "<option value='", row["TaxID"].ToString(), "~", row["TaxRate"].ToString(), "' ", empty, ">", this.objBase.SpecialDecode(row["TaxName"].ToString()), "</option>" };
                controls.Add(new LiteralControl(string.Concat(str)));
            }
            return this.plhItemTotal.ToString();
        }

        protected void OnClick_btnCancel(object sender, EventArgs e)
        {
            if (this.modulename.ToLower() == "order")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "Orders/", this.submodulename, "_view.aspx"));
                return;
            }
            HttpResponse response = base.Response;
            string[] strArrays = new string[] { this.strSitepath, this.modulename, "/", this.submodulename, "_view.aspx" };
            response.Redirect(string.Concat(strArrays));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] estimateItemID;
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (!base.IsPostBack)
            {
                this.btnStay.Text = this.objLanguage.GetLanguageConversion("Save_Stay");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            }
            if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
            {
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.btnSave.Visible = true;
                    this.btnStay.Visible = true;
                }
                else
                {
                    this.btnSave.Visible = false;
                    this.btnStay.Visible = false;
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
            {
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.btnSave.Visible = true;
                    this.btnStay.Visible = true;
                }
                else
                {
                    this.btnSave.Visible = false;
                    this.btnStay.Visible = false;
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
            {
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.btnSave.Visible = true;
                    this.btnStay.Visible = true;
                }
                else
                {
                    this.btnSave.Visible = false;
                    this.btnStay.Visible = false;
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("orders/"))
            {
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.btnSave.Visible = true;
                    this.btnStay.Visible = true;
                }
                else
                {
                    this.btnSave.Visible = false;
                    this.btnStay.Visible = false;
                }
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
            if (this.QtyCount == 0)
            {
                this.QtyCount = 1;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            if (base.Request.Params["acthist"] != null)
            {
                this.IsFromActHist = base.Request.Params["acthist"].ToString();
            }
            string str = "visibility: visible;";
            string empty1 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
            {
                if (row["IsTotalHighlighted"].ToString().ToLower() != "true")
                {
                    continue;
                }
                empty1 = "color:red";
            }
            if (this.Check_SpecialPrivilege)
            {
                str = "display:none;";
            }
            if (!base.IsPostBack && this.IsFromActHist.ToLower() == "yes")
            {
                this.btnSave.Visible = false;
                this.btnStay.Visible = false;
            }
            bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
            this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
            if (ConnectionClass.AccountingCode != "" && ConnectionClass.AccountingCode != "n")
            {
                this.IsAccountingCode = true;
            }
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            this.plhItemTotal.Controls.Clear();
            int num = 0;
            DataTable dataTable = EstimatesBasePage.estimate_item_total_price_details_select(this.CompanyID, this.EstimateItemID, this.EstType);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                long num1 = Convert.ToInt64(dataRow["SectionID"]);
                string str1 = "display:none";
                string str2 = "display:none";
                string str3 = "display:none";
                string str4 = "display:none";
                item_summary_total.SalesPersonID = dataRow["SalesPersonID"].ToString();
                if (this.EstType == "B" || this.EstType == "K" || this.EstType == "N" || this.EstType == "R")
                {
                    this.QtyCount = Convert.ToInt32(dataRow["QtyCount"]);
                    this.SectionCount = Convert.ToInt32(dataRow["SectionCount"]);
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
                else if (this.EstType == "O")
                {
                    foreach (DataRow row1 in EstimatesBasePage.summary_outwork_select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        if (Convert.ToInt32(row1["QuantityNumber"]) == 1)
                        {
                            this.tblWidth = "42%";
                            this.tblWidth_MinWidth = "min-width:320px;";
                            this.QtyCount = Convert.ToInt32(row1["Quantity"]);
                            this.IsShowOW1 = Convert.ToBoolean(row1["IsSelected"]);
                            if (!this.IsShowOW1)
                            {
                                if (row1["SupplierSelected"].ToString().ToLower() != "no")
                                {
                                    continue;
                                }
                                str1 = "visibility:visible;";
                            }
                            else
                            {
                                str1 = "visibility:visible;";
                            }
                        }
                        else if (Convert.ToInt32(row1["QuantityNumber"]) == 2)
                        {
                            this.tblWidth = "62%";
                            this.tblWidth_MinWidth = "min-width:445px;";
                            this.QtyCount = Convert.ToInt32(row1["Quantity"]);
                            this.IsShowOW2 = Convert.ToBoolean(row1["IsSelected"]);
                            if (!this.IsShowOW2)
                            {
                                if (row1["SupplierSelected"].ToString().ToLower() != "no")
                                {
                                    continue;
                                }
                                str2 = "visibility:visible;";
                            }
                            else
                            {
                                str2 = "visibility:visible;";
                            }
                        }
                        else if (Convert.ToInt32(row1["QuantityNumber"]) != 3)
                        {
                            if (Convert.ToInt32(row1["QuantityNumber"]) != 4)
                            {
                                continue;
                            }
                            this.tblWidth = "100%";
                            this.tblWidth_MinWidth = "min-width:550px;";
                            this.QtyCount = Convert.ToInt32(row1["Quantity"]);
                            this.IsShowOW4 = Convert.ToBoolean(row1["IsSelected"]);
                            if (!this.IsShowOW4)
                            {
                                if (row1["SupplierSelected"].ToString().ToLower() != "no")
                                {
                                    continue;
                                }
                                str4 = "visibility:visible;";
                            }
                            else
                            {
                                str4 = "visibility:visible;";
                            }
                        }
                        else
                        {
                            this.tblWidth = "82%";
                            this.tblWidth_MinWidth = "min-width:520px;";
                            this.QtyCount = Convert.ToInt32(row1["Quantity"]);
                            this.IsShowOW3 = Convert.ToBoolean(row1["IsSelected"]);
                            if (!this.IsShowOW3)
                            {
                                if (row1["SupplierSelected"].ToString().ToLower() != "no")
                                {
                                    continue;
                                }
                                str3 = "visibility:visible;";
                            }
                            else
                            {
                                str3 = "visibility:visible;";
                            }
                        }
                    }
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
                EstimatesItem estimatesItem = new EstimatesItem()
                {
                    CostPriceExMarkup1 = Convert.ToDecimal(dataRow["TotalCostExMarkup1"]),
                    CostPriceExMarkup2 = Convert.ToDecimal(dataRow["TotalCostExMarkup2"]),
                    CostPriceExMarkup3 = Convert.ToDecimal(dataRow["TotalCostExMarkup3"]),
                    CostPriceExMarkup4 = Convert.ToDecimal(dataRow["TotalCostExMarkup4"]),
                    MarkupPrice1 = Convert.ToDecimal(dataRow["TotalMarkupPrice1"]),
                    MarkupPrice2 = Convert.ToDecimal(dataRow["TotalMarkupPrice2"]),
                    MarkupPrice3 = Convert.ToDecimal(dataRow["TotalMarkupPrice3"]),
                    MarkupPrice4 = Convert.ToDecimal(dataRow["TotalMarkupPrice4"]),
                    CostPriceInMarkup1 = Convert.ToDecimal(dataRow["TotalCostInMarkup1"]),
                    CostPriceInMarkup2 = Convert.ToDecimal(dataRow["TotalCostInMarkup2"]),
                    CostPriceInMarkup3 = Convert.ToDecimal(dataRow["TotalCostInMarkup3"]),
                    CostPriceInMarkup4 = Convert.ToDecimal(dataRow["TotalCostInMarkup4"]),
                    ProfitMargin1 = Convert.ToDecimal(dataRow["TotalProfitMarginPercentage1"]),
                    ProfitMargin2 = Convert.ToDecimal(dataRow["TotalProfitMarginPercentage2"]),
                    ProfitMargin3 = Convert.ToDecimal(dataRow["TotalProfitMarginPercentage3"]),
                    ProfitMargin4 = Convert.ToDecimal(dataRow["TotalProfitMarginPercentage4"]),
                    ProfitMarginPrice1 = Convert.ToDecimal(dataRow["TotalProfitMarginPrice1"]),
                    ProfitMarginPrice2 = Convert.ToDecimal(dataRow["TotalProfitMarginPrice2"]),
                    ProfitMarginPrice3 = Convert.ToDecimal(dataRow["TotalProfitMarginPrice3"]),
                    ProfitMarginPrice4 = Convert.ToDecimal(dataRow["TotalProfitMarginPrice4"]),
                    SubTotal1 = Convert.ToDecimal(dataRow["TotalSubTotal1"]),
                    SubTotal2 = Convert.ToDecimal(dataRow["TotalSubTotal2"]),
                    SubTotal3 = Convert.ToDecimal(dataRow["TotalSubTotal3"]),
                    SubTotal4 = Convert.ToDecimal(dataRow["TotalSubTotal4"]),
                    PricePerUnitOfMeasure1 = dataRow["TotalPricePerUnit1"].ToString(),
                    PricePerUnitOfMeasure2 = dataRow["TotalPricePerUnit2"].ToString(),
                    PricePerUnitOfMeasure3 = dataRow["TotalPricePerUnit3"].ToString(),
                    PricePerUnitOfMeasure4 = dataRow["TotalPricePerUnit4"].ToString(),
                    TaxID = Convert.ToInt32(dataRow["TotalTaxID1"]),
                    TaxRate1 = Convert.ToDecimal(dataRow["TotalTaxPercentage1"]),
                    TaxRate2 = Convert.ToDecimal(dataRow["TotalTaxPercentage2"]),
                    TaxRate3 = Convert.ToDecimal(dataRow["TotalTaxPercentage3"]),
                    TaxRate4 = Convert.ToDecimal(dataRow["TotalTaxPercentage4"]),
                    TaxPrice1 = Convert.ToDecimal(dataRow["TotalTaxPrice1"]),
                    TaxPrice2 = Convert.ToDecimal(dataRow["TotalTaxPrice2"]),
                    TaxPrice3 = Convert.ToDecimal(dataRow["TotalTaxPrice3"]),
                    TaxPrice4 = Convert.ToDecimal(dataRow["TotalTaxPrice4"]),
                    SellingPrice1 = Convert.ToDecimal(dataRow["TotalSellingPrice1"]),
                    SellingPrice2 = Convert.ToDecimal(dataRow["TotalSellingPrice2"]),
                    SellingPrice3 = Convert.ToDecimal(dataRow["TotalSellingPrice3"]),
                    SellingPrice4 = Convert.ToDecimal(dataRow["TotalSellingPrice4"]),
                    GrossProfitPercentage1 = Convert.ToDecimal(dataRow["TotalGrossProfitPercentage1"]),
                    GrossProfitPercentage2 = Convert.ToDecimal(dataRow["TotalGrossProfitPercentage2"]),
                    GrossProfitPercentage3 = Convert.ToDecimal(dataRow["TotalGrossProfitPercentage3"]),
                    GrossProfitPercentage4 = Convert.ToDecimal(dataRow["TotalGrossProfitPercentage4"]),
                    GrossProfitPrice1 = Convert.ToDecimal(dataRow["TotalGrossProfitPrice1"]),
                    GrossProfitPrice2 = Convert.ToDecimal(dataRow["TotalGrossProfitPrice2"]),
                    GrossProfitPrice3 = Convert.ToDecimal(dataRow["TotalGrossProfitPrice3"]),
                    GrossProfitPrice4 = Convert.ToDecimal(dataRow["TotalGrossProfitPrice4"])
                };
                ControlCollection controls = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_EstimateID_", this.EstimateItemID, "' value='", this.EstimateID, "' />" };
                controls.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections = this.plhItemTotal.Controls;
                object[] objArray = new object[] { "<input type='hidden' id='hdn_SectionID_", this.EstimateItemID, "_", num, "' value='", num1.ToString(), "' />" };
                controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                ControlCollection controls1 = this.plhItemTotal.Controls;
                object[] estimateItemID1 = new object[] { "<input type='hidden' id='hdn_IsSubTotalLocked_", this.EstimateItemID, "_", num, "' value='", dataRow["IsSubTotalLocked"].ToString(), "' />" };
                controls1.Add(new LiteralControl(string.Concat(estimateItemID1)));
                string str5 = "";
                if (this.EstType != "B" && this.EstType != "K" && this.EstType != "N" && this.EstType != "R" && this.EstType != "DN")
                {
                    ControlCollection controlCollections1 = this.plhItemTotal.Controls;
                    object[] objArray1 = new object[] { "<div align='left' id='divTotal_", this.EstimateItemID, "_", num, "' style='clear:both; width:100%; display: block; border:0px solid red;'>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                }
                else if (num1 != (long)-999)
                {
                    ControlCollection controls2 = this.plhItemTotal.Controls;
                    object[] estimateItemID2 = new object[] { "<div align='left' id='divTotal_", this.EstimateItemID, "_", num, "' style='width:100%;display: none';border:0px solid red;>" };
                    controls2.Add(new LiteralControl(string.Concat(estimateItemID2)));
                }
                else
                {
                    str5 = "disabled=disabled";
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div align='left' id='divTotal_", this.EstimateItemID, "_All' style='width:100%;display: block; border:0px solid red;'>")));
                }
                if (this.IsFromActHist.ToLower() == "yes")
                {
                    str5 = "disabled=disabled";
                }
                ControlCollection controlCollections2 = this.plhItemTotal.Controls;
                string[] tblWidthMinWidth = new string[] { "<table id='tblTotal' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='border:0px solid red;", this.tblWidth_MinWidth, "''>" };
                controlCollections2.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                string empty2 = string.Empty;
                if (this.objBase.ReturnRoles_Privileges_Others("showcostexmarkup").ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trCostExMarkup' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='tdspn' style='width: 16%;'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", this.objLanguage.GetLanguageConversion("Cost_Price_Ex_Markup"), "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;border:solid 0px red; ", str1, "'>")));
                ControlCollection controls3 = this.plhItemTotal.Controls;
                object[] objArray2 = new object[] { "<span id='spnCostExMarkup1_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup1, 0, "", false, false, true), true), "</span>" };
                controls3.Add(new LiteralControl(string.Concat(objArray2)));
                ControlCollection controlCollections3 = this.plhItemTotal.Controls;
                object[] estimateItemID3 = new object[] { "<input type='hidden' id='hdn_CostExMarkup1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceExMarkup1, "' />" };
                controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID3)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty2' style='text-align: right; width: 21%; ", str2, "'>")));
                ControlCollection controls4 = this.plhItemTotal.Controls;
                object[] objArray3 = new object[] { "<span id='spnCostExMarkup2_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup2, 0, "", false, false, true), true), "</span>" };
                controls4.Add(new LiteralControl(string.Concat(objArray3)));
                ControlCollection controlCollections4 = this.plhItemTotal.Controls;
                object[] estimateItemID4 = new object[] { "<input type='hidden' id='hdn_CostExMarkup2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceExMarkup2, "' />" };
                controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty3' style='text-align: right; width: 21%; ", str3, "'>")));
                ControlCollection controls5 = this.plhItemTotal.Controls;
                object[] objArray4 = new object[] { "<span id='spnCostExMarkup3_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup3, 0, "", false, false, true), true), "</span>" };
                controls5.Add(new LiteralControl(string.Concat(objArray4)));
                ControlCollection controlCollections5 = this.plhItemTotal.Controls;
                object[] estimateItemID5 = new object[] { "<input type='hidden' id='hdn_CostExMarkup3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceExMarkup3, "' />" };
                controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty4' style='text-align: right; width: 21%; ", str4, "'>")));
                ControlCollection controls6 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnCostExMarkup4_", this.EstimateItemID, "_", num, "' class='normalText' >", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceExMarkup4, 0, "", false, false, true), true), "</span>" };
                controls6.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections6 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_CostExMarkup4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceExMarkup4, "' />" };
                controlCollections6.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trMarkupPrice' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td1' style='width: 16%'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", this.objLanguage.GetLanguageConversion("Markup"), "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td2' style='text-align: right; width: 21%; ", str1, "'>")));
                ControlCollection controls7 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnMarkupPrice1_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MarkupPrice1, 0, "", false, false, true), true), "</span>" };
                controls7.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections7 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_MarkupPrice1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.MarkupPrice1, "' />" };
                controlCollections7.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td3' style='text-align: right; width: 21%; ", str2, "'>")));
                ControlCollection controls8 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnMarkupPrice2_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MarkupPrice2, 0, "", false, false, true), true), "</span>" };
                controls8.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections8 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_MarkupPrice2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.MarkupPrice2, "' />" };
                controlCollections8.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td4' style='text-align: right; width: 21%; ", str3, "'>")));
                ControlCollection controls9 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { " <span id='spnMarkupPrice3_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MarkupPrice3, 0, "", false, false, true), true), "</span>" };
                controls9.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections9 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_MarkupPrice3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.MarkupPrice3, "' />" };
                controlCollections9.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td5' style='text-align: right; width: 21%; ", str4, "'>")));
                ControlCollection controls10 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnMarkupPrice4_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.MarkupPrice4, 0, "", false, false, true), true), "</span>" };
                controls10.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections10 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_MarkupPrice4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.MarkupPrice4, "' />" };
                controlCollections10.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                string empty3 = string.Empty;
                if (this.objBase.ReturnRoles_Privileges_Others("showcostincmarkup").ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trCostInMarkup' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td6' style='width: 16%'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", this.objLanguage.GetLanguageConversion("Cost_Price_Inc_Markup"), "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td7' style='text-align: right; width: 21%; ", str1, "'>")));
                ControlCollection controls11 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnCostInMarkup1_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup1, 0, "", false, false, true), true), "</span>" };
                controls11.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections11 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_CostInMarkup1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceInMarkup1, "' />" };
                controlCollections11.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td8' style='text-align: right; width: 21%; ", str2, "'>")));
                ControlCollection controls12 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnCostInMarkup2_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup2, 0, "", false, false, true), true), "</span>" };
                controls12.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections12 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_CostInMarkup2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceInMarkup2, "' />" };
                controlCollections12.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td9' style='text-align: right; width: 21%; ", str3, "'>")));
                ControlCollection controls13 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnCostInMarkup3_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup3, 0, "", false, false, true), true), "</span>" };
                controls13.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections13 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_CostInMarkup3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceInMarkup3, "' />" };
                controlCollections13.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td10' style='text-align: right; width: 21%; ", str4, "'>")));
                ControlCollection controls14 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnCostInMarkup4_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.CostPriceInMarkup4, 0, "", false, false, true), true), "</span>" };
                controls14.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections14 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_CostInMarkup4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.CostPriceInMarkup4, "' />" };
                controlCollections14.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                string empty4 = string.Empty;
                if (this.objBase.ReturnRoles_Privileges_Others("showprofitmargin").ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                string str6 = "display:none;";
                if (num1 > (long)-10)
                {
                    str6 = "visibility: visible;";
                }
                if (str == "display:none;")
                {
                    str6 = "display:none;";
                }
                string empty5 = string.Empty;
                empty5 = (this.EstType.ToLower() != "x" ? str6 : "display:none;");
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trProfitPercentage' style='", empty5, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td11' style='width: 16%'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", this.objLanguage.GetLanguageConversion("Markup"), " (%) </div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td12' align='right' style='width: 21%; ", str1, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,1,'percent',", this.EstimateItemID, ",", num, ");" };
                string str7 = string.Concat(estimateItemID);
                ControlCollection controls15 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPercentage1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str7, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMargin1, 0, "", false, false, false), "' />" };
                controls15.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections15 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPercentage1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMargin1, "' />" };
                controlCollections15.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td13' align='right' style='width: 21%; ", str2, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,2,'percent',", this.EstimateItemID, ",", num, ");" };
                string str8 = string.Concat(estimateItemID);
                ControlCollection controls16 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPercentage2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str8, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMargin2, 0, "", false, false, false), "' />" };
                controls16.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections16 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPercentage2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMargin2, "' />" };
                controlCollections16.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td14' align='right' style='width: 21%; ", str3, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,3,'percent',", this.EstimateItemID, ",", num, ");" };
                string str9 = string.Concat(estimateItemID);
                ControlCollection controls17 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, "  id='txtProfitMarginPercentage3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str9, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMargin3, 0, "", false, false, false), "' />" };
                controls17.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections17 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPercentage3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMargin3, "' />" };
                controlCollections17.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td15' align='right' style='width: 21%; ", str4, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,4,'percent',", this.EstimateItemID, ",", num, ");" };
                string str10 = string.Concat(estimateItemID);
                ControlCollection controls18 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, "  id='txtProfitMarginPercentage4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str10, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMargin4, 0, "", false, false, false), "' />" };
                controls18.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections18 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPercentage4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMargin4, "' />" };
                controlCollections18.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                string empty6 = string.Empty;
                if (this.objBase.ReturnRoles_Privileges_Others("showprofitincurrency").ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                string empty7 = string.Empty;
                empty7 = (this.EstType.ToLower() != "x" ? str : "display:none;");
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trProfitPrice' style='", empty7, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td16' style='width: 16%'>"));
                ControlCollection controls19 = this.plhItemTotal.Controls;
                tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", this.objLanguage.GetLanguageConversion("Markup"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                controls19.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td17' align='right' style='width: 21%; ", str1, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,1,'price',", this.EstimateItemID, ",", num, ");" };
                string str11 = string.Concat(estimateItemID);
                ControlCollection controlCollections19 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPrice1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str11, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMarginPrice1, 0, "", false, false, false), "' />" };
                controlCollections19.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls20 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPrice1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMarginPrice1, "' />" };
                controls20.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td18' align='right' style='width: 21%; ", str2, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,2,'price',", this.EstimateItemID, ",", num, ");" };
                string str12 = string.Concat(estimateItemID);
                ControlCollection controlCollections20 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPrice2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str12, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMarginPrice2, 0, "", false, false, false), "' />" };
                controlCollections20.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls21 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPrice2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMarginPrice2, "' />" };
                controls21.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td19' align='right' style='width: 21%; ", str3, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,3,'price',", this.EstimateItemID, ",", num, ");" };
                string str13 = string.Concat(estimateItemID);
                ControlCollection controlCollections21 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPrice3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str13, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMarginPrice3, 0, "", false, false, false), "' />" };
                controlCollections21.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls22 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPrice3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMarginPrice3, "' />" };
                controls22.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td20' align='right' style='width: 21%; ", str4, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);ProfitMargin_OnBlur(this.value,4,'price',", this.EstimateItemID, ",", num, ");" };
                string str14 = string.Concat(estimateItemID);
                ControlCollection controlCollections22 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtProfitMarginPrice4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str14, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.ProfitMarginPrice4, 0, "", false, false, false), "' />" };
                controlCollections22.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls23 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_ProfitMarginPrice4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.ProfitMarginPrice4, "' />" };
                controls23.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));



                ////--------------------- start
                string lable_sqm = "Selling Price per SQM";
                if (this.EstType.ToUpper() == "L")
                {
                    decimal InvSheets1 = 0m;
                    decimal InvSheets2 = 0m;
                    decimal InvSheets3 = 0m;
                    decimal InvSheets4 = 0m;
                    string CalcType = "square";
                    decimal sqm_value_ = 0m;
                    string regionalSettings = (new BasePage()).GetRegionalSettings(CompanyID, "PaperMeasure");
                    foreach (DataRow row in EstimatesBasePage.estimate_large_item_select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        InvSheets1 = BaseClass.CheckDecimalNull(row["InvSheets1"]);
                        InvSheets2 = BaseClass.CheckDecimalNull(row["InvSheets2"]);
                        InvSheets3 = BaseClass.CheckDecimalNull(row["InvSheets3"]);
                        InvSheets4 = BaseClass.CheckDecimalNull(row["InvSheets4"]);
                        CalcType = Convert.ToString(row["CalcType"]);
                        if (regionalSettings != "In.")
                        {
                            sqm_value_ = ((Convert.ToDecimal(row["JobHeight"]) / new decimal(1000)) * (Convert.ToDecimal(row["JobWidth"]) / new decimal(1000)));
                        }
                        else
                        {
                            sqm_value_ = ((Convert.ToDecimal(row["JobHeight"]) / new decimal(12)) * (Convert.ToDecimal(row["JobWidth"]) / new decimal(12)));
                            lable_sqm = "Selling Price per SQFT";
                        }
                        //this.hdn_JobHeight.Value = row["JobHeight"].ToString();
                        //this.hdn_JobWidth.Value = row["JobWidth"].ToString();
                    }
                    if (CalcType.ToLower() == "square")
                    {



                        decimal SellingPricePerSQM1 = 0m;
                        decimal SellingPricePerSQM2 = 0m;
                        decimal SellingPricePerSQM3 = 0m;
                        decimal SellingPricePerSQM4 = 0m;


                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM1"].ToString()))
                        {
                            SellingPricePerSQM1 = Convert.ToDecimal(dataRow["SellingPricePerSQM1"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty1"]) > 0 && InvSheets1 > 0)
                        {
                            //SellingPricePerSQM1 = (estimatesItem.CostPriceInMarkup1 * (1 + estimatesItem.ProfitMargin1)) / (Convert.ToDecimal(dataRow["TotalQty1"]) * InvSheets1);
                            SellingPricePerSQM1 = (estimatesItem.CostPriceInMarkup1 + estimatesItem.ProfitMarginPrice1) / (Convert.ToDecimal(dataRow["TotalQty1"])) / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM2"].ToString()))
                        {
                            SellingPricePerSQM2 = Convert.ToDecimal(dataRow["SellingPricePerSQM2"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty2"]) > 0 && InvSheets2 > 0)
                        {
                            //SellingPricePerSQM2 = (estimatesItem.CostPriceInMarkup2 * (1 + estimatesItem.ProfitMargin2)) / (Convert.ToDecimal(dataRow["TotalQty2"]) * InvSheets2);
                            SellingPricePerSQM2 = (estimatesItem.CostPriceInMarkup2 + estimatesItem.ProfitMarginPrice2) / (Convert.ToDecimal(dataRow["TotalQty2"])) / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM3"].ToString()))
                        {
                            SellingPricePerSQM3 = Convert.ToDecimal(dataRow["SellingPricePerSQM3"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty3"]) > 0 && InvSheets3 > 0)
                        {
                            //SellingPricePerSQM3 = (estimatesItem.CostPriceInMarkup3 * (1 + estimatesItem.ProfitMargin3)) / (Convert.ToDecimal(dataRow["TotalQty3"]) * InvSheets3);
                            SellingPricePerSQM3 = (estimatesItem.CostPriceInMarkup3 + estimatesItem.ProfitMarginPrice3) / (Convert.ToDecimal(dataRow["TotalQty3"])) / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM4"].ToString()))
                        {
                            SellingPricePerSQM4 = Convert.ToDecimal(dataRow["SellingPricePerSQM4"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty4"]) > 0 && InvSheets4 > 0)
                        {
                            //SellingPricePerSQM4 = (estimatesItem.CostPriceInMarkup4 * (1 + estimatesItem.ProfitMargin4)) / (Convert.ToDecimal(dataRow["TotalQty4"]) * InvSheets4);
                            SellingPricePerSQM4 = (estimatesItem.CostPriceInMarkup4 + estimatesItem.ProfitMarginPrice4) / (Convert.ToDecimal(dataRow["TotalQty4"])) / sqm_value_;
                        }

                        string empty7_new = string.Empty;
                        empty7_new = (this.EstType.ToLower() != "x" ? str : "display:none;");
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trSellingPricePerSQM' style='", empty7_new, "'>")));
                        this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td16_new' style='width: 16%'>"));
                        ControlCollection controls19_new = this.plhItemTotal.Controls;
                        tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", lable_sqm, "</div>" };
                        controls19_new.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td17_new' align='right' style='width: 21%; ", str1, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlur(this.value,1,'price',", this.EstimateItemID, ",", num, ");" };
                        string str11_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections19_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str11_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM1, 0, "", false, false, false), "' />" };
                        controlCollections19_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls20_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM1_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM1, "' />" };
                        controls20_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td18_new' align='right' style='width: 21%; ", str2, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlur(this.value,2,'price',", this.EstimateItemID, ",", num, ");" };
                        string str12_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections20_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str12_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM2, 0, "", false, false, false), "' />" };
                        controlCollections20_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls21_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM2_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM2, "' />" };
                        controls21_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td19_new' align='right' style='width: 21%; ", str3, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlur(this.value,3,'price',", this.EstimateItemID, ",", num, ");" };
                        string str13_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections21_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str13_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM3, 0, "", false, false, false), "' />" };
                        controlCollections21_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls22_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM3_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM3, "' />" };
                        controls22_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td20_new' align='right' style='width: 21%; ", str4, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlur(this.value,4,'price',", this.EstimateItemID, ",", num, ");" };
                        string str14_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections22_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str14_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM4, 0, "", false, false, false), "' />" };
                        controlCollections22_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls23_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM4_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM4, "' />" };
                        controls23_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

                    }
                }
                else if (this.EstType.ToUpper() == "C")
                {
                    decimal InvSheets1 = 0m;
                    decimal InvSheets2 = 0m;
                    decimal InvSheets3 = 0m;
                    decimal InvSheets4 = 0m;
                    string CalcType = "square";
                    string matrixtype = "";
                    decimal sqm_value_ = 0m;
                    string regionalSettings = (new BasePage()).GetRegionalSettings(CompanyID, "PaperMeasure");

                    foreach (DataRow row in EstimatesBasePage.estimate_price_catalogue_item_select(this.CompanyID, this.EstimateItemID).Rows)
                    {

                        if (regionalSettings != "In.")
                        {
                            sqm_value_ = ((Convert.ToDecimal(row["Height"]) / new decimal(1000)) * (Convert.ToDecimal(row["Width"]) / new decimal(1000)));
                        }
                        else
                        {
                            sqm_value_ = ((Convert.ToDecimal(row["Height"]) / new decimal(12)) * (Convert.ToDecimal(row["Width"]) / new decimal(12)));
                            lable_sqm = "Selling Price per SQFT";
                        }
                        sqm_value_ = Math.Round(sqm_value_, 2);
                        matrixtype = row["MatrixType"].ToString();
                        //this.hdn_JobHeight.Value = row["JobHeight"].ToString();
                        //this.hdn_JobWidth.Value = row["JobWidth"].ToString();
                    }
                    if (CalcType.ToLower() == "square" && matrixtype.ToLower() == "g")
                    {



                        decimal SellingPricePerSQM1 = 0m;
                        decimal SellingPricePerSQM2 = 0m;
                        decimal SellingPricePerSQM3 = 0m;
                        decimal SellingPricePerSQM4 = 0m;


                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM1"].ToString()))
                        {
                            SellingPricePerSQM1 = Convert.ToDecimal(dataRow["SellingPricePerSQM1"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty1"]) > 0 && sqm_value_ > 0)
                        {
                            //SellingPricePerSQM1 = (estimatesItem.CostPriceInMarkup1 * (1 + estimatesItem.ProfitMargin1)) / (Convert.ToDecimal(dataRow["TotalQty1"]) * InvSheets1);
                            SellingPricePerSQM1 = (estimatesItem.CostPriceInMarkup1 + estimatesItem.ProfitMarginPrice1) / (Convert.ToDecimal(dataRow["TotalQty1"]));
                            SellingPricePerSQM1 = SellingPricePerSQM1 / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM2"].ToString()))
                        {
                            SellingPricePerSQM2 = Convert.ToDecimal(dataRow["SellingPricePerSQM2"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty2"]) > 0 && sqm_value_ > 0)
                        {
                            //SellingPricePerSQM2 = (estimatesItem.CostPriceInMarkup2 * (1 + estimatesItem.ProfitMargin2)) / (Convert.ToDecimal(dataRow["TotalQty2"]) * InvSheets2);
                            SellingPricePerSQM2 = (estimatesItem.CostPriceInMarkup2 + estimatesItem.ProfitMarginPrice2) / (Convert.ToDecimal(dataRow["TotalQty2"])) / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM3"].ToString()))
                        {
                            SellingPricePerSQM3 = Convert.ToDecimal(dataRow["SellingPricePerSQM3"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty3"]) > 0 && sqm_value_ > 0)
                        {
                            //SellingPricePerSQM3 = (estimatesItem.CostPriceInMarkup3 * (1 + estimatesItem.ProfitMargin3)) / (Convert.ToDecimal(dataRow["TotalQty3"]) * InvSheets3);
                            SellingPricePerSQM3 = (estimatesItem.CostPriceInMarkup3 + estimatesItem.ProfitMarginPrice3) / (Convert.ToDecimal(dataRow["TotalQty3"])) / sqm_value_;
                        }

                        if (!String.IsNullOrEmpty(dataRow["SellingPricePerSQM4"].ToString()))
                        {
                            SellingPricePerSQM4 = Convert.ToDecimal(dataRow["SellingPricePerSQM4"]);
                        }
                        else if (Convert.ToDecimal(dataRow["TotalQty4"]) > 0 && sqm_value_ > 0)
                        {
                            //SellingPricePerSQM4 = (estimatesItem.CostPriceInMarkup4 * (1 + estimatesItem.ProfitMargin4)) / (Convert.ToDecimal(dataRow["TotalQty4"]) * InvSheets4);
                            SellingPricePerSQM4 = (estimatesItem.CostPriceInMarkup4 + estimatesItem.ProfitMarginPrice4) / (Convert.ToDecimal(dataRow["TotalQty4"])) / sqm_value_;
                        }

                        string empty7_new = string.Empty;
                        empty7_new = (this.EstType.ToLower() != "x" ? str : "display:none;");
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trSellingPricePerSQM' style='", empty7_new, "'>")));
                        this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td16_new' style='width: 16%'>"));
                        ControlCollection controls19_new = this.plhItemTotal.Controls;
                        tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", lable_sqm, "</div>" };
                        controls19_new.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td17_new' align='right' style='width: 21%; ", str1, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlurP(this.value,1,'price',", this.EstimateItemID, ",", num, ");" };
                        string str11_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections19_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str11_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM1, 0, "", false, false, false), "' />" };
                        controlCollections19_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls20_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM1_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM1, "' />" };
                        controls20_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td18_new' align='right' style='width: 21%; ", str2, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlurP(this.value,2,'price',", this.EstimateItemID, ",", num, ");" };
                        string str12_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections20_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str12_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM2, 0, "", false, false, false), "' />" };
                        controlCollections20_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls21_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM2_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM2, "' />" };
                        controls21_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td19_new' align='right' style='width: 21%; ", str3, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlurP(this.value,3,'price',", this.EstimateItemID, ",", num, ");" };
                        string str13_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections21_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str13_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM3, 0, "", false, false, false), "' />" };
                        controlCollections21_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls22_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM3_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM3, "' />" };
                        controls22_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td20_new' align='right' style='width: 21%; ", str4, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SQM_OnBlurP(this.value,4,'price',", this.EstimateItemID, ",", num, ");" };
                        string str14_new = string.Concat(estimateItemID);
                        ControlCollection controlCollections22_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSellingPricePerSQM4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str14_new, " style='width: 80px;text-align: right;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, SellingPricePerSQM4, 0, "", false, false, false), "' />" };
                        controlCollections22_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controls23_new = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPricePerSQM4_", this.EstimateItemID, "_", num, "' value='", SellingPricePerSQM4, "' />" };
                        controls23_new.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

                    }
                }
                ////--------------------- end

                string empty8 = string.Empty;
                str = (this.objBase.ReturnRoles_Privileges_Others("showsubtotal").ToLower() != "false" ? "visibility: visible;" : "display:none;");

                if (this.Module.ToLower() == "estimate")
                {
                    if (this.EstType.ToUpper() == "L" || this.EstType.ToUpper() == "C" || this.EstType.ToUpper() == "Q")
                    {
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trPricePerUnit' style='", str, "'>")));
                        this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td46' style='width: 16%'>"));

                        ControlCollection controlCollections51 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total_Unit_Price"), "</b></div>" };
                        controlCollections51.Add(new LiteralControl(string.Concat(estimateItemID)));
                        DataTable dt = EstimatesBasePage.GetEstimateQty(this.EstimateItemID);
                        string subTotalUnitPrice1 = string.Empty;
                        string subTotalUnitPrice2 = string.Empty;
                        string subTotalUnitPrice3 = string.Empty;
                        string subTotalUnitPrice4 = string.Empty;

                        foreach (DataRow dr in dt.Rows)
                        {
                            int qty1 = int.Parse(dr["TotalQty1"].ToString());
                            int qty2 = int.Parse(dr["TotalQty2"].ToString());
                            int qty3 = int.Parse(dr["TotalQty3"].ToString());
                            int qty4 = int.Parse(dr["TotalQty4"].ToString());

                            if (qty1 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit1"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"].ToString()) > 0)
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"])), 0, "", false, false, false);

                                }
                                else
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal1 / qty1), 0, "", false, false, false);
                                }
                            }
                            if (qty2 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit2"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"].ToString()) > 0)
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal2 / qty2), 0, "", false, false, false);
                                }
                            }
                            if (qty3 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit3"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"].ToString()) > 0)
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal3 / qty3), 0, "", false, false, false);
                                }
                            }
                            if (qty4 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit4"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"].ToString()) > 0)
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal4 / qty4), 0, "", false, false, false);
                                }
                            }
                        }

                        if (Convert.ToBoolean(dataRow["IsSubTotalLocked"]))
                        {
                                str5 = "disabled=disabled";
                        }

                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td47' align='right' style='width: 21%; padding-top:10px; ", str1, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,1,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str23 = string.Concat(estimateItemID);
                        ControlCollection controlCollections59 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str23, " style='width:80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice1, "' />" };
                        controlCollections59.Add(new LiteralControl(string.Concat(estimateItemID)));

                        ControlCollection controlCollections52 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice1, "' />" };
                        controlCollections52.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td48' align='right' style='width: 21%;padding-top:10px; ", str2, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,2,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str20 = string.Concat(estimateItemID);
                        ControlCollection controlCollections53 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str20, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice2, "' />" };
                        controlCollections53.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections54 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice2, "' />" };
                        controlCollections54.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td49' align='right' style='width: 21%;padding-top:10px; ", str3, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,3,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str21 = string.Concat(estimateItemID);
                        ControlCollection controlCollections55 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str21, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice3, "' />" };
                        controlCollections55.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections56 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice3, "' />" };
                        controlCollections56.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td50' align='right' style='width: 21%;padding-top:10px; ", str4, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,4,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str22 = string.Concat(estimateItemID);
                        ControlCollection controlCollections57 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str22, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice4, "' />" };
                        controlCollections57.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections58 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice4, "' />" };
                        controlCollections58.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                    }
                    
                    if (this.EstType.ToUpper() == "O" && Convert.ToString(dataRow["Costingtype"]) == "P")
                    {
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trPricePer1000' style='", str, "'>")));
                        this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td46' style='width: 16%'>"));

                        ControlCollection controlCollections51 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total_per1000_Price"), "</b></div>" };
                        controlCollections51.Add(new LiteralControl(string.Concat(estimateItemID)));
                        DataTable dt = EstimatesBasePage.GetEstimateQty(this.EstimateItemID);
                        string subTotalUnitPrice1 = string.Empty;
                        string subTotalUnitPrice2 = string.Empty;
                        string subTotalUnitPrice3 = string.Empty;
                        string subTotalUnitPrice4 = string.Empty;

                        foreach (DataRow dr in dt.Rows)
                        {
                            int qty1 = int.Parse(dr["TotalQty1"].ToString());
                            int qty2 = int.Parse(dr["TotalQty2"].ToString());
                            int qty3 = int.Parse(dr["TotalQty3"].ToString());
                            int qty4 = int.Parse(dr["TotalQty4"].ToString());

                            if (qty1 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit1"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"].ToString()) > 0)
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"])), 0, "", false, false, false);

                                }
                                else
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal1 / qty1) * 1000, 0, "", false, false, false);
                                }
                            }
                            if (qty2 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit2"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"].ToString()) > 0)
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal2 / qty2) * 1000, 0, "", false, false, false);
                                }
                            }
                            if (qty3 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit3"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"].ToString()) > 0)
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal3 / qty3) * 1000, 0, "", false, false, false);
                                }
                            }
                            if (qty4 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit4"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"].ToString()) > 0)
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal4 / qty4) * 1000, 0, "", false, false, false);
                                }
                            }
                        }

                        if (Convert.ToBoolean(dataRow["IsSubTotalLocked"]))
                        {
                            str5 = "disabled=disabled";
                        }

                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td47' align='right' style='width: 21%; padding-top:10px; ", str1, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,1,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str23 = string.Concat(estimateItemID);
                        ControlCollection controlCollections59 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str23, " style='width:80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice1, "' />" };
                        controlCollections59.Add(new LiteralControl(string.Concat(estimateItemID)));

                        ControlCollection controlCollections52 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice1, "' />" };
                        controlCollections52.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td48' align='right' style='width: 21%;padding-top:10px; ", str2, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,2,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str20 = string.Concat(estimateItemID);
                        ControlCollection controlCollections53 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str20, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice2, "' />" };
                        controlCollections53.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections54 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice2, "' />" };
                        controlCollections54.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td49' align='right' style='width: 21%;padding-top:10px; ", str3, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,3,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str21 = string.Concat(estimateItemID);
                        ControlCollection controlCollections55 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str21, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice3, "' />" };
                        controlCollections55.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections56 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice3, "' />" };
                        controlCollections56.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td50' align='right' style='width: 21%;padding-top:10px; ", str4, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,4,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str22 = string.Concat(estimateItemID);
                        ControlCollection controlCollections57 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str22, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice4, "' />" };
                        controlCollections57.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections58 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice4, "' />" };
                        controlCollections58.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                    }

                }

                if (this.Module.ToLower() == "job" || this.Module.ToLower() == "invoice")
                {
                    if (this.EstType.ToUpper() == "L" || this.EstType.ToUpper() == "C" || this.EstType.ToUpper() == "Q")
                    {
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trPricePerUnit' style='", str, "'>")));
                        this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td46' style='width: 16%'>"));

                        ControlCollection controlCollections51 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total_Unit_Price"), "</b></div>" };
                        controlCollections51.Add(new LiteralControl(string.Concat(estimateItemID)));
                        DataTable dt = EstimatesBasePage.GetEstimateQty(this.EstimateItemID);
                        string subTotalUnitPrice1 = string.Empty;
                        string subTotalUnitPrice2 = string.Empty;
                        string subTotalUnitPrice3 = string.Empty;
                        string subTotalUnitPrice4 = string.Empty;

                        foreach (DataRow dr in dt.Rows)
                        {
                            int qty1 = int.Parse(dr["TotalQty1"].ToString());
                            int qty2 = int.Parse(dr["TotalQty2"].ToString());
                            int qty3 = int.Parse(dr["TotalQty3"].ToString());
                            int qty4 = int.Parse(dr["TotalQty4"].ToString());

                            if (qty1 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit1"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"].ToString()) > 0)
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit1"])), 0, "", false, false, false);

                                }
                                else
                                {
                                    subTotalUnitPrice1 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal1 / qty1), 0, "", false, false, false);
                                }
                            }
                            if (qty2 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit2"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"].ToString()) > 0)
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit2"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice2 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal2 / qty2), 0, "", false, false, false);
                                }
                            }
                            if (qty3 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit3"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"].ToString()) > 0)
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit3"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice3 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal3 / qty3), 0, "", false, false, false);
                                }
                            }
                            if (qty4 > 0)
                            {
                                if (!string.IsNullOrEmpty(dataRow["SubTotalPricePerUnit4"].ToString()) && Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"].ToString()) > 0)
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(dataRow["SubTotalPricePerUnit4"])), 0, "", false, false, false);
                                }
                                else
                                {
                                    subTotalUnitPrice4 = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (estimatesItem.SubTotal4 / qty4), 0, "", false, false, false);
                                }
                            }
                        }

                        if (Convert.ToBoolean(dataRow["IsSubTotalLocked"]))
                        {
                            str5 = "disabled=disabled";
                        }

                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td47' align='right' style='width: 21%; padding-top:10px; ", str1, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,1,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str23 = string.Concat(estimateItemID);
                        ControlCollection controlCollections59 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str23, " style='width:80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice1, "' />" };
                        controlCollections59.Add(new LiteralControl(string.Concat(estimateItemID)));

                        ControlCollection controlCollections52 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit1_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice1, "' />" };
                        controlCollections52.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td48' align='right' style='width: 21%;padding-top:10px; ", str2, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,2,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str20 = string.Concat(estimateItemID);
                        ControlCollection controlCollections53 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str20, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice2, "' />" };
                        controlCollections53.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections54 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit2_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice2, "' />" };
                        controlCollections54.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td49' align='right' style='width: 21%;padding-top:10px; ", str3, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,3,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str21 = string.Concat(estimateItemID);
                        ControlCollection controlCollections55 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str21, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice3, "' />" };
                        controlCollections55.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections56 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit3_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice3, "' />" };
                        controlCollections56.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td50' align='right' style='width: 21%;padding-top:10px; ", str4, "'>")));
                        estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_PricePerUnit_OnBlur(this.value,4,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                        string str22 = string.Concat(estimateItemID);
                        ControlCollection controlCollections57 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str22, " style='width: 80px;text-align: right;font-weight:bold;' value='", subTotalUnitPrice4, "' />" };
                        controlCollections57.Add(new LiteralControl(string.Concat(estimateItemID)));
                        ControlCollection controlCollections58 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal_PricePerUnit4_", this.EstimateItemID, "_", num, "' value='", subTotalUnitPrice4, "' />" };
                        controlCollections58.Add(new LiteralControl(string.Concat(estimateItemID)));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                    }
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trSubTotal' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td21' style='width: 16%'>"));
                this.OrderItemApprovalStatus = OrderBasePage.OrderItemApprovalStatus_Select(this.EstimateItemID);
                string empty9 = string.Empty;
                if (!Convert.ToBoolean(dataRow["IsSubTotalLocked"]))
                {
                    if (this.IsFromActHist.ToLower() != "yes")
                    {
                        str5 = "''";
                        empty9 = "visibility: visible;";
                    }
                    else
                    {
                        str5 = "disabled=disabled";
                        empty9 = "visibility: hidden;";
                    }
                    if (this.OrderItemApprovalStatus == 1)
                    {
                        if (this.EstType.ToLower() != "x")
                        {
                            ControlCollection controlCollections23 = this.plhItemTotal.Controls;
                            estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;' onclick=\"javascript:LockSubTotal('", dataRow["EstTotalID"].ToString(), "','1','img_", this.EstimateItemID, "_", num, "','", this.EstimateID, "', '", this.EstimateItemID, "', '", this.EstType, "','", this.QtyCount, "','", this.SectionCount, "','stay');\" id=\"img_", this.EstimateItemID, "_", num, "\" width=20 height=20 title='Click here to Lock the Sub Total' alt='Click here to Lock the Sub Total' style='", empty9, "' src=\"../images/lockopen.png\"/></div>" };
                            controlCollections23.Add(new LiteralControl(string.Concat(estimateItemID)));
                        }
                        else
                        {
                            this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;visibility: hidden;' onclick=\"javascript:void(0);\" width=20 height=20 src=\"../images/lockopen.png\"/></div>")));
                        }
                    }
                    else if (this.EstType.ToLower() != "x")
                    {
                        ControlCollection controls24 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;visibility: hidden;' onclick=\"javascript:LockSubTotal('", dataRow["EstTotalID"].ToString(), "','1','img_", this.EstimateItemID, "_", num, "','", this.EstimateID, "', '", this.EstimateItemID, "', '", this.EstType, "','", this.QtyCount, "','", this.SectionCount, "','stay');\" id=\"img_", this.EstimateItemID, "_", num, "\" width=20 height=20 title='Click here to Lock the Sub Total' alt='Click here to Lock the Sub Total' style='", empty9, "' src=\"../images/lockopen.png\"/></div>" };
                        controls24.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        ControlCollection controlCollections24 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;visibility: hidden;' onclick=\"javascript:void(0);\" id=\"img_", this.EstimateItemID, "_", num, "\" width=20 height=20 src=\"../images/lockopen.png\"/></div>" };
                        controlCollections24.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                }
                else
                {
                    str5 = "disabled=disabled";
                    empty9 = (this.IsFromActHist.ToLower() != "yes" ? "visibility: visible;" : "visibility: hidden;");
                    if (this.EstType.ToLower() != "x")
                    {
                        ControlCollection controls25 = this.plhItemTotal.Controls;
                        estimateItemID = new object[] { "<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;' onclick=\"javascript:LockSubTotal('", dataRow["EstTotalID"].ToString(), "','0','img_", this.EstimateItemID, "_", num, "','", this.EstimateID, "', '", this.EstimateItemID, "', '", this.EstType, "','", this.QtyCount, "','", this.SectionCount, "','stay');\" id=\"img_", this.EstimateItemID, "_", num, "\" width=20 height=20 title='Click here to UnLock the Sub Total' alt='Click here to UnLock the Sub Total' style='", empty9, "' src=\"../images/lockclosed.png\"/></div>" };
                        controls25.Add(new LiteralControl(string.Concat(estimateItemID)));
                    }
                    else
                    {
                        this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary_B' style='width: 160px; clear: both'><b>", this.objLanguage.GetLanguageConversion("Sub_Total"), "</b><img  style='vertical-align:bottom;visibility: hidden;' onclick=\"javascript:void(0);\" width=20 height=20 src=\"../images/lockclosed.png\"/></div>")));
                    }
                }
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td22' align='right' style='width: 21%; padding-top:10px; ", str1, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_OnBlur(this.value,1,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                string str15 = string.Concat(estimateItemID);
                if (this.EstType.ToLower() != "x")
                {
                    ControlCollection controlCollections25 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str15, " style='width:80px;text-align: right;font-weight:bold;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SubTotal1, 0, "", false, false, false), "' />" };
                    controlCollections25.Add(new LiteralControl(string.Concat(estimateItemID)));
                }
                else
                {
                    ControlCollection controls26 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<input disabled='disabled' type='text' ", str5, " id='txtSubTotal1_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str15, " style='width:80px;text-align: right;font-weight:bold;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SubTotal1, 0, "", false, false, false, false, true), "' />" };
                    controls26.Add(new LiteralControl(string.Concat(estimateItemID)));
                }
                ControlCollection controlCollections26 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SubTotal1, "' />" };
                controlCollections26.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td23' align='right' style='width: 21%;padding-top:10px; ", str2, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_OnBlur(this.value,2,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                string str16 = string.Concat(estimateItemID);
                ControlCollection controls27 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal2_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str16, " style='width: 80px;text-align: right;font-weight:bold;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SubTotal2, 0, "", false, false, false), "' />" };
                controls27.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections27 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SubTotal2, "' />" };
                controlCollections27.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td24' align='right' style='width: 21%;padding-top:10px; ", str3, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_OnBlur(this.value,3,", this.EstimateItemID, ",", num, ",'",this.EstType.ToUpper(),"');" };
                string str17 = string.Concat(estimateItemID);
                ControlCollection controls28 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal3_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str17, " style='width: 80px;text-align: right;font-weight:bold;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SubTotal3, 0, "", false, false, false), "' />" };
                controls28.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections28 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SubTotal3, "' />" };
                controlCollections28.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td25' align='right' style='width: 21%;padding-top:10px; ", str4, "'>")));
                estimateItemID = new object[] { "onblur=javascript:AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);SubTotal_OnBlur(this.value,4,", this.EstimateItemID, ",", num, ",'", this.EstType.ToUpper(), "');" };
                string str18 = string.Concat(estimateItemID);
                ControlCollection controls29 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='text' ", str5, " id='txtSubTotal4_", this.EstimateItemID, "_", num, "' class='textboxnew' maxlength='12' ", str18, " style='width: 80px;text-align: right;font-weight:bold;' value='", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SubTotal4, 0, "", false, false, false), "' />" };
                controls29.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections29 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SubTotal4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SubTotal4, "' />" };
                controlCollections29.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                if (this.UnitOfMeasureKey && this.EstType != "Q" && this.EstType != "O" && this.EstType != "W" && this.EstType != "U" && this.EstType != "B" && this.EstType != "K" && this.EstType != "N" && this.EstType != "R")
                {
                    this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trPricePerUnit' style='visibility: visible;'>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td41' style='width: 16%'>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both'>", this.objLanguage.GetLanguageConversion("Price_Per_Unit_Of_Measure"), "</div>")));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td42' style='text-align: right; width: 21%; ", str1, "'>")));
                    ControlCollection controls30 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<span id='spnPricePerUnit1_", this.EstimateItemID, "_", num, "' class='normalText' style='white-space:normal'>", this.commclass.GetCurrencyinRequiredFormate(estimatesItem.PricePerUnitOfMeasure1.Replace("$", ""), true), "</span>" };
                    controls30.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td43' style='text-align: right; width: 21%; ", str2, "'>")));
                    ControlCollection controlCollections30 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<span id='spnPricePerUnit2_", this.EstimateItemID, "_", num, "' class='normalText' style='white-space:normal'>", this.commclass.GetCurrencyinRequiredFormate(estimatesItem.PricePerUnitOfMeasure2.Replace("$", ""), true), "</span>" };
                    controlCollections30.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td44' style='text-align: right; width: 21%; ", str3, "'>")));
                    ControlCollection controls31 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<span id='spnPricePerUnit3_", this.EstimateItemID, "_", num, "' class='normalText' style='white-space:normal'>", this.commclass.GetCurrencyinRequiredFormate(estimatesItem.PricePerUnitOfMeasure3.Replace("$", ""), true), "</span>" };
                    controls31.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td45' style='text-align: right; width: 21%; ", str4, "'>")));
                    ControlCollection controlCollections31 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<span id='spnPricePerUnit4_", this.EstimateItemID, "_", num, "' class='normalText' style='white-space:normal'>", this.commclass.GetCurrencyinRequiredFormate(estimatesItem.PricePerUnitOfMeasure4.Replace("$", ""), true), "</span>" };
                    controlCollections31.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                }
                string empty10 = string.Empty;
                str = (this.objBase.ReturnRoles_Privileges_Others("showtax").ToLower() != "false" ? "visibility: visible;" : "display:none;");
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trTax' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td26' style='width: 16%'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 30px; clear: both'>", this.objLanguage.GetLanguageConversion("Tax"), "&nbsp;")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<div style='float: right; margin-right:10px;'>"));
                estimateItemID = new object[] { "onchange=javascript:Tax_OnChange(this.value,", this.QtyCount, ",", this.EstimateItemID, ",", num, ");" };
                string str19 = string.Concat(estimateItemID);
                if (this.IsFromActHist.ToLower() == "yes" || base.Request.Url.ToString().ToLower().Contains("order"))
                {
                    ControlCollection controls32 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<select id='ddlTax_", this.EstimateItemID, "_", num, "' class='normaltext' ", str19, " style='width:150px;display:none;' >" };
                    controls32.Add(new LiteralControl(string.Concat(estimateItemID)));
                }
                else
                {
                    ControlCollection controlCollections32 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<select id='ddlTax_", this.EstimateItemID, "_", num, "' class='normaltext' ", str19, " style='width:150px;' >" };
                    controlCollections32.Add(new LiteralControl(string.Concat(estimateItemID)));
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(this.Load_Tax_Values(estimatesItem.TaxID, this.CompanyID, estimatesItem.TaxRate1) ?? ""));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </select>"));
                ControlCollection controls33 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxID_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxID, "' />" };
                controls33.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections33 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPercentage_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxRate1, "' />" };
                controlCollections33.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td27' style='text-align: right; width: 21%; ", str1, "'>")));
                ControlCollection controls34 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnTaxPrice1_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.TaxPrice1, 0, "", false, false, true), true), "</span>" };
                controls34.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections34 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPrice1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxPrice1, "' />" };
                controlCollections34.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td28' style='text-align: right; width: 21%; ", str2, "'>")));
                ControlCollection controls35 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnTaxPrice2_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.TaxPrice2, 0, "", false, false, true), true), "</span>" };
                controls35.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections35 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPrice2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxPrice2, "' />" };
                controlCollections35.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td29' style='text-align: right; width: 21%; ", str3, "'>")));
                ControlCollection controls36 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnTaxPrice3_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.TaxPrice3, 0, "", false, false, true), true), "</span>" };
                controls36.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections36 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPrice3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxPrice3, "' />" };
                controlCollections36.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td30' style='text-align: right; width: 21%; ", str4, "'>")));
                ControlCollection controls37 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnTaxPrice4_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.TaxPrice4, 0, "", false, false, true), true), "</span>" };
                controls37.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controlCollections37 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_TaxPrice4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.TaxPrice4, "' />" };
                controlCollections37.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                string empty11 = string.Empty;
                str = (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false" ? "visibility: visible;" : "display:none;");
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trSellingPrice' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td31' style='width: 16%'>"));
                ControlCollection controls38 = this.plhItemTotal.Controls;
                tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 160px; clear: both; ", empty1, " '>", this.objLanguage.GetLanguageConversion("Selling_Price_Inc_Tax"), "</div>" };
                controls38.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td32' style='text-align: right; width: 21%; ", str1, "'>")));
                ControlCollection controlCollections38 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnSellingPrice1_", this.EstimateItemID, "_", num, "' class='normalText' style='", empty1, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SellingPrice1, 0, "", false, false, true), true), "</span>" };
                controlCollections38.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls39 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPrice1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SellingPrice1, "' />" };
                controls39.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td33' style='text-align: right; width: 21%; ", str2, "'>")));
                ControlCollection controlCollections39 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnSellingPrice2_", this.EstimateItemID, "_", num, "' class='normalText' style='", empty1, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SellingPrice2, 0, "", false, false, true), true), "</span>" };
                controlCollections39.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls40 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPrice2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SellingPrice2, "' />" };
                controls40.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td34' style='text-align: right; width: 21%; ", str3, "'>")));
                ControlCollection controlCollections40 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnSellingPrice3_", this.EstimateItemID, "_", num, "' class='normalText' style='", empty1, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SellingPrice3, 0, "", false, false, true), true), "</span>" };
                controlCollections40.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls41 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPrice3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SellingPrice3, "' />" };
                controls41.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td35' style='text-align: right; width: 21%; ", str4, "'>")));
                ControlCollection controlCollections41 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnSellingPrice4_", this.EstimateItemID, "_", num, "' class='normalText' style='", empty1, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.SellingPrice4, 0, "", false, false, true), true), "</span>" };
                controlCollections41.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls42 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_SellingPrice4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.SellingPrice4, "' />" };
                controls42.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                if (Convert.ToBoolean(dataRow["IsCouponCodeApplied"]))
                {
                    this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trCouponCode'>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td51' style='width: 16%'>"));
                    ControlCollection controlCollections42 = this.plhItemTotal.Controls;
                    tblWidthMinWidth = new string[] { "<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", this.objLanguage.GetLanguageConversion("Discount"), "</br> ", dataRow["CouponCodeUserFriendlyName"].ToString(), " (", dataRow["CouponCode"].ToString(), ") - ", dataRow["CouponCodeDiscount"].ToString(), "</div>" };
                    controlCollections42.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    str1 = (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false" ? "visibility: visible;" : "display:none;");
                    this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='td52' style='text-align: right; width: 21%; ", str1, "'>")));
                    ControlCollection controls43 = this.plhItemTotal.Controls;
                    estimateItemID = new object[] { "<span id='spnCouponCode_", this.EstimateItemID, "_", num, "' class='normalText'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true), true), "</span>" };
                    controls43.Add(new LiteralControl(string.Concat(estimateItemID)));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                }
                string empty12 = string.Empty;
                empty12 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofitmargin");
                string empty13 = string.Empty;
                empty13 = this.objBase.ReturnRoles_Privileges_Others("showgrossprofit");
                if (!(empty12.ToLower() == "false") || !(empty13.ToLower() == "false"))
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trBorder'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td valign='top' class='Summary_BorderLine' colspan='5' id='tdborder'><span></span>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trGrossProfit' style='", str, "'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td valign='top' id='td36' style='width: 16%'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 160px; clear: both;font-weight:bold;height:30px;padding-top:10px;margin-left:4px;'>", this.objLanguage.GetLanguageConversion("Gross_Profit"), "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='td37' style='text-align: right;width: 21%;font-weight:bold; ", str1, "'>")));
                if (empty13.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right; padding-top:5px;", str, "'>")));
                ControlCollection controlCollections43 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPrice1_", this.EstimateItemID, "_", num, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPrice1, 0, "", false, false, true), true), "</span>" };
                controlCollections43.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls44 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPrice1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPrice1, "' />" };
                controls44.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div><div style='clear:both;padding-top:7px'></div>"));
                if (empty12.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right;", str, "'>")));
                ControlCollection controlCollections44 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPercentage1_", this.EstimateItemID, "_", num, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPercentage1, 0, "", false, false, true, false, false), "%</span>" };
                controlCollections44.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls45 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPercentage1_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPercentage1, "' />" };
                controls45.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='td38' style='text-align: right;width: 21%;font-weight:bold; ", str2, "'>")));
                if (empty13.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right; padding-top:5px; ", str, "'>")));
                ControlCollection controlCollections45 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPrice2_", this.EstimateItemID, "_", num, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPrice2, 0, "", false, false, true, false, false), true), "</span>" };
                controlCollections45.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls46 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPrice2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPrice2, "' />" };
                controls46.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div><div style='clear:both;padding-top:7px'></div>"));
                if (empty12.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right;", str, "'>")));
                ControlCollection controlCollections46 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPercentage2_", this.EstimateItemID, "_", num, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPercentage2, 0, "", false, false, true, false, false), "%</span>" };
                controlCollections46.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls47 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPercentage2_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPercentage2, "' />" };
                controls47.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='td39' style='text-align: right; width: 21%;font-weight:bold; ", str3, "'>")));
                if (empty13.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right; text-align: right;padding-top:5px; ", str, "'>")));
                ControlCollection controlCollections47 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPrice3_", this.EstimateItemID, "_", num, "'>", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPrice3, 0, "", false, false, true, false, false), true), "</span>" };
                controlCollections47.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls48 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPrice3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPrice3, "' />" };
                controls48.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div><div style='clear:both;padding-top:7px'></div>"));
                if (empty12.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right;", str, "'>")));
                ControlCollection controlCollections48 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPercentage3_", this.EstimateItemID, "_", num, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPercentage3, 0, "", false, false, true, false, false), "%</span>" };
                controlCollections48.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls49 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPercentage3_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPercentage3, "' />" };
                controls49.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td valign='top' id='td40' style='text-align: right; width: 21%;font-weight:bold; ", str4, "'>")));
                if (empty13.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right; text-align: right; padding-top:5px; ", str, "'>")));
                ControlCollection controlCollections49 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPrice4_", this.EstimateItemID, "_", num, "' >", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPrice4, 0, "", false, false, true, false, false), true), "</span>" };
                controlCollections49.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls50 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPrice4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPrice4, "' />" };
                controls50.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div><div style='clear:both;padding-top:7px'></div>"));
                if (empty12.ToLower() != "false")
                {
                    str = (!this.Check_SpecialPrivilege ? "visibility: visible;" : "display:none;");
                }
                else
                {
                    str = "display:none;";
                }
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div style='float:right;text-align: right;", str, "'>")));
                ControlCollection controlCollections50 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<span id='spnGrossProfitPercentage4_", this.EstimateItemID, "_", num, "'>", this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, estimatesItem.GrossProfitPercentage4, 0, "", false, false, true, false, false), "%</span>" };
                controlCollections50.Add(new LiteralControl(string.Concat(estimateItemID)));
                ControlCollection controls51 = this.plhItemTotal.Controls;
                estimateItemID = new object[] { "<input type='hidden' id='hdn_GrossProfitPercentage4_", this.EstimateItemID, "_", num, "' value='", estimatesItem.GrossProfitPercentage4, "' />" };
                controls51.Add(new LiteralControl(string.Concat(estimateItemID)));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</div>"));
                num++;
            }
            item_summary_total.IsEditOnlyHisRecords = baseClass.ReturnRoles_Privileges_Others("editrecords");
            if (item_summary_total.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != item_summary_total.SalesPersonID)
            {
                this.btnSave.Visible = false;
                this.btnStay.Visible = false;
            }
            Button button = this.btnStay;
            estimateItemID = new object[] { "javascript:CallSave(", this.EstimateID, ", ", this.EstimateItemID, ", '", this.EstType, "', ", this.QtyCount, ",", this.SectionCount, ",'stay');" };
            button.OnClientClick = string.Concat(estimateItemID);
            Button button1 = this.btnSave;
            estimateItemID = new object[] { "javascript:CallSave(", this.EstimateID, ", ", this.EstimateItemID, ", '", this.EstType, "', ", this.QtyCount, ",", this.SectionCount, ",'save');" };
            button1.OnClientClick = string.Concat(estimateItemID);
        }

        public void SaveClick(string type, string finalvalues, string JobID, string InvoiceID, string ItemDesc)
        {
            string[] strArrays = ItemDesc.Split(new char[] { '\u25AC' });
            EstimateCommonMethods.EditUpdateIDescriptionsInSummary(Convert.ToInt32(strArrays[0]), Convert.ToInt64(strArrays[1]), Convert.ToInt64(strArrays[2]), strArrays[3].ToString(), strArrays[4].ToString(), Convert.ToBoolean(strArrays[5]), Convert.ToBoolean(strArrays[6]), Convert.ToBoolean(strArrays[7]), strArrays[8].ToString(), strArrays[9].ToString(), this.UserID);
            this.btnType = type;
            this.SaveValues = finalvalues;
            this.jID = JobID;
            this.InvID = InvoiceID;
            this.btnStay_Click(null, null);
        }

        private decimal ToDecimal(string Value)
        {
            if (Value.Length == 0)
            {
                return new decimal(0);
            }
            return decimal.Parse(Value.Replace(" ", ""));
        }
    }
}