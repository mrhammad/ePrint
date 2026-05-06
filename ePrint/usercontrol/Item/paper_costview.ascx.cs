using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.Calculations;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
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
    public partial class paper_costview : UsercontrolBasePage
    {
        public int paperID;

        public long EstimateItemID;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

        public int CompanyID;

        public int UserID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public int RowNo;

        public commonClass comm = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string ItemFrom = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private BasePage ObjPage = new BasePage();

        public int rowNo = 1;

        public bool IsPaperUnitPriceLocked;

        public long QtyID;

        public long EstimateCalculationID;

        public string ProfitTaxKey = string.Empty;

        public string[] arrQty = new string[4];

        public string[] arrInvSheets = new string[4];

        public string[] arrPrintSheets = new string[4];

        public string[] arrMarkUp = new string[4];

        public bool iseditUnitprice;

        public bool IsPricePerPack;

        public string paperType = string.Empty;

        private string LargeFormatCalculation = string.Empty;

        private string _firstPaperType = string.Empty;

        private string PaperMeasure = string.Empty;

        public string IsFromeStore = string.Empty;
        private Hashtable htInventory = new Hashtable();

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

        public paper_costview()
        {
        }


        public void update_printSheets()
        {

            decimal[] array_printSheets = new decimal[4];
            decimal[] array_printSheetsPrize = new decimal[4];

            int num1 = 0;
            Int64 quantityID = 0;
            decimal number = new decimal(0);
            for (int i = 0; i < 4; i++)
            {


                if (i < this.GridPaperCostView.Items.Count)
                {

                    TextBox textBox_Print_Sheets = (TextBox)this.GridPaperCostView.Items[i].FindControl("txtPrintSheets");

                    HiddenField hiddenField1 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdn_CostExMarkup");

                    HiddenField hiddenField3 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdnQtyNumber");
                    num1 = Convert.ToInt32(hiddenField3.Value);

                    HiddenField hiddenField7 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdn_QuantityID");
                    quantityID = Convert.ToInt64(hiddenField7.Value);
                    number = Convert.ToDecimal(textBox_Print_Sheets.Text);
                    if (num1 == 1)
                    {
                        array_printSheets[0] = Convert.ToDecimal(textBox_Print_Sheets.Text);
                        array_printSheetsPrize[0] = Convert.ToDecimal(hiddenField1.Value);
                    }
                    else if (num1 == 2)
                    {
                        array_printSheets[1] = Convert.ToDecimal(textBox_Print_Sheets.Text);
                        array_printSheetsPrize[1] = Convert.ToDecimal(hiddenField1.Value);
                    }
                    else if (num1 == 3)
                    {
                        array_printSheets[2] = Convert.ToDecimal(textBox_Print_Sheets.Text);
                        array_printSheetsPrize[2] = Convert.ToDecimal(hiddenField1.Value);
                    }
                    else if (num1 != 4)
                    {
                        array_printSheets[i] = new decimal(0);
                        array_printSheetsPrize[i] = new decimal(0);
                    }
                    else
                    {
                        array_printSheets[3] = Convert.ToDecimal(textBox_Print_Sheets.Text);
                        array_printSheetsPrize[3] = Convert.ToDecimal(hiddenField1.Value);
                    }

                }
            }
            EstimatesBasePage.updatePrintSheets(array_printSheets[0], array_printSheets[1], array_printSheets[2], array_printSheets[3], quantityID, array_printSheetsPrize[0], array_printSheetsPrize[1], array_printSheetsPrize[2], array_printSheetsPrize[3]);
            this.comm.UpdateActivityHistoryForInventory(this.EstimateItemID, number, "h");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (base.Request.Params["From"] != null)
            {
                if (string.Compare(base.Request.Params["From"].ToString(), "li", true) == 0)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    string empty = string.Empty;
                    base.Request.Params["item"].ToString();
                }
                this.ItemFrom = base.Request.Params["From"].ToString();
            }
            long num = (long)0;
            string str = string.Empty;
            int num1 = 0;
            decimal[] numArray = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] num2 = new decimal[4];
            long[] numArray2 = new long[4];
            for (int i = 0; i < 4; i++)
            {
                if (i < this.GridPaperCostView.Items.Count)
                {
                    HiddenField hiddenField = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdn_MarkupPrice");
                    HiddenField hiddenField1 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdn_CostExMarkup");
                    TextBox textBox = (TextBox)this.GridPaperCostView.Items[i].FindControl("txt_Markup");
                    HiddenField hiddenField2 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdn_EstimateCalculationID");
                    HiddenField hiddenField3 = (HiddenField)this.GridPaperCostView.Items[i].FindControl("hdnQtyNumber");
                    num1 = Convert.ToInt32(hiddenField3.Value);
                    if (num1 == 1)
                    {
                        numArray[0] = Convert.ToDecimal(hiddenField.Value);
                        numArray1[0] = Convert.ToDecimal(hiddenField1.Value);
                        num2[0] = Convert.ToDecimal(textBox.Text);
                        numArray2[0] = Convert.ToInt64(hiddenField2.Value);
                    }
                    else if (num1 == 2)
                    {
                        numArray[1] = Convert.ToDecimal(hiddenField.Value);
                        numArray1[1] = Convert.ToDecimal(hiddenField1.Value);
                        num2[1] = Convert.ToDecimal(textBox.Text);
                        numArray2[1] = Convert.ToInt64(hiddenField2.Value);
                    }
                    else if (num1 == 3)
                    {
                        numArray[2] = Convert.ToDecimal(hiddenField.Value);
                        numArray1[2] = Convert.ToDecimal(hiddenField1.Value);
                        num2[2] = Convert.ToDecimal(textBox.Text);
                        numArray2[2] = Convert.ToInt64(hiddenField2.Value);
                    }
                    else if (num1 != 4)
                    {
                        numArray[i] = new decimal(0);
                        numArray1[i] = new decimal(0);
                        num2[i] = new decimal(0);
                        numArray2[i] = (long)0;
                    }
                    else
                    {
                        numArray[3] = Convert.ToDecimal(hiddenField.Value);
                        numArray1[3] = Convert.ToDecimal(hiddenField1.Value);
                        num2[3] = Convert.ToDecimal(textBox.Text);
                        numArray2[3] = Convert.ToInt64(hiddenField2.Value);
                    }
                }
            }

            if ((int)numArray2.Length > 0)
            {
                int num3 = 0;
                while (num3 < (int)numArray2.Length)
                {
                    if (numArray2[num3] <= (long)0)
                    {
                        num3++;
                    }
                    else
                    {
                        num = numArray2[num3];
                        break;
                    }
                }
            }




            //start


            DataTable dt = EstimatesBasePage.estimateCalculationSelect(num);

            decimal mrkUp = 0.00M;
            decimal mrkUp2 = 0.00M;
            decimal mrkUp3 = 0.00M;
            decimal mrkUp4 = 0.00M;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    mrkUp = Convert.ToDecimal(item["PaperMarkup"]);
                    mrkUp2 = Convert.ToDecimal(item["PaperMarkup2"]);
                    mrkUp3 = Convert.ToDecimal(item["PaperMarkup3"]);
                    mrkUp4 = Convert.ToDecimal(item["PaperMarkup4"]);
                }
            }

            TextBox textBoxz = (TextBox)this.GridPaperCostView.Items[0].FindControl("txt_Markup");
            for (int i = this.GridPaperCostView.Items.Count; i < 4; i++)
            {

                if (i == 0) { num2[i] = mrkUp; }
                if (i == 1) { num2[i] = Convert.ToDecimal(textBoxz.Text); }
                if (i == 2) { num2[i] = Convert.ToDecimal(textBoxz.Text); }
                if (i == 3) { num2[i] = Convert.ToDecimal(textBoxz.Text); }

            }





            //end



            str = "Paper";
            if (this.EstType.ToLower() == "l")
            {
                if (string.Compare(str, "paper", true) == 0)
                {
                    EstimatesBasePage.estimates_Materialmarkup_calculation_update(this.CompanyID, num, this.EstType, num2[0], num2[1], num2[2], num2[3], numArray[0], numArray[1], numArray[2], numArray[3], numArray1[0], numArray1[1], numArray1[2], numArray1[3], this.Module);
                }
            }
            else if (string.Compare(str, "paper", true) == 0)
            {
                EstimatesBasePage.estimates_markup_calculation_update(this.CompanyID, num, num2[0], str, this.TypeID, this.EstType, num2[1], num2[2], num2[3], numArray[0], numArray[1], numArray[2], numArray[3], numArray1[0], numArray1[1], numArray1[2], numArray1[3], this.Module, new decimal(0), new decimal(0), new decimal(0), new decimal(0));
            }
            if (this.iseditUnitprice)
            {
                long num4 = (long)0;
                long num5 = (long)0;
                decimal num6 = new decimal(0);
                for (int j = 0; j < this.GridPaperCostView.Items.Count; j++)
                {
                    Label label = (Label)this.GridPaperCostView.Items[j].FindControl("lbl_qty");
                    Label label1 = (Label)this.GridPaperCostView.Items[j].FindControl("lbl_PaperLength");
                    Label label2 = (Label)this.GridPaperCostView.Items[j].FindControl("lbl_InventorySheets");
                    TextBox textBox_Print_Sheets = (TextBox)this.GridPaperCostView.Items[j].FindControl("txtPrintSheets");
                    TextBox textBox1 = (TextBox)this.GridPaperCostView.Items[j].FindControl("txt_Markup");
                    HiddenField hiddenField4 = (HiddenField)this.GridPaperCostView.Items[j].FindControl("hdnQtyNumber");
                    num1 = Convert.ToInt32(hiddenField4.Value);
                    if (j == 0)
                    {
                        TextBox textBox2 = (TextBox)this.GridPaperCostView.Items[j].FindControl("txt_UnitPrice");
                        HiddenField hiddenField5 = (HiddenField)this.GridPaperCostView.Items[j].FindControl("hdn_paperUnitPrice");
                        HiddenField hiddenField6 = (HiddenField)this.GridPaperCostView.Items[j].FindControl("hdn_EstimateCalculationID");
                        HiddenField hiddenField7 = (HiddenField)this.GridPaperCostView.Items[j].FindControl("hdn_QuantityID");
                        HiddenField hiddenField8 = (HiddenField)this.GridPaperCostView.Items[j].FindControl("hdn_IsPaperUnitPriceLocked");
                        num4 = Convert.ToInt64(hiddenField7.Value);
                        num5 = Convert.ToInt64(hiddenField6.Value);
                        num6 = Convert.ToDecimal(hiddenField5.Value);
                    }
                    if (num1 == 1)
                    {
                        this.arrQty[0] = label.Text.ToString();
                        if (this.paperType.ToLower() == "roll" || this.paperType.ToLower() == "web printing" || this.LargeFormatCalculation.ToString().ToLower() == "square" || this.LargeFormatCalculation.ToString().ToLower() == "linear")
                        {
                            this.arrInvSheets[0] = label1.Text.ToString();
                        }
                        else
                        {
                            this.arrInvSheets[0] = label2.Text.ToString();
                            this.arrPrintSheets[0] = textBox_Print_Sheets.Text.ToString();
                        }
                        this.arrMarkUp[0] = textBox1.Text.ToString();
                    }
                    else if (num1 == 2)
                    {
                        this.arrQty[1] = label.Text.ToString();
                        if (this.paperType.ToLower() == "roll" || this.paperType.ToLower() == "web printing" || this.LargeFormatCalculation.ToString().ToLower() == "square" || this.LargeFormatCalculation.ToString().ToLower() == "linear")
                        {
                            this.arrInvSheets[1] = label1.Text.ToString();
                        }
                        else
                        {
                            this.arrInvSheets[1] = label2.Text.ToString();
                            this.arrPrintSheets[1] = textBox_Print_Sheets.Text.ToString();
                        }
                        this.arrMarkUp[1] = textBox1.Text.ToString();
                    }
                    else if (num1 == 3)
                    {
                        this.arrQty[2] = label.Text.ToString();
                        if (this.paperType.ToLower() == "roll" || this.paperType.ToLower() == "web printing" || this.LargeFormatCalculation.ToString().ToLower() == "square" || this.LargeFormatCalculation.ToString().ToLower() == "linear")
                        {
                            this.arrInvSheets[2] = label1.Text.ToString();
                        }
                        else
                        {
                            this.arrInvSheets[2] = label2.Text.ToString();
                            this.arrPrintSheets[2] = textBox_Print_Sheets.Text.ToString();
                        }
                        this.arrMarkUp[2] = textBox1.Text.ToString();
                    }
                    else if (num1 != 4)
                    {
                        this.arrQty[j] = label.Text.ToString();
                        if (this.paperType.ToLower() == "roll" || this.paperType.ToLower() == "web printing" || this.LargeFormatCalculation.ToString().ToLower() == "square" || this.LargeFormatCalculation.ToString().ToLower() == "linear")
                        {
                            this.arrInvSheets[j] = label1.Text.ToString();
                        }
                        else
                        {
                            this.arrInvSheets[j] = label2.Text.ToString();
                            this.arrPrintSheets[j] = textBox_Print_Sheets.Text.ToString();
                        }
                        this.arrMarkUp[j] = textBox1.Text.ToString();
                    }
                    else
                    {
                        this.arrQty[3] = label.Text.ToString();
                        if (this.paperType.ToLower() == "roll" || this.paperType.ToLower() == "web printing" || this.LargeFormatCalculation.ToString().ToLower() == "square" || this.LargeFormatCalculation.ToString().ToLower() == "linear")
                        {
                            this.arrInvSheets[3] = label1.Text.ToString();
                        }
                        else
                        {
                            this.arrInvSheets[3] = label2.Text.ToString();
                            this.arrPrintSheets[3] = textBox_Print_Sheets.Text.ToString();
                        }
                        this.arrMarkUp[3] = textBox1.Text.ToString();
                    }
                }
                this.calculation_update_papercost(num4, num5, num6, Convert.ToBoolean(this.hdn_isLock.Value.ToString()), this.Module, num1);
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            this.GridPaperCostView.Visible = false;
            this.pnlCallAfterUpdate.Visible = true;

            this.update_printSheets();
            //this.comm.UpdateActivityHistoryForInventory(this.EstimateItemID, new decimal(0),"h");
        }

        public void calculation_update_papercost(long quantityID, long estCalculationID, decimal PaperUnitPrice, bool islock, string Module, int QtyNumber)
        {
            Calculations calculation = new Calculations();
            int[] num = new int[4];
            decimal[] numArray = new decimal[4];
            decimal[] paperUnitPrice = new decimal[4];
            decimal[] num1 = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] num2 = new decimal[4];
            decimal[] num3 = new decimal[4];
            decimal[] numArray2 = new decimal[4];
            for (int i = 1; i <= 4; i++)
            {
                num[i - 1] = Convert.ToInt32(this.arrQty[i - 1]);
                num2[i - 1] = Convert.ToDecimal(this.arrInvSheets[i - 1]);
                num3[i - 1] = Convert.ToDecimal(this.arrPrintSheets[i - 1]);
                if (num[i - 1] <= 0)
                {
                    num[i - 1] = 0;
                    numArray[i - 1] = new decimal(0);
                    paperUnitPrice[i - 1] = new decimal(0);
                    num1[i - 1] = new decimal(0);
                    numArray1[i - 1] = new decimal(0);
                    num2[i - 1] = new decimal(0);
                    numArray2[i - 1] = new decimal(0);
                }
                else
                {
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        numArray[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                    }
                    else
                    {
                        numArray[i - 1] = Convert.ToDecimal(this.arrMarkUp[i - 1]);
                    }
                    decimal sheetsToUse = this.EstType.ToLower() == "l" ? num2[i - 1] : num3[i - 1];
                    //paperUnitPrice[i - 1] = num2[i - 1] * PaperUnitPrice;
                    paperUnitPrice[i - 1] = sheetsToUse * PaperUnitPrice;
                    num1[i - 1] = (paperUnitPrice[i - 1] * numArray[i - 1]) / new decimal(100);
                    numArray1[i - 1] = paperUnitPrice[i - 1] + num1[i - 1];
                }
            }
            if (this.EstType.ToLower() == "l")
            {
                EstimatesBasePage.update_Materialcost_onLockUnitPrice(quantityID, estCalculationID, PaperUnitPrice, islock, paperUnitPrice[0], paperUnitPrice[1], paperUnitPrice[2], paperUnitPrice[3], num1[0], num1[1], num1[2], num1[3]);
                return;
            }
            EstimatesBasePage.update_papercost_onLockUnitPrice(quantityID, estCalculationID, PaperUnitPrice, islock, paperUnitPrice[0], paperUnitPrice[1], paperUnitPrice[2], paperUnitPrice[3], num1[0], num1[1], num1[2], num1[3], Module, QtyNumber);
        }

        protected void GridPaperCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["SellingPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["UnitPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["MarkupPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Markup_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                if (this.iseditUnitprice)
                {
                    item["UnitPrice"].Attributes.Add("style", "padding-right:30px;");
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_qty");
                Label removeDecimalPlacesIfZero = (Label)e.Item.FindControl("lbl_InventorySheets");
                Label label1 = (Label)e.Item.FindControl("lbl_Packedin");
                Label label2 = (Label)e.Item.FindControl("lbl_PackedPrice");
                Label removeDecimalPlacesIfZero1 = (Label)e.Item.FindControl("lbl_PaperLength");
                TextBox textBox = (TextBox)e.Item.FindControl("txt_UnitPrice");
                Label label3 = (Label)e.Item.FindControl("lbl_UnitPrice");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txt_Markup");

                TextBox textBoxPrintSheets = (TextBox)e.Item.FindControl("txtPrintSheets");

                Label label4 = (Label)e.Item.FindControl("lbl_SellingPrice");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_EstItemID");
                HtmlImage htmlImage = (HtmlImage)e.Item.FindControl("img_LockUnlock");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_IsPaperUnitPriceLocked");
                HiddenField str = (HiddenField)e.Item.FindControl("hdn_NoOfPacks");
                Label label5 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnQtyNumber");
                if (this.rowNo != 1 || !this.iseditUnitprice)
                {
                    label3.Visible = true;
                    htmlImage.Visible = false;
                    textBox.Visible = false;
                }
                else
                {
                    label3.Visible = false;
                    htmlImage.Visible = true;
                    textBox.Visible = true;
                    AttributeCollection attributes = textBox.Attributes;
                    object[] isPricePerPack = new object[] { "javascript:AllowNumber(this,this.value);todecimal_functionwithfourdecimal(this,this.value);calculateSellingprice_onBlur(this,'", this.paperType, "','", this.IsPricePerPack, "');" };
                    attributes.Add("onblur", string.Concat(isPricePerPack));
                    if (!Convert.ToBoolean(hiddenField1.Value))
                    {
                        htmlImage.Src = string.Concat(global.imagePath(), "lockopen.png");
                        htmlImage.Attributes.Add("onclick", "javascript:LockPaperUnitPrice(this,0);");
                        this.hdn_isLock.Value = "false";
                    }
                    else
                    {
                        htmlImage.Src = string.Concat(global.imagePath(), "lockclosed.png");
                        htmlImage.Attributes.Add("onclick", "javascript:LockPaperUnitPrice(this,1);");
                        textBox.Attributes.Add("disabled", "disabled");
                        htmlImage.Attributes.Add("disabled", "disabled");
                        this.hdn_isLock.Value = "true";
                    }
                }
                if (this.iseditUnitprice)
                {
                    label3.Attributes.Add("style", "padding-right:25px;");
                }
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                removeDecimalPlacesIfZero.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero.Text), 0, "", false, false, true));
                decimal num = Convert.ToDecimal(textBox.Text) * Convert.ToDecimal(label1.Text);
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                if (!this.IsPricePerPack)
                {
                    label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                }
                else
                {
                    label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num, 0, "", false, false, true);
                    if (Convert.ToDecimal(label1.Text) > new decimal(0))
                    {
                        decimal num1 = Math.Ceiling(Convert.ToDecimal(removeDecimalPlacesIfZero.Text) / Convert.ToDecimal(label1.Text));
                        str.Value = num1.ToString();
                    }
                }
                removeDecimalPlacesIfZero1.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero1.Text), 0, "", false, false, true));
                label5.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label5.Text), 0, "", false, false, true);
                label4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", false, false, true);
                textBox1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox1.Text), 0, "", false, false, true);
                textBox1.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Paper(this);");
                textBox1.Attributes.Add("onclick", "javascript:this.select();");

                textBoxPrintSheets.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBoxPrintSheets.Text), 0, "", false, false, true);

                AttributeCollection attributes__ = textBoxPrintSheets.Attributes;
                object[] isPricePerPack__ = new object[] { "javascript:AllowNumber(this,this.value);todecimal_functionwithfourdecimal(this,this.value);calculateSellingprice_onBlur_TotalSheets(this,'", this.paperType, "','", this.IsPricePerPack, "','", this.rowNo, "');" };
                attributes__.Add("onblur", string.Concat(isPricePerPack__));

                //textBoxPrintSheets.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_functionwithfourdecimal(this,this.value);calculateSellingprice_onBlur(this,'", this.paperType, "','", this.IsPricePerPack, "');");
                textBoxPrintSheets.Attributes.Add("onclick", "javascript:this.select();");

                paper_costview usercontrolItemPaperCostview = this;
                usercontrolItemPaperCostview.rowNo = usercontrolItemPaperCostview.rowNo + 1;
            }
        }

        #region Page_Load
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
        //    this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
        //    this.paperID = Convert.ToInt32(base.Request.QueryString["PaperID"].ToString());
        //    this.EstType = base.Request.QueryString["EstType"].ToString();
        //    this.EstimateItemID = (long)Convert.ToInt32(base.Request.QueryString["EstimateItemID"].ToString());
        //    this.arrQty[0] = "0";
        //    this.arrQty[1] = "0";
        //    this.arrQty[2] = "0";
        //    this.arrQty[3] = "0";
        //    this.arrInvSheets[0] = "0";
        //    this.arrInvSheets[1] = "0";
        //    this.arrInvSheets[2] = "0";
        //    this.arrInvSheets[3] = "0";
        //    this.arrMarkUp[0] = "0";
        //    this.arrMarkUp[1] = "0";
        //    this.arrMarkUp[2] = "0";
        //    this.arrMarkUp[3] = "0";
        //    int num = 0;
        //    if (!base.IsPostBack)
        //    {
        //        this.GridPaperCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
        //        this.GridPaperCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Sheets");
        //        this.GridPaperCostView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Packed_In_small");
        //        this.GridPaperCostView.Columns[3].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Pack_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
        //        this.GridPaperCostView.Columns[6].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (%)");
        //        this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
        //    }
        //    this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
        //    if (this.EstType.ToLower() != "b")
        //    {
        //        this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
        //    }
        //    else
        //    {
        //        this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
        //    }
        //    if (ConnectionClass.ProfitTaxKey != null)
        //    {
        //        this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
        //    }
        //    if (this.EstType.ToLower() == "l" && base.Request.QueryString["MaterialNo"] != null)
        //    {
        //        num = Convert.ToInt32(base.Request.QueryString["MaterialNo"].ToString());
        //    }
        //    foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
        //    {
        //        this.EstimateID = Convert.ToInt64(row["EstimateID"]);
        //        this.JobID = Convert.ToInt64(row["JOBID"]);
        //        this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
        //    }
        //    this.Module = base.Request.QueryString["Module"].ToString();
        //    DataTable dataTable = EstimatesBasePage.PCR_Paper_Cost_ViewOnPopUp(this.paperID, this.EstimateItemID, this.EstType, this.TypeID, this.Module, num);
        //    if (dataTable.Rows.Count <= 0)
        //    {
        //        this.GridPaperCostView.MasterTableView.Columns[0].Visible = false;
        //    }
        //    else
        //    {
        //        this.lblPaperName.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PaperName"].ToString());
        //        this.lblInventoryCode.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["InventoryCode"].ToString());
        //        this.lblPriceforWholePack.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PriceforWholePack"].ToString());
        //        this.lblPaperSupplied.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PaperSupplied"].ToString());
        //        this.lblSupplierName1.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
        //        this.lblSupplierName2.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
        //        this.lblSupplierName3.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
        //        this.lblDescription.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Description"].ToString());
        //        this.paperType = dataTable.Rows[0]["PaperType"].ToString().ToLower();
        //        this._firstPaperType = dataTable.Rows[0]["FirstPaperType"].ToString().ToLower();
        //        this.LargeFormatCalculation = dataTable.Rows[0]["calculationType"].ToString().ToLower();
        //        this.hdn_CalcType.Value = this.LargeFormatCalculation;
        //        if (this.LargeFormatCalculation.ToString().ToLower() == "square")
        //        {
        //            if (this.PaperMeasure != "In.")
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Sq_Meter");
        //            }
        //            else
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Sq_feet");
        //            }
        //        }
        //        else if(this.LargeFormatCalculation.ToString().ToLower() == "tilling")
        //        {
        //            if (this.PaperMeasure != "In.")
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = "Stock Area (sq m)";
        //            }
        //            else
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = "Stock Area (sq ft)";
        //            }
        //        }
        //        else if (this.EstType.ToLower() == "l")
        //        {
        //            if (this.PaperMeasure != "In.")
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Meter");
        //            }
        //            else
        //            {
        //                this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_feet");
        //            }
        //        }
        //        else if (this.PaperMeasure != "In.")
        //        {
        //            this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Paper_Length_Meter");
        //        }
        //        else
        //        {
        //            this.GridPaperCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Paper_Length_feet");
        //        }
        //        if (dataTable.Rows[0]["PaperType"].ToString().ToLower() != "roll" && dataTable.Rows[0]["PaperType"].ToString().ToLower() != "web printing")
        //        {
        //            if (dataTable.Rows[0]["PriceforWholepack"].ToString().ToLower() == "yes")
        //            {
        //                this.trHeading3.Visible = true;
        //                this.trHeading5.Visible = false;
        //                if (this.EstType.ToLower() != "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                }
        //                else if (this._firstPaperType != "sheet")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
        //                }
        //                else
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = false;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
        //                this.GridPaperCostView.MasterTableView.Columns[3].Visible = true;
        //                this.iseditUnitprice = true;
        //                this.IsPricePerPack = true;
        //            }
        //            else if (dataTable.Rows[0]["PaperSupplied"].ToString().ToLower() != "yes")
        //            {
        //                this.trHeading5.Visible = true;
        //                this.trHeading6.Visible = true;
        //                if (this.EstType.ToLower() != "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                }
        //                else if (this._firstPaperType != "sheet")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
        //                }
        //                else
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = false;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                this.iseditUnitprice = true;
        //            }
        //            else
        //            {
        //                this.trHeading2.Visible = true;
        //                this.trHeading5.Visible = false;
        //                if (this.EstType.ToLower() != "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                }
        //                else if (this._firstPaperType != "sheet")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
        //                }
        //                else
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = false;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //                this.iseditUnitprice = false;
        //            }
        //        }
        //        else if (dataTable.Rows[0]["PriceforWholepack"].ToString().ToLower() == "yes")
        //        {
        //            this.trHeading3.Visible = true;
        //            this.trHeading5.Visible = false;
        //            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
        //            this.GridPaperCostView.MasterTableView.Columns[3].Visible = true;
        //            this.iseditUnitprice = true;
        //            this.IsPricePerPack = true;
        //        }
        //        else if (dataTable.Rows[0]["PaperSupplied"].ToString().ToLower() != "yes")
        //        {
        //            this.trHeading5.Visible = true;
        //            this.trHeading6.Visible = true;
        //            if (this.EstType.ToLower() == "l")
        //            {
        //                if (this._firstPaperType != "sheet")
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
        //                }
        //                else
        //                {
        //                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = false;
        //                    this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //                }
        //            }
        //            this.iseditUnitprice = true;
        //        }
        //        else
        //        {
        //            this.trHeading2.Visible = true;
        //            this.trHeading5.Visible = false;
        //            if (this.EstType.ToLower() != "l")
        //            {
        //                this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //            }
        //            else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
        //            {
        //                this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //            }
        //            else if (this._firstPaperType != "sheet")
        //            {
        //                this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
        //                this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
        //            }
        //            else
        //            {
        //                this.GridPaperCostView.MasterTableView.Columns[4].Visible = false;
        //                this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
        //            }
        //            this.iseditUnitprice = false;
        //        }
        //        this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
        //        this.GridPaperCostView.MasterTableView.Columns[6].Visible = true;
        //        this.GridPaperCostView.MasterTableView.Columns[7].Visible = true;
        //        this.GridPaperCostView.MasterTableView.Columns[8].Visible = true;
        //    }
        //    if (this.EstType.ToLower() != "l")
        //    {
        //        this.paperlabel.Text = this.objLanguage.GetLanguageConversion("Paper_Name");
        //    }
        //    else
        //    {
        //        this.paperlabel.Text = this.objLanguage.GetLanguageConversion("Material_Name");
        //    }
        //    this.GridPaperCostView.DataSource = dataTable;
        //    this.GridPaperCostView.DataBind();
        //    if (this.Module.ToLower() == "job")
        //    {
        //        this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.JobID, "jobs");
        //    }
        //    if (this.Module.ToLower() == "invoice")
        //    {
        //        this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
        //    }
        //}
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.paperID = Convert.ToInt32(base.Request.QueryString["PaperID"].ToString());
            this.EstType = base.Request.QueryString["EstType"].ToString();
            this.EstimateItemID = (long)Convert.ToInt32(base.Request.QueryString["EstimateItemID"].ToString());
            this.arrQty[0] = "0";
            this.arrQty[1] = "0";
            this.arrQty[2] = "0";
            this.arrQty[3] = "0";
            this.arrInvSheets[0] = "0";
            this.arrInvSheets[1] = "0";
            this.arrInvSheets[2] = "0";
            this.arrInvSheets[3] = "0";
            this.arrMarkUp[0] = "0";
            this.arrMarkUp[1] = "0";
            this.arrMarkUp[2] = "0";
            this.arrMarkUp[3] = "0";
            int num = 0;
            if (!base.IsPostBack)
            {
                this.GridPaperCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                this.GridPaperCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Sheets");
                this.GridPaperCostView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Print_Sheets");
                this.GridPaperCostView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Packed_In_small");
                this.GridPaperCostView.Columns[4].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Pack_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                this.GridPaperCostView.Columns[7].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (%)");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            }
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            if (this.EstType.ToLower() == "l" && base.Request.QueryString["MaterialNo"] != null)
            {
                num = Convert.ToInt32(base.Request.QueryString["MaterialNo"].ToString());
            }
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                this.JobID = Convert.ToInt64(row["JOBID"]);
                this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
            }
            this.Module = base.Request.QueryString["Module"].ToString();
            DataTable dataTable = EstimatesBasePage.PCR_Paper_Cost_ViewOnPopUp(this.paperID, this.EstimateItemID, this.EstType, this.TypeID, this.Module, num);
            if (dataTable.Rows.Count <= 0)
            {
                this.GridPaperCostView.MasterTableView.Columns[0].Visible = false;
            }
            else
            {
                this.lblPaperName.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PaperName"].ToString());
                this.lblInventoryCode.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["InventoryCode"].ToString());
                this.lblPriceforWholePack.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PriceforWholePack"].ToString());
                this.lblPaperSupplied.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["PaperSupplied"].ToString());
                this.lblSupplierName1.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
                this.lblSupplierName2.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
                this.lblSupplierName3.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Supplier"].ToString());
                this.lblDescription.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["Description"].ToString());
                this.paperType = dataTable.Rows[0]["PaperType"].ToString().ToLower();
                this._firstPaperType = dataTable.Rows[0]["FirstPaperType"].ToString().ToLower();
                this.hdn_invshet.Value = dataTable.Rows[0]["InventorySheets"].ToString();
                this.LargeFormatCalculation = dataTable.Rows[0]["calculationType"].ToString().ToLower();
                this.hdn_CalcType.Value = this.LargeFormatCalculation;
                if (this.LargeFormatCalculation.ToString().ToLower() == "square")
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Sq_Meter");
                    }
                    else
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Sq_feet");
                    }
                }
                else if (this.LargeFormatCalculation.ToString().ToLower() == "tilling")
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = "Stock Area (sq m)";
                    }
                    else
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = "Stock Area (sq ft)";
                    }
                }
                else if (this.EstType.ToLower() == "l")
                {
                    if (this.PaperMeasure != "In.")
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_Meter");
                    }
                    else
                    {
                        this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Material_Length_feet");
                    }
                }
                else if (this.PaperMeasure != "In.")
                {
                    this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Paper_Length_Meter");
                }
                else
                {
                    this.GridPaperCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Paper_Length_feet");
                }
                if (dataTable.Rows[0]["PaperType"].ToString().ToLower() != "roll" && dataTable.Rows[0]["PaperType"].ToString().ToLower() != "web printing")
                {
                    if (dataTable.Rows[0]["PriceforWholepack"].ToString().ToLower() == "yes")
                    {
                        this.trHeading3.Visible = true;
                        this.trHeading5.Visible = false;
                        if (this.EstType.ToLower() != "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                        }
                        else if (this._firstPaperType != "sheet")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = false;
                        }
                        else
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        this.GridPaperCostView.MasterTableView.Columns[3].Visible = true;
                        this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
                        this.iseditUnitprice = true;
                        this.IsPricePerPack = true;
                    }
                    else if (dataTable.Rows[0]["PaperSupplied"].ToString().ToLower() != "yes")
                    {
                        this.trHeading5.Visible = true;
                        this.trHeading6.Visible = true;
                        if (this.EstType.ToLower() != "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                        }
                        else if (this._firstPaperType != "sheet")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = false;
                        }
                        else
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        this.iseditUnitprice = true;
                    }
                    else
                    {
                        this.trHeading2.Visible = true;
                        this.trHeading5.Visible = false;
                        if (this.EstType.ToLower() != "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                        }
                        else if (this._firstPaperType != "sheet")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = false;
                        }
                        else
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                        this.iseditUnitprice = false;
                    }
                }
                else if (dataTable.Rows[0]["PriceforWholepack"].ToString().ToLower() == "yes")
                {
                    this.trHeading3.Visible = true;
                    this.trHeading5.Visible = false;
                    this.GridPaperCostView.MasterTableView.Columns[3].Visible = true;
                    this.GridPaperCostView.MasterTableView.Columns[4].Visible = true;
                    this.iseditUnitprice = true;
                    this.IsPricePerPack = true;
                }
                else if (dataTable.Rows[0]["PaperSupplied"].ToString().ToLower() != "yes")
                {
                    this.trHeading5.Visible = true;
                    this.trHeading6.Visible = true;
                    if (this.EstType.ToLower() == "l")
                    {
                        if (this._firstPaperType != "sheet")
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = false;
                        }
                        else
                        {
                            this.GridPaperCostView.MasterTableView.Columns[5].Visible = false;
                            this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                            this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                        }
                    }
                    this.iseditUnitprice = true;
                }
                else
                {
                    this.trHeading2.Visible = true;
                    this.trHeading5.Visible = false;
                    if (this.EstType.ToLower() != "l")
                    {
                        this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                        this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                    }
                    else if (this.LargeFormatCalculation.ToString().ToLower() == "square" && this.EstType.ToLower() == "l")
                    {
                        this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                    }
                    else if (this._firstPaperType != "sheet")
                    {
                        this.GridPaperCostView.MasterTableView.Columns[5].Visible = true;
                        this.GridPaperCostView.MasterTableView.Columns[1].Visible = false;
                        this.GridPaperCostView.MasterTableView.Columns[2].Visible = false;
                    }
                    else
                    {
                        this.GridPaperCostView.MasterTableView.Columns[5].Visible = false;
                        this.GridPaperCostView.MasterTableView.Columns[1].Visible = true;
                        this.GridPaperCostView.MasterTableView.Columns[2].Visible = true;
                    }
                    this.iseditUnitprice = false;
                }
                this.GridPaperCostView.MasterTableView.Columns[6].Visible = true;
                this.GridPaperCostView.MasterTableView.Columns[7].Visible = true;
                this.GridPaperCostView.MasterTableView.Columns[8].Visible = true;
                this.GridPaperCostView.MasterTableView.Columns[9].Visible = true;
            }
            if (this.EstType.ToLower() != "l")
            {
                this.paperlabel.Text = this.objLanguage.GetLanguageConversion("Paper_Name");
            }
            else
            {
                this.paperlabel.Text = this.objLanguage.GetLanguageConversion("Material_Name");
            }
            this.GridPaperCostView.DataSource = dataTable;
            this.GridPaperCostView.DataBind();
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