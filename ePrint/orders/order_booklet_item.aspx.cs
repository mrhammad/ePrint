using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
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
namespace ePrint.orders
{
    public partial class order_booklet_item : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string req_type = string.Empty;

        public string FromSummary = string.Empty;

        public long EstimateID;

        public int IsItemCompleted;

        public long EstimateItemID;

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

        public order_booklet_item()
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
            global.pageName = "webstoreorder";
            this.gloobj.setpagename("webstoreorder");
            try
            {
                if (base.Request.QueryString["estid"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                }
                if (base.Request.QueryString["ordid"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["ordid"]);
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
            if (base.Request.Params["type"] != null)
            {
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    this.req_type = "add";
                    string empty = string.Empty;
                    if (base.Request.Params["FromAddAnItem"] == null)
                    {
                        base.Navigation_Path(string.Concat("<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_Add_Booklet")));
                    }
                    else if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                    {
                        object[] estimateID = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(estimateID);
                        string[] languageConversion = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Order_Add_Booklet")));
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Order Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
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
                    string str = string.Empty;
                    if (this.FromSummary == "sum")
                    {
                        object[] objArray = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;>" };
                        str = string.Concat(objArray);
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Order_Edit_Booklet")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Order Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    if (this.IsItemCompleted == 0)
                    {
                        base.Navigation_Path(string.Concat("<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_Add_Booklet")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Order Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                }
            }
        }
    }
}