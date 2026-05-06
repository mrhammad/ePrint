using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.Estimates
{
    public partial class estimate_quotedetails_panel : BaseClass, IRequiresSessionState
    {
        //protected RadWindowManager RadWindowManager1;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessageNew;

        //protected usercontrol_Item_item_summary_supplierquotedetails ucQuotedetails;

        private BaseClass objbase = new BaseClass();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        private Global gloobj = new Global();

        public string Module = string.Empty;

        private long EstimateItemID;

        private long EstimateID;

        private string ItemTitle = string.Empty;

        private BaseClass objBase = new BaseClass();

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

        public estimate_quotedetails_panel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl htmlControl = (HtmlControl)base.Master.FindControl("DivLeftpanel");
            HtmlControl htmlControl1 = (HtmlControl)base.Master.FindControl("DivLeftpanel1");
            HtmlControl htmlControl2 = (HtmlControl)base.Master.FindControl("RightPanel");
            htmlControl.Style.Add("display", "none");
            htmlControl2.Style.Add("width", "100%");
            if (base.Request.QueryString["estitemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["estitemID"]);
                this.ItemTitle = base.Request.QueryString["title"];
                this.Module = base.Request.QueryString["Module"];
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Quote Details Updated Successfully", "msg-success", this.plhMessage);
            }
            if (base.Request.Params["estid"] != null && base.Request.Params["estid"] != "")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>" };
            string str = string.Concat(languageConversion);
            object[] estimateID = new object[] { "&nbsp;>&nbsp;<a href=../estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Quote_Details") };
            base.Navigation_Path(str, string.Concat(estimateID));
            base.Title = this.objLanguage.convert(global.pageTitle("Estimate Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "order")
            {
                foreach (DataRow row in EstimatesBasePage.EstimateitemIDList_PerEstItemID(this.EstimateItemID).Rows)
                {
                    this.ucQuotedetails.QuoteDetails_Bind(Convert.ToInt64(row["ItemID"]), row["ItemTitle"].ToString(), row["IDList"].ToString());
                }
            }
            global.pageName = "estimate";
            global.pgName = "";
            this.gloobj.setpagename("estimate");
            base.Title = this.objLanguage.convert(global.pageTitle("Estimate Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}