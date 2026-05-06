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
    public partial class guillotine_costview : UsercontrolBasePage
    {
        public long GuillotineID;

        public long EstimateItemID;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

        public int CompanyID;

        public int UserID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public string ItemFrom = string.Empty;

        public commonClass comm = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

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

        public guillotine_costview()
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
            decimal[] numArray = new decimal[4];
            decimal[] num1 = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] num2 = new decimal[4];
            long[] numArray2 = new long[4];
            for (int i = 0; i < 4; i++)
            {
                if (i < this.GridGuillotineCostView.Items.Count)
                {
                    HiddenField hiddenField = (HiddenField)this.GridGuillotineCostView.Items[i].FindControl("hdn_MarkupPrice");
                    HiddenField hiddenField1 = (HiddenField)this.GridGuillotineCostView.Items[i].FindControl("hdn_CostExMarkup");
                    HiddenField hiddenField2 = (HiddenField)this.GridGuillotineCostView.Items[i].FindControl("hdn_CostExMarkup_Actual");
                    TextBox textBox = (TextBox)this.GridGuillotineCostView.Items[i].FindControl("txt_Markup");
                    HiddenField hiddenField3 = (HiddenField)this.GridGuillotineCostView.Items[i].FindControl("hdn_EstimateCalculationID");
                    HiddenField hiddenField4 = (HiddenField)this.GridGuillotineCostView.Items[i].FindControl("hdnQtyNumber");
                    int num3 = Convert.ToInt32(hiddenField4.Value);
                    if (num3 == 1)
                    {
                        numArray[0] = Convert.ToDecimal(hiddenField.Value);
                        num1[0] = Convert.ToDecimal(hiddenField1.Value);
                        numArray1[0] = Convert.ToDecimal(hiddenField2.Value);
                        num2[0] = Convert.ToDecimal(textBox.Text);
                        numArray2[0] = Convert.ToInt64(hiddenField3.Value);
                    }
                    else if (num3 == 2)
                    {
                        numArray[1] = Convert.ToDecimal(hiddenField.Value);
                        num1[1] = Convert.ToDecimal(hiddenField1.Value);
                        numArray1[1] = Convert.ToDecimal(hiddenField2.Value);
                        num2[1] = Convert.ToDecimal(textBox.Text);
                        numArray2[1] = Convert.ToInt64(hiddenField3.Value);
                    }
                    else if (num3 == 3)
                    {
                        numArray[2] = Convert.ToDecimal(hiddenField.Value);
                        num1[2] = Convert.ToDecimal(hiddenField1.Value);
                        numArray1[2] = Convert.ToDecimal(hiddenField2.Value);
                        num2[2] = Convert.ToDecimal(textBox.Text);
                        numArray2[2] = Convert.ToInt64(hiddenField3.Value);
                    }
                    else if (num3 != 4)
                    {
                        numArray[i] = new decimal(0);
                        num1[i] = new decimal(0);
                        numArray1[i] = new decimal(0);
                        num2[i] = new decimal(0);
                        numArray2[i] = (long)0;
                    }
                    else
                    {
                        numArray[3] = Convert.ToDecimal(hiddenField.Value);
                        num1[3] = Convert.ToDecimal(hiddenField1.Value);
                        numArray1[3] = Convert.ToDecimal(hiddenField2.Value);
                        num2[3] = Convert.ToDecimal(textBox.Text);
                        numArray2[3] = Convert.ToInt64(hiddenField3.Value);
                    }
                }
            }
            if ((int)numArray2.Length > 0)
            {
                int num4 = 0;
                while (num4 < (int)numArray2.Length)
                {
                    if (numArray2[num4] <= (long)0)
                    {
                        num4++;
                    }
                    else
                    {
                        num = numArray2[num4];
                        break;
                    }
                }
            }
            str = "guillotine";
            if (string.Compare(str, "guillotine", true) == 0)
            {
                EstimatesBasePage.estimates_markup_calculation_update(this.CompanyID, num, num2[0], str, this.TypeID, this.EstType, num2[1], num2[2], num2[3], numArray[0], numArray[1], numArray[2], numArray[3], num1[0], num1[1], num1[2], num1[3], this.Module, numArray1[0], numArray1[1], numArray1[2], numArray1[3]);
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void GridGuillotineCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["CostPerCut"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Cost_Per_Cut"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["SellingPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["GuillotineSetupCharge"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Set_Up_Charge"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["MarkupPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Markup_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_qty");
                Label label1 = (Label)e.Item.FindControl("lbl_Sheets");
                Label label2 = (Label)e.Item.FindControl("lbl_PrintSheets");
                Label label3 = (Label)e.Item.FindControl("lbl_Cuts");
                Label label4 = (Label)e.Item.FindControl("lbl_NoOfBundles");
                Label label5 = (Label)e.Item.FindControl("lbl_FirstTrimCuts");
                Label label6 = (Label)e.Item.FindControl("lbl_FirstTrimNoOfBundles");
                Label label7 = (Label)e.Item.FindControl("lbl_SecondTrimCuts");
                Label label8 = (Label)e.Item.FindControl("lbl_SecondTrimNoOfBundles");
                Label label9 = (Label)e.Item.FindControl("lbl_CostPerCut");
                Label label10 = (Label)e.Item.FindControl("lbl_SetupCharge");
                TextBox textBox = (TextBox)e.Item.FindControl("txt_Markup");
                Label label11 = (Label)e.Item.FindControl("lbl_SellingPrice");
                Label label12 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnQtyNumber");
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", true, false, true);
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", true, false, true);
                label3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text), 0, "", false, false, true);
                label4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", false, false, true);
                label9.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label9.Text), 0, "", false, false, true);
                textBox.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox.Text), 0, "", false, false, true);
                label10.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label10.Text), 0, "", false, false, true);
                label11.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label11.Text), 0, "", false, false, true);
                label12.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label12.Text), 0, "", false, false, true);
                textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Guillotine(this);");
                textBox.Attributes.Add("onclick", "javascript:this.select();");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.GuillotineID = Convert.ToInt64(base.Request.QueryString["GuillotineID"].ToString());
            this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["EstimateItemID"].ToString());
            this.EstType = base.Request.QueryString["EstType"].ToString();
            if (!base.IsPostBack)
            {
                this.GridGuillotineCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                this.GridGuillotineCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Inv_Sheets");
                this.GridGuillotineCostView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Print_Sheets");
                this.GridGuillotineCostView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("No_Of_Bundles");
                this.GridGuillotineCostView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("First_Trim_Cuts");
                this.GridGuillotineCostView.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("First_Trim_No_Of_Bundles");
                this.GridGuillotineCostView.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Second_Trim_Cuts");
                this.GridGuillotineCostView.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Second_Trim_No_Of_Bundles");
                this.GridGuillotineCostView.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Per_Cut");
                this.GridGuillotineCostView.Columns[10].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (%)");
                this.GridGuillotineCostView.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Set_up_Charge");
                this.GridGuillotineCostView.Columns[13].HeaderText = this.objLanguage.GetLanguageConversion("Selling_Price");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            }
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            this.Module = base.Request.QueryString["Module"].ToString();
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                this.JobID = Convert.ToInt64(row["JOBID"]);
                this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
            }
            DataTable dataTable = EstimatesBasePage.PCR_Guillotine_Cost_ViewOnPopUp(this.GuillotineID, this.EstimateItemID, this.EstType, this.TypeID, this.Module);
            if (dataTable.Rows.Count <= 0)
            {
                this.GridGuillotineCostView.MasterTableView.Columns[0].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[1].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[2].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[3].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[4].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[5].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[6].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[7].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[8].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[9].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[10].Visible = false;
                this.GridGuillotineCostView.MasterTableView.Columns[12].Visible = false;
            }
            else
            {
                this.lblGuillotine.Text = this.objBase.SpecialDecode(dataTable.Rows[0]["GuillotineName"].ToString());
                this.lblMinimumCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable.Rows[0]["MinimumCharge"].ToString()), 0, "", false, false, true);
                if (this.EstType.ToLower() != "l")
                {
                    this.Guillotinelabel.Text = this.objLanguage.GetLanguageConversion("Guillotine_Name");
                }
                else
                {
                    this.Guillotinelabel.Text = this.objLanguage.GetLanguageConversion("Cutting_Table_Name");
                    if (string.Compare(dataTable.Rows[0]["papertype"].ToString().Trim().ToLower(), "roll", true) == 0 || string.Compare(dataTable.Rows[0]["papertype"].ToString().Trim().ToLower(), "web printing", true) == 0)
                    {
                        if (dataTable.Rows[0]["isLarge"].ToString().ToLower() != "true")
                        {
                            this.GridGuillotineCostView.MasterTableView.Columns[3].Visible = false;
                        }
                        else
                        {
                            this.GridGuillotineCostView.MasterTableView.Columns[3].Visible = true;
                        }
                        this.GridGuillotineCostView.MasterTableView.Columns[1].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[4].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[5].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[6].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[7].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[8].Visible = false;
                    }
                    else if (dataTable.Rows[0]["isLarge"].ToString().ToLower() != "true")
                    {
                        this.GridGuillotineCostView.MasterTableView.Columns[3].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[5].Visible = true;
                        this.GridGuillotineCostView.MasterTableView.Columns[6].Visible = true;
                        this.GridGuillotineCostView.MasterTableView.Columns[7].Visible = true;
                        this.GridGuillotineCostView.MasterTableView.Columns[8].Visible = true;
                        this.GridGuillotineCostView.MasterTableView.Columns[4].Visible = false;
                    }
                    else
                    {
                        this.GridGuillotineCostView.MasterTableView.Columns[3].Visible = true;
                        this.GridGuillotineCostView.MasterTableView.Columns[4].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[5].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[6].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[7].Visible = false;
                        this.GridGuillotineCostView.MasterTableView.Columns[8].Visible = false;
                    }
                    this.GridGuillotineCostView.MasterTableView.Columns[2].Visible = false;
                    this.GridGuillotineCostView.MasterTableView.Columns[1].Visible = false;
                }
            }
            this.GridGuillotineCostView.DataSource = dataTable;
            this.GridGuillotineCostView.DataBind();
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