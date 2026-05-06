using ePrint.Proofs;
using ePrint.usercontrol.crm;
using ePrint.usercontrol.Delivery;
using ePrint.usercontrol.ESTIMATE;
using ePrint.usercontrol.INVOICE;
using ePrint.usercontrol.jobs;
using ePrint.usercontrol.orders;
using ePrint.usercontrol.purchase;
using ePrint.usercontrol.warehouse;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
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

namespace ePrint
{
    public partial class search_results : BaseClass, IRequiresSessionState
    {
        public languageClass objLanguage = new languageClass();

        public BasePage obj = new BasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int companyid;

        public int UserID;

        public string DateFormat = string.Empty;

        public string searchString = string.Empty;

        public string module = string.Empty;

        private CompanyBasePage CompanyBasePageObject = new CompanyBasePage();

        public string strSitepath = global.sitePath();

        public int OrderRecCount;

        public int JobRecCount;

        public int PurchaseRecCount;

        public int DeliveryRecCount;

        public int InvoiceRecCount;

        public int WarehouseRecCount;

        public int ProofRecCount;


        private Global gloobj = new Global();

        public bool CrmStatus;

        public bool EstimateStatus;

        public bool OrderStatus;

        public bool JobStatus;

        public bool PurchaseStatus;

        public bool DeliveryStatus;

        public bool InvoiceStatus;

        public bool WarehouseStatus;

        public bool ProofStatus;


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

        public search_results()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblResultsFor.Text = this.objLanguage.GetLanguageConversion("Search_Results_for");
            this.lblCRM.Text = this.objLanguage.GetLanguageConversion("CRM");
            this.lblSupplier.Text = this.objLanguage.GetLanguageConversion("Supplier");
            this.lblCustomer.Text = this.objLanguage.GetLanguageConversion("Customer");
            this.lblProspect.Text = this.objLanguage.GetLanguageConversion("Prospect");
            this.lblEstimates.Text = this.objLanguage.GetLanguageConversion("Estimates");
            this.lblJobs.Text = this.objLanguage.GetLanguageConversion("Jobs");
            this.lblPurchase.Text = this.objLanguage.GetLanguageConversion("Purchase");
            this.lblDelivery.Text = this.objLanguage.GetLanguageConversion("Delivery");
            this.lblWareHouse.Text = string.Concat(this.objLanguage.GetLanguageConversion("Warehouse_Report"), ": ", this.objLanguage.GetLanguageConversion("Warehouse"));
            this.lbleStoreOrders.Text = this.objLanguage.GetLanguageConversion("eStore_Orders");
            this.lblInvoice.Text = this.objLanguage.GetLanguageConversion("Invoice");
            this.lblProof.Text = this.objLanguage.GetLanguageConversion("Proof");

            if (this.Session["email"] == null)
            {
                base.Response.Redirect("error.aspx");
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.companyid = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            HttpCookie httpCookie = base.Request.Cookies.Get("searchDdlItem");
            if (httpCookie != null)
            {
                this.module = httpCookie.Value.ToString();
            }
            if (base.Request.Params["srch_val"] != null)
            {
                this.searchString = base.Request.Params["srch_val"].ToString().Trim();
                this.lblSearchstring.Text = this.searchString;
            }
            if (this.module.ToLower() == "crm")
            {
                global.pageName = "client";
                this.gloobj.setpagename("client");
                this.CrmStatus = true;
                this.pnlCRM.Visible = true;
                this.searchCRM();
                return;
            }
            if (this.module.ToLower() == "estimates")
            {
                global.pageName = "estimate";
                this.gloobj.setpagename("estimate");
                this.pnlEstimates.Visible = true;
                this.EstimateStatus = true;
                this.searchEstimate();
                return;
            }
            if (this.module.ToLower() == "order")
            {
                global.pageName = "webstoreorder";
                this.gloobj.setpagename("webstoreorder");
                this.pnlOrders.Visible = true;
                this.OrderStatus = true;
                this.searchOrder();
                return;
            }
            if (this.module.ToLower() == "job")
            {
                global.pageName = "job";
                this.gloobj.setpagename("job");
                this.pnlJob.Visible = true;
                this.JobStatus = true;
                this.searchJob();
                return;
            }
            if (this.module.ToLower() == "purchase order")
            {
                global.pageName = "purchase";
                this.gloobj.setpagename("purchase");
                this.pnlPurchaseorder.Visible = true;
                this.PurchaseStatus = true;
                this.searchPurchase();
                return;
            }
            if (this.module.ToLower() == "delivery notes")
            {
                global.pageName = "deliverynote";
                this.gloobj.setpagename("deliverynote");
                this.pnlDeliverynote.Visible = true;
                this.DeliveryStatus = true;
                this.searchDelivery();
                return;
            }
            if (this.module.ToLower() == "warehouse")
            {
                global.pageName = "Warehouse";
                this.gloobj.setpagename("Warehouse");
                this.pnlWarehouse.Visible = true;
                this.WarehouseStatus = true;
                this.searchWarehouse();
                return;
            }
            if (this.module.ToLower() == "proof")
            {
                global.pageName = "Proof";
                this.gloobj.setpagename("Proof");
                this.pnlProof.Visible = true;
                this.ProofStatus = true;
                this.searchProof();
                return;
            }
            if (this.module.ToLower() != "invoice")
            {
                if (this.module.ToLower() == "all")
                {
                    global.pageName = "client";
                    this.gloobj.setpagename("client");
                    this.showallmodule_result();
                }
                return;
            }
           
            global.pageName = "invoice";
            this.gloobj.setpagename("invoice");
            this.pnlInvoice.Visible = true;
            this.InvoiceStatus = true;
            this.searchInvoice();
        }

        public void searchCRM()
        {
            CRM_Search usercontrolCrmCRMSearch = (CRM_Search)base.LoadControl("~/usercontrol/crm/CRM_Search.ascx");
            usercontrolCrmCRMSearch.ID = "UCCRMSearchCustomer";
            usercontrolCrmCRMSearch.companytype = "Customer";
            this.plhCRMSearchCustomer.Controls.Add(usercontrolCrmCRMSearch);
            usercontrolCrmCRMSearch.GetPageCount += new GetQueryCount(this.UCRaiseCRM_customer_GetPageCount);
            CRM_Search usercontrolCrmCRMSearch1 = (CRM_Search)base.LoadControl("~/usercontrol/crm/CRM_Search.ascx");
            usercontrolCrmCRMSearch1.ID = "UCCRMSearchSupplier";
            usercontrolCrmCRMSearch1.companytype = "Supplier";
            this.plhCRMSearchSupplier.Controls.Add(usercontrolCrmCRMSearch1);
            usercontrolCrmCRMSearch1.GetPageCount += new GetQueryCount(this.UCRaiseCRM_supplier_GetPageCount);
            CRM_Search usercontrolCrmCRMSearch2 = (CRM_Search)base.LoadControl("~/usercontrol/crm/CRM_Search.ascx");
            usercontrolCrmCRMSearch2.ID = "UCCRMSearchProspect";
            usercontrolCrmCRMSearch2.companytype = "prospect";
            this.plhCRMSearchProspect.Controls.Add(usercontrolCrmCRMSearch2);
            usercontrolCrmCRMSearch2.GetPageCount += new GetQueryCount(this.UCRaiseCRM_prospect_GetPageCount);
        }

        public void searchDelivery()
        {
            DeliverySearch_General usercontrolDeliveryDeliverySearchGeneral = (DeliverySearch_General)base.LoadControl("~/usercontrol/Delivery/DeliverySearch_General.ascx");
            usercontrolDeliveryDeliverySearchGeneral.ID = "UCDeliverysearch";
            this.plhDiliverySearch.Controls.Add(usercontrolDeliveryDeliverySearchGeneral);
            usercontrolDeliveryDeliverySearchGeneral.getDeliveryRecCount += new GetDeliveyRecCount(this.UCRaiseDelivery_GetDeliveryRecCount);
        }

        public void searchEstimate()
        {
            Estimate_Search usercontrolEstimateEstimateSearch = (Estimate_Search)base.LoadControl("~/usercontrol/Estimate/Estimate_Search.ascx");
            usercontrolEstimateEstimateSearch.ID = "UCEstimateSearch";
            this.plhEstimateSearch.Controls.Add(usercontrolEstimateEstimateSearch);
            usercontrolEstimateEstimateSearch.getEstimateRecCount += new GetRecordCount(this.UCRaiseEstimate_GetEstimateRecCount);
        }

        public void searchInvoice()
        {
            Invoice_Search usercontrolInvoiceInvoiceSearch = (Invoice_Search)base.LoadControl("~/usercontrol/Invoice/Invoice_Search.ascx");
            usercontrolInvoiceInvoiceSearch.ID = "UCInvoicesearch";
            this.plhInvoiceSearch.Controls.Add(usercontrolInvoiceInvoiceSearch);
            usercontrolInvoiceInvoiceSearch.getInvoiceRecordCount += new GetInvoiceRecCount(this.UCRaiseInvoice_GetInoviceRecCount);
        }

        public void searchJob()
        {
            Job_Search usercontrolJobsJobSearch = (Job_Search)base.LoadControl("~/usercontrol/jobs/Job_Search.ascx");
            usercontrolJobsJobSearch.ID = "UcJobSearch";
            this.plhJobSearch.Controls.Add(usercontrolJobsJobSearch);
            usercontrolJobsJobSearch.getJobRecCount += new GetJobRecordCount(this.UCRaiseJob_GetJobRecCount);
        }

        public void searchOrder()
        {
            Order_Search usercontrolOrdersOrderSearch = (Order_Search)base.LoadControl("~/usercontrol/Orders/Order_Search.ascx");
            usercontrolOrdersOrderSearch.ID = "UCOrderSearch";
            this.plhOrderSearch.Controls.Add(usercontrolOrdersOrderSearch);
            usercontrolOrdersOrderSearch.getOrderRecCount += new GetOrderRecordCount(this.UCRaiseOrder_GetOrderRecCount);
        }

        public void searchPurchase()
        {
            PurchaseSearch_General usercontrolPurchasePurchaseSearchGeneral = (PurchaseSearch_General)base.LoadControl("~/usercontrol/purchase/PurchaseSearch_General.ascx");
            usercontrolPurchasePurchaseSearchGeneral.ID = "UCPurchasesearch";
            this.plhPurchaseSearch.Controls.Add(usercontrolPurchasePurchaseSearchGeneral);
            usercontrolPurchasePurchaseSearchGeneral.getPurchaseRecCount += new GetPurchaseRecCount(this.UCRaisePurchase_GetPurchaseRecCount);
        }

        public void searchWarehouse()
        {
            WerhouseSearch_General usercontrolWarehouseWerhouseSearchGeneral = (WerhouseSearch_General)base.LoadControl("~/usercontrol/warehouse/WerhouseSearch_General.ascx");
            usercontrolWarehouseWerhouseSearchGeneral.ID = "UCWareHouseSearch";
            this.plhWareHouseSearch.Controls.Add(usercontrolWarehouseWerhouseSearchGeneral);
            usercontrolWarehouseWerhouseSearchGeneral.getWarehouseRecordCount += new GetWarehouseRecCount(this.UCRaiseWarehouse_GetwarehouseRecCount);
        }

        public void searchProof()
        {
            Proof_Search usercontrolProof = (Proof_Search)base.LoadControl("~/Proofs/Proof_Search.ascx");
            usercontrolProof.ID = "UCProofSearch";
            this.plhProofSearch.Controls.Add(usercontrolProof);
            usercontrolProof.getProofRecordCount += new GetProofRecCount(this.UCRaiseProof_GetproofRecCount);
        }
        public void showallmodule_result()
        {
            DataSet dataSet = new DataSet();
            if (this.Session["HeaderNavigation"] != null)
            {
                dataSet = (DataSet)this.Session["HeaderNavigation"];
            }
            else
            {
                DataTable dataTable = new DataTable();
                string str = "";
                dataSet = this.obj.GetHeaderimage(Convert.ToInt32(this.Session["companyID"]), Convert.ToInt32(this.Session["userID"]), "Settings", ref dataTable, ref str, (int)this.Session["admin"]);
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["headerName"].ToString().ToLower().Contains("crm") || row["headerName"].ToString().ToLower().Contains("clients"))
                {
                    this.pnlCRM.Visible = true;
                    this.CrmStatus = true;
                    this.searchCRM();
                }
                if (row["headerName"].ToString().ToLower().Contains("estimates") || row["headerName"].ToString().ToLower().Contains("estimate"))
                {
                    this.pnlEstimates.Visible = true;
                    this.EstimateStatus = true;
                    this.searchEstimate();
                }
                if (row["headerName"].ToString().ToLower().Contains("webstoreorder") || row["headerName"].ToString().ToLower().Contains("orders"))
                {
                    this.pnlOrders.Visible = true;
                    this.OrderStatus = true;
                    this.searchOrder();
                }
                if (row["headerName"].ToString().ToLower().Contains("jobs") || row["headerName"].ToString().ToLower().Contains("job"))
                {
                    this.pnlJob.Visible = true;
                    this.JobStatus = true;
                    this.searchJob();
                }
                if (row["headerName"].ToString().ToLower().Contains("purchase") || row["headerName"].ToString().ToLower().Contains("purchases"))
                {
                    this.pnlPurchaseorder.Visible = true;
                    this.PurchaseStatus = true;
                    this.searchPurchase();
                }
                if (row["headerName"].ToString().ToLower().Contains("warehouse") || row["headerName"].ToString().ToLower().Contains("inventory"))
                {
                    this.pnlWarehouse.Visible = true;
                    this.WarehouseStatus = true;
                    this.searchWarehouse();
                }
                if (row["headerName"].ToString().ToLower().Contains("invoice") || row["headerName"].ToString().ToLower().Contains("invoices"))
                {
                    this.pnlInvoice.Visible = true;
                    this.InvoiceStatus = true;
                    this.searchInvoice();
                }
                //if (row["headerName"].ToString().ToLower().Contains("proof") || row["headerName"].ToString().ToLower().Contains("proofs"))
                //{
                //    this.pnlInvoice.Visible = true;
                //    this.ProofStatus = true;
                //    this.searchProof();
                //}
                if (!row["headerName"].ToString().ToLower().Contains("deliverynotes") && !row["headerName"].ToString().ToLower().Contains("deliverynote"))
                {
                    continue;
                }
                this.pnlDeliverynote.Visible = true;
                this.DeliveryStatus = true;
                this.searchDelivery();
            }
        }

        private void UCRaiseCRM_customer_GetPageCount(int RecordsCount)
        {
            this.hdnCrmCustRecfound.Value = Convert.ToString(RecordsCount);
        }

        private void UCRaiseCRM_prospect_GetPageCount(int RecordsCount)
        {
            this.hdnCrmProspectRecfound.Value = Convert.ToString(RecordsCount);
        }

        private void UCRaiseCRM_supplier_GetPageCount(int RecordsCount)
        {
            this.hdnCrmSupplierRecfound.Value = Convert.ToString(RecordsCount);
        }

        private void UCRaiseDelivery_GetDeliveryRecCount(int RecordsCount)
        {
            this.DeliveryRecCount = RecordsCount;
        }

        private void UCRaiseEstimate_GetEstimateRecCount(int RecordsCount)
        {
            this.hdnEstimateRecfound.Value = Convert.ToString(RecordsCount);
        }

        private void UCRaiseInvoice_GetInoviceRecCount(int RecordsCount)
        {
            this.InvoiceRecCount = RecordsCount;
        }

        private void UCRaiseJob_GetJobRecCount(int RecordsCount)
        {
            this.JobRecCount = RecordsCount;
        }

        private void UCRaiseOrder_GetOrderRecCount(int RecordsCount)
        {
            this.OrderRecCount = RecordsCount;
        }

        private void UCRaisePurchase_GetPurchaseRecCount(int RecordsCount)
        {
            this.PurchaseRecCount = RecordsCount;
        }

        private void UCRaiseWarehouse_GetwarehouseRecCount(int RecordsCount)
        {
            this.WarehouseRecCount = RecordsCount;
        }
        private void UCRaiseProof_GetproofRecCount(int RecordsCount)
        {
            this.ProofRecCount = RecordsCount;
        }
    }
}