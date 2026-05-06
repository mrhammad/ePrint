using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.usercontrol.Item
{
    public partial class Job_Revert_To_Estimate : UserControl
    {
        //protected CheckBox Chk_DeletePO;

        //protected CheckBox Chk_DeleteDN;

        //protected CheckBox Chk_InvaAjusted;

        //protected CheckBox Chk_StockCancel;

        //protected HtmlGenericControl revert2;

        //protected Button btnRevertJob;

        //protected HtmlGenericControl div_revert2estimate;

        //protected RadioButton rdb_All_Item;

        //protected RadioButton rdb_Selected_Item;

        //protected PlaceHolder plhItemsList;

        //protected HtmlGenericControl div_Itemlist;

        //protected HtmlGenericControl main;

        //protected HiddenField hdnIsinventoryBack;

        //protected HiddenField hdnReduceStockTypeForCancelledNew;

        //protected HiddenField hdnStockCancelChk;

        //protected HiddenField hidchkDeleteDel;

        //protected HiddenField hidchkDeletepo;

        //protected HiddenField hdnrevertitem;

        //protected HiddenField hdnEstItemsSelected;

        //protected HiddenField hdnEstItemsSelectedCount;

        //protected LinkButton lnk_RevertToJob;

        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        public languageClass objLanguage = new languageClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long ParentEstimateItemID;

        public long EstimateItemID;

        public string pg = string.Empty;

        public string Module = string.Empty;

        public string Pgtype = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string ParentEstimateType = string.Empty;

        public string EstimateType = string.Empty;

        public string MainType = string.Empty;

        public bool Check_SpecialPrivilege;

        public string divItemList_Style = string.Empty;

        public string RedirectPath = string.Empty;

        private string Div_Content = string.Empty;

        private string Div_ShowContent = string.Empty;

        private string Div_HideContent = string.Empty;

        public string Div_Content_first = string.Empty;

        public string EsttypeName = string.Empty;

        private EstimatesItem EstItem = new EstimatesItem();

        private commonClass commclass = new commonClass();

        public decimal SubTotal;

        public string StrSubTotal = string.Empty;

        public long ViewEstItemID;

        private bool falg = true;

        public long EstItemID_BKN;

        public bool IsShowDelete;

        public bool IsShowJobReRun;

        public bool IsShowInvRerun;

        private string EstStatus = string.Empty;

        public string Isfromactivityhist = string.Empty;

        public int CustomerID;

        public string pagename = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int MainItemCnt;

        public string cpyItm = string.Empty;

        public languageClass objLangClass = new languageClass();

        public long EstimateItemID_ForSave;

        public static string SalesPersonID;

        public string IDs = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = string.Empty;

        public string tab = string.Empty;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public long EstID;

        private Hashtable htInventory = new Hashtable();

        public long JObID;

        public int RemainingItemCnt;

        private long Item_EstimateItemID;

        public DataTable dt_Select_Item;

        public string module = string.Empty;

        public long ordid;

        public long EstimateItem_ID;

        public bool IsItemRevert;

        public string IS_INVOICEorJOB_from_Webstore = string.Empty;

        public string PaymentType = string.Empty;

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

        static Job_Revert_To_Estimate()
        {
            Job_Revert_To_Estimate.SalesPersonID = string.Empty;
            Job_Revert_To_Estimate.ManageStockPermission = 0;
        }

        public Job_Revert_To_Estimate()
        {
        }

        private void Adjust_Inventory_On_Job_Revert(DataSet ds, string StrJobNum, int StatusID, long EstID, long EstimateItemID, Hashtable htInventory)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, this.UserID, this.CompanyID, "reverted", htInventory, EstimateItemID);
        }

        public void btnAddTraining_Click(object sender, EventArgs e)
        {
            string[] strArrays;
            string empty = string.Empty;
            DataSet dataSet = new DataSet();
            DataTable dataTable = JobBasePage.Job_Card_Info_Select_By_JobID(this.JObID);
            DataTable dataTable1 = new DataTable();
            string str = string.Empty;
            str = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            string empty1 = string.Empty;
            int num = 0;
            BaseClass baseClass = new BaseClass();
            this.StockCancellationType = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
            string[] strArrays1 = Regex.Split(this.hdnEstItemsSelected.Value, "»");
            string[] strArrays2 = Regex.Split(this.hdnEstItemsSelectedCount.Value, "»");
            string str1 = string.Empty;
            string empty2 = string.Empty;
            foreach (DataRow row in EstimateBasePage.purchase_select_by_estimateid(this.CompanyID, this.EstID).Rows)
            {
                str1 = (str1 == "" ? string.Concat(str1, row["PONO"].ToString()) : string.Concat(str1, ", ", row["PONO"].ToString()));
            }
            DataTable dataTable2 = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstID, (long)0, "");
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                empty2 = (empty2 == "" ? string.Concat(empty2, dataRow["DeliveryNumber"].ToString()) : string.Concat(empty2, ", ", dataRow["DeliveryNumber"].ToString()));
            }
            if (this.hidchkDeletepo.Value.ToString().ToLower() == "true")
            {
                if (this.IsItemRevert)
                {
                    JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.EstimateItem_ID, 1, 0, "Item");
                }
                else if (this.rdb_Selected_Item.Checked)
                {
                    for (int i = 0; i < (int)strArrays2.Length; i++)
                    {
                        JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, Convert.ToInt64(strArrays2[i]), 1, 0, "Item");
                    }
                }
                else if (this.rdb_All_Item.Checked)
                {
                    JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.JObID, 1, 0, "Main");
                }
            }
            if (this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                if (this.IsItemRevert)
                {
                    JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.EstimateItem_ID, 0, 1, "Item");
                }
                else if (this.rdb_Selected_Item.Checked)
                {
                    for (int j = 0; j < (int)strArrays2.Length; j++)
                    {
                        JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, Convert.ToInt64(strArrays2[j]), 0, 1, "Item");
                    }
                }
                else if (this.rdb_All_Item.Checked)
                {
                    JobsBasePage.Delete_PODeliverynote_for_RevertJob((long)this.CompanyID, this.JObID, 0, 1, "Main");
                }
            }
            if (str == "a" || str == "p" && this.hdnReduceStockTypeForCancelledNew.Value.ToLower() == "true")
            {
                foreach (DataRow row1 in dataTable.Rows)
                {
                    long num1 = Convert.ToInt64(row1["EstimateItemID"]);
                    int num2 = Convert.ToInt32(row1["QtyNumber"]);
                    string str2 = row1["ItemType"].ToString();
                    empty1 = row1["JobNumber"].ToString();
                    num = Convert.ToInt32(row1["StatusID"].ToString());
                    long num3 = (long)0;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    int num4 = 0;
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    string empty4 = string.Empty;
                    decimal num7 = new decimal(0);
                    if (string.Compare(str2, "S", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow1["PaperID"]);
                            empty3 = "I";
                            dataRow1["InventoryCode"].ToString();
                            dataRow1["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow1["Quantity"]);
                            Convert.ToDecimal(dataRow1["PackedIn"]);
                            Convert.ToInt64(dataRow1["EstimateSingleItemID"]);
                            num5 = Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                            Convert.ToDecimal(dataRow1["PaperMarkup"]);
                            num7 = Convert.ToDecimal(dataRow1["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "P", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow row2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row2["PaperID"]);
                            empty3 = "I";
                            row2["InventoryCode"].ToString();
                            row2["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row2["Quantity"]);
                            Convert.ToDecimal(row2["PackedIn"]);
                            Convert.ToInt64(row2["EstimatePadItemID"]);
                            num5 = Convert.ToDecimal(row2["PaperUnitPrice"]);
                            Convert.ToInt32(row2["PrintLayoutValue"]);
                            Convert.ToDecimal(row2["SetupSpoilage"]);
                            Convert.ToDecimal(row2["RunningSpoilage"]);
                            Convert.ToDecimal(row2["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row2["InvSheets"]);
                            if (row2["LeavesPerPad"] != null)
                            {
                                Convert.ToDecimal(row2["LeavesPerPad"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "L", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow2["PaperID"]);
                            empty3 = "I";
                            dataRow2["InventoryCode"].ToString();
                            dataRow2["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow2["Quantity"]);
                            Convert.ToDecimal(dataRow2["PackedIn"]);
                            Convert.ToInt64(dataRow2["EstimateLargeItemID"]);
                            num5 = Convert.ToDecimal(dataRow2["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow2["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow2["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow2["RunningSpoilage"]);
                            Convert.ToDecimal(dataRow2["PaperMarkup"]);
                            Convert.ToDecimal(dataRow2["JobHeight"]);
                            Convert.ToDecimal(dataRow2["JobWidth"]);
                            Convert.ToDecimal(dataRow2["SheetHeight"]);
                            Convert.ToDecimal(dataRow2["SheetWidth"]);
                            Convert.ToDecimal(dataRow2["GutterHorizontal"]);
                            Convert.ToDecimal(dataRow2["GutterVertical"]);
                            Convert.ToDecimal(dataRow2["Row"]);
                            Convert.ToDecimal(dataRow2["Col"]);
                            dataRow2["PrintLayout"].ToString();
                            string str4 = dataRow2["PressPaperType"].ToString();
                            num7 = Convert.ToDecimal(dataRow2["InvSheets"]);
                            if (string.Compare(str4, "roll", true) == 0 && Convert.ToDecimal(dataRow2["length"]) > new decimal(0))
                            {
                                num5 = num5 / Convert.ToDecimal(dataRow2["length"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = (int)Math.Round(Convert.ToDouble(this.htInventory[num3].ToString())) + Convert.ToInt32(num7);
                                //this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num7), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "B", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        Hashtable hashtables = new Hashtable();
                        foreach (DataRow row3 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row3["PaperID"]);
                            empty3 = "I";
                            row3["InventoryCode"].ToString();
                            row3["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row3["Quantity"]);
                            Convert.ToDecimal(row3["PackedIn"]);
                            Convert.ToInt64(row3["EstimateBookletItemID"]);
                            num5 = Convert.ToDecimal(row3["PaperUnitPrice"]);
                            Convert.ToDecimal(row3["NoOfSignatures"]);
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
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key), empty3, Convert.ToInt32(hashtables[key]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "W", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        Hashtable hashtables1 = new Hashtable();
                        foreach (DataRow dataRow3 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow3["WarehouseTypeID"]);
                            empty3 = dataRow3["WarehouseType"].ToString();
                            num4 = Convert.ToInt32(dataRow3["Quantity"]);
                            if (Convert.ToInt32(dataRow3["IsDeleted"]) != 0)
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
                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty3, Convert.ToInt32(hashtables1[key1]), "reverted", num1);
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "O", true) == 0)
                    {
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "C", true) == 0 || string.Compare(str2, "X", true) == 0)
                    {
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "F", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow row4 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row4["PaperID"]);
                            empty3 = "I";
                            row4["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row4["Quantity"]);
                            Convert.ToDecimal(row4["PackedIn"]);
                            Convert.ToInt64(row4["EstLithoItemID"]);
                            num5 = Convert.ToDecimal(row4["PaperUnitPrice"]);
                            Convert.ToInt32(row4["PrintLayoutValue"]);
                            Convert.ToDecimal(row4["SetupSpoilage"]);
                            Convert.ToDecimal(row4["RunningSpoilage"]);
                            Convert.ToDecimal(row4["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row4["InvSheets"]);
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num7), "reverted", num1);
                        }
                        dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num1);
                        foreach (DataRow dataRow4 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow4["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow4["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num4), "reverted", num1);
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
                    else if (string.Compare(str2, "D", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow row5 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row5["PaperID"]);
                            empty3 = "I";
                            row5["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row5["Quantity"]);
                            Convert.ToDecimal(row5["PackedIn"]);
                            Convert.ToInt64(row5["EstimateLithoPadItemID"]);
                            num5 = Convert.ToDecimal(row5["PaperUnitPrice"]);
                            Convert.ToInt32(row5["PrintLayoutValue"]);
                            Convert.ToDecimal(row5["SetupSpoilage"]);
                            Convert.ToDecimal(row5["RunningSpoilage"]);
                            Convert.ToDecimal(row5["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row5["InvSheets"]);
                            if (row5["LeavesPerPad"] != null)
                            {
                                Convert.ToDecimal(row5["LeavesPerPad"]);
                            }
                            if (!this.htInventory.ContainsKey(num3))
                            {
                                this.htInventory.Add(num3, Convert.ToInt32(num7));
                            }
                            else
                            {
                                this.htInventory[num3] = Convert.ToInt32(this.htInventory[num3].ToString()) + Convert.ToInt32(num7);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num7), "reverted", num1);
                        }
                        dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num1);
                        foreach (DataRow dataRow5 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow5["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow5["Noofplates"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num4), "reverted", num1);
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
                    else if (string.Compare(str2, "N", true) == 0)
                    {
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num1);
                        Hashtable hashtables2 = new Hashtable();
                        foreach (DataRow row6 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(row6["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(row6["Noofplates"]);
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
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty3, Convert.ToInt32(hashtables2[key2]), "reverted", num1);
                        }
                        hashtables2.Clear();
                        foreach (DataRow dataRow6 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(dataRow6["PaperID"]);
                            empty3 = "I";
                            dataRow6["InventoryCode"].ToString();
                            dataRow6["inventoryname"].ToString();
                            num4 = Convert.ToInt32(dataRow6["Quantity"]);
                            Convert.ToDecimal(dataRow6["PackedIn"]);
                            Convert.ToInt64(dataRow6["EstimateLithoNCRItemID"]);
                            num5 = Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                            Convert.ToInt32(dataRow6["PrintLayoutValue"]);
                            Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                            Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                            decimal num8 = Convert.ToDecimal(dataRow6["NcrPartsPerSet"].ToString());
                            decimal num9 = Convert.ToDecimal(dataRow6["NcrSetsPerPad"].ToString());
                            Convert.ToDecimal(dataRow6["PaperMarkup"]);
                            num7 = Convert.ToDecimal(dataRow6["InvSheets"]);
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
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty3, Convert.ToInt32(hashtables2[key3]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                    else if (string.Compare(str2, "K", true) != 0)
                    {
                        if (string.Compare(str2, "Q", true) != 0)
                        {
                            continue;
                        }
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        foreach (DataRow row7 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row7["PaperID"]);
                            empty3 = "I";
                            row7["InventoryCode"].ToString();
                            num4 = Convert.ToInt32(row7["Quantity"]);
                            Convert.ToDecimal(row7["PackedIn"]);
                            Convert.ToInt64(row7["QuickQuoteID"]);
                            num5 = Convert.ToDecimal(row7["PaperUnitPrice"]);
                            Convert.ToInt32(row7["PrintLayoutValue"]);
                            Convert.ToDecimal(row7["SetupSpoilage"]);
                            Convert.ToDecimal(row7["RunningSpoilage"]);
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num3, empty3, Convert.ToInt32(num6), "reverted", num1);
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
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num1, num2, str2);
                        dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num1);
                        Hashtable hashtables3 = new Hashtable();
                        foreach (DataRow dataRow7 in dataTable1.Rows)
                        {
                            num3 = Convert.ToInt64(dataRow7["PlateID"]);
                            empty3 = "I";
                            num4 = Convert.ToInt32(dataRow7["Noofplates"]);
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
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key4), empty3, Convert.ToInt32(hashtables3[key4]), "reverted", num1);
                        }
                        hashtables3.Clear();
                        foreach (DataRow row8 in dataSet.Tables[0].Rows)
                        {
                            num3 = Convert.ToInt64(row8["PaperID"]);
                            empty3 = "I";
                            row8["InventoryCode"].ToString();
                            row8["inventoryname"].ToString();
                            num4 = Convert.ToInt32(row8["Quantity"]);
                            Convert.ToDecimal(row8["PackedIn"]);
                            Convert.ToInt64(row8["EstimateLithobookletItemID"]);
                            num5 = Convert.ToDecimal(row8["PaperUnitPrice"]);
                            Convert.ToInt32(row8["NoOfSignatures"]);
                            Convert.ToDecimal(row8["SetupSpoilage"]);
                            Convert.ToDecimal(row8["RunningSpoilage"]);
                            Convert.ToDecimal(row8["PaperMarkup"]);
                            num7 = Convert.ToDecimal(row8["InvSheets"]);
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
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key5), empty3, Convert.ToInt32(hashtables3[key5]), "reverted", num1);
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num1, this.htInventory);
                    }
                }
            }
            //if (this.StockCancellationType == "a" || this.StockCancellationType == "p" && this.hdnStockCancelChk.Value.ToLower() == "true" && base.Request.QueryString["module"] != "order")
            if ((this.StockCancellationType == "a" || this.StockCancellationType == "p") && this.hdnStockCancelChk.Value.ToLower() == "true" && base.Request.QueryString["module"] != "order")
            {
                foreach (DataRow dataRow8 in dataTable.Rows)
                {
                    long num10 = Convert.ToInt64(dataRow8["EstimateItemID"]);
                    int num11 = Convert.ToInt32(dataRow8["QtyNumber"]);
                    string str5 = dataRow8["ItemType"].ToString();
                    empty1 = dataRow8["JobNumber"].ToString();
                    num = Convert.ToInt32(dataRow8["StatusID"].ToString());
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    int num12 = 0;
                    string str6 = string.Empty;
                    if (!this.IsItemRevert)
                    {
                        strArrays = (this.dt_Select_Item.Rows.Count != 1 ? Regex.Split(this.hdnrevertitem.Value, "»") : Regex.Split(this.Item_EstimateItemID.ToString(), "»"));
                        if (string.Compare(str5, "C", true) != 0 && string.Compare(str5, "X", true) != 0 || !strArrays.Contains<string>(num10.ToString()))
                        {
                            continue;
                        }
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str5);
                        foreach (DataRow row9 in dataSet.Tables[0].Rows)
                        {
                            long num13 = Convert.ToInt64(row9["PriceCatalogueID"]);
                            num12 = Convert.ToInt32(row9["Quantity"]);
                            decimal num14 = Convert.ToDecimal(row9["Price"]);
                            foreach (DataRow dataRow9 in baseClass.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                            {
                                if (dataRow9["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass.StockCancellationProcess((long)this.CompanyID, num13, (long)0, "self", num10, "Job", (long)this.UserID, this.StockCancellationType);
                                }
                                else if (dataRow9["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass.StockCancellationProcess((long)this.CompanyID, (long)0, num13, "other", num10, "Job", (long)this.UserID, this.StockCancellationType);
                                }
                                else if (dataRow9["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow9["DrawStockFrom"].ToString().ToLower() != "m")
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
                    else
                    {
                        if (num10 != this.EstimateItem_ID)
                        {
                            continue;
                        }
                        dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str5);
                        if (string.Compare(str5, "C", true) != 0 && string.Compare(str5, "X", true) != 0)
                        {
                            continue;
                        }
                        foreach (DataRow row10 in dataSet.Tables[0].Rows)
                        {
                            long num15 = Convert.ToInt64(row10["PriceCatalogueID"]);
                            num12 = Convert.ToInt32(row10["Quantity"]);
                            decimal num16 = Convert.ToDecimal(row10["Price"]);
                            foreach (DataRow dataRow10 in baseClass.ProductStockType_Select((long)this.CompanyID, num15).Rows)
                            {
                                if (dataRow10["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass.StockCancellationProcess((long)this.CompanyID, num15, (long)0, "self", num10, "Job", (long)this.UserID, this.StockCancellationType);
                                }
                                else if (dataRow10["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass.StockCancellationProcess((long)this.CompanyID, (long)0, num15, "other", num10, "Job", (long)this.UserID, this.StockCancellationType);
                                }
                                else if (dataRow10["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow10["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass.StockCancellationProcess((long)this.CompanyID, num15, (long)0, "multiple", num10, "Job", (long)this.UserID, this.StockCancellationType);
                                }
                                else
                                {
                                    baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num15, "additional option", num12, num10, "Job", (long)this.UserID, num16);
                                }
                            }
                        }
                        this.Adjust_Inventory_On_Job_Revert(dataSet, empty1, num, this.EstID, num10, this.htInventory);
                    }
                }
            }
            string empty7 = string.Empty;
            if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRevertedFromEstimate);
            }
            else
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRevertedFromOrder);
            }
            this.objnotes.ModuleName = "job";
            this.objnotes.ModuleID = this.JObID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            if (this.IsItemRevert)
            {
                DataTable dataTable3 = Notes.select_item_number_for_Activity_History(this.JObID, this.Item_EstimateItemID, this.modulename);
                foreach (DataRow row11 in dataTable3.Rows)
                {
                    empty7 = row11["rownumber"].ToString();
                }
                JobsBasePage.Job_Item_Revart(this.Item_EstimateItemID, (long)this.CompanyID, (long)this.UserID);
                this.objnotes.Item_number = empty7;
                this.objnotes.ItemID = this.Item_EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
            else if (this.dt_Select_Item.Rows.Count == 1)
            {
                DataTable dataTable4 = Notes.select_item_number_for_Activity_History(this.JObID, this.Item_EstimateItemID, this.modulename);
                foreach (DataRow dataRow11 in dataTable4.Rows)
                {
                    empty7 = dataRow11["rownumber"].ToString();
                }
                JobsBasePage.Job_Item_Revart(this.Item_EstimateItemID, (long)this.CompanyID, (long)this.UserID);
                this.objnotes.Item_number = empty7;
                this.objnotes.ItemID = this.Item_EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
            else if (this.rdb_Selected_Item.Checked)
            {
                for (int k = 0; k < (int)strArrays2.Length; k++)
                {
                    DataTable dataTable5 = Notes.select_item_number_for_Activity_History(this.JObID, Convert.ToInt64(strArrays2[k]), this.modulename);
                    foreach (DataRow row12 in dataTable5.Rows)
                    {
                        empty7 = row12["rownumber"].ToString();
                    }
                    JobsBasePage.Job_Item_Revart(Convert.ToInt64(strArrays2[k]), (long)this.CompanyID, (long)this.UserID);
                    this.objnotes.Item_number = empty7;
                    this.objnotes.ItemID = Convert.ToInt64(strArrays2[k]);
                    this.objN.NotesAdd(this.objnotes);
                }
            }
            else if (this.rdb_All_Item.Checked)
            {
                for (int l = 0; l < (int)strArrays1.Length - 1; l++)
                {
                    DataTable dataTable6 = Notes.select_item_number_for_Activity_History(this.JObID, Convert.ToInt64(strArrays1[l]), this.modulename);
                    foreach (DataRow dataRow12 in dataTable6.Rows)
                    {
                        empty7 = dataRow12["rownumber"].ToString();
                    }
                    JobsBasePage.Job_Item_Revart(Convert.ToInt64(strArrays1[l]), (long)this.CompanyID, (long)this.UserID);
                    this.objnotes.Item_number = empty7;
                    this.objnotes.ItemID = Convert.ToInt64(strArrays1[l]);
                    this.objN.NotesAdd(this.objnotes);
                }
            }
            if (this.hidchkDeletepo.Value.ToString().ToLower() == "true" && this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPOandDel);
                }
                else
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPOandDelFromorder);
                }
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "true" && this.hidchkDeleteDel.Value.ToString().ToLower() == "false")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPO);
                }
                else
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithPOFromorder);
                }
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "false" && this.hidchkDeleteDel.Value.ToString().ToLower() == "true")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithDel);
                }
                else
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithDelFromorder);
                }
            }
            else if (this.hidchkDeletepo.Value.ToString().ToLower() == "false" && this.hidchkDeleteDel.Value.ToString().ToLower() == "false")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithOutPOandDel);
                }
                else
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobRevertWithOutPOandDelFromorder);
                }
            }
            if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
            {
                this.objnotes.ModuleName = "estimate";
            }
            else
            {
                this.objnotes.ModuleName = "webstoreorder";
            }
            this.objnotes.ItemID = (long)0;
            this.objnotes.Delivery_number = empty2;
            this.objnotes.PO_Numbers = str1;
            this.objnotes.ModuleID = this.EstID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass1 = this.objnotes;
            commonClass _commonClass1 = this.commclass;
            now = DateTime.Now;
            _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            DataTable dataTable7 = new DataTable();
            dataTable7 = EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstID);
            string str7 = string.Empty;
            foreach (DataRow row13 in dataTable7.Rows)
            {
                str7 = row13["EstimateNumber"].ToString();
            }
            if (this.htInventory.Count > 0)
            {
                foreach (long key6 in this.htInventory.Keys)
                {
                    string empty8 = string.Empty;
                    DataTable dataTable8 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable8.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow13 in dataTable8.Rows)
                        {
                            empty8 = dataRow13["FinalQuantity"].ToString();
                        }
                    }
                    if (empty8 == null || empty8 == "")
                    {
                        empty8 = "0";
                    }
                    commonClass _commonClass2 = this.commclass;
                    long num17 = Convert.ToInt64(key6);
                    object[] estID = new object[] { "Job reverted to estimate and stock adjusted - <a href='", this.strSitepath, "estimates/estimate_summary.aspx?frm=view&estid=", this.EstID, "' target='_blank' >", str7, "</a>" };
                    _commonClass2.Insert_Activity_History_For_Inventory(num17, string.Concat(estID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(Convert.ToDecimal(empty8) + Convert.ToDecimal(this.htInventory[key6])));
                }
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:WindowClose();", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            this.JObID = Convert.ToInt64(base.Request.Params["jid"].ToString());
            if (base.Request.Params["IsItemRevert"] != null && base.Request.Params["estitemid"] != null && base.Request.Params["IsItemRevert"].ToString() == "1" && base.Request.Params["estitemid"].ToString() != "")
            {
                this.EstimateItem_ID = Convert.ToInt64(base.Request.Params["estitemid"]);
                this.IsItemRevert = true;
            }
            this.Chk_DeletePO.Text = this.objLangClass.GetLanguageConversion("Delete_POs_Related_to_this_Job");
            this.Chk_DeleteDN.Text = this.objLangClass.GetLanguageConversion("Delete_Delivery_notes_Related_to_this_Job");
            this.Chk_InvaAjusted.Text = this.objLangClass.GetLanguageConversion("Do_you_want_inventory_adjusted_if_any_to_be_added_back_to_the_system");
            this.Chk_StockCancel.Text = this.objLangClass.GetLanguageConversion("Do you want stock adjusted if any to be added back to the system?");
            if (base.Request.QueryString["module"] != "estimate")
            {
                this.btnRevertJob.Text = this.objLangClass.GetLanguageConversion("Revert_To_Order");
                this.rdb_All_Item.Text = this.objLangClass.GetLanguageConversion("Revert_All_Item_To_Order");
                this.rdb_Selected_Item.Text = this.objLangClass.GetLanguageConversion("Revert_Selected_Item_To_Order");
                this.module = "order";
            }
            else
            {
                this.btnRevertJob.Text = this.objLangClass.GetLanguageConversion("Revert_To_Estimate");
                this.rdb_All_Item.Text = this.objLangClass.GetLanguageConversion("Revert_All_Item_To_Estimate");
                this.rdb_Selected_Item.Text = this.objLangClass.GetLanguageConversion("Revert_Selected_Item_To_Estimate");
                this.module = "estimate";
            }
            if (!this.IsItemRevert)
            {
                this.div_revert2estimate.Attributes.Add("style", "display:none");
                this.div_Itemlist.Attributes.Add("style", "display:block");
            }
            if (this.rdb_All_Item.Checked)
            {
                this.divItemList_Style = "display: none;";
            }
            if (!this.IsItemRevert)
            {
                if (this.JObID > (long)0)
                {
                    this.dt_Select_Item = JobsBasePage.Select_All_Job_Item(this.JObID);
                }
                foreach (DataRow row in this.dt_Select_Item.Rows)
                {
                    this.Item_EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                    row["EstimateType"].ToString();
                    string str = row["ItemTitle"].ToString();
                    this.hdnEstItemsSelected.Value = string.Concat(this.hdnEstItemsSelected.Value, this.Item_EstimateItemID, "»");
                    if (Convert.ToInt32(row["Shoppingcartvalue"]) != 0)
                    {
                        this.rdb_Selected_Item.Enabled = false;
                    }
                    ControlCollection controls = this.plhItemsList.Controls;
                    object[] itemEstimateItemID = new object[] { "<div style='padding: 0px 5px 6px 0px; float: left;'><input style='cursor: pointer; margin-left:25px; margin-top:3px;' type='checkbox' id='chkEstItems_", this.Item_EstimateItemID, "' title='", str, "' checked='checked' value='", this.Item_EstimateItemID, "' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(itemEstimateItemID)));
                    this.plhItemsList.Controls.Add(new LiteralControl(string.Concat("<div style='padding-top:3px;'>", this.objBC.SpecialDecode(str), "</div>")));
                    this.plhItemsList.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
                    Job_Revert_To_Estimate remainingItemCnt = this;
                    remainingItemCnt.RemainingItemCnt = remainingItemCnt.RemainingItemCnt + 1;
                }
            }
            else
            {
                this.Item_EstimateItemID = this.EstimateItem_ID;
                Job_Revert_To_Estimate usercontrolItemJobRevertToEstimate = this;
                usercontrolItemJobRevertToEstimate.RemainingItemCnt = usercontrolItemJobRevertToEstimate.RemainingItemCnt + 1;
                this.dt_Select_Item = JobsBasePage.Select_All_Job_Item((long)-999);
            }
            if (this.dt_Select_Item.Rows.Count == 1)
            {
                this.div_Itemlist.Attributes.Add("style", "display:none");
                this.div_revert2estimate.Attributes.Add("style", "display:block");
            }
            if (this.RemainingItemCnt > 0)
            {
                this.plhItemsList.Controls.Add(new LiteralControl("</div>"));
                this.plhItemsList.Controls.Add(new LiteralControl("<div style='padding-top: 5px; float: left; padding-left:6.2%;'><input type='submit' id='rdb_Revert_Job' value='Next' class='button' onclick='javascript:EstimateItemIDCount();revert_item();return false;'/></div>"));
                if (this.RemainingItemCnt == 1)
                {
                    this.divItemList_Style = "display: none;";
                }
            }
            if (ConnectionClass.InventoryManagement != null)
            {
                this.InventoryManagement = ConnectionClass.InventoryManagement;
            }
            if (base.Request.Url.ToString().ToLower().Contains("job"))
            {
                this.modulename = "Job";
            }
            if (base.Request.Params["EstID"] != null)
            {
                this.EstID = Convert.ToInt64(base.Request.Params["EstID"].ToString());
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (!this.IsItemRevert)
            {
                DataSet dataSet = EstimateBasePage.DeliveryPurchase_Check(this.CompanyID, this.JObID, (long)0);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    this.Chk_DeletePO.Enabled = false;
                }
                if (dataSet.Tables[1].Rows.Count == 0)
                {
                    this.Chk_DeleteDN.Enabled = false;
                }
            }
            else
            {
                DataSet dataSet1 = EstimateBasePage.DeliveryPurchase_Check(this.CompanyID, this.JObID, this.Item_EstimateItemID);
                if (dataSet1.Tables[0].Rows.Count == 0)
                {
                    this.Chk_DeletePO.Enabled = false;
                }
                if (dataSet1.Tables[1].Rows.Count == 0)
                {
                    this.Chk_DeleteDN.Enabled = false;
                }
            }
            if (base.IsPostBack)
            {
                this.main.Attributes.Add("style", "display:none");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:RevertJob_reeng_Controls();", true);
            }
            if (this.modulename.ToLower() == "job")
            {
                this.IS_INVOICEorJOB_from_Webstore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.JObID, "jobs");
            }
            this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.EstimateID);
            if (this.PaymentType.ToLower().Contains("braintree credit card") || this.PaymentType.ToLower().Contains("paypal") || this.PaymentType.ToLower().Contains("stripe credit card"))
            {
                this.rdb_Selected_Item.Enabled = false;
            }
        }
    }
}