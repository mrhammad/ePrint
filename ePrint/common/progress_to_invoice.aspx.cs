using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class progress_to_invoice : System.Web.UI.Page, IRequiresSessionState
    {


        public string ServerName = ConnectionClass.ServerName;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        public languageClass objLangClass = new languageClass();

        public int CompanyID;

        public int UserID;

        private Notes objN = new Notes();

        public static long CustomerID;

        public bool IsItemSelected;

        private string EstimateItemIDs = string.Empty;

        public string IsJobFromEstore = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string ReduceStockType = string.Empty;

        private Hashtable htInventory = new Hashtable();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public bool IsBrainTreePayment;

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

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

        static progress_to_invoice()
        {
        }

        public progress_to_invoice()
        {
        }

        private void Adjust_Inventory_On_Job_Complete(DataSet ds, string StrJobNum, int StatusID, long EstID, Hashtable htInventory, long EstimteItemID, string JobStatus)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, this.UserID, this.CompanyID, JobStatus, htInventory, EstimteItemID);
        }

        protected void btnContactNext_Click(object sender, EventArgs e)
        {
            this.DirectInvoiceCreate();
        }

        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            DateTime dateTime;
            if (this.hdnSelectedIDs.Value != "")
            {
                string str = this.hdnSelectedIDs.Value.Substring(0, this.hdnSelectedIDs.Value.Length - 1);
                string[] strArrays = str.Split(new char[] { ',' });
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '\u005F' });
                    progress_to_invoice.CustomerID = Convert.ToInt64(strArrays1[3]);
                    empty = string.Concat(empty, strArrays1[0].ToString(), ",");
                    empty1 = string.Concat(empty1, strArrays1[1].ToString(), ",");
                    str1 = string.Concat(str1, strArrays1[2].ToString(), ",");
                    if (!empty2.Contains(strArrays1[0].ToString()))
                    {
                        empty2 = string.Concat(empty2, strArrays1[0].ToString(), ",");
                        str2 = string.Concat(str2, strArrays1[1].ToString(), ",");
                    }
                }
                empty = empty.Substring(0, empty.Length - 1);
                empty1 = empty1.Substring(0, empty1.Length - 1);
                str1 = str1.Substring(0, str1.Length - 1);
                string[] strArrays2 = empty.Split(new char[] { ',' });
                string[] strArrays3 = empty1.Split(new char[] { ',' });
                str1.Split(new char[] { ',' });
                string[] strArrays4 = empty2.Split(new char[] { ',' });
                string[] strArrays5 = str2.Split(new char[] { ',' });
                int num = Convert.ToInt32(strArrays3[0]);
                CompanyBasePage companyBasePage = new CompanyBasePage();
                commonClass _commonClass = new commonClass();
                notesclass _notesclass = new notesclass();
                long num1 = companyBasePage.settings_lastcounter_select(this.CompanyID, "i");
                long num2 = (long)10000000 + num1;
                string str3 = string.Concat(ConnectionClass.InvoicePrefix, num2.ToString().Substring(1, num2.ToString().Length - 1));
                int paymentDetailsFromEstimateID = InvoiceBasePage.Get_PaymentDetails_From_EstimateID((long)num);
                DateTime now = DateTime.Now;
                DateTime dateTime1 = now.AddDays((double)paymentDetailsFromEstimateID);
                int defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "invoice", 0);
                try
                {
                    commonClass _commonClass1 = this.commclass;
                    DateTime now1 = DateTime.Now;
                    dateTime = _commonClass1.Eprint_return_ActualDate_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                }
                catch
                {
                    dateTime = Convert.ToDateTime(DateTime.Now.ToString());
                }
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
                {
                    empty3 = row["PhraseText"].ToString();
                }
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
                {
                    empty4 = dataRow["PhraseText"].ToString();
                }
                int num3 = 0;
                char chr = 'C';
                //customer order number
                string CusOrdNo = string.Empty;
                //for (int n = 0; n < (int)strArrays3.Length; n++)
                //{
                //    foreach (DataRow row1 in InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, Convert.ToInt32(strArrays3[n])).Rows)
                //    {                       
                //        if (n == 0)
                //        {
                //            CusOrdNo = Convert.ToString(row1["CustomerOrderNumber"]);
                //        }
                //        if (n > 0)
                //        {
                //            CusOrdNo += ", " + Convert.ToString(row1["CustomerOrderNumber"]);
                //        }
                //    }
                //}
                List<string> orderNumbers = new List<string>();

                for (int n = 0; n < strArrays3.Length; n++)
                {
                    var rows = InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, Convert.ToInt32(strArrays3[n])).Rows;

                    foreach (DataRow row1 in rows)
                    {
                        string orderNumber = Convert.ToString(row1["CustomerOrderNumber"]);
                        if (!string.IsNullOrWhiteSpace(orderNumber))
                        {
                            orderNumbers.Add(orderNumber);
                        }
                    }
                }

                CusOrdNo = string.Join(", ", orderNumbers);
                foreach (DataRow row1 in InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, (long)num).Rows)
                {
                    num3 = Convert.ToInt32(row1["InvoiceAddressID"].ToString());
                    chr = Convert.ToChar(row1["InvoiceAddressType"].ToString());
                }
                bool flag = false;
                if (this.rdnProformaInvNo.Checked)
                {
                    flag = true;
                }
                long num4 = InvoiceBasePage.Invoice_insert_SplitItems(Convert.ToInt32(this.Session["CompanyID"]), str3, defaultStatusID, dateTime, dateTime, Convert.ToInt32(this.Session["UserID"].ToString()), 0, this.objBase.ReplaceSingleQuote(empty3), this.objBase.ReplaceSingleQuote(empty4), 0, ConnectionClass.IsHandy, num3, chr, num3, dateTime1, progress_to_invoice.CustomerID, Convert.ToInt64(this.ddlContactList.SelectedValue), Convert.ToInt64(this.ddlSalesPerson.SelectedValue), this.objBase.SpecialEncode(this.txtInvoiceTitle.Text), flag, CusOrdNo);
                for (int j = 0; j < (int)strArrays4.Length - 1; j++)
                {
                    string str4 = string.Empty;
                    string empty5 = string.Empty;
                    string str5 = string.Empty;
                    string empty6 = string.Empty;
                    if (empty2[j].ToString() != "0")
                    {
                        DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(strArrays5[j]), "", (long)0);
                        foreach (DataRow dataRow1 in dataTable.Rows)
                        {
                            empty5 = dataRow1["Estimatenumber"].ToString();
                            str5 = dataRow1["jobnumber"].ToString();
                            empty6 = dataRow1["invoicenumber"].ToString();
                        }
                        _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                        _notesclass.Estimate_number = empty5;
                        _notesclass.Job_number = str5;
                        _notesclass.Invoice_number = empty6;
                        _notesclass.ModuleName = "job";
                        _notesclass.ModuleID = Convert.ToInt64(strArrays4[j]);
                        _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        commonClass _commonClass2 = this.commclass;
                        now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        _notesclass.CompanyID = this.CompanyID;
                        _notesclass.UserID = this.UserID;
                        this.objN.NotesAdd(_notesclass);
                    }
                }
                for (int k = 0; k < (int)strArrays2.Length; k++)
                {
                    InvoiceBasePage.InvoiceID_Update_in_Items(num4, Convert.ToInt64(strArrays2[k]));
                    if (flag)
                    {
                        InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, dateTime, Convert.ToInt64(strArrays2[k]));
                    }
                    string str6 = string.Empty;
                    string empty7 = string.Empty;
                    DataTable dataTable1 = JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, Convert.ToInt64(strArrays2[k]));
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        empty7 = row2["InvoiceItemNumber"].ToString();
                        str6 = row2["JobItemNumber"].ToString();
                    }
                    _notesclass.Job_number = str6;
                    _notesclass.Invoice_number = empty7;
                    _notesclass.ItemID = Convert.ToInt64(strArrays2[k]);
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobItemProgInv);
                    _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    commonClass _commonClass3 = this.commclass;
                    now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    _notesclass.CompanyID = this.CompanyID;
                    _notesclass.UserID = this.UserID;
                    this.objN.NotesAdd(_notesclass);
                }
                if (this.InventoryManagement == "IM" && this.ReduceStockType.ToLower() != "e")
                {
                    this.Call_Inventory_Adjustment("completed-i", (long)0, num4);
                }
                if ((new BaseClass()).Return_StockManagementSettings("SR_WhenStockReduced") == "c")
                {
                    this.Call_Inventory_Adjustment("completed-i", (long)0, num4);
                }
                this.IsJobFromEstore = InvoiceBasePage.Is_INVOICE_from_Webstore(num4);
                Session.Remove("IDs");
                Session.Remove("IsItemSelected");
                if (this.hdnNextType.Value == "payment")
                {
                    HttpResponse response = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/Invoice_Paid_View.aspx?SelectedIDs=", str, "&InvID=", num4, "&ItemIDs=", empty, "&EstimateIDs=", empty1, "&JobIDs=", str1 };
                    response.Redirect(string.Concat(objArray));
                    return;
                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:TakeOut(", num4, ");"), true);
            }
        }

        private string Call_Inventory_Adjustment(string JobStatus, long EstimateID, long InvoiceID)
        {
            object[] estimateID;
            string empty = string.Empty;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            dataTable = InvoiceBasePage.Job_Card_Info_Select_By_InvoiceID(InvoiceID);
            string str = string.Empty;
            string empty1 = string.Empty;
            int num = 0;
            string str1 = string.Empty;
            if (JobStatus == "completed-i")
            {
                JobStatus = "completed";
                str1 = "invoice";
            }
            if (JobStatus == "progressed-i")
            {
                JobStatus = "progressed";
                str1 = "invoice";
            }
            if (JobStatus == "reverted-i")
            {
                str1 = "invoice";
            }
            int num1 = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null)
                {
                    continue;
                }
                long num2 = Convert.ToInt64(row["EstimateItemID"]);
                int num3 = Convert.ToInt32(row["QtyNumber"]);
                string str2 = row["ItemType"].ToString();
                long num4 = (long)0;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                int num5 = 0;
                int num6 = 0;
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal printSheetCalulation = new decimal(0);
                decimal num10 = new decimal(0);
                string str3 = string.Empty;
                str = row["JobNumber"].ToString();
                num = Convert.ToInt32(row["StatusID"].ToString());
                if (row["InvoiceNumber"] != null)
                {
                    empty1 = row["InvoiceNumber"].ToString();
                }
                if (string.Compare(str2, "S", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow["PaperID"]);
                        empty2 = "I";
                        dataRow["InventoryCode"].ToString();
                        dataRow["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow["Quantity"]);
                        Convert.ToDecimal(dataRow["PackedIn"]);
                        Convert.ToInt64(dataRow["EstimateSingleItemID"]);
                        Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "P", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row1["PaperID"]);
                        empty2 = "I";
                        row1["InventoryCode"].ToString();
                        row1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row1["Quantity"]);
                        Convert.ToDecimal(row1["PackedIn"]);
                        Convert.ToInt64(row1["EstimatePadItemID"]);
                        Convert.ToDecimal(row1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row1["RunningSpoilage"]);
                        Convert.ToDecimal(row1["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row1["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "L", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow1["PaperID"]);
                        empty2 = "I";
                        dataRow1["InventoryCode"].ToString();
                        dataRow1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow1["Quantity"]);
                        Convert.ToDecimal(dataRow1["PackedIn"]);
                        Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                        Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow1["PaperMarkup"]);
                        Convert.ToDecimal(dataRow1["JobHeight"]);
                        Convert.ToDecimal(dataRow1["JobWidth"]);
                        Convert.ToDecimal(dataRow1["SheetHeight"]);
                        Convert.ToDecimal(dataRow1["SheetWidth"]);
                        Convert.ToDecimal(dataRow1["GutterHorizontal"]);
                        Convert.ToDecimal(dataRow1["GutterVertical"]);
                        Convert.ToDecimal(dataRow1["Row"]);
                        Convert.ToDecimal(dataRow1["Col"]);
                        dataRow1["PrintLayout"].ToString();
                        dataRow1["PressPaperType"].ToString();
                        num10 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, num10);
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, num10, JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "B", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables = new Hashtable();
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row2["PaperID"]);
                        empty2 = "I";
                        row2["InventoryCode"].ToString();
                        row2["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row2["Quantity"]);
                        Convert.ToDecimal(row2["PackedIn"]);
                        Convert.ToInt64(row2["EstimateBookletItemID"]);
                        Convert.ToDecimal(row2["PaperUnitPrice"]);
                        Convert.ToDecimal(row2["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row2["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row2["RunningSpoilage"]);
                        Convert.ToDecimal(row2["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row2["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        if (!hashtables.ContainsKey(num4))
                        {
                            hashtables.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables[num4] = Convert.ToInt32(hashtables[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key in hashtables.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key), empty2, Convert.ToInt32(hashtables[key]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "W", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables1 = new Hashtable();
                    foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                        empty2 = dataRow2["WarehouseType"].ToString();
                        num5 = Convert.ToInt32(dataRow2["Quantity"]);
                        if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                        {
                            continue;
                        }
                        if (!hashtables1.ContainsKey(num4))
                        {
                            hashtables1.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables1[num4] = Convert.ToInt32(hashtables1[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        num1 = num1 + this.SummaryClassObj.Select_Quantity_History_For_Inventory(num2);
                    }
                    if (hashtables1.Count > 0)
                    {
                        foreach (long key1 in hashtables1.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty2, Convert.ToInt32(hashtables1[key1]), JobStatus, num2);
                        }
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "O", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "C", true) == 0)
                {
                    if (this.ServerName.ToLower().Contains("dmc"))
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num11 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row3["Quantity"]);
                        decimal num12 = Convert.ToDecimal(row3["Price"]);
                        BaseClass baseClass = new BaseClass();
                        if (baseClass.Return_StockManagementSettings("SR_WhenStockReduced") != "c")
                        {
                            continue;
                        }
                        foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)this.CompanyID, num11).Rows)
                        {
                            this.Session["StockItemType"] = "C";
                            if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "self", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num11, "other", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else
                            {
                                empty = baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num11, "additional option", num5, num2, "Job", (long)this.UserID, num12);
                            }
                        }
                    }
                    if (commonClass.CheckFTPEnable())
                    {
                        long priceCatalogurID = 0;
                        string filePath = string.Empty;
                        if (dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "0" && dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "")
                        {
                            priceCatalogurID = Convert.ToInt64(dataSet.Tables[0].Rows[0]["PriceCatalogueID"]);
                        }
                        //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                        DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                        if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                        {
                            //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                            {
                                object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                filePath = string.Concat(editableTemplatePath);
                            }
                            else
                            {
                                string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                            }
                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceCreation", "ProductEstimate", num2);
                        }

                    }

                    this.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "X", true) == 0)
                {
                    if (this.ServerName.ToLower().Contains("dmc"))
                    {
                        continue;
                    }
                    bool flag = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row4 in dataSet.Tables[0].Rows)
                    {
                        long num13 = Convert.ToInt64(row4["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row4["Quantity"]);
                        decimal num14 = Convert.ToDecimal(row4["Price"]);
                        bool flag1 = Convert.ToBoolean(row4["IsStockReplenish"]);
                        bool flag2 = Convert.ToBoolean(row4["IsStockReplenished"]);
                        BaseClass baseClass1 = new BaseClass();
                        string str4 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        if (flag1.ToString().ToLower() == "true" && flag2.ToString().ToLower() != "true")
                        {
                            flag = false;
                        }
                        if (!(flag1.ToString().ToLower() != "true") || !(flag.ToString().ToLower() == "true") || !(str4 == "c"))
                        {
                            continue;
                        }
                        foreach (DataRow dataRow4 in baseClass1.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                        {
                            this.Session["StockItemType"] = "X";
                            this.Session["ALC_OrderItemId"] = row4["OrderItemId"].ToString();
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "self", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num13, "other", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else
                            {
                                empty = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num13, "additional option", num5, num2, "Job", (long)this.UserID, num14);
                            }
                        }
                    }

                    if (commonClass.CheckFTPEnable())
                    {
                        long priceCatalogurID = 0;
                        string filePath = string.Empty;
                        if (dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "0" && dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "")
                        {
                            priceCatalogurID = Convert.ToInt64(dataSet.Tables[0].Rows[0]["PriceCatalogueID"]);
                        }
                        //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                        DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                        if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                        {
                            //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                            {
                                DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(num2);
                                object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                //object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                filePath = string.Concat(secureDocEditablePath);
                            }
                            else
                            {
                                string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                            }
                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceCreation", "OnlineOrder", num2);
                        }

                    }

                }
                else if (string.Compare(str2, "F", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num2);
                    foreach (DataRow row5 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row5["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row5["Noofplates"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                    }
                    foreach (DataRow dataRow5 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow5["PaperID"]);
                        empty2 = "I";
                        dataRow5["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(dataRow5["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(dataRow5["Quantity"]);
                        Convert.ToDecimal(dataRow5["PackedIn"]);
                        Convert.ToInt64(dataRow5["EstLithoItemID"]);
                        Convert.ToDecimal(dataRow5["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow5["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow5["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow5["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow5["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow5["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "D", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num2);
                    foreach (DataRow row6 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row6["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row6["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (DataRow dataRow6 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow6["PaperID"]);
                        empty2 = "I";
                        dataRow6["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(dataRow6["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(dataRow6["Quantity"]);
                        Convert.ToDecimal(dataRow6["PackedIn"]);
                        Convert.ToInt64(dataRow6["EstimateLithoPadItemID"]);
                        Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow6["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow6["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow6["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "N", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num2);
                    Hashtable hashtables2 = new Hashtable();
                    foreach (DataRow row7 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row7["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row7["Noofplates"]);
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToInt32(hashtables2[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (long key2 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty2, Convert.ToInt32(hashtables2[key2]), JobStatus, num2);
                    }
                    hashtables2.Clear();
                    foreach (DataRow dataRow7 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow7["PaperID"]);
                        empty2 = "I";
                        dataRow7["InventoryCode"].ToString();
                        dataRow7["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow7["Quantity"]);
                        Convert.ToDecimal(dataRow7["PackedIn"]);
                        Convert.ToInt64(dataRow7["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(dataRow7["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow7["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow7["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow7["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow7["NcrPartsPerSet"].ToString());
                        Convert.ToDecimal(dataRow7["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(dataRow7["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow7["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToInt32(hashtables2[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key3 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty2, Convert.ToInt32(hashtables2[key3]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "K", true) != 0)
                {
                    if (string.Compare(str2, "Q", true) != 0)
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row8["PaperID"]);
                        empty2 = "I";
                        row8["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row8["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(row8["Quantity"]);
                        Convert.ToDecimal(row8["PackedIn"]);
                        Convert.ToInt64(row8["QuickQuoteID"]);
                        Convert.ToDecimal(row8["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row8["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row8["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row8["RunningSpoilage"]);
                        printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num5, num6, num7, num8, new decimal(0), "singleitem", new decimal(0), "", out num9);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(printSheetCalulation);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(printSheetCalulation), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num2);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow8 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow8["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow8["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToInt32(hashtables3[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (long key4 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key4), empty2, Convert.ToInt32(hashtables3[key4]), JobStatus, num2);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row9 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row9["PaperID"]);
                        empty2 = "I";
                        row9["InventoryCode"].ToString();
                        row9["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row9["Quantity"]);
                        Convert.ToDecimal(row9["PackedIn"]);
                        Convert.ToInt64(row9["EstimateLithobookletItemID"]);
                        Convert.ToDecimal(row9["PaperUnitPrice"]);
                        Convert.ToInt32(row9["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row9["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row9["RunningSpoilage"]);
                        Convert.ToDecimal(row9["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row9["InvSheets"]);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToInt32(hashtables3[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key5 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key5), empty2, Convert.ToInt32(hashtables3[key5]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
            }
            this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            if (this.htInventory.Count > 0)
            {
                foreach (long key6 in this.htInventory.Keys)
                {
                    string empty4 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow9 in dataTable2.Rows)
                        {
                            empty4 = dataRow9["FinalQuantity"].ToString();
                        }
                    }
                    if (JobStatus == "reverted-i")
                    {
                        commonClass _commonClass = this.commclass;
                        long num15 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job status not matched: <a href='", this.strSitepath, "invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num15, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                    if (JobStatus == "completed")
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        if (str1 != "invoice")
                        {
                            commonClass _commonClass1 = this.commclass;
                            long num16 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                            _commonClass1.Insert_Activity_History_For_Inventory(num16, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                        else
                        {
                            commonClass _commonClass2 = this.commclass;
                            long num17 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "/invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                            _commonClass2.Insert_Activity_History_For_Inventory(num17, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                    }
                    if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(this.ReduceStockType.ToLower() != "e") || !(this.ReduceStockType.ToLower() != num.ToString()) || !(this.ReduceStockType.ToLower() != "i") || !(str1 != "invoice"))
                        {
                            continue;
                        }
                        commonClass _commonClass3 = this.commclass;
                        long num18 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock allocated: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass3.Insert_Activity_History_For_Inventory(num18, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "h", new decimal(0));
                    }
                    else
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        commonClass _commonClass4 = this.commclass;
                        long num19 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job cancellation: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass4.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                }
            }
            return empty;
        }

        public void DirectInvoiceCreate()
        {
            DateTime dateTime;
            object[] objArray;
            //string str = base.Request.QueryString["IDs"].ToString();
            string str = string.Empty;
            if (base.Request.Form["IDs"] != null && base.Request.Form["IDs"] != "")
            {
                str = base.Request.Form["IDs"].ToString();
            }
            else
            {
                str = Session["IDs"] as string;
            }
            string[] strArrays = str.Split(new char[] { ',' });
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '\u005F' });
                progress_to_invoice.CustomerID = Convert.ToInt64(strArrays1[3]);
                empty = string.Concat(empty, strArrays1[2].ToString(), ",");
                empty1 = string.Concat(empty1, strArrays1[1].ToString(), ",");
                str1 = string.Concat(str1, strArrays1[0].ToString(), ",");
                if (!empty2.Contains(strArrays1[0].ToString()))
                {
                    empty2 = string.Concat(empty2, strArrays1[0].ToString(), ",");
                    str2 = string.Concat(str2, strArrays1[1].ToString(), ",");
                }
            }            
                empty = empty.Substring(0, empty.Length - 1);
            if (!this.IsItemSelected)
            {
                empty = this.EstimateItemIDs;
            }
            empty1 = empty1.Substring(0, empty1.Length - 1);
            str1 = str1.Substring(0, str1.Length - 1);
            string[] strArrays2 = empty.Split(new char[] { ',' });
            string[] strArrays3 =  empty1.Split(new char[] { ',' }).Distinct().ToArray();
            //string[] strArrays3 = empty1.Split(new char[] { ',' });
            str1.Split(new char[] { ',' });
            string[] strArrays4 = empty2.Split(new char[] { ',' });
            str2.Split(new char[] { ',' });
            int num = 0;
            num = Convert.ToInt32(strArrays3[0]);
            CompanyBasePage companyBasePage = new CompanyBasePage();
            commonClass _commonClass = new commonClass();
            notesclass _notesclass = new notesclass();
            long num1 = companyBasePage.settings_lastcounter_select(this.CompanyID, "i");
            long num2 = (long)10000000 + num1;
            string str3 = string.Concat(ConnectionClass.InvoicePrefix, num2.ToString().Substring(1, num2.ToString().Length - 1));
            int paymentDetailsFromEstimateID = InvoiceBasePage.Get_PaymentDetails_From_EstimateID((long)num);
            DateTime now = DateTime.Now;
            DateTime dateTime1 = now.AddDays((double)paymentDetailsFromEstimateID);
            int defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "invoice", 0);
            try
            {
                commonClass _commonClass1 = this.commclass;
                DateTime now1 = DateTime.Now;
                dateTime = _commonClass1.Eprint_return_ActualDate_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
            }
            catch
            {
                dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            }
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
            {
                empty3 = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
            {
                empty4 = dataRow["PhraseText"].ToString();
            }
            int num3 = 0;
            char chr = 'C';
            //customer order number
            string CusOrdNo = string.Empty;
            //for (int n = 0; n < (int)strArrays3.Length; n++)
            //{
            //    foreach (DataRow row1 in InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, Convert.ToInt32(strArrays3[n])).Rows)
            //    {
            //        if (n == 0)
            //        {
            //            CusOrdNo =  Convert.ToString(row1["CustomerOrderNumber"]);
            //        }
            //        if (n > 0)
            //        {
            //            CusOrdNo += ", " + Convert.ToString(row1["CustomerOrderNumber"]);
            //        }

            //    }
            //}
            List<string> orderNumbers = new List<string>();

            for (int n = 0; n < strArrays3.Length; n++)
            {
                var rows = InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, Convert.ToInt32(strArrays3[n])).Rows;

                foreach (DataRow row1 in rows)
                {
                    string orderNumber = Convert.ToString(row1["CustomerOrderNumber"]);
                    if (!string.IsNullOrWhiteSpace(orderNumber))
                    {
                        orderNumbers.Add(orderNumber);
                    }
                }
            }

            CusOrdNo = string.Join(", ", orderNumbers);
            foreach (DataRow row1 in InvoiceBasePage.GetClientDefaultInvoiceDetails(this.CompanyID, (long)num).Rows)
            {
                num3 = Convert.ToInt32(row1["InvoiceAddressID"].ToString());
                chr = Convert.ToChar(row1["InvoiceAddressType"].ToString());              
            }
            bool flag = false;
            if (this.rdnProformaInvNo.Checked)
            {
                flag = true;
            }
            long num4 = InvoiceBasePage.Invoice_insert_SplitItems(Convert.ToInt32(this.Session["CompanyID"]), str3, defaultStatusID, dateTime, dateTime, Convert.ToInt32(this.Session["UserID"]), 0, this.objBase.ReplaceSingleQuote(empty3), this.objBase.ReplaceSingleQuote(empty4), 0, ConnectionClass.IsHandy, num3, chr, num3, dateTime1, progress_to_invoice.CustomerID, Convert.ToInt64(this.ddlContactList.SelectedValue), Convert.ToInt64(this.ddlSalesPerson.SelectedValue), this.objBase.SpecialEncode(this.txtInvoiceTitle.Text), flag, CusOrdNo);
            for (int j = 0; j < (int)strArrays2.Length; j++)
            {
                InvoiceBasePage.InvoiceID_Update_in_Items(num4, Convert.ToInt64(strArrays2[j]));
                if (flag)
                {
                    InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, dateTime, Convert.ToInt64(strArrays2[j]));
                }
            }
            for (int k = 0; k < (int)strArrays4.Length - 1; k++)
            {
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                if (strArrays4[k].ToString() != "0")
                {
                    foreach (DataRow dataRow1 in InvoiceBasePage.Invoice_JobDetails_SelectByInvoiceID(this.CompanyID, num4).Rows)
                    {
                        empty5 = dataRow1["Estimatenumber"].ToString();
                        str5 = dataRow1["jobnumber"].ToString();
                        empty6 = dataRow1["invoicenumber"].ToString();
                    }
                    if (this.hdnNextType.Value != "payment")
                    {
                        _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                    }
                    else
                    {
                        _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobProgInvPayment);
                    }
                    _notesclass.Estimate_number = empty5;
                    _notesclass.Job_number = str5;
                    _notesclass.Invoice_number = empty6;
                    _notesclass.ModuleName = "job";
                    _notesclass.ModuleID = Convert.ToInt64(strArrays4[k]);
                    _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    commonClass _commonClass2 = this.commclass;
                    now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    _notesclass.CompanyID = this.CompanyID;
                    _notesclass.UserID = this.UserID;
                    this.objN.NotesAdd(_notesclass);
                }
            }
            if ((int)strArrays4.Length - 1 != 1)
            {
                _notesclass.NotesType = Convert.ToString(Notes.NotesType.MultipleInvCreate);
                _notesclass.ModuleName = "invoice";
                _notesclass.ModuleID = num4;
                this.objN.NotesAdd(_notesclass);
            }
            else
            {
                _notesclass.NotesType = Convert.ToString(Notes.NotesType.InvCreate);
                _notesclass.ModuleName = "invoice";
                _notesclass.ModuleID = num4;
                this.objN.NotesAdd(_notesclass);
            }
            for (int l = 0; l < (int)strArrays2.Length; l++)
            {
                string str6 = string.Empty;
                string empty7 = string.Empty;
                DataTable dataTable = JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, Convert.ToInt64(strArrays2[l]));
                foreach (DataRow row2 in dataTable.Rows)
                {
                    empty7 = row2["InvoiceItemNumber"].ToString();
                    str6 = row2["JobItemNumber"].ToString();
                }
                _notesclass.Job_number = str6;
                _notesclass.Invoice_number = empty7;
                _notesclass.ItemID = Convert.ToInt64(strArrays2[l]);
                _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobItemProgInv);
                _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                commonClass _commonClass3 = this.commclass;
                now = DateTime.Now;
                _notesclass.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                _notesclass.CompanyID = this.CompanyID;
                _notesclass.UserID = this.UserID;
                this.objN.NotesAdd(_notesclass);
            }
            if (this.InventoryManagement == "IM" && this.ReduceStockType.ToLower() != "e")
            {
                this.Call_Inventory_Adjustment("completed-i", (long)0, num4);
            }
            if ((new BaseClass()).Return_StockManagementSettings("SR_WhenStockReduced") == "c")
            {
                this.Call_Inventory_Adjustment("completed-i", (long)0, num4);
            }
            this.IsJobFromEstore = InvoiceBasePage.Is_INVOICE_from_Webstore(num4);
            Session.Remove("IDs");
            Session.Remove("IsItemSelected");
            if (this.hdnNextType.Value != "payment")
            {
                System.Web.UI.Page page = this.Page;
                Type type = base.GetType();
                objArray = new object[] { "javascript:TakeOut(", num4, ",", num, ");" };
                System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "", string.Concat(objArray), true);
                return;
            }
            HttpResponse response = base.Response;
            objArray = new object[] { this.strSitepath, "common/Invoice_Paid_View.aspx?SelectedIDs=", str, "&InvID=", num4, "&ItemIDs=", empty, "&EstimateIDs=", empty1, "&JobIDs=", str1 };
            response.Redirect(string.Concat(objArray));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] == null || this.Session["UserID"] == null)
            {
                this.objBase.Session_Check();
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            //if (base.Request.QueryString["IsItemSelected"] != null && base.Request.QueryString["IsItemSelected"].ToString() != "")
            //{
            //    this.IsItemSelected = Convert.ToBoolean(base.Request.QueryString["IsItemSelected"]);
            //}
            if (IsPostBack && !string.IsNullOrEmpty(Request.Form["IsItemSelected"]))
            {
                this.IsItemSelected = Convert.ToBoolean(Request.Form["IsItemSelected"]);
            }
            this.rdnProformaInvYes.Text = this.objLangClass.GetLanguageConversion("Generate_Invoice_and_keep_the_job_live");
            this.rdnProformaInvNo.Text = this.objLangClass.GetLanguageConversion("Generate_Invoice_and_archive_the_job");
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            }
            if (!base.IsPostBack)
            {
                //if (base.Request.QueryString["IDs"] != null && base.Request.QueryString["IDs"].ToString() != "")
                if (base.Request.Form["IDs"] != null && base.Request.Form["IDs"].ToString() != "")
                {
                    base.Title = "Progress To Invoice";
                    Session["IDs"] = Request.Form["IDs"];
                    Session["IsItemSelected"] = Request.Form["IsItemSelected"];
                    string empty = string.Empty;
                    string[] strArrays = base.Request.Form["IDs"].ToString().Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        string[] strArrays1 = strArrays[i].Split(new char[] { '\u005F' });
                        empty = string.Concat(empty, strArrays1[0], ",");
                        progress_to_invoice.CustomerID = Convert.ToInt64(strArrays1[3]);
                        if (this.IsItemSelected)
                        {
                            progress_to_invoice commonProgressToInvoice = this;
                            commonProgressToInvoice.EstimateItemIDs = string.Concat(commonProgressToInvoice.EstimateItemIDs, strArrays1[2], ",");
                        }
                    }
                    DataTable dataTable = new DataTable();
                    if (!this.IsItemSelected)
                    {
                        empty = empty.Substring(0, empty.Length - 1);
                        dataTable = JobBasePage.EstimateItems_PendingForInvoice_Select(empty);
                        if (dataTable != null)
                        {
                            dataTable.Columns[2].ReadOnly = false;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                row["ItemTitle"] = row["ItemTitle"].ToString();
                                progress_to_invoice commonProgressToInvoice1 = this;
                                commonProgressToInvoice1.EstimateItemIDs = string.Concat(commonProgressToInvoice1.EstimateItemIDs, row["EstimateItemID"].ToString(), ",");
                            }
                        }
                        this.ItemsGridView.DataSource = dataTable;
                        this.ItemsGridView.DataBind();
                    }
                    if (this.EstimateItemIDs.Length > 0)
                    {
                        this.EstimateItemIDs = this.EstimateItemIDs.Substring(0, this.EstimateItemIDs.Length - 1);
                        DataSet invoiceAllContactsSelect = JobBasePage.Job_ProgToInvoice_allContacts_Select(this.EstimateItemIDs);
                        DataTable item = invoiceAllContactsSelect.Tables[0];
                        DataTable item1 = invoiceAllContactsSelect.Tables[1];
                        DataTable dataTable1 = invoiceAllContactsSelect.Tables[2];
                        DataTable item2 = invoiceAllContactsSelect.Tables[3];
                        this.ddlContactList.DataSource = item;
                        this.ddlContactList.DataTextField = "ContactName";
                        this.ddlContactList.DataValueField = "ContactID";
                        this.ddlContactList.DataBind();
                        this.ddlSalesPerson.DataSource = item1;
                        this.ddlSalesPerson.DataTextField = "Name";
                        this.ddlSalesPerson.DataValueField = "SalesPerson";
                        this.ddlSalesPerson.DataBind();
                        DataSet invContactsSelect = JobBasePage.Job_ProgressToInv_Contacts_Select(this.EstimateItemIDs);
                        if (invContactsSelect.Tables[0].Rows.Count > 0)
                        {
                            this.objBase.SetDDLValue(this.ddlContactList, invContactsSelect.Tables[0].Rows[0]["ContactID"].ToString());
                        }
                        if (item1.Rows.Count > 1)
                        {
                            this.ddlSalesPerson.Items.Insert(0, " ");
                            this.ddlSalesPerson.Items[0].Text = "---Select---";
                            this.ddlSalesPerson.Items[0].Value = "0";
                        }
                        if (dataTable1.Rows.Count > 0)
                        {
                            this.txtInvoiceTitle.Text = dataTable1.Rows[0]["EstimateTitle"].ToString();
                        }
                        if (item2.Rows.Count > 0)
                        {
                            this.objBase.SetDDLValue(this.ddlSalesPerson, item2.Rows[0]["SalesPersonID"].ToString());
                        }
                        if (this.IsItemSelected)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:ItemListDisplay('no');", true);
                            this.btnPrevious.Style.Add("display", "none");
                            this.btnNext.Style.Add("display", "none");
                        }
                        else if (dataTable.Rows.Count <= 1)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:ItemListDisplay('no');", true);
                            this.btnPrevious.Style.Add("display", "none");
                            this.btnNext.Style.Add("display", "none");
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:ItemListDisplay('yes');", true);
                        }
                    }
                }
                if (!this.commclass.performinvoicecheck(this.CompanyID, "job", "Job_Progress_to_Invoice"))
                {
                    this.rdnProformaInvYes.Checked = true;
                    this.rdnProformaInvNo.Checked = false;
                }
                else
                {
                    this.rdnProformaInvNo.Checked = true;
                    this.rdnProformaInvYes.Checked = false;
                }
                if (this.IsItemSelected)
                {
                    this.rdnProformaInvYes.Text = this.objLangClass.GetLanguageConversion("Generate_Invoice_and_keep_the_job__Item_live");
                    this.rdnProformaInvNo.Text = this.objLangClass.GetLanguageConversion("Generate_Invoice_and_archive_the_job_Item");
                }
            }
            //string str = base.Request.QueryString["IDs"].ToString();
            string str = string.Empty;
            if(base.Request.Form["IDs"] != null && base.Request.Form["IDs"] != "")
            {
                str = base.Request.Form["IDs"].ToString();
            }
            else
            {
                str = Session["IDs"] as string;
            }
            if (str.ToString().ToLower().Trim().Contains("paypal") || str.ToString().ToLower().Trim().Contains("braintree credit card") || str.ToString().ToLower().Trim().Contains("stripe credit card"))
            {
                this.IsBrainTreePayment = true;
                this.btnContactNext2.Style.Add("display", "none");
            }
        }
    }
}