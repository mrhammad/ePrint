using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using System.Collections.Specialized;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Data;

namespace ePrint.common
{
    public partial class spentlimit : System.Web.UI.Page, IRequiresSessionState
    {
        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objcomm = new CompanyBasePage();
        public commonClass comm = new commonClass();

        private commonClass objJava = new commonClass();

        public int CompanyID;

        private string IDs = string.Empty;

        public string Type = string.Empty;

        public string DateFormat = "MM/dd/yyyy";

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

        public spentlimit()
        {
        }

        protected void btnSaveSpendlimit_Click(object sender, EventArgs e)
        {
            string[] strArrays = this.IDs.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                this.objcomm.Contact_or_Dept_SpendLimitUpdate(this.CompanyID, Convert.ToInt64(strArrays[i]), this.ddlPeriod.SelectedValue, Convert.ToDecimal(this.txt_SpendAmount.Text), this.Type, chkRollover.Checked, ddlRollOverLimit.SelectedItem.Text, Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dtpRollOverDate.Text)));
            }
            this.pnlLoadContactPanel.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Title = this.objLanguage.GetLanguageConversion("Apply_Spend_Limit");
            this.lblAmount.Text = string.Concat(this.objLanguage.GetLanguageConversion("Amount"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.lblPeriod.Text = this.objLanguage.GetLanguageConversion("Select_Period");
            this.CompanyID = int.Parse(this.Session["CompanyID"].ToString());



            if (base.Request.Params["IDs"].ToString() != null)
            {
                this.IDs = base.Request.Params["IDs"].ToString();
            }
            if (base.Request.Params["type"].ToString() != null)
            {
                this.Type = base.Request.Params["type"].ToString();
            }


            string[] strArrays = this.IDs.Split(new char[] { ',' });
            if (!base.IsPostBack)
            {
                TextBox textBox = this.dtpRollOverDate;
                commonClass _commonClass1 = this.comm;
                var now = DateTime.Now;
                textBox.Text = _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, Convert.ToInt32(base.Session["UserID"].ToString()), true);

                this.dtpRollOverDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));

                DataTable dataTable6 = CompanyBasePage.PC_company_contactByContactId_select(Convert.ToInt32(strArrays[0]));
                foreach (DataRow row in dataTable6.Rows)
                {
                    txt_SpendAmount.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["SpendLimitAmount"].ToString()), 2, "", false, false, true).ToString();
                    ddlPeriod.ClearSelection();
                    ddlPeriod.SelectedValue = row["SpendLimitPeriod"].ToString();
                    FillCombobox();
                    chkRollover.Checked = Convert.ToBoolean(row["EnableRollOver"] == DBNull.Value ? false : row["EnableRollOver"]);
                    dtpRollOverDate.Text = this.comm.Eprint_return_Date_Before_View(row["RollOverStart"].ToString(), this.CompanyID, 0, false);
                    if (row["RollOverLimit"].ToString() != "")
                    {
                        ddlRollOverLimit.ClearSelection();
                        var spenlimit = ddlRollOverLimit.Items.FindByText(row["RollOverLimit"].ToString());
                        if (spenlimit != null)
                        {
                            ddlRollOverLimit.Items.FindByText(row["RollOverLimit"].ToString()).Selected = true;
                        }
                    }

                }
            }

            if (chkRollover.Checked)
            {
                ddlRollOverLimit.Enabled = true;
                dtpRollOverDate.Enabled = true;
            }
            else
            {
                ddlRollOverLimit.Enabled = false;
                dtpRollOverDate.Enabled = false;
            }

        }

        void FillCombobox()
        {
            //this.strconvertedate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtEstimateDate.Text));
            DataTable dt; ;
            if (this.ddlPeriod.SelectedValue == "Calendar Year" || this.ddlPeriod.SelectedValue == "Financial Year")
            {
                dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("FormulaNew");
                dt.Columns.Add("Label");
                DataRow _row = dt.NewRow();
                _row["FormulaNew"] = "0";
                _row["Label"] = "Unlimited";
                dt.Rows.Add(_row);
                _row = dt.NewRow();
                _row["FormulaNew"] = "1";
                _row["Label"] = "One Roll Over";
                dt.Rows.Add(_row);
            }
            else if (this.ddlPeriod.SelectedValue == "Month")
            {
                dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("FormulaNew");
                dt.Columns.Add("Label");
                DataRow _row = dt.NewRow();
                _row["FormulaNew"] = "0";
                _row["Label"] = "Roll over 11 times";
                dt.Rows.Add(_row);
                _row = dt.NewRow();
                _row["FormulaNew"] = "1";
                _row["Label"] = "Roll over once";
                dt.Rows.Add(_row);
                _row = dt.NewRow();
                _row["FormulaNew"] = "2";
                _row["Label"] = "Roll over 2 times";
                dt.Rows.Add(_row);
            }
            else
            {
                dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("FormulaNew");
                dt.Columns.Add("Label");
                DataRow _row = dt.NewRow();
                _row["FormulaNew"] = "0";
                _row["Label"] = "Unlimited";
                dt.Rows.Add(_row);
                _row = dt.NewRow();
                _row["FormulaNew"] = "1";
                _row["Label"] = "To end of financial year";
                dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["FormulaNew"] = "2";
                _row["Label"] = "To end of calendar year";
                dt.Rows.Add(_row);
            }
            ddlRollOverLimit.DataSource = dt;
            ddlRollOverLimit.DataTextField = "Label";
            ddlRollOverLimit.DataValueField = "FormulaNew";
            ddlRollOverLimit.DataBind();
        }

        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCombobox();
        }

        protected void ddlPeriod_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRollOverLimit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}