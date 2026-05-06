using ePrint.usercontrol.warehouse;
using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class common_popup : BaseClass, IRequiresSessionState
    {


        public string type;

        public string item;

        public string From;

        public string EstType;

        public string CustomerName = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BaseClass objbase = new BaseClass();

        private Global gloobj = new Global();

        public languageClass objLanguage = new languageClass();

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

        public common_popup()
        {
        }

        [WebMethod]
        public static string CalculateFormulaCost(string FormulaVals)
        {
            return (new MathParser()).Calculate(FormulaVals).ToString();
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
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
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

        [WebMethod]
        public static string GetSuppliersQuote_List(string StrCompanyID, string StrEstimateItemID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.supplier_select_in_QuoteDetails(Convert.ToInt32(StrCompanyID), Convert.ToInt64(StrEstimateItemID));
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pgName = "";
            try
            {
                if (base.Request.QueryString["type"] != null)
                {
                    this.type = base.Request.QueryString["type"].ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.QueryString["item"] != null)
                {
                    this.item = base.Request.QueryString["item"].ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.QueryString["From"] != null)
                {
                    this.From = base.Request.QueryString["From"].ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.QueryString["EstType"] != null)
                {
                    this.EstType = base.Request.QueryString["EstType"].ToString();
                }
            }
            catch
            {
            }
            if (this.type == null)
            {
                base.Response.Write("No type found");
            }
            else if (this.type == "report")
            {
                this.gloobj.setpagename("job");
                base.Title = this.objLanguage.convert(global.pageTitle("Reports List", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/Item/item_reportsList.ascx");
                this.plhDiv.Controls.Add(userControl);
                ((Label)userControl.FindControl("lblClose")).Visible = false;
                HtmlGenericControl htmlGenericControl = (HtmlGenericControl)userControl.FindControl("div_reportsList");
                htmlGenericControl.Attributes.Add("style", "display:block");
            }
            else if (this.type == "jcedit")
            {
                this.gloobj.setpagename("job");
                base.Title = this.objLanguage.convert(global.pageTitle("Job Card", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl1 = (UserControl)base.LoadControl("~/usercontrol/jobs/jobcard_edit.ascx");
                this.plhDiv.Controls.Add(userControl1);
                ((Label)userControl1.FindControl("lblClose")).Visible = false;
                HtmlGenericControl htmlGenericControl1 = (HtmlGenericControl)userControl1.FindControl("div_jobcard_edit");
                htmlGenericControl1.Attributes.Add("style", "display:block");
            }
            else if (this.type == "POadd")
            {
                this.gloobj.setpagename("purchase");
                base.Title = this.objLanguage.convert(global.pageTitle("Add Purchase Order", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/purchase/purchase_add.ascx");
                this.plhDiv.Controls.Add(userControl2);
                HtmlGenericControl htmlGenericControl2 = (HtmlGenericControl)userControl2.FindControl("div_purchase_add");
                htmlGenericControl2.Attributes.Add("style", "display:block");
            }
            else if (this.type == "invselector")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.Request.Params["item"].ToString(), "&nbsp;Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl3 = (UserControl)base.LoadControl("~/usercontrol/warehouse/inventory_item_selector.ascx");
                this.plhDiv.Controls.Add(userControl3);
            }
            else if (this.type == "DCselector")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat("Delivery Cost", "&nbsp;Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl43 = (UserControl)base.LoadControl("~/usercontrol/Delivery_Cost_selector.ascx");
                this.plhDiv.Controls.Add(userControl43);
            }
            else if (this.type == "Paper")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.Request.Params["item"].ToString(), "&nbsp;Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl4 = (UserControl)base.LoadControl("~/usercontrol/warehouse/inventory_add.ascx");
                this.plhDiv.Controls.Add(userControl4);
            }
            else if (this.type == "morefilm")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Paper Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl5 = (UserControl)base.LoadControl("~/usercontrol/item/item_stockonly_po.ascx");
                this.plhDiv.Controls.Add(userControl5);
                HtmlGenericControl htmlGenericControl3 = (HtmlGenericControl)userControl5.FindControl("divfilm");
                htmlGenericControl3.Style.Add("display", "block");
                HtmlGenericControl htmlGenericControl4 = (HtmlGenericControl)userControl5.FindControl("tdaddnew");
                htmlGenericControl4.Style.Add("display", "none");
            }
            else if (this.type == "moreplate")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Paper Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl6 = (UserControl)base.LoadControl("~/usercontrol/item/item_stockonly_po.ascx");
                this.plhDiv.Controls.Add(userControl6);
                HtmlGenericControl htmlGenericControl5 = (HtmlGenericControl)userControl6.FindControl("divplate");
                htmlGenericControl5.Style.Add("display", "block");
                HtmlGenericControl htmlGenericControl6 = (HtmlGenericControl)userControl6.FindControl("tdaddnew");
                htmlGenericControl6.Style.Add("display", "none");
            }
            else if (this.type == "moreplant")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                if (base.Request.Params["islarge"] == null)
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Guillotine Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Cutting Table Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                UserControl userControl7 = (UserControl)base.LoadControl("~/usercontrol/settings/Guillotine_Selector.ascx");
                this.plhDiv.Controls.Add(userControl7);
                HtmlGenericControl htmlGenericControl7 = (HtmlGenericControl)userControl7.FindControl("div_plant_selctor");
            }
            else if (this.type == "actvityHistory")
            {
                this.gloobj.setpagename("client");
                base.Title = this.objLanguage.convert(global.pageTitle("Company-Activity History", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl8 = (UserControl)base.LoadControl("~/usercontrol/customer_activity_history.ascx");
                this.plhDiv.Controls.Add(userControl8);
            }
            else if (this.type == "deptselect")
            {
                string lower = base.Request.QueryString["pg"].ToLower();
                this.gloobj.setpagename(lower);
                base.Title = this.objLanguage.convert(global.pageTitle("Department", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl9 = (UserControl)base.LoadControl("~/usercontrol/Departments/department_selector.ascx");
                this.plhDiv.Controls.Add(userControl9);
            }
            else if (this.type == "moreaddress")
            {
                string str = base.Request.QueryString["pg"].ToString().ToLower().Trim();
                if (str == "contact")
                {
                    str = "client";
                }
                if (str == "estimates")
                {
                    str = "estimate";
                }
                if (str == "jobs")
                {
                    str = "job";
                }
                this.gloobj.setpagename(str);
                if (base.Request.Params["CustomerName"] == null)
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Addresses", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    this.CustomerName = this.objbase.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                    base.Title = string.Concat(this.CustomerName, ": Addresses");
                }
                UserControl userControl10 = (UserControl)base.LoadControl("~/usercontrol/item/address_selector.ascx");
                this.plhDiv.Controls.Add(userControl10);
            }
            else if (this.type == "moreDept")
            {
                string str1 = base.Request.QueryString["pg"].ToString().ToLower().Trim();
                if (str1 == "estimates")
                {
                    str1 = "estimate";
                }
                if (str1 == "jobs")
                {
                    str1 = "job";
                }
                this.gloobj.setpagename(str1);
                if (base.Request.Params["CustomerName"] == null)
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Departments", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    this.CustomerName = this.objbase.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                    base.Title = string.Concat(this.CustomerName, ": Departments");
                }
                UserControl userControl11 = (UserControl)base.LoadControl("~/usercontrol/Departments/deptartment_add.ascx");
                this.plhDiv.Controls.Add(userControl11);
            }
            else if (this.type == "moreCost")
            {
                string str2 = base.Request.QueryString["pg"].ToString().ToLower().Trim();
                if (str2 == "estimates")
                {
                    str2 = "estimate";
                }
                if (str2 == "jobs")
                {
                    str2 = "job";
                }
                this.gloobj.setpagename(str2);
                if (base.Request.Params["CustomerName"] == null)
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Cost Centre", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    this.CustomerName = this.objbase.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                    base.Title = string.Concat(this.CustomerName, ": Cost Centre");
                }
                UserControl userControl12 = (UserControl)base.LoadControl("~/usercontrol/crm/cost_selector.ascx");
                this.plhDiv.Controls.Add(userControl12);
            }
            else if (this.type == "moreCostEdit")
            {
                string str3 = base.Request.QueryString["pg"].ToString().ToLower().Trim();
                if (str3 == "estimates")
                {
                    str3 = "estimate";
                }
                if (str3 == "jobs")
                {
                    str3 = "job";
                }
                this.gloobj.setpagename(str3);
                if (base.Request.Params["CustomerName"] == null)
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Cost Centre", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    this.CustomerName = this.objbase.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                    base.Title = string.Concat(this.CustomerName, ": Cost Centre");
                }
                UserControl userControl13 = (UserControl)base.LoadControl("~/usercontrol/crm/cost_selector.ascx");
                this.plhDiv.Controls.Add(userControl13);
            }
            else if (this.type == "deliveryaddress")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Address Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl14 = (UserControl)base.LoadControl("~/usercontrol/item/address_selector.ascx");
                this.plhDiv.Controls.Add(userControl14);
            }
            else if (this.type == "newcontact")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Customer Contacts", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl15 = (UserControl)base.LoadControl("~/usercontrol/contacts_add.ascx");
                this.plhDiv.Controls.Add(userControl15);
            }
            else if (this.type == "inventory")
            {
                this.gloobj.setpagename("inventory");
                base.Title = this.objLanguage.convert(global.pageTitle("Item Form", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl16 = (UserControl)base.LoadControl("~/usercontrol/item/inventory_add.ascx");
                this.plhDiv.Controls.Add(userControl16);
            }
            else if (this.type == "itemview")
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Item Cost Center View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl17 = (UserControl)base.LoadControl("~/usercontrol/item/item_costcenter_view.ascx");
                this.plhDiv.Controls.Add(userControl17);
            }
            else if (this.type == "warehouse")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Inventory items", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl18 = (UserControl)base.LoadControl("~/usercontrol/warehouse/inventory_store_customer_view.ascx");
                ((inventory_store_customer_view)userControl18).InvenotoryInk = "ink";
                this.plhDiv.Controls.Add(userControl18);
            }
            else if (this.type == "markup")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Markup", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl19 = (UserControl)base.LoadControl("~/usercontrol/Settings/settings_markup.ascx");
                this.plhDiv.Controls.Add(userControl19);
            }
            else if (this.type == "purwarehouse")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.Request.Params["item"].ToString(), "&nbsp;Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl20 = (UserControl)base.LoadControl("~/usercontrol/purchase/warehouse_list.ascx");
                this.plhDiv.Controls.Add(userControl20);
            }
            else if (this.type == "attachments")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Attachments", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl21 = (UserControl)base.LoadControl("~/usercontrol/Item/attachments.ascx");
                this.plhDiv.Controls.Add(userControl21);
            }
            else if (this.type == "proof")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Attachments", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl21 = (UserControl)base.LoadControl("~/usercontrol/Item/prof_attachment_selection.ascx");
                this.plhDiv.Controls.Add(userControl21);
            }
            //////////-------------------------------------
            else if (this.type == "reorderitems")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Reorder Items", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl21 = (UserControl)base.LoadControl("~/usercontrol/Item/items_reorder.ascx");
                this.plhDiv.Controls.Add(userControl21);
            }
            else if (this.type == "multiple_categories")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Add new Categories", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl21_new = (UserControl)base.LoadControl("~/usercontrol/Item/add_multiple_categories.ascx");
                this.plhDiv.Controls.Add(userControl21_new);
            }
            else if (this.type == "select_otherstore")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Select Other Store", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl21_new = (UserControl)base.LoadControl("~/usercontrol/Item/Store_Selector.ascx");
                this.plhDiv.Controls.Add(userControl21_new);
            }
            /////////--------------------------------------
            else if (this.type == "othercost")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("OtherCost", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl22 = (UserControl)base.LoadControl("~/usercontrol/Item/othercost_selector.ascx");
                this.plhDiv.Controls.Add(userControl22);
            }
            else if (this.type == "othercosttabs")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("OtherCost", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl23 = (UserControl)base.LoadControl("~/usercontrol/Item/item_usercostcentres.ascx");
                this.plhDiv.Controls.Add(userControl23);
            }
            else if (this.type == "finishedgoods_import")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Finished Goods: Import", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl24 = (UserControl)base.LoadControl("~/usercontrol/warehouse/finishedgoodsimport.ascx");
                this.plhDiv.Controls.Add(userControl24);
            }
            else if (this.type == "supplier_addmore")
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat("Quote Details: ", this.objLanguage.GetLanguageConversion("Add_More_Supplier")), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl25 = (UserControl)base.LoadControl("~/usercontrol/item/supplier_addmore.ascx");
                this.plhDiv.Controls.Add(userControl25);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && (string.Compare(this.From, "w", true) == 0 || string.Compare(this.From, "C", true) == 0 || string.Compare(this.From, "IU", true) == 0 || string.Compare(this.From, "IO", true) == 0 || string.Compare(this.From, "U", true) == 0 || string.Compare(this.From, "IC", true) == 0))
            {
                this.gloobj.setpagename("estimate");
                global.pageName = "inventory";
                base.Title = this.objLanguage.convert(global.pageTitle("Paper Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl26 = (UserControl)base.LoadControl("~/usercontrol/item/item_cost_view.ascx");
                this.plhDiv.Controls.Add(userControl26);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "paper", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Paper Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl27 = (UserControl)base.LoadControl("~/usercontrol/item/paper_costview.ascx");
                this.plhDiv.Controls.Add(userControl27);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "press", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Press Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl28 = (UserControl)base.LoadControl("~/usercontrol/item/press_costview.ascx");
                this.plhDiv.Controls.Add(userControl28);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "guillotine", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                if (this.EstType.ToLower() != "l")
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Guillotine Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else
                {
                    base.Title = this.objLanguage.convert(global.pageTitle("Cutting Table Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                UserControl userControl29 = (UserControl)base.LoadControl("~/usercontrol/item/guillotine_costview.ascx");
                this.plhDiv.Controls.Add(userControl29);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "ink", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Ink Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl30 = (UserControl)base.LoadControl("~/usercontrol/item/ink_costview.ascx");
                this.plhDiv.Controls.Add(userControl30);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "plates", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Plate Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl31 = (UserControl)base.LoadControl("~/usercontrol/item/plates_costview.ascx");
                this.plhDiv.Controls.Add(userControl31);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "washup", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Wash Up Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl32 = (UserControl)base.LoadControl("~/usercontrol/item/washup_costview.ascx");
                this.plhDiv.Controls.Add(userControl32);
            }
            else if (string.Compare(this.type, "costview", true) == 0 && string.Compare(this.item, "makeready", true) == 0)
            {
                this.gloobj.setpagename("estimate");
                base.Title = this.objLanguage.convert(global.pageTitle("Make Ready Cost View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl33 = (UserControl)base.LoadControl("~/usercontrol/item/makeready_costview.ascx");
                this.plhDiv.Controls.Add(userControl33);
            }
            else if (this.type.ToLower() == "customtext")
            {
                this.gloobj.setpagename("customtext");
                base.Title = this.objLanguage.convert(global.pageTitle("Custom Text", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl34 = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/CustomText.ascx");
                this.plhDiv.Controls.Add(userControl34);
            }
            else if (this.type.ToLower() == "stockedit")
            {
                this.gloobj.setpagename("productcatalogue");
                base.Title = this.objLanguage.convert(global.pageTitle("Stock", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl35 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/ProductCatalogueItem_Stock.ascx");
                this.plhDiv.Controls.Add(userControl35);
            }
            else if (this.type.ToLower() == "categoryallocatedview")
            {
                this.gloobj.setpagename("productcatalogue");
                base.Title = this.objLanguage.convert(global.pageTitle("Allocated Customers", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl36 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/ProductCategory_Allocated_View.ascx");
                this.plhDiv.Controls.Add(userControl36);
            }
            else if (this.type.ToLower() == "estimateproductcatalogue")
            {
                BaseClass baseClass = new BaseClass();
                string str4 = "ProductCatalogue";
                if (base.Request.QueryString["cataloguename"] != null)
                {
                    str4 = base.Request.QueryString["cataloguename"].ToString();
                }

                if (base.Request.QueryString["modulename"] != null)
                {
                    if (base.Request.QueryString["modulename"] == "estimates")
                    {
                        this.gloobj.setpagename("estimate");
                    }
                    else
                    {
                        this.gloobj.setpagename("productcatalogue");
                    }

                }
                else
                {
                    this.gloobj.setpagename("productcatalogue");
                }
                base.Title = this.objLanguage.convert(global.pageTitle(baseClass.SpecialDecode(str4), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl37 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/EstimateProductcatalogueBind.ascx");
                this.plhDiv.Controls.Add(userControl37);
            }
            else if (this.type == "productlist")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Warehouse Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl38 = (UserControl)base.LoadControl("~/usercontrol/purchase/product_list.ascx");
                this.plhDiv.Controls.Add(userControl38);
            }
            else if (this.type == "gdsrcvd")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Warehouse Goods Recieved Details", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl39 = (UserControl)base.LoadControl("~/usercontrol/purchase/purchaseWarehouse_GoodsRcvd.ascx");
                this.plhDiv.Controls.Add(userControl39);
            }
            else if (this.type.ToLower() == "copytonewcust")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                if (base.Request.QueryString["pg"] == "estimate")
                {
                    base.Title = "Copy Estimate";
                }
                else if (base.Request.QueryString["pg"] == "job")
                {
                    base.Title = "Copy Job";
                }
                else if (base.Request.QueryString["pg"] == "invoice")
                {
                    base.Title = "Copy Invoice";
                }
                UserControl userControl40 = (UserControl)base.LoadControl("~/usercontrol/Item/Item_Summary_CopytoNew_SameCustomer.ascx");
                this.plhDiv.Controls.Add(userControl40);
            }
            else if (this.type.ToLower() == "productcatalogueitemstockhistory")
            {
                this.gloobj.setpagename("productcatalogue");
                base.Title = this.objLanguage.convert(global.pageTitle("Stock Allocation", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl41 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/ProductCatalogueItemStockHistory.ascx");
                this.plhDiv.Controls.Add(userControl41);
            }
            ///modification By Bilal Stage 3.5
            else if (this.type.ToLower() == "productcatalogueitemstockpo")
            {
                this.gloobj.setpagename("productcatalogue");
                base.Title = this.objLanguage.convert(global.pageTitle("Stock Purchase Orders", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl42 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/ProductCatalogueItemStockPO.ascx");
                this.plhDiv.Controls.Add(userControl42);
            }
            else if (this.type.ToLower() == "otherstockedit")
            {
                string itemTitle = Request.QueryString["itemTitle"].ToString();
                this.gloobj.setpagename("productcatalogue");
                base.Title = this.objLanguage.convert(global.pageTitle("Edit "+ itemTitle + "", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl43 = (UserControl)base.LoadControl("~/usercontrol/ProductCatalogue/ProductCatalogueItem_Stock_Other.ascx");
                this.plhDiv.Controls.Add(userControl43);
            }
            try
            {
                if (base.Request.Params["module"] != null)
                {
                    string str5 = base.Request.Params["module"].ToString();
                    if (string.Compare(str5, "job", true) == 0)
                    {
                        this.gloobj.setpagename("job");
                    }
                    else if (string.Compare(str5, "invoice", true) == 0)
                    {
                        this.gloobj.setpagename("invoice");
                    }
                    else if (string.Compare(str5, "estimate", true) == 0)
                    {
                        this.gloobj.setpagename("estimate");
                    }
                }
            }
            catch
            {
            }
        }

        [WebMethod]
        public static void RemoveAttachmentFile(string CompID, string AttachmentID)
        {
            EstimateBasePage.estimates_attachment_delete(Convert.ToInt32(CompID), Convert.ToInt64(AttachmentID));
        }

        private void usr2_name_command(string name, int id)
        {
            base.Response.Write(string.Concat(name, "<br/>", id));
            base.Response.End();
        }
    }
}