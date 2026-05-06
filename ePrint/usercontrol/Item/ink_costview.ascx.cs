using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
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
using Telerik.Web.UI;
namespace ePrint.usercontrol.Item
{
    public partial class ink_costview : UsercontrolBasePage
    {
        public long PressID;

        public long EstimateItemID;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

        public int CompanyID;

        public int UserID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public string prevSide = string.Empty;

        public string prevQty = string.Empty;

        public string prevQtyNo = string.Empty;

        public int i = 1;

        public commonClass comm = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string ItemFrom = string.Empty;

        public string IsDoubleSide = "no";

        public string Section = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private string PaperMeasure = string.Empty;

        public BasePage ObjPage = new BasePage();

        public string IsFromeStore = string.Empty;

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

        public ink_costview()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (base.Request.Params["From"] != null)
            {
                if (string.Compare(base.Request.Params["From"].ToString(), "li", true) == 0)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    string empty = string.Empty;
                    base.Request.Params["item"].ToString();
                }
                this.ItemFrom = base.Request.Params["From"].ToString();
            }
            long num = (long)0;
            string str = string.Empty;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            for (int i = 0; i < this.GridInkCostView.Items.Count; i++)
            {
                HiddenField hiddenField = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdn_MarkupPrice");
                HiddenField hiddenField1 = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdn_CostExMarkup");
                HiddenField hiddenField2 = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdn_CostExMarkup_Actual");
                TextBox textBox = (TextBox)this.GridInkCostView.Items[i].FindControl("txt_Markup");
                HiddenField hiddenField3 = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdn_EstimateCalculationID");
                HiddenField hiddenField4 = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdn_EstimateInkCalcId");
                HiddenField hiddenField5 = (HiddenField)this.GridInkCostView.Items[i].FindControl("hdnQty");
                num = Convert.ToInt64(hiddenField3.Value);
                int num13 = Convert.ToInt32(hiddenField5.Value);
                if (num13 == 1)
                {
                    num1 = num1 + Convert.ToDecimal(hiddenField.Value);
                    num5 = num5 + Convert.ToDecimal(hiddenField1.Value);
                    num9 = num9 + Convert.ToDecimal(hiddenField2.Value);
                }
                else if (num13 == 2)
                {
                    num2 = num2 + Convert.ToDecimal(hiddenField.Value);
                    num6 = num6 + Convert.ToDecimal(hiddenField1.Value);
                    num10 = num10 + Convert.ToDecimal(hiddenField2.Value);
                }
                else if (num13 == 3)
                {
                    num3 = num3 + Convert.ToDecimal(hiddenField.Value);
                    num7 = num7 + Convert.ToDecimal(hiddenField1.Value);
                    num11 = num11 + Convert.ToDecimal(hiddenField2.Value);
                }
                else if (num13 == 4)
                {
                    num4 = num4 + Convert.ToDecimal(hiddenField.Value);
                    num8 = num8 + Convert.ToDecimal(hiddenField1.Value);
                    num12 = num12 + Convert.ToDecimal(hiddenField2.Value);
                }
                EstimatesBasePage.PCR_estimates_markup_calculation_update_forInk(Convert.ToDecimal(hiddenField1.Value), Convert.ToDecimal(textBox.Text), Convert.ToDecimal(hiddenField.Value), Convert.ToDecimal(hiddenField2.Value), num13, Convert.ToInt64(hiddenField4.Value), this.Module);
            }
            str = "ink";
            EstimatesBasePage.estimates_markup_calculation_update(this.CompanyID, num, new decimal(0), str, this.TypeID, this.EstType, new decimal(0), new decimal(0), new decimal(0), num1, num2, num3, num4, num5, num6, num7, num8, this.Module, num9, num10, num11, num12);
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void GridInkCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["SellingPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["UnitPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["CostPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Cost_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["SetupCost"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Setup_Cost"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_Sides");
                Label text = (Label)e.Item.FindControl("lbl_qty");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdninkType");
                Label label1 = (Label)e.Item.FindControl("lbl_CostPrice");
                Label label2 = (Label)e.Item.FindControl("lbl_SellingPrice");
                Label label3 = (Label)e.Item.FindControl("lbl_SetupCost");
                Label label4 = (Label)e.Item.FindControl("lbl_InkCoverage1");
                Label label5 = (Label)e.Item.FindControl("lbl_InkCoverage2");
                Label label6 = (Label)e.Item.FindControl("lbl_UnitPrice");
                Label label7 = (Label)e.Item.FindControl("lbl_MinCharge");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnQty");
                Label label8 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                Label label9 = (Label)e.Item.FindControl("lbl_paperlength");
                TextBox textBox = (TextBox)e.Item.FindControl("txt_Markup");
                textBox.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox.Text.ToString()), 0, "", false, false, true);
                textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Ink(this);");
                textBox.Attributes.Add("onclick", "javascript:this.select();");
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label7.Text), 0, "", false, false, true);
                label8.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label8.Text), 0, "", false, false, true);
                if (label3.Text == "")
                {
                    label3.Text = "0";
                }
                label3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text.ToString()), 0, "", false, false, true);
                label4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text.ToString()), 0, "", false, false, true);
                label5.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label5.Text.ToString()), 0, "", false, false, true);
                label9.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label9.Text.ToString()), 0, "", false, false, true);
                string str = text.Text;
                string text1 = label.Text;
                string value = hiddenField1.Value;
                if (hiddenField.Value.ToLower() == "m")
                {
                    label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text.ToString()), 0, "", false, false, true);
                    label6.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label6.Text.ToString()), 0, "", false, false, true);
                }
                if (this.IsDoubleSide != "yes")
                {
                    if (this.prevQtyNo == hiddenField1.Value)
                    {
                        text.Text = "";
                        label9.Text = "";
                    }
                    if (this.prevSide.ToLower() == label.Text.ToLower())
                    {
                        label.Text = "";
                    }
                }
                else
                {
                    if (this.prevSide.ToLower() == label.Text.ToLower())
                    {
                        label.Text = "";
                    }
                    else if (label.Text.ToLower() == "side1")
                    {
                        label.Text = "Side 1";
                    }
                    else if (label.Text.ToLower() == "side2")
                    {
                        label.Text = "Side 2";
                    }
                    if (text.Text.ToLower() != this.prevQty.ToLower())
                    {
                        text.Text = text.Text;
                        ink_costview usercontrolItemInkCostview = this;
                        usercontrolItemInkCostview.i = usercontrolItemInkCostview.i + 1;
                    }
                    else
                    {
                        text.Text = "";
                        label9.Text = "";
                    }
                }
                this.prevSide = text1.ToString();
                this.prevQty = str.ToString();
                this.prevQtyNo = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridInkCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
            this.GridInkCostView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Sides");
            this.GridInkCostView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Ink_Name");
            this.GridInkCostView.Columns[8].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (%)");
            this.GridInkCostView.Columns[9].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInkCostView.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Minimum_Charge");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.PressID = Convert.ToInt64(base.Request.QueryString["PressID"].ToString());
            this.EstType = base.Request.QueryString["EstType"].ToString();
            this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["EstimateItemID"].ToString());
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            if (this.EstType.ToLower() == "l")
            {
                this.GridInkCostView.MasterTableView.Columns[1].Visible = true;
            }
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                this.JobID = Convert.ToInt64(row["JOBID"]);
                this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
            }
            this.Module = base.Request.QueryString["Module"].ToString();
            if (base.Request.QueryString["Sectioncount"] != null)
            {
                this.Section = base.Request.QueryString["Sectioncount"].ToString();
            }
            DataSet dataSet = EstimatesBasePage.PCR_Ink_Cost_ViewOnPopUp(this.PressID, this.EstimateItemID, this.EstType, this.TypeID, this.Module, this.Section);
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count > 0)
            {
                if (item.Rows[0]["calculationType"].ToString().ToLower().Trim() != "square" && item.Rows[0]["calculationType"].ToString().ToLower().Trim() != "tilling")
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridInkCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Length_Meter");
                    }
                    else
                    {
                        this.GridInkCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Length_feet");
                    }
                    this.GridInkCostView.Columns[7].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
                else if (item.Rows[0]["calculationType"].ToString().ToString().ToLower() == "tilling")
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridInkCostView.Columns[1].HeaderText = "Stock Area (sq m)";
                    }
                    else
                    {
                        this.GridInkCostView.Columns[1].HeaderText = "Stock Area (sq ft)";
                    }
                }
                else
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridInkCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_Meter");
                    }
                    else
                    {
                        this.GridInkCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_feet");
                    }
                    this.GridInkCostView.Columns[7].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("unit_sq_meters"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
                if (item.Rows[0]["side"].ToString().ToLower().Trim() == "double")
                {
                    this.IsDoubleSide = "yes";
                }
                else if (item.Rows[0]["side"].ToString().ToLower().Trim() == "single" || item.Rows[0]["side"].ToString().ToLower().Trim() == "sigle")
                {
                    this.IsDoubleSide = "no";
                    this.trHeading2.Style.Add("display", "none");
                }
                string str = dataSet.Tables[0].Rows[0]["Side1color"].ToString().ToLower().Trim();
                string str1 = dataSet.Tables[0].Rows[0]["Side2color"].ToString().ToLower().Trim();
                if (str == "" && str1 == "")
                {
                    this.trHeading1.Style.Add("display", "none");
                    this.trHeading2.Style.Add("display", "none");
                }
                if (str == "color")
                {
                    str = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                }
                else if (str == "swhite")
                {
                    str = "Single Special";
                }
                else if (str == "dwhite")
                {
                    str = "Double Special";
                }
                else if (str == "colourwithswhite")
                {
                    str = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Special");
                }
                else if (str == "colourwithdwhite")
                {
                    str = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Double Special");
                }
                if (str1 == "color")
                {
                    str1 = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                }
                else if (str1 == "swhite")
                {
                    str1 = "Single Special";
                }
                else if (str1 == "dwhite")
                {
                    str1 = "Double Special";
                }
                else if (str1 == "colourwithswhite")
                {
                    str1 = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Special");
                }
                else if (str1 == "colourwithdwhite")
                {
                    str1 = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Double Special");
                }
                this.lblSide1color.Text = this.objBase.SpecialDecode(str);
                this.lblSide2color.Text = this.objBase.SpecialDecode(str1);
                if (this.EstType.ToLower() == "l")
                {
                    this.GridInkCostView.MasterTableView.Columns[7].Visible = false;
                    this.GridInkCostView.MasterTableView.Columns[2].Visible = false;
                }
                else if (item.Rows[0]["InkType"].ToString().ToLower() == "y")
                {
                    this.GridInkCostView.MasterTableView.Columns[2].Visible = true;
                    this.GridInkCostView.MasterTableView.Columns[4].Visible = true;
                    this.GridInkCostView.MasterTableView.Columns[5].Visible = true;
                }
                else if (item.Rows[0]["InkType"].ToString().ToLower() == "m")
                {
                    this.GridInkCostView.MasterTableView.Columns[2].Visible = true;
                    this.GridInkCostView.MasterTableView.Columns[10].Visible = true;
                }
            }
            this.GridInkCostView.DataSource = item;
            this.GridInkCostView.DataBind();
            DataTable dataTable = dataSet.Tables[1];
            if (dataTable.Rows.Count > 0)
            {
                this.plhTotalSellingPrice.Controls.Add(new LiteralControl(string.Concat(" <table width='250px'><tr><td align='right'><strong>Quantity</strong></td><td align='right'><strong>Total Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></td></tr>")));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ControlCollection controls = this.plhTotalSellingPrice.Controls;
                    string[] strArrays = new string[] { "<tr><td align='right'>", dataRow["quantity"].ToString(), "</td><td align='right'>", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["totalSellingPrice"].ToString()), 0, "", false, false, true), true), "</td></tr>" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                this.plhTotalSellingPrice.Controls.Add(new LiteralControl("</table>"));
            }
            if (this.Module.ToLower() == "job")
            {
                this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.JobID, "jobs");
            }
            if (this.Module.ToLower() == "invoice")
            {
                this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            }
        }
    }
}