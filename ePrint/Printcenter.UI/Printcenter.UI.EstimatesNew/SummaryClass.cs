using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace Printcenter.UI.EstimatesNew
{
    public class SummaryClass : System.Web.UI.Page
    {
        public int CompanyID;

        public int UserID;

        private DataTable dtJobCard = new DataTable();

        public string SectionKey = string.Empty;

        public string JobCardDescription = string.Empty;

        public short LineSpacing;

        public string lineBrakes = string.Empty;

        private commonClass commclass = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string ReduceStockType = string.Empty;

        private CompanyBasePage objCom = new CompanyBasePage();

        public static long DeliveryAddressID;

        public static string DeliveryAddressType;

        public static int CourierID;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public bool IsJobCopied;

        public long NewEstimateID;

        public bool FrmJobAdd;

        private Hashtable htInventory = new Hashtable();

        public bool isrerun;

        public bool isMainitem;

        public bool isStock_Reduce;

        public static int ManageStockPermission;

        public static string StockCancellationType;

        public static bool IsStockCancel;

        public int OrderID;

        private long ModuleID;

        private static DateTime CreatedDate;

        static SummaryClass()
        {
            SummaryClass.DeliveryAddressID = (long)0;
            SummaryClass.DeliveryAddressType = string.Empty;
            SummaryClass.CourierID = 0;
            SummaryClass.ManageStockPermission = 0;
            SummaryClass.StockCancellationType = string.Empty;
            SummaryClass.IsStockCancel = false;
        }

        public SummaryClass()
        {
        }

        private void Adjust_Inventory_On_Job_Complete(DataSet ds, string StrJobNum, int StatusID, long EstID, Hashtable htInventory, int CompanyID, long EstimateItemID, string JobStatus)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, Convert.ToInt32(Convert.ToString(this.Session["UserID"])), CompanyID, JobStatus, htInventory, EstimateItemID);
        }

        public static void AttachmentUpdate_PO_DN(long EstimateID, long EstimateItemID, long TypeID, string Attachmenttype)
        {
            EstimateBasePage.Attachments_PO_DN_Copy(EstimateID, EstimateItemID, TypeID, Attachmenttype);
        }

        public string Call_Inventory_Adjustment(string JobStatus, long EstimateID, int CompanyID, long EstimateItemID, int UserID)
        {
            object[] estimateID;
            string str = global.sitePath();
            string empty = string.Empty;
            Hashtable hashtables = new Hashtable();
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            string empty1 = string.Empty;
            empty1 = _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            DataTable dataTable1 = new DataTable();
            dataTable = EstimateBasePage.job_card_info_select_by_estimateid(CompanyID, EstimateID);
            string PaperType = string.Empty;
            if (JobStatus.ToLower().Contains("cancelled-stock"))
            {
                dataTable = EstimateBasePage.job_card_info_select_by_estimateid_With_Subitem(CompanyID, EstimateID);
            }
            string str1 = string.Empty;
            int num = 0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num1 = 0;
            if (JobStatus.ToLower().Contains("progressed-invoice"))
            {
                JobStatus = "progressed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("archive"))
            {
                JobStatus = "archive";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-jobdelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-invoicedelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-invoice"))
            {
                JobStatus = "completed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("progressed-rerun"))
            {
                JobStatus = "progressed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("completed-rerun"))
            {
                JobStatus = "completed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-status"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-status"))
            {
                this.FrmJobAdd = true;
                JobStatus = "completed";
            }
            if (JobStatus.ToLower().Contains("progressed-status"))
            {
                JobStatus = "progressed";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("progressed-inv-rerun"))
            {
                JobStatus = "progressed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("completed-inv-rerun"))
            {
                JobStatus = "completed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-status"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-delete"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (!JobStatus.ToLower().Contains("cancelled-stock"))
            {
                SummaryClass.IsStockCancel = false;
            }
            else
            {
                SummaryClass.IsStockCancel = true;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null || row["EstimateItemID"] == null || EstimateItemID != Convert.ToInt64(row["EstimateItemID"]) && !this.FrmJobAdd && !this.IsJobCopied)
                {
                    continue;
                }
                int num2 = Convert.ToInt32(row["QtyNumber"]);
                string str3 = row["ItemType"].ToString();
                long num3 = (long)0;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                int num4 = 0;
                EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                int num5 = 0;
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal printSheetCalulation = new decimal(0);
                string str4 = string.Empty;
                decimal num9 = new decimal(0);
                str1 = row["JobNumber"].ToString();
                num = Convert.ToInt32(row["StatusID"].ToString());
                empty2 = row["InvoiceNumber"].ToString();
                if (string.Compare(str3, "S", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow["PaperID"]);
                        empty3 = "I";
                        dataRow["InventoryCode"].ToString();
                        num9 = Convert.ToDecimal(dataRow["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "P", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row1["PaperID"]);
                        empty3 = "I";
                        row1["InventoryCode"].ToString();
                        row1["inventoryname"].ToString();
                        num4 = BaseClass.CheckIntegerNull(row1["Quantity"]);
                        Convert.ToDecimal(row1["PackedIn"]);
                        Convert.ToInt64(row1["EstimatePadItemID"]);
                        Convert.ToDecimal(row1["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row1["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row1["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row1["RunningSpoilage"]);
                        Convert.ToDecimal(row1["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row1["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "L", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow1["PaperID"]);
                        empty3 = "I";
                        dataRow1["InventoryCode"].ToString();
                        dataRow1["inventoryname"].ToString();
                        num4 = BaseClass.CheckIntegerNull(dataRow1["Quantity"]);
                        Convert.ToDecimal(dataRow1["PackedIn"]);
                        Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                        Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
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
                        string CalType = dataRow1["CalculationType"].ToString();
                        if (CalType.ToString().ToLower() == "square")
                        {
                           num9 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow1["InvStock"].ToString()), 0, "", false, false, true));
                        }
                        else
                        {
                            num9 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        }
                        //num9 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, num9);
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                        {
                           EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToDecimal(Math.Ceiling(num9)), JobStatus, EstimateItemID);
                        }
                        else
                        {
                           EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToDecimal(num9), JobStatus, EstimateItemID);
                        }
                        //EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToDecimal(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "B", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    Hashtable hashtables1 = new Hashtable();
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row2["PaperID"]);
                        empty3 = "I";
                        row2["InventoryCode"].ToString();
                        row2["inventoryname"].ToString();
                       // num4 = Convert.ToInt32(row2["Quantity"]);
                        num4 = BaseClass.CheckIntegerNull(row2["Quantity"]);
                        Convert.ToDecimal(row2["PackedIn"]);
                        Convert.ToInt64(row2["EstimateBookletItemID"]);
                        Convert.ToDecimal(row2["PaperUnitPrice"]);
                        Convert.ToDecimal(row2["NoOfSignatures"]);
                        num6 = Convert.ToDecimal(row2["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row2["RunningSpoilage"]);
                        Convert.ToDecimal(row2["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row2["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (!hashtables1.ContainsKey(num3))
                        {
                            hashtables1.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables1[num3] = Convert.ToInt32(hashtables1[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key in hashtables1.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key), empty3, Convert.ToInt32(hashtables1[key]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "W", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    Hashtable hashtables2 = new Hashtable();
                    foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                        empty3 = dataRow2["WarehouseType"].ToString();
                        num4 = Convert.ToInt32(dataRow2["Quantity"]);
                        if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                        {
                            continue;
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(hashtables[num3].ToString()))) + Convert.ToInt32(num4);
                        }
                        if (!hashtables2.ContainsKey(num3))
                        {
                            hashtables2.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        num1 = num1 + this.Select_Quantity_History_For_Inventory(EstimateItemID);
                    }
                    if (hashtables2.Count > 0)
                    {
                        foreach (long key1 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key1), empty3, Convert.ToInt32(hashtables2[key1]), JobStatus, EstimateItemID);
                        }
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "O", true) == 0 || string.Compare(str3, "U", true) == 0) //Modification by Bilal ticket # 8071
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "C", true) == 0)
                {
                    bool flag = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num10 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        bool flag1 = Convert.ToBoolean(row3["IsStockReplenish"]);
                        bool flag2 = Convert.ToBoolean(row3["IsStockReplenished"]);
                        bool HasPurchaseOrder = Convert.ToBoolean(row3["HasPurchaseOrder"]);
                        num4 = Convert.ToInt32(row3["Quantity"]);
                        decimal num11 = Convert.ToDecimal(row3["Price"]);
                        BaseClass baseClass = new BaseClass();
                        string str5 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str6 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str7 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str8 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str9 = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
                        string strStatus = baseClass.Return_StockManagementSettings("SR_JobStatusID");
                        if (flag1.ToString().ToLower() == "true" && flag2.ToString().ToLower() != "true")
                        {
                            flag = false;
                        }
                        if (SummaryClass.IsStockCancel)
                        {
                            if (!(JobStatus == "cancelled-stock") && !(str9 == "a"))
                            {
                                continue;
                            }
                            foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "self", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, (long)0, num10, "other", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str9);
                                }
                            }
                        }
                        else
                        {
                            if (!(flag1.ToString().ToLower() != "true") || !(flag.ToString().ToLower() == "true"))
                            {
                                if (num.ToString() == strStatus)
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (str5 == "e")
                            {
                                foreach (DataRow row4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (row4["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() != "true")
                                    {
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (row4["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() == "true" && HasPurchaseOrder.ToString().ToLower() == "true")
                                    {
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                }
                            }
                            else if (str5 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == num.ToString())
                            {
                                foreach (DataRow dataRow4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() != "true")
                                    {
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                }
                            }
                            if (str8 == "e")
                            {
                                foreach (DataRow row5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (row5["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() != "true")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                            else if (str8 != "j")
                            {
                                if (!(str8 == "c") || string.Compare(str2, "invoice", true) != 0)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (dataRow5["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() != "true")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (dataRow5["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (dataRow5["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow5["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                            else
                            {
                                string str10 = baseClass.Return_StockManagementSettings("SR_JobStatusID");
                                bool flag3 = false;
                                if (str10 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                {
                                    flag3 = true;
                                }
                                if (!flag3)
                                {
                                    continue;
                                }
                                foreach (DataRow row6 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    this.Session["StockItemType"] = "C";
                                    if (row6["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() != "true")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() == "s" && flag2.ToString().ToLower() == "true" && HasPurchaseOrder.ToString().ToLower() == "true")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                        }
                    }
                    this.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "F", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow6 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow6["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow6["Noofplates"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                    }
                    foreach (DataRow row7 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row7["PaperID"]);
                        empty3 = "I";
                        row7["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row7["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row7["Quantity"]);
                        Convert.ToDecimal(row7["PackedIn"]);
                        Convert.ToInt64(row7["EstLithoItemID"]);
                        Convert.ToDecimal(row7["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row7["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row7["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row7["RunningSpoilage"]);
                        Convert.ToDecimal(row7["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row7["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "D", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow7 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow7["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow7["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row8["PaperID"]);
                        empty3 = "I";
                        row8["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row8["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row8["Quantity"]);
                        Convert.ToDecimal(row8["PackedIn"]);
                        Convert.ToInt64(row8["EstimateLithoPadItemID"]);
                        Convert.ToDecimal(row8["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row8["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row8["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row8["RunningSpoilage"]);
                        Convert.ToDecimal(row8["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row8["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "N", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow8 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow8["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow8["Noofplates"]);
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (long key2 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key2), empty3, Convert.ToInt32(hashtables3[key2]), JobStatus, EstimateItemID);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row9 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row9["PaperID"]);
                        empty3 = "I";
                        row9["InventoryCode"].ToString();
                        row9["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row9["Quantity"]);
                        Convert.ToDecimal(row9["PackedIn"]);
                        Convert.ToInt64(row9["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(row9["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row9["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row9["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row9["RunningSpoilage"]);
                        decimal num12 = Convert.ToDecimal(row9["NcrPartsPerSet"].ToString());
                        decimal num13 = Convert.ToDecimal(row9["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(row9["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row9["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key3 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key3), empty3, Convert.ToInt32(hashtables3[key3]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "R", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow8 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow8["PlateID"]);
                        empty3 = "I";
                        //num4 = Convert.ToInt32(dataRow8["Noofplates"]);
                        num4 = 0;
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (long key2 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key2), empty3, Convert.ToInt32(hashtables3[key2]), JobStatus, EstimateItemID);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row9 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row9["PaperID"]);
                        empty3 = "I";
                        row9["InventoryCode"].ToString();
                        row9["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row9["Quantity"]);
                        Convert.ToDecimal(row9["PackedIn"]);
                        Convert.ToInt64(row9["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(row9["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row9["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row9["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row9["RunningSpoilage"]);
                        decimal num12 = Convert.ToDecimal(row9["NcrPartsPerSet"].ToString());
                        decimal num13 = Convert.ToDecimal(row9["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(row9["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row9["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key3 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key3), empty3, Convert.ToInt32(hashtables3[key3]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "K", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(CompanyID, EstimateItemID);
                    Hashtable hashtables4 = new Hashtable();
                    foreach (DataRow dataRow9 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow9["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow9["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                        if (!hashtables4.ContainsKey(num3))
                        {
                            hashtables4.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (long key4 in hashtables4.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key4), empty3, Convert.ToInt32(hashtables4[key4]), JobStatus, EstimateItemID);
                    }
                    hashtables4.Clear();
                    foreach (DataRow row10 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row10["PaperID"]);
                        empty3 = "I";
                        row10["InventoryCode"].ToString();
                        row10["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row10["Quantity"]);
                        Convert.ToDecimal(row10["PackedIn"]);
                        Convert.ToInt64(row10["EstimateLithobookletItemID"]);
                        Convert.ToDecimal(row10["PaperUnitPrice"]);
                        int num14 = Convert.ToInt32(row10["NoOfSignatures"]);
                        num6 = Convert.ToDecimal(row10["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row10["RunningSpoilage"]);
                        Convert.ToDecimal(row10["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row10["InvSheets"]);
                        decimal printSheetCalulation1 = new decimal(0);
                        printSheetCalulation1 = EstimatesBasePage.GetPrintSheetCalulation(num4, new decimal(0), num6, num7, Convert.ToDecimal(num14), "booklet", new decimal(0), "", out num8);
                        printSheetCalulation = EstimateBasePage.NoOfSheetsReturnByFirstTrim(Convert.ToDecimal(row10["height"]), Convert.ToDecimal(row10["width"]), Convert.ToDecimal(row10["SheetHeight"]), Convert.ToDecimal(row10["SheetWidth"]), num5.ToString(), printSheetCalulation1);
                        if (!hashtables4.ContainsKey(num3))
                        {
                            hashtables4.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key5 in hashtables4.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key5), empty3, Convert.ToInt32(hashtables4[key5]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "Q", true) != 0)
                {
                    if (string.Compare(str3, "X", true) != 0)
                    {
                        continue;
                    }
                    string str11 = string.Format("<script type='text/javascript' language='javascript'>alert('{0}')</script>", "hi");
                    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "PopupScript", str11);
                    bool flag4 = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow10 in dataSet.Tables[0].Rows)
                    {
                        long num15 = Convert.ToInt64(dataRow10["PriceCatalogueID"]);
                        long num16 = Convert.ToInt64(dataRow10["OrderItemId"]);
                        num4 = Convert.ToInt32(dataRow10["Quantity"]);
                        decimal num17 = Convert.ToDecimal(dataRow10["Price"]);
                        bool flag5 = Convert.ToBoolean(dataRow10["IsStockReplenish"]);
                        bool flag6 = Convert.ToBoolean(dataRow10["IsStockReplenished"]);
                        BaseClass baseClass1 = new BaseClass();
                        string str12 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str13 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str14 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str15 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str16 = baseClass1.Return_StockManagementSettings("SC_IfJobCancelled");
                        string str17 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                        if (flag5.ToString().ToLower() == "true" && flag6.ToString().ToLower() != "true")
                        {
                            flag4 = false;
                        }
                        if (SummaryClass.IsStockCancel)
                        {
                            if (!(JobStatus == "cancelled-stock") && !(str16 == "a"))
                            {
                                continue;
                            }
                            foreach (DataRow row11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                            {
                                if (row11["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "self", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else if (row11["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num15, "other", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else if (row11["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row11["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str16);
                                }
                            }
                        }
                        else
                        {
                            if (!(flag5.ToString().ToLower() != "true") || !(flag4.ToString().ToLower() == "true"))
                            {
                                continue;
                            }
                            if (str12 == "j" || str17 == "j")
                            {
                                string str18 = baseClass1.Return_StockManagementSettings("SA_EstoreJobStatusID");
                                string str19 = baseClass1.Return_StockManagementSettings("SA_JobStatusID");
                                if (str18 == num.ToString() || str19 == num.ToString())
                                {
                                    foreach (DataRow dataRow11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        if (dataRow11["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow11["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow11["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow11["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            foreach (DataRow row12 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                            {
                                                empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row12["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                            }
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                        }
                                    }
                                }
                            }
                            else if (str12 == "c" || str12 == "p")
                            {
                                foreach (DataRow dataRow12 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (dataRow12["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                    }
                                    else if (dataRow12["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                    }
                                    else if (dataRow12["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow12["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow row13 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                        {
                                            empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row13["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                    }
                                }
                            }
                            if (str15 == "e")
                            {
                                foreach (DataRow dataRow13 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (dataRow13["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow13["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow13["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow13["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                            else if (str15 != "j")
                            {
                                if (!(str15 == "c") || string.Compare(str2, "invoice", true) != 0)
                                {
                                    continue;
                                }
                                foreach (DataRow row14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (row14["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (row14["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (row14["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row14["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                            else
                            {
                                string str20 = baseClass1.Return_StockManagementSettings("SR_JobStatusID");
                                bool flag7 = false;
                                if (str20 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                {
                                    flag7 = true;
                                }
                                if (!flag7)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    this.Session["StockItemType"] = "X";
                                    this.Session["ALC_OrderItemId"] = num16.ToString();
                                    if (dataRow14["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow14["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow14["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow14["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                        }
                    }
                    this.Session["StockItemType"] = "X";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row15 in dataSet.Tables[0].Rows)
                    {
                        if (!this.isMainitem)
                        {
                            continue;
                        }
                        num3 = Convert.ToInt64(row15["PaperID"]);
                        empty3 = "I";
                        row15["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row15["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row15["Quantity"]);
                        Convert.ToDecimal(row15["PackedIn"]);
                        Convert.ToInt64(row15["QuickQuoteID"]);
                        Convert.ToDecimal(row15["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row15["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row15["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row15["RunningSpoilage"]);
                        PaperType = row15["PressPaperType"].ToString();
                        printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num4, num5, num6, num7, new decimal(0), "singleitem", new decimal(0), "", out num8);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(printSheetCalulation);
                        }
                        if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                        {
                           EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(Math.Ceiling(printSheetCalulation)), JobStatus, EstimateItemID);
                        }
                        else
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(Math.Ceiling(printSheetCalulation)), JobStatus, EstimateItemID);
                        }
                        //EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(printSheetCalulation), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
            }
            if (hashtables.Count > 0)
            {
                string JOBID = string.Empty;
                JOBID = JobBasePage.Get_JobID_By_EstimateID(EstimateID, CompanyID);
                foreach (long key6 in hashtables.Keys)
                {
                    string empty5 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow15 in dataTable2.Rows)
                        {
                            empty5 = dataRow15["FinalQuantity"].ToString();
                        }
                    }
                    if (this.isrerun)
                    {
                        if (JobStatus == "progressed" && empty1.ToLower() != "e" && empty1.ToLower() != num.ToString() && empty1.ToLower() != "i")
                        {
                            long num18 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num18, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        if (JobStatus != "completed")
                        {
                            continue;
                        }
                        long num19 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                        {
                            _commonClass.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "u", new decimal(0));
                        }
                        else
                        {
                            _commonClass.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                        }
                        //_commonClass.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                    }
                    else if (this.FrmJobAdd)
                    {
                        if (JobStatus == "completed")
                        {
                            if (empty5 == null || empty5 == "")
                            {
                                empty5 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num20 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID,"&jID=",JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            //_commonClass.Insert_Activity_History_For_Inventory(num20, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                            if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                            {
                                _commonClass.Insert_Activity_History_For_InventoryNew(num20, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "u", new decimal(0), EstimateItemID);
                            }
                            else
                            {
                                _commonClass.Insert_Activity_History_For_InventoryNew(num20, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0), EstimateItemID);
                            }
                            //_commonClass.Insert_Activity_History_For_InventoryNew(num20, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0), EstimateItemID);
                        }
                        else if (JobStatus != "cancelled")
                        {
                            if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i"))
                            {
                                continue;
                            }
                            long num21 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            //_commonClass.Insert_Activity_History_For_Inventory(num21, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0));
                            if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                            {
                                _commonClass.Insert_Activity_History_For_InventoryNew(num21, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "h", new decimal(0), EstimateItemID);
                            }
                            else
                            {
                               _commonClass.Insert_Activity_History_For_InventoryNew(num21, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0), EstimateItemID);
                            }
                            //_commonClass.Insert_Activity_History_For_InventoryNew(num21, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0), EstimateItemID);
                        }
                        else
                        {
                            if (empty5 == null || empty5 == "")
                            {
                                empty5 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num22 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock restored due to cancellation of job :<a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num22, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                        }
                    }
                    else if (JobStatus == "completed")
                    {
                        if (empty5 == null || empty5 == "")
                        {
                            empty5 = "0";
                        }
                        if (str2 == string.Empty)
                        {
                            long num23 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                            {
                                _commonClass.Insert_Activity_History_For_InventoryNew(num23, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "u", new decimal(0), EstimateItemID);
                            }
                            else
                            {
                               _commonClass.Insert_Activity_History_For_InventoryNew(num23, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0), EstimateItemID);
                            }
                            //_commonClass.Insert_Activity_History_For_InventoryNew(num23, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0), EstimateItemID);
                        }
                        else if (str2.ToLower() != "invoice")
                        {
                            if (str2.ToLower() != "inv")
                            {
                                continue;
                            }
                            long num24 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock altered: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                            {
                                _commonClass.Insert_Activity_History_For_Inventory(num24, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "u", new decimal(0));
                            }
                            else
                            {
                               _commonClass.Insert_Activity_History_For_Inventory(num24, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                            }
                            //_commonClass.Insert_Activity_History_For_Inventory(num24, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                        }
                        else
                        {
                            long num25 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                            {
                                _commonClass.Insert_Activity_History_For_Inventory(num25, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "u", new decimal(0));
                            }
                            else
                            {
                                _commonClass.Insert_Activity_History_For_Inventory(num25, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                            }
                            //_commonClass.Insert_Activity_History_For_Inventory(num25, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "u", new decimal(0));
                        }
                    }
                    else if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i") || !(str2.ToLower() != "invoice") || !(str2.ToLower() != "inv"))
                        {
                            continue;
                        }
                        long num26 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        //_commonClass.Insert_Activity_History_For_Inventory(num26, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0));
                        if (string.Equals(PaperType, "sheet", StringComparison.OrdinalIgnoreCase))
                        {
                            _commonClass.Insert_Activity_History_For_InventoryNew(num26, string.Concat(estimateID), UserID, Math.Ceiling(Convert.ToDecimal(hashtables[key6])), "h", new decimal(0), EstimateItemID);
                        }
                        else
                        {
                            _commonClass.Insert_Activity_History_For_InventoryNew(num26, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0), EstimateItemID);
                        }
                        //_commonClass.Insert_Activity_History_For_InventoryNew(num26, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0), EstimateItemID);
                    }
                    else
                    {
                        if (empty5 == null || empty5 == "")
                        {
                            empty5 = "0";
                        }
                        if (str2 != string.Empty)
                        {
                            continue;
                        }
                        long num27 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to deletion of item in job : <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "&jID=", JOBID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num27, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                    }
                }
            }
            return empty;
        }

        public string Call_Inventory_Adjustment_Job(string JobStatus, long EstimateID, int CompanyID, long EstimateItemID, int UserID, bool IsPerItem, long JobID, long InvoiceID)
         {
            object[] estimateID;
            string str = global.sitePath();
            string empty = string.Empty;
            Hashtable hashtables = new Hashtable();
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            string empty1 = string.Empty;
            empty1 = _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            DataTable dataTable1 = new DataTable();
            if (InvoiceID == (long)0)
            {
                dataTable = JobBasePage.Job_Card_Info_Select_By_JobID(JobID);
            }
            else if (JobID == (long)0)
            {
                dataTable = InvoiceBasePage.Job_Card_Info_Select_By_InvoiceID(InvoiceID);
            }
            string str1 = string.Empty;
            int num = 0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num1 = 0;
            if (JobStatus.ToLower().Contains("progressed-invoice"))
            {
                JobStatus = "progressed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("archive"))
            {
                JobStatus = "archive";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-jobdelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-invoicedelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-invoice"))
            {
                JobStatus = "completed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("progressed-rerun"))
            {
                JobStatus = "progressed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("completed-rerun"))
            {
                JobStatus = "completed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-status"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-status"))
            {
                this.FrmJobAdd = true;
                JobStatus = "completed";
            }
            if (JobStatus.ToLower().Contains("progressed-status"))
            {
                JobStatus = "progressed";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("progressed-inv-rerun"))
            {
                JobStatus = "progressed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("completed-inv-rerun"))
            {
                JobStatus = "completed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-status"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-delete"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (!JobStatus.ToLower().Contains("cancelled-stock"))
            {
                SummaryClass.IsStockCancel = false;
            }
            else
            {
                SummaryClass.IsStockCancel = true;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null || row["EstimateItemID"] == null)
                {
                    continue;
                }
                if (!IsPerItem)
                {
                    if (EstimateItemID != Convert.ToInt64(row["EstimateItemID"]) && !this.FrmJobAdd && !this.IsJobCopied)
                    {
                        continue;
                    }
                    int num2 = Convert.ToInt32(row["QtyNumber"]);
                    string str3 = row["ItemType"].ToString();
                    long num3 = (long)0;
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    int num4 = 0;
                    EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                    int num5 = 0;
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal printSheetCalulation = new decimal(0);
                    string str4 = string.Empty;
                    decimal num9 = new decimal(0);
                    str1 = row["JobNumber"].ToString();
                    num = Convert.ToInt32(row["StatusID"].ToString());
                    empty2 = row["InvoiceNumber"].ToString();
                    if (string.Compare(str3, "S", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow["PaperID"]);
                            empty3 = "I";
                            dataRow["InventoryCode"].ToString();
                            num9 = Convert.ToDecimal(dataRow["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "P", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow row1 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row1["PaperID"]);
                            empty3 = "I";
                            row1["InventoryCode"].ToString();
                            row1["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row1["Quantity"]);
                            Convert.ToDecimal(row1["PackedIn"]);
                            Convert.ToInt64(row1["EstimatePadItemID"]);
                            Convert.ToDecimal(row1["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(row1["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(row1["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row1["RunningSpoilage"]);
                            Convert.ToDecimal(row1["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row1["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "L", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow1["PaperID"]);
                            empty3 = "I";
                            dataRow1["InventoryCode"].ToString();
                            dataRow1["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow1["Quantity"]);
                            Convert.ToDecimal(dataRow1["PackedIn"]);
                            Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                            Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
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
                            num9 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, num9);
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToDecimal(num9), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "B", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        Hashtable hashtables1 = new Hashtable();
                        foreach (DataRow row2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row2["PaperID"]);
                            empty3 = "I";
                            row2["InventoryCode"].ToString();
                            row2["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row2["Quantity"]);
                            Convert.ToDecimal(row2["PackedIn"]);
                            Convert.ToInt64(row2["EstimateBookletItemID"]);
                            Convert.ToDecimal(row2["PaperUnitPrice"]);
                            Convert.ToDecimal(row2["NoOfSignatures"]);
                            num6 = Convert.ToDecimal(row2["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row2["RunningSpoilage"]);
                            Convert.ToDecimal(row2["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row2["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            if (!hashtables1.ContainsKey(num3))
                            {
                                hashtables1.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables1[num3] = Convert.ToInt32(hashtables1[num3].ToString()) + Convert.ToInt32(num9);
                            }
                        }
                        foreach (long key in hashtables1.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key), empty3, Convert.ToInt32(hashtables1[key]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "W", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        Hashtable hashtables2 = new Hashtable();
                        foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                            empty3 = dataRow2["WarehouseType"].ToString();
                            num4 = Convert.ToInt32(dataRow2["Quantity"]);
                            if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                            {
                                continue;
                            }
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!hashtables2.ContainsKey(num3))
                            {
                                hashtables2.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            num1 = num1 + this.Select_Quantity_History_For_Inventory(EstimateItemID);
                        }
                        if (hashtables2.Count > 0)
                        {
                            foreach (long key1 in hashtables2.Keys)
                            {
                                EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key1), empty3, Convert.ToInt32(hashtables2[key1]), JobStatus, EstimateItemID);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "O", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "C", true) == 0)
                    {
                        bool flag = true;
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow row3 in dataSet.Tables[0].Rows)
                        {
                            long num10 = Convert.ToInt64(row3["PriceCatalogueID"]);
                            bool flag1 = Convert.ToBoolean(row3["IsStockReplenish"]);
                            bool flag2 = Convert.ToBoolean(row3["IsStockReplenished"]);
                            num4 = Convert.ToInt32(row3["Quantity"]);
                            decimal num11 = Convert.ToDecimal(row3["Price"]);
                            BaseClass baseClass = new BaseClass();
                            string str5 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                            string str6 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                            string str7 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                            string str8 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                            string str9 = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
                            if (flag1.ToString().ToLower() == "true" && flag2.ToString().ToLower() != "true")
                            {
                                flag = false;
                            }
                            if (SummaryClass.IsStockCancel)
                            {
                                if (!(JobStatus == "cancelled-stock") && !(str9 == "a"))
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "self", EstimateItemID, "Job", (long)UserID, str9);
                                    }
                                    else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockCancellationProcess((long)CompanyID, (long)0, num10, "other", EstimateItemID, "Job", (long)UserID, str9);
                                    }
                                    else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str9);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str9);
                                    }
                                }
                            }
                            else
                            {
                                if (!(flag1.ToString().ToLower() != "true") || !(flag.ToString().ToLower() == "true"))
                                {
                                    continue;
                                }
                                if (str5 == "e")
                                {
                                    foreach (DataRow row4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                    {
                                        if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else
                                        {
                                            empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                    }
                                }
                                else if (str5 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == num.ToString())
                                {
                                    foreach (DataRow dataRow4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                    {
                                        if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                        else
                                        {
                                            empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                        }
                                    }
                                }
                                if (str8 == "e")
                                {
                                    foreach (DataRow row5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                    {
                                        if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else
                                        {
                                            empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                    }
                                }
                                else if (str8 != "j")
                                {
                                    if (!(str8 == "c") || string.Compare(str2, "invoice", true) != 0)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                    {
                                        if (dataRow5["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (dataRow5["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (dataRow5["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow5["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else
                                        {
                                            empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                    }
                                }
                                else
                                {
                                    string str10 = baseClass.Return_StockManagementSettings("SR_JobStatusID");
                                    bool flag3 = false;
                                    if (str10 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                    {
                                        flag3 = true;
                                    }
                                    if (!flag3)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow row6 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                    {
                                        this.Session["StockItemType"] = "C";
                                        if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                        else
                                        {
                                            empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                        }
                                    }
                                }
                            }
                        }
                        this.Session["StockItemType"] = "C";
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "F", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        dataTable1 = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                        foreach (DataRow dataRow6 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow6["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow6["Noofplates"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                        }
                        foreach (DataRow row7 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row7["PaperID"]);
                            empty3 = "I";
                            row7["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row7["ItemDescription"].ToString());
                            num4 = Convert.ToInt32(row7["Quantity"]);
                            Convert.ToDecimal(row7["PackedIn"]);
                            Convert.ToInt64(row7["EstLithoItemID"]);
                            Convert.ToDecimal(row7["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(row7["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(row7["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row7["RunningSpoilage"]);
                            Convert.ToDecimal(row7["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row7["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "D", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        dataTable1 = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                        foreach (DataRow dataRow7 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow7["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow7["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (DataRow row8 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row8["PaperID"]);
                            empty3 = "I";
                            row8["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row8["ItemDescription"].ToString());
                            num4 = Convert.ToInt32(row8["Quantity"]);
                            Convert.ToDecimal(row8["PackedIn"]);
                            Convert.ToInt64(row8["EstimateLithoPadItemID"]);
                            Convert.ToDecimal(row8["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(row8["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(row8["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row8["RunningSpoilage"]);
                            Convert.ToDecimal(row8["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row8["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "N", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                        Hashtable hashtables3 = new Hashtable();
                        foreach (DataRow dataRow8 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow8["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow8["Noofplates"]);
                            if (!hashtables3.ContainsKey(num3))
                            {
                                hashtables3.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (long key2 in hashtables3.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key2), empty3, Convert.ToInt32(hashtables3[key2]), JobStatus, EstimateItemID);
                        }
                        hashtables3.Clear();
                        foreach (DataRow row9 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row9["PaperID"]);
                            empty3 = "I";
                            row9["InventoryCode"].ToString();
                            row9["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row9["Quantity"]);
                            Convert.ToDecimal(row9["PackedIn"]);
                            Convert.ToInt64(row9["EstimateLithoNCRItemID"]);
                            Convert.ToDecimal(row9["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(row9["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(row9["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row9["RunningSpoilage"]);
                            decimal num12 = Convert.ToDecimal(row9["NcrPartsPerSet"].ToString());
                            decimal num13 = Convert.ToDecimal(row9["NcrSetsPerPad"].ToString());
                            Convert.ToDecimal(row9["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row9["InvSheets"]);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                            }
                            if (!hashtables3.ContainsKey(num3))
                            {
                                hashtables3.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num9);
                            }
                        }
                        foreach (long key3 in hashtables3.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key3), empty3, Convert.ToInt32(hashtables3[key3]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "K", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        dataTable1 = EstimatesBasePage.lithobooklet_item_select(CompanyID, EstimateItemID);
                        Hashtable hashtables4 = new Hashtable();
                        foreach (DataRow dataRow9 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow9["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow9["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                            if (!hashtables4.ContainsKey(num3))
                            {
                                hashtables4.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (long key4 in hashtables4.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key4), empty3, Convert.ToInt32(hashtables4[key4]), JobStatus, EstimateItemID);
                        }
                        hashtables4.Clear();
                        foreach (DataRow row10 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row10["PaperID"]);
                            empty3 = "I";
                            row10["InventoryCode"].ToString();
                            row10["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row10["Quantity"]);
                            Convert.ToDecimal(row10["PackedIn"]);
                            Convert.ToInt64(row10["EstimateLithobookletItemID"]);
                            Convert.ToDecimal(row10["PaperUnitPrice"]);
                            int num14 = Convert.ToInt32(row10["NoOfSignatures"]);
                            num6 = Convert.ToDecimal(row10["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row10["RunningSpoilage"]);
                            Convert.ToDecimal(row10["PaperMarkup"]);
                            num9 = Convert.ToDecimal(row10["InvSheets"]);
                            decimal printSheetCalulation1 = new decimal(0);
                            printSheetCalulation1 = EstimatesBasePage.GetPrintSheetCalulation(num4, new decimal(0), num6, num7, Convert.ToDecimal(num14), "booklet", new decimal(0), "", out num8);
                            printSheetCalulation = EstimateBasePage.NoOfSheetsReturnByFirstTrim(Convert.ToDecimal(row10["height"]), Convert.ToDecimal(row10["width"]), Convert.ToDecimal(row10["SheetHeight"]), Convert.ToDecimal(row10["SheetWidth"]), num5.ToString(), printSheetCalulation1);
                            if (!hashtables4.ContainsKey(num3))
                            {
                                hashtables4.Add(num3, Convert.ToInt32(num9));
                            }
                            else
                            {
                                hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num9);
                            }
                        }
                        foreach (long key5 in hashtables4.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key5), empty3, Convert.ToInt32(hashtables4[key5]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str3, "Q", true) != 0)
                    {
                        if (string.Compare(str3, "X", true) != 0)
                        {
                            continue;
                        }
                        string str11 = string.Format("<script type='text/javascript' language='javascript'>alert('{0}')</script>", "hi");
                        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "PopupScript", str11);
                        bool flag4 = true;
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow dataRow10 in dataSet.Tables[0].Rows)
                        {
                            long num15 = Convert.ToInt64(dataRow10["PriceCatalogueID"]);
                            long num16 = Convert.ToInt64(dataRow10["OrderItemId"]);
                            num4 = Convert.ToInt32(dataRow10["Quantity"]);
                            decimal num17 = Convert.ToDecimal(dataRow10["Price"]);
                            bool flag5 = Convert.ToBoolean(dataRow10["IsStockReplenish"]);
                            bool flag6 = Convert.ToBoolean(dataRow10["IsStockReplenished"]);
                            BaseClass baseClass1 = new BaseClass();
                            string str12 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                            string str13 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                            string str14 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                            string str15 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                            string str16 = baseClass1.Return_StockManagementSettings("SC_IfJobCancelled");
                            string str17 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                            if (flag5.ToString().ToLower() == "true" && flag6.ToString().ToLower() != "true")
                            {
                                flag4 = false;
                            }
                            if (SummaryClass.IsStockCancel)
                            {
                                if (!(JobStatus == "cancelled-stock") && !(str16 == "a"))
                                {
                                    continue;
                                }
                                foreach (DataRow row11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (row11["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "self", EstimateItemID, "Job", (long)UserID, str16);
                                    }
                                    else if (row11["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num15, "other", EstimateItemID, "Job", (long)UserID, str16);
                                    }
                                    else if (row11["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row11["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str16);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str16);
                                    }
                                }
                            }
                            else
                            {
                                if (!(flag5.ToString().ToLower() != "true") || !(flag4.ToString().ToLower() == "true"))
                                {
                                    continue;
                                }
                                if (str12 == "j" || str17 == "j")
                                {
                                    string str18 = baseClass1.Return_StockManagementSettings("SA_EstoreJobStatusID");
                                    string str19 = baseClass1.Return_StockManagementSettings("SA_JobStatusID");
                                    if (str18 == num.ToString() || str19 == num.ToString())
                                    {
                                        foreach (DataRow dataRow11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                        {
                                            if (dataRow11["DrawStockFrom"].ToString().ToLower() == "s")
                                            {
                                                empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                            }
                                            else if (dataRow11["DrawStockFrom"].ToString().ToLower() == "o")
                                            {
                                                empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                            }
                                            else if (dataRow11["DrawStockFrom"].ToString().ToLower() != "a")
                                            {
                                                if (dataRow11["DrawStockFrom"].ToString().ToLower() != "m")
                                                {
                                                    continue;
                                                }
                                                foreach (DataRow row12 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                                {
                                                    empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row12["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                                }
                                            }
                                            else
                                            {
                                                empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                            }
                                        }
                                    }
                                }
                                else if (str12 == "c" || str12 == "p")
                                {
                                    foreach (DataRow dataRow12 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        if (dataRow12["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow12["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow12["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow12["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            foreach (DataRow row13 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                            {
                                                empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row13["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                            }
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                        }
                                    }
                                }
                                if (str15 == "e")
                                {
                                    foreach (DataRow dataRow13 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        if (dataRow13["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (dataRow13["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (dataRow13["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow13["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                    }
                                }
                                else if (str15 != "j")
                                {
                                    if (!(str15 == "c") || string.Compare(str2, "invoice", true) != 0)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow row14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        if (row14["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (row14["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (row14["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row14["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                    }
                                }
                                else
                                {
                                    string str20 = baseClass1.Return_StockManagementSettings("SR_JobStatusID");
                                    bool flag7 = false;
                                    if (str20 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                    {
                                        flag7 = true;
                                    }
                                    if (!flag7)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        this.Session["StockItemType"] = "X";
                                        this.Session["ALC_OrderItemId"] = num16.ToString();
                                        if (dataRow14["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (dataRow14["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else if (dataRow14["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow14["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                        }
                                    }
                                }
                            }
                        }
                        this.Session["StockItemType"] = "X";
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                        foreach (DataRow row15 in dataSet.Tables[0].Rows)
                        {
                            if (!this.isMainitem)
                            {
                                continue;
                            }
                            num3 = Convert.ToInt64(row15["PaperID"]);
                            empty3 = "I";
                            row15["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row15["ItemDescription"].ToString());
                            num4 = Convert.ToInt32(row15["Quantity"]);
                            Convert.ToDecimal(row15["PackedIn"]);
                            Convert.ToInt64(row15["QuickQuoteID"]);
                            Convert.ToDecimal(row15["PaperUnitPrice"]);
                            num5 = Convert.ToInt32(row15["PrintLayoutValue"]);
                            num6 = Convert.ToDecimal(row15["SetupSpoilage"]);
                            num7 = Convert.ToDecimal(row15["RunningSpoilage"]);
                            printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num4, num5, num6, num7, new decimal(0), "singleitem", new decimal(0), "", out num8);
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(printSheetCalulation));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(printSheetCalulation);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(printSheetCalulation), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                }
                else
                {
                    if (EstimateItemID != Convert.ToInt64(row["EstimateItemID"]) || !this.FrmJobAdd && !this.IsJobCopied)
                    {
                        continue;
                    }
                    int num18 = Convert.ToInt32(row["QtyNumber"]);
                    string str21 = row["ItemType"].ToString();
                    long num19 = (long)0;
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    int num20 = 0;
                    EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                    int num21 = 0;
                    decimal num22 = new decimal(0);
                    decimal num23 = new decimal(0);
                    decimal num24 = new decimal(0);
                    decimal printSheetCalulation2 = new decimal(0);
                    string empty7 = string.Empty;
                    decimal num25 = new decimal(0);
                    str1 = row["JobNumber"].ToString();
                    num = Convert.ToInt32(row["StatusID"].ToString());
                    empty2 = row["InvoiceNumber"].ToString();
                    if (string.Compare(str21, "S", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow dataRow15 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(dataRow15["PaperID"]);
                            empty5 = "I";
                            dataRow15["InventoryCode"].ToString();
                            num25 = Convert.ToDecimal(dataRow15["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num25), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "P", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow row16 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row16["PaperID"]);
                            empty5 = "I";
                            row16["InventoryCode"].ToString();
                            row16["inventoryname"].ToString();
                            num20 = Convert.ToInt32(row16["Quantity"]);
                            Convert.ToDecimal(row16["PackedIn"]);
                            Convert.ToInt64(row16["EstimatePadItemID"]);
                            Convert.ToDecimal(row16["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(row16["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(row16["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row16["RunningSpoilage"]);
                            Convert.ToDecimal(row16["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row16["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num25), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "L", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow dataRow16 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(dataRow16["PaperID"]);
                            empty5 = "I";
                            dataRow16["InventoryCode"].ToString();
                            dataRow16["inventoryname"].ToString();
                            num20 = Convert.ToInt32(dataRow16["Quantity"]);
                            Convert.ToDecimal(dataRow16["PackedIn"]);
                            Convert.ToInt64(dataRow16["EstimateLargeItemID"]);
                            Convert.ToDecimal(dataRow16["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(dataRow16["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(dataRow16["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(dataRow16["RunningSpoilage"]);
                            Convert.ToDecimal(dataRow16["PaperMarkup"]);
                            Convert.ToDecimal(dataRow16["JobHeight"]);
                            Convert.ToDecimal(dataRow16["JobWidth"]);
                            Convert.ToDecimal(dataRow16["SheetHeight"]);
                            Convert.ToDecimal(dataRow16["SheetWidth"]);
                            Convert.ToDecimal(dataRow16["GutterHorizontal"]);
                            Convert.ToDecimal(dataRow16["GutterVertical"]);
                            Convert.ToDecimal(dataRow16["Row"]);
                            Convert.ToDecimal(dataRow16["Col"]);
                            dataRow16["PrintLayout"].ToString();
                            dataRow16["PressPaperType"].ToString();
                            num25 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow16["InvSheets"].ToString()), 0, "", false, false, true));
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, num25);
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToDecimal(num25), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "B", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        Hashtable hashtables5 = new Hashtable();
                        foreach (DataRow row17 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row17["PaperID"]);
                            empty5 = "I";
                            row17["InventoryCode"].ToString();
                            row17["inventoryname"].ToString();
                            num20 = Convert.ToInt32(row17["Quantity"]);
                            Convert.ToDecimal(row17["PackedIn"]);
                            Convert.ToInt64(row17["EstimateBookletItemID"]);
                            Convert.ToDecimal(row17["PaperUnitPrice"]);
                            Convert.ToDecimal(row17["NoOfSignatures"]);
                            num22 = Convert.ToDecimal(row17["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row17["RunningSpoilage"]);
                            Convert.ToDecimal(row17["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row17["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            if (!hashtables5.ContainsKey(num19))
                            {
                                hashtables5.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables5[num19] = Convert.ToInt32(hashtables5[num19].ToString()) + Convert.ToInt32(num25);
                            }
                        }
                        foreach (long key6 in hashtables5.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key6), empty5, Convert.ToInt32(hashtables5[key6]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "W", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        Hashtable hashtables6 = new Hashtable();
                        foreach (DataRow dataRow17 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(dataRow17["WarehouseTypeID"]);
                            empty5 = dataRow17["WarehouseType"].ToString();
                            num20 = Convert.ToInt32(dataRow17["Quantity"]);
                            if (Convert.ToInt32(dataRow17["IsDeleted"]) != 0)
                            {
                                continue;
                            }
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(num20);
                            }
                            if (!hashtables6.ContainsKey(num19))
                            {
                                hashtables6.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables6[num19] = Convert.ToInt32(hashtables6[num19].ToString()) + Convert.ToInt32(num20);
                            }
                            num1 = num1 + this.Select_Quantity_History_For_Inventory(EstimateItemID);
                        }
                        if (hashtables6.Count > 0)
                        {
                            foreach (long key7 in hashtables6.Keys)
                            {
                                EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key7), empty5, Convert.ToInt32(hashtables6[key7]), JobStatus, EstimateItemID);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "O", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "C", true) == 0)
                    {
                        bool flag8 = true;
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow row18 in dataSet.Tables[0].Rows)
                        {
                            long num26 = Convert.ToInt64(row18["PriceCatalogueID"]);
                            bool flag9 = Convert.ToBoolean(row18["IsStockReplenish"]);
                            bool flag10 = Convert.ToBoolean(row18["IsStockReplenished"]);
                            num20 = Convert.ToInt32(row18["Quantity"]);
                            decimal num27 = Convert.ToDecimal(row18["Price"]);
                            BaseClass baseClass2 = new BaseClass();
                            string str22 = baseClass2.Return_StockManagementSettings("SA_EprintMISJobs");
                            string str23 = baseClass2.Return_StockManagementSettings("SR_StockReductionMethod");
                            string str24 = baseClass2.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                            string str25 = baseClass2.Return_StockManagementSettings("SR_WhenStockReduced");
                            string str26 = baseClass2.Return_StockManagementSettings("SC_IfJobCancelled");
                            if (flag9.ToString().ToLower() == "true" && flag10.ToString().ToLower() != "true")
                            {
                                flag8 = false;
                            }
                            if (SummaryClass.IsStockCancel)
                            {
                                if (!(JobStatus == "cancelled-stock") && !(str26 == "a"))
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow18 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                {
                                    if (dataRow18["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass2.StockCancellationProcess((long)CompanyID, num26, (long)0, "self", EstimateItemID, "Job", (long)UserID, str26);
                                    }
                                    else if (dataRow18["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass2.StockCancellationProcess((long)CompanyID, (long)0, num26, "other", EstimateItemID, "Job", (long)UserID, str26);
                                    }
                                    else if (dataRow18["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow18["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass2.StockCancellationProcess((long)CompanyID, num26, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str26);
                                    }
                                    else
                                    {
                                        empty = baseClass2.StockCancellationProcess((long)CompanyID, num26, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str26);
                                    }
                                }
                            }
                            else
                            {
                                if (!(flag9.ToString().ToLower() != "true") || !(flag8.ToString().ToLower() == "true"))
                                {
                                    continue;
                                }
                                if (str22 == "e")
                                {
                                    foreach (DataRow row19 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                    {
                                        if (row19["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass2.StockAllocationProcess((long)CompanyID, num26, (long)0, num20, str23, "self", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else if (row19["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass2.StockAllocation_Others((long)CompanyID, num26, num20, str23, Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else if (row19["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row19["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass2.StockAllocationProcess((long)CompanyID, num26, (long)0, num20, str23, "multiple", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else
                                        {
                                            empty = baseClass2.StockAllocationForAdditionalOption((long)CompanyID, num26, num20, str23, "additional option", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                    }
                                }
                                else if (str22 == "j" && baseClass2.Return_StockManagementSettings("SA_JobStatusID") == num.ToString())
                                {
                                    foreach (DataRow dataRow19 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                    {
                                        if (dataRow19["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass2.StockAllocationProcess((long)CompanyID, num26, (long)0, num20, str23, "self", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else if (dataRow19["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass2.StockAllocation_Others((long)CompanyID, num26, num20, str23, Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else if (dataRow19["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow19["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass2.StockAllocationProcess((long)CompanyID, num26, (long)0, num20, str23, "multiple", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                        else
                                        {
                                            empty = baseClass2.StockAllocationForAdditionalOption((long)CompanyID, num26, num20, str23, "additional option", Convert.ToBoolean(str24), EstimateItemID, "Job", num27, (long)UserID);
                                        }
                                    }
                                }
                                if (str25 == "e")
                                {
                                    foreach (DataRow row20 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                    {
                                        if (row20["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (row20["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, (long)0, num26, "other", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (row20["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row20["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else
                                        {
                                            empty = baseClass2.StockReductionProcessForAdditionalOption((long)CompanyID, num26, "additional option", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                    }
                                }
                                else if (str25 != "j")
                                {
                                    if (!(str25 == "c") || string.Compare(str2, "invoice", true) != 0)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow20 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                    {
                                        if (dataRow20["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (dataRow20["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, (long)0, num26, "other", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (dataRow20["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow20["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else
                                        {
                                            empty = baseClass2.StockReductionProcessForAdditionalOption((long)CompanyID, num26, "additional option", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                    }
                                }
                                else
                                {
                                    string str27 = baseClass2.Return_StockManagementSettings("SR_JobStatusID");
                                    bool flag11 = false;
                                    if (str27 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                    {
                                        flag11 = true;
                                    }
                                    if (!flag11)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow row21 in baseClass2.ProductStockType_Select((long)CompanyID, num26).Rows)
                                    {
                                        this.Session["StockItemType"] = "C";
                                        if (row21["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (row21["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, (long)0, num26, "other", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else if (row21["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row21["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass2.StockReductionProcess((long)CompanyID, num26, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                        else
                                        {
                                            empty = baseClass2.StockReductionProcessForAdditionalOption((long)CompanyID, num26, "additional option", num20, EstimateItemID, "Job", (long)UserID, num27);
                                        }
                                    }
                                }
                            }
                        }
                        this.Session["StockItemType"] = "C";
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "F", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        dataTable1 = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                        foreach (DataRow dataRow21 in dataTable1.Rows)
                        {
                            num19 = Convert.ToInt64(dataRow21["PlateID"]);
                            empty5 = "I";
                            num20 = Convert.ToInt32(dataRow21["Noofplates"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(num20);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num20), JobStatus, EstimateItemID);
                        }
                        foreach (DataRow row22 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row22["PaperID"]);
                            empty5 = "I";
                            row22["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row22["ItemDescription"].ToString());
                            num20 = Convert.ToInt32(row22["Quantity"]);
                            Convert.ToDecimal(row22["PackedIn"]);
                            Convert.ToInt64(row22["EstLithoItemID"]);
                            Convert.ToDecimal(row22["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(row22["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(row22["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row22["RunningSpoilage"]);
                            Convert.ToDecimal(row22["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row22["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num25), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "D", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        dataTable1 = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                        foreach (DataRow dataRow22 in dataTable1.Rows)
                        {
                            num19 = Convert.ToInt64(dataRow22["PlateID"]);
                            empty5 = "I";
                            num20 = Convert.ToInt32(dataRow22["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num20), JobStatus, EstimateItemID);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(num20);
                            }
                        }
                        foreach (DataRow row23 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row23["PaperID"]);
                            empty5 = "I";
                            row23["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row23["ItemDescription"].ToString());
                            num20 = Convert.ToInt32(row23["Quantity"]);
                            Convert.ToDecimal(row23["PackedIn"]);
                            Convert.ToInt64(row23["EstimateLithoPadItemID"]);
                            Convert.ToDecimal(row23["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(row23["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(row23["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row23["RunningSpoilage"]);
                            Convert.ToDecimal(row23["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row23["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num25), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "N", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                        Hashtable hashtables7 = new Hashtable();
                        foreach (DataRow dataRow23 in dataTable1.Rows)
                        {
                            num19 = Convert.ToInt64(dataRow23["PlateID"]);
                            empty5 = "I";
                            num20 = Convert.ToInt32(dataRow23["Noofplates"]);
                            if (!hashtables7.ContainsKey(num19))
                            {
                                hashtables7.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables7[num19] = Convert.ToInt32(hashtables7[num19].ToString()) + Convert.ToInt32(num20);
                            }
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(num20);
                            }
                        }
                        foreach (long key8 in hashtables7.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key8), empty5, Convert.ToInt32(hashtables7[key8]), JobStatus, EstimateItemID);
                        }
                        hashtables7.Clear();
                        foreach (DataRow row24 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row24["PaperID"]);
                            empty5 = "I";
                            row24["InventoryCode"].ToString();
                            row24["inventoryname"].ToString();
                            num20 = Convert.ToInt32(row24["Quantity"]);
                            Convert.ToDecimal(row24["PackedIn"]);
                            Convert.ToInt64(row24["EstimateLithoNCRItemID"]);
                            Convert.ToDecimal(row24["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(row24["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(row24["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row24["RunningSpoilage"]);
                            decimal num28 = Convert.ToDecimal(row24["NcrPartsPerSet"].ToString());
                            decimal num29 = Convert.ToDecimal(row24["NcrSetsPerPad"].ToString());
                            Convert.ToDecimal(row24["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row24["InvSheets"]);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToDecimal(hashtables[num19].ToString()) + Convert.ToDecimal(num25);
                            }
                            if (!hashtables7.ContainsKey(num19))
                            {
                                hashtables7.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables7[num19] = Convert.ToInt32(hashtables7[num19].ToString()) + Convert.ToInt32(num25);
                            }
                        }
                        foreach (long key9 in hashtables7.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key9), empty5, Convert.ToInt32(hashtables7[key9]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "K", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        dataTable1 = EstimatesBasePage.lithobooklet_item_select(CompanyID, EstimateItemID);
                        Hashtable hashtables8 = new Hashtable();
                        foreach (DataRow dataRow24 in dataTable1.Rows)
                        {
                            num19 = Convert.ToInt64(dataRow24["PlateID"]);
                            empty5 = "I";
                            num20 = Convert.ToInt32(dataRow24["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(num20), JobStatus, EstimateItemID);
                            if (!hashtables8.ContainsKey(num19))
                            {
                                hashtables8.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables8[num19] = Convert.ToInt32(hashtables8[num19].ToString()) + Convert.ToInt32(num20);
                            }
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(num20));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(num20);
                            }
                        }
                        foreach (long key10 in hashtables8.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key10), empty5, Convert.ToInt32(hashtables8[key10]), JobStatus, EstimateItemID);
                        }
                        hashtables8.Clear();
                        foreach (DataRow row25 in dataSet.Tables[0].Rows)
                        {
                            num19 = Convert.ToInt64(row25["PaperID"]);
                            empty5 = "I";
                            row25["InventoryCode"].ToString();
                            row25["inventoryname"].ToString();
                            num20 = Convert.ToInt32(row25["Quantity"]);
                            Convert.ToDecimal(row25["PackedIn"]);
                            Convert.ToInt64(row25["EstimateLithobookletItemID"]);
                            Convert.ToDecimal(row25["PaperUnitPrice"]);
                            int num30 = Convert.ToInt32(row25["NoOfSignatures"]);
                            num22 = Convert.ToDecimal(row25["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row25["RunningSpoilage"]);
                            Convert.ToDecimal(row25["PaperMarkup"]);
                            num25 = Convert.ToDecimal(row25["InvSheets"]);
                            decimal printSheetCalulation3 = new decimal(0);
                            printSheetCalulation3 = EstimatesBasePage.GetPrintSheetCalulation(num20, new decimal(0), num22, num23, Convert.ToDecimal(num30), "booklet", new decimal(0), "", out num24);
                            printSheetCalulation2 = EstimateBasePage.NoOfSheetsReturnByFirstTrim(Convert.ToDecimal(row25["height"]), Convert.ToDecimal(row25["width"]), Convert.ToDecimal(row25["SheetHeight"]), Convert.ToDecimal(row25["SheetWidth"]), num21.ToString(), printSheetCalulation3);
                            if (!hashtables8.ContainsKey(num19))
                            {
                                hashtables8.Add(num19, Convert.ToInt32(num25));
                            }
                            else
                            {
                                hashtables8[num19] = Convert.ToInt32(hashtables8[num19].ToString()) + Convert.ToInt32(num25);
                            }
                        }
                        foreach (long key11 in hashtables8.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key11), empty5, Convert.ToInt32(hashtables8[key11]), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else if (string.Compare(str21, "Q", true) != 0)
                    {
                        if (string.Compare(str21, "X", true) != 0)
                        {
                            continue;
                        }
                        string str28 = string.Format("<script type='text/javascript' language='javascript'>alert('{0}')</script>", "hi");
                        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "PopupScript", str28);
                        bool flag12 = true;
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow dataRow25 in dataSet.Tables[0].Rows)
                        {
                            long num31 = Convert.ToInt64(dataRow25["PriceCatalogueID"]);
                            long num32 = Convert.ToInt64(dataRow25["OrderItemId"]);
                            num20 = Convert.ToInt32(dataRow25["Quantity"]);
                            decimal num33 = Convert.ToDecimal(dataRow25["Price"]);
                            bool flag13 = Convert.ToBoolean(dataRow25["IsStockReplenish"]);
                            bool flag14 = Convert.ToBoolean(dataRow25["IsStockReplenished"]);
                            BaseClass baseClass3 = new BaseClass();
                            string str29 = baseClass3.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                            string str30 = baseClass3.Return_StockManagementSettings("SR_StockReductionMethod");
                            string str31 = baseClass3.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                            string str32 = baseClass3.Return_StockManagementSettings("SR_WhenStockReduced");
                            string str33 = baseClass3.Return_StockManagementSettings("SC_IfJobCancelled");
                            string str34 = baseClass3.Return_StockManagementSettings("SA_EprintMISJobs");
                            if (flag13.ToString().ToLower() == "true" && flag14.ToString().ToLower() != "true")
                            {
                                flag12 = false;
                            }
                            if (SummaryClass.IsStockCancel)
                            {
                                if (!(JobStatus == "cancelled-stock") && !(str33 == "a"))
                                {
                                    continue;
                                }
                                foreach (DataRow row26 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                {
                                    if (row26["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass3.StockCancellationProcess((long)CompanyID, num31, (long)0, "self", EstimateItemID, "Job", (long)UserID, str33);
                                    }
                                    else if (row26["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass3.StockCancellationProcess((long)CompanyID, (long)0, num31, "other", EstimateItemID, "Job", (long)UserID, str33);
                                    }
                                    else if (row26["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row26["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass3.StockCancellationProcess((long)CompanyID, num31, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str33);
                                    }
                                    else
                                    {
                                        empty = baseClass3.StockCancellationProcess((long)CompanyID, num31, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str33);
                                    }
                                }
                            }
                            else
                            {
                                if (!(flag13.ToString().ToLower() != "true") || !(flag12.ToString().ToLower() == "true"))
                                {
                                    continue;
                                }
                                if (str29 == "j" || str34 == "j")
                                {
                                    string str35 = baseClass3.Return_StockManagementSettings("SA_EstoreJobStatusID");
                                    string str36 = baseClass3.Return_StockManagementSettings("SA_JobStatusID");
                                    if (str35 == num.ToString() || str36 == num.ToString())
                                    {
                                        foreach (DataRow dataRow26 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                        {
                                            if (dataRow26["DrawStockFrom"].ToString().ToLower() == "s")
                                            {
                                                empty = baseClass3.StockAllocationProcess((long)CompanyID, num31, (long)0, num20, str30, "self", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                            }
                                            else if (dataRow26["DrawStockFrom"].ToString().ToLower() == "o")
                                            {
                                                empty = baseClass3.StockAllocation_Others((long)CompanyID, num31, num20, str30, Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                            }
                                            else if (dataRow26["DrawStockFrom"].ToString().ToLower() != "a")
                                            {
                                                if (dataRow26["DrawStockFrom"].ToString().ToLower() != "m")
                                                {
                                                    continue;
                                                }
                                                foreach (DataRow row27 in PurchaseBasePage.OtherMultipleProductDetails_Select(num31, num20, true).Rows)
                                                {
                                                    empty = baseClass3.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row27["KitItemID"].ToString()), num31, num20, str30, "multiple", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                                }
                                            }
                                            else
                                            {
                                                empty = baseClass3.StockAllocationForAdditionalOptionEstore((long)CompanyID, num31, num20, str30, "additional option", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID, (long)0, num32);
                                            }
                                        }
                                    }
                                }
                                else if (str29 == "c" || str29 == "p")
                                {
                                    foreach (DataRow dataRow27 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                    {
                                        if (dataRow27["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass3.StockAllocationProcess((long)CompanyID, num31, (long)0, num20, str30, "self", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                        }
                                        else if (dataRow27["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass3.StockAllocation_Others((long)CompanyID, num31, num20, str30, Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                        }
                                        else if (dataRow27["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow27["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            foreach (DataRow row28 in PurchaseBasePage.OtherMultipleProductDetails_Select(num31, num20, true).Rows)
                                            {
                                                empty = baseClass3.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row28["KitItemID"].ToString()), num31, num20, str30, "multiple", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID);
                                            }
                                        }
                                        else
                                        {
                                            empty = baseClass3.StockAllocationForAdditionalOptionEstore((long)CompanyID, num31, num20, str30, "additional option", Convert.ToBoolean(str31), EstimateItemID, "Job", num33, (long)UserID, (long)0, num32);
                                        }
                                    }
                                }
                                if (str32 == "e")
                                {
                                    foreach (DataRow dataRow28 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                    {
                                        if (dataRow28["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (dataRow28["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, (long)0, num31, "other", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (dataRow28["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow28["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else
                                        {
                                            empty = baseClass3.StockReductionProcessForAdditionalOption((long)CompanyID, num31, "additional option", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                    }
                                }
                                else if (str32 != "j")
                                {
                                    if (!(str32 == "c") || string.Compare(str2, "invoice", true) != 0)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow row29 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                    {
                                        if (row29["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (row29["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, (long)0, num31, "other", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (row29["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row29["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else
                                        {
                                            empty = baseClass3.StockReductionProcessForAdditionalOption((long)CompanyID, num31, "additional option", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                    }
                                }
                                else
                                {
                                    string str37 = baseClass3.Return_StockManagementSettings("SR_JobStatusID");
                                    bool flag15 = false;
                                    if (str37 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                    {
                                        flag15 = true;
                                    }
                                    if (!flag15)
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow29 in baseClass3.ProductStockType_Select((long)CompanyID, num31).Rows)
                                    {
                                        this.Session["StockItemType"] = "X";
                                        this.Session["ALC_OrderItemId"] = num32.ToString();
                                        if (dataRow29["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "self", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (dataRow29["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, (long)0, num31, "other", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else if (dataRow29["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow29["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            empty = baseClass3.StockReductionProcess((long)CompanyID, num31, (long)0, "multiple", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                        else
                                        {
                                            empty = baseClass3.StockReductionProcessForAdditionalOption((long)CompanyID, num31, "additional option", num20, EstimateItemID, "Job", (long)UserID, num33);
                                        }
                                    }
                                }
                            }
                        }
                        this.Session["StockItemType"] = "X";
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                    else
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num18, str21);
                        foreach (DataRow row30 in dataSet.Tables[0].Rows)
                        {
                            if (!this.isMainitem)
                            {
                                continue;
                            }
                            num19 = Convert.ToInt64(row30["PaperID"]);
                            empty5 = "I";
                            row30["InventoryCode"].ToString();
                            SummaryClass.Split_ItemDescription_forpurchaseorder(row30["ItemDescription"].ToString());
                            num20 = Convert.ToInt32(row30["Quantity"]);
                            Convert.ToDecimal(row30["PackedIn"]);
                            Convert.ToInt64(row30["QuickQuoteID"]);
                            Convert.ToDecimal(row30["PaperUnitPrice"]);
                            num21 = Convert.ToInt32(row30["PrintLayoutValue"]);
                            num22 = Convert.ToDecimal(row30["SetupSpoilage"]);
                            num23 = Convert.ToDecimal(row30["RunningSpoilage"]);
                            printSheetCalulation2 = EstimatesBasePage.GetPrintSheetCalulation(num20, num21, num22, num23, new decimal(0), "singleitem", new decimal(0), "", out num24);
                            if (!hashtables.ContainsKey(num19))
                            {
                                hashtables.Add(num19, Convert.ToInt32(printSheetCalulation2));
                            }
                            else
                            {
                                hashtables[num19] = Convert.ToInt32(hashtables[num19].ToString()) + Convert.ToInt32(printSheetCalulation2);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num19, empty5, Convert.ToInt32(printSheetCalulation2), JobStatus, EstimateItemID);
                        }
                        this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                    }
                }
            }
            if (hashtables.Count > 0)
            {
                foreach (long key12 in hashtables.Keys)
                {
                    string empty8 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key12));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow30 in dataTable2.Rows)
                        {
                            empty8 = dataRow30["FinalQuantity"].ToString();
                        }
                    }
                    if (this.isrerun)
                    {
                        if (JobStatus == "progressed" && empty1.ToLower() != "e" && empty1.ToLower() != num.ToString() && empty1.ToLower() != "i")
                        {
                            long num34 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num34, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        if (JobStatus != "completed")
                        {
                            continue;
                        }
                        long num35 = Convert.ToInt64(key12);
                        estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num35, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                    }
                    else if (this.FrmJobAdd)
                    {
                        if (JobStatus == "completed")
                        {
                            if (empty8 == null || empty8 == "")
                            {
                                empty8 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num36 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num36, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else if (JobStatus != "cancelled")
                        {
                            if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i"))
                            {
                                continue;
                            }
                            long num37 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num37, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key12]), "h", new decimal(0));
                        }
                        else
                        {
                            if (empty8 == null || empty8 == "")
                            {
                                empty8 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num38 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock restored due to cancellation of job :<a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num38, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                        }
                    }
                    else if (JobStatus == "completed")
                    {
                        if (empty8 == null || empty8 == "")
                        {
                            empty8 = "0";
                        }
                        if (str2 == string.Empty)
                        {
                            long num39 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num39, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else if (str2.ToLower() != "invoice")
                        {
                            if (str2.ToLower() != "inv")
                            {
                                continue;
                            }
                            long num40 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock altered: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num40, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else
                        {
                            long num41 = Convert.ToInt64(key12);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num41, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                    }
                    else if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i") || !(str2.ToLower() != "invoice") || !(str2.ToLower() != "inv"))
                        {
                            continue;
                        }
                        long num42 = Convert.ToInt64(key12);
                        estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num42, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key12]), "h", new decimal(0));
                    }
                    else
                    {
                        if (empty8 == null || empty8 == "")
                        {
                            empty8 = "0";
                        }
                        if (str2 != string.Empty)
                        {
                            continue;
                        }
                        long num43 = Convert.ToInt64(key12);
                        estimateID = new object[] { "Stock restored due to deletion of item in job : <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num43, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                    }
                }
            }
            return empty;
        }

        public string Call_Inventory_Adjustment_Order(string JobStatus, long EstimateID, int CompanyID, long EstimateItemID, int UserID)
        {
            object[] estimateID;
            string str = global.sitePath();
            string empty = string.Empty;
            Hashtable hashtables = new Hashtable();
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            string empty1 = string.Empty;
            empty1 = _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            DataTable dataTable1 = new DataTable();
            dataTable = EstimateBasePage.job_card_info_select_by_OrderID(CompanyID, EstimateID);
            string str1 = string.Empty;
            int num = 0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num1 = 0;
            if (JobStatus.ToLower().Contains("progressed-invoice"))
            {
                JobStatus = "progressed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("archive"))
            {
                JobStatus = "archive";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-jobdelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-invoicedelete"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-invoice"))
            {
                JobStatus = "completed";
                str2 = "invoice";
            }
            if (JobStatus.ToLower().Contains("progressed-rerun"))
            {
                JobStatus = "progressed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("completed-rerun"))
            {
                JobStatus = "completed";
                this.isrerun = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-status"))
            {
                JobStatus = "cancelled";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("completed-status"))
            {
                this.FrmJobAdd = true;
                JobStatus = "completed";
            }
            if (JobStatus.ToLower().Contains("progressed-status"))
            {
                JobStatus = "progressed";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("progressed-inv-rerun"))
            {
                JobStatus = "progressed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("completed-inv-rerun"))
            {
                JobStatus = "completed";
                str2 = "inv";
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-status"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (JobStatus.ToLower().Contains("cancelled-stock-delete"))
            {
                JobStatus = "cancelled-stock";
                this.FrmJobAdd = true;
            }
            if (!JobStatus.ToLower().Contains("cancelled-stock"))
            {
                SummaryClass.IsStockCancel = false;
            }
            else
            {
                SummaryClass.IsStockCancel = true;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null || row["EstimateItemID"] == null || EstimateItemID != Convert.ToInt64(row["EstimateItemID"]) && !this.FrmJobAdd && !this.IsJobCopied)
                {
                    continue;
                }
                int num2 = Convert.ToInt32(row["QtyNumber"]);
                string str3 = row["ItemType"].ToString();
                long num3 = (long)0;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                int num4 = 0;
                EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                int num5 = 0;
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal printSheetCalulation = new decimal(0);
                string str4 = string.Empty;
                decimal num9 = new decimal(0);
                str1 = row["JobNumber"].ToString();
                num = Convert.ToInt32(row["StatusID"].ToString());
                empty2 = row["InvoiceNumber"].ToString();
                if (string.Compare(str3, "S", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow["PaperID"]);
                        empty3 = "I";
                        dataRow["InventoryCode"].ToString();
                        num9 = Convert.ToDecimal(dataRow["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "P", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row1["PaperID"]);
                        empty3 = "I";
                        row1["InventoryCode"].ToString();
                        row1["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row1["Quantity"]);
                        Convert.ToDecimal(row1["PackedIn"]);
                        Convert.ToInt64(row1["EstimatePadItemID"]);
                        Convert.ToDecimal(row1["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row1["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row1["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row1["RunningSpoilage"]);
                        Convert.ToDecimal(row1["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row1["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "L", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow1["PaperID"]);
                        empty3 = "I";
                        dataRow1["InventoryCode"].ToString();
                        dataRow1["inventoryname"].ToString();
                        num4 = Convert.ToInt32(dataRow1["Quantity"]);
                        Convert.ToDecimal(dataRow1["PackedIn"]);
                        Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                        Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
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
                        num9 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, num9);
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToDecimal(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "B", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    Hashtable hashtables1 = new Hashtable();
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row2["PaperID"]);
                        empty3 = "I";
                        row2["InventoryCode"].ToString();
                        row2["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row2["Quantity"]);
                        Convert.ToDecimal(row2["PackedIn"]);
                        Convert.ToInt64(row2["EstimateBookletItemID"]);
                        Convert.ToDecimal(row2["PaperUnitPrice"]);
                        Convert.ToDecimal(row2["NoOfSignatures"]);
                        num6 = Convert.ToDecimal(row2["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row2["RunningSpoilage"]);
                        Convert.ToDecimal(row2["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row2["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (!hashtables1.ContainsKey(num3))
                        {
                            hashtables1.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables1[num3] = Convert.ToInt32(hashtables1[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key in hashtables1.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key), empty3, Convert.ToInt32(hashtables1[key]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "W", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    Hashtable hashtables2 = new Hashtable();
                    foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                        empty3 = dataRow2["WarehouseType"].ToString();
                        num4 = Convert.ToInt32(dataRow2["Quantity"]);
                        if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                        {
                            continue;
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables2.ContainsKey(num3))
                        {
                            hashtables2.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        num1 = num1 + this.Select_Quantity_History_For_Inventory(EstimateItemID);
                    }
                    if (hashtables2.Count > 0)
                    {
                        foreach (long key1 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key1), empty3, Convert.ToInt32(hashtables2[key1]), JobStatus, EstimateItemID);
                        }
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "O", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "C", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num10 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        num4 = Convert.ToInt32(row3["Quantity"]);
                        decimal num11 = Convert.ToDecimal(row3["Price"]);
                        BaseClass baseClass = new BaseClass();
                        string str5 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str6 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str7 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str8 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str9 = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
                        if (SummaryClass.IsStockCancel)
                        {
                            if (!(JobStatus == "cancelled-stock") && !(str9 == "a"))
                            {
                                continue;
                            }
                            foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "self", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, (long)0, num10, "other", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str9);
                                }
                                else
                                {
                                    empty = baseClass.StockCancellationProcess((long)CompanyID, num10, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str9);
                                }
                            }
                        }
                        else
                        {
                            if (str5 == "e")
                            {
                                foreach (DataRow row4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                }
                            }
                            else if (str5 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == num.ToString())
                            {
                                foreach (DataRow dataRow4 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "self", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockAllocation_Others((long)CompanyID, num10, num4, str6, Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockAllocationProcess((long)CompanyID, num10, (long)0, num4, str6, "multiple", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockAllocationForAdditionalOption((long)CompanyID, num10, num4, str6, "additional option", Convert.ToBoolean(str7), EstimateItemID, "Job", num11, (long)UserID);
                                    }
                                }
                            }
                            if (str8 == "e")
                            {
                                foreach (DataRow row5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                            else if (str8 != "j")
                            {
                                if (!(str8 == "c") || string.Compare(str2, "invoice", true) != 0)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow5 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    if (dataRow5["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (dataRow5["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (dataRow5["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow5["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                            else
                            {
                                string str10 = baseClass.Return_StockManagementSettings("SR_JobStatusID");
                                bool flag = false;
                                if (str10 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                {
                                    flag = true;
                                }
                                if (!flag)
                                {
                                    continue;
                                }
                                foreach (DataRow row6 in baseClass.ProductStockType_Select((long)CompanyID, num10).Rows)
                                {
                                    this.Session["StockItemType"] = "C";
                                    if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num10, "other", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass.StockReductionProcess((long)CompanyID, num10, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                    else
                                    {
                                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num10, "additional option", num4, EstimateItemID, "Job", (long)UserID, num11);
                                    }
                                }
                            }
                        }
                    }
                    this.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "F", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow6 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow6["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow6["Noofplates"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                    }
                    foreach (DataRow row7 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row7["PaperID"]);
                        empty3 = "I";
                        row7["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row7["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row7["Quantity"]);
                        Convert.ToDecimal(row7["PackedIn"]);
                        Convert.ToInt64(row7["EstLithoItemID"]);
                        Convert.ToDecimal(row7["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row7["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row7["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row7["RunningSpoilage"]);
                        Convert.ToDecimal(row7["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row7["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "D", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow7 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow7["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow7["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row8["PaperID"]);
                        empty3 = "I";
                        row8["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row8["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row8["Quantity"]);
                        Convert.ToDecimal(row8["PackedIn"]);
                        Convert.ToInt64(row8["EstimateLithoPadItemID"]);
                        Convert.ToDecimal(row8["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row8["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row8["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row8["RunningSpoilage"]);
                        Convert.ToDecimal(row8["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row8["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num9), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "N", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow8 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow8["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow8["Noofplates"]);
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (long key2 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key2), empty3, Convert.ToInt32(hashtables3[key2]), JobStatus, EstimateItemID);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row9 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row9["PaperID"]);
                        empty3 = "I";
                        row9["InventoryCode"].ToString();
                        row9["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row9["Quantity"]);
                        Convert.ToDecimal(row9["PackedIn"]);
                        Convert.ToInt64(row9["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(row9["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row9["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row9["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row9["RunningSpoilage"]);
                        decimal num12 = Convert.ToDecimal(row9["NcrPartsPerSet"].ToString());
                        decimal num13 = Convert.ToDecimal(row9["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(row9["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row9["InvSheets"]);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToDecimal(hashtables[num3].ToString()) + Convert.ToDecimal(num9);
                        }
                        if (!hashtables3.ContainsKey(num3))
                        {
                            hashtables3.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key3 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key3), empty3, Convert.ToInt32(hashtables3[key3]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "K", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(CompanyID, EstimateItemID);
                    Hashtable hashtables4 = new Hashtable();
                    foreach (DataRow dataRow9 in dataTable1.Rows)
                    {
                        num3 = Convert.ToInt64(dataRow9["PlateID"]);
                        empty3 = "I";
                        num4 = Convert.ToInt32(dataRow9["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(num4), JobStatus, EstimateItemID);
                        if (!hashtables4.ContainsKey(num3))
                        {
                            hashtables4.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num4);
                        }
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(num4));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num4);
                        }
                    }
                    foreach (long key4 in hashtables4.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key4), empty3, Convert.ToInt32(hashtables4[key4]), JobStatus, EstimateItemID);
                    }
                    hashtables4.Clear();
                    foreach (DataRow row10 in dataSet.Tables[0].Rows)
                    {
                        num3 = Convert.ToInt64(row10["PaperID"]);
                        empty3 = "I";
                        row10["InventoryCode"].ToString();
                        row10["inventoryname"].ToString();
                        num4 = Convert.ToInt32(row10["Quantity"]);
                        Convert.ToDecimal(row10["PackedIn"]);
                        Convert.ToInt64(row10["EstimateLithobookletItemID"]);
                        Convert.ToDecimal(row10["PaperUnitPrice"]);
                        int num14 = Convert.ToInt32(row10["NoOfSignatures"]);
                        num6 = Convert.ToDecimal(row10["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row10["RunningSpoilage"]);
                        Convert.ToDecimal(row10["PaperMarkup"]);
                        num9 = Convert.ToDecimal(row10["InvSheets"]);
                        decimal printSheetCalulation1 = new decimal(0);
                        printSheetCalulation1 = EstimatesBasePage.GetPrintSheetCalulation(num4, new decimal(0), num6, num7, Convert.ToDecimal(num14), "booklet", new decimal(0), "", out num8);
                        printSheetCalulation = EstimateBasePage.NoOfSheetsReturnByFirstTrim(Convert.ToDecimal(row10["height"]), Convert.ToDecimal(row10["width"]), Convert.ToDecimal(row10["SheetHeight"]), Convert.ToDecimal(row10["SheetWidth"]), num5.ToString(), printSheetCalulation1);
                        if (!hashtables4.ContainsKey(num3))
                        {
                            hashtables4.Add(num3, Convert.ToInt32(num9));
                        }
                        else
                        {
                            hashtables4[num3] = Convert.ToInt32(hashtables4[num3].ToString()) + Convert.ToInt32(num9);
                        }
                    }
                    foreach (long key5 in hashtables4.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, Convert.ToInt64(key5), empty3, Convert.ToInt32(hashtables4[key5]), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else if (string.Compare(str3, "Q", true) != 0)
                {
                    if (string.Compare(str3, "X", true) != 0)
                    {
                        continue;
                    }
                    string str11 = string.Format("<script type='text/javascript' language='javascript'>alert('{0}')</script>", "hi");
                    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "PopupScript", str11);
                    bool flag1 = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow dataRow10 in dataSet.Tables[0].Rows)
                    {
                        long num15 = Convert.ToInt64(dataRow10["PriceCatalogueID"]);
                        long num16 = Convert.ToInt64(dataRow10["OrderItemId"]);
                        num4 = Convert.ToInt32(dataRow10["Quantity"]);
                        decimal num17 = Convert.ToDecimal(dataRow10["Price"]);
                        bool flag2 = Convert.ToBoolean(dataRow10["IsStockReplenish"]);
                        bool flag3 = Convert.ToBoolean(dataRow10["IsStockReplenished"]);
                        BaseClass baseClass1 = new BaseClass();
                        string str12 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                        string str13 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str14 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str15 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        string str16 = baseClass1.Return_StockManagementSettings("SC_IfJobCancelled");
                        string str17 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                        if (flag2.ToString().ToLower() == "true" && flag3.ToString().ToLower() != "true")
                        {
                            flag1 = false;
                        }
                        if (SummaryClass.IsStockCancel)
                        {
                            if (!(JobStatus == "cancelled-stock") && !(str16 == "a"))
                            {
                                continue;
                            }
                            foreach (DataRow row11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                            {
                                if (row11["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "self", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else if (row11["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num15, "other", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else if (row11["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row11["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, str16);
                                }
                                else
                                {
                                    empty = baseClass1.StockCancellationProcess((long)CompanyID, num15, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, str16);
                                }
                            }
                        }
                        else
                        {
                            if (!(flag2.ToString().ToLower() != "true") || !(flag1.ToString().ToLower() == "true"))
                            {
                                continue;
                            }
                            if (str12 == "j" || str17 == "j")
                            {
                                string str18 = baseClass1.Return_StockManagementSettings("SA_EstoreJobStatusID");
                                string str19 = baseClass1.Return_StockManagementSettings("SA_JobStatusID");
                                if (str18 == num.ToString() || str19 == num.ToString())
                                {
                                    foreach (DataRow dataRow11 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                    {
                                        if (dataRow11["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow11["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                        else if (dataRow11["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (dataRow11["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            foreach (DataRow row12 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                            {
                                                empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row12["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                            }
                                        }
                                        else
                                        {
                                            empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                        }
                                    }
                                }
                            }
                            else if (str12 == "c" || str12 == "p")
                            {
                                foreach (DataRow dataRow12 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (dataRow12["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockAllocationProcess((long)CompanyID, num15, (long)0, num4, str13, "self", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                    }
                                    else if (dataRow12["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockAllocation_Others((long)CompanyID, num15, num4, str13, Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                    }
                                    else if (dataRow12["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow12["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow row13 in PurchaseBasePage.OtherMultipleProductDetails_Select(num15, num4, true).Rows)
                                        {
                                            empty = baseClass1.StockAllocationProcess((long)CompanyID, Convert.ToInt64(row13["KitItemID"].ToString()), num15, num4, str13, "multiple", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID);
                                        }
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)CompanyID, num15, num4, str13, "additional option", Convert.ToBoolean(str14), EstimateItemID, "Job", num17, (long)UserID, (long)0, num16);
                                    }
                                }
                            }
                            if (str15 == "e")
                            {
                                foreach (DataRow dataRow13 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (dataRow13["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow13["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow13["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow13["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                            else if (str15 != "j")
                            {
                                if (!(str15 == "c") || string.Compare(str2, "invoice", true) != 0)
                                {
                                    continue;
                                }
                                foreach (DataRow row14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    if (row14["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (row14["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (row14["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row14["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                            else
                            {
                                string str20 = baseClass1.Return_StockManagementSettings("SR_JobStatusID");
                                bool flag4 = false;
                                if (str20 == num.ToString() || string.Compare(str2, "invoice", true) == 0)
                                {
                                    flag4 = true;
                                }
                                if (!flag4)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow14 in baseClass1.ProductStockType_Select((long)CompanyID, num15).Rows)
                                {
                                    this.Session["StockItemType"] = "X";
                                    this.Session["ALC_OrderItemId"] = num16.ToString();
                                    if (dataRow14["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "self", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow14["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num15, "other", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else if (dataRow14["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow14["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num15, (long)0, "multiple", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num15, "additional option", num4, EstimateItemID, "Job", (long)UserID, num17);
                                    }
                                }
                            }
                        }
                    }
                    this.Session["StockItemType"] = "X";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
                else
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, num2, str3);
                    foreach (DataRow row15 in dataSet.Tables[0].Rows)
                    {
                        if (!this.isMainitem)
                        {
                            continue;
                        }
                        num3 = Convert.ToInt64(row15["PaperID"]);
                        empty3 = "I";
                        row15["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row15["ItemDescription"].ToString());
                        num4 = Convert.ToInt32(row15["Quantity"]);
                        Convert.ToDecimal(row15["PackedIn"]);
                        Convert.ToInt64(row15["QuickQuoteID"]);
                        Convert.ToDecimal(row15["PaperUnitPrice"]);
                        num5 = Convert.ToInt32(row15["PrintLayoutValue"]);
                        num6 = Convert.ToDecimal(row15["SetupSpoilage"]);
                        num7 = Convert.ToDecimal(row15["RunningSpoilage"]);
                        printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num4, num5, num6, num7, new decimal(0), "singleitem", new decimal(0), "", out num8);
                        if (!hashtables.ContainsKey(num3))
                        {
                            hashtables.Add(num3, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(printSheetCalulation);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num3, empty3, Convert.ToInt32(printSheetCalulation), JobStatus, EstimateItemID);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str1, num, EstimateID, hashtables, CompanyID, EstimateItemID, JobStatus);
                }
            }
            if (hashtables.Count > 0)
            {
                foreach (long key6 in hashtables.Keys)
                {
                    string empty5 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow15 in dataTable2.Rows)
                        {
                            empty5 = dataRow15["FinalQuantity"].ToString();
                        }
                    }
                    if (this.isrerun)
                    {
                        if (JobStatus == "progressed" && empty1.ToLower() != "e" && empty1.ToLower() != num.ToString() && empty1.ToLower() != "i")
                        {
                            long num18 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num18, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        if (JobStatus != "completed")
                        {
                            continue;
                        }
                        long num19 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock altered for job: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                    }
                    else if (this.FrmJobAdd)
                    {
                        if (JobStatus == "completed")
                        {
                            if (empty5 == null || empty5 == "")
                            {
                                empty5 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num20 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num20, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else if (JobStatus != "cancelled")
                        {
                            if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i"))
                            {
                                continue;
                            }
                            long num21 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num21, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0));
                        }
                        else
                        {
                            if (empty5 == null || empty5 == "")
                            {
                                empty5 = "0";
                            }
                            if (str2 != string.Empty)
                            {
                                continue;
                            }
                            long num22 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock restored due to cancellation of job :<a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num22, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                        }
                    }
                    else if (JobStatus == "completed")
                    {
                        if (empty5 == null || empty5 == "")
                        {
                            empty5 = "0";
                        }
                        if (str2 == string.Empty)
                        {
                            long num23 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num23, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else if (str2.ToLower() != "invoice")
                        {
                            if (str2.ToLower() != "inv")
                            {
                                continue;
                            }
                            long num24 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock altered: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num24, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                        else
                        {
                            long num25 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", str, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", empty2, "</a>" };
                            _commonClass.Insert_Activity_History_For_Inventory(num25, string.Concat(estimateID), UserID, new decimal(0), "u", new decimal(0));
                        }
                    }
                    else if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(empty1.ToLower() != "e") || !(empty1.ToLower() != num.ToString()) || !(empty1.ToLower() != "i") || !(str2.ToLower() != "invoice") || !(str2.ToLower() != "inv"))
                        {
                            continue;
                        }
                        long num26 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock allocated: <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num26, string.Concat(estimateID), UserID, Convert.ToDecimal(hashtables[key6]), "h", new decimal(0));
                    }
                    else
                    {
                        if (empty5 == null || empty5 == "")
                        {
                            empty5 = "0";
                        }
                        if (str2 != string.Empty)
                        {
                            continue;
                        }
                        long num27 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to deletion of item in job : <a href='", str, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue' >", str1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num27, string.Concat(estimateID), UserID, new decimal(0), "a", new decimal(0));
                    }
                }
            }
            return empty;
        }

        public bool CopyItem(long EstimateID, long EstimateItemID, string EstimateType, string Module, string ddlStatusVal)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            bool flag = false;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            BaseClass baseClass = new BaseClass();
            long num = (long)0;
            long num1 = (long)0;
            long num2 = (long)0;
            foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, EstimateID).Rows)
            {
                num2 = (long)Convert.ToInt32(row["AccountID"]);
            }
            long num3 = EstimatesBasePage.Item_Copy_AllMainItem_withallAdditionItems_reeng(Convert.ToInt64(EstimateItemID), EstimateType, Module);
            long num4 = num3;
            empty = (ConnectionClass.SecureDocPath == null ? "" : ConnectionClass.SecureDocPath);
            str = (ConnectionClass.ServerName == null ? "" : ConnectionClass.ServerName);
            DataTable dataTable = EstimatesBasePage.Copying_ArtworkFile((long)this.CompanyID, EstimateItemID);
            string[] strArrays = new string[dataTable.Rows.Count];
            string[] strArrays1 = new string[dataTable.Rows.Count];
            string[] str2 = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strArrays[i] = dataTable.Rows[i]["Filename"].ToString();
                strArrays1[i] = dataTable.Rows[i]["IsFromStoreAttach"].ToString();
                str2[i] = dataTable.Rows[i]["OriginalFileName"].ToString();
            }
            string[] strArrays2 = new string[] { empty, str, "/", this.Session["companyid"].ToString(), "/attachments/" };
            string str3 = string.Concat(strArrays2);
            object[] objArray = new object[] { empty, str, "//store//", num2, "//artwork//" };
            string str4 = string.Concat(objArray);
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            for (int j = 0; j < (int)strArrays.Length; j++)
            {
                if (File.Exists(string.Concat(str3, baseClass.ReplaceSingleQuote(strArrays[j].ToString()))))
                {
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        string str5 = string.Concat(guid.ToString().Substring(0, 5), "_", strArrays[j]);
                        if (empty2 != "")
                        {
                            empty2 = string.Concat(empty2, ',', str5);
                            empty3 = string.Concat(empty3, ',', str2[j]);
                        }
                        else
                        {
                            empty2 = str5;
                            empty3 = str2[j];
                        }
                        File.Copy(string.Concat(str3, strArrays[j].ToString()), string.Concat(str3, str5), true);
                        if (strArrays1[j].ToString().ToLower() == "true")
                        {
                            File.Copy(string.Concat(str4, strArrays[j].ToString()), string.Concat(str4, str5), true);
                        }
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
            try
            {
                EstimatesBasePage.SendingNewArtWorkFilenames(this.CompanyID, EstimateItemID, empty2, empty3, num4);
            }
            catch (Exception exception1)
            {
            }
            this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            if (Module.ToLower() == "estimate")
            {
                this.objnotes.ModuleName = "estimate";
            }
            else if (Module.ToLower() == "job")
            {
                this.objnotes.ModuleName = "job";
            }
            else if (Module.ToLower() == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
            }
            foreach (DataRow dataRow in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(EstimateItemID).Rows)
            {
                num = Convert.ToInt64(dataRow["JOBID"].ToString());
                num1 = Convert.ToInt64(dataRow["InvoiceID"].ToString());
            }
            foreach (DataRow row1 in EstimatesBasePage.select_EstimateItemID(EstimateID).Rows)
            {
                num3 = Convert.ToInt64(row1["EstimateItemID"].ToString());
            }
            if (Module.ToLower() == "job")
            {
                DataTable dataTable1 = Notes.select_item_number_for_Activity_History(num, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    empty1 = dataRow1["rownumber"].ToString();
                }
                foreach (DataRow row2 in Notes.select_item_number_for_Activity_History(num, num3, Module).Rows)
                {
                    str1 = row2["rownumber"].ToString();
                }
            }
            else if (Module.ToLower() != "invoice")
            {
                DataTable dataTable2 = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow dataRow2 in dataTable2.Rows)
                {
                    empty1 = dataRow2["rownumber"].ToString();
                }
                foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(EstimateID, num3, Module).Rows)
                {
                    str1 = row3["rownumber"].ToString();
                }
            }
            else
            {
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(num1, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow dataRow3 in dataTable3.Rows)
                {
                    empty1 = dataRow3["rownumber"].ToString();
                }
                foreach (DataRow row4 in Notes.select_item_number_for_Activity_History(num1, num3, Module).Rows)
                {
                    str1 = row4["rownumber"].ToString();
                }
            }
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.CopyItem);
            this.objnotes.NewItem_number = string.Concat("Item ", str1);
            this.objnotes.Item_number = string.Concat("Item ", empty1);
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = string.Concat(HttpContext.Current.Session["FirstName"].ToString(), HttpContext.Current.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
            if (Module.ToLower() == "job")
            {
                string empty4 = string.Empty;
                foreach (DataRow dataRow4 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, EstimateID).Rows)
                {
                    empty4 = dataRow4["StatusID"].ToString();
                }
                this.Call_Inventory_Adjustment("progressed", EstimateID, this.CompanyID, num3, this.UserID);
                if (this.ReduceStockType.ToLower() == empty4.ToString())
                {
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "e")
                {
                    flag = true;
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
            }
            else if (Module.ToLower() == "invoice")
            {
                this.Call_Inventory_Adjustment("progressed-invoice", EstimateID, this.CompanyID, num3, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    flag = true;
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "i" || this.isStock_Reduce)
                {
                    flag = true;
                    this.Call_Inventory_Adjustment("completed-invoice", EstimateID, this.CompanyID, num3, this.UserID);
                }
            }
            return flag;
        }

        public long CopyItem_ForEstItemID(long EstimateID, long EstimateItemID, string EstimateType, string Module, string ddlStatusVal)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            BaseClass baseClass = new BaseClass();
            long num = (long)0;
            long num1 = (long)0;
            long num2 = (long)0;
            foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, EstimateID).Rows)
            {
                num2 = (long)Convert.ToInt32(row["AccountID"]);
            }
            long num3 = EstimatesBasePage.Item_Copy_AllMainItem_withallAdditionItems_reeng(Convert.ToInt64(EstimateItemID), EstimateType, Module);
            long num4 = num3;
            empty = (ConnectionClass.SecureDocPath == null ? "" : ConnectionClass.SecureDocPath);
            str = (ConnectionClass.ServerName == null ? "" : ConnectionClass.ServerName);
            DataTable dataTable = EstimatesBasePage.Copying_ArtworkFile((long)this.CompanyID, EstimateItemID);
            string[] strArrays = new string[dataTable.Rows.Count];
            string[] strArrays1 = new string[dataTable.Rows.Count];
            string[] str2 = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strArrays[i] = dataTable.Rows[i]["Filename"].ToString();
                strArrays1[i] = dataTable.Rows[i]["IsFromStoreAttach"].ToString();
                str2[i] = dataTable.Rows[i]["OriginalFileName"].ToString();
            }
            string[] strArrays2 = new string[] { empty, str, "/", this.Session["companyid"].ToString(), "/attachments/" };
            string str3 = string.Concat(strArrays2);
            object[] objArray = new object[] { empty, str, "//store//", num2, "//artwork//" };
            string str4 = string.Concat(objArray);
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            for (int j = 0; j < (int)strArrays.Length; j++)
            {
                if (File.Exists(string.Concat(str3, baseClass.ReplaceSingleQuote(strArrays[j].ToString()))))
                {
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        string str5 = string.Concat(guid.ToString().Substring(0, 5), "_", strArrays[j]);
                        if (empty2 != "")
                        {
                            empty2 = string.Concat(empty2, ',', str5);
                            empty3 = string.Concat(empty3, ',', str2[j]);
                        }
                        else
                        {
                            empty2 = str5;
                            empty3 = str2[j];
                        }
                        File.Copy(string.Concat(str3, strArrays[j].ToString()), string.Concat(str3, str5), true);
                        if (strArrays1[j].ToString().ToLower() == "true")
                        {
                            File.Copy(string.Concat(str4, strArrays[j].ToString()), string.Concat(str4, str5), true);
                        }
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
            try
            {
                EstimatesBasePage.SendingNewArtWorkFilenames(this.CompanyID, EstimateItemID, empty2, empty3, num4);
            }
            catch (Exception exception1)
            {
            }
            this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            foreach (DataRow dataRow in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(EstimateItemID).Rows)
            {
                num = Convert.ToInt64(dataRow["JOBID"].ToString());
                num1 = Convert.ToInt64(dataRow["InvoiceID"].ToString());
            }
            if (Module.ToLower() == "job")
            {
                DataTable dataTable1 = Notes.select_item_number_for_Activity_History(num, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    empty1 = row1["rownumber"].ToString();
                }
                foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(num, num3, Module).Rows)
                {
                    str1 = dataRow1["rownumber"].ToString();
                }
                this.objnotes.ModuleName = "Job";
                this.objnotes.ModuleID = num;
            }
            else if (Module.ToLower() != "invoice")
            {
                DataTable dataTable2 = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    empty1 = row2["rownumber"].ToString();
                }
                foreach (DataRow dataRow2 in Notes.select_item_number_for_Activity_History(EstimateID, num3, Module).Rows)
                {
                    str1 = dataRow2["rownumber"].ToString();
                }
            }
            else
            {
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(num1, Convert.ToInt64(EstimateItemID), Module);
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    empty1 = row3["rownumber"].ToString();
                }
                foreach (DataRow dataRow3 in Notes.select_item_number_for_Activity_History(num1, num3, Module).Rows)
                {
                    str1 = dataRow3["rownumber"].ToString();
                }
                this.objnotes.ModuleName = "Invoice";
                this.objnotes.ModuleID = num1;
            }
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.CopyItem);
            this.objnotes.NewItem_number = string.Concat("Item ", str1);
            this.objnotes.Item_number = string.Concat("Item ", empty1);
            this.objnotes.CustomerName = string.Concat(HttpContext.Current.Session["FirstName"].ToString(), HttpContext.Current.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = num3;
            this.objN.NotesAdd(this.objnotes);
            if (Module.ToLower() == "job")
            {
                string empty4 = string.Empty;
                foreach (DataRow row4 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, EstimateID).Rows)
                {
                    empty4 = row4["StatusID"].ToString();
                }
                this.Call_Inventory_Adjustment("progressed", EstimateID, this.CompanyID, num3, this.UserID);
                if (this.ReduceStockType.ToLower() == empty4.ToString())
                {
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "e")
                {
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
            }
            else if (Module.ToLower() == "invoice")
            {
                this.Call_Inventory_Adjustment("progressed-invoice", EstimateID, this.CompanyID, num3, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "i" || this.isStock_Reduce)
                {
                    this.Call_Inventory_Adjustment("completed-invoice", EstimateID, this.CompanyID, num3, this.UserID);
                }
            }
            else if (Module.ToLower() == "order")
            {
                this.Call_Inventory_Adjustment("progressed", EstimateID, this.CompanyID, num3, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.Call_Inventory_Adjustment("completed", EstimateID, this.CompanyID, num3, this.UserID);
                }
            }
            return num3;
        }

        protected string date_Check_new(string DateFormat, string PaperMeasure, string DateFormatt, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (DateFormat == string.Concat(PaperMeasure, "/dd/yyyy"))
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays1);
                    }
                    else if (DateFormatt == string.Concat(PaperMeasure, "/dd/yyyy"))
                    {
                        string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays2);
                    }
                }
                if (DateFormat == "dd/mm/yyyy")
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormatt == string.Concat(PaperMeasure, "/dd/yyyy"))
                    {
                        string[] strArrays4 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays4);
                    }
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        public void EmptyRowCreation(StringBuilder Strbud)
        {
            for (int i = 0; i < 3; i++)
            {
                Strbud.Append("<td width='25%'>");
                Strbud.Append("&nbsp;</td>");
            }
        }

        public void EndTableCreation(StringBuilder Strbud)
        {
            Strbud.Append("</tr>");
            Strbud.Append("</table>");
            Strbud.Append("</div>");
            Strbud.Append("</div>");
            Strbud.Append("<div class='onlyEmpty'></div>");
        }

        public void EstoreCommentsStyle(StringBuilder Strbud, string title, string DivID)
        {
            Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
            Strbud.Append("<div class='bglabel'  style = 'padding-top:5px;width:200px;float:left;'>");
            //Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;margin-left:38.5%;margin-top:24px;position:absolute;'>");
            Strbud.Append(title ?? "");
            Strbud.Append("</div>");
            Strbud.Append("<div style='float:left;border:solid 0px blue;position: absolute;margin-left: 17%;margin-top: 5px;'>");
            Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='0%' >");
            Strbud.Append("<tr>");
        }

        public void EstoreCommentsStyle1(StringBuilder Strbud, string title, string DivID)
        {
            Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
            Strbud.Append("<div class='bglabel'  style = 'padding-top:5px;width:200px;float:left;'>");
            //Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;margin-left:38.5%;margin-top:24px;position:absolute;'>");
            Strbud.Append(title ?? "");
            Strbud.Append("</div>");
            Strbud.Append("<div style='float:left;border:solid 0px blue;position: absolute;margin-left: 15%;margin-top: 5px;'>");
            Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='0%' >");
            Strbud.Append("<tr>");
        }

        public static DataTable guillotine_cost_for_large(int CompanyID, long GuillotineID, int Quantity)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_guillotine_cost_for_large");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Insert_ActivityHistory_CarInfoUpdate(long ID, string Module)
        {
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            }
            if (Module.ToLower().Trim() == "delivery")
            {
                this.objnotes.ModuleName = "delivery";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelCarInfoChanged);
                this.objnotes.ModuleID = ID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                foreach (DataRow row in DeliveryBasePage.delivery_select(this.CompanyID, ID).Rows)
                {
                    this.objnotes.CarrierName = row["CarrierName"].ToString();
                }
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.objnotes.ModuleID = ID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_ActivityHistory_OnItemDelete(long EstimateID, long EstimateItemID, string EstimateType, string Module, string itemTitle)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string empty = string.Empty;
            DataTable dataTable = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(EstimateItemID), Module);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["rownumber"].ToString();
            }
            if (Module.ToLower() == "estimate")
            {
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemDeleted);
            }
            else if (Module.ToLower() == "job")
            {
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemDeleted);
            }
            else if (Module.ToLower() == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemDeleted);
            }
            else if (Module.ToLower() == "order")
            {
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderItemDeleted);
            }
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.Item_title = itemTitle;
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = string.Concat(HttpContext.Current.Session["FirstName"].ToString(), HttpContext.Current.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_ActivityHistory_OnItemDescriptionUpdate(long EstimateID, long EstimateItemID, string EstimateType, string Module, string itemTitle)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string empty = string.Empty;
            DataTable dataTable = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(EstimateItemID), Module);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["rownumber"].ToString();
            }
            if (Module.ToLower() == "estimate")
            {
                this.objnotes.ModuleName = "estimate";
            }
            else if (Module.ToLower() == "job")
            {
                this.objnotes.ModuleName = "job";
            }
            else if (Module.ToLower() == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
            }
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemDesc);
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.Item_title = itemTitle;
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = string.Concat(HttpContext.Current.Session["FirstName"].ToString(), HttpContext.Current.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_ActivityHistory_OnSubItemDelete(long EstimateID, long EstimateItemID, string EstimateType, string Module, long ParentEstimateItemID)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(Convert.ToString(this.Session["UserID"]));
            string empty = string.Empty;
            long num = (long)0;
            long num1 = (long)0;
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(EstimateItemID).Rows)
            {
                num = Convert.ToInt64(row["JOBID"].ToString());
                num1 = Convert.ToInt64(row["InvoiceID"].ToString());
            }
            if (Module.ToLower() == "estimate")
            {
                DataTable dataTable = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(ParentEstimateItemID), Module);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    empty = dataRow["rownumber"].ToString();
                }
                this.ModuleID = EstimateID;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemDelte);
            }
            else if (Module.ToLower() == "job")
            {
                DataTable dataTable1 = Notes.select_item_number_for_Activity_History(num, Convert.ToInt64(ParentEstimateItemID), Module);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    empty = row1["rownumber"].ToString();
                }
                this.ModuleID = num;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubItemDelte);
            }
            else if (Module.ToLower() == "invoice")
            {
                DataTable dataTable2 = Notes.select_item_number_for_Activity_History(num1, Convert.ToInt64(ParentEstimateItemID), Module);
                foreach (DataRow dataRow1 in dataTable2.Rows)
                {
                    empty = dataRow1["rownumber"].ToString();
                }
                this.ModuleID = num1;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvoiceSubItemDelte);
            }
            else if (Module.ToLower() == "order")
            {
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(ParentEstimateItemID), Module);
                foreach (DataRow row2 in dataTable3.Rows)
                {
                    empty = row2["rownumber"].ToString();
                }
                this.ModuleID = EstimateID;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderSubItemDelte);
            }
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.ModuleID = this.ModuleID;
            this.objnotes.CustomerName = string.Concat(HttpContext.Current.Session["FirstName"].ToString(), HttpContext.Current.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = ParentEstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public static void Insert_ActivityHistory_Purchase(long EstimateID, long PurchaseID, string Job_number, string PONO, string CustomerName, int CompanyID, int UserID)
        {
            notesclass _notesclass = new notesclass();
            Notes note = new Notes();
            commonClass _commonClass = new commonClass();
            _notesclass.ModuleName = "estimate";
            _notesclass.Po_number = PONO;
            _notesclass.Job_number = Job_number;
            _notesclass.NotesType = Convert.ToString(Notes.NotesType.POCreatedFromJob);
            _notesclass.ModuleID = PurchaseID;
            _notesclass.CustomerName = CustomerName;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
            _notesclass.CompanyID = CompanyID;
            _notesclass.UserID = UserID;
            note.NotesAdd(_notesclass);
        }

        public void Insert_ActivityHistory_StatusUpdate(long EstimateID, string Module)
        {
            string empty = string.Empty;
            if (this.Session["OrderID"] != null)
            {
                this.OrderID = Convert.ToInt32(this.Session["OrderID"].ToString());
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            if (Module.ToLower() == "estimate")
            {
                string str = string.Empty;
                foreach (DataRow row in EstimatesBasePage.estimate_select_summary(this.CompanyID, EstimateID).Rows)
                {
                    empty = row["StatusTitle"].ToString();
                    str = row["EstimateNumber"].ToString();
                }
                this.objnotes.Estimate_number = str;
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstChangeStatus);
            }
            else if (Module.ToLower() == "job")
            {
                string empty1 = string.Empty;
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_JobID(this.CompanyID, EstimateID).Rows)
                {
                    empty = dataRow["jobstatus"].ToString();
                    empty1 = dataRow["JobNumber"].ToString();
                }
                this.objnotes.Job_number = empty1;
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobChangeStatus);
            }
            else if (Module.ToLower() == "invoice")
            {
                string str1 = string.Empty;
                string empty2 = string.Empty;
                foreach (DataRow row1 in InvoiceBasePage.Invoice_Select_By_InvoiceID(this.CompanyID, EstimateID).Rows)
                {
                    str1 = row1["Status"].ToString();
                    empty2 = row1["InvoiceNumber"].ToString();
                }
                this.objnotes.Status_name = str1;
                this.objnotes.Invoice_number = empty2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvChangeStatus);
            }
            else if (Module.ToLower() == "order")
            {
                string str2 = string.Empty;
                string empty3 = string.Empty;
                foreach (DataRow dataRow1 in OrderBasePage.Order_select(this.CompanyID, EstimateID).Rows)
                {
                    str2 = dataRow1["StatusTitle"].ToString();
                    empty3 = dataRow1["OrderNo"].ToString();
                }
                this.objnotes.Status_name = str2;
                this.objnotes.Invoice_number = empty3;
                this.objnotes.ModuleName = "order";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdChangeStatus);
            }
            else if (Module.ToLower().Trim() == "purchase")
            {
                this.objnotes.ModuleName = "purchase";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POChangeStatus);
                this.objnotes.ModuleID = EstimateID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                foreach (DataRow row2 in PurchaseBasePage.purchase_select(this.CompanyID, EstimateID).Rows)
                {
                    this.objnotes.Po_number = row2["PONO"].ToString();
                    this.objnotes.Status_name = row2["StatusTitle"].ToString();
                }
            }
            else if (Module.ToLower().Trim() == "delivery")
            {
                this.objnotes.ModuleName = "delivery";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelChangeStatus);
                this.objnotes.ModuleID = EstimateID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                foreach (DataRow dataRow2 in DeliveryBasePage.delivery_select(this.CompanyID, EstimateID).Rows)
                {
                    this.objnotes.Delivery_number = dataRow2["DeliveryNumber"].ToString();
                    this.objnotes.Status_name = dataRow2["StatusTitle"].ToString();
                }
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_ActivityHistory_StatusUpdate_PerItem(long EstimateItemID, string Module)
        {
            string empty = string.Empty;
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            if (Module.ToLower() == "estimate")
            {
                string str = string.Empty;
                foreach (DataRow row in EstimatesBasePage.estimate_select_summary_PerItem(this.CompanyID, EstimateItemID).Rows)
                {
                    empty = row["StatusName"].ToString();
                    str = row["EstimateItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(row["ModuleID"]);
                }
                this.objnotes.Estimate_number = str;
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstChangeStatus);
            }
            else if (Module.ToLower() == "job")
            {
                string empty1 = string.Empty;
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateItemID(this.CompanyID, EstimateItemID).Rows)
                {
                    empty = dataRow["JobstatusName"].ToString();
                    empty1 = dataRow["JobItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(dataRow["ModuleID"]);
                }
                this.objnotes.Job_number = empty1;
                this.objnotes.Status_name = empty;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobChangeStatus);
            }
            else if (Module.ToLower() == "invoice")
            {
                string str1 = string.Empty;
                string empty2 = string.Empty;
                foreach (DataRow row1 in InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(this.CompanyID, EstimateItemID).Rows)
                {
                    str1 = row1["InvoiceStatusName"].ToString();
                    empty2 = row1["InvoiceItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(row1["ModuleID"]);
                }
                this.objnotes.Status_name = str1;
                this.objnotes.Invoice_number = empty2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvChangeStatus);
            }
            else if (Module.ToLower() == "webstoreorder" || Module.ToLower() == "order")
            {
                string str2 = string.Empty;
                string empty3 = string.Empty;
                foreach (DataRow dataRow1 in OrderBasePage.Order_select_Summary_PerItem(this.CompanyID, EstimateItemID).Rows)
                {
                    str2 = dataRow1["OrderStatusName"].ToString();
                    empty3 = dataRow1["OrderItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(dataRow1["ModuleID"]);
                }
                this.objnotes.Status_name = str2;
                this.objnotes.Invoice_number = empty3;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdChangeStatus);
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.objnotes.ModuleID = this.ModuleID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void InvoicePay_fromInvoiceSummary(int CompanyID, int UserID, long EstimateID, string CustomerName, string txtInvoicePaymentDate, string ddl_Paymentmode, string txt_PaymentDetailNotes, string DateFormat, string PaperMeasure)
        {
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            string str = this.date_Check_new(DateFormat, PaperMeasure, DateFormat, baseClass.ReplaceSingleQuote(txtInvoicePaymentDate));
            long num = InvoiceBasePage.invoice_InvoiceID_select(CompanyID, EstimateID, "Paid");
            InvoiceBasePage.Insert_InvoicePaymentDetails(num, EstimateID, (long)CompanyID, Convert.ToInt32(ddl_Paymentmode), Convert.ToDateTime(str), txt_PaymentDetailNotes, "", "", 0, 0, "0", "0");
            string empty = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPayment);
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = CustomerName;
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
            this.objnotes.CompanyID = CompanyID;
            this.objnotes.UserID = UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Job_Card_Of_PriceCatalogue(int CompanyID, long EstimateItemID, long OrderItemID)
        {
            string[] strArrays = new string[0];
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (DataRow row in OrderBasePage.Select_ProductCatalogue_Details(CompanyID, OrderItemID).Rows)
            {
                strArrays = row["Itemdesc"].ToString().Split(new char[] { 'µ' });
            }
            StringBuilder stringBuilder2 = new StringBuilder();
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                this.dtJobCard = SettingsBasePage.Select_JobCardSettings((long)CompanyID);
                foreach (DataRow dataRow in this.dtJobCard.Rows)
                {
                    this.SectionKey = dataRow["SectionKey"].ToString();
                    this.JobCardDescription = dataRow["Description"].ToString();
                    this.LineSpacing = Convert.ToInt16(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["LineSpacing"].ToString()), 0, "", true, false, false));
                    if (string.Compare(strArrays1[0], "ItemTitle", true) == 0 && this.SectionKey == "[PriceCatalogueItemTitle]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Title>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Description", true) == 0 && this.SectionKey == "[PriceCatalogueItemDescription]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Description>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Artwork", true) == 0 && this.SectionKey == "[PriceCatalogueItemArtWork]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Artwork>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Colour", true) == 0 && this.SectionKey == "[PriceCatalogueColor]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Colour>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Size", true) == 0 && this.SectionKey == "[PriceCatalogueItemSize]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Size>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Material", true) == 0 && this.SectionKey == "[PriceCataloguetemMaterial]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Material>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Delivery", true) == 0 && this.SectionKey == "[PriceCatalogueItemDelivery]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Delivery>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Finishing", true) == 0 && this.SectionKey == "[PriceCatalogueItemFinishing]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Finishing>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Notes", true) == 0 && this.SectionKey == "[PriceCatalogueNotes]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<item_notes>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Proofs", true) == 0 && this.SectionKey == "[PriceCatalogueItemProofs]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Proofs>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Packing", true) == 0 && this.SectionKey == "[PriceCatalogueItemPacking]")
                    {
                        stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Packing>", strArrays1[2].ToString()) ?? "");
                        stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                    }
                    if (string.Compare(strArrays1[0], "Instructions", true) != 0 || !(this.SectionKey == "[PriceCatalogueItem_Terms/Instructions]"))
                    {
                        continue;
                    }
                    stringBuilder2.Append(this.JobCardDescription.Replace("<Item_Terms/Instructions>", strArrays1[2].ToString()) ?? "");
                    stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                }
            }
            string str2 = string.Empty;
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Select_JobCardSettings((long)CompanyID);
            foreach (DataRow row1 in dataTable.Rows)
            {
                this.SectionKey = row1["SectionKey"].ToString();
                this.JobCardDescription = row1["Description"].ToString();
                this.LineSpacing = Convert.ToInt16(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row1["LineSpacing"].ToString()), 0, "", true, false, false));
                if (this.SectionKey == "[PricecatalogueDetails]")
                {
                    string[] strArrays2 = new string[] { "<b><u>", this.JobCardDescription.ToString(), "</u></b>", SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes), stringBuilder2.ToString().Replace("\n", "<br />") };
                    str2 = string.Concat(strArrays2);
                }
                SummaryClass.jobcard_for_sub_item(CompanyID, OrderItemID, ref str1);
                string[] strArrays3 = str1.Split(new char[] { '±' });
                if (this.SectionKey == "[PrePressOthercostName]" && strArrays3[0] != "")
                {
                    empty = "<b><u>Other Cost Details:</u></b><br />";
                    empty = string.Concat(empty, this.JobCardDescription.Replace("<Othercost_Name>", strArrays3[0]));
                    empty = string.Concat(empty, SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                }
                if (this.SectionKey == "[AdminOthercostName]" && strArrays3[3] != "")
                {
                    str = "<b><u>Other Cost Details:</u></b><br />";
                    str = string.Concat(str, this.JobCardDescription.Replace("<Othercost_Name>", strArrays3[3]));
                    str = string.Concat(str, SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                }
                if (this.SectionKey == "[PostPressOthercostName]")
                {
                    if (!string.IsNullOrEmpty(strArrays3[1]))
                    {
                        stringBuilder1.Append("<b><u>Other Cost Details:</u></b><br />");
                        stringBuilder1.Append(this.JobCardDescription.Replace("<Othercost_Name>", strArrays3[1]));
                    }
                    stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
                }
                if (this.SectionKey != "[pressOtherCostsName]")
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(strArrays3[2]))
                {
                    stringBuilder.Append("<b><u>Other Cost Details:</u></b><br />");
                    stringBuilder.Append(this.JobCardDescription.Replace("<Othercost_Name>", strArrays3[2]));
                }
                stringBuilder.Append(SummaryClass.jobcard_LineSpacing(CompanyID, this.LineSpacing, ref this.lineBrakes));
            }
            JobBasePage.job_card_required_update(CompanyID, EstimateItemID, empty, stringBuilder.ToString(), stringBuilder1.ToString(), str2, "", "", str);
        }

        public static string Job_Card_Of_Sub_Item_Warehouse(int CompanyID, long ItemID, string EstType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in JobBasePage.Jobs_WarehouseItems_Slect(CompanyID, ItemID, EstType).Rows)
            {
                string str = row["Types"].ToString();
                if (string.Compare(str, "Inventory", true) == 0)
                {
                    stringBuilder.Append("<b><u>Inventory Details:</u></b>  <br />");
                    stringBuilder.Append(string.Concat("Inventory Name: ", row["WarehouseName"].ToString(), "  <br />"));
                }
                else if (string.Compare(str, "Store Supply", true) == 0)
                {
                    stringBuilder.Append("<b><u>Store Supply Details:</u></b>  <br />");
                    stringBuilder.Append(string.Concat("Product Name: ", row["WarehouseName"].ToString(), "  <br />"));
                }
                else if (string.Compare(str, "Customer Item", true) == 0)
                {
                    stringBuilder.Append("<b><u>Customer Item Details:</u></b>  <br />");
                    stringBuilder.Append(string.Concat("Product Name: ", row["WarehouseName"].ToString(), "  <br />"));
                }
                stringBuilder.Append(string.Concat("Quantity: ", row["Quantity"].ToString(), "  <br /> <br />"));
            }
            return stringBuilder.ToString();
        }

        public static string jobcard_for_sub_item(int CompanyID, long ParentItemID, string ParentItemType, ref string strWarehouse, ref string strOutwork, ref string strOtherCost)
        {
            strWarehouse = string.Empty;
            strOutwork = string.Empty;
            strOtherCost = string.Empty;
            commonClass _commonClass = new commonClass();
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            string str = string.Empty;
            string empty1 = string.Empty;
            short num = 0;
            DataSet dataSet = JobsBasePage.jobcard_for_sub_item(CompanyID, ParentItemID, ParentItemType);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (string.Compare(row["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(row["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                dataTable = SettingsBasePage.Select_JobCardSettings((long)CompanyID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    str = dataRow["SectionKey"].ToString();
                    empty1 = dataRow["Description"].ToString();
                    num = Convert.ToInt16(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["LineSpacing"].ToString()), 0, "", true, false, false));
                    string str1 = row["Types"].ToString();
                    if (string.Compare(str1, "Inventory", true) == 0)
                    {
                        if (str == "[WarehouseInventoryDetails]")
                        {
                            stringBuilder1.Append(string.Concat("<b><u>", empty1.ToString(), "</u></b>"));
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        if (str == "[WarehouseInventoryName]")
                        {
                            stringBuilder1.Append(empty1.Replace("<Inventory_Name>", row["WarehouseName"].ToString()) ?? "");
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                    }
                    else if (string.Compare(str1, "Store Supply", true) == 0)
                    {
                        if (str == "[WarehouseStoreSupplyDetails]")
                        {
                            stringBuilder1.Append(string.Concat("<b><u>", empty1.ToString(), "</u></b>"));
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        if (str == "[WarehouseSupplyProductName]")
                        {
                            stringBuilder1.Append(empty1.Replace("<SupplyProduct_Name>", row["WarehouseName"].ToString()) ?? "");
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                    }
                    else if (string.Compare(str1, "Customer Item", true) == 0)
                    {
                        if (str == "[WarehouseCustomerItemDetails]")
                        {
                            stringBuilder1.Append(string.Concat("<b><u>", empty1.ToString(), "</u></b> "));
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        if (str == "[WarehouseItemProductName]")
                        {
                            stringBuilder1.Append(empty1.Replace("<ItemProduct_Name>", row["WarehouseName"].ToString()) ?? "");
                            stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                    }
                    if (!(str == "[WarehouseQuantity]") && !(str == "[WarehoseSupplyQuantity]") && !(str == "[WarehouseItemQuantity]"))
                    {
                        continue;
                    }
                    stringBuilder1.Append(string.Concat(empty1.Replace("<quantity>", row["Quantity"].ToString()), " "));
                    stringBuilder1.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                }
            }
            strWarehouse = stringBuilder1.ToString();
            int num1 = 1;
            foreach (DataRow row1 in dataSet.Tables[1].Rows)
            {
                if (string.Compare(row1["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(row1["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                dataTable = SettingsBasePage.Select_JobCardSettings((long)CompanyID);
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    str = dataRow1["SectionKey"].ToString();
                    empty1 = dataRow1["Description"].ToString();
                    num = Convert.ToInt16(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow1["LineSpacing"].ToString()), 0, "", true, false, false));
                    stringBuilder2.Append(string.Concat("<b><u>Item ", num1, ":</u></b><br />"));
                    DataTable dataTable1 = JobsBasePage.jobcard_outwork(CompanyID, Convert.ToInt64(row1["EstOutworkID"]));
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        if (str == "[OutworkItemTitle]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Title>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemDescription]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Description>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemArtwork]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Artwork>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemColour]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Colour>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemSize]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Size>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemMaterial]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Material>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemDelivery]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Delivery>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemFinishing]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Finishing>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemNotes]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Notes>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str == "[OutworkItemTerms]")
                        {
                            stringBuilder2.Append(empty1.Replace("<Terms/Instructions>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else if (str != "[OutworkItemProofs]")
                        {
                            if (str != "[OutworkItemPacking]")
                            {
                                continue;
                            }
                            stringBuilder2.Append(string.Concat(empty1.Replace("<Item_Packing>", row2["Description"].ToString()), " "));
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                        else
                        {
                            stringBuilder2.Append(empty1.Replace("<Item_Proofs>", row2["Description"].ToString()) ?? "");
                            stringBuilder2.Append(SummaryClass.jobcard_LineSpacing(CompanyID, num, ref empty));
                        }
                    }
                }
                num1++;
            }
            strOutwork = stringBuilder2.ToString();
            strOutwork = "";
            StringBuilder stringBuilder3 = new StringBuilder();
            StringBuilder stringBuilder4 = new StringBuilder();
            StringBuilder stringBuilder5 = new StringBuilder();
            StringBuilder stringBuilder6 = new StringBuilder();
            foreach (DataRow dataRow2 in dataSet.Tables[2].Rows)
            {
                if (string.Compare(dataRow2["PoType"].ToString(), "othercost", true) != 0 || string.Compare(dataRow2["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                StringBuilder stringBuilder7 = new StringBuilder();
                string str2 = dataRow2["CalculationType"].ToString();
                string str3 = dataRow2["typeid"].ToString();
                stringBuilder7.Append(string.Concat(dataRow2["OtherCostName"].ToString(), "<br />"));
                if (str3.Trim() == "0")
                {
                    stringBuilder7.Append(string.Concat("Description: ", dataRow2["Description"].ToString(), "<br />"));
                }
                else
                {
                    stringBuilder7.Append(string.Concat("Description: ", dataRow2["Notes"].ToString(), "<br />"));
                }
                if (string.Compare(str2, "t", true) == 0)
                {
                    stringBuilder7.Append(string.Concat("Hours: ", _commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["HoursOrQty"].ToString()), 0, "", false, false, true), "<br /><br />"));
                }
                else if (string.Compare(str2, "q", true) != 0)
                {
                    stringBuilder7.Append("<br />");
                }
                else
                {
                    stringBuilder7.Append(string.Concat("Quantity: ", Convert.ToInt32(dataRow2["HoursOrQty"]), "<br /><br />"));
                }
                stringBuilder7.Append("<br />");
                dataRow2["OtherCostCategoryName"].ToString();
                string str4 = dataRow2["JobcardCategory"].ToString();
                if (string.Compare(str4, "Post Press", true) == 0)
                {
                    stringBuilder4.Append(stringBuilder7.ToString());
                }
                else if (string.Compare(str4, "Press", true) == 0)
                {
                    stringBuilder5.Append(stringBuilder7.ToString());
                }
                else if (string.Compare(str4, "Pre Press", true) != 0)
                {
                    if (string.Compare(str4, "Admin", true) != 0)
                    {
                        continue;
                    }
                    stringBuilder6.Append(stringBuilder7.ToString());
                }
                else
                {
                    stringBuilder3.Append(stringBuilder7.ToString());
                }
            }
            string[] strArrays = new string[] { stringBuilder3.ToString(), "±", stringBuilder4.ToString(), "±", stringBuilder5.ToString(), "±", stringBuilder6.ToString() };
            strOtherCost = string.Concat(strArrays).ToString();
            return stringBuilder.ToString();
        }

        public static string jobcard_for_sub_item(int CompanyID, long OrderItemID, ref string strOtherCost)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            foreach (DataRow row in OrderBasePage.Select_OtherCost_AdditionalItemDetails(CompanyID, OrderItemID).Rows)
            {
                StringBuilder stringBuilder4 = new StringBuilder();
                stringBuilder4.Append(string.Concat(row["webothercostName"].ToString(), "<br />"));
                stringBuilder4.Append(string.Concat("Description: ", row["Description"].ToString(), "<br />"));
                stringBuilder4.Append("<br />");
                row["OtherCostCategoryName"].ToString();
                string str = row["JobcardCategory"].ToString();
                if (string.Compare(str, "Post Press", true) == 0)
                {
                    stringBuilder1.Append(stringBuilder4.ToString());
                }
                else if (string.Compare(str, "Press", true) == 0)
                {
                    stringBuilder2.Append(stringBuilder4.ToString());
                }
                else if (string.Compare(str, "Pre Press", true) != 0)
                {
                    if (string.Compare(str, "Admin", true) != 0)
                    {
                        continue;
                    }
                    stringBuilder3.Append(stringBuilder4.ToString());
                }
                else
                {
                    stringBuilder.Append(stringBuilder4.ToString());
                }
            }
            string[] strArrays = new string[] { stringBuilder.ToString(), "±", stringBuilder1.ToString(), "±", stringBuilder2.ToString(), "±", stringBuilder3.ToString() };
            strOtherCost = string.Concat(strArrays).ToString();
            return strOtherCost.ToString();
        }

        public static string jobcard_LineSpacing(int CompanyID, int LineSpace, ref string strJobcardLineSpacing)
        {
            commonClass _commonClass = new commonClass();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= LineSpace; i++)
            {
                stringBuilder.Append("<br />");
            }
            strJobcardLineSpacing = stringBuilder.ToString();
            return strJobcardLineSpacing;
        }

        public static decimal One_Roll_Cost(int CompanyID, decimal Cost, decimal PerQuantity, decimal PackedIn, decimal PackedPrice, decimal InvWidth, decimal InvLength, decimal PaperLength_Required, ref decimal Roll_WholePackPrice)
        {
            Roll_WholePackPrice = new decimal(0);
            decimal perQuantity = (PerQuantity * InvLength) / new decimal(1000);
            if (perQuantity != new decimal(0))
            {
                decimal num = Math.Ceiling(PaperLength_Required / perQuantity);
                Roll_WholePackPrice = num * Cost;
            }
            decimal cost = new decimal(0);
            try
            {
                cost = Cost / PerQuantity;
            }
            catch
            {
            }
            decimal invLength = InvLength / new decimal(1000);
            if (invLength <= new decimal(0))
            {
                return new decimal(0);
            }
            return (PaperLength_Required * cost) / invLength;
        }

        public string OrderStatusChange_StockReduction(long OrderID, int CompanyID, long EstimateItemID, int UserID)
        {
            string empty = string.Empty;
            foreach (DataRow row in (new DataTable()).Rows)
            {
                long num = Convert.ToInt64(row["ProductID"]);
                long num1 = Convert.ToInt64(row["OrderItemID"]);
                int num2 = Convert.ToInt32(row["Quantity"]);
                EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                decimal num3 = new decimal(0);
                BaseClass baseClass = new BaseClass();
                foreach (DataRow dataRow in baseClass.ProductStockType_Select((long)CompanyID, num).Rows)
                {
                    this.Session["StockItemType"] = "X";
                    this.Session["ALC_OrderItemId"] = num1.ToString();
                    if (dataRow["DrawStockFrom"].ToString().ToLower() == "s")
                    {
                        empty = baseClass.StockReductionProcess((long)CompanyID, num, (long)0, "self", num2, EstimateItemID, "Job", (long)UserID, num3);
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        empty = baseClass.StockReductionProcess((long)CompanyID, (long)0, num, "other", num2, EstimateItemID, "Job", (long)UserID, num3);
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() != "a")
                    {
                        if (dataRow["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            continue;
                        }
                        empty = baseClass.StockReductionProcess((long)CompanyID, num, (long)0, "multiple", num2, EstimateItemID, "Job", (long)UserID, num3);
                    }
                    else
                    {
                        empty = baseClass.StockReductionProcessForAdditionalOption((long)CompanyID, num, "additional option", num2, EstimateItemID, "Job", (long)UserID, num3);
                    }
                }
            }
            return empty;
        }

        public void PBReadTopString(StringBuilder Strbud, string title, string DivID)
        {
            if (title == "Gross Profit")
            {
                Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
                Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;height:25px'>");
                Strbud.Append(title ?? "");
                Strbud.Append("</div>");
                Strbud.Append("<div style='float:left;width:65%;border:solid 0px blue'>");
                Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='99%' >");
                Strbud.Append("<tr>");
                return;
            }
            Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
            Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;'>");
            Strbud.Append(title ?? "");
            Strbud.Append("</div>");
            Strbud.Append("<div style='float:left;width:65%;border:solid 0px blue'>");
            Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='100%' >");
            Strbud.Append("<tr>");
        }

        public void PBReadTopString1(StringBuilder Strbud, string title, string DivID)
        {
            if (title == "Gross Profit")
            {
                Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
                Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;height:25px'>");
                Strbud.Append(title ?? "");
                Strbud.Append("</div>");
                Strbud.Append("<div style='float:left;border:solid 0px blue'>");
                Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='99%' >");
                Strbud.Append("<tr>");
                return;
            }
            Strbud.Append(string.Concat("<div align='left' id=", DivID, " style='width:100%'>"));
            Strbud.Append("<div class='bglabel'  style='width:200px;float:left;border:solid 0px green;'>");
            Strbud.Append(title ?? "");
            Strbud.Append("</div>");
            Strbud.Append("<div style='float:left;border:solid 0px blue'>");
            Strbud.Append("<table cellpadding='0px' cellspacing='0px' border='0' width='100%' >");
            Strbud.Append("<tr>");
        }

        public long ProgrssTo_Invoice(int CompanyID, int UserID, long EstimateID, string CustomerName, string RdnNo, string txtInvoicePaymentDate, string ddl_Paymentmode, string txt_PaymentDetailNotes, string DateFormat, string PaperMeasure, string OrderPaymentType, int IsProformaInv)
        {
            long num = (long)0;
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            this.date_Check_new(DateFormat, PaperMeasure, DateFormat, baseClass.ReplaceSingleQuote(txtInvoicePaymentDate));
            commonClass _commonClass1 = this.commclass;
            commonClass _commonClass2 = this.commclass;
            DateTime now = DateTime.Now;
            _commonClass1.date_Check_new(DateFormat, _commonClass2.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, false), CompanyID);
            DateTime dateTime = DateTime.Now;
            long num1 = (long)0;
            num1 = this.objCom.settings_lastcounter_select(CompanyID, "i");
            long num2 = (long)10000000 + num1;
            string str = string.Concat("INV-", num2.ToString().Substring(1, num2.ToString().Length - 1));
            string empty = string.Empty;
            string empty1 = string.Empty;
            BaseClass baseClass1 = new BaseClass();
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Invoice Header").Rows)
            {
                empty = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Invoice Footer").Rows)
            {
                empty1 = dataRow["PhraseText"].ToString();
            }
            int defaultStatusID = 0;
            defaultStatusID = SettingsBasePage.get_default_Status_ID(CompanyID, "invoice", Convert.ToInt32(EstimateID));
            if (RdnNo != "no")
            {
                num = (long)InvoiceBasePage.invoice_insert_ispaid(CompanyID, EstimateID, str, defaultStatusID, dateTime, dateTime, UserID, 0, baseClass1.ReplaceSingleQuote(empty), baseClass1.ReplaceSingleQuote(empty1), 1, ConnectionClass.IsHandy, 0, 'C', 0);
                InvoiceBasePage.Insert_InvoicePaymentDetailsForEstore(num, EstimateID, (long)CompanyID, Convert.ToInt32(ddl_Paymentmode), dateTime, txt_PaymentDetailNotes, "", "", 0, 0, "0", "0");
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInvPayment);
            }
            else
            {
                int num3 = 0;
                if (OrderPaymentType == "Credit Card" || OrderPaymentType == "PayPal" || OrderPaymentType == "Braintree Credit Card" || OrderPaymentType == "Stripe Credit Card")
                {
                    num3 = 1;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdJobProgInv);
                }
                else
                {
                    num3 = 0;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                }
                num = InvoiceBasePage.Invoice_insert(CompanyID, EstimateID, str, defaultStatusID, dateTime, dateTime, UserID, 0, baseClass1.ReplaceSingleQuote(empty), baseClass1.ReplaceSingleQuote(empty1), num3, ConnectionClass.IsHandy, 0, 'C', 0, dateTime, (long)0, "Pending", null,null,null, null, null);
            }
            return num;
        }

        public static decimal ReturnPackedPrice(decimal TotalSheets, decimal PackedInQty, decimal PackPrice, decimal PaperMarkup, out decimal TotalNoOfPacks)
        {
            decimal num = new decimal(0);
            decimal packPrice = new decimal(0);
            decimal num1 = new decimal(0);
            decimal paperMarkup = new decimal(0);
            TotalNoOfPacks = new decimal(0);
            if (PackedInQty != new decimal(0))
            {
                num = Math.Ceiling(TotalSheets / PackedInQty);
            }
            packPrice = num * PackPrice;
            paperMarkup = (packPrice * PaperMarkup) / new decimal(100);
            num1 = packPrice + paperMarkup;
            TotalNoOfPacks = num;
            return num1;
        }

        public static string ReturnPricePerQty(int CompanyID, int UserID, int Qty, double SubTotal, int UnitOfMeasure, bool IsDispOnlyCost)
        {
            commonClass _commonClass = new commonClass();
            string empty = string.Empty;
            if (Qty <= UnitOfMeasure)
            {
                empty = (!IsDispOnlyCost ? string.Concat(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(SubTotal.ToString()), 0, "", false, false, true), "&nbsp;per&nbsp;", Qty) : _commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(SubTotal.ToString()), 0, "", false, false, true).ToString());
            }
            else
            {
                double qty = (double)Qty / Convert.ToDouble(UnitOfMeasure);
                double subTotal = SubTotal / qty;
                empty = (!IsDispOnlyCost ? string.Concat(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(subTotal.ToString()), 0, "", false, false, true), "&nbsp;per&nbsp;", UnitOfMeasure) : _commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(subTotal.ToString()), 0, "", false, false, true).ToString());
            }
            return empty;
        }

        public int Select_Quantity_History_For_Inventory(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Quantity_History_For_Inventory");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public static string Split_ItemDescription(string strData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = strData.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (i == 0)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 1)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 2)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 3)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 4)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 5)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 6)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 7)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 8)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 9)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 10)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 11)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 12)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 13)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 14)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 15)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 16)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 17)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 18)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 19)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 20)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 21)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 22)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 23)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 24)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 25)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 26)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 27)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 28)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 29)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 30)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 31)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 32)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 33)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 34)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 35)
                {
                    if (strArrays[i] != "")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }
                }
                else if (i == 36 && strArrays[i] != "")
                {
                    stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                }
            }
            return stringBuilder.ToString();
        }

        public static string Split_ItemDescription_forpurchaseorder(string strData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = strData.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    if (j == 0 && strArrays1[0].ToString().ToLower() == "material")
                    {
                        stringBuilder.Append(SummaryClass.strItemDesc(strArrays[i]));
                    }

                    // Ticket #8281 - to append description 
                    if (j == 0 && strArrays1[0].ToString().ToLower() == "description")
                    {
                        string[] strDescArrays = strArrays[i].Split(new char[] { '»' });
                        for (int k = 0; k < (int)strDescArrays.Length; k++)
                        {
                            if (k == 2 && string.Compare(strDescArrays[3].ToString(), "true", true) == 0 && !string.IsNullOrEmpty(strDescArrays[2].ToString()))
                            {
                                stringBuilder.AppendFormat(" {1} \n", strDescArrays[1].ToString(), strDescArrays[2].ToString());
                            }
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

        public static string strItemDesc(string strArray_0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] strArrays = strArray_0.Split(new char[] { '»' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (i == 2 && string.Compare(strArrays[3].ToString(), "true", true) == 0 && !string.IsNullOrEmpty(strArrays[2].ToString()))
                    {                      
                      stringBuilder.AppendFormat("{0}: {1} \n", strArrays[1].ToString(), strArrays[2].ToString());     
                    }
                }
            }
            catch
            {
            }
            return stringBuilder.ToString();
        }

        public static string SubItem_Inventory_Update(DataSet ds, string StrJobNum, int StatusID, long EstimateID, int UserID, int CompanyID, string type, Hashtable htInventory, long EstimteItemID)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            commonClass _commonClass = new commonClass();
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            long num = (long)0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num1 = 0;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string empty3 = string.Empty;
            DataTable dataTable = new DataTable();
            decimal num4 = new decimal(0);
            try
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    if (string.Compare(row["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(row["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    num = Convert.ToInt64(row["WarehouseTypeID"]);
                    empty2 = row["WarehouseType"].ToString();
                    row["ItemCode"].ToString();
                    num1 = Convert.ToInt32(row["Quantity"]);
                    Convert.ToInt32(row["PackedIn"]);
                    Convert.ToDecimal(row["UnitPrice"]);
                    EstimteItemID = Convert.ToInt64(row["EstimateItemID"]);
                    if (!htInventory.ContainsKey(num))
                    {
                        htInventory.Add(num, Convert.ToInt32(num3));
                    }
                    else
                    {
                        htInventory[num] = Convert.ToInt32(htInventory[num].ToString()) + Convert.ToInt32(num1);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num1), type, EstimteItemID);
                }
                foreach (DataRow dataRow in ds.Tables[2].Rows)
                {
                    if (string.Compare(dataRow["PoType"].ToString(), "Outwork", true) != 0)
                    {
                        continue;
                    }
                    string.Compare(dataRow["IsEmpty"].ToString(), "No", true);
                }
                foreach (DataRow row1 in ds.Tables[3].Rows)
                {
                    if (string.Compare(row1["PoType"].ToString(), "single", true) != 0 || string.Compare(row1["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    num = Convert.ToInt64(row1["PaperID"]);
                    empty2 = "I";
                    row1["InventoryCode"].ToString();
                    row1["Inventoryname"].ToString();
                    num1 = Convert.ToInt32(row1["Quantity"]);
                    Convert.ToInt32(row1["PackedIn"]);
                    Convert.ToInt64(row1["EstimateSingleItemID"]);
                    Convert.ToDecimal(row1["PaperUnitPrice"]);
                    Convert.ToInt32(row1["PrintLayoutValue"]);
                    Convert.ToDecimal(row1["SetupSpoilage"]);
                    Convert.ToDecimal(row1["RunningSpoilage"]);
                    Convert.ToDecimal(row1["PaperMarkup"]);
                    EstimteItemID = Convert.ToInt64(row1["EstimateItemID"]);
                    num4 = Convert.ToDecimal(row1["InvSheets"]);
                    if (!htInventory.ContainsKey(num))
                    {
                        htInventory.Add(num, Convert.ToInt32(num4));
                    }
                    else
                    {
                        htInventory[num] = Convert.ToDecimal(htInventory[num].ToString()) + Convert.ToDecimal(num4);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num4), type, EstimteItemID);
                }
                foreach (DataRow dataRow1 in ds.Tables[4].Rows)
                {
                    if (string.Compare(dataRow1["PoType"].ToString(), "pad", true) != 0 || string.Compare(dataRow1["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    num = Convert.ToInt64(dataRow1["PaperID"]);
                    empty2 = "I";
                    dataRow1["InventoryCode"].ToString();
                    dataRow1["Inventoryname"].ToString();
                    num1 = Convert.ToInt32(dataRow1["Quantity"]);
                    Convert.ToInt32(dataRow1["PackedIn"]);
                    Convert.ToInt64(dataRow1["EstimatePadItemID"]);
                    Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                    Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow1["PaperMarkup"]);
                    EstimteItemID = Convert.ToInt64(dataRow1["EstimateItemID"]);
                    num4 = Convert.ToDecimal(dataRow1["InvSheets"]);
                    if (!htInventory.ContainsKey(num))
                    {
                        htInventory.Add(num, Convert.ToInt32(num4));
                    }
                    else
                    {
                        htInventory[num] = Convert.ToDecimal(htInventory[num].ToString()) + Convert.ToDecimal(num4);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num4), type, EstimteItemID);
                }
                foreach (DataRow row2 in ds.Tables[5].Rows)
                {
                    if (string.Compare(row2["PoType"].ToString(), "large", true) != 0 || string.Compare(row2["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    num = Convert.ToInt64(row2["PaperID"]);
                    empty2 = "I";
                    row2["InventoryCode"].ToString();
                    row2["Inventoryname"].ToString();
                    num1 = Convert.ToInt32(row2["Quantity"]);
                    Convert.ToInt32(row2["PackedIn"]);
                    Convert.ToInt64(row2["EstimateLargeItemID"]);
                    Convert.ToDecimal(row2["PaperUnitPrice"]);
                    Convert.ToInt32(row2["PrintLayoutValue"]);
                    Convert.ToDecimal(row2["SetupSpoilage"]);
                    Convert.ToDecimal(row2["RunningSpoilage"]);
                    EstimteItemID = Convert.ToInt64(row2["EstimateItemID"]);
                    row2["PressPaperType"].ToString();
                    num4 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row2["InvSheets"].ToString()), 0, "", false, false, true));
                    if (!htInventory.ContainsKey(num))
                    {
                        htInventory.Add(num, num4);
                    }
                    else
                    {
                        htInventory[num] = Convert.ToDecimal(htInventory[num].ToString()) + Convert.ToDecimal(num4);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, num4, type, EstimteItemID);
                }
                foreach (DataRow dataRow2 in ds.Tables[6].Rows)
                {
                    if (string.Compare(dataRow2["PoType"].ToString(), "Lithosingle", true) == 0 && string.Compare(dataRow2["IsEmpty"].ToString(), "No", true) == 0)
                    {
                        num = Convert.ToInt64(dataRow2["PaperID"]);
                        empty2 = "I";
                        dataRow2["InventoryCode"].ToString();
                        dataRow2["Inventoryname"].ToString();
                        num1 = Convert.ToInt32(dataRow2["Quantity"]);
                        Convert.ToDecimal(dataRow2["PackedIn"]);
                        Convert.ToInt64(dataRow2["EstLithoItemID"]);
                        Convert.ToDecimal(dataRow2["PaperUnitPrice"]);
                        Convert.ToInt32(dataRow2["PrintLayoutValue"]);
                        Convert.ToDecimal(dataRow2["SetupSpoilage"]);
                        Convert.ToDecimal(dataRow2["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow2["PaperMarkup"]);
                        EstimteItemID = Convert.ToInt64(dataRow2["EstimateItemID"]);
                        num4 = Convert.ToDecimal(dataRow2["InvSheets"]);
                        if (!htInventory.ContainsKey(num))
                        {
                            htInventory.Add(num, Convert.ToInt32(num4));
                        }
                        else
                        {
                            htInventory[num] = Convert.ToDecimal(htInventory[num].ToString()) + Convert.ToDecimal(num4);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num4), type, EstimteItemID);
                    }
                    dataTable = EstimatesBasePage.litho_estimate_select(CompanyID, EstimteItemID);
                    foreach (DataRow row3 in dataTable.Rows)
                    {
                        num = Convert.ToInt64(row3["PlateID"]);
                        empty2 = "I";
                        num1 = Convert.ToInt32(row3["Noofplates"]);
                        if (!htInventory.ContainsKey(num))
                        {
                            htInventory.Add(num, Convert.ToInt32(num1));
                        }
                        else
                        {
                            htInventory[num] = Convert.ToInt32(htInventory[num].ToString()) + Convert.ToInt32(num1);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num1), type, EstimteItemID);
                    }
                }
                foreach (DataRow dataRow3 in ds.Tables[7].Rows)
                {
                    if (string.Compare(dataRow3["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(dataRow3["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    num = Convert.ToInt64(dataRow3["PaperID"]);
                    empty2 = "I";
                    dataRow3["InventoryCode"].ToString();
                    dataRow3["Inventoryname"].ToString();
                    num1 = Convert.ToInt32(dataRow3["Quantity"]);
                    Convert.ToDecimal(dataRow3["PackedIn"]);
                    Convert.ToInt64(dataRow3["EstimateLithoPadItemID"]);
                    Convert.ToDecimal(dataRow3["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow3["PrintLayoutValue"]);
                    Convert.ToDecimal(dataRow3["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow3["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow3["PaperMarkup"]);
                    EstimteItemID = Convert.ToInt64(dataRow3["EstimateItemID"]);
                    num4 = Convert.ToDecimal(dataRow3["InvSheets"]);
                    if (!htInventory.ContainsKey(num))
                    {
                        htInventory.Add(num, Convert.ToInt32(num4));
                    }
                    else
                    {
                        htInventory[num] = Convert.ToDecimal(htInventory[num].ToString()) + Convert.ToDecimal(num4);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num4), type, EstimteItemID);
                    dataTable = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimteItemID);
                    foreach (DataRow row4 in dataTable.Rows)
                    {
                        num = Convert.ToInt64(row4["PlateID"]);
                        empty2 = "I";
                        num1 = Convert.ToInt32(row4["Noofplates"]);
                        if (!htInventory.ContainsKey(num))
                        {
                            htInventory.Add(num, Convert.ToInt32(num1));
                        }
                        else
                        {
                            htInventory[num] = Convert.ToInt32(htInventory[num].ToString()) + Convert.ToInt32(num1);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num, empty2, Convert.ToInt32(num1), type, EstimteItemID);
                    }
                }
                foreach (DataRow dataRow4 in ds.Tables[8].Rows)
                {
                    if (string.Compare(dataRow4["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(dataRow4["IsEmpty"].ToString(), "No", true) != 0)
                    {
                        continue;
                    }
                    long num5 = Convert.ToInt64(dataRow4["PriceCatalogueID"]);
                    EstimteItemID = Convert.ToInt64(dataRow4["EstimateItemID"]);
                    num1 = Convert.ToInt32(dataRow4["Quantity"]);
                    num2 = Convert.ToDecimal(dataRow4["Price"]);
                    long num6 = Convert.ToInt64(dataRow4["EstimateItemID"].ToString());
                    BaseClass baseClass1 = new BaseClass();
                    string str3 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                    string str4 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str5 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    string str6 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                    string str7 = baseClass1.Return_StockManagementSettings("SC_IfJobCancelled");
                    if (str3 == "e")
                    {
                        foreach (DataRow row5 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                        {
                            if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockAllocationProcess((long)CompanyID, num5, (long)0, num1, str4, "self", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockAllocation_Others((long)CompanyID, num5, num1, str4, Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockAllocationProcess((long)CompanyID, num5, (long)0, num1, str4, "multiple", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else
                            {
                                empty = baseClass1.StockAllocationForAdditionalOption((long)CompanyID, num5, num1, str4, "additional option", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                        }
                    }
                    else if (str3 == "j" && baseClass1.Return_StockManagementSettings("SA_JobStatusID") == StatusID.ToString())
                    {
                        foreach (DataRow dataRow5 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                        {
                            if (dataRow5["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockAllocationProcess((long)CompanyID, num5, (long)0, num1, str4, "self", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else if (dataRow5["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockAllocation_Others((long)CompanyID, num5, num1, str4, Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else if (dataRow5["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow5["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockAllocationProcess((long)CompanyID, num5, (long)0, num1, str4, "multiple", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                            else
                            {
                                empty = baseClass1.StockAllocationForAdditionalOption((long)CompanyID, num5, num1, str4, "additional option", Convert.ToBoolean(str5), num6, "Job", num2, (long)UserID);
                            }
                        }
                    }
                    if (str6 == "e")
                    {
                        foreach (DataRow row6 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                        {
                            if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "self", num1, num6, "Job", (long)UserID, num2);
                            }
                            else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num5, "other", num1, num6, "Job", (long)UserID, num2);
                            }
                            else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "multiple", num1, num6, "Job", (long)UserID, num2);
                            }
                            else
                            {
                                empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num5, "additional option", num1, num6, "Job", (long)UserID, num2);
                            }
                        }
                    }
                    else if (str6 == "j")
                    {
                        if (baseClass1.Return_StockManagementSettings("SR_JobStatusID") != Convert.ToString(StatusID))
                        {
                            long num7 = (long)0;
                            DataTable dataTable1 = JobBasePage.QuickLinks_ItemDetials_Select(CompanyID, num6);
                            DataTable dataTable2 = new DataTable();
                            foreach (DataRow dataRow6 in dataTable1.Rows)
                            {
                                num7 = Convert.ToInt64(dataRow6["JobID"]);
                            }
                            if (num7 > (long)0)
                            {
                                dataTable2 = JobBasePage.Job_Card_Full_Info_Select_By_JobID(num7);
                            }
                            foreach (DataRow row7 in dataTable2.Rows)
                            {
                                if (Convert.ToInt64(row7["EstimateItemID"]) != num6 || Convert.ToInt64(row7["InvoiceID"]) <= (long)0)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow7 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                                {
                                    if (dataRow7["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "self", num1, num6, "Job", (long)UserID, num2);
                                    }
                                    else if (dataRow7["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num5, "other", num1, num6, "Job", (long)UserID, num2);
                                    }
                                    else if (dataRow7["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow7["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "multiple", num1, num6, "Job", (long)UserID, num2);
                                    }
                                    else
                                    {
                                        empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num5, "additional option", num1, num6, "Job", (long)UserID, num2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow row8 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                            {
                                if (row8["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "self", num1, num6, "Job", (long)UserID, num2);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num5, "other", num1, num6, "Job", (long)UserID, num2);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row8["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "multiple", num1, num6, "Job", (long)UserID, num2);
                                }
                                else
                                {
                                    empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num5, "additional option", num1, num6, "Job", (long)UserID, num2);
                                }
                            }
                        }
                    }
                    else if (str6 == "c" && type.Contains("complete"))
                    {
                        foreach (DataRow dataRow8 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                        {
                            if (dataRow8["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "self", num1, num6, "Job", (long)UserID, num2);
                            }
                            else if (dataRow8["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockReductionProcess((long)CompanyID, (long)0, num5, "other", num1, num6, "Job", (long)UserID, num2);
                            }
                            else if (dataRow8["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow8["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockReductionProcess((long)CompanyID, num5, (long)0, "multiple", num1, num6, "Job", (long)UserID, num2);
                            }
                            else
                            {
                                empty = baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num5, "additional option", num1, num6, "Job", (long)UserID, num2);
                            }
                        }
                    }
                    if (!type.Contains("cancelled") && !type.Contains("revert") || !(str7 == "p") && !(str7 == "a"))
                    {
                        continue;
                    }
                    foreach (DataRow row9 in baseClass1.ProductStockType_Select((long)CompanyID, num5).Rows)
                    {
                        if (row9["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            empty = baseClass1.StockCancellationProcess((long)CompanyID, num5, (long)0, "self", num6, "Job", (long)UserID, str7);
                        }
                        else if (row9["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            empty = baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num5, "other", num6, "Job", (long)UserID, str7);
                        }
                        else if (row9["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (row9["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            empty = baseClass1.StockCancellationProcess((long)CompanyID, num5, (long)0, "multiple", num6, "Job", (long)UserID, str7);
                        }
                        else
                        {
                            empty = baseClass1.StockCancellationProcess((long)CompanyID, num5, (long)0, "additional option", num6, "Job", (long)UserID, str7);
                        }
                    }
                }
            }
            catch
            {
            }
            return empty;
        }

        public static void SubItem_Purchase_Order_Insert(DataSet ds, string StrJobNum, int StatusID, long EstimateID, int UserID, int CompanyID, Hashtable htInventory, long EstimateItemID, string DateFormat, string CustomerName, out string AddPurchaseOrders)
        {
            object[] objArray;
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            long num4 = (long)0;
            DateTime now = DateTime.Now;
            string str1 = _commonClass.date_Check_new(DateFormat, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime = Convert.ToDateTime(str1);
            now = DateTime.Now;
            SummaryClass.CreatedDate = Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, UserID, true));
            long num5 = (long)0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num6 = 0;
            int num7 = 0;
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            string empty3 = string.Empty;
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);
            string str3 = string.Empty;
            DataTable dataTable = new DataTable();
            string empty4 = string.Empty;
            string str4 = string.Empty;
            long num14 = (long)0;
            DateTime dateTime1 = DateTime.Now.AddDays(5);
            str3 = _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(CompanyID);
            SummaryClass.ManageStockPermission = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            SummaryClass.StockCancellationType = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            decimal taxRate = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            DateTime now1 = DateTime.Now;
            decimal num15 = new decimal(0);
            string serverName = ConnectionClass.ServerName;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                str = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in ds.Tables[1].Rows)
            {
                if (string.Compare(dataRow["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(dataRow["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(dataRow["WarehouseTypeID"]);
                empty2 = dataRow["WarehouseType"].ToString();
                str2 = dataRow["ItemCode"].ToString();
                num6 = Convert.ToInt32(dataRow["Quantity"]);
                num7 = Convert.ToInt32(dataRow["PackedIn"]);
                num9 = Convert.ToDecimal(dataRow["UnitPrice"]);
                num8 = num6 * num9;
                num1 = Convert.ToInt32(dataRow["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow["AddressID"].ToString());
                empty = dataRow["AddressType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(dataRow["EstimateItemID"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow["PoReqDate"]);
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, 0, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num16 = (num8 * taxRate) / new decimal(100);
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, "", num6, num7, Convert.ToDecimal(num8), taxID, num16, 0, "", false, EstimateItemID, "w", (long)0, UserID, SummaryClass.CreatedDate);
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num6));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToInt32(htInventory[num5].ToString()) + Convert.ToInt32(num6);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "completed", EstimateItemID);
                }
                foreach (DataRow row1 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row1["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow1 in ds.Tables[2].Rows)
            {
                if (string.Compare(dataRow1["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(dataRow1["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = (long)0;
                empty2 = "A";
                str2 = "";
                num6 = Convert.ToInt32(dataRow1["Quantity"]);
                num7 = 0;
                num8 = Convert.ToDecimal(dataRow1["Price"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow1["EstimateItemID"].ToString());
                num1 = Convert.ToInt32(dataRow1["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow1["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(dataRow1["AddressID"].ToString());
                empty = dataRow1["AddressType"].ToString();
                string str5 = SummaryClass.Split_ItemDescription(dataRow1["Description"].ToString());
                string str6 = dataRow1["Notes"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow1["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow1["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num17 = (num8 * taxRate) / new decimal(100);
                num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str5, num6, num7, Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num17), 0, str6, false, EstimateItemID, "O", (long)0, UserID, SummaryClass.CreatedDate);
                foreach (DataRow row2 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row2["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow2 in ds.Tables[3].Rows)
            {
                if (string.Compare(dataRow2["PoType"].ToString(), "single", true) != 0 || string.Compare(dataRow2["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(dataRow2["PaperID"]);
                empty2 = "I";
                str2 = dataRow2["InventoryCode"].ToString();
                empty3 = dataRow2["Inventoryname"].ToString();
                num6 = Convert.ToInt32(dataRow2["Quantity"]);
                num7 = Convert.ToInt32(dataRow2["PackedIn"]);
                Convert.ToInt64(dataRow2["EstimateSingleItemID"]);
                num9 = Convert.ToDecimal(dataRow2["PaperUnitPrice"]);
                Convert.ToInt32(dataRow2["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow2["SetupSpoilage"]);
                Convert.ToDecimal(dataRow2["RunningSpoilage"]);
                Convert.ToDecimal(dataRow2["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow2["EstimateItemID"].ToString());
                num15 = Convert.ToDecimal(dataRow2["InvSheets"]);
                if (dataRow2["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num12 = Convert.ToDecimal(dataRow2["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num15, num7, num12, new decimal(0), out num13);
                    num11 = num13;
                }
                else
                {
                    num8 = num15 * num9;
                }
                num1 = Convert.ToInt32(dataRow2["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow2["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow2["AddressID"].ToString());
                empty = dataRow2["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow2["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow2["PoReqDate"]);
                if (dataRow2["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num18 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToInt32(num15), num7, Convert.ToDecimal(num8), taxID, num18, 0, "", false, EstimateItemID, "S", (long)0, UserID, SummaryClass.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num15));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num15);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "completed", EstimateItemID);
                }
                foreach (DataRow row3 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row3["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow3 in ds.Tables[4].Rows)
            {
                if (string.Compare(dataRow3["PoType"].ToString(), "pad", true) != 0 || string.Compare(dataRow3["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(dataRow3["PaperID"]);
                empty2 = "I";
                str2 = dataRow3["InventoryCode"].ToString();
                empty3 = dataRow3["Inventoryname"].ToString();
                num6 = Convert.ToInt32(dataRow3["Quantity"]);
                num7 = Convert.ToInt32(dataRow3["PackedIn"]);
                Convert.ToInt64(dataRow3["EstimatePadItemID"]);
                num9 = Convert.ToDecimal(dataRow3["PaperUnitPrice"]);
                Convert.ToInt32(dataRow3["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow3["SetupSpoilage"]);
                Convert.ToDecimal(dataRow3["RunningSpoilage"]);
                Convert.ToDecimal(dataRow3["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow3["EstimateItemID"].ToString());
                num15 = Convert.ToDecimal(dataRow3["InvSheets"]);
                if (dataRow3["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(dataRow3["LeavesPerPad"]);
                }
                if (dataRow3["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num12 = Convert.ToDecimal(dataRow3["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num15, num7, num12, new decimal(0), out num13);
                    num11 = num13;
                }
                else
                {
                    num8 = num15 * num9;
                }
                num1 = Convert.ToInt32(dataRow3["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow3["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow3["AddressID"].ToString());
                empty = dataRow3["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow3["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow3["PoReqDate"]);
                if (dataRow3["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num19 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToInt32(num15), num11, Convert.ToDecimal(num8), taxID, num19, 0, "", false, EstimateItemID, "P", (long)0, UserID, SummaryClass.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num15));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num15);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "completed", EstimateItemID);
                }
                foreach (DataRow row4 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row4["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow4 in ds.Tables[5].Rows)
            {
                if (string.Compare(dataRow4["PoType"].ToString(), "large", true) != 0 || string.Compare(dataRow4["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(dataRow4["PaperID"]);
                empty2 = "I";
                str2 = dataRow4["InventoryCode"].ToString();
                empty3 = dataRow4["Inventoryname"].ToString();
                num6 = Convert.ToInt32(dataRow4["Quantity"]);
                num7 = Convert.ToInt32(dataRow4["PackedIn"]);
                Convert.ToInt64(dataRow4["EstimateLargeItemID"]);
                num9 = Convert.ToDecimal(dataRow4["PaperUnitPrice"]);
                Convert.ToInt32(dataRow4["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow4["SetupSpoilage"]);
                Convert.ToDecimal(dataRow4["RunningSpoilage"]);
                dataRow4["PressPaperType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(dataRow4["EstimateItemID"].ToString());
                num14 = Convert.ToInt64(dataRow4["EstLargeItemCalculationID"]);
                num15 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow4["InvSheets"].ToString()), 0, "", false, false, true));
                if (dataRow4["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num12 = Convert.ToDecimal(dataRow4["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num15, num11, num12, new decimal(0), out num13);
                    num11 = num13;
                }
                else
                {
                    num8 = num15 * num9;
                }
                num1 = Convert.ToInt32(dataRow4["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow4["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow4["AddressID"].ToString());
                empty = dataRow4["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow4["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow4["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num20 = (num8 * taxRate) / new decimal(100);
                num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToInt32(num15), num7, Convert.ToDecimal(num8), taxID, num20, 0, "", false, EstimateItemID, "L", num14, UserID, SummaryClass.CreatedDate);
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, num15);
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num15);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, num15, "completed", EstimateItemID);
                }
                foreach (DataRow row5 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row5["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow5 in ds.Tables[6].Rows)
            {
                if (string.Compare(dataRow5["PoType"].ToString(), "Lithosingle", true) != 0 || string.Compare(dataRow5["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(dataRow5["PaperID"]);
                empty2 = "I";
                str2 = dataRow5["InventoryCode"].ToString();
                empty3 = dataRow5["Inventoryname"].ToString();
                num6 = Convert.ToInt32(dataRow5["Quantity"]);
                num11 = Convert.ToDecimal(dataRow5["PackedIn"]);
                Convert.ToInt64(dataRow5["EstLithoItemID"]);
                num9 = Convert.ToDecimal(dataRow5["PaperUnitPrice"]);
                Convert.ToInt32(dataRow5["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow5["SetupSpoilage"]);
                Convert.ToDecimal(dataRow5["RunningSpoilage"]);
                Convert.ToDecimal(dataRow5["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow5["EstimateItemID"].ToString());
                num15 = Convert.ToDecimal(dataRow5["InvSheets"]);
                if (dataRow5["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num12 = Convert.ToDecimal(dataRow5["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num15, num11, num12, new decimal(0), out num13);
                    num11 = num13;
                }
                else
                {
                    num8 = num15 * num9;
                }
                num1 = Convert.ToInt32(dataRow5["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow5["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow5["AddressID"].ToString());
                empty = dataRow5["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow5["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow5["PoReqDate"]);
                if (dataRow5["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num21 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num15), Convert.ToDecimal(num11), Convert.ToDecimal(num8), taxID, num21, 0, "", false, EstimateItemID, "F", (long)0, UserID, SummaryClass.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num15));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num15);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "completed", EstimateItemID);
                }
                dataTable = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                foreach (DataRow row6 in dataTable.Rows)
                {
                    num5 = Convert.ToInt64(row6["PlateID"]);
                    empty2 = "I";
                    num6 = Convert.ToInt32(row6["Noofplates"]);
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "progressed", EstimateItemID);
                    if (str3 != "e")
                    {
                        continue;
                    }
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num6));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToInt32(htInventory[num5].ToString()) + Convert.ToInt32(num6);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "completed", EstimateItemID);
                }
                foreach (DataRow dataRow6 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow6["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow row7 in ds.Tables[7].Rows)
            {
                if (string.Compare(row7["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(row7["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = Convert.ToInt64(row7["PaperID"]);
                empty2 = "I";
                str2 = row7["InventoryCode"].ToString();
                empty3 = row7["Inventoryname"].ToString();
                num6 = Convert.ToInt32(row7["Quantity"]);
                num11 = Convert.ToDecimal(row7["PackedIn"]);
                Convert.ToInt64(row7["EstimateLithoPadItemID"]);
                num9 = Convert.ToDecimal(row7["PaperUnitPrice"]);
                Convert.ToInt32(row7["PrintLayoutValue"]);
                Convert.ToDecimal(row7["SetupSpoilage"]);
                Convert.ToDecimal(row7["RunningSpoilage"]);
                Convert.ToDecimal(row7["PaperMarkup"]);
                if (row7["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(row7["LeavesPerPad"]);
                }
                EstimateItemID = (long)Convert.ToInt32(row7["EstimateItemID"].ToString());
                num15 = Convert.ToDecimal(row7["InvSheets"]);
                if (row7["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num12 = Convert.ToDecimal(row7["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num15, num11, num12, new decimal(0), out num13);
                    num11 = num13;
                }
                else
                {
                    num8 = num15 * num9;
                }
                num1 = Convert.ToInt32(row7["SupplierID"].ToString());
                num2 = Convert.ToInt32(row7["ContactID"].ToString());
                num3 = Convert.ToInt64(row7["AddressID"].ToString());
                empty = row7["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row7["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(row7["PoReqDate"]);
                if (row7["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num22 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num15), Convert.ToDecimal(num11), Convert.ToDecimal(num8), taxID, num22, 0, "", false, EstimateItemID, "D", (long)0, UserID, SummaryClass.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num10), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num15));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num15);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num15), "completed", EstimateItemID);
                }
                dataTable = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                foreach (DataRow dataRow7 in dataTable.Rows)
                {
                    num5 = Convert.ToInt64(dataRow7["PlateID"]);
                    empty2 = "I";
                    num6 = Convert.ToInt32(dataRow7["Noofplates"]);
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "progressed", EstimateItemID);
                    if (str3 != "e")
                    {
                        continue;
                    }
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num6));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToInt32(htInventory[num5].ToString()) + Convert.ToInt32(num6);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "completed", EstimateItemID);
                }
                foreach (DataRow row8 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row8["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
            }
            foreach (DataRow dataRow8 in ds.Tables[8].Rows)
            {
                if (string.Compare(dataRow8["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(dataRow8["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                num5 = (long)0;
                empty2 = "A";
                str2 = "";
                num6 = Convert.ToInt32(dataRow8["Quantity"]);
                num7 = Convert.ToInt32(dataRow8["Quantity"]);
                num8 = Convert.ToDecimal(dataRow8["Price"]);
                long num23 = Convert.ToInt64(dataRow8["PriceCatalogueID"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow8["EstimateItemID"].ToString());
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow8["DeliveryAddress"].ToString());
                num1 = Convert.ToInt32(dataRow8["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow8["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(dataRow8["AddressID"].ToString());
                empty = dataRow8["AddressType"].ToString();
                string str7 = SummaryClass.Split_ItemDescription(dataRow8["ItemDescription"].ToString());
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                empty6 = dataRow8["Notes"].ToString();
                dataRow8["Material"].ToString();
                dateTime1 = Convert.ToDateTime(dataRow8["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num24 = (num8 * taxRate) / new decimal(100);
                DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num23);
                if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str7, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num24), 0, empty6, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else if (SummaryClass.ManageStockPermission != 1)
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str7, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num24), 0, empty6, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str7, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num24), 0, empty6, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else
                {
                    foreach (DataRow row9 in PurchaseBasePage.Kit_Details(num23).Rows)
                    {
                        int num25 = num6 * Convert.ToInt16(row9["Quantity"]);
                        DataTable dataTable3 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(row9["KitItemID"]));
                        string str8 = dataTable3.Rows[0]["ItemCode"].ToString();
                        string str9 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(row9["KitItemID"])).Replace("»", "\n");
                        num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, Convert.ToInt64(row9["KitItemID"]), "W", str8, str9, Convert.ToDecimal(num25), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num24), 0, empty6, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                    }
                }
                foreach (DataRow dataRow9 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow9["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(objArray);
                BaseClass baseClass1 = new BaseClass();
                string str10 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                string str11 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                string str12 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string str13 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                if (SummaryClass.IsStockCancel)
                {
                    if (!(SummaryClass.StockCancellationType == "a") && !(SummaryClass.StockCancellationType == "p") || !SummaryClass.IsStockCancel)
                    {
                        continue;
                    }
                    foreach (DataRow row10 in baseClass1.ProductStockType_Select((long)CompanyID, num23).Rows)
                    {
                        if (row10["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, num23, (long)0, "self", EstimateItemID, "Job", (long)UserID, SummaryClass.StockCancellationType);
                        }
                        else if (row10["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num23, "other", EstimateItemID, "Job", (long)UserID, SummaryClass.StockCancellationType);
                        }
                        else if (row10["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (row10["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            baseClass1.StockCancellationProcess((long)CompanyID, num23, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, SummaryClass.StockCancellationType);
                        }
                        else
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, num23, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, SummaryClass.StockCancellationType);
                        }
                    }
                }
                else
                {
                    if (str10 == "e")
                    {
                        foreach (DataRow dataRow10 in baseClass1.ProductStockType_Select((long)CompanyID, num23).Rows)
                        {
                            if (dataRow10["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockAllocationProcess((long)CompanyID, num23, (long)0, num6, str11, "self", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                            else if (dataRow10["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass1.StockAllocation_Others((long)CompanyID, num23, num6, str11, Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else if (dataRow10["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow10["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)CompanyID, num23, (long)0, num6, str11, "multiple", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else
                            {
                                baseClass1.StockAllocationForAdditionalOption((long)CompanyID, num23, num6, str11, "additional option", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                        }
                    }
                    else if (str10 == "j" && baseClass1.Return_StockManagementSettings("SA_JobStatusID") == StatusID.ToString())
                    {
                        foreach (DataRow row11 in baseClass1.ProductStockType_Select((long)CompanyID, num23).Rows)
                        {
                            if (row11["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockAllocationProcess((long)CompanyID, num23, (long)0, num6, str11, "self", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                            else if (row11["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass1.StockAllocation_Others((long)CompanyID, num23, num6, str11, Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else if (row11["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row11["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)CompanyID, num23, (long)0, num6, str11, "multiple", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else
                            {
                                baseClass1.StockAllocationForAdditionalOption((long)CompanyID, num23, num6, str11, "additional option", Convert.ToBoolean(str12), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                        }
                    }
                    if (str13 != "c")
                    {
                        if (!(str13 == "j") || !(baseClass1.Return_StockManagementSettings("SR_JobStatusID") == StatusID.ToString()))
                        {
                            continue;
                        }
                        foreach (DataRow dataRow11 in baseClass1.ProductStockType_Select((long)CompanyID, num23).Rows)
                        {
                            if (dataRow11["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockReductionProcess((long)CompanyID, num23, (long)0, "self", num6, EstimateItemID, "Job", (long)UserID, num8);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                            else if (dataRow11["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass1.StockReductionProcess((long)CompanyID, (long)0, num23, "other", num6, EstimateItemID, "Job", (long)UserID, num8);
                            }
                            else if (dataRow11["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow11["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass1.StockReductionProcess((long)CompanyID, num23, (long)0, "multiple", num6, EstimateItemID, "Job", (long)UserID, num8);
                            }
                            else
                            {
                                baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num23, "additional option", num6, EstimateItemID, "Job", (long)UserID, num8);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row12 in baseClass1.ProductStockType_Select((long)CompanyID, num23).Rows)
                        {
                            if (row12["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockReductionProcess((long)CompanyID, num23, (long)0, "self", num6, EstimateItemID, "Job", (long)UserID, num8);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                            else if (row12["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass1.StockReductionProcess((long)CompanyID, (long)0, num23, "other", num6, EstimateItemID, "Job", (long)UserID, num8);
                            }
                            else if (row12["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row12["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass1.StockReductionProcess((long)CompanyID, num23, (long)0, "multiple", num6, EstimateItemID, "Job", (long)UserID, num8);
                            }
                            else
                            {
                                baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num23, "additional option", num6, EstimateItemID, "Job", (long)UserID, num8);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num23, num4);
                            }
                        }
                    }
                }
            }
            foreach (DataRow dataRow12 in ds.Tables[9].Rows)
            {
                if (string.Compare(dataRow12["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(dataRow12["IsEmpty"].ToString().ToLower(), "no", true) != 0)
                {
                    continue;
                }
                num6 = Convert.ToInt32(dataRow12["Quantity"]);
                dateTime1 = Convert.ToDateTime(dataRow12["PoReqDate"]);
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow12["DeliveryAddress"].ToString());
                num1 = Convert.ToInt32(dataRow12["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow12["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow12["AddressID"].ToString());
                num8 = Convert.ToDecimal(dataRow12["cost"].ToString());
                empty3 = dataRow12["ItemDescription"].ToString();
                long num26 = Convert.ToInt64(dataRow12["estOtherCostID"].ToString());
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, now1, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num27 = new decimal(0);
                num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num27), 0, "", false, num26, "U", (long)0, UserID, SummaryClass.CreatedDate);
                foreach (DataRow row13 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row13["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str4, CustomerName, CompanyID, UserID);
            }
            AddPurchaseOrders = empty4;
        }

        public static void SubItem_Purchase_Order_Insert_ForAdditionalItems(DataSet ds, string StrJobNum, int StatusID, long EstimateID, int UserID, int CompanyID, long EstimateItemID, string DateFormat, string additionalItemID, string CustomerName, out string AddPurchaseOrders, out string AddItemNumbers)
        {
            object[] objArray;
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(CompanyID);
            SummaryClass.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            DateTime now = DateTime.Now;
            string str1 = _commonClass.date_Check_new(DateFormat, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime = Convert.ToDateTime(str1);
            long num4 = (long)0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num5 = 0;
            int num6 = 0;
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            string pODN = string.Empty;
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            string empty3 = string.Empty;
            long num12 = (long)0;
            DataTable dataTable1 = new DataTable();
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            long estimateItemID = EstimateItemID;
            DateTime dateTime1 = DateTime.Now.AddDays(5);
            decimal num13 = new decimal(0);
            _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            string serverName = ConnectionClass.ServerName;
            string empty5 = string.Empty;
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                empty5 = "job";
            }
            else if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                empty5 = "invoice";
            }
            else if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("estimates/estimate"))
            {
                empty5 = "estimate";
            }
            else if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                empty5 = "order";
            }
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                str = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in ds.Tables[1].Rows)
            {
                if (string.Compare(dataRow["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(dataRow["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow["WarehouseTypeID"]);
                empty2 = dataRow["WarehouseType"].ToString();
                str2 = dataRow["ItemCode"].ToString();
                num5 = Convert.ToInt32(dataRow["Quantity"]);
                num6 = Convert.ToInt32(dataRow["PackedIn"]);
                num8 = Convert.ToDecimal(dataRow["UnitPrice"]);
                num7 = num5 * num8;
                num1 = Convert.ToInt32(dataRow["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow["AddressID"].ToString());
                empty = dataRow["AddressType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(dataRow["EstimateItemID"].ToString());
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, 0, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, "", num5, num6, Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "W", (long)0, UserID, SummaryClass.CreatedDate);
                foreach (DataRow row1 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = row1["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string str5 = string.Empty;
                foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    str5 = dataRow1["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", str5);
            }
            foreach (DataRow row2 in ds.Tables[2].Rows)
            {
                if (string.Compare(row2["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(row2["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row2["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = (long)0;
                empty2 = "A";
                str2 = "";
                num5 = Convert.ToInt32(row2["Quantity"]);
                num6 = 0;
                num7 = Convert.ToDecimal(row2["Price"]);
                decimal num14 = new decimal(0);
                int num15 = 0;
                EstimateItemID = (long)Convert.ToInt32(row2["EstimateItemID"].ToString());
                num1 = Convert.ToInt32(row2["SupplierID"].ToString());
                num2 = Convert.ToInt32(row2["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(row2["AddressID"].ToString());
                empty = row2["AddressType"].ToString();
                string str6 = SummaryClass.Split_ItemDescription(row2["Description"].ToString());
                string str7 = row2["Notes"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row2["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(row2["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, str6, num5, num6, Convert.ToDecimal(num7), num15, Convert.ToDecimal(num14), 0, str7, false, EstimateItemID, "O", (long)0, UserID, SummaryClass.CreatedDate);
                foreach (DataRow dataRow2 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = dataRow2["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty6 = string.Empty;
                foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty6 = row3["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty6);
            }
            foreach (DataRow dataRow3 in ds.Tables[3].Rows)
            {
                if (string.Compare(dataRow3["PoType"].ToString(), "single", true) != 0 || string.Compare(dataRow3["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow3["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow3["PaperID"]);
                empty2 = "I";
                str2 = dataRow3["InventoryCode"].ToString();
                pODN = dataRow3["Inventoryname"].ToString();
                num5 = Convert.ToInt32(dataRow3["Quantity"]);
                num6 = Convert.ToInt32(dataRow3["PackedIn"]);
                Convert.ToInt64(dataRow3["EstimateSingleItemID"]);
                num8 = Convert.ToDecimal(dataRow3["PaperUnitPrice"]);
                Convert.ToInt32(dataRow3["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow3["SetupSpoilage"]);
                Convert.ToDecimal(dataRow3["RunningSpoilage"]);
                Convert.ToDecimal(dataRow3["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow3["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(dataRow3["InvSheets"]);
                if (dataRow3["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(dataRow3["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(dataRow3["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow3["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow3["AddressID"].ToString());
                empty = dataRow3["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow3["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow3["PoReqDate"]);
                if (dataRow3["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToInt32(num13), num6, Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "S", (long)0, UserID, SummaryClass.CreatedDate);
                }
                foreach (DataRow row4 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = row4["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty7 = string.Empty;
                foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty7 = dataRow4["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty7);
            }
            foreach (DataRow row5 in ds.Tables[4].Rows)
            {
                if (string.Compare(row5["PoType"].ToString(), "pad", true) != 0 || string.Compare(row5["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row5["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(row5["PaperID"]);
                empty2 = "I";
                str2 = row5["InventoryCode"].ToString();
                pODN = row5["Inventoryname"].ToString();
                num5 = Convert.ToInt32(row5["Quantity"]);
                num6 = Convert.ToInt32(row5["PackedIn"]);
                Convert.ToInt64(row5["EstimatePadItemID"]);
                num8 = Convert.ToDecimal(row5["PaperUnitPrice"]);
                Convert.ToInt32(row5["PrintLayoutValue"]);
                Convert.ToDecimal(row5["SetupSpoilage"]);
                Convert.ToDecimal(row5["RunningSpoilage"]);
                Convert.ToDecimal(row5["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row5["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(row5["InvSheets"]);
                if (row5["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(row5["LeavesPerPad"]);
                }
                if (row5["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(row5["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(row5["SupplierID"].ToString());
                num2 = Convert.ToInt32(row5["ContactID"].ToString());
                num3 = Convert.ToInt64(row5["AddressID"].ToString());
                empty = row5["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row5["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(row5["PoReqDate"]);
                if (row5["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToInt32(num13), num6, Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "P", (long)0, UserID, SummaryClass.CreatedDate);
                }
                foreach (DataRow dataRow5 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = dataRow5["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty8 = string.Empty;
                foreach (DataRow row6 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty8 = row6["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty8);
            }
            foreach (DataRow dataRow6 in ds.Tables[5].Rows)
            {
                if (string.Compare(dataRow6["PoType"].ToString(), "large", true) != 0 || string.Compare(dataRow6["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow6["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow6["PaperID"]);
                empty2 = "I";
                str2 = dataRow6["InventoryCode"].ToString();
                pODN = dataRow6["Inventoryname"].ToString();
                num5 = Convert.ToInt32(dataRow6["Quantity"]);
                num6 = Convert.ToInt32(dataRow6["PackedIn"]);
                Convert.ToInt64(dataRow6["EstimateLargeItemID"]);
                num8 = Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                Convert.ToInt32(dataRow6["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                dataRow6["PressPaperType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(dataRow6["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(dataRow6["InvSheets"]);
                num12 = Convert.ToInt64(dataRow6["EstLargeItemCalculationID"]);
                if (dataRow6["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(dataRow6["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(dataRow6["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow6["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow6["AddressID"].ToString());
                empty = dataRow6["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow6["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow6["PoReqDate"]);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToInt32(num13), num9, Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "L", num12, UserID, SummaryClass.CreatedDate);
                foreach (DataRow row7 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = row7["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string str8 = string.Empty;
                foreach (DataRow dataRow7 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    str8 = dataRow7["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", str8);
            }
            foreach (DataRow row8 in ds.Tables[6].Rows)
            {
                if (string.Compare(row8["PoType"].ToString(), "Lithosingle", true) != 0 || string.Compare(row8["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row8["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(row8["PaperID"]);
                empty2 = "I";
                str2 = row8["InventoryCode"].ToString();
                pODN = row8["Inventoryname"].ToString();
                num5 = Convert.ToInt32(row8["Quantity"]);
                num9 = Convert.ToDecimal(row8["PackedIn"]);
                Convert.ToInt64(row8["EstLithoItemID"]);
                num8 = Convert.ToDecimal(row8["PaperUnitPrice"]);
                Convert.ToInt32(row8["PrintLayoutValue"]);
                Convert.ToDecimal(row8["SetupSpoilage"]);
                Convert.ToDecimal(row8["RunningSpoilage"]);
                Convert.ToDecimal(row8["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row8["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(row8["InvSheets"]);
                if (row8["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(row8["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(row8["SupplierID"].ToString());
                num2 = Convert.ToInt32(row8["ContactID"].ToString());
                num3 = Convert.ToInt64(row8["AddressID"].ToString());
                empty = row8["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row8["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(row8["PoReqDate"]);
                if (row8["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num9), Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "F", (long)0, UserID, SummaryClass.CreatedDate);
                }
                foreach (DataRow dataRow8 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = dataRow8["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty9 = string.Empty;
                foreach (DataRow row9 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty9 = row9["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty9);
            }
            foreach (DataRow dataRow9 in ds.Tables[7].Rows)
            {
                if (string.Compare(dataRow9["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(dataRow9["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow9["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow9["PaperID"]);
                empty2 = "I";
                str2 = dataRow9["InventoryCode"].ToString();
                pODN = dataRow9["Inventoryname"].ToString();
                num5 = Convert.ToInt32(dataRow9["Quantity"]);
                num9 = Convert.ToDecimal(dataRow9["PackedIn"]);
                Convert.ToInt64(dataRow9["EstimateLithoPadItemID"]);
                num8 = Convert.ToDecimal(dataRow9["PaperUnitPrice"]);
                Convert.ToInt32(dataRow9["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow9["SetupSpoilage"]);
                Convert.ToDecimal(dataRow9["RunningSpoilage"]);
                Convert.ToDecimal(dataRow9["PaperMarkup"]);
                if (dataRow9["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(dataRow9["LeavesPerPad"]);
                }
                EstimateItemID = (long)Convert.ToInt32(dataRow9["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(dataRow9["InvSheets"]);
                if (dataRow9["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(dataRow9["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(dataRow9["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow9["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow9["AddressID"].ToString());
                empty = dataRow9["AddressType"].ToString();
                SummaryClass.DeliveryAddressID = Convert.ToInt64(dataRow9["DeliveryAddress"].ToString());
                dateTime1 = Convert.ToDateTime(dataRow9["PoReqDate"]);
                if (dataRow9["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                    SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num9), Convert.ToDecimal(num7), 0, new decimal(0), 0, "", false, EstimateItemID, "D", (long)0, UserID, SummaryClass.CreatedDate);
                }
                foreach (DataRow row10 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = row10["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string str9 = string.Empty;
                foreach (DataRow dataRow10 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    str9 = dataRow10["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", str9);
            }
            foreach (DataRow row11 in ds.Tables[8].Rows)
            {
                if (string.Compare(row11["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(row11["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row11["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = (long)0;
                empty2 = "A";
                str2 = "";
                num5 = Convert.ToInt32(row11["Quantity"]);
                num6 = Convert.ToInt32(row11["Quantity"]);
                num7 = Convert.ToDecimal(row11["Price"]);
                long num16 = Convert.ToInt64(row11["PriceCatalogueID"]);
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row11["DeliveryAddress"].ToString());
                decimal num17 = new decimal(0);
                int num18 = 0;
                num1 = Convert.ToInt32(row11["SupplierID"].ToString());
                num2 = Convert.ToInt32(row11["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(row11["AddressID"].ToString());
                empty = row11["AddressType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(row11["EstimateItemID"].ToString());
                string str10 = SummaryClass.Split_ItemDescription(row11["ItemDescription"].ToString());
                string empty10 = string.Empty;
                string empty11 = string.Empty;
                string str11 = string.Empty;
                row11["Notes"].ToString();
                row11["Material"].ToString();
                dateTime1 = Convert.ToDateTime(row11["PoReqDate"]);
                pODN = _commonClass.ItemDescriptionToPO_DN(CompanyID, EstimateItemID, "Purchase", ref str11);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num16);
                if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, str10, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num18, Convert.ToDecimal(num17), 0, str11, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else if (SummaryClass.ManageStockPermission != 1)
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, str10, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num18, Convert.ToDecimal(num17), 0, str11, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, str10, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num18, Convert.ToDecimal(num17), 0, str11, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                }
                else
                {
                    foreach (DataRow dataRow11 in PurchaseBasePage.Kit_Details(num16).Rows)
                    {
                        int num19 = num5 * Convert.ToInt16(dataRow11["Quantity"]);
                        DataTable dataTable3 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(dataRow11["KitItemID"]));
                        string str12 = dataTable3.Rows[0]["ItemCode"].ToString();
                        string str13 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(dataRow11["KitItemID"])).Replace("»", "\n");
                        PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, Convert.ToInt64(dataRow11["KitItemID"]), "W", str12, str13, Convert.ToDecimal(num19), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num18, Convert.ToDecimal(num17), 0, str11, false, EstimateItemID, "C", (long)0, UserID, SummaryClass.CreatedDate);
                    }
                }
                foreach (DataRow row12 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = row12["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty12 = string.Empty;
                foreach (DataRow dataRow12 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty12 = dataRow12["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty12);
            }
            foreach (DataRow row13 in ds.Tables[9].Rows)
            {
                if (string.Compare(row13["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(row13["IsEmpty"].ToString().ToLower(), "no", true) != 0 || !additionalItemID.ToString().Contains(row13["estOtherCostID"].ToString()))
                {
                    continue;
                }
                num5 = Convert.ToInt32(row13["Quantity"]);
                dateTime1 = Convert.ToDateTime(row13["PoReqDate"]);
                num6 = 0;
                SummaryClass.DeliveryAddressID = Convert.ToInt64(row13["DeliveryAddress"].ToString());
                num1 = Convert.ToInt32(row13["SupplierID"].ToString());
                num2 = Convert.ToInt32(row13["ContactID"].ToString());
                num3 = Convert.ToInt64(row13["AddressID"].ToString());
                num7 = Convert.ToDecimal(row13["cost"].ToString());
                pODN = row13["ItemDescription"].ToString();
                long num20 = Convert.ToInt64(row13["estOtherCostID"].ToString());
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.ReplaceSingleQuote(str), "", "", dateTime, baseClass.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, DateTime.Now, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, SummaryClass.DeliveryAddressID, SummaryClass.DeliveryAddressType, 0, (long)0, DateTime.Now, "");
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num21 = new decimal(0);
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, str2, pODN, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), taxID, Convert.ToDecimal(num21), 0, "", false, num20, "U", (long)0, UserID, SummaryClass.CreatedDate);
                foreach (DataRow dataRow13 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str3 = dataRow13["PONO"].ToString();
                }
                SummaryClass.Insert_ActivityHistory_Purchase(EstimateID, num, baseClass.ReplaceSingleQuote(StrJobNum), str3, CustomerName, CompanyID, UserID);
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                objArray = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str3, "</a>" };
                empty4 = string.Concat(objArray);
                string empty13 = string.Empty;
                foreach (DataRow row14 in Notes.select_item_number_for_Activity_History(EstimateID, estimateItemID, empty5).Rows)
                {
                    empty13 = row14["rownumber"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str4 = string.Concat(str4, "Item ", empty13);
            }
            AddPurchaseOrders = empty4;
            AddItemNumbers = str4;
        }

        public Int32 convertObjectToInt(object obj)
        {
            string objString = (obj as string);
            return Convert.ToInt32(string.IsNullOrEmpty(objString) ? "0" : objString);
        }
    }
}