using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Department;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class cost_selector : System.Web.UI.UserControl
    {
        private BaseClass objBase = new BaseClass();

        public languageClass objLangClass = new languageClass();

        public string strSitepath = global.sitePath();

        public string wintype = string.Empty;

        public string companytype = string.Empty;

        public string pg = string.Empty;

        public string Pgtype = string.Empty;

        public string mode = string.Empty;

        public string From = string.Empty;

        public string type = string.Empty;

        public int ClientID;

        public int CompanyID;

        public int UserID;

        public long CostID;

        public string CostCentreID = "";

        public long rtnCostID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

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

        public cost_selector()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.btncancel.Attributes.Add("OnClientClick", "javascript:loadingimg('div_btncancel','div_cancelprocess');");
            if (this.Pgtype.ToString().ToLower() != "client")
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
                return;
            }
            if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
            {
                this.pnlCostCenter.Visible = true;
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "CloseSave();", true);
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            this.btnsave.Attributes.Add("OnClientClick", "javascript:loadingimg('div_btnadd','div_btnaddprocess');");
            if (this.Pgtype.ToString().ToLower() != "client")
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "CloseSave();", true);
            }
            else if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
            {
                this.pnlCostCenter.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "CloseSave();", true);
            }
            if (this.mode == "add")
            {
                int num = 0;
                int num1 = 0;
                num = (!this.chk_CostDefault.Checked ? 0 : 1);
                num1 = (!this.chk_ApplyDept.Checked ? 0 : 1);
                DepartmentBaseClass.costcenter_details_insert(this.CompanyID, this.ClientID, this.objBase.SpecialEncode(this.txtcostcentercode.Text), this.objBase.SpecialEncode(this.txtcostcentername.Text), num1, num, this.UserID);
                base.Session["IsAddedCC"] = "yes";
                return;
            }
            int num2 = 0;
            int num3 = 0;
            num2 = (!this.chk_CostDefault.Checked ? 0 : 1);
            num3 = (!this.chk_ApplyDept.Checked ? 0 : 1);
            DepartmentBaseClass.costcenter_details_update(Convert.ToInt32(this.hdncostcenterid.Value), this.ClientID, this.objBase.SpecialEncode(this.txtcostcentercode.Text), this.objBase.SpecialEncode(this.txtcostcentername.Text), num3, num2, this.UserID);
            base.Session["IsAddedCC"] = "up";
        }

        public void Edit()
        {
            DataTable dataTable = new DataTable();
            dataTable = DepartmentBaseClass.costcenter_details_select(this.CostCentreID);
            if (dataTable.Rows.Count > 0)
            {
                this.txtcostcentercode.Text = dataTable.Rows[0]["CostCentreCode"].ToString();
                this.txtcostcentername.Text = dataTable.Rows[0]["CostCentreName"].ToString();
                string str = dataTable.Rows[0]["IsApplyDepartment"].ToString();
                string str1 = dataTable.Rows[0]["IsDefault"].ToString();
                if (str.ToString() != "True")
                {
                    this.chk_ApplyDept.Checked = false;
                }
                else
                {
                    this.chk_ApplyDept.Checked = true;
                }
                if (str1.ToString() == "True")
                {
                    this.chk_CostDefault.Checked = true;
                    return;
                }
                this.chk_CostDefault.Checked = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btncancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnsave.Text = this.objLangClass.GetLanguageConversion("Save");
            BaseClass baseClass = new BaseClass();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            base.Request.Url.ToString();
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
                this.Pgtype = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["ClientID"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["ClientID"].ToString());
            }
            if (base.Request.Params["companytype"] != null)
            {
                this.companytype = base.Request.Params["companytype"].ToString();
            }
            if (base.Request.Params["mode"] != null)
            {
                this.mode = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["CostCentreID"] != null)
            {
                this.CostCentreID = base.Request.Params["CostCentreID"].ToString();
                this.hdncostcenterid.Value = base.Request.Params["CostCentreID"].ToString();
                base.Session["CostCentreID"] = base.Request.Params["CostCentreID"].ToString();
                this.CostID = Convert.ToInt64(base.Request.Params["CostCentreID"].ToString());
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString().ToLower().Trim();
            }
            this.txtcostcentercode.Focus();
            if (this.mode == "edit")
            {
                this.Edit();
            }
        }
    }
}