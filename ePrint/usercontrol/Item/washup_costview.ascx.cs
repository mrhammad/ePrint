using nmsCommon;
using nmsConnectionClass;
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
    public partial class washup_costview : UsercontrolBasePage
    {

        public long EstimateItemID;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

        public int CompanyID;

        public int UserID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public commonClass comm = new commonClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string ItemFrom = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public washup_costview()
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
                    empty = base.Request.Params["item"].ToString();
                    string value = this.hdn_LithoMarkup.Value;
                    EstimatesBasePage.estimates_litho_markup_calculation_update(this.CompanyID, this.EstimateItemID, Convert.ToDecimal(this.hdn_LithoMarkup.Value), empty, this.TypeID, this.EstType);
                }
                this.ItemFrom = base.Request.Params["From"].ToString();
            }
            long num = (long)0;
            string str = string.Empty;
            decimal[] numArray = new decimal[4];
            decimal[] num1 = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            long[] num2 = new long[4];
            int count = this.GridWashUpCostView.Items.Count;
            for (int i = 0; i < 4; i++)
            {
                if (i >= count)
                {
                    numArray[i] = new decimal(0);
                    num1[i] = new decimal(0);
                    numArray1[i] = new decimal(0);
                    num2[i] = (long)0;
                }
                else
                {
                    HiddenField hiddenField = (HiddenField)this.GridWashUpCostView.Items[i].FindControl("hdn_MarkupPrice");
                    HiddenField hiddenField1 = (HiddenField)this.GridWashUpCostView.Items[i].FindControl("hdn_CostExMarkup");
                    TextBox textBox = (TextBox)this.GridWashUpCostView.Items[i].FindControl("txt_Markup");
                    HiddenField hiddenField2 = (HiddenField)this.GridWashUpCostView.Items[i].FindControl("hdn_EstimateCalculationID");
                    numArray[i] = Convert.ToDecimal(hiddenField.Value);
                    num1[i] = Convert.ToDecimal(hiddenField1.Value);
                    numArray1[i] = Convert.ToDecimal(textBox.Text);
                    num2[i] = Convert.ToInt64(hiddenField2.Value);
                }
            }
            if ((int)num2.Length > 0)
            {
                num = num2[0];
            }
            str = "washup";
            if (string.Compare(str, "washup", true) == 0)
            {
                EstimatesBasePage.estimates_markup_calculation_update(this.CompanyID, num, numArray1[0], str, this.TypeID, this.EstType, numArray1[1], numArray1[2], numArray1[3], numArray[0], numArray[1], numArray[2], numArray[3], num1[0], num1[1], num1[2], num1[3], this.Module, new decimal(0), new decimal(0), new decimal(0), new decimal(0));
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void GridWashUpCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["SellingPrice"].Text = string.Concat("Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["UnitPrice"].Text = string.Concat("Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["MarkupPrice"].Text = string.Concat("Markup Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_UnitPrice");
                Label label1 = (Label)e.Item.FindControl("lbl_SellingPrice");
                TextBox textBox = (TextBox)e.Item.FindControl("txt_Markup");
                Label label2 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                textBox.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox.Text), 0, "", false, false, true);
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Washup(this);");
                textBox.Attributes.Add("onclick", "javascript:this.select();");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["EstimateItemID"].ToString());
            this.EstType = base.Request.QueryString["EstType"].ToString();
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                this.JobID = Convert.ToInt64(row["JOBID"]);
                this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
            }
            this.Module = base.Request.QueryString["Module"].ToString();
            DataTable dataTable = EstimatesBasePage.PCR_WashUp_Cost_ViewOnPopUp(this.EstimateItemID, this.EstType, this.TypeID, this.Module);
            this.GridWashUpCostView.DataSource = dataTable;
            this.GridWashUpCostView.DataBind();
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