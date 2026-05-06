using iTextSharp.text.pdf;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Estimates;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.warehouse
{
    public partial class inventory_store_customer_view : UserControl
    {
    

	public string strImagepath = global.imagePath();

	public string strSitepath = global.sitePath();

	private Global gloobj = new Global();

	private BaseClass objBase = new BaseClass();

	private InventoryBasePage objInv = new InventoryBasePage();

	private SetProperties objSp = new SetProperties();

	public commonClass cmnDate = new commonClass();

	public languageClass objLanguage = new languageClass();

	private SettingsBasePage objSet = new SettingsBasePage();

	public string InventoryManagement = ConnectionClass.InventoryManagement;

	private string para = "";

	public string type = string.Empty;

	public string url = string.Empty;

	public int CompanyID;

	public string ItemType = string.Empty;

	public int totalrec;

	public int UserID;

	public int defaultviewid;

	public string defaultsortedby = string.Empty;

	public string defaultsortdirection = string.Empty;

	public string cellvalue_instockquantity = string.Empty;

	public string flag_instockquantity = string.Empty;

	public string cellvalue_packquantity = string.Empty;

	public string flag_packquantity = string.Empty;

	public string cellvalue_packcostprice = string.Empty;

	public string flag_packcostprice = string.Empty;

	public string cellvalue_createddate = string.Empty;

	public string flag_createddate = string.Empty;

	public string cellvalue_unitprice = string.Empty;

	public string flag_unitprice = string.Empty;

	public string cellvalue_height = string.Empty;

	public string flag_customheight = string.Empty;

	public string cellvalue_stocktype = string.Empty;

	public string cellvalue_cost = string.Empty;

	public string flag_cost = string.Empty;

	public string cellvalue_stockType = string.Empty;

	public string flag_stockType = string.Empty;

	public string cellvalue_suppName = string.Empty;

	public string flag_suppName = string.Empty;

	public string cellvalue_Name = string.Empty;

	public string flag_Name = string.Empty;

	public string cellvalue_Description = string.Empty;

	public string flag_Description = string.Empty;

	public string cellvalue_IsArchive = string.Empty;

	public string flag_IsArchive = string.Empty;

	public string flag_Is_archived = string.Empty;

	public string cellvalue_isarchived = string.Empty;

	public string cellvalue_Availableqty = string.Empty;

	public string flag_Availableqty = string.Empty;

	public string cellvalue_Location = string.Empty;

	public string flag_Location = string.Empty;

	public string flag_createddate_item = string.Empty;

	public string flag_instockquantity_item = string.Empty;

	public string flag_packquantity_item = string.Empty;

	public string flag_packcostprice_item = string.Empty;

	public string flag_unitprice_item = string.Empty;

	public string flag_IsArchive_item = string.Empty;

	public string cellvalue_custName = string.Empty;

	public string flag_custName = string.Empty;

	public string cellvalue_Action = string.Empty;

	public string flag_Action = string.Empty;

	public string flag_createddate_store = string.Empty;

	public string flag_instockquantity_store = string.Empty;

	public string flag_packquantity_store = string.Empty;

	public string flag_packcostprice_store = string.Empty;

	public string flag_unitprice_store = string.Empty;

	public string cellvalue_prodName_store = string.Empty;

	public string flag_prodName_store = string.Empty;

	public string cellvalue_inventoryno = string.Empty;

	public string flag_inventoryno = string.Empty;

	public string cellvalue_friendlyname = string.Empty;

	public string flag_friendlyname = string.Empty;

	public string cellvalue_color = string.Empty;

	public string flag_color = string.Empty;

	public string ColorValue = string.Empty;

	public string type2 = "40px";

	public string type3 = "65px";

	public string type4 = "100px";

	public string type1 = "80px";

	public string type0 = "30px";

	public string type5 = "120px";

	public string type6 = "130px";

	public static string WhereCondition;

	public static string sortdirection;

	public static string SortedBy;

	public static string WhereConditionstore;

	public static string sortdirectionstore;

	public static string SortedBystore;

	public static string WhereConditionItem;

	public static string sortdirectionItem;

	public static string SortedByItem;

	public DataTable dt = new DataTable();

	public string pg;

	public languageClass objLangClass = new languageClass();

	private DataTable dtsearchInv = new DataTable();

	private DataTable dtsearchStore = new DataTable();

	private DataTable dtsearchItem = new DataTable();

	public string DateFormat = string.Empty;

	private createViewClass objCreateView = new createViewClass();

	private BasePage objpage = new BasePage();

	public string PaperMeasure = string.Empty;

	public string WeightMeasure = string.Empty;

	public string MeterMeasure = string.Empty;

	public static int InvenotoryPageSize;

	public int ViewID;

	public string VersionNumber = ConnectionClass.VersionNumber;

	public string Archive_Row_Selection_Alert = string.Empty;

	public string Delete_Row_Selection_Alert = string.Empty;

	public string UnArchive_Row_Selection_Alert = string.Empty;

	private string _InvenotoryInk = string.Empty;

	private string _IamFrom = string.Empty;

	private static bool ItemClick;

	public string AddStatus = string.Empty;

	public string DeleteStatus = string.Empty;

	protected Global ApplicationInstance
	{
		get
		{
			return (Global)this.Context.ApplicationInstance;
		}
	}

	public string IamFrom
	{
		get
		{
			return this._IamFrom;
		}
		set
		{
			this._IamFrom = value;
		}
	}

	public string InvenotoryInk
	{
		get
		{
			return this._InvenotoryInk;
		}
		set
		{
			this._InvenotoryInk = value;
		}
	}

	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}

	static inventory_store_customer_view()
	{
		inventory_store_customer_view.WhereCondition = string.Empty;
		inventory_store_customer_view.sortdirection = string.Empty;
		inventory_store_customer_view.SortedBy = string.Empty;
		inventory_store_customer_view.WhereConditionstore = string.Empty;
		inventory_store_customer_view.sortdirectionstore = string.Empty;
		inventory_store_customer_view.SortedBystore = string.Empty;
		inventory_store_customer_view.WhereConditionItem = string.Empty;
		inventory_store_customer_view.sortdirectionItem = string.Empty;
		inventory_store_customer_view.SortedByItem = string.Empty;
		inventory_store_customer_view.InvenotoryPageSize = 50;
		inventory_store_customer_view.ItemClick = false;
	}

	public inventory_store_customer_view()
	{
	}

	public void AddBoundColumns_inventory(DataTable dt, RadGrid gv)
	{
		if (!base.IsPostBack)
		{
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				GridBoundColumn gridBoundColumn = new GridBoundColumn();
				this.GridViewInv.MasterTableView.Columns.Add(gridBoundColumn);
				gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
				gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
				gridBoundColumn.DataField = dt.Columns[i].ColumnName;
				gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
				gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
				gridBoundColumn.AutoPostBackOnFilter = true;
				if (dt.Columns[i].ColumnName.ToLower() == "action")
				{
					gridBoundColumn.AllowFiltering = false;
				}
					if (dt.Columns[i].ColumnName.ToLower() == "createddate")
				{
					gridBoundColumn.DataType = Type.GetType("System.DateTime");
					gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
				}
				else if (dt.Columns[i].ColumnName.ToLower() == "isarchived")
				{
					gridBoundColumn.DataType = Type.GetType("System.Int32");
					gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
				}
				else if (dt.Columns[i].ColumnName.ToLower() == "availablequantity")
				{
					gridBoundColumn.DataType = Type.GetType("System.Int32");
					gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
				}
			}
			for (int j = 0; j < this.GridViewInv.Columns.Count; j++)
			{
				this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
				this.GridViewInv.Columns[j].HeaderStyle.Wrap = false;
				if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "inventorycode")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Inventory_Code");
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.flag_inventoryno = "true";
					this.cellvalue_inventoryno = this.GridViewInv.Columns[j].SortExpression.ToLower();
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "inventoryname")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Inventory_Name");
					this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.flag_Name = "true";
					this.cellvalue_Name = this.GridViewInv.Columns[j].SortExpression.ToLower();
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "friendlyname")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Friendly_Name");
					this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.flag_friendlyname = "true";
					this.cellvalue_friendlyname = this.GridViewInv.Columns[j].SortExpression.ToLower();
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "colour")
				{
					this.GridViewInv.Columns[j].HeaderText = this.ColorValue;
					this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.flag_color = "true";
					this.cellvalue_color = this.GridViewInv.Columns[j].SortExpression.ToLower();
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "suppliername")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Supplier_Name");
					this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.flag_suppName = "true";
					this.cellvalue_suppName = this.GridViewInv.Columns[j].SortExpression.ToLower();
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "customheight")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Weight_Size");
					this.cellvalue_height = this.GridViewInv.Columns[j].SortExpression;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "customstocktype")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Stock_Type");
					this.cellvalue_stocktype = this.GridViewInv.Columns[j].SortExpression;
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.GridViewInv.Columns[j].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "action")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Action");
					this.flag_Action = "true";
					this.cellvalue_Action = this.GridViewInv.Columns[j].SortExpression.ToLower();
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.GridViewInv.HeaderStyle.Width = Unit.Pixel(100);
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "width")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "height")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "length")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "widthtype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "lengthtype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "papertype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "packedin")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "packedintype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "basisweight")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "papername")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "stocktype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "chargablesheets")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "inktype")
				{
					this.GridViewInv.Columns[j].Visible = false;
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "cost")
				{
					this.GridViewInv.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Cost"), " (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.cellvalue_cost = this.GridViewInv.Columns[j].SortExpression;
					this.flag_cost = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "unitprice")
				{
					this.GridViewInv.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Unit_Price"), " (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
					this.cellvalue_unitprice = this.GridViewInv.Columns[j].SortExpression;
					this.flag_unitprice = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "isarchived")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Archived");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					this.cellvalue_IsArchive = this.GridViewInv.Columns[j].SortExpression;
					this.flag_IsArchive = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "createddate")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Created_On");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					this.cellvalue_createddate = this.GridViewInv.Columns[j].SortExpression;
					this.flag_createddate = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "availablequantity")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Available_Qty");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_Availableqty = this.GridViewInv.Columns[j].SortExpression;
					this.flag_Availableqty = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "location")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Location");
					this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
					this.cellvalue_Location = this.GridViewInv.Columns[j].SortExpression;
					this.flag_Location = "true";
				}
				else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "description")
				{
					this.GridViewInv.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Description");
				}
			}
		}
	}

	public void AddBoundColumns_item(DataTable dt, RadGrid gv)
	{
		if (!base.IsPostBack)
		{
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				GridBoundColumn gridBoundColumn = new GridBoundColumn();
				this.GridCustomerItem.Columns.Add(gridBoundColumn);
				gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
				gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
				gridBoundColumn.DataField = dt.Columns[i].ColumnName;
				gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
				gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
				gridBoundColumn.AutoPostBackOnFilter = true;
				if (dt.Columns[i].ColumnName.ToLower() == "createddate")
				{
					gridBoundColumn.DataType = Type.GetType("System.DateTime");
				}
				else if (dt.Columns[i].ColumnName.ToLower() == "isarchived")
				{
					gridBoundColumn.DataType = Type.GetType("System.Int32");
				}
			}
			for (int j = 0; j < this.GridCustomerItem.Columns.Count; j++)
			{
				this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
				this.GridCustomerItem.Columns[j].HeaderStyle.Wrap = false;
				if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "productcode")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Product Code";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "customerid")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Customer Name";
					this.GridCustomerItem.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridCustomerItem.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridCustomerItem.Columns[j].ItemStyle.Wrap = false;
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "productname")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Product Name";
					this.GridCustomerItem.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridCustomerItem.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridCustomerItem.Columns[j].ItemStyle.Wrap = false;
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "instockquantity")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "In Stock Qty";
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_instockquantity = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_instockquantity = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "packquantity")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Pack Qty";
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_packquantity = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_packquantity = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "packcostprice")
				{
					this.GridCustomerItem.Columns[j].HeaderText = string.Concat("Pack Cost Price (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_packcostprice = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_packcostprice = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "unitprice")
				{
					this.GridCustomerItem.Columns[j].HeaderText = string.Concat("Unit Price (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_unitprice = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_unitprice = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "isarchived")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Archived";
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_IsArchive = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_IsArchive_item = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "createddate")
				{
					this.GridCustomerItem.Columns[j].HeaderText = "Created On";
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					this.cellvalue_createddate = this.GridCustomerItem.Columns[j].SortExpression;
					this.flag_createddate = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "action")
				{
					this.GridCustomerItem.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Action");
					this.flag_Action = "true";
					this.cellvalue_Action = this.GridCustomerItem.Columns[j].SortExpression.ToLower();
					this.GridCustomerItem.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.GridCustomerItem.HeaderStyle.Width = Unit.Pixel(100);
				}
			}
		}
	}

	public void AddBoundColumns_store(DataTable dt, RadGrid gv)
	{
		if (!base.IsPostBack)
		{
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				GridBoundColumn gridBoundColumn = new GridBoundColumn();
				this.GridStoreSupply.MasterTableView.Columns.Add(gridBoundColumn);
				gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
				gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
				gridBoundColumn.DataField = dt.Columns[i].ColumnName;
				gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
				gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
				gridBoundColumn.AutoPostBackOnFilter = true;
				if (dt.Columns[i].ColumnName.ToLower() == "createddate")
				{
					gridBoundColumn.DataType = Type.GetType("System.DateTime");
				}
				else if (dt.Columns[i].ColumnName.ToLower() == "isarchived")
				{
					gridBoundColumn.DataType = Type.GetType("System.Int32");
				}
			}
			for (int j = 0; j < this.GridStoreSupply.Columns.Count; j++)
			{
				this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
				this.GridStoreSupply.Columns[j].HeaderStyle.Wrap = false;
				if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "productcode")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "Product Code";
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "productname")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "Product Name";
					this.GridStoreSupply.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
					this.GridStoreSupply.Columns[j].ItemStyle.Width = Unit.Pixel(200);
					this.GridStoreSupply.Columns[j].ItemStyle.Wrap = false;
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "instockquantity")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "In Stock Qty";
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_instockquantity = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_instockquantity = "true";
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "packquantity")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "Pack Qty";
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_packquantity = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_packquantity = "true";
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "packcostprice")
				{
					this.GridStoreSupply.Columns[j].HeaderText = string.Concat("Pack Cost Price (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_packcostprice = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_packcostprice = "true";
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "unitprice")
				{
					this.GridStoreSupply.Columns[j].HeaderText = string.Concat("Unit Price (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.cellvalue_unitprice = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_unitprice = "true";
				}
				else if (this.GridCustomerItem.Columns[j].SortExpression.ToLower() == "action")
				{
					this.GridStoreSupply.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Action");
					this.flag_Action = "true";
					this.cellvalue_Action = this.GridStoreSupply.Columns[j].SortExpression.ToLower();
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					this.GridStoreSupply.HeaderStyle.Width = Unit.Pixel(100);
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "isarchived")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "Archived";
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					this.cellvalue_isarchived = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_Is_archived = "true";
				}
				else if (this.GridStoreSupply.Columns[j].SortExpression.ToLower() == "createddate")
				{
					this.GridStoreSupply.Columns[j].HeaderText = "Created On";
					this.GridStoreSupply.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					this.cellvalue_createddate = this.GridStoreSupply.Columns[j].SortExpression;
					this.flag_createddate = "true";
				}
			}
		}
	}

	public void btnEditViewInventory_Click(object sender, EventArgs e)
	{
		HttpResponse response = base.Response;
		object[] value = new object[] { "../warehouse/customviewinv.aspx?type=edit&id=", this.editInvViewID.Value, "&cid=", this.CompanyID };
		response.Redirect(string.Concat(value));
	}

	private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
	{
		TextBox textBox = (TextBox)this.Page.Master.FindControl("keywordsearch");
		if (textBox.Text != "")
		{
			this.para = textBox.Text;
			base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse_inventory_search.aspx?para=", this.para));
		}
	}

	protected void Call_When_Warehousetab()
	{
		if (this.type == "store")
		{
			this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, "false");
		}
		if (this.type == "item")
		{
			this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, "false");
		}
	}

	public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
	{
		if (FilterExpression.ToLower() != "nofilter")
		{
			base.Session[string.Concat("inv_", ColName.ToLower())] = value;
			return;
		}
		base.Session[string.Concat("inv_", ColName.ToLower())] = "";
	}

	protected void clrFilters_Click(object sender, EventArgs e)
	{
		if (this.type == "inventory")
		{
			inventory_store_customer_view.WhereCondition = "";
			base.Session["searchInv"] = null;
			foreach (GridColumn column in this.GridViewInv.MasterTableView.Columns)
			{
				column.CurrentFilterFunction = GridKnownFunction.NoFilter;
				column.CurrentFilterValue = string.Empty;
			}
			this.GridViewInv.MasterTableView.FilterExpression = string.Empty;
			this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
			this.GridViewInv.MasterTableView.Rebind();
			return;
		}
		if (this.type == "store")
		{
			inventory_store_customer_view.WhereConditionstore = "";
			base.Session["searchStore"] = null;
			foreach (GridColumn empty in this.GridStoreSupply.MasterTableView.Columns)
			{
				empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
				empty.CurrentFilterValue = string.Empty;
			}
			this.GridStoreSupply.MasterTableView.FilterExpression = string.Empty;
			this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
			this.GridStoreSupply.Rebind();
			return;
		}
		if (this.type == "item")
		{
			inventory_store_customer_view.WhereConditionItem = "";
			base.Session["searchItem"] = null;
			foreach (GridColumn gridColumn in this.GridCustomerItem.MasterTableView.Columns)
			{
				gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
				gridColumn.CurrentFilterValue = string.Empty;
			}
			this.GridCustomerItem.MasterTableView.FilterExpression = string.Empty;
			this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
			this.GridCustomerItem.MasterTableView.Rebind();
		}
	}

	public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		this.pg = "inventory";
		int num = 0;
		int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
		num = Convert.ToInt32(this.ddl_View.SelectedIndex);
		HttpCookie httpCookie = new HttpCookie("ckeEditviewID_inventory");
		httpCookie["Inventory_viewID"] = this.ddl_View.SelectedValue;
		base.Response.Cookies.Add(httpCookie);
		HttpResponse response = base.Response;
		object[] objArray = new object[] { this.strSitepath, "warehouse/warehouse.aspx?type=inventory&viewid=", num1, "&index=", num };
		response.Redirect(string.Concat(objArray));
	}

	public void ddlView1_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		this.pg = "store";
		int num = 0;
		int num1 = Convert.ToInt32(this.ddl_View1.SelectedValue);
		num = Convert.ToInt32(this.ddl_View1.SelectedIndex);
		HttpResponse response = base.Response;
		object[] objArray = new object[] { this.strSitepath, "warehouse/warehouse.aspx?type=store&viewid=", num1, "&index=", num };
		response.Redirect(string.Concat(objArray));
	}

	public void ddlView2_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		this.pg = "item";
		int num = 0;
		int num1 = Convert.ToInt32(this.ddl_View2.SelectedValue);
		num = Convert.ToInt32(this.ddl_View2.SelectedIndex);
		HttpResponse response = base.Response;
		object[] objArray = new object[] { this.strSitepath, "warehouse/warehouse.aspx?type=item&viewid=", num1, "&index=", num };
		response.Redirect(string.Concat(objArray));
	}

	public string FilterFunction(DataTable dtsearch)
	{
		int num = 0;
		string empty = string.Empty;
		string str = string.Empty;
		int num1 = 0;
		foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
		{
			num1 = Convert.ToInt32(row["Roundoff"].ToString());
		}
		base.Session["searchInv"] = dtsearch;
		foreach (DataRow dataRow in dtsearch.Rows)
		{
			if (dataRow["filter"].ToString().ToLower() != "nofilter" && inventory_store_customer_view.WhereCondition != "")
			{
				inventory_store_customer_view.WhereCondition = string.Concat(inventory_store_customer_view.WhereCondition, " and ");
			}
			if (dataRow["ColumnName"].ToString().ToLower() == "createddate")
			{
				str = this.cmnDate.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
				empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
			}
			else if (dataRow["ColumnName"].ToString().ToLower() == "cost")
			{
				str = dataRow["FilterText"].ToString().Trim();
				object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
				empty = string.Concat(objArray);
			}
			else if (dataRow["ColumnName"].ToString().ToLower() != "isarchived")
			{
				empty = dataRow["ColumnName"].ToString();
				str = dataRow["FilterText"].ToString().Trim();
			}
			else
			{
				empty = dataRow["ColumnName"].ToString();
				str = (dataRow["FilterText"].ToString().ToLower().Trim() != "no" ? "1" : "0");
			}
			string lower = dataRow["filter"].ToString().ToLower();
			string str1 = lower;
			if (lower == null)
			{
				continue;
			}
                var dictionary = new Dictionary<string, int>(10)
                             {
                                 { "startswith", 0 },
                                 { "endswith", 1 },
                                 { "contains", 2 },
                                 { "doesnotcontain", 3 },
                                 { "equalto", 4 },
                                 { "notequalto", 5 },
                                 { "greaterthan", 6 },
                                 { "greaterthanorequalto", 7 },
                                 { "lessthan", 8 },
                                 { "lessthanorequalto", 9 }
                             };

                dictionary.TryGetValue(str1, out num);
                switch (num)
			{
				case 0:
				{
					string whereCondition = inventory_store_customer_view.WhereCondition;
					string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
					inventory_store_customer_view.WhereCondition = string.Concat(strArrays);
					continue;
				}
				case 1:
				{
					string whereCondition1 = inventory_store_customer_view.WhereCondition;
					string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
					inventory_store_customer_view.WhereCondition = string.Concat(strArrays1);
					continue;
				}
				case 2:
				{
					string whereCondition2 = inventory_store_customer_view.WhereCondition;
					string[] strArrays2 = new string[] { whereCondition2, " ", empty, " like '%", str, "%'" };
					inventory_store_customer_view.WhereCondition = string.Concat(strArrays2);
					continue;
				}
				case 3:
				{
					string str2 = inventory_store_customer_view.WhereCondition;
					string[] strArrays3 = new string[] { str2, " ", empty, " not like '%", str, "%'" };
					inventory_store_customer_view.WhereCondition = string.Concat(strArrays3);
					continue;
				}
				case 4:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition3 = inventory_store_customer_view.WhereCondition;
						string[] strArrays4 = new string[] { whereCondition3, " ", empty, " = ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays4);
						continue;
					}
					else
					{
						string str3 = inventory_store_customer_view.WhereCondition;
						string[] strArrays5 = new string[] { str3, " ", empty, " = '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays5);
						continue;
					}
				}
				case 5:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition4 = inventory_store_customer_view.WhereCondition;
						string[] strArrays6 = new string[] { whereCondition4, " ", empty, " != ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays6);
						continue;
					}
					else
					{
						string str4 = inventory_store_customer_view.WhereCondition;
						string[] strArrays7 = new string[] { str4, " ", empty, " != '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays7);
						continue;
					}
				}
				case 6:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition5 = inventory_store_customer_view.WhereCondition;
						string[] strArrays8 = new string[] { whereCondition5, " ", empty, " > ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays8);
						continue;
					}
					else
					{
						string str5 = inventory_store_customer_view.WhereCondition;
						string[] strArrays9 = new string[] { str5, " ", empty, " > '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays9);
						continue;
					}
				}
				case 7:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition6 = inventory_store_customer_view.WhereCondition;
						string[] strArrays10 = new string[] { whereCondition6, " ", empty, " >= ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays10);
						continue;
					}
					else
					{
						string str6 = inventory_store_customer_view.WhereCondition;
						string[] strArrays11 = new string[] { str6, " ", empty, " >= '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays11);
						continue;
					}
				}
				case 8:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition7 = inventory_store_customer_view.WhereCondition;
						string[] strArrays12 = new string[] { whereCondition7, " ", empty, " < ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays12);
						continue;
					}
					else
					{
						string str7 = inventory_store_customer_view.WhereCondition;
						string[] strArrays13 = new string[] { str7, " ", empty, " < '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays13);
						continue;
					}
				}
				case 9:
				{
					if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived" || dataRow["ColumnName"].ToString().ToLower() == "availablequantity")
					{
						string whereCondition8 = inventory_store_customer_view.WhereCondition;
						string[] strArrays14 = new string[] { whereCondition8, " ", empty, " <= ", str };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays14);
						continue;
					}
					else
					{
						string str8 = inventory_store_customer_view.WhereCondition;
						string[] strArrays15 = new string[] { str8, " ", empty, " <= '", str, "'" };
						inventory_store_customer_view.WhereCondition = string.Concat(strArrays15);
						continue;
					}
				}
				default:
				{
					continue;
				}
			}
		}
		return inventory_store_customer_view.WhereCondition;
	}

	private string GetSortDirection(string column)
	{
		string str = "ASC";
		string item = this.ViewState["SortExpression"] as string;
		if (item != null && item == column)
		{
			string item1 = this.ViewState["SortDirection"] as string;
			if (item1 != null && item1 == "ASC")
			{
				str = "DESC";
			}
		}
		this.ViewState["SortDirection"] = str;
		this.ViewState["SortExpression"] = column;
		return str;
	}

	public void GridBindCust(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
	{
		string empty = string.Empty;
		viewClass _viewClass = new viewClass();
		empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, "item", ViewID, SortedBy, SortDirection, para);
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
		{
			CommandType = CommandType.StoredProcedure
		};
        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        sqlCommand.Parameters.AddWithValue("@strSQL", empty);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		_commonClass.closeConnection();
		this.GridCustomerItem.DataSource = dataSet;
		if (dataSet.Tables[0].Rows.Count <= 0)
		{
			this.AddBoundColumns_item(dataSet.Tables[0], this.GridCustomerItem);
			this.div_MainCus.Style.Add("display", "block");
			this.GridCustomerItem.AllowCustomPaging = false;
			return;
		}
		this.AddBoundColumns_item(dataSet.Tables[0], this.GridCustomerItem);
		this.div_MainCus.Style.Add("display", "block");
		this.GridCustomerItem.AllowCustomPaging = true;
		this.GridCustomerItem.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
	}

	public void GridBindInv(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
	{
		string empty = string.Empty;
		viewClass _viewClass = new viewClass();
		empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, "inventory", ViewID, SortedBy, SortDirection, para);
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
		{
			CommandType = CommandType.StoredProcedure
		};
        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        sqlCommand.Parameters.AddWithValue("@strSQL", empty);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		DataTable item = dataSet.Tables[0];
		for (int i = 0; i < item.Columns.Count; i++)
		{
			item.Columns[i].ReadOnly = false;
		}
		if (item != null)
		{
			foreach (DataRow row in item.Rows)
			{
				if (row.Table.Columns.Contains("CreatedDate"))
				{
					row["CreatedDate"] = this.cmnDate.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
				}
				if (row.Table.Columns.Contains("Location"))
				{
					row["Location"] = this.objBase.SpecialDecode(row["Location"].ToString());
				}
				if (row.Table.Columns.Contains("Description"))
				{
					row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
				}
				if (row.Table.Columns.Contains("InventoryCode"))
				{
					row["InventoryCode"] = this.objBase.SpecialDecode(row["InventoryCode"].ToString());
				}
				if (row.Table.Columns.Contains("InventoryName"))
				{
					row["InventoryName"] = this.objBase.SpecialDecode(row["InventoryName"].ToString());
				}
				if (row.Table.Columns.Contains("SupplierName"))
				{
					row["SupplierName"] = this.objBase.SpecialDecode(row["SupplierName"].ToString());
				}
				if (row.Table.Columns.Contains("StockType"))
				{
					row["StockType"] = this.objBase.SpecialDecode(row["StockType"].ToString());
				}
				if (row.Table.Columns.Contains("CustomStockType"))
				{
					row["CustomStockType"] = this.objBase.SpecialDecode(row["CustomStockType"].ToString());
				}
				if (!row.Table.Columns.Contains("FriendlyName"))
				{
					continue;
				}
				row["FriendlyName"] = this.objBase.SpecialDecode(row["FriendlyName"].ToString());
			}
		}
		_commonClass.closeConnection();
		this.GridViewInv.DataSource = dataSet;
		if (dataSet.Tables[0].Rows.Count <= 0)
		{
			this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridViewInv);
			this.div_MainInv.Style.Add("display", "block");
			this.GridViewInv.AllowCustomPaging = false;
			return;
		}
		this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridViewInv);
		this.div_MainInv.Style.Add("display", "block");
		this.GridViewInv.AllowCustomPaging = true;
		this.GridViewInv.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
	}

	public void GridBindStore(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
	{
		string empty = string.Empty;
		viewClass _viewClass = new viewClass();
		empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, "store", ViewID, SortedBy, SortDirection, para);
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
		{
			CommandType = CommandType.StoredProcedure
		};
        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        sqlCommand.Parameters.AddWithValue("@strSQL", empty);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		_commonClass.closeConnection();
		this.GridStoreSupply.DataSource = dataSet;
		if (dataSet.Tables[0].Rows.Count <= 0)
		{
			this.AddBoundColumns_store(dataSet.Tables[0], this.GridStoreSupply);
			this.div_MainSto.Style.Add("display", "block");
			this.GridStoreSupply.AllowCustomPaging = false;
			return;
		}
		this.AddBoundColumns_store(dataSet.Tables[0], this.GridStoreSupply);
		this.div_MainSto.Style.Add("display", "block");
		this.GridStoreSupply.AllowCustomPaging = true;
		this.GridStoreSupply.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
	}

	protected void GridCust_ItemCommand(object sender, GridCommandEventArgs e)
	{
		int num = 0;
		if (e.CommandName == "Filter")
		{
			Pair commandArgument = (Pair)e.CommandArgument;
			string str = commandArgument.Second.ToString();
			TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
			item.Text = this.objBase.ReplaceSingleQuote(item.Text);
			inventory_store_customer_view.WhereConditionItem = "";
			string empty = string.Empty;
			string empty1 = string.Empty;
			int num1 = 0;
			foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
			{
				num1 = Convert.ToInt32(row["Roundoff"].ToString());
			}
			if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "packcostprice" || commandArgument.Second.ToString().ToLower() == "unitprice" || commandArgument.Second.ToString().ToLower() == "packquantity" || commandArgument.Second.ToString().ToLower() == "instockquantity"))
			{
				item.Text = item.Text.Replace(",", "");
				item.Text = this.Only_number(item.Text);
				if (item.Text == "")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Pls_Enter_Only_Number"), "msg-fail", this.plhErrorMessage);
				}
				else
				{
					item.Text = item.Text.Trim();
				}
			}
			if (base.Session["searchItem"] == null)
			{
				this.dtsearchItem.Columns.Add("ColumnName");
				this.dtsearchItem.Columns.Add("Filter");
				this.dtsearchItem.Columns.Add("FilterText");
			}
			if (base.Session["searchItem"] != null)
			{
				this.dtsearchItem = (DataTable)base.Session["searchItem"];
			}
			DataRow[] dataRowArray = this.dtsearchItem.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
			if (item.Text != "")
			{
				if ((int)dataRowArray.Length <= 0)
				{
					object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
					this.dtsearchItem.Rows.Add(second);
				}
				else
				{
					this.dtsearchItem.Rows.Remove(dataRowArray[0]);
					if (commandArgument.First.ToString().ToLower() != "nofilter")
					{
						object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
						this.dtsearchItem.Rows.Add(objArray);
					}
				}
			}
			base.Session["searchItem"] = this.dtsearchItem;
			foreach (DataRow dataRow in this.dtsearchItem.Rows)
			{
				if (dataRow["filter"].ToString().ToLower() != "nofilter" && inventory_store_customer_view.WhereConditionItem != "")
				{
					inventory_store_customer_view.WhereConditionItem = string.Concat(inventory_store_customer_view.WhereConditionItem, " and ");
				}
				if (dataRow["ColumnName"].ToString().ToLower() == "createddate")
				{
					empty1 = this.cmnDate.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
					empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
				}
				else if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice")
				{
					object[] str1 = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
					empty = string.Concat(str1);
					empty1 = dataRow["FilterText"].ToString().Trim();
				}
				else if (dataRow["ColumnName"].ToString().ToLower() != "isarchived")
				{
					empty = dataRow["ColumnName"].ToString();
					empty1 = dataRow["FilterText"].ToString().Trim();
				}
				else
				{
					empty = dataRow["ColumnName"].ToString();
					empty1 = (dataRow["FilterText"].ToString().ToLower().Trim() != "no" ? "1" : "0");
				}
				string lower = dataRow["filter"].ToString().ToLower();
				string str2 = lower;
				if (lower == null)
				{
					continue;
				}
                    var dictionary = new Dictionary<string, int>(10)
                             {
                                 { "startswith", 0 },
                                 { "endswith", 1 },
                                 { "contains", 2 },
                                 { "doesnotcontain", 3 },
                                 { "equalto", 4 },
                                 { "notequalto", 5 },
                                 { "greaterthan", 6 },
                                 { "greaterthanorequalto", 7 },
                                 { "lessthan", 8 },
                                 { "lessthanorequalto", 9 }
                             };

                    dictionary.TryGetValue(item.Text, out num);
                    switch (num)
				{
					case 0:
					{
						string whereConditionItem = inventory_store_customer_view.WhereConditionItem;
						string[] strArrays = new string[] { whereConditionItem, " ", empty, " like '", empty1, "%'" };
						inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays);
						continue;
					}
					case 1:
					{
						string whereConditionItem1 = inventory_store_customer_view.WhereConditionItem;
						string[] strArrays1 = new string[] { whereConditionItem1, " ", empty, " like '%", empty1, "'" };
						inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays1);
						continue;
					}
					case 2:
					{
						string whereConditionItem2 = inventory_store_customer_view.WhereConditionItem;
						string[] strArrays2 = new string[] { whereConditionItem2, " ", empty, " like '%", empty1, "%'" };
						inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays2);
						continue;
					}
					case 3:
					{
						string whereConditionItem3 = inventory_store_customer_view.WhereConditionItem;
						string[] strArrays3 = new string[] { whereConditionItem3, " ", empty, " not like '%", empty1, "%'" };
						inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays3);
						continue;
					}
					case 4:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionstore = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays4 = new string[] { whereConditionstore, " ", empty, " = ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays4);
							continue;
						}
						else
						{
							string str3 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays5 = new string[] { str3, " ", empty, " = '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays5);
							continue;
						}
					}
					case 5:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionItem4 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays6 = new string[] { whereConditionItem4, " ", empty, " != ", empty1 };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays6);
							continue;
						}
						else
						{
							string str4 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays7 = new string[] { str4, " ", empty, " != '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays7);
							continue;
						}
					}
					case 6:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionItem5 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays8 = new string[] { whereConditionItem5, " ", empty, " > ", empty1 };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays8);
							continue;
						}
						else
						{
							string str5 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays9 = new string[] { str5, " ", empty, " > '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays9);
							continue;
						}
					}
					case 7:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionItem6 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays10 = new string[] { whereConditionItem6, " ", empty, " >= ", empty1 };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays10);
							continue;
						}
						else
						{
							string str6 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays11 = new string[] { str6, " ", empty, " >= '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays11);
							continue;
						}
					}
					case 8:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionItem7 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays12 = new string[] { whereConditionItem7, " ", empty, " < ", empty1 };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays12);
							continue;
						}
						else
						{
							string str7 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays13 = new string[] { str7, " ", empty, " < '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays13);
							continue;
						}
					}
					case 9:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string whereConditionItem8 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays14 = new string[] { whereConditionItem8, " ", empty, " <= ", empty1 };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays14);
							continue;
						}
						else
						{
							string str8 = inventory_store_customer_view.WhereConditionItem;
							string[] strArrays15 = new string[] { str8, " ", empty, " <= '", empty1, "'" };
							inventory_store_customer_view.WhereConditionItem = string.Concat(strArrays15);
							continue;
						}
					}
					default:
					{
						continue;
					}
				}
			}
			this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
			this.GridCustomerItem.Rebind();
		}
	}

	protected void GridCust_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
	{
		if (this.type == "item")
		{
			this.GridCustomerItem.AllowCustomPaging = true;
			this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, this.GridCustomerItem.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View2.SelectedValue), inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
		}
	}

	protected void GridCustItem_SortCommand(object sender, GridSortCommandEventArgs e)
	{
		inventory_store_customer_view.SortedByItem = e.SortExpression;
		inventory_store_customer_view.sortdirectionItem = e.NewSortOrder.ToString();
		if (inventory_store_customer_view.sortdirectionItem.ToLower() == "ascending")
		{
			inventory_store_customer_view.sortdirectionItem = "ASC";
		}
		else if (inventory_store_customer_view.sortdirectionItem.ToLower() != "descending")
		{
			inventory_store_customer_view.sortdirectionItem = "ASC";
		}
		else
		{
			inventory_store_customer_view.sortdirectionItem = "DESC";
		}
		this.GridCustomerItem.CurrentPageIndex = 0;
		this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, this.GridCustomerItem.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View2.Items[this.ddl_View2.SelectedIndex].Value), e.SortExpression, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
	}

	private void GridStateLoad()
	{
		this.cmnDate.GridStateLoadNew("inventory", string.Concat(this.UserID, "inventory"), this.GridViewInv, "yes");
	}

	private void GridStateSave()
	{
		this.cmnDate.GridStateSaveNew("inventory", string.Concat(this.UserID, "inventory"), this.GridViewInv);
	}

	protected void GridViewInv_ItemCommand(object sender, GridCommandEventArgs e)
	{
		if (e.CommandName == "Filter")
		{
			e.Canceled = true;
			Pair commandArgument = (Pair)e.CommandArgument;
			string str = commandArgument.Second.ToString();
			TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
			item.Text = this.objBase.SpecialEncode(item.Text);
			inventory_store_customer_view.WhereCondition = "";
			string empty = string.Empty;
			string empty1 = string.Empty;
			foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
			{
				Convert.ToInt32(row["Roundoff"].ToString());
			}
			if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "cost" || commandArgument.Second.ToString().ToLower() == "unitprice" || commandArgument.Second.ToString().ToLower() == "availablequantity"))
			{
				item.Text = item.Text.Replace(",", "");
				if (item.Text.Contains("per"))
				{
					string[] strArrays = item.Text.Split(new char[] { 'p' });
					item.Text = strArrays[0].Trim();
				}
				item.Text = this.Only_number(item.Text);
				if (item.Text == "")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Pls_Enter_Only_Number"), "msg-fail", this.plhErrorMessage);
				}
				else
				{
					item.Text = item.Text.Trim();
				}
			}
			if (base.Session["searchInv"] == null)
			{
				this.dtsearchInv.Columns.Add("ColumnName");
				this.dtsearchInv.Columns.Add("Filter");
				this.dtsearchInv.Columns.Add("FilterText");
			}
			if (base.Session["searchInv"] != null)
			{
				this.dtsearchInv = (DataTable)base.Session["searchInv"];
			}
			DataRow[] dataRowArray = this.dtsearchInv.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
			if ((int)dataRowArray.Length <= 0)
			{
				object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
				this.dtsearchInv.Rows.Add(second);
				this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
			}
			else
			{
				this.dtsearchInv.Rows.Remove(dataRowArray[0]);
				if (commandArgument.First.ToString().ToLower() != "nofilter")
				{
					object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
					this.dtsearchInv.Rows.Add(objArray);
				}
				this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
			}
			base.Session["searchInv"] = this.dtsearchInv;
			inventory_store_customer_view.WhereCondition = this.FilterFunction(this.dtsearchInv);
			this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
			this.GridViewInv.Rebind();
		}
	}

	protected void GridViewInv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
	{
		if (this.type == "inventory")
		{
			this.GridViewInv.AllowCustomPaging = true;
			this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.SelectedValue), inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
		}
	}

	protected void GridViewInv_SortCommand(object sender, GridSortCommandEventArgs e)
	{
		inventory_store_customer_view.SortedBy = e.SortExpression;
		inventory_store_customer_view.sortdirection = e.NewSortOrder.ToString();
		if (inventory_store_customer_view.sortdirection.ToLower() == "ascending")
		{
			inventory_store_customer_view.sortdirection = "ASC";
			this.GridViewInv.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
		}
		else if (inventory_store_customer_view.sortdirection.ToLower() != "descending")
		{
			inventory_store_customer_view.sortdirection = "ASC";
			this.GridViewInv.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
		}
		else
		{
			inventory_store_customer_view.sortdirection = "DESC";
			this.GridViewInv.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
		}
		this.GridViewInv.CurrentPageIndex = 0;
		this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
	}

	protected void GridViewStore_ItemCommand(object sender, GridCommandEventArgs e)
	{
		int num = 0;
		if (e.CommandName == "Filter")
		{
			Pair commandArgument = (Pair)e.CommandArgument;
			string str = commandArgument.Second.ToString();
			TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
			item.Text = this.objBase.ReplaceSingleQuote(item.Text);
			inventory_store_customer_view.WhereConditionstore = "";
			string empty = string.Empty;
			string empty1 = string.Empty;
			int num1 = 0;
			foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
			{
				num1 = Convert.ToInt32(row["Roundoff"].ToString());
			}
			if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "packcostprice" || commandArgument.Second.ToString().ToLower() == "unitprice" || commandArgument.Second.ToString().ToLower() == "packquantity" || commandArgument.Second.ToString().ToLower() == "instockquantity"))
			{
				item.Text = item.Text.Replace(",", "");
				item.Text = this.Only_number(item.Text);
				if (item.Text == "")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Pls_Enter_Only_Number"), "msg-fail", this.plhErrorMessage);
				}
				else
				{
					item.Text = item.Text.Trim();
				}
			}
			if (base.Session["searchStore"] == null)
			{
				this.dtsearchStore.Columns.Add("ColumnName");
				this.dtsearchStore.Columns.Add("Filter");
				this.dtsearchStore.Columns.Add("FilterText");
			}
			if (base.Session["searchStore"] != null)
			{
				this.dtsearchStore = (DataTable)base.Session["searchStore"];
			}
			DataRow[] dataRowArray = this.dtsearchStore.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
			if (item.Text != "")
			{
				if ((int)dataRowArray.Length <= 0)
				{
					object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
					this.dtsearchStore.Rows.Add(second);
				}
				else
				{
					this.dtsearchStore.Rows.Remove(dataRowArray[0]);
					if (commandArgument.First.ToString().ToLower() != "nofilter")
					{
						object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
						this.dtsearchStore.Rows.Add(objArray);
					}
				}
			}
			base.Session["searchStore"] = this.dtsearchStore;
			foreach (DataRow dataRow in this.dtsearchStore.Rows)
			{
				if (dataRow["filter"].ToString().ToLower() != "nofilter" && inventory_store_customer_view.WhereConditionstore != "")
				{
					inventory_store_customer_view.WhereConditionstore = string.Concat(inventory_store_customer_view.WhereConditionstore, " and ");
				}
				if (dataRow["ColumnName"].ToString().ToLower() == "createddate")
				{
					empty1 = this.cmnDate.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
					empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
				}
				else if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice")
				{
					object[] str1 = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
					empty = string.Concat(str1);
					empty1 = dataRow["FilterText"].ToString().Trim();
				}
				else if (dataRow["ColumnName"].ToString().ToLower() != "isarchived")
				{
					empty = dataRow["ColumnName"].ToString();
					empty1 = dataRow["FilterText"].ToString().Trim();
				}
				else
				{
					empty = dataRow["ColumnName"].ToString();
					empty1 = (dataRow["FilterText"].ToString().ToLower().Trim() != "no" ? "1" : "0");
				}
				string lower = dataRow["filter"].ToString().ToLower();
				string str2 = lower;
				if (lower == null)
				{
					continue;
				}
                //if (<PrivateImplementationDetails>{AB11BBCB-06B8-4897-90BA-6FD3CF1065BA}.$$method0x6000020-1 == null)
                //{
                //    <PrivateImplementationDetails>{AB11BBCB-06B8-4897-90BA-6FD3CF1065BA}.$$method0x6000020-1 = new Dictionary<string, int>(10)
                //    {
                //        { "startswith", 0 },
                //        { "endswith", 1 },
                //        { "contains", 2 },
                //        { "doesnotcontain", 3 },
                //        { "equalto", 4 },
                //        { "notequalto", 5 },
                //        { "greaterthan", 6 },
                //        { "greaterthanorequalto", 7 },
                //        { "lessthan", 8 },
                //        { "lessthanorequalto", 9 }
                //    };
                //}
                //if (!<PrivateImplementationDetails>{AB11BBCB-06B8-4897-90BA-6FD3CF1065BA}.$$method0x6000020-1.TryGetValue(str2, out num))
                //{
                //    continue;
                //}
				switch (num)
				{
					case 0:
					{
						string whereConditionstore = inventory_store_customer_view.WhereConditionstore;
						string[] strArrays = new string[] { whereConditionstore, " ", empty, " like '", empty1, "%'" };
						inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays);
						continue;
					}
					case 1:
					{
						string whereConditionstore1 = inventory_store_customer_view.WhereConditionstore;
						string[] strArrays1 = new string[] { whereConditionstore1, " ", empty, " like '%", empty1, "'" };
						inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays1);
						continue;
					}
					case 2:
					{
						string whereConditionstore2 = inventory_store_customer_view.WhereConditionstore;
						string[] strArrays2 = new string[] { whereConditionstore2, " ", empty, " like '%", empty1, "%'" };
						inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays2);
						continue;
					}
					case 3:
					{
						string whereConditionstore3 = inventory_store_customer_view.WhereConditionstore;
						string[] strArrays3 = new string[] { whereConditionstore3, " ", empty, " not like '%", empty1, "%'" };
						inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays3);
						continue;
					}
					case 4:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str3 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays4 = new string[] { str3, " ", empty, " = ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays4);
							continue;
						}
						else
						{
							string whereConditionstore4 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays5 = new string[] { whereConditionstore4, " ", empty, " = '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays5);
							continue;
						}
					}
					case 5:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str4 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays6 = new string[] { str4, " ", empty, " != ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays6);
							continue;
						}
						else
						{
							string whereConditionstore5 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays7 = new string[] { whereConditionstore5, " ", empty, " != '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays7);
							continue;
						}
					}
					case 6:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str5 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays8 = new string[] { str5, " ", empty, " > ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays8);
							continue;
						}
						else
						{
							string whereConditionstore6 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays9 = new string[] { whereConditionstore6, " ", empty, " > '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays9);
							continue;
						}
					}
					case 7:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str6 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays10 = new string[] { str6, " ", empty, " >= ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays10);
							continue;
						}
						else
						{
							string whereConditionstore7 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays11 = new string[] { whereConditionstore7, " ", empty, " >= '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays11);
							continue;
						}
					}
					case 8:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str7 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays12 = new string[] { str7, " ", empty, " < ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays12);
							continue;
						}
						else
						{
							string whereConditionstore8 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays13 = new string[] { whereConditionstore8, " ", empty, " < '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays13);
							continue;
						}
					}
					case 9:
					{
						if (dataRow["ColumnName"].ToString().ToLower() == "packcostprice" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "packquantity" || dataRow["ColumnName"].ToString().ToLower() == "instockquantity" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
						{
							string str8 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays14 = new string[] { str8, " ", empty, " <= ", empty1 };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays14);
							continue;
						}
						else
						{
							string whereConditionstore9 = inventory_store_customer_view.WhereConditionstore;
							string[] strArrays15 = new string[] { whereConditionstore9, " ", empty, " <= '", empty1, "'" };
							inventory_store_customer_view.WhereConditionstore = string.Concat(strArrays15);
							continue;
						}
					}
					default:
					{
						continue;
					}
				}
			}
			this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
			this.GridStoreSupply.Rebind();
		}
	}

	protected void GridViewStore_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
	{
		if (this.type == "store")
		{
			this.GridStoreSupply.AllowCustomPaging = true;
			this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, this.GridStoreSupply.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View1.SelectedValue), inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
		}
	}

	protected void GridViewStore_SortCommand(object sender, GridSortCommandEventArgs e)
	{
		inventory_store_customer_view.SortedBystore = e.SortExpression;
		inventory_store_customer_view.sortdirectionstore = e.NewSortOrder.ToString();
		if (inventory_store_customer_view.sortdirectionstore.ToLower() == "ascending")
		{
			inventory_store_customer_view.sortdirectionstore = "ASC";
		}
		else if (inventory_store_customer_view.sortdirectionstore.ToLower() != "descending")
		{
			inventory_store_customer_view.sortdirectionstore = "ASC";
		}
		else
		{
			inventory_store_customer_view.sortdirectionstore = "DESC";
		}
		this.GridStoreSupply.CurrentPageIndex = 0;
		this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, this.GridStoreSupply.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View1.Items[this.ddl_View1.SelectedIndex].Value), e.SortExpression, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
	}

	protected void lnkCusArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvCustDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_archive(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
		this.objBase.Message_Display("Customer Item(s) archived successfully", "successfulMsg", this.plhMessage);
		if (this.GridCustomerItem.Items.Count != 0)
		{
			this.hidCustomCount.Value = this.GridCustomerItem.Items.Count.ToString();
		}
		this.GridCustomerItem.Rebind();
	}

	protected void lnkCusDelete_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvCustDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_delete(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
		if (this.GridCustomerItem.Items.Count < 10)
		{
			int count = this.GridCustomerItem.Items.Count;
		}
		this.objBase.Message_Display("Customer Item(s) deleted successfully", "successfulMsg", this.plhMessage);
		if (this.GridCustomerItem.Items.Count != 0)
		{
			this.hidCustomCount.Value = this.GridCustomerItem.Items.Count.ToString();
		}
		this.GridCustomerItem.Rebind();
	}

	protected void lnkCusUnArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvCustDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_unarchive(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindCust(this.CompanyID, this.UserID, this.GridCustomerItem.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedByItem, inventory_store_customer_view.sortdirectionItem, inventory_store_customer_view.WhereConditionItem);
		this.objBase.Message_Display("Customer Item(s) Un-Archived successfully", "successfulMsg", this.plhMessage);
		if (this.GridCustomerItem.Items.Count != 0)
		{
			this.hidCustomCount.Value = this.GridCustomerItem.Items.Count.ToString();
		}
		this.GridCustomerItem.Rebind();
	}

	protected void lnkInvArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_inventory_archive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
		this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
		if (this.GridViewInv.Items.Count != 0)
		{
			this.hidGridRecord.Value = this.GridViewInv.Items.Count.ToString();
		}
		this.GridViewInv.Rebind();
	}

	protected void lnkInvDelete_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_inventory_delete(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
		}
		this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
		this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
		if (this.GridViewInv.Items.Count != 0)
		{
			this.hidGridRecord.Value = this.GridViewInv.Items.Count.ToString();
		}
		this.GridViewInv.Rebind();
	}

	protected void lnkInvunArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_inventory_unarchive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, inventory_store_customer_view.WhereCondition);
		this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
		if (this.GridViewInv.Items.Count != 0)
		{
			this.hidGridRecord.Value = this.GridViewInv.Items.Count.ToString();
		}
		this.GridViewInv.Rebind();
	}

	protected void lnkStoArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvStoreDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_archive(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
		this.objBase.Message_Display("Store supply Item(s) archived successfully", "successfulMsg", this.plhMessage);
		if (this.GridStoreSupply.Items.Count != 0)
		{
			this.hidStoreCount.Value = this.GridStoreSupply.Items.Count.ToString();
		}
		this.GridStoreSupply.Rebind();
	}

	protected void lnkStoDelete_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvStoreDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_delete(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
		this.objBase.Message_Display("Store supply Item(s) deleted successfully", "successfulMsg", this.plhMessage);
		if (this.GridStoreSupply.Items.Count != 0)
		{
			this.hidStoreCount.Value = this.GridStoreSupply.Items.Count.ToString();
		}
		this.GridStoreSupply.Rebind();
	}

	protected void lnkStoUnArchive_OnClick(object sender, EventArgs e)
	{
		string[] strArrays = this.hdnInvStoreDelIds.Value.Split(new char[] { ',' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			this.objInv.warehouse_finishedgoods_unarchive(this.CompanyID, Convert.ToInt32(strArrays[i].ToString()));
		}
		this.GridBindStore(this.CompanyID, this.UserID, this.GridStoreSupply.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBystore, inventory_store_customer_view.sortdirectionstore, inventory_store_customer_view.WhereConditionstore);
		this.objBase.Message_Display("Store supply Item(s) Un-Archived successfully", "successfulMsg", this.plhMessage);
		if (this.GridStoreSupply.Items.Count != 0)
		{
			this.hidStoreCount.Value = this.GridStoreSupply.Items.Count.ToString();
		}
		this.GridStoreSupply.Rebind();
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		GridFilterMenu filterMenu = this.GridViewInv.FilterMenu;
		for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
		{
			if (filterMenu.Items[i].Text.ToLower() == "nofilter")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
			}
			if (filterMenu.Items[i].Text.ToLower() == "contains")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
			}
			if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
			}
			if (filterMenu.Items[i].Text.ToLower() == "startswith")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
			}
			if (filterMenu.Items[i].Text.ToLower() == "endswith")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
			}
			if (filterMenu.Items[i].Text.ToLower() == "equalto")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
			}
			if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
			}
			if (filterMenu.Items[i].Text.ToLower() == "lessthan")
			{
				filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
			}
		}
	}

	public string Only_number(string input)
	{
		return Regex.Replace(input, "[^0-9.]", "");
	}

	protected override void OnPreRender(EventArgs e)
	{
		base.OnPreRender(e);
		this.GridStateSave();
	}

	public void OnRowDataBound_GridCust(object sender, GridItemEventArgs e)
	{
		if (e.Item.ItemType == GridItemType.Header)
		{
			e.Item.Visible = false;
			for (int i = 0; i < this.GridCustomerItem.Columns.Count; i++)
			{
				if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "createddate")
				{
					this.cellvalue_createddate = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_createddate_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "instockquantity")
				{
					this.cellvalue_instockquantity = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_instockquantity_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "packquantity")
				{
					this.cellvalue_packquantity = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_packquantity_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "packcostprice")
				{
					this.cellvalue_packcostprice = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_packcostprice_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "unitprice")
				{
					this.cellvalue_unitprice = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_unitprice_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "isarchived")
				{
					this.cellvalue_IsArchive = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_IsArchive_item = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "description")
				{
					this.cellvalue_Description = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_Description = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "suppliername")
				{
					this.cellvalue_suppName = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_suppName = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "productname")
				{
					this.cellvalue_prodName_store = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_prodName_store = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "customerid")
				{
					this.cellvalue_custName = this.GridCustomerItem.Columns[i].SortExpression;
					this.flag_custName = "true";
				}
				else if (this.GridCustomerItem.Columns[i].SortExpression.ToLower() == "action")
				{
					this.GridCustomerItem.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Action");
					this.flag_Action = "true";
					this.cellvalue_Action = this.GridCustomerItem.Columns[i].SortExpression.ToLower();
					this.GridCustomerItem.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
				}
			}
		}
		if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_UnitPrice");
			int num = (int)InventoryBasePage.finishedgoods_getPackedIn_qty(this.CompanyID, Convert.ToInt32(((DataRowView)e.Item.DataItem)[0].ToString()), 'c');
			decimal num1 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "F", Convert.ToInt64(((DataRowView)e.Item.DataItem)[0].ToString())));
			GridDataItem item = (GridDataItem)e.Item;
			TableCell tableCell = item["productcode"];
			string[] str = new string[] { "<a style='color:#10357F;' href=", this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=item&type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", ((DataRowView)e.Item.DataItem)[1].ToString(), "</a>" };
			tableCell.Text = string.Concat(str);
			AttributeCollection attributes = item["productcode"].Attributes;
			object[] objArray = new object[] { "javascript:return Call_Estimate_Func('", ((DataRowView)e.Item.DataItem)[0].ToString(), "','", ((DataRowView)e.Item.DataItem)[1].ToString(), "','F','", hiddenField.Value, "','", num, "','", num1, "')" };
			attributes.Add("onclick", string.Concat(objArray));
			if (this.flag_createddate_item == "true")
			{
				item[this.cellvalue_createddate].Attributes.Add("align", "center");
			}
			if (this.flag_instockquantity_item == "true")
			{
				item[this.cellvalue_instockquantity].Attributes.Add("align", "right");
				TableCell item1 = item[this.cellvalue_instockquantity];
				string[] strArrays = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_instockquantity].Text), 0, "", true, false, true), "</div>" };
				item1.Text = string.Concat(strArrays);
			}
			if (this.flag_packquantity_item == "true")
			{
				item[this.cellvalue_packquantity].Attributes.Add("align", "right");
				double num2 = Convert.ToDouble(item[this.cellvalue_packquantity].Text.ToString());
				string str1 = num2.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", "");
				TableCell tableCell1 = item[this.cellvalue_packquantity];
				string[] strArrays1 = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str1), 0, "", true, false, true), "</div>" };
				tableCell1.Text = string.Concat(strArrays1);
			}
			if (this.flag_packcostprice_item == "true")
			{
				item[this.cellvalue_packcostprice].Attributes.Add("align", "right");
				TableCell item2 = item[this.cellvalue_packcostprice];
				double num3 = Convert.ToDouble(item[this.cellvalue_packcostprice].Text.ToString());
				item2.Text = num3.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", "");
				TableCell tableCell2 = item[this.cellvalue_packcostprice];
				string[] strArrays2 = new string[] { "<div style='width: ", this.type3, ";overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_packcostprice].Text), 0, "", false, false, true), "</div>" };
				tableCell2.Text = string.Concat(strArrays2);
			}
			if (this.flag_unitprice_item == "true")
			{
				item[this.cellvalue_unitprice].Attributes.Add("align", "right");
				decimal num4 = Convert.ToDecimal(item[this.cellvalue_unitprice].Text.ToString());
				string str2 = num4.ToString();
				TableCell item3 = item[this.cellvalue_unitprice];
				string[] strArrays3 = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str2), 0, "", false, false, true), "</div>" };
				item3.Text = string.Concat(strArrays3);
			}
			if (this.flag_Action == "true")
			{
				item[this.cellvalue_Action].Attributes.Add("align", "right");
				item[this.cellvalue_Action].Controls.Clear();
				ImageButton imageButton = new ImageButton()
				{
					ID = "imgbtnDelete",
					CommandArgument = hiddenField.Value,
					ImageUrl = "~/images/erase.png",
					ToolTip = this.objLanguage.GetLanguageConversion("Delete"),
					OnClientClick = string.Concat("javascript:return EraseCheck('", hiddenField.Value, "');")
				};
				item[this.cellvalue_Action].Controls.Add(imageButton);
				item[this.cellvalue_Action].Controls.Add(new LiteralControl("&nbsp;"));
				ImageButton imageButton1 = new ImageButton()
				{
					ID = "imgbtnCopy",
					CommandArgument = hiddenField.Value,
					ImageUrl = "~/images/copy.png",
					ToolTip = this.objLanguage.GetLanguageConversion("Copy"),
					OnClientClick = string.Concat("javascript:Copy('", hiddenField.Value, "')")
				};
				item[this.cellvalue_Action].Controls.Add(imageButton1);
				if (this.DeleteStatus.Trim().ToLower() != "false")
				{
					imageButton.Visible = true;
				}
				else
				{
					imageButton.Visible = false;
				}
				if (this.AddStatus.Trim().ToLower() != "false")
				{
					imageButton1.Visible = true;
					//this.RadMenu1.Items[0].Visible = true;
				}
				else
				{
					imageButton1.Visible = false;
					//this.RadMenu1.Items[0].Visible = false;
				}
			}
			if (this.flag_IsArchive_item == "true")
			{
				item[this.cellvalue_IsArchive].Attributes.Add("align", "Center");
				if (item[this.cellvalue_IsArchive].Text != "1")
				{
					item[this.cellvalue_IsArchive].Text = "No";
				}
				else
				{
					item[this.cellvalue_IsArchive].Text = "Yes";
				}
			}
			if (this.flag_Description == "true")
			{
				TableCell tableCell3 = item[this.cellvalue_Description];
				string[] text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Description].Text, "</div>" };
				tableCell3.Text = string.Concat(text);
			}
			if (this.flag_suppName == "true")
			{
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					TableCell item4 = item[this.cellvalue_suppName];
					string[] text1 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					item4.Text = string.Concat(text1);
				}
				else
				{
					TableCell tableCell4 = item[this.cellvalue_suppName];
					string[] text2 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					tableCell4.Text = string.Concat(text2);
				}
			}
			if (this.flag_prodName_store == "true")
			{
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					TableCell item5 = item[this.cellvalue_prodName_store];
					string[] text3 = new string[] { "<div style='min-width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_prodName_store].Text, "</div>" };
					item5.Text = string.Concat(text3);
				}
				else
				{
					TableCell tableCell5 = item[this.cellvalue_prodName_store];
					string[] text4 = new string[] { "<div style='width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_prodName_store].Text, "</div>" };
					tableCell5.Text = string.Concat(text4);
				}
			}
			if (this.flag_custName == "true")
			{
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					TableCell item6 = item[this.cellvalue_custName];
					string[] strArrays4 = new string[] { "<div style='min-width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_custName].Text, "</div>" };
					item6.Text = string.Concat(strArrays4);
				}
				else
				{
					TableCell tableCell6 = item[this.cellvalue_custName];
					string[] text5 = new string[] { "<div style='width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_custName].Text, "</div>" };
					tableCell6.Text = string.Concat(text5);
				}
			}
		}
		if (e.Item is GridFilteringItem)
		{
			GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
			if (this.flag_unitprice_item == "true")
			{
				gridFilteringItem[this.cellvalue_unitprice].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_packcostprice_item == "true")
			{
				gridFilteringItem[this.cellvalue_packcostprice].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_instockquantity_item == "true")
			{
				gridFilteringItem[this.cellvalue_instockquantity].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_packquantity_item == "true")
			{
				gridFilteringItem[this.cellvalue_packquantity].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_IsArchive == "true")
			{
				gridFilteringItem[this.cellvalue_IsArchive].HorizontalAlign = HorizontalAlign.Center;
			}
			if (this.flag_createddate == "true")
			{
				gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
			}
		}
	}

	public void OnRowDataBound_GridStoreSupply(object sender, GridItemEventArgs e)
	{
		if (e.Item.ItemType == GridItemType.Header)
		{
			e.Item.Visible = false;
			for (int i = 0; i < this.GridStoreSupply.Columns.Count; i++)
			{
				if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "createddate")
				{
					this.cellvalue_createddate = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_createddate_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "instockquantity")
				{
					this.cellvalue_instockquantity = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_instockquantity_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "packquantity")
				{
					this.cellvalue_packquantity = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_packquantity_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "packcostprice")
				{
					this.cellvalue_packcostprice = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_packcostprice_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "unitprice")
				{
					this.cellvalue_unitprice = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_unitprice_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "isarchived")
				{
					this.cellvalue_isarchived = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_Is_archived = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "productname")
				{
					this.cellvalue_prodName_store = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_prodName_store = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "description")
				{
					this.cellvalue_Description = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_Description = "true";
				}
				else if (this.GridStoreSupply.Columns[i].SortExpression.ToLower() == "suppliername")
				{
					this.cellvalue_suppName = this.GridStoreSupply.Columns[i].SortExpression;
					this.flag_suppName = "true";
				}
			}
		}
		if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_UnitPrice");
			int num = (int)InventoryBasePage.finishedgoods_getPackedIn_qty(this.CompanyID, Convert.ToInt32(((DataRowView)e.Item.DataItem)[0].ToString()), 's');
			decimal num1 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "F", Convert.ToInt64(((DataRowView)e.Item.DataItem)[0].ToString())));
			GridDataItem item = (GridDataItem)e.Item;
			TableCell tableCell = item["productcode"];
			string[] str = new string[] { "<a style='color:#10357F;' href=", this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store&type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", ((DataRowView)e.Item.DataItem)[1].ToString(), "</a>" };
			tableCell.Text = string.Concat(str);
			AttributeCollection attributes = item["productcode"].Attributes;
			object[] objArray = new object[] { "javascript:return Call_Estimate_Func('", ((DataRowView)e.Item.DataItem)[0].ToString(), "','", ((DataRowView)e.Item.DataItem)[1].ToString(), "','F','", hiddenField.Value, "','", num, "','", num1, "')" };
			attributes.Add("onclick", string.Concat(objArray));
			if (this.flag_createddate_store == "true")
			{
				item[this.cellvalue_createddate].Attributes.Add("align", "center");
			}
			if (this.flag_instockquantity_store == "true")
			{
				item[this.cellvalue_instockquantity].Attributes.Add("align", "right");
				decimal num2 = Convert.ToDecimal(item[this.cellvalue_instockquantity].Text.ToString());
				string str1 = num2.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", " ");
				item[this.cellvalue_instockquantity].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str1), 0, "", true, false, true), "</div>");
			}
			if (this.flag_packquantity_store == "true")
			{
				item[this.cellvalue_packquantity].Attributes.Add("align", "right");
				decimal num3 = Convert.ToDecimal(item[this.cellvalue_packquantity].Text.ToString());
				string str2 = num3.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", " ");
				TableCell item1 = item[this.cellvalue_packquantity];
				string[] strArrays = new string[] { "<div style='width: ", this.type2, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str2), 0, "", true, false, true), "</div>" };
				item1.Text = string.Concat(strArrays);
			}
			if (this.flag_packcostprice_store == "true")
			{
				item[this.cellvalue_packcostprice].Attributes.Add("align", "right");
				decimal num4 = Convert.ToDecimal(item[this.cellvalue_packcostprice].Text.ToString());
				string str3 = num4.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", " ");
				TableCell tableCell1 = item[this.cellvalue_packcostprice];
				string[] strArrays1 = new string[] { "<div style='width: ", this.type4, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str3), 0, "", false, false, true), "</div>" };
				tableCell1.Text = string.Concat(strArrays1);
			}
			if (this.flag_unitprice_store == "true")
			{
				item[this.cellvalue_unitprice].Attributes.Add("align", "right");
				decimal num5 = Convert.ToDecimal(item[this.cellvalue_unitprice].Text.ToString());
				string str4 = num5.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", " ");
				TableCell item2 = item[this.cellvalue_unitprice];
				string[] strArrays2 = new string[] { "<div style='width: ", this.type2, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str4), 0, "", false, false, true), "</div>" };
				item2.Text = string.Concat(strArrays2);
			}
			if (this.flag_Is_archived == "true")
			{
				item[this.cellvalue_isarchived].Attributes.Add("align", "Center");
				if (item[this.cellvalue_isarchived].Text != "1")
				{
					item[this.cellvalue_isarchived].Text = "No";
				}
				else
				{
					item[this.cellvalue_isarchived].Text = "Yes";
				}
			}
			if (this.flag_prodName_store == "true")
			{
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					TableCell tableCell2 = item[this.cellvalue_prodName_store];
					string[] text = new string[] { "<div style='min-width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_prodName_store].Text, "</div>" };
					tableCell2.Text = string.Concat(text);
				}
				else
				{
					TableCell item3 = item[this.cellvalue_prodName_store];
					string[] text1 = new string[] { "<div style='width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_prodName_store].Text, "</div>" };
					item3.Text = string.Concat(text1);
				}
			}
			if (this.flag_suppName == "true")
			{
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					TableCell tableCell3 = item[this.cellvalue_suppName];
					string[] text2 = new string[] { "<div style='min-width: ", this.type5, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					tableCell3.Text = string.Concat(text2);
				}
				else
				{
					TableCell item4 = item[this.cellvalue_suppName];
					string[] text3 = new string[] { "<div style='width: ", this.type5, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					item4.Text = string.Concat(text3);
				}
			}
			if (this.flag_Description == "true")
			{
				TableCell tableCell4 = item[this.cellvalue_Description];
				string[] strArrays3 = new string[] { "<div style='width: ", this.type1, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Description].Text, "</div>" };
				tableCell4.Text = string.Concat(strArrays3);
			}
		}
		if (e.Item is GridFilteringItem)
		{
			GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
			if (this.flag_unitprice_store == "true")
			{
				gridFilteringItem[this.cellvalue_unitprice].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_packcostprice_store == "true")
			{
				gridFilteringItem[this.cellvalue_packcostprice].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_instockquantity_store == "true")
			{
				gridFilteringItem[this.cellvalue_instockquantity].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_packquantity_store == "true")
			{
				gridFilteringItem[this.cellvalue_packquantity].HorizontalAlign = HorizontalAlign.Right;
			}
			if (this.flag_IsArchive == "true")
			{
				gridFilteringItem[this.cellvalue_IsArchive].HorizontalAlign = HorizontalAlign.Center;
			}
			if (this.flag_createddate == "true")
			{
				gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
			}
		}
	}

	protected void OnRowDataBound_GridViewInv(object sender, GridItemEventArgs e)
	{
		if (e.Item.ItemType == GridItemType.Header)
		{
			e.Item.Visible = false;
			for (int i = 0; i < this.GridViewInv.Columns.Count; i++)
			{
				if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "inventorycode")
				{
					this.flag_inventoryno = "true";
					this.cellvalue_inventoryno = this.GridViewInv.Columns[i].SortExpression.ToLower();
				}
				if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "createddate")
				{
					this.cellvalue_createddate = this.GridViewInv.Columns[i].SortExpression;
					this.flag_createddate = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "cost")
				{
					this.cellvalue_cost = this.GridViewInv.Columns[i].SortExpression;
					this.flag_cost = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "unitprice")
				{
					this.cellvalue_unitprice = this.GridViewInv.Columns[i].SortExpression;
					this.flag_unitprice = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "action")
				{
					this.cellvalue_Action = this.GridViewInv.Columns[i].SortExpression;
					this.flag_Action = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "isarchived")
				{
					this.cellvalue_IsArchive = this.GridViewInv.Columns[i].SortExpression;
					this.flag_IsArchive = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "customheight")
				{
					this.cellvalue_height = this.GridViewInv.Columns[i].SortExpression;
					this.flag_customheight = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "inventoryname")
				{
					this.cellvalue_Name = this.GridViewInv.Columns[i].SortExpression;
					this.flag_Name = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "friendlyname")
				{
					this.cellvalue_friendlyname = this.GridViewInv.Columns[i].SortExpression;
					this.flag_friendlyname = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "colour")
				{
					this.cellvalue_color = this.GridViewInv.Columns[i].SortExpression;
					this.flag_color = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "suppliername")
				{
					this.cellvalue_suppName = this.GridViewInv.Columns[i].SortExpression;
					this.flag_suppName = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "customstocktype")
				{
					this.cellvalue_stockType = this.GridViewInv.Columns[i].SortExpression;
					this.flag_stockType = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "description")
				{
					this.GridViewInv.Columns[i].HeaderText = this.objLangClass.GetLanguageConversion("Description");
					this.cellvalue_Description = this.GridViewInv.Columns[i].SortExpression;
					this.flag_Description = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "availablequantity")
				{
					this.cellvalue_Availableqty = this.GridViewInv.Columns[i].SortExpression;
					this.flag_Availableqty = "true";
				}
				else if (this.GridViewInv.Columns[i].SortExpression.ToLower() == "location")
				{
					this.cellvalue_Location = this.GridViewInv.Columns[i].SortExpression;
					this.flag_Location = "true";
				}
			}
		}
		if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_InventoryID");
			GridDataItem item = (GridDataItem)e.Item;
			string str = string.Concat("inventory_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
			int num = (int)InventoryBasePage.inventory_getPackedIn_qty(this.CompanyID, Convert.ToInt32(hiddenField.Value));
			decimal num1 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", Convert.ToInt64(hiddenField.Value)));
			TableCell tableCell = item["InventoryCode"];
			string[] strArrays = new string[] { "<a style='color:#10357F;' href=", this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["InventoryCode"].Text, "</a>" };
			tableCell.Text = string.Concat(strArrays);
			try
			{
				AttributeCollection attributes = item["InventoryCode"].Attributes;
				object[] objArray = new object[] { "javascript:return Call_Estimate_Func('", ((DataRowView)e.Item.DataItem)[0].ToString(), "','", ((DataRowView)e.Item.DataItem)[1].ToString(), "','I','", item["UnitPrice"].Text, "','", num, "','", num1, "')" };
				attributes.Add("onclick", string.Concat(objArray));
			}
			catch
			{
			}
			HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hid_WeightSize");
			HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hid_Gsm");
			HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hid_PaperName");
			HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hid_PaperType");
			HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hid_LengthType");
			HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hid_WidthType");
			HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hid_Length");
			HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hid_Width");
			HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hid_Height");
			HiddenField hiddenField10 = (HiddenField)e.Item.FindControl("hid_PackedIn");
			HiddenField hiddenField11 = (HiddenField)e.Item.FindControl("hid_StockType");
			HiddenField hiddenField12 = (HiddenField)e.Item.FindControl("hid_PackedInType");
			HiddenField hiddenField13 = (HiddenField)e.Item.FindControl("hid_UnitPrice");
			HiddenField hiddenField14 = (HiddenField)e.Item.FindControl("hid_ChargableSheets");
			HiddenField hiddenField15 = (HiddenField)e.Item.FindControl("hid_InkType");
			if (this.flag_unitprice == "true")
			{
				if (hiddenField11.Value.ToLower() == "ink" || hiddenField11.Value.ToLower() == "inks")
				{
					item[this.cellvalue_unitprice].Attributes.Add("align", "right");
					item[this.cellvalue_unitprice].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
					item[this.cellvalue_unitprice].Style.Add("cursor", "pointer");
					if (hiddenField15.Value.ToLower() != "m")
					{
						TableCell item1 = item[this.cellvalue_unitprice];
						string[] strArrays1 = new string[] { "<div style='width: ", this.type4, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_unitprice].Text), 9, "", false, false, true), "</div>" };
						item1.Text = string.Concat(strArrays1);
					}
					else
					{
						TableCell tableCell1 = item[this.cellvalue_unitprice];
						string[] strArrays2 = new string[] { "<div style='width: ", this.type4, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_unitprice].Text), 0, "", false, false, true), " per ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField14.Value), 0, "", true, false, true), "</div>" };
						tableCell1.Text = string.Concat(strArrays2);
					}
				}
				else if (hiddenField11.Value.ToLower() == "paper" || hiddenField11.Value.ToLower() == "papers")
				{
					item[this.cellvalue_unitprice].Attributes.Add("align", "right");
					decimal num2 = Convert.ToDecimal(item[this.cellvalue_unitprice].Text);
					string str1 = num2.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", "");
					TableCell item2 = item[this.cellvalue_unitprice];
					string[] strArrays3 = new string[] { "<div style='width: ", this.type4, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str1), 4, "", false, false, true), "</div>" };
					item2.Text = string.Concat(strArrays3);
				}
				else
				{
					item[this.cellvalue_unitprice].Attributes.Add("align", "right");
					decimal num3 = Convert.ToDecimal(item[this.cellvalue_unitprice].Text);
					string str2 = num3.ToString().Replace(this.cmnDate.GetCurrencyinRequiredFormate("", true) ?? "", "");
					TableCell tableCell2 = item[this.cellvalue_unitprice];
					string[] strArrays4 = new string[] { "<div style='width: ", this.type4, ";max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str2), 0, "", false, false, true), "</div>" };
					tableCell2.Text = string.Concat(strArrays4);
				}
			}
			if (this.flag_Action == "true")
			{
				item[this.cellvalue_Action].Attributes.Add("align", "right");
				item[this.cellvalue_Action].Controls.Clear();
				ImageButton imageButton = new ImageButton()
				{
					ID = "imgbtnDelete",
					CommandArgument = hiddenField.Value,
					ImageUrl = "~/images/erase.png",
					ToolTip = this.objLanguage.GetLanguageConversion("Delete"),
					OnClientClick = string.Concat("javascript:return EraseCheck('", hiddenField.Value, "');")
				};
				item[this.cellvalue_Action].Controls.Add(imageButton);
				item[this.cellvalue_Action].Controls.Add(new LiteralControl("&nbsp;"));
				ImageButton imageButton1 = new ImageButton()
				{
					ID = "imgbtnCopy",
					CommandArgument = hiddenField.Value,
					ImageUrl = "~/images/copy.png",
					ToolTip = this.objLanguage.GetLanguageConversion("Copy"),
					OnClientClick = string.Concat("javascript:Copy('", hiddenField.Value, "')")
				};
				item[this.cellvalue_Action].Controls.Add(imageButton1);
				if (this.DeleteStatus.Trim().ToLower() != "false")
				{
					imageButton.Visible = true;
				}
				else
				{
					imageButton.Visible = false;
				}
				if (this.AddStatus.Trim().ToLower() != "false")
				{
					imageButton1.Visible = true;
					//this.RadMenu1.Items[0].Visible = true;
				}
				else
				{
					imageButton1.Visible = false;
					//this.RadMenu1.Items[0].Visible = false;
				}
			}
			if (this.flag_IsArchive == "true")
			{
				item[this.cellvalue_IsArchive].Attributes.Add("align", "Center");
				item[this.cellvalue_IsArchive].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_IsArchive].Style.Add("cursor", "pointer");
				if (item[this.cellvalue_IsArchive].Text != "1")
				{
					item[this.cellvalue_IsArchive].Text = "No";
				}
				else
				{
					item[this.cellvalue_IsArchive].Text = "Yes";
				}
			}
			if (this.flag_createddate == "true")
			{
				item[this.cellvalue_createddate].Attributes.Add("align", "center");
				item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
			}
			if (this.flag_Availableqty == "true")
			{
				item[this.cellvalue_Availableqty].Attributes.Add("align", "right");
				item[this.cellvalue_Availableqty].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_Availableqty].Style.Add("cursor", "pointer");
				item[this.cellvalue_Availableqty].Text = string.Concat("<div style='width:auto;overflow:hidden;max-height: 15px;height:15px;'>", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Availableqty].Text), 0, "", false, false, true), "</div>");
			}
			if (this.flag_cost == "true")
			{
				item[this.cellvalue_cost].Attributes.Add("align", "right");
				item[this.cellvalue_cost].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_cost].Style.Add("cursor", "pointer");
				if (hiddenField4.Value.ToLower() == "web printing")
				{
					if (Convert.ToDouble(hiddenField7.Value) == 0)
					{
						item[this.cellvalue_cost].Text = "0.00";
					}
					else
					{
						item[this.cellvalue_cost].Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_cost].Text), 0, "", false, false, true);
					}
				}
				if (hiddenField15.Value.ToLower() != "m")
				{
					item[this.cellvalue_cost].Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_cost].Text), 0, "", false, false, true);
				}
				else
				{
					item[this.cellvalue_cost].Text = string.Concat(this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_cost].Text), 0, "", false, false, true), " per ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField14.Value), 0, "", true, false, true));
				}
				item[this.cellvalue_cost].Text = string.Concat("<div style='width: 100px;max-height: 15px;height:15px;'>", item[this.cellvalue_cost].Text, "</div>");
			}
			if (this.cellvalue_height != "")
			{
				item[this.cellvalue_height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_height].Style.Add("cursor", "pointer");
				item[this.cellvalue_height].Text = this.objBase.SpecialDecode(item[this.cellvalue_height].Text);
				if (hiddenField11.Value.ToLower() != "paper")
				{
					hiddenField1.Value = "";
					hiddenField2.Value = "";
				}
				else
				{
					item[this.cellvalue_height].ToolTip = item[this.cellvalue_height].Text;
					item[this.cellvalue_height].Text = string.Concat("<div style='width:300;max-height: 15px;height:15px;'>", item[this.cellvalue_height].Text, "</div>");
				}
			}
			HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkAll");
			HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)e.Item.FindControl("Id");
			if (this.flag_stockType == "true")
			{
				item[this.cellvalue_stockType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_stockType].Style.Add("cursor", "pointer");
				item[this.cellvalue_stockType].ToolTip = item[this.cellvalue_stockType].Text;
				item[this.cellvalue_stockType].Text = string.Concat("<div style='width: auto;overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_stockType].Text, "</div>");
			}
			if (this.flag_Name == "true")
			{
				item[this.cellvalue_Name].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_Name].Style.Add("cursor", "pointer");
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					item[this.cellvalue_Name].ToolTip = item[this.cellvalue_Name].Text;
					TableCell item3 = item[this.cellvalue_Name];
					string[] text = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Name].Text, "</div>" };
					item3.Text = string.Concat(text);
				}
				else
				{
					item[this.cellvalue_Name].ToolTip = item[this.cellvalue_Name].Text;
					TableCell tableCell3 = item[this.cellvalue_Name];
					string[] text1 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Name].Text, "</div>" };
					tableCell3.Text = string.Concat(text1);
				}
			}
			if (this.flag_friendlyname == "true")
			{
				item[this.cellvalue_friendlyname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_friendlyname].Style.Add("cursor", "pointer");
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					item[this.cellvalue_friendlyname].ToolTip = item[this.cellvalue_friendlyname].Text;
					TableCell item4 = item[this.cellvalue_friendlyname];
					string[] text2 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_friendlyname].Text, "</div>" };
					item4.Text = string.Concat(text2);
				}
				else
				{
					item[this.cellvalue_friendlyname].ToolTip = item[this.cellvalue_friendlyname].Text;
					TableCell tableCell4 = item[this.cellvalue_friendlyname];
					string[] text3 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_friendlyname].Text, "</div>" };
					tableCell4.Text = string.Concat(text3);
				}
			}
			if (this.flag_color == "true")
			{
				item[this.cellvalue_color].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_color].Style.Add("cursor", "pointer");
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					item[this.cellvalue_color].ToolTip = item[this.cellvalue_color].Text;
					TableCell item5 = item[this.cellvalue_color];
					string[] text4 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_color].Text, "</div>" };
					item5.Text = string.Concat(text4);
				}
				else
				{
					item[this.cellvalue_color].ToolTip = item[this.cellvalue_color].Text;
					TableCell tableCell5 = item[this.cellvalue_color];
					string[] text5 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_color].Text, "</div>" };
					tableCell5.Text = string.Concat(text5);
				}
			}
			if (this.flag_suppName == "true")
			{
				item[this.cellvalue_suppName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_suppName].Style.Add("cursor", "pointer");
				if (!base.Request.Browser.Type.Contains("IE"))
				{
					item[this.cellvalue_suppName].ToolTip = item[this.cellvalue_suppName].Text;
					TableCell item6 = item[this.cellvalue_suppName];
					string[] strArrays5 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					item6.Text = string.Concat(strArrays5);
				}
				else
				{
					item[this.cellvalue_suppName].ToolTip = item[this.cellvalue_suppName].Text;
					TableCell tableCell6 = item[this.cellvalue_suppName];
					string[] text6 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
					tableCell6.Text = string.Concat(text6);
				}
			}
			if (this.flag_Description == "true")
			{
				item[this.cellvalue_Description].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_Description].Style.Add("cursor", "pointer");
				item[this.cellvalue_Description].ToolTip = item[this.cellvalue_Description].Text;
				TableCell item7 = item[this.cellvalue_Description];
				string[] strArrays6 = new string[] { "<div style='width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Description].Text, "</div>" };
				item7.Text = string.Concat(strArrays6);
			}
			if (this.flag_Location == "true")
			{
				item[this.cellvalue_Location].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
				item[this.cellvalue_Location].Style.Add("cursor", "pointer");
			}
		}
		if (e.Item is GridFilteringItem)
		{
			GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
			if (this.flag_inventoryno == "true")
			{
				TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_inventoryno].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_inventoryno)] != null && base.Session[string.Concat("inv_", this.cellvalue_inventoryno)].ToString() == "")
				{
					textBox.Text = "";
				}
			}
			if (this.flag_Description == "true")
			{
				TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_Description].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_Description)] != null && base.Session[string.Concat("inv_", this.cellvalue_Description)].ToString() == "")
				{
					textBox1.Text = "";
				}
			}
			if (this.flag_Name == "true")
			{
				TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_Name].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_Name)] != null && base.Session[string.Concat("inv_", this.cellvalue_Name)].ToString() == "")
				{
					textBox2.Text = "";
				}
			}
			if (this.flag_friendlyname == "true")
			{
				TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_friendlyname].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_friendlyname)] != null && base.Session[string.Concat("inv_", this.cellvalue_friendlyname)].ToString() == "")
				{
					textBox3.Text = "";
				}
			}
			if (this.flag_color == "true")
			{
				TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_color].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_color)] != null && base.Session[string.Concat("inv_", this.cellvalue_color)].ToString() == "")
				{
					textBox4.Text = "";
				}
			}
			if (this.flag_stockType == "true")
			{
				TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_stockType].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_stockType)] != null && base.Session[string.Concat("inv_", this.cellvalue_stockType)].ToString() == "")
				{
					textBox5.Text = "";
				}
			}
			if (this.flag_suppName == "true")
			{
				TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_suppName].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_suppName)] != null && base.Session[string.Concat("inv_", this.cellvalue_suppName)].ToString() == "")
				{
					textBox6.Text = "";
				}
			}
			if (this.flag_customheight == "true")
			{
				TextBox textBox7 = (e.Item as GridFilteringItem)[this.cellvalue_height].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_height)] != null && base.Session[string.Concat("inv_", this.cellvalue_height)].ToString() == "")
				{
					textBox7.Text = "";
				}
			}
			if (this.flag_cost == "true")
			{
				gridFilteringItem[this.cellvalue_cost].HorizontalAlign = HorizontalAlign.Right;
				TextBox item8 = (e.Item as GridFilteringItem)[this.cellvalue_cost].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_cost)] != null && base.Session[string.Concat("inv_", this.cellvalue_cost)].ToString() == "")
				{
					item8.Text = "";
				}
			}
			if (this.flag_unitprice == "true")
			{
				gridFilteringItem[this.cellvalue_unitprice].HorizontalAlign = HorizontalAlign.Right;
				TextBox textBox8 = (e.Item as GridFilteringItem)[this.cellvalue_unitprice].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_unitprice)] != null && base.Session[string.Concat("inv_", this.cellvalue_unitprice)].ToString() == "")
				{
					textBox8.Text = "";
				}
			}
			if (this.flag_IsArchive == "true")
			{
				gridFilteringItem[this.cellvalue_IsArchive].HorizontalAlign = HorizontalAlign.Center;
				TextBox item9 = (e.Item as GridFilteringItem)[this.cellvalue_IsArchive].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_IsArchive)] != null && base.Session[string.Concat("inv_", this.cellvalue_IsArchive)].ToString() == "")
				{
					item9.Text = "";
				}
			}
			if (this.flag_createddate == "true")
			{
				gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
				TextBox textBox9 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_createddate)] != null && base.Session[string.Concat("inv_", this.cellvalue_createddate)].ToString() == "")
				{
					textBox9.Text = "";
				}
			}
			if (this.flag_Availableqty == "true")
			{
				gridFilteringItem[this.cellvalue_Availableqty].HorizontalAlign = HorizontalAlign.Right;
				TextBox item10 = (e.Item as GridFilteringItem)[this.cellvalue_Availableqty].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_Availableqty)] != null && base.Session[string.Concat("inv_", this.cellvalue_Availableqty)].ToString() == "")
				{
					item10.Text = "";
				}
			}
			if (this.flag_Location == "true")
			{
				gridFilteringItem[this.cellvalue_Location].HorizontalAlign = HorizontalAlign.Left;
				TextBox textBox10 = (e.Item as GridFilteringItem)[this.cellvalue_Location].Controls[0] as TextBox;
				if (base.Session[string.Concat("inv_", this.cellvalue_Location)] != null && base.Session[string.Concat("inv_", this.cellvalue_Location)].ToString() == "")
				{
					textBox10.Text = "";
				}
			}
		}
		if (e.Item is GridPagerItem)
		{
			Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
			languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
			GridTableView masterTableView = this.GridViewInv.MasterTableView;
			GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
			GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
			this.GridViewInv.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
		}
	}
	protected void lnkCopy_OnClick(object sender, EventArgs e)
	{
		int num = 0;
		long num1 = this.objInv.Copy_Inventory(this.CompanyID, (long)Convert.ToInt32(this.hdnProcessedId.Value), num);
		string empty = string.Empty;
		string str = string.Empty;
		if (this.InventoryManagement == "IM")
		{
			foreach (DataRow row in this.objInv.warehouse_inventory_select(this.CompanyID, (long)Convert.ToInt32(this.hdnProcessedId.Value)).Rows)
			{
				empty = row["InventoryName"].ToString();
				row["FriendlyName"].ToString();
			}
			this.cmnDate.Insert_Activity_History_For_Inventory(num1, string.Concat("Copied Inventory from ", empty), this.UserID, Convert.ToInt32(Convert.ToDecimal(num)), "o", Convert.ToInt32(Convert.ToDecimal(num)));
		}
		HttpResponse response = base.Response;
		object[] objArray = new object[] { this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id=", num1, "&suc=cop" };
		response.Redirect(string.Concat(objArray));
	}

	protected void lnkDelete_OnClick(object sender, EventArgs e)
	{
		
		this.objInv.warehouse_inventory_delete(this.CompanyID, (long)Convert.ToInt32(this.hdnProcessedId.Value));
		this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
		this.GridViewInv.Rebind();
	}

		protected void Page_Load(object sender, EventArgs e)
	{
		this.lnkInventoryedit.Text = this.objLangClass.GetLanguageConversion("Edit_View");
		this.GridViewInv.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
		this.lblArchive.Text = this.objLangClass.GetLanguageConversion("Archive_Selected");
		this.lblUnArchive.Text = this.objLangClass.GetLanguageConversion("Un_Archive_Selected");
		this.lblDelete.Text = this.objLangClass.GetLanguageConversion("Detele_Selected");
		this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
		this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
		this.UnArchive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("UnArchive_Row_Selection_Alert");
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
		{
			this.DivSelected.Visible = true;
		}
		else
		{
			this.DivSelected.Visible = false;
		}
        if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
        {
            this.divarchive.Visible = true;
            this.divunarchive.Visible = true;
        }
        else
        {
            this.divarchive.Visible = false;
            this.divunarchive.Visible = false;
        }
		BaseClass baseClass1 = new BaseClass();
		this.AddStatus = baseClass1.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
		this.DeleteStatus = baseClass1.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString());
		if (this.DeleteStatus.Trim().ToLower() != "false")
		{
			//this.RadMenu1.Items[1].Visible = true;
		}
		else
		{
			//this.RadMenu1.Items[1].Visible = false;
		}
		global.pageName = "Inventory";
		global.pgName = "";
		this.gloobj.setpagename("Inventory");
		this.pg = "Inventory";
		this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
		this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
		this.DateFormat = base.Session["Dateformat"].ToString();
		DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
		this.ColorValue = dataTable.Rows[0]["Colour"].ToString();
		if (base.Request.Url.ToString().ToLower().Contains("/warehouse/warehouse.aspx?type=store"))
		{
			this.url = "store";
		}
		else if (base.Request.Url.ToString().ToLower().Contains("/warehouse/warehouse.aspx?type=item"))
		{
			this.url = "item";
		}
		else if (!base.Request.Url.ToString().ToLower().Contains("/warehouse/warehouse.aspx?type=inventory"))
		{
			this.url = "warehouse";
		}
		else
		{
			this.url = "warehouse";
		}
		if (base.Request.Params["type"] != null)
		{
			this.type = base.Request.Params["type"].ToString().ToLower();
		}
		this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
		this.WeightMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
		this.MeterMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "Metre");
		this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
		string str = this.cmnDate.UserSetting_Selete(this.CompanyID, this.UserID, "inventory_view");
		if (str != "" && str != null)
		{
			this.defaultviewid = Convert.ToInt32(str);
		}
		if (base.Session["InventoryViewID"] != null)
		{
			this.defaultviewid = Convert.ToInt32(base.Session["InventoryViewID"]);
		}
		if (!base.IsPostBack)
		{
			if (this.type == "inventory")
			{
				if (base.Request.Params["ViewID"] != null)
				{
					this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
					this.objCreateView.BindCustomView("inventory", this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
					int num = 0;
					while (num < this.ddl_View.Items.Count)
					{
						if (this.ddl_View.Items[num].Value != this.ViewID.ToString())
						{
							num++;
						}
						else
						{
							this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num].Value.ToString());
							break;
						}
					}
					this.lblView.Text = this.ddl_View.SelectedItem.Text;
				}
				else if (this.defaultviewid == 0)
				{
					this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.pg);
					if (this.dt.Rows.Count != 0)
					{
						foreach (DataRow row in this.dt.Rows)
						{
							this.defaultviewid = Convert.ToInt32(row["ViewID"].ToString());
						}
					}
					this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View);
					int num1 = 0;
					while (num1 < this.ddl_View.Items.Count)
					{
						if (this.ddl_View.Items[num1].Value != this.defaultviewid.ToString())
						{
							num1++;
						}
						else
						{
							this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num1].Value.ToString());
							break;
						}
					}
					this.lblView.Text = this.ddl_View.SelectedItem.Text;
				}
				else
				{
					this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, this.defaultviewid);
					int num2 = 0;
					while (num2 < this.ddl_View.Items.Count)
					{
						if (this.ddl_View.Items[num2].Value != this.defaultviewid.ToString())
						{
							num2++;
						}
						else
						{
							this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num2].Value.ToString());
							break;
						}
					}
					this.lblView.Text = this.ddl_View.SelectedItem.Text;
				}
				if (this.ddl_View.Text.Length == 0)
				{
					this.ddl_View.Visible = false;
				}
			}
			if (this.type == "store")
			{
				if (base.Request.Params["ViewID"] == null)
				{
					this.objCreateView.BindCustomView(this.type, this.CompanyID, this.ddl_View1);
					this.lblViewstore.Text = this.ddl_View1.SelectedItem.Text;
				}
				else
				{
					this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
					this.objCreateView.BindCustomView("store", this.CompanyID, this.ddl_View1, Convert.ToInt32(base.Request.Params["ViewID"]));
					int num3 = 0;
					while (num3 < this.ddl_View1.Items.Count)
					{
						if (this.ddl_View1.Items[num3].Value != this.ViewID.ToString())
						{
							num3++;
						}
						else
						{
							this.objBase.SetDDLValue(this.ddl_View1, this.ddl_View1.Items[num3].Value.ToString());
							break;
						}
					}
					this.lblViewstore.Text = this.ddl_View1.SelectedItem.Text;
				}
				if (this.ddl_View1.Text.Length == 0)
				{
					this.ddl_View1.Visible = false;
				}
			}
			if (this.type == "item")
			{
				if (base.Request.Params["ViewID"] == null)
				{
					this.objCreateView.BindCustomView(this.type, this.CompanyID, this.ddl_View2);
					this.lblviewCust.Text = this.ddl_View2.SelectedItem.Text;
				}
				else
				{
					this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
					this.objCreateView.BindCustomView("item", this.CompanyID, this.ddl_View2, Convert.ToInt32(base.Request.Params["ViewID"]));
					int num4 = 0;
					while (num4 < this.ddl_View2.Items.Count)
					{
						if (this.ddl_View2.Items[num4].Value != this.ViewID.ToString())
						{
							num4++;
						}
						else
						{
							this.objBase.SetDDLValue(this.ddl_View2, this.ddl_View2.Items[num4].Value.ToString());
							break;
						}
					}
					this.lblviewCust.Text = this.ddl_View2.SelectedItem.Text;
				}
				if (this.ddl_View2.Text.Length == 0)
				{
					this.ddl_View2.Visible = false;
				}
			}
		}
		int num5 = 0;
		num5 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
		this.dt = this.objCreateView.CustomizeView_Select(num5, this.CompanyID, this.type);
		if (this.dt.Rows.Count != 0)
		{
			foreach (DataRow dataRow in this.dt.Rows)
			{
				this.defaultsortedby = dataRow["SortedBy"].ToString();
				this.defaultsortdirection = dataRow["SortDirection"].ToString();
			}
		}
		if (!base.IsPostBack)
		{
			this.GridViewInv.PageSize = 50;
			inventory_store_customer_view.WhereCondition = "";
			inventory_store_customer_view.WhereConditionstore = "";
			inventory_store_customer_view.WhereConditionItem = "";
			base.Session["searchStore"] = null;
			base.Session["searchItem"] = null;
			if (this.defaultsortedby == "")
			{
				inventory_store_customer_view.SortedBy = "InventoryCode";
				inventory_store_customer_view.SortedBystore = "ProductCode";
				inventory_store_customer_view.SortedByItem = "ProductCode";
			}
			else
			{
				inventory_store_customer_view.SortedBy = this.defaultsortedby;
				inventory_store_customer_view.SortedBystore = this.defaultsortedby;
				inventory_store_customer_view.SortedByItem = this.defaultsortedby;
			}
			if (this.defaultsortedby == "")
			{
				inventory_store_customer_view.sortdirection = "Desc";
				inventory_store_customer_view.sortdirectionstore = "Desc";
				inventory_store_customer_view.sortdirectionItem = "Desc";
			}
			else if (this.defaultsortdirection != "")
			{
				inventory_store_customer_view.sortdirection = this.defaultsortdirection;
				inventory_store_customer_view.sortdirectionstore = this.defaultsortdirection;
				inventory_store_customer_view.sortdirectionItem = this.defaultsortdirection;
			}
		}
		if (base.Request.QueryString["viewid"] != null)
		{
			this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
			if (!base.IsPostBack && this.type == "inventory")
			{
				string str1 = string.Concat(this.pg, this.UserID, this.pg);
				base.Session["searchInv"] = null;
				base.Session[str1] = null;
			}
			this.Call_When_Warehousetab();
		}
		else if (!(this.InvenotoryInk == "estimate") && !base.IsPostBack)
		{
			this.Call_When_Warehousetab();
		}
		if (!base.IsPostBack && base.Request.Params["suc"] != null)
		{
			if (base.Request.Params["suc"].ToString().ToLower() == "ins")
			{
				if (this.type == "inventory")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Saved_Successfully"), "successfulMsg", this.plhMessage);
				}
				else if (this.type == "store")
				{
					this.objBase.Message_Display("Store Supply saved successfully", "successfulMsg", this.plhMessage);
				}
				else if (this.type == "item")
				{
					this.objBase.Message_Display("Customer Item saved successfully", "successfulMsg", this.plhMessage);
				}
			}
			else if (base.Request.Params["suc"].ToString().ToLower() == "upd")
			{
				if (this.type == "inventory")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Updated_Successfully").ToString(), "successfulMsg", this.plhMessage);
				}
				else if (this.type == "store")
				{
					this.objBase.Message_Display("Store Supply updated successfully", "successfulMsg", this.plhMessage);
				}
				else if (this.type == "item")
				{
					this.objBase.Message_Display("Customer Item updated successfully", "successfulMsg", this.plhMessage);
				}
			}
			else if (base.Request.Params["suc"].ToString().ToLower() == "d")
			{
				if (this.type == "inventory")
				{
					this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
				}
				else if (this.type == "store")
				{
					this.objBase.Message_Display("Store Supply deleted successfully", "successfulMsg", this.plhMessage);
				}
				else if (this.type == "item")
				{
					this.objBase.Message_Display("Customer Item(s) deleted successfully", "successfulMsg", this.plhMessage);
				}
			}
			else if (base.Request.Params["suc"].ToString().ToLower() != "ua")
			{
				if (base.Request.Params["suc"].ToString().ToLower() == "a")
				{
					if (this.type == "inventory")
					{
						this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
					}
					else if (this.type == "store")
					{
						this.objBase.Message_Display("Store Supply Archived successfully", "successfulMsg", this.plhMessage);
					}
					else if (this.type == "item")
					{
						this.objBase.Message_Display("Customer Item(s) Archived successfully", "successfulMsg", this.plhMessage);
					}
				}
			}
			else if (this.type == "inventory")
			{
				this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
			}
			else if (this.type == "store")
			{
				this.objBase.Message_Display("Store Supply Un-Archived successfully", "successfulMsg", this.plhMessage);
			}
			else if (this.type == "item")
			{
				this.objBase.Message_Display("Customer Item(s) Un-Archived successfully", "successfulMsg", this.plhMessage);
			}
		}
		if (!base.IsPostBack)
		{
			string str2 = "";
			this.GridStateLoad();
			if (base.Session["searchInv"] != null)
			{
				DataTable item = (DataTable)base.Session["searchInv"];
				str2 = this.FilterFunction(item);
			}
			base.Session["InventoryViewID"] = this.defaultviewid;
			inventory_store_customer_view.InvenotoryPageSize = this.cmnDate.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridViewInv);
			this.GridViewInv.PageSize = inventory_store_customer_view.InvenotoryPageSize;
			this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, inventory_store_customer_view.SortedBy, inventory_store_customer_view.sortdirection, str2);
			this.GridStateLoad();
			this.GridViewInv.Rebind();
		}
		if (this.type == "inventory")
		{
			try
			{
				this.GridViewInv.MasterTableView.GetColumn("InventoryID").Visible = false;
			}
			catch (Exception exception)
			{
			}
		}
		else if (this.type == "store")
		{
			try
			{
				this.GridStoreSupply.MasterTableView.GetColumn("FinishedGoodsID").Visible = false;
			}
			catch (Exception exception1)
			{
			}
		}
		else if (this.type == "item")
		{
			try
			{
				this.GridCustomerItem.MasterTableView.GetColumn("FinishedGoodsID").Visible = false;
			}
			catch (Exception exception2)
			{
			}
		}
	}
}
}