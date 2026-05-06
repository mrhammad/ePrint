using Printcenter.BusinessAccessLayer.Notes;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Printcenter.UI.Company;

namespace ePrint.Purchase
{
    public partial class purchase_add : BaseClass, IRequiresSessionState
    {
        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public static string str_Sitepath;

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public commonClass objComn = new commonClass();

        private PurchaseBasePage objPur = new PurchaseBasePage();

        private BaseClass objBC = new BaseClass();

        private BasePage objpage = new BasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string Type = string.Empty;

        public int CompanyID;

        public static int Company_ID;

        public int UserID;

        public static int User_ID;

        public long PurchaseID;

        public long PurchaseItemID;

        public int TaxID;

        public int AccountCodeID;

        public int AccountCodeID_CPO;

        public string Code = string.Empty;

        public string TaxName = string.Empty;

        public languageClass objLangClass = new languageClass();

        public decimal TaxRate;

        public string FinalTaxValues = string.Empty;

        public long POCODE;

        public string FinalSupDet = string.Empty;

        public long ItemID;

        public string ItemType = string.Empty;

        public string ItemCode = string.Empty;

        public string ItemDesc = string.Empty;

        public decimal ItemQty;

        public string ReceivedQty = string.Empty; ///modification by Bilal warehouse stage 3

        public decimal PackedIn;

        public decimal PackedPrice;

        public int Tax;

        public decimal TaxValue;

        public string Notess = string.Empty;

        public bool GoodsReceived;

        public string DateFormat = string.Empty;

        public string newdate = string.Empty;

        private string pagetype = string.Empty;

        public long EstimateID;

        private string JobNumber = string.Empty;

        public long PurEstimateID;

        public string pg = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int InventoryFinishedQuantity;

        public long ItemInventoryID;

        public Hashtable ht = new Hashtable();

        public Hashtable htNew = new Hashtable();

        public static bool frmStay;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public DateTime TodayDate;

        public string PaperMeasure = string.Empty;

        public long DeliveryAddressID;

        public int CourierID;

        public int CustomerID;

        public string DeliveryAddressType = string.Empty;

        public long TaskID;

        public long ordid;

        public long EstimateItemID;

        public string EstimateType = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string isOther = string.Empty;

        public string Goods_Received_Display = string.Empty;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public string ServerName = string.Empty;

        public long PurcahseStatusID;

        public string PerQuantity = "0";

        public string MainCost = "0";

        public string StockType = string.Empty;

        public string MainPackedPrice = "0";

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string PurhcasePrefix = ConnectionClass.PurhcasePrefix;

        public bool GoodsAdded;
        public bool IsCompleted;

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

        static purchase_add()
        {
            purchase_add.str_Sitepath = global.sitePath();
            purchase_add.User_ID = 0;
            purchase_add.frmStay = false;
            purchase_add.SalesPersonID = string.Empty;
            purchase_add.IsEditOnlyHisRecords = string.Empty;
        }

        public purchase_add()
        {
        }

        public void AdditionalSave(string PurchaseNotes)
        {
            if (this.hdnSave_Additional.Value != "")
            {
                string str = this.hdnSave_Additional.Value.Substring(0, this.hdnSave_Additional.Value.Length - 1);
                string[] strArrays = str.Split(new char[] { '¥' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '\u00A7' });
                    this.pricecataloguestock_additional_insert_popup(Convert.ToInt32(strArrays1[0].ToString()), strArrays1[1].ToString(), strArrays1[2].ToString(), Convert.ToInt32(strArrays1[3].ToString()), strArrays1[4].ToString(), strArrays1[5].ToString(), strArrays1[6].ToString(), strArrays1[7].ToString(), strArrays1[8].ToString(), strArrays1[9].ToString(), Convert.ToInt32(strArrays1[10].ToString()), Convert.ToDecimal(strArrays1[11].ToString()), strArrays1[12].ToString(), Convert.ToInt32(strArrays1[13].ToString()), PurchaseNotes);
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (this.pagetype != "job")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_view.aspx"));
                return;
            }
            string empty = string.Empty;
            if (this.jobID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            }
            if (empty.ToLower() != "yes")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
            httpResponse.Redirect(string.Concat(objArray));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = PurchaseBasePage.purchase_select(this.CompanyID, Convert.ToInt64(this.PurchaseID));
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.EstimateItemID = Convert.ToInt64(current["EstimateItemId"].ToString());
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            PurchaseBasePage.purchase_delete(this.CompanyID, Convert.ToInt64(this.PurchaseID));
            if (this.pagetype != "job")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_view.aspx?su=de"));
                return;
            }
            this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                string empty = string.Empty;
                DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.PurEstimateID, "", (long)0);
                foreach (DataRow row in dataTable1.Rows)
                {
                    empty = row["jobnumber"].ToString();
                }
                this.objnotes.Job_number = empty;
                this.objnotes.ModuleID = this.PurEstimateID;
                this.objnotes.Po_number = this.lblPONo.Text;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPODelete);
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.objComn;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            string str = string.Empty;
            if (this.jobID != (long)0)
            {
                str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            }
            long num = EstimatesBasePage.Module_IsConverted_To_NextModule(this.EstimateItemID, "Purchase");
            string str1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.EstimateID, "estimate");
            if (str.ToLower() == "yes")
            {
                if (num > (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                if (str1 != "yes")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", this.EstimateID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (num <= (long)0)
            {
                if (str1 != "yes")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", this.EstimateID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            if (this.jobID != (long)0)
            {
                if (str1 == "yes")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
                    httpResponse1.Redirect(string.Concat(objArray1));
                    return;
                }
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (str1 == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, "&jID=", num };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, "&jID=", num };
            response3.Redirect(string.Concat(estimateID3));
        }

        protected void btnSave_Onclick(object sender, EventArgs e)
        {
            if (this.pagetype == "job")
            {
                this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            }
            long num = Convert.ToInt64(this.hid_PurchaseID.Value);
            if (this.pagetype != "job")
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    this.Insert_Activity_History("edit", "", Convert.ToInt64(this.PurchaseID), (long)0);
                    base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_view.aspx?su=up"));
                    return;
                }
                if (this.hid_Mode.Value != "")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "purchase/templates_view.aspx?page=Purchase&EstID=", num));
                    return;
                }
                this.Insert_Activity_History("add", "", num, (long)0);
                base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_view.aspx?su=in"));
                return;
            }
            this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                this.Insert_Activity_History("edit", "job", num, this.PurEstimateID);
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                this.Insert_Activity_History("add", "job", num, this.PurEstimateID);
            }
            string empty = string.Empty;
            string str = string.Empty;
            string lower = string.Empty;
            foreach (DataRow row in JobBasePage.Jobs_Jobcard_Jobdetails_select(this.CompanyID, this.jobID).Rows)
            {
                empty = row["OrderNo"].ToString();
                str = row["JobNumber"].ToString();
                lower = row["IsFromWebStore"].ToString().ToLower();
            }
            if (lower != "yes")
            {
                if (str != "")
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", num, this.jID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (empty != "")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", num, "&ordid=", this.ordid, this.jID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        protected void btnSaveandStay_Onclick(object sender, EventArgs e)
        {
            purchase_add.frmStay = true;
            if (this.pagetype == "job")
            {
                this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            }
            long num = Convert.ToInt64(this.hid_PurchaseID.Value);
            if (this.pagetype != "job")
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    this.Insert_Activity_History("edit", "", Convert.ToInt64(this.PurchaseID), (long)0);
                    base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num));
                    return;
                }
                if (this.hid_Mode.Value != "")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "purchase/templates_view.aspx?page=Purchase&EstID=", num));
                    return;
                }
                this.Insert_Activity_History("add", "", num, (long)0);
                HttpResponse response = base.Response;
                object[] objArray = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, this.jID };
                response.Redirect(string.Concat(objArray));
                return;
            }
            this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                this.Insert_Activity_History("edit", "job", num, this.PurEstimateID);
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                this.Insert_Activity_History("add", "job", num, this.PurEstimateID);
            }
            if (this.ordid == (long)0)
            {
                HttpResponse httpResponse = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", num, this.jID };
                httpResponse.Redirect(string.Concat(estimateID));
                return;
            }
            HttpResponse response1 = base.Response;
            object[] estimateID1 = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", num, "&ordid=", this.ordid, this.jID };
            response1.Redirect(string.Concat(estimateID1));
        }

        public void DirectPOSelfSave(string PurchaseNotes, int index)
        {
            if (this.hdnSave_Self.Value != "")
            {
                string str = this.hdnSave_Self.Value.Substring(0, this.hdnSave_Self.Value.Length - 1);
                string[] strArrays = str.Split(new char[] { '¥' });
                if (0 < (int)strArrays.Length)
                {
                    string[] strArrays1 = strArrays[index].ToString().Split(new char[] { '\u00A7' });
                    this.pricecataloguestock_self_insert_popup(Convert.ToInt32(strArrays1[0].ToString()), Convert.ToInt32(strArrays1[1].ToString()), strArrays1[2].ToString(), strArrays1[3].ToString(), strArrays1[4].ToString(), strArrays1[5].ToString(), strArrays1[6].ToString(), strArrays1[7].ToString(), Convert.ToDecimal(strArrays1[8].ToString()), strArrays1[9].ToString(), PurchaseNotes);
                    return;
                }
            }
        }

        private void FollowUpTask(long PurchaseID)
        {
            if (this.chk_FollowupTask.Checked && !string.IsNullOrEmpty(this.hidFollowupTask.Value))
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                string[] strArrays = this.hidFollowupTask.Value.Split(new char[] { '±' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    if (string.Compare("assignedto", strArrays1[0], true) == 0)
                    {
                        empty = strArrays1[1];
                    }
                    else if (string.Compare("status", strArrays1[0], true) == 0)
                    {
                        str = base.SpecialEncode(strArrays1[1]);
                    }
                    else if (string.Compare("subject", strArrays1[0], true) == 0)
                    {
                        empty1 = base.SpecialEncode(strArrays1[1]);
                    }
                    else if (string.Compare("priority", strArrays1[0], true) == 0)
                    {
                        str1 = strArrays1[1];
                    }
                    else if (string.Compare("contactid", strArrays1[0], true) == 0)
                    {
                        empty2 = strArrays1[1];
                    }
                    else if (string.Compare("txtduedate", strArrays1[0], true) == 0)
                    {
                        str2 = strArrays1[1];
                    }
                    else if (string.Compare("ddlhour", strArrays1[0], true) == 0)
                    {
                        empty3 = strArrays1[1];
                    }
                    else if (string.Compare("ddlminute", strArrays1[0], true) == 0)
                    {
                        str3 = strArrays1[1];
                    }
                    else if (string.Compare("description", strArrays1[0], true) == 0)
                    {
                        empty4 = base.SpecialEncode(strArrays1[1]);
                    }
                }
                string str4 = string.Concat(empty3, ":", str3);
                int num = Convert.ToInt32(this.Session["userID"]);
                string str5 = DateTime.Now.ToString();
                int num1 = Convert.ToInt32(this.Session["userID"]);
                string str6 = DateTime.Now.ToString();
                string str7 = base.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, str2);
                taskClass _taskClass = new taskClass();
                if (base.Request.Params["type"] != null)
                {
                    if (base.Request.Params["type"].ToString().ToLower() != "edit")
                    {
                        _taskClass.task_Add("", this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "purchase", PurchaseID, empty4, 0, Convert.ToInt32(empty), num, 0, str5, str6, "", 0);
                    }
                    else
                    {
                        if (base.Request.Params["estid"] == null)
                        {
                            _taskClass.task_Edit(Convert.ToInt32(this.hdnTaskID.Value), this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "purchase", PurchaseID, empty4, 0, Convert.ToInt32(empty), num1, str6, "", 0);
                            return;
                        }
                        if (base.Request.Params["estid"] != null)
                        {
                            if (Convert.ToInt32(this.hdnTaskID.Value) == 0)
                            {
                                _taskClass.task_Add("", this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "purchase", PurchaseID, empty4, 0, Convert.ToInt32(empty), num, 0, str5, str6, "", 0);
                                return;
                            }
                            _taskClass.task_Edit(Convert.ToInt32(this.hdnTaskID.Value), this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "purchase", PurchaseID, empty4, 0, Convert.ToInt32(empty), num1, str6, "", 0);
                            return;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public static string GetContactAddress(string CompID, string ContactID)
        {
            string str = CompanyBasePage.company_contact_address_select(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
            return str;
        }

        [WebMethod]
        public static string GetSupplierName(string val)
        {
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = companyBasePage.company_autocomplete(Convert.ToInt32(str), "Supplier", baseClass.ReplaceSingleQuote(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["ClientID"].ToString();
                empty1 = row["ClientName"].ToString();
                empty2 = row["Contacts"].ToString();
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                str2 = row["AccountNumber"].ToString();
                str4 = row["DeliveryAddress"].ToString();
                empty6 = row["DeliveryAddressType"].ToString();
                str6 = row["DeliveryAddressID"].ToString();
                str5 = str4;
                string[] strArrays1 = new string[] { str6, "»", str4, "»", str5, "»1»", empty6 };
                empty3 = string.Concat(strArrays1);
                string[] strArrays2 = new string[] { empty, "$", empty1, "$", empty2, "$", str2, "$", empty3, "µ" };
                empty4 = string.Concat(empty4, string.Concat(strArrays2));
            }
            return empty4;
        }

        public void Insert_Activity_History(string Type, string Module, long PurchaseId, long EstID)
        {
            if (Type == "add")
            {
                if (Module != "job")
                {
                    this.objnotes.Po_number = this.lblPONo.Text;
                    this.objnotes.ModuleName = "purchase";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POCreated);
                    this.objnotes.ModuleID = PurchaseId;
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objComn;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    return;
                }
                this.objnotes.Po_number = this.lblPONo.Text;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOCreate);
                this.objnotes.ModuleID = EstID;
                this.objnotes.Po_Attachment = string.Concat(this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", PurchaseId);
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objComn;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                this.objnotes.Po_number = this.lblPONo.Text;
                this.objnotes.ModuleName = "purchase";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POCreated);
                this.objnotes.ModuleID = PurchaseId;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass2 = this.objComn;
                DateTime now1 = DateTime.Now;
                _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (Type == "edit")
            {
                if (Module == "job")
                {
                    string empty = string.Empty;
                    DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.PurEstimateID, "", (long)0);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty = row["jobnumber"].ToString();
                    }
                    this.objnotes.Job_number = empty;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.ModuleID = EstID;
                    this.objnotes.Po_number = this.lblPONo.Text;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOEdited);
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass3 = this.objnotes;
                    commonClass _commonClass3 = this.objComn;
                    DateTime dateTime1 = DateTime.Now;
                    _notesclass3.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    this.objnotes.ModuleName = "purchase";
                    this.objnotes.Po_number = this.lblPONo.Text;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POUpdate);
                    this.objnotes.ModuleID = Convert.ToInt64(this.PurchaseID);
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass4 = this.objnotes;
                    commonClass _commonClass4 = this.objComn;
                    DateTime now2 = DateTime.Now;
                    _notesclass4.Created_Date = _commonClass4.Eprint_return_DateTime_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    return;
                }
                this.objnotes.ModuleName = "purchase";
                this.objnotes.Po_number = this.lblPONo.Text;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POUpdate);
                this.objnotes.ModuleID = Convert.ToInt64(this.PurchaseID);
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                this.objnotes.Status_name = this.ddlStatus.SelectedItem.Text;
                notesclass _notesclass5 = this.objnotes;
                commonClass _commonClass5 = this.objComn;
                DateTime dateTime2 = DateTime.Now;
                _notesclass5.Created_Date = _commonClass5.Eprint_return_DateTime_Before_View(dateTime2.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
        }

        protected void lnkSave_Onclick(object sender, EventArgs e)
        {
            long num = Convert.ToInt64(this.hid_PurchaseID.Value);
            if (this.pagetype != "job")
            {
                HttpResponse response = base.Response;
                object[] value = new object[] { this.strSitepath, "purchase/templates_view1.aspx?sectionid=", this.hid_ClientID.Value, "&sectionname=Purchase&type=Supplier&page=Purchase&EstID=", num };
                response.Redirect(string.Concat(value));
                return;
            }
            this.PurEstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, "purchase/templates_view1.aspx?sectionid=", this.hid_ClientID.Value, "&sectionname=Purchase&type=Supplier&page=Purchase&frompg=job&EstID=", num, "&jobEstID=", this.PurEstimateID };
            httpResponse.Redirect(string.Concat(objArray));
        }

        protected void lnktaskAdd_OnClick(object sender, EventArgs e)
        {
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/Item/estimate_task_add.ascx");
            this.plhTask.Controls.Add(userControl);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] languageConversion;
            object value;
            object[] accountCodeID;
            if (this.Session["CompanyID"] == null || this.Session["UserID"] == null)
            {
                this.objBC.Session_Check();
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.DateFormat = this.objpage.GetRegionalSettings(this.CompanyID, "Dateformat");
            if (base.Request.Params["type"] != null)
            {
                this.Type = base.Request.Params["type"].ToString().ToLower();
                if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    this.PurchaseID = Convert.ToInt64(base.Request.Params["id"].ToString());
                }
                if (base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    this.PurchaseID = (long)0;
                }
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
                hdn_JobId.Value = Convert.ToString(this.jobID);
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
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
                if (this.ServerName.ToLower() == "dmc" || this.ServerName.ToLower() == "dmc2")
                {
                    this.spn_CourierInfo.Attributes.Add("style", "display:block");
                    this.spn_CourierInfo.Attributes.Add("style", "color:red");
                }
                else
                {
                    this.spn_CourierInfo.Attributes.Add("style", "display:none");
                }
            }
            long purchaseStatusID = ConnectionClass.PurchaseStatusID;
            this.PurcahseStatusID = ConnectionClass.PurchaseStatusID;
            this.Goods_Received_Display = this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "others", this.Page.Request.Url.ToString());
            if (this.Goods_Received_Display == "0" || this.Goods_Received_Display == "2")
            {
                this.TDLabel1.Visible = false;
            }
            else
            {
                this.TDLabel1.Visible = true;
            }
            this.Button1.Attributes.Add("onclick", string.Concat("javascript:AddMoreItem('0','0','Enter Title Description','0','0','0.00','','", this.Goods_Received_Display, "');return false;"));
            string empty = string.Empty;
            string strRemove = this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "isremove", this.Page.Request.Url.ToString());
            if (this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.Button2.Visible = true;
                this.btnDelete.Visible = true;
            }
            else
            {
                if(strRemove.Trim() == "1")
                {
                    this.Button2.Visible = true;
                    this.btnDelete.Visible = true;
                }
                else
                {
                    this.Button2.Visible = false;
                    this.btnDelete.Visible = false;
                }
            }
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            this.Session["TemplateTable"] = null;
            this.Session["isSplit"] = null;
            this.Session["TemplateID"] = null;
            this.txtSupplier.Focus();
            global.pageName = "Purchase";
            global.pgName = "";
            this.gloobj.setpagename("Purchase");
            this.pg = this.Session["PageName"].ToString();
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            purchase_add.User_ID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Add Purchase Order", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.txtSupplier.Attributes.Add("autocomplete", "off");
            this.POCODE = this.objComp.settings_lastcounter_select(this.CompanyID, "p") + (long)1;
            this.txtSupplier.Focus();
            if (base.Request.Params["ordid"] != null)
            {
                this.ordid = Convert.ToInt64(base.Request.Params["ordid"]);
            }
            if (!base.IsPostBack)
            {
                this.txtSupplier.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'supplier','", this.CompanyID, "','1',event);"));
                this.txtSupplier.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'supplier','", this.CompanyID, "','1',event);"));
                this.objset.Bind_Status_new(this.ddlStatus, this.CompanyID, string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---"), "purchase");
                if (base.Request.QueryString["type"] == "add")
                {
                    int defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "purchase", 0);
                    if (0 < this.ddlStatus.Items.Count)
                    {
                        this.ddlStatus.SelectedIndex = this.ddlStatus.Items.IndexOf(this.ddlStatus.Items.FindByValue(Convert.ToString(defaultStatusID)));
                    }
                }
                this.hdn_Previous_PurchaseID.Value = this.ddlStatus.SelectedValue;
                this.objComp.company_carrier_supplier_select(this.CompanyID, this.ddlCourierInfo);
                this.ddlCourierInfo.Items[0].Text = string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---");
            }
            if (!base.IsPostBack)
            {
                if (this.AccountingCode != "e")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = false;
                }
                if (this.AccountingCode != "e")
                {
                    this.tdACcode.Visible = false;
                }
                else
                {
                    this.tdACcode.Visible = true;
                }
            }
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(now.ToString());
            this.newdate = dateTime.ToShortDateString();
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            commonClass _commonClass = this.objComn;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.objComn;
            DateTime now1 = DateTime.Now;
            _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
            commonClass _commonClass2 = this.objComn;
            DateTime dateTime1 = DateTime.Now;
            this.TodayDate = _commonClass2.Eprint_return_ActualDate_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
            this.txtSupplier.Attributes.Add("autocomplete", "off");
            if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                this.delvisible.Visible = false;
            }
            if (base.Request.Params["pg"] != null)
            {
                this.pagetype = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                this.Session["EstimateID"] = this.EstimateID;
            }
            if (base.Request.Params["id"] != null)
            {
                this.JobNumber = JobBasePage.Job_Job_Number_Select(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
                this.Label42.Text = "Job Number";
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_user_select(this.CompanyID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    row["LimitName"] = base.SpecialDecode(row["LimitName"].ToString());
                }
                this.ddlRaisedBy.DataSource = dataTable;
                this.ddlRaisedBy.DataTextField = "LimitName";
                this.ddlRaisedBy.DataValueField = "UserID";
                this.ddlRaisedBy.DataBind();
                if (base.Request.Params["type"] != null)
                {
                    if (base.Request.Params["type"].ToString().ToLower() == "add")
                    {
                        this.btnDelete.Visible = false;
                        this.objBC.SetDDLValue(this.ddlRaisedBy, this.UserID.ToString());
                        long pOCODE = (long)10000000 + this.POCODE;
                        this.lblPONo.Text = string.Concat(this.PurhcasePrefix, pOCODE.ToString().Substring(1, pOCODE.ToString().Length - 1));
                        languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../purchase/purchase_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Purchase_View"), "</a>" };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_Add")));
                        foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Footer").Rows)
                        {
                            this.lblFooter.Text = dataRow["LimitPhraseText"].ToString().ToLower();
                            this.lblFooter.ToolTip = dataRow["PhraseText"].ToString().ToLower();
                            this.hid_FooterID.Value = dataRow["PhraseBookID"].ToString();
                            this.hid_FootNote.Value = dataRow["PhraseText"].ToString();
                        }
                        foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Header").Rows)
                        {
                            this.lblheader.Text = base.SpecialDecode(row1["LimitPhraseText"].ToString().ToLower());
                            this.lblheader.ToolTip = base.SpecialDecode(row1["PhraseText"].ToString().ToLower());
                            this.hid_HeaderID.Value = row1["PhraseBookID"].ToString();
                            this.hid_HeaderText.Value = row1["PhraseText"].ToString();
                        }
                        foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Instructions").Rows)
                        {
                            //this.txtComments.Text = base.SpecialDecode(dataRow1["LimitPhraseText"].ToString().ToLower());
                            this.txtComments.Text = dataRow1["PhraseText"].ToString();
                            this.txtComments.ToolTip = dataRow1["PhraseText"].ToString().ToLower();
                            this.hdn_CommenttID.Value = dataRow1["PhraseBookID"].ToString();
                            this.hdn_Commenttxt.Value = dataRow1["PhraseText"].ToString();
                        }
                        string str = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "directpo");
                        str = (str != "a" ? "R" : "A");
                        DataTable pODeliveryAddress = PurchaseBasePage.getPODeliveryAddress(this.CompanyID, this.PurchaseID, (long)0, str, this.EstimateID);
                        foreach (DataRow row2 in pODeliveryAddress.Rows)
                        {
                            if (base.Request.Url.ToString().ToLower().Contains("http://occy.eprintsoftware.com"))
                            {
                                continue;
                            }
                            this.lbl_deliveryAddress_Value.Text = row2["Address"].ToString();
                            this.lbl_deliveryAddress_Value.ToolTip = row2["Address"].ToString();
                            this.lbl_CompanyName.Style.Add("display", "block");
                            this.lbl_CompanyName.Text = row2["CompanyName"].ToString();
                            this.lbl_CompanyName.ToolTip = row2["CompanyName"].ToString();
                            this.hdn_CompanyID.Value = "0";
                        }
                    }
                    if (this.pagetype == "job")
                    {
                        this.txtRefNo.Text = this.JobNumber;
                    }
                }
                foreach (DataRow dataRow2 in SettingsBasePage.Setting_accountingCode_SelectAllPurchaseCode(this.CompanyID).Rows)
                {
                    this.AccountCodeID = Convert.ToInt32(dataRow2["AccountCodeID"].ToString());
                    this.Code = string.Concat(dataRow2["Code"].ToString(), " - ", dataRow2["Description"].ToString());
                    HiddenField hidACcode = this.hid_ACcode;
                    value = hidACcode.Value;
                    accountCodeID = new object[] { value, this.AccountCodeID, "¶", this.Code, "¶", dataRow2["IsDefaultPurchase"].ToString(), "µ" };
                    hidACcode.Value = string.Concat(accountCodeID);
                    if (dataRow2["IsDefaultPurchase"].ToString().ToLower().Trim() != "true")
                    {
                        continue;
                    }
                    this.AccountCodeID_CPO = Convert.ToInt32(dataRow2["AccountCodeID"]);
                }
                foreach (DataRow row3 in SettingsBasePage.settings_taxrate_select(this.CompanyID).Rows)
                {
                    this.TaxID = Convert.ToInt32(row3["TaxID"].ToString());
                    this.TaxName = row3["TaxName"].ToString();
                    this.TaxRate = Convert.ToDecimal(row3["TaxRate"].ToString());
                    accountCodeID = new object[] { this.TaxID, "¶", this.TaxName, "¶", this.TaxRate };
                    string.Concat(accountCodeID);
                    HiddenField hidTaxValues = this.hid_TaxValues;
                    value = hidTaxValues.Value;
                    accountCodeID = new object[] { value, this.TaxID, "¶", this.TaxName, "¶", this.TaxRate, "µ" };
                    hidTaxValues.Value = string.Concat(accountCodeID);
                }
                DataTable dataTable1 = SettingsBasePage.settings_system_markup_select(this.CompanyID);
                if (dataTable1.Rows.Count <= 0)
                {
                    this.hid_DefaultTax.Value = "0";
                }
                else
                {
                    foreach (DataRow dataRow3 in dataTable1.Rows)
                    {
                        this.hid_DefaultTax.Value = dataRow3["TaxID"].ToString();
                    }
                }
                this.txtDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox = this.txtDate;
                commonClass _commonClass3 = this.objComn;
                now = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.txtReqDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtSuppInvDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox1 = this.txtReqDate;
                commonClass _commonClass4 = this.objComn;
                now = DateTime.Now.AddDays(5);
                textBox1.Text = _commonClass4.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox2 = this.txtSuppInvDate;
                commonClass _commonClass5 = this.objComn;
                now = DateTime.Now;
                // ticket 90834
                //   textBox2.Text = _commonClass5.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                CompanyBasePage companyBasePage = new CompanyBasePage();
                if (base.Request.Params["type"] != null)
                {
                    string empty1 = string.Empty;
                    if (base.Request.Params["type"].ToString().ToLower() == "edit")
                    {
                        this.Session["PurchaseID"] = this.PurchaseID;
                        this.divPoNo.Visible = true;
                        languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../purchase/purchase_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Purchase_View"), "</a>" };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_Edit")));
                        string str1 = string.Empty;
                        if (this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                        {
                            this.btnDelete.Visible = true;
                        }
                        else
                        {
                            if(strRemove.Trim() == "1")
                            {
                                this.btnDelete.Visible = true;
                            }
                            else
                            {
                                this.btnDelete.Visible = false;
                            }
                        }
                        this.hid_PurchaseID.Value = Convert.ToString(this.PurchaseID);
                        DataTable dataTable2 = PurchaseBasePage.purchase_select(this.CompanyID, Convert.ToInt64(this.PurchaseID));
                        if (this.AccountingCode != "e")
                        {
                            this.div_AccountCode.Visible = false;
                        }
                        foreach (DataRow row4 in dataTable2.Rows)
                        {
                            this.txtSupplier.Text = base.SpecialDecode(row4["SupplierName"].ToString());
                            this.hid_ContactID.Value = row4["ContactID"].ToString();
                            this.lblAddress.Text = base.SpecialDecode(row4["Address"].ToString());
                            this.lblAddress.ToolTip = base.SpecialDecode(row4["Address"].ToString());
                            this.txtComments.Text = base.SpecialDecode(row4["Comments"].ToString());
                            this.lblFooter.Text = base.SpecialDecode(row4["FootNote"].ToString());
                            this.lblFooter.ToolTip = base.SpecialDecode(row4["FootNote"].ToString());
                            this.chkGoodsReceived.Checked = Convert.ToBoolean(row4["GoodsReceived"].ToString());
                            this.lblPONo.Text = base.SpecialDecode(row4["PONO"].ToString());
                            this.ddlRaisedBy.SelectedValue = row4["RaisedByID"].ToString();
                            this.txtDate.Text = this.objComn.Eprint_return_Date_Before_View(row4["PODate"].ToString(), this.CompanyID, this.UserID, false);
                            this.txtRefNo.Text = base.SpecialDecode(row4["ReferenceNo"].ToString());
                            this.txtSuppQuote.Text = base.SpecialDecode(row4["SupplierQuoteNo"].ToString());
                            this.txtSuppInv.Text = base.SpecialDecode(row4["SupplierInvoiceNo"].ToString());
                            this.txtReqDate.Text = this.objComn.Eprint_return_Date_Before_View(row4["ReqDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.chkInvoiceReceived.Checked = Convert.ToBoolean(row4["InvoiceReceived"].ToString());
                            this.PurEstimateID = Convert.ToInt64(row4["EstimateID"].ToString());
                            this.DeliveryAddressID = Convert.ToInt64(row4["DeliveryAddressID"].ToString());
                            this.DeliveryAddressType = row4["DeliveryAddressType"].ToString();
                            this.ddlCourierInfo.SelectedValue = row4["CourierID"].ToString();
                            this.hdn_supplierID.Value = row4["CourierID"].ToString();
                            this.hdn_deliveryAddressID.Value = row4["DeliveryAddressID"].ToString();
                            this.hdn_deliveryAddressType.Value = row4["DeliveryAddressType"].ToString();
                            this.EstimateItemID = Convert.ToInt64(row4["EstimateItemID"].ToString());
                            this.txtSuppInvDate.Text = this.objComn.Eprint_return_Date_Before_View(row4["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false);
                            purchase_add.SalesPersonID = row4["SalesPerson"].ToString();
                            this.ddlStatus.SelectedValue = row4["Status"].ToString();
                            this.hdn_Previous_PurchaseID.Value = this.ddlStatus.SelectedValue;
                            this.hid_ClientID.Value = row4["SupplierID"].ToString();
                            this.hid_Suppname.Value = row4["SupplierName"].ToString();
                            this.hdnAddressID.Value = row4["AddressID"].ToString();
                            this.hid_FootNote.Value = row4["FootNote"].ToString();
                            this.hid_AddressType.Value = row4["AddressType"].ToString();
                            this.hid_HeaderText.Value = base.SpecialDecode(row4["headernote"].ToString());
                            this.hdn_Commenttxt.Value = row4["Comments"].ToString();
                            this.lblheader.Text = base.SpecialDecode(row4["headernote"].ToString());
                            this.lblheader.ToolTip = base.SpecialDecode(row4["headernote"].ToString());
                            this.TaskID = Convert.ToInt64(row4["TaskID"]);
                            this.EstimateID = Convert.ToInt64(row4["EstimateID"]);
                            this.hdnTaskID.Value = this.TaskID.ToString();
                            if (this.TaskID <= (long)0)
                            {
                                continue;
                            }
                            this.chk_FollowupTask.Checked = true;
                        }
                        if (Convert.ToInt32(this.hdn_deliveryAddressID.Value) != 0 || this.EstimateID != (long)0)
                        {
                            DataTable pODeliveryAddress1 = PurchaseBasePage.getPODeliveryAddress(this.CompanyID, Convert.ToInt64(this.PurchaseID), (long)Convert.ToInt32(this.hdn_deliveryAddressID.Value), this.DeliveryAddressType, this.EstimateID);
                            foreach (DataRow dataRow4 in pODeliveryAddress1.Rows)
                            {
                                this.lbl_deliveryAddress_Value.Text = dataRow4["Address"].ToString();
                                this.lbl_deliveryAddress_Value.ToolTip = dataRow4["Address"].ToString();
                                this.lbl_CompanyName.Style.Add("display", "block");
                                this.lbl_CompanyName.Text = dataRow4["CompanyName"].ToString();
                                this.lbl_CompanyName.ToolTip = dataRow4["CompanyName"].ToString();
                                this.hdn_CompanyID.Value = dataRow4["ClientID"].ToString();
                            }
                        }
                        else
                        {
                            DataTable pODeliveryAddress2 = PurchaseBasePage.getPODeliveryAddress(this.CompanyID, this.PurchaseID, this.DeliveryAddressID, this.DeliveryAddressType, this.EstimateID);
                            foreach (DataRow row5 in pODeliveryAddress2.Rows)
                            {
                                this.lbl_deliveryAddress_Value.Text = row5["Address"].ToString();
                                this.lbl_deliveryAddress_Value.ToolTip = row5["Address"].ToString();
                                this.lbl_CompanyName.Style.Add("display", "block");
                                this.lbl_CompanyName.Text = row5["CompanyName"].ToString();
                                this.lbl_CompanyName.ToolTip = row5["CompanyName"].ToString();
                                this.hdn_CompanyID.Value = row5["ClientID"].ToString();
                            }
                        }
                        string str = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "DescriptionInclude");
                        str = (str != "a" ? "R" : "A");
                        DataTable dataTable3 = PurchaseBasePage.purchaseitem_select(this.CompanyID, Convert.ToInt64(this.PurchaseID));
                        foreach (DataRow dataRow5 in dataTable3.Rows)
                        {
                            this.PurchaseItemID = Convert.ToInt64(dataRow5["PurchaseItemID"].ToString());
                            this.ItemID = Convert.ToInt64(dataRow5["WarehouseItemID"].ToString());
                            this.ItemType = dataRow5["WarehouseItemType"].ToString();
                            this.ItemCode = base.SpecialDecode(dataRow5["ItemCode"].ToString());
                            if (str == "A")
                            {
                                this.ItemDesc = base.SpecialDecode(dataRow5["Description"].ToString().Replace("<br/>", " - "));
                                if (!this.ItemDesc.Contains(dataRow5["InvDescription"].ToString()))
                                {
                                    this.ItemDesc = string.Concat(this.ItemDesc, " - ", dataRow5["InvDescription"].ToString());
                                } 
                            }
                            else
                                this.ItemDesc = base.SpecialDecode(dataRow5["Description"].ToString().Replace("<br/>", " - "));

                            this.ItemQty = Convert.ToDecimal(this.objComn.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow5["Qty"].ToString()), 0, "", true, true, false));
                            this.objComn.ToRemoveDecimalPlacesIfZero(this.ItemQty.ToString());
                            this.PackedIn = Convert.ToDecimal(this.objComn.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow5["PackedIn"].ToString()), 0, "", false, false, false));
                            this.PackedPrice = Convert.ToDecimal(this.objComn.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow5["Price"].ToString()), 0, "", false, false, false));
                            this.Tax = Convert.ToInt32(dataRow5["TaxID"].ToString());
                            this.AccountCodeID = Convert.ToInt32(dataRow5["AccountCodeID"].ToString());
                            this.TaxValue = Convert.ToDecimal(this.objComn.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow5["TaxValue"].ToString()), 0, "", false, false, false));
                            this.Notess = base.SpecialDecode(dataRow5["Note"].ToString());
                            this.PerQuantity = dataRow5["PerQuantity"].ToString();
                            this.MainCost = dataRow5["MainCost"].ToString();
                            this.MainPackedPrice = dataRow5["MainPackedPrice"].ToString();
                            this.StockType = dataRow5["StockType"].ToString();
                            this.IsCompleted = Convert.ToBoolean(dataRow5["IsCompleted"]);
                            if (Convert.ToBoolean(dataRow5["IsCompleted"]))
                            {
                                this.GoodsReceived = true;
                            }
                            else
                            {
                                this.GoodsReceived = Convert.ToBoolean(dataRow5["IsGoodsReceived"]);
                            }
                            this.ReceivedQty = dataRow5["GoodsReceived"].ToString(); ///modification by Bilal Stage 3
                            PurchaseBasePage.PurchaseItem_Goodsreceived_Update(this.GoodsReceived, this.PurchaseItemID);
                            HiddenField hidPOValues = this.hid_PO_values;
                            value = hidPOValues.Value;
                            accountCodeID = new object[] { value, "PurchaseItemID»", this.PurchaseItemID, "±ItemID»", this.ItemID, "±" };
                            hidPOValues.Value = string.Concat(accountCodeID);
                            HiddenField hiddenField = this.hid_PO_values;
                            string value1 = hiddenField.Value;
                            languageConversion = new string[] { value1, "ItemType»", this.ItemType, "±ItemCode»", this.ItemCode, "±" };
                            hiddenField.Value = string.Concat(languageConversion);
                            HiddenField hidPOValues1 = this.hid_PO_values;
                            hidPOValues1.Value = string.Concat(hidPOValues1.Value, "ItemDesc»", this.ItemDesc, "±");
                            HiddenField hiddenField1 = this.hid_PO_values;
                            hiddenField1.Value = string.Concat(hiddenField1.Value, "±ItemQty»", this.objComn.ToRemoveDecimalPlacesIfZero(this.ItemQty.ToString()), "±");
                            HiddenField hidPOValues2 = this.hid_PO_values;
                            value = hidPOValues2.Value;
                            accountCodeID = new object[] { value, "PackedIn»", this.PackedIn, "±" };
                            hidPOValues2.Value = string.Concat(accountCodeID);
                            HiddenField hiddenField2 = this.hid_PO_values;
                            value = hiddenField2.Value;
                            accountCodeID = new object[] { value, "±PackedPrice»", this.PackedPrice, "±" };
                            hiddenField2.Value = string.Concat(accountCodeID);
                            HiddenField hidPOValues3 = this.hid_PO_values;
                            value = hidPOValues3.Value;
                            accountCodeID = new object[] { value, "Tax»", this.Tax, "±TaxValue»", this.TaxValue, "±" };
                            hidPOValues3.Value = string.Concat(accountCodeID);
                            HiddenField hiddenField3 = this.hid_PO_values;
                            value = hiddenField3.Value;
                            accountCodeID = new object[] { value, "AccountCodeID»", this.AccountCodeID, "±" };
                            hiddenField3.Value = string.Concat(accountCodeID);
                            HiddenField hidPOValues4 = this.hid_PO_values;
                            hidPOValues4.Value = string.Concat(hidPOValues4.Value, "PerQuantity»", this.PerQuantity, "±");
                            HiddenField hiddenField4 = this.hid_PO_values;
                            hiddenField4.Value = string.Concat(hiddenField4.Value, "MainCost»", this.MainCost, "±");
                            HiddenField hidPOValues5 = this.hid_PO_values;
                            hidPOValues5.Value = string.Concat(hidPOValues5.Value, "MainPackedPrice»", this.MainPackedPrice, "±");
                            HiddenField hiddenField5 = this.hid_PO_values;
                            hiddenField5.Value = string.Concat(hiddenField5.Value, "StockType»", this.StockType, "±");
                            HiddenField hidPOValues6 = this.hid_PO_values;
                            value = hidPOValues6.Value;
                            accountCodeID = new object[] { value, "Notes»", this.Notess, "±GoodsReceived»", this.GoodsReceived, "±ReceivedQty»", this.ReceivedQty, "±IsCompleted»", this.IsCompleted }; ///modification by Bilal Stage 3
                            hidPOValues6.Value = string.Concat(accountCodeID);
                            //if (this.ItemType.ToLower() == "w" && !this.GoodsReceived) Modification By Bilal
                            if (this.ItemType.ToLower() == "w")
                            {
                                foreach (DataRow row6 in PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(this.ItemID).Rows)
                                {
                                    HiddenField hiddenField6 = this.hid_PO_values;
                                    hiddenField6.Value = string.Concat(hiddenField6.Value, "±PriceCatalogueType»", row6["DrawStockFrom"].ToString());
                                    HiddenField hidPOValues7 = this.hid_PO_values;
                                    hidPOValues7.Value = string.Concat(hidPOValues7.Value, "±OnlyItemTitle»", row6["ItemTitle"].ToString());
                                }
                                HiddenField hiddenField7 = this.hid_PO_values;
                                hiddenField7.Value = string.Concat(hiddenField7.Value, "±AdditionalOptionDetails»", dataRow5["AdditionalOptionDetails"].ToString());
                            }
                            HiddenField hidPOValues8 = this.hid_PO_values;
                            hidPOValues8.Value = string.Concat(hidPOValues8.Value, "µ");
                            this.pnlLoadOnEdit.Visible = true;
                        }
                    }
                }
                if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "add" && base.Request.Params["CPOid"] != null && base.Request.Params["CPOid"] != "")
                {
                    long num = (long)0;
                    num = Convert.ToInt64(base.Request.Params["CPOid"].ToString());
                    languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../purchase/purchase_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Purchase_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_Add")));
                    string empty2 = string.Empty;
                    if (this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.btnDelete.Visible = true;
                    }
                    else
                    {
                        if(strRemove.Trim() == "1")
                        {
                            this.btnDelete.Visible = true;
                        }
                        else
                        {
                            this.btnDelete.Visible = false;
                        }
                    }
                    foreach (DataRow dataRow6 in PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num).Rows)
                    {
                        this.txtSupplier.Text = base.SpecialDecode(dataRow6["SupplierName"].ToString());
                        this.hid_ContactID.Value = dataRow6["ContactID"].ToString();
                        this.lblAddress.Text = base.SpecialDecode(dataRow6["Address"].ToString());
                        this.lblAddress.ToolTip = base.SpecialDecode(dataRow6["Address"].ToString());
                        this.hdnAddressID.Value = dataRow6["AddressID"].ToString();
                        this.hid_ClientID.Value = dataRow6["SupplierID"].ToString();
                        this.ItemCode = dataRow6["ItemCode"].ToString();
                        this.ItemDesc = dataRow6["ItemTitle"].ToString();
                        this.ItemQty = Convert.ToDecimal(this.objComn.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow6["ReorderQuantity"].ToString()), 0, "", true, true, false));
                        HiddenField hiddenField8 = this.hid_PO_values;
                        value = hiddenField8.Value;
                        accountCodeID = new object[] { value, "PurchaseItemID»", this.PurchaseItemID, "±ItemID»", num, "±" };
                        hiddenField8.Value = string.Concat(accountCodeID);
                        HiddenField hidPOValues9 = this.hid_PO_values;
                        hidPOValues9.Value = string.Concat(hidPOValues9.Value, "ItemType»W±ItemCode»", this.ItemCode, "±");
                        HiddenField hiddenField9 = this.hid_PO_values;
                        hiddenField9.Value = string.Concat(hiddenField9.Value, "ItemDesc»", this.ItemDesc, "±");
                        HiddenField hidPOValues10 = this.hid_PO_values;
                        hidPOValues10.Value = string.Concat(hidPOValues10.Value, "±ItemQty»", this.objComn.ToRemoveDecimalPlacesIfZero(this.ItemQty.ToString()), "±");
                        HiddenField hiddenField10 = this.hid_PO_values;
                        value = hiddenField10.Value;
                        accountCodeID = new object[] { value, "PackedIn»", this.PackedIn, "±" };
                        hiddenField10.Value = string.Concat(accountCodeID);
                        HiddenField hidPOValues11 = this.hid_PO_values;
                        value = hidPOValues11.Value;
                        accountCodeID = new object[] { value, "±PackedPrice»", this.PackedPrice, "±" };
                        hidPOValues11.Value = string.Concat(accountCodeID);
                        HiddenField hiddenField11 = this.hid_PO_values;
                        value = hiddenField11.Value;
                        accountCodeID = new object[] { value, "Tax»", this.Tax, "±TaxValue»", this.TaxValue, "±" };
                        hiddenField11.Value = string.Concat(accountCodeID);
                        HiddenField hidPOValues12 = this.hid_PO_values;
                        value = hidPOValues12.Value;
                        accountCodeID = new object[] { value, "AccountCodeID»", this.AccountCodeID_CPO, "±" };
                        hidPOValues12.Value = string.Concat(accountCodeID);
                        HiddenField hiddenField12 = this.hid_PO_values;
                        value = hiddenField12.Value;
                        accountCodeID = new object[] { value, "Notes»", this.Notess, "±GoodsReceived»", this.GoodsReceived, "±IsCompleted»", this.IsCompleted };
                        hiddenField12.Value = string.Concat(accountCodeID);
                        HiddenField hidPOValues13 = this.hid_PO_values;
                        hidPOValues13.Value = string.Concat(hidPOValues13.Value, "±PriceCatalogueType»", dataRow6["DrawStockFrom"].ToString());
                        HiddenField hiddenField13 = this.hid_PO_values;
                        hiddenField13.Value = string.Concat(hiddenField13.Value, "±OnlyItemTitle»", dataRow6["ItemTitle"].ToString());
                        HiddenField hidPOValues14 = this.hid_PO_values;
                        hidPOValues14.Value = string.Concat(hidPOValues14.Value, "±AdditionalOptionDetails»");
                        HiddenField hiddenField14 = this.hid_PO_values;
                        hiddenField14.Value = string.Concat(hiddenField14.Value, "µ");
                        this.pnlLoadOnEdit.Visible = true;
                    }
                    DataTable dataTable4 = companyBasePage.company_contacts_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), "");
                    this.ddlcontact.DataSource = dataTable4;
                    this.ddlcontact.DataTextField = "ContactName";
                    this.ddlcontact.DataValueField = "ContactID";
                    this.ddlcontact.DataBind();
                    this.ddlcontact.Items.Insert(0, new ListItem("---Select---", "0"));
                    for (int j = 0; j < this.ddlcontact.Items.Count; j++)
                    {
                        if (this.ddlcontact.Items[j].Value == this.hid_ContactID.Value.ToString())
                        {
                            this.ddlcontact.SelectedValue = this.hid_ContactID.Value.ToString();
                        }
                    }
                }
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() != "edit")
                {
                    this.ImgSupplierAdd.PostBackUrl = string.Concat(this.strSitepath, "client/client_add.aspx?type=Supplier&post=purchase&mode=", base.Request.Params["type"].ToString().ToLower());
                }
                else
                {
                    ImageButton imgSupplierAdd = this.ImgSupplierAdd;
                    languageConversion = new string[] { this.strSitepath, "client/client_add.aspx?type=Supplier&post=purchase&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", Convert.ToString(this.PurchaseID) };
                    imgSupplierAdd.PostBackUrl = string.Concat(languageConversion);
                }
            }
            if (base.Request.QueryString["suplrid"] != null)
            {
                HiddenField hidClientID = this.hid_ClientID;
                int num1 = Convert.ToInt32(base.Request.QueryString["suplrid"]);
                hidClientID.Value = num1.ToString();
                DataTable dataTable5 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), "supplier");
                foreach (DataRow row7 in dataTable5.Rows)
                {
                    this.txtSupplier.Text = base.SpecialDecode(row7["ClientName"].ToString());
                }
                if (base.Request.QueryString["contactid"] != null)
                {
                    HiddenField hidContactID = this.hid_ContactID;
                    num1 = Convert.ToInt32(base.Request.QueryString["contactid"]);
                    hidContactID.Value = num1.ToString();
                    DataTable dataTable6 = EstimatesBasePage.Clients_New_Contact_Select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value));
                    foreach (DataRow dataRow7 in dataTable6.Rows)
                    {
                        if (!string.IsNullOrEmpty(dataRow7["ContactList"].ToString()))
                        {
                            string str2 = dataRow7["ContactList"].ToString();
                            char[] chrArray = new char[] { '±' };
                            string[] strArrays = str2.Split(chrArray);
                            for (int k = 0; k < (int)strArrays.Length; k++)
                            {
                                string str3 = strArrays[k];
                                chrArray = new char[] { '»' };
                                string[] strArrays1 = str3.Split(chrArray);
                                ListItem listItem = new ListItem()
                                {
                                    Text = base.SpecialDecode(strArrays1[1]),
                                    Value = strArrays1[0]
                                };
                                this.ddlcontact.Items.Add(listItem);
                            }
                        }
                        this.lblAddress.Text = base.SpecialDecode(dataRow7["DefaultContactAddress"].ToString());
                        this.hdnAddressID.Value = dataRow7["ContactAddressID"].ToString();
                    }
                    this.ddlcontact.SelectedValue = this.hid_ContactID.Value;
                }
            }
            if (base.Request.QueryString["cntct"] != null)
            {
                if (base.Request.QueryString["cntct"].ToString().ToLower() == "new")
                {
                    this.ddlcontact.SelectedValue = "0";
                    this.lblAddress.Text = "";
                }
            }
            else if (base.Request.Params["type"] != null && base.Request.QueryString["type"].ToString().ToLower() == "edit" && !base.IsPostBack)
            {
                CompanyBasePage companyBasePage1 = new CompanyBasePage();
                DataTable dataTable7 = companyBasePage1.company_contacts_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), "");
                this.ddlcontact.DataSource = dataTable7;
                this.ddlcontact.DataTextField = "ContactName";
                this.ddlcontact.DataValueField = "ContactID";
                this.ddlcontact.DataBind();
                this.ddlcontact.Items.Insert(0, new ListItem("---Select---", "0"));
                for (int l = 0; l < this.ddlcontact.Items.Count; l++)
                {
                    if (this.ddlcontact.Items[l].Value == this.hid_ContactID.Value.ToString())
                    {
                        this.ddlcontact.SelectedValue = this.hid_ContactID.Value.ToString();
                    }
                }
            }
            this.Label26.Text = string.Concat(this.objLanguage.GetLanguageConversion("Tax_Value"), "(", this.objComn.GetCurrencyinRequiredFormate("", true), ")");
            this.TextBox20.Text = this.objComn.GetCurrencyinRequiredFormate("0.00", true) ?? "";
            this.ddlCourierInfo.Focus();
            this.Label28.Text = this.objLangClass.GetLanguageConversion("Supplier");
            this.ImgSupplierAdd.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Supplier");
            this.Label35.Text = this.objLangClass.GetLanguageConversion("Contact");
            this.imgbtnContact.ToolTip = this.objLangClass.GetLanguageConversion("Select_Contact");
            this.Label36.Text = this.objLangClass.GetLanguageConversion("Contact_Address");
            this.ingbtnAddress.ToolTip = this.objLangClass.GetLanguageConversion("Select_Supplier_Address");
            this.lbl_deliveryAddress.Text = this.objLangClass.GetLanguageConversion("Delivery_To");
            this.ImageButton2.ToolTip = this.objLangClass.GetLanguageConversion("Delivery_To");
            this.lblD_InstructionsTitle.Text = this.objLangClass.GetLanguageConversion("Comment_Delivery_Instructions");
            this.imgbtnDelivery_Instructions.ToolTip = this.objLangClass.GetLanguageConversion("Select_Delivery_Instructions");
            this.lblHeaderTitle.Text = this.objLangClass.GetLanguageConversion("Header");
            this.Label38.Text = this.objLangClass.GetLanguageConversion("Footer");
            this.imgbtnheader.ToolTip = this.objLangClass.GetLanguageConversion("Select_Header");
            this.ImageButton6.ToolTip = this.objLangClass.GetLanguageConversion("Select_Footnote");
            this.lblAccountCode.Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
            this.lblaccode.Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
            this.Label46.Text = this.objLangClass.GetLanguageConversion("Goods_Received");
            this.Label101.Text = this.objLangClass.GetLanguageConversion("Received_Qty");  ///modification by Bilal stage 3
            this.Label1.Text = this.objLangClass.GetLanguageConversion("Goods_Received");
            this.Label102.Text = this.objLangClass.GetLanguageConversion("Purchase_Order_Completed");
            this.Label39.Text = this.objLangClass.GetLanguageConversion("Purchase_Order_Number");
            this.Label44.Text = this.objLangClass.GetLanguageConversion("Raised_By");
            this.Label41.Text = this.objLangClass.GetLanguageConversion("Date");
            this.lbl_CourierInfo.Text = this.objLangClass.GetLanguageConversion("Carrier_Information");
            this.img_CourierInfo.ToolTip = this.objLangClass.GetLanguageConversion("Add_Carrier");
            this.Label42.Text = this.objLangClass.GetLanguageConversion("Ref_No");
            this.Label148.Text = this.objLangClass.GetLanguageConversion("Supp_Quote");
            this.Label43.Text = this.objLangClass.GetLanguageConversion("Supp_Inv");
            this.Label45.Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            this.Label47.Text = this.objLangClass.GetLanguageConversion("Invoice_Received");
            this.Label21.Text = this.objLangClass.GetLanguageConversion("Item_Code");
            this.Label29.Text = this.objLangClass.GetLanguageConversion("Description");
            this.Label30.Text = this.objLangClass.GetLanguageConversion("Quantity");
            this.Label25.Text = this.objLangClass.GetLanguageConversion("Packed_In");
            // this.Label22.Text = this.objLangClass.GetLanguageConversion("Price");
            this.Label22.Text = this.objLangClass.GetLanguageConversion("Total_Cost");
            this.Label23.Text = this.objLangClass.GetLanguageConversion("Tax");
            this.lblaccode.Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
            this.Label27.Text = this.objLangClass.GetLanguageConversion("Notes");
            this.txtItemCode123.Text = this.objLangClass.GetLanguageConversion("ITM00012");
            this.TextBox3.Text = this.objLangClass.GetLanguageConversion("Laser_Guarantee_100gsm_SRA2_100");
            this.Button1.Text = this.objLangClass.GetLanguageConversion("Add");
            this.Button2.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.Label31.Text = string.Concat(this.objLangClass.GetLanguageConversion("Total_ExclTax"), ":");
            this.Label33.Text = string.Concat(this.objLangClass.GetLanguageConversion("Total_inclTax"), ":");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.Button3.Text = this.objLangClass.GetLanguageConversion("Save_Stay");
            this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.lblSuppInvDate.Text = this.objLanguage.GetLanguageConversion("Supplier_Invoice_Date");
            if (this.Session["CustomAccessRight"] != null)
            {
                if (this.Session["CustomAccessRight"].ToString().Trim().ToLower() != "true")
                {
                    this.isOther = "1";
                }
                else
                {
                    this.isOther = this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "others", this.Page.Request.Url.ToString());
                }
            }
            string empty3 = string.Empty;
            purchase_add.IsEditOnlyHisRecords = this.objBC.ReturnRoles_Privileges_Others("editrecords");
            if (this.objBC.ReturnRoles_Privileges_ForGrid("purchases", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                if (purchase_add.IsEditOnlyHisRecords.ToLower() == "his" && this.Session["UserID"].ToString() != purchase_add.SalesPersonID)
                {
                    this.btnSave.Visible = false;
                    this.Button3.Visible = false;
                }
                return;
            }
            this.Button1.Visible = false;
            this.btnSave.Visible = false;
            this.Button3.Visible = false;
            this.DivAddSupplier.Visible = false;
            this.DivContact.Visible = false;
            this.DivContactAddress.Visible = false;
            this.DivDeliveryTo.Visible = false;
            this.DivCommentDeliveryInstructions.Visible = false;
            this.DivHeader.Visible = false;
            this.DivFooter.Visible = false;
            this.DivCarrierInformation.Visible = false;
        }

        public void pricecataloguestock_additional_insert_popup(int PricecatalogueID, string optionname, string optionvalue, int openingstock, string customfield1, string customfield2, string customfield3, string customfield4, string customfield5, string customfield6, int webothercostid, decimal price, string popupdate, int ChoiceID, string PurchaseNotes)
        {
            string str = WebstoreBasePage.pricecataloguestock_actiontype_checkAdditional((long)PricecatalogueID);
            string str1 = this.objComn.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.objComn.Eprint_return_Date_Before_View(popupdate, this.CompanyID, purchase_add.User_ID, true));
            DateTime dateTime = Convert.ToDateTime(str1);
            WebstoreBasePage.pricecataloguestock_additional_insert(PricecatalogueID, optionname, optionvalue, openingstock, customfield1, customfield2, customfield3, customfield4, customfield5, customfield6, webothercostid, purchase_add.User_ID, dateTime, price, str, ChoiceID, PurchaseNotes);
        }

        public void pricecataloguestock_self_insert_popup(int PricecatalogueID, int openingstock, string Customfield1, string Customfield2, string Customfield3, string Customfield4, string Customfield5, string Customfield6, decimal Price, string popupdate, string PurchaseNotes)
        {
            string str = WebstoreBasePage.pricecataloguestock_actiontype_check((long)PricecatalogueID, "self");
            string str1 = this.objComn.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.objComn.Eprint_return_Date_Before_View(popupdate, this.CompanyID, purchase_add.User_ID, true));
            DateTime dateTime = Convert.ToDateTime(str1);
            WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Price, purchase_add.User_ID, dateTime, str, PurchaseNotes, "");
        }

        public double ReturnExact2Decimal(double Amount)
        {
            Amount = Amount * 100;
            string[] strArrays = Amount.ToString().Split(new char[] { '.' });
            Amount = Convert.ToDouble(strArrays[0]) / 100;
            return Amount;
        }

        public long Save_Purchase()
        {
            char[] chrArray;
            bool flag = false;
            string empty = string.Empty;
            this.ht.Clear();
            long num = (long)0;
            long num1 = (long)0;
            if (this.DateFormat == "dd/mm/yyyy")
            {
                string text = this.txtDate.Text;
                chrArray = new char[] { '/' };
                string[] strArrays = text.Split(chrArray);
                TextBox textBox = this.txtDate;
                string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                textBox.Text = string.Concat(strArrays1);
                string[] strArrays2 = this.txtReqDate.Text.Split(new char[] { '/' });
                TextBox textBox1 = this.txtReqDate;
                string[] strArrays3 = new string[] { strArrays2[1], "/", strArrays2[0], "/", strArrays2[2] };
                textBox1.Text = string.Concat(strArrays3);
                if (this.txtSuppInvDate.Text.Trim().Length == 0)
                {
                    this.txtSuppInvDate.Text = "1/1/1900";
                }
                string[] strArrays4 = this.txtSuppInvDate.Text.Split(new char[] { '/' });
                TextBox textBox2 = this.txtSuppInvDate;
                string[] strArrays5 = new string[] { strArrays4[1], "/", strArrays4[0], "/", strArrays4[2] };
                textBox2.Text = string.Concat(strArrays5);
            }
            if (this.DateFormat == "mm/dd/yyyy")
            {
                string[] strArrays6 = this.txtDate.Text.Split(new char[] { ' ' });
                this.txtDate.Text = strArrays6[0];
                string[] strArrays7 = this.txtReqDate.Text.Split(new char[] { ' ' });
                this.txtReqDate.Text = strArrays7[0];
                if (this.txtSuppInvDate.Text.Trim().Length == 0)
                {
                    this.txtSuppInvDate.Text = "1/1/1900";
                }
                string str = this.txtSuppInvDate.Text;
                chrArray = new char[] { ' ' };
                string[] strArrays8 = str.Split(chrArray);
                this.txtSuppInvDate.Text = strArrays8[0];
            }
            this.CourierID = Convert.ToInt32(this.hdn_supplierID.Value);
            if (this.hdn_deliveryAddressType.Value == "" && this.hdn_deliveryAddressID.Value == "0")
            {
                this.DeliveryAddressID = (long)0;
                this.DeliveryAddressType = "R";
            }
            else if (this.hdn_deliveryAddressID.Value == "")
            {
                this.DeliveryAddressID = (long)0;
                this.DeliveryAddressType = "R";
            }
            else
            {
                this.DeliveryAddressID = Convert.ToInt64(this.hdn_deliveryAddressID.Value);
                this.DeliveryAddressType = this.hdn_deliveryAddressType.Value;
                if (this.DeliveryAddressType.ToLower() == "delivery")
                {
                    this.DeliveryAddressType = "c";
                }
            }
            if (this.txtSuppInvDate.Text.Trim() == "")
            {
                this.txtSuppInvDate.Text = "1/1/1900";
            }
            long num2 = Convert.ToInt64(this.hid_PurchaseID.Value);
            int companyID = this.CompanyID;
            int num3 = Convert.ToInt32(this.hid_ClientID.Value);
            int num4 = Convert.ToInt32(this.hid_ContactID.Value);
            long num5 = Convert.ToInt64(this.hdnAddressID.Value);
            string str1 = base.SpecialEncode(this.txtComments.Text);
            string str2 = base.SpecialEncode(this.hid_FootNote.Value);
            string str3 = base.SpecialEncode(this.lblPONo.Text);
            DateTime dateTime = Convert.ToDateTime(this.txtDate.Text);
            string str4 = base.SpecialEncode(this.txtRefNo.Text);
            string str5 = base.SpecialEncode(this.txtSuppQuote.Text);
            string str6 = base.SpecialEncode(this.txtSuppInv.Text);
            long num6 = Convert.ToInt64(this.ddlRaisedBy.SelectedValue);
            DateTime dateTime1 = Convert.ToDateTime(this.txtReqDate.Text);
            bool @checked = this.chkGoodsReceived.Checked;
            bool checked1 = this.chkInvoiceReceived.Checked;
            int num7 = Convert.ToInt32(this.ddlStatus.SelectedValue);
            int userID = this.UserID;
            int userID1 = this.UserID;
            commonClass _commonClass = this.objComn;
            DateTime now = DateTime.Now;
            num1 = PurchaseBasePage.purchase_insert(num2, companyID, num3, num4, num5, str1, str2, str3, dateTime, str4, str5, str6, num6, dateTime1, @checked, checked1, num7, userID, userID1, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.POCODE, this.hid_AddressType.Value, this.PurEstimateID, base.SpecialEncode(this.hid_HeaderText.Value), (long)0, this.TodayDate, this.DeliveryAddressID, this.DeliveryAddressType, this.CourierID, (long)0, Convert.ToDateTime(this.txtSuppInvDate.Text), "");
            this.FollowUpTask(num1);
            if (num1 > (long)0)
            {
                DataTable dataTable = PurchaseBasePage.purchase_select(this.CompanyID, num1);
                object[] strSitepath = new object[] { "Stock added through Purchase order  <a style='cursor:pointer;color:blue;' href='", purchase_add.str_Sitepath, "purchase/purchase_add.aspx?type=edit&id=", num1, "' target='_blank'>", dataTable.Rows[0]["PONO"].ToString(), "</a>" };
                empty = string.Concat(strSitepath);
                string value = this.hid_ItemValues.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays9 = value.Split(chrArray);
                DataTable dataTable1 = new DataTable();
                int num8 = 0;
                for (int i = 0; i < (int)strArrays9.Length - 1; i++)
                {
                    flag = false;
                    this.GoodsReceived = false;
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string str7 = strArrays9[i];
                    chrArray = new char[] { '±' };
                    string[] strArrays10 = str7.Split(chrArray);
                    for (int j = 0; j < (int)strArrays10.Length; j++)
                    {
                        string str8 = strArrays10[j];
                        chrArray = new char[] { '»' };
                        string[] strArrays11 = str8.Split(chrArray);
                        if (strArrays11[0] == "PurchaseItemID")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.PurchaseItemID = Convert.ToInt64(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.PurchaseItemID = (long)0;
                            }
                        }
                        if (strArrays11[0] == "ItemID")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.ItemID = Convert.ToInt64(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.ItemID = (long)0;
                            }
                        }
                        else if (strArrays11[0] == "ItemType")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.ItemType = strArrays11[1];
                            }
                            else
                            {
                                this.ItemType = "A";
                            }
                        }
                        else if (strArrays11[0] == "ItemCode")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.ItemCode = base.SpecialEncode(strArrays11[1]);
                            }
                        }
                        else if (strArrays11[0] == "ItemDesc")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.ItemDesc = base.SpecialEncode(strArrays11[1]);
                            }
                            else
                            {
                                this.ItemDesc = "Enter Title Description";
                            }
                        }
                        else if (strArrays11[0] == "ItemQty")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.ItemQty = Convert.ToDecimal(strArrays11[1]);
                            }
                            else
                            {
                                this.ItemQty = new decimal(0);
                            }
                        }
                        else if (strArrays11[0] == "PackedIn")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.PackedIn = Convert.ToDecimal(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.PackedIn = new decimal(0);
                            }
                        }
                        else if (strArrays11[0] == "PackedPrice")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.PackedPrice = Convert.ToDecimal(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.PackedPrice = new decimal(0);
                            }
                        }
                        else if (strArrays11[0] == "Tax")
                        {
                            this.Tax = Convert.ToInt32(strArrays11[1].ToString());
                        }
                        else if (strArrays11[0] == "TaxValue")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.TaxValue = Convert.ToDecimal(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.TaxValue = new decimal(0);
                            }
                        }
                        else if (strArrays11[0] == "AccountCodeID")
                        {
                            this.AccountCodeID = Convert.ToInt32(strArrays11[1]);
                        }
                        else if (strArrays11[0] == "Notes")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.Notess = base.SpecialEncode(strArrays11[1]);
                            }
                            else
                            {
                                this.Notess = "";
                            }
                        }
                        else if (strArrays11[0] == "GoodsReceived")
                        {
                            if (strArrays11[1] != "")
                            {
                                this.GoodsReceived = Convert.ToBoolean(strArrays11[1].ToString());
                            }
                            else
                            {
                                this.GoodsReceived = false;
                            }
                        }
                        else if (strArrays11[0] == "DrawStockFrom")
                        {
                            strArrays11[1].ToString();
                        }
                        else if (strArrays11[0] == "AdditionalOptionDetails")
                        {
                            empty2 = strArrays11[1].ToString();
                        }
                    }
                    if (this.PurchaseID != (long)0 && this.hid_DeletedItemID.Value != null)
                    {
                        string value1 = this.hid_DeletedItemID.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays12 = value1.Split(chrArray);
                        for (int k = 0; k < (int)strArrays12.Length - 1; k++)
                        {
                            PurchaseBasePage.purchaseitem_delete(this.CompanyID, Convert.ToInt64(strArrays12[k]), Convert.ToInt64(base.Request.Params["id"].ToString()));
                        }
                    }
                    num = PurchaseBasePage.purchaseitem_insert_new(this.CompanyID, this.PurchaseItemID, num1, this.ItemID, this.ItemType, this.ItemCode, this.ItemDesc, this.ItemQty, this.PackedIn, this.PackedPrice, this.Tax, this.TaxValue, this.AccountCodeID, this.Notess, this.GoodsReceived, this.EstimateItemID, this.ItemType, empty2, false);
                    string[] strArrays13 = new string[0];
                    if (this.GoodsReceived)
                    {
                        if (this.ItemType == "W")
                        {
                            flag = true;
                        }
                        if (this.ItemType != "W")
                        {
                            if (this.InventoryManagement == "IM")
                            {
                                if (num1 != (long)0)
                                {
                                    int companyID1 = this.CompanyID;
                                    string itemCode = this.ItemCode;
                                    int num9 = Convert.ToInt32(this.ItemQty);
                                    strSitepath = new object[] { "Stock Replenished through purchase: <a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num1, "' target='_blank' style='color:Blue' >", this.lblPONo.Text, "</a>" };
                                    InventoryBasePage.InventoryItem_Update(companyID1, itemCode, num9, string.Concat(strSitepath), this.UserID, num);
                                }
                                purchase_add.frmStay = false;
                            }
                            if (this.ItemID != (long)0)
                            {
                                string str9 = PurchaseBasePage.purchase_warehousestockqty_select(this.CompanyID, this.ItemID, this.ItemType);
                                chrArray = new char[] { 'µ' };
                                strArrays13 = str9.Split(chrArray);
                                Convert.ToDecimal(strArrays13[0].ToString());
                                this.ItemInventoryID = this.ItemID;
                            }
                            else if (this.ItemType == "I")
                            {
                                this.ItemType = "I";
                                int num10 = 0;
                                num10 = this.objInv.warehouse_inventory_insert(this.CompanyID, this.ItemCode, this.ItemCode, this.ItemCode, 0, this.ItemDesc, "", Convert.ToInt32(this.hid_ClientID.Value), this.ItemQty, new decimal(0), 0, 0, false);
                                if (num10 == -1)
                                {
                                    this.ItemInventoryID = (long)num10;
                                    long num11 = this.objInv.warehouse_code_select(this.CompanyID, "i") + (long)1;
                                    string.Concat("INV", num11.ToString().Substring(1, num11.ToString().Length - 1));
                                    this.ItemCode = string.Concat("INV", this.lblPONo.Text, i);
                                    num10 = this.objInv.warehouse_inventory_insert(this.CompanyID, this.ItemCode, this.ItemCode, this.ItemCode, 0, this.ItemDesc, "", Convert.ToInt32(this.hid_ClientID.Value), this.ItemQty, new decimal(0), 0, 0, false);
                                }
                                if (num10 != -1)
                                {
                                    this.ItemInventoryID = (long)num10;
                                    double num12 = 0;
                                    if (this.ItemQty > new decimal(0))
                                    {
                                        num12 = this.ReturnExact2Decimal(Convert.ToDouble((this.PackedIn / this.ItemQty) * this.PackedPrice));
                                    }
                                    //Ticket 81174
                                    this.objInv.warehouse_inventoryproperties_insert(this.CompanyID, num10, this.PackedPrice, this.ItemQty, this.PackedIn, Convert.ToDecimal(num12), new decimal(0), new decimal(0), new decimal(0), 0, new decimal(0), new decimal(0), "", new decimal(0), "", new decimal(0), "", "", "", new decimal(0), 0, new decimal(0), "", "", "", new decimal(0), new decimal(0), new decimal(0), new decimal(0));
                                    PurchaseBasePage.purchase_warehouseitemid_update(this.CompanyID, num, Convert.ToInt64(num10), "I", this.ItemCode);
                                }
                            }
                        }
                        if (this.ItemType.ToLower() == "a")
                        {
                            long num13 = (long)0;
                            string empty3 = string.Empty;
                            dataTable1 = PurchaseBasePage.PurchaseItems_Details_Select(num);
                            if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["EstimateItemID"] != null)
                            {
                                num13 = Convert.ToInt64(dataTable1.Rows[0]["EstimateItemID"]);
                                empty3 = dataTable1.Rows[0]["EstimateType"].ToString();
                            }
                            if (empty3.ToLower() == "x")
                            {
                                string empty4 = string.Empty;
                                if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) == 1)
                                {
                                    foreach (DataRow row in EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, this.PurEstimateID).Rows)
                                    {
                                        long num14 = Convert.ToInt64(row["EstimateItemID"]);
                                        int num15 = Convert.ToInt32(row["QtyNumber"]);
                                        string str10 = row["JobNumber"].ToString();
                                        if (num14 != num13)
                                        {
                                            continue;
                                        }
                                        DataSet dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num14, num15, "x");
                                        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                        {
                                            long num16 = Convert.ToInt64(dataRow["PriceCatalogueID"]);
                                            long num17 = Convert.ToInt64(dataRow["OrderItemId"]);
                                            int num18 = Convert.ToInt32(dataRow["Quantity"]);
                                            bool flag1 = Convert.ToBoolean(dataRow["IsStockReplenish"]);
                                            bool flag2 = Convert.ToBoolean(dataRow["IsStockReplenished"]);
                                            if (!(flag1.ToString().ToLower() == "true") || !(flag2.ToString().ToLower() == "false"))
                                            {
                                                continue;
                                            }
                                            DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num16);
                                            DataTable dataTable3 = this.objBC.ProductStockType_Select((long)this.CompanyID, num16);
                                            if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                            {
                                                continue;
                                            }
                                            foreach (DataRow row1 in dataTable3.Rows)
                                            {
                                                if (row1["DrawStockFrom"].ToString().ToLower() == "s")
                                                {
                                                    this.objBC.callstockreplenish_process((long)this.UserID, (long)this.CompanyID, num16, num18, "self", num14, (long)0, num17, str10, this.EstimateID);
                                                }
                                                else if (row1["DrawStockFrom"].ToString().ToLower() == "o")
                                                {
                                                    this.objBC.callstockreplenish_process((long)this.UserID, (long)this.CompanyID, num16, num18, "other", num14, (long)0, num17, str10, this.EstimateID);
                                                }
                                                else if (row1["DrawStockFrom"].ToString().ToLower() == "a")
                                                {
                                                    this.objBC.callstockreplenish_process((long)this.UserID, (long)this.CompanyID, num16, num18, "additionaloption", num14, (long)0, num17, str10, this.EstimateID);
                                                }
                                                else if (row1["DrawStockFrom"].ToString().ToLower() == "m")
                                                {
                                                    this.objBC.callstockreplenish_process((long)this.UserID, (long)this.CompanyID, num16, num18, "othermultiple", num14, (long)0, num17, str10, this.EstimateID);
                                                }
                                                this.objBC.Replenished_updatepurchaseitem(num14);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    dataTable1 = PurchaseBasePage.PurchaseItems_Details_Select(num);
                    if (flag)
                    {
                        long num19 = (long)0;
                        long num20 = (long)0;
                        int num21 = 0;
                        bool flag3 = false;
                        bool flag4 = false;
                        foreach (DataRow dataRow1 in EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, this.PurEstimateID).Rows)
                        {
                            if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["EstimateItemID"] != null)
                            {
                                num20 = Convert.ToInt64(dataTable1.Rows[0]["EstimateItemID"]);
                            }
                            num19 = Convert.ToInt64(dataRow1["EstimateItemID"]);
                            num21 = Convert.ToInt32(dataRow1["QtyNumber"]);
                            if (num19 != num20)
                            {
                                continue;
                            }
                            DataSet dataSet1 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num19, num21, "x");
                            foreach (DataRow row2 in dataSet1.Tables[0].Rows)
                            {
                                flag3 = Convert.ToBoolean(row2["IsStockReplenish"]);
                                flag4 = Convert.ToBoolean(row2["IsStockReplenished"]);
                                if (!flag3 || flag4)
                                {
                                    continue;
                                }
                                this.SelfSave(empty, num);
                                this.AdditionalSave(empty);
                                this.objBC.Replenished_updatepurchaseitem(num19);
                            }
                        }
                        if (this.PurEstimateID == (long)0 && base.Request.QueryString["jID"] == null)
                        {
                            if (dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["IsGoodsAdded"] != null)
                            {
                                this.GoodsAdded = Convert.ToBoolean(dataTable1.Rows[0]["IsGoodsAdded"]);
                            }
                            if (!this.GoodsAdded)
                            {
                                this.DirectPOSelfSave(empty, num8);
                                this.objBC.GoodsAdded_updatepurchaseitem(num);
                                num8++;
                            }
                        }
                    }
                    if (base.Request.QueryString["jID"] == null && dataTable1.Rows.Count > 0 && dataTable1.Rows[0]["IsStockItem"] != null && !Convert.ToBoolean(dataTable1.Rows[0]["IsStockItem"]))
                    {
                        this.objBC.DirectPO_StockItem_Update(num);
                    }
                }
            }
            return num1;
        }

        public void SelfSave(string PurchaseNotes, long PurchaseItemID)
        {
            if (this.hdnSave_Self.Value != "")
            {
                string str = this.hdnSave_Self.Value.Substring(0, this.hdnSave_Self.Value.Length - 1);
                string[] strArrays = str.Split(new char[] { '¥' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '\u00A7' });
                    if (PurchaseItemID == Convert.ToInt64(strArrays1[10].ToString().Trim()))
                    {
                        this.pricecataloguestock_self_insert_popup(Convert.ToInt32(strArrays1[0].ToString()), Convert.ToInt32(strArrays1[1].ToString()), strArrays1[2].ToString(), strArrays1[3].ToString(), strArrays1[4].ToString(), strArrays1[5].ToString(), strArrays1[6].ToString(), strArrays1[7].ToString(), Convert.ToDecimal(strArrays1[8].ToString()), strArrays1[9].ToString(), PurchaseNotes);
                    }
                }
            }
        }
    }
}
