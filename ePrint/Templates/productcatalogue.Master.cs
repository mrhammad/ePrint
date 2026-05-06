using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.ProductCatalogue
{
    public partial class productcatalogue : System.Web.UI.MasterPage
    {
        private string _callbackResult;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string pg;

        public string pgDetailname;

        public string color = string.Empty;

        public string colorformat = string.Empty;

        public int height;

        public string width = string.Empty;

        public languageClass objLanguage = new languageClass();

        private BaseClass objbase = new BaseClass();

        public BasePage objpage = new BasePage();

        public string tabcolor = string.Empty;

        public string forecolor = "";

        public int companyid;

        public string roundoff = string.Empty;

        public string WebStore = string.Empty;

        public string MYOB = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string TabSelection = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string AccountingExport = ConnectionClass.AccountingExport;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public productcatalogue()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().IndexOf("dmcsportonline") != -1)
            {
                bool flag = false;
                string lower = base.Request.Url.ToString().ToLower();
                if (lower.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower = lower.Replace("http", "https");
                    flag = true;
                }
                if (lower.ToString().ToLower().IndexOf("https://dmcsportonline.com.au") != -1)
                {
                    lower = lower.Replace("https://dmcsportonline.com.au", "https://www.dmcsportonline.com.au");
                    flag = true;
                }
                if (flag)
                {
                    base.Response.Redirect(lower);
                }
            }
            if (base.Session["CompanyID"] != null)
            {
                string str = string.Concat(ConnectionClass.faviconpath, base.Session["CompanyID"].ToString(), "/favicon.ico");
                this.Head1.Controls.Add(new LiteralControl(string.Concat("<link rel='shortcut icon' href='", str, "'>")));
                this.Head1.DataBind();
            }
            if (base.Session["companyID"] != null)
            {
                this.companyid = int.Parse(base.Session["companyID"].ToString());
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "error.aspx"));
            }
            this.objbase.CheckUserAccessRight("productcatalogue");
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow row in dataTable.Rows)
            {
                this.roundoff = row["Roundoff"].ToString();
            }
            this.Page.Header.DataBind();
            BasePage basePage = new BasePage();
            this.colorformat = basePage.GetRegionalSettings(int.Parse(base.Session["companyID"].ToString()), "colour");
            basePage.logoSetting(this.plhHeader, this.plhFooter, int.Parse(base.Session["companyID"].ToString()), "both");
            this.forecolor = this.objpage.Forecolor(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.objbase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
        }
    }
}