using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

[ScriptService]
[WebService(Namespace="http://www.eprintsoftware.com/")]
[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
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

	public item_summary()
	{
	}

	[WebMethod(EnableSession=true)]
	public void Delete_PODeliverynote_for_RevertJob(long CompanyID, long EstimateID, int DeletePO, int DeleteDel, string Type)
	{
		JobsBasePage.Delete_PODeliverynote_for_RevertJob(CompanyID, EstimateID, DeletePO, DeleteDel, Type);
	}

	[WebMethod(EnableSession=true)]
	public void DeleteSubItems(string EstimateType, long EstimateItemID, long ItemTypeID, long EstimateID, string Module, long ParentEstimateItemID)
	{
		if (string.IsNullOrEmpty(Convert.ToString(base.Session["CompanyID"])))
		{
			this.objBase.Session_Check();
		}
		if (string.Compare(Module, "invoice", true) == 0 || string.Compare(Module, "job", true) == 0)
		{
			int num = Convert.ToInt32(base.Session["CompanyID"]);
			EstimateCommonMethods.ShowJobCardDetails(num, EstimateID, EstimateItemID, "S");
			if (string.Compare(Module, "job", true) == 0)
			{
				long num1 = (long)0;
				foreach (DataRow row in JobBasePage.QuickLinks_ItemDetials_Select(num, ParentEstimateItemID).Rows)
				{
					num1 = Convert.ToInt64(row["JobID"]);
				}
				this.SummaryClassObj.Call_Inventory_Adjustment_Job("cancelled-stock-delete", EstimateID, num, ParentEstimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num1, (long)0);
			}
		}
		this.SummaryClassObj.Insert_ActivityHistory_OnSubItemDelete(EstimateID, EstimateItemID, EstimateType, Module, ParentEstimateItemID);
		EstimatesBasePage.estimate_sub_item_delete(EstimateType, EstimateItemID, ItemTypeID);
		EstimatesBasePage.estimate_EstTotalPriceDetails_Update(EstimateItemID);
	}

	[WebMethod(EnableSession=true)]
	public string DeliveryPurchase_Check(int CompanyID, long JobID, long EstimateItemID)
	{
		DataSet dataSet = EstimateBasePage.DeliveryPurchase_Check(CompanyID, JobID, EstimateItemID);
		string empty = string.Empty;
		empty = (dataSet.Tables[0].Rows.Count != 0 ? string.Concat(empty, "true«") : string.Concat(empty, "false«"));
		empty = (dataSet.Tables[1].Rows.Count != 0 ? string.Concat(empty, "true") : string.Concat(empty, "false«"));
		return empty;
	}

	[WebMethod(EnableSession=true)]
	public bool DelNoteCarInfoUpdate(long CompanyID, string Module, long CarInfoID, long ID)
	{
		EstimateBasePage.DeliveryNoteCarInfoUpdate(CompanyID, CarInfoID, ID);
		this.SummaryClassObj.Insert_ActivityHistory_CarInfoUpdate(ID, Module);
		return true;
	}

	[WebMethod(EnableSession=true)]
	public bool DelPurchaseOrdStatusUpdate(long CompanyID, string Module, long StatusID, long ID, string StockValue)
	{
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
		bool flag = false;
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
						foreach (DataRow dataRow in this.objBase.StockReductionForDeliveryItemNew(num4).Rows)
						{
							num2 = Convert.ToInt64(dataRow["PriceCatalogueID"].ToString());
							long num5 = Convert.ToInt64(dataRow["EstimateItemID"].ToString());
							empty = dataRow["DrawStockFrom"].ToString();
							num = Convert.ToInt32(dataRow["Quantity"].ToString());
							num1 = Convert.ToInt32(dataRow["DelItemQuantity"].ToString());
							bool flag1 = false;
							if (str1.ToLower() == "x")
							{
								flag1 = Convert.ToBoolean(dataRow["IsstockReplenish"]);
							}
							bool flag2 = false;
							bool flag3 = false;
							if (empty.Trim().ToLower() == "o")
							{
								empty = "s";
								flag3 = true;
							}
							if (empty.ToLower() == "s" || empty.ToLower() == "o" || empty.ToLower() == "a" || empty.ToLower() == "m")
							{
								if (empty.ToLower() == "s")
								{
									if (str1.ToLower() == "x" && flag1.ToString().ToLower() == "true")
									{
										flag2 = true;
									}
									else if (str1.ToLower() == "x" && flag1.ToString().ToLower() != "true")
									{
										flag2 = this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("self¶", num4.ToString()), num1, num, num5, flag3);
									}
									else if (str1.ToLower() == "c")
									{
										flag2 = this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("self¶", num4.ToString()), num1, num, num5, flag3);
									}
								}
								else if (empty.ToLower() == "o")
								{
									num3 = Convert.ToInt64(dataRow["PriceCatalogueID2"].ToString());
									if (str1.ToLower() == "x" && flag1.ToString().ToLower() == "true")
									{
										flag2 = true;
									}
									else if (str1.ToLower() == "x" && flag1.ToString().ToLower() != "true")
									{
										flag2 = this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, num3, string.Concat("other¶", num4.ToString()), num1, num, num5, flag3);
									}
									else if (str1.ToLower() == "c")
									{
										flag2 = this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, num3, string.Concat("other¶", num4.ToString()), num1, num, num5, flag3);
									}
								}
								else if (empty.ToLower() == "a")
								{
									base.Session["StockItemType"] = str1.ToLower();
									base.Session["ALC_OrderItemId"] = dataRow["OrderItemID"].ToString();
									if (!(str1.ToLower() == "x") || !(flag1.ToString().ToLower() == "true"))
									{
										flag2 = (!(str1.ToLower() == "x") || !(flag1.ToString().ToLower() != "true") ? this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("additional option¶", num4.ToString()), num1, num, num5, flag3) : this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("additional option¶", num4.ToString()), num1, num, num5, flag3));
									}
									else
									{
										flag2 = true;
									}
								}
								else if (empty.ToLower() == "m")
								{
									base.Session["StockItemType"] = str1.ToLower();
									base.Session["ALC_OrderItemId"] = dataRow["OrderItemID"].ToString();
									if (!(str1.ToLower() == "x") || !(flag1.ToString().ToLower() == "true"))
									{
										flag2 = (!(str1.ToLower() == "x") || !(flag1.ToString().ToLower() != "true") ? this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("multiple¶", num4.ToString()), num1, num, num5, flag3) : this.objBase.IsDeliveryItemStatusChanges(CompanyID, num2, (long)0, string.Concat("multiple¶", num4.ToString()), num1, num, num5, flag3));
									}
									else
									{
										flag2 = true;
									}
								}
								if (!flag2)
								{
									str = string.Concat(str, "false");
								}
								else
								{
									str = string.Concat(str, "true");
									if (base.Session["IsUpdateKingsQty"] == null)
									{
										flag = false;
									}
									else
									{
										if (base.Session["IsUpdateKingsQty"].ToString() != "true")
										{
											continue;
										}
										flag = true;
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
		if (flag)
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
		return true;
	}

	[WebMethod(EnableSession=true)]
	public long Estimate_Items_Copy(long EstimateID, long EstimateItemID, string EstimateType, string Module, string ddlStatusVal, string isStock_Reduce)
	{
		long num;
		if (Module.ToLower().ToString() == "invoice" || Module.ToLower().ToString() == "job")
		{
			Hashtable hashtables = new Hashtable();
			DataTable dataTable = EstimatesBasePage.price_catalogue_select_by_estimateitem_id_new(this.CompanyID, EstimateItemID);
			string empty = string.Empty;
			foreach (DataRow row in dataTable.Rows)
			{
				if (!hashtables.Contains(Convert.ToInt64(row["PriceCatalogueID"])))
				{
					hashtables.Add(Convert.ToInt64(row["PriceCatalogueID"]), Convert.ToInt32(row["Quantity"]) * Convert.ToInt32(row["MultipleOf"]));
					empty = this.objBase.Check_Estimate_Possible(Convert.ToInt64(row["PriceCatalogueID"]), Convert.ToInt32(row["Quantity"]) * Convert.ToInt32(row["MultipleOf"]), Module, Convert.ToInt64(ddlStatusVal));
				}
				else
				{
					hashtables[Convert.ToInt64(row["PriceCatalogueID"])] = Convert.ToInt64(hashtables[Convert.ToInt64(row["PriceCatalogueID"])]) + Convert.ToInt64(row["Quantity"]) * Convert.ToInt64(row["MultipleOf"]);
					empty = this.objBase.Check_Estimate_Possible(Convert.ToInt64(row["PriceCatalogueID"]), Convert.ToInt32(hashtables[Convert.ToInt64(row["PriceCatalogueID"])]), Module, Convert.ToInt64(ddlStatusVal));
				}
				if (string.IsNullOrEmpty(empty) || !empty.ToLower().Contains("false"))
				{
					continue;
				}
				hashtables.Clear();
				num = (long)0;
				return num;
			}
			DataSet dataSet = EstimatesBasePage.sub_item_summary(this.CompanyID, EstimateItemID, EstimateType);
			IEnumerator enumerator = dataSet.Tables[5].Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow current = (DataRow)enumerator.Current;
					if (!hashtables.Contains(Convert.ToInt64(current["PriceCatalogueID"])))
					{
						hashtables.Add(Convert.ToInt64(current["PriceCatalogueID"]), Convert.ToInt32(current["SubItemQuantity"]));
						empty = this.objBase.Check_Estimate_Possible(Convert.ToInt64(current["PriceCatalogueID"]), Convert.ToInt32(current["SubItemQuantity"]), Module, Convert.ToInt64(ddlStatusVal));
					}
					else
					{
						hashtables[Convert.ToInt64(current["PriceCatalogueID"])] = Convert.ToInt64(hashtables[Convert.ToInt64(current["PriceCatalogueID"])]) + Convert.ToInt64(current["SubItemQuantity"]);
						empty = this.objBase.Check_Estimate_Possible(Convert.ToInt64(current["PriceCatalogueID"]), Convert.ToInt32(hashtables[Convert.ToInt64(current["PriceCatalogueID"])]), Module, Convert.ToInt64(ddlStatusVal));
					}
					if (string.IsNullOrEmpty(empty) || !empty.ToLower().Contains("false"))
					{
						continue;
					}
					hashtables.Clear();
					num = (long)0;
					return num;
				}
				hashtables.Clear();
				if (isStock_Reduce.ToString() == "1")
				{
					this.SummaryClassObj.isStock_Reduce = true;
				}
				return this.SummaryClassObj.CopyItem_ForEstItemID(EstimateID, EstimateItemID, EstimateType, Module, ddlStatusVal);
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return num;
		}
		if (isStock_Reduce.ToString() == "1")
		{
			this.SummaryClassObj.isStock_Reduce = true;
		}
		return this.SummaryClassObj.CopyItem_ForEstItemID(EstimateID, EstimateItemID, EstimateType, Module, ddlStatusVal);
	}

	[WebMethod(EnableSession=true)]
	public void Estimate_Items_Delete(int CompanyID, long EstimateItemID, string Estimatetype, long EstimateID, string Module, string ItemTitle, bool KeepEstimateLive)
	{
		EstimatesBasePage.EstimateItem_Delete(CompanyID, EstimateItemID, Module, KeepEstimateLive);
		EstimatesBasePage.estimate_EstTotalPriceDetails_Update(EstimateItemID);
	}

	[WebMethod(EnableSession=true)]
	public string EstJobInvIduvidualItemStatuS_Update(int CompanyID, long estimateItemID, long EstimateID, int StatusID, string Module)
	{
		bool flag = true;
		long num = (long)0;
		long num1 = (long)0;
		foreach (DataRow row in JobBasePage.QuickLinks_ItemDetials_Select(CompanyID, estimateItemID).Rows)
		{
			num1 = Convert.ToInt64(row["JobID"]);
		}
		string str = this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
		string str1 = this.objBase.Return_StockManagementSettings("SR_JobStatusID");
		string str2 = this.objBase.Return_StockManagementSettings("SA_JobStatusID");
		string str3 = this.objBase.Return_StockManagementSettings("SA_EprintMISJobs");
		this.objBase.Return_StockManagementSettings("StatusMessage");
		string str4 = this.objBase.Return_StockManagementSettings("SA_EstoreJobStatusID");
		string str5 = this.objBase.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
		string str6 = this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
		if (this.InventoryManagement == "IM")
		{
			this.ReduceStockType = this.commcls.Settings_inventoryStockReduction_Select((long)CompanyID);
			this.ReduceStockTypeForCancelled = this.commcls.Settings_inventoryStockReduction_CancelledJob((long)CompanyID);
		}
		if ((!(Module == "job") || !(this.ReduceStockType.ToString() == StatusID.ToString())) && (!(Module == "job") || !(str1 == StatusID.ToString())))
		{
			num = EstimatesBasePage.EstimateItemsOnCheck_Status_Update(CompanyID, estimateItemID.ToString(), StatusID, Module.ToLower());
			if (Module.ToLower() == "job")
			{
				this.commcls.SendMailOnJobStatusChange_Item(CompanyID, EstimateID, StatusID, Module, estimateItemID, (long)0);
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
			if (!(Module == "job") || !(str6 == StatusID.ToString()))
			{
				foreach (DataRow dataRow in JobBasePage.Job_Card_Info_Select_By_JobID(num1).Rows)
				{
					if (estimateItemID != Convert.ToInt64(dataRow["EstimateItemID"]) || Convert.ToBoolean(dataRow["IsStockReplenishItem"]))
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
								object[] objArray = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(dataRow1["ReqQuantity"]), Convert.ToInt64(dataRow1["KitItemID"]), Convert.ToInt32(dataRow1["AvailableQuantity"]), Convert.ToBoolean(dataRow1["IsBackOrder"]), dataRow1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]) };
								rows.Add(objArray);
							}
						}
						else
						{
							DataRowCollection dataRowCollection = dataTable.Rows;
							object[] objArray1 = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(row1["Quantity"]), Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["AvailableQuantity"]), Convert.ToBoolean(row1["IsBackOrder"]), row1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]) };
							dataRowCollection.Add(objArray1);
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
					if (str2 == StatusID.ToString() || str4 == StatusID.ToString())
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
						if (!(row3["IsStockTransacted"].ToString().ToLower() == "allocated") || !(row3["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(row3["AvailableQty"]) >= 0)
						{
							continue;
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
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				num = EstimatesBasePage.EstimateItemsOnCheck_Status_Update(CompanyID, estimateItemID.ToString(), StatusID, Module.ToLower());
				string empty = string.Empty;
				if (Module.ToLower() == "job")
				{
					empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(num1, "jobs");
					if (empty.ToLower() == "yes")
					{
						if ((str5 == "j" || str3 == "j") && (str4 == StatusID.ToString() || str2 == StatusID.ToString()))
						{
							this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num1, (long)0);
						}
						if (str == "j" && str1 == StatusID.ToString())
						{
							this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num1, (long)0);
						}
					}
				}
				if (empty.ToLower() != "yes")
				{
					this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, estimateItemID, Convert.ToInt32(base.Session["UserID"]), true, num1, (long)0);
				}
				if (Module.ToLower() == "job")
				{
					this.commcls.SendMailOnJobStatusChange_Item(CompanyID, EstimateID, StatusID, Module, estimateItemID, (long)0);
				}
				this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(estimateItemID, Module);
			}
		}
		return string.Concat(flag, ",", num);
	}

	[WebMethod]
	public string HelloWorld()
	{
		return "Hello World";
	}

	[WebMethod(EnableSession=true)]
	public void InventoryStockBackOn_itemDelete(int companyID, long EstimateID, long estimateItemID, int UserId)
	{
		int num = 0;
		if (base.Session["UserID"] != null)
		{
			num = Convert.ToInt32(base.Session["UserID"].ToString());
		}
		this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", EstimateID, companyID, estimateItemID, num);
	}

	[WebMethod(EnableSession=true)]
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

	[WebMethod(EnableSession=true)]
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

	[WebMethod(EnableSession=true)]
	public void LockItemStatus(long EstimateItemID, string Module)
	{
		EstimatesBasePage.LockItemStatus(EstimateItemID, Module);
	}

	[WebMethod(EnableSession=true)]
	public void SaveItemPriceDetails(long EstimateID, long EstimateItemID, long SectionID, string EstimateType, decimal TotalProfitMarginPercentage1, decimal TotalProfitMarginPercentage2, decimal TotalProfitMarginPercentage3, decimal TotalProfitMarginPercentage4, decimal TotalProfitMarginPrice1, decimal TotalProfitMarginPrice2, decimal TotalProfitMarginPrice3, decimal TotalProfitMarginPrice4, decimal TotalSubTotal1, decimal TotalSubTotal2, decimal TotalSubTotal3, decimal TotalSubTotal4, int TotalTaxID1, int TotalTaxID2, int TotalTaxID3, int TotalTaxID4, decimal TotalTaxPercentage1, decimal TotalTaxPercentage2, decimal TotalTaxPercentage3, decimal TotalTaxPercentage4, decimal TotalTaxPrice1, decimal TotalTaxPrice2, decimal TotalTaxPrice3, decimal TotalTaxPrice4, decimal TotalSellingPrice1, decimal TotalSellingPrice2, decimal TotalSellingPrice3, decimal TotalSellingPrice4, decimal TotalGrossProfitPercentage1, decimal TotalGrossProfitPercentage2, decimal TotalGrossProfitPercentage3, decimal TotalGrossProfitPercentage4, decimal TotalGrossProfitPrice1, decimal TotalGrossProfitPrice2, decimal TotalGrossProfitPrice3, decimal TotalGrossProfitPrice4, bool IsSubTotalLocked)
	{
		EstimatesBasePage.estimate_item_total_price_details_update(EstimateID, EstimateItemID, SectionID, EstimateType, TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4, TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4, TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4, TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4, TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4, TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4, TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4, TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4, TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4, IsSubTotalLocked);
	}

	[WebMethod(EnableSession=true)]
	public void StockBackOn_StatusUpdate(int companyID, long EstimateID, int UserId)
	{
		this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-status", EstimateID, companyID, (long)0, UserId);
	}

	[WebMethod(EnableSession=true)]
	public void UnLockItemStatus(long EstimateItemID, string Module)
	{
		EstimatesBasePage.UnLockItemStatus(EstimateItemID, Module);
	}

	[WebMethod(EnableSession=true)]
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
			string str = this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
			string str1 = this.objBase.Return_StockManagementSettings("SR_JobStatusID");
			string str2 = this.objBase.Return_StockManagementSettings("SA_EprintMISJobs");
			string str3 = this.objBase.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
			string str4 = this.objBase.Return_StockManagementSettings("SA_EstoreJobStatusID");
			this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
			string str5 = this.objBase.Return_StockManagementSettings("SA_JobStatusID");
			if ((str3 == "j" || str2 == "j") && (str4 == ddlStatusID.ToString() || str5 == ddlStatusID.ToString()))
			{
				this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, (long)0, num, false, (long)ModuleID, (long)0);
			}
			if (str == "j" && str1 == ddlStatusID.ToString())
			{
				this.SummaryClassObj.Call_Inventory_Adjustment_Job("completed-status", EstimateID, CompanyID, (long)0, num, false, (long)ModuleID, (long)0);
			}
		}
		else if (Module.ToLower() == "webstoreorder")
		{
			string str6 = this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
			string str7 = this.objBase.Return_StockManagementSettings("SR_JobStatusID");
			if (str6 == "o" && str7 == ddlStatusID.ToString() && base.Session["ProductStockManagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
			{
				this.SummaryClassObj.OrderStatusChange_StockReduction((long)ModuleID, CompanyID, (long)0, num);
			}
		}
		this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate((long)ModuleID, Module);
	}

	[WebMethod(EnableSession=true)]
	public void UpdateItemDescriptionInSummary(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string AllItemDescnValues, bool CopyCustomerDesnToSuplrDesn, bool ChkCopyPOState, bool ChkCopyDNState, string itemtitle, string module)
	{
		EstimateCommonMethods.EditUpdateIDescriptionsInSummary(CompanyID, EstimateID, EstimateItemID, EstimateType, AllItemDescnValues, CopyCustomerDesnToSuplrDesn, ChkCopyPOState, ChkCopyDNState, itemtitle, module);
	}

	[WebMethod(EnableSession=true)]
	public bool UpdateStatus(int companyID, long EstimateID, int ddlStatusID, string Module, int UserId, long ModuleID)
	{
		bool flag = true;
		this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
		string str = this.objBase.Return_StockManagementSettings("SR_JobStatusID");
		string str1 = this.objBase.Return_StockManagementSettings("SA_JobStatusID");
		this.objBase.Return_StockManagementSettings("SA_EprintMISJobs");
		this.objBase.Return_StockManagementSettings("StatusMessage");
		string str2 = this.objBase.Return_StockManagementSettings("SA_EstoreJobStatusID");
		this.objBase.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
		string str3 = this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
		if (this.InventoryManagement == "IM")
		{
			this.ReduceStockType = this.commcls.Settings_inventoryStockReduction_Select((long)companyID);
			this.ReduceStockTypeForCancelled = this.commcls.Settings_inventoryStockReduction_CancelledJob((long)companyID);
		}
		if ((!(Module == "job") || !(this.ReduceStockType.ToString() == ddlStatusID.ToString())) && (!(Module == "job") || !(str == ddlStatusID.ToString())))
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
				}
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
			if (!(Module == "job") || !(str3 == ddlStatusID.ToString()))
			{
				foreach (DataRow dataRow in JobBasePage.Job_Card_Info_Select_By_JobID(ModuleID).Rows)
				{
					if (!(Convert.ToString(dataRow["Itemtype"]).ToLower() == "c") && !(Convert.ToString(dataRow["Itemtype"]).ToLower() == "x") || Convert.ToBoolean(dataRow["IsStockReplenishItem"]))
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
								DataRowCollection rows = dataTable1.Rows;
								object[] num = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(dataRow1["ReqQuantity"]), Convert.ToInt64(dataRow1["KitItemID"]), Convert.ToInt32(dataRow1["AvailableQuantity"]), Convert.ToBoolean(dataRow1["IsBackOrder"]), dataRow1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]) };
								rows.Add(num);
							}
						}
						else
						{
							DataRowCollection dataRowCollection = dataTable1.Rows;
							object[] objArray = new object[] { Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt32(row1["Quantity"]), Convert.ToInt64(row1["PriceCatalogueID"]), Convert.ToInt32(row1["AvailableQuantity"]), Convert.ToBoolean(row1["IsBackOrder"]), row1["DrawStockFrom"].ToString(), row1["IsStockTransacted"].ToString(), Convert.ToBoolean(row1["Is_Item_BackOrder"]) };
							dataRowCollection.Add(objArray);
						}
					}
				}
				foreach (DataRow row2 in dataTable1.Rows)
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
				dataTable1.AcceptChanges();
				foreach (DataRow dataRow2 in dataTable1.Rows)
				{
					if (str1 == ddlStatusID.ToString() || str2 == ddlStatusID.ToString())
					{
						if (!(dataRow2["IsStockTransacted"].ToString() == "") || Convert.ToInt32(dataRow2["AvailableQty"]) >= 0 || !(dataRow2["IsBackOrder"].ToString().ToLower() == "false"))
						{
							continue;
						}
						flag = false;
						break;
					}
					else if (dataRow2["IsStockTransacted"].ToString() != "")
					{
						if (!(dataRow2["IsStockTransacted"].ToString().ToLower() == "allocated") || !(dataRow2["Is_Item_BackOrder"].ToString().ToLower() == "true") || Convert.ToInt32(dataRow2["AvailableQty"]) >= 0)
						{
							continue;
						}
						flag = false;
						break;
					}
					else
					{
						if (Convert.ToInt32(dataRow2["AvailableQty"]) >= 0)
						{
							continue;
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
					if (!ConnectionClass.IsSplitItem)
					{
						this.commcls.SendMailOnJobStatusChange(companyID, EstimateID, ddlStatusID, Module);
					}
					else
					{
						this.commcls.SendMailOnJobStatusChange_Item(companyID, EstimateID, ddlStatusID, Module, (long)0, ModuleID);
					}
				}
				DataTable dataTable2 = new DataTable();
				dataTable2 = (Module.ToLower() != "job" ? InvoiceBasePage.InvoiceItem_EstimateItemID_Select(ModuleID, Module) : JobBasePage.JobItem_EstimateItemID_Select(ModuleID, "items"));
				foreach (DataRow row3 in dataTable2.Rows)
				{
					this.SummaryClassObj.Insert_ActivityHistory_StatusUpdate_PerItem(Convert.ToInt64(row3["EstimateItemID"]), Module);
				}
			}
		}
		return flag;
	}

	[WebMethod(EnableSession=true)]
	public void WarehouseStockBackOn_itemDelete(int companyID, long EstimateID, long estimateItemID, int UserId)
	{
		int num = 0;
		if (base.Session["UserID"] != null)
		{
			num = Convert.ToInt32(base.Session["UserID"].ToString());
		}
		this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock", EstimateID, companyID, estimateItemID, num);
	}

	[WebMethod(EnableSession=true)]
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

	[WebMethod(EnableSession=true)]
	public void WarehouseStockBackOn_itemDelete_Order(int companyID, long EstimateID, long estimateItemID, int UserId)
	{
		int num = 0;
		if (base.Session["UserID"] != null)
		{
			num = Convert.ToInt32(base.Session["UserID"].ToString());
		}
		this.SummaryClassObj.Call_Inventory_Adjustment_Order("cancelled-stock", EstimateID, companyID, estimateItemID, num);
	}

	[WebMethod(EnableSession=true)]
	public void WarehouseStockBackOn_StatusUpdate(int companyID, long EstimateID, int UserId)
	{
		int num = 0;
		if (base.Session["UserID"] != null)
		{
			num = Convert.ToInt32(base.Session["UserID"].ToString());
		}
		this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock-status", EstimateID, companyID, (long)0, num);
	}
}