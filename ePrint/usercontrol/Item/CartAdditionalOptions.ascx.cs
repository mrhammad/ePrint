using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Order;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class CartAdditionalOptions : UserControl
    {
        //protected PlaceHolder ph_CartAdditional;

        //protected PlaceHolder plh_CartItems;

        //protected Button btnSave;

        //protected HiddenField hdn_ddlValue;

        //protected HiddenField hdn_lblValue;

        //protected HiddenField hdn_IsFormula;

        //protected HiddenField hdn_NoOfCartItems;

        //protected HtmlGenericControl div_CartAddOptionID;

        private BaseClass objBase = new BaseClass();

        public commonClass commclass = new commonClass();

        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int cnt_CartAdditional;

        public int CartAdditional_Length;

        public int IsFormula;

        public string strSitepath = global.sitePath();

        public string FormulaTagMul = string.Empty;

        public string strReplace = string.Empty;

        public string IsVisibleToCart = string.Empty;

        public decimal TotalExTax;

        public decimal TotalIncTax;

        public int TotalQuantity;

        public long EstimateID;

        public long OrderID;

        public long OptionID;

        public string Formula = string.Empty;

        public long Markup;

        public decimal TotalPrice;

        public long SelectedID;

        public string SelectedValue = string.Empty;

        public decimal MarkupValue;

        public int SortOrderNo;

        public decimal SelectedPrice;

        public long OrderedQuantity;

        public string modulename = "";

        public string submodulename = "";

        public decimal TotalExGst;

        public decimal TotalIncGst;

        public long OrderItemID;

        public decimal TaxValue;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long OrderAdditionalTaxID;

        public decimal OrderAdditionalTaxPercentage;

        public decimal OrderAdditionalTaxValue;

        public languageClass objLanguage = new languageClass();

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

        public CartAdditionalOptions()
        {
        }

        protected void btnSave_Onclick(object sender, EventArgs e)
        {
            OrderBasePage.PC_OrderAdditionalOptions_Delete(this.OrderID);
            for (int i = 0; i <= this.cnt_CartAdditional - 1; i++)
            {
                int num = i;
                if (((CheckBox)this.FindControl(string.Concat("chk_CartAdditional_", num))).Checked)
                {
                    DropDownList dropDownList = (DropDownList)this.FindControl(string.Concat("ddl_CartAdditional_", num));
                    HiddenField hiddenField = (HiddenField)this.FindControl(string.Concat("hdnSelectedPrice_CartAdditional_", num));
                    HiddenField hiddenField1 = (HiddenField)this.FindControl(string.Concat("hdnTotaldPrice_CartAdditional_", num));
                    HiddenField hiddenField2 = (HiddenField)this.FindControl(string.Concat("hdnOrderAdditionalTaxValue_CartAdditional_", num));
                    HiddenField hiddenField3 = (HiddenField)this.FindControl(string.Concat("hdnAdditionalMarkupPrice_CartAdditional_", num));

                    TextBox txtPrice = (TextBox)this.FindControl(string.Concat("lbl_CartAdditional_", num));// Cost Price
                    TextBox txtMarkup = (TextBox)this.FindControl(string.Concat("txt_CartAdditionalmarkup_", num)); // Marup % txt_CartAdditionalmarkup

                    string[] strArrays = dropDownList.SelectedValue.Split(new char[] { '~' });
                    string selectedValue = dropDownList.SelectedValue;
                    //decimal num1 = Convert.ToDecimal(hiddenField3.Value);
                    decimal num1 = Convert.ToDecimal(txtMarkup.Text);
                    //decimal num2 = Convert.ToDecimal(hiddenField1.Value);
                    decimal num2 = Convert.ToDecimal(txtPrice.Text);
                    decimal num3 = Convert.ToDecimal(txtPrice.Text); // Selected Price
                    // Formula change
                    //string[] valuesArray =  selectedValue.Split('~');
                    // Total Price
     //               string[] strArrays = ddl.SelectedValue.Split(new char[] { '~' });
               
                    num2 = ((num2 * Convert.ToDecimal(txtMarkup.Text)) / new decimal(100)) + num2;
                    //
                    selectedValue = string.Concat(num3, '~', txtMarkup.Text, '~', strArrays[2]);
                    long num4 = (long)Convert.ToInt32(strArrays[2]);
                    string text = dropDownList.SelectedItem.Text; 
                    decimal num5 = (num3 * num1) / new decimal(100);
                    OrderBasePage.OrderAdditionalOptions_Update(this.OrderID, selectedValue, num1, num2, num4, text, num5, num, num3, this.OrderAdditionalTaxID, this.OrderAdditionalTaxPercentage, Convert.ToDecimal(hiddenField2.Value));
                }
            }
            OrderBasePage.PC_UpdateOrderAdditional_InOrders(this.OrderID);
            string empty = string.Empty;
            if (base.Request.QueryString["pg"] == "job")
            {
                object[] orderID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=edit&ordid=", this.OrderID, "&estid=", this.EstimateID };
                empty = string.Concat(orderID);
            }
            else if (base.Request.QueryString["pg"] == "invoice")
            {
                object[] objArray = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=edit&ordid=", this.OrderID, "&estid=", this.EstimateID };
                empty = string.Concat(objArray);
            }
            else if (base.Request.QueryString["pg"] == "webstoreorder")
            {
                object[] orderID1 = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID };
                empty = string.Concat(orderID1);
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showConfirm", string.Concat("javascript:windowclose('", empty, "');"), true);
        }

        public static double Calculate(string e)
        {
            e = e.Replace(".", ",");
            if (e.IndexOf("(") != -1)
            {
                int num = e.LastIndexOf("(");
                int num1 = e.IndexOf(")", num);
                double num2 = CartAdditionalOptions.Calculate(e.Substring(num + 1, num1 - num - 1));
                return CartAdditionalOptions.Calculate(string.Concat(e.Substring(0, num), num2.ToString(), e.Substring(num1 + 1)));
            }
            double num3 = 0;
            string[] strArrays = e.Split(new char[] { '+' });
            if ((int)strArrays.Length > 1)
            {
                num3 = CartAdditionalOptions.Calculate(strArrays[0]);
                for (int i = 1; i < (int)strArrays.Length; i++)
                {
                    num3 = num3 + CartAdditionalOptions.Calculate(strArrays[i]);
                }
                return num3;
            }
            string[] strArrays1 = strArrays[0].Split(new char[] { '-' });
            if ((int)strArrays1.Length > 1)
            {
                num3 = CartAdditionalOptions.Calculate(strArrays1[0]);
                for (int j = 1; j < (int)strArrays1.Length; j++)
                {
                    num3 = num3 - CartAdditionalOptions.Calculate(strArrays1[j]);
                }
                return num3;
            }
            string[] strArrays2 = strArrays1[0].Split(new char[] { '*' });
            if ((int)strArrays2.Length > 1)
            {
                num3 = CartAdditionalOptions.Calculate(strArrays2[0]);
                for (int k = 1; k < (int)strArrays2.Length; k++)
                {
                    num3 = num3 * CartAdditionalOptions.Calculate(strArrays2[k]);
                }
                return num3;
            }
            string[] strArrays3 = strArrays2[0].Split(new char[] { '/' });
            if ((int)strArrays3.Length <= 1)
            {
                return double.Parse(e);
            }
            num3 = CartAdditionalOptions.Calculate(strArrays3[0]);
            for (int l = 1; l < (int)strArrays3.Length; l++)
            {
                num3 = num3 / CartAdditionalOptions.Calculate(strArrays3[l]);
            }
            return num3;
        }

        private void Estimate_Additional_Price(int CartAdditionalLength, int CartAdditionalCount, string ddlValue, int cnt_CartAdditional, TextBox lbl, HiddenField hdnSelectedPrice, HiddenField hdnTotaldPrice, TextBox txtMarup, Label lblsellingprice)
        {
            if (CartAdditionalLength != 0)
            {
                for (int i = 0; i <= CartAdditionalLength - 1; i++)
                {
                    Label label = new Label()
                    {
                        ID = string.Concat("lblMultipleID_", i)
                    };
                    string[] strArrays = ddlValue.Split(new char[] { '~' });
                    string str = strArrays[0];
                    if (str == "" && str == "0")
                    {
                        label.Text = "0.00";
                    }
                    else if (str.ToLower() == "---select---")
                    {
                        label.Text = "0.00";
                    }
                    else if (str == "" || str == "0")
                    {
                        label.Text = "0.00";
                    }
                    else
                    {
                        this.FormulaTagMul = strArrays[0].ToString();
                        for (int j = 0; j <= (int)strArrays.Length; j++)
                        {
                            this.FormulaTagMul = this.FormulaTagMul.Replace("[$TotalEx.GST$]", this.TotalExTax.ToString()).Replace("[$totalex.gst$]", this.TotalExTax.ToString()).Replace("[$TotalInc.GST$]", this.TotalIncTax.ToString()).Replace("[$totalinc.gst$]", this.TotalIncTax.ToString()).Replace("[$TotalQty$]", this.TotalQuantity.ToString()).Replace("[$totalqty$]", this.TotalQuantity.ToString()).Replace("[$TotalNo.ofCartItems$]", this.hdn_NoOfCartItems.Value.ToString()).Replace("[$totalno.ofcartitems$]", this.hdn_NoOfCartItems.Value.ToString());
                        }
                        string str1 = this.FormulaTagMul.Trim();
                        if (str1.Contains("(") || str1.Contains(")"))
                        {
                            this.strReplace = str1.Replace('(', ' ').Replace(')', ' ');
                            if (!this.strReplace.ToString().Contains("="))
                            {
                                str1 = this.strReplace.ToString().Trim();
                            }
                            else
                            {
                                string[] strArrays1 = this.strReplace.Split(new char[] { '=' });
                                str1 = strArrays1[1].ToString().Trim();
                            }
                        }
                        string str2 = CartAdditionalOptions.Evaluate(str1);
                        hdnSelectedPrice.Value = str2;
                        decimal num = Convert.ToDecimal(str2);
                        decimal num1 = (Convert.ToDecimal(num) * Convert.ToDecimal(this.Markup)) / new decimal(100);
                        decimal num2 = Convert.ToDecimal(num) + Convert.ToDecimal(num1);
                        lbl.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num, 0, "", false, false, true);
                        txtMarup.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.Markup, 0, "", false, false, true);
                        lblsellingprice.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, true);
                        hdnTotaldPrice.Value = num2.ToString();
                    }
                }
            }
        }

        private void Estimate_Additional_Price1(DropDownList ddl, TextBox lbl, int CartAdditionalCount, HiddenField hdnSelectedPrice, HiddenField hdnTotaldPrice, TextBox txtMarkup, Label lblsellingprice)
        {
            ddl.ID = string.Concat("ddl_CartAdditional_", CartAdditionalCount);
            lbl.ID = string.Concat("lbl_CartAdditional_", this.cnt_CartAdditional);
            try
            {
                string[] strArrays = ddl.SelectedValue.Split(new char[] { '~' });
                decimal num = Convert.ToDecimal(strArrays[0]);
                hdnSelectedPrice.Value = num.ToString();
                decimal num1 = Convert.ToDecimal(strArrays[1]);
                decimal num2 = ((num * num1) / new decimal(100)) + num;
                lbl.Text = Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num, 0, "", false, false, true));
                txtMarkup.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num1, 0, "", false, false, true);
                lblsellingprice.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, true);
                hdnTotaldPrice.Value = num2.ToString();
            }
            catch
            {
            }
        }

        public static string Evaluate(string e)
        {
            string str;
            if (e.Length == 0)
            {
                return "0";
            }
            if (e[0] == '-')
            {
                e = string.Concat("0", e);
            }
            string str1 = "";
            try
            {
                str1 = CartAdditionalOptions.Calculate(e).ToString();
                return str1;
            }
            catch
            {
                str = "The call caused an exception";
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "jobs";
                this.submodulename = "job";
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btnSave.Visible = false;
                }
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "orders";
                this.submodulename = "order";
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btnSave.Visible = false;
                }
            }
            else
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btnSave.Visible = false;
                }
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.OrderedQuantity = Convert.ToInt64(base.Session["Ordered_Quantity"]);
            if (base.Session["Markup"] != null)
            {
                this.Markup = Convert.ToInt64(base.Session["Markup"]);
            }
            if (base.Session["TotalExTax"] != null)
            {
                this.TotalExTax = Convert.ToInt32(base.Session["TotalExTax"]);
            }
            if (base.Session["TotalIncTax"] != null)
            {
                this.TotalIncTax = Convert.ToInt32(base.Session["TotalIncTax"]);
            }
            if (base.Session["AccountID"] != null)
            {
                this.AccountID = Convert.ToInt32(base.Session["AccountID"]);
            }
            if (base.Session["TotalQuantity"] != null)
            {
                this.TotalQuantity = Convert.ToInt32(base.Session["TotalQuantity"]);
            }
            if (base.Request.QueryString["Ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.QueryString["Ordid"]);
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"]);
            }
            if (base.Request.QueryString["OrderItemID"] != null)
            {
                this.OrderItemID = Convert.ToInt64(base.Request.QueryString["OrderItemID"]);
            }
            HiddenField hdnNoOfCartItems = this.hdn_NoOfCartItems;
            int count = EstimatesBasePage.EstimateitemIDList_PerEstID(this.EstimateID).Rows.Count;
            hdnNoOfCartItems.Value = count.ToString();
            foreach (DataRow row in OrderBasePage.Select_OrderItems_WithAdditionalItems(this.OrderItemID).Tables[0].Rows)
            {
                this.OrderAdditionalTaxID = Convert.ToInt64(row["Taxid"].ToString());
                this.OrderAdditionalTaxPercentage = Convert.ToDecimal(row["Tax"].ToString());
                this.TaxValue = Convert.ToDecimal(row["Tax"]);
            }
            decimal num = new decimal(0);
            DataTable dataTable = OrderBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, (long)this.AccountID, "yes");
            this.ph_CartAdditional.Controls.Add(new LiteralControl("<table cellspacing='25px'><tr>"));
            ControlCollection controls = this.ph_CartAdditional.Controls;
            string[] languageConversion = new string[] { "<td></td><td></td><td style='text-align:right;'><b>", this.objLanguage.GetLanguageConversion("Cost_price"), "</b></td><td style='text-align:right;'><b>", this.objLanguage.GetLanguageConversion("Markup"), " (%)</b></td><td style='text-align:right;'><b>", this.objLanguage.GetLanguageConversion("Selling_Price"), "</b></td></tr>" };
            controls.Add(new LiteralControl(string.Concat(languageConversion)));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                DataSet dataSet = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataRow["WebOtherCostID"].ToString()), this.OrderID);
                DataTable item = dataSet.Tables[0];
                DataTable item1 = dataSet.Tables[1];
                DataTable dataTable1 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.OrderID);
                long num1 = (long)0;
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    if (Convert.ToInt32(row1["OptionID"]) != Convert.ToInt32(dataRow["WebOtherCostID"].ToString()))
                    {
                        continue;
                    }
                    num1 = (long)Convert.ToInt32(row1["OrderAdditionalOptionID"]);
                    this.SelectedValue = row1["SelectedValue"].ToString();
                    this.Formula = Convert.ToString(row1["Formula"]);
                    this.TotalExGst = Convert.ToDecimal(row1["OrderIncmarkup"]);
                    num = (this.TotalExGst * this.TaxValue) / new decimal(100);
                    this.TotalIncGst = this.TotalExGst + num;
                }
                this.CartAdditional_Length = item1.Rows.Count;
                Convert.ToInt64(dataRow["WebOtherCostID"].ToString());
                this.IsVisibleToCart = dataRow["VisibletoCart"].ToString();
                CheckBox checkBox = new CheckBox()
                {
                    ID = string.Concat("chk_CartAdditional_", this.cnt_CartAdditional),
                    Text = this.objBase.SpecialDecode(dataRow["UserFriendlyName"].ToString())
                };
                DropDownList dropDownList = new DropDownList()
                {
                    ID = string.Concat("ddl_CartAdditional_", this.cnt_CartAdditional),
                    Width = 250,
                    CssClass = "normaltext"
                };
                foreach (DataRow dataRow1 in item1.Rows)
                {
                    if (dataRow1["Label"] == null)
                    {
                        continue;
                    }
                    dataRow1["Label"] = this.objBase.SpecialDecode(dataRow1["Label"].ToString());
                }
                dropDownList.DataSource = item1;
                dropDownList.DataTextField = "Label";
                dropDownList.DataValueField = "FormulaNew";
                dropDownList.DataBind();
                // On CHange
                TextBox textBox = new TextBox()
                {
                    ID = string.Concat("lbl_CartAdditional_", this.cnt_CartAdditional),
                    Text = "0.00",
                    Width = 75
                };
                textBox.Style.Add("text-align", "right");
                // On CHange
                TextBox textBox1 = new TextBox()
                {
                    ID = string.Concat("txt_CartAdditionalmarkup_", this.cnt_CartAdditional),
                    Text = "0.00",
                    Width = 75
                };
                textBox1.Style.Add("text-align", "right");

                // Adding Attributes to the Price and Mark up Text Box 
                AttributeCollection priceAttributes = textBox.Attributes;
                object[] textBoxPriceAttribute = new object[] { "javascript:onPriceOrMarkupChange(", this.cnt_CartAdditional +");" };
                priceAttributes.Add("onchange", string.Concat(textBoxPriceAttribute));

                AttributeCollection markupAttributes = textBox1.Attributes;
                object[] textBoxMarkupAttribute = new object[] { "javascript:onPriceOrMarkupChange(", this.cnt_CartAdditional, ");" };
                markupAttributes.Add("onchange", string.Concat(textBoxMarkupAttribute));
                ///////////
                Label label = new Label()
                {
                    ID = string.Concat("lbl_sellingprice_", this.cnt_CartAdditional),
                    Text = "0.00",
                    Width = 75
                };
                label.Style.Add("text-align", "right");
                HiddenField hiddenField = new HiddenField()
                {
                    ID = string.Concat("hdnSelectedPrice_CartAdditional_", this.cnt_CartAdditional),
                    Value = "0.00"
                };
                HiddenField hiddenField1 = new HiddenField()
                {
                    ID = string.Concat("hdnTotaldPrice_CartAdditional_", this.cnt_CartAdditional),
                    Value = "0.00"
                };
                HiddenField hiddenField2 = new HiddenField()
                {
                    ID = string.Concat("hdnOrderAdditionalTaxValue_CartAdditional_", this.cnt_CartAdditional),
                    Value = "0.00"
                };
                HiddenField hiddenField3 = new HiddenField()
                {
                    ID = string.Concat("hdnAdditionalMarkupPrice_CartAdditional_", this.cnt_CartAdditional),
                    Value = "0.00"
                };
                if (num1 > (long)0)
                {
                    this.SetDDLText(dropDownList, this.SelectedValue);
                    checkBox.Checked = true;
                }
                else if (item1.Rows.Count > 0)
                {
                    this.Formula = item1.Rows[0]["FormulaNew"].ToString();
                }
                if (this.Formula.Contains("[$TotalEx.GST$]") || this.Formula.Contains("[$TotalQty$]") || this.Formula.Contains("[$TotalInc.GST$]") || this.Formula.Contains("[$TotalNo.ofCartItems$]"))
                {
                    this.Estimate_Additional_Price(this.CartAdditional_Length, this.cnt_CartAdditional, Convert.ToString(this.Formula), this.cnt_CartAdditional, textBox, hiddenField, hiddenField1, textBox1, label);
                    this.IsFormula = 1;
                }
                else
                {
                    this.Estimate_Additional_Price1(dropDownList, textBox, this.cnt_CartAdditional, hiddenField, hiddenField1, textBox1, label);
                }
                this.ph_CartAdditional.Controls.Add(new LiteralControl("<tr><td>"));
                this.ph_CartAdditional.Controls.Add(checkBox);
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td><td>"));
                this.ph_CartAdditional.Controls.Add(dropDownList);
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td><td style='text-align:right;'>"));
                this.ph_CartAdditional.Controls.Add(textBox);
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td>"));
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td><td>"));
                this.ph_CartAdditional.Controls.Add(textBox1);
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td>"));
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td><td>"));
                this.ph_CartAdditional.Controls.Add(label);
                this.ph_CartAdditional.Controls.Add(new LiteralControl("</td></tr>"));
                this.ph_CartAdditional.Controls.Add(hiddenField);
                this.ph_CartAdditional.Controls.Add(hiddenField1);
                this.ph_CartAdditional.Controls.Add(hiddenField2);
                this.ph_CartAdditional.Controls.Add(hiddenField3);
                AttributeCollection attributes = dropDownList.Attributes;
                object[] cntCartAdditional = new object[] { "javascript:Cart_Additional_Price('", this.cnt_CartAdditional, "','", this.IsFormula, "');Cart_Additional_Price_onblur('", this.cnt_CartAdditional, "','", this.IsFormula, "');" };
                attributes.Add("onchange", string.Concat(cntCartAdditional));
                AttributeCollection attributeCollection = textBox1.Attributes;
                object[] objArray = new object[] { "javascript:Cart_Additional_Price_onblur('", this.cnt_CartAdditional, "','", this.IsFormula, "');" };
                attributeCollection.Add("onblur", string.Concat(objArray));
                AttributeCollection attributes1 = textBox.Attributes;
                object[] cntCartAdditional1 = new object[] { "javascript:Cart_Additional_Price_onblur('", this.cnt_CartAdditional, "','", this.IsFormula, "');" };
                attributes1.Add("onblur", string.Concat(cntCartAdditional1));
                CartAdditionalOptions usercontrolItemCartAdditionalOption = this;
                usercontrolItemCartAdditionalOption.cnt_CartAdditional = usercontrolItemCartAdditionalOption.cnt_CartAdditional + 1;
            }
            this.ph_CartAdditional.Controls.Add(new LiteralControl("</table>"));
        }

        public void SetDDLText(DropDownList ddl, string text)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByText(text);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
                ddl.SelectedItem.Text = this.SelectedValue;
            }
            catch
            {
            }
        }

        public void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        public static bool VerifyAllowed(string e)
        {
            string str = "0123456789+-*/().,";
            for (int i = 0; i < e.Length; i++)
            {
                if (str.IndexOf(string.Concat(e[i])) == -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}