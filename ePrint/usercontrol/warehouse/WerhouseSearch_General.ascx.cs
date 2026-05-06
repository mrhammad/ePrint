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
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
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
    public partial class WerhouseSearch_General : System.Web.UI.UserControl
    {
        private int WarehouseReccount;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private InventoryBasePage objInv = new InventoryBasePage();

        private SetProperties objSp = new SetProperties();

        public commonClass cmnDate = new commonClass();

        public languageClass objLanguage = new languageClass();

        private string para = "";

        public string type = "inventory";

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

        public string flag_createddate_store = string.Empty;

        public string flag_instockquantity_store = string.Empty;

        public string flag_packquantity_store = string.Empty;

        public string flag_packcostprice_store = string.Empty;

        public string flag_unitprice_store = string.Empty;

        public string cellvalue_prodName_store = string.Empty;

        public string flag_prodName_store = string.Empty;

        public string type2 = "40px";

        public string type3 = "65px";

        public string type4 = "100px";

        public string type1 = "80px";

        public string type0 = "30px";

        public string type5 = "120px";

        public string type6 = "130px";

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public string WhereConditionstore = string.Empty;

        public string sortdirectionstore = string.Empty;

        public string SortedBystore = string.Empty;

        public string WhereConditionItem = string.Empty;

        public string sortdirectionItem = string.Empty;

        public string SortedByItem = string.Empty;

        public DataTable dt = new DataTable();

        public string pg;

        public string pgsearch = string.Empty;

        private DataTable dtsearchInv = new DataTable();

        private DataTable dtsearchStore = new DataTable();

        private DataTable dtsearchItem = new DataTable();

        public string DateFormat = string.Empty;

        private createViewClass objCreateView = new createViewClass();

        private BasePage objpage = new BasePage();

        public string PaperMeasure = string.Empty;

        public string WeightMeasure = string.Empty;

        public string MeterMeasure = string.Empty;

        public int InvenotoryPageSize;

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private string _InvenotoryInk = string.Empty;

        private string _IamFrom = string.Empty;

        private static bool ItemClick;

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

        static WerhouseSearch_General()
        {
        }

        public WerhouseSearch_General()
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
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                    else if (dt.Columns[i].ColumnName.ToLower() == "isarchived")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Int32");
                    }
                    else if (dt.Columns[i].ColumnName.ToLower() == "availablequantity")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Int32");
                    }
                }
                for (int j = 0; j < this.GridViewInv.Columns.Count; j++)
                {
                    this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewInv.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "inventorycode")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Product_Code");
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "inventoryname")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Name");
                        this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                        this.flag_Name = "true";
                        this.cellvalue_Name = this.GridViewInv.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "suppliername")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Supplier_Name");
                        this.GridViewInv.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridViewInv.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                        this.flag_suppName = "true";
                        this.cellvalue_suppName = this.GridViewInv.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "customheight")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Weight_Size");
                        this.cellvalue_height = this.GridViewInv.Columns[j].SortExpression;
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "customstocktype")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Stock_Type");
                        this.cellvalue_stocktype = this.GridViewInv.Columns[j].SortExpression;
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                        this.GridViewInv.Columns[j].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
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
                        this.GridViewInv.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Cost"), "(", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_cost = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_cost = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "unitprice")
                    {
                        this.GridViewInv.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), "(", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInv.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_unitprice = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_unitprice = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "isarchived")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Archived");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_IsArchive = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_IsArchive = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Created_On");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "availablequantity")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Available_Qty");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_Availableqty = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_Availableqty = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "location")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Location");
                        this.GridViewInv.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Location = this.GridViewInv.Columns[j].SortExpression;
                        this.flag_Location = "true";
                    }
                    else if (this.GridViewInv.Columns[j].SortExpression.ToLower() == "description")
                    {
                        this.GridViewInv.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Description");
                    }
                }
            }
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected void Call_When_Warehousetab()
        {
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

        public void GridBindInv(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para, string new_para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView_ForSearch(CompanyID, UserID, PageSize, PageNumber, "inventory", ViewID, SortedBy, SortDirection, para, new_para);
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
                    if (!row.Table.Columns.Contains("customheight"))
                    {
                        continue;
                    }
                    if (row["StockType"].ToString().ToLower() != "paper")
                    {
                        object[] objArray = new object[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Height"]), 0, "", false, false, true), " ", row["WidthType"], " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), " ", row["WidthType"] };
                        row["customheight"] = string.Concat(objArray);
                    }
                    else if (row["PaperType"].ToString().ToLower() == "sheet")
                    {
                        if (row["BasisWeight"].ToString().ToLower() != "0")
                        {
                            string[] strArrays = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["BasisWeight"]), 0, "", false, false, true), " ", this.WeightMeasure, " ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["height"]), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), " ", this.PaperMeasure };
                            row["customheight"] = string.Concat(strArrays);
                        }
                        else
                        {
                            string[] strArrays1 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["height"]), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), " ", this.PaperMeasure };
                            row["customheight"] = string.Concat(strArrays1);
                        }
                    }
                    else if (row["PaperType"].ToString().ToLower() == "web printing")
                    {
                        if (row["BasisWeight"].ToString().ToLower() != "0")
                        {
                            string[] strArrays2 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["BasisWeight"]), 0, "", false, false, true), " ", this.WeightMeasure, " ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Length"]), 0, "", false, false, true), " ", this.MeterMeasure };
                            row["customheight"] = string.Concat(strArrays2);
                        }
                        else
                        {
                            string[] strArrays3 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["WidthType"]), 0, "", false, false, true), " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row["Length"]), 0, "", false, false, true), " ", this.MeterMeasure };
                            row["customheight"] = string.Concat(strArrays3);
                        }
                    }
                    row["customheight"] = Convert.ToString(row["customheight"]).Replace(".00", "").Replace(".000", "").Replace(".0000", "");
                }
            }
            _commonClass.closeConnection();
            this.GridViewInv.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridViewInv);
                this.div_MainInv.Style.Add("display", "block");
                this.GridViewInv.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridViewInv);
                this.div_MainInv.Style.Add("display", "block");
                this.GridViewInv.AllowCustomPaging = true;
                this.GridViewInv.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.WarehouseReccount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getWarehouseRecordCount != null)
                {
                    this.getWarehouseRecordCount(this.WarehouseReccount);
                    return;
                }
            }
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
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
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
                        string text = item.Text;
                        char[] chrArray = new char[] { 'p' };
                        item.Text = text.Split(chrArray)[0];
                    }
                    item.Text = this.Only_number(item.Text);
                    if (item.Text != "")
                    {
                        item.Text = item.Text;
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
                if (item.Text != "")
                {
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearchInv.Rows.Add(second);
                    }
                    else
                    {
                        this.dtsearchInv.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            this.dtsearchInv.Rows.Add(objArray);
                        }
                    }
                }
                base.Session["searchInv"] = this.dtsearchInv;
                this.WhereCondition = "";
                this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.GridViewInv.Rebind();
            }
        }

        protected void GridViewInv_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInv.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInv.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInv.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInv.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.GridViewInv.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void GridViewInv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (this.type == "inventory")
            {
                this.GridViewInv.AllowCustomPaging = true;
                this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
            }
        }

        protected void GridViewInv_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            this.SortedBy = e.SortExpression;
            this.sortdirection = e.NewSortOrder.ToString();
            if (this.sortdirection.ToLower() == "ascending")
            {
                this.sortdirection = "ASC";
            }
            else if (this.sortdirection.ToLower() != "descending")
            {
                this.sortdirection = "ASC";
            }
            else
            {
                this.sortdirection = "DESC";
            }
            this.GridViewInv.CurrentPageIndex = 0;
            this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
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

        protected void OnRowDataBound_GridViewInv(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewInv.Columns.Count; i++)
                {
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
                string str = string.Concat("warehouse/inventory_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
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
                    if (hiddenField11.Value.ToLower() != "paper")
                    {
                        hiddenField1.Value = "";
                        hiddenField2.Value = "";
                    }
                    else
                    {
                        if (hiddenField4.Value.ToLower() == "sheet")
                        {
                            if (hiddenField1.Value != "0")
                            {
                                TableCell item3 = item[this.cellvalue_height];
                                string[] strArrays5 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField1.Value), 0, "", false, false, true), " ", this.WeightMeasure, " ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField9.Value), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField8.Value), 0, "", false, false, true), " ", this.PaperMeasure };
                                item3.Text = string.Concat(strArrays5);
                            }
                            else
                            {
                                TableCell tableCell3 = item[this.cellvalue_height];
                                string[] strArrays6 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField9.Value), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField8.Value), 0, "", false, false, true), " ", this.PaperMeasure };
                                tableCell3.Text = string.Concat(strArrays6);
                            }
                        }
                        else if (hiddenField4.Value.ToLower() == "web printing")
                        {
                            if (hiddenField1.Value != "0")
                            {
                                TableCell item4 = item[this.cellvalue_height];
                                string[] strArrays7 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField1.Value), 0, "", false, false, true), " ", this.WeightMeasure, " ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField8.Value), 0, "", false, false, true), " ", this.PaperMeasure, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField7.Value), 0, "", false, false, true), " ", this.MeterMeasure };
                                item4.Text = string.Concat(strArrays7);
                            }
                            else
                            {
                                TableCell tableCell4 = item[this.cellvalue_height];
                                string[] strArrays8 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField8.Value), 0, "", false, false, true), this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField6.Value), 0, "", false, false, true), " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField7.Value), 0, "", false, false, true), " ", this.MeterMeasure };
                                tableCell4.Text = string.Concat(strArrays8);
                            }
                        }
                        item[this.cellvalue_height].Text = Convert.ToString(item[this.cellvalue_height].Text).Replace(".00", "").Replace(".000", "").Replace(".0000", "");
                        item[this.cellvalue_height].Text = string.Concat("<div style='width:300;max-height: 15px;height:15px;'>", item[this.cellvalue_height].Text, "</div>");
                    }
                }
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkAll");
                HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)e.Item.FindControl("Id");
                string.Compare(this.IamFrom, "EstimateSummary", true);
                if (this.flag_stockType == "true")
                {
                    item[this.cellvalue_stockType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_stockType].Style.Add("cursor", "pointer");
                    item[this.cellvalue_stockType].Text = string.Concat("<div style='width: auto;overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_stockType].Text, "</div>");
                }
                if (this.flag_Name == "true")
                {
                    item[this.cellvalue_Name].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Name].Style.Add("cursor", "pointer");
                    if (!base.Request.Browser.Type.Contains("IE"))
                    {
                        TableCell item5 = item[this.cellvalue_Name];
                        string[] text = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Name].Text, "</div>" };
                        item5.Text = string.Concat(text);
                    }
                    else
                    {
                        TableCell tableCell5 = item[this.cellvalue_Name];
                        string[] text1 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Name].Text, "</div>" };
                        tableCell5.Text = string.Concat(text1);
                    }
                }
                if (this.flag_suppName == "true")
                {
                    item[this.cellvalue_suppName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_suppName].Style.Add("cursor", "pointer");
                    if (!base.Request.Browser.Type.Contains("IE"))
                    {
                        TableCell item6 = item[this.cellvalue_suppName];
                        string[] text2 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
                        item6.Text = string.Concat(text2);
                    }
                    else
                    {
                        TableCell tableCell6 = item[this.cellvalue_suppName];
                        string[] text3 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_suppName].Text, "</div>" };
                        tableCell6.Text = string.Concat(text3);
                    }
                }
                if (this.flag_Description == "true")
                {
                    item[this.cellvalue_Description].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Description].Style.Add("cursor", "pointer");
                    TableCell item7 = item[this.cellvalue_Description];
                    string[] text4 = new string[] { "<div style='width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Description].Text, "</div>" };
                    item7.Text = string.Concat(text4);
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
                if (this.flag_cost == "true")
                {
                    gridFilteringItem[this.cellvalue_cost].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_unitprice == "true")
                {
                    gridFilteringItem[this.cellvalue_unitprice].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_IsArchive == "true")
                {
                    gridFilteringItem[this.cellvalue_IsArchive].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_Availableqty == "true")
                {
                    gridFilteringItem[this.cellvalue_Availableqty].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_Location == "true")
                {
                    gridFilteringItem[this.cellvalue_Location].HorizontalAlign = HorizontalAlign.Left;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "Inventory";
            global.pgName = "";
            this.gloobj.setpagename("Inventory");
            this.pg = "Inventory";
            this.pgsearch = "Inventorysearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
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
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.WeightMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
            this.MeterMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "Metre");
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
                this.GridViewInv.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_display");
                this.GridViewInv.PageSize = 50;
                this.InvenotoryPageSize = 50;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, this.type);
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row in this.dt.Rows)
                {
                    this.defaultsortedby = row["SortedBy"].ToString();
                    this.defaultsortdirection = row["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                this.GridViewInv.PageSize = 50;
                this.WhereCondition = "";
                this.WhereConditionstore = "";
                this.WhereConditionItem = "";
                base.Session["searchStore"] = null;
                base.Session["searchItem"] = null;
                if (this.defaultsortedby == "")
                {
                    this.SortedBy = "InventoryCode";
                    this.SortedBystore = "ProductCode";
                    this.SortedByItem = "ProductCode";
                }
                else
                {
                    this.SortedBy = this.defaultsortedby;
                    this.SortedBystore = this.defaultsortedby;
                    this.SortedByItem = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    this.sortdirection = "Desc";
                    this.sortdirectionstore = "Desc";
                    this.sortdirectionItem = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    this.sortdirection = this.defaultsortdirection;
                    this.sortdirectionstore = this.defaultsortdirection;
                    this.sortdirectionItem = this.defaultsortdirection;
                }
            }
            if (base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                if (!base.IsPostBack && this.type == "inventory")
                {
                    string str1 = string.Concat(this.pgsearch, this.UserID, this.pgsearch);
                    base.Session["searchInv"] = null;
                    base.Session[str1] = null;
                }
            }
            else if (this.InvenotoryInk != "estimate")
            {
                bool isPostBack = base.IsPostBack;
            }
            if (!base.IsPostBack)
            {
                string str2 = "";
                string str3 = "";
                if (base.Request.Params["srch_val"] != null)
                {
                    BaseClass baseClass = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str4 = baseClass.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(InventoryCode LIKE '%", str4, "%' OR InventoryName LIKE '%", str4, "%' OR FriendlyName LIKE '%", str4, "%' OR Description LIKE '%", str4, "%' OR Location LIKE '%", str4, "%' OR SupplierName LIKE '%", str4, "%')" };
                    str3 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["searchInv"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["searchInv"];
                    str2 = "";
                }
                base.Session["InventoryViewID"] = this.defaultviewid;
                this.InvenotoryPageSize = this.cmnDate.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewInv);
                this.GridViewInv.PageSize = this.InvenotoryPageSize;
                this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.GridViewInv.Rebind();
            }
            if (this.type == "inventory")
            {
                this.GridViewInv.MasterTableView.GetColumn("InventoryID").Visible = false;
            }
        }

        public event GetWarehouseRecCount getWarehouseRecordCount;
    }
}