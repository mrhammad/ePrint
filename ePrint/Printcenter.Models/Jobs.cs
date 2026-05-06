using System;
using System.Data;

public class Jobs
{
	public Jobs()
	{
	}

	public static void Delete_PODeliverynote_for_RevertJob(long CompanyID, long EstimateID, int DeletePO, int DeleteDel, string Type)
	{
		(new DbJobs()).Delete_PODeliverynote_for_RevertJob(CompanyID, EstimateID, DeletePO, DeleteDel, Type);
	}

	public static DataTable Job_DeliveryNote_AllItems_Quantity_Details_Select(int CompanyID, long EstimateItemID, string EstimateType, long ItemID, int QtyNumber)
	{
		return (new DbJobs()).Job_DeliveryNote_AllItems_Quantity_Details_Select(CompanyID, EstimateItemID, EstimateType, ItemID, QtyNumber);
	}

	public static void Job_DeliveryNote_DeliveryQty_Update(int CompanyID, long DeliveryID, long DeliveryItemID, long EstimateItemID, string EstimateType, long DeliveryAddressID, string DeliveryAddressType, int Quantity)
	{
		DbJobs dbJob = new DbJobs();
		dbJob.Job_DeliveryNote_DeliveryQty_Update(CompanyID, DeliveryID, DeliveryItemID, EstimateItemID, EstimateType, DeliveryAddressID, DeliveryAddressType, Quantity);
	}

	public static int Job_DeliveryNote_QtyProduced_Select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
	{
		return (new DbJobs()).Job_DeliveryNote_QtyProduced_Select(CompanyID, EstimateID, EstimateItemID, EstimateType);
	}

	public static void Job_DeliveryNote_QtyProduced_Update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, int QtyProduced)
	{
		(new DbJobs()).Job_DeliveryNote_QtyProduced_Update(CompanyID, EstimateID, EstimateItemID, EstimateType, QtyProduced);
	}

	public static DataTable job_item_cost_view_sub_item_outwork(int CompanyID, long ParentEstimateItemID, long EstimateItemID)
	{
		return (new DbJobs()).job_item_cost_view_sub_item_outwork(CompanyID, ParentEstimateItemID, EstimateItemID);
	}

	public static DataTable job_item_details_selectall(int CompanyID, long EstimateItemID, string EstimateType)
	{
		return (new DbJobs()).job_item_details_selectall(CompanyID, EstimateItemID, EstimateType);
	}

	public static int Job_Item_Invoiced_Count(long JobID)
	{
		return (new DbJobs()).Job_Item_Invoiced_Count(JobID);
	}

	public static void Job_Item_Revart(long EstimateItemID, long CompanyID, long UserID)
	{
		(new DbJobs()).Job_Item_Revart(EstimateItemID, CompanyID, UserID);
	}

	public static DataTable Job_Items_Quantity_Details_Select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, short QtyNumber)
	{
		return (new DbJobs()).Job_Items_Quantity_Details_Select(CompanyID, EstimateItemID, ItemID, ItemType, QtyNumber);
	}

	public static string job_outwork_by_id(int CompanyID, long EstimateItemID)
	{
		return (new DbJobs()).job_outwork_by_id(CompanyID, EstimateItemID);
	}

	public static DataTable job_qty_select_by_qtynumber(int CompanyID, long EstimateItemID)
	{
		return (new DbJobs()).job_qty_select_by_qtynumber(CompanyID, EstimateItemID);
	}

	public static int job_quantity_number_select(int CompanyID, long ParentEstimateItemID, string ParentEstimateType)
	{
		return (new DbJobs()).job_quantity_number_select(CompanyID, ParentEstimateItemID, ParentEstimateType);
	}

	public static DataTable job_subitem_qty_select_by_qtynumber(long CompanyID, long EstimateItemID, long ParentEstimateItemID)
	{
		return (new DbJobs()).job_subitem_qty_select_by_qtynumber(CompanyID, EstimateItemID, ParentEstimateItemID);
	}

	public static DataSet jobcard_for_sub_item(int CompanyID, long ParentItemID, string ParentItemType)
	{
		return (new DbJobs()).jobcard_for_sub_item(CompanyID, ParentItemID, ParentItemType);
	}

	public static DataTable jobcard_outwork(int CompanyID, long EstOutworkID)
	{
		return (new DbJobs()).jobcard_outwork(CompanyID, EstOutworkID);
	}

	public static DataTable jobcard_quantity_select(int CompanyID, short QtyNumber, long EstimateItemID, long EstimateBookletItemID, string EstimateType)
	{
		return (new DbJobs()).jobcard_quantity_select(CompanyID, QtyNumber, EstimateItemID, EstimateBookletItemID, EstimateType);
	}

	public static DataTable jobs_deliverynote_warehouse_details_select(int CompanyID, long EstimateItemID)
	{
		return (new DbJobs()).jobs_deliverynote_warehouse_details_select(CompanyID, EstimateItemID);
	}

	public static DataTable Jobs_ItemTitle_select(int CompanyID, string Query)
	{
		return (new DbJobs()).Jobs_ItemTitle_select(CompanyID, Query);
	}

	public static DataTable Jobs_Jobcard_ItemQuantity_select(int CompanyID, long ItemID, long EstimateItemID, short QtyNumber, string ItemType)
	{
		return (new DbJobs()).Jobs_Jobcard_ItemQuantity_select(CompanyID, ItemID, EstimateItemID, QtyNumber, ItemType);
	}

	public static DataTable Jobs_Jobcard_Jobdetails_ByJobID_select(int CompanyID, long JobID)
	{
		return (new DbJobs()).Jobs_Jobcard_Jobdetails_ByJobID_select(CompanyID, JobID);
	}

	public static DataTable Select_All_Job_Item(long JobID)
	{
		return (new DbJobs()).Select_All_Job_Item(JobID);
	}

	public static DataTable Select_jobcard_Details_forOrders(int CompanyID, long EstimateID, long EstimateItemID)
	{
		return (new DbJobs()).Select_jobcard_Details_forOrders(CompanyID, EstimateID, EstimateItemID);
	}
}