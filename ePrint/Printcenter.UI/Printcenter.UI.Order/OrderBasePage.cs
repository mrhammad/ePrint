using Printcenter.BusinessAccessLayer.Order;
using System;
using System.Data;

namespace Printcenter.UI.Order
{
	public class OrderBasePage
	{
		public OrderBasePage()
		{
		}

		public static void Archive_Order(long OrderID, long CompanyID)
		{
			Orders.Archive_Order(OrderID, CompanyID);
		}

		public static void Order_Comments_Update(int commentId, string newComment)
		{
			Orders.Order_Comments_Update(commentId, newComment);
		}

		public static void CartAdditionalValues_Update(long OrderID, long OptionID, decimal TotalPrice, int SelectedID)
		{
			Orders.CartAdditionalValues_Update(OrderID, OptionID, TotalPrice, SelectedID);
		}

		public static int Company_RoundOff_Value(int CompanyID)
		{
			return Orders.Company_RoundOff_Value(CompanyID);
		}

		public static void delete_Order(long OrderID, long CompanyID, long LoggedIN_UserID)
		{
			Orders.delete_Order(OrderID, CompanyID, LoggedIN_UserID);
		}

		public static void Delete_OrderItems(long CompanyID, long OrderItemID, long EstimateItemID)
		{
			Orders.Delete_OrderItems(CompanyID, OrderItemID, EstimateItemID);
		}

		public static void Insert_OrderAdditionalItems(long OrderID, long OrderItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, decimal SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkupValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
		{
			Orders.Insert_OrderAdditionalItems(OrderID, OrderItemID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkupValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType, FreeTextQuestionLong);
		}

		public static DataTable JobInvoiceAllItemDetails_select(long ModuleID, string ModuleType)
		{
			return Orders.JobInvoiceAllItemDetails_select(ModuleID, ModuleType);
		}

		public static DataTable jobOrder_select(int CompanyID, long OrderID, long EstimateID)
		{
			return Orders.jobOrder_select(CompanyID, OrderID, EstimateID);
		}

		public static DataTable order_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			return Orders.order_advance_search(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
		}

		public static DataTable order_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			return Orders.order_advance_search_SplitItems(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
		}

		public static DataTable Order_AllItemsDetails_Select(long ModuleID, string ModuleType)
		{
			return Orders.Order_AllItemsDetails_Select(ModuleID, ModuleType);
		}

		public static DataTable Order_select(int CompanyID, long OrderID)
		{
			return Orders.Order_select(CompanyID, OrderID);
		}

		public static DataTable Order_select_Summary_PerItem(int CompanyID, long EstimateItemID)
		{
			return Orders.Order_select_Summary_PerItem(CompanyID, EstimateItemID);
		}

		public static void OrderAdditionalOptions_Update(long OrderID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal MarkupValue, int SortOrderNo, decimal SelectedPrice, long TaxID, decimal TaxPercentage, decimal TotalTaxValue)
		{
			Orders.OrderAdditionalOptions_Update(OrderID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, MarkupValue, SortOrderNo, SelectedPrice, TaxID, TaxPercentage, TotalTaxValue);
		}

		public static string OrderConvertedToJob(long OrderID)
		{
			return Orders.OrderConvertedToJob(OrderID);
		}

		public static void OrderEditDetails_update(string Module, long OrderID, long EstimateID, long CompanyID, long ContactID, string ContactEmail, string ContactPhone, long DepartmentID, int CostCentrID, string Greeting, long ContactAddressID, long DeliveryAddressID, long InvoiceAddressID, string Header, string Footer, int SalesPerson, string Title, long StatusID, string OrderNumber, string Comments, DateTime DeliveryDate, DateTime InvoiceDueDate, long JobID, long InvoiceID, DateTime InvoiceDate, DateTime EstimatedArtwork, DateTime EstProofDate, DateTime EstApprovalDate, DateTime EstCompletionDate, int InvoiceContactid, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			Orders.OrderEditDetails_update(Module, OrderID, EstimateID, CompanyID, ContactID, ContactEmail, ContactPhone, DepartmentID, CostCentrID, Greeting, ContactAddressID, DeliveryAddressID, InvoiceAddressID, Header, Footer, SalesPerson, Title, StatusID, OrderNumber, Comments, DeliveryDate, InvoiceDueDate, JobID, InvoiceID, InvoiceDate,  EstimatedArtwork,  EstProofDate,  EstApprovalDate,  EstCompletionDate, InvoiceContactid, customDate1, customDate2, customDate3, customDate4, customDate5);
		}

		public static int OrderItemApprovalStatus_Select(long EstimateItemID)
		{
			return Orders.OrderItemApprovalStatus_Select(EstimateItemID);
		}

		public static DataTable OrderItemID_Select(long OrderID, long EstimateItemID)
		{
			return Orders.OrderItemID_Select(OrderID, EstimateItemID);
		}

		public static void OrderOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
		{
			Orders.OrderOnCheck_Status_Update(CompanyID, EstimateIDs, StatusID, Module);
		}

		public static void PC_OrderAdditionalOptions_Delete(long OrderID)
		{
			Orders.PC_OrderAdditionalOptions_Delete(OrderID);
		}

		public static void PC_UpdateOrderAdditional_InOrders(long OrderID)
		{
			Orders.PC_UpdateOrderAdditional_InOrders(OrderID);
		}

		public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			return Orders.Product_CatalogueQty_Select(PriceCatalogueID);
		}

		public static DataTable productsDetails_Select(long PriceCatalogueID)
		{
			return Orders.productsDetails_Select(PriceCatalogueID);
		}

		public static void Progress_toJob(long CompanyID, long OrderID, long OrderItemID, DateTime ConvertedDate, long EstimateItemID, string IsAllConverted)
		{
			Orders.Progress_toJob(CompanyID, OrderID, OrderItemID, ConvertedDate, EstimateItemID, IsAllConverted);
		}

		public static long Select_AccountID(int CompanyID, long ModuleID, string ModuleType)
		{
			return Orders.Select_AccountID(CompanyID, ModuleID, ModuleType);
		}

		public static DataTable Select_CampaignValues(long AccountID)
		{
			return Orders.Select_CampaignValues(AccountID);
		}

		public static DataTable Select_OrderAdditionalOptions(int CompanyID, long EstimateID, long EstimateItemID)
		{
			return Orders.Select_OrderAdditionalOptions(CompanyID, EstimateID, EstimateItemID);
		}

		public static DataSet Select_OrderItems_WithAdditionalItems(long OrderItemID)
		{
			return Orders.Select_OrderItems_WithAdditionalItems(OrderItemID);
		}
		public static DataSet Select_OrderItems_WithAdditionalItems1(long OrderItemID)
		{
			return Orders.Select_OrderItems_WithAdditionalItems1(OrderItemID);
		}
		public static DataTable Select_OtherCost_AdditionalItemDetails(int CompanyID, long OrderItemID)
		{
			return Orders.Select_OtherCost_AdditionalItemDetails(CompanyID, OrderItemID);
		}

		public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
		{
			return Orders.Select_OtherCostAdditional_ItemsDetail(WebOtherCostID);
		}

		public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID, long OrderID)
		{
			return Orders.Select_OtherCostAdditional_ItemsDetail(WebOtherCostID, OrderID);
		}

		public static DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
		{
			return Orders.Select_OtherCostAdditional_ItemsIDs(PriceCatalogueID);
		}

		public static DataTable Select_OtherCostMatrix_Value(long PriceCatalogueID, int Quantity)
		{
			return Orders.Select_OtherCostMatrix_Value(PriceCatalogueID, Quantity);
		}

		public static DataTable Select_ProductCatalogue_Details(int CompanyID, long OrderItemID)
		{
			return Orders.Select_ProductCatalogue_Details(CompanyID, OrderItemID);
		}

		public static DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
		{
			return Orders.ShoppingCart_AdditionalOption_Select(CompanyID, AccountID, IsVisibleToCart);
		}

		public static DataTable Tax_Bind(int companyID)
		{
			return Orders.Tax_Bind(companyID);
		}

		public static void Update_OrdersItems(long CompanyID, long OrderID, long OrderItemID, long ProductID, string JobName, int Quantity, decimal UnitPrice, string UploadFile, string UploadFile1, string UploadFile2, decimal MainItemPrice, decimal TaxRate, decimal MainItemMarkupPrice, decimal OrderItemTotalPrice, decimal OrderItemTax, decimal OrderItemShipping, string ItemDesc, decimal TotalMarkupPrice, long CampaignID, decimal Height, decimal Width, decimal Markup, int TaxId)
		{
			Orders.Update_OrdersItems(CompanyID, OrderID, OrderItemID, ProductID, JobName, Quantity, UnitPrice, UploadFile, UploadFile1, UploadFile2, MainItemPrice, TaxRate, MainItemMarkupPrice, OrderItemTotalPrice, OrderItemTax, OrderItemShipping, ItemDesc, TotalMarkupPrice, CampaignID, Height, Width, Markup, TaxId);
		}
	}
}