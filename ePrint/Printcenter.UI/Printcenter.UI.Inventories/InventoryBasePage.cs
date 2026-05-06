using nmsCommon;
using Printcenter.BusinessAccessLayer.Inventories;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.Inventories
{
	public class InventoryBasePage : BasePage
	{
		private static int _ReturnDeleteID;

		public int ReturnDeleteID
		{
			get
			{
				return InventoryBasePage._ReturnDeleteID;
			}
			set
			{
				InventoryBasePage._ReturnDeleteID = value;
			}
		}

		static InventoryBasePage()
		{
		}

		public InventoryBasePage()
		{
		}

		public static DataTable autocomplete_inventory_selectink(int CompanyID, string ItemType, string InkType, string SearchParameter)
		{
			return Inventory.autocomplete_inventory_selectink(CompanyID, ItemType, InkType, SearchParameter);
		}

		public void Bind_PaperSize(DropDownList ddl, int sqlParameter1, string defaultValue)
		{
			(new SettingsBasePage()).Bind_PaperSize(ddl, sqlParameter1, defaultValue);
		}

		public void Bind_Stock_Category(DropDownList ddl, int sqlParameter1, string defaultValue)
		{
			BaseClass baseClass = new BaseClass();
			DataTable dataTable = this.settings_stockcategory_selectall(sqlParameter1);
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				dataTable.Columns[i].ReadOnly = false;
			}
			ddl.DataSource = dataTable;
			ddl.DataTextField = "CategoryName";
			ddl.DataValueField = "CategoryID";
			ddl.DataBind();
		}

		public void Bind_Stock_SubCategory(DropDownList ddl, int sqlParameter1, int sqlParameter2, string defaultValue)
		{
			ddl.DataSource = this.settings_stocksubcategory_select_by_categoryid(sqlParameter1, sqlParameter2);
			ddl.DataTextField = "SubCategoryName";
			ddl.DataValueField = "SubCategoryID";
			ddl.DataBind();
			ddl.Items.Insert(0, " ");
			ddl.Items[0].Text = defaultValue;
			ddl.Items[0].Value = "0";
		}

		public static DataTable Bind_StockAdditionalItems(long PriceCatalogueID)
		{
			return Inventory.Bind_StockAdditionalItems(PriceCatalogueID);
		}

		public long Copy_Inventory(int CompanyID, long InventoryID, int InStock)
		{
			return Inventory.Copy_Inventory(CompanyID, InventoryID, InStock);
		}

		public static DataTable Fetch_Inventory_Dependancy(long CompanyID, long InventoryID)
		{
			return Inventory.Fetch_Inventory_Dependancy(CompanyID, InventoryID);
		}

		public static void FinishedGoods_AccountingCode_Insert(long CompanyID, long FinishedGoodsID, int AccountCodeID)
		{
			Inventory.FinishedGoods_AccountingCode_Insert(CompanyID, FinishedGoodsID, AccountCodeID);
		}

		public static int FinishedGoods_AccountingCode_Select(long CompanyID, long FinishedGoodsID)
		{
			return Inventory.FinishedGoods_AccountingCode_Select(CompanyID, FinishedGoodsID);
		}

		public static decimal finishedgoods_getPackedIn_qty(int CompanyID, int FinishedGoodsID, char GoodsType)
		{
			return Inventory.finishedgoods_getPackedIn_qty(CompanyID, FinishedGoodsID, GoodsType);
		}

		public static string GetUserEmail(int CompanyID, int UserID)
		{
			return Inventory.GetUserEmail(CompanyID, UserID);
		}

		public static void Inventory_AccountingCode_Insert(long CompanyID, long InventoryID, int AccountCodeID)
		{
			Inventory.Inventory_AccountingCode_Insert(CompanyID, InventoryID, AccountCodeID);
		}

		public static int Inventory_AccountingCode_Select(long CompanyID, long InventoryID)
		{
			return Inventory.Inventory_AccountingCode_Select(CompanyID, InventoryID);
		}

		public static DataTable Inventory_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate)
		{
			return Inventory.Inventory_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate);
		}

		public static decimal inventory_getPackedIn_qty(int CompanyID, int InventoryID)
		{
			return Inventory.inventory_getPackedIn_qty(CompanyID, InventoryID);
		}

		public static void Inventory_InventoryAlerts_On_Insert_Update(long InventoryID, string AlertType, string AlertEmailID, string Reason)
		{
			Inventory.Inventory_InventoryAlerts_On_Insert_Update(InventoryID, AlertType, AlertEmailID, Reason);
		}

		public static DataSet inventory_selectall(int CompanyID, string ItemType, string PaperType, string InkType)
		{
			return Inventory.inventory_selectall(CompanyID, ItemType, PaperType, InkType);
		}

		public static DataSet inventory_SelectLargeFormat(int CompanyID, string ItemType)
		{
			return Inventory.inventory_SelectLargeFormat(CompanyID, ItemType);
		}

		public static void InventoryItem_Update(int CompanyID, string InventoryCode, int Quantity, string Description, int userID, long PurchaseItemID)
		{
			Inventory.InventoryItem_Update(CompanyID, InventoryCode, Quantity, Description, userID, PurchaseItemID);
		}

		public static void Litho_Bind_coverage_popup(TextBox txtbx, int sqlParameter1, int count, int PressID, string type, long Estimateitemid, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string sidenumber, string PressChangeVal, string Esttype)
		{
			if (type.ToLower().Trim() == "add")
			{
				IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader.Read())
				{
					txtbx.Text = dataReader["coverage"].ToString();
				}
				return;
			}
			if (type.ToLower().Trim() == "edit" && PressChangeVal.ToString().ToLower() == "yes")
			{
				IDataReader dataReader1 = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader1.Read())
				{
					txtbx.Text = dataReader1["coverage"].ToString();
				}
				return;
			}
			if (type.ToLower().Trim() == "edit" && (Esttype == "K" || Esttype == "N") && (EstimateLithoNCRItemID == (long)0 || EstimateLithobookletItemID == (long)0))
			{
				IDataReader dataReader2 = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader2.Read())
				{
					txtbx.Text = dataReader2["coverage"].ToString();
				}
				return;
			}
			IDataReader dataReader3 = EstimatesBasePage.estimate_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count, Estimateitemid, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, sidenumber);
			while (dataReader3.Read())
			{
				txtbx.Text = dataReader3["coverage"].ToString();
			}
		}

		public static void Litho_Bind_ink_popup(DropDownList ddl, int sqlParameter1, string defaultValue, int count, int PressID, string type, long Estimateitemid, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string InkType, string sidenumber)
		{
			ddl.DataSource = InventoryBasePage.warehouse_inventory_selectink(sqlParameter1, "inks", InkType);
			ddl.DataTextField = "InkInventoryName";
			ddl.DataValueField = "InventoryID";
			ddl.DataBind();
			ddl.Items.Insert(0, " ");
			ddl.Items[0].Text = defaultValue;
			ddl.Items[0].Value = "0";
			if (type.ToLower().Trim() == "add")
			{
				IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader.Read())
				{
					InventoryBasePage.SetDDLValue(ddl, dataReader["InkID"].ToString());
				}
				return;
			}
			IDataReader dataReader1 = EstimatesBasePage.estimate_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count, Estimateitemid, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, sidenumber);
			while (dataReader1.Read())
			{
				InventoryBasePage.SetDDLValue(ddl, dataReader1["InkID"].ToString());
			}
		}

		public static void Litho_Bind_Inkname_popup(TextBox txt, Label lbl, int sqlParameter1, string defaultValue, int count, int PressID, string type, long Estimateitemid, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string InkType, string sidenumber, string PressChangeVal, string Esttype)
		{
			BaseClass baseClass = new BaseClass();
			InventoryBasePage.warehouse_inventory_selectink(sqlParameter1, "inks", InkType);
			if (type.ToLower().Trim() == "add")
			{
				IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader.Read())
				{
					txt.Text = baseClass.SpecialDecode(dataReader["inventoryname"].ToString());
					lbl.Text = dataReader["inkid"].ToString();
				}
				return;
			}
			if (type.ToLower().Trim() == "edit" && PressChangeVal.ToString().ToLower() == "yes")
			{
				IDataReader dataReader1 = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader1.Read())
				{
					txt.Text = baseClass.SpecialDecode(dataReader1["inventoryname"].ToString());
					lbl.Text = dataReader1["inkid"].ToString();
				}
				return;
			}
			if (type.ToLower().Trim() == "edit" && (Esttype == "K" || Esttype == "N") && (EstimateLithoNCRItemID == (long)0 || EstimateLithobookletItemID == (long)0))
			{
				IDataReader dataReader2 = SettingsBasePage.settings_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count);
				while (dataReader2.Read())
				{
					txt.Text = baseClass.SpecialDecode(dataReader2["inventoryname"].ToString());
					lbl.Text = dataReader2["inkid"].ToString();
				}
				return;
			}
			IDataReader dataReader3 = EstimatesBasePage.estimate_lithopress_select_ink_rownum(sqlParameter1, (long)PressID, count, Estimateitemid, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, sidenumber);
			while (dataReader3.Read())
			{
				txt.Text = baseClass.SpecialDecode(dataReader3["inventoryname"].ToString());
				lbl.Text = dataReader3["inkid"].ToString();
			}
		}

		public static DataTable Select_Activity_History_For_Inventory(long InventoryID)
		{
			return Inventory.Select_Activity_History_For_Inventory(InventoryID);
		}

		public static DataSet Select_finishedgoods_for_Estimate(int CompanyID, char finishedgoodstype, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			return Inventory.Select_finishedgoods_for_Estimate(CompanyID, finishedgoodstype, PageSize, PageNumber, SortedBy, Direction, para);
		}

		public static DataSet Select_Inventory_Select_Estimate(int CompanyID, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			return Inventory.Select_Inventory_Select_Estimate(CompanyID, PageSize, PageNumber, SortedBy, Direction, para);
		}

		public static DataSet SelectProductcatalogueitems_InPurchse(int CompanyID, int PageSize, int PageNumber, string WhereCondition)
		{
			return Inventory.SelectProductcatalogueitems_InPurchse(CompanyID, PageSize, PageNumber, WhereCondition);
		}

		public static void SetDDLText(DropDownList ddl, string text)
		{
			try
			{
				ListItem listItem = ddl.Items.FindByText(text);
				ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
			}
			catch
			{
			}
		}

		public static void SetDDLValue(DropDownList ddl, string value)
		{
			try
			{
				ListItem listItem = ddl.Items.FindByValue(value);
				ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
			}
			catch
			{
			}
		}

		public DataTable settings_InvCategory_selectall(int CompanyID, string CategoryName)
		{
			return Inventory.settings_InvCategory_selectall(CompanyID, CategoryName);
		}

		public DataTable settings_inventoryproperties_name_select(int CompanyID)
		{
			return Inventory.settings_inventoryproperties_name_select(CompanyID);
		}

		public DataTable settings_inventoryproperties_name_select_by_categoryID(int CompanyID, int CategoryID)
		{
			return Inventory.settings_inventoryproperties_name_select_by_categoryID(CompanyID, CategoryID);
		}

		public int settings_stockcategory_delete(int CompanyID, int CategoryID)
		{
			return Inventory.settings_stockcategory_delete(CompanyID, CategoryID);
		}

		public int settings_stockcategory_insert(int companyID, string categoryCode, string categoryName, string description, bool isWeight, bool isColor, bool isItemCustomSize, bool isItemPaperSize, bool isCoatingType, bool isPrinting)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				CategoryCode = categoryCode,
				CategoryName = categoryName,
				Description = description,
				IsWeight = isWeight,
				IsColor = isColor,
				IsItemCustomSize = isItemCustomSize,
				IsItemPaperSize = isItemPaperSize,
				IsCoatingType = isCoatingType,
				IsPrinting = isPrinting
			};
			return Inventory.settings_stockcategory_insert(inventoryItem);
		}

		public DataTable settings_stockcategory_select(int CompanyID, int CategoryID)
		{
			return Inventory.settings_stockcategory_select(CompanyID, CategoryID);
		}

		public DataTable settings_stockcategory_selectall(int CompanyID)
		{
			return Inventory.settings_stockcategory_selectall(CompanyID);
		}

		public int settings_stockcategory_update(int companyID, int categoryID, string categoryCode, string categoryName, string description, bool isWeight, bool isColor, bool isItemCustomSize, bool isItemPaperSize, bool isCoatingType, bool isPrinting)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				CategoryID = categoryID,
				CategoryCode = categoryCode,
				CategoryName = categoryName,
				Description = description,
				IsWeight = isWeight,
				IsColor = isColor,
				IsItemCustomSize = isItemCustomSize,
				IsItemPaperSize = isItemPaperSize,
				IsCoatingType = isCoatingType,
				IsPrinting = isPrinting,
			};
			return Inventory.settings_stockcategory_update(inventoryItem);
		}

		public int settings_stocksubcategory_delete(int CompanyID, int SubCategoryID)
		{
			return Inventory.settings_stocksubcategory_delete(this.companyID, SubCategoryID);
		}

		public int settings_stocksubcategory_insert(int companyID, int parentCategory, string subCategoryCode, string subCategoryName, string description)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				CategoryID = parentCategory,
				SubCategoryCode = subCategoryCode,
				SubCategoryName = subCategoryName,
				Description = description
			};
			return Inventory.settings_stocksubcategory_insert(inventoryItem);
		}

		public DataTable settings_stocksubcategory_select(int CompanyID, int SubCategoryID)
		{
			return Inventory.settings_stocksubcategory_select(CompanyID, SubCategoryID);
		}

		public DataTable settings_stocksubcategory_select_by_categoryid(int CompanyID, int ParentCategory)
		{
			return Inventory.settings_stocksubcategory_select_by_categoryid(CompanyID, ParentCategory);
		}

		public DataTable settings_stocksubcategory_selectall(int CompanyID)
		{
			return Inventory.settings_stocksubcategory_selectall(CompanyID);
		}

		public int settings_stocksubcategory_update(int companyID, int subCategoryID, int parentCategory, string subCategoryCode, string subCategoryName, string description)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				SubCategoryID = subCategoryID,
				CategoryID = parentCategory,
				SubCategoryCode = subCategoryCode,
				SubCategoryName = subCategoryName,
				Description = description
			};
			return Inventory.settings_stocksubcategory_update(inventoryItem);
		}

		public DataTable settings_subcategoryonID_selectall(int ParentCategory)
		{
			return Inventory.settings_subcategoryonID_selectall(ParentCategory);
		}

		public static DataTable Warehouse_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string pagetype, string TodayDate, string StartDate, string EndDate)
		{
			return Inventory.Warehouse_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, pagetype, TodayDate, StartDate, EndDate);
		}

		public long warehouse_code_select(int companyid, string type)
		{
			return Inventory.warehouse_code_select(companyid, type);
		}

		public void warehouse_code_update(int companyid, string type, long lastcount)
		{
			Inventory.warehouse_code_update(companyid, type, lastcount);
		}

		public int warehouse_finished_goods_duplicacy_check(int CompanyID, string ProductName, string ProductCode, long GoodsID, string GooodsType)
		{
			return Inventory.warehouse_finished_goods_duplicacy_check(CompanyID, ProductName, ProductCode, GoodsID, GooodsType);
		}

		public void warehouse_finishedgoods_archive(int companyid, int goodsid)
		{
			Inventory.warehouse_finishedgoods_archive(companyid, goodsid);
		}

		public void warehouse_finishedgoods_delete(int companyid, int goodsid)
		{
			Inventory.warehouse_finishedgoods_delete(companyid, goodsid);
		}

		public void warehouse_finishedgoods_edit(int companyid, int goodsid, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			Inventory.warehouse_finishedgoods_edit(companyid, goodsid, customerid, supplierid, barcode, productname, productcode, location, supplierPartNo, taxID, packQuantity, packCostPrice, markup, packSalePrice, inStockQuantity, reOrderLevel, reorderQuantity, description, ProfitMargin);
		}

		public static DataSet warehouse_finishedgoods_forestimate_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int CustomerID)
		{
			return Inventory.warehouse_finishedgoods_forestimate_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, CustomerID);
		}

		public int warehouse_finishedgoods_insert(int companyid, char goodstype, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			return Inventory.warehouse_finishedgoods_insert(companyid, goodstype, customerid, supplierid, barcode, productname, productcode, location, supplierPartNo, taxID, packQuantity, packCostPrice, markup, packSalePrice, inStockQuantity, reOrderLevel, reorderQuantity, description, ProfitMargin);
		}

		public static DataSet warehouse_finishedgoods_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			return Inventory.warehouse_finishedgoods_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataTable warehouse_finishedgoods_search(int CompanyID, string FinishedgoodType, string SearchText)
		{
			return Inventory.warehouse_finishedgoods_search(CompanyID, FinishedgoodType, SearchText);
		}

		public void warehouse_finishedgoods_select(int companyid, int goodsid, char goodstype, TextBox txtbarcode, TextBox txtproductname, TextBox txtproductcode, TextBox txtlocation, DropDownList ddlsupplier, TextBox txtpartNo, DropDownList ddltax, TextBox txtpackquentity, TextBox txtPackCostPrice, DropDownList ddlmarkup, HiddenField hid_packprice, TextBox txtInstock, TextBox txtReOrderLevel, TextBox txtReorderQuantity, DropDownList ddlcustomer, TextBox txtdecription, TextBox txtProfitMargin, HiddenField hdn_ArchiveID)
		{
			Inventory.warehouse_finishedgoods_select(companyid, goodsid, goodstype, txtbarcode, txtproductname, txtproductcode, txtlocation, ddlsupplier, txtpartNo, ddltax, txtpackquentity, txtPackCostPrice, ddlmarkup, hid_packprice, txtInstock, txtReOrderLevel, txtReorderQuantity, ddlcustomer, txtdecription, txtProfitMargin, hdn_ArchiveID);
		}

		public void warehouse_finishedgoods_unarchive(int companyid, int goodsid)
		{
			Inventory.warehouse_finishedgoods_unarchive(companyid, goodsid);
		}

		public void warehouse_inventory_adjustment_update(int CompanyID, long InventoryID, long InventoryPropertyID, int InStock, decimal Cost)
		{
			Inventory.warehouse_inventory_adjustment_update(CompanyID, InventoryID, InventoryPropertyID, InStock, Cost);
		}

		public static DataSet Warehouse_Inventory_AllSupplier_Select(int CompanyID)
		{
			return Inventory.Warehouse_Inventory_AllSupplier_Select(CompanyID);
		}

		public void warehouse_inventory_archive(int CompanyID, long InventoryID)
		{
			Inventory.warehouse_inventory_archive(CompanyID, InventoryID);
		}

		public void warehouse_inventory_delete(int CompanyID, long InventoryID)
		{
			Inventory.warehouse_inventory_delete(CompanyID, InventoryID);
		}

		public int warehouse_inventory_insert(int companyID, string inventoryName, string friendlyName, string inventoryCode, int inventoryCategoryID, string description, string location, int supplierID, decimal inStock, decimal reOrderLevel, int reOrderQuantity, int AllocatedQty, bool IsLargeFormatMaterial)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryName = inventoryName,
				FriendlyName = friendlyName,
				InventoryCode = inventoryCode,
				InventoryCategoryID = inventoryCategoryID,
				Description = description,
				Location = location,
				SupplierID = supplierID,
				InvInStock = inStock,
				ReOrderLevel = reOrderLevel,
				ReOrderQuantity = reOrderQuantity,
				AllocatedQty = AllocatedQty,
				IsLargeFormatMaterial = IsLargeFormatMaterial
			};
			return Inventory.warehouse_inventory_insert(inventoryItem);
		}

		public DataTable warehouse_inventory_search(int CompanyID, string SearchText)
		{
			return Inventory.warehouse_inventory_search(CompanyID, SearchText);
		}

		public DataTable warehouse_inventory_select(int CompanyID, long InventoryID)
		{
			return Inventory.warehouse_inventory_select(CompanyID, InventoryID);
		}

		public DataTable warehouse_inventory_selectall(int CompanyID, string ItemType, string SearchText)
		{
			return Inventory.warehouse_inventory_selectall(CompanyID, ItemType, SearchText);
		}

		public static DataTable warehouse_inventory_selectall_onclientid(int CompanyID, int ClientID, string ItemType)
		{
			return Inventory.warehouse_inventory_selectall_onclientid(CompanyID, ClientID, ItemType);
		}

		public static DataSet warehouse_inventory_selectall_onclientid_PageText(int CompanyID, int ClientID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			return Inventory.warehouse_inventory_selectall_onclientid_PageText(CompanyID, ClientID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataSet warehouse_inventory_selectall_PageText(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string PaperType, string InkType)
		{
			return Inventory.warehouse_inventory_selectall_PageText(CompanyID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, PaperType, InkType);
		}

		public static DataTable warehouse_inventory_selectink(int CompanyID, string ItemType, string InkType)
		{
			return Inventory.warehouse_inventory_selectink(CompanyID, ItemType, InkType);
		}

		public static DataTable warehouse_inventory_selectink_withinktype(int CompanyID, long LithoPressID)
		{
			return Inventory.warehouse_inventory_selectink_withinktype(CompanyID, LithoPressID);
		}

		public static DataSet warehouse_inventory_selectLargeFormat(int CompanyID, string ItemType, string SearchText)
		{
			return Inventory.warehouse_inventory_selectLargeFormat(CompanyID, ItemType, SearchText);
		}

		public void warehouse_inventory_unarchive(int CompanyID, long InventoryID)
		{
			Inventory.warehouse_inventory_unarchive(CompanyID, InventoryID);
		}

		public int warehouse_inventory_update(int companyID, long inventoryID, string inventoryName, string friendlyName, string inventoryCode, int inventoryCategoryID, string description, string location, int supplierID, decimal inStock, decimal reOrderLevel, int reOrderQuantity, decimal AllocatedQty, bool IsLargeFormatMaterial)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryID = inventoryID,
				InventoryName = inventoryName,
				FriendlyName = friendlyName,
				InventoryCode = inventoryCode,
				InventoryCategoryID = inventoryCategoryID,
				Description = description,
				Location = location,
				SupplierID = supplierID,
				InStock = inStock,
				ReOrderLevel = reOrderLevel,
				ReOrderQuantity = reOrderQuantity,
				AllocatedQty = AllocatedQty,
				IsLargeFormatMaterial = IsLargeFormatMaterial
			};
			return Inventory.warehouse_inventory_update(inventoryItem);
		}

		public int warehouse_inventoryduplicacy_check(int companyID, string inventoryName, string inventoryCode, long inventoryID)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryName = inventoryName,
				InventoryCode = inventoryCode,
				InventoryID = inventoryID
			};
			return Inventory.warehouse_inventoryduplicacy_check(inventoryItem);
		}

		public int warehouse_inventoryinkMatrix_insert(int companyID, long inventoryID, long InventorySheetsFrom, long InventorySheetsTo, decimal ChargableCost, long ChargableSheets, decimal SetUpCost)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryID = inventoryID,
				InventorySheetsFrom = InventorySheetsFrom,
				InventorySheetsTo = InventorySheetsTo,
				ChargableCost = ChargableCost,
				ChargableSheets = ChargableSheets,
				SetUpCost = SetUpCost
			};
			return Inventory.warehouse_inventoryinkMatrix_insert(inventoryItem);
		}

		public static DataTable warehouse_inventoryinkMatrix_select(int CompanyID, long InventoryID)
		{
			return Inventory.warehouse_inventoryinkMatrix_select(CompanyID, InventoryID);
		}

		public void warehouse_inventoryinkMatrix_Update(int companyID, long inventoryID, long InkMatrixId, long InventorySheetsFrom, long InventorySheetsTo, decimal ChargableCost, long ChargableSheets, decimal SetUpCost)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryID = inventoryID,
				InkMatrixId = InkMatrixId,
				InventorySheetsFrom = InventorySheetsFrom,
				InventorySheetsTo = InventorySheetsTo,
				ChargableCost = ChargableCost,
				ChargableSheets = ChargableSheets,
				SetUpCost = SetUpCost
			};
			Inventory.warehouse_inventoryinkMatrix_Update(inventoryItem);
		}
		//Ticket 81174
		public int warehouse_inventoryproperties_insert(int companyID, int inventoryID, decimal cost, decimal perQuantity, decimal packedIn, decimal packedPrice, decimal processCharge, decimal sellingPrice, decimal costPerReel, int paperSizeID, decimal height, decimal width, string widthType, decimal length, string lengthType, decimal basisWeight, string coated, string colour, string paperType, decimal inkAbsorption, int washupCounter, decimal yield, string yieldType, string packedInType, string InkType, decimal InkMinimumCost, decimal CostPerLinear, decimal Markup,decimal Caliper)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryID = (long)inventoryID,
				Cost = cost,
				InvPerQuantity = perQuantity,
				InvPackedIn = packedIn,
				PackedPrice = packedPrice,
				ProcessCharge = processCharge,
				SellingPrice = sellingPrice,
				CostPerReel = costPerReel,
				PaperSizeID = paperSizeID,
				Height = height,
				Width = width,
				WidthType = widthType,
				InvLength = length,
				LengthType = lengthType,
				BasisWeight = basisWeight,
				Coated = coated,
				Colour = colour,
				PaperType = paperType,
				InkAbsorption = inkAbsorption,
				WashupCounter = washupCounter,
				Yield = yield,
				YieldType = yieldType,
				PackedInType = packedInType,
				InkType = InkType,
				InkMinimumCost = InkMinimumCost,
				CostPerLinear = CostPerLinear,
				Markup = Markup,
				Caliper = Caliper
            };
			return Inventory.warehouse_inventoryproperties_insert(inventoryItem);
		}

		public DataTable warehouse_inventoryproperties_select(int CompanyID, long InventoryID)
		{
			return Inventory.warehouse_inventoryproperties_select(CompanyID, InventoryID);
		}
		//Ticket 81174
		public int warehouse_inventoryproperties_update(int companyID, long inventoryID, decimal cost, decimal perQuantity, decimal packedIn, decimal packedPrice, decimal processCharge, decimal sellingPrice, decimal costPerReel, int paperSizeID, decimal height, decimal width, string widthType, decimal length, string lengthType, decimal basisWeight, string coated, string colour, string paperType, decimal inkAbsorption, int washupCounter, decimal yield, string yieldType, string packedInType, string InkType, decimal InkMinimumCost, decimal ConvCostPerLinear, decimal Markup,decimal Caliper)
		{
			InventoryItem inventoryItem = new InventoryItem()
			{
				CompanyID = companyID,
				InventoryID = inventoryID,
				Cost = cost,
				InvPerQuantity = perQuantity,
				InvPackedIn = packedIn,
				PackedPrice = packedPrice,
				ProcessCharge = processCharge,
				SellingPrice = sellingPrice,
				CostPerReel = costPerReel,
				PaperSizeID = paperSizeID,
				Height = height,
				Width = width,
				WidthType = widthType,
				InvLength = length,
				LengthType = lengthType,
				BasisWeight = basisWeight,
				Coated = coated,
				Colour = colour,
				PaperType = paperType,
				InkAbsorption = inkAbsorption,
				WashupCounter = washupCounter,
				Yield = yield,
				YieldType = yieldType,
				PackedInType = packedInType,
				InkType = InkType,
				InkMinimumCost = InkMinimumCost,
				CostPerLinear = ConvCostPerLinear,
                Markup = Markup,
				Caliper = Caliper
            };
			return Inventory.warehouse_inventoryproperties_update(inventoryItem);
		}
        public static DataTable uppernavigator_select(int CompanyID, string moduleName,int userid)
        {
            return Inventory.uppernavigator_select(CompanyID, moduleName, userid);
        }
    }
}