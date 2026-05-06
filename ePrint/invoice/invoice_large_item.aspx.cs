using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
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

namespace ePrint.invoice
{
    public partial class invoice_large_item : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        private BaseClass Objclss = new BaseClass();

        private Global gloobj = new Global();

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public int IsItemCompleted;

        public string QueryType = string.Empty;

        public string FromSummary = string.Empty;

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

        public invoice_large_item()
        {
        }

        [WebMethod(BufferResponse = false)]
        public static string GetPaperHeightWidth(string CompID, string InventoryID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_largeitem_paperproperties_select(Convert.ToInt32(CompID), Convert.ToInt64(InventoryID), "L");
            return empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("invoice");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            string empty = string.Empty;
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    base.Request.Params["parentesttype"].ToString();
                }
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
            string str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            string empty1 = string.Empty;
            if (string.Compare(this.QueryType, "add", true) != 0)
            {
                if (string.Compare(this.QueryType, "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    if (this.FromSummary == "sum" || this.QueryType == "edit")
                    {
                        if (str.ToLower() != "yes")
                        {
                            object[] estimateID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(estimateID);
                        }
                        else
                        {
                            object[] objArray = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(objArray);
                        }
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] languageConversion = new string[] { "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Edit_Large_Item")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Invoice Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    string[] strArrays = new string[] { "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat(">&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Invoice Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                return;
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                {
                    if (str.ToLower() != "yes")
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                        empty1 = string.Concat(estimateID1);
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item")));
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                        empty1 = string.Concat(objArray1);
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item")));
                    }
                }
            }
            else if (base.Request.Params["maintype"] != "edit")
            {
                string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                base.Navigation_Path(string.Concat(languageConversion2), this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item"));
            }
            else if (str.ToLower() != "yes")
            {
                object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                empty1 = string.Concat(estimateID2);
                string[] strArrays2 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                base.Navigation_Path(string.Concat(strArrays2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item")));
            }
            else
            {
                object[] objArray2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                empty1 = string.Concat(objArray2);
                string[] languageConversion3 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                base.Navigation_Path(string.Concat(languageConversion3), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Large_Item")));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Invoice Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}