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
    public partial class StripeSettings :  BaseClass, IRequiresSessionState
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
      
            SettingsBasePage.UpdateStripeDetails(Convert.ToInt32(CompanyID), str, this.StripeKey.Text, this.imgToSave); //this.StripeKey.Text
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Display_Settings_Saved_Successfully"), "msg-success", this.plhMessage);
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Stripe");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Stripe")));
            base.Title = this.objlang.GetLanguageConversion("Stripe");
            this.SettingName = this.objlang.GetLanguageConversion("Stripe");
            string[] clientID;
            if (base.Request.Params["page"] == null)
            {
                this.PageType = "StripeSettings";
            }
            if (!base.IsPostBack)
            {
                string str = HttpContext.Current.Request.Url.Host.ToString();
                if (str.Trim().ToLower() == "localhost" || str.Trim().ToLower() == "192.168.1.6")
                {
                    str = ConfigurationManager.AppSettings["HostName"].ToString();
                }
                DataTable dataTable = SettingsBasePage.GetStripeDetails(Convert.ToInt32(CompanyID), str);


                foreach(DataRow dr in dataTable.Rows)
                {
                   
                    this.StripeKey.Text = dr["StripeKey"].ToString();
                    if (dr["StripeImage"].ToString() != "")
                    {
                        this.hid_StripeImage.Value = dr["StripeImage"].ToString();
                        this.StripeUploadimage.Attributes.Add("style", "display:none");
                        this.lblStripeImage.Attributes.Add("style", "display:block");
                        QueryString queryString = new QueryString()
                        {
                            { "doctype", "stripenew" },
                            { "filename", Convert.ToString(dr["StripeImage"]) }
                        };
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        Label label = this.lblStripeImage;
                        clientID = new string[] { "<a href='", this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", dr["StripeImage"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' onclick=RemoveImage('image'); title='Remove'>" };
                        label.Text = string.Concat(clientID);
                    }
                }

            }


        }

       
    }
}