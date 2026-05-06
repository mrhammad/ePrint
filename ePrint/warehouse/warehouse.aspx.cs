using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.warehouse
{
    public partial class warehouse : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string type = string.Empty;

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        public string strHeader = string.Empty;

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

        public warehouse()
        {
        }

        protected void btnitem_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("item_finishedgoods_add.aspx?page=item");
        }

        protected void btnstore_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("item_finishedgoods_add.aspx?page=store");
        }

        [WebMethod]
        public static string FetchDependancy(string CompanyID, string InventoryIds)
        {
            string str = "";
            string str1 = "";
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("InventoryID");
            dataTable1.Columns.Add("DependancyValue");
            string[] strArrays = InventoryIds.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                str = "";
                long num = Convert.ToInt64(strArrays[i].ToString());
                dataTable = InventoryBasePage.Fetch_Inventory_Dependancy(Convert.ToInt64(CompanyID), num);
                if (dataTable.Rows[0]["InkCount"].ToString() == "1")
                {
                    str = "Ink";
                }
                else if (dataTable.Rows[0]["PaperCount"].ToString() == "1")
                {
                    str = "Paper";
                }
                else if (dataTable.Rows[0]["PlateCount"].ToString() == "1")
                {
                    str = "Plate";
                }
                DataRow dataRow = dataTable1.NewRow();
                dataRow["InventoryID"] = num;
                dataRow["DependancyValue"] = str;
                dataTable1.Rows.Add(dataRow);
            }
            dataTable1.AcceptChanges();
            foreach (DataRow row in dataTable1.Rows)
            {
                if (row["DependancyValue"] == null)
                {
                    str = "Plate";
                    break;
                }
                else if (row["DependancyValue"] == null)
                {
                    str = "Ink";
                    break;
                }
                else if (row["DependancyValue"] != null)
                {
                    str = "";
                }
                else
                {
                    str = "Paper";
                    str1 = "Paper";
                }
            }
            if (str1 != "" && str == "")
            {
                str = str1;
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("warehouse", "isview", "");
            global.pageName = "Warehouse";
            this.gloobj.setpagename("Warehouse");
            this.Session["pgtype"] = null;
            base.Title = this.objLanguage.convert(global.pageTitle("Warehouse", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (base.Request.Params["type"].ToString().ToLower() == "inventory")
            {
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;padding-left:4px;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Warehouse_Inventory")));
                this.Session["pgtype"] = "inventory";
                this.strHeader = "Warehouse: Inventory";
            }
            else if (base.Request.Params["type"].ToString().ToLower() != "store")
            {
                base.Navigation_Path("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;padding-left:4px;'>Home</a>", "&nbsp;>&nbsp;Warehouse: Customer Item");
                this.Session["pgtype"] = "item";
                this.strHeader = "Warehouse: Customer Item";
            }
            else
            {
                base.Navigation_Path("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;padding-left:4px;'>Home</a>", "&nbsp;>&nbsp;Warehouse: Store Supply");
                this.Session["pgtype"] = "store";
                this.strHeader = "Warehouse: Store Supply";
            }
            try
            {
                this.type = base.Request.Params["type"].ToString();
            }
            catch
            {
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
        }
    }
}