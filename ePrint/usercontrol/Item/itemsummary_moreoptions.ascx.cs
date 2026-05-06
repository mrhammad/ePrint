using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class itemsummary_moreoptions : UserControl
    {
        //protected HtmlGenericControl divLoadingImageCus;

        //protected PlaceHolder plhLeftPanel;

        //protected Button btnMoreOptions;

        //protected HtmlGenericControl li_pm;

        //protected HtmlGenericControl li_allitems;

        //protected HtmlGenericControl li_selecteditems;

        //protected HtmlGenericControl li_outwork_supplier;

        //protected HtmlGenericControl div_printmail;

        //protected HtmlGenericControl li_additems;

        //protected HtmlGenericControl li_Sheet_Fed_Digital;

        //protected HtmlGenericControl li_sheetfed_digital_single;

        //protected HtmlGenericControl li_sheetfed_digital_booklet;

        //protected HtmlGenericControl li_sheetfed_digital_pads;

        //protected HtmlGenericControl div_Sheet_Fed_Digital;

        //protected HtmlGenericControl li_Sheet_Fed_offset;

        //protected HtmlGenericControl li_sheetfed_offset_single;

        //protected HtmlGenericControl li_sheetfed_offset_booklet;

        //protected HtmlGenericControl li_sheetfed_offset_ncr;

        //protected HtmlGenericControl li_sheetfed_offset_pads;

        //protected HtmlGenericControl div_Sheet_Fed_offset;

        //protected HtmlGenericControl li_outwork;

        //protected HtmlGenericControl li_product_catalogue;

        //protected HtmlGenericControl li_other_cost;

        //protected HtmlGenericControl li_large_format;

        //protected HtmlGenericControl li_large_linear;

        //protected HtmlGenericControl li_large_sm;

        //protected HtmlGenericControl li_warehouse;

        //protected HtmlGenericControl li_quick_qoute;

        //protected HtmlGenericControl div_additems;

        //protected HtmlGenericControl li_p2j;

        //protected HtmlGenericControl div_p2job;

        //protected HtmlGenericControl li_attatchments;

        //protected HtmlGenericControl div_attachments;

        //protected Label lblCopy;

        //protected HtmlGenericControl li_copy;

        //protected HtmlGenericControl li_copy2same;

        //protected HtmlGenericControl li_copy2new;

        //protected HtmlGenericControl div_copy;

        //protected Label lblrevert;

        //protected HtmlGenericControl li_revert;

        //protected HtmlGenericControl div_revert;

        //protected HtmlGenericControl li_rerun;

        //protected HtmlGenericControl div_rerun;

        //protected HtmlGenericControl div_options;

        //protected HtmlGenericControl DivMoreAction;

        //protected HtmlGenericControl Div_EstSummary;

        //protected HiddenField hdn_PrintEmail;

        //protected Panel pnlCustomize;

        //protected HiddenField hdnPCPath;

        //protected HiddenField hdnIDs;

        //protected HiddenField editViewID;

        //protected HiddenField CompanyID_change;

        //protected HiddenField hidchkDeletepo;

        //protected HiddenField hidchkDeleteDel;

        //protected HiddenField hdnReduceStockTypeForCancelledNew;

        //protected HiddenField hdnStockCancelChk;

        //protected LinkButton lnk_RevertToJob;

        //protected HiddenField hdnOrderID;

        //protected HiddenField hdnEstimateID;

        //protected HiddenField hdnJObID;

        //protected HiddenField hdnEmailselectOrnot;

        //protected HiddenField hdnIsdirectJob;

        //protected HiddenField hdbstatustitlesamecustomer;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int divheight;

        private CompanyBasePage objCom = new CompanyBasePage();

        public string urlInventory = string.Empty;

        public string urlStoreSupply = string.Empty;

        public string urlCustomerItem = string.Empty;

        public long EstID;

        public long ProofID;

        private long InvoiceNum;

        public int CompanyID;

        public string DateFormat = string.Empty;

        public int UserID;

        public string PageType = string.Empty;

        public long EstNo;

        private CompanyBasePage objComp = new CompanyBasePage();

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass cmnDate = new commonClass();

        private DateTime TodayDate;

        private notesclass objnotes = new notesclass();

        public string ImgPath = global.imagePath();

        private Notes objN = new Notes();

        private int EstimateItemCount;

        private string EstimateItems = string.Empty;

        private string EstimateType = string.Empty;

        private string EstimateTypeID = string.Empty;

        private string ItemName = string.Empty;

        private string ItemDescription = string.Empty;

        private string[] ArryItems;

        private string[] ArryItemType;

        private string[] ArryItemTypeID;

        private string[] ArryItemName;

        private string[] ArryItemDescription;

        private string[] ArryQtyNo;

        public long DeliveryID;

        public long DeliveryItemID;

        public int CustomerID;

        public int AttentionID;

        public long OrderID;

        public string ShippedTo = string.Empty;

        public long DeliveryAddID;

        public string DelAddType = string.Empty;

        public string Footer = string.Empty;

        public long DelNO;

        public DateTime DeliveyDate = DateTime.Now;

        public DateTime ActualDeliveryDate = DateTime.Now;

        public string RefNo = string.Empty;

        public string OrderNo = string.Empty;

        public string sectionid = string.Empty;

        public string companytype = string.Empty;

        private string jobconvertedtoinvoice = string.Empty;

        public string PaperMeasure = string.Empty;

        public string ConsignmentNumber = string.Empty;

        private Hashtable htInventory = new Hashtable();

        private commonClass comm = new commonClass();

        private int OrderConvertedToJob;

        private int EstimateConvertedToJob;

        public long ApprovedOrderCount;

        public string SheetFedDigital = string.Empty;

        public string DigitalSingleItem = string.Empty;

        public string DigitalBooklet = string.Empty;

        public string DigitalPads = string.Empty;

        public string DigitalNCR = string.Empty;

        public string OffsetSingleItem = string.Empty;

        public string OffsetPad = string.Empty;

        public string OffsetNCR = string.Empty;

        public string OffsetBooklet = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private string prdctPath = string.Empty;

        public languageClass objLangClass = new languageClass();

        public string ConsigneeUrl = string.Empty;

        public long CostCentreID;

        public static int ManageStockPermission;

        public string StockCancellationType = string.Empty;

        public string DeliveryNotePrefix = ConnectionClass.DeliveryNotePrefix;

        public string EstimatePrefix = ConnectionClass.EstimatePrefix;

        public string img_arrow_pmstyle = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string IsFromWebStore = string.Empty;

        private long IsConverted;

        public string PaymentType = string.Empty;

        public Boolean IsJobLocked;
        public string CanIgnoreLock;
        public Int32 LockStatusId;
        public Int32 UnLockStatusId;
        public string isPopupSortingAllowed = string.Empty;
        private commonClass commclass = new commonClass();

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

        static itemsummary_moreoptions()
        {
        }

        public itemsummary_moreoptions()
        {
        }

        private void Adjust_Inventory_On_Job_Revert(DataSet ds, string StrJobNum, int StatusID, long EstID, long EstimateItemID, Hashtable htInventory)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, this.UserID, this.CompanyID, "reverted", htInventory, EstimateItemID);
        }

        public void btnAddTraining_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            DataSet dataSet = new DataSet();
            DataTable dataTable = EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, this.EstID);
            DataTable dataTable1 = new DataTable();
            string str = string.Empty;
            str = this.cmnDate.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            string empty1 = string.Empty;
            int num = 0;
            if (str == "a" || str == "p" && this.hdnReduceStockTypeForCancelledNew.Value.ToLower() == "true")
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    long num1 = Convert.ToInt64(row["EstimateItemID"]);
                    int num2 = Convert.ToInt32(row["QtyNumber"]);
                    string str1 = row["ItemType"].ToString();
                    empty1 = row["JobNumber"].ToString();
                    num = Convert.ToInt32(row["StatusID"].ToString());
                    long num3 = (long)0;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    int num4 = 0;
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    string empty3 = string.Empty;
                    decimal num7 = new decimal(0);
                    if (string.Compare(str1, "S", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow["PaperID"]);
                            empty2 = "I";
                            dataRow["InventoryCode"].ToString();
                            dataRow["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow["Quantity"]);
                            Convert.ToDecimal(dataRow["PackedIn"]);
                            Convert.ToInt64(dataRow["EstimateSingleItemID"]);
                            num5 = Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow["RunningSpoilage"]);
                            Convert.ToDecimal(dataRow["PaperMarkup"]);
                            num7 = Convert.ToDecimal(dataRow["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "P", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow row1 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row1["PaperID"]);
                            empty2 = "I";
                            row1["InventoryCode"].ToString();
                            row1["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row1["Quantity"]);
                            Convert.ToDecimal(row1["PackedIn"]);
                            Convert.ToInt64(row1["EstimatePadItemID"]);
                            num5 = Convert.ToDecimal(row1["PaperUnitPrice"]);
                            Convert.ToInt32(row1["PrintLayoutValue"]);
                            Convert.ToDecimal(row1["SetupSpoilage"]);
                            Convert.ToDecimal(row1["RunningSpoilage"]);
                            Convert.ToDecimal(row1["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row1["InvSheets"]);
                            if (row1["LeavesPerPad"] != null)
                            {
                                Convert.ToDecimal(row1["LeavesPerPad"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "L", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow1["PaperID"]);
                            empty2 = "I";
                            dataRow1["InventoryCode"].ToString();
                            dataRow1["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow1["Quantity"]);
                            Convert.ToDecimal(dataRow1["PackedIn"]);
                            Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                            num5 = Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow1["RunningSpoilage"]);
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
                            string str3 = dataRow1["PressPaperType"].ToString();
                            num7 = Convert.ToDecimal(dataRow1["InvSheets"]);
                            if (string.Compare(str3, "roll", true) == 0 && Convert.ToDecimal(dataRow1["length"]) > new decimal(0))
                            {
                                num5 = num5 / Convert.ToDecimal(dataRow1["length"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "B", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        Hashtable hashtables = new Hashtable();
                        foreach (DataRow row2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row2["PaperID"]);
                            empty2 = "I";
                            row2["InventoryCode"].ToString();
                            row2["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row2["Quantity"]);
                            Convert.ToDecimal(row2["PackedIn"]);
                            Convert.ToInt64(row2["EstimateBookletItemID"]);
                            num5 = Convert.ToDecimal(row2["PaperUnitPrice"]);
                            Convert.ToDecimal(row2["NoOfSignatures"]);
                            Convert.ToDecimal(row2["SetupSpoilage"]);
                            Convert.ToDecimal(row2["RunningSpoilage"]);
                            Convert.ToDecimal(row2["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row2["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            if (!hashtables.ContainsKey(num3))
                            {
                                hashtables.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                hashtables[num3] = Convert.ToInt32(hashtables[num3].ToString()) + Convert.ToInt32(num7);
                            }
                        }
                        foreach (long key in hashtables.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key), empty2, Convert.ToInt32(hashtables[key]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "W", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        Hashtable hashtables1 = new Hashtable();
                        foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                            empty2 = dataRow2["WarehouseType"].ToString();
                            num4 = Convert.ToInt32(dataRow2["Quantity"]);
                            if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                            {
                                continue;
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!hashtables1.ContainsKey(num3))
                            {
                                hashtables1.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables1[num3] = Convert.ToInt32(hashtables1[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        if (hashtables1.Count > 0)
                        {
                            foreach (long key1 in hashtables1.Keys)
                            {
                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty2, Convert.ToInt32(hashtables1[key1]), "reverted", num1);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "O", true) == 0)
                    {
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "C", true) == 0 || string.Compare(str1, "X", true) == 0)
                    {
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "F", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow row3 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row3["PaperID"]);
                            empty2 = "I";
                            row3["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row3["Quantity"]);
                            Convert.ToDecimal(row3["PackedIn"]);
                            Convert.ToInt64(row3["EstLithoItemID"]);
                            num5 = Convert.ToDecimal(row3["PaperUnitPrice"]);
                            Convert.ToInt32(row3["PrintLayoutValue"]);
                            Convert.ToDecimal(row3["SetupSpoilage"]);
                            Convert.ToDecimal(row3["RunningSpoilage"]);
                            Convert.ToDecimal(row3["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row3["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num7), "reverted", num1);
                        }
                        dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num1);
                        foreach (DataRow dataRow3 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow3["PlateID"]);
                            empty2 = "I";
                            num4 = Convert.ToInt32(dataRow3["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num4), "reverted", num1);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "D", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow row4 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row4["PaperID"]);
                            empty2 = "I";
                            row4["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row4["Quantity"]);
                            Convert.ToDecimal(row4["PackedIn"]);
                            Convert.ToInt64(row4["EstimateLithoPadItemID"]);
                            num5 = Convert.ToDecimal(row4["PaperUnitPrice"]);
                            Convert.ToInt32(row4["PrintLayoutValue"]);
                            Convert.ToDecimal(row4["SetupSpoilage"]);
                            Convert.ToDecimal(row4["RunningSpoilage"]);
                            Convert.ToDecimal(row4["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row4["InvSheets"]);
                            if (row4["LeavesPerPad"] != null)
                            {
                                Convert.ToDecimal(row4["LeavesPerPad"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num7), "reverted", num1);
                        }
                        dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num1);
                        foreach (DataRow dataRow4 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow4["PlateID"]);
                            empty2 = "I";
                            num4 = Convert.ToInt32(dataRow4["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num4), "reverted", num1);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "N", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num1);
                        Hashtable hashtables2 = new Hashtable();
                        foreach (DataRow row5 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(row5["PlateID"]);
                            empty2 = "I";
                            num4 = Convert.ToInt32(row5["Noofplates"]);
                            if (!hashtables2.ContainsKey(num3))
                            {
                                hashtables2.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (long key2 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty2, Convert.ToInt32(hashtables2[key2]), "reverted", num1);
                        }
                        hashtables2.Clear();
                        foreach (DataRow dataRow5 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow5["PaperID"]);
                            empty2 = "I";
                            dataRow5["InventoryCode"].ToString();
                            dataRow5["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow5["Quantity"]);
                            Convert.ToDecimal(dataRow5["PackedIn"]);
                            Convert.ToInt64(dataRow5["EstimateLithoNCRItemID"]);
                            num5 = Convert.ToDecimal(dataRow5["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow5["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow5["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow5["RunningSpoilage"]);
                            decimal num8 = Convert.ToDecimal(dataRow5["NcrPartsPerSet"].ToString());
                            decimal num9 = Convert.ToDecimal(dataRow5["NcrSetsPerPad"].ToString());
                            Convert.ToDecimal(dataRow5["PaperMarkup"]);
                            num7 = Convert.ToDecimal(dataRow5["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            if (!hashtables2.ContainsKey(num3))
                            {
                                hashtables2.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num7);
                            }
                        }
                        foreach (long key3 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty2, Convert.ToInt32(hashtables2[key3]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "R", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num1);
                        Hashtable hashtables2 = new Hashtable();
                        foreach (DataRow row5 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(row5["PlateID"]);
                            empty2 = "I";
                            num4 = Convert.ToInt32(row5["Noofplates"]);
                            if (!hashtables2.ContainsKey(num3))
                            {
                                hashtables2.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (long key2 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty2, Convert.ToInt32(hashtables2[key2]), "reverted", num1);
                        }
                        hashtables2.Clear();
                        foreach (DataRow dataRow5 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow5["PaperID"]);
                            empty2 = "I";
                            dataRow5["InventoryCode"].ToString();
                            dataRow5["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow5["Quantity"]);
                            Convert.ToDecimal(dataRow5["PackedIn"]);
                            Convert.ToInt64(dataRow5["EstimateLithoNCRItemID"]);
                            num5 = Convert.ToDecimal(dataRow5["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow5["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow5["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow5["RunningSpoilage"]);
                            decimal num8 = Convert.ToDecimal(dataRow5["NcrPartsPerSet"].ToString());
                            decimal num9 = Convert.ToDecimal(dataRow5["NcrSetsPerPad"].ToString());
                            Convert.ToDecimal(dataRow5["PaperMarkup"]);
                            num7 = Convert.ToDecimal(dataRow5["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            if (!hashtables2.ContainsKey(num3))
                            {
                                hashtables2.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                hashtables2[num3] = Convert.ToInt32(hashtables2[num3].ToString()) + Convert.ToInt32(num7);
                            }
                        }
                        foreach (long key3 in hashtables2.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty2, Convert.ToInt32(hashtables2[key3]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str1, "K", true) != 0)
                    {
                        if (string.Compare(str1, "Q", true) != 0)
                        {
                            continue;
                        }
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        foreach (DataRow row6 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row6["PaperID"]);
                            empty2 = "I";
                            row6["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row6["Quantity"]);
                            Convert.ToDecimal(row6["PackedIn"]);
                            Convert.ToInt64(row6["QuickQuoteID"]);
                            num5 = Convert.ToDecimal(row6["PaperUnitPrice"]);
                            Convert.ToInt32(row6["PrintLayoutValue"]);
                            Convert.ToDecimal(row6["SetupSpoilage"]);
                            Convert.ToDecimal(row6["RunningSpoilage"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty2, Convert.ToInt32(num6), "reverted", num1);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num6));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num6);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str1);
                        dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num1);
                        Hashtable hashtables3 = new Hashtable();
                        foreach (DataRow dataRow6 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow6["PlateID"]);
                            empty2 = "I";
                            num4 = Convert.ToInt32(dataRow6["Noofplates"]);
                            if (!hashtables3.ContainsKey(num3))
                            {
                                hashtables3.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num4);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num4));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num4);
                            }
                        }
                        foreach (long key4 in hashtables3.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key4), empty2, Convert.ToInt32(hashtables3[key4]), "reverted", num1);
                        }
                        hashtables3.Clear();
                        foreach (DataRow row7 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row7["PaperID"]);
                            empty2 = "I";
                            row7["InventoryCode"].ToString();
                            row7["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row7["Quantity"]);
                            Convert.ToDecimal(row7["PackedIn"]);
                            Convert.ToInt64(row7["EstimateLithobookletItemID"]);
                            num5 = Convert.ToDecimal(row7["PaperUnitPrice"]);
                            Convert.ToInt32(row7["NoOfSignatures"]);
                            Convert.ToDecimal(row7["SetupSpoilage"]);
                            Convert.ToDecimal(row7["RunningSpoilage"]);
                            Convert.ToDecimal(row7["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row7["InvSheets"]);
                            if (!hashtables3.ContainsKey(num3))
                            {
                                hashtables3.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                hashtables3[num3] = Convert.ToInt32(hashtables3[num3].ToString()) + Convert.ToInt32(num7);
                            }
                        }
                        foreach (long key5 in hashtables3.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key5), empty2, Convert.ToInt32(hashtables3[key5]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                }
            }
            if (this.StockCancellationType == "a" || this.StockCancellationType == "p" && this.hdnStockCancelChk.Value.ToLower() == "true")
            {
                foreach (DataRow dataRow7 in dataTable.Rows)
                {
                    long num10 = Convert.ToInt64(dataRow7["EstimateItemID"]);
                    int num11 = Convert.ToInt32(dataRow7["QtyNumber"]);
                    string str4 = dataRow7["ItemType"].ToString();
                    empty1 = dataRow7["JobNumber"].ToString();
                    num = Convert.ToInt32(dataRow7["StatusID"].ToString());
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    int num12 = 0;
                    string str5 = string.Empty;
                    if (string.Compare(str4, "C", true) != 0 && string.Compare(str4, "X", true) != 0)
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str4);
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        long num13 = Convert.ToInt64(row8["PriceCatalogueID"]);
                        num12 = Convert.ToInt32(row8["Quantity"]);
                        decimal num14 = Convert.ToDecimal(row8["Price"]);
                        BaseClass baseClass = new BaseClass();
                        foreach (DataRow dataRow8 in baseClass.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                        {
                            if (dataRow8["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockCancellationProcess((long)this.CompanyID, num13, (long)0, "self", num10, "Job", (long)this.UserID, this.StockCancellationType);
                            }
                            else if (dataRow8["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockCancellationProcess((long)this.CompanyID, (long)0, num13, "other", num10, "Job", (long)this.UserID, this.StockCancellationType);
                            }
                            else if (dataRow8["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow8["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockCancellationProcess((long)this.CompanyID, num13, (long)0, "multiple", num10, "Job", (long)this.UserID, this.StockCancellationType);
                            }
                            else
                            {
                                baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num13, "additional option", num12, num10, "Job", (long)this.UserID, num14);
                            }
                        }
                    }
                    this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num10, this.htInventory);
                }
            }
            JobBasePage.Jobs_Revert(Convert.ToInt32(base.Session["CompanyID"]), this.EstID);
            string empty6 = string.Empty;
            string str6 = string.Empty;
            foreach (DataRow row9 in EstimateBasePage.purchase_select_by_estimateid(this.CompanyID, this.EstID).Rows)
            {
                empty6 = (empty6 == "" ? string.Concat(empty6, row9["PONO"].ToString()) : string.Concat(empty6, ", ", row9["PONO"].ToString()));
            }
            DataTable dataTable2 = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstID, (long)0, "");
            foreach (DataRow dataRow9 in dataTable2.Rows)
            {
                str6 = (str6 == "" ? string.Concat(str6, dataRow9["DeliveryNumber"].ToString()) : string.Concat(str6, ", ", dataRow9["DeliveryNumber"].ToString()));
            }
            if (this.hidchkDeletepo.Value.ToString().ToLower() == "true")
            {
                JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.EstID, 1, 0, "Main");
            }
            if (this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.EstID, 0, 1, "Main");
            }
            if (this.hidchkDeletepo.Value.ToString().ToLower() == "true" && this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPOandDel);
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "true" && this.hidchkDeleteDel.Value.ToString().ToLower() == "false")
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPO);
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "false" && this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithDel);
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "false" && this.hidchkDeleteDel.Value.ToString().ToLower() == "false")
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithOutPOandDel);
            }
            string empty7 = string.Empty;
            this.objnotes.ModuleName = "job";
            this.objnotes.Delivery_number = str6;
            this.objnotes.PO_Numbers = empty6;
            this.objnotes.ModuleID = this.EstID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.cmnDate;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            DataTable dataTable3 = new DataTable();
            dataTable3 = EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstID);
            string str7 = string.Empty;
            foreach (DataRow row10 in dataTable3.Rows)
            {
                str7 = row10["EstimateNumber"].ToString();
            }
            if (this.htInventory.Count > 0)
            {
                foreach (long key6 in this.htInventory.Keys)
                {
                    string empty8 = string.Empty;
                    DataTable dataTable4 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable4.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow10 in dataTable4.Rows)
                        {
                            empty8 = dataRow10["FinalQuantity"].ToString();
                        }
                    }
                    if (empty8 == null || empty8 == "")
                    {
                        empty8 = "0";
                    }
                    commonClass _commonClass1 = this.cmnDate;
                    long num15 = Convert.ToInt64(key6);
                    object[] estID = new object[] { "Job reverted to estimate and stock adjusted - <a href='", this.strSitepath, "estimates/estimate_summary.aspx?frm=view&estid=", this.EstID, "' target='_blank' >", str7, "</a>" };
                    _commonClass1.Insert_Activity_History_For_Inventory(num15, string.Concat(estID), this.UserID, Convert.ToInt32(this.htInventory[key6]), "a", Convert.ToInt32(empty8) + Convert.ToInt32(this.htInventory[key6]));
                }
            }
            base.Response.Redirect(string.Concat("../Estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID));
        }

        public void btnCopyCampaign_Click(object sender, EventArgs e)
        {
            QueryString queryString = new QueryString()
        {
            { "campaignid", this.editViewID.Value }
        };
            string str = "campaign_clone.aspx";
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            str = string.Concat(str, queryString1.ToString());
            base.Response.Redirect(str);
        }

        public void btnEditView_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../estimates/customview.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewCampaign_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat("../campaign/campaign_editview.aspx?viewvalueid=", this.editViewID.Value));
        }

        public void btnEditViewDelivery_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../delivery/customviewdelivery.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewInventory_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../warehouse/customviewinv.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewInvoice_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../invoice/customviewinvoice.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewItem_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../warehouse/customviewitem.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewJob_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../jobs/customviewjob.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewOrder_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../orders/customvieworder.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewPurchase_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../purchase/customviewpurchase.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnEditViewStore_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../warehouse/customviewstore.aspx?type=edit&id=", this.editViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void btnProgressToInvoice_Click(object sender, EventArgs e)
        {
        }

        public string CheckProgressToJobPossible(int CompanyID, long EstimateItemID, string ItemType, int QtyNumber, string Module)
        {
            string empty = string.Empty;
            if (base.Session["ProductStockManagement"] != null)
            {
                if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
                {
                    empty = "true";
                }
                else
                {
                    DataSet dataSet = new DataSet();
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                    this.objBase.Return_StockManagementSettings("SA_EprintMISJobs");
                    DataTable dataTable = new DataTable();
                    if (ItemType.ToLower() == "x" || ItemType.ToLower() == "c")
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            if (Module == "order")
                            {
                                if (Convert.ToString(row["DrawStockFrom"]).ToLower() == "s")
                                {
                                    dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "self", EstimateItemID);
                                }
                                else if (Convert.ToString(row["DrawStockFrom"]).ToLower() == "o")
                                {
                                    dataTable = this.objBase.StockProductRerunDetails_Select((long)0, Convert.ToInt64(row["PriceCatalogueID"]), (long)CompanyID, "others", EstimateItemID);
                                }
                                else if (Convert.ToString(row["DrawStockFrom"]).ToLower() == "m")
                                {
                                    dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "multiple", EstimateItemID);
                                }
                                else if (Convert.ToString(row["DrawStockFrom"]).ToLower() == "a")
                                {
                                    dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "additional option", EstimateItemID);
                                }
                            }
                            if (dataTable.Rows.Count <= 0)
                            {
                                long num = Convert.ToInt64(row["PriceCatalogueID"]);
                                int num1 = Convert.ToInt32(row["Quantity"]);
                                if (!Convert.ToBoolean(row["IsStockReplenish"].ToString()))
                                {
                                    empty = this.objBase.Check_Estimate_Possible(num, num1, Module, Convert.ToInt64(row["JobItemStatusID"]));
                                    if (empty == "false")
                                    {
                                        break;
                                    }
                                    empty = "true";
                                }
                                else
                                {
                                    empty = "true";
                                }
                            }
                            else
                            {
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (Convert.ToInt32(dataRow["TotalOldQty"].ToString()) == Convert.ToInt32(row["Quantity"]))
                                    {
                                        empty = "true";
                                    }
                                    else
                                    {
                                        long num2 = Convert.ToInt64(row["PriceCatalogueID"]);
                                        int num3 = Convert.ToInt32(row["Quantity"]);
                                        if (!Convert.ToBoolean(row["IsStockReplenish"].ToString()))
                                        {
                                            empty = this.objBase.Check_Estimate_Possible(num2, num3, Module, Convert.ToInt64(row["JobItemStatusID"]));
                                            if (empty == "false")
                                            {
                                                break;
                                            }
                                            empty = "true";
                                        }
                                        else
                                        {
                                            empty = "true";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow row1 in dataSet.Tables[8].Rows)
                    {
                        if (!dataSet.Tables[8].Columns.Contains("PriceCatalogueID"))
                        {
                            continue;
                        }
                        if (Module == "order")
                        {
                            if (Convert.ToString(row1["DrawStockFrom"]).ToLower() == "s")
                            {
                                dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "self", Convert.ToInt64(row1["EstimateItemID"]));
                            }
                            else if (Convert.ToString(row1["DrawStockFrom"]).ToLower() == "o")
                            {
                                dataTable = this.objBase.StockProductRerunDetails_Select((long)0, Convert.ToInt64(row1["PriceCatalogueID"]), (long)CompanyID, "others", Convert.ToInt64(row1["EstimateItemID"]));
                            }
                            else if (Convert.ToString(row1["DrawStockFrom"]).ToLower() == "m")
                            {
                                dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "multiple", Convert.ToInt64(row1["EstimateItemID"]));
                            }
                            else if (Convert.ToString(row1["DrawStockFrom"]).ToLower() == "a")
                            {
                                dataTable = this.objBase.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "additional option", Convert.ToInt64(row1["EstimateItemID"]));
                            }
                        }
                        if (dataTable.Rows.Count <= 0)
                        {
                            empty = this.objBase.Check_Estimate_Possible((long)Convert.ToInt32(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]), Module, Convert.ToInt64(row1["JobItemStatusID"]));
                            if (empty == "false")
                            {
                                break;
                            }
                            empty = "true";
                        }
                        else
                        {
                            foreach (DataRow dataRow1 in dataTable.Rows)
                            {
                                if (Convert.ToInt32(dataRow1["TotalOldQty"].ToString()) == Convert.ToInt32(row1["Quantity"]))
                                {
                                    empty = "true";
                                }
                                else
                                {
                                    empty = this.objBase.Check_Estimate_Possible((long)Convert.ToInt32(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]), Module, Convert.ToInt64(row1["JobItemStatusID"]));
                                    if (empty == "false")
                                    {
                                        break;
                                    }
                                    empty = "true";
                                }
                            }
                        }
                    }
                }
            }
            return empty;
        }

        protected string date_Check_new(string DateFormatt, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (this.DateFormat == string.Concat(this.PaperMeasure, "/dd/yyyy"))
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays1);
                    }
                    else if (DateFormatt == string.Concat(this.PaperMeasure, "/dd/yyyy"))
                    {
                        string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays2);
                    }
                }
                if (this.DateFormat == "dd/mm/yyyy")
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormatt == string.Concat(this.PaperMeasure, "/dd/yyyy"))
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

        private long Delivery_Note_Insert()
        {
            long num = (long)0;
            if (EstimateBasePage.estimate_hasdeliverynote_select(this.CompanyID, this.EstID).ToLower() == "no")
            {
                string empty = string.Empty;
                IDataReader dataReader = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstID);
                while (dataReader.Read())
                {
                    empty = dataReader["DeliveryDate"].ToString();
                    this.RefNo = dataReader["JobNumber"].ToString();
                }
                empty = this.objBase.date_Check(this.DateFormat, this.objBase.ReplaceSingleQuote(empty));
                empty = this.cmnDate.return_Date_Before_Insert(empty, this.CompanyID, int.Parse(base.Session["userid"].ToString()));
                foreach (DataRow row in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstID).Rows)
                {
                    this.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
                    this.AttentionID = Convert.ToInt32(row["AttentionID"].ToString());
                    this.ShippedTo = row["Company"].ToString();
                    this.DeliveryAddID = Convert.ToInt64(row["DeliveryAddressID"].ToString());
                    this.DelAddType = row["DeliveryAddressType"].ToString();
                    this.Footer = row["Footer"].ToString();
                    this.OrderNo = row["OrderNumber"].ToString();
                    this.CostCentreID = Convert.ToInt64(row["costcentreID"]);
                }
                this.DelNO = this.objCom.settings_lastcounter_select(this.CompanyID, "d");
                long delNO = (long)10000000 + this.DelNO;
                string str = string.Concat(this.DeliveryNotePrefix, delNO.ToString().Substring(1, delNO.ToString().Length - 1));
                this.DeliveyDate = Convert.ToDateTime(empty);
                string empty1 = string.Empty;
                foreach (DataRow dataRow in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                {
                    empty1 = dataRow["Comments"].ToString();
                }
                long num1 = (long)0;
                int num2 = 0;
                int jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                num = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, this.EstID, num1, "E", this.CustomerID, this.AttentionID, this.ShippedTo, this.DeliveryAddID, this.DelAddType, this.Footer, empty1, str, this.DeliveyDate, this.RefNo, this.OrderNo, false, num2, this.UserID, jobStatusID, DateTime.Now, this.UserID, this.DelNO, "", this.TodayDate, this.CustomerID, this.ConsignmentNumber, this.ConsigneeUrl, Convert.ToDateTime("1900-01-01 00:00:00.000"), this.CostCentreID, this.DeliveryNotePrefix);
                DataTable dataTable = EstimateBasePage.Estimate_Items_Select(this.CompanyID, this.EstID);
                this.EstimateItemCount = dataTable.Rows.Count;
                foreach (DataRow row1 in dataTable.Rows)
                {
                    this.EstimateItems = string.Concat(this.EstimateItems, row1["EstimateItemID"].ToString(), ",");
                    this.EstimateType = string.Concat(this.EstimateType, row1["EstimateType"].ToString(), ",");
                }
                string estimateItems = this.EstimateItems;
                char[] chrArray = new char[] { ',' };
                this.ArryItems = estimateItems.Split(chrArray);
                string estimateType = this.EstimateType;
                char[] chrArray1 = new char[] { ',' };
                this.ArryItemType = estimateType.Split(chrArray1);
                int num3 = 1;
                string str1 = string.Empty;
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    int num4 = num3 - 1;
                    DataTable dataTable1 = this.ItemTitle(Convert.ToInt32(this.ArryItems[num4].ToString()), this.ArryItemType[num4].ToString());
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        this.EstimateTypeID = string.Concat(this.EstimateTypeID, row2["TypeID"].ToString(), ",");
                        this.ItemName = string.Concat(this.ItemName, row2["ItemTitle"].ToString(), ",");
                        this.ItemDescription = string.Concat(this.ItemDescription, row2["ItemDescription"], ",");
                    }
                    string itemName = this.ItemName;
                    char[] chrArray2 = new char[] { ',' };
                    this.ArryItemName = itemName.Split(chrArray2);
                    string itemDescription = this.ItemDescription;
                    char[] chrArray3 = new char[] { ',' };
                    this.ArryItemDescription = itemDescription.Split(chrArray3);
                    string estimateTypeID = this.EstimateTypeID;
                    char[] chrArray4 = new char[] { ',' };
                    this.ArryItemTypeID = estimateTypeID.Split(chrArray4);
                    long num5 = (long)JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, (long)Convert.ToInt32(this.ArryItems[num4].ToString()));
                    str1 = string.Concat(str1, num5.ToString(), "±");
                    num3++;
                }
                char[] chrArray5 = new char[] { '±' };
                this.ArryQtyNo = str1.Split(chrArray5);
                for (int i = 0; i < (int)this.ArryItems.Length - 1; i++)
                {
                    long num6 = Convert.ToInt64(this.ArryItems[i].ToString());
                    long num7 = Convert.ToInt64(this.ArryItemTypeID[i].ToString());
                    string str2 = this.ArryItemType[i].ToString();
                    int num8 = Convert.ToInt32(this.ArryQtyNo[i].ToString());
                    string str3 = EstimateBasePage.estimate_item_quantity_fordelivery_select(this.CompanyID, num6, num7, str2, num8);
                    string[] strArrays = this.ArryItemDescription[i].ToString().Split(new char[] { 'µ' });
                    string empty2 = string.Empty;
                    for (int j = 0; j < (int)strArrays.Length; j++)
                    {
                        string[] strArrays1 = strArrays[j].Split(new char[] { '»' });
                        if (string.Compare(strArrays1[0], "ItemTitle", true) == 0)
                        {
                            string[] strArrays2 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays2);
                        }
                        if (string.Compare(strArrays1[0], "Description", true) == 0)
                        {
                            string[] strArrays3 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays3);
                        }
                        if (string.Compare(strArrays1[0], "Artwork", true) == 0)
                        {
                            string[] str4 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(str4);
                        }
                        if (string.Compare(strArrays1[0], "Colour", true) == 0)
                        {
                            string[] strArrays4 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays4);
                        }
                        if (string.Compare(strArrays1[0], "Size", true) == 0)
                        {
                            string[] str5 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(str5);
                        }
                        if (string.Compare(strArrays1[0], "Material", true) == 0)
                        {
                            string[] strArrays5 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays5);
                        }
                        if (string.Compare(strArrays1[0], "Delivery", true) == 0)
                        {
                            string[] str6 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(str6);
                        }
                        if (string.Compare(strArrays1[0], "Finishing", true) == 0)
                        {
                            string[] strArrays6 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays6);
                        }
                        if (string.Compare(strArrays1[0], "Notes", true) == 0)
                        {
                            string[] str7 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(str7);
                        }
                        if (string.Compare(strArrays1[0], "Instructions", true) == 0)
                        {
                            string[] strArrays7 = new string[] { empty2, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                            empty2 = string.Concat(strArrays7);
                        }
                    }
                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, this.DeliveryItemID, num, this.EstID, num6, str2, str3, empty2, (long)1, "", (long)0);
                }
                EstimateBasePage.estimate_hasdeliverynote_update(this.CompanyID, this.EstID);
            }
            return num;
        }

        public void EstimatesTypesfromDwebconfig()
        {
            if (ConnectionClass.SheetFedDigital == null)
            {
                this.div_Sheet_Fed_Digital.Visible = false;
            }
            else
            {
                if (ConnectionClass.DigitalSingleItem == null)
                {
                    this.li_sheetfed_digital_single.Visible = false;
                }
                if (ConnectionClass.DigitalBooklet == null)
                {
                    this.li_sheetfed_digital_booklet.Visible = false;
                }
                if (ConnectionClass.DigitalPads == null)
                {
                    this.li_sheetfed_digital_pads.Visible = false;
                }
                if (ConnectionClass.DigitalNCR == null)
                {
                    this.li_sheetfed_digital_NCR.Visible = false;
                }
            }
            if (ConnectionClass.SheetFedOffset == null)
            {
                this.div_Sheet_Fed_offset.Visible = false;
            }
            else
            {
                if (ConnectionClass.OffsetSingleItem == null)
                {
                    this.li_sheetfed_offset_single.Visible = false;
                }
                if (ConnectionClass.OffsetBooklet == null)
                {
                    this.li_sheetfed_offset_booklet.Visible = false;
                }
                if (ConnectionClass.OffsetNCR == null)
                {
                    this.li_sheetfed_offset_ncr.Visible = false;
                }
                if (ConnectionClass.OffsetPad == null)
                {
                    this.li_sheetfed_offset_pads.Visible = false;
                }
            }
            if (ConnectionClass.PrintBroker == null)
            {
                this.li_outwork.Visible = false;
            }
            if (ConnectionClass.PriceCatalogue == null)
            {
                this.li_product_catalogue.Visible = false;
            }
            if (ConnectionClass.OtherCosts == null)
            {
                this.li_other_cost.Visible = false;
            }
            if (ConnectionClass.LargeFormat == null)
            {
                this.li_large_format.Visible = false;
            }
            else
            {
                if (ConnectionClass.Linear == null)
                {
                    this.li_large_linear.Visible = false;
                }
                if (ConnectionClass.SquareMeter == null)
                {
                    this.li_large_sm.Visible = false;
                }
                if (ConnectionClass.Tilling == null)
                {
                    this.li_large_tilling.Visible = false;
                }
            }
            if (ConnectionClass.Warehouse == null)
            {
                this.li_warehouse.Visible = false;
            }
            if (ConnectionClass.QuickQuote == null)
            {
                this.li_quick_qoute.Visible = false;
            }
            if (ConnectionClass.DeliveryCost == null)
            {
                this.li_delivery_cost.Visible = false;
            }
        }

        public DataTable ItemTitle(int EstimateItemID, string EstimateType)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (EstimateType == "S")
            {
                empty = "tb_EstSingleItem";
                str = "EstSingleItemID";
            }
            else if (EstimateType == "P")
            {
                empty = "tb_EstPadItem";
                str = "EstPadItemID";
            }
            else if (EstimateType == "L")
            {
                empty = "tb_EstLargeItem";
                str = "EstLargeItemID";
            }
            else if (EstimateType == "O")
            {
                empty = "tb_EstOutwork";
                str = "EstOutworkID";
            }
            else if (EstimateType == "B")
            {
                empty = "tb_EstBookletItem";
                str = "EstBookletItemID";
            }
            else if (EstimateType == "W")
            {
                empty = "tb_EstWarehouseItem";
                str = "EstWarehouseItemID";
            }
            else if (EstimateType == "U")
            {
                empty = "tb_EstOtherCost";
                str = "EstOtherCostID";
            }
            else if (EstimateType == "C" || EstimateType == "X")
            {
                empty = "tb_EstPriceCatalogue";
                str = "EstPriceCatalogueID";
            }
            object[] estimateItemID = new object[] { "select ", str, " as TypeID, ItemTitle,ItemDescription from ", empty, " where EstimateItemID=", EstimateItemID };
            string str1 = string.Concat(estimateItemID);
            return JobBasePage.Jobs_ItemTitle_select(this.CompanyID, str1);
        }

        private void lnkCopyEstimate_Click(object sender, EventArgs e)
        {
            this.EstNo = this.objComp.settings_lastcounter_select(this.CompanyID, "e") + (long)1;
            long estNo = (long)10000000 + this.EstNo;
            string str = string.Concat(this.EstimatePrefix, estNo.ToString().Substring(1, estNo.ToString().Length - 1));
            EstimatesBasePage.Estimate_Copy(this.CompanyID, this.EstID, str, Convert.ToInt32(base.Session["UserID"]));
            base.Response.Redirect("estimate_view.aspx");
        }

        private void lnkDeliveryNote_Click(object sender, EventArgs e)
        {
            long num = this.Delivery_Note_Insert();
            HttpResponse response = base.Response;
            object[] estID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&estid=", this.EstID, "&id=", num };
            response.Redirect(string.Concat(estID));
        }

        protected void lnkprogressto_job_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "jobs/jobs_edit.aspx"));
        }

        protected void lnkrevertto_estimate_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=edit"));
        }

        public void LoadLi(string liText, string liLink, PlaceHolder plh)
        {
            if (liText == "Edit View Estimate")
            {
                LinkButton linkButton = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton.Attributes.Add("onclick", "javascript:return editview();");
                linkButton.Click += new EventHandler(this.btnEditView_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Job")
            {
                LinkButton linkButton1 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton1.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton1.Attributes.Add("onclick", "javascript:return editview_job();");
                linkButton1.Click += new EventHandler(this.btnEditViewJob_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton1);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Invoice")
            {
                LinkButton linkButton2 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton2.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton2.Attributes.Add("onclick", "javascript:return editview_invoice();");
                linkButton2.Click += new EventHandler(this.btnEditViewInvoice_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton2);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Purchase")
            {
                LinkButton linkButton3 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton3.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton3.Attributes.Add("onclick", "javascript:return editview_purchase();");
                linkButton3.Click += new EventHandler(this.btnEditViewPurchase_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton3);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Delivery")
            {
                LinkButton linkButton4 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton4.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton4.Attributes.Add("onclick", "javascript:return editview_delivery();");
                linkButton4.Click += new EventHandler(this.btnEditViewDelivery_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton4);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Inventory")
            {
                LinkButton linkButton5 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Manage Views"
                };
                linkButton5.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton5.Attributes.Add("onclick", "javascript:return editview_inventory();");
                linkButton5.Click += new EventHandler(this.btnEditViewInventory_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton5);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Store")
            {
                LinkButton linkButton6 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton6.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton6.Attributes.Add("onclick", "javascript:return editview_store();");
                linkButton6.Click += new EventHandler(this.btnEditViewStore_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton6);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Item")
            {
                LinkButton linkButton7 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton7.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton7.Attributes.Add("onclick", "javascript:return editview_item();");
                linkButton7.Click += new EventHandler(this.btnEditViewItem_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton7);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Campaign")
            {
                LinkButton linkButton8 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton8.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton8.Attributes.Add("onclick", "javascript:return editview_campaign();");
                linkButton8.Click += new EventHandler(this.btnEditViewCampaign_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton8);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Edit View Order")
            {
                LinkButton linkButton9 = new LinkButton()
                {
                    ID = "lnkeditview",
                    Text = "Edit View"
                };
                linkButton9.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton9.Attributes.Add("onclick", "javascript:return editview_order();");
                linkButton9.Click += new EventHandler(this.btnEditViewOrder_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton9);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText != "Copy")
            {
                ControlCollection controls = plh.Controls;
                string[] strArrays = new string[] { "<li><a href='", liLink, "' style='padding-left:18px;text-decoration:none;'>", liText, "</a></li>" };
                controls.Add(new LiteralControl(string.Concat(strArrays)));
                return;
            }
            LinkButton linkButton10 = new LinkButton()
            {
                ID = "lnkCopy",
                Text = this.objLangClass.GetLanguageConversion("Copy_Campaign") ?? ""
            };
            linkButton10.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
            linkButton10.Attributes.Add("onclick", "javascript:return Copy_campaign();");
            linkButton10.Click += new EventHandler(this.btnCopyCampaign_Click);
            plh.Controls.Add(new LiteralControl("<li>"));
            plh.Controls.Add(linkButton10);
            plh.Controls.Add(new LiteralControl("</li>"));
        }

        public void LoadLi(string liText, string liLink, string liFunc, PlaceHolder plh, string jobconvertedtoinvoice)
        {
            if (liText == "Progress To Invoice")
            {
                LinkButton linkButton = new LinkButton()
                {
                    ID = "lnkProgress",
                    Text = liText
                };
                linkButton.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton.Click += new EventHandler(this.btnProgressToInvoice_Click);
                if (jobconvertedtoinvoice.ToLower().Trim() != "true")
                {
                    linkButton.Enabled = true;
                    linkButton.Attributes.Add("onclick", "javascript:return ProgressJob();");
                }
                else
                {
                    linkButton.Enabled = false;
                    linkButton.Attributes.Add("onclick", "javascript:alert('This Job is already progressed to an invoice and hence cannot be progressed again.');");
                }
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Revert To Estimate")
            {
                LinkButton linkButton1 = new LinkButton()
                {
                    ID = "lnkrevert",
                    Text = liText
                };
                linkButton1.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton1.Click += new EventHandler(this.btnAddTraining_Click);
                if (jobconvertedtoinvoice.ToLower().Trim() != "true")
                {
                    linkButton1.Enabled = true;
                    linkButton1.Attributes.Add("onclick", "javascript:return RevertJob();");
                }
                else
                {
                    linkButton1.Enabled = false;
                    linkButton1.Attributes.Add("onclick", "javascript:alert('This Job is already progressed to an invoice and hence cannot be revert.');");
                }
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton1);
                plh.Controls.Add(new LiteralControl("</li>"));
            }
        }

        public void LoadLi(string liText, string liLink, string liFunc, PlaceHolder plh)
        {
            if (string.Compare(liText, "Estimate Print Email", true) == 0)
            {
                LinkButton linkButton = new LinkButton()
                {
                    ID = "lnk_print_email",
                    Text = "Print/Email"
                };
                linkButton.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton.Attributes.Add("onclick", "javascript:CallPrintEmail();return false;");
                plh.Controls.Add(new LiteralControl("<li id='li_print_email' style='display:none;'>"));
                plh.Controls.Add(linkButton);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Revert To Estimate")
            {
                LinkButton linkButton1 = new LinkButton()
                {
                    ID = "lnkrevert",
                    Text = liText
                };
                linkButton1.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton1.Attributes.Add("onclick", "javascript:return RevertJob();");
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton1);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Progress To Invoice")
            {
                LinkButton linkButton2 = new LinkButton()
                {
                    ID = "lnkProgress",
                    Text = liText
                };
                linkButton2.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton2.Attributes.Add("onclick", "javascript:return ProgressJob();");
                linkButton2.Click += new EventHandler(this.btnProgressToInvoice_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton2);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Copy Estimate")
            {
                LinkButton linkButton3 = new LinkButton()
                {
                    ID = "lnkCopyToNewEstimate",
                    Text = liText
                };
                linkButton3.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton3.Click += new EventHandler(this.lnkCopyEstimate_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton3);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            if (liText == "Add Delivery Note")
            {
                LinkButton linkButton4 = new LinkButton()
                {
                    ID = "lnkDeliveryNote",
                    Text = liText
                };
                linkButton4.Attributes.Add("style", "padding-left:18px;text-decoration:none;");
                linkButton4.OnClientClick = "javascript:return CallConfirm();";
                linkButton4.Click += new EventHandler(this.lnkDeliveryNote_Click);
                plh.Controls.Add(new LiteralControl("<li>"));
                plh.Controls.Add(linkButton4);
                plh.Controls.Add(new LiteralControl("</li>"));
                return;
            }
            ControlCollection controls = plh.Controls;
            string[] strArrays = new string[] { "<li><a href='", liLink, "' style='padding-left:18px;text-decoration:none;' onclick='", liFunc, "'>", liText, "</a></li>" };
            controls.Add(new LiteralControl(string.Concat(strArrays)));
        }

        public void LoadLi(string liTextParent, string liLinkParent, string[] liTextChild, string[] liLinkChild, string[] liFunc, PlaceHolder plh)
        {
            ControlCollection controls = plh.Controls;
            string[] strArrays = new string[] { "<li id='li1'><a href='", liLinkParent, "' style='padding-left:18px;text-decoration:none;'>", liTextParent, "</a>" };
            controls.Add(new LiteralControl(string.Concat(strArrays)));
            plh.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
            for (int i = 0; i < (int)liTextChild.Length; i++)
            {
                ControlCollection controlCollections = plh.Controls;
                string[] strArrays1 = new string[] { "<li><a href='", liLinkChild[i], "' style='padding-left:18px;text-decoration:none;' onclick=", liFunc[i], ">", liTextChild[i], "</a></li>" };
                controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
            }
            plh.Controls.Add(new LiteralControl("</ul>"));
            plh.Controls.Add(new LiteralControl("</li>"));
        }

        public void LoadLi_AccessRight(string liText, PlaceHolder plh)
        {
            plh.Controls.Add(new LiteralControl(string.Concat("<li><a href='javascript:Redirect_LeftPanel();' style='padding-left:18px;text-decoration:none;'>", liText, "</a></li>")));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] estID;
            string[] str;
            if (commonClass.CheckProofPermission())
            {
                if (base.Request.QueryString["ProofID"] != null)
                {
                    this.DivMoreProofAction.Visible = true;
                    this.DivMoreAction.Visible = false;
                    this.btnMoreOptions.Visible = false;
                    this.btnMoreProofOptions.Visible = true;
                }
                else
                {
                    this.DivMoreProofAction.Visible = false;
                    this.DivMoreAction.Visible = true;
                    this.btnMoreOptions.Visible = true;
                    this.btnMoreProofOptions.Visible = false;
                }
            }
            else
            {
                this.DivMoreProofAction.Visible = false;
                this.DivMoreAction.Visible = true;
                this.btnMoreOptions.Visible = true;
                this.btnMoreProofOptions.Visible = false;
            }
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["CompanyID"].ToString())).Rows)
            {
                this.isPopupSortingAllowed = Convert.ToString(row["AllowSortingPopup"]).ToLower().ToString();
            }

            if (isPopupSortingAllowed == "true")
            {
                div_reorder.Visible = true;
            }
            else
            {
                div_reorder.Visible = false;
            }

            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
                this.hdnJObID.Value = base.Request.Params["jID"].ToString();
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
            if (this.OrderID == (long)0)
            {
                if (base.Request.QueryString["estid"] != null)
                {
                    this.OrderID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.EstID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    this.hdnEstimateID.Value = base.Request.Params["estid"].ToString();
                }
                else if (base.Request.QueryString["ordid"] != null)
                {
                    this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
                    this.hdnOrderID.Value = this.OrderID.ToString();
                }
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.OrderID);
            this.li_other_cost.InnerHtml = string.Concat("<a href='#'>", this.objLangClass.GetLanguageConversion("Other_Costs"), "</a>");
            string empty = string.Empty;
            if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
            {
                empty = "estimate";
                this.lblCopy.Text = this.objLangClass.GetLanguageConversion("Copy_Estimate");
                this.btnMoreOptions.Text = this.objLangClass.GetLanguageConversion("Estimate_Options");
                string str1 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
                if (str1 == "0" || str1 == "2")
                {
                    this.div_printmail.Visible = false;
                }
                else
                {
                    this.div_printmail.Visible = true;
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.div_additems.Visible = true;
                    this.div_copy.Visible = true;
                }
                else
                {
                    this.div_additems.Visible = false;
                    this.div_copy.Visible = false;
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.div_attachments.Visible = true;
                }
                else
                {
                    this.div_attachments.Visible = false;
                }
                string str2 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
                if (str2 == "0" || str2 == "2")
                {
                    this.li_p2j.Visible = false;
                }
                else
                {
                    this.li_p2j.Visible = true;
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
            {
                this.lblCopy.Text = this.objLangClass.GetLanguageConversion("Copy_Job");
                empty = "job";
                this.btnMoreOptions.Text = this.objLangClass.GetLanguageConversion("Job_Options");
                if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                {
                    this.lblrevert.Text = this.objLangClass.GetLanguageConversion("Revert_To_Estimate");
                    this.IsFromWebStore = "NO";
                }
                else
                {
                    this.lblrevert.Text = this.objLangClass.GetLanguageConversion("Revert_To_Order");
                    this.IsFromWebStore = "YES";
                }
                string str3 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "printoremail", this.Page.Request.Url.ToString());
                if (str3 == "0" || str3 == "2")
                {
                    this.div_printmail.Visible = false;
                }
                else
                {
                    this.div_printmail.Visible = true;
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.div_additems.Visible = true;
                }
                else
                {
                    this.div_additems.Visible = false;
                }
                string str4 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "others", this.Page.Request.Url.ToString());
                if (str4 == "0" || str4 == "2")
                {
                    this.li_p2j.Visible = false;
                }
                else
                {
                    this.li_p2j.Visible = true;
                }

                var locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                var ignorelocking = "";
                ignorelocking = this.objBase.ReturnRoles_Privileges_Others("ignorelock").ToLower();
                CanIgnoreLock = ignorelocking;
                this.liUnlock.Attributes.Add("onclick", string.Concat("javascript:LockUnlockJob('", this.jobID, "');"));
                var locked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);
                if (locking == "true")
                {


                    LockStatusId = commclass.getLockUnlockStatus(CompanyID, "JOBS", "Lock Job");


                    UnLockStatusId = commclass.getLockUnlockStatus(CompanyID, "JOBS", "UnLock Job");


                    div_lock.Visible = true;
                    liUnlock.Visible = true;
                    lblLockUnlock.Text = "Lock Job";
                    if (locked)
                    {
                        IsJobLocked = true;
                        //div_rerun.Visible = false;
                        //div_additems.Visible = false;
                        //div_revert.Visible = false;
                        lblLockUnlock.Text = "Unlock Job";

                    }

                }

            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
            {
                this.lblCopy.Text = this.objLangClass.GetLanguageConversion("Copy_Invoice");
                this.btnMoreOptions.Text = this.objLangClass.GetLanguageConversion("Invoice_Options");
                empty = "invoice";
                if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                {
                    this.IsFromWebStore = "NO";
                }
                else
                {
                    this.IsFromWebStore = "YES";
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("orders/") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order"))
            {
                empty = "order";
                this.lblCopy.Text = this.objLangClass.GetLanguageConversion("Copy_Order");
                if (base.Request.Url.ToString().ToLower().Contains("orders/"))
                {
                    this.btnMoreOptions.Text = this.objLangClass.GetLanguageConversion("Order_Options");
                }
                this.div_copy.Visible = false;
                this.IsConverted = EstimatesBasePage.Module_IsConverted_To_NextModule(this.jobID, "Job");
                this.div_additems.Visible = true;
                if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary"))
                {
                    this.div_reorder.Attributes.Add("onclick", string.Concat("javascript:ReorderItems('", this.EstID, "','", this.CompanyID, "','0','0','order',);"));
                    this.IsConverted = EstimatesBasePage.Module_IsConverted_To_NextModule(this.OrderID, "order");
                    if (this.IsConverted > (long)0)
                    {
                        DataTable dataTable = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.OrderID, this.OrderID);
                        if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe") || dataTable.Rows.Count > 0)
                        {
                            this.div_additems.Visible = false;
                        }
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order"))
                {
                    this.IsConverted = EstimatesBasePage.Module_IsConverted_To_NextModule(this.jobID, "job");
                    if (this.IsConverted > (long)0)
                    {
                        DataTable dataTable1 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.OrderID, this.OrderID);
                        if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || this.PaymentType.Contains("Stripe") || dataTable1.Rows.Count > 0)
                        {
                            this.div_additems.Visible = false;
                        }
                    }
                }
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["estid"] != null)
            {
                this.EstID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                this.hdnEstimateID.Value = base.Request.Params["estid"].ToString();
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
                this.hdnOrderID.Value = this.OrderID.ToString();
            }
            if (base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.PageType = "webstoreorder";
                DataTable dataTable2 = EstimatesBasePage.estimate_item_select_ByModule(this.CompanyID, this.OrderID, this.PageType);
                this.ApprovedOrderCount = (long)dataTable2.Rows.Count;
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            commonClass _commonClass = this.cmnDate;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.cmnDate;
            DateTime now = DateTime.Now;
            _commonClass.eprint_checkdateformat_returnonlymmddyyyy(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.TodayDate = DateTime.Now;
            this.EstimatesTypesfromDwebconfig();
            DataTable dataTable3 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            itemsummary_moreoptions.ManageStockPermission = Convert.ToInt32(dataTable3.Rows[0]["ProductStockManagement"]);
            this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            this.li_allitems.InnerText = this.objLangClass.GetLanguageConversion("All_Items");
            this.li_proofallitems.InnerText = this.objLangClass.GetLanguageConversion("All_Items");
            this.plhLeftPanel.Controls.Add(new LiteralControl("<div align='left' id='divCustContent'  style='display: block; overflow: visible; height: 150px>"));
            this.plhLeftPanel.Controls.Add(new LiteralControl("<div style='float: left;>"));
            this.plhLeftPanel.Controls.Add(new LiteralControl("<ul id='verticalmenu' class='glossymenu1'>"));
            if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_view.aspx"))
            {
                this.PageType = "estimate";
                this.pnlCustomize.Visible = true;
                string str5 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                if (str5.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=add"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                this.plhLeftPanel.Controls.Add(linkButton);
                LinkButton linkButton1 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton1);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str5.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", string.Concat(this.strSitepath, "estimates/customview.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "estimate") > 0)
                {
                    this.LoadLi("Edit View Estimate", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("estimate", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "estimates/estimate_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/customview.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                string str6 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString());
                string str8 = this.objBase.ReturnRoles_Privileges_ReportStatus("estimate", "showreport");
                if (str6.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=add"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (str7.Trim().ToLower() != "false")
                {
                    this.LoadLi("View Estimates", string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
                if (str8.Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "estimates/estimate_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_pad_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_DigitalNCR_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_large_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_warehouse.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_printbroker.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_pricecatalog.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_item_description.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_othercost.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_large_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_addanitem.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_ncr_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_quickquote.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_DeliveryCost.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_pad_item.aspx?"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Estimates"), this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx?type=edit") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_add.aspx?type=edit"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Estimates", string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx?type=add") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_add.aspx?type=add"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Estimates", string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx?type=more") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_add.aspx?type=more"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Estimates", string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
            {
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                int count = 0;
                string empty3 = string.Empty;
                empty3 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
                StringBuilder stringBuilder = new StringBuilder();
                long num = Convert.ToInt64(base.Request.Params["estid"]);
                bool flag = false;
                foreach (DataRow row in EstimatesBasePage.EstimatItem_Details_Select(this.CompanyID, num, this.PageType).Rows)
                {
                    if (row["EstimateType"].ToString().ToLower() == "o")
                    {
                        flag = true;
                    }
                    empty2 = row["EstimateItemID"].ToString();
                }
                this.plhLeftPanel.Visible = false;
                this.pnlCustomize.Visible = true;
                this.Div_EstSummary.Visible = true;
                this.li_p2j.Style.Add("display", "block");
                this.div_attachments.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','estimate');"));

                if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
                {
                    this.div_reorder.Attributes.Add("onclick", string.Concat("javascript:ReorderItems('", this.EstID, "','", this.CompanyID, "','0','0','estimate',);"));
                }

                this.li_copy2same.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_SameCust('", empty, "');"));
                this.li_copy2new.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_NewCust('", empty, "');"));
                foreach (DataRow dataRow in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, num).Rows)
                {
                    this.sectionid = dataRow["CustomerID"].ToString();
                    this.companytype = dataRow["CompanyType"].ToString();
                    this.hdbstatustitlesamecustomer.Value = dataRow["CustomerStatusTitle"].ToString();
                }
                DataTable dataTable4 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num);
                if (!flag)
                {
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    base.Session["NewTempKey"] = null;
                    this.div_printmail.Style.Add("cursor", "hand");
                    if (empty3 == "0" || empty3 == "2")
                    {
                        this.div_options.Visible = false;
                    }
                    if (dataTable4.Rows.Count <= 1)
                    {
                        this.li_allitems.Visible = false;
                        this.li_selecteditems.Visible = false;
                        this.li_outwork_supplier.Visible = false;
                        this.img_arrow_pmstyle = "display:none;";
                        AttributeCollection attributes = this.div_printmail.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "'" };
                        attributes.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        this.li_outwork_supplier.Visible = false;
                        AttributeCollection attributeCollection = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&GenPdf=all'" };
                        attributeCollection.Add("onclick", string.Concat(estID));
                        this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        HiddenField hdnPrintEmail = this.hdn_PrintEmail;
                        estID = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID };
                        hdnPrintEmail.Value = string.Concat(estID);
                    }
                }
                else
                {
                    this.div_printmail.Style.Add("cursor", "hand");
                    if (dataTable4.Rows.Count <= 1)
                    {
                        if (empty3 == "0" || empty3 == "2")
                        {
                            this.div_options.Visible = false;
                        }
                        this.li_allitems.Visible = true;
                        this.li_selecteditems.Visible = false;
                        this.li_outwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display: block;";
                        this.li_allitems.InnerText = this.objLangClass.GetLanguageConversion("Customer");
                        AttributeCollection attributes1 = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=", this.companytype, "&page=Estimate&EstID=", this.EstID, "'" };
                        attributes1.Add("onclick", string.Concat(estID));
                        AttributeCollection attributeCollection1 = this.li_outwork_supplier.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty2, "'" };
                        attributeCollection1.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        if (empty3 == "0" || empty3 == "2")
                        {
                            this.div_options.Visible = false;
                        }
                        this.li_outwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display:block;";
                        AttributeCollection attributes2 = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&GenPdf=all'" };
                        attributes2.Add("onclick", string.Concat(estID));
                        this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        AttributeCollection attributeCollection2 = this.li_outwork_supplier.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty2, "'" };
                        attributeCollection2.Add("onclick", string.Concat(estID));
                        HiddenField hiddenField = this.hdn_PrintEmail;
                        estID = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID };
                        hiddenField.Value = string.Concat(estID);
                    }
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                if (base.Request.Params["estid"] != null)
                {
                    num = Convert.ToInt64(base.Request.Params["estid"]);
                    DateTime dateTime = DateTime.Now;
                    DataTable dataTable5 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num);
                    StringBuilder stringBuilder1 = new StringBuilder();
                    count = dataTable5.Rows.Count;
                    if (dataTable5.Rows.Count > 1)
                    {
                        stringBuilder1.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none;'>Delete</a>");
                        stringBuilder1.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                    }
                    int num1 = 1;
                    int num2 = 1;
                    foreach (DataRow row1 in dataTable5.Rows)
                    {
                        if (dataTable5.Rows.Count > 1)
                        {
                            string str9 = string.Concat("onclick=javascript:DeleteItem('", row1["EstimateItemID"].ToString(), "')");
                            estID = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str9, " >Item", num1, "</a></li>" };
                            stringBuilder1.Append(string.Concat(estID));
                            num1++;
                        }
                        num2++;
                        empty1 = row1["EstimateType"].ToString();
                        empty2 = row1["EstimateItemID"].ToString();
                    }
                    if (dataTable5.Rows.Count > 1)
                    {
                        stringBuilder1.Append("</ul>");
                        stringBuilder1.Append("</li>");
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                }
                if (count != 10 && count < 10)
                {
                    this.LoadLi("Add An Item", "#", "javascript:AddAnotherItems();", this.plhLeftPanel);
                }
                this.LoadLi("Progress To Job", "#", "javascript:ShowProgressToJob();", this.plhLeftPanel);
                this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                if (this.EstimateConvertedToJob == 0)
                {
                    this.LoadLi("Activity History", "#", "javascript:ShowNotes();", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Copy Estimate</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton2 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;To Same Customer",
                    OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton2);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton3 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;To New Customer",
                    OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton3);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
            }
            else if (base.Request.Url.ToString().ToLower().Contains("proofs/proof"))
            {
                if (base.Request.QueryString["ProofID"] != null)
                {
                    this.ProofID = Convert.ToInt64(base.Request.Params["ProofID"].ToString());

                }
                this.btnMoreProofOptions.Text = "Proof Options";
                this.div_additems.Visible = false;
                this.div_p2job.Visible = false;
                this.div_copy.Visible = false;
                this.div_rerun.Visible = false;
                this.div_attachments.Visible = false;
                this.div_reorder.Visible = false;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                int count = 0;
                string empty3 = string.Empty;
                empty3 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
                StringBuilder stringBuilder = new StringBuilder();
                long num = Convert.ToInt64(base.Request.Params["estid"]);
                bool flag = false;
                foreach (DataRow row in EstimatesBasePage.EstimatItem_Details_Select(this.CompanyID, num, this.PageType).Rows)
                {
                    //if (row["EstimateType"].ToString().ToLower() == "o")
                    //{
                    //    flag = true;
                    //}
                    empty2 = row["EstimateItemID"].ToString();
                }
                this.plhLeftPanel.Visible = false;
                this.pnlCustomize.Visible = true;
                this.Div_EstSummary.Visible = true;
                this.li_p2j.Style.Add("display", "block");
                this.div_attachments.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','estimate');"));

                if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
                {
                    this.div_reorder.Attributes.Add("onclick", string.Concat("javascript:ReorderItems('", this.EstID, "','", this.CompanyID, "','0','0','estimate',);"));
                }

                this.li_copy2same.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_SameCust('", empty, "');"));
                this.li_copy2new.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_NewCust('", empty, "');"));
                foreach (DataRow dataRow in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, num).Rows)
                {
                    this.sectionid = dataRow["CustomerID"].ToString();
                    this.companytype = dataRow["CompanyType"].ToString();
                    this.hdbstatustitlesamecustomer.Value = dataRow["CustomerStatusTitle"].ToString();
                }
                DataTable dataTable4 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num);
                BaseClass baseClass = new BaseClass();
                if (baseClass.GetUserRolePrivilege("proofs", "printoremail") != "1")
                {
                    this.div_proofoptions.Visible = false;
                }
                if (!flag)
                {
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    base.Session["NewTempKey"] = null;
                    this.div_printmail.Style.Add("cursor", "hand");
                    if (empty3 == "0" || empty3 == "2")
                    {
                        this.div_proofoptions.Visible = false;
                    }
                    if (dataTable4.Rows.Count <= 1)
                    {
                        this.li_proofallitems.Visible = false;
                        //this.li_proofselecteditems.Visible = false;
                        //this.li_proofoutwork_supplier.Visible = false;
                        this.img_arrow_pmstyle = "display:none;";
                        AttributeCollection attributes = this.div_printproofmail.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "'" };
                        attributes.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        //this.li_proofoutwork_supplier.Visible = false;
                        AttributeCollection attributeCollection = this.li_proofallitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "&GenPdf=all'" };
                        attributeCollection.Add("onclick", string.Concat(estID));
                        //this.li_proofselecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        HiddenField hdnPrintEmail = this.hdn_PrintEmail;
                        estID = new object[] { this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID };
                        hdnPrintEmail.Value = string.Concat(estID);

                    }
                }
                else
                {
                    this.div_printproofmail.Style.Add("cursor", "hand");
                    if (dataTable4.Rows.Count <= 1)
                    {
                        if (empty3 == "0" || empty3 == "2")
                        {
                            this.div_proofoptions.Visible = false;
                        }
                        this.li_proofallitems.Visible = true;
                        //this.li_proofselecteditems.Visible = false;
                        //this.li_proofoutwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display: block;";
                        this.li_proofallitems.InnerText = this.objLangClass.GetLanguageConversion("Customer");
                        AttributeCollection attributes1 = this.li_proofallitems.Attributes;
                        //estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=", this.companytype, "&page=Estimate&EstID=", this.EstID, "'" };
                        estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "'" };
                        attributes1.Add("onclick", string.Concat(estID));
                        //AttributeCollection attributeCollection1 = this.li_proofoutwork_supplier.Attributes;
                        //estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty2, "'" };
                        //estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "'" };
                        //attributeCollection1.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        if (empty3 == "0" || empty3 == "2")
                        {
                            this.div_proofoptions.Visible = false;
                        }
                        //this.li_proofoutwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display:block;";
                        AttributeCollection attributes2 = this.li_proofallitems.Attributes;
                        //estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&GenPdf=all'" };
                        estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "&GenPdf=all'" };
                        attributes2.Add("onclick", string.Concat(estID));
                        //this.li_proofselecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        //AttributeCollection attributeCollection2 = this.li_proofoutwork_supplier.Attributes;
                        //estID = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty2, "'" };
                        //estID = new object[] { "window.location.href='", this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "&GenPdf=all'" };
                        //attributeCollection2.Add("onclick", string.Concat(estID));
                        HiddenField hiddenField = this.hdn_PrintEmail;
                        //estID = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID };
                        estID = new object[] { this.strSitepath, "Proofs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&ProofID=", this.ProofID, "&GenPdf=all" };
                        hiddenField.Value = string.Concat(estID);
                    }
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                if (base.Request.Params["estid"] != null)
                {
                    num = Convert.ToInt64(base.Request.Params["estid"]);
                    DateTime dateTime = DateTime.Now;
                    DataTable dataTable5 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num);
                    StringBuilder stringBuilder1 = new StringBuilder();
                    count = dataTable5.Rows.Count;
                    if (dataTable5.Rows.Count > 1)
                    {
                        stringBuilder1.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none;'>Delete</a>");
                        stringBuilder1.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                    }
                    int num1 = 1;
                    int num2 = 1;
                    foreach (DataRow row1 in dataTable5.Rows)
                    {
                        if (dataTable5.Rows.Count > 1)
                        {
                            string str9 = string.Concat("onclick=javascript:DeleteItem('", row1["EstimateItemID"].ToString(), "')");
                            estID = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str9, " >Item", num1, "</a></li>" };
                            stringBuilder1.Append(string.Concat(estID));
                            num1++;
                        }
                        num2++;
                        empty1 = row1["EstimateType"].ToString();
                        empty2 = row1["EstimateItemID"].ToString();
                    }
                    if (dataTable5.Rows.Count > 1)
                    {
                        stringBuilder1.Append("</ul>");
                        stringBuilder1.Append("</li>");
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                }
                if (count != 10 && count < 10)
                {
                    this.LoadLi("Add An Item", "#", "javascript:AddAnotherItems();", this.plhLeftPanel);
                }
                this.LoadLi("Progress To Job", "#", "javascript:ShowProgressToJob();", this.plhLeftPanel);
                this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                if (this.EstimateConvertedToJob == 0)
                {
                    this.LoadLi("Activity History", "#", "javascript:ShowNotes();", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Copy Estimate</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton2 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;To Same Customer",
                    OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton2);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton3 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;To New Customer",
                    OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton3);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
            }

            else if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx"))
            {
                this.pnlCustomize.Visible = true;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                empty4 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "printoremail", this.Page.Request.Url.ToString());
                this.Div_EstSummary.Visible = true;
                this.Div_EstSummary.Visible = true;
                this.li_p2j.Style.Add("display", "block");
                this.div_attachments.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','webstoreorder');"));
                this.li_copy2same.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_SameCust('", empty, "');"));
                this.li_copy2new.Attributes.Add("onclick", string.Concat("javascript:ClosedMoreActions();EstimateCopyto_NewCust('", empty, "');"));
                DataTable dataTable6 = OrderBasePage.Order_select(this.CompanyID, Convert.ToInt64(base.Request.Params["ordid"]));
                foreach (DataRow dataRow1 in dataTable6.Rows)
                {
                    this.sectionid = dataRow1["ClientID"].ToString();
                    this.companytype = dataRow1["CompanyType"].ToString();
                }
                base.Session["TemplateHTML"] = null;
                base.Session["TemplateControlList"] = null;
                base.Session["TemplateID"] = null;
                base.Session["NewTempKey"] = null;
                bool flag1 = false;
                DataTable dataTable7 = EstimatesBasePage.EstimatItem_Details_Select(this.CompanyID, Convert.ToInt64(base.Request.Params["estid"]), this.PageType);
                foreach (DataRow row2 in dataTable7.Rows)
                {
                    if (row2["EstimateType"].ToString() == "O")
                    {
                        flag1 = true;
                    }
                    empty6 = row2["EstimateItemID"].ToString();
                }
                DataTable dataTable8 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, Convert.ToInt64(base.Request.Params["estid"]));
                if (flag1)
                {
                    if (dataTable8.Rows.Count <= 1)
                    {
                        this.li_allitems.Visible = true;
                        this.li_selecteditems.Visible = false;
                        this.li_outwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display:block;";
                        this.li_allitems.InnerText = this.objLangClass.GetLanguageConversion("Customer");
                        AttributeCollection attributes3 = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", this.EstID, "&EstID=", this.EstID, "'" };
                        attributes3.Add("onclick", string.Concat(estID));
                        AttributeCollection attributeCollection3 = this.li_outwork_supplier.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&ordid=", this.EstID, "&EstItemID=", empty6, "'" };
                        attributeCollection3.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        this.li_outwork_supplier.Visible = true;
                        this.img_arrow_pmstyle = "display:block;";
                        AttributeCollection attributes4 = this.li_allitems.Attributes;
                        str = new string[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["estid"].ToString(), "&GenPdf=all'" };
                        attributes4.Add("onclick", string.Concat(str));
                        this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        AttributeCollection attributeCollection4 = this.li_outwork_supplier.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&ordid=", this.EstID, "&EstItemID=", empty6, "'" };
                        attributeCollection4.Add("onclick", string.Concat(estID));
                        HiddenField hdnPrintEmail1 = this.hdn_PrintEmail;
                        str = new string[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["estid"].ToString() };
                        hdnPrintEmail1.Value = string.Concat(str);
                    }
                }
                else if (dataTable8.Rows.Count <= 1)
                {
                    this.li_allitems.Visible = false;
                    this.li_selecteditems.Visible = false;
                    this.li_outwork_supplier.Visible = false;
                    this.img_arrow_pmstyle = "display:none;";
                    this.div_printmail.Attributes.Add("onclick", "javascript:CheckApprovedOrder();return false;");
                }
                else
                {
                    this.li_allitems.Attributes.Add("onclick", "javascript:CheckApprovedOrder();return false;");
                    this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                    HiddenField hiddenField1 = this.hdn_PrintEmail;
                    str = new string[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["estid"].ToString() };
                    hiddenField1.Value = string.Concat(str);
                }
                long num3 = Convert.ToInt64(base.Request.Params["estid"]);
                DataTable dataTable9 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num3);
                StringBuilder stringBuilder2 = new StringBuilder();
                if (dataTable9.Rows.Count > 1)
                {
                    stringBuilder2.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none; border: 1px solid red;'>Delete</a>");
                    stringBuilder2.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                }
                int num4 = 1;
                int num5 = 1;
                foreach (DataRow dataRow2 in dataTable9.Rows)
                {
                    if (dataTable9.Rows.Count > 1)
                    {
                        str = new string[] { "onclick=javascript:DeleteOrderItem('", dataRow2["EstimateItemID"].ToString(), "','", dataRow2["OrderItemID"].ToString(), "')" };
                        string str10 = string.Concat(str);
                        estID = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str10, " >Item", num4, "</a></li>" };
                        stringBuilder2.Append(string.Concat(estID));
                        num4++;
                    }
                    num5++;
                }
                if (dataTable9.Rows.Count > 1)
                {
                    stringBuilder2.Append("</ul>");
                    stringBuilder2.Append("</li>");
                }
                string empty7 = string.Empty;
                empty7 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "others", this.Page.Request.Url.ToString());
                if (empty4 == "0" || empty4 == "2")
                {
                    this.div_options.Visible = false;
                }
                if (empty7 == "0" || empty7 == "2")
                {
                    this.li_p2j.Visible = false;
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("estimates/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=edit");
                string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=edit");
                if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), string.Concat(this.strSitepath, "estimates/estimate_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/jobs_view.aspx"))
            {
                this.PageType = "job";
                this.pnlCustomize.Visible = true;
                string str11 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                if (str11.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "jobs/job_add.aspx?type=add"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton4 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton4);
                }
                LinkButton linkButton5 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton5);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton6 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Copy To New Job",
                    OnClientClick = "javascript:return CheckchkOnlyOne();"
                };
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str11.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", string.Concat(this.strSitepath, "jobs/customviewjob.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "job") > 0)
                {
                    this.LoadLi("Edit View Job", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("job", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "jobs/job_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/customviewjob.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Jobs"), string.Concat(this.strSitepath, "Jobs/jobs_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
            {
                string empty8 = string.Empty;
                empty8 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "printoremail", this.Page.Request.Url.ToString());
                this.pnlCustomize.Visible = true;
                string empty9 = string.Empty;
                string empty10 = string.Empty;
                string empty11 = string.Empty;
                int count1 = 0;
                EstimateBasePage.estimate_hasdeliverynote_select(this.CompanyID, this.EstID);
                EstimateBasePage.estimate_deliverynoteid_select(this.CompanyID, this.EstID);
                string empty12 = string.Empty;
                StringBuilder stringBuilder3 = new StringBuilder();
                DataTable dataTable10 = EstimateBasePage.Estimate_Summary_Items_select_by_JobInvoiceID(this.CompanyID, "job", this.jobID);
                count1 = dataTable10.Rows.Count;
                foreach (DataRow row3 in dataTable10.Rows)
                {
                    this.sectionid = row3["CustomerID"].ToString();
                    this.companytype = row3["CompanyType"].ToString();
                    empty11 = row3["IsDirectJob"].ToString();
                    this.hdnIsdirectJob.Value = row3["IsDirectJob"].ToString();
                    this.hdbstatustitlesamecustomer.Value = row3["CustomerStatusTitle"].ToString();
                    empty9 = row3["EstimateType"].ToString();
                    empty10 = row3["EstimateItemID"].ToString();
                    if (itemsummary_moreoptions.ManageStockPermission != 1 || !(empty9.ToLower() == "c") && !(empty9.ToLower() == "x") || !(row3["DrawStockFrom"].ToString().Trim() != ""))
                    {
                        continue;
                    }
                    if (row3["DrawStockFrom"].ToString() == "P")
                    {
                        empty12 = "false_";
                        continue;

                    }
                    empty12 = string.Concat(empty12, this.objBase.Check_Rerun_Delete_Revert_On_Reduction(Convert.ToInt64(row3["pricecatalogueID"]), (long)this.CompanyID, Convert.ToInt64(empty10), this.EstID, row3["DrawStockFrom"].ToString()), "_");
                }
                this.Div_EstSummary.Visible = true;
                this.div_attachments.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.jobID, "','job');"));
                this.li_copy2same.Attributes.Add("onclick", string.Concat("javascript: var a = CheckJobCopyPossible(", this.jobID, "); if(a) EstimateCopyto_SameCust('job'); return a;"));
                this.li_copy2new.Attributes.Add("onclick", string.Concat("javascript: var a = CheckJobCopyPossible(", this.jobID, "); if(a) EstimateCopyto_NewCust('job'); return a;"));
                this.li_revert.Style.Add("display", "block");

                if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx"))
                {
                    this.div_reorder.Attributes.Add("onclick", string.Concat("javascript:ReorderItems('0','", this.CompanyID, "','", this.jobID, "','0','job',);"));
                }

                if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                {
                    this.li_revert.Attributes.Add("onclick", "javascript:RevertJob_reeng('estimate');");
                }
                else
                {
                    this.li_revert.Attributes.Add("onclick", "javascript:RevertJob_reeng('order');");
                }
                if (empty11.ToLower() == "1")
                {
                    this.li_revert.Style.Add("display", "none");
                }
                if (JobsBasePage.Job_Item_Invoiced_Count(this.jobID) == 0)
                {
                    this.li_revert.Style.Add("display", "none");
                }
                if (empty12.ToLower().Contains("false"))
                {
                    this.li_revert.Style.Add("display", "none");
                }
                if (base.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true" && this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isrevert", "").Trim().ToLower() != "1")
                {
                    this.li_revert.Style.Add("display", "none");
                }
                if (empty9 != null)
                {
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    if (empty8 == "0" || empty8 == "2")
                    {
                        this.div_options.Visible = false;
                    }
                    if (count1 <= 1)
                    {
                        this.li_allitems.Visible = false;
                        this.li_selecteditems.Visible = false;
                        this.li_outwork_supplier.Visible = false;
                        this.img_arrow_pmstyle = "display:none;";
                        AttributeCollection attributes5 = this.div_printmail.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job", this.jID, "&EstID=", this.EstID, "&ordid=", this.EstID, "'" };
                        attributes5.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        AttributeCollection attributeCollection5 = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job&EstID=", this.EstID, this.jID, "&GenPdf=all&ordid=", this.EstID, "'" };
                        attributeCollection5.Add("onclick", string.Concat(estID));
                        this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        HiddenField hdnPrintEmail2 = this.hdn_PrintEmail;
                        estID = new object[] { this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job", this.jID, "&EstID=", this.EstID, "&ordid=", this.EstID };
                        hdnPrintEmail2.Value = string.Concat(estID);
                    }
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                if (base.Request.Params["estid"] != null)
                {
                    long num6 = Convert.ToInt64(base.Request.Params["estid"]);
                    DateTime now1 = DateTime.Now;
                    EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num6);
                    StringBuilder stringBuilder4 = new StringBuilder();
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton7 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;To Same Customer",
                        Visible = false,
                        OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton7);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton8 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;To New Customer",
                        Visible = false,
                        OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton8);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Jobs", "jobs_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/jobs_add.aspx") || base.Request.Url.ToString().ToLower().Contains("job_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_large_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_DigitalNCR_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_othercost.aspx") || base.Request.Url.ToString().ToLower().Contains("job_pricecatalog.aspx") || base.Request.Url.ToString().ToLower().Contains("job_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains("job_warehouse.aspx") || base.Request.Url.ToString().ToLower().Contains("job_addanitem.aspx") || base.Request.Url.ToString().ToLower().Contains("job_item_description.aspx") || base.Request.Url.ToString().ToLower().Contains("job_ncr_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_pad_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_quickquote.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_DeliveryCost.aspx?"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Jobs"), "jobs_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Jobs", string.Concat(this.strSitepath, "jobs/jobs_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("job", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "jobs/job_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/customviewinvoice.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Invoice", string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Invoice", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_view.aspx"))
            {
                this.PageType = "invoice";
                this.pnlCustomize.Visible = true;
                string str12 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                if (str12.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "invoice/invoices_add.aspx?type=add"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton9 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton9);
                }
                LinkButton linkButton10 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton10);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton11 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Copy To New Invoice",
                    OnClientClick = "javascript:return CheckchkOnlyOne();"
                };
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str12.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", string.Concat(this.strSitepath, "invoice/customviewinvoice.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "invoice") > 0)
                {
                    this.LoadLi("Edit View Invoice", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("invoices", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "invoice/invoice_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
            {
                string empty13 = string.Empty;
                string str13 = string.Empty;
                empty13 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "printoremail", this.Page.Request.Url.ToString());
                str13 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                string empty14 = string.Empty;
                string str14 = string.Empty;
                this.pnlCustomize.Visible = true;
                StringBuilder stringBuilder5 = new StringBuilder();
                EstimateBasePage.estimate_hasdeliverynote_select(this.CompanyID, this.EstID);
                DataTable dataTable11 = EstimateBasePage.Estimate_Summary_Items_select_by_JobInvoiceID(this.CompanyID, "invoice", this.InvoiceID);
                foreach (DataRow dataRow3 in dataTable11.Rows)
                {
                    empty14 = dataRow3["EstimateType"].ToString();
                    dataRow3["EstimateItemID"].ToString();
                    this.sectionid = dataRow3["CustomerID"].ToString();
                    this.companytype = dataRow3["CompanyType"].ToString();
                }
                this.Div_EstSummary.Visible = true;
                this.div_attachments.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.InvoiceID, "','invoice');"));
                this.li_copy2same.Attributes.Add("onclick", string.Concat("javascript: var a = CheckisInvoiceCopyPossible(", this.InvoiceID, "); if(a) ClosedMoreActions();EstimateCopyto_SameCust('invoice'); return a;"));
                this.li_copy2new.Attributes.Add("onclick", string.Concat("javascript: var a = CheckisInvoiceCopyPossible(", this.InvoiceID, "); if(a) ClosedMoreActions();EstimateCopyto_NewCust('invoice'); return a;"));

                if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                {
                    this.div_reorder.Attributes.Add("onclick", string.Concat("javascript:ReorderItems('0','", this.CompanyID, "','0','", this.InvoiceID, "','invoice',);"));
                }


                if (empty14 != null)
                {
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    if (empty13 == "0" || empty13 == "2")
                    {
                        this.div_options.Visible = false;
                    }
                    if (dataTable11.Rows.Count <= 1)
                    {
                        this.li_allitems.Visible = false;
                        this.li_selecteditems.Visible = false;
                        this.li_outwork_supplier.Visible = false;
                        this.img_arrow_pmstyle = "display:none;";
                        AttributeCollection attributes6 = this.div_printmail.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice", this.InvID, "&EstID=", this.EstID, "&ordid=", this.EstID, "'" };
                        attributes6.Add("onclick", string.Concat(estID));
                    }
                    else
                    {
                        AttributeCollection attributeCollection6 = this.li_allitems.Attributes;
                        estID = new object[] { "window.location.href='", this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice&EstID=", this.EstID, this.InvID, "&GenPdf=all&ordid=", this.EstID, "'" };
                        attributeCollection6.Add("onclick", string.Concat(estID));
                        this.li_selecteditems.Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        HiddenField hiddenField2 = this.hdn_PrintEmail;
                        estID = new object[] { this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice", this.InvID, "&EstID=", this.EstID, "&ordid=", this.EstID };
                        hiddenField2.Value = string.Concat(estID);
                    }
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                if (base.Request.Params["estid"] != null)
                {
                    string empty15 = string.Empty;
                    foreach (DataRow row4 in InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstID).Rows)
                    {
                        if (row4["Status"].ToString().ToLower() != "locked")
                        {
                            continue;
                        }
                        empty15 = "yes";
                    }
                    if (empty15 == "")
                    {
                        long num7 = Convert.ToInt64(base.Request.Params["estid"]);
                        DateTime dateTime1 = DateTime.Now;
                        DataTable dataTable12 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num7);
                        StringBuilder stringBuilder6 = new StringBuilder();
                        int count2 = dataTable12.Rows.Count;
                        this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                    }
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton12 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;To Same Customer",
                    Visible = false,
                    OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton12);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton13 = new LinkButton()
                {
                    Visible = false,
                    Text = "&nbsp;&nbsp;To New Customer",
                    OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                };
                this.plhLeftPanel.Controls.Add(linkButton13);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str13.Trim().ToLower() == "false")
                {
                    this.div_additems.Visible = false;
                    this.div_copy.Visible = false;
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx?type=add") || base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_large_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_DigitalNCR_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_othercost.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_pricecatalog.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_warehouse.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_addanitem.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_item_description.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_ncr_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_quickquote.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_DeliveryCost.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx?type=more"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx?type=edit"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "invoice/invoices_add.aspx?type=add"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Estimates", string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                }
                this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), string.Concat(this.strSitepath, "invoice/invoice_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("invoices", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "invoice/invoice_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse_search.aspx?type=store"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Store Supply", string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=store"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "warehouse/finishedgoods_report.aspx?type=store"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse_search.aspx?type=item"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=item"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Customer Item", string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=item"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "warehouse/finishedgoods_report.aspx?type=item"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse_inventory_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "warehouse/inventory_add.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "warehouse/inventory_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse.aspx?type=inventory") || base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_settings.aspx"))
            {
                this.pnlCustomize.Visible = true;
                string str15 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                if (str15.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "warehouse/inventory_add.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Categories", string.Concat(this.strSitepath, "warehouse/inventory_settings.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Categories", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Tools</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul2' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton14 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Export",
                    PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventoryexport.aspx")
                };
                string str16 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "exportorimport", this.Page.Request.Url.ToString());
                if (str16 != "0" && str16 != "2")
                {
                    this.plhLeftPanel.Controls.Add(linkButton14);
                }
                LinkButton linkButton15 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Import",
                    PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventory_import.aspx")
                };
                if (str16 != "0" && str16 != "2")
                {
                    this.plhLeftPanel.Controls.Add(linkButton15);
                }
                LinkButton linkButton16 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Mass Adjustment",
                    PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventory_adjustment.aspx")
                };
                this.plhLeftPanel.Controls.Add(linkButton16);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton17 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton17);
                }
                LinkButton linkButton18 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive Selected",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton18);
                LinkButton linkButton19 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Un-Archive selected",
                    OnClientClick = "javascript:return CheckchkOne('unarchive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton19);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Views</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                if (str15.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", string.Concat(this.strSitepath, "warehouse/customviewinv.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "inventory") > 0)
                {
                    this.LoadLi("Edit View Inventory", " ", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", string.Concat(this.strSitepath, "warehouse/inventory_report.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse.aspx?type=store"))
            {
                this.pnlCustomize.Visible = true;
                string str17 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                if (str17.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"), this.plhLeftPanel);
                    this.LoadLi("View Customer Item", string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=item"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton20 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton20);
                }
                LinkButton linkButton21 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive selected",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton21);
                LinkButton linkButton22 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Un-Archive selected",
                    OnClientClick = "javascript:return CheckchkOne('unarchive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton22);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str17.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", string.Concat(this.strSitepath, "warehouse/customviewstore.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "store") > 0)
                {
                    this.LoadLi("Edit View Store", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Report", "../warehouse/finishedgoods_report.aspx?type=store", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Report", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse.aspx?type=item"))
            {
                this.pnlCustomize.Visible = true;
                string str18 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                if (str18.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../warehouse/item_finishedgoods_add.aspx?page=item", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                    this.LoadLi("View Store Supply", "../warehouse/warehouse.aspx?type=store", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton23 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton23);
                }
                LinkButton linkButton24 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive Selected",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton24);
                LinkButton linkButton25 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Un-Archive selected",
                    OnClientClick = "javascript:return CheckchkOne('unarchive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton25);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str18.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", "../warehouse/customviewitem.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "item") > 0)
                {
                    this.LoadLi("Edit View Item", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Report", "../warehouse/finishedgoods_report.aspx?type=item", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Report", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_add.aspx?type=edit"))
            {
                this.pnlCustomize.Visible = true;
                this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString());
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton26 = new LinkButton()
                {
                    Text = string.Concat("&nbsp;&nbsp;&nbsp;", this.objLangClass.GetLanguageConversion("Copy_Inventory")),
                    OnClientClick = "javascript:return Copy_Inventory();"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton26);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_add.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Inventory"), "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/item_finishedgoods_add.aspx?page=store"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                    this.LoadLi("View Store Supply", "../warehouse/warehouse.aspx?type=store", this.plhLeftPanel);
                    this.LoadLi("View Customer Item", "../warehouse/warehouse.aspx?type=item", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/item_finishedgoods_add.aspx?page=item"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                    this.LoadLi("View Customer Item", "../warehouse/warehouse.aspx?type=item", this.plhLeftPanel);
                    this.LoadLi("View Store Supply", "../warehouse/warehouse.aspx?type=store", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                    this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_view.aspx"))
            {
                this.PageType = "purchase";
                this.pnlCustomize.Visible = true;
                string str19 = this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isadd", this.Page.Request.Url.ToString());
                if (str19.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../Purchase/purchase_add.aspx?type=add", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton27 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton27);
                }
                LinkButton linkButton28 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton28);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton29 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Copy To New PO",
                    OnClientClick = "javascript:return CheckchkOnlyOne();"
                };
                if (str19.Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton29);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str19.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", "../Purchase/customviewpurchase.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "purchase") > 0)
                {
                    this.LoadLi("Edit View Purchase", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("purchase", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", "../Purchase/purchase_report.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../Purchase/purchase_add.aspx?type=add", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Purchase", "../Purchase/purchase_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Purchase", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("purchase", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", "../Purchase/purchase_report.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=add"))
            {
                this.pnlCustomize.Visible = true;
                string str20 = this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "printoremail", this.Page.Request.Url.ToString());
                if (str20 == "0" || str20 == "2")
                {
                    this.LoadLi_AccessRight("Print/Email", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Purchase"), "../Purchase/purchase_view.aspx", this.plhLeftPanel);
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse"), "#", "Javascript:javascript:PopUpWarehouse();", this.plhLeftPanel);
                    if (itemsummary_moreoptions.ManageStockPermission == 1)
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse_Report"), "javascript:void(0);", "Javascript:javascript:PopUpProductList();", this.plhLeftPanel);
                    }
                }
                else
                {
                    this.LoadLi_AccessRight("View Purchases", this.plhLeftPanel);
                    this.LoadLi_AccessRight("Warehouse", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit"))
            {
                long num8 = Convert.ToInt64(base.Request.Params["id"].ToString());
                foreach (DataRow dataRow4 in PurchaseBasePage.purchase_select(this.CompanyID, num8).Rows)
                {
                    this.sectionid = dataRow4["SupplierID"].ToString();
                    this.companytype = dataRow4["CompanyType"].ToString();
                }
                this.pnlCustomize.Visible = true;
                BaseClass baseClass = new BaseClass();
                string empty16 = string.Empty;
                empty16 = baseClass.ReturnRoles_Privileges_ForGrid("purchases", "printoremail", this.Page.Request.Url.ToString());
                if (empty16 != "0" && empty16 != "2")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                }
                string empty17 = string.Empty;
                if (baseClass.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()) != "False")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Purchase"), "../Purchase/purchase_view.aspx", this.plhLeftPanel);
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse"), "#", "Javascript:javascript:PopUpWarehouse();", this.plhLeftPanel);
                    if (itemsummary_moreoptions.ManageStockPermission == 1)
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse_Report"), "javascript:void(0);", "Javascript:javascript:PopUpProductList();", this.plhLeftPanel);
                    }
                }
                base.Session["TemplateHTML"] = null;
                base.Session["TemplateControlList"] = null;
                base.Session["TemplateID"] = null;
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Purchases", "../Purchase/purchase_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Purchases", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("documents/document.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("documents", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("Add_New"), "../documents/document_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("documents/document_add.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("documents", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Documents", "../documents/document.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Documents", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("documents/document_edit.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("documents", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Documents", "../documents/document.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Documents", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("documents/document_category_detail.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("documents", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../documents/document_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("documents", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Documents", "../documents/document.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Documents", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase/customviewpurchase.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Purchase"), "../Purchase/purchase_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Purchase", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery/customviewdelivery.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Delivery"), "../Delivery/delivery_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Delivery", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/customviewinv.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Inventory"), "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/customviewstore.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Store Supply", "../warehouse/warehouse.aspx?type=store", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/customviewitem.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Customer Item", "../warehouse/warehouse.aspx?type=item", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventoryexport.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_import.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_adjustment.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_view.aspx"))
            {
                this.PageType = "delivery";
                this.pnlCustomize.Visible = true;
                string str21 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString());
                if (str21.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../delivery/delivery_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton30 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton30);
                }
                LinkButton linkButton31 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton31);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (str21.Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", "../delivery/customviewdelivery.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "deliverynote") > 0)
                {
                    this.LoadLi("Edit View Delivery", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("delivery notes", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", "../delivery/delivery_report.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_search.aspx"))
            {
                this.PageType = "delivery";
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../delivery/delivery_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Delivery Notes", "../delivery/delivery_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Delivery Notes", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("delivery notes", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", "../delivery/delivery_report.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx"))
            {
                if (base.Request.Params["id"] == null)
                {
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    string str22 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "printoremail", this.Page.Request.Url.ToString());
                    if (str22 == "0" || str22 == "2")
                    {
                        this.LoadLi_AccessRight("Print/Email", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                    }
                }
                else
                {
                    long num9 = (long)Convert.ToInt32(base.Request.Params["id"].ToString());
                    foreach (DataRow row5 in DeliveryBasePage.delivery_select(this.CompanyID, num9).Rows)
                    {
                        this.sectionid = row5["CustomerID"].ToString();
                        this.companytype = row5["CompanyType"].ToString();
                    }
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    string str23 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "printoremail", this.Page.Request.Url.ToString());
                    if (str23 != "0" || str23 != "2")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                    }
                }
                this.pnlCustomize.Visible = true;
                string str24 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isview", this.Page.Request.Url.ToString());
                if (str24.Trim().ToLower() != "false")
                {
                    this.LoadLi(this.objLangClass.GetLanguageConversion("View_Delivery_Note"), "../delivery/delivery_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Delivery Note", this.plhLeftPanel);
                }
                if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit"))
                {
                    if (str24.Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Attachments", this.plhLeftPanel);
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Delivery Notes", "../delivery/delivery_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Delivery Note", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_view.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../Campaign/Campaign_add.aspx", this.plhLeftPanel);
                    this.LoadLi("Add New View", "../campaign/campaign_createview.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (CompanyBasePage.Campaign_customview_count(this.CompanyID) > 0)
                {
                    this.LoadLi("Edit View Campaign", "", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_createview.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_editview.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_detail.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../Campaign/Campaign_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
                this.LoadLi("Copy", "", this.plhLeftPanel);
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/emailmarketing_detail.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New", "../Campaign/Campaign_add.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_edit.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_add.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("campaign/campaign_clone.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("common/attachment_viewall.aspx"))
            {
                if (base.Request.Url.ToString().ToLower().Contains("common/attachment_viewall.aspx?sectionname=campaign"))
                {
                    this.pnlCustomize.Visible = true;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("campaign", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Campaigns", "../campaign/campaign_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Campaigns", this.plhLeftPanel);
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("common/report.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.CheckUserAccessRight("clients", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("crm", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("CRM_Report"), "../client/client_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("CRM Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("ESTIMATES", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("estimate", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Estimate_Report"), "../estimates/estimate_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Estimate Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("webstoreorder", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("webstoreorder", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Order_Report"), "../Orders/order_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Order Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("JOBS", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("job", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Job_Report"), "../jobs/job_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Job Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("PURCHASES", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("purchase", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Purchase_Report"), "../Purchase/purchase_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Purchase Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("DELIVERYNOTE", "report") && ConnectionClass.DeliveryNote != null)
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("delivery notes", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Delivery_Report"), "../delivery/delivery_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Delivery Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("INVOICES", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("invoices", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Invoice_Report"), "../invoice/invoice_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Invoice Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("WAREHOUSE", "report") && ConnectionClass.Warehouse != null)
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Inventory_Report"), "../warehouse/inventory_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Inventory Report", this.plhLeftPanel);
                    }
                }
                if (this.objBase.CheckUserAccessRight("PRODUCTCATALOGUE", "report"))
                {
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("product catalogue", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Product_Catalogue"), "../common/productcatalogue_report.aspx?pg=report", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Product Catalogue", this.plhLeftPanel);
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order_productcatalogue.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Orders", "../orders/order_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Orders", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary_rerun.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Orders", "../orders/order_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Orders", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order_view.aspx"))
            {
                this.PageType = "orders";
                this.pnlCustomize.Visible = true;
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                LinkButton linkButton32 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Delete",
                    OnClientClick = "javascript:return CheckchkOne('delete');"
                };
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.plhLeftPanel.Controls.Add(linkButton32);
                }
                LinkButton linkButton33 = new LinkButton()
                {
                    Text = "&nbsp;&nbsp;Archive",
                    OnClientClick = "javascript:return CheckchkOne('archive');"
                };
                this.plhLeftPanel.Controls.Add(linkButton33);
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Add New View", "../orders/customvieworder.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Add New View", this.plhLeftPanel);
                }
                if (EstimateBasePage.estimates_customview_count(this.CompanyID, "webstoreorder") > 0)
                {
                    this.LoadLi("Edit View Order", " ", this.plhLeftPanel);
                }
                if (this.objBase.ReturnRoles_Privileges_ReportStatus("webstoreorder", "showreport").Trim().ToLower() != "false")
                {
                    this.LoadLi("Reports", "../Orders/order_report.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/customvieworder.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Order View", "../orders/order_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Order View", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/order_search.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Order View", "../orders/order_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Order View", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_productcatalogue.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Jobs", "../jobs/jobs_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("orders/templates_view1.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("Order View", string.Concat(this.strSitepath, "orders/order_view.aspx"), this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("Order View", this.plhLeftPanel);
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_productcatalogue.aspx"))
            {
                this.pnlCustomize.Visible = true;
                if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                {
                    this.LoadLi("View Orders", "../invoice/invoice_view.aspx", this.plhLeftPanel);
                }
                else
                {
                    this.LoadLi_AccessRight("View Orders", this.plhLeftPanel);
                }
            }
            this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
            this.plhLeftPanel.Controls.Add(new LiteralControl("</div>"));
            this.plhLeftPanel.Controls.Add(new LiteralControl("</div>"));
            string empty18 = string.Empty;
            if (this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure") == "In.")
            {
                this.li_large_sm.InnerText = this.objLangClass.GetLanguageConversion("Square_Feet");
                return;
            }
            this.li_large_sm.InnerText = this.objLangClass.GetLanguageConversion("Sqaure_Meter");
            this.li_large_tilling.InnerText = "Tilling";
        }

        private void SystemNotes_ProgressToInvoice_Insert()
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in EstimateBasePage.estimates_notestag_select(this.CompanyID).Rows)
            {
                row["TagName"].ToString();
                row["VariableName"].ToString();
            }
            string str1 = DateTime.Now.ToString();
            string str2 = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            foreach (DataRow dataRow in EstimateBasePage.estimates_systemnotes_select(this.CompanyID, "Progress_ToInvoice").Rows)
            {
                empty = dataRow["Description"].ToString();
            }
            empty = empty.Replace("<ProgressedDate>", str1);
            empty = empty.Replace("<UserName>", str2);
            EstimateItem estimateItem = new EstimateItem()
            {
                CompanyID = this.CompanyID,
                EstNotesID = (long)0,
                ModuleType = "I",
                ModuleID = this.EstID,
                NotesType = "S",
                Notes = empty,
                CreatedBy = Convert.ToInt32(base.Session["UserID"].ToString())
            };
        }

        private void SystemNotes_RevertToEstimate_Insert()
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in EstimateBasePage.estimates_notestag_select(this.CompanyID).Rows)
            {
                row["TagName"].ToString();
                row["VariableName"].ToString();
            }
            string str1 = DateTime.Now.ToString();
            string str2 = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            foreach (DataRow dataRow in EstimateBasePage.estimates_systemnotes_select(this.CompanyID, "Revert_ToEstimate").Rows)
            {
                empty = dataRow["Description"].ToString();
            }
            empty = empty.Replace("<RevertedDate>", str1);
            empty = empty.Replace("<UserName>", str2);
            EstimateItem estimateItem = new EstimateItem()
            {
                CompanyID = this.CompanyID,
                EstNotesID = (long)0,
                ModuleType = "E",
                ModuleID = this.EstID,
                NotesType = "S",
                Notes = empty,
                CreatedBy = Convert.ToInt32(base.Session["UserID"].ToString())
            };
        }
    }
}