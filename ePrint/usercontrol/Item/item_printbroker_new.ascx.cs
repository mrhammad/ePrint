using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class item_printbroker_new : UsercontrolBasePage
    {
        private const int LENGTH_TEXT = 100;


        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        private BasePage objPage = new BasePage();

        private BaseClass Objclss = new BaseClass();

        private EstimateBasePage EstBase = new EstimateBasePage();

        private commonClass commclass = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objLanguage = new languageClass();

        public string SecureSitePath = global.SecureSitePath();

        public string ServerName = string.Empty;

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long EstimateItemID;

        public string DateFormat = string.Empty;

        public string UcPage = string.Empty;

        public string IsMain = string.Empty;

        public string ReqType = string.Empty;

        public long EstSingleItemID;

        public long ParentItemID;

        private string ParentItemType = string.Empty;

        public string EstTypeFromSP = string.Empty;

        public string EstType = string.Empty;

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public static string modulename;

        public string submodulename = "estimate";

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public long EstimateBookletItemID;

        public string subedit = string.Empty;

        public string newdate = string.Empty;

        public bool IsPrintBrokerDirect = true;

        public string ClientId_PB = string.Empty;

        public static double printbroker_markup;

        private commonClass comm = new commonClass();

        public string frmcopyitem = string.Empty;

        public string MainType = string.Empty;

        public static string ProfitTaxKey;

        public string SupplierID_Client = string.Empty;

        public string Supplier_DdlID_Client = string.Empty;

        public string SupplierID_ContactID = string.Empty;

        public string Supplier_DdlID_ContactID = string.Empty;

        public int QtyNumber;

        public string ISFromAddAnItem = "n";

        public string SysName = string.Empty;

        public string StrNum_Inv = string.Empty;

        public int JobCompletionDateInc = ConnectionClass.JobCompletionDate;

        private commonClass objJava = new commonClass();

        public string[] KeyCodeArray;

        public string KeyCodeText = string.Empty;

        public int IsProductCreated;

        public string Supplier = string.Empty;

        public string Name = string.Empty;

        public string Contact = string.Empty;

        public string IsProductDescAutofill = ConnectionClass.IsProductDescAutofill;

        public bool IsArchive_Job;

        public long Module_ID;

        public string Modul_Name = string.Empty;

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

        static item_printbroker_new()
        {
            item_printbroker_new.modulename = "estimates";
            item_printbroker_new.printbroker_markup = 0;
            item_printbroker_new.ProfitTaxKey = string.Empty;
        }

        public item_printbroker_new()
        {
        }

        protected void btncancel_click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] estimateID = new object[] { this.strSitepath, "Estimates/estimate_summary_reeng.aspx?frm=add&estid=", this.EstimateID, this.jID, this.InvID };
            response.Redirect(string.Concat(estimateID));
        }

        protected void btnOutWork_OnClick(object sender, EventArgs e)
        {
            this.OUTWORK_INSERT("");
        }

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (item_printbroker_new.modulename == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, item_printbroker_new.modulename);
            }
            else if (item_printbroker_new.modulename == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, item_printbroker_new.modulename);
            }
            if (this.QueryType == "add")
            {
                if (item_printbroker_new.modulename != "orders")
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (empty.ToString().ToLower() != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?Estid=", this.EstimateID, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse httpResponse = base.Response;
                            object[] objArray = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?Estid=", this.EstimateID, this.jID, this.InvID };
                            httpResponse.Redirect(string.Concat(objArray));
                        }
                    }
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        if (this.submodulename.ToLower() == "estimate")
                        {
                            this.submodulename = "estimates";
                        }
                        if (this.submodulename.ToLower() == "job")
                        {
                            this.submodulename = "job";
                        }
                        if (this.submodulename.ToLower() == "invoice")
                        {
                            this.submodulename = "invoices";
                        }
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=O&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToString().ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&Estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response3.Redirect(string.Concat(estimateID3));
                    return;
                }
            }
            else if (this.QueryType == "edit")
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                if (item_printbroker_new.modulename != "orders")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        if (empty.ToString().ToLower() == "yes")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response4.Redirect(string.Concat(estimateID4));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        if (empty.ToString().ToLower() == "yes")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] objArray4 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?Estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(objArray4));
                            return;
                        }
                        HttpResponse response5 = base.Response;
                        object[] estimateID5 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?Estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        response5.Redirect(string.Concat(estimateID5));
                        return;
                    }
                    if (this.submodulename.ToLower() == "estimate")
                    {
                        this.submodulename = "estimates";
                    }
                    if (this.submodulename.ToLower() == "job")
                    {
                        this.submodulename = "job";
                    }
                    if (this.submodulename.ToLower() == "invoice")
                    {
                        this.submodulename = "invoices";
                    }
                    HttpResponse httpResponse5 = base.Response;
                    object[] objArray5 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=O&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response6.Redirect(string.Concat(estimateID6));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        HttpResponse httpResponse6 = base.Response;
                        object[] objArray6 = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&Estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        httpResponse6.Redirect(string.Concat(objArray6));
                        return;
                    }
                }
            }
        }

        public string DateFormat_returnasdateformat(string DateFormat, string txtvalue)
        {
            string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
            if (DateFormat == "dd/mm/yyyy")
            {
                string[] strArrays1 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                txtvalue = string.Concat(strArrays1);
            }
            else if (DateFormat == "mm/dd/yyyy")
            {
                string[] strArrays2 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                txtvalue = string.Concat(strArrays2);
            }
            return txtvalue;
        }

        protected void ddlsupplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void GetDefaultMarkuptype()
        {
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hid_DefaultMarkupType.Value = row["OutworkMarkuptype"].ToString();
            }
        }

        private void Insert_activity_history()
        {
            if (string.Compare(this.QueryType, "add", true) != 0)
            {
                string empty = string.Empty;
                if (item_printbroker_new.modulename == "estimates")
                {
                    DataTable dataTable = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, item_printbroker_new.modulename);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty = row["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = empty;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                }
                else if (item_printbroker_new.modulename == "jobs")
                {
                    DataTable dataTable1 = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, item_printbroker_new.modulename);
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        empty = dataRow["rownumber"].ToString();
                    }
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Item_number = empty;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                }
                else if (item_printbroker_new.modulename == "invoice")
                {
                    DataTable dataTable2 = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, item_printbroker_new.modulename);
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        empty = row1["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                }
                else if (item_printbroker_new.modulename == "orders")
                {
                    DataTable dataTable3 = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, item_printbroker_new.modulename);
                    foreach (DataRow dataRow1 in dataTable3.Rows)
                    {
                        empty = dataRow1["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = empty;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                }
            }
            else if (base.Request.Params["FromAddAnItem"] == null)
            {
                string str = string.Empty;
                if (item_printbroker_new.modulename == "estimates")
                {
                    DataTable dataTable4 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                    foreach (DataRow row2 in dataTable4.Rows)
                    {
                        str = row2["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = "OutWork Item";
                    this.objnotes.Estimate_number = str;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                else if (item_printbroker_new.modulename == "jobs")
                {
                    DataTable dataTable5 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "job", (long)0);
                    foreach (DataRow dataRow2 in dataTable5.Rows)
                    {
                        str = dataRow2["jobnumber"].ToString();
                    }
                    this.objnotes.Job_type = "OutWork Item";
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = str;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                }
                else if (item_printbroker_new.modulename == "invoice")
                {
                    DataTable dataTable6 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "invoice", (long)0);
                    foreach (DataRow row3 in dataTable6.Rows)
                    {
                        str = row3["invoicenumber"].ToString();
                    }
                    this.objnotes.Invoice_type = "OutWork Item";
                    this.objnotes.Invoice_number = str;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                }
                else if (item_printbroker_new.modulename == "orders")
                {
                    DataTable dataTable7 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.EstimateID, "", (long)0);
                    foreach (DataRow dataRow3 in dataTable7.Rows)
                    {
                        str = dataRow3["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = "OutWork Item";
                    this.objnotes.Estimate_number = str;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
            }
            else
            {
                string empty1 = string.Empty;
                DataTable dataTable8 = Notes.select_item_number_for_Activity_History(this.EstimateID, this.EstimateItemID, item_printbroker_new.modulename);
                foreach (DataRow row4 in dataTable8.Rows)
                {
                    empty1 = row4["rownumber"].ToString();
                }
                this.objnotes.Item_number = string.Concat("Item ", empty1);
                if (item_printbroker_new.modulename == "estimates")
                {
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.Estimate_type = "OutWork Item";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                }
                else if (item_printbroker_new.modulename == "jobs")
                {
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_type = "OutWork Item";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                }
                else if (item_printbroker_new.modulename == "invoice")
                {
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.Invoice_type = "OutWork Item";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                }
                else if (item_printbroker_new.modulename == "orders")
                {
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.Estimate_type = "OutWork Item";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                }
            }
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = this.EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_activity_history(int CompanyID, long ModuleID, long EstimateItemID)
        {
            if (item_printbroker_new.modulename.Contains("job"))
            {
                ModuleID = this.jobID;
            }
            else if (!item_printbroker_new.modulename.Contains("invoice"))
            {
                ModuleID = this.EstimateID;
            }
            else
            {
                ModuleID = this.InvoiceID;
            }
            if (string.Compare(this.MainType, "add", true) == 0)
            {
                string str = "O";
                string str1 = "OutWork Item";
                string empty = string.Empty;
                foreach (DataRow row in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
                {
                    empty = row["itemtitle"].ToString();
                }
                if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
                {
                    string empty1 = string.Empty;
                    foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                    {
                        empty1 = dataRow["rownumber"].ToString();
                    }
                    if (item_printbroker_new.modulename == "estimates")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Estimate_type = str1;
                    }
                    else if (item_printbroker_new.modulename == "jobs")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Job_type = str1;
                    }
                    else if (item_printbroker_new.modulename == "invoice")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Invoice_type = str1;
                    }
                    else if (item_printbroker_new.modulename == "orders")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Estimate_type = str1;
                    }
                    this.objnotes.ModuleID = ModuleID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                    return;
                }
                string empty2 = string.Empty;
                if (item_printbroker_new.modulename == "estimates")
                {
                    foreach (DataRow row1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = row1["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                else if (item_printbroker_new.modulename == "jobs")
                {
                    foreach (DataRow dataRow1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "job", (long)0).Rows)
                    {
                        empty2 = dataRow1["jobnumber"].ToString();
                    }
                    this.objnotes.Job_type = str1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = empty2;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                }
                else if (item_printbroker_new.modulename == "invoice")
                {
                    foreach (DataRow row2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "invoice", (long)0).Rows)
                    {
                        empty2 = row2["invoicenumber"].ToString();
                    }
                    this.objnotes.Invoice_type = str1;
                    this.objnotes.Invoice_number = empty2;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                }
                else if (item_printbroker_new.modulename == "orders")
                {
                    foreach (DataRow dataRow2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = dataRow2["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
            {
                string str2 = "O";
                string str3 = "OutWork Item";
                string empty3 = string.Empty;
                if (item_printbroker_new.modulename == "estimates")
                {
                    if (str2.ToLower() != "o")
                    {
                        foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                        {
                            empty3 = row3["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else
                    {
                        foreach (DataRow dataRow3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                        {
                            empty3 = (dataRow3["IsParentItem"].ToString().ToLower() != "true" ? dataRow3["ParentItemNumber"].ToString() : dataRow3["rownumber"].ToString());
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.Estimate_type = str3;
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                        }
                        else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemRerun);
                        }
                    }
                }
                else if (item_printbroker_new.modulename == "jobs")
                {
                    foreach (DataRow row4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                    {
                        empty3 = (row4["IsParentItem"].ToString().ToLower() != "true" ? row4["ParentItemNumber"].ToString() : row4["rownumber"].ToString());
                    }
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = empty3;
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubItemRerun);
                    }
                }
                else if (item_printbroker_new.modulename == "invoice")
                {
                    foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                    {
                        empty3 = (dataRow4["IsParentItem"].ToString().ToLower() != "true" ? dataRow4["ParentItemNumber"].ToString() : dataRow4["rownumber"].ToString());
                    }
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = empty3;
                    this.objnotes.ModuleName = "invoice";
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvSubItemRerun);
                    }
                }
                else if (item_printbroker_new.modulename == "orders")
                {
                    if (str2.ToLower() != "o")
                    {
                        foreach (DataRow row5 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                        {
                            empty3 = row5["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else
                    {
                        foreach (DataRow dataRow5 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, item_printbroker_new.modulename).Rows)
                        {
                            empty3 = (dataRow5["IsParentItem"].ToString().ToLower() != "true" ? dataRow5["ParentItemNumber"].ToString() : dataRow5["rownumber"].ToString());
                        }
                        this.objnotes.Estimate_type = str3;
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "webstoreorder";
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                        }
                        else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemRerun);
                        }
                    }
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass2 = this.objJava;
                DateTime now1 = DateTime.Now;
                _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
        }

        private string Insert_ItemDesc_PrintEmail(string strData)
        {
            StringBuilder stringBuilder = new StringBuilder()
            {
                Length = 0
            };
            string[] strArrays = strData.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(strArrays1[1].ToString().Trim()) && j == 3)
                        {
                            object[] str = new object[] { strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString() };
                            stringBuilder.AppendFormat("{0}»{1}»{2}»{3}µ", str);
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

        public void lnkPrintEmail_OnClick(object sender, EventArgs e)
        {
            this.OUTWORK_INSERT("PrintEmail");
        }

        private string Main_Outwork_RFQ_Label_Insert(string strPara)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = strPara.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                strArrays1[0] = strArrays1[0].Trim();
                stringBuilder.Append(" Insert into [TABLE_EstOutworkRFQLabel] (EstOutworkID,Label,Description,FieldName,IsChecked) values ");
                string[] strArrays2 = new string[] { " (@EstOutworkID,'", this.objBase.ReplaceSingleQuote(strArrays1[1].Trim()), "','", this.objBase.ReplaceSingleQuote(strArrays1[2].Trim()), "','", this.objBase.ReplaceSingleQuote(strArrays1[0].Trim()), "','", this.objBase.ReplaceSingleQuote(strArrays1[3].Trim()), "');" };
                stringBuilder.Append(string.Concat(strArrays2));
            }
            return stringBuilder.ToString();
        }

        private void OUTWORK_INSERT(string paraMeter)
        {
            DateTime now;
            object[] qtyNumber;
            string[] str;
            long num = (long)0;
            this.Phrase_Insert_Before_Check();
            if (this.hdn_supplierproductcatalogueid.Value != null)
            {
                num = Convert.ToInt64(this.hdn_supplierproductcatalogueid.Value);
            }
            if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                this.ParentItemID = this.ParentEstimateItemID;
                foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                {
                    this.EstTypeFromSP = row["EstimateType"].ToString();
                    this.ParentItemType = row["EstimateType"].ToString();
                }
            }
            else if (base.Request.Params["type"].ToString() == "add" || this.frmcopyitem == "yes")
            {
                long parentEstimateItemID = (long)0;
                if (this.ParentEstimateItemID != (long)0)
                {
                    bool flag = false;
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        flag = false;
                        parentEstimateItemID = this.ParentEstimateItemID;
                    }
                    else
                    {
                        flag = true;
                        parentEstimateItemID = (long)0;
                    }
                    if (this.InvoiceID <= (long)0)
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "O", flag, parentEstimateItemID);
                    }
                    else
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "O", flag, parentEstimateItemID);
                    }
                    if (this.jobID > (long)0)
                    {
                        long estimateItemID = this.EstimateItemID;
                        long num1 = this.jobID;
                        commonClass _commonClass = this.objJava;
                        now = DateTime.Now;
                        JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num1, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                    }
                    if (this.InvoiceID > (long)0)
                    {
                        InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                    }
                    foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                    {
                        this.EstTypeFromSP = dataRow["EstimateType"].ToString();
                        this.ParentItemType = dataRow["EstimateType"].ToString();
                    }
                    this.ParentItemID = this.ParentEstimateItemID;
                }
                else
                {
                    bool flag1 = false;
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        flag1 = false;
                        parentEstimateItemID = this.ParentEstimateItemID;
                    }
                    else
                    {
                        flag1 = true;
                        parentEstimateItemID = (long)0;
                    }
                    if (this.InvoiceID <= (long)0)
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "O", flag1, parentEstimateItemID);
                    }
                    else
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "O", flag1, parentEstimateItemID);
                    }
                    EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                    if (this.jobID > (long)0)
                    {
                        long estimateItemID1 = this.EstimateItemID;
                        long num2 = this.jobID;
                        commonClass _commonClass1 = this.objJava;
                        now = DateTime.Now;
                        JobBasePage.EstimateItems_ProgressToJob(estimateItemID1, num2, false, Convert.ToDateTime(_commonClass1.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                    }
                    if (this.InvoiceID > (long)0)
                    {
                        InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                    }
                    this.EstSingleItemID = (long)0;
                    this.EstTypeFromSP = "";
                }
            }
            string empty = string.Empty;
            empty = this.hid_outwork_save.Value;
            string str1 = this.Objclss.ReplaceSingleQuote(empty);
            char[] chrArray = new char[] { 'µ' };
            string[] strArrays = str1.Split(chrArray);
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
            {
                this.ParentItemID = this.EstimateBookletItemID;
            }
            string str2 = "no";
            string empty3 = string.Empty;
            if (base.Request.Params["type"].ToString().ToLower() == "edit" || paraMeter.ToString().ToLower() == "printemail" || base.Request.Params["type"].ToString().ToLower() == "add")
            {
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i].Trim()))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringBuilder1 = new StringBuilder();
                        StringBuilder stringBuilder2 = new StringBuilder();
                        StringBuilder stringBuilder3 = new StringBuilder();
                        StringBuilder stringBuilder4 = new StringBuilder();
                        string str3 = strArrays[i];
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays1 = str3.Split(chrArray);
                        double num3 = 0;
                        double num4 = 0;
                        int num5 = 0;
                        double num6 = 0;
                        foreach (DataRow row1 in EstimatesBasePage.estimate_summary_outwork_taxprofitmargin_select(this.CompanyID, this.EstimateItemID).Rows)
                        {
                            num5 = Convert.ToInt32(row1["TaxID"]);
                            num4 = Convert.ToDouble(row1["Tax"]);
                            num3 = Convert.ToDouble(row1["ProfitMargin"]);
                            num6 = Convert.ToDouble(row1["SubTotal"]);
                        }
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            if (j == 0)
                            {
                                stringBuilder1.Append(" Insert into tb_EstOutwork (EstimateItemID,CostingType,RFQReturnDate,JobCompletionDate,Header,Footer,");
                                stringBuilder1.Append(" ArtWork,ItemTitle,Design,Colour,Size,Materials,Finishing,Delivery,Notes,CreatedBy,ItemDescription,ParentItemID,ParentItemType,PriceCatalogueID)");
                                stringBuilder1.Append(string.Concat(" Values (", this.EstimateItemID, ",  "));
                                if (base.Request.Params["type"].ToString() == "edit")
                                {
                                    stringBuilder2.Append(" Update [TABLE_EstOutwork] ");
                                    stringBuilder2.Append(" SET ");
                                }
                                string str4 = strArrays1[j];
                                chrArray = new char[] { '±' };
                                string[] strArrays2 = str4.Split(chrArray);
                                string empty4 = string.Empty;
                                for (int k = 0; k < (int)strArrays2.Length; k++)
                                {
                                    string str5 = strArrays2[k];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays3 = str5.Split(chrArray);
                                    strArrays3[0] = strArrays3[0].Trim();
                                    if (strArrays3[0].Trim() == "QtyType")
                                    {
                                        string str6 = strArrays3[1].Trim();
                                        if (str6 == "single")
                                        {
                                            empty4 = "S";
                                        }
                                        else if (str6 == "runon")
                                        {
                                            empty4 = "R";
                                        }
                                        else if (str6 == "multiple")
                                        {
                                            empty4 = "M";
                                        }
                                    }
                                    else if (strArrays3[0].Trim() == "Quantity")
                                    {
                                        string str7 = strArrays3[1].Trim();
                                        chrArray = new char[] { '|' };
                                        string[] strArrays4 = str7.Split(chrArray);
                                        for (int l = 0; l < (int)strArrays4.Length; l++)
                                        {
                                            if (!string.IsNullOrEmpty(strArrays4[l].Trim()) && Convert.ToInt32(strArrays4[l].Trim()) != 0)
                                            {
                                                stringBuilder.Append(" Insert into tb_EstQuantity ");
                                                stringBuilder.Append(" ( ItemType,ItemID,QtyType,QtyNumber,Quantity )");
                                                stringBuilder.Append(" Values");
                                                if (!(base.Request.Params["type"].ToString() == "add") || this.ParentEstimateItemID <= (long)0 || !(item_printbroker_new.modulename.ToLower() == "jobs") && !(item_printbroker_new.modulename.ToLower() == "invoice") && !(item_printbroker_new.modulename.ToLower() == "orders"))
                                                {
                                                    qtyNumber = new object[] { "( 'O',@EstOutworkID,'", empty4, "',", l, ",", strArrays4[l], "); " };
                                                    stringBuilder.Append(string.Concat(qtyNumber));
                                                }
                                                else
                                                {
                                                    qtyNumber = new object[] { "( 'O',@EstOutworkID,'", empty4, "',", this.QtyNumber, ",", strArrays4[l], "); " };
                                                    stringBuilder.Append(string.Concat(qtyNumber));
                                                }
                                            }
                                        }
                                    }
                                    else if (strArrays3[0].Trim() == "CostingType")
                                    {
                                        string empty5 = string.Empty;
                                        //empty5 = (strArrays3[1].Trim().ToLower() == "simple" || strArrays3[1].Trim().ToLower() == "s" ? "S" : "U");
                                        if (strArrays3[1].Trim().ToLower() == "per1000" || strArrays3[1].Trim().ToLower() == "p")
                                        {
                                            empty5 = "P";
                                        }
                                        else if (strArrays3[1].Trim().ToLower() == "unit" || strArrays3[1].Trim().ToLower() == "u")
                                        {
                                            empty5 = "U";
                                        }
                                        else if (strArrays3[1].Trim().ToLower() == "simple" || strArrays3[1].Trim().ToLower() == "s")
                                        {
                                            empty5 = "S";
                                        }
                                        stringBuilder1.Append(string.Concat("'", empty5, "',"));
                                        stringBuilder2.Append(string.Concat("CostingType='", empty5, "',"));
                                    }
                                    else if (strArrays3[0].Trim() == "RFQReturnDate")
                                    {
                                        if (!string.IsNullOrEmpty(strArrays3[1].Trim()))
                                        {
                                            now = Convert.ToDateTime(this.RadTimePicker1.SelectedDate);
                                            string str8 = now.ToString("h:mm:ss tt");
                                            string str9 = this.Objclss.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, strArrays3[1].Trim());
                                            if (str9.Length <= 10)
                                            {
                                                str9 = string.Concat(str9, " ", str8);
                                            }
                                            stringBuilder1.Append(string.Concat(" '", str9, "', "));
                                            stringBuilder2.Append(string.Concat("RFQReturnDate='", str9, "',"));
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("'01/01/1900',");
                                            stringBuilder2.Append("RFQReturnDate='01/01/1900',");
                                        }
                                    }
                                    else if (strArrays3[0].Trim() == "JobCompletionDate")
                                    {
                                        if (!string.IsNullOrEmpty(strArrays3[1].Trim()))
                                        {
                                            int length = this.Objclss.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, strArrays3[1].Trim()).Length;
                                            stringBuilder1.Append(string.Concat(" '", this.Objclss.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, strArrays3[1].Trim()), "', "));
                                            stringBuilder2.Append(string.Concat("JobCompletionDate='", this.Objclss.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, strArrays3[1].Trim()), "',"));
                                        }
                                        else
                                        {
                                            stringBuilder1.Append("'01/01/1900',");
                                            stringBuilder2.Append("JobCompletionDate='01/01/1900',");
                                        }
                                    }
                                    else if (string.Compare(strArrays3[0].Trim(), "Header", true) == 0)
                                    {
                                        stringBuilder1.Append(string.Concat(" '", this.Objclss.ReplaceSingleQuote(strArrays3[1].Trim()), "', "));
                                        stringBuilder2.Append(string.Concat("Header='", this.Objclss.ReplaceSingleQuote(strArrays3[1].Trim()), "',"));
                                    }
                                    else if (string.Compare(strArrays3[0].Trim(), "Footer", true) == 0)
                                    {
                                        stringBuilder1.Append(string.Concat(" '", this.Objclss.ReplaceSingleQuote(strArrays3[1].Trim()), "', "));
                                        stringBuilder2.Append(string.Concat("Footer='", this.Objclss.ReplaceSingleQuote(strArrays3[1].Trim()), "',"));
                                    }
                                    else if (strArrays3[0].Trim() == "ArtWork")
                                    {
                                        if (strArrays3[1].Trim() != "")
                                        {
                                            string str10 = strArrays3[1].Trim();
                                            chrArray = new char[] { '«' };
                                            string[] strArrays5 = str10.Split(chrArray);
                                            for (int m = 0; m < (int)strArrays5.Length - 1; m++)
                                            {
                                                if (strArrays5[m].ToString().Trim() != "")
                                                {
                                                    empty1 = string.Concat(empty1, strArrays5[m].ToString().Trim(), "«");
                                                }
                                            }
                                        }
                                        string str11 = strArrays1[1].Replace("±", "µ");
                                        stringBuilder1.Append(string.Concat("'", this.Objclss.ReplaceSingleQuote(empty1), "',"));
                                        stringBuilder1.Append(string.Concat("'", this.Objclss.ReplaceSingleQuote(this.hid_outwork_title.Value), "',' ',"));
                                        stringBuilder1.Append("' ',' ',");
                                        stringBuilder1.Append("' ',' ',");
                                        stringBuilder1.Append("' ',' ',");
                                        stringBuilder1.Append(string.Concat(base.Session["UserID"].ToString(), ","));
                                        qtyNumber = new object[] { "'", str11, "',", this.ParentItemID, ",'", this.EstTypeFromSP, "',", num, ");" };
                                        stringBuilder1.Append(string.Concat(qtyNumber));
                                        stringBuilder1.Append("DECLARE @EstOutworkID bigint;");
                                        stringBuilder1.Append("set @EstOutworkID = ident_current('tb_EstOutwork');");
                                        empty3 = this.Objclss.ReplaceSingleQuote(empty1);
                                        stringBuilder2.Append(string.Concat("ArtWork='", this.Objclss.ReplaceSingleQuote(empty1), "', "));
                                        stringBuilder2.Append(string.Concat("ItemTitle='", this.Objclss.ReplaceSingleQuote(this.hid_outwork_title.Value), "', "));
                                        stringBuilder2.Append("Design=' ', ");
                                        stringBuilder2.Append("Colour=' ', ");
                                        stringBuilder2.Append("Size=' ', ");
                                        stringBuilder2.Append("Materials=' ', ");
                                        stringBuilder2.Append("Finishing=' ', ");
                                        stringBuilder2.Append("Delivery=' ', ");
                                        stringBuilder2.Append("Notes=' ', ");
                                        stringBuilder2.Append(string.Concat("ModifiedBy=", base.Session["UserID"].ToString(), ","));
                                        stringBuilder2.Append(string.Concat("ItemDescription='", str11, "',"));
                                        if (base.Request.Params["parentestitemid"] == null)
                                        {
                                            this.ParentItemID = (long)0;
                                        }
                                        else
                                        {
                                            this.ParentItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                                        }
                                        stringBuilder2.Append(string.Concat("ParentItemID=", this.ParentItemID, ","));
                                        stringBuilder2.Append(string.Concat("ParentItemType='", this.EstTypeFromSP, " ',"));
                                        stringBuilder2.Append(string.Concat("PriceCatalogueID=", num, " "));
                                    }
                                    else if (strArrays3[0].Trim() == "EstItemOutworkID" && base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes")
                                    {
                                        stringBuilder2.Append(string.Concat(" Where EstOutworkID=", strArrays3[1].Trim(), " ;"));
                                        stringBuilder2.Append(" DECLARE @EstOutworkID bigint; ");
                                        stringBuilder2.Append(string.Concat(" Set @EstOutworkID=", strArrays3[1].Trim(), "; "));
                                        stringBuilder2.Append("Delete from tb_EstQuantity where  ItemType='O' AND ItemID=@EstOutworkID; ");
                                        if (!string.IsNullOrEmpty(strArrays3[1].Trim()))
                                        {
                                            stringBuilder1.Remove(0, stringBuilder1.Length);
                                            stringBuilder1.Append(stringBuilder2.ToString());
                                        }
                                    }
                                }
                            }
                            else if (j == 1)
                            {
                                stringBuilder3.Append("Delete from tb_EstOutworkRFQLabel where EstOutworkID=@EstOutworkID; ");
                                stringBuilder3.Append(this.Main_Outwork_RFQ_Label_Insert(strArrays1[j]));
                                if (this.Chk_POItmDescn.Checked)
                                {
                                    string str12 = strArrays1[j].Replace('±', 'µ');
                                    string str13 = SummaryClass.Split_ItemDescription(str12);
                                    EstimateBasePage.Update_Description_OnCheck(this.CompanyID, this.EstimateID, this.EstimateItemID, this.objBase.ReplaceSingleQuote(str13));
                                }
                                if (this.Chk_DNCopy.Checked)
                                {
                                    string str14 = strArrays1[j].Replace('±', 'µ');
                                    string str15 = SummaryClass.Split_ItemDescription(str14);
                                    EstimateBasePage.Update_Description_OnCheck_DN(this.EstimateID, this.EstimateItemID, this.objBase.ReplaceSingleQuote(str15));
                                }
                                if (string.Compare(paraMeter, "PrintEmail", true) == 0 && base.Request.Params["type"].ToString().ToLower() == "add")
                                {
                                    str2 = "yes";
                                }
                            }
                            else if (j == 2)
                            {
                                stringBuilder4.Append(" Delete from tb_EstOutworkSupplier where EstOutworkID=@EstOutworkID and IsDeleted=1; ");
                                stringBuilder4.Append(" Update tb_EstOutworkSupplier set IsDeleted=1 where EstOutworkID=@EstOutworkID; ");
                                string str16 = strArrays1[j];
                                chrArray = new char[] { 'Ç' };
                                string[] strArrays6 = str16.Split(chrArray);
                                string empty6 = string.Empty;
                                string empty7 = string.Empty;
                                for (int n = 0; n < (int)strArrays6.Length; n++)
                                {
                                    if (!string.IsNullOrEmpty(strArrays6[n]))
                                    {
                                        string str17 = strArrays6[n];
                                        chrArray = new char[] { '±' };
                                        string[] strArrays7 = str17.Split(chrArray);
                                        stringBuilder4.Append(" Insert into tb_EstOutworkSupplier (EstOutworkID,SupplierID,");
                                        stringBuilder4.Append(" SupplierContactID,Quantity,Cost,IsDeliveryIncluded,DeliveryCost,");
                                        stringBuilder4.Append(" DeliveryDate,MarkUpType,MarkUpValue,TotalPrice,IsSelected,QuantityNumber,SupplierRefNo,");
                                        stringBuilder4.Append(" Tax,TaxID,ProfitMargin,SubTotal)");
                                        stringBuilder4.Append(" values ( ");
                                        for (int o = 0; o < (int)strArrays7.Length; o++)
                                        {
                                            string str18 = strArrays7[o];
                                            chrArray = new char[] { '»' };
                                            string[] strArrays8 = str18.Split(chrArray);
                                            strArrays8[0] = strArrays8[0].Trim();
                                            strArrays8[1] = strArrays8[1].Trim();
                                            if (strArrays8[0] == "SupplierID")
                                            {
                                                if (n == 0)
                                                {
                                                    empty6 = strArrays8[1];
                                                }
                                                else if (empty6 != strArrays8[1])
                                                {
                                                    empty6 = strArrays8[1];
                                                }
                                                stringBuilder4.Append(string.Concat("@EstOutworkID,", strArrays8[1], ","));
                                            }
                                            else if (strArrays8[0] == "SupplierContactID")
                                            {
                                                stringBuilder4.Append(string.Concat(strArrays8[1], ","));
                                            }
                                            else if (strArrays8[0] == "Quantity")
                                            {
                                                stringBuilder4.Append(string.Concat(strArrays8[1], ","));
                                            }
                                            else if (strArrays8[0] == "Cost")
                                            {
                                                stringBuilder4.Append(string.Concat((strArrays8[1].Trim() == "" ? "0" : strArrays8[1].Trim()), ","));
                                            }
                                            else if (strArrays8[0] == "DeliveryIncluded")
                                            {
                                                stringBuilder4.Append(string.Concat("'", strArrays8[1], "',"));
                                            }
                                            else if (strArrays8[0] == "DeliveryCost")
                                            {
                                                stringBuilder4.Append(string.Concat((strArrays8[1] == "" ? "0" : strArrays8[1]), ","));
                                            }
                                            else if (strArrays8[0] == "DeliveryDate")
                                            {
                                                if (!string.IsNullOrEmpty(strArrays8[1].Trim()))
                                                {
                                                    stringBuilder4.Append(string.Concat(" '", this.Objclss.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, strArrays8[1].Trim()), "', "));
                                                }
                                                else
                                                {
                                                    stringBuilder4.Append("'01/01/1900',");
                                                }
                                            }
                                            else if (strArrays8[0] == "MarkupType")
                                            {
                                                string empty8 = string.Empty;
                                                if (!(paraMeter.ToLower() == "printemail") || !(base.Request.Params["type"].ToString().ToLower() == "add"))
                                                {
                                                    empty8 = (strArrays8[1].Trim() == "percentage" ? "P" : "F");
                                                }
                                                else
                                                {
                                                    empty8 = (this.hid_DefaultMarkupType.Value != "2" ? "P" : "F");
                                                }
                                                stringBuilder4.Append(string.Concat("'", empty8, "',"));
                                            }
                                            else if (strArrays8[0] == "MarkupValue")
                                            {
                                                string empty9 = string.Empty;
                                                if (!(paraMeter.ToLower() == "printemail") || !(base.Request.Params["type"].ToString().ToLower() == "add"))
                                                {
                                                    empty9 = (strArrays8[1] == "" ? "0" : strArrays8[1]);
                                                }
                                                else
                                                {
                                                    decimal num7 = Math.Round(Convert.ToDecimal(item_printbroker_new.printbroker_markup), 2);
                                                    empty9 = num7.ToString();
                                                }
                                                stringBuilder4.Append(string.Concat(empty9, ","));
                                            }
                                            else if (strArrays8[0] == "TotalPrice")
                                            {
                                                stringBuilder4.Append(string.Concat((strArrays8[1].Trim() == "" ? "0" : strArrays8[1].Trim()), ","));
                                            }
                                            else if (strArrays8[0] == "IsSelected")
                                            {
                                                stringBuilder4.Append(string.Concat("'", strArrays8[1], "',"));
                                            }
                                            else if (strArrays8[0] == "QuantityNumber")
                                            {
                                                string str19 = (strArrays8[1].Trim() == "undefined" ? (n + 1).ToString() : strArrays8[1].Trim());
                                                if (!(base.Request.Params["type"].ToString() == "edit") || this.ParentEstimateItemID <= (long)0 || !(item_printbroker_new.modulename.ToLower() == "jobs") && !(item_printbroker_new.modulename.ToLower() == "invoice") && !(item_printbroker_new.modulename.ToLower() == "orders"))
                                                {
                                                    stringBuilder4.Append(string.Concat(str19, ", "));
                                                }
                                                else
                                                {
                                                    stringBuilder4.Append(string.Concat(str19, ", "));
                                                }
                                            }
                                            else if (strArrays8[0] == "SupplierRefNo")
                                            {
                                                stringBuilder4.Append(string.Concat("'", strArrays8[1].ToString(), "',"));
                                            }
                                            else if (o == 12 && strArrays8[0] != "SupplierRefNo")
                                            {
                                                stringBuilder4.Append("'',");
                                            }
                                        }
                                        stringBuilder4.Append(string.Concat(num4, ", "));
                                        stringBuilder4.Append(string.Concat(num5, ", "));
                                        stringBuilder4.Append(string.Concat(num3, ", "));
                                        stringBuilder4.Append(string.Concat(num6, "); "));
                                    }
                                }
                            }
                        }
                        string str20 = "   DECLARE @SupplierID bigint DECLARE TABLEName CURSOR FOR SELECT distinct SupplierID from tb_estOutworksupplier where EstOutworkID=@EstOutworkID  and IsDeleted=0 OPEN TABLEName FETCH NEXT FROM TABLEName INTO @SupplierID WHILE @@FETCH_STATUS=0 BEGIN declare @KeyCode nvarchar(100) set @KeyCode=substring(cast(newid() as nvarchar(100)),0,17) update tb_estOutworksupplier set  KeyCode= @KeyCode where EstOutworkID=@EstOutworkID and SupplierID=@SupplierID  and IsDeleted=0 FETCH NEXT FROM TABLEName INTO @SupplierID END CLOSE TABLEName DEALLOCATE TABLEName   ";
                        string str21 = "         DECLARE @Supplier_ID bigint DECLARE @SupplierContact_ID bigint DECLARE @Key_Code nvarchar(20) DECLARE @IsEmail_Sent bit DECLARE @EmailSent_By bigint DECLARE @IsQuote_Accepted bit DECLARE Est_Table CURSOR FOR SELECT distinct SupplierID,SupplierContactID,KeyCode,IsEmailSent,EmailSentBy,IsQuoteAccepted from tb_EstOutworkSupplier where EstOutworkID=@EstOutworkID and IsDeleted=1 OPEN Est_Table FETCH NEXT FROM Est_Table INTO @Supplier_ID,@SupplierContact_ID,@Key_Code,@IsEmail_Sent,@EmailSent_By,@IsQuote_Accepted WHILE @@FETCH_STATUS=0 BEGIN Update tb_EstOutworkSupplier set IsEmailSent=@IsEmail_Sent,IsQuoteAccepted=@IsQuote_Accepted,EmailSentBy=@EmailSent_By,KeyCode=@Key_Code where EstOutworkID=@EstOutworkID and IsDeleted=0 and SupplierID=@Supplier_ID and SupplierContactID=@SupplierContact_ID FETCH NEXT FROM Est_Table INTO @Supplier_ID,@SupplierContact_ID,@Key_Code,@IsEmail_Sent,@EmailSent_By,@IsQuote_Accepted END CLOSE Est_Table DEALLOCATE Est_Table ";
                        str = new string[] { stringBuilder1.ToString(), stringBuilder.ToString(), stringBuilder3.ToString(), stringBuilder4.ToString(), str20, str21 };
                        string str22 = string.Concat(str);
                        string empty10 = string.Empty;
                        if (base.Request.Params["type"].ToString().ToLower() == "edit" || paraMeter.ToString().ToLower() == "printemail")
                        {
                            string str23 = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                            chrArray = new char[] { '»' };
                            string[] strArrays9 = str23.Split(chrArray);
                            int num8 = 0;
                            while (num8 < (int)strArrays9.Length)
                            {
                                if (!strArrays9[num8].Contains("Artwork="))
                                {
                                    num8++;
                                }
                                else
                                {
                                    string str24 = strArrays9[num8].Trim();
                                    chrArray = new char[] { '=' };
                                    string[] strArrays10 = str24.Split(chrArray);
                                    empty2 = strArrays10[1].ToString().Trim();
                                    if (strArrays10[1].ToString().Trim() == empty3.ToString().Trim())
                                    {
                                        break;
                                    }
                                    string str25 = strArrays10[1];
                                    chrArray = new char[] { '«' };
                                    string[] strArrays11 = str25.Split(chrArray);
                                    for (int p = 0; p < (int)strArrays11.Length; p++)
                                    {
                                        if (strArrays11[p] != "" && !empty3.ToLower().Contains(strArrays11[p].ToString().ToLower()))
                                        {
                                            empty10 = string.Concat(empty10, strArrays11[p].Trim(), "«");
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        EstimateBasePage.Estimate_Outwork_Insert(this.CompanyID, str22, str2, this.EstimateItemID);
                        if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                        {
                            this.Modul_Name = "job";
                            if (Convert.ToInt64(base.Request.Params["jID"]) == (long)0)
                            {
                                Convert.ToInt64(base.Request.Params["jID"]);
                            }
                            this.Module_ID = Convert.ToInt64(base.Request.Params["jID"]);
                        }
                        else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                        {
                            this.Modul_Name = "invoice";
                            if (Convert.ToInt64(base.Request.Params["InvID"]) == (long)0)
                            {
                                Convert.ToInt64(base.Request.Params["InvID"]);
                            }
                            this.Module_ID = Convert.ToInt64(base.Request.Params["InvID"]);
                        }
                        else if (!base.Request.Url.ToString().ToLower().Contains("orders"))
                        {
                            this.Modul_Name = "estimate";
                            if (Convert.ToInt64(base.Request.Params["EstID"]) == (long)0)
                            {
                                Convert.ToInt64(base.Request.Params["EstID"]);
                            }
                            this.Module_ID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
                        }
                        else
                        {
                            this.Modul_Name = "webstoreorder";
                            if (Convert.ToInt64(base.Request.Params["EstID"]) == (long)0)
                            {
                                Convert.ToInt64(base.Request.Params["EstID"]);
                            }
                            this.Module_ID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
                        }
                        EstimateBasePage.OutworkItemAttachmentUpdate(this.CompanyID, this.UserID, this.Module_ID, this.EstimateItemID, 'O', empty3, this.submodulename.ToLower(), empty10, this.hdn_ArtworkFileSave.Value.ToString());
                    }
                }
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            if (string.Compare(this.ReqType, "add", true) == 0 || this.Chk_CopytoCustomr.Checked)
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "O", false);
            }
            if (string.Compare(this.ReqType, "edit", true) == 0 && this.IsProductCreated == 1)
            {
                int num9 = 0;
                if (this.chkPoduct1.Checked)
                {
                    num9 = 1;
                }
                else if (this.chkPoduct2.Checked)
                {
                    num9 = 2;
                }
                DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "O");
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Rows[0]["PricecatalogueID"].ToString();
                    if (num9 == 1 || num9 == 2)
                    {
                        EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "O", num9);
                    }
                }
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                if (empty1 != "")
                {
                    string empty11 = string.Empty;
                    string str26 = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                    chrArray = new char[] { '»' };
                    string[] strArrays12 = str26.Split(chrArray);
                    int num10 = 0;
                    while (num10 < (int)strArrays12.Length)
                    {
                        if (!strArrays12[num10].Contains("Artwork="))
                        {
                            num10++;
                        }
                        else
                        {
                            string str27 = strArrays12[num10].Trim();
                            chrArray = new char[] { '=' };
                            string[] strArrays13 = str27.Split(chrArray);
                            string str28 = strArrays13[1].ToString().Trim();
                            chrArray = new char[] { '«' };
                            string[] strArrays14 = str28.Split(chrArray);
                            for (int q = 0; q < (int)strArrays14.Length; q++)
                            {
                                if (strArrays14[q].ToString() != "")
                                {
                                    if (empty11 == "")
                                    {
                                        str = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", strArrays14[q], "' target='_blank'>", Convert.ToString(strArrays14[q]), "</a>, " };
                                        empty11 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str = new string[] { empty11, "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", strArrays14[q], "' target='_blank'>", Convert.ToString(strArrays14[q]), "</a>, " };
                                        empty11 = string.Concat(str);
                                    }
                                }
                            }
                            break;
                        }
                    }
                    string empty12 = string.Empty;
                    DataTable dataTable1 = Notes.select_item_number_for_Activity_History(this.Module_ID, this.EstimateItemID, this.Modul_Name);
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        empty12 = dataRow1["rownumber"].ToString();
                    }
                    string empty13 = string.Empty;
                    DataTable dataTable2 = Notes.select_item_Title_for_Activity_History(this.CompanyID, this.Module_ID, this.EstimateItemID, "O");
                    foreach (DataRow row2 in dataTable2.Rows)
                    {
                        empty13 = row2["itemtitle"].ToString();
                    }
                    if (empty11.ToString().Length > 0)
                    {
                        this.objnotes.attachments = empty11.Remove(empty11.Length - 2);
                    }
                    this.objnotes.Item_title = empty13;
                    this.objnotes.ModuleName = this.Modul_Name;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.ArtworkAttchmentAdded);
                    this.objnotes.Item_number = string.Concat(" ", empty12);
                    this.objnotes.ModuleID = this.Module_ID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass2 = this.objJava;
                    now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = this.EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                }
            }
            else if ((base.Request.Params["type"].ToString().ToLower() == "edit" || paraMeter.ToString().ToLower() == "printemail") && empty1.ToString() != empty2.ToString())
            {
                string empty14 = string.Empty;
                string str29 = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                chrArray = new char[] { '»' };
                string[] strArrays15 = str29.Split(chrArray);
                int num11 = 0;
                while (num11 < (int)strArrays15.Length)
                {
                    if (!strArrays15[num11].Contains("Artwork="))
                    {
                        num11++;
                    }
                    else
                    {
                        string str30 = strArrays15[num11].Trim();
                        chrArray = new char[] { '=' };
                        string[] strArrays16 = str30.Split(chrArray);
                        string str31 = strArrays16[1].ToString().Trim();
                        chrArray = new char[] { '«' };
                        string[] strArrays17 = str31.Split(chrArray);
                        for (int r = 0; r < (int)strArrays17.Length; r++)
                        {
                            if (strArrays17[r].ToString() != "")
                            {
                                if (empty14 == "")
                                {
                                    str = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", strArrays17[r], "' target='_blank'>", Convert.ToString(strArrays17[r]), "</a>, " };
                                    empty14 = string.Concat(str);
                                }
                                else
                                {
                                    str = new string[] { empty14, "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", strArrays17[r], "' target='_blank'>", Convert.ToString(strArrays17[r]), "</a>, " };
                                    empty14 = string.Concat(str);
                                }
                            }
                        }
                        break;
                    }
                }
                string empty15 = string.Empty;
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(this.Module_ID, this.EstimateItemID, this.Modul_Name);
                foreach (DataRow dataRow2 in dataTable3.Rows)
                {
                    empty15 = dataRow2["rownumber"].ToString();
                }
                string empty16 = string.Empty;
                DataTable dataTable4 = Notes.select_item_Title_for_Activity_History(this.CompanyID, this.Module_ID, this.EstimateItemID, "O");
                foreach (DataRow row3 in dataTable4.Rows)
                {
                    empty16 = row3["itemtitle"].ToString();
                }
                if (empty14.ToString().Length > 0)
                {
                    this.objnotes.attachments = empty14.Remove(empty14.Length - 2);
                }
                this.objnotes.Item_title = empty16;
                this.objnotes.ModuleName = this.Modul_Name;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.ArtworkAttchmentUpdated);
                this.objnotes.Item_number = string.Concat(" ", empty15);
                this.objnotes.ModuleID = this.Module_ID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass3 = this.objJava;
                now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = this.EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (string.Compare(this.tabtype, "invoice", true) == 0 || string.Compare(this.tabtype, "job", true) == 0)
            {
                if (string.Compare(this.ReqType, "add", true) == 0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "O");
                    string empty17 = string.Empty;
                    foreach (DataRow dataRow3 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        empty17 = dataRow3["StatusID"].ToString();
                    }
                    if (string.Compare(item_printbroker_new.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                    {
                        this.objJava.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty17), "job", this.EstimateItemID, (long)0);
                    }
                }
                if (string.Compare(this.ReqType, "edit", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "O");
                }
            }
            if (item_printbroker_new.modulename == "jobs")
            {
                string empty18 = string.Empty;
                string empty19 = string.Empty;
                foreach (DataRow row4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    empty18 = row4["PhraseText"].ToString();
                }
                foreach (DataRow dataRow4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    empty19 = dataRow4["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty18, empty19);
            }
            HttpSessionState session = base.Session;
            str = new string[] { this.txtTitleDescription.Text, "~", this.txtOriginationDescription.Text, "~", this.txtArtworkDescription.Text, "~", this.txtColorDescription.Text, "~", this.txtSizeDescription.Text, "~", this.txtMaterialDescription.Text, "~", this.txtDeliveryDescription.Text, "~", this.txtFinishingDescription.Text, "~", this.txtProofsDescription.Text, "~", this.txtPackingDescription.Text, "~", this.txtNotesDescription.Text, "~", this.txtTermsDescription.Text };
            session["PrintBrokerDesc"] = string.Concat(str);
            EstimatesBasePage.estimate_itemtitle_update(this.EstimateID, this.objBase.ReplaceSingleQuote(this.txtjobtitle.Text));
            if (string.Compare(this.ReqType, "edit", true) == 0 && this.ParentEstimateItemID == (long)0)
            {
                EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "O");
            }
            if (string.Compare(paraMeter, "PrintEmail", true) == 0)
            {
                base.Session["TemplateHTML"] = null;
                base.Session["TemplateControlList"] = null;
                base.Session["TemplateID"] = null;
                string value = this.hid_Pub_ClientID.Value;
                if (string.Compare(this.ReqType, "add", true) == 0 || string.Compare(this.ReqType, "more", true) == 0)
                {
                    if (EstimatesBasePage.estimate_iscompleted_select(this.CompanyID, this.EstimateID) == 0)
                    {
                        EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                    }
                    if (string.Compare(this.tabtype, "invoice", true) == 0 || string.Compare(this.tabtype, "job", true) == 0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                        EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, this.EstType);
                    }
                }
                if (string.Compare(this.tabtype, "job", true) == 0)
                {
                    HttpResponse response = base.Response;
                    qtyNumber = new object[] { this.strSitepath, "jobs/templates_view1.aspx?sectionid=", value, "&sectionname=PrintBroker&type=supplier&page=PrintBroker&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, "&isdirect=1" };
                    response.Redirect(string.Concat(qtyNumber));
                    return;
                }
                if (string.Compare(this.tabtype, "invoice", true) == 0)
                {
                    HttpResponse httpResponse = base.Response;
                    qtyNumber = new object[] { this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", value, "&sectionname=PrintBroker&type=supplier&page=PrintBroker&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, "&isdirect=1" };
                    httpResponse.Redirect(string.Concat(qtyNumber));
                    return;
                }
                if (string.Compare(this.tabtype, "order", true) != 0)
                {
                    this.MainType = base.Session["MainType"].ToString();
                    HttpResponse response1 = base.Response;
                    qtyNumber = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", value, "&sectionname=PrintBroker&type=supplier&page=PrintBroker&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, "&isdirect=1" };
                    response1.Redirect(string.Concat(qtyNumber));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                qtyNumber = new object[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", value, "&sectionname=PrintBroker&type=supplier&page=PrintBroker&EstID=", this.EstimateID, "&ordid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, "&isdirect=1" };
                httpResponse1.Redirect(string.Concat(qtyNumber));
                return;
            }
            if (this.QueryType == "add" && this.ParentEstimateItemID == (long)0 && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "O") > (long)0)
            {
                HttpResponse response2 = base.Response;
                qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&parentesttype=O&maintype=edit&subitem=s", this.jID, this.InvID };
                response2.Redirect(string.Concat(qtyNumber));
            }
            string empty20 = string.Empty;
            if (item_printbroker_new.modulename == "invoice")
            {
                empty20 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, item_printbroker_new.modulename);
            }
            else if (item_printbroker_new.modulename == "jobs")
            {
                empty20 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, item_printbroker_new.modulename);
            }
            if (item_printbroker_new.modulename == "orders")
            {
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse httpResponse2 = base.Response;
                    qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(qtyNumber));
                    return;
                }
                HttpResponse response3 = base.Response;
                qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response3.Redirect(string.Concat(qtyNumber));
                return;
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (empty20.ToString().ToLower() == "yes")
                {
                    HttpResponse httpResponse3 = base.Response;
                    qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    httpResponse3.Redirect(string.Concat(qtyNumber));
                    return;
                }
                HttpResponse response4 = base.Response;
                qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                response4.Redirect(string.Concat(qtyNumber));
                return;
            }
            if (empty20.ToString().ToLower() == "yes")
            {
                HttpResponse httpResponse4 = base.Response;
                qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse4.Redirect(string.Concat(qtyNumber));
                return;
            }
            HttpResponse response5 = base.Response;
            qtyNumber = new object[] { this.strSitepath, item_printbroker_new.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            response5.Redirect(string.Concat(qtyNumber));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.RadTimePicker1.TimeView.Interval = new TimeSpan(0, 30, 0);
                this.RadTimePicker1.TimeView.TimeFormat = "h:mm:ss tt";
                this.RadTimePicker1.DateInput.DisplayDateFormat = "h:mm:ss tt";
                this.RadTimePicker1.DateInput.DateFormat = "h:mm:ss tt";
                this.RadTimePicker1.SelectedDate = new DateTime?(DateTime.Now);
            }
            this.ddlCostingType.Items[0].Text = this.objLanguage.GetLanguageConversion("Unit_Based_Costing");
            this.ddlCostingType.Items[1].Text = this.objLanguage.GetLanguageConversion("Simple_Costing");
            //this.ddlCostingType.Items[2].Text = this.objLanguage.GetLanguageConversion("Per_1000_Costing");
            this.Supplier = this.objLanguage.GetLanguageConversion("Supplier");
            this.Name = this.objLanguage.GetLanguageConversion("Name");
            this.Contact = this.objLanguage.GetLanguageConversion("Contact");
            if (!base.IsPostBack)
            {
                this.lblqty.Text = this.objLanguage.GetLanguageConversion("Quantity");
                this.RdlQtyType.Items[0].Text = this.objLanguage.GetLanguageConversion("Single_Qty");
                this.RdlQtyType.Items[1].Text = this.objLanguage.GetLanguageConversion("Multiple_Qty");
                this.lblcustomer.Text = this.objLanguage.GetLanguageConversion("Costing_Type");
                this.lblrfq.Text = this.objLanguage.GetLanguageConversion("RFQ_Return_Date");
                this.lbljob.Text = this.objLanguage.GetLanguageConversion("Job_Completion_Date");
                this.lblartwork.Text = this.objLanguage.GetLanguageConversion("ArtWork");
                this.Label3.Text = this.objLanguage.GetLanguageConversion("Name");
                this.Label5.Text = this.objLanguage.GetLanguageConversion("Contact");
                this.Button1.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Next");
                this.btn_Outwork_PrintEmail.Text = this.objLanguage.GetLanguageConversion("Print_Email");
                this.Button11.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.Button12.Text = this.objLanguage.GetLanguageConversion("Finish");
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.ProfitTaxKey != null)
            {
                item_printbroker_new.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
                this.UcPage = base.Session["pagename"].ToString();
            }
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                if (Convert.ToInt32(row["DefaultCostingType"]) == 2)
                {
                    this.ddlCostingType.SelectedIndex = 1;

                }
                else if (Convert.ToInt32(row["DefaultCostingType"]) == 3)
                {
                    this.ddlCostingType.SelectedIndex = 2;
                }
                else
                {
                    this.ddlCostingType.SelectedIndex = 1;
                }
            }
            if (base.Request.QueryString["EstID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.QueryString["esttype"] != null)
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
            }
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (this.IsProductDescAutofill.ToString().ToLower() == "true")
            {
                this.div_searchproduct.Attributes.CssStyle.Add("display", "block");
            }
            this.txtprodsearch.Attributes.Add("onkeyup", string.Concat("javascript:GetSupplierProductDetailsAutofill(this,'supplierproduct','", this.CompanyID, "','5',event);"));
            this.txtprodsearch.Attributes.Add("onclick", string.Concat("javascript:GetSupplierProductDetailsAutofill(this,'supplierproduct','", this.CompanyID, "','5',event);"));
            if (!(base.Request.Params["type"].ToString() == "edit") || !(base.Request.QueryString["esttype"] == "O"))
            {
                this.Div_Text.Visible = false;
                this.Chk_CopytoCustomr.Visible = false;
            }
            else
            {
                if (base.Request.Params["EstItemID"] != null && base.Request.Params["EstItemID"] != "")
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
                }
                if (!base.IsPostBack)
                {
                    this.Chk_CopytoCustomr.Visible = true;
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (row["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_CopytoCustomr.Checked = false;
                        }
                        else
                        {
                            this.Chk_CopytoCustomr.Checked = true;
                        }
                    }
                }
                foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                {
                    this.IsProductCreated = Convert.ToInt16(dataRow["IsProductCreated"].ToString());
                }
                if (this.IsProductCreated == 1)
                {
                    this.Div_Productcatalogue.Visible = true;
                }
                if (base.Request.Url.ToString().ToLower().Contains("estimates"))
                {
                    this.chklabel.Text = this.objLanguage.GetLanguageConversion("Customer_estimate_item_description_fields");
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                {
                    this.chklabel.Text = this.objLanguage.GetLanguageConversion("Customer_job_item_description_fields");
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice"))
                {
                    this.chklabel.Text = this.objLanguage.GetLanguageConversion("Customer_invoice_item_description_fields");
                }
                else if (base.Request.Url.ToString().ToLower().Contains("order"))
                {
                    this.chklabel.Text = this.objLanguage.GetLanguageConversion("Customer_order_item_description_fields");
                }
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job") || base.Request.Url.ToString().ToLower().Contains("invoice"))
                {
                    this.Chk_POItmDescn.Visible = true;
                    this.Chk_DNCopy.Visible = true;
                }
                else if ((int)JobBasePage.jobcard_existcheck(this.CompanyID, this.EstimateID) != 1)
                {
                    this.Chk_POItmDescn.Visible = false;
                    this.Chk_DNCopy.Visible = false;
                }
                else
                {
                    this.Chk_POItmDescn.Visible = true;
                    this.Chk_DNCopy.Visible = true;
                }
            }
            DataTable dataTable = EstimateBasePage.Invoice_ItemDescn_EstimateNum_Select(this.CompanyID, this.UserID, this.EstimateID);
            foreach (DataRow row1 in dataTable.Rows)
            {
                this.StrNum_Inv = row1["EstimateNumber"].ToString();
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice") && base.Request.QueryString["esttype"] == "O" && (this.StrNum_Inv == "Direct Invoice" || this.StrNum_Inv == "0"))
            {
                this.Chk_DNCopy.Visible = false;
                this.Chk_POItmDescn.Visible = false;
                if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_printbroker.aspx?type=edit"))
                {
                    this.Chk_DNCopy.Visible = false;
                    this.Chk_POItmDescn.Visible = false;
                }
            }
            base.Session["maintype"] = this.QueryType;
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                this.ISFromAddAnItem = base.Request.Params["FromAddAnItem"].ToString().ToLower();
            }
            this.RdlQtyType.Attributes.Add("onclick", "javascript:CheckQtyType('yes');");
            this.ddlCostingType.Attributes.Add("onclick", "javascript:CostSelected();");
            this.ddlCostingType.Attributes.Add("onchange", "javascript:DivPriceCompClear();");
            this.txtSingleQty.Attributes.Add("style", "text-align:right");
            this.txtMultiQty1.Attributes.Add("style", "text-align:right");
            this.txtMultiQty2.Attributes.Add("style", "text-align:right");
            this.txtMultiQty3.Attributes.Add("style", "text-align:right");
            this.txtMultiQty4.Attributes.Add("style", "text-align:right");
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains(" maintype=edit"))
            {
                this.IsPrintBrokerDirect = false;
                this.btn_Outwork_PrintEmail.Enabled = false;
                this.btn_Outwork_PrintEmail.Style.Add("display", "none");
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains(" maintype=edit"))
            {
                this.IsPrintBrokerDirect = false;
                this.btn_Outwork_PrintEmail.Enabled = false;
                this.btn_Outwork_PrintEmail.Style.Add("display", "none");
            }
            if (base.Request.Url.ToString().ToLower().Contains("http://occy.eprintsoftware.com"))
            {
                this.SysName = "occy";
            }
            try
            {
                if (base.Request.Params["parentesttype"] != null)
                {
                    this.ParentEstimateType = base.Request.Params["parentesttype"].ToString();
                }
                if (base.Request.QueryString["sectionid"] != null)
                {
                    this.EstimateBookletItemID = Convert.ToInt64(base.Request.QueryString["sectionid"]);
                }
                if (base.Request.Params["parentestitemid"] == null)
                {
                    this.IsPrintBrokerDirect = true;
                }
                else
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                    this.div_title.Style.Add("display", "none");
                    this.IsPrintBrokerDirect = false;
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            if (base.Request.Params["type"] == null)
            {
                this.ReqType = "add";
            }
            else
            {
                this.ReqType = base.Request.Params["type"].ToString();
            }
            if (!base.IsPostBack)
            {
                if (string.Compare(this.ReqType, "add", true) == 0 || string.Compare(this.ReqType, "more", true) == 0)
                {
                    DataSet dataSet = SettingsBasePage.settings_default_phrasebook_of_outwork_header_foooter(this.CompanyID, "");
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        this.spn_PrintBroker_Header.InnerHtml = this.objBase.SpecialDecode(dataRow1["PhraseText"].ToString());
                        this.spn_PrintBroker_Header.Attributes.Add("title", dataRow1["PhraseText"].ToString());
                    }
                    foreach (DataRow row2 in dataSet.Tables[1].Rows)
                    {
                        this.spn_PrintBroker_Footer.InnerHtml = this.objBase.SpecialDecode(row2["PhraseText"].ToString());
                        this.spn_PrintBroker_Footer.Attributes.Add("title", row2["PhraseText"].ToString());
                    }
                }
                if (base.Request.Params["SuppAdd"] != null && base.Request.Params["SuppId"] != null)
                {
                    this.SupplierID_Client = base.Request.Params["SuppId"].ToString();
                    this.Supplier_DdlID_Client = base.Request.Params["id"].ToString();
                }
                if (base.Request.Params["ContactAdd"] != null && base.Request.Params["SuppId"] != null)
                {
                    this.SupplierID_ContactID = base.Request.Params["SuppId"].ToString();
                    this.Supplier_DdlID_ContactID = base.Request.Params["id"].ToString();
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                item_printbroker_new.modulename = "jobs";
                this.submodulename = "job";
                this.tabtype = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                item_printbroker_new.modulename = "invoice";
                this.submodulename = "invoice";
                this.tabtype = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders"))
            {
                item_printbroker_new.modulename = "estimates";
                this.submodulename = "estimate";
                this.tabtype = "estimate";
            }
            else
            {
                item_printbroker_new.modulename = "orders";
                this.submodulename = "order";
                this.tabtype = "order";
            }
            if (!base.IsPostBack)
            {
                commonClass _commonClass = this.comm;
                DateTime dateTime1 = DateTime.Now.AddDays(1);
                string str = _commonClass.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                this.txtRFQReturnDate.Text = str;
                this.txtRFQReturnDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox = this.txtJobCompletionDate;
                commonClass _commonClass1 = this.comm;
                DateTime dateTime2 = DateTime.Now.AddDays((double)this.JobCompletionDateInc);
                textBox.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime2.ToString(), this.CompanyID, this.UserID, true);
                this.txtJobCompletionDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (base.Request.QueryString["type"] != null)
                {
                    if (base.Request.Params["type"].ToString() == "edit")
                    {
                        if (base.Request.QueryString["esttype"] != null)
                        {
                            if (base.Request.QueryString["esttype"] != "O")
                            {
                                this.IsMain = "no";
                                this.TakeItemDesc();
                            }
                            else
                            {
                                this.IsMain = "yes";
                                this.Select_OutWork_Item();
                            }
                        }
                    }
                    else if (base.Request.Params["type"].ToString() == "add" || base.Request.Params["type"].ToString() == "more")
                    {
                        this.TakeItemDesc();
                        this.SetDefault_ItemDescription();
                        this.LoadSortedDivs();
                        if (base.Request.QueryString["parentesttype"] != null)
                        {
                            this.CopyParentItemDescription(this.ParentEstimateItemID);
                        }
                    }
                }
                if (item_printbroker_new.modulename != "invoice")
                {
                    foreach (DataRow dataRow2 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        this.ClientId_PB = dataRow2["customerid"].ToString();
                        this.hid_Pub_ClientID.Value = this.ClientId_PB;
                        this.txtjobtitle.Text = this.objBase.SpecialDecode(dataRow2["EstimateTitle"].ToString());
                    }
                }
                else
                {
                    foreach (DataRow row3 in InvoiceBasePage.InvoiceDetails_ByInvoiceID_Select(this.InvoiceID).Rows)
                    {
                        this.ClientId_PB = row3["CustomerID"].ToString();
                        this.hid_Pub_ClientID.Value = this.ClientId_PB;
                        this.txtjobtitle.Text = this.objBase.SpecialDecode(row3["InvoiceTitle"].ToString());
                    }
                }
                this.txtMultiQty1.Focus();
                this.txtMultiQty1.Attributes.Add("onfocus", "select()");
            }
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = base.Request.QueryString["subedit"].ToString();
                }
                if (!base.IsPostBack)
                {
                    foreach (DataRow dataRow3 in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                    {
                        if (base.Request.Params["FromAddAnItem"] == null)
                        {
                            this.txtTitleDescription.Text = this.objBase.SpecialDecode(dataRow3["EstimateTitle"].ToString());
                        }
                        else
                        {
                            this.txtTitleDescription.Text = base.Session["AddAnItemtitem"].ToString();
                        }
                    }
                }
            }
            catch
            {
                this.subedit = "0";
            }
            foreach (DataRow row4 in SettingsBasePage.settings_markup_for_printbroker_select(this.CompanyID).Rows)
            {
                item_printbroker_new.printbroker_markup = Convert.ToDouble(row4["printbroker"].ToString());
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            this.GetDefaultMarkuptype();
            if (item_printbroker_new.modulename.ToLower() == "jobs" || item_printbroker_new.modulename.ToLower() == "invoice")
            {
                if (item_printbroker_new.modulename.ToLower() != "jobs")
                {
                    this.lbltitle.Text = this.objLanguage.GetLanguageConversion("Invoice_Title");
                }
                else
                {
                    this.lbltitle.Text = this.objLanguage.GetLanguageConversion("Job_Title");
                }
                if (base.Request.Params["parentestitemid"] == null)
                {
                    this.ParentEstimateItemID = (long)0;
                    foreach (DataRow dataRow4 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        this.QtyNumber = Convert.ToInt16(dataRow4["QtyNumber"].ToString());
                    }
                    if (this.QtyNumber == 0)
                    {
                        this.QtyNumber = 1;
                    }
                }
                else
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                    foreach (DataRow row5 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                    {
                        this.QtyNumber = Convert.ToInt16(row5["QtyNumber"].ToString());
                    }
                    if (this.QtyNumber == 0)
                    {
                        this.QtyNumber = 1;
                    }
                }
            }
            if (item_printbroker_new.modulename.ToLower() == "orders")
            {
                if (base.Request.Params["parentestitemid"] == null)
                {
                    this.ParentEstimateItemID = (long)0;
                }
                else
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                this.lbltitle.Text = this.objLanguage.GetLanguageConversion("Order_Title");
                this.QtyNumber = 1;
            }
            if (item_printbroker_new.modulename.ToLower() == "estimates")
            {
                this.lbltitle.Text = this.objLanguage.GetLanguageConversion("Estimate_Title");
            }
            this.txtTitleDescription.Attributes.Add("onfocus", "select()");
            this.txtOriginationDescription.Attributes.Add("onfocus", "select()");
            this.txtArtworkDescription.Attributes.Add("onfocus", "select()");
            this.txtColorDescription.Attributes.Add("onfocus", "select()");
            this.txtSizeDescription.Attributes.Add("onfocus", "select()");
            this.txtMaterialDescription.Attributes.Add("onfocus", "select()");
            this.txtDeliveryDescription.Attributes.Add("onfocus", "select()");
            this.txtFinishingDescription.Attributes.Add("onfocus", "select()");
            this.txtProofsDescription.Attributes.Add("onfocus", "select()");
            this.txtPackingDescription.Attributes.Add("onfocus", "select()");
            this.txtNotesDescription.Attributes.Add("onfocus", "select()");
            this.txtTermsDescription.Attributes.Add("onfocus", "select()");
            if (string.Compare(this.QueryType, "add", true) == 0 && this.ParentEstimateItemID > (long)0 && !base.IsPostBack)
            {
                DataTable quantityForItems = EstimatesBasePage.getQuantity_for_items(this.ParentEstimateItemID, this.ParentEstimateType, item_printbroker_new.modulename);
                foreach (DataRow dataRow5 in quantityForItems.Rows)
                {
                    this.txtMultiQty1.Text = dataRow5["Quantity1"].ToString();
                    this.txtMultiQty2.Text = dataRow5["Quantity2"].ToString();
                    this.txtMultiQty3.Text = dataRow5["Quantity3"].ToString();
                    this.txtMultiQty4.Text = dataRow5["Quantity4"].ToString();
                }
            }
            string str1 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
            if (str1 == "0" || str1 == "2")
            {
                this.btn_Outwork_PrintEmail.Attributes.Add("Style", "display:none");
            }
        }

        public void Phrase_Insert_Before_Check()
        {
            if (this.hid_outwork_phrase_data.Value != "")
            {
                string[] strArrays = this.hid_outwork_phrase_data.Value.Split(new char[] { '±' });
                base.Response.Write(this.hid_outwork_phrase_data.Value);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    string empty = string.Empty;
                    string str = string.Empty;
                    if ((int)strArrays1.Length > 0 && strArrays1[0] != null)
                    {
                        empty = strArrays1[0];
                    }
                    if ((int)strArrays1.Length > 1 && strArrays1[1] != null)
                    {
                        str = strArrays1[1];
                    }
                    this.PhraseBook_Insert(this.objBase.ReplaceSingleQuote(empty), this.objBase.ReplaceSingleQuote(str), false);
                }
            }
        }

        public void PhraseBook_Insert(string PhraseType, string PhraseData, bool IsDefaultPhrase)
        {
            SettingsBasePage.settings_phrasebook_insert(this.CompanyID, PhraseType, this.Objclss.ReplaceSingleQuote(PhraseData), IsDefaultPhrase, "", "");
        }

        private void Select_OutWork_Item()
        {
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            if (this.EstimateItemID != (long)0)
            {
                string str = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                int num = 0;
                while (true)
                {
                    char[] chrArray = new char[] { '»' };
                    if (num > (int)str.Split(chrArray).Length)
                    {
                        break;
                    }
                    char[] chrArray1 = new char[] { '»' };
                    if (str.Split(chrArray1)[num].Contains("RFQReturnTime"))
                    {
                        char[] chrArray2 = new char[] { '»' };
                        string str1 = str.Split(chrArray2)[num];
                        char[] chrArray3 = new char[] { '=' };
                        string str2 = str1.Split(chrArray3)[1];
                        char[] chrArray4 = new char[] { '¤' };
                        if (str2.Split(chrArray4)[0] != null)
                        {
                            char[] chrArray5 = new char[] { '»' };
                            string str3 = str.Split(chrArray5)[num];
                            char[] chrArray6 = new char[] { '=' };
                            string str4 = str3.Split(chrArray6)[1];
                            char[] chrArray7 = new char[] { '¤' };
                            if (str4.Split(chrArray7)[0] != "")
                            {
                                RadTimePicker radTimePicker1 = this.RadTimePicker1;
                                char[] chrArray8 = new char[] { '»' };
                                string str5 = str.Split(chrArray8)[num];
                                char[] chrArray9 = new char[] { '=' };
                                string str6 = str5.Split(chrArray9)[1];
                                char[] chrArray10 = new char[] { '¤' };
                                radTimePicker1.SelectedDate = new DateTime?(Convert.ToDateTime(str6.Split(chrArray10)[0]));
                                break;
                            }
                        }
                    }
                    num++;
                }
                this.hid_single_outworkData.Value = string.Concat(str, "µ");
                this.pnlMainOutwork.Visible = true;
            }
        }

        public void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        private void SetDefault_ItemDescription()
        {
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_forestimate_select(this.CompanyID, "PrintBroker").Rows)
            {
                string str = row["PhraseType"].ToString();
                string str1 = this.objBase.SpecialDecode(row["PhraseText"].ToString());
                if (string.Compare(str, "PrintBroker Title", true) == 0)
                {
                    try
                    {
                        if (base.Request.Params["FromAddAnItem"] == null)
                        {
                            this.txtTitleDescription.Text = str1;
                        }
                        else
                        {
                            this.txtTitleDescription.Text = base.Session["AddAnItemtitem"].ToString();
                        }
                    }
                    catch
                    {
                        this.txtTitleDescription.Text = str1;
                    }
                }
                if (string.Compare(str, "PrintBroker Description", true) == 0)
                {
                    this.txtOriginationDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Artwork", true) == 0)
                {
                    this.txtArtworkDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Colours", true) == 0)
                {
                    this.txtColorDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Size", true) == 0)
                {
                    this.txtSizeDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Material", true) == 0)
                {
                    this.txtMaterialDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Delivery", true) == 0)
                {
                    this.txtDeliveryDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Finishing", true) == 0)
                {
                    this.txtFinishingDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Proofs", true) == 0)
                {
                    this.txtProofsDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Packing", true) == 0)
                {
                    this.txtPackingDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Notes", true) == 0)
                {
                    this.txtNotesDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker Terms", true) == 0)
                {
                    this.txtTermsDescription.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription1", true) == 0)
                {
                    this.txt_SuplierValue1.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription2", true) == 0)
                {
                    this.txt_SuplierValue2.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription3", true) == 0)
                {
                    this.txt_SuplierValue3.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription4", true) == 0)
                {
                    this.txt_SuplierValue4.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription5", true) == 0)
                {
                    this.txt_SuplierValue5.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription6", true) == 0)
                {
                    this.txt_SuplierValue6.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription7", true) == 0)
                {
                    this.txt_SuplierValue7.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription8", true) == 0)
                {
                    this.txt_SuplierValue8.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription9", true) == 0)
                {
                    this.txt_SuplierValue9.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription10", true) == 0)
                {
                    this.txt_SuplierValue10.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription11", true) == 0)
                {
                    this.txt_SuplierValue11.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription12", true) == 0)
                {
                    this.txt_SuplierValue12.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription13", true) == 0)
                {
                    this.txt_SuplierValue13.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription14", true) == 0)
                {
                    this.txt_SuplierValue14.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription15", true) == 0)
                {
                    this.txt_SuplierValue15.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription16", true) == 0)
                {
                    this.txt_SuplierValue16.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription17", true) == 0)
                {
                    this.txt_SuplierValue17.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription18", true) == 0)
                {
                    this.txt_SuplierValue18.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription19", true) == 0)
                {
                    this.txt_SuplierValue19.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription20", true) == 0)
                {
                    this.txt_SuplierValue20.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription21", true) == 0)
                {
                    this.txt_SuplierValue21.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription22", true) == 0)
                {
                    this.txt_SuplierValue22.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription23", true) == 0)
                {
                    this.txt_SuplierValue23.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription24", true) == 0)
                {
                    this.txt_SuplierValue24.Text = str1;
                }
                if (string.Compare(str, "PrintBroker CustomDescription25", true) != 0)
                {
                    continue;
                }
                this.txt_SuplierValue25.Text = str1;
            }
            this.txtTitleDescription.Focus();
            this.txtTitleDescription.Attributes.Add("onfocus", "select()");
        }
        private void LoadSortedDivs()
        {
            DataTable dataTable = SettingsBasePage.settings_itemdescriptionNew_select(this.CompanyID, "O");
            Dictionary<string, string> fieldToDivMap = new Dictionary<string, string>
            {
                { "ItemTitle", "div_OutItemTitle" },
                { "Description", "div_OutDescription" },
                { "Artwork", "div_OutArtwork" },
                { "Colour", "div_OutColour" },
                { "Size", "div_OutSize" },
                { "Material", "div_OutMaterial" },
                { "Delivery", "div_OutDelivery" },
                { "Finishing", "div_OutFinishing" },
                { "Proofs", "div_OutProofs" },
                { "Packing", "div_OutPacking" },
                { "Notes", "div_OutNotes" },
                { "Instructions", "div_OutInstructions" },

                { "Custom Description 1", "div_SupplierDescrn1" },
                { "Custom Description 2", "div_SupplierDescrn2" },
                { "Custom Description 3", "div_SupplierDescrn3" },
                { "Custom Description 4", "div_SupplierDescrn4" },
                { "Custom Description 5", "div_SupplierDescrn5" },
                { "Custom Description 6", "div_SupplierDescrn6" },
                { "Custom Description 7", "div_SupplierDescrn7" },
                { "Custom Description 8", "div_SupplierDescrn8" },
                { "Custom Description 9", "div_SupplierDescrn9" },
                { "Custom Description 10", "div_SupplierDescrn10" },

                { "Custom Description 11", "div_SupplierDescrn11" },
                { "Custom Description 12", "div_SupplierDescrn12" },
                { "Custom Description 13", "div_SupplierDescrn13" },
                { "Custom Description 14", "div_SupplierDescrn14" },
                { "Custom Description 15", "div_SupplierDescrn15" },
                { "Custom Description 16", "div_SupplierDescrn16" },
                { "Custom Description 17", "div_SupplierDescrn17" },
                { "Custom Description 18", "div_SupplierDescrn18" },
                { "Custom Description 19", "div_SupplierDescrn19" },
                { "Custom Description 20", "div_SupplierDescrn20" },
                { "Custom Description 21", "div_SupplierDescrn21" },
                { "Custom Description 22", "div_SupplierDescrn22" },
                { "Custom Description 23", "div_SupplierDescrn23" },
                { "Custom Description 24", "div_SupplierDescrn24" },
                { "Custom Description 25", "div_SupplierDescrn25" },
            };
            Dictionary<string, int> divOrder = dataTable.AsEnumerable()
                .Where(row => row["DatabaseFieldName"] != DBNull.Value && row["DisplayOrder"] != DBNull.Value)
                .ToDictionary(row => row.Field<string>("DatabaseFieldName"), row => row.Field<int>("DisplayOrder"));

            List<Control> divControls = divOrder.Keys
                .Where(fieldToDivMap.ContainsKey) // Ensure the field has a mapped control ID
                .Select(fieldName => divContainer.FindControl(fieldToDivMap[fieldName])) // Map field name to actual div ID
                .Where(control => control != null) // Ignore null controls
                .ToList();

            var sortedDivs = divControls
                .OrderBy(control => divOrder.ContainsKey(control.ID) ? divOrder[control.ID] : int.MaxValue)
                .ToList();

            divContainer.Controls.Clear();
            foreach (var div in sortedDivs)
            {
                divContainer.Controls.Add(div);
            }
        }
        private void CopyParentItemDescription(long EstimateItemID)
        {
            commonClass _common = new commonClass();
            foreach (DataRow row in _common.Select_itemDescriptions(this.CompanyID, EstimateItemID).Rows)
            {
                this.txtTitleDescription.Text = HttpUtility.UrlDecode(row["ItemTitleValue"].ToString());
                this.txtOriginationDescription.Text = HttpUtility.UrlDecode(row["DescriptionValue"].ToString());
                this.txtArtworkDescription.Text = HttpUtility.UrlDecode(row["ArtworkValue"].ToString());
                this.txtColorDescription.Text = HttpUtility.UrlDecode(row["ColourValue"].ToString());
                this.txtSizeDescription.Text = HttpUtility.UrlDecode(row["SizeValue"].ToString());
                this.txtMaterialDescription.Text = HttpUtility.UrlDecode(row["MaterialValue"].ToString());
                this.txtDeliveryDescription.Text = HttpUtility.UrlDecode(row["DeliveryValue"].ToString());
                this.txtFinishingDescription.Text = HttpUtility.UrlDecode(row["FinishingValue"].ToString());
                this.txtProofsDescription.Text = HttpUtility.UrlDecode(row["ProofsValue"].ToString());
                this.txtPackingDescription.Text = HttpUtility.UrlDecode(row["PackingValue"].ToString());
                this.txtNotesDescription.Text = HttpUtility.UrlDecode(row["NotesValue"].ToString());
                this.txtTermsDescription.Text = HttpUtility.UrlDecode(row["InstructionsValue"].ToString());
                this.txt_SuplierValue1.Text = HttpUtility.UrlDecode(row["CustomDescriptionValue1"].ToString());
                this.txt_SuplierValue2.Text = HttpUtility.UrlDecode(row["CustomDescriptionValue2"].ToString());
                this.txt_SuplierValue3.Text = row["CustomDescriptionValue3"].ToString();
                this.txt_SuplierValue4.Text = row["CustomDescriptionValue4"].ToString();
                this.txt_SuplierValue5.Text = row["CustomDescriptionValue5"].ToString();
                this.txt_SuplierValue6.Text = row["CustomDescriptionValue6"].ToString();
                this.txt_SuplierValue7.Text = row["CustomDescriptionValue7"].ToString();
                this.txt_SuplierValue8.Text = row["CustomDescriptionValue8"].ToString();
                this.txt_SuplierValue9.Text = row["CustomDescriptionValue9"].ToString();
                this.txt_SuplierValue10.Text = row["CustomDescriptionValue10"].ToString();
                this.txt_SuplierValue11.Text = row["CustomDescriptionValue11"].ToString();
                this.txt_SuplierValue12.Text = row["CustomDescriptionValue12"].ToString();
                this.txt_SuplierValue13.Text = row["CustomDescriptionValue13"].ToString();
                this.txt_SuplierValue14.Text = row["CustomDescriptionValue14"].ToString();
                this.txt_SuplierValue15.Text = row["CustomDescriptionValue15"].ToString();
                this.txt_SuplierValue16.Text = row["CustomDescriptionValue16"].ToString();
                this.txt_SuplierValue17.Text = row["CustomDescriptionValue17"].ToString();
                this.txt_SuplierValue18.Text = row["CustomDescriptionValue18"].ToString();
                this.txt_SuplierValue19.Text = row["CustomDescriptionValue19"].ToString();
                this.txt_SuplierValue20.Text = row["CustomDescriptionValue20"].ToString();
                this.txt_SuplierValue21.Text = row["CustomDescriptionValue21"].ToString();
                this.txt_SuplierValue22.Text = row["CustomDescriptionValue22"].ToString();
                this.txt_SuplierValue23.Text = row["CustomDescriptionValue23"].ToString();
                this.txt_SuplierValue24.Text = row["CustomDescriptionValue24"].ToString();
                this.txt_SuplierValue25.Text = row["CustomDescriptionValue25"].ToString();
            }
        }

        private void TakeItemDesc()
        {
            string str = SettingsBasePage.settings_itemdescription_selectall(this.CompanyID);
            string[] strArrays = str.Split(new char[] { '\u00B6' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '±' });
                if (strArrays1[0].ToString() == "outwork")
                {
                    this.hdn_OutworkDesc.Value = strArrays1[1].ToString();
                }
            }
        }
    }
}