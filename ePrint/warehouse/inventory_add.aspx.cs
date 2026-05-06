using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;


namespace ePrint.warehouse
{
    public partial class inventory_add : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

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

        public inventory_add()
        {
        }

        [WebMethod]
        public static int FindOutNew(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.ReplaceSingleQuote(strArrays[1]);
            string str2 = baseClass.ReplaceSingleQuote(strArrays[2]);
            long num = Convert.ToInt64(strArrays[3]);
            InventoryBasePage inventoryBasePage = new InventoryBasePage();
            int num1 = inventoryBasePage.warehouse_inventoryduplicacy_check(Convert.ToInt32(str), str1, str2, num);
            return num1;
        }

        [WebMethod]
        public static string GetPaperHeightWidth(string val)
        {
            string[] strArrays = val.Split(new char[] { '&' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            DataTable dataTable = SettingsBasePage.settings_papersize_select(Convert.ToInt32(str), Convert.ToInt32(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Height"].ToString();
                empty1 = row["Width"].ToString();
            }
            return string.Concat(empty, "µ", empty1);
        }

        // Ticket 80178 
        [WebMethod]
        public static string ddlInvCategory_SelectedIndexChanged(string ddlInvCategory)
        {
         commonClass comm = new commonClass();
        int CompanyID = Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString());
            DataTable dataTable = SettingsBasePage.settings_system_markup_select(CompanyID);
            string Markup = string.Empty;
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                //// for custom catagories and indexing in dropdown, it is changed to ddl text from index ticket 88415

                //if (ddlInvCategory == "0")
                //    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["Inks"].ToString()), 0, "", false, false, true);
                //else if (ddlInvCategory == "1")
                //    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["Paper"].ToString()), 0, "", false, false, true);
                //else
                //    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["InventoryItems"].ToString()), 0, "", false, false, true);

                if (ddlInvCategory == "Inks")
                    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["Inks"].ToString()), 0, "", false, false, true);
                else if (ddlInvCategory == "Paper")
                    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["Paper"].ToString()), 0, "", false, false, true);
                else 
                    Markup = comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["InventoryItems"].ToString()), 0, "", false, false, true);  
            }
            return Markup;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("warehouse", "isview", "");
            BaseClass baseClass = new BaseClass();
            global.pageName = "Warehouse";
            global.pgName = "";
            this.gloobj.setpagename("Warehouse");
            if (base.Request.Params["type"] == null)
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href='../warehouse/warehouse.aspx?type=inventory' class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Inventory Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else if (base.Request.Params["type"] == "edit")
            {
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href='../warehouse/warehouse.aspx?type=inventory' class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_Edit")));
                base.Title = this.objLanguage.convert(global.pageTitle("Inventory Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                return;
            }
        }
    }
}