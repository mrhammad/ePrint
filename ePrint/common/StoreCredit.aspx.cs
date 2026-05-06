using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class StoreCredit : System.Web.UI.Page, IRequiresSessionState
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["IDs"].ToString() != null)
            {
                this.IDs = base.Request.Params["IDs"].ToString();
            }
            string[] strArrays = this.IDs.Split(new char[] { ',' });
            this.CompanyID = int.Parse(this.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
               
                commonClass _commonClass1 = this.comm;
                var now = DateTime.Now;
               

               

                DataTable dataTable6 = CompanyBasePage.PC_company_StoreCredit_select(Convert.ToInt32(strArrays[0]));
                foreach (DataRow row in dataTable6.Rows)
                {
                  
                    txt_CreditAmount.Text = row["StoreCredit"].ToString();
                }
            }
                }

        protected void btnSaveSpendlimit_Click(object sender, EventArgs e)
        {
            string[] strArrays = this.IDs.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                this.objcomm.StoreCreditUpdate(this.CompanyID, Convert.ToInt64(strArrays[i]), Convert.ToDouble(txt_CreditAmount.Text));
            }

            this.pnlLoadContactPanel.Visible = true;

        }

    }
}