using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using System.Configuration;
using Printcenter.UI.Setting;
using System.Data;
using System.Web.SessionState;

namespace ePrint.settings
{
    public partial class StripeRedirect :  BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        public int CompanyID;

        public int UserID;

        public string SettingName;

        public string strSitepath = global.sitePath();

        public string PageType;

        private BaseClass objbase = new BaseClass();

        public string strSitePath = global.sitePath();

        public string imgToSave = string.Empty;

        public string strImagepath = global.imagePath();

        public string LogoURL = string.Empty;



        public void btnSave_Click(object sender, EventArgs e)
        {

            HttpCookie httpCookie = base.Request.Cookies["cke_uploadimageName"];
            if (httpCookie != null)
            {
                this.imgToSave = httpCookie["stripeUploadImgname"];
                httpCookie.Expires = DateTime.Now.AddDays(-1);
                base.Response.Cookies.Add(httpCookie);
            }
            else if (!string.IsNullOrEmpty(this.hid_StripeImage.Value))
            {
                this.imgToSave = this.hid_StripeImage.Value;
            }
            else
            {
                this.imgToSave = "";
            }
            string str = HttpContext.Current.Request.Url.Host.ToString();
            if (str.Trim().ToLower() == "localhost" || str.Trim().ToLower() == "192.168.1.6")
            {
                str = ConfigurationManager.AppSettings["HostName"].ToString();
            }

            QueryString queryString = new QueryString()
                        {
                            { "doctype", "stripenew" },
                            { "filename", Convert.ToString(this.hid_StripeImage.Value) }
                        };
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);

            this.LogoURL = String.Concat(this.strSitePath, "DocManagerView.ashx", queryString1.ToString().Trim());

            string baseLogoURL = this.LogoURL;

            // Split the base URL and query string
            Uri baseUri = new Uri(baseLogoURL);
            string basePath = baseUri.GetLeftPart(UriPartial.Path); // Base path
            string query = baseUri.Query; // Query string

            // Encode the query string values
            var queryParams = HttpUtility.ParseQueryString(query);
            string encodedValue = Uri.EscapeDataString(queryParams.ToString());


            // Reconstruct the full URL
            string encodedUrl = $"{basePath}?{encodedValue}";

            //string encodedUrl = Uri.EscapeDataString(this.LogoURL);
            SettingsBasePage.UpdateStripeSuccessDetails(Convert.ToInt32(CompanyID), str,this.stripeURL.Text, this.stripeMessage.Text, this.imgToSave, baseLogoURL);
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Display_Settings_Saved_Successfully"), "msg-success", this.plhMessage);
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = "Stripe Checkout Link";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Stripe")));
            base.Title = this.objlang.GetLanguageConversion("Stripe");
            this.SettingName = this.objlang.GetLanguageConversion("Stripe");
            string[] clientID;
            if (base.Request.Params["page"] == null)
            {
                this.PageType = "StripeRedirect";
            }
            if (!base.IsPostBack)
            {
                string str = HttpContext.Current.Request.Url.Host.ToString();
                if (str.Trim().ToLower() == "localhost" || str.Trim().ToLower() == "192.168.1.6")
                {
                    str = ConfigurationManager.AppSettings["HostName"].ToString();
                }
                DataTable dataTable = SettingsBasePage.GetStripeSuccessDetails(Convert.ToInt32(CompanyID), str);


                foreach(DataRow dr in dataTable.Rows)
                {
                    this.stripeMessage.Text = dr["message"].ToString();
                    this.stripeURL.Text = dr["redirecturl"].ToString();
                    if (dr["logoimage"].ToString() != "")
                    {
                        this.hid_StripeImage.Value = dr["logoimage"].ToString();
                        this.StripeUploadimage.Attributes.Add("style", "display:none");
                        this.lblStripeImage.Attributes.Add("style", "display:block");
                        QueryString queryString = new QueryString()
                        {
                            { "doctype", "stripenew" },
                            { "filename", Convert.ToString(dr["logoimage"]) }
                        };
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        Label label = this.lblStripeImage;
                        clientID = new string[] { "<a href='", this.strSitePath, "DocManagerView.ashx", queryString1.ToString().Trim(), "' target='_blank'>", dr["logoimage"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' onclick=RemoveImage('image'); title='Remove'>" };
                        label.Text = string.Concat(clientID);
                    }
                }

            }


        }
    }
}