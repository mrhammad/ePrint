using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint
{
    public partial class printcenter_leftpanel : UserControl
    {
        //protected HtmlGenericControl divLoadingImageCus;

        //protected HtmlGenericControl divitemclose;

        //protected HtmlGenericControl divitemshow;

        //protected Label lblItem;

        //protected HtmlGenericControl divItem;

        //protected HtmlGenericControl divItem_Store;

        //protected HtmlGenericControl divItem_Contract;

        //protected HtmlGenericControl divItem_Library;

        //protected HtmlGenericControl divItem_Jobs;

        //protected HtmlGenericControl divItem_Attachments;

        //protected HtmlGenericControl divItem_Notes;

        //protected HtmlGenericControl divAddItem;

        //protected Panel pnlestimate;

        //protected HtmlGenericControl divestimateclosed;

        //protected HtmlGenericControl divestimateopen;

        //protected HtmlGenericControl add_estimate;

        //protected HtmlGenericControl report_estimate;

        //protected HtmlGenericControl view_estimate;

        //protected HtmlGenericControl att_estimate;

        //protected HtmlGenericControl note_estimate;

        //protected Panel pnlItem;

        //protected HtmlGenericControl divstockclose;

        //protected HtmlGenericControl divstockshow;

        //protected Panel pnlPurchase;

        //protected Label lblheader1;

        //protected HtmlGenericControl divinventoryclose;

        //protected Label lblheader;

        //protected HtmlGenericControl divinventoryshow;

        //protected HtmlGenericControl liInvAdd;

        //protected HtmlGenericControl liInvView;

        //protected HtmlGenericControl listoresupply;

        //protected HtmlGenericControl licustomeritem;

        //protected HtmlGenericControl liInvAdj;

        //protected HtmlGenericControl liAddStore;

        //protected HtmlGenericControl li5;

        //protected HtmlGenericControl liViewStore;

        //protected HtmlGenericControl li9;

        //protected HtmlGenericControl li6;

        //protected HtmlGenericControl liAddItem;

        //protected HtmlGenericControl li7;

        //protected HtmlGenericControl liViewItem;

        //protected HtmlGenericControl li10;

        //protected HtmlGenericControl li8;

        //protected HtmlGenericControl divsetting;

        //protected Panel pnlWarehouse;

        //protected HtmlGenericControl divprintclose;

        //protected HtmlGenericControl divprintshow;

        //protected PlaceHolder plhLeftSide;

        //protected HtmlGenericControl divitem_form1;

        //protected HtmlGenericControl add_moreitem;

        //protected HtmlGenericControl Li1;

        //protected HtmlGenericControl Li2;

        //protected HtmlGenericControl Li3;

        //protected HtmlGenericControl Li4;

        //protected HtmlGenericControl divitem_form;

        //protected HtmlGenericControl prntEstimate;

        //protected HtmlGenericControl prntProforma;

        //protected HtmlGenericControl prntInvoice;

        //protected HtmlGenericControl prntMrn;

        //protected HtmlGenericControl prntNote;

        //protected HtmlGenericControl prntPo;

        //protected HtmlGenericControl prntAckno;

        //protected LinkButton lnkrevertto_estimate;

        //protected HtmlGenericControl divbtnestimate;

        //protected LinkButton lnkprogressto_job;

        //protected HtmlGenericControl divbtnjob;

        //protected HtmlGenericControl divPrint;

        //protected Panel pnlPrint;

        //protected LinkButton btnEstimate;

        //protected LinkButton btnJob;

        //protected Panel pnlButton;

        //protected HtmlGenericControl divcustclose;

        //protected HtmlGenericControl divcustshow;

        //protected RadPanelBar RadPanelBar_ordSummary;

        //protected HtmlGenericControl Div_OrderSummary;

        //protected PlaceHolder plhLeftPanel;

        //protected RadPanelBar RadPanelBar_LeftPanel;

        //protected HtmlGenericControl Div_EstSummary;

        //protected HiddenField hdn_PrintEmail;

        //protected PlaceHolder plhjobLeftPanel;

        //protected HtmlGenericControl divJobCust;

        //protected Panel pnlCustomize;

        //protected HtmlGenericControl divcustclose2;

        //protected HtmlGenericControl divcustshow2;

        //protected PlaceHolder plhLeftPanel2;

        //protected Panel pnlCustomize2;

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

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int divheight;

        private CompanyBasePage objCom = new CompanyBasePage();

        public string urlInventory = string.Empty;

        public string urlStoreSupply = string.Empty;

        public string urlCustomerItem = string.Empty;

        private long EstID;

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

        public string SheetFedDigital = string.Empty;

        public string DigitalSingleItem = string.Empty;

        public string DigitalBooklet = string.Empty;

        public string DigitalPads = string.Empty;

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

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        static printcenter_leftpanel()
        {
        }

        public printcenter_leftpanel()
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
                    else if (string.Compare(str1, "C", true) == 0)
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
                    if (string.Compare(str4, "C", true) != 0)
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
            RadMenu languageConversion = (RadMenu)this.RadPanelBar_LeftPanel.Items[1].Items[0].FindControl("RadMenu_LeftPanel");
            if (ConnectionClass.SheetFedDigital == null)
            {
                languageConversion.Items[0].Visible = false;
            }
            else
            {
                languageConversion.Items[0].Text = this.objLangClass.GetLanguageConversion("Sheet_Fed_Digital");
                if (ConnectionClass.DigitalSingleItem == null)
                {
                    languageConversion.Items[0].Items[0].Visible = false;
                }
                else
                {
                    languageConversion.Items[0].Items[0].Text = this.objLangClass.GetLanguageConversion("Single_Item");
                }
                if (ConnectionClass.DigitalBooklet == null)
                {
                    languageConversion.Items[0].Items[1].Visible = false;
                }
                else
                {
                    languageConversion.Items[0].Items[1].Text = this.objLangClass.GetLanguageConversion("Booklet");
                }
                if (ConnectionClass.DigitalPads == null)
                {
                    languageConversion.Items[0].Items[2].Visible = false;
                }
                else
                {
                    languageConversion.Items[0].Items[2].Text = this.objLangClass.GetLanguageConversion("Pads");
                }
            }
            if (ConnectionClass.SheetFedOffset == null)
            {
                languageConversion.Items[1].Visible = false;
            }
            else
            {
                languageConversion.Items[1].Text = this.objLangClass.GetLanguageConversion("Sheet_Fed_Offset");
                if (ConnectionClass.OffsetSingleItem == null)
                {
                    languageConversion.Items[1].Items[0].Visible = false;
                }
                else
                {
                    languageConversion.Items[1].Items[0].Text = this.objLangClass.GetLanguageConversion("Single_Item");
                }
                if (ConnectionClass.OffsetBooklet == null)
                {
                    languageConversion.Items[1].Items[1].Visible = false;
                }
                else
                {
                    languageConversion.Items[1].Items[1].Text = this.objLangClass.GetLanguageConversion("Booklet");
                }
                if (ConnectionClass.OffsetNCR == null)
                {
                    languageConversion.Items[1].Items[2].Visible = false;
                }
                else
                {
                    languageConversion.Items[1].Items[2].Text = this.objLangClass.GetLanguageConversion("NCR");
                }
                if (ConnectionClass.OffsetPad == null)
                {
                    languageConversion.Items[1].Items[3].Visible = false;
                }
                else
                {
                    languageConversion.Items[1].Items[3].Text = this.objLangClass.GetLanguageConversion("Pads");
                }
            }
            if (ConnectionClass.PrintBroker == null)
            {
                languageConversion.Items[2].Visible = false;
            }
            else
            {
                languageConversion.Items[2].Text = this.objLangClass.GetLanguageConversion("Outwork");
            }
            if (ConnectionClass.PriceCatalogue == null)
            {
                languageConversion.Items[3].Visible = false;
            }
            else
            {
                languageConversion.Items[3].Text = this.objLangClass.GetLanguageConversion("Product_Catalogue");
            }
            if (ConnectionClass.OtherCosts == null)
            {
                languageConversion.Items[4].Visible = false;
            }
            else
            {
                languageConversion.Items[4].Text = this.objLangClass.GetLanguageConversion("OtherCost");
            }
            if (ConnectionClass.LargeFormat == null)
            {
                languageConversion.Items[5].Visible = false;
            }
            else
            {
                languageConversion.Items[5].Text = this.objLangClass.GetLanguageConversion("Large_Format");
            }
            if (ConnectionClass.Warehouse == null)
            {
                languageConversion.Items[6].Visible = false;
            }
            else
            {
                languageConversion.Items[6].Text = this.objLangClass.GetLanguageConversion("Inventory");
            }
            if (ConnectionClass.QuickQuote == null)
            {
                languageConversion.Items[7].Visible = false;
                return;
            }
            else
            {
                languageConversion.Items[7].Text = this.objLangClass.GetLanguageConversion("QuickQuote");
            }
            if (ConnectionClass.DeliveryCost == null)
            {
                languageConversion.Items[7].Visible = false;
                return;
            }
            else
            {
                languageConversion.Items[7].Text = this.objLangClass.GetLanguageConversion("DeliveryCost");
            }
            //if (ConnectionClass.zip2tax == null)
            //{
              //  languageConversion.Items[9].Visible = false;
              //  return;
            //}
            //else
            //{
              //  languageConversion.Items[9].Text = this.objLangClass.GetLanguageConversion("zip2tax");
            //}
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
            else if (EstimateType == "C")
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
            DataRow[] dataRowArray;
            int i;
            string[] languageConversion;
            object[] str;
            if (!base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
            {
                if (!base.IsPostBack)
                {
                    RadMenu radMenu = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                    radMenu.Items[0].Text = this.objLangClass.GetLanguageConversion("Print_Email");
                    this.RadPanelBar_LeftPanel.Items[1].Text = this.objLangClass.GetLanguageConversion("Add_Item");
                    RadMenu languageConversion1 = (RadMenu)this.RadPanelBar_LeftPanel.Items[1].Items[0].FindControl("RadMenu_LeftPanel");
                    languageConversion1.Items[0].Text = this.objLangClass.GetLanguageConversion("Sheet_Fed_Digital");
                    languageConversion1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sheet_Fed_Offset");
                    languageConversion1.Items[2].Text = this.objLangClass.GetLanguageConversion("Outwork");
                    languageConversion1.Items[3].Text = this.objLangClass.GetLanguageConversion("Product_Catalogue");
                    languageConversion1.Items[4].Text = this.objLangClass.GetLanguageConversion("Other_Costs");
                    languageConversion1.Items[5].Text = this.objLangClass.GetLanguageConversion("Large_Format");
                    languageConversion1.Items[6].Text = this.objLangClass.GetLanguageConversion("Warehouse");
                    languageConversion1.Items[7].Text = this.objLangClass.GetLanguageConversion("Quick_Quote");
                    this.RadPanelBar_LeftPanel.Items[2].Text = this.objLangClass.GetLanguageConversion("Progress_To_Job");
                    this.RadPanelBar_LeftPanel.Items[3].Text = this.objLangClass.GetLanguageConversion("Attachments");
                    this.RadPanelBar_LeftPanel.Items[4].Text = this.objLangClass.GetLanguageConversion("Copy_Estimate");
                    this.RadPanelBar_LeftPanel.Items[4].Items[0].Text = this.objLangClass.GetLanguageConversion("To_Same_Customer");
                    this.RadPanelBar_LeftPanel.Items[4].Items[1].Text = this.objLangClass.GetLanguageConversion("To_New_Customer");
                    this.RadPanelBar_LeftPanel.Items[5].Text = this.objLangClass.GetLanguageConversion("Revert_To_Estimate");
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
                string empty = string.Empty;
                if (base.Request.Url.ToString().ToLower().Contains("estimates/"))
                {
                    empty = "estimate";
                    string str1 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
                    if (str1 == "0" || str1 == "2")
                    {
                        this.RadPanelBar_LeftPanel.Items[0].Visible = false;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[0].Visible = true;
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Visible = true;
                        this.RadPanelBar_LeftPanel.Items[4].Visible = true;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Visible = false;
                        this.RadPanelBar_LeftPanel.Items[4].Visible = false;
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.RadPanelBar_LeftPanel.Items[3].Visible = true;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[3].Visible = false;
                    }
                    string str2 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
                    if (str2 == "0" || str2 == "2")
                    {
                        this.RadPanelBar_LeftPanel.Items[2].Visible = false;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[2].Visible = true;
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("jobs/"))
                {
                    empty = "job";
                    string str3 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "printoremail", this.Page.Request.Url.ToString());
                    if (str3 == "0" || str3 == "2")
                    {
                        this.RadPanelBar_LeftPanel.Items[0].Visible = false;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[0].Visible = true;
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Visible = true;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Visible = false;
                    }
                    string str4 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "others", this.Page.Request.Url.ToString());
                    if (str4 == "0" || str4 == "2")
                    {
                        this.RadPanelBar_LeftPanel.Items[2].Visible = false;
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[2].Visible = true;
                    }
                }
                if (base.Request.Url.ToString().ToLower().Contains("invoice/"))
                {
                    empty = "invoice";
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
                RadMenu radMenu1 = (RadMenu)this.RadPanelBar_LeftPanel.Items[1].Items[0].FindControl("RadMenu_LeftPanel");
                this.DateFormat = base.Session["DateFormat"].ToString();
                this.pnlCustomize2.Visible = false;
                this.plhjobLeftPanel.Visible = false;
                bool flag = false;
                bool flag1 = false;
                foreach (DataRow row in EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstID, empty).Rows)
                {
                    if (Convert.ToInt64(row["JOBID"]) > (long)0)
                    {
                        flag = true;
                    }
                    if (Convert.ToInt64(row["InvoiceID"]) <= (long)0)
                    {
                        continue;
                    }
                    flag1 = true;
                }
                commonClass _commonClass = this.cmnDate;
                string dateFormat = this.DateFormat;
                commonClass _commonClass1 = this.cmnDate;
                DateTime now = DateTime.Now;
                _commonClass.eprint_checkdateformat_returnonlymmddyyyy(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                this.TodayDate = DateTime.Now;
                this.EstimatesTypesfromDwebconfig();
                DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
                printcenter_leftpanel.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
                if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&id=") || base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&pg=job&estid=") || base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit&id="))
                {
                    this.divJobCust.Attributes.Add("style", "display:block");
                    this.pnlCustomize.Visible = true;
                    this.plhjobLeftPanel.Visible = true;
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div>"));
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string str5 = "False";
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    string str6 = string.Empty;
                    string empty7 = string.Empty;
                    string str7 = string.Empty;
                    string empty8 = string.Empty;
                    string str8 = string.Empty;
                    long num = (long)0;
                    string empty9 = string.Empty;
                    long num1 = (long)0;
                    if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx"))
                    {
                        if (base.Request.Params["id"] != null)
                        {
                            num1 = Convert.ToInt64(base.Request.Params["id"].ToString());
                            empty9 = "deliverynote";
                        }
                    }
                    else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx") && base.Request.Params["id"] != null)
                    {
                        num1 = Convert.ToInt64(base.Request.Params["id"].ToString());
                        empty9 = "Purchase";
                    }
                    DataTable dataTable1 = this.objBase.UserAccessRights_OnConditionally((long)this.CompanyID, (long)this.UserID);
                    DataSet dataSet = JobBasePage.AllModuleDetails_Select(this.CompanyID, num1, empty9);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        this.sectionid = dataRow["CustomerID"].ToString();
                        this.companytype = dataRow["CompanyType"].ToString();
                        empty1 = dataRow["IsDirectJob"].ToString();
                        str5 = dataRow["IsForInvoice"].ToString();
                        empty2 = dataRow["EstimateNumber"].ToString();
                        empty3 = dataRow["EstimateDate"].ToString();
                        empty5 = dataRow["OrderNo"].ToString();
                        empty4 = dataRow["OrderDate"].ToString();
                        num = Convert.ToInt64(dataRow["OrderID"].ToString());
                        this.EstID = Convert.ToInt64(dataRow["EstimateID"]);
                    }
                    foreach (DataRow row1 in dataSet.Tables[2].Rows)
                    {
                        row1["InvoiceDate"].ToString();
                        row1["InvoiceNumber"].ToString();
                        if (this.InvoiceID != (long)0)
                        {
                            continue;
                        }
                        this.InvID = string.Concat("&InvID=", row1["InvoiceID"].ToString());
                    }
                    empty8 = (num == (long)0 ? "" : string.Concat("&ordid=", num));
                    if (empty1 != null && empty1 != "")
                    {
                        bool flag2 = false;
                        dataRowArray = dataTable1.Select("SectionName='Estimates'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow1 = dataRowArray[i];
                            flag2 = Convert.ToBoolean(dataRow1["IsDisplay"]);
                        }
                        if (!Convert.ToBoolean(empty1) && !Convert.ToBoolean(str5))
                        {
                            if (empty2 == "")
                            {
                                bool flag3 = false;
                                dataRowArray = dataTable1.Select("SectionName='WebstoreOrder'");
                                for (i = 0; i < (int)dataRowArray.Length; i++)
                                {
                                    DataRow dataRow2 = dataRowArray[i];
                                    flag3 = Convert.ToBoolean(dataRow2["IsDisplay"]);
                                }
                                if (!flag3)
                                {
                                    ControlCollection controls = this.plhjobLeftPanel.Controls;
                                    languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><label class='normalText' style='cursor: default'>", empty5, "</label><br/></div>" };
                                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                                }
                                else
                                {
                                    ControlCollection controlCollections = this.plhjobLeftPanel.Controls;
                                    str = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Order"), ":<br><a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", num, "&estid=", this.EstID, "' target='' onclick=''>", empty5, "</a><br/>Date: ", this.comm.Eprint_return_Date_Before_View(empty4, this.CompanyID, this.UserID, false), "</div>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(str)));
                                }
                            }
                            else if (flag2)
                            {
                                ControlCollection controls1 = this.plhjobLeftPanel.Controls;
                                str = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, "' target='' onclick=''>", empty2, "</a><br/>Date: ", this.comm.Eprint_return_Date_Before_View(empty3, this.CompanyID, this.UserID, false), " </div>" };
                                controls1.Add(new LiteralControl(string.Concat(str)));
                            }
                            else
                            {
                                ControlCollection controlCollections1 = this.plhjobLeftPanel.Controls;
                                languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><label class='normalText' style='cursor: default'>", empty2, "</label><br/></div>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                        else if (!flag2)
                        {
                            ControlCollection controls2 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><label class='normalText' style='cursor: default'>", empty2, "</label><br/></div>" };
                            controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else if (!(empty2 != "") || empty2.ToLower().Contains("direct"))
                        {
                            ControlCollection controlCollections2 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br>", this.objLangClass.GetLanguageConversion("Direct_Job"), "<br/></div>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            ControlCollection controls3 = this.plhjobLeftPanel.Controls;
                            str = new object[] { "<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Estimate"), ":<br><a href='", this.strSitepath, "estimates/estimate_summary.aspx?frm=view&estid=", this.EstID, "' target='' onclick=''>", empty2, "</a><br/></div>" };
                            controls3.Add(new LiteralControl(string.Concat(str)));
                        }
                    }
                    bool flag4 = false;
                    dataRowArray = dataTable1.Select("SectionName='Jobs'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow3 = dataRowArray[i];
                        flag4 = Convert.ToBoolean(dataRow3["IsDisplay"]);
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Job"), ":&nbsp;")));
                    foreach (DataRow row2 in dataSet.Tables[1].Rows)
                    {
                        empty6 = row2["JobCreatedDate"].ToString();
                        str6 = row2["JobNumber"].ToString();
                        if (this.jobID == (long)0)
                        {
                            this.jID = string.Concat("&jID=", row2["JobID"].ToString());
                        }
                        if (!(str6 != "") || !flag4)
                        {
                            continue;
                        }
                        if (empty5 == "")
                        {
                            ControlCollection controlCollections3 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div><a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", row2["EstimateID"].ToString(), "&jID=", row2["JobID"].ToString(), "' target='' onclick=''>", str6, "</a><br/> Date: ", this.comm.Eprint_return_Date_Before_View(empty6, this.CompanyID, this.UserID, false), "</div>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            ControlCollection controls4 = this.plhjobLeftPanel.Controls;
                            languageConversion = new string[] { "<div><a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", row2["EstimateID"].ToString(), "&estid=", row2["EstimateID"].ToString(), "&jID=", row2["JobID"].ToString(), "' target='' onclick=''>", str6, "</a><br/> Date: ", this.comm.Eprint_return_Date_Before_View(empty6, this.CompanyID, this.UserID, false), "</div>" };
                            controls4.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    if (!base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit&id=") && ConnectionClass.DeliveryNote != null)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        DataTable item = new DataTable();
                        item = dataSet.Tables[3];
                        bool flag5 = false;
                        dataRowArray = dataTable1.Select("SectionName='DeliveryNote'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow4 = dataRowArray[i];
                            flag5 = Convert.ToBoolean(dataRow4["IsDisplay"]);
                        }
                        if (item.Rows.Count <= 0)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br>")));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":<br>"));
                        }
                        int num2 = 1;
                        foreach (DataRow row3 in item.Rows)
                        {
                            if (item.Rows.Count <= 1)
                            {
                                str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row3["DeliveryID"].ToString(), "&estid=", this.EstID, empty8, this.jID };
                                string str9 = string.Concat(str);
                                if (row3["DeliveryNumber"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":")));
                                }
                                else if (!flag5)
                                {
                                    stringBuilder.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row3["DeliveryNumber"], "</label>"));
                                }
                                else
                                {
                                    str = new object[] { "<a href='", str9, "' target=''> ", row3["DeliveryNumber"], "</a><br>Date:", this.comm.Eprint_return_Date_Before_View(Convert.ToString(row3["DeliveryDate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder.Append(string.Concat(str));
                                }
                            }
                            else
                            {
                                string str10 = "";
                                if (num2 != 1)
                                {
                                    str10 = "<br/>";
                                }
                                str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row3["DeliveryID"].ToString(), "&estid=", this.EstID, empty8 };
                                string str11 = string.Concat(str);
                                if (row3["DeliveryNumber"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Delivery_Note"), ":")));
                                }
                                else if (!flag5)
                                {
                                    str = new object[] { str10, "<label class='normalText' style='cursor: default'> ", row3["DeliveryNumber"], "</label>" };
                                    stringBuilder.Append(string.Concat(str));
                                    num2++;
                                }
                                else
                                {
                                    str = new object[] { str10, "<a href='", str11, "' target=''> ", row3["DeliveryNumber"], "</a><br>Date:", this.comm.Eprint_return_Date_Before_View(Convert.ToString(row3["DeliveryDate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder.Append(string.Concat(str));
                                    num2++;
                                }
                            }
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    if (!base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&id=") && !base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit&pg=job&estid="))
                    {
                        StringBuilder stringBuilder1 = new StringBuilder();
                        DataTable item1 = new DataTable();
                        item1 = dataSet.Tables[3];
                        bool flag6 = false;
                        dataRowArray = dataTable1.Select("SectionName='Purchases'");
                        for (i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow5 = dataRowArray[i];
                            flag6 = Convert.ToBoolean(dataRow5["IsDisplay"]);
                        }
                        if (item1.Rows.Count <= 0)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":  ")));
                        }
                        else
                        {
                            stringBuilder1.Append(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ":<br>"));
                        }
                        int num3 = 1;
                        int num4 = 1;
                        foreach (DataRow row4 in item1.Rows)
                        {
                            if (item1.Rows.Count <= 1)
                            {
                                str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstID, "&id=", row4["PurchaseID"].ToString(), empty8 };
                                string str12 = string.Concat(str);
                                if (row4["PONO"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": ")));
                                }
                                else if (!flag6)
                                {
                                    stringBuilder1.Append(string.Concat("<label class='normalText' style='cursor: default'> ", row4["PONO"], "</label>"));
                                }
                                else
                                {
                                    str = new object[] { "<a href='", str12, "' target=''> ", row4["PONO"], "</a><br>Date:", this.comm.Eprint_return_Date_Before_View(Convert.ToString(row4["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder1.Append(string.Concat(str));
                                }
                            }
                            else
                            {
                                string str13 = "";
                                if (num3 != 1)
                                {
                                    str13 = "<br/>";
                                }
                                str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstID, "&id=", row4["PurchaseID"].ToString(), empty8 };
                                string str14 = string.Concat(str);
                                if (row4["PONO"] == null)
                                {
                                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Purchase_Order"), ": ")));
                                }
                                else if (!flag6)
                                {
                                    str = new object[] { str13, "<label class='normalText' style='cursor: default'> ", row4["PONO"], "</label>" };
                                    stringBuilder1.Append(string.Concat(str));
                                    num3++;
                                }
                                else
                                {
                                    str = new object[] { str13, "<a href='", str14, "' target=''> ", row4["PONO"], "</a><br>Date:", this.comm.Eprint_return_Date_Before_View(Convert.ToString(row4["PODate"].ToString()), this.CompanyID, this.UserID, false) };
                                    stringBuilder1.Append(string.Concat(str));
                                    num3++;
                                }
                            }
                            num4++;
                        }
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    }
                    LinkButton linkButton = new LinkButton();
                    string empty10 = string.Empty;
                    bool flag7 = false;
                    dataRowArray = dataTable1.Select("SectionName='Invoices'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow6 = dataRowArray[i];
                        flag7 = Convert.ToBoolean(dataRow6["IsDisplay"]);
                    }
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = dataSet.Tables[2];
                    string empty11 = string.Empty;
                    if (empty5 == "")
                    {
                        str = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstID, this.InvID };
                        empty11 = string.Concat(str);
                    }
                    else
                    {
                        str = new object[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstID, "&ordid=", num, this.InvID };
                        empty11 = string.Concat(str);
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ":<br>")));
                    foreach (DataRow row5 in dataTable2.Rows)
                    {
                        if (row5["InvoiceNumber"] == null)
                        {
                            this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div class='activity-list'>", this.objLangClass.GetLanguageConversion("Invoice"), ": <br/></div>")));
                        }
                        else if (!flag7)
                        {
                            empty10 = string.Concat("<label class='normalText' style='cursor: default'> ", row5["InvoiceNumber"], "</label><br/>");
                        }
                        else
                        {
                            str = new object[] { "<a href='", empty11, "' target=''> ", row5["InvoiceNumber"], "</a><br>Date:", this.comm.Eprint_return_Date_Before_View(Convert.ToString(row5["InvoiceDate"].ToString()), this.CompanyID, this.UserID, false) };
                            empty10 = string.Concat(str);
                        }
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(empty10.ToString()));
                    dataRowArray = dataTable1.Select("SectionName='Invoices'");
                    for (i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow7 = dataRowArray[i];
                        flag7 = Convert.ToBoolean(dataRow7["IsDisplay"]);
                    }
                    if (flag7)
                    {
                        this.plhjobLeftPanel.Controls.Add(linkButton);
                    }
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));

                    //if (commonClass.CheckProofPermission())
                    //{
                    //    //if (this.Module.ToLower() == "estimate" || this.Module.ToLower() == "job")
                    //    //{
                    //    Int64 _estimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    //    long _estimateItemID = 0;
                    //    DataTable _dt = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, _estimateID);
                    //    foreach (DataRow dr in _dt.Rows)
                    //    {
                    //        _estimateItemID = (long)dr["EstimateItemID"];
                    //    }
                    //    DataTable dt = EstimateBasePage.Get_Proofed_WebLink(_estimateItemID);
                    //    int attachment_count = EstimateBasePage.Get_AttachmentCount(_estimateItemID);
                    //    ControlCollection controls25 = this.plhjobLeftPanel.Controls;
                    //    string[] languageConversion1;
                    //    if (attachment_count > 0)
                    //    {
                    //        if (dt.Rows.Count < attachment_count)
                    //        {
                    //            foreach (DataRow dr in dt.Rows)
                    //            {
                    //                languageConversion1 = new string[] { "<div class='activity-list'> Proofs:<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                    //                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                    //            }
                    //        }
                    //        else
                    //        {
                    //            this.plhjobLeftPanel.Controls.Add(new LiteralControl("<div class='activity-list'> Proofs:"));
                    //            foreach (DataRow dr in dt.Rows)
                    //            {

                    //                languageConversion1 = new string[] { "<br><a href='" + this.strSitepath + "/Proofs/Proof_summary.aspx?estid=" + dr["EstimateID"].ToString() + "&EstItemID=" + dr["EstimateItemId"].ToString() + "&ProofID=" + dr["ProofId"].ToString() + "' >", dr["WebLink"].ToString(), "</a><br>", "Date: ", dr["ProofDate"].ToString() };
                    //                controls25.Add(new LiteralControl(string.Concat(languageConversion1)));
                    //            }
                    //            this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    //        }
                    //    }


                    //    StringBuilder stringBuilder20 = new StringBuilder();
                    //    this.plhjobLeftPanel.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                    //    if (dt.Rows.Count < attachment_count)
                    //    {
                    //        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    //    }
                    //    else if (attachment_count == 0)
                    //    {
                    //        this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                    //    }

                    //    //}

                    //}

                    this.plhjobLeftPanel.Controls.Add(new LiteralControl(string.Concat("<div id='activities-all' style='padding-left:5px; background-color: #ECECEC;'><a href='#' onclick='javascript:ShowNotes();'>", this.objLangClass.GetLanguageConversion("View_History"), "</a></div></div></div>")));
                    this.plhjobLeftPanel.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("<div align='left' id='divCustContent'  style='display: block; overflow: visible; height: 150px>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<div style='float: left;>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<ul id='verticalmenu' class='glossymenu1'>"));
                if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_view.aspx"))
                {
                    this.PageType = "estimate";
                    this.pnlCustomize.Visible = true;
                    string str15 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                    if (str15.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../estimates/estimates_add.aspx?type=add", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton1 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton1);
                    LinkButton linkButton2 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton2);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str15.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New View", "../estimates/customview.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Reports", "../estimates/estimate_report.aspx", this.plhLeftPanel);
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
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), "../estimates/estimate_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_search.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    string str16 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString());
                    string str17 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString());
                    string str18 = this.objBase.ReturnRoles_Privileges_ReportStatus("estimate", "showreport");
                    if (str16.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../estimates/estimates_add.aspx?type=add", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (str17.Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Estimates", "../estimates/estimate_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                    }
                    if (str18.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../estimates/estimate_report.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimates_add.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_pad_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_large_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_warehouse.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_printbroker.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_pricecatalog.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_item_description.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_othercost.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_large_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_addanitem.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_ncr_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_quickquote.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_DeliveryCost.aspx?") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_litho_pad_item.aspx?"))
                {
                    this.pnlCustomize.Visible = true;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), "../estimates/estimate_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi("View Estimates", "../estimates/estimate_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi("View Estimates", "../estimates/estimate_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi("View Estimates", "../estimates/estimate_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Estimates", this.plhLeftPanel);
                    }
                    this.LoadLi("Estimate Print Email", "#", "", this.plhLeftPanel);
                }
                else if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary_reeng.aspx"))
                {
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    int count = 0;
                    string empty14 = string.Empty;
                    empty14 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
                    StringBuilder stringBuilder2 = new StringBuilder();
                    long num5 = Convert.ToInt64(base.Request.Params["estid"]);
                    if (flag)
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Style.Add("display", "none");
                    }
                    bool flag8 = false;
                    foreach (DataRow row6 in EstimatesBasePage.EstimatItem_Details_Select(this.CompanyID, num5, this.PageType).Rows)
                    {
                        if (row6["EstimateType"].ToString() == "O")
                        {
                            flag8 = true;
                        }
                        empty13 = row6["EstimateItemID"].ToString();
                    }
                    this.plhLeftPanel.Visible = false;
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    this.Div_EstSummary.Visible = true;
                    this.RadPanelBar_LeftPanel.Items[2].Style.Add("display", "block");
                    this.RadPanelBar_LeftPanel.Items[3].Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','estimate');"));
                    this.RadPanelBar_LeftPanel.Items[4].Items[0].Attributes.Add("onclick", "javascript:EstimateCopyto_SameCust('estimate');");
                    this.RadPanelBar_LeftPanel.Items[4].Items[1].Attributes.Add("onclick", "javascript:EstimateCopyto_NewCust('estimate');");
                    DataTable dataTable3 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num5);
                    foreach (DataRow row7 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, num5).Rows)
                    {
                        this.sectionid = row7["CustomerID"].ToString();
                        this.companytype = row7["CompanyType"].ToString();
                    }
                    if (!flag8)
                    {
                        base.Session["TemplateHTML"] = null;
                        base.Session["TemplateControlList"] = null;
                        base.Session["TemplateID"] = null;
                        base.Session["NewTempKey"] = null;
                        this.RadPanelBar_LeftPanel.Items[0].Style.Add("cursor", "default");
                        RadMenu radMenu2 = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                        if (empty14 == "0" || empty14 == "2")
                        {
                            radMenu2.Visible = false;
                        }
                        if (dataTable3.Rows.Count <= 1)
                        {
                            radMenu2.Items[0].Items[0].Visible = false;
                            radMenu2.Items[0].Items[1].Visible = false;
                            radMenu2.Items[0].Items[2].Visible = false;
                            AttributeCollection attributes = radMenu2.Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "'" };
                            attributes.Add("onclick", string.Concat(str));
                        }
                        else
                        {
                            radMenu2.Items[0].Items[0].Text = "All Items";
                            radMenu2.Items[0].Items[1].Text = "Selected Items";
                            radMenu2.Items[0].Items[2].Visible = false;
                            AttributeCollection attributeCollection = radMenu2.Items[0].Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&GenPdf=all'" };
                            attributeCollection.Add("onclick", string.Concat(str));
                            radMenu2.Items[0].Items[1].Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                            AttributeCollection attributes1 = radMenu2.Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "'" };
                            attributes1.Add("onclick", string.Concat(str));
                            HiddenField hdnPrintEmail = this.hdn_PrintEmail;
                            str = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID };
                            hdnPrintEmail.Value = string.Concat(str);
                        }
                    }
                    else
                    {
                        this.RadPanelBar_LeftPanel.Items[0].Style.Add("cursor", "default");
                        if (dataTable3.Rows.Count <= 1)
                        {
                            RadMenu radMenu3 = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                            if (empty14 == "0" || empty14 == "2")
                            {
                                radMenu3.Visible = false;
                            }
                            radMenu3.Items[0].Items[0].Visible = true;
                            radMenu3.Items[0].Items[1].Visible = true;
                            radMenu3.Items[0].Items[2].Visible = false;
                            AttributeCollection attributeCollection1 = radMenu3.Items[0].Items[0].Attributes;
                            str = new object[] { "window.location.href='../estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=", this.companytype, "&page=Estimate&EstID=", this.EstID, "'" };
                            attributeCollection1.Add("onclick", string.Concat(str));
                            AttributeCollection attributes2 = radMenu3.Items[0].Items[1].Attributes;
                            str = new object[] { "window.location.href='../estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty13, "'" };
                            attributes2.Add("onclick", string.Concat(str));
                        }
                        else
                        {
                            RadMenu languageConversion2 = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                            if (empty14 == "0" || empty14 == "2")
                            {
                                languageConversion2.Visible = false;
                            }
                            languageConversion2.Items[0].Items[0].Text = this.objLangClass.GetLanguageConversion("All_Items");
                            languageConversion2.Items[0].Items[1].Text = "Selected Items";
                            languageConversion2.Items[0].Items[2].Text = "Outwork Supplier";
                            AttributeCollection attributeCollection2 = languageConversion2.Items[0].Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "&GenPdf=all'" };
                            attributeCollection2.Add("onclick", string.Concat(str));
                            languageConversion2.Items[0].Items[1].Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                            AttributeCollection attributes3 = languageConversion2.Items[0].Items[2].Attributes;
                            str = new object[] { "window.location.href='../estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=PrintBroker&type=", this.companytype, "&page=PrintBroker&EstID=", this.EstID, "&EstItemID=", empty13, "'" };
                            attributes3.Add("onclick", string.Concat(str));
                            AttributeCollection attributeCollection3 = languageConversion2.Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID, "'" };
                            attributeCollection3.Add("onclick", string.Concat(str));
                            HiddenField hiddenField = this.hdn_PrintEmail;
                            str = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Estimate&type=Customer&page=Estimate&EstID=", this.EstID };
                            hiddenField.Value = string.Concat(str);
                        }
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                    if (base.Request.Params["estid"] != null)
                    {
                        num5 = Convert.ToInt64(base.Request.Params["estid"]);
                        DateTime dateTime = DateTime.Now;
                        DataTable dataTable4 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num5);
                        StringBuilder stringBuilder3 = new StringBuilder();
                        count = dataTable4.Rows.Count;
                        if (dataTable4.Rows.Count > 1)
                        {
                            stringBuilder3.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none;'>Delete</a>");
                            stringBuilder3.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                        }
                        int num6 = 1;
                        int num7 = 1;
                        foreach (DataRow row8 in dataTable4.Rows)
                        {
                            if (dataTable4.Rows.Count > 1)
                            {
                                string str19 = string.Concat("onclick=javascript:DeleteItem('", row8["EstimateItemID"].ToString(), "')");
                                str = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str19, " >Item", num6, "</a></li>" };
                                stringBuilder3.Append(string.Concat(str));
                                num6++;
                            }
                            num7++;
                            empty12 = row8["EstimateType"].ToString();
                            empty13 = row8["EstimateItemID"].ToString();
                        }
                        if (dataTable4.Rows.Count > 1)
                        {
                            stringBuilder3.Append("</ul>");
                            stringBuilder3.Append("</li>");
                        }
                        this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
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
                    LinkButton linkButton3 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;To Same Customer",
                        OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton3);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton4 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;To New Customer",
                        OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton4);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                }
                else if (base.Request.Url.ToString().ToLower().Contains("estimates/templates_view1.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Estimates"), "../estimates/estimate_view.aspx", this.plhLeftPanel);
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
                    string str20 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
                    if (str20.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../jobs/job_add.aspx?type=add", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton5 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton5);
                    }
                    LinkButton linkButton6 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton6);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton7 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Copy To New Job",
                        OnClientClick = "javascript:return CheckchkOnlyOne();"
                    };
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str20.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New View", "../jobs/customviewjob.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Reports", "../jobs/job_report.aspx", this.plhLeftPanel);
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
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Jobs"), "../Jobs/jobs_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/job_summary_reeng.aspx"))
                {
                    string empty15 = string.Empty;
                    empty15 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "printoremail", this.Page.Request.Url.ToString());
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    string empty16 = string.Empty;
                    string empty17 = string.Empty;
                    string empty18 = string.Empty;
                    int count1 = 0;
                    if (flag1)
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Style.Add("display", "none");
                    }
                    EstimateBasePage.estimate_hasdeliverynote_select(this.CompanyID, this.EstID);
                    EstimateBasePage.estimate_deliverynoteid_select(this.CompanyID, this.EstID);
                    DataTable dataTable5 = JobBasePage.Jobs_Jobcard_Jobdetails_select(this.CompanyID, this.EstID);
                    string empty19 = string.Empty;
                    foreach (DataRow dataRow8 in dataTable5.Rows)
                    {
                        this.sectionid = dataRow8["CustomerID"].ToString();
                        this.companytype = dataRow8["CompanyType"].ToString();
                        empty18 = dataRow8["IsDirectJob"].ToString();
                        this.jobconvertedtoinvoice = dataRow8["isconverted"].ToString();
                    }
                    StringBuilder stringBuilder4 = new StringBuilder();
                    DataTable dataTable6 = EstimateBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, this.EstID);
                    count1 = dataTable6.Rows.Count;
                    foreach (DataRow row9 in dataTable6.Rows)
                    {
                        empty16 = row9["EstimateType"].ToString();
                        empty17 = row9["EstimateItemID"].ToString();
                        if (printcenter_leftpanel.ManageStockPermission != 1 || !(empty16.ToLower() == "c"))
                        {
                            continue;
                        }
                        empty19 = string.Concat(empty19, this.objBase.Check_Rerun_Delete_Revert_On_Reduction(Convert.ToInt64(row9["pricecatalogueID"]), (long)this.CompanyID, Convert.ToInt64(empty17), this.EstID, row9["DrawStockFrom"].ToString()), "_");
                    }
                    this.Div_EstSummary.Visible = true;
                    this.Div_EstSummary.Style.Add("margin-top", "-12px");
                    this.RadPanelBar_LeftPanel.Items[4].Text = this.objLangClass.GetLanguageConversion("Copy_Job");
                    this.RadPanelBar_LeftPanel.Items[3].Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','job');"));
                    this.RadPanelBar_LeftPanel.Items[4].Items[0].Attributes.Add("onclick", "javascript:EstimateCopyto_SameCust('job');");
                    this.RadPanelBar_LeftPanel.Items[4].Items[1].Attributes.Add("onclick", "javascript:EstimateCopyto_NewCust('job');");
                    this.RadPanelBar_LeftPanel.Items[5].Style.Add("display", "block");
                    this.RadPanelBar_LeftPanel.Items[5].Attributes.Add("onclick", "javascript:RevertJob_reeng();");
                    if (empty18.ToLower() == "true")
                    {
                        this.RadPanelBar_LeftPanel.Items[5].Style.Add("display", "none");
                    }
                    if (this.jobconvertedtoinvoice.ToLower() == "true")
                    {
                        this.RadPanelBar_LeftPanel.Items[5].Style.Add("display", "none");
                    }
                    if (empty19.ToLower().Contains("false"))
                    {
                        this.RadPanelBar_LeftPanel.Items[5].Style.Add("display", "none");
                    }
                    if (empty16 != null)
                    {
                        base.Session["TemplateHTML"] = null;
                        base.Session["TemplateControlList"] = null;
                        base.Session["TemplateID"] = null;
                        RadMenu radMenu4 = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                        if (empty15 == "0" || empty15 == "2")
                        {
                            radMenu4.Visible = false;
                        }
                        if (count1 <= 1)
                        {
                            radMenu4.Items[0].Items[0].Visible = false;
                            radMenu4.Items[0].Items[1].Visible = false;
                            radMenu4.Items[0].Items[2].Visible = false;
                            AttributeCollection attributes4 = radMenu4.Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job", this.jID, "&EstID=", this.EstID, "'" };
                            attributes4.Add("onclick", string.Concat(str));
                        }
                        else
                        {
                            radMenu4.Items[0].Items[0].Text = "All Items";
                            radMenu4.Items[0].Items[1].Text = "Selected Items";
                            radMenu4.Items[0].Items[2].Visible = false;
                            AttributeCollection attributeCollection4 = radMenu4.Items[0].Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job&EstID=", this.EstID, this.jID, "&GenPdf=all'" };
                            attributeCollection4.Add("onclick", string.Concat(str));
                            radMenu4.Items[0].Items[1].Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                            HiddenField hdnPrintEmail1 = this.hdn_PrintEmail;
                            str = new object[] { this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Job&type=Customer&page=Job", this.jID, "&EstID=", this.EstID };
                            hdnPrintEmail1.Value = string.Concat(str);
                        }
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                    if (base.Request.Params["estid"] != null)
                    {
                        long num8 = Convert.ToInt64(base.Request.Params["estid"]);
                        DateTime now1 = DateTime.Now;
                        EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num8);
                        StringBuilder stringBuilder5 = new StringBuilder();
                        this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                        this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                        this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                        LinkButton linkButton8 = new LinkButton()
                        {
                            Text = "&nbsp;&nbsp;To Same Customer",
                            Visible = false,
                            OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                        };
                        this.plhLeftPanel.Controls.Add(linkButton8);
                        this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                        this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                        LinkButton linkButton9 = new LinkButton()
                        {
                            Text = "&nbsp;&nbsp;To New Customer",
                            Visible = false,
                            OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                        };
                        this.plhLeftPanel.Controls.Add(linkButton9);
                        this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                        this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                        this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/templates_view1.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Jobs", "jobs_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx") || base.Request.Url.ToString().ToLower().Contains("jobs/jobs_add.aspx") || base.Request.Url.ToString().ToLower().Contains("job_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_large_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("job_othercost.aspx") || base.Request.Url.ToString().ToLower().Contains("job_pricecatalog.aspx") || base.Request.Url.ToString().ToLower().Contains("job_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains("job_warehouse.aspx") || base.Request.Url.ToString().ToLower().Contains("job_addanitem.aspx") || base.Request.Url.ToString().ToLower().Contains("job_item_description.aspx") || base.Request.Url.ToString().ToLower().Contains("job_ncr_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_booklet_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_single_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_litho_pad_item.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_quickquote.aspx?") || base.Request.Url.ToString().ToLower().Contains("job_DeliveryCost.aspx?"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
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
                        this.LoadLi("View Jobs", "../jobs/jobs_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Jobs", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("job", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../jobs/job_report.aspx", this.plhLeftPanel);
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
                        this.LoadLi("View Invoice", "../invoice/invoice_view.aspx", this.plhLeftPanel);
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
                    string str21 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                    if (str21.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../invoice/invoices_add.aspx?type=add", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton10 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton10);
                    }
                    LinkButton linkButton11 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton11);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton12 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Copy To New Invoice",
                        OnClientClick = "javascript:return CheckchkOnlyOne();"
                    };
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str21.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New View", "../invoice/customviewinvoice.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Reports", "../invoice/invoice_report.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_item_form.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice_summary_reeng.aspx"))
                {
                    string empty20 = string.Empty;
                    string empty21 = string.Empty;
                    empty20 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "printoremail", this.Page.Request.Url.ToString());
                    empty21 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
                    string empty22 = string.Empty;
                    string str22 = string.Empty;
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    StringBuilder stringBuilder6 = new StringBuilder();
                    EstimateBasePage.estimate_hasdeliverynote_select(this.CompanyID, this.EstID);
                    foreach (DataRow dataRow9 in InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstID).Rows)
                    {
                        this.sectionid = dataRow9["CustomerID"].ToString();
                        this.companytype = dataRow9["CompanyType"].ToString();
                    }
                    DataTable dataTable7 = EstimateBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, this.EstID);
                    foreach (DataRow row10 in dataTable7.Rows)
                    {
                        empty22 = row10["EstimateType"].ToString();
                        row10["EstimateItemID"].ToString();
                    }
                    this.Div_EstSummary.Visible = true;
                    this.Div_EstSummary.Style.Add("margin-top", "-12px");
                    this.RadPanelBar_LeftPanel.Items[4].Text = this.objLangClass.GetLanguageConversion("Copy_Invoice");
                    this.RadPanelBar_LeftPanel.Items[3].Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstID, "','invoice');"));
                    this.RadPanelBar_LeftPanel.Items[4].Items[0].Attributes.Add("onclick", "javascript:EstimateCopyto_SameCust('invoice');");
                    this.RadPanelBar_LeftPanel.Items[4].Items[1].Attributes.Add("onclick", "javascript:EstimateCopyto_NewCust('invoice');");
                    if (empty22 != null)
                    {
                        base.Session["TemplateHTML"] = null;
                        base.Session["TemplateControlList"] = null;
                        base.Session["TemplateID"] = null;
                        RadMenu radMenu5 = (RadMenu)this.RadPanelBar_LeftPanel.Items[0].FindControl("RadMenu_LeftPanel1");
                        if (empty20 == "0" || empty20 == "2")
                        {
                            radMenu5.Visible = false;
                        }
                        if (dataTable7.Rows.Count <= 1)
                        {
                            radMenu5.Items[0].Items[0].Visible = false;
                            radMenu5.Items[0].Items[1].Visible = false;
                            radMenu5.Items[0].Items[2].Visible = false;
                            AttributeCollection attributes5 = radMenu5.Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice", this.InvID, "&EstID=", this.EstID, "'" };
                            attributes5.Add("onclick", string.Concat(str));
                        }
                        else
                        {
                            radMenu5.Items[0].Items[0].Text = "All Items";
                            radMenu5.Items[0].Items[1].Text = "Selected Items";
                            radMenu5.Items[0].Items[2].Visible = false;
                            AttributeCollection attributeCollection5 = radMenu5.Items[0].Items[0].Attributes;
                            str = new object[] { "window.location.href='", this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice&EstID=", this.EstID, this.InvID, "&GenPdf=all'" };
                            attributeCollection5.Add("onclick", string.Concat(str));
                            radMenu5.Items[0].Items[1].Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                            HiddenField hiddenField1 = this.hdn_PrintEmail;
                            str = new object[] { this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=Customer&page=Invoice", this.InvID, "&EstID=", this.EstID };
                            hiddenField1.Value = string.Concat(str);
                        }
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                    if (base.Request.Params["estid"] != null)
                    {
                        string empty23 = string.Empty;
                        foreach (DataRow dataRow10 in InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstID).Rows)
                        {
                            if (dataRow10["Status"].ToString().ToLower() != "locked")
                            {
                                continue;
                            }
                            empty23 = "yes";
                        }
                        if (empty23 == "")
                        {
                            long num9 = Convert.ToInt64(base.Request.Params["estid"]);
                            DateTime dateTime1 = DateTime.Now;
                            DataTable dataTable8 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num9);
                            StringBuilder stringBuilder7 = new StringBuilder();
                            int count2 = dataTable8.Rows.Count;
                            this.plhLeftPanel.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                        }
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton13 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;To Same Customer",
                        Visible = false,
                        OnClientClick = "javascript:return EstimateCopyto_SameCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton13);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton14 = new LinkButton()
                    {
                        Visible = false,
                        Text = "&nbsp;&nbsp;To New Customer",
                        OnClientClick = "javascript:return EstimateCopyto_NewCust();"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton14);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (empty21.Trim().ToLower() == "false")
                    {
                        this.RadPanelBar_LeftPanel.Items[1].Visible = false;
                        this.RadPanelBar_LeftPanel.Items[4].Visible = false;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/templates_view1.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), "../invoice/invoice_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx?type=add") || base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_large_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_othercost.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_pricecatalog.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_printbroker.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_warehouse.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_addanitem.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_item_description.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_ncr_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_booklet_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_single_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_litho_pad_item.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_quickquote.aspx") || base.Request.Url.ToString().ToLower().Contains("invoice_DeliveryCost.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), "../invoice/invoice_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), "../invoice/invoice_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Add New", "../invoice/invoices_add.aspx?type=add", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Estimates", "../invoice/invoice_view.aspx", this.plhLeftPanel);
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
                        this.LoadLi(this.objLangClass.GetLanguageConversion("View_Invoices"), "../invoice/invoice_view.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight(this.objLangClass.GetLanguageConversion("View_Invoices"), this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("invoices", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../invoice/invoice_report.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Add New", "../warehouse/item_finishedgoods_add.aspx?page=store", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Store Supply", "../warehouse/warehouse.aspx?type=store", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Store Supply", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../warehouse/finishedgoods_report.aspx?type=store", this.plhLeftPanel);
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
                        this.LoadLi("Add New", "../warehouse/item_finishedgoods_add.aspx?page=item", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Customer Item", "../warehouse/warehouse.aspx?type=item", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../warehouse/finishedgoods_report.aspx?type=item", this.plhLeftPanel);
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
                        this.LoadLi("Add New", "../warehouse/inventory_add.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ReportStatus("inventory", "showreport").Trim().ToLower() != "false")
                    {
                        this.LoadLi("Reports", "../warehouse/inventory_report.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse.aspx?type=inventory") || base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_settings.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    string str23 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                    if (str23.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../warehouse/inventory_add.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("Categories", "../warehouse/inventory_settings.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Categories", this.plhLeftPanel);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Tools</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul2' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton15 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Export",
                        PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventoryexport.aspx")
                    };
                    string str24 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "exportorimport", this.Page.Request.Url.ToString());
                    if (str24 != "0" && str24 != "2")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton15);
                    }
                    LinkButton linkButton16 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Import",
                        PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventory_import.aspx")
                    };
                    if (str24 != "0" && str24 != "2")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton16);
                    }
                    LinkButton linkButton17 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Mass Adjustment",
                        PostBackUrl = string.Concat(this.strSitepath, "warehouse/inventory_adjustment.aspx")
                    };
                    this.plhLeftPanel.Controls.Add(linkButton17);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton18 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton18);
                    }
                    LinkButton linkButton19 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive Selected",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton19);
                    LinkButton linkButton20 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Un-Archive selected",
                        OnClientClick = "javascript:return CheckchkOne('unarchive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton20);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Views</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    if (str23.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New View", "../warehouse/customviewinv.aspx", this.plhLeftPanel);
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
                        this.LoadLi("Reports", "../warehouse/inventory_report.aspx", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Reports", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("warehouse/warehouse.aspx?type=store"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
                    string str25 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                    if (str25.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New", "../warehouse/item_finishedgoods_add.aspx?page=store", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Add New", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.LoadLi("View Inventory", "../warehouse/warehouse.aspx?type=inventory", this.plhLeftPanel);
                        this.LoadLi("View Customer Item", "../warehouse/warehouse.aspx?type=item", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi_AccessRight("View Inventory", this.plhLeftPanel);
                        this.LoadLi_AccessRight("View Customer Item", this.plhLeftPanel);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li id='li1'><a href='#' style='padding-left:18px;text-decoration:none;'>Action</a>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton21 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton21);
                    }
                    LinkButton linkButton22 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive selected",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton22);
                    LinkButton linkButton23 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Un-Archive selected",
                        OnClientClick = "javascript:return CheckchkOne('unarchive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton23);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str25.Trim().ToLower() != "false")
                    {
                        this.LoadLi("Add New View", "../warehouse/customviewstore.aspx", this.plhLeftPanel);
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
                    this.pnlCustomize2.Visible = false;
                    string str26 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
                    if (str26.Trim().ToLower() != "false")
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
                    LinkButton linkButton24 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton24);
                    }
                    LinkButton linkButton25 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive Selected",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton25);
                    LinkButton linkButton26 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Un-Archive selected",
                        OnClientClick = "javascript:return CheckchkOne('unarchive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton26);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str26.Trim().ToLower() != "false")
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
                    this.pnlCustomize2.Visible = false;
                    this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isview", this.Page.Request.Url.ToString());
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton27 = new LinkButton()
                    {
                        Text = string.Concat("&nbsp;&nbsp;&nbsp;", this.objLangClass.GetLanguageConversion("Copy_Inventory")),
                        OnClientClick = "javascript:return Copy_Inventory();"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton27);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                }
                else if (base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_add.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
                    string str27 = this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isadd", this.Page.Request.Url.ToString());
                    if (str27.Trim().ToLower() != "false")
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
                    LinkButton linkButton28 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton28);
                    }
                    LinkButton linkButton29 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton29);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("<li>"));
                    LinkButton linkButton30 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Copy To New PO",
                        OnClientClick = "javascript:return CheckchkOnlyOne();"
                    };
                    if (str27.Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton30);
                    }
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str27.Trim().ToLower() != "false")
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
                    string str28 = this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "printoremail", this.Page.Request.Url.ToString());
                    //DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
                    //DataTable item = appSettingsAndConnectionString.Tables[0];
                    if (str28 == "0" || str28 == "2")
                    {
                        this.LoadLi_AccessRight("Print/Email", this.plhLeftPanel);
                    }
                    else
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                    }
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        //--------Ticket72049-------------kr
                        DataTable dt = InventoryBasePage.uppernavigator_select(this.CompanyID, "Warehouse", Convert.ToInt32(base.Session["UserID"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse"), "#", "Javascript:javascript:PopUpWarehouse();", this.plhLeftPanel);
                        }
                        //--------Ticket72049-------------kr
                        if (printcenter_leftpanel.ManageStockPermission == 1)
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Products"), "javascript:void(0);", "Javascript:javascript:PopUpProductList();", this.plhLeftPanel);
                        }
                    }
                    else
                    {
                        this.LoadLi_AccessRight("Warehouse", this.plhLeftPanel);
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("purchase/purchase_add.aspx?type=edit"))
                {
                    long num10 = Convert.ToInt64(base.Request.Params["id"].ToString());
                    foreach (DataRow row11 in PurchaseBasePage.purchase_select(this.CompanyID, num10).Rows)
                    {
                        this.sectionid = row11["SupplierID"].ToString();
                        this.companytype = row11["CompanyType"].ToString();
                    }
                    this.pnlCustomize.Visible = true;
                    BaseClass baseClass = new BaseClass();
                    string empty24 = string.Empty;
                    empty24 = baseClass.ReturnRoles_Privileges_ForGrid("purchases", "printoremail", this.Page.Request.Url.ToString());
                    if (empty24 != "0" && empty24 != "2")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                    }
                    string empty25 = string.Empty;
                    if (baseClass.ReturnRoles_Privileges_ForGrid("purchases", "isview", this.Page.Request.Url.ToString()) != "False")
                    {
                        this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                        //--------Ticket72049-------------kr
                        DataTable dt = InventoryBasePage.uppernavigator_select(this.CompanyID, "Warehouse", Convert.ToInt32(base.Session["UserID"].ToString()));
                        if (dt.Rows.Count > 0)
                        {

                            this.LoadLi(this.objLangClass.GetLanguageConversion("Warehouse"), "#", "Javascript:javascript:PopUpWarehouse();", this.plhLeftPanel);
                        }
                        //--------Ticket72049-------------kr
                        if (printcenter_leftpanel.ManageStockPermission == 1)
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Products"), "javascript:void(0);", "Javascript:javascript:PopUpProductList();", this.plhLeftPanel);
                        }
                    }
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                }
                else if (base.Request.Url.ToString().ToLower().Contains("purchase/templates_view1.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    this.pnlCustomize2.Visible = false;
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
                    string str29 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString());
                    if (str29.Trim().ToLower() != "false")
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
                    LinkButton linkButton31 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton31);
                    }
                    LinkButton linkButton32 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton32);
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                    this.plhLeftPanel.Controls.Add(new LiteralControl("</li>"));
                    if (str29.Trim().ToLower() != "false")
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
                        string str30 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "printoremail", this.Page.Request.Url.ToString());
                        if (str30 == "0" || str30 == "2")
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
                        long num11 = (long)Convert.ToInt32(base.Request.Params["id"].ToString());
                        foreach (DataRow dataRow11 in DeliveryBasePage.delivery_select(this.CompanyID, num11).Rows)
                        {
                            this.sectionid = dataRow11["CustomerID"].ToString();
                            this.companytype = dataRow11["CompanyType"].ToString();
                        }
                        base.Session["TemplateHTML"] = null;
                        base.Session["TemplateControlList"] = null;
                        base.Session["TemplateID"] = null;
                        string str31 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "printoremail", this.Page.Request.Url.ToString());
                        if (!(str31 == "0") && !(str31 == "2"))
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Print_Email"), "#", "javascript:printemail();", this.plhLeftPanel);
                        }
                    }
                    this.pnlCustomize.Visible = true;
                    string str32 = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isview", this.Page.Request.Url.ToString());
                    if (base.Request.Url.ToString().ToLower().Contains("delivery/delivery_add.aspx?type=edit"))
                    {
                        if (str32.Trim().ToLower() != "false")
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Copy_Delivery"), "#", "javascript:Copy_Delivery();", this.plhLeftPanel);

                        }
                        else
                        {
                            this.LoadLi_AccessRight("Attachments", this.plhLeftPanel);
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Copy_Delivery"), "#", "javascript:Copy_Delivery();", this.plhLeftPanel);
                        }
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("delivery/templates_view1.aspx"))
                {
                    this.pnlCustomize.Visible = true;
                    this.pnlCustomize2.Visible = false;
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
                    LinkButton linkButton33 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Delete",
                        OnClientClick = "javascript:return CheckchkOne('delete');"
                    };
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                    {
                        this.plhLeftPanel.Controls.Add(linkButton33);
                    }
                    LinkButton linkButton34 = new LinkButton()
                    {
                        Text = "&nbsp;&nbsp;Archive",
                        OnClientClick = "javascript:return CheckchkOne('archive');"
                    };
                    this.plhLeftPanel.Controls.Add(linkButton34);
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
                else if (base.Request.Url.ToString().ToLower().Contains("orders/order_summary.aspx"))
                {
                    string empty26 = string.Empty;
                    empty26 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "printoremail", this.Page.Request.Url.ToString());
                    this.Div_OrderSummary.Visible = true;
                    if (ConnectionClass.Is_crm_order_module != null)
                    {
                        if (ConnectionClass.Is_crm_order_module.ToString().ToString().ToLower() != "true")
                        {
                            this.RadPanelBar_ordSummary.Items.FindItemByText("Progress to Job").Visible = true;
                        }
                        else
                        {
                            this.RadPanelBar_ordSummary.Items.FindItemByText("Progress to Job").Visible = false;
                        }
                    }
                    DataTable dataTable9 = OrderBasePage.Order_select(this.CompanyID, Convert.ToInt64(base.Request.Params["ordid"]));
                    foreach (DataRow row12 in dataTable9.Rows)
                    {
                        this.sectionid = row12["ClientID"].ToString();
                        this.companytype = row12["CompanyType"].ToString();
                    }
                    base.Session["TemplateHTML"] = null;
                    base.Session["TemplateControlList"] = null;
                    base.Session["TemplateID"] = null;
                    base.Session["NewTempKey"] = null;
                    this.RadPanelBar_ordSummary.Items[0].Style.Add("cursor", "default");
                    DataTable dataTable10 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, Convert.ToInt64(base.Request.Params["estid"]));
                    RadMenu radMenu6 = (RadMenu)this.RadPanelBar_ordSummary.Items[0].FindControl("RadMenu_ordSummary");
                    if (dataTable10.Rows.Count <= 1)
                    {
                        radMenu6.Items[0].Items[0].Visible = false;
                        radMenu6.Items[0].Items[1].Visible = false;
                        AttributeCollection attributes6 = radMenu6.Attributes;
                        languageConversion = new string[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&EstID=", base.Request.Params["estid"].ToString(), "&ordid=", base.Request.Params["ordid"].ToString(), "'" };
                        attributes6.Add("onclick", string.Concat(languageConversion));
                    }
                    else
                    {
                        radMenu6.Items[0].Items[0].Text = "All Items";
                        radMenu6.Items[0].Items[1].Text = "Selected Items";
                        AttributeCollection attributeCollection6 = radMenu6.Items[0].Items[0].Attributes;
                        languageConversion = new string[] { "window.location.href='", this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["estid"].ToString(), "&GenPdf=all'" };
                        attributeCollection6.Add("onclick", string.Concat(languageConversion));
                        radMenu6.Items[0].Items[1].Attributes.Add("onclick", "javascript:OpenPrintandEmail();return false;");
                        HiddenField hdnPrintEmail2 = this.hdn_PrintEmail;
                        languageConversion = new string[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=webstoreorder&type=", this.companytype, "&page=webstoreorder&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["estid"].ToString() };
                        hdnPrintEmail2.Value = string.Concat(languageConversion);
                    }
                    long num12 = Convert.ToInt64(base.Request.Params["estid"]);
                    DataTable dataTable11 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num12);
                    StringBuilder stringBuilder8 = new StringBuilder();
                    if (dataTable11.Rows.Count > 1)
                    {
                        stringBuilder8.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none; border: 1px solid red;'>Delete</a>");
                        stringBuilder8.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                    }
                    int num13 = 1;
                    int num14 = 1;
                    foreach (DataRow dataRow12 in dataTable11.Rows)
                    {
                        if (dataTable11.Rows.Count > 1)
                        {
                            languageConversion = new string[] { "onclick=javascript:DeleteOrderItem('", dataRow12["EstimateItemID"].ToString(), "','", dataRow12["OrderItemID"].ToString(), "')" };
                            string str33 = string.Concat(languageConversion);
                            str = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str33, " >Item", num13, "</a></li>" };
                            stringBuilder8.Append(string.Concat(str));
                            num13++;
                        }
                        num14++;
                    }
                    if (dataTable11.Rows.Count > 1)
                    {
                        stringBuilder8.Append("</ul>");
                        stringBuilder8.Append("</li>");
                    }
                    string empty27 = string.Empty;
                    empty27 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "others", this.Page.Request.Url.ToString());
                    if (empty26 == "0" || empty26 == "2")
                    {
                        radMenu6.Visible = false;
                    }
                    if (empty27 == "0" || empty27 == "2")
                    {
                        this.RadPanelBar_ordSummary.Items.FindItemByText("Progress To Job").Visible = false;
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
                else if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary.aspx"))
                {
                    if (base.Request.Url.ToString().ToLower().Contains("jobs/job_productcatalogue.aspx"))
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
                    else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary.aspx"))
                    {
                        this.pnlCustomize.Visible = true;
                        foreach (DataRow row13 in JobBasePage.Jobs_Jobcard_Jobdetails_select(this.CompanyID, this.EstID).Rows)
                        {
                            this.sectionid = row13["CustomerID"].ToString();
                            this.companytype = row13["CompanyType"].ToString();
                            this.jobconvertedtoinvoice = row13["isconverted"].ToString();
                        }
                        base.Session["TemplateHTML"] = null;
                        base.Session["TemplateControlList"] = null;
                        base.Session["TemplateID"] = null;
                        string str34 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "printoremail", this.Page.Request.Url.ToString());
                        if (str34 == "0" || str34 == "2")
                        {
                            this.LoadLi_AccessRight("Print/Email", this.plhLeftPanel);
                        }
                        else
                        {
                            string languageConversion3 = this.objLangClass.GetLanguageConversion("Print_Email");
                            languageConversion = new string[] { "../invoice/templates_view1.aspx?sectionid=", this.sectionid, "&sectionname=Invoice&type=", this.companytype, "&page=Invoice&ordid=", base.Request.Params["ordid"].ToString(), "&EstID=", base.Request.Params["EstID"].ToString() };
                            this.LoadLi(languageConversion3, string.Concat(languageConversion), this.plhLeftPanel);
                        }
                        if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isview", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
                        {
                            this.LoadLi(this.objLangClass.GetLanguageConversion("Attachments"), "#", "javascript:ShowAttachments();", this.plhLeftPanel);
                        }
                        else
                        {
                            this.LoadLi_AccessRight("Attachments", this.plhLeftPanel);
                        }
                        if (base.Request.Params["estid"] != null)
                        {
                            string empty28 = string.Empty;
                            foreach (DataRow dataRow13 in InvoiceBasePage.Invoice_Select_By_EstimateID(this.CompanyID, this.EstID).Rows)
                            {
                                if (dataRow13["Status"].ToString().ToLower() != "locked")
                                {
                                    continue;
                                }
                                empty28 = "yes";
                            }
                            if (empty28 == "")
                            {
                                long num15 = Convert.ToInt64(base.Request.Params["estid"]);
                                DataTable dataTable12 = EstimatesBasePage.Estimate_Summary_Items_select_by_EstimateID(this.CompanyID, num15);
                                StringBuilder stringBuilder9 = new StringBuilder();
                                if (dataTable12.Rows.Count > 1)
                                {
                                    stringBuilder9.Append("<li id='li1'><a href='' style='padding-left:18px;text-decoration:none;'>Delete</a>");
                                    stringBuilder9.Append("<ul style='border-top: solid 1px #ccc' id='ul1' class='glossymenu1'>");
                                }
                                int num16 = 1;
                                int num17 = 1;
                                foreach (DataRow row14 in dataTable12.Rows)
                                {
                                    if (dataTable12.Rows.Count > 1)
                                    {
                                        languageConversion = new string[] { "onclick=javascript:DeleteOrderItem('", row14["EstimateItemID"].ToString(), "','", row14["OrderItemID"].ToString(), "')" };
                                        string str35 = string.Concat(languageConversion);
                                        str = new object[] { "<li><a href='#' style='padding-left:18px;text-decoration:none;' ", str35, " >Item", num16, "</a></li>" };
                                        stringBuilder9.Append(string.Concat(str));
                                        num16++;
                                    }
                                    num17++;
                                }
                                if (dataTable12.Rows.Count > 1)
                                {
                                    stringBuilder9.Append("</ul>");
                                    stringBuilder9.Append("</li>");
                                }
                            }
                        }
                        str = new object[] { "../Invoice/invoice_Othercost.aspx?type=add&EstID=", this.EstID, "&OrdID=", this.OrderID, "&FromAddAnItem=Y&maintype=add&eStore=yes", this.jID, this.InvID };
                        this.LoadLi("Add Other Cost", string.Concat(str), this.plhLeftPanel);
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
                }
                this.plhLeftPanel.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</div>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</div>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("<div class='only10px'>"));
                this.plhLeftPanel.Controls.Add(new LiteralControl("</div>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("<div id='divCustContent2' style='display: block; overflow: visible; height: 150px>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("<div style='float: left;>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("<ul class='glossymenu1'>"));
                if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_summary.aspx"))
                {
                    this.LoadLi("Print/Email Estimate", "#", this.plhLeftPanel2);
                    this.LoadLi("Pro Forma Invoice", "#", this.plhLeftPanel2);
                    this.LoadLi("Print MRN", "#", this.plhLeftPanel2);
                }
                this.plhLeftPanel2.Controls.Add(new LiteralControl("</ul>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("</div>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("</div>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("<div class='only10px'>"));
                this.plhLeftPanel2.Controls.Add(new LiteralControl("</div>"));
            }
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