using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.orders
{
    public partial class templates_view1 : BaseClass, IRequiresSessionState
    {
       

        private Global gloobj = new Global();

        public string maintype = string.Empty;

        public string ORDERID = string.Empty;

        public string ESTID = string.Empty;

        private static long CompanyID;

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

        static templates_view1()
        {
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                templates_view1.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"]);
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.ORDERID = base.Request.Params["ordid"].ToString();
            }
            if (base.Request.Params["estid"] != null)
            {
                this.ESTID = base.Request.Params["estid"].ToString();
            }
            if (base.Request.Params["GenPdf"] != null && base.Request.Params["GenPdf"].ToLower() == "all")
            {
                this.Session["SelectedItemForPrint"] = null;
            }
            this.gloobj.setpagename("webstoreorder");
            base.Title = "eStore Order: Templates";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_view"), "</a>&nbsp;>&nbsp;<a href=../orders/order_summary.aspx?frm=view&ordid=", this.ORDERID, "&estid=", this.ESTID, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Templates")));
        }

        [WebMethod]
        public static string SaveEmailedTemplate(string strattachment, string PDFKey)
        {
            SettingsBasePage.settings_template_emailed_insert(strattachment, PDFKey, templates_view1.CompanyID);
            return PDFKey;
        }
    }
}