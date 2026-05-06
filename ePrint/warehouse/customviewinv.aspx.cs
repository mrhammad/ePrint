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
namespace ePrint.warehouse
{
    public partial class customviewinv : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

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

        public customviewinv()
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
            int num = EstimateBasePage.Estimate_ViewNameduplicacy_check(Convert.ToInt32(str), str1, Convert.ToInt32(str2), "inventory");
            return num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("warehouse", "isadd", "");
            global.pageName = "warehouse";
            global.pgName = "";
            this.pg = "inventory";
            this.gloobj.setpagename("warehouse");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["type"] == null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New Inventory View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../warehouse/warehouse.aspx?type=inventory class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), " </a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_View_Add")));
            }
            else if (base.Request.Params["type"].ToString().ToLower() != "edit")
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New Inventory View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../warehouse/warehouse.aspx?type=inventory class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), " </a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_View_Add")));
            }
            else
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New Inventory View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../warehouse/warehouse.aspx?type=inventory class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), " </a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_View_AddOREdit")));
            }
            this.ucCustomViewInv.pg = "inventory";
        }
    }
}