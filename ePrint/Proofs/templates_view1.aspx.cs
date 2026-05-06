using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.Proofs
{
    public partial class templates_view1 : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string iframePath = string.Empty;

        public string iframePathForEditTemplate = string.Empty;

        public int EmailCount;

        public string TempKey = string.Empty;

        public object objPrintBroker;

        public string OnlyOneTemp = string.Empty;

        public int PageSize = 25;

        public string ordid = string.Empty;

        public string maintype = string.Empty;
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

        public templates_view1()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Title = "Proof: Templates";
            this.gloobj.setpagename("Proofs");
            if (base.Request.Params["GenPdf"] != null && base.Request.Params["GenPdf"].ToLower() == "all")
            {
                this.Session["SelectedItemForPrint"] = null;
            }
            if (base.Request.Params["page"] == null || !(base.Request.Params["page"].ToString().ToLower() == "printbroker"))
            {
                //string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"], " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>" };
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_details"), "</a>&nbsp;>&nbsp;<a href=../Estimates/Proofs.aspx class='subnavigator'  style='text-decoration:underline;'>Proof View</a>&nbsp;>&nbsp;<a href=../Proofs/Proof_summary.aspx?estid="+ base.Request.Params["EstID"] + "&EstItemID=0&ProofID=", base.Request.Params["ProofID"], " class='subnavigator'  style='text-decoration:underline;'>Proof Summary</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email")));
                return;
            }
            if (this.Session["maintype"] != null)
            {
                this.maintype = this.Session["maintype"].ToString();
            }
            if (base.Request.Params["maintype"] != null)
            {
                this.maintype = base.Request.Params["maintype"].ToString();
            }
            if (this.maintype.ToLower() == "edit")
            {
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), "&estitemid=", base.Request.Params["EstItemID"].ToString(), "&recall=y&maintype=", this.maintype.ToLower(), " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Templates")));
                return;
            }
            if (this.maintype.ToLower() != "add")
            {
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"], " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Templates")));
                return;
            }
            string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_details"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>&nbsp;>&nbsp;<a href=../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), "&estitemid=", base.Request.Params["EstItemID"].ToString(), "&maintype=", this.maintype.ToLower(), " class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>" };
            base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Templates")));
        }
    }
}