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
namespace ePrint.Delivery
{
    public partial class templates_view1 : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public languageClass objLangClass = new languageClass();

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

        public templates_view1()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                templates_view1.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"]);
            }
            base.Title = this.objLangClass.GetLanguageConversion("Delivery_Note_Templates");
            this.gloobj.setpagename("deliverynote");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../delivery/delivery_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Delivery_Note_View"), "</a>&nbsp;>&nbsp;<a href=../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"], " class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Delivery_Note_Details"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Templates")));
        }

        [WebMethod]
        public static string SaveEmailedTemplate(string strattachment, string PDFKey)
        {
            SettingsBasePage.settings_template_emailed_insert(strattachment, PDFKey, templates_view1.CompanyID);
            return PDFKey;
        }
    }
}