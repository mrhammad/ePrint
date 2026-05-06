using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;

namespace ePrint.usercontrol.Item
{
    public partial class Proof_Template : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strFilepath = global.filePath();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        private Template objTemplate = new Template();

        public languageClass objLangClass = new languageClass();

        public languageClass objLanguage = new languageClass();

       

        private int CompanyID;

        public int UserID;

        public int TemplateID;

        public int EstimateID;
        public int ProofID;

        public int EstimateItemID;

        private int CustomerID;

        private int AttentionID;

        private string[] arryTag;

        private string TagNames = string.Empty;

        private int Items;

        private string RFQdescription = string.Empty;

        private string StrEsimateItemID = string.Empty;

        private string StrEstimateType = string.Empty;
        public int totalrec;

        public int DefTemplateID;

        public string PageType = string.Empty;

        public int sectionid;

        public string sectionname = string.Empty;

        public string CompanyType = string.Empty;

        public string report_page = string.Empty;

        public string PDFIsFrom = string.Empty;

        private double Price;

        private double TaxValue;

        private double TotalIncTax;

        private string[] AryStrNoteQty;

        private string[] AryStrDescription;

        private string[] AryStrPurCode;

        private string[] AryStrPurQty;

        private string[] AryStrPurDesc;

        private string[] AryStrPurPrice;

        private string[] AryStrPurTotPriceIncTax;

        public string iframePath = string.Empty;

        public string iframePathChooseTemp = string.Empty;

        public string iframePathpdf = string.Empty;

        public string iframePathForEditTemplate = string.Empty;

        public string iframeEmailPath = string.Empty;

        public int EmailCount;

        public string TempKey = string.Empty;

        public object objPrintBroker;

        public string OnlyOneTemp = string.Empty;

        public int PageSize = 25;

        public string ordid = string.Empty;

        public string maintype = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Module = string.Empty;
        public int EstID;
        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EstimateID = Convert.ToInt32(base.Request.Params["EstID"].ToString());
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.PageType = base.Request.Params["page"].ToString();
            if (base.Request.Params["sectionid"].ToString() != "" && base.Request.Params["sectionid"].ToString() != null)
            {
                this.sectionid = Convert.ToInt32(base.Request.Params["sectionid"].ToString());
            }
            this.sectionname = base.Request.Params["sectionname"].ToString();
            this.CompanyType = base.Request.Params["type"].ToString();
            this.report_page = base.Request.Params["page"].ToString();
            base.Request.Url.ToString();
            if (base.Request.QueryString["ProofID"] != null)
            {
                this.ProofID = Convert.ToInt32(base.Request.Params["ProofID"]);
            }
            this.EstID = this.EstimateID;
            if ((base.Request.Params["Page"].ToString().ToLower() == "job" || base.Request.Params["Page"].ToString().ToLower() == "printbroker") && base.Request.Params["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt32(base.Request.Params["EstItemID"].ToString());
            }
            if (base.Request.Url.ToString().ToLower().Contains("estimates/templates_view1.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/templates_view1.aspx"))
            {
                this.PDFIsFrom = "e";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/templates_view1.aspx"))
            {
                this.PDFIsFrom = "j";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/templates_view1.aspx"))
            {
                this.PDFIsFrom = "i";
            }
            if (this.ordid == "")
            {
                this.ordid = base.Request.Params["EstID"].ToString();
            }
            string empty = string.Empty;
            if (base.Request.Params["isdirect"] != null)
            {
                empty = "&isdirect=1";
            }
            if (!base.IsPostBack)
            {

                object[] objArray8 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&ordid=", this.ordid, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                this.iframeEmailPath = string.Concat(objArray8);
                if (base.Request.Url.ToString().ToLower().Contains("proofs/templates_view1.aspx"))
                {
                    this.iframePath = string.Concat(this.iframeEmailPath, "&ProofID=", ProofID);
                }
               
            }
        }

    }
}