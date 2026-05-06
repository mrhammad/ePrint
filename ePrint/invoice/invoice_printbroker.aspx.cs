using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.invoice
{
    public partial class invoice_printbroker : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public int IsItemCompleted;

        public long EstSingleItemID;

        public long EstPadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "job";

        public string widthsize = string.Empty;

        private Global gloobj = new Global();

        public string FromSummary = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long InvoiceID;

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

        public invoice_printbroker()
        {
        }

        [WebMethod]
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
        }

        [WebMethod]
        public static string GetSuppliers_List(string StrCompanyID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.supplier_select_in_printbroker(Convert.ToInt32(StrCompanyID));
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("invoice");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            try
            {
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
            }
            catch
            {
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            string empty = string.Empty;
            empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                if (base.Request.QueryString["esttype"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                    this.Select_OutWork_Item();
                }
                string str = string.Empty;
                if (this.FromSummary == "sum" || this.QueryType == "edit")
                {
                    if (empty.ToString().ToLower() != "yes")
                    {
                        object[] estimateID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary&nbsp;></a>" };
                        str = string.Concat(estimateID);
                    }
                    else
                    {
                        object[] objArray = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary&nbsp;></a>" };
                        str = string.Concat(objArray);
                    }
                }
                base.Navigation_Path(string.Concat("<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>Invoice View</a> &nbsp;>&nbsp;", str), "&nbsp;Invoice Edit: Outwork");
                base.Title = this.objLanguage.convert(global.pageTitle("Invoice Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
            {
                string empty1 = string.Empty;
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                    {
                        if (empty.ToString().ToLower() != "yes")
                        {
                            object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                            empty1 = string.Concat(estimateID1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                            empty1 = string.Concat(objArray1);
                        }
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>Invoice View</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(strArrays), "&nbsp;Invoice Add: Outwork");
                    }
                }
                else if (base.Request.Params["maintype"] != "edit")
                {
                    base.Navigation_Path(string.Concat("<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>Invoice View</a> &nbsp;>&nbsp;", empty1), "Invoice Add: Outwork");
                }
                else
                {
                    if (empty.ToString().ToLower() != "yes")
                    {
                        object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                        empty1 = string.Concat(estimateID2);
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>Invoice Summary</a>&nbsp;>" };
                        empty1 = string.Concat(objArray2);
                    }
                    string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>Invoice View</a> &nbsp;>&nbsp;", empty1 };
                    base.Navigation_Path(string.Concat(strArrays1), "&nbsp;Invoice Add: Outwork");
                }
                base.Title = this.objLanguage.convert(global.pageTitle("Invoice Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
        }

        private void Select_OutWork_Item()
        {
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            if (this.EstimateItemID != (long)0)
            {
                string str = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                this.hid_single_outworkData.Value = string.Concat(str, "µ");
            }
        }
    }
}