using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.Item
{
    public partial class estimate_stage1_new : UsercontrolBasePage
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strfilepath = global.filePath();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        private BasePage objPage = new BasePage();

        private BaseClass objBC = new BaseClass();

        public string Pgtype = "estimate";

        private BaseClass Objclss = new BaseClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string UcStageSection = string.Empty;

        public int CompanyID;

        public int UserID;

        public string ContactName = string.Empty;

        public long EstNo;

        public long InvNo;

        public string DateFormat = "mm/dd/yyyy";

        public string Type = string.Empty;

        public long EstimateID;

        public string Pub_CustomerID = "0";

        public string Pub_CustomerName = "";

        public string IsSatge1 = "display:block;";

        public string newdate = string.Empty;

        public string footerht = string.Empty;

        public DataTable dtstatus_def = new DataTable();

        private string Fromedit = string.Empty;

        private DataTable dtEst = new DataTable();

        private ConnectionClass CC = new ConnectionClass();

        public commonClass comm = new commonClass();

        private long InvoiceNum;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string req_type = string.Empty;

        public string DigitalSingleItem = string.Empty;

        public string DigitalBooklet = string.Empty;

        public string DigitalPads = string.Empty;

        public string DigitalNCR = string.Empty;

        public string OffsetSingleItem = string.Empty;

        public string OffsetPad = string.Empty;

        public string OffsetNCR = string.Empty;

        public string OffsetBooklet = string.Empty;

        public string estimatetype = string.Empty;

        public static string DeliveryNOte;

        private DateTime Estimateartworkdate;

        private DateTime Estimatedeliverydate;

        private DateTime EstimateCreatedDate;

        private DateTime strconvertedate;

        private DateTime JobCompletionDate = DateTime.Now;

        public string AccountingCode = ConnectionClass.AccountingCode;

        private SummaryClass SummaryClassObj = new SummaryClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string serverName = ConnectionClass.ServerName;

        public string ReduceStockTypeNew = string.Empty;

        public bool IsHandy = ConnectionClass.IsHandy;

        public string MainType = "add";

        public long EstimateItemID;

        public long AcCode;

        private DateTime ProofDate;

        private DateTime ApprovalDate;

        private DateTime ProdcnDate;

        private DateTime JobDate = new DateTime();

        public languageClass objLanguage = new languageClass();

        public int WorkingDaysFrom;

        public int WorkingDaysTo;

        public int DefaultEstimatedArtwork;

        public int DefaultEstimatedProof;

        public int DefaultEstimatedApproval;

        public int DefaultEstimatedProduction;

        public int DefaultEstimatedCompletion;

        public int DefaultEstimatedDelivery;

        public string ReduceStockTypeForCancelled = string.Empty;

        private string calcType = string.Empty;

        public long jobID;

        public long invoiceID;

        public long GetJobID;

        public long GetInvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string IsFromWebStore = string.Empty;

        private bool IsArchive_Job;

        public DateTime strInvduedate;

        public string IsFromEstore = string.Empty;

        private DateTime CreatedDate;

        public int estimatorid = 0;

        public string customDatetitle1 = string.Empty;
        public string customDatetitle2 = string.Empty;
        public string customDatetitle3 = string.Empty;
        public string customDatetitle4 = string.Empty;
        public string customDatetitle5 = string.Empty;

        public string DefaultCustomDate1;
        public string DefaultCustomDate2;
        public string DefaultCustomDate3;
        public string DefaultCustomDate4;
        public string DefaultCustomDate5;

        private DateTime? CustomDate1;
        private DateTime? CustomDate2;
        private DateTime? CustomDate3;
        private DateTime? CustomDate4;
        private DateTime? CustomDate5;

        private bool chkEnblePriority=false;

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

        static estimate_stage1_new()
        {
            estimate_stage1_new.DeliveryNOte = string.Empty;
        }

        public estimate_stage1_new()
        {
        }

        protected void btnEditCancel_OnClick(object sender, EventArgs e)
        {
            if (base.Request.QueryString["proofid"] != null)
            {
                HttpResponse response = base.Response;
                long _proofID = Convert.ToInt64(base.Request.QueryString["proofid"]);
                object[]  estimateID = new object[] { this.strSitepath, "Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + _proofID + "" };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (this.Pgtype == "job")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (this.Pgtype != "invoice")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.hdn_IsEstoreInvoice.Value.ToString().ToLower() == "yes")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_order_summary.aspx?estid=0&InvID=", this.invoiceID));
                return;
            }
            HttpResponse response1 = base.Response;
            object[] estimateID1 = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
            response1.Redirect(string.Concat(estimateID1));
        }

        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"].ToString() == "add" || base.Request.Params["type"].ToString() == "Edit")
            {
                this.Click_Add();
            }
            else if (base.Request.Params["type"].ToString() == "more")
            {
                this.Click_Add();
            }
            string empty = string.Empty;
            string str = string.Empty;
            if (this.jobID != (long)0)
            {
                empty = string.Concat("&jID=", this.jobID);
            }
            if (this.invoiceID != (long)0)
            {
                str = string.Concat("&invID=", this.invoiceID);
            }
            if (this.Fromedit == "F")
            {
                if (this.ddlEstimateType.SelectedValue == "pricecatalogue")
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "warehouse")
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_warehouse.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    httpResponse.Redirect(string.Concat(objArray));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalSingleItem")
                {
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response1.Redirect(string.Concat(estimateID1));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalPads")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pad_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    httpResponse1.Redirect(string.Concat(objArray1));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalBooklet")
                {
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_booklet_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalNCR")
                {
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_DigitalNCR_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "othercost", true) == 0)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    httpResponse2.Redirect(string.Concat(objArray2));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "printbroker", true) == 0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response3.Redirect(string.Concat(estimateID3));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "largeformat", true) == 0)
                {
                    HttpResponse httpResponse3 = base.Response;
                    object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, "&calcType=", this.ddlCalcType.SelectedValue.ToString(), empty, str };
                    httpResponse3.Redirect(string.Concat(objArray3));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "QuickQuote", true) == 0)
                {
                    HttpResponse response4 = base.Response;
                    object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response4.Redirect(string.Concat(estimateID4));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "DeliveryCost", true) == 0)
                {
                    HttpResponse response4 = base.Response;
                    object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_DeliveryCost.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    response4.Redirect(string.Concat(estimateID4));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetSingleItem")
                {
                    HttpResponse httpResponse4 = base.Response;
                    object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=add&estid=", this.EstimateID, "&maintype=", this.MainType, empty, str };
                    httpResponse4.Redirect(string.Concat(objArray4));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetNCR")
                {
                    HttpResponse response5 = base.Response;
                    object[] estimateID5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_NCR_item.aspx?type=add&estid=", this.EstimateID, "&FromLitho=yes&maintype=", this.MainType, empty, str };
                    response5.Redirect(string.Concat(estimateID5));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetPad")
                {
                    HttpResponse httpResponse5 = base.Response;
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_pad_item.aspx?type=add&estid=", this.EstimateID, "&FromLitho=yes&maintype=", this.MainType, empty, str };
                    httpResponse5.Redirect(string.Concat(objArray5));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetBooklet")
                {
                    HttpResponse response6 = base.Response;
                    object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_Booklet_item.aspx?type=add&estid=", this.EstimateID, "&FromLitho=yes&maintype=", this.MainType, empty, str };
                    response6.Redirect(string.Concat(estimateID6));
                    return;
                }
            }
            else if (this.Fromedit == "S")
            {
                long num = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
                if (this.ddlEstimateType.SelectedValue == "pricecatalogue")
                {
                    HttpResponse httpResponse6 = base.Response;
                    object[] objArray6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=C&maintype=", this.MainType, empty, str };
                    httpResponse6.Redirect(string.Concat(objArray6));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "warehouse")
                {
                    HttpResponse response7 = base.Response;
                    object[] estimateID7 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_warehouse.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=W&maintype=", this.MainType, empty, str };
                    response7.Redirect(string.Concat(estimateID7));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "othercost", true) == 0)
                {
                    HttpResponse httpResponse7 = base.Response;
                    object[] objArray7 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=U&maintype=", this.MainType, empty, str };
                    httpResponse7.Redirect(string.Concat(objArray7));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "printbroker", true) == 0)
                {
                    HttpResponse response8 = base.Response;
                    object[] estimateID8 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_printbroker.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=O&maintype=", this.MainType, empty, str };
                    response8.Redirect(string.Concat(estimateID8));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "largeformat", true) == 0)
                {
                    HttpResponse httpResponse8 = base.Response;
                    object[] objArray8 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_large_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=L&maintype=", this.MainType, empty, str };
                    httpResponse8.Redirect(string.Concat(objArray8));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "QuickQuote", true) == 0)
                {
                    HttpResponse response9 = base.Response;
                    object[] estimateID9 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_quickquote.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=Q&maintype=", this.MainType, empty, str };
                    response9.Redirect(string.Concat(estimateID9));
                    return;
                }
                if (string.Compare(this.ddlEstimateType.SelectedValue, "DeliveryCost", true) == 0)
                {
                    HttpResponse response9 = base.Response;
                    object[] estimateID9 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_DeliveryCost.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=Q&maintype=", this.MainType, empty, str };
                    response9.Redirect(string.Concat(estimateID9));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalSingleItem")
                {
                    HttpResponse httpResponse9 = base.Response;
                    object[] objArray9 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_single_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=S&maintype=", this.MainType, empty, str };
                    httpResponse9.Redirect(string.Concat(objArray9));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalPads")
                {
                    HttpResponse response10 = base.Response;
                    object[] estimateID10 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_pad_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=P&maintype=", this.MainType, empty, str };
                    response10.Redirect(string.Concat(estimateID10));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalBooklet")
                {
                    HttpResponse httpResponse10 = base.Response;
                    object[] objArray10 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_booklet_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=B&maintype=", this.MainType, empty, str };
                    httpResponse10.Redirect(string.Concat(objArray10));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedDigital" && this.ddlProductType.SelectedValue == "DigitalNCR")
                {
                    HttpResponse httpResponse10 = base.Response;
                    object[] objArray10 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_DigitalNCR_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=R&maintype=", this.MainType, empty, str };
                    httpResponse10.Redirect(string.Concat(objArray10));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetSingleItem")
                {
                    HttpResponse response11 = base.Response;
                    object[] estimateID11 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_single_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=F&maintype=", this.MainType, empty, str };
                    response11.Redirect(string.Concat(estimateID11));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetNCR")
                {
                    HttpResponse httpResponse11 = base.Response;
                    object[] objArray11 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_NCR_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=N&maintype=", this.MainType, empty, str };
                    httpResponse11.Redirect(string.Concat(objArray11));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetPad")
                {
                    HttpResponse response12 = base.Response;
                    object[] estimateID12 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_pad_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=D&maintype=", this.MainType, empty, str };
                    response12.Redirect(string.Concat(estimateID12));
                    return;
                }
                if (this.ddlEstimateType.SelectedValue == "SheetFedOffset" && this.ddlProductType.SelectedValue == "OffsetBooklet")
                {
                    HttpResponse httpResponse12 = base.Response;
                    object[] objArray12 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_litho_booklet_item.aspx?type=edit&estid=", this.EstimateID, "&estitemid=", num, "&esttype=K&maintype=", this.MainType, empty, str };
                    httpResponse12.Redirect(string.Concat(objArray12));
                }
            }
        }

        private void Click_Add()
        {
            this.EstimateID = this.Insert_Estimate_Data();
        }

        public void EstimatesTypesfromDwebconfig()
        {
            int num = 1;
            int num1 = 0;
            int num2 = 0;
            if (ConnectionClass.SheetFedDigital != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Sheet_Fed_Digital"));
                this.ddlEstimateType.Items[num].Value = "SheetFedDigital";
                num++;
            }
            if (ConnectionClass.DigitalSingleItem != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Single_Item"));
                this.ddlProductType.Items[num1].Value = "DigitalSingleItem";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.DigitalSingleItem = ConnectionClass.DigitalSingleItem;
            }
            if (ConnectionClass.DigitalBooklet != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Booklet"));
                this.ddlProductType.Items[num1].Value = "DigitalBooklet";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.DigitalBooklet = ConnectionClass.DigitalBooklet;
            }
            if (ConnectionClass.DigitalPads != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Pads"));
                this.ddlProductType.Items[num1].Value = "DigitalPads";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.DigitalPads = ConnectionClass.DigitalPads;
            }
            if (ConnectionClass.DigitalNCR != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("NCR"));
                this.ddlProductType.Items[num1].Value = "DigitalNCR";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.DigitalNCR = ConnectionClass.DigitalNCR;
            }
            if (ConnectionClass.LargeFormat != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Large_Format"));
                this.ddlEstimateType.Items[num].Value = "largeformat";
                num++;
            }
            if (ConnectionClass.Linear != null)
            {
                this.ddlCalcType.Items.Insert(num2, this.objLanguage.GetLanguageConversion("Linear"));
                this.ddlCalcType.Items[num2].Value = "linear";
                num2++;
            }
            
            if (ConnectionClass.SquareMeter != null)
            {
                string empty = string.Empty;
                if (this.objPage.GetRegionalSettings(Convert.ToInt32(base.Session["CompanyID"].ToString()), "PaperMeasure") != "In.")
                {
                    this.ddlCalcType.Items.Insert(num2, this.objLanguage.GetLanguageConversion("Sqaure_Meter"));
                }
                else
                {
                    this.ddlCalcType.Items.Insert(num2, this.objLanguage.GetLanguageConversion("Square_Feet"));
                }
                this.ddlCalcType.Items[num2].Value = "square";
                num2++;
                bool isSquareMeter = ConnectionClass.IsSquareMeter;
                if (num2 == 2)
                {
                    this.ddlCalcType.SelectedIndex = Convert.ToInt16(ConnectionClass.IsSquareMeter);
                }
            }
            if (ConnectionClass.Tilling != null)
            {
                this.ddlCalcType.Items.Insert(num2, "Tilling");
                this.ddlCalcType.Items[num2].Value = "Tilling";
                num2++;
            }
            if (ConnectionClass.PrintBroker != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Outwork_New"));
                this.ddlEstimateType.Items[num].Value = "printbroker";
                num++;
            }
            if (ConnectionClass.Warehouse != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Inventory"));
                this.ddlEstimateType.Items[num].Value = "warehouse";
                num++;
            }
            if (ConnectionClass.OtherCosts != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("OtherCost"));
                this.ddlEstimateType.Items[num].Value = "othercost";
                num++;
            }
            if (ConnectionClass.PriceCatalogue != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Product_Catalogue"));
                this.ddlEstimateType.Items[num].Value = "pricecatalogue";
                num++;
            }
            if (ConnectionClass.SheetFedOffset != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset"));
                this.ddlEstimateType.Items[num].Value = "SheetFedOffset";
                num++;
            }
            if (ConnectionClass.QuickQuote != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("QuickQuote"));
                this.ddlEstimateType.Items[num].Value = "QuickQuote";
                num++;
            }
            if (ConnectionClass.DeliveryCost != null)
            {
                this.ddlEstimateType.Items.Insert(num, this.objLanguage.GetLanguageConversion("DeliveryCost"));
                this.ddlEstimateType.Items[num].Value = "DeliveryCost";
                num++;
            }
            if (ConnectionClass.OffsetSingleItem != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Single_Item"));
                this.ddlProductType.Items[num1].Value = "OffsetSingleItem";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.OffsetSingleItem = ConnectionClass.OffsetSingleItem;
            }
            if (ConnectionClass.OffsetPad != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Pads"));
                this.ddlProductType.Items[num1].Value = "OffsetPad";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.OffsetPad = ConnectionClass.OffsetPad;
            }
            if (ConnectionClass.OffsetNCR != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("NCR"));
                this.ddlProductType.Items[num1].Value = "OffsetNCR";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.OffsetNCR = ConnectionClass.OffsetNCR;
            }
            if (ConnectionClass.OffsetBooklet != null)
            {
                this.ddlProductType.Items.Insert(num1, this.objLanguage.GetLanguageConversion("Booklet"));
                this.ddlProductType.Items[num1].Value = "OffsetBooklet";
                this.ddlProductType.Items[num1].Attributes.Add("style", "margin-left:15px");
                num1++;
                this.OffsetBooklet = ConnectionClass.OffsetBooklet;
            }
        }

        public int GetWeekNumber(string WeekDay)
        {
            int num = 0;
            string lower = WeekDay.Trim().ToLower();
            string str = lower;
            if (lower != null)
            {
                switch (str)
                {
                    case "sunday":
                        {
                            num = 1;
                            break;
                        }
                    case "monday":
                        {
                            num = 2;
                            break;
                        }
                    case "tuesday":
                        {
                            num = 3;
                            break;
                        }
                    case "wednesday":
                        {
                            num = 4;
                            break;
                        }
                    case "thursday":
                        {
                            num = 5;
                            break;
                        }
                    case "friday":
                        {
                            num = 6;
                            break;
                        }
                    case "saturday":
                        {
                            num = 7;
                            break;
                        }
                    default:
                        {
                            num = -1;
                            return num;
                        }
                }
            }
            else
            {
                num = -1;
                return num;
            }
            return num;
        }

        private long Insert_Estimate_Data()
        {
            int num = 0;
            long num1 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            long num2 = (long)0;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            int num3 = 0;
            DateTime now = DateTime.Now;
            int num4 = 0;
            long num5 = (long)0;
            int num6 = 0;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            long num7 = (long)0;
            long num8 = (long)0;
            string str4 = string.Empty;
            long num9 = (long)0;
            long num10 = (long)0;
            this.Estimateartworkdate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtEstimateartworkDate.Text));
            this.Estimatedeliverydate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtEstimatedeliveryDate.Text));
            this.JobCompletionDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtjobcompletiondate.Text));
            this.ProofDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproofdate.Text));
            this.ApprovalDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtapprovaldate.Text));
            this.ProdcnDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproductiondate.Text));

            this.CustomDate1 = string.IsNullOrEmpty(this.txtCustomDate1.Text)? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate1.Text));
            this.CustomDate2 = string.IsNullOrEmpty(this.txtCustomDate2.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate2.Text));
            this.CustomDate3 = string.IsNullOrEmpty(this.txtCustomDate3.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate3.Text));
            this.CustomDate4 = string.IsNullOrEmpty(this.txtCustomDate4.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate4.Text));
            this.CustomDate5 = string.IsNullOrEmpty(this.txtCustomDate5.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate5.Text));

            commonClass _commonClass = this.comm;
            DateTime dateTime = DateTime.Now;
            DateTime dateTime1 = _commonClass.Eprint_return_ActualDate_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
            if (base.Request.QueryString["clientid"] != null)
            {
                num = Convert.ToInt32(base.Request.QueryString["clientid"]);
            }
            string[] strArrays = this.hid_Stage1_values.Value.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (strArrays1[0].Trim() == "CustomerID")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1]) || Convert.ToInt32(strArrays1[1].Trim()) != 0)
                    {
                        num = Convert.ToInt32(strArrays1[1].Trim());
                    }
                }
                else if (strArrays1[0].Trim() == "ContactID")
                {
                    num1 = (strArrays1[0].Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "CustomerID")
                {
                    num = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Greeting")
                {
                    empty = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Company")
                {
                    str = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "AddressID")
                {
                    num2 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "Header")
                {
                    empty1 = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Footer")
                {
                    str1 = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateTitle")
                {
                    empty2 = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateNumber")
                {
                    str2 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "OrderNumber")
                {
                    empty3 = this.Objclss.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "StatusID")
                {
                    num3 = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateDate")
                {
                    string str5 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                    now = Convert.ToDateTime(str5);
                }
                else if (strArrays1[0].Trim() == "ValidFor")
                {
                    num4 = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "DeliveryAddress")
                {
                    num5 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "SalesPerson")
                {
                    //num6 = Convert.ToInt32(strArrays1[1].Trim());

                    
                    // Check if the array has the required index and the value is a valid integer
                    if (strArrays1.Length > 1 && int.TryParse(strArrays1[1].Trim(), out num6))
                    {
                        // The conversion was successful; num6 now holds the integer value.
                    }
                    else
                    {
                        // Handle the error: set a default value or log a message
                        num6 = 0;
                        // Optional: Response.Write("Invalid format at index 1");
                    }

                }
                //estimator
                else if (strArrays1[0].Trim() == "Estimator")
                {
                    estimatorid = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "AddressType")
                {
                    str3 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "DeliveryAddressType")
                {
                    empty4 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "InvoiceAddressID")
                {
                    num8 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "DepartmentID")
                {
                    num7 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "CostCentreID")
                {
                    num9 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "InvoiceContactId")
                {
                    num10 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
            }
            if (this.Chk_isDefaultTitle.Checked)
            {
                SettingsBasePage.settings_phrasebook_insert(Convert.ToInt32(base.Session["CompanyID"]), "Estimate Title", this.txtEstimateTitle.Text, false, "estimate", "estimate");
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx?"))
            {
                //Ticket # 69944  
                if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
                {
                    estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
                }
                this.EstimateID = EstimateBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(base.Session["UserID"]), num, num1, empty, str, num2, empty1, str1, num6, empty2, str2, empty3, num3, now, num4, num5, false, this.CreatedDate, 0, this.EstimateID, true, str3, empty4, this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, this.EstimateCreatedDate, false, this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9, estimatorid, txtcomments.Text,num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Approved");
                DateTime dateTime2 = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoiceDueDate.Text));
                if (this.invoiceID != (long)0)
                {
                    InvoiceBasePage.invoice_update((long)this.CompanyID, this.GetInvoiceID, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), now, this.CreatedDate, dateTime2, empty1, str1, (long)num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(empty3), num4, (long)num, num1, this.objBase.SpecialEncode(empty), num2, num5, num8, Convert.ToChar(this.hid_InvoiceAddressType.Value), Convert.ToInt64(this.hid_InvoiceAddressClientID.Value), num7, num9, Convert.ToInt64(base.Session["UserID"]), txtcomments.Text, num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                }
                else
                {
                    this.invoiceID = InvoiceBasePage.Invoice_insert(Convert.ToInt32(base.Session["CompanyID"]), this.EstimateID, "DirectInvoice", num3, this.CreatedDate, now, Convert.ToInt32(base.Session["UserID"].ToString()), 0, empty1, str1, 0, ConnectionClass.IsHandy, Convert.ToInt32(num8), Convert.ToChar(this.hid_InvoiceAddressType.Value), Convert.ToInt32(this.hid_InvoiceAddressClientID.Value), dateTime2, (long)0, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                }
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx?"))
            {
                //Ticket # 69944  
                if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
                {
                    estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
                }
                this.EstimateID = EstimateBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(base.Session["UserID"]), num, num1, empty, str, num2, empty1, str1, num6, empty2, str2, empty3, num3, now, num4, num5, false, this.CreatedDate, 0, this.EstimateID, false, str3, empty4, this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, this.EstimateCreatedDate, false, this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9, estimatorid, txtcomments.Text,num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                if(base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add"))
                {
                    this.comm.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, num3, "estimate");
                }
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add"))
                {
                    this.JobDate = now;
                    JobBasePage.job_update(this.CompanyID, this.EstimateID, empty1, str1, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), this.JobDate, this.JobCompletionDate, this.Estimatedeliverydate, this.ProofDate,this.ProdcnDate, this.GetJobID,this.Estimateartworkdate, this.ApprovalDate, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                }
                if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                {
                    DateTime dateTime3 = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoiceDueDate.Text));
                    InvoiceBasePage.invoice_update((long)this.CompanyID, this.GetInvoiceID, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), now, this.CreatedDate, dateTime3, empty1, str1, (long)num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(empty3), num4, (long)num, num1, this.objBase.SpecialEncode(empty), num2, num5, num8, Convert.ToChar(this.hid_InvoiceAddressType.Value), Convert.ToInt64(this.hid_InvoiceAddressClientID.Value), num7, num9, Convert.ToInt64(base.Session["UserID"]), txtcomments.Text, num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                }
            }
            else
            {
                //Ticket # 69944  
                if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
                {
                    estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
                }
                this.EstimateID = EstimateBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(base.Session["UserID"]), num, num1, empty, str, num2, empty1, str1, num6, empty2, str2, empty3, num3, now, num4, num5, false, this.CreatedDate, 0, this.EstimateID, false, str3, empty4, this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, this.EstimateCreatedDate, true, this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9, estimatorid,txtcomments.Text, num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                this.JobDate = now;
                DateTime estimateartworkdate = this.Estimateartworkdate;
                if (this.jobID != (long)0)
                {
                    JobBasePage.job_update(this.CompanyID, this.EstimateID, empty1, str1, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), this.JobDate, this.JobCompletionDate, this.Estimatedeliverydate,this.ProofDate,this.ProdcnDate, this.GetJobID, this.Estimateartworkdate, this.ApprovalDate, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                }
                else
                {
                    this.jobID = JobBasePage.jobs_insert(this.CompanyID, this.EstimateID, "DirectJob", dateTime1, this.JobDate, this.JobCompletionDate, this.Estimatedeliverydate, Convert.ToInt32(base.Session["UserID"]), empty3, estimateartworkdate, this.ApprovalDate, this.ProofDate, this.ProdcnDate, false, num3, ConnectionClass.IsHandy, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                    this.comm.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, num3, "job");
                }
            }
            return this.EstimateID;
        }

        protected void OnClick_btnEditSave(object sender, EventArgs e)
        {
            int num = 0;
            long num1 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            long num2 = (long)0;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            int num3 = 0;
            DateTime now = DateTime.Now;
            int num4 = 0;
            long num5 = (long)0;
            int num6 = 0;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            long num7 = (long)0;
            long num8 = (long)0;
            string str4 = string.Empty;
            long num9 = (long)0;
            long num10 = (long)0;
            //int estimatorid = 0;
            string[] strArrays = this.hid_Stage1_values.Value.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (strArrays1[0].Trim() == "CustomerID")
                {
                    num = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "ContactID")
                {
                    num1 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "CustomerID")
                {
                    num = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Greeting")
                {
                    empty = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Company")
                {
                    str = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "AddressID")
                {
                    num2 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "InvoiceAddressID")
                {
                    num8 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Header")
                {
                    empty1 = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Footer")
                {
                    str1 = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateTitle")
                {
                    empty2 = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateNumber")
                {
                    str2 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "OrderNumber")
                {
                    empty3 = this.objBC.SpecialEncode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "StatusID")
                {
                    num3 = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "EstimateDate")
                {
                    string str5 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                    now = Convert.ToDateTime(str5);
                }
                else if (strArrays1[0].Trim() == "CompletionDate")
                {
                    string str6 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                    this.JobCompletionDate = Convert.ToDateTime(str6);
                }
                else if (strArrays1[0].Trim() == "ArtworkDate")
                {
                    string str7 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                    this.Estimateartworkdate = Convert.ToDateTime(str7);
                }
                else if (strArrays1[0].Trim() == "DeliveryDate")
                {
                    string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                    this.Estimatedeliverydate = Convert.ToDateTime(str8);
                }

                else if (strArrays1[0].Trim() == "CustomDate1")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1].Trim()))
                    {
                        string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                        this.CustomDate1 = Convert.ToDateTime(str8);
                    }
                    else
                    {
                        this.CustomDate1 = null;
                    }
                }
                else if (strArrays1[0].Trim() == "CustomDate2")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1].Trim()))
                    {
                        string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                        this.CustomDate2 = Convert.ToDateTime(str8);
                    }
                    else
                    {
                        this.CustomDate2 = null;
                    }
                }
                else if (strArrays1[0].Trim() == "CustomDate3")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1].Trim()))
                    {
                        string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                        this.CustomDate3 = Convert.ToDateTime(str8);
                    }
                    else
                    {
                        this.CustomDate3 = null;
                    }
                }
                else if (strArrays1[0].Trim() == "CustomDate4")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1].Trim()))
                    {
                        string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                        this.CustomDate4 = Convert.ToDateTime(str8);
                    }
                    else
                    {
                        this.CustomDate4 = null;
                    }
                }
                else if (strArrays1[0].Trim() == "CustomDate5")
                {
                    if (!string.IsNullOrEmpty(strArrays1[1].Trim()))
                    {
                        string str8 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[1].Trim());
                        this.CustomDate5 = Convert.ToDateTime(str8);
                    }
                    else
                    {
                        this.CustomDate5 = null;
                    }
                }


                else if (strArrays1[0].Trim() == "ValidFor")
                {
                    num4 = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "DeliveryAddress")
                {
                    num5 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "SalesPerson")
                {
                    num6 = Convert.ToInt32(strArrays1[1].Trim());
                }
                    //estimator
                else if (strArrays1[0].Trim() == "Estimator")
                {
                    estimatorid = Convert.ToInt32(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "AddressType")
                {
                    str3 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "DeliveryAddressType")
                {
                    empty4 = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "InvoiceAddressID")
                {
                    num8 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "DepartmentID")
                {
                    num7 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "CostCentreID")
                {
                    num9 = Convert.ToInt64(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "InvoiceContactId")
                {
                    num10 = (strArrays1[1].ToLower().Trim() == "undefined" || strArrays1[1].ToLower().Trim() == "" ? (long)0 : Convert.ToInt64(strArrays1[1].Trim()));
                }
            }
            if (this.Chk_isDefaultTitle.Checked)
            {
                SettingsBasePage.settings_phrasebook_insert(Convert.ToInt32(base.Session["CompanyID"]), "Estimate Title", this.txtEstimateTitle.Text, false, "estimate", "estimate");
            }
            if (this.Pgtype == "estimate")
            {
                this.ProofDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproofdate.Text));
                this.ApprovalDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtapprovaldate.Text));
                this.ProdcnDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproductiondate.Text));
                //Ticket # 69944  
                if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
                {
                    estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
                }

                EstimatesBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(base.Session["UserID"]), num, num1, this.objBase.SpecialEncode(empty), this.objBase.SpecialEncode(str), num2, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str1), num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), this.objBase.SpecialEncode(empty3), num3, now, num4, num5, false, this.CreatedDate, Convert.ToInt32(base.Session["UserID"]), this.EstimateID, false, this.objBase.SpecialEncode(str3), this.objBase.SpecialEncode(empty4), this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, "estimate", this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9, estimatorid, this.objBase.SpecialEncode(this.txtcomments.Text), num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                //EstimatesBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(estimatorid), num, num1, this.objBase.SpecialEncode(empty), this.objBase.SpecialEncode(str), num2, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str1), num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), this.objBase.SpecialEncode(empty3), num3, now, num4, num5, false, this.CreatedDate, Convert.ToInt32(base.Session["UserID"]), this.EstimateID, false, this.objBase.SpecialEncode(str3), this.objBase.SpecialEncode(empty4), this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, "estimate", this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9);
                if (this.hid_OldClientID.Value != num.ToString())
                {
                    EstimatesBasePage.updateProfitmargin_OnCustomerChange((long)this.CompanyID, this.EstimateID);
                }
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstInfoRerun);
                this.objnotes.ModuleID = this.EstimateID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.comm;
                DateTime dateTime = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, this.jID };
                if (base.Request.QueryString["proofid"] != null)
                {
                    long _proofID = Convert.ToInt64(base.Request.QueryString["proofid"]);
                    estimateID = new object[] { this.strSitepath, "Proofs/Proof_summary.aspx?estid="+this.EstimateID+"&EstItemID="+this.EstimateItemID+"&ProofID="+_proofID+"" };
                }
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (this.Pgtype != "job")
            {
                if (this.Pgtype == "invoice")
                {
                    DateTime dateTime1 = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoiceDueDate.Text));
                    //Ticket # 69944  
                    //if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
                    //{
                    //    estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
                    //}
                    //InvoiceBasePage.invoice_update((long)this.CompanyID, this.GetInvoiceID, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), now, this.CreatedDate, dateTime1, empty1, str1, (long)num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(empty3), num4, (long)num, num1, this.objBase.SpecialEncode(empty), num2, num5, num8, Convert.ToChar(this.hid_InvoiceAddressType.Value), Convert.ToInt64(this.hid_InvoiceAddressClientID.Value), num7, num9, Convert.ToInt64(base.Session["UserID"]), estimatorid);
                    InvoiceBasePage.invoice_update((long)this.CompanyID, this.GetInvoiceID, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), now, this.CreatedDate, dateTime1, empty1, str1, (long)num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(empty3), num4, (long)num, num1, this.objBase.SpecialEncode(empty), num2, num5, num8, Convert.ToChar(this.hid_InvoiceAddressType.Value), Convert.ToInt64(this.hid_InvoiceAddressClientID.Value), num7, num9, Convert.ToInt64(estimatorid), txtcomments.Text, num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvInfoRerun);
                    this.objnotes.ModuleID = this.GetInvoiceID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass1 = this.objnotes;
                    commonClass _commonClass1 = this.comm;
                    DateTime now1 = DateTime.Now;
                    _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    if (this.hdn_IsEstoreInvoice.Value.ToString().ToLower() == "yes")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_order_summary.aspx?estid=0&InvID=", this.invoiceID));
                        return;
                    }
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse.Redirect(string.Concat(objArray));
                }
                return;
            }
            this.ProofDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproofdate.Text));
            this.ApprovalDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtapprovaldate.Text));
            this.ProdcnDate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtproductiondate.Text));
            //Ticket # 69944  
            if (estimatorid != Convert.ToInt32(ddlEstimator.SelectedValue))
            {
                estimatorid = Convert.ToInt32(ddlEstimator.SelectedValue);
            }
            EstimatesBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(base.Session["UserID"]), num, num1, this.objBase.SpecialEncode(empty), this.objBase.SpecialEncode(str), num2, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str1), num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), this.objBase.SpecialEncode(empty3), num3, now, num4, num5, false, this.CreatedDate, Convert.ToInt32(base.Session["UserID"]), this.EstimateID, false, this.objBase.SpecialEncode(str3), this.objBase.SpecialEncode(empty4), this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, "job", this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9, estimatorid, this.objBase.SpecialEncode(this.txtcomments.Text),num10, this.ddlpriority.SelectedItem.Value, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
            //EstimatesBasePage.Estimate_Insert(this.CompanyID, Convert.ToInt32(estimatorid), num, num1, this.objBase.SpecialEncode(empty), this.objBase.SpecialEncode(str), num2, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str1), num6, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), this.objBase.SpecialEncode(empty3), num3, now, num4, num5, false, this.CreatedDate, Convert.ToInt32(base.Session["UserID"]), this.EstimateID, false, this.objBase.SpecialEncode(str3), this.objBase.SpecialEncode(empty4), this.EstNo, this.Estimateartworkdate, this.Estimatedeliverydate, "job", this.JobCompletionDate, this.ProofDate, this.ApprovalDate, this.ProdcnDate, num8, num7, num9);
            this.JobDate = now;
            JobBasePage.job_update(this.CompanyID, this.EstimateID, empty1, str1, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), this.JobDate, this.JobCompletionDate, this.Estimatedeliverydate, this.ProofDate, this.ProdcnDate, this.GetJobID, this.Estimateartworkdate, this.ApprovalDate, this.CustomDate1, this.CustomDate2, this.CustomDate3, this.CustomDate4, this.CustomDate5);
            this.comm.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(this.ddlStatus.SelectedItem.Value), "job", (long)0, this.jobID);
            this.objnotes.ModuleName = "job";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobInfoRerun);
            this.objnotes.ModuleID = this.jobID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass2 = this.objnotes;
            commonClass _commonClass2 = this.comm;
            DateTime now2 = DateTime.Now;
            _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.InventoryManagement == "IM")
            {
                string empty5 = string.Empty;
                empty5 = this.comm.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeNew = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
                if (this.ReduceStockTypeNew.ToLower() == "p" && this.hdnReduceStockTypeForCancelled.Value.ToLower() == "true" || this.ReduceStockTypeNew.ToLower() == "a")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-status", this.EstimateID, this.CompanyID, (long)0, this.UserID);
                }
                else if (empty5.ToLower() == num3.ToString())
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, (long)0, this.UserID);
                }
            }
            if (this.IsFromWebStore != "YES")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "&ordid=", this.EstimateID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] companyID;
            string[] lower;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.btnNext.Text = this.objLanguage.GetLanguageConversion("Next");
            this.btnEditSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btncancel_address.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnEditCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            if(base.Request.QueryString["proofid"] != null)
            {
                base.Session["pagename"] = "estimate";
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.invoiceID = (long)Convert.ToInt32(base.Request.Params["InvID"]);
            }
            if (base.Request.Params["IsFromWebStore"] != null)
            {
                this.IsFromWebStore = base.Request.Params["IsFromWebStore"].ToString();
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.invoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.invoiceID);
            }
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                this.ImgCustomerAdd.Visible = false;
                this.ImageButton8.Visible = false;
            }
            else
            {
                this.ImgCustomerAdd.Visible = true;
                this.ImageButton8.Visible = true;
            }
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.divArtworkdelivery.Attributes.Add("style", "display:block");
                this.div_ProofNew.Attributes.Add("style", "display:block");
            }
            else
            {
                this.divArtworkdelivery.Attributes.Add("style", "display:none");
                this.div_ProofNew.Attributes.Add("style", "display:none");
            }
            this.txtName.Focus();
            if (!base.IsPostBack)
            {
                this.EstimatesTypesfromDwebconfig();
                this.lbljobNo.Text = this.objLanguage.GetLanguageConversion("Job_Number");
                string digitalNCR = ConnectionClass.DigitalNCR;
                hiddenDigitalNCR.Value = digitalNCR;
            }
            if (base.Request.Params["esttype"] != null)
            {
                this.estimatetype = base.Request.Params["esttype"].ToString();
            }
            if (base.Request.Params["calcType"] != null)
            {
                this.calcType = base.Request.Params["calcType"].ToString();
            }
            if (ConnectionClass.DeliveryNote != null)
            {
                estimate_stage1_new.DeliveryNOte = ConnectionClass.DeliveryNote.ToString();
            }
            if (base.Request.Params["maintype"] != null)
            {
                this.MainType = base.Request.Params["maintype"].ToString();
            }
            this.panelddlestimatefromconfig.Visible = true;
            this.txtName.Attributes.Add("autocomplete", "off");
            this.txtEstimateTitle.Attributes.Add("autocomplete", "off");
            if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
            {
                this.div_costcentre.Style.Add("display", "block");
            }
            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.strInvduedate = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            if (base.Request.Params["type"] != null)
            {
                this.req_type = base.Request.Params["type"].ToString();
                if (string.Compare(this.req_type, "edit", true) == 0 || string.Compare(this.req_type, "more", true) == 0)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                }
                if (string.Compare(this.req_type, "edit", true) == 0 || string.Compare(this.req_type, "more", true) == 0)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                }
            }
            this.UcStageSection = base.BaseSection;
            if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx"))
            {
                this.lbl_proofdate.Text = this.objLanguage.GetLanguageConversion("Estimated_Proof");
                this.lbl_Apprvldate.Text = this.objLanguage.GetLanguageConversion("Estimated_Approval");
                this.lbl_Prdcndate.Text = this.objLanguage.GetLanguageConversion("Estimated_Production");
                this.lbl_Complndate.Text = this.objLanguage.GetLanguageConversion("Estimated_Completion");
                this.lblEstimateDate.Text = this.objLanguage.GetLanguageConversion("Estimate_Date");
                this.lblEstimateArtwork.Text = this.objLanguage.GetLanguageConversion("Estimated_Artwork");
                this.lblEstimateDelivery.Text = this.objLanguage.GetLanguageConversion("Estimated_Delivery");
              
            }
            else if(base.Request.QueryString["proofid"] != null)
            {
                this.lbl_proofdate.Text = this.objLanguage.GetLanguageConversion("Estimated_Proof");
                this.lbl_Apprvldate.Text = this.objLanguage.GetLanguageConversion("Estimated_Approval");
                this.lbl_Prdcndate.Text = this.objLanguage.GetLanguageConversion("Estimated_Production");
                this.lbl_Complndate.Text = this.objLanguage.GetLanguageConversion("Estimated_Completion");
                this.lblEstimateDate.Text = this.objLanguage.GetLanguageConversion("Estimate_Date");
                this.lblEstimateArtwork.Text = this.objLanguage.GetLanguageConversion("Estimated_Artwork");
                this.lblEstimateDelivery.Text = this.objLanguage.GetLanguageConversion("Estimated_Delivery");
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.Pgtype = "job";
                this.lblEstimateDate.Text = this.objLanguage.GetLanguageConversion("Job_Date");
                this.lblEstimateArtwork.Text = this.objLanguage.GetLanguageConversion("Artwork_Date");
                this.lblEstimateDelivery.Text = this.objLanguage.GetLanguageConversion("Delivery_Date");
                this.lblestimatetype.Text = this.objLanguage.GetLanguageConversion("Job_type");
                this.EstNo = (long)0;
                this.lbl_proofdate.Text = this.objLanguage.GetLanguageConversion("Proof_Date");
                this.lbl_Apprvldate.Text = this.objLanguage.GetLanguageConversion("Approval_Date");
                this.lbl_Prdcndate.Text = this.objLanguage.GetLanguageConversion("Production_Date");
                this.lbl_Complndate.Text = this.objLanguage.GetLanguageConversion("Completion_Date");
                if (base.Request.Params["jID"] != null)
                {
                    this.GetJobID = (long)Convert.ToInt32(base.Request.Params["jID"]);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Pgtype = "invoice";
                this.InvNo = this.objComp.settings_lastcounter_select(this.CompanyID, "i") + (long)1;
                this.lblEstimateDate.Text = this.objLanguage.GetLanguageConversion("Invoice_Date");
                this.div_InvoiceDueDate.Style.Add("display", "block");
                if (base.Request.Params["InvID"] != null)
                {
                    this.GetInvoiceID = (long)Convert.ToInt32(base.Request.Params["InvID"]);
                }
            }

            foreach (DataRow dataRow8 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                //this.ddlEstimateType.SelectedValue = dataRow8["DefaultEstimateType"].ToString();
                //this.txtValidFor.Text = dataRow8["ValidFor"].ToString();
                this.lblCustomDate1.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle1"].ToString()) ? "Custom Date 1" : dataRow8["DefaultCustomDateTitle1"].ToString();
                this.lblCustomDate2.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle2"].ToString()) ? "Custom Date 2" : dataRow8["DefaultCustomDateTitle2"].ToString();
                this.lblCustomDate3.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle3"].ToString()) ? "Custom Date 3" : dataRow8["DefaultCustomDateTitle3"].ToString();
                this.lblCustomDate4.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle4"].ToString()) ? "Custom Date 4" : dataRow8["DefaultCustomDateTitle4"].ToString();
                this.lblCustomDate5.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle5"].ToString()) ? "Custom Date 5" : dataRow8["DefaultCustomDateTitle5"].ToString();

            }

            this.DateFormat = base.Session["DateFormat"].ToString();
            this.Label13.Text = string.Concat(this.objBC.ToTitleCase(base.Session["pagename"].ToString(), "p"), " ", this.objLanguage.GetLanguageConversion("Title"));
            if (!base.IsPostBack)
            {
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtEstimateTitle.Attributes.Add("onkeyup", string.Concat("javascript:GetEstimateTitleDetails(this,'estimate','", this.CompanyID, "','1',event);"));
                this.txtEstimateTitle.Attributes.Add("onclick", string.Concat("javascript:GetEstimateTitleDetails(this,'estimate','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnEditSave.ClientID, "');"));
                this.txtGreeting.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnEditSave.ClientID, "');"));
                this.txtCompany.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnEditSave.ClientID, "');"));
                this.txtOrderNumber.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnEditSave.ClientID, "');"));
                if (!base.Request.Browser.IsBrowser("IE"))
                {
                    this.footerht = "11px";
                }
                else
                {
                    this.footerht = "20px";
                }
                string str = string.Empty;
                this.txtGreeting.Text = " ";
                if (this.Pgtype == "job")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "job");
                    this.dtstatus_def = SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "job");
                    foreach (DataRow row in this.dtstatus_def.Rows)
                    {
                        str = row["StatusTitle"].ToString();
                    }
                    if (str != "")
                    {
                        this.objBase.SetDDLText(this.ddlStatus, str);
                    }
                }
                else if (this.Pgtype != "invoice")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "estimate");
                    this.dtstatus_def = SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "estimate");
                    foreach (DataRow dataRow in this.dtstatus_def.Rows)
                    {
                        str = dataRow["StatusTitle"].ToString();
                    }
                    if (str != "")
                    {
                        for (int i = 0; i < this.ddlStatus.Items.Count; i++)
                        {
                            if (string.Compare(this.ddlStatus.Items[i].Text, str, true) == 0)
                            {
                                this.ddlStatus.SelectedIndex = i;
                            }
                        }
                    }
                }
                else
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "invoice");
                    this.dtstatus_def = SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "invoice");
                    foreach (DataRow row1 in this.dtstatus_def.Rows)
                    {
                        str = row1["StatusTitle"].ToString();
                    }
                    if (str != "")
                    {
                        this.objBase.SetDDLText(this.ddlStatus, str);
                    }
                }
                DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        if (!dataRow1.Table.Columns.Contains("LimitName"))
                        {
                            continue;
                        }
                        dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                        dataRow1["LimitName"] = this.objBase.SpecialDecode(dataRow1["LimitName"].ToString());
                    }
                }
                this.ddlSalesPerson.DataSource = dataTable;
                this.ddlSalesPerson.DataTextField = "LimitName";
                this.ddlSalesPerson.DataValueField = "UserID";
                this.ddlSalesPerson.DataBind();
                
                // estimator
                this.ddlEstimator.DataSource = dataTable;
                this.ddlEstimator.DataTextField = "LimitName";
                this.ddlEstimator.DataValueField = "UserID";
                this.ddlEstimator.DataBind();

                foreach (DataRow row2 in SettingsBasePage.Get_Estimate_DefaulSetting(this.CompanyID).Rows)
                {
                    this.WorkingDaysFrom = Convert.ToInt32(row2["WorkingDaysFrom"]);
                    this.WorkingDaysTo = Convert.ToInt32(row2["WorkingDaysTo"]);
                    this.DefaultEstimatedArtwork = Convert.ToInt32(row2["DefaultEstimatedArtwork"]);
                    this.DefaultEstimatedProof = Convert.ToInt32(row2["DefaultEstimatedProof"]);
                    this.DefaultEstimatedApproval = Convert.ToInt32(row2["DefaultEstimatedApproval"]);
                    this.DefaultEstimatedProduction = Convert.ToInt32(row2["DefaultEstimatedProduction"]);
                    this.DefaultEstimatedCompletion = Convert.ToInt32(row2["DefaultEstimatedCompletion"]);
                    this.DefaultEstimatedDelivery = Convert.ToInt32(row2["DefaultEstimatedDelivery"]);
                    this.DefaultCustomDate1 = String.IsNullOrEmpty(row2["DefaultCustomDate1"].ToString()) ? "" : row2["DefaultCustomDate1"].ToString();
                    this.DefaultCustomDate2 = String.IsNullOrEmpty(row2["DefaultCustomDate2"].ToString()) ? "" : row2["DefaultCustomDate2"].ToString();
                    this.DefaultCustomDate3 = String.IsNullOrEmpty(row2["DefaultCustomDate3"].ToString()) ? "" : row2["DefaultCustomDate3"].ToString();
                    this.DefaultCustomDate4 = String.IsNullOrEmpty(row2["DefaultCustomDate4"].ToString()) ? "" : row2["DefaultCustomDate4"].ToString();
                    this.DefaultCustomDate5 = String.IsNullOrEmpty(row2["DefaultCustomDate5"].ToString()) ? "" : row2["DefaultCustomDate5"].ToString();
                    if (!Convert.ToBoolean(row2["IsDefaultArtwork"]))
                    {
                        this.divArtworkdelivery.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divArtworkdelivery.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultProof"]))
                    {
                        this.div_ProofNew.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.div_ProofNew.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultApproval"]))
                    {
                        this.div_ApprovalNew.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.div_ApprovalNew.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultProduction"]))
                    {
                        this.divProductionDate.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divProductionDate.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultCompletion"]))
                    {
                        this.divJobCompletionDate.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divJobCompletionDate.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultDelivery"]))
                    {
                        this.divEstimateDeliveryDate.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divEstimateDeliveryDate.Attributes.Add("style", "display:block");
                    }

                    if (!Convert.ToBoolean(row2["chkEnblePriority"]))
                    {
                        this.div_priority.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.div_priority.Attributes.Add("style", "display:block");
                    }



                    if (!Convert.ToBoolean(row2["IsDefaultCustomDate1"]))
                    {
                        this.divCustomDate1.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divCustomDate1.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultCustomDate2"]))
                    {
                        this.divCustomDate2.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divCustomDate2.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultCustomDate3"]))
                    {
                        this.divCustomDate3.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divCustomDate3.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultCustomDate4"]))
                    {
                        this.divCustomDate4.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divCustomDate4.Attributes.Add("style", "display:block");
                    }
                    if (!Convert.ToBoolean(row2["IsDefaultCustomDate5"]))
                    {
                        this.divCustomDate5.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.divCustomDate5.Attributes.Add("style", "display:block");
                    }
                }
                now = DateTime.Now;
                now = Convert.ToDateTime(now.ToString());
                this.newdate = now.ToShortDateString();
                TextBox textBox = this.txtEstimateDate;
                commonClass _commonClass1 = this.comm;
                now = DateTime.Now;
                textBox.Text = _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox1 = this.txtEstimateartworkDate;
                commonClass _commonClass2 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedArtwork);
                textBox1.Text = _commonClass2.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox2 = this.txtEstimatedeliveryDate;
                commonClass _commonClass3 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedDelivery);
                textBox2.Text = _commonClass3.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox3 = this.txtjobcompletiondate;
                commonClass _commonClass4 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedCompletion);
                textBox3.Text = _commonClass4.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.txtEstimateDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtEstimateartworkDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtEstimatedeliveryDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtjobcompletiondate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtInvoiceDueDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.serverName == "burstmedia")
                {
                    this.txtEstimatedeliveryDate.Attributes.Add("onfocus", "javascript:CopyDelDate();");
                }
                TextBox textBox4 = this.txtproofdate;
                commonClass _commonClass5 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedProof);
                textBox4.Text = _commonClass5.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox5 = this.txtapprovaldate;
                commonClass _commonClass6 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedApproval);
                textBox5.Text = _commonClass6.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox6 = this.txtproductiondate;
                commonClass _commonClass7 = this.comm;
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, this.DefaultEstimatedProduction);
                textBox6.Text = _commonClass7.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                //CustomDates settings
                this.txtCustomDate1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomDate2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomDate3.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomDate4.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomDate5.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));

                TextBox textBox7 = this.txtCustomDate1;
                commonClass _commonClass71 = this.comm;
                if (!string.IsNullOrEmpty(this.DefaultCustomDate1))
                {
                    now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate1));
                    textBox7.Text = _commonClass71.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                }
                else
                {
                    textBox7.Text = "";
                }
                TextBox textBox8 = this.txtCustomDate2;
                commonClass _commonClass72 = this.comm;
                if (!string.IsNullOrEmpty(this.DefaultCustomDate2))
                {
                    now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate2));
                    textBox8.Text = _commonClass72.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                }
                else
                {
                    textBox8.Text = "";
                }
                TextBox textBox9 = this.txtCustomDate3;
                commonClass _commonClass73 = this.comm;
                if (!string.IsNullOrEmpty(this.DefaultCustomDate3))
                {
                    now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate3));
                    textBox9.Text = _commonClass73.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                }
                else
                {
                    textBox9.Text = "";
                }
                TextBox textBox10 = this.txtCustomDate4;
                commonClass _commonClass74 = this.comm;
                if (!string.IsNullOrEmpty(this.DefaultCustomDate4))
                {
                    now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate4));
                    textBox10.Text = _commonClass74.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                }
                else
                {
                    textBox10.Text = "";
                }
                TextBox textBox11 = this.txtCustomDate5;
                commonClass _commonClass75 = this.comm;
                if (!string.IsNullOrEmpty(this.DefaultCustomDate5))
                {
                    now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate5));
                    textBox11.Text = _commonClass75.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                }
                else
                {
                    textBox11.Text = "";
                }

                this.txtproofdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtapprovaldate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtproductiondate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (base.Request.Params["type"] != null)
                {
                    this.div_InvoiceAddress.Style.Add("display", "block");
                    this.Type = base.Request.Params["type"].ToString().ToLower();
                    if (base.Request.Params["type"].ToString().ToLower() == "add")
                    {
                        DataTable dataTable1 = new DataTable();
                        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateTitle_Default_Select");
                        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(base.Session["CompanyID"].ToString()));
                        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                        {
                            dataTable1.Load(dataReader);
                        }
                        if (dataTable1.Rows.Count > 0)
                        {
                            this.txtEstimateTitle.Text = this.objBase.SpecialDecode(dataTable1.Rows[0]["PhraseText"].ToString());
                        }
                        long estNo = (long)10000000 + this.EstNo;
                        if (!this.IsHandy)
                        {
                            this.lblEstimateNumber.Text = string.Concat("EST-", estNo.ToString().Substring(1, estNo.ToString().Length - 1));
                        }
                        else
                        {
                            this.lblEstimateNumber.Text = string.Concat("ESTH", estNo.ToString().Substring(1, estNo.ToString().Length - 1));
                        }
                        this.pnlForStage1.Visible = true;
                        this.ddlSalesPerson.SelectedValue = this.UserID.ToString();
                        
                        // load default logged in user
                        this.ddlEstimator.SelectedValue = Convert.ToString(this.UserID);
                        if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate"))
                        {
                            DataSet dataSet = SettingsBasePage.settings_default_phrasebook_select_header_footer(this.CompanyID, "Estimate Header");
                            DataSet dataSet1 = SettingsBasePage.settings_default_phrasebook_select_header_footer(this.CompanyID, "Estimate Footer");
                            foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                            {
                                this.lblHeader.Text = this.objBase.SpecialDecode(dataRow2["PhraseText"].ToString());
                                this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow2["PhraseText"].ToString());
                                this.hid_HeaderID.Value = dataRow2["PhraseBookID"].ToString();
                                this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow2["PhraseText"].ToString());
                            }
                            foreach (DataRow row3 in dataSet1.Tables[1].Rows)
                            {
                                this.lblFooter.Text = this.objBase.SpecialDecode(row3["PhraseText"].ToString());
                                this.lblFooter.ToolTip = this.objBase.SpecialDecode(row3["PhraseText"].ToString());
                                this.hid_FooterID.Value = row3["PhraseBookID"].ToString();
                                this.hid_FooterText.Value = this.objBase.SpecialDecode(row3["PhraseText"].ToString());
                            }
                            this.ddlpriority.SelectedIndex = 0;
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                        {
                            foreach (DataRow dataRow3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
                            {
                                this.lblHeader.Text = this.objBase.SpecialDecode(dataRow3["PhraseText"].ToString());
                                this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow3["PhraseText"].ToString());
                                this.hid_HeaderID.Value = dataRow3["PhraseBookID"].ToString();
                                this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow3["PhraseText"].ToString());
                            }
                            foreach (DataRow row4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
                            {
                                this.lblFooter.Text = this.objBase.SpecialDecode(row4["PhraseText"].ToString());
                                this.lblFooter.ToolTip = this.objBase.SpecialDecode(row4["PhraseText"].ToString());
                                this.hid_FooterID.Value = row4["PhraseBookID"].ToString();
                                this.hid_FooterText.Value = this.objBase.SpecialDecode(row4["PhraseText"].ToString());
                            }
                            this.ddlpriority.SelectedIndex = 0;
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                        {
                            foreach (DataRow dataRow4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                            {
                                this.lblHeader.Text = this.objBase.SpecialDecode(dataRow4["PhraseText"].ToString());
                                this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow4["PhraseText"].ToString());
                                this.hid_HeaderID.Value = dataRow4["PhraseBookID"].ToString();
                                this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow4["PhraseText"].ToString());
                            }
                            foreach (DataRow row5 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                            {
                                this.lblFooter.Text = this.objBase.SpecialDecode(row5["PhraseText"].ToString());
                                this.lblFooter.ToolTip = this.objBase.SpecialDecode(row5["PhraseText"].ToString());
                                this.hid_FooterID.Value = row5["PhraseBookID"].ToString();
                                this.hid_FooterText.Value = this.objBase.SpecialDecode(row5["PhraseText"].ToString());
                            }
                            this.ddlpriority.SelectedIndex = 0;
                        }
                    }
                    else if (base.Request.Params["type"].ToString().ToLower() != "null" && base.Request.Params["estid"].ToString() != null)
                    {
                        string empty1 = string.Empty;
                        try
                        {
                            if (base.Request.Params["prev"].ToString().ToLower() != "null" && base.Request.Params["prev"].ToString().ToLower() == "y")
                            {
                                empty1 = "yes";
                            }
                        }
                        catch
                        {
                            empty1 = "no";
                        }
                        if (empty1 != "yes")
                        {
                            this.pnldiv_only_for_add.Visible = true;
                            if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                            {
                                int num = 0;
                                foreach (DataRow dataRow5 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                                {
                                    this.txtName.Text = this.objBase.SpecialDecode(dataRow5["ClientName"].ToString());
                                    this.hid_ClientID.Value = dataRow5["CustomerID"].ToString();
                                    this.hid_OldClientID.Value = dataRow5["CustomerID"].ToString();
                                    this.Pub_CustomerID = this.hid_ClientID.Value.ToString();
                                    this.hid_CustName.Value = dataRow5["ClientName"].ToString();
                                    this.Pub_CustomerName = this.hid_CustName.Value;
                                    this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataRow5["InvoiceAddress"].ToString());
                                    this.lblInvoiceAddress.ToolTip = this.objBase.SpecialDecode(dataRow5["InvoiceAddress"].ToString());
                                    this.hdn_InvoiceAddressID.Value = dataRow5["InvoiceAddressID"].ToString();
                                    this.hid_InvoiceAddressID.Value = dataRow5["InvoiceAddressID"].ToString();
                                    this.hdnStatusTitle.Value = dataRow5["CustomerStatusTitle"].ToString();
                                    this.txtcomments.Text = this.objBase.SpecialDecode(dataRow5["eStoreComments"].ToString());
                                    this.ddlpriority.SelectedValue = dataRow5["priority"].ToString();

                                    if (base.Request.QueryString["cntct"] == null)
                                    {
                                        if (num == 0)
                                        {
                                            if (!string.IsNullOrEmpty(dataRow5["ContactList"].ToString()) && base.Request.QueryString["clientid"] == null)
                                            {
                                                string str1 = dataRow5["ContactList"].ToString();
                                                chrArray = new char[] { '±' };
                                                string[] strArrays = str1.Split(chrArray);
                                                for (int j = 0; j < (int)strArrays.Length; j++)
                                                {
                                                    string str2 = strArrays[j];
                                                    chrArray = new char[] { '»' };
                                                    string[] strArrays1 = str2.Split(chrArray);
                                                    ListItem listItem = new ListItem()
                                                    {
                                                        Text = this.objBase.SpecialDecode(strArrays1[1]),
                                                        Value = strArrays1[0]
                                                    };
                                                    this.ddlcontact.Items.Add(listItem);
                                                 
                                                }
                                            }
                                            this.ddlcontact.SelectedValue = dataRow5["AttentionID"].ToString();



                                            if (!string.IsNullOrEmpty(dataRow5["ContactList"].ToString()) && base.Request.QueryString["clientid"] == null)
                                            {
                                                string str1 = dataRow5["ContactList"].ToString();
                                                chrArray = new char[] { '±' };
                                                string[] strArrays = str1.Split(chrArray);
                                                for (int j = 0; j < (int)strArrays.Length; j++)
                                                {
                                                    string str2 = strArrays[j];
                                                    chrArray = new char[] { '»' };
                                                    string[] strArrays1 = str2.Split(chrArray);
                                                    ListItem listItem = new ListItem()
                                                    {
                                                        Text = this.objBase.SpecialDecode(strArrays1[1]),
                                                        Value = strArrays1[0]
                                                    };
                                                   
                                                    this.ddlinvoicecontact.Items.Add(listItem);
                                                }
                                            }


                                            this.ddlinvoicecontact.SelectedValue = String.IsNullOrEmpty(dataRow5["InvoiceContactId"].ToString()) ? dataRow5["AttentionID"].ToString(): dataRow5["InvoiceContactId"].ToString();
                                        }
                                        num++;
                                    }
                                    else if (base.Request.QueryString["cntct"].ToString().ToLower() == "new")
                                    {
                                        this.ddlcontact.SelectedValue = "";
                                       this.ddlinvoicecontact.SelectedValue = "";
                                    }
                                    this.hid_ContactID.Value = dataRow5["AttentionID"].ToString();
                                    this.txtGreeting.Text = this.objBase.SpecialDecode(dataRow5["Greeting"].ToString());
                                    this.txtCompany.Text = this.objBase.SpecialDecode(dataRow5["Company"].ToString());
                                    this.hdnAddressID.Value = dataRow5["AddressID"].ToString();
                                    this.lblAddress.Text = this.objBase.SpecialDecode(dataRow5["Address"].ToString());
                                    this.lblAddress.ToolTip = this.objBase.SpecialDecode(dataRow5["Address"].ToString());
                                    this.hid_AddressType.Value = dataRow5["AddressType"].ToString();
                                    if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                                    {
                                        this.lblHeader.Text = this.objBase.SpecialDecode(dataRow5["InvoiceHeader"].ToString());
                                        this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow5["InvoiceHeader"].ToString());
                                        this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow5["InvoiceHeader"].ToString());
                                        this.lblFooter.Text = this.objBase.SpecialDecode(dataRow5["InvoiceFooter"].ToString());
                                        this.hid_FooterText.Value = this.objBase.SpecialDecode(dataRow5["InvoiceFooter"].ToString());
                                        this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataRow5["InvoiceFooter"].ToString());
                                    }
                                    if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate"))
                                    {
                                        this.lblHeader.Text = this.objBase.SpecialDecode(dataRow5["Header"].ToString());
                                        this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow5["Header"].ToString());
                                        this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow5["Header"].ToString());
                                        this.lblHeader.Text = (this.lblHeader.Text.Length > 31 ? string.Concat(this.lblHeader.Text.Substring(0, 31).Trim(), "...") : this.lblHeader.Text);
                                        this.lblFooter.Text = this.objBase.SpecialDecode(dataRow5["Footer"].ToString());
                                        this.hid_FooterText.Value = this.objBase.SpecialDecode(dataRow5["Footer"].ToString());
                                        this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataRow5["Footer"].ToString());
                                    }
                                    this.txtEstimateTitle.Text = this.objBase.SpecialDecode(dataRow5["EstimateTitle"].ToString());
                                    this.lblEstimateNumber.Text = this.objBase.SpecialDecode(dataRow5["EstimateNumber"].ToString());
                                    this.txtOrderNumber.Text = this.objBase.SpecialDecode(dataRow5["OrderNumber"].ToString());
                                    this.ddlStatus.SelectedValue = dataRow5["StatusID"].ToString();
                                    if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                                    {
                                        this.txtEstimateDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["invoicecreateddate"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtEstimatedeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                                    }
                                    else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                                    {
                                        this.txtEstimateDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtjobcompletiondate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtEstimatedeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                                    }
                                    else
                                    {
                                        this.txtEstimateDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["Jobdate"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtjobcompletiondate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["jobcompletiondate"].ToString(), this.CompanyID, this.UserID, false);
                                        this.txtEstimatedeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["JobDeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                                    }

                                    this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtCustomDate2.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtCustomDate3.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtCustomDate4.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtCustomDate5.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);

                                    this.txtproofdate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstProofDate"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtapprovaldate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtproductiondate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtEstimateartworkDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow5["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                                    this.txtValidFor.Text = dataRow5["ValidFor"].ToString();
                                    this.lblAccountNumber.Text = this.objBase.SpecialDecode(dataRow5["AccountNo"].ToString());
                                    this.hid_DeliveryAddressID.Value = dataRow5["DeliveryAddressID"].ToString();
                                    this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataRow5["DeliveryAddress"].ToString());
                                    this.lblDeliveryAddress.ToolTip = this.objBase.SpecialDecode(dataRow5["DeliveryAddress"].ToString());
                                    this.hdn_DepartmentID.Value = dataRow5["departmentID"].ToString();
                                    this.hid_DelAddressType.Value = dataRow5["DeliveryAddressType"].ToString();
                                    this.hdn_selectedcentre.Value = dataRow5["costcentreID"].ToString();
                                    this.ddlSalesPerson.SelectedValue = dataRow5["SalesPerson"].ToString();
                                   
                                    // estimator
                                    this.ddlEstimator.SelectedValue = Convert.ToString(dataRow5["EstimatorId"]);

                                    this.pnlForStage1.Visible = true;
                                    this.pnldiv_only_for_add.Visible = true;
                                    System.Type type = base.GetType();
                                    companyID = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.hid_ClientID.Value, ",", this.hdn_DepartmentID.Value, ",", 0, ");" };
                                    ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(companyID), true);
                                }
                                if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                                {
                                    this.div_InvoiceAddress.Style.Add("display", "block");
                                    string empty2 = string.Empty;
                                    foreach (DataRow row6 in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.jobID).Rows)
                                    {
                                        empty2 = row6["jobstatus"].ToString();
                                        this.lblHeader.Text = this.objBase.SpecialDecode(row6["Header"].ToString());
                                        this.hid_HeaderText.Value = this.objBase.SpecialDecode(row6["Header"].ToString());
                                        this.lblHeader.ToolTip = this.objBase.SpecialDecode(row6["Header"].ToString());
                                        this.lblFooter.Text = this.objBase.SpecialDecode(row6["Footer"].ToString());
                                        this.hid_FooterText.Value = this.objBase.SpecialDecode(row6["Footer"].ToString());
                                        this.lblFooter.ToolTip = this.objBase.SpecialDecode(row6["Footer"].ToString());
                                        this.ddlpriority.SelectedValue = row6["priority"].ToString();
                                    }
                                    for (int k = 0; k < this.ddlStatus.Items.Count; k++)
                                    {
                                        if (this.ddlStatus.Items[k].Text.ToLower().Trim() == empty2.ToLower().Trim())
                                        {
                                            this.ddlStatus.SelectedIndex = k;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                IDataReader dataReader1 = InvoiceBasePage.Invoices_Invoice_Details_select_ByInvoiceID(this.CompanyID, this.invoiceID);
                                string empty3 = string.Empty;
                                while (dataReader1.Read())
                                {
                                    this.txtName.Text = this.objBase.SpecialDecode(dataReader1["ClientName"].ToString());
                                    this.hid_ClientID.Value = dataReader1["ClientID"].ToString();
                                    this.hid_OldClientID.Value = dataReader1["ClientID"].ToString();
                                    this.Pub_CustomerID = this.hid_ClientID.Value.ToString();
                                    this.hid_CustName.Value = dataReader1["ClientName"].ToString();
                                    this.Pub_CustomerName = this.hid_CustName.Value;
                                    this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataReader1["InvoiceAddress"].ToString());
                                    this.lblInvoiceAddress.ToolTip = this.objBase.SpecialDecode(dataReader1["InvoiceAddress"].ToString());
                                    this.hdn_InvoiceAddressID.Value = dataReader1["InvoiceAddressID"].ToString();
                                    this.ddlpriority.SelectedValue = dataReader1["priority"].ToString();
                                    if (base.Request.QueryString["cntct"] == null)
                                    {
                                        if (!string.IsNullOrEmpty(dataReader1["ContactList"].ToString()) && base.Request.QueryString["clientid"] == null)
                                        {
                                            string str3 = dataReader1["ContactList"].ToString();
                                            chrArray = new char[] { '±' };
                                            string[] strArrays2 = str3.Split(chrArray);
                                            for (int l = 0; l < (int)strArrays2.Length; l++)
                                            {
                                                string str4 = strArrays2[l];
                                                chrArray = new char[] { '»' };
                                                string[] strArrays3 = str4.Split(chrArray);
                                                ListItem listItem1 = new ListItem()
                                                {
                                                    Text = this.objBase.SpecialDecode(strArrays3[1]),
                                                    Value = strArrays3[0]
                                                };
                                                this.ddlcontact.Items.Add(listItem1);
                                               
                                            }
                                        }
                                        this.objBase.SetDDLValue(this.ddlcontact, dataReader1["AttentionID"].ToString());
                                        if (!string.IsNullOrEmpty(dataReader1["ContactList"].ToString()) && base.Request.QueryString["clientid"] == null)
                                        {
                                            string str3 = dataReader1["ContactList"].ToString();
                                            chrArray = new char[] { '±' };
                                            string[] strArrays2 = str3.Split(chrArray);
                                            for (int l = 0; l < (int)strArrays2.Length; l++)
                                            {
                                                string str4 = strArrays2[l];
                                                chrArray = new char[] { '»' };
                                                string[] strArrays3 = str4.Split(chrArray);
                                                ListItem listItem1 = new ListItem()
                                                {
                                                    Text = this.objBase.SpecialDecode(strArrays3[1]),
                                                    Value = strArrays3[0]
                                                };
                                             
                                                this.ddlinvoicecontact.Items.Add(listItem1);
                                            }
                                        }
                                        this.objBase.SetDDLValue(this.ddlinvoicecontact, String.IsNullOrEmpty(dataReader1["InvoiceContactId"].ToString()) ? dataReader1["AttentionID"].ToString() : dataReader1["InvoiceContactId"].ToString());

                                    }
                                    else if (base.Request.QueryString["cntct"].ToString().ToLower() == "new")
                                    {
                                        this.ddlcontact.SelectedValue = "";
                                        this.ddlinvoicecontact.SelectedValue = "";
                                    }
                                    this.hid_ContactID.Value = dataReader1["AttentionID"].ToString();
                                    this.txtGreeting.Text = this.objBase.SpecialDecode(dataReader1["Greeting"].ToString());
                                    this.txtCompany.Text = this.objBase.SpecialDecode(dataReader1["DepartmentName"].ToString());
                                    this.hdnAddressID.Value = dataReader1["AddressID"].ToString();
                                    this.lblAddress.Text = this.objBase.SpecialDecode(dataReader1["Address"].ToString());
                                    this.lblAddress.ToolTip = this.objBase.SpecialDecode(dataReader1["Address"].ToString());
                                    this.txtEstimateTitle.Text = this.objBase.SpecialDecode(dataReader1["InvoiceTitle"].ToString());
                                    this.lblEstimateNumber.Text = this.objBase.SpecialDecode(dataReader1["InvoiceNumber"].ToString());
                                    this.txtOrderNumber.Text = this.objBase.SpecialDecode(dataReader1["CustomerOrderNumber"].ToString());
                                    this.txtinvoicenumber.Text = this.objBase.SpecialDecode(dataReader1["InvoiceNumber"].ToString());
                                    if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                                    {
                                        this.txtEstimateDate.Text = this.comm.Eprint_return_Date_Before_View(dataReader1["invoicecreateddate"].ToString(), this.CompanyID, this.UserID, false);
                                    }
                                    this.txtValidFor.Text = dataReader1["ValidFor"].ToString();
                                    this.lblAccountNumber.Text = this.objBase.SpecialDecode(dataReader1["AccountNumber"].ToString());
                                    this.hid_DeliveryAddressID.Value = dataReader1["DeliveryAddressID"].ToString();
                                    this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataReader1["DeliveryAddress"].ToString());
                                    this.lblDeliveryAddress.ToolTip = this.objBase.SpecialDecode(dataReader1["DeliveryAddress"].ToString());
                                    this.hdn_DepartmentID.Value = dataReader1["departmentID"].ToString();
                                    this.hdn_selectedcentre.Value = dataReader1["costcentre"].ToString();
                                    this.ddlSalesPerson.SelectedValue = dataReader1["SalesPersonID"].ToString();

                                    // estimator
                                    this.ddlEstimator.SelectedValue = Convert.ToString(dataReader1["EstimatorId"]);
                                    this.pnlForStage1.Visible = true;
                                    this.pnldiv_only_for_add.Visible = true;
                                    System.Type type1 = base.GetType();
                                    companyID = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.hid_ClientID.Value, ",", this.hdn_DepartmentID.Value, ",", 0, ");" };
                                    ScriptManager.RegisterStartupScript(this, type1, " ", string.Concat(companyID), true);
                                    this.objBase.SetDDLValue(this.ddlStatus, dataReader1["status"].ToString());
                                    this.lblHeader.Text = this.objBase.SpecialDecode(dataReader1["Header"].ToString());
                                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataReader1["Header"].ToString());
                                    this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataReader1["Header"].ToString());
                                    this.div_InvoiceAddress.Style.Add("display", "block");
                                    this.hid_InvoiceAddressID.Value = dataReader1["InvoiceAddressID"].ToString();
                                    this.hid_InvoiceAddressType.Value = dataReader1["InvoiceAddressType"].ToString();
                                    this.hid_InvoiceAddressClientID.Value = dataReader1["InvoiceAddressClientID"].ToString();
                                    this.lblFooter.Text = this.objBase.SpecialDecode(dataReader1["Footer"].ToString());
                                    this.hid_FooterText.Value = this.objBase.SpecialDecode(dataReader1["Footer"].ToString());
                                    this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataReader1["Footer"].ToString());
                                    this.txtInvoiceDueDate.Text = this.comm.Eprint_return_Date_Before_View(dataReader1["Invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                                    this.IsFromEstore = dataReader1["IsfromWebstore"].ToString().ToLower().Trim();
                                    this.hdn_IsEstoreInvoice.Value = dataReader1["IsfromWebstore"].ToString().ToLower().Trim();
                                    if (dataReader1["IsfromWebstore"].ToString().ToLower().Trim() != "yes")
                                    {
                                        this.div_InvoiceNumber.Style.Add("display", "none");
                                    }
                                    else
                                    {
                                        this.div_InvoiceNumber.Style.Add("display", "block");
                                        this.txtinvoicenumber.Enabled = false;
                                        this.txtName.Enabled = false;
                                        this.txtCompany.Enabled = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.estimatetype.ToString().ToLower() == "s")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedDigital";
                                this.ddlProductType.SelectedValue = "DigitalSingleItem";
                            }
                            if (this.estimatetype.ToString().ToLower() == "b")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedDigital";
                                this.ddlProductType.SelectedValue = "DigitalBooklet";
                            }
                            if (this.estimatetype.ToString().ToLower() == "p")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedDigital";
                                this.ddlProductType.SelectedValue = "DigitalPads";
                            }
                            if (this.estimatetype.ToString().ToLower() == "r")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedDigital";
                                this.ddlProductType.SelectedValue = "DigitalNCR";
                            }
                            if (this.estimatetype.ToString().ToLower() == "l")
                            {
                                this.ddlEstimateType.SelectedValue = "largeformat";
                            }
                            if (this.estimatetype.ToString().ToLower() == "w")
                            {
                                this.ddlEstimateType.SelectedValue = "warehouse";
                            }
                            if (this.estimatetype.ToString().ToLower() == "o")
                            {
                                this.ddlEstimateType.SelectedValue = "printbroker";
                            }
                            if (this.estimatetype.ToString().ToLower() == "u")
                            {
                                this.ddlEstimateType.SelectedValue = "othercost";
                            }
                            if (this.estimatetype.ToString().ToLower() == "c")
                            {
                                this.ddlEstimateType.SelectedValue = "pricecatalogue";
                            }
                            if (this.estimatetype.ToString().ToLower() == "f")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedOffset";
                                this.ddlProductType.SelectedValue = "OffsetSingleItem";
                            }
                            if (this.estimatetype.ToString().ToLower() == "n")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedOffset";
                                this.ddlProductType.SelectedValue = "OffsetNCR";
                            }
                            if (this.estimatetype.ToString().ToLower() == "k")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedOffset";
                                this.ddlProductType.SelectedValue = "OffsetBooklet";
                            }
                            if (this.estimatetype.ToString().ToLower() == "d")
                            {
                                this.ddlEstimateType.SelectedValue = "SheetFedOffset";
                                this.ddlProductType.SelectedValue = "OffsetPad";
                            }
                            if (this.estimatetype.ToString().ToLower() == "q")
                            {
                                this.ddlEstimateType.SelectedValue = "QuickQuote";
                                this.ddlProductType.SelectedValue = "QuickQuote";
                            }
                            if (this.estimatetype.ToString().ToLower() == "t")
                            {
                                this.ddlEstimateType.SelectedValue = "DeliveryCost";
                                this.ddlProductType.SelectedValue = "DeliveryCost";
                            }
                            if (this.calcType.ToString().ToLower() == "square")
                            {
                                this.ddlCalcType.SelectedValue = "square";
                            }
                            else if (this.calcType.ToString().ToLower() == "linear")
                            {
                                this.ddlCalcType.SelectedValue = "linear";
                            }
                            foreach (DataRow dataRow6 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                            {
                                this.txtName.Text = this.objBase.SpecialDecode(dataRow6["ClientName"].ToString());
                                this.hid_ClientID.Value = dataRow6["CustomerID"].ToString();
                                this.Pub_CustomerID = this.hid_ClientID.Value.ToString();
                                this.hid_CustName.Value = this.objBase.SpecialDecode(dataRow6["ClientName"].ToString());
                                this.hid_CustName.Value = this.hid_CustName.Value.Replace(" ", "");
                                this.Pub_CustomerName = this.objBase.SpecialEncode(this.hid_CustName.Value);
                                this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataRow6["InvoiceAddress"].ToString());
                                this.hdn_DepartmentID.Value = dataRow6["departmentID"].ToString();
                                this.hdn_InvoiceAddressID.Value = dataRow6["InvoiceAddressID"].ToString();
                                this.ddlpriority.SelectedValue = dataRow6["priority"].ToString();
                                if (!string.IsNullOrEmpty(dataRow6["ContactList"].ToString()))
                                {
                                    string str5 = dataRow6["ContactList"].ToString();
                                    chrArray = new char[] { '±' };
                                    string[] strArrays4 = str5.Split(chrArray);
                                    for (int m = 0; m < (int)strArrays4.Length; m++)
                                    {
                                        string str6 = strArrays4[m];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays5 = str6.Split(chrArray);
                                        ListItem listItem2 = new ListItem()
                                        {
                                            Text = this.objBase.SpecialDecode(strArrays5[1]),
                                            Value = strArrays5[0]
                                        };
                                        this.ddlcontact.Items.Add(listItem2);
                                      
                                    }
                                }

                                if (!string.IsNullOrEmpty(dataRow6["ContactList"].ToString()))
                                {
                                    string str5 = dataRow6["ContactList"].ToString();
                                    chrArray = new char[] { '±' };
                                    string[] strArrays4 = str5.Split(chrArray);
                                    for (int m = 0; m < (int)strArrays4.Length; m++)
                                    {
                                        string str6 = strArrays4[m];
                                        chrArray = new char[] { '»' };
                                        string[] strArrays5 = str6.Split(chrArray);
                                        ListItem listItem2 = new ListItem()
                                        {
                                            Text = this.objBase.SpecialDecode(strArrays5[1]),
                                            Value = strArrays5[0]
                                        };
                                   
                                        this.ddlinvoicecontact.Items.Add(listItem2);
                                    }
                                }


                                this.hid_ContactID.Value = dataRow6["AttentionID"].ToString();
                                this.ddlcontact.SelectedValue = dataRow6["AttentionID"].ToString();
                                this.ddlinvoicecontact.SelectedValue = String.IsNullOrEmpty(dataRow6["InvoiceContactId"].ToString()) ? dataRow6["AttentionID"].ToString() : dataRow6["InvoiceContactId"].ToString();
                                this.txtGreeting.Text = this.objBase.SpecialDecode(dataRow6["Greeting"].ToString());
                                this.txtCompany.Text = this.objBase.SpecialDecode(dataRow6["Company"].ToString());
                                this.hdnAddressID.Value = dataRow6["AddressID"].ToString();
                                this.lblAddress.Text = this.objBase.SpecialDecode(dataRow6["Address"].ToString());
                                this.lblAddress.ToolTip = this.objBase.SpecialDecode(dataRow6["Address"].ToString());
                                this.hid_AddressType.Value = dataRow6["AddressType"].ToString();
                                if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                                {
                                    this.lblHeader.Text = this.objBase.SpecialDecode(dataRow6["Header"].ToString());
                                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow6["Header"].ToString());
                                    this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow6["Header"].ToString());
                                    this.lblFooter.Text = this.objBase.SpecialDecode(dataRow6["Footer"].ToString());
                                    this.hid_FooterText.Value = this.objBase.SpecialDecode(dataRow6["Footer"].ToString());
                                    this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataRow6["Footer"].ToString());
                                }
                                else
                                {
                                    this.lblHeader.Text = this.objBase.SpecialDecode(dataRow6["InvoiceHeader"].ToString());
                                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow6["InvoiceHeader"].ToString());
                                    this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataRow6["InvoiceHeader"].ToString());
                                    this.lblFooter.Text = this.objBase.SpecialDecode(dataRow6["InvoiceFooter"].ToString());
                                    this.hid_FooterText.Value = this.objBase.SpecialDecode(dataRow6["InvoiceFooter"].ToString());
                                    this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataRow6["InvoiceFooter"].ToString());
                                }
                                this.txtEstimateTitle.Text = this.objBase.SpecialDecode(dataRow6["EstimateTitle"].ToString());
                                this.lblEstimateNumber.Text = this.objBase.SpecialDecode(dataRow6["EstimateNumber"].ToString());
                                this.txtOrderNumber.Text = this.objBase.SpecialDecode(dataRow6["OrderNumber"].ToString());
                                this.ddlStatus.SelectedValue = dataRow6["StatusID"].ToString();
                                this.txtEstimateDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["EstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                                this.txtEstimateartworkDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                                if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                                {
                                    this.txtEstimatedeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                                }
                                else
                                {
                                    this.txtEstimatedeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["JobDeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                                }
                                if (this.serverName.ToLower() == "burstmedia")
                                {
                                    this.txtjobcompletiondate.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                                }

                                this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                                this.txtCustomDate2.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                                this.txtCustomDate3.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                                this.txtCustomDate4.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                                this.txtCustomDate5.Text = this.comm.Eprint_return_Date_Before_View(dataRow6["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);

                                this.txtValidFor.Text = dataRow6["ValidFor"].ToString();
                                this.lblAccountNumber.Text = this.objBase.SpecialDecode(dataRow6["AccountNo"].ToString());
                                this.hid_DeliveryAddressID.Value = dataRow6["DeliveryAddressID"].ToString();
                                this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataRow6["DeliveryAddress"].ToString());
                                this.lblDeliveryAddress.ToolTip = this.objBase.SpecialDecode(dataRow6["DeliveryAddress"].ToString());
                                this.hid_DelAddressType.Value = dataRow6["DeliveryAddressType"].ToString();
                                this.ddlSalesPerson.SelectedValue = dataRow6["SalesPerson"].ToString();

                                // estimator
                                this.ddlEstimator.SelectedValue = Convert.ToString(dataRow6["userID"]);

                                this.hdn_selectedcentre.Value = dataRow6["costcentreID"].ToString();
                                this.pnlForStage1.Visible = true;
                                this.pnldiv_only_for_add.Visible = true;
                            }
                            System.Type type2 = base.GetType();
                            companyID = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.hid_ClientID.Value, ",", this.hdn_DepartmentID.Value, ",", 0, ");" };
                            ScriptManager.RegisterStartupScript(this, type2, " ", string.Concat(companyID), true);
                            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                            {
                                IDataReader dataReader2 = InvoiceBasePage.Invoices_Invoice_Details_select_ByInvoiceID(this.CompanyID, this.invoiceID);
                                string empty4 = string.Empty;
                                while (dataReader2.Read())
                                {
                                    this.ddlStatus.SelectedValue = dataReader2["status"].ToString();
                                    this.lblHeader.Text = this.objBase.SpecialDecode(dataReader2["Header"].ToString());
                                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataReader2["Header"].ToString());
                                    this.lblHeader.ToolTip = this.objBase.SpecialDecode(dataReader2["Header"].ToString());
                                    this.div_InvoiceAddress.Style.Add("display", "block");
                                    this.hid_InvoiceAddressID.Value = dataReader2["InvoiceAddressID"].ToString();
                                    this.hid_InvoiceAddressType.Value = dataReader2["InvoiceAddressType"].ToString();
                                    this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataReader2["InvoiceAddress"].ToString());
                                    this.hid_InvoiceAddressClientID.Value = dataReader2["InvoiceAddressClientID"].ToString();
                                    this.lblFooter.Text = this.objBase.SpecialDecode(dataReader2["Footer"].ToString());
                                    this.hid_FooterText.Value = this.objBase.SpecialDecode(dataReader2["Footer"].ToString());
                                    this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataReader2["Footer"].ToString());
                                    this.txtInvoiceDueDate.Text = this.comm.Eprint_return_Date_Before_View(dataReader2["Invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                                    this.ddlpriority.SelectedValue = dataReader2["priority"].ToString();
                                }
                            }
                            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                            {
                                this.div_InvoiceAddress.Style.Add("display", "block");
                                string empty5 = string.Empty;
                                foreach (DataRow row7 in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.jobID).Rows)
                                {
                                    empty5 = row7["jobstatus"].ToString();
                                    this.lblHeader.Text = this.objBase.SpecialDecode(row7["Header"].ToString());
                                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(row7["Header"].ToString());
                                    this.lblHeader.ToolTip = this.objBase.SpecialDecode(row7["Header"].ToString());
                                    this.lblFooter.Text = this.objBase.SpecialDecode(row7["Footer"].ToString());
                                    this.hid_FooterText.Value = this.objBase.SpecialDecode(row7["Footer"].ToString());
                                    this.lblFooter.ToolTip = this.objBase.SpecialDecode(row7["Footer"].ToString());
                                    this.ddlpriority.SelectedValue = row7["priority"].ToString();
                                }
                                for (int n = 0; n < this.ddlStatus.Items.Count; n++)
                                {
                                    if (this.ddlStatus.Items[n].Text.ToLower().Trim() == empty5.ToLower().Trim())
                                    {
                                        this.ddlStatus.SelectedIndex = n;
                                    }
                                }
                            }
                            this.pnldiv_only_for_add.Visible = false;
                        }
                    }
                    if (string.Compare(base.Request.Params["type"], "more", true) == 0 || base.Request.Params["type"].ToString().ToLower() == "edit")
                    {
                        foreach (DataRow dataRow7 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                        {
                            this.Pub_CustomerID = dataRow7["CustomerID"].ToString();
                            this.hid_ClientID.Value = dataRow7["CustomerID"].ToString();
                            this.hid_CustName.Value = this.objBase.SpecialDecode(dataRow7["ClientName"].ToString());
                            this.txtName.Text = this.hid_CustName.Value;
                            this.Pub_CustomerName = this.objBase.SpecialEncode(this.hid_CustName.Value);
                            this.hdnAddressID.Value = dataRow7["AddressID"].ToString();
                            this.hid_InvoiceAddressID.Value = dataRow7["InvoiceAddressID"].ToString();
                            this.hdn_InvoiceAddressID.Value = dataRow7["InvoiceAddressID"].ToString();
                            this.hid_DeliveryAddressID.Value = dataRow7["DeliveryAddressID"].ToString();
                            this.ddlpriority.SelectedValue = dataRow7["priority"].ToString();
                        }
                    }
                }
                if (string.Compare(this.Pgtype, "job", true) == 0 && base.Session["pagename"].ToString().ToLower() == "job")
                {
                    lower = new string[] { " " };
                    string[] strArrays6 = lower;
                    foreach (DataRow row8 in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.jobID).Rows)
                    {
                        string[] strArrays7 = row8["ConvertedDate"].ToString().Split(strArrays6, StringSplitOptions.None);
                        this.lblJobProgressedValue.Text = this.comm.Eprint_return_Date_Before_View(strArrays7[0].ToString(), this.CompanyID, this.UserID, true);
                        string[] strArrays8 = row8["CompletionDate"].ToString().Split(strArrays6, StringSplitOptions.None);
                        this.lblCompletionDateValue.Text = strArrays8[0].ToString();
                        this.lblCompletionDateValue.Text = (this.lblCompletionDateValue.Text.ToString() == "1/1/1900" ? "" : this.comm.Eprint_return_Date_Before_View(this.lblCompletionDateValue.Text.ToString(), this.CompanyID, this.UserID, false));
                        this.lblJobNoValue.Text = this.objBase.SpecialDecode(row8["JobNumber"].ToString());
                        this.ddlpriority.SelectedValue = row8["priority"].ToString();
                    }
                }
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    this.hid_EstimateID.Value = base.Request.Params["estid"].ToString();
                    if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                    {
                        ImageButton imgCustomerAdd = this.ImgCustomerAdd;
                        lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=invoice&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["estid"].ToString(), this.jID, this.InvID };
                        imgCustomerAdd.PostBackUrl = string.Concat(lower);
                    }
                    else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                    {
                        ImageButton imageButton = this.ImgCustomerAdd;
                        lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=estimate&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["estid"].ToString(), this.jID, this.InvID };
                        imageButton.PostBackUrl = string.Concat(lower);
                    }
                    else
                    {
                        ImageButton imgCustomerAdd1 = this.ImgCustomerAdd;
                        lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=job&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["estid"].ToString(), this.jID, this.InvID };
                        imgCustomerAdd1.PostBackUrl = string.Concat(lower);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                {
                    ImageButton imageButton1 = this.ImgCustomerAdd;
                    lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=invoice&mode=", base.Request.Params["type"].ToString().ToLower(), this.jID, this.InvID };
                    imageButton1.PostBackUrl = string.Concat(lower);
                }
                else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                {
                    ImageButton imgCustomerAdd2 = this.ImgCustomerAdd;
                    lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=estimate&mode=", base.Request.Params["type"].ToString().ToLower(), this.jID, this.InvID };
                    imgCustomerAdd2.PostBackUrl = string.Concat(lower);
                }
                else
                {
                    ImageButton imageButton2 = this.ImgCustomerAdd;
                    lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=job&mode=", base.Request.Params["type"].ToString().ToLower(), this.jID, this.InvID };
                    imageButton2.PostBackUrl = string.Concat(lower);
                }
            }
            try
            {
                if (base.Request.Params["From"] != null)
                {
                    this.Fromedit = base.Request.Params["From"].ToString();
                }
                else
                {
                    this.Fromedit = "F";
                }
                
            }
            catch
            {
                this.Fromedit = "F";
            }
            if (this.Fromedit == "S")
            {
                this.ddlEstimateType.Enabled = false;
                this.ddlProductType.Enabled = false;
            }
            if (base.Request.Params["ReRun"] != null)
            {
                this.ddlProductType.Visible = false;
                this.ddlEstimateType.Visible = false;
                this.divp.Visible = false;
                this.dive.Visible = false;
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                this.modulename = "jobs";
                this.submodulename = "job";
            }
            if (!base.IsPostBack && string.Compare(this.req_type, "add", true) == 0)
            {
                foreach (DataRow dataRow8 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.ddlEstimateType.SelectedValue = dataRow8["DefaultEstimateType"].ToString();
                    this.txtValidFor.Text = dataRow8["ValidFor"].ToString();
                    this.lblCustomDate1.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle1"].ToString()) ? "Custom Date 1" : dataRow8["DefaultCustomDateTitle1"].ToString();
                    this.lblCustomDate2.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle2"].ToString()) ? "Custom Date 2" : dataRow8["DefaultCustomDateTitle2"].ToString();
                    this.lblCustomDate3.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle3"].ToString()) ? "Custom Date 3" : dataRow8["DefaultCustomDateTitle3"].ToString();
                    this.lblCustomDate4.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle4"].ToString()) ? "Custom Date 4" : dataRow8["DefaultCustomDateTitle4"].ToString();
                    this.lblCustomDate5.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle5"].ToString()) ? "Custom Date 5" : dataRow8["DefaultCustomDateTitle5"].ToString();

                }
            }
            commonClass _commonClass8 = this.comm;
            string dateFormat = this.DateFormat;
            commonClass _commonClass9 = this.comm;
            now = DateTime.Now;
            _commonClass8.eprint_checkdateformat_returnonlymmddyyyy(dateFormat, _commonClass9.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.EstimateCreatedDate = DateTime.Now;
            this.strconvertedate = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtEstimateDate.Text));
            if (!base.IsPostBack && this.InventoryManagement == "IM")
            {
                this.ReduceStockTypeNew = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (base.Request.QueryString["clientid"] != null)
            {
                HiddenField hidClientID = this.hid_ClientID;
                int num1 = Convert.ToInt32(base.Request.QueryString["clientid"]);
                hidClientID.Value = num1.ToString();
                DataTable dataTable2 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), "customer");
                foreach (DataRow row9 in dataTable2.Rows)
                {
                    this.txtName.Text = this.objBase.SpecialDecode(row9["ClientName"].ToString());
                    this.lblAccountNumber.Text = this.objBase.SpecialDecode(row9["AccountNumber"].ToString());
                    this.hdnStatusTitle.Value = this.objBase.SpecialDecode(row9["AccountStatusName"].ToString());
                }
                if (base.Request.QueryString["contactid"] != null)
                {
                    HiddenField hidContactID = this.hid_ContactID;
                    num1 = Convert.ToInt32(base.Request.QueryString["contactid"]);
                    hidContactID.Value = num1.ToString();
                    DataTable dataTable3 = EstimatesBasePage.Clients_New_Contact_Select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value));
                    if (base.Request.QueryString["cntct"] == null)
                    {
                        foreach (DataRow dataRow9 in dataTable3.Rows)
                        {
                            if (!string.IsNullOrEmpty(dataRow9["ContactList"].ToString()))
                            {
                                string str7 = dataRow9["ContactList"].ToString();
                                chrArray = new char[] { '±' };
                                string[] strArrays9 = str7.Split(chrArray);
                                for (int o = 0; o < (int)strArrays9.Length; o++)
                                {
                                    string str8 = strArrays9[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays10 = str8.Split(chrArray);
                                    ListItem listItem3 = new ListItem()
                                    {
                                        Text = this.objBase.SpecialDecode(strArrays10[1]),
                                        Value = strArrays10[0]
                                    };
                                    this.ddlcontact.Items.Add(listItem3);
                                  
                                }
                            }

                            if (!string.IsNullOrEmpty(dataRow9["ContactList"].ToString()))
                            {
                                string str7 = dataRow9["ContactList"].ToString();
                                chrArray = new char[] { '±' };
                                string[] strArrays9 = str7.Split(chrArray);
                                for (int o = 0; o < (int)strArrays9.Length; o++)
                                {
                                    string str8 = strArrays9[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays10 = str8.Split(chrArray);
                                    ListItem listItem3 = new ListItem()
                                    {
                                        Text = this.objBase.SpecialDecode(strArrays10[1]),
                                        Value = strArrays10[0]
                                    };
                                 
                                    this.ddlinvoicecontact.Items.Add(listItem3);
                                }
                            }

                            this.txtCompany.Text = this.objBase.SpecialDecode(dataRow9["Department"].ToString());
                            this.txtGreeting.Text = this.objBase.SpecialDecode(dataRow9["Greeting"].ToString());
                            this.lblAddress.Text = this.objBase.SpecialDecode(dataRow9["DefaultContactAddress"].ToString());
                            this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataRow9["DefaultDeliveryaddress"].ToString());
                            this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataRow9["DefaultInvoiceaddress"].ToString());
                            this.lblAccountNumber.Text = this.objBase.SpecialDecode(dataRow9["AccountNo"].ToString());
                            this.hdnAddressID.Value = dataRow9["ContactAddressID"].ToString();
                            this.hdn_DepartmentID.Value = dataRow9["DeptID"].ToString();
                            this.hdn_ContactAddressID.Value = dataRow9["ContactAddressID"].ToString();
                            this.hid_DeliveryAddressID.Value = dataRow9["DeliveryAddressID"].ToString();
                            this.hdn_InvoiceAddressID.Value = dataRow9["InvoiceAddressID"].ToString();
                        }
                        this.ddlcontact.SelectedValue = this.hid_ContactID.Value;
                        this.ddlinvoicecontact.SelectedValue = this.hid_ContactID.Value;
                    }
                    else if (base.Request.QueryString["cntct"].ToString().ToLower() == "new")
                    {
                        this.ddlcontact.SelectedValue = "";
                       this.ddlinvoicecontact.SelectedValue = "";
                    }
                }
                if (base.Request.QueryString["salperson"] != null && base.Request.QueryString["salperson"] != "-1")
                {
                    this.ddlSalesPerson.SelectedValue = base.Request.QueryString["salperson"].ToString();
                }
            }
            if (base.Request.QueryString["cntct"] != null && base.Request.QueryString["cntct"].ToString().ToLower() == "new")
            {
                this.txtGreeting.Text = "";
                this.txtCompany.Text = "";
                this.lblAddress.Text = "";
                this.lblDeliveryAddress.Text = "";
                this.lblInvoiceAddress.Text = "";
            }
            this.ddlEstimateType.Items[0].Text = string.Concat("--", this.objLanguage.GetLanguageConversion("Select"), "--");
            commonClass _commonClass10 = this.comm;
            now = DateTime.Now;
            this.CreatedDate = _commonClass10.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
        }

        public DateTime ReturnWeekDate(DateTime TodaysDate, int WorkingDaysFrom, int WorkingDaysTo, int AddDays)
        {
            if (AddDays == 0)
            {
                return TodaysDate;
            }
            this.GetWeekNumber(TodaysDate.DayOfWeek.ToString());
            DateTime todaysDate = TodaysDate;
            for (int i = 1; i <= AddDays; i++)
            {
                try
                {
                    todaysDate = todaysDate.AddDays(1);
                    int weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                    if (WorkingDaysFrom <= WorkingDaysTo)
                    {
                        while (weekNumber < WorkingDaysFrom || weekNumber > WorkingDaysTo)
                        {
                            todaysDate = todaysDate.AddDays(1);
                            weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                        }
                    }
                    else
                    {
                        while (weekNumber < WorkingDaysFrom)
                        {
                            if (weekNumber > WorkingDaysTo)
                            {
                                todaysDate = todaysDate.AddDays(1);
                                weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            return todaysDate;
        }
    }
}