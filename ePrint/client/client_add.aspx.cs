using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace ePrint.client
{
    public partial class client_add : BaseClass, IRequiresSessionState
    {
        private BaseClass objBase = new BaseClass();

        private Global gloobj = new Global();

        public languageClass objLanguage = new languageClass();

        private BaseClass basecls = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private BasePage comnbasepage = new BasePage();

        public commonClass comncls = new commonClass();

        public int CompanyID;

        public int UserID;

        public string DateFormat = string.Empty;

        public string companytype = string.Empty;

        public int ClientID;

        private int isnew = 2;

        public string newdate = string.Empty;

        public string action = string.Empty;

        public string postback = string.Empty;

        public string mode = string.Empty;

        public string id = string.Empty;

        public languageClass objLangClass = new languageClass();

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

        public client_add()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl htmlControl = (HtmlControl)base.Master.FindControl("DivLeftpanel");
            HtmlControl htmlControl1 = (HtmlControl)base.Master.FindControl("DivLeftpanel1");
            HtmlControl htmlControl2 = (HtmlControl)base.Master.FindControl("RightPanel");
            htmlControl.Style.Add("display", "none");
            htmlControl2.Style.Add("width", "100%");
            this.objBase.ReturnRoles_Privileges_Tabs("clients", "isadd", "");
            global.pageName = "client";
            global.pgName = "";
            this.gloobj.setpagename("client");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Add New Company", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateFormat = this.Session["DateFormat"].ToString();
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
            if (base.Request.Params["type"] == null)
            {
                try
                {
                    string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                    ArrayList arrayLists = Encryption.querystrvalue(str);
                    this.companytype = arrayLists[7].ToString();
                    this.action = arrayLists[9].ToString();
                    try
                    {
                        this.isnew = int.Parse(Convert.ToString(arrayLists[3]));
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            else
            {
                this.companytype = base.Request.Params["type"].ToString();
                try
                {
                    //this.postback = base.Request.Params["post"]?.ToString() ?? string.Empty;
                    //this.mode = base.Request.Params["mode"].ToString();
                    //this.id = base.Request.Params["id"].ToString();
                }
                catch
                {
                }
            }
            if (this.companytype != "")
            {
                if (this.companytype.ToLower() == "customer" && this.action != "edit")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("CRM_View"), "</a>" };
                    string str1 = string.Concat(languageConversion);
                    string[] strArrays = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Customer"), " ", this.objLangClass.GetLanguageConversion("Add"), " " };
                    base.Navigation_Path(str1, string.Concat(strArrays));
                    return;
                }
                if (this.companytype.ToLower() == "customer" && this.action == "edit")
                {
                    string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("CRM_View"), "</a>" };
                    string str2 = string.Concat(languageConversion1);
                    string[] strArrays1 = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Customer"), " ", this.objLangClass.GetLanguageConversion("Edit"), " " };
                    base.Navigation_Path(str2, string.Concat(strArrays1));
                    return;
                }
                if (this.companytype.ToLower() == "supplier" && this.action != "edit")
                {
                    string[] languageConversion2 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Supplier_View"), "</a>" };
                    string str3 = string.Concat(languageConversion2);
                    string[] strArrays2 = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Supplier"), " ", this.objLangClass.GetLanguageConversion("Add"), " " };
                    base.Navigation_Path(str3, string.Concat(strArrays2));
                    return;
                }
                if (this.companytype.ToLower() == "supplier" && this.action == "edit")
                {
                    string[] languageConversion3 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Supplier_View"), "</a>" };
                    string str4 = string.Concat(languageConversion3);
                    string[] strArrays3 = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Supplier"), " ", this.objLangClass.GetLanguageConversion("Edit"), " " };
                    base.Navigation_Path(str4, string.Concat(strArrays3));
                    return;
                }
                if (this.companytype.ToLower() == "prospect" && this.action != "edit")
                {
                    string[] languageConversion4 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Prospect_View"), "</a>" };
                    string str5 = string.Concat(languageConversion4);
                    string[] strArrays4 = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Prospect"), " ", this.objLangClass.GetLanguageConversion("Add"), " " };
                    base.Navigation_Path(str5, string.Concat(strArrays4));
                    return;
                }
                if (this.companytype.ToLower() == "prospect" && this.action == "edit")
                {
                    string[] languageConversion5 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Prospect_View"), "</a>" };
                    string str6 = string.Concat(languageConversion5);
                    string[] strArrays5 = new string[] { "&nbsp;>&nbsp; ", this.objLangClass.GetLanguageConversion("Prospect"), " ", this.objLangClass.GetLanguageConversion("Edit"), " " };
                    base.Navigation_Path(str6, string.Concat(strArrays5));
                }
            }
        }
    }
}