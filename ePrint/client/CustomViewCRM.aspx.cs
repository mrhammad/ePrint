using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Estimates;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.client
{
    public partial class CustomViewCRM : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

        public string companytype = "Customer";

        public string PageTitle = string.Empty;

        public string NavigationName = string.Empty;

        public languageClass objLangClass = new languageClass();

        private BaseClass objBase = new BaseClass();

        public string DisplayName = string.Empty;

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

        public CustomViewCRM()
        {
        }

        [WebMethod]
        public static int GetViewName(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.ReplaceSingleQuote(strArrays[1]);
            string str2 = strArrays[2];
            int num = EstimateBasePage.Estimate_ViewNameduplicacy_check(Convert.ToInt32(str), str1, Convert.ToInt32(str2), "crm");
            return num;
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
            this.pg = "client";
            this.gloobj.setpagename("client");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["pgtype"] != null && base.Request.Params["pgtype"].ToString() != "")
            {
                this.companytype = base.Request.Params["pgtype"].ToString();
                if (this.companytype.ToLower() == "supplier")
                {
                    this.companytype = "Supplier";
                }
                if (this.companytype.ToLower() == "prospect")
                {
                    this.companytype = "Prospect";
                }
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString() != "edit")
                {
                    this.PageTitle = "Add New CRM View";
                    this.NavigationName = " view add";
                    if (base.Request.Params["pgtype"].ToString().ToLower() == "customer")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Customer_View_Add");
                    }
                    else if (base.Request.Params["pgtype"].ToString().ToLower() == "supplier")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Supplier_View_Add");
                    }
                    else if (base.Request.Params["pgtype"].ToString().ToLower() == "prospect")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Prospect_View_Add");
                    }
                }
                else
                {
                    this.PageTitle = "CRM Edit View";
                    this.NavigationName = " view edit";
                    if (base.Request.Params["pgtype"].ToString().ToLower() == "customer")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Customer_View_Edit");
                    }
                    else if (base.Request.Params["pgtype"].ToString().ToLower() == "supplier")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Supplier_View_Edit");
                    }
                    else if (base.Request.Params["pgtype"].ToString().ToLower() == "prospect")
                    {
                        this.DisplayName = this.objLangClass.GetLanguageConversion("Prospect_View_Edit");
                    }
                }
            }
            else if (base.Request.Params["pgtype"] != null)
            {
                this.PageTitle = "Add New CRM View";
                this.NavigationName = " view add";
                if (base.Request.Params["pgtype"].ToString().ToLower() == "customer")
                {
                    this.DisplayName = this.objLangClass.GetLanguageConversion("Customer_View_Add");
                }
                else if (base.Request.Params["pgtype"].ToString().ToLower() == "supplier")
                {
                    this.DisplayName = this.objLangClass.GetLanguageConversion("Supplier_View_Add");
                }
                else if (base.Request.Params["pgtype"].ToString().ToLower() == "prospect")
                {
                    this.DisplayName = this.objLangClass.GetLanguageConversion("Prospect_View_Add");
                }
            }
            base.Title = this.objLanguage.convert(global.pageTitle(this.PageTitle, int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (base.Request.Params["pgtype"] != null)
            {
                if (base.Request.Params["pgtype"].ToString().ToLower() == "customer")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("CRM_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.DisplayName));
                }
                else if (base.Request.Params["pgtype"].ToString().ToLower() == "supplier")
                {
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx?type=supplier class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Supplier_View"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.DisplayName));
                }
                else if (base.Request.Params["pgtype"].ToString().ToLower() == "prospect")
                {
                    string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx?type=prospect class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Prospect_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.DisplayName));
                }
            }
            this.ucCustomViewCRM.pg = "client";
        }
    }
}