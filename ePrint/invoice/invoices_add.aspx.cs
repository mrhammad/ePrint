using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.Invoices;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.invoice
{
    public partial class invoices_add : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_Item_estimate_stage1_new UCStage1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private Global gloobj = new Global();

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        public invoices_add()
        {
        }

        [WebMethod]
        public static string GetClientName(string val)
        {
            return val;
        }

        [WebMethod]
        public static string GetContactAddress(string CompID, string ContactID)
        {
            string str = CompanyBasePage.company_contact_address_select(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
            return str;
        }

        [WebMethod]
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
        }

        [WebMethod]
        public static int GetInvoiceDueDate(string ClientID)
        {
            return EstimateBasePage.Get_Client_PaymentTerms(Convert.ToInt64(ClientID));
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

        protected void onclik_cancel(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_item_form.aspx", this.InvID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("invoices", "isadd", "");
            global.pageName = "Invoice";
            global.pgName = "";
            this.gloobj.setpagename("Invoice");
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            try
            {
                if (base.Request.QueryString["estid"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                }
            }
            catch
            {
            }
            if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add Invoice", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), "&nbsp;>&nbsp;Invoice Add");
                return;
            }
            if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                string str = InvoiceBasePage.Is_INVOICE_from_Webstore(this.InvoiceID);
                string empty = string.Empty;
                if (str.ToLower() != "yes")
                {
                    object[] estimateID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                    empty = string.Concat(estimateID);
                }
                else
                {
                    object[] objArray = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                    empty = string.Concat(objArray);
                }
                base.Title = this.objLanguage.convert(global.pageTitle("Edit Invoice", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", empty, "Invoice Edit"));
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