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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Templates
{
    public partial class innerMasterPage_withoutLeftTD : MasterPage
    {
        //protected ContentPlaceHolder HeadContent;

        //protected HtmlHead Head1;

        //protected PlaceHolder plhStyle;

        //protected ScriptManager sm1;

        //protected HtmlInputHidden Hidden1;

       // protected PlaceHolder plhHeader;

        //protected Templates_header header1;

        //protected Templates_lowerheader header2;

        //protected ContentPlaceHolder ContentPlaceHolder1;

        //protected PlaceHolder plhFooter;

        //protected HtmlTable outerTable;

        //protected HtmlForm form1;

        public string newdate = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string pg;

        public languageClass objLanguage = new languageClass();

        public BasePage objpage = new BasePage();

        private BaseClass objbase = new BaseClass();

        public string tabcolor = string.Empty;

        public string roundoff = string.Empty;

        public string forecolor = "";

        public int companyid;

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

        public innerMasterPage_withoutLeftTD()
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
            this.companyid = int.Parse(base.Session["companyid"].ToString());
            BaseClass baseClass = this.objbase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            this.forecolor = this.objpage.Forecolor(this.companyid, global.pageName);
            this.tabcolor = this.objpage.colorCode(this.companyid, global.pageName);
            this.objbase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
            this.strImagepath = global.imagePath();
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow row in dataTable.Rows)
            {
                this.roundoff = row["Roundoff"].ToString();
            }
            commonClass _commonClass = new commonClass();
            _commonClass.logoSetting(this.plhHeader, this.plhFooter, int.Parse(base.Session["companyid"].ToString()), "both");
            this.PopulateHeadAssets();
            this.Page.Header.DataBind();
        }

        private void PopulateHeadAssets()
        {
            if (this.ltrHeadAssets == null)
            {
                return;
            }
            string vn = this.VersionNumber ?? string.Empty;
            string ro = this.roundoff ?? string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(1024);
            sb.Append("<script type=\"text/javascript\" src=\"../common/Report.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\" src=\"../common/calendar.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\" src=\"../common/swazz_calendar.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\" src=\"../js/jquery-1.3.2.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\">var roundoff = '").Append(ro).Append("';</script>");
            sb.Append("<script type=\"text/javascript\" src=\"../js/commonloading.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\" src=\"../js/jquery.min.js?VN='").Append(vn).Append("'\"></script>");
            sb.Append("<script type=\"text/javascript\" src=\"../js/jquery.popup.js?VN='").Append(vn).Append("'\"></script>");
            this.ltrHeadAssets.Text = sb.ToString();
        }
    }
}