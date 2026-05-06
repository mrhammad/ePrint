using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.orders
{
    public partial class order_pricecatalog : BaseClass, IRequiresSessionState
    {
        public BaseClass objBase = new BaseClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

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

        public string tabtype = "order";

        public string widthsize = string.Empty;

        public string Pub_CustomerID = "0";

        public string Pub_CustomerName = "";

        private Global gloobj = new Global();

        public string EstTypeFromSP = string.Empty;

        private long ParentItemID;

        private string ParentItemType = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string req_type = string.Empty;

        public string FromSummary = string.Empty;

        public string frmcopyitem = string.Empty;

        public int IsItemCompleted;

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

        public order_pricecatalog()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "webstoreorder";
            this.gloobj.setpagename("webstoreorder");
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
            if (base.Request.Params["type"] != null)
            {
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    string empty = string.Empty;
                    this.req_type = "add";
                    if (base.Request.Params["estid"] != null)
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    }
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                        {
                            object[] estimateID = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;>" };
                            empty = string.Concat(estimateID);
                            string[] languageConversion = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", empty };
                            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Order_Add_Product_Catalogue")));
                        }
                    }
                    else if (base.Request.Params["maintype"] != "edit")
                    {
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Order_Add_Product_Catalogue"));
                    }
                    else
                    {
                        object[] objArray = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(objArray);
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Order_Add_Product_Catalogue")));
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Order Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "more", true) == 0)
                {
                    this.req_type = "more";
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
                {
                    if (base.Request.Params["estid"] != null)
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    }
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    this.req_type = "edit";
                    string str = string.Empty;
                    if (this.FromSummary == "sum" || base.Request.Params["type"].ToString() == "edit")
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;></a>" };
                        str = string.Concat(estimateID1);
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Order_Edit_Product_Catalogue")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Order Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                    else if (this.IsItemCompleted == 0)
                    {
                        base.Navigation_Path(string.Concat("<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", str, this.objLanguage.GetLanguageConversion("Order_Add_Product_Catalogue")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Order Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                }
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (this.frmcopyitem == "yes" && string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
            {
                return;
            }
            if (this.frmcopyitem != "yes" && string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
            {
                return;
            }
            if (this.frmcopyitem != "yes")
            {
                string.Compare(base.Request.Params["type"].ToString(), "edit", true);
            }
        }
    }
}