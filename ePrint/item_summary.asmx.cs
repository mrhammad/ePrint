using Newtonsoft.Json;
using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

//namespace ePrint
//{


[ScriptService]
[WebService(Namespace = "http://www.eprintsoftware.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class item_summary : WebService
{
    private commonClass commcls = new commonClass();

    private SummaryClass SummaryClassObj = new SummaryClass();

    private storeEmail Objemail = new storeEmail();

    private BaseClass objBase = new BaseClass();

    public string ReduceStockType = string.Empty;

    public string ReduceStockTypeForCancelled = string.Empty;

    public string InventoryManagement = ConnectionClass.InventoryManagement;

    public int CompanyID;

    public string KitStockValues = string.Empty;

    private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

    public item_summary()
    {
    }

    [WebMethod(EnableSession = true)]
    public void Delete_PODeliverynote_for_RevertJob(long CompanyID, long EstimateID, int DeletePO, int DeleteDel, string Type)
    {
        JobsBasePage.Delete_PODeliverynote_for_RevertJob(CompanyID, EstimateID, DeletePO, DeleteDel, Type);
    }

    [WebMethod(EnableSession = true)]
    public void DeleteSubItems(string EstimateType, long EstimateItemID, long ItemTypeID, long EstimateID, string Module, long ParentEstimateItemID)
    {
        this.SummaryClassObj.Insert_ActivityHistory_OnSubItemDelete(EstimateID, EstimateItemID, EstimateType, Module, ParentEstimateItemID);
        EstimatesBasePage.estimate_sub_item_delete(EstimateType, EstimateItemID, ItemTypeID);
        EstimatesBasePage.estimate_EstTotalPriceDetails_Update(EstimateItemID);
        if (string.Compare(Module, "invoice", true) == 0 || string.Compare(Module, "job", true) == 0)
        {
            int num = Convert.ToInt32(base.Session["CompanyID"]);
            EstimateCommonMethods.ShowJobCardDetails(num, EstimateID, EstimateItemID, "S");
        }
    }

    [WebMethod(EnableSession = true)]
    public string DeliveryPurchase_Check(int CompanyID, long JobID, long EstimateItemID)
    {
        DataSet dataSet = EstimateBasePage.DeliveryPurchase_Check(CompanyID, JobID, EstimateItemID);
        string empty = string.Empty;
        empty = (dataSet.Tables[0].Rows.Count != 0 ? string.Concat(empty, "true«") : string.Concat(empty, "false«"));
        empty = (dataSet.Tables[1].Rows.Count != 0 ? string.Concat(empty, "true") : string.Concat(empty, "false«"));
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public bool DelPurchaseOrdStatusUpdate(long CompanyID, string Module, long StatusID, long ID, string StockValue)
    {
        bool flag;
        IEnumerator enumerator;
        char[] chrArray;
        object[] objArray;
        if (Module.ToString().ToLower().Trim() == "purchase")
        {
            EstimateBasePage.PurchaseOrdStatusUpdate(CompanyID, StatusID, ID);
            this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate(ID, Module);
            return true;
        }
        if (Module.ToString().ToLower().Trim() != "delivery")
        {
            return false;
        }
        string empty = string.Empty;
        int num = 0;
        int num1 = 0;
        bool flag1 = false;
        long num2 = (long)0;
        long num3 = (long)0;
        string str = string.Empty;
        if (base.Session["ProductStockManagement"] == null)
        {
            str = "true";
        }
        else if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true" && (ConnectionClass.ServerName.ToLower() == "dmc" || ConnectionClass.ServerName.ToLower() == "dmc2"))
        {
            if (StatusID.ToString() != ConnectionClass.DeliveryStatusID.ToString())
            {
                str = "true";
            }
            else
            {
                base.Session["Counter"] = null;
                foreach (DataRow row in DeliveryBasePage.deliveryitem_select(Convert.ToInt32(CompanyID), ID).Rows)
                {
                    long num4 = Convert.ToInt64(row["DeliveryItemID"].ToString());
                    Convert.ToInt64(row["ItemID"].ToString());
                    string str1 = row["ItemType"].ToString();
                    row["Quantity"].ToString();
                    row["Description"].ToString();
                    if (Convert.ToInt32(row["isSentToKing"].ToString()) != 0)
                    {
                        str = string.Concat(str, "false");
                    }
                    else
                    {
                        if (!(str1.ToLower() == "c") && !(str1.ToLower() == "x"))
                        {
                            continue;
                        }
                        BaseClass baseClass = new BaseClass();
                        foreach (DataRow dataRow in baseClass.StockReductionForDeliveryItemNew(num4).Rows)
                        {
                            num2 = Convert.ToInt64(dataRow["PriceCatalogueID"].ToString());
                            long num5 = Convert.ToInt64(dataRow["EstimateItemID"].ToString());
                            empty = dataRow["DrawStockFrom"].ToString();
                            num = Convert.ToInt32(dataRow["Quantity"].ToString());
                            num1 = Convert.ToInt32(dataRow["DelItemQuantity"].ToString());
                            bool flag2 = false;
                            if (str1.ToLower() == "x")
                            {
                                flag2 = Convert.ToBoolean(dataRow["IsstockReplenish"]);
                            }
                            bool flag3 = false;
                            bool flag4 = false;
                            if (empty.Trim().ToLower() == "o")
                            {
                                empty = "s";
                                flag4 = true;
                            }
                            if (empty.ToLower() == "s" || empty.ToLower() == "o" || empty.ToLower() == "a" || empty.ToLower() == "m")
                            {
                                if (empty.ToLower() == "s")
                                {
                                    if (str1.ToLower() == "x" && flag2.ToString().ToLower() == "true")
                                    {
                                        flag3 = true;
                                    }
                                    else if (str1.ToLower() == "x" && flag2.ToString().ToLower() != "true")
                                    {
                                        flag3 = baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("self¶", num4.ToString()), num1, num, num5, flag4);
                                    }
                                    else if (str1.ToLower() == "c")
                                    {
                                        flag3 = baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("self¶", num4.ToString()), num1, num, num5, flag4);
                                    }
                                }
                                else if (empty.ToLower() == "o")
                                {
                                    num3 = Convert.ToInt64(dataRow["PriceCatalogueID2"].ToString());
                                    if (str1.ToLower() == "x" && flag2.ToString().ToLower() == "true")
                                    {
                                        flag3 = true;
                                    }
                                    else if (str1.ToLower() == "x" && flag2.ToString().ToLower() != "true")
                                    {
                                        flag3 = baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, num3, string.Concat("other¶", num4.ToString()), num1, num, num5, flag4);
                                    }
                                    else if (str1.ToLower() == "c")
                                    {
                                        flag3 = baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, num3, string.Concat("other¶", num4.ToString()), num1, num, num5, flag4);
                                    }
                                }
                                else if (empty.ToLower() == "a")
                                {
                                    base.Session["StockItemType"] = str1.ToLower();
                                    base.Session["ALC_OrderItemId"] = dataRow["OrderItemID"].ToString();
                                    if (!(str1.ToLower() == "x") || !(flag2.ToString().ToLower() == "true"))
                                    {
                                        flag3 = (!(str1.ToLower() == "x") || !(flag2.ToString().ToLower() != "true") ? baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("additional option¶", num4.ToString()), num1, num, num5, flag4) : baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("additional option¶", num4.ToString()), num1, num, num5, flag4));
                                    }
                                    else
                                    {
                                        flag3 = true;
                                    }
                                }
                                else if (empty.ToLower() == "m")
                                {
                                    base.Session["StockItemType"] = str1.ToLower();
                                    base.Session["ALC_OrderItemId"] = dataRow["OrderItemID"].ToString();
                                    if (!(str1.ToLower() == "x") || !(flag2.ToString().ToLower() == "true"))
                                    {
                                        flag3 = (!(str1.ToLower() == "x") || !(flag2.ToString().ToLower() != "true") ? baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("multiple¶", num4.ToString()), num1, num, num5, flag4) : baseClass.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("multiple¶", num4.ToString()), num1, num, num5, flag4));
                                    }
                                    else
                                    {
                                        flag3 = true;
                                    }
                                }
                                if (!flag3)
                                {
                                    str = string.Concat(str, "false");
                                }
                                else
                                {
                                    str = string.Concat(str, "true");
                                    if (base.Session["IsUpdateKingsQty"] == null)
                                    {
                                        flag1 = false;
                                    }
                                    else
                                    {
                                        if (base.Session["IsUpdateKingsQty"].ToString() != "true")
                                        {
                                            continue;
                                        }
                                        flag1 = true;
                                    }
                                }
                            }
                            else
                            {
                                str = string.Concat(str, "true");
                            }
                        }
                    }
                }
            }
        }
        if (str.Contains("false"))
        {
            return false;
        }
        EstimateBasePage.DeliveryNoteStatusUpdate(CompanyID, StatusID, ID);
        this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate(ID, Module);
        this.commcls.SendInternalMailOnModuleStatusChange(Convert.ToInt32(CompanyID), ID, Convert.ToInt32(StatusID), Module);

        if (flag1)
        {
            if (empty.ToLower() == "o")
            {
                this.objBase.UpdateKingsQtySent(num3, num);
            }
            else if (empty.ToLower() != "m")
            {
                this.objBase.UpdateKingsQtySent(num2, num1);
            }
            else if (base.Session["PriceCatalogueID_othermultiple"] != null)
            {
                this.objBase.UpdateKingsQtySent(Convert.ToInt64(base.Session["PriceCatalogueID_othermultiple"].ToString()), num);
            }
        }
        if (ID > (long)0)
        {
            long num6 = (long)0;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            chrArray = new char[] { '\u00A7' };
            string[] strArrays = StockValue.Split(chrArray);
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '‡' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '«' });
                    if (strArrays2[0] == "DeliveryItemID")
                    {
                        num6 = (strArrays2[1] != "" ? Convert.ToInt64(strArrays2[1].ToString()) : (long)0);
                    }
                    if (strArrays2[0] == "ItemID")
                    {
                        if (strArrays2[1] != "")
                        {
                            Convert.ToInt64(strArrays2[1].ToString());
                        }
                    }
                    else if (strArrays2[0] == "ItemType")
                    {
                        empty1 = (strArrays2[1] != "" ? strArrays2[1] : "D");
                    }
                    else if (strArrays2[0] == "ItemQty")
                    {
                        if (strArrays2[1] != "")
                        {
                            strArrays2[1].ToString();
                        }
                    }
                    else if (strArrays2[0] == "ItemDesc" && !(strArrays2[1] == ""))
                    {
                        string str3 = strArrays2[1];
                    }
                }
                if (base.Session["ProductStockManagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
                {
                    BaseClass baseClass1 = new BaseClass();
                    if (baseClass1.Return_StockManagementSettings("SR_WhenStockReduced") == "d" && baseClass1.Return_StockManagementSettings("SR_JobStatusID") == StatusID.ToString().Trim() && (empty1.ToLower() == "c" || empty1.ToLower() == "x"))
                    {
                        enumerator = baseClass1.StockReductionForDeliveryItem(num6).Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow current = (DataRow)enumerator.Current;
                                long num7 = Convert.ToInt64(current["PriceCatalogueID"].ToString());
                                long num8 = Convert.ToInt64(current["PriceCatalogueID2"].ToString());
                                long num9 = Convert.ToInt64(current["EstimateItemID"].ToString());
                                string str4 = current["DrawStockFrom"].ToString();
                                int num10 = Convert.ToInt32(current["Quantity"].ToString());
                                int num11 = Convert.ToInt32(current["DelItemQuantity"].ToString());
                                bool flag5 = false;
                                if (empty1.ToLower() == "x")
                                {
                                    flag5 = Convert.ToBoolean(current["IsstockReplenish"]);
                                }
                                if (str4.ToLower() != "s" && str4.ToLower() != "a" && str4.ToLower() != "m")
                                {
                                    if (str4.ToLower() != "o")
                                    {
                                        continue;
                                    }
                                    string str5 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                    string str6 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                    string empty4 = string.Empty;
                                    if (!(empty1.ToLower() == "x") || !(flag5.ToString().ToLower() != "true"))
                                    {
                                        if (empty1.ToLower() != "c")
                                        {
                                            continue;
                                        }
                                        baseClass1.StockAllocation_Others(CompanyID, num8, num, string.Concat(str5, "¶", num6.ToString()), Convert.ToBoolean(str6), num9, "Job", new decimal(0), (long)Convert.ToInt32(base.Session["UserID"].ToString()));
                                        empty3 = string.Concat(empty3, baseClass1.IsDeliveryItemStatusChanges_Kit(CompanyID, num7, num8, "other", num1, num, num9), ",");
                                        objArray = new object[] { "other~", num8, "~", num9, "~", num, "~", empty3, "~", empty1 };
                                        this.KitStockValues = string.Concat(objArray);
                                    }
                                    else
                                    {
                                        baseClass1.StockAllocation_Others(CompanyID, num8, num, string.Concat(str5, "¶", num6.ToString()), Convert.ToBoolean(str6), num9, "Job", new decimal(0), (long)Convert.ToInt32(base.Session["UserID"].ToString()));
                                        empty3 = string.Concat(empty3, baseClass1.IsDeliveryItemStatusChanges_Kit(CompanyID, num7, num8, "other", num1, num, num9), ",");
                                        objArray = new object[] { "other~", num8, "~", num9, "~", num, "~", empty3, "~", empty1 };
                                        this.KitStockValues = string.Concat(objArray);
                                    }
                                }
                                else if (num11 > num10)
                                {
                                    flag = false;
                                    return flag;
                                }
                                else
                                {
                                    if (empty1.ToLower() == "c")
                                    {
                                        base.Session["StockItemType"] = "C";
                                    }
                                    else if (empty1.ToLower() == "x")
                                    {
                                        base.Session["StockItemType"] = "X";
                                        base.Session["ALC_OrderItemId"] = current["OrderItemID"].ToString();
                                    }
                                    if (this.objBase.DeliveryItemID_Reduction_Check(num6))
                                    {
                                        continue;
                                    }
                                    if (str4.ToLower() == "s")
                                    {
                                        if (!(empty1.ToLower() == "x") || !(flag5.ToString().ToLower() != "true"))
                                        {
                                            if (empty1.ToLower() != "c")
                                            {
                                                continue;
                                            }
                                            baseClass1.StockReductionProcess(CompanyID, num7, (long)0, string.Concat("self¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                        }
                                        else
                                        {
                                            baseClass1.StockReductionProcess(CompanyID, num7, (long)0, string.Concat("self¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                        }
                                    }
                                    else if (str4.ToLower() != "a")
                                    {
                                        if (str4.ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        if (!(empty1.ToLower() == "x") || !(flag5.ToString().ToLower() != "true"))
                                        {
                                            if (empty1.ToLower() != "c")
                                            {
                                                continue;
                                            }
                                            baseClass1.StockReductionProcess(CompanyID, num7, (long)0, string.Concat("multiple¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                        }
                                        else
                                        {
                                            baseClass1.StockReductionProcess(CompanyID, num7, (long)0, string.Concat("multiple¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                        }
                                    }
                                    else if (!(empty1.ToLower() == "x") || !(flag5.ToString().ToLower() != "true"))
                                    {
                                        if (empty1.ToLower() != "c")
                                        {
                                            continue;
                                        }
                                        baseClass1.StockReductionProcessForAdditionalOption(CompanyID, num7, string.Concat("additional option¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                    }
                                    else
                                    {
                                        baseClass1.StockReductionProcessForAdditionalOption(CompanyID, num7, string.Concat("additional option¶", num6.ToString()), num11, num9, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                                    }
                                }
                            }
                            goto Label0;
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                        //return flag;
                    }
                }
            Label0:
                int ii = 0;
            }

        }
        if (base.Session["ProductStockManagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
        {
            BaseClass baseClass2 = new BaseClass();
            if (baseClass2.Return_StockManagementSettings("SR_WhenStockReduced") == "d" && baseClass2.Return_StockManagementSettings("SR_JobStatusID") == StatusID.ToString() && this.KitStockValues != "" && this.KitStockValues != null)
            {
                string kitStockValues = this.KitStockValues;
                chrArray = new char[] { '~' };
                string[] strArrays3 = kitStockValues.Split(chrArray);
                string str7 = strArrays3[0];
                long num12 = Convert.ToInt64(strArrays3[1].ToString());
                long num13 = Convert.ToInt64(strArrays3[2].ToString());
                int num14 = Convert.ToInt32(strArrays3[3].ToString());
                string str8 = strArrays3[4];
                string str9 = strArrays3[5];
                if (!str8.ToLower().Contains("false"))
                {
                    if (str9.ToLower() == "c")
                    {
                        base.Session["StockItemType"] = "C";
                    }
                    else if (str9.ToLower() == "x")
                    {
                        base.Session["StockItemType"] = "X";
                    }
                    baseClass2.StockReductionProcess(CompanyID, (long)0, num12, "other", num14, num13, "DeliveryItem", (long)Convert.ToInt32(base.Session["UserID"].ToString()), new decimal(0));
                }
                else if (DeliveryBasePage.Allcn_Check(num13) != (long)-1)
                {
                    return false;
                }
                this.KitStockValues = "";
            }
        }

        this.commcls.SendMailOnDeliveryStatusChange(Convert.ToInt64(CompanyID), Convert.ToInt64(ID), StatusID, Module);
        return true;
    }

    [WebMethod(EnableSession = true)]
    public long Estimate_Items_Copy(long EstimateID, long EstimateItemID, string EstimateType, string Module, string ddlStatusVal, string isStock_Reduce)
    {
        if (isStock_Reduce.ToString() == "1")
        {
            this.SummaryClassObj.isStock_Reduce = true;
        }
        return this.SummaryClassObj.CopyItem_ForEstItemID(EstimateID, EstimateItemID, EstimateType, Module, ddlStatusVal);
    }

    [WebMethod(EnableSession = true)]
    public void Estimate_Items_Delete(int CompanyID, long EstimateItemID, string Estimatetype, long EstimateID, string Module, string ItemTitle, bool KeepEstimateLive)
    {
        EstimatesBasePage.EstimateItem_Delete(CompanyID, EstimateItemID, Module, KeepEstimateLive);
        EstimatesBasePage.estimate_EstTotalPriceDetails_Update(EstimateItemID);
    }

    [WebMethod(EnableSession = true)]
    public bool EstJobInvIduvidualItemStatuS_Update(int CompanyID, long estimateItemID, long EstimateID, int StatusID, string Module)
    {
        bool flag = true;
        long num = (long)0;
        foreach (DataRow row in JobBasePage.QuickLinks_ItemDetials_Select(CompanyID, estimateItemID).Rows)
        {
            num = Convert.ToInt64(row["JobID"]);
        }
        BaseClass baseClass = new BaseClass();
        string str = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
        string str1 = baseClass.Return_StockManagementSettings("SR_JobStatusID");
        string str2 = baseClass.Return_StockManagementSettings("SA_JobStatusID");
        baseClass.Return_StockManagementSettings("StatusMessage");
        string str3 = baseClass.Return_StockManagementSettings("SA_EstoreJobStatusID");
        string str4 = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
        string str5 = baseClass.Return_StockManagementSettings("Replenish_JobStatusID");
        if (this.InventoryManagement == "IM")
        {
            this.ReduceStockType = this.commcls.Settings_inventoryStockReduction_Select((long)CompanyID);
            this.ReduceStockTypeForCancelled = this.commcls.Settings_inventoryStockReduction_CancelledJob((long)CompanyID);
        }
        if ((!(Module == "job") || !(this.ReduceStockType.ToString() == StatusID.ToString())) && !(str1 == StatusID.ToString()) && !(str2 == StatusID.ToString()) && !(str3 == StatusID.ToString()) && (!(Module == "job") || !(str5 == StatusID.ToString())))
        {
            EstimatesBasePage.EstimateItemsOnCheck_Status_Update(CompanyID, estimateItemID.ToString(), StatusID, Module.ToLower());
            if (Module.ToLower() == "job")
            {
                this.commcls.SendMailOnJobStatusChange_Item(CompanyID, EstimateID, StatusID, Module, estimateItemID, (long)0);
                this.commcls.NewMailOnJobStatusChange(CompanyID, EstimateID, StatusID, Module);
                this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, StatusID, Module);
            }
            else if(Module.ToLower() == "estimate")
            {
                this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, StatusID, Module);
            }
            this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(estimateItemID, Module);
        }
        else
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("EstimateItemID", typeof(long));
            dataTable.Columns.Add("RequiredQty", typeof(int));
            dataTable.Columns.Add("PriceCatalogueID", typeof(long));
            dataTable.Columns.Add("AvailableQty", typeof(int));
            dataTable.Columns.Add("IsBackOrder", typeof(bool));
            dataTable.Columns.Add("ProductType", typeof(string));
            dataTable.Columns.Add("IsStockTransacted", typeof(string));
            dataTable.Columns.Add("Is_Item_BackOrder", typeof(bool));
            dataTable.Columns.Add("IsStockReplenishItem", typeof(bool));
            dataTable.Columns.Add("AllocatedQty", typeof(int));
            dataTable.Columns.Add("TotalQuantity", typeof(int));
            if (!(Module == "job") || !(str5 == StatusID.ToString()))
            {
                foreach (DataRow dataRow in EstimatesBasePage.Get_EstimateItems_Type_PriceCatalogue(EstimateID).Rows)
                {
                    if (estimateItemID != Convert.ToInt64(dataRow["EstimateItemID"]))
                    {
                        continue;
                    }
                    DataTable detailsEstimateItemsPriceCatalogueType = EstimatesBasePage.Get_Details_EstimateItems_PriceCatalogueType(Convert.ToInt64(dataRow["EstimateItemID"]), Convert.ToInt32(dataRow["QtyNumber"]));
                    foreach (DataRow row1 in detailsEstimateItemsPriceCatalogueType.Rows)
                    {
                        if (row1["DrawStockFrom"].ToString().ToLower() != "s")
                        {
                            if (row1["DrawStockFrom"].ToString().ToLower() != "o")
                            {
                                continue;
                            }
                            DataTable kitDetailsEstimateItemsPriceCatalogueType = EstimatesBasePage.Get_KitDetails_EstimateItems_PriceCatalogueType(Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]));
                            foreach (DataRow dataRow1 in kitDetailsEstimateItemsPriceCatalogueType.Rows)
                            {
                                DataRowCollection rows = dataTable.Rows;
                                object[] objArray = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(dataRow1["ReqQuantity"]), Convert.ToInt64(dataRow1["KitItemID"]), Convert.ToInt32(dataRow1["AvailableQuantity"]), Convert.ToBoolean(dataRow1["IsBackOrder"]), dataRow1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]), Convert.ToBoolean(row1["IsStockReplenishItem"]), Convert.ToInt32(dataRow1["AllocatedQuantity"]), Convert.ToInt32(dataRow1["TotalQuantity"]) };
                                rows.Add(objArray);
                            }
                        }
                        else
                        {
                            DataRowCollection dataRowCollection = dataTable.Rows;
                            object[] num1 = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(row1["Quantity"]), Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["AvailableQuantity"]), Convert.ToBoolean(row1["IsBackOrder"]), row1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]), Convert.ToBoolean(row1["IsStockReplenishItem"]), Convert.ToInt32(row1["AllocatedQuantity"]), Convert.ToInt32(row1["TotalQuantity"]) };
                            dataRowCollection.Add(num1);
                        }
                    }
                }
                foreach (DataRow row2 in dataTable.Rows)
                {
                    if (row2["IsStockTransacted"].ToString().Trim() != "")
                    {
                        continue;
                    }
                    DataRow[] dataRowArray = dataTable.Select(string.Concat(" PriceCatalogueID=", row2["PriceCatalogueID"].ToString(), " and IsStockTransacted=''"));
                    int num2 = Convert.ToInt32(row2["AvailableQty"]);
                    DataRow[] dataRowArray1 = dataRowArray;
                    for (int i = 0; i < (int)dataRowArray1.Length; i++)
                    {
                        DataRow dataRow2 = dataRowArray1[i];
                        dataRow2["AvailableQty"] = num2 - Convert.ToInt32(row2["RequiredQty"]);
                    }
                }
                dataTable.AcceptChanges();
                foreach (DataRow row3 in dataTable.Rows)
                {
                    if (str2 == StatusID.ToString())
                    {
                        if (!(row3["IsStockTransacted"].ToString() == "") || Convert.ToInt32(row3["AvailableQty"]) >= 0 || !(row3["IsBackOrder"].ToString().ToLower() == "false"))
                        {
                            continue;
                        }
                        flag = false;
                        break;
                    }
                    else if (row3["IsStockTransacted"].ToString() != "")
                    {
                        //if (!(row3["IsStockTransacted"].ToString().ToLower() == "allocated") || !(row3["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(row3["AvailableQty"]) >= 0)
                        if (!(row3["IsStockTransacted"].ToString().ToLower() == "allocated") || !(row3["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(row3["AllocatedQty"]) >= Convert.ToInt32(row3["RequiredQty"]))
                        {
                            if (!(Convert.ToInt32(row3["TotalQuantity"]) >= Convert.ToInt32(row3["RequiredQty"])))
                            {
                                flag = false;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        flag = false;
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(row3["AvailableQty"]) >= 0)
                        {
                            continue;
                        }
                        if (Convert.ToBoolean(row3["IsStockReplenishItem"] = true))
                        {
                            flag = true;
                            break;
                        }
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                EstimatesBasePage.EstimateItemsOnCheck_Status_Update(CompanyID, estimateItemID.ToString(), StatusID, Module.ToLower());
                string empty = string.Empty;
                if (Module.ToLower() == "job")
                {
                    empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(num, "jobs");
                    if (empty.ToLower() == "yes")
                    {
                        if (str4 == "j" && str3 == StatusID.ToString())
                        {
                            this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num, (long)0);
                        }
                        if (str == "j" && str1 == StatusID.ToString())
                        {
                            this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num, (long)0);
                        }
                        if (StatusID.ToString() == str5)
                        {
                            this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num, (long)0);
                        }
                    }
                }
                if (empty.ToLower() != "yes")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num, (long)0);
                }
                if (Module.ToLower() == "job")
                {
                    this.commcls.SendMailOnJobStatusChange_Item(CompanyID, EstimateID, StatusID, Module, estimateItemID, (long)0);
                    this.commcls.NewMailOnJobStatusChange(CompanyID, EstimateID, StatusID, Module);
                    this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, StatusID, Module);
                }
                else if (Module.ToLower() == "estimate")
                {
                    this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, EstimateID, StatusID, Module);
                }
                this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(estimateItemID, Module);
            }
        }
        if (Module.ToLower() == "estimate" || Module.ToLower() == "job" || Module.ToLower() == "invoice" || Module.ToLower() == "order")
        {
            string itemType = EstimatesBasePage.GetEstimateType_EstimateItemID(estimateItemID);
            if (itemType == "C" || itemType == "X")
            {
                if (commonClass.CheckFTPEnable())
                {
                    string filePath = string.Empty;
                    var settings = SettingsBasePage.LoadFtpRouteSettings(CompanyID);
                    var product = itemType == "X"
                        ? settings.FirstOrDefault(s => s.SectionName == "OnlineOrder")
                        : settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                    int _statusID = product.StatusValue;
                    if (_statusID == StatusID)
                    {
                        long priceCatalogurID = EstimatesBasePage.GetPriceCatalogueIDByEstimateItemID(estimateItemID);
                        //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, CompanyID);
                        DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, CompanyID);
                        if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                        {
                            if(dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                            {
                                object[] editableTemplatePath;
                                if (itemType == "X")
                                {
                                    DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(estimateItemID);
                                    editableTemplatePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                }
                                else
                                {
                                    editableTemplatePath = new object[] { this.EditableTemplatePath, CompanyID, "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                }
                                filePath = string.Concat(editableTemplatePath);
                            }
                            else
                            {
                                string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, CompanyID.ToString());
                                filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                            }
                            if (Module.ToLower() == "estimate")
                            {
                                commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "EstimateStatus", "ProductEstimate", estimateItemID);
                            }
                            else if(Module.ToLower() == "job")
                            {
                                if(itemType == "X")
                                {
                                    commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "OnlineOrder", estimateItemID);
                                }
                                else
                                {
                                    commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "ProductEstimate", estimateItemID);
                                }
                            }
                            else if (Module.ToLower() == "order")
                            {
                                commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "OrderStatus", "OnlineOrder", estimateItemID);
                            }
                            else
                            {
                                if (itemType == "X")
                                {
                                    commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "OnlineOrder", estimateItemID);
                                }
                                else
                                {
                                    commonClass.UploadPrintReadyFileToSftp(CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "ProductEstimate", estimateItemID);
                                }
                            }
                        }
                    }
                }

            }
        }
        return flag;
    }
    [WebMethod(EnableSession = true)]
    public bool ProofItemStatuS_Update(int CompanyID, long estimateItemID, int StatusID, string Module, int ProofID,int ProofItemID)
    {
        bool flag = true;
        EstimateBasePage.Proof_ItemStatus_Update(CompanyID, estimateItemID, StatusID, Module, ProofID,ProofItemID);
        this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, ProofID, StatusID, Module);
        return flag;
    }
    [WebMethod(EnableSession = true)]
    public bool UpdateProofStatus(int companyID, int ddlStatusID, string Module, int UserId, long ModuleID)
    {
        bool flag = true;
        EstimateBasePage.Proof_Status_Update(companyID, ddlStatusID, Module, ModuleID);
        this.commcls.SendInternalMailOnModuleStatusChange(CompanyID, ModuleID, ddlStatusID, Module);
        return flag;

    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(EnableSession = true)]
    public void InventoryStockBackOn_itemDelete(int companyID, long EstimateID, long estimateItemID, int UserId)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", EstimateID, companyID, estimateItemID, num);
    }

    [WebMethod(EnableSession = true)]
    public void InventoryStockBackOn_itemDelete_EstOrder(int companyID, long EstimateID, long estimateItemID, int UserId, string Estimatetype, string Module, string ItemTitle, bool KeepEstimateLive)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", EstimateID, companyID, estimateItemID, num);
        EstimatesBasePage.EstimateItem_Delete(this.CompanyID, estimateItemID, Module, KeepEstimateLive);
        EstimatesBasePage.estimate_EstTotalPriceDetails_Update(estimateItemID);
    }

    [WebMethod(EnableSession = true)]
    public void Job_Item_Revart(long EstimateItemID)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        int num1 = 0;
        if (base.Session["CompanyID"] != null)
        {
            num1 = Convert.ToInt32(base.Session["CompanyID"].ToString());
        }
        JobsBasePage.Job_Item_Revart(EstimateItemID, (long)num1, (long)num);
    }

    [WebMethod(EnableSession = true)]
    public void LockItemStatus(long EstimateItemID, string Module)
    {
        EstimatesBasePage.LockItemStatus(EstimateItemID, Module);
    }

    [WebMethod(EnableSession = true)]
    public void SaveItemPriceDetails(long EstimateID, long EstimateItemID, long SectionID, string EstimateType, decimal TotalProfitMarginPercentage1, decimal TotalProfitMarginPercentage2, decimal TotalProfitMarginPercentage3, decimal TotalProfitMarginPercentage4, decimal TotalProfitMarginPrice1, decimal TotalProfitMarginPrice2, decimal TotalProfitMarginPrice3, decimal TotalProfitMarginPrice4, decimal TotalSubTotal1, decimal TotalSubTotal2, decimal TotalSubTotal3, decimal TotalSubTotal4, int TotalTaxID1, int TotalTaxID2, int TotalTaxID3, int TotalTaxID4, decimal TotalTaxPercentage1, decimal TotalTaxPercentage2, decimal TotalTaxPercentage3, decimal TotalTaxPercentage4, decimal TotalTaxPrice1, decimal TotalTaxPrice2, decimal TotalTaxPrice3, decimal TotalTaxPrice4, decimal TotalSellingPrice1, decimal TotalSellingPrice2, decimal TotalSellingPrice3, decimal TotalSellingPrice4, decimal TotalGrossProfitPercentage1, decimal TotalGrossProfitPercentage2, decimal TotalGrossProfitPercentage3, decimal TotalGrossProfitPercentage4, decimal TotalGrossProfitPrice1, decimal TotalGrossProfitPrice2, decimal TotalGrossProfitPrice3, decimal TotalGrossProfitPrice4, bool IsSubTotalLocked, decimal SellingPricePerSQM1, decimal SellingPricePerSQM2, decimal SellingPricePerSQM3, decimal SellingPricePerSQM4, decimal SubTotalUnitPrice1, decimal SubTotalUnitPrice2, decimal SubTotalUnitPrice3, decimal SubTotalUnitPrice4)
    {
        EstimatesBasePage.estimate_item_total_price_details_update(EstimateID, EstimateItemID, SectionID, EstimateType, TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4, TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4, TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4, TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4, TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4, TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4, TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4, TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4, TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4, IsSubTotalLocked, SellingPricePerSQM1, SellingPricePerSQM2, SellingPricePerSQM3, SellingPricePerSQM4, SubTotalUnitPrice1, SubTotalUnitPrice2, SubTotalUnitPrice3, SubTotalUnitPrice4);
    }

    [WebMethod(EnableSession = true)]
    public void StockBackOn_StatusUpdate(int companyID, long EstimateID, int UserId)
    {
        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-status", EstimateID, companyID, (long)0, UserId);
    }

    [WebMethod(EnableSession = true)]
    public void UnLockItemStatus(long EstimateItemID, string Module)
    {
        EstimatesBasePage.UnLockItemStatus(EstimateItemID, Module);
    }

    [WebMethod(EnableSession = true)]
    public void Update_eStoreOrderStatus(int CompanyID, long EstimateID, int ddlStatusID, string Module, int ModuleID, int AccountID)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        if (Module.ToLower() == "job")
        {
            if (AccountID == 0)
            {
                DataTable accountID = JobBasePage.GetAccountID(CompanyID, (long)ModuleID);
                if (accountID.Rows.Count > 0)
                {
                    AccountID = Convert.ToInt32(accountID.Rows[0]["accountid"]);
                }
            }
            int num1 = 0;
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(CompanyID, AccountID, (long)0, "Order Shipping", "Customer");
            foreach (DataRow row in customerSelect.Rows)
            {
                num1 = Convert.ToInt32(row["StatusID"].ToString());
            }
            if (ddlStatusID == num1)
            {
                long num2 = (long)0;
                foreach (DataRow dataRow in OrderBasePage.Order_select(CompanyID, EstimateID).Rows)
                {
                    num2 = Convert.ToInt64(dataRow["StoreUserID"]);
                }
                this.Objemail.emailOrdersDetails(num2, EstimateID, CompanyID, Convert.ToInt32(AccountID), "Order Shipping");
            }
            BaseClass baseClass = new BaseClass();
            string str = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
            string str1 = baseClass.Return_StockManagementSettings("SR_JobStatusID");
            string str2 = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
            string str3 = baseClass.Return_StockManagementSettings("SA_EstoreJobStatusID");
            string str4 = baseClass.Return_StockManagementSettings("Replenish_JobStatusID");
            if (str2 == "j" && str3 == ddlStatusID.ToString())
            {
                this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, (long)0, num, false, (long)ModuleID, (long)0);
            }
            if (str == "j" && str1 == ddlStatusID.ToString())
            {
                this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, (long)0, num, false, (long)ModuleID, (long)0);
            }
            if (ddlStatusID.ToString() == str4)
            {
                this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, (long)0, num, false, (long)ModuleID, (long)0);
            }
        }
        else if (Module.ToLower() == "webstoreorder")
        {
            BaseClass baseClass1 = new BaseClass();
            string str5 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
            string str6 = baseClass1.Return_StockManagementSettings("SR_JobStatusID");
            if (str5 == "o" && str6 == ddlStatusID.ToString() && base.Session["ProductStockManagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
            {
                this.SummaryClassObj.OrderStatusChange_StockReduction((long)ModuleID, CompanyID, (long)0, num);
            }
        }
        this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate((long)ModuleID, Module);
    }

    [WebMethod(EnableSession = true)]
    public void UpdateItemDescriptionInSummary(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string AllItemDescnValues, bool CopyCustomerDesnToSuplrDesn, bool ChkCopyPOState, bool ChkCopyDNState, string itemtitle, string module)
    {
        EstimateCommonMethods.EditUpdateIDescriptionsInSummary(CompanyID, EstimateID, EstimateItemID, EstimateType, AllItemDescnValues, CopyCustomerDesnToSuplrDesn, ChkCopyPOState, ChkCopyDNState, itemtitle, module);
    }

    [WebMethod(EnableSession = true)]
    public void UpdateProofItemDescriptionInSummary(int CompanyID, long EstimateID, long EstimateItemID,long ProofItemID, string EstimateType, string AllItemDescnValues, bool CopyCustomerDesnToSuplrDesn, bool ChkCopyPOState, bool ChkCopyDNState, string itemtitle, string module)
    {
        EstimateCommonMethods.UpdateProofItemDescriptionInSummary(CompanyID, EstimateID, EstimateItemID, ProofItemID, EstimateType, AllItemDescnValues, CopyCustomerDesnToSuplrDesn, ChkCopyPOState, ChkCopyDNState, itemtitle, module);
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateStatus(int companyID, long EstimateID, int ddlStatusID, string Module, int UserId, long ModuleID)
    {
        bool flag = true;
        BaseClass baseClass = new BaseClass();
        baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
        string str = baseClass.Return_StockManagementSettings("SR_JobStatusID");
        string str1 = baseClass.Return_StockManagementSettings("SA_JobStatusID");
        baseClass.Return_StockManagementSettings("StatusMessage");
        baseClass.Return_StockManagementSettings("SA_EstoreJobStatusID");
        baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
        string str2 = baseClass.Return_StockManagementSettings("Replenish_JobStatusID");


        string _url = HttpContext.Current.Request.UrlReferrer.ToString();
        if (_url.ToLower().Contains("test1.eprintsoftware.com"))
        {
            if (Module == "job" || Module == "order")
            {
                string UOSOrderID = string.Empty;
                string statusTitle = string.Empty;
                DataTable _dt = EstimateBasePage.GetAPIOrderID(EstimateID);
                foreach (DataRow dt in _dt.Rows)
                {
                    UOSOrderID = dt["API_UOSOrderID"].ToString();
                }
                if (!string.IsNullOrEmpty(UOSOrderID))
                {
                    DataTable _statusdt = EstimateBasePage.GetStatusDetails(ddlStatusID);
                    foreach (DataRow dr in _statusdt.Rows)
                    {
                        statusTitle = dr["StatusTitle"].ToString();
                    }
                    //string URI = "https://birchprint.yourdevwebsite.co.uk/wp-content/themes/OPSv3/api/hc-webhook.php";
                    //var _obj = new { ExternalOrderID = UOSOrderID, OrderStatus = statusTitle };
                    //string jsonData = "";
                    //jsonData = JsonConvert.SerializeObject(_obj);
                    //using (WebClient wc = new WebClient())
                    //{
                    //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    //    string HtmlResult = wc.UploadString(URI, jsonData);
                    //}


                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://birchprint.yourdevwebsite.co.uk/wp-content/themes/OPSv3/api/hc-webhook.php");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new

                    StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            ExternalOrderID = UOSOrderID,
                            OrderStatus = statusTitle
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }


                }

            }
        }
        if (this.InventoryManagement == "IM")
        {
            this.ReduceStockType = this.commcls.Settings_inventoryStockReduction_Select((long)companyID);
            this.ReduceStockTypeForCancelled = this.commcls.Settings_inventoryStockReduction_CancelledJob((long)companyID);
        }
        if ((!(Module == "job") || !(this.ReduceStockType.ToString() == ddlStatusID.ToString())) && !(str == ddlStatusID.ToString()) && !(str1 == ddlStatusID.ToString()) && (!(Module == "job") || !(str2 == ddlStatusID.ToString())))
        {
            EstimateBasePage.Estimate_Status_Update(companyID, EstimateID, ddlStatusID, Module, ModuleID);
            this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate(ModuleID, Module);
            if (Module.ToLower() == "job")
            {
                if (!ConnectionClass.IsSplitItem)
                {
                    this.commcls.SendMailOnJobStatusChange(companyID, EstimateID, ddlStatusID, Module);
                }
                else
                {
                    this.commcls.SendMailOnJobStatusChange_Item(companyID, EstimateID, ddlStatusID, Module, (long)0, ModuleID);
                    this.commcls.NewMailOnJobStatusChange(companyID, EstimateID, ddlStatusID, Module);
                }
                this.commcls.SendInternalMailOnModuleStatusChange(companyID, EstimateID, ddlStatusID, Module);
            }
            else if (Module.ToLower() == "estimate")
            {
                this.commcls.SendInternalMailOnModuleStatusChange(companyID, EstimateID, ddlStatusID, Module);
            }
            DataTable dataTable = new DataTable();
            dataTable = (Module.ToLower() != "job" ? InvoiceBasePage.InvoiceItem_EstimateItemID_Select(ModuleID, Module) : JobBasePage.JobItem_EstimateItemID_Select(ModuleID, "items"));
            if (ConnectionClass.IsSplitItem)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(Convert.ToInt64(row["EstimateItemID"]), Module);
                }
            }
        }
        else
        {
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("EstimateItemID", typeof(long));
            dataTable1.Columns.Add("RequiredQty", typeof(int));
            dataTable1.Columns.Add("PriceCatalogueID", typeof(long));
            dataTable1.Columns.Add("AvailableQty", typeof(int));
            dataTable1.Columns.Add("IsBackOrder", typeof(bool));
            dataTable1.Columns.Add("ProductType", typeof(string));
            dataTable1.Columns.Add("IsStockTransacted", typeof(string));
            dataTable1.Columns.Add("Is_Item_BackOrder", typeof(bool));
            dataTable1.Columns.Add("IsStockReplenishItem", typeof(bool));
            dataTable1.Columns.Add("AllocatedQty", typeof(int));
            dataTable1.Columns.Add("TotalQuantity", typeof(int));
            if (!(Module == "job") || !(str2 == ddlStatusID.ToString()))
            {
                foreach (DataRow dataRow in EstimatesBasePage.Get_EstimateItems_Type_PriceCatalogue(EstimateID).Rows)
                {
                    DataTable detailsEstimateItemsPriceCatalogueType = EstimatesBasePage.Get_Details_EstimateItems_PriceCatalogueType(Convert.ToInt64(dataRow["EstimateItemID"]), Convert.ToInt32(dataRow["QtyNumber"]));
                    foreach (DataRow row1 in detailsEstimateItemsPriceCatalogueType.Rows)
                    {
                        if (row1["DrawStockFrom"].ToString().ToLower() != "s")
                        {
                            if (row1["DrawStockFrom"].ToString().ToLower() != "o")
                            {
                                continue;
                            }
                            DataTable kitDetailsEstimateItemsPriceCatalogueType = EstimatesBasePage.Get_KitDetails_EstimateItems_PriceCatalogueType(Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]));
                            foreach (DataRow dataRow1 in kitDetailsEstimateItemsPriceCatalogueType.Rows)
                            {
                                DataRowCollection rows = dataTable1.Rows;
                                object[] num = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(dataRow1["ReqQuantity"]), Convert.ToInt64(dataRow1["KitItemID"]), Convert.ToInt32(dataRow1["AvailableQuantity"]), Convert.ToBoolean(dataRow1["IsBackOrder"]), dataRow1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]), Convert.ToBoolean(row1["IsStockReplenishItem"]), Convert.ToInt32(dataRow1["AllocatedQuantity"]), Convert.ToInt32(dataRow1["TotalQuantity"]) };
                                rows.Add(num);
                            }
                        }
                        else
                        {
                            DataRowCollection dataRowCollection = dataTable1.Rows;
                            object[] objArray = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(row1["Quantity"]), Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["AvailableQuantity"]), Convert.ToBoolean(row1["IsBackOrder"]), row1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]), Convert.ToBoolean(row1["IsStockReplenishItem"]), Convert.ToInt32(row1["AllocatedQuantity"]), Convert.ToInt32(row1["TotalQuantity"]) };
                            dataRowCollection.Add(objArray);
                        }
                    }
                }
                foreach (DataRow row2 in dataTable1.Rows)
                {
                    if (str1 != ddlStatusID.ToString())
                    {
                        if (row2["IsStockTransacted"].ToString().Trim() != "")
                        {
                            continue;
                        }
                        DataRow[] dataRowArray = dataTable1.Select(string.Concat(" PriceCatalogueID=", row2["PriceCatalogueID"].ToString(), " and IsStockTransacted=''"));
                        int num1 = Convert.ToInt32(row2["AvailableQty"]);
                        DataRow[] dataRowArray1 = dataRowArray;
                        for (int i = 0; i < (int)dataRowArray1.Length; i++)
                        {
                            DataRow num2 = dataRowArray1[i];
                            num2["AvailableQty"] = num1 - Convert.ToInt32(row2["RequiredQty"]);
                        }
                    }
                    else
                    {
                        if (row2["IsStockTransacted"].ToString().Trim() != "")
                        {
                            continue;
                        }
                        DataRow[] dataRowArray2 = dataTable1.Select(string.Concat(" PriceCatalogueID=", row2["PriceCatalogueID"].ToString(), " and IsStockTransacted=''"));
                        int num3 = Convert.ToInt32(row2["AvailableQty"]);
                        DataRow[] dataRowArray3 = dataRowArray2;
                        for (int j = 0; j < (int)dataRowArray3.Length; j++)
                        {
                            DataRow dataRow2 = dataRowArray3[j];
                            dataRow2["AvailableQty"] = num3 - Convert.ToInt32(row2["RequiredQty"]);
                        }
                    }
                }
                dataTable1.AcceptChanges();
                foreach (DataRow row3 in dataTable1.Rows)
                {
                    if (str1 == ddlStatusID.ToString())
                    {
                        if (!(row3["IsStockTransacted"].ToString() == "") || Convert.ToInt32(row3["AvailableQty"]) >= 0 || !(row3["IsBackOrder"].ToString().ToLower() == "false"))
                        {
                            continue;
                        }
                        flag = false;
                        break;
                    }
                    else if (row3["IsStockTransacted"].ToString() != "")
                    {
                        //if (!(row3["IsStockTransacted"].ToString().ToLower() == "allocated") || !(row3["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(row3["AvailableQty"]) >= 0)
                        if (!(row3["IsStockTransacted"].ToString().ToLower() == "allocated") || !(row3["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(row3["AllocatedQty"]) >= Convert.ToInt32(row3["RequiredQty"]))
                        {
                            if (Convert.ToInt32(row3["TotalQuantity"]) >= Convert.ToInt32(row3["RequiredQty"]) || Convert.ToInt32(row3["TotalQuantity"]) >= Convert.ToInt32(row3["AllocatedQty"])
                                || row3["IsStockTransacted"].ToString() != ("allocated")) 
                            {
                                continue;
                            }
                        }
                        flag = false;
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(row3["AvailableQty"]) >= 0)
                        {
                            continue;
                        }
                        if (Convert.ToBoolean(row3["IsStockReplenishItem"] = true))
                        {
                            flag = true;
                            break;
                        }
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                EstimateBasePage.Estimate_Status_Update(companyID, EstimateID, ddlStatusID, Module, ModuleID);
                this.SummaryClassObj.Call_Inventory_Adjustment("completed-status", EstimateID, companyID, (long)0, UserId);
                this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate(ModuleID, Module);
                if (Module.ToLower() == "job")
                {
                    if (ddlStatusID.ToString() == str2)
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, companyID, (long)0, UserId, false, ModuleID, (long)0);
                    }
                    if (!ConnectionClass.IsSplitItem)
                    {
                        this.commcls.SendMailOnJobStatusChange(companyID, EstimateID, ddlStatusID, Module);
                    }
                    else
                    {
                        this.commcls.SendMailOnJobStatusChange_Item(companyID, EstimateID, ddlStatusID, Module, (long)0, ModuleID);
                        this.commcls.NewMailOnJobStatusChange(companyID, EstimateID, ddlStatusID, Module);
                    }

                }
                DataTable dataTable2 = new DataTable();
                dataTable2 = (Module.ToLower() != "job" ? InvoiceBasePage.InvoiceItem_EstimateItemID_Select(ModuleID, Module) : JobBasePage.JobItem_EstimateItemID_Select(ModuleID, "items"));
                foreach (DataRow dataRow3 in dataTable2.Rows)
                {
                    this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(Convert.ToInt64(dataRow3["EstimateItemID"]), Module);
                }
            }
        }
        if (Module.ToLower() == "estimate" || Module.ToLower() == "job" || Module.ToLower() == "invoice" || Module.ToLower() == "order")
        {
            DataTable dt = EstimatesBasePage.GetPriceCatalogueIDByEstimateID(companyID, EstimateID);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["EstimateType"].ToString() == "C" || dr["EstimateType"].ToString() == "X")
                    {
                        if (commonClass.CheckFTPEnable())
                        {
                            string filePath = string.Empty;
                            var settings = SettingsBasePage.LoadFtpRouteSettings(companyID);
                            var product = dr["EstimateType"].ToString() == "X"
                             ? settings.FirstOrDefault(s => s.SectionName == "OnlineOrder")
                             : settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                            //var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                            int _statusID = product.StatusValue;
                            if (_statusID == ddlStatusID)
                            {
                                long priceCatalogurID = Convert.ToInt64(dr["PriceCatalogueID"].ToString());
                                //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, companyID);
                                DataTable dataTable6 =commonClass.Get_ProductFileByType(priceCatalogurID, companyID);
                                if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                                {
                                    if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                                    {
                                        object[] editableTemplatePath;
                                        if (dr["EstimateType"].ToString() == "X")
                                        {
                                            DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                            editableTemplatePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", companyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                        }
                                        else
                                        {
                                            editableTemplatePath = new object[] { this.EditableTemplatePath, companyID, "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                        }
                                        filePath = string.Concat(editableTemplatePath);
                                    }
                                    else
                                    {
                                        string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, companyID.ToString());
                                        filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                        //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, companyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                                    }
                                    if (Module.ToLower() == "estimate")
                                    {
                                        commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "EstimateStatus", "ProductEstimate", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                    }
                                    else if (Module.ToLower() == "job")
                                    {
                                        if(dr["EstimateType"].ToString() == "X")
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "JobStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                        }
                                        else
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "JobStatus", "ProductEstimate", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                        }
                                    }
                                    else if (Module.ToLower() == "order")
                                    {
                                        commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "OrderStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                    }
                                    else
                                    {
                                        if (dr["EstimateType"].ToString() == "X")
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                        }
                                        else
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(companyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "ProductEstimate", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                        }
                                    }
                                }
                            }
                        }

                    }

                }

            }
        }

        return flag;
    }


    [WebMethod(EnableSession = true)]
    public void WarehouseStockBackOn_itemDelete(int companyID, long EstimateID, long estimateItemID, int UserId)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock", EstimateID, companyID, estimateItemID, num);
    }

    [WebMethod(EnableSession = true)]
    public void WarehouseStockBackOn_itemDelete_EstOrder(int companyID, long EstimateID, long estimateItemID, int UserId, string Estimatetype, string Module, string ItemTitle, bool KeepEstimateLive)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        if (Module.ToLower() == "estimate" || Module.ToLower() == "invoice" || Module.ToLower() == "job")
        {
            this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock", EstimateID, companyID, estimateItemID, num);
        }
        else
        {
            this.SummaryClassObj.Call_Inventory_Adjustment_Order("cancelled-stock", EstimateID, companyID, estimateItemID, num);
        }
        EstimatesBasePage.EstimateItem_Delete(this.CompanyID, estimateItemID, Module, KeepEstimateLive);
        EstimatesBasePage.estimate_EstTotalPriceDetails_Update(estimateItemID);
    }

    [WebMethod(EnableSession = true)]
    public void WarehouseStockBackOn_itemDelete_Order(int companyID, long EstimateID, long estimateItemID, int UserId)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        this.SummaryClassObj.Call_Inventory_Adjustment_Order("cancelled-stock", EstimateID, companyID, estimateItemID, num);
    }

    [WebMethod(EnableSession = true)]
    public void WarehouseStockBackOn_StatusUpdate(int companyID, long EstimateID, int UserId)
    {
        int num = 0;
        if (base.Session["UserID"] != null)
        {
            num = Convert.ToInt32(base.Session["UserID"].ToString());
        }
        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock-status", EstimateID, companyID, (long)0, num);
    }

    [WebMethod(EnableSession = true)]
    public void PC_update_JobLocking_Status(long ID, Boolean Status)
    {

        EstimatesBasePage.PC_update_JobLocking_Status(ID, Status);

    }

    [WebMethod(EnableSession = true)]
    public void Create_proof(int CompanyID, long EstimateID, long ProofID, DateTime ProofDate)
    {
        EstimateBasePage.Create_proof(CompanyID, EstimateID, ProofID, ProofDate);
    }

    [WebMethod(EnableSession = true)]
    public string Get_Proof_History(int AttachmentID)
    {
        var data = EstimateBasePage.Get_Proof_History(AttachmentID);
        var AccessNotes = "";
        var History = "";
        //foreach (DataRow row in data.Rows)
        //{
        //    AccessNotes = row["AccessNotes"].ToString() + Environment.NewLine;
        //        + "ยง" + row["AccessByUser"].ToString() + "ยง" + BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("dd.MM.yyyy") + "ยง" + BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("dd.MM.yyyy");
        //}

        return History;
    }
    [WebMethod(EnableSession = true)]
    public string ChangeProofStatus(int EstimateID,string Status,int AttachmentID,int ProofID,int ProofItemID,int EstimateItemID,int Customerid,string HostName, bool IsTermsAndConditions = false)
    {
        string proofStatus = EstimateBasePage.GetProofStatus(ProofID, EstimateItemID, AttachmentID);
        string Comment = string.Empty;
        int UserID = Convert.ToInt32(base.Session["UserID"]);
        int _companyID = Convert.ToInt32(base.Session["CompanyID"]);
        if (Status == "Approved")
        {
            EstimateBasePage.UpdateProofStatus(ProofID, EstimateItemID, AttachmentID, Comment, Status, IsTermsAndConditions);
            EstimateBasePage.UpdateProofItemStatus(ProofID, EstimateItemID, Status);
            if (proofStatus != "Approved")
            {
                DataTable dt = EstimateBasePage.Get_SecondApprover_EmailAndName(ProofItemID);
                string name = string.Empty;
                string email = string.Empty;
                string proofApproval = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    proofApproval = dr["Two_Stage_Approval"].ToString();
                    name = dr["SecondApproverName"].ToString();
                    email = dr["SecondApproverEmail"].ToString();
                }
                //if (proofApproval.ToLower() == "true" && !string.IsNullOrEmpty(email))
                //{
                //    BaseClass.SendMailMessageSecondApprover(ProofID, ConnectionClass.ServerName, _companyID, true,HostName, UserID, Customerid, EstimateID, name, email);
                //}
            }
        }
        else
        {
            EstimateBasePage.UpdateProofStatus(ProofID, EstimateItemID, AttachmentID, Comment, Status, IsTermsAndConditions);
            EstimateBasePage.UpdateProofItemStatus(ProofID, EstimateItemID, Status);
            //BaseClass.SendProofMailMessage(ProofID, ConnectionClass.ServerName, _companyID, true, Comment, Status, Convert.ToInt64(EstimateID));
        }
        
        int approvalCount = EstimateBasePage.GetApprovalCount(ProofID, EstimateItemID, AttachmentID, ProofItemID);
        if(approvalCount == -1)
        {
            if(proofStatus != "Approved")
            {
                try
                {
                    EstimateBasePage.InsertProofAttachmentHistory(ProofID, EstimateItemID, ProofItemID, AttachmentID, Comment, Status, UserID,_companyID);
                    notesclass objnotes = new notesclass();
                    Notes _notes = new Notes();
                    commonClass _commonClass = new commonClass();
                    objnotes.Item_number = "";
                    if(Status == "Approved")
                    {
                        objnotes.NotesType = Convert.ToString(Notes.NotesType.ManualProofApproval);
                    }
                    else
                    {
                        objnotes.NotesType = Convert.ToString(Notes.NotesType.ManualProofRejection);
                    }
                    objnotes.ItemID = (long)Convert.ToInt32(ProofItemID);
                    objnotes.ModuleName = "Proof";
                    UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                    objnotes.ModuleID = ProofID;
                    objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass = objnotes;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(),_companyID, UserID, true);
                    objnotes.CompanyID = _companyID;
                    objnotes.UserID = UserID;
                    _notes.NotesAdd(objnotes);
                    if (string.IsNullOrEmpty(Status))
                    {
                        Status = EstimateBasePage.GetProofStatus(ProofID, EstimateItemID, AttachmentID);
                        //BaseClass.SendProofMailMessage(ProofID, ConnectionClass.ServerName, _companyID, true, Comment, Status, 0);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                return "This file proof has already been approved.";
            }
        }
        else
        {
            if (approvalCount < 2)
            {
                try
                {
                    EstimateBasePage.InsertProofAttachmentHistory(ProofID, EstimateItemID, ProofItemID, AttachmentID, Comment, Status, UserID,_companyID);
                    if (string.IsNullOrEmpty(Status))
                    {
                        Status = EstimateBasePage.GetProofStatus(ProofID, EstimateItemID, AttachmentID);
                        //BaseClass.SendProofMailMessage(ProofID, ConnectionClass.ServerName, _companyID, true, Comment, Status, 0);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                return "This file proof has already been approved.";
            }
        }
        
       
        return "";
    }


}
//}