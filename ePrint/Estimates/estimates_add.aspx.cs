using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint
{
    public partial class estimates_add : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_Item_estimate_stage1_new UCStage1;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public string EstimateType = string.Empty;

        private Global gloobj = new Global();

        public string newdate = string.Empty;

        public string DateFormat = string.Empty;

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

        public estimates_add()
        {
        }

        [WebMethod]
        public static string GetClientName(string val)
        {
            return val;
        }

        [WebMethod]
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
        }

        [WebMethod]
        public static string GetPaperHeightWidth(string CompID, string InventoryID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_paperproperties_select(Convert.ToInt32(CompID), Convert.ToInt64(InventoryID));
            return empty;
        }

        [WebMethod]
        public static string GetSalesPerson(string CompID, string ClientID)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            string str = companyBasePage.main_company_salesperson_select(Convert.ToInt32(ClientID), Convert.ToInt32(CompID));
            return str;
        }

        [WebMethod]
        public static string GetInvoiceContact(string CompID, string ClientID)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            string str = companyBasePage.main_company_InvocieContact_select(Convert.ToInt32(ClientID), Convert.ToInt32(CompID));
            return str;
        }

        [WebMethod]
        public static string GetSuppliers_List(string StrCompanyID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.supplier_select_in_printbroker(Convert.ToInt32(StrCompanyID));
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        public bool HasValue(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (o == DBNull.Value)
            {
                return false;
            }
            if (o is string && ((string)o).Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }

        protected void onclik_cancel(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_item_form.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("estimates", "isadd", "");
            global.pageName = "estimate";
            global.pgName = "";
            this.pg = "estimate";
            this.gloobj.setpagename("estimate");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            languageClass _languageClass = new languageClass();
            this.DateFormat = this.Session["DateFormat"].ToString();
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Estimate_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Estimate_Add")));
            base.Title = _languageClass.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!this.HasValue(base.Request.Params["type"]))
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    EstimateBasePage.etimates_tempattachment_delete(this.CompanyID, this.UserID);
                }
                if (base.Request.Params["type"].ToLower().Trim() == "edit")
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    object[] estimateID = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>&nbsp", _languageClass.GetLanguageConversion("Estimate_Add") };
                    string str = string.Concat(estimateID);
                    if (base.Request.Params["prev"] != null && base.Request.Params["prev"].ToLower().Trim() == "y")
                    {
                        str = _languageClass.GetLanguageConversion("Estimate_Add");
                    }
                    base.Navigation_Path(string.Concat("<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Estimate_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", str, _languageClass.GetLanguageConversion("Estimate_Edit")));
                    base.Title = _languageClass.convert(global.pageTitle("Estimate Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    if (!this.HasValue(base.Request.Params["estid"]))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
                    }
                    if (base.Request.Params["EstItemID"] != null)
                    {
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
                        this.EstimateType = base.Request.Params["esttype"].ToString();
                    }
                    if (!base.ValidatePageURL(this.CompanyID, "estimate", this.EstimateID, this.EstimateItemID, this.EstimateType, "edit"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
                    }
                }
            }
        }

        [WebMethod]
        public static void RemoveOtherCostItem(string CompID, string EstOtherCostID)
        {
            EstimateBasePage.Estimate_Summary_OtherCost_Remove(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
            EstimateBasePage.estimate_othercost_variableqty_delete(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
        }

        [WebMethod]
        public static void RemovePrintBroker(string CompID, string EstOutworkID, string OutworkType)
        {
            long num = Convert.ToInt64(EstOutworkID);
            EstimateBasePage.Estimate_Outwork_Delete(Convert.ToInt32(CompID), num, OutworkType);
        }

        [WebMethod]
        public static void RemoveWarehouseItem(string CompID, string EstWarehouseItemID)
        {
            EstimateBasePage.Estimate_Summary_Warehouse_Delete(Convert.ToInt32(CompID), Convert.ToInt64(EstWarehouseItemID));
        }
        [WebMethod]
        public static string GetContactFirstName(string ContactID)
        {
            string firstName = EstimateBasePage.GetContactFirstName(ContactID);
            return firstName;
        }
    }
}