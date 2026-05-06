using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;


namespace ePrint.ProductCatalogue
{
    public partial class CustomViewProduct : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

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

        public CustomViewProduct()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "productcatalogue";
            global.pgName = "";
            this.pg = "productcatalogue";
            this.gloobj.setpagename("productcatalogue");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["type"] == null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New ProductCatalogue View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../productcatalogue/pricecatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("ProductCatalogue_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("ProductCatalogue_View_Add")));
            }
            else if (base.Request.Params["type"].ToString().ToLower() != "edit")
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New ProductCatalogue View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../productcatalogue/pricecatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("ProductCatalogue_View"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("ProductCatalogue_View_Add")));
            }
            else
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New ProductCatalogue View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../productcatalogue/pricecatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("ProductCatalogue_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("ProductCatalogue_View_AddOREdit")));
            }
            this.ucCustomView.pg = "productcatalogue";
        }
    }
}