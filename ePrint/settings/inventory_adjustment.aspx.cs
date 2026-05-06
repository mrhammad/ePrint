using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.settings
{
    public partial class inventory_adjustment : BaseClass, IRequiresSessionState
    {
        private InventoryBasePage objinv = new InventoryBasePage();

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string type = string.Empty;

        public int CompanyID;

        public int UserID;

        public int totalrec;

        private commonClass cmns = new commonClass();

        public int PageSize = 10000;

        public string pg = string.Empty;

        public static string SearchText;

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

        static inventory_adjustment()
        {
            inventory_adjustment.SearchText = string.Empty;
        }

        public inventory_adjustment()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["userID"].ToString());
            global.pageName = "Warehouse";
            global.pgName = "";
            this.gloobj.setpagename("Warehouse");
            this.pg = "inventory";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href='../warehouse/warehouse.aspx?type=inventory' class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_Adjustment")));
            base.Title = this.objLanguage.convert(global.pageTitle("Inventory Export", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}