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
    public partial class invoice_booklet_item : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string req_type = string.Empty;

        public string FromSummary = string.Empty;

        public long EstimateID;

        public int IsItemCompleted;

        public long EstimateItemID;

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

        public invoice_booklet_item()
        {
        }

        [WebMethod]
        public static string GetPaperHeightWidth(string CompID, string InventoryID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_paperproperties_select(Convert.ToInt32(CompID), Convert.ToInt64(InventoryID));
            return empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("invoice");
            try
            {
                if (base.Request.QueryString["estid"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                }
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
                if (base.Request.QueryString["estitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
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
            if (base.Request.Params["type"] != null)
            {
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    this.req_type = "add";
                    string str = string.Empty;
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                        {
                            if (empty.ToString().ToLower() != "yes")
                            {
                                object[] estimateID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                                str = string.Concat(estimateID);
                            }
                            else
                            {
                                object[] objArray = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                                str = string.Concat(objArray);
                            }
                            string[] languageConversion = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", str };
                            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Bookelet_Item")));
                        }
                    }
                    else if (base.Request.Params["maintype"] != "edit")
                    {
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;" };
                        base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Invoice_Add_Bookelet_Item"));
                    }
                    else
                    {
                        if (empty.ToString().ToLower() != "yes")
                        {
                            object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            str = string.Concat(estimateID1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            str = string.Concat(objArray1);
                        }
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Bookelet_Item")));
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Invoice Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    return;
                }
                if (string.Compare(base.Request.Params["type"].ToString(), "more", true) == 0)
                {
                    this.req_type = "more";
                    return;
                }
                if (string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    this.req_type = "edit";
                    string empty1 = string.Empty;
                    if (this.FromSummary == "sum")
                    {
                        if (empty.ToString().ToLower() != "yes")
                        {
                            object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(estimateID2);
                        }
                        else
                        {
                            object[] objArray2 = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(objArray2);
                        }
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Edit_Booklet")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Invoice Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    base.Navigation_Path(string.Concat("<a href=../invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Add_Bookelet_Item")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Invoice Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
            }
        }
    }
}
    