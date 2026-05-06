using Printcenter.BusinessAccessLayer;
using Printcenter.DataAccessLayer.Inventories;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.BusinessAccessLayer.Inventories
{
	public class Inventory : BaseBusiness
	{
		public Inventory()
		{
		}

		public static DataTable autocomplete_inventory_selectink(int CompanyID, string ItemType, string InkType, string SearchParameter)
		{
			return (new DbInventory()).autocomplete_inventory_selectink(CompanyID, ItemType, InkType, SearchParameter);
		}

		public static DataTable Bind_StockAdditionalItems(long PriceCatalogueID)
		{
			return (new DbInventory()).Bind_StockAdditionalItems(PriceCatalogueID);
		}

		public static long Copy_Inventory(int CompanyID, long InventoryID, int InStock)
		{
			return (new DbInventory()).Copy_Inventory(CompanyID, InventoryID, InStock);
		}

		public static DataTable Fetch_Inventory_Dependancy(long CompanyID, long InventoryID)
		{
			return (new DbInventory()).Fetch_Inventory_Dependancy(CompanyID, InventoryID);
		}

		public static void FinishedGoods_AccountingCode_Insert(long CompanyID, long FinishedGoodsID, int AccountCodeID)
		{
			(new DbInventory()).FinishedGoods_AccountingCode_Insert(CompanyID, FinishedGoodsID, AccountCodeID);
		}

		public static int FinishedGoods_AccountingCode_Select(long CompanyID, long FinishedGoodsID)
		{
			return (new DbInventory()).FinishedGoods_AccountingCode_Select(CompanyID, FinishedGoodsID);
		}

		public static decimal finishedgoods_getPackedIn_qty(int CompanyID, int FinishedGoodsID, char GoodsType)
		{
			return (new DbInventory()).finishedgoods_getPackedIn_qty(CompanyID, FinishedGoodsID, GoodsType);
		}

		public static string GetUserEmail(int CompanyID, int UserID)
		{
			return (new DbInventory()).GetUserEmail(CompanyID, UserID);
		}

		public static void Inventory_AccountingCode_Insert(long CompanyID, long InventoryID, int AccountCodeID)
		{
			(new DbInventory()).Inventory_AccountingCode_Insert(CompanyID, InventoryID, AccountCodeID);
		}

		public static int Inventory_AccountingCode_Select(long CompanyID, long InventoryID)
		{
			return (new DbInventory()).Inventory_AccountingCode_Select(CompanyID, InventoryID);
		}

		public static DataTable Inventory_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.Inventory_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate);
		}

		public static decimal inventory_getPackedIn_qty(int CompanyID, int InventoryID)
		{
			return (new DbInventory()).inventory_getPackedIn_qty(CompanyID, InventoryID);
		}

		public static void Inventory_InventoryAlerts_On_Insert_Update(long InventoryID, string AlertType, string AlertEmailID, string Reason)
		{
			(new DbInventory()).Inventory_InventoryAlerts_On_Insert_Update(InventoryID, AlertType, AlertEmailID, Reason);
		}

		public static DataSet inventory_selectall(int CompanyID, string ItemType, string PaperType, string InkType)
		{
			return (new DbInventory()).inventory_selectall(CompanyID, ItemType, PaperType, InkType);
		}

		public static DataSet inventory_SelectLargeFormat(int CompanyID, string ItemType)
		{
			return (new DbInventory()).inventory_SelectLargeFormat(CompanyID, ItemType);
		}

		public static void InventoryItem_Update(int CompanyID, string InventoryCode, int Quantity, string Description, int userID, long PurchaseItemID)
		{
			(new DbInventory()).InventoryItem_Update(CompanyID, InventoryCode, Quantity, Description, userID, PurchaseItemID);
		}

		public static DataTable Select_Activity_History_For_Inventory(long InventoryID)
		{
			return (new DbInventory()).Select_Activity_History_For_Inventory(InventoryID);
		}

		public static DataSet Select_finishedgoods_for_Estimate(int CompanyID, char finishedgoodstype, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.Select_finishedgoods_for_Estimate(CompanyID, finishedgoodstype, PageSize, PageNumber, SortedBy, Direction, para);
		}

		public static DataSet Select_Inventory_Select_Estimate(int CompanyID, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.Select_Inventory_Select_Estimate(CompanyID, PageSize, PageNumber, SortedBy, Direction, para);
		}

		public static DataSet SelectProductcatalogueitems_InPurchse(int CompanyID, int PageSize, int PageNumber, string WhereCondition)
		{
			return (new DbInventory()).SelectProductcatalogueitems_InPurchse(CompanyID, PageSize, PageNumber, WhereCondition);
		}

		public static DataTable settings_InvCategory_selectall(int CompanyID, string CategoryName)
		{
			return (new DbInventory()).settings_InvCategory_selectall(CompanyID, CategoryName);
		}

		public static DataTable settings_inventoryproperties_name_select(int CompanyID)
		{
			return (new DbInventory()).settings_inventoryproperties_name_select(CompanyID);
		}

		public static DataTable settings_inventoryproperties_name_select_by_categoryID(int CompanyID, int CategoryID)
		{
			return (new DbInventory()).settings_inventoryproperties_name_select_by_categoryID(CompanyID, CategoryID);
		}

		public static int settings_stockcategory_delete(int CompanyID, int CategoryID)
		{
			return (new DbInventory()).settings_stockcategory_delete(CompanyID, CategoryID);
		}

		public static int settings_stockcategory_insert(InventoryItem item)
		{
			return (new DbInventory()).settings_stockcategory_insert(item);
		}

		public static DataTable settings_stockcategory_select(int CompanyID, int CategoryID)
		{
			return (new DbInventory()).settings_stockcategory_select(CompanyID, CategoryID);
		}

		public static DataTable settings_stockcategory_selectall(int CompanyID)
		{
			return (new DbInventory()).settings_stockcategory_selectall(CompanyID);
		}

		public static int settings_stockcategory_update(InventoryItem item)
		{
			return (new DbInventory()).settings_stockcategory_update(item);
		}

		public static int settings_stocksubcategory_delete(int CompanyID, int SubCategoryID)
		{
			return (new DbInventory()).settings_stocksubcategory_delete(CompanyID, SubCategoryID);
		}

		public static int settings_stocksubcategory_insert(InventoryItem item)
		{
			return (new DbInventory()).settings_stocksubcategory_insert(item);
		}

		public static DataTable settings_stocksubcategory_select(int CompanyID, int SubCategoryID)
		{
			return (new DbInventory()).settings_stocksubcategory_select(CompanyID, SubCategoryID);
		}

		public static DataTable settings_stocksubcategory_select_by_categoryid(int CompanyID, int ParentCategory)
		{
			return (new DbInventory()).settings_stocksubcategory_select_by_categoryid(CompanyID, ParentCategory);
		}

		public static DataTable settings_stocksubcategory_selectall(int CompanyID)
		{
			return (new DbInventory()).settings_stocksubcategory_selectall(CompanyID);
		}

		public static int settings_stocksubcategory_update(InventoryItem item)
		{
			return (new DbInventory()).settings_stocksubcategory_update(item);
		}

		public static DataTable settings_subcategoryonID_selectall(int ParentCategory)
		{
			return (new DbInventory()).settings_subcategoryonID_selectall(ParentCategory);
		}

		public static DataTable Warehouse_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string pagetype, string TodayDate, string StartDate, string EndDate)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.Warehouse_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, pagetype, TodayDate, StartDate, EndDate);
		}

		public static long warehouse_code_select(int companyid, string type)
		{
			return (new DbInventory()).warehouse_code_select(companyid, type);
		}

		public static void warehouse_code_update(int companyid, string type, long lastcount)
		{
			(new DbInventory()).warehouse_code_update(companyid, type, lastcount);
		}

		public static int warehouse_finished_goods_duplicacy_check(int CompanyID, string ProductName, string ProductCode, long GoodsID, string GooodsType)
		{
			return (new DbInventory()).warehouse_finished_goods_duplicacy_check(CompanyID, ProductName, ProductCode, GoodsID, GooodsType);
		}

		public static void warehouse_finishedgoods_archive(int companyid, int goodsid)
		{
			(new DbInventory()).warehouse_finishedgoods_archive(companyid, goodsid);
		}

		public static void warehouse_finishedgoods_delete(int companyid, int goodsid)
		{
			(new DbInventory()).warehouse_finishedgoods_delete(companyid, goodsid);
		}

		public static void warehouse_finishedgoods_edit(int companyid, int goodsid, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			DbInventory dbInventory = new DbInventory();
			dbInventory.warehouse_finishedgoods_edit(companyid, goodsid, customerid, supplierid, barcode, productname, productcode, location, supplierPartNo, taxID, packQuantity, packCostPrice, markup, packSalePrice, inStockQuantity, reOrderLevel, reorderQuantity, description, ProfitMargin);
		}

		public static DataSet warehouse_finishedgoods_forestimate_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int CustomerID)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.warehouse_finishedgoods_forestimate_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, CustomerID);
		}

		public static int warehouse_finishedgoods_insert(int companyid, char goodstype, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.warehouse_finishedgoods_insert(companyid, goodstype, customerid, supplierid, barcode, productname, productcode, location, supplierPartNo, taxID, packQuantity, packCostPrice, markup, packSalePrice, inStockQuantity, reOrderLevel, reorderQuantity, description, ProfitMargin);
		}

		public static DataSet warehouse_finishedgoods_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.warehouse_finishedgoods_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataTable warehouse_finishedgoods_search(int CompanyID, string FinishedgoodType, string SearchText)
		{
			return (new DbInventory()).warehouse_finishedgoods_search(CompanyID, FinishedgoodType, SearchText);
		}

		public static void warehouse_finishedgoods_select(int companyid, int goodsid, char goodstype, TextBox txtbarcode, TextBox txtproductname, TextBox txtproductcode, TextBox txtlocation, DropDownList ddlsupplier, TextBox txtpartNo, DropDownList ddltax, TextBox txtpackquentity, TextBox txtPackCostPrice, DropDownList ddlmarkup, HiddenField hid_packprice, TextBox txtInstock, TextBox txtReOrderLevel, TextBox txtReorderQuantity, DropDownList ddlcustomer, TextBox txtdecription, TextBox txtProfitMargin, HiddenField hdn_ArchiveID)
		{
			DbInventory dbInventory = new DbInventory();
			dbInventory.warehouse_finishedgoods_select(companyid, goodsid, goodstype, txtbarcode, txtproductname, txtproductcode, txtlocation, ddlsupplier, txtpartNo, ddltax, txtpackquentity, txtPackCostPrice, ddlmarkup, hid_packprice, txtInstock, txtReOrderLevel, txtReorderQuantity, ddlcustomer, txtdecription, txtProfitMargin, hdn_ArchiveID);
		}

		public static void warehouse_finishedgoods_unarchive(int companyid, int goodsid)
		{
			(new DbInventory()).warehouse_finishedgoods_unarchive(companyid, goodsid);
		}

		public static void warehouse_inventory_adjustment_update(int CompanyID, long InventoryID, long InventoryPropertyID, int InStock, decimal Cost)
		{
			(new DbInventory()).warehouse_inventory_adjustment_update(CompanyID, InventoryID, InventoryPropertyID, InStock, Cost);
		}

		public static DataSet Warehouse_Inventory_AllSupplier_Select(int CompanyID)
		{
			return (new DbInventory()).Warehouse_Inventory_AllSupplier_Select(CompanyID);
		}

		public static void warehouse_inventory_archive(int CompanyID, long InventoryID)
		{
			(new DbInventory()).warehouse_inventory_archive(CompanyID, InventoryID);
		}

		public static void warehouse_inventory_delete(int CompanyID, long InventoryID)
		{
			(new DbInventory()).warehouse_inventory_delete(CompanyID, InventoryID);
		}

		public static int warehouse_inventory_insert(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventory_insert(item);
		}

		public static DataTable warehouse_inventory_search(int CompanyID, string SearchText)
		{
			return (new DbInventory()).warehouse_inventory_search(CompanyID, SearchText);
		}

		public static DataTable warehouse_inventory_select(int CompanyID, long InventoryID)
		{
			return (new DbInventory()).warehouse_inventory_select(CompanyID, InventoryID);
		}

		public static DataTable warehouse_inventory_selectall(int CompanyID, string ItemType, string SearchText)
		{
			return (new DbInventory()).warehouse_inventory_selectall(CompanyID, ItemType, SearchText);
		}

		public static DataTable warehouse_inventory_selectall_onclientid(int CompanyID, int ClientID, string ItemType)
		{
			return (new DbInventory()).warehouse_inventory_selectall_onclientid(CompanyID, ClientID, ItemType);
		}

		public static DataSet warehouse_inventory_selectall_onclientid_PageText(int CompanyID, int ClientID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.warehouse_inventory_selectall_onclientid_PageText(CompanyID, ClientID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataSet warehouse_inventory_selectall_PageText(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string PaperType, string InkType)
		{
			DbInventory dbInventory = new DbInventory();
			return dbInventory.warehouse_inventory_selectall_PageText(CompanyID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, PaperType, InkType);
		}

		public static DataTable warehouse_inventory_selectink(int CompanyID, string ItemType, string InkType)
		{
			return (new DbInventory()).warehouse_inventory_selectink(CompanyID, ItemType, InkType);
		}

		public static DataTable warehouse_inventory_selectink_withinktype(int CompanyID, long LithoPressID)
		{
			return (new DbInventory()).warehouse_inventory_selectink_withinktype(CompanyID, LithoPressID);
		}

		public static DataSet warehouse_inventory_selectLargeFormat(int CompanyID, string ItemType, string SearchText)
		{
			return (new DbInventory()).warehouse_inventory_selectLargeFormat(CompanyID, ItemType, SearchText);
		}

		public static void warehouse_inventory_unarchive(int CompanyID, long InventoryID)
		{
			(new DbInventory()).warehouse_inventory_unarchive(CompanyID, InventoryID);
		}

		public static int warehouse_inventory_update(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventory_update(item);
		}

		public static int warehouse_inventoryduplicacy_check(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventoryduplicacy_check(item);
		}

		public static int warehouse_inventoryinkMatrix_insert(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventoryinkMatrix_insert(item);
		}

		public static DataTable warehouse_inventoryinkMatrix_select(int CompanyID, long InventoryID)
		{
			return (new DbInventory()).warehouse_inventoryinkMatrix_select(CompanyID, InventoryID);
		}

		public static void warehouse_inventoryinkMatrix_Update(InventoryItem item)
		{
			(new DbInventory()).warehouse_inventoryinkMatrix_Update(item);
		}

		public static int warehouse_inventoryproperties_insert(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventoryproperties_insert(item);
		}

		public static DataTable warehouse_inventoryproperties_select(int CompanyID, long InventoryID)
		{
			return (new DbInventory()).warehouse_inventoryproperties_select(CompanyID, InventoryID);
		}

		public static int warehouse_inventoryproperties_update(InventoryItem item)
		{
			return (new DbInventory()).warehouse_inventoryproperties_update(item);
		}

        public static DataTable uppernavigator_select(int CompanyID, string moduleName, int userid)
        {
            return DbInventory.uppernavigator_select(CompanyID, moduleName, userid);
        }
    }
}