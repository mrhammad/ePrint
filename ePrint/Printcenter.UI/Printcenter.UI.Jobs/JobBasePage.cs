using Printcenter.BusinessAccessLayer.Job;
using System;
using System.Data;

namespace Printcenter.UI.Jobs
{
	public class JobBasePage
	{
		public JobBasePage()
		{
		}

		public static DataSet AllModuleDetails_Select(int CompanyID, long PoDnID, string page)
		{
			return Job.AllModuleDetails_Select(CompanyID, PoDnID, page);
		}

		public static long copy_job(int CompanyID, long JobID, long New_EstimateID, bool IsHandy)
		{
			return Job.copy_job(CompanyID, JobID, New_EstimateID, IsHandy);
		}

		public static void copy_jobcard(int CompanyID, long Old_EstimateItemID, long New_EstimateItemID)
		{
			Job.copy_jobcard(CompanyID, Old_EstimateItemID, New_EstimateItemID);
		}

		public static void Estimate_Revert_Status_Update(int CompanyID, long EstimateID)
		{
			Job.Estimate_Revert_Status_Update(CompanyID, EstimateID);
		}

		public static long EstimateID_Select_By_JobID(int CompanyID, long JobID)
		{
			return Job.EstimateID_Select_By_JobID(CompanyID, JobID);
		}

		public static string EstimateItem_JobItemNumber_Select(long JobID, long EstimateItemID)
		{
			return Job.EstimateItem_JobItemNumber_Select(JobID, EstimateItemID);
		}

		public static DataTable EstimateItems_PendingForInvoice_Select(string JobIDs)
		{
			return Job.EstimateItems_PendingForInvoice_Select(JobIDs);
		}

		public static void EstimateItems_ProgressToJob(long EstimateItemID, long JobID, bool IsArchive_Job, DateTime CreatedDate)
		{
			Job.EstimateItems_ProgressToJob(EstimateItemID, JobID, IsArchive_Job, CreatedDate);
		}

		public static DataTable GetAccountID(int CompanyID, long EstimateID)
		{
			return Job.GetAccountID(CompanyID, EstimateID);
		}

		public static DataTable job_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			return Job.job_advance_search(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
		}

		public static DataTable job_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			return Job.job_advance_search_SplitItems(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
		}

		public static DataTable job_advance_search_top5(int CompanyID, int ClientID, string Status, string DateType, bool IsArchived)
		{
			return Job.job_advance_search_top5(CompanyID, ClientID, Status, DateType, IsArchived);
		}

		public static void Job_Archive(int CompanyID, long JobID)
		{
			Job.Job_Archive(CompanyID, JobID);
		}

		public static DataTable Job_Booklet_Quantity_Details_Select(int CompanyID, long EstimateItemID, short QtyNumber)
		{
			return Job.Job_Booklet_Quantity_Details_Select(CompanyID, EstimateItemID, QtyNumber);
		}

		public static DataTable Job_Card_Full_Info_Select_By_JobID(long JobID)
		{
			return Job.Job_Card_Full_Info_Select_By_JobID(JobID);
		}
        public static DataTable Job_Card_Full_Info_Select_By_JobID_Create_Bulk(long JobID)
        {
            return Job.Job_Card_Full_Info_Select_By_JobID_Create_Bulk(JobID);
        }
        
        public static DataTable Job_Card_Info_Select_By_JobID(long JobID)
		{
			return Job.Job_Card_Info_Select_By_JobID(JobID);
		}

		public static DataTable job_card_othercost_sub_items(int CompanyID, long TypeID, string EstimateType, long QuantityID)
		{
			return Job.job_card_othercost_sub_items(CompanyID, TypeID, EstimateType, QuantityID);
		}

		public static void job_card_price_catalogue_update(int CompanyID, long EstimateItemID, string ReqPriceCatalogue)
		{
			Job.job_card_price_catalogue_update(CompanyID, EstimateItemID, ReqPriceCatalogue);
		}

		public static void job_card_required_update(int CompanyID, long EstimateItemID, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin)
		{
			Job.job_card_required_update(CompanyID, EstimateItemID, ReqPrePress, ReqPress, ReqPostPress, ReqPriceCatalogue, ReqOutwork, ReqWarehouse, ReqAdmin);
		}

		public static long job_check_estimate(int CompanyID, long EstimateID)
		{
			return Job.job_check_estimate(CompanyID, EstimateID);
		}

		public static short Job_Item_QuantityNumber_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Job_Item_QuantityNumber_Select(CompanyID, EstimateItemID);
		}

		public static DataTable Job_Items_Quantity_Details_Select(int CompanyID, long ItemID, string ItemType, short QtyNumber)
		{
			return Job.Job_Items_Quantity_Details_Select(CompanyID, ItemID, ItemType, QtyNumber);
		}

		public static string Job_Job_Number_Select(int CompanyID, long PurchaseID)
		{
			return Job.Job_Job_Number_Select(CompanyID, PurchaseID);
		}

		public static void Job_Jobcard_Insert_NewItem(int CompanyID, long EstimateItemID, short QtyNumber, long EstimateID)
		{
			Job.Job_Jobcard_Insert_NewItem(CompanyID, EstimateItemID, QtyNumber, EstimateID);
		}

		public static void Job_Jobcard_Insert_NewItem_JOBTIME(int CompanyID, long EstimateItemID, short QtyNumber, long EstimateID, decimal JobTime)
		{
			Job.Job_Jobcard_Insert_NewItem_JOBTIME(CompanyID, EstimateItemID, QtyNumber, EstimateID, JobTime);
		}

		public static DataSet Job_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			return Job.Job_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static void Job_Progress_Status_Insert(int CompanyID, long JobID)
		{
			Job.Job_Progress_Status_Insert(CompanyID, JobID);
		}

		public static DataSet Job_ProgressToInv_Contacts_Select(string EstimateItemIDs)
		{
			return Job.Job_ProgressToInv_Contacts_Select(EstimateItemIDs);
		}

		public static DataSet Job_ProgToInvoice_allContacts_Select(string EstimateItemIDs)
		{
			return Job.Job_ProgToInvoice_allContacts_Select(EstimateItemIDs);
		}

		public static DataTable Job_QtyIDQty_Select(int CompanyID, short QtyNo, long ItemID, string ItemType)
		{
			return Job.Job_QtyIDQty_Select(CompanyID, QtyNo, ItemID, ItemType);
		}

		public static DataTable Job_Quantity_Numbert_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Job_Quantity_Numbert_Select(CompanyID, EstimateItemID);
		}

		public static DataTable Job_Quantity_Select_By_ID(int CompanyID, string EstimateType, long ItemID, short QtyNo)
		{
			return Job.Job_Quantity_Select_By_ID(CompanyID, EstimateType, ItemID, QtyNo);
		}

		public static DataTable Job_Select_By_EstimateID(int CompanyID, long EstimateID)
		{
			return Job.Job_Select_By_EstimateID(CompanyID, EstimateID);
		}

		public static DataTable Job_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
		{
			return Job.Job_Select_By_EstimateItemID(CompanyID, EstimateItemID);
		}

		public static DataTable Job_Select_By_JobID(int CompanyID, long JobID)
		{
			return Job.Job_Select_By_JobID(CompanyID, JobID);
		}

		public static string Get_JobID_By_EstimateID(long estimateID, int CompanyID)
		{
			return Job.Get_JobID_By_EstimateID(estimateID, CompanyID);
		}

		public static void Job_Status_Update(int CompanyID, long EstimateID)
		{
			Job.Job_Status_Update(CompanyID, EstimateID);
		}

		public static DataTable Job_Summary_Item_Cost_View_Qtys_And_Cal(int CompanyID, long EstimateItemID, long TypeID, string EstType, long EstBookletSectionID, string SpType, short QtyNo)
		{
			return Job.Job_Summary_Item_Cost_View_Qtys_And_Cal(CompanyID, EstimateItemID, TypeID, EstType, EstBookletSectionID, SpType, QtyNo);
		}

		public static DataTable Job_Summary_Item_Cost_View_Qtys_And_Cal_Book(int CompanyID, long EstBookletSectionID, string SpType, short QtyNo)
		{
			return Job.Job_Summary_Item_Cost_View_Qtys_And_Cal_Book(CompanyID, EstBookletSectionID, SpType, QtyNo);
		}

		public static DataTable Job_Summary_Outwork_Select_By_EstimateItemID(int CompanyID, long EstimateItemID, short QtyNumber)
		{
			return Job.Job_Summary_Outwork_Select_By_EstimateItemID(CompanyID, EstimateItemID, QtyNumber);
		}

		public static void Job_UnArchive(int CompanyID, long JobID)
		{
			Job.Job_UnArchive(CompanyID, JobID);
		}

		public static void job_update(int CompanyID, long EstimateID, string Header, string Footer, int StatusID, DateTime Jobdate, DateTime CompletionDate, DateTime DeliveryDate, DateTime ProofDate, DateTime ProducDate, long JobID, DateTime ArtworkDate, DateTime ApprovalDate,DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			Job.job_update(CompanyID, EstimateID, Header, Footer, StatusID, Jobdate, CompletionDate, DeliveryDate, ProofDate, ProducDate, JobID, ArtworkDate, ApprovalDate, customDate1, customDate2, customDate3, customDate4, customDate5);
		}

		public static long jobcard_existcheck(int CompanyID, long EstimateID)
		{
			return Job.jobcard_existcheck(CompanyID, EstimateID);
		}

		public static void jobcard_item_description_update(int CompanyID, long EstimateItemID, string ItemDescription)
		{
			Job.jobcard_item_description_update(CompanyID, EstimateItemID, ItemDescription);
		}

		public static DataTable jobcard_jobItemdetails_select(int CompanyID, long EstimateItemID)
		{
			return Job.jobcard_jobItemdetails_select(CompanyID, EstimateItemID);
		}

		public static DataTable JobItem_EstimateItemID_Select(long JobID, string Type)
		{
			return Job.JobItem_EstimateItemID_Select(JobID, Type);
		}

		public static int JobItemNotConvertedToInvoice_Select(long JobID)
		{
			return Job.JobItemNotConvertedToInvoice_Select(JobID);
		}

		public static void Jobs_Delete(int CompanyID, long JobID, bool Keep_EstimateJOB_LIVE)
		{
			Job.Jobs_Delete(CompanyID, JobID, Keep_EstimateJOB_LIVE);
		}

		public static DataTable Jobs_EmailAutoJobStatus(int StatusID, string autojob, string isenabled, long EstimateID, int companyID)
		{
			return Job.Jobs_EmailAutoJobStatus(StatusID, autojob, isenabled, EstimateID, companyID);
		}
		public static DataTable Jobs_EmailAutoJobStatus_Item(int StatusID, string autojob, string isenabled, long EstimateID, int companyID, long EstimateItemID)
		{
			return Job.Jobs_EmailAutoJobStatus_Item(StatusID, autojob, isenabled, EstimateID, companyID, EstimateItemID);
		}

		public static DataTable Jobs_EmailStatus_select(int CompanyID, int StatusID, long CheckMailSentJobID)
		{
			return Job.Jobs_EmailStatus_select(CompanyID, StatusID, CheckMailSentJobID);
		}

		public static string Jobs_EstimateType_select(int CompanyID, int EstimateItemID)
		{
			return Job.Jobs_EstimateType_select(CompanyID, EstimateItemID);
		}

		public static DataTable Jobs_GuillotineDetails_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Jobs_GuillotineDetails_Select(CompanyID, EstimateItemID);
		}

		public static long jobs_insert(int CompanyID, long EstID, string JobNumber, DateTime ConvertedDate, DateTime JobDate, DateTime CompletionDate, DateTime DeliveryDate, int ConvertedBy, string OrderNumber, DateTime ArtworkDate, DateTime ApprovalDate, DateTime ProofDate, DateTime ProductionDate, bool IsConverted, int StatusID, bool IsHandy, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			return Job.jobs_insert(CompanyID, EstID, JobNumber, ConvertedDate, JobDate, CompletionDate, DeliveryDate, ConvertedBy, OrderNumber, ArtworkDate, ApprovalDate, ProofDate, ProductionDate, IsConverted, StatusID, IsHandy, customDate1, customDate2, customDate3, customDate4, customDate5);
		}

		public static DataTable Jobs_ItemTitle_select(int CompanyID, string Query)
		{
			return Job.Jobs_ItemTitle_select(CompanyID, Query);
		}

		public static IDataReader Jobs_Job_Details_select(int CompanyID, long EstimateID)
		{
			return Job.Jobs_Job_Details_select(CompanyID, EstimateID);
		}

		public static DataTable Jobs_Jobcard_details_select(int CompanyID, int EstimateItemID)
		{
			return Job.Jobs_Jobcard_details_select(CompanyID, EstimateItemID);
		}

		public static void jobs_jobcard_insert(int CompanyID, int EstimateItemID, short QtyNumber, DateTime CompletionDate, DateTime DeliveryDate, DateTime ArtworkDate, DateTime ApprovalDate, DateTime ProofDate, DateTime ProductionDate)
		{
			Job.jobs_jobcard_insert(CompanyID, EstimateItemID, QtyNumber, CompletionDate, DeliveryDate, ArtworkDate, ApprovalDate, ProofDate, ProductionDate);
		}

		public static DataTable Jobs_Jobcard_ItemQuantity_select(int CompanyID, long ItemID, short QtyNumber, string ItemType)
		{
			return Job.Jobs_Jobcard_ItemQuantity_select(CompanyID, ItemID, QtyNumber, ItemType);
		}

		public static DataTable Jobs_Jobcard_Jobdetails_select(int CompanyID, long JobID)
		{
			return Job.Jobs_Jobcard_Jobdetails_select(CompanyID, JobID);
		}

		public static void Jobs_Jobcard_Update(int CompanyID, int EstimateItemID, DateTime ReqArtworkDate, DateTime ActArtworkdate, DateTime ReqApprovalDate, DateTime ActApprovalDate, DateTime ReqProofDate, DateTime ActProofDate, DateTime ReqProductionDate, DateTime ActProductionDate, DateTime ReqDeliveryDate, DateTime ActDeliveryDate, string ReqPrePress, string ActPrePress, string ReqPress, string ActPress, string ReqPostPress, string ActPostPress, string ReqWarehouse, string ActWarehouse, string ReqOutwork, string ActOutwork, string ReqPriceCatalogue, string ActPriceCatalogue, string ReqAdmin, string ActAdmin, string ReqPaper, string ReqInk, string ReqPlates, string ReqGuillotine, string ReqWashUp, string ReqMakeReady, string ActPaper, string ActInk, string ActPlates, string ActGuillotine, string ActWashUp, string ActMakeReady, decimal ActualJobTime)
		{
			Job.Jobs_Jobcard_Update(CompanyID, EstimateItemID, ReqArtworkDate, ActArtworkdate, ReqApprovalDate, ActApprovalDate, ReqProofDate, ActProofDate, ReqProductionDate, ActProductionDate, ReqDeliveryDate, ActDeliveryDate, ReqPrePress, ActPrePress, ReqPress, ActPress, ReqPostPress, ActPostPress, ReqWarehouse, ActWarehouse, ReqOutwork, ActOutwork, ReqPriceCatalogue, ActPriceCatalogue, ReqAdmin, ActAdmin, ReqPaper, ReqInk, ReqPlates, ReqGuillotine, ReqWashUp, ReqMakeReady, ActPaper, ActInk, ActPlates, ActGuillotine, ActWashUp, ActMakeReady, ActualJobTime);
		}

		public static DataTable Jobs_OtherCostItemDetails_Select(int CompanyID, long OtherCostID)
		{
			return Job.Jobs_OtherCostItemDetails_Select(CompanyID, OtherCostID);
		}

		public static DataTable Jobs_OtherCostItemName_Slect(int CompanyID, long OtherCostID)
		{
			return Job.Jobs_OtherCostItemName_Slect(CompanyID, OtherCostID);
		}

		public static DataTable Jobs_OtherCostItems_Slect(int CompanyID, long TypeID)
		{
			return Job.Jobs_OtherCostItems_Slect(CompanyID, TypeID);
		}

		public static DataTable Jobs_OtherCostMainItems_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Jobs_OtherCostMainItems_Select(CompanyID, EstimateItemID);
		}

		public static DataTable Jobs_OutworkItemDescription_Select(int CompanyID, long EstItemOutworkID)
		{
			return Job.Jobs_OutworkItemDescription_Select(CompanyID, EstItemOutworkID);
		}

		public static DataTable Jobs_OutworkItems_Select(int CompanyID, long TypeID, string EstimateType)
		{
			return Job.Jobs_OutworkItems_Select(CompanyID, TypeID, EstimateType);
		}

		public static DataTable Jobs_OutworkMainItem_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Jobs_OutworkMainItem_Select(CompanyID, EstimateItemID);
		}

		public static DataTable Jobs_PressDetails_select(int CompanyID, string Query)
		{
			return Job.Jobs_PressDetails_select(CompanyID, Query);
		}

		public static void Jobs_Revert(int CompanyID, long EstimateID)
		{
			Job.Jobs_Revert(CompanyID, EstimateID);
		}

		public static DataTable Jobs_Select_All(int CompanyID, string Para)
		{
			return Job.Jobs_Select_All(CompanyID, Para);
		}

		public static DataTable Jobs_WarehouseItemName_Slect(int CompanyID, long WarehouseTypeID, string WarehouseType)
		{
			return Job.Jobs_WarehouseItemName_Slect(CompanyID, WarehouseTypeID, WarehouseType);
		}

		public static DataTable Jobs_WarehouseItems_Slect(int CompanyID, long TypeID, string EstimateType)
		{
			return Job.Jobs_WarehouseItems_Slect(CompanyID, TypeID, EstimateType);
		}

		public static DataTable Jobs_WarehouseMainItemDetails_Slect(int CompanyID, long EstBookletItemID)
		{
			return Job.Jobs_WarehouseMainItemDetails_Slect(CompanyID, EstBookletItemID);
		}

		public static DataTable Jobs_WarehouseMainItems_Slect(int CompanyID, long EstimateItemID)
		{
			return Job.Jobs_WarehouseMainItems_Slect(CompanyID, EstimateItemID);
		}

		public static DataTable Jobs_WarehouseRFQ_Select(int CompanyID, long EstimateItemID)
		{
			return Job.Jobs_WarehouseRFQ_Select(CompanyID, EstimateItemID);
		}

		public static DataSet PCR_JOBCard_GetAllItems(long CurrentEstimateItemID)
		{
			return Job.PCR_JOBCard_GetAllItems(CurrentEstimateItemID);
		}

		public static DataSet PCR_JOBCard_Values_To_Replace(long EstimateItemID, string EstimateType, long ParentItemID)
		{
			return Job.PCR_JOBCard_Values_To_Replace(EstimateItemID, EstimateType, ParentItemID);
		}

		public static void PCR_JOBCard_Values_Update_After_Replace(long EstimateItemID, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin, string ReqPaper, string ReqInk, string ReqPlates, string ReqGuillotine, string ReqWashUp, string ReqMakeReady)
		{
			Job.PCR_JOBCard_Values_Update_After_Replace(EstimateItemID, ReqPrePress, ReqPress, ReqPostPress, ReqPriceCatalogue, ReqOutwork, ReqWarehouse, ReqAdmin, ReqPaper, ReqInk, ReqPlates, ReqGuillotine, ReqWashUp, ReqMakeReady);
		}

		public static DataSet PCR_Select_JobCardSettings_ForReplace(int CompanyID, string EstimateType, string MainOrSub)
		{
			return Job.PCR_Select_JobCardSettings_ForReplace(CompanyID, EstimateType, MainOrSub);
		}

		public static DataSet PCR_Select_JobCardTags_ForReplace(int CompanyID)
		{
			return Job.PCR_Select_JobCardTags_ForReplace(CompanyID);
		}

		public static DataTable price_catalogue_select_by_estimateitem_id_qtynumber(int CompanyID, long EstimateItemID, int QtyNumber)
		{
			return Job.price_catalogue_select_by_estimateitem_id_qtynumber(CompanyID, EstimateItemID, QtyNumber);
		}

		public static DataTable QuickLinks_ItemDetials_Select(int CompanyID, long EstimateItemID)
		{
			return Job.QuickLinks_ItemDetials_Select(CompanyID, EstimateItemID);
		}

		public static void Update_EstimateJobTime(long EstimateItemID, decimal JobTime)
		{
			Job.Update_EstimateJobTime(EstimateItemID, JobTime);
		}
	}
}