using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.SUPPLIER
{
    public partial class SupplierQuote : System.Web.UI.Page, IRequiresSessionState
    {
        private BaseClass objBase = new BaseClass();

        public short CompanyID;

        public short UserID;

        public long EstimateID;

        public long EstimateItemID;

        private string QuoteLink = string.Empty;

        public string KeyCode = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public static string DateFormat;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string IsSupplierQuote = string.Empty;

        private commonClass commclass = new commonClass();

        public languageClass objLangClass = new languageClass();

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

        static SupplierQuote()
        {
            SupplierQuote.DateFormat = string.Empty;
        }

        public SupplierQuote()
        {
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            this.Insert_Quote(0);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            this.lbl_QuoteStats.Text = "r";
            this.Insert_Quote(1);
        }

        public void Display_none()
        {
            this.lblQuantity1.Style.Add("display", "none");
            this.txtPriceEx1.Style.Add("display", "none");
            this.txtDelivery1.Style.Add("display", "none");
            this.chkDelInc1.Style.Add("display", "none");
            this.txtDelCost1.Style.Add("display", "none");
            this.lblQuantity2.Style.Add("display", "none");
            this.txtPriceEx2.Style.Add("display", "none");
            this.txtDelivery2.Style.Add("display", "none");
            this.chkDelInc2.Style.Add("display", "none");
            this.txtDelCost2.Style.Add("display", "none");
            this.lblQuantity3.Style.Add("display", "none");
            this.txtPriceEx3.Style.Add("display", "none");
            this.txtDelivery3.Style.Add("display", "none");
            this.chkDelInc3.Style.Add("display", "none");
            this.txtDelCost3.Style.Add("display", "none");
            this.lblQuantity4.Style.Add("display", "none");
            this.txtPriceEx4.Style.Add("display", "none");
            this.txtDelivery4.Style.Add("display", "none");
            this.chkDelInc4.Style.Add("display", "none");
            this.txtDelCost4.Style.Add("display", "none");
        }

        public void GetEstimateDetails(string KeyCD)
        {
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.SupplierQuote_Details(KeyCD);
            DataRow item = dataSet.Tables[0].Rows[0];
            DataRow dataRow = dataSet.Tables[2].Rows[0];
            DataTable dataTable = dataSet.Tables[1];
            DataTable item1 = dataSet.Tables[3];
            this.EstimateID = Convert.ToInt64(item["EstimateID"].ToString());
            this.EstimateItemID = Convert.ToInt64(item["EstimateItemID"].ToString());
            if (item1.Rows.Count > 0)
            {
                this.txtComments.Text = item1.Rows[0]["Comments"].ToString();
                this.txtRejectReason.Text = item1.Rows[0]["RejectedReason"].ToString();
            }
            object[] estimateID = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&tab=Q" };
            this.QuoteLink = string.Concat(estimateID);
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            DateTime dateTime1 = Convert.ToDateTime(this.commclass.Eprint_return_ActualDate_Before_View(item["RFQReturnDate"].ToString(), this.CompanyID, this.UserID, false));
            this.Timeleft.Text = (dateTime1 - dateTime).TotalSeconds.ToString();
            SupplierQuote.DateFormat = dataTable.Rows[0]["DateFormat"].ToString();
            this.calDelivery1.Format = SupplierQuote.DateFormat.Replace("mm", "M").Replace("dd", "d");
            this.calDelivery2.Format = SupplierQuote.DateFormat.Replace("mm", "M").Replace("dd", "d");
            this.calDelivery3.Format = SupplierQuote.DateFormat.Replace("mm", "M").Replace("dd", "d");
            this.calDelivery4.Format = SupplierQuote.DateFormat.Replace("mm", "M").Replace("dd", "d");
            this.lblSupplierRefNo.Text = dataTable.Rows[0]["SupplierRefNo"].ToString();
            this.lblEstNumber.Text = item["EstimateNumber"].ToString();
            this.lblEstTitle.Text = item["EstimateTitle"].ToString();
            this.lblRfqDue.Text = this.commclass.Eprint_return_Date_Before_View(item["RFQReturnDate"].ToString(), this.CompanyID, this.UserID, false);
            this.lblJobComp.Text = this.commclass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
            this.lblArtFileName.Text = "";
            if (dataTable.Rows[0]["Name"].ToString() != "")
            {
                this.lblSupplierName.Text = string.Concat(dataTable.Rows[0]["Name"].ToString(), "-  ");
            }
            this.lblSupplierName.Text = string.Concat(this.lblSupplierName.Text, dataTable.Rows[0]["SupplierName"].ToString());
            this.lblCompanyID.Text = dataTable.Rows[0]["CompanyID"].ToString();
            this.lblEmailID.Text = dataTable.Rows[0]["EmailID"].ToString();
            this.lblEmailSenderID.Text = dataTable.Rows[0]["EmailSentBy"].ToString();
            this.commclass.logoSetting(this.plhheader, this.plhFooter, int.Parse(this.lblCompanyID.Text), "both");
            if (item["ArtWork"].ToString() == "")
            {
                this.lblArtInc.Text = "No";
                this.lblArtFileName.Text = "-";
            }
            else
            {
                this.lblArtInc.Text = "Yes";
                string[] strArrays = item["ArtWork"].ToString().Split(new char[] { '«' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        Label label = this.lblArtFileName;
                        label.Text = string.Concat(label.Text, strArrays[i].ToString(), "<br/>");
                    }
                }
            }
            string str = item["ItemDescription"].ToString();
            string[] strArrays1 = str.Split(new char[] { 'µ' });

            for (int j = 0; j < strArrays1.Length; j++)
            {
                string str1 = strArrays1[j].ToString();
                string[] strArrays2 = str1.Split(new char[] { '»' });

                if (str1 != "" && strArrays2[3].ToLower() == "true")
                {
                    // Decode the value
                    string decodedValue = HttpUtility.UrlDecode(strArrays2[2]);

                    if (j != 0)
                    {
                        this.plhDescription.Controls.Add(new LiteralControl("<table cellpadding='3' cellspacing='0' border='0' style='padding-bottom:7px;' >"));
                        this.plhDescription.Controls.Add(new LiteralControl("<tr>"));
                        this.plhDescription.Controls.Add(new LiteralControl("<td align='left' style='width:200px;'  valign='top'>"));
                        this.plhDescription.Controls.Add(new LiteralControl($"<span>{strArrays2[1]}:</span>"));
                        this.plhDescription.Controls.Add(new LiteralControl("</td>"));
                        this.plhDescription.Controls.Add(new LiteralControl("<td align='left'>"));
                        this.plhDescription.Controls.Add(new LiteralControl($"<span>{decodedValue}</span>"));
                        this.plhDescription.Controls.Add(new LiteralControl("</td>"));
                        this.plhDescription.Controls.Add(new LiteralControl("</tr>"));
                        this.plhDescription.Controls.Add(new LiteralControl("</table>"));
                    }
                    else
                    {
                        this.lblItemTitle.Text = decodedValue;
                    }
                }
            }

            this.Display_none();
            this.lbl_QuoteStats.Text = "i";
            if (dataTable.Rows[0] != null)
            {
                DataRow dataRow1 = dataTable.Rows[0];
                if (dataRow1["QuantityNumber"].ToString() == "1")
                {
                    this.lblQuantity1.Style.Add("display", "block");
                    this.txtPriceEx1.Style.Add("display", "block");
                    this.txtDelivery1.Style.Add("display", "block");
                    this.chkDelInc1.Style.Add("display", "block");
                    this.txtDelCost1.Style.Add("display", "block");
                    this.lblQuantity1.Text = dataRow1["Quantity"].ToString();
                    TextBox textBox = this.txtPriceEx1;
                    decimal num = Math.Round(Convert.ToDecimal(dataRow1["Cost"]), 2);
                    textBox.Text = num.ToString();
                    if (!dataRow1["DeliveryDate"].ToString().Contains("1900"))
                    {
                        this.txtDelivery1.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    if (dataRow1["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                    {
                        this.chkDelInc1.Checked = false;
                        TextBox textBox1 = this.txtDelCost1;
                        decimal num1 = Math.Round(Convert.ToDecimal(dataRow1["DeliveryCost"]), 2);
                        textBox1.Text = num1.ToString();
                    }
                    else
                    {
                        this.chkDelInc1.Checked = true;
                        this.txtDelCost1.Text = "";
                        this.txtDelCost1.Enabled = false;
                    }
                }
                else if (dataRow1["QuantityNumber"].ToString() == "2")
                {
                    this.lblQuantity2.Style.Add("display", "block");
                    this.txtPriceEx2.Style.Add("display", "block");
                    this.txtDelivery2.Style.Add("display", "block");
                    this.chkDelInc2.Style.Add("display", "block");
                    this.txtDelCost2.Style.Add("display", "block");
                    this.lblQuantity2.Text = dataRow1["Quantity"].ToString();
                    TextBox str2 = this.txtPriceEx2;
                    decimal num2 = Math.Round(Convert.ToDecimal(dataRow1["Cost"]), 2);
                    str2.Text = num2.ToString();
                    if (!dataRow1["DeliveryDate"].ToString().Contains("1900"))
                    {
                        this.txtDelivery2.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    if (dataRow1["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                    {
                        this.chkDelInc2.Checked = false;
                        TextBox textBox2 = this.txtDelCost2;
                        decimal num3 = Math.Round(Convert.ToDecimal(dataRow1["DeliveryCost"]), 2);
                        textBox2.Text = num3.ToString();
                    }
                    else
                    {
                        this.chkDelInc2.Checked = true;
                        this.txtDelCost2.Text = "";
                        this.txtDelCost2.Enabled = false;
                    }
                }
                else if (dataRow1["QuantityNumber"].ToString() == "3")
                {
                    this.lblQuantity3.Style.Add("display", "block");
                    this.txtPriceEx3.Style.Add("display", "block");
                    this.txtDelivery3.Style.Add("display", "block");
                    this.chkDelInc3.Style.Add("display", "block");
                    this.txtDelCost3.Style.Add("display", "block");
                    this.lblQuantity3.Text = dataRow1["Quantity"].ToString();
                    TextBox str3 = this.txtPriceEx3;
                    decimal num4 = Math.Round(Convert.ToDecimal(dataRow1["Cost"]), 2);
                    str3.Text = num4.ToString();
                    if (!dataRow1["DeliveryDate"].ToString().Contains("1900"))
                    {
                        this.txtDelivery3.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    if (dataRow1["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                    {
                        this.chkDelInc3.Checked = false;
                        TextBox textBox3 = this.txtDelCost3;
                        decimal num5 = Math.Round(Convert.ToDecimal(dataRow1["DeliveryCost"]), 2);
                        textBox3.Text = num5.ToString();
                    }
                    else
                    {
                        this.chkDelInc3.Checked = true;
                        this.txtDelCost3.Text = "";
                        this.txtDelCost3.Enabled = false;
                    }
                }
                else if (dataRow1["QuantityNumber"].ToString() == "4")
                {
                    this.lblQuantity4.Style.Add("display", "block");
                    this.txtPriceEx4.Style.Add("display", "block");
                    this.txtDelivery4.Style.Add("display", "block");
                    this.chkDelInc4.Style.Add("display", "block");
                    this.txtDelCost4.Style.Add("display", "block");
                    this.lblQuantity4.Text = dataRow1["Quantity"].ToString();
                    TextBox str4 = this.txtPriceEx4;
                    decimal num6 = Math.Round(Convert.ToDecimal(dataRow1["Cost"]), 2);
                    str4.Text = num6.ToString();
                    if (!dataRow1["DeliveryDate"].ToString().Contains("1900"))
                    {
                        this.txtDelivery4.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    if (dataRow1["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                    {
                        this.chkDelInc4.Checked = false;
                        TextBox textBox4 = this.txtDelCost4;
                        decimal num7 = Math.Round(Convert.ToDecimal(dataRow1["DeliveryCost"]), 2);
                        textBox4.Text = num7.ToString();
                    }
                    else
                    {
                        this.chkDelInc4.Checked = true;
                        this.txtDelCost4.Text = "";
                        this.txtDelCost4.Enabled = false;
                    }
                }
            }
            try
            {
                if (dataTable.Rows[1] != null)
                {
                    DataRow item2 = dataTable.Rows[1];
                    if (item2["QuantityNumber"].ToString() == "2")
                    {
                        this.lblQuantity2.Style.Add("display", "block");
                        this.txtPriceEx2.Style.Add("display", "block");
                        this.txtDelivery2.Style.Add("display", "block");
                        this.chkDelInc2.Style.Add("display", "block");
                        this.txtDelCost2.Style.Add("display", "block");
                        this.lblQuantity2.Text = item2["Quantity"].ToString();
                        TextBox str5 = this.txtPriceEx2;
                        decimal num8 = Math.Round(Convert.ToDecimal(item2["Cost"]), 2);
                        str5.Text = num8.ToString();
                        if (!item2["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery2.Text = this.commclass.Eprint_return_Date_Before_View(item2["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (item2["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc2.Checked = false;
                            TextBox textBox5 = this.txtDelCost2;
                            decimal num9 = Math.Round(Convert.ToDecimal(item2["DeliveryCost"]), 2);
                            textBox5.Text = num9.ToString();
                        }
                        else
                        {
                            this.chkDelInc2.Checked = true;
                            this.txtDelCost2.Text = "";
                            this.txtDelCost2.Enabled = false;
                        }
                    }
                    else if (item2["QuantityNumber"].ToString() == "3")
                    {
                        this.lblQuantity3.Style.Add("display", "block");
                        this.txtPriceEx3.Style.Add("display", "block");
                        this.txtDelivery3.Style.Add("display", "block");
                        this.chkDelInc3.Style.Add("display", "block");
                        this.txtDelCost3.Style.Add("display", "block");
                        this.lblQuantity3.Text = item2["Quantity"].ToString();
                        TextBox str6 = this.txtPriceEx3;
                        decimal num10 = Math.Round(Convert.ToDecimal(item2["Cost"]), 2);
                        str6.Text = num10.ToString();
                        if (!item2["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery3.Text = this.commclass.Eprint_return_Date_Before_View(item2["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (item2["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc3.Checked = false;
                            TextBox textBox6 = this.txtDelCost3;
                            decimal num11 = Math.Round(Convert.ToDecimal(item2["DeliveryCost"]), 2);
                            textBox6.Text = num11.ToString();
                        }
                        else
                        {
                            this.chkDelInc3.Checked = true;
                            this.txtDelCost3.Text = "";
                            this.txtDelCost3.Enabled = false;
                        }
                    }
                    else if (item2["QuantityNumber"].ToString() == "4")
                    {
                        this.lblQuantity4.Style.Add("display", "block");
                        this.txtPriceEx4.Style.Add("display", "block");
                        this.txtDelivery4.Style.Add("display", "block");
                        this.chkDelInc4.Style.Add("display", "block");
                        this.txtDelCost4.Style.Add("display", "block");
                        this.lblQuantity4.Text = item2["Quantity"].ToString();
                        TextBox str7 = this.txtPriceEx4;
                        decimal num12 = Math.Round(Convert.ToDecimal(item2["Cost"]), 2);
                        str7.Text = num12.ToString();
                        if (!item2["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery4.Text = this.commclass.Eprint_return_Date_Before_View(item2["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (item2["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc4.Checked = false;
                            TextBox textBox7 = this.txtDelCost4;
                            decimal num13 = Math.Round(Convert.ToDecimal(item2["DeliveryCost"]), 2);
                            textBox7.Text = num13.ToString();
                        }
                        else
                        {
                            this.chkDelInc4.Checked = true;
                            this.txtDelCost4.Text = "";
                            this.txtDelCost4.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                if (dataTable.Rows[2] != null)
                {
                    DataRow dataRow2 = dataTable.Rows[2];
                    if (dataRow2["QuantityNumber"].ToString() == "3")
                    {
                        this.lblQuantity3.Style.Add("display", "block");
                        this.txtPriceEx3.Style.Add("display", "block");
                        this.txtDelivery3.Style.Add("display", "block");
                        this.chkDelInc3.Style.Add("display", "block");
                        this.txtDelCost3.Style.Add("display", "block");
                        this.lblQuantity3.Text = dataRow2["Quantity"].ToString();
                        TextBox str8 = this.txtPriceEx3;
                        decimal num14 = Math.Round(Convert.ToDecimal(dataRow2["Cost"]), 2);
                        str8.Text = num14.ToString();
                        if (!dataRow2["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery3.Text = this.commclass.Eprint_return_Date_Before_View(dataRow2["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (dataRow2["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc3.Checked = false;
                            TextBox textBox8 = this.txtDelCost3;
                            decimal num15 = Math.Round(Convert.ToDecimal(dataRow2["DeliveryCost"]), 2);
                            textBox8.Text = num15.ToString();
                        }
                        else
                        {
                            this.chkDelInc3.Checked = true;
                            this.txtDelCost3.Text = "";
                            this.txtDelCost3.Enabled = false;
                        }
                    }
                    else if (dataRow2["QuantityNumber"].ToString() == "4")
                    {
                        this.lblQuantity4.Style.Add("display", "block");
                        this.txtPriceEx4.Style.Add("display", "block");
                        this.txtDelivery4.Style.Add("display", "block");
                        this.chkDelInc4.Style.Add("display", "block");
                        this.txtDelCost4.Style.Add("display", "block");
                        this.lblQuantity4.Text = dataRow2["Quantity"].ToString();
                        TextBox str9 = this.txtPriceEx4;
                        decimal num16 = Math.Round(Convert.ToDecimal(dataRow2["Cost"]), 2);
                        str9.Text = num16.ToString();
                        if (!dataRow2["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery4.Text = this.commclass.Eprint_return_Date_Before_View(dataRow2["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (dataRow2["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc4.Checked = false;
                            TextBox textBox9 = this.txtDelCost4;
                            decimal num17 = Math.Round(Convert.ToDecimal(dataRow2["DeliveryCost"]), 2);
                            textBox9.Text = num17.ToString();
                        }
                        else
                        {
                            this.chkDelInc4.Checked = true;
                            this.txtDelCost4.Text = "";
                            this.txtDelCost4.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                if (dataTable.Rows[3] != null)
                {
                    DataRow item3 = dataTable.Rows[3];
                    if (item3["QuantityNumber"].ToString() == "4")
                    {
                        this.lblQuantity4.Style.Add("display", "block");
                        this.txtPriceEx4.Style.Add("display", "block");
                        this.txtDelivery4.Style.Add("display", "block");
                        this.chkDelInc4.Style.Add("display", "block");
                        this.txtDelCost4.Style.Add("display", "block");
                        this.lblQuantity4.Text = item3["Quantity"].ToString();
                        TextBox str10 = this.txtPriceEx4;
                        decimal num18 = Math.Round(Convert.ToDecimal(item3["Cost"]), 2);
                        str10.Text = num18.ToString();
                        if (!item3["DeliveryDate"].ToString().Contains("1900"))
                        {
                            this.txtDelivery4.Text = this.commclass.Eprint_return_Date_Before_View(item3["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        if (item3["IsDeliveryIncluded"].ToString().ToLower() != "yes")
                        {
                            this.chkDelInc4.Checked = false;
                            TextBox textBox10 = this.txtDelCost4;
                            decimal num19 = Math.Round(Convert.ToDecimal(item3["DeliveryCost"]), 2);
                            textBox10.Text = num19.ToString();
                        }
                        else
                        {
                            this.chkDelInc4.Checked = true;
                            this.txtDelCost4.Text = "";
                            this.txtDelCost4.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void Insert_Quote(int isRejected)
        {
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.SupplierQuote_Details(this.KeyCode);
            DataRow item = dataSet.Tables[0].Rows[0];
            DataRow dataRow = dataSet.Tables[2].Rows[0];
            DataTable dataTable = dataSet.Tables[1];
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string text = string.Empty;
            string text1 = string.Empty;
            string empty2 = string.Empty;
            string text2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string text3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            empty4 = item["ItemDescription"].ToString();
            string str4 = item["ItemDescription"].ToString();
            string[] strArrays = str4.Split(new char[] { 'µ' });
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str5 = strArrays[i].ToString();
                string[] strArrays1 = str5.Split(new char[] { '»' });
                if (str5 != "" && strArrays1[3].ToString().ToLower() == "true" && i != 0)
                {
                    stringBuilder.Append("<table  cellpadding='3' cellspacing='0' border='0' >");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td align='left'>");
                    stringBuilder.Append(string.Concat("<span>", strArrays1[1].ToString(), ":</span>"));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td align='left'>&nbsp;");
                    stringBuilder.Append(string.Concat("<span>", strArrays1[2].ToString(), "</span>"));
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                }
            }
            if (!this.chkDelInc1.Checked)
            {
                empty = "no";
                text = this.txtDelCost1.Text;
            }
            else
            {
                empty = "yes";
                text = "0.00";
            }
            if (!this.chkDelInc2.Checked)
            {
                str = "no";
                text1 = this.txtDelCost2.Text;
            }
            else
            {
                str = "yes";
                text1 = "0.00";
            }
            if (!this.chkDelInc3.Checked)
            {
                empty1 = "no";
                empty2 = this.txtDelCost3.Text;
            }
            else
            {
                empty1 = "yes";
                empty2 = "0.00";
            }
            if (!this.chkDelInc4.Checked)
            {
                str1 = "no";
                text2 = this.txtDelCost4.Text;
            }
            else
            {
                str1 = "yes";
                text2 = "0.00";
            }
            if (this.txtPriceEx4.Text != "")
            {
                str3 = this.txtPriceEx4.Text;
            }
            else
            {
                str3 = "0.00";
                text2 = "0.00";
            }
            if (this.txtPriceEx3.Text != "")
            {
                text3 = this.txtPriceEx3.Text;
            }
            else
            {
                text3 = "0.00";
                empty2 = "0.00";
            }
            if (this.txtPriceEx2.Text != "")
            {
                empty3 = this.txtPriceEx2.Text;
            }
            else
            {
                empty3 = "0.00";
                text1 = "0.00";
            }
            if (this.txtPriceEx1.Text != "")
            {
                str2 = this.txtPriceEx1.Text;
            }
            else
            {
                str2 = "0.00";
                text = "0.00";
            }
            if (this.txtDelivery4.Text != "")
            {
                this.txtDelivery4.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.txtDelivery4.Text);
            }
            else
            {
                this.txtDelivery4.Text = "1900-01-01 00:00:00.000";
            }
            if (this.txtDelivery3.Text != "")
            {
                this.txtDelivery3.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.txtDelivery3.Text);
            }
            else
            {
                this.txtDelivery3.Text = "1900-01-01 00:00:00.000";
            }
            if (this.txtDelivery2.Text != "")
            {
                this.txtDelivery2.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.txtDelivery2.Text);
            }
            else
            {
                this.txtDelivery2.Text = "1900-01-01 00:00:00.000";
            }
            if (this.txtDelivery1.Text != "")
            {
                this.txtDelivery1.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.txtDelivery1.Text);
            }
            else
            {
                this.txtDelivery1.Text = "1900-01-01 00:00:00.000";
            }
            this.lblRfqDue.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.lblRfqDue.Text);
            this.lblJobComp.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(SupplierQuote.DateFormat, this.lblJobComp.Text);
            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(this.lblRfqDue.Text);
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(this.lblJobComp.Text);
            DateTime dateTime2 = new DateTime();
            dateTime2 = Convert.ToDateTime(this.txtDelivery1.Text);
            DateTime dateTime3 = new DateTime();
            dateTime3 = Convert.ToDateTime(this.txtDelivery2.Text);
            DateTime dateTime4 = new DateTime();
            dateTime4 = Convert.ToDateTime(this.txtDelivery3.Text);
            DateTime dateTime5 = new DateTime();
            dateTime5 = Convert.ToDateTime(this.txtDelivery4.Text);
            EstimateBasePage.SupplierQuote_Insert_BySupplier(dataTable.Rows[0]["EstimateItemID"].ToString(), dataTable.Rows[0]["SupplierID"].ToString(), this.lblEstNumber.Text, this.lblEstTitle.Text, this.lblArtInc.Text, item["ArtWork"].ToString(), dateTime, dateTime1, this.lblItemTitle.Text, empty4, this.lblSupplierRefNo.Text, this.txtComments.Text, this.lblQuantity1.Text, str2, dateTime2, empty, text, this.lblQuantity2.Text, empty3, dateTime3, str, text1, this.lblQuantity3.Text, text3, dateTime4, empty1, empty2, this.lblQuantity4.Text, str3, dateTime5, str1, text2, isRejected, this.txtRejectReason.Text, this.KeyCode);
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            this.EstimateID = Convert.ToInt64(item["EstimateID"].ToString());
            this.EstimateItemID = Convert.ToInt64(item["EstimateItemID"].ToString());
            object[] estimateID = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&tab=Q" };
            this.QuoteLink = string.Concat(estimateID);
            DataTable dataTable1 = new DataTable();
            dataTable1 = (isRejected != 0 ? EstimateBasePage.SupplierEmailBody_Select(Convert.ToInt64(this.lblCompanyID.Text), "Rejected") : EstimateBasePage.SupplierEmailBody_Select(Convert.ToInt64(this.lblCompanyID.Text), "Recieved"));
            if (dataTable1.Rows.Count > 0)
            {
                DataRow item1 = dataTable1.Rows[0];
                string str6 = item1["Body"].ToString();
                string empty5 = string.Empty;
                string text4 = this.lblEmailID.Text;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                string str7 = item1["Subject"].ToString();
                string empty8 = string.Empty;
                str6 = str6.Replace("[$SUPPLIER_NAME$]", this.lblSupplierName.Text);
                str6 = str6.Replace("[$ESTIMATE_NUMBER$]", this.lblEstNumber.Text);
                str6 = str6.Replace("[$SUPPLIER_RFQ_NUMBER$]", this.lblSupplierRefNo.Text);
                str6 = str6.Replace("[$ESTIMATE_TITLE$]", this.lblEstTitle.Text);
                str6 = str6.Replace("[$JOBCOMPLETION_DATE$]", this.commclass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$ITEM_TITLE$]", this.lblItemTitle.Text);
                str6 = str6.Replace("[$RFQ_RETURN_DATE$]", this.commclass.Eprint_return_Date_Before_View(item["RFQReturnDate"].ToString(), this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$QUANTITY1$]", this.lblQuantity1.Text);
                str6 = str6.Replace("[$QUANTITY2$]", this.lblQuantity2.Text);
                str6 = str6.Replace("[$QUANTITY3$]", this.lblQuantity3.Text);
                str6 = str6.Replace("[$QUANTITY4$]", this.lblQuantity4.Text);
                str6 = str6.Replace("[$PRICE1$]", this.txtPriceEx1.Text);
                str6 = str6.Replace("[$PRICE2$]", this.txtPriceEx2.Text);
                str6 = str6.Replace("[$PRICE3$]", this.txtPriceEx3.Text);
                str6 = str6.Replace("[$PRICE4$]", this.txtPriceEx4.Text);
                str6 = str6.Replace("[$DELIVERY_DATE1$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery1.Text, this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$DELIVERY_DATE2$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery2.Text, this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$DELIVERY_DATE3$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery3.Text, this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$DELIVERY_DATE4$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery4.Text, this.CompanyID, this.UserID, false));
                str6 = str6.Replace("[$DELIVERY_INCLUDED1$]", empty);
                str6 = str6.Replace("[$DELIVERY_INCLUDED2$]", str);
                str6 = str6.Replace("[$DELIVERY_INCLUDED3$]", empty1);
                str6 = str6.Replace("[$DELIVERY_INCLUDED4$]", str1);
                str6 = str6.Replace("[$DELIVERY_COST1$]", this.txtDelCost1.Text);
                str6 = str6.Replace("[$DELIVERY_COST2$]", this.txtDelCost2.Text);
                str6 = str6.Replace("[$DELIVERY_COST3$]", this.txtDelCost3.Text);
                str6 = str6.Replace("[$DELIVERY_COST4$]", this.txtDelCost4.Text);
                str6 = str6.Replace("[$SUPPLIER_COMMENTS$]", this.txtComments.Text);
                str6 = str6.Replace("[$QUOTE_LINK$]", this.QuoteLink);
                str6 = str6.Replace("[$ITEMDESCRIPTION_DETAILS$]", stringBuilder.ToString());
                str7 = str7.Replace("[$SUPPLIER_NAME$]", this.lblSupplierName.Text);
                str7 = str7.Replace("[$ESTIMATE_NUMBER$]", this.lblEstNumber.Text);
                str7 = str7.Replace("[$SUPPLIER_RFQ_NUMBER$]", this.lblSupplierRefNo.Text);
                str7 = str7.Replace("[$ESTIMATE_TITLE$]", this.lblEstTitle.Text);
                str7 = str7.Replace("[$JOBCOMPLETION_DATE$]", this.commclass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$ITEM_TITLE$]", this.lblItemTitle.Text);
                str7 = str7.Replace("[$RFQ_RETURN_DATE$]", this.commclass.Eprint_return_Date_Before_View(item["RFQReturnDate"].ToString(), this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$QUANTITY1$]", this.lblQuantity1.Text);
                str7 = str7.Replace("[$QUANTITY2$]", this.lblQuantity2.Text);
                str7 = str7.Replace("[$QUANTITY3$]", this.lblQuantity3.Text);
                str7 = str7.Replace("[$QUANTITY4$]", this.lblQuantity4.Text);
                str7 = str7.Replace("[$PRICE1$]", this.txtPriceEx1.Text);
                str7 = str7.Replace("[$PRICE2$]", this.txtPriceEx2.Text);
                str7 = str7.Replace("[$PRICE3$]", this.txtPriceEx3.Text);
                str7 = str7.Replace("[$PRICE4$]", this.txtPriceEx4.Text);
                str7 = str7.Replace("[$DELIVERY_DATE1$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery1.Text, this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$DELIVERY_DATE2$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery2.Text, this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$DELIVERY_DATE3$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery3.Text, this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$DELIVERY_DATE4$]", this.commclass.Eprint_return_Date_Before_View(this.txtDelivery4.Text, this.CompanyID, this.UserID, false));
                str7 = str7.Replace("[$DELIVERY_INCLUDED1$]", empty);
                str7 = str7.Replace("[$DELIVERY_INCLUDED2$]", str);
                str7 = str7.Replace("[$DELIVERY_INCLUDED3$]", empty1);
                str7 = str7.Replace("[$DELIVERY_INCLUDED4$]", str1);
                str7 = str7.Replace("[$DELIVERY_COST1$]", this.txtDelCost1.Text);
                str7 = str7.Replace("[$DELIVERY_COST2$]", this.txtDelCost2.Text);
                str7 = str7.Replace("[$DELIVERY_COST3$]", this.txtDelCost3.Text);
                str7 = str7.Replace("[$DELIVERY_COST4$]", this.txtDelCost4.Text);
                str7 = str7.Replace("[$SUPPLIER_COMMENTS$]", this.txtComments.Text);
                str7 = str7.Replace("[$QUOTE_LINK$]", this.QuoteLink);
                str7 = str7.Replace("[$ITEMDESCRIPTION_DETAILS$]", stringBuilder.ToString());
                BaseClass.SendMailMessage(empty5, text4, empty6, empty7, str7, str6, empty8, true);
            }
            if (!base.Request.QueryString.ToString().Contains("type"))
            {
                base.Response.Redirect(string.Concat(absoluteUri, "&&type=", this.lbl_QuoteStats.Text));
                return;
            }
            absoluteUri = absoluteUri.Remove(absoluteUri.Length - 1);
            base.Response.Redirect(string.Concat(absoluteUri, this.lbl_QuoteStats.Text));
        }

        public void Message_Display(string strMsg, string cssclass, PlaceHolder plh)
        {
            plh.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/Usercontrol/message_display.ascx");
            plh.Controls.Add(userControl);
            Timer timer = (Timer)userControl.FindControl("TimerMessage");
            Label label = (Label)userControl.FindControl("lblMessage");
            Panel panel = (Panel)userControl.FindControl("pnlMessage");
            timer.Enabled = false;
            panel.CssClass = cssclass;
            timer.Interval = 5000;
            label.Text = strMsg;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtDelivery4.Attributes.Add("readonly", "readonly");
            this.txtDelivery3.Attributes.Add("readonly", "readonly");
            this.txtDelivery2.Attributes.Add("readonly", "readonly");
            this.txtDelivery1.Attributes.Add("readonly", "readonly");
            this.chkIAgree.Checked = false;
            this.lblQuoteNumber.Text = this.objLangClass.GetLanguageConversion("Your_Quote_Number").ToString();
            if (base.Request.QueryString == null || !(base.Request.QueryString.ToString() != ""))
            {
                this.DivError.Visible = true;
                this.DivNotAvailable.Visible = true;
                this.DivWrongKey.Visible = false;
                this.DivHideAll.Visible = false;
            }
            else
            {
                if (base.Request.Params["KeyCD"] == null)
                {
                    this.DivError.Visible = true;
                    this.DivNotAvailable.Visible = true;
                    this.DivWrongKey.Visible = false;
                    this.DivHideAll.Visible = false;
                    return;
                }
                if (!(base.Request.Params["KeyCD"].ToString() != "") || base.Request.Params["KeyCD"].ToString() == null)
                {
                    this.DivError.Visible = true;
                    this.DivNotAvailable.Visible = false;
                    this.DivWrongKey.Visible = true;
                    this.DivHideAll.Visible = false;
                    return;
                }
                this.KeyCode = base.Request.Params["KeyCD"].ToString();
                if (EstimateBasePage.KeyCode_Check(this.KeyCode) <= 0)
                {
                    this.DivError.Visible = true;
                    this.DivNotAvailable.Visible = false;
                    this.DivWrongKey.Visible = true;
                    this.DivHideAll.Visible = false;
                    return;
                }
                DataSet dataSet = new DataSet();
                dataSet = EstimateBasePage.SupplierQuote_Details(this.KeyCode);
                DataTable item = dataSet.Tables[1];
                if (item.Rows[0]["CompanyID"].ToString() == "")
                {
                    this.DivError.Visible = true;
                    this.DivNotAvailable.Visible = false;
                    this.DivWrongKey.Visible = true;
                    this.DivHideAll.Visible = false;
                    return;
                }
                this.Session["CompanyID"] = Convert.ToInt16(item.Rows[0]["CompanyID"].ToString());
                this.Session["email"] = item.Rows[0]["EmailID"].ToString();
                this.CompanyID = Convert.ToInt16(item.Rows[0]["CompanyID"].ToString());
                this.UserID = Convert.ToInt16(item.Rows[0]["EmailSentBy"].ToString());
                DataTable dataTable = EstimateBasePage.select_IssupplierQuote(Convert.ToInt64(item.Rows[0]["CompanyID"].ToString()));
                if (dataTable.Rows.Count <= 0)
                {
                    this.IsSupplierQuote = "False";
                }
                else
                {
                    bool flag = Convert.ToBoolean(dataTable.Rows[0]["IssupplierQuote"]);
                    this.IsSupplierQuote = flag.ToString();
                }
                if (this.IsSupplierQuote.ToLower() == "false")
                {
                    this.DivError.Visible = true;
                    this.DivNotAvailable.Visible = true;
                    this.DivWrongKey.Visible = false;
                    this.DivHideAll.Visible = false;
                    this.div_Welcome.Visible = false;
                    return;
                }
                this.isAuthentic.Text = "authentic";
                this.DivError.Visible = false;
                this.DivHideAll.Visible = true;
                this.div_Welcome.Visible = true;
                if (!base.IsPostBack)
                {
                    this.GetEstimateDetails(this.KeyCode);
                    if (base.Request.QueryString.ToString().Contains("type"))
                    {
                        string str = base.Request.Params["type"].ToString();
                        if (str == "i")
                        {
                            this.Message_Display("Quote Sent Successfully", "msg-success", this.plhMessage);
                            return;
                        }
                        if (str == "u")
                        {
                            this.Message_Display("Quote Sent Successfully", "msg-success", this.plhMessage);
                            return;
                        }
                        if (str == "r")
                        {
                            this.Message_Display("Quote Rejected Successfully", "msg-reject", this.plhMessage);
                            return;
                        }
                    }
                }
            }
        }
    }
}