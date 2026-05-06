using nmsCommon;
using nmsConnection;
using Printcenter.UI.CMS;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore.usercontrol
{
    public partial class account_left_banner2 : UserControl
    {
        protected PlaceHolder plhLeftBanner;

        protected HtmlGenericControl account_leftBanner;

        protected Panel pnlaccount;

        private commonclass comm = new commonclass();

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string SesseionKey = string.Empty;

        public long StoreUserID;

        public int CompanyID;

        public static int AccountID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static account_left_banner2()
        {
        }

        public account_left_banner2()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            base.Request.Url.ToString().ToLower().Contains("account/account");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                account_left_banner2.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            int num = 0;
            int num1 = 0;
            DataTable dataTable = CMSBasePage.Select_BannerImages((long)account_left_banner2.AccountID, 0, "L", "My Accounts");
            foreach (DataRow row in dataTable.Rows)
            {
                if (num1 == 0)
                {
                    this.plhLeftBanner.Controls.Add(new LiteralControl("<div>"));
                }
                object[] item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", row["bannerImage"], "&amp;type=b&aid=", account_left_banner2.AccountID, "&cid=", this.CompanyID };
                string str = string.Concat(item);
                if (row["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhLeftBanner.Controls;
                    object[] objArray = new object[] { "<div><img src='", str, "' class='imgWidth BorderWhite' alt='", row["bannerTitle"], "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhLeftBanner.Controls;
                    object[] item1 = new object[] { "<div><a href='", row["URL"], "'><img src='", str, "' alt='", row["bannerTitle"], "' class='BorderWhite' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item1)));
                }
                num1++;
                num++;
            }
            if (num1 != 0)
            {
                this.plhLeftBanner.Controls.Add(new LiteralControl("</div>"));
            }
            if (num == 0)
            {
                this.account_leftBanner.Attributes.Add("class", "account_leftBanner_empty");
            }
        }
    }
}