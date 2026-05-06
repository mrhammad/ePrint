using nmsCommon;
using nmsConnection;
using nmsLanguage;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.WebStore.account
{
    public partial class SpendLimit : BaseClass, IRequiresSessionState
    {
        private commonclass comm = new commonclass();
        public string CurrencySymbol = string.Empty;

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;
        public long StoreUserID;
        public int CompanyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());

            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);

            }
            this.CurrencySymbol = this.comm.GetCurrencyinRequiredFormate("", true);
            System.Data.DataTable dataTable14 = Printcenter.UI.Products.ProductBasePage.Select_SpendLimitAmount_Dashboard(this.StoreUserID, Convert.ToInt32(ConnectionClass.AccountID), this.CompanyID);
            lblSpenlimit.Text = "Your Spend Limit is: N/A";
            lblCurrentSpend.Text = "Current spend in the period: N/A";
            lblBalance.Text = "Balance to spend: N/A";

            foreach (System.Data.DataRow row6 in dataTable14.Rows)
            {
                if (Convert.ToBoolean(row6["IsSpendlimitEnabled"]))
                {

                    lblSpenlimit.Text = "Your Spend Limit is: " + CurrencySymbol + row6["SpendLimitAmount"].ToString() + " Per " + row6["SpendLimitPeriod"].ToString();
                    lblCurrentSpend.Text = "Current spend in the period: " + CurrencySymbol + Convert.ToDecimal(row6["EstimateAmountSpent"]).ToString("n2");
                    lblBalance.Text = "Balance to spend: " + CurrencySymbol + (Convert.ToDecimal(row6["SpendLimitAmount"]) - Convert.ToDecimal(row6["EstimateAmountSpent"])).ToString("n2");
                }
            }


            System.Data.DataTable StoreCredit = Printcenter.UI.Products.ProductBasePage.Select_StoreCreditAmount_Dashboard(this.StoreUserID);
            lblStoreCredit.Text = "Your available store credit is N/A";
           

            foreach (System.Data.DataRow row6 in StoreCredit.Rows)
            {
                if (Convert.ToBoolean(row6["IsStoreCreditsEnabled"]))
                {

                    lblStoreCredit.Text = "Your available store credit is : " + CurrencySymbol + row6["StoreCredit"].ToString() ;
                   
                }
            }

        }
    }
}