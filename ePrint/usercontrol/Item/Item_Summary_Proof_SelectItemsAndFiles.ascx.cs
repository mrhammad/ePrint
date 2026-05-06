using System;
using nmsCommon;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using RemovingWhiteSpacesAspNet;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class Item_Summary_Proof_SelectItemsAndFiles : UserControl
    {
        //protected Label Label5;

        //protected ImageButton ImageButton7;

        //protected PlaceHolder Plh_PrintEmail;

        //protected Button btnPrintEmail;

        //protected UpdateProgress upProgress;

        //protected HiddenField hdnPrintURL;

        //protected HiddenField hdnSelectedItemsID;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        private CompanyBasePage objCom = new CompanyBasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public languageClass objLanguage = new languageClass();

        public commonClass objComn = new commonClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string MainType = string.Empty;

        public string DateFormat = string.Empty;

        public bool Check_SpecialPrivilege;

        public string UserName = string.Empty;

        public string Pgtype = "estimate";

        public static int RetPOCount;

        private DateTime TodayDate;

        public long DuplicateEstItemID;

        public long InvoiceID;

        public long jobID;

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

        static Item_Summary_Proof_SelectItemsAndFiles()
        {
        }

        public Item_Summary_Proof_SelectItemsAndFiles()
        {
        }

        protected void btnPrintEmail_Click(object sender, EventArgs e)
        {
            if (this.hdnSelectedItemsID.Value.Length <= 0)
            {
                base.Session["SelectedItemForPrint"] = null;
            }
            else
            {
                this.hdnSelectedItemsID.Value = this.hdnSelectedItemsID.Value.Substring(0, this.hdnSelectedItemsID.Value.Length - 1);
                base.Session["SelectedItemForPrint"] = this.hdnSelectedItemsID.Value;
            }
            if (this.hdnSelectedItemsID.Value.Length <= 0)
            {
                base.Session["SelectedItemForPrint"] = null;
            }
            if (this.hdnProofAppvedURL.Value == "ProofApproved")
            {
                this.hdnPrintURL.Value = this.hdnPrintURL.Value + "&proof=sendProofApproval";
            }
            base.Response.Redirect(this.hdnPrintURL.Value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            if (!base.IsPostBack)
            {
                this.btnPrintEmail.Text = "Proof Files";//this.objLanguage.GetLanguageConversion("Print_Email");
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                this.Pgtype = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
                this.Pgtype = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.Module = "estimate";
                this.Pgtype = "estimate";
            }
            else
            {
                this.Module = "webstoreorder";
                this.Pgtype = "webstoreorder";
            }
            DataTable dataTable = new DataTable();
            if (this.Module == "invoice")
            {
                dataTable = EstimatesBasePage.estimate_item_select_ByModule(this.CompanyID, this.InvoiceID, this.Pgtype);
            }
            else if (this.Module != "job")
            {
                dataTable = (this.Module != "webstoreorder" ? EstimatesBasePage.estimate_item_select_ByModule(this.CompanyID, this.EstimateID, this.Pgtype) : EstimatesBasePage.estimate_item_select_ByModule(this.CompanyID, this.EstimateID, this.Pgtype));
            }
            else
            {
                dataTable = EstimatesBasePage.estimate_item_select_ByModule(this.CompanyID, this.jobID, this.Pgtype);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                CheckBox checkBox = new CheckBox()
                {
                    ID = string.Concat("ChkPrintEmail_", row["EstimateItemID"]),
                    Text = string.Concat(this.objBase.SpecialDecode(row["ItemTitle"].ToString()), "<br/>"),
                    Checked = true
                };
                this.Plh_Items.Controls.Add(checkBox);
            }
        }
    }

}