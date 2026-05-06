using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Templates
{
    public partial class innerMasterPage_withLeftTD : System.Web.UI.MasterPage
    {
        //protected HtmlHead Head1;

        //protected PlaceHolder plhStyle;

        //protected ScriptManager sm1;

        //protected HtmlInputHidden Hidden1;

        //protected PlaceHolder plhHeader;

        //protected templates_header_ascx header1;

        //protected templates_lowerheader_ascx header2;

        //protected usercontrol_home_leftpanel_ascx Home_panel1;

        //protected Panel panel_home;

        //protected usercontrol_company_leftpanel_ascx Printbroker1;

        //protected Panel panel_company;

        //protected usercontrol_printcenter_leftpanel_ascx tint;

        //protected Panel printcenter_leftpanel;

        //protected HtmlGenericControl search;

        //protected HtmlGenericControl showsearch;

        //protected Panel pnlSearch;

        //protected HtmlGenericControl DivLeftpanel;

        //protected HtmlTableCell tdLeftpanel;

        //protected ContentPlaceHolder ContentPlaceHolder1;

        //protected HtmlTableCell RightPanel;

        //protected ContentPlaceHolder ContentPlaceHolder2;

        //protected PlaceHolder plhFooter;

        //protected ImageButton ImageButton1;

        //protected HtmlForm form1;

        public string newdate = string.Empty;

        private string _callbackResult;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string pg;

        public string pgDetailname;

        public string color = string.Empty;

        public int height;

        public string width = string.Empty;

        public languageClass objLanguage = new languageClass();

        private BaseClass objbase = new BaseClass();

        public BasePage objpage = new BasePage();

        public string tabcolor = string.Empty;

        public string forecolor = "";

        public int companyid;

        public string DateFormat = string.Empty;

        public string pgName = string.Empty;

        public string pgtype = string.Empty;

        public string roundoff = string.Empty;

        private commonClass commclass = new commonClass();

        public string currentdate = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;


        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public innerMasterPage_withLeftTD()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(base.Request.Url.ToString().Contains("Proof_summary.aspx"))
            {
                this.footer_border_line.Visible = false;
            }

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
            this.companyid = int.Parse(base.Session["companyID"].ToString());
            if (base.Session["companyID"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "error.aspx"));
            }
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow row in dataTable.Rows)
            {
                this.roundoff = row["Roundoff"].ToString();
            }
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.currentdate = dateTime.ToShortDateString();
            this.Page.Header.DataBind();
            this.DateFormat = this.objpage.GetRegionalSettings(this.companyid, "Dateformat");
            this.pgName = base.Session["pagename"].ToString();
            if (base.Session["pgtype"] != null)
            {
                this.pgtype = base.Session["pgtype"].ToString();
            }
            this.companyid = int.Parse(base.Session["companyID"].ToString());
            this.DateFormat = this.objpage.GetRegionalSettings(this.companyid, "Dateformat");
            if (base.Session["pagename"].ToString() != "moretabs")
            {
                this.forecolor = this.objpage.Forecolor(this.companyid, base.Session["pagename"].ToString());
                this.tabcolor = this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString());
            }
            else
            {
                this.forecolor = "white";
                this.tabcolor = "#8a8a75";
                this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString());
            }
            this.objbase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.width = "100%";
            //if (base.Request.Url.ToString().ToLower().Contains("/client"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //if (base.Request.Url.ToString().ToLower().Contains("client/client_view.aspx") || base.Request.Url.ToString().ToLower().Contains("common/email_send.aspx") || base.Request.Url.ToString().ToLower().Contains("common/email_viewall.aspx") || base.Request.Url.ToString().ToLower().Contains("common/attachment_viewall.aspx"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_view.aspx"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_add_main.aspx"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //else if (base.Request.Url.ToString().ToLower().Contains("contact/contact_viewdetail.aspx"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //else if (base.Request.Url.ToString().ToLower().Contains("client/customviewcrm.aspx"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //else if (base.Request.Url.ToString().ToLower().Trim().Contains("accounts/"))
            //{
            //    this.panel_company.Visible = true;
            //}
            //if (base.Request.Url.ToString().ToLower().Contains("/welcome") || base.Request.Url.ToString().ToLower().Contains("/common/event") || base.Request.Url.ToString().ToLower().Contains("/common/task"))
            //{
            //    this.panel_home.Visible = true;
            //}
            BasePage basePage = new BasePage();
            basePage.logoSetting(this.plhHeader, this.plhFooter, int.Parse(base.Session["companyID"].ToString()), "both");
            bool isPostBack = base.IsPostBack;
            try
            {
                string lower1 = global.pageName.ToLower();
                string str1 = lower1;
                if (lower1 != null)
                {
                    switch (str1)
                    {
                        case "welcome":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "home");
                                break;
                            }
                        case "lead":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "lead");
                                break;
                            }
                        case "client":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "client");
                                break;
                            }
                        case "contact":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "contact");
                                break;
                            }
                        case "campaign":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "campaign");
                                break;
                            }
                        case "ticket":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "ticket");
                                break;
                            }
                        case "solution":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "solution");
                                break;
                            }
                        case "opportunity":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "opportunity");
                                break;
                            }
                        case "contract":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "contract");
                                break;
                            }
                        case "asset":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "asset");
                                break;
                            }
                        case "product":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "product");
                                break;
                            }
                        case "forecast":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "forecast");
                                break;
                            }
                        case "report":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "report");
                                break;
                            }
                        case "document":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "document");
                                break;
                            }
                        case "dashboard":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "dashboard");
                                break;
                            }
                        case "moretabs":
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "moretabs");
                                break;
                            }
                        default:
                            {
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "home");
                                return;
                            }
                    }
                }
                else
                {
                    this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyID"]), "home");
                    return;
                }
            }
            catch
            {
            }
        }
    }
}