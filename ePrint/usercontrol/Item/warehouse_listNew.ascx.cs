using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace ePrint.usercontrol.Item
{
    public partial class warehouse_listNew : UsercontrolBasePage
    {
        //protected usercontrol_settings_Loading ucLoading;

        //protected UpdateProgress UpPro;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UpdatePanel2;

        //protected RadGrid GridViewInv;

        //protected HtmlGenericControl div_MainInv;

        //protected HiddenField hid_plhMessage;

        //protected LinkButton btn_inventory;

        //protected UpdatePanel upWare;

        //protected Label Label1;

        //protected ImageButton ImageButton2;

        //protected Label Label135;

        //protected TextBox txtWarehouseQuantity;

        //protected Label Label7;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor img_UpdateDEscription;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Label Label2;

        //protected CheckBox chkPoduct1;

        //protected CheckBox chkPoduct2;

        //protected HtmlGenericControl Div_Productcatalogue;

        //protected Button Button6;

        //protected Button Button8;

        //protected HiddenField hdnProtrait;

        //protected HiddenField hdnLandscale;

        //protected Panel pnladd;

        //protected Button btnprevious;

        //protected Button Button3;

        //protected HiddenField hid_warehouse_save;

        //protected HiddenField hdn_WarehouseDesc;

        //protected HiddenField hid_ware_data;

        //protected CheckBox chkWareItemtitle;

        //protected TextBox txt_lblWareItemtitle;

        //protected ImageButton ImageButton45;

        //protected HiddenField hdn_lblWareItemtitle;

        //protected TextBox txtWareItemTitle;

        //protected CheckBox chk_Ware_Phrase_ItemTitle;

        //protected Label Label133;

        //protected Label Label134;

        //protected CheckBox chkWareDescription;

        //protected TextBox txt_lblWareDescription;

        //protected ImageButton ImageButton46;

        //protected HiddenField hdn_lblWareDescription;

        //protected TextBox txtWareDesign;

        //protected CheckBox chk_Ware_Phrase_Design;

        //protected CheckBox chkWareArtwork;

        //protected TextBox txt_lblWareArtwork;

        //protected ImageButton ImageButton47;

        //protected HiddenField hdn_lblWareArtwork;

        //protected TextBox txtWareArtwork;

        //protected CheckBox chk_Ware_Phrase_Artwork;

        //protected CheckBox chkWareColour;

        //protected TextBox txt_lblWareColour;

        //protected ImageButton ImageButton48;

        //protected HiddenField hdn_lblWareColour;

        //protected TextBox txtWareColour;

        //protected CheckBox chk_Ware_Phrase_Colour;

        //protected CheckBox chkWareSize;

        //protected TextBox txt_lblWareSize;

        //protected ImageButton ImageButton49;

        //protected HiddenField hdn_lblWareSize;

        //protected TextBox txtWareSize;

        //protected CheckBox chk_Ware_Phrase_Size;

        //protected CheckBox chkWareMaterial;

        //protected TextBox txt_lblWareMaterial;

        //protected ImageButton ImageButton50;

        //protected HiddenField hdn_lblWareMaterial;

        //protected TextBox txtWareMaterial;

        //protected CheckBox chk_Ware_Phrase_Material;

        //protected CheckBox chkWareDelivery;

        //protected TextBox txt_lblWareDelivery;

        //protected ImageButton ImageButton51;

        //protected HiddenField hdn_lblWareDelivery;

        //protected TextBox txtWareDelivery;

        //protected CheckBox chk_Ware_Phrase_Delivery;

        //protected CheckBox chkWareFinishing;

        //protected TextBox txt_lblWareFinishing;

        //protected ImageButton ImageButton52;

        //protected HiddenField hdn_lblWareFinishing;

        //protected TextBox txtWareFinishing;

        //protected CheckBox chk_Ware_Phrase_Finishing;

        //protected CheckBox chkWareNotes;

        //protected TextBox txt_lblWareNotes;

        //protected ImageButton ImageButton53;

        //protected HiddenField hdn_lblWareNotes;

        //protected TextBox txtWareNotes;

        //protected CheckBox chk_Ware_Phrase_Notes;

        //protected CheckBox chkWareInstructions;

        //protected TextBox txt_lblWareInstructions;

        //protected ImageButton ImageButton69;

        //protected HiddenField hdn_lblWareInstructions;

        //protected TextBox txtWareInstructions;

        //protected CheckBox chk_Ware_Phrase_Instructions;

        //protected Label Label10;

        //protected ImageButton ImageButtonNew2;

        //protected Button btnYes1;

        //protected Button btnNo1;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField hdnStockReduce;

        //protected HiddenField hdnStockReduceNew;

        //protected HiddenField hidEditMainWarehouse;

        //protected HiddenField hdn_invStockReduce;

        //protected Panel pnlWarehouseOnly;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CompanyID;

        public int UserID;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private InventoryBasePage objInv = new InventoryBasePage();

        private SetProperties objSp = new SetProperties();

        private commonClass cmnDate = new commonClass();

        private commonClass objJava = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objLanguage = new languageClass();

        private string para = "";

        public string type = string.Empty;

        public string url = string.Empty;

        public string ItemType = string.Empty;

        public int totalrec;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public int cellvalue_instockquantity;

        public string flag_instockquantity = string.Empty;

        public int cellvalue_packquantity;

        public string flag_packquantity = string.Empty;

        public int cellvalue_packcostprice;

        public string flag_packcostprice = string.Empty;

        public int cellvalue_createddate;

        public string flag_createddate = string.Empty;

        public int cellvalue_unitprice;

        public string flag_unitprice = string.Empty;

        public int cellvalue_height;

        public int cellvalue_stocktype;

        public int cellvalue_cost;

        public string flag_cost = string.Empty;

        public string flag_createddate_item = string.Empty;

        public string flag_instockquantity_item = string.Empty;

        public string flag_packquantity_item = string.Empty;

        public string flag_packcostprice_item = string.Empty;

        public string flag_unitprice_item = string.Empty;

        public string flag_createddate_store = string.Empty;

        public string flag_instockquantity_store = string.Empty;

        public string flag_packquantity_store = string.Empty;

        public string flag_packcostprice_store = string.Empty;

        public string flag_unitprice_store = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public DataTable dt = new DataTable();

        public string pg;

        private createViewClass objCreateView = new createViewClass();

        private DataTable dtsearchInv = new DataTable();

        private DataTable dtsearchStore = new DataTable();

        private DataTable dtsearchItem = new DataTable();

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public string DateFormat = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long EstSingleItemID;

        public long EstPadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        public string EstTypeFromSP = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        public int PageSize = 25;

        private CompanyBasePage objCom = new CompanyBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string subedit = string.Empty;

        public long EstimateBookletItemID;

        public string WareType = string.Empty;

        private commonClass commclass = new commonClass();

        private SummaryClass summryCls = new SummaryClass();

        public string frmcopyitem = string.Empty;

        public string MainType = string.Empty;

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        public static string WhereConditionstore;

        public static string sortdirectionstore;

        public static string SortedBystore;

        public static string WhereConditionItem;

        public static string sortdirectionItem;

        public static string SortedByItem;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int defaultviewid;

        public int IsProductCreated;

        public string ReduceStockType = string.Empty;

        public string oldWareItemID = string.Empty;

        public string oldQuantity = string.Empty;

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

        static warehouse_listNew()
        {
            warehouse_listNew.WhereCondition = string.Empty;
            warehouse_listNew.sortdirection = string.Empty;
            warehouse_listNew.SortedBy = string.Empty;
            warehouse_listNew.WhereConditionstore = string.Empty;
            warehouse_listNew.sortdirectionstore = string.Empty;
            warehouse_listNew.SortedBystore = string.Empty;
            warehouse_listNew.WhereConditionItem = string.Empty;
            warehouse_listNew.sortdirectionItem = string.Empty;
            warehouse_listNew.SortedByItem = string.Empty;
        }

        public warehouse_listNew()
        {
        }

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.QueryType == "add")
            {
                if (this.modulename != "orders")
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (empty.ToLower() != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse httpResponse = base.Response;
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            httpResponse.Redirect(string.Concat(objArray));
                        }
                    }
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        if (this.submodulename.ToLower() == "estimate")
                        {
                            this.submodulename = "estimates";
                        }
                        if (this.submodulename.ToLower() == "job")
                        {
                            this.submodulename = "job";
                        }
                        if (this.submodulename.ToLower() == "invoice")
                        {
                            this.submodulename = "invoices";
                        }
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=W&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response3.Redirect(string.Concat(estimateID3));
                    return;
                }
            }
            else if (this.QueryType == "edit")
            {
                if (this.modulename != "orders")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        if (empty.ToLower() == "yes")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response4.Redirect(string.Concat(estimateID4));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        if (empty.ToLower() == "yes")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(objArray4));
                            return;
                        }
                        HttpResponse response5 = base.Response;
                        object[] estimateID5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        response5.Redirect(string.Concat(estimateID5));
                        return;
                    }
                    if (this.submodulename.ToLower() == "estimate")
                    {
                        this.submodulename = "estimates";
                    }
                    if (this.submodulename.ToLower() == "job")
                    {
                        this.submodulename = "job";
                    }
                    if (this.submodulename.ToLower() == "invoice")
                    {
                        this.submodulename = "invoices";
                    }
                    HttpResponse httpResponse5 = base.Response;
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=W&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response6.Redirect(string.Concat(estimateID6));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        HttpResponse httpResponse6 = base.Response;
                        object[] objArray6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        httpResponse6.Redirect(string.Concat(objArray6));
                        return;
                    }
                }
            }
        }

        protected void btnsubmit_onclick(object sender, EventArgs e)
        {
            this.WareType = "inv";
            if (this.hid_plhMessage.Value == "succ")
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Item_Added_Successfully"), "successfulMsg", this.plhMessage);
                this.hid_plhMessage.Value = "abc";
                warehouse_listNew.SortedBy = "InventoryID";
                warehouse_listNew.sortdirection = "DESC";
                warehouse_listNew.WhereCondition = "";
                base.Session["searchInv"] = null;
                foreach (GridColumn column in this.GridViewInv.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.GridViewInv.MasterTableView.FilterExpression = string.Empty;
            }
            this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, warehouse_listNew.SortedBy, warehouse_listNew.sortdirection, warehouse_listNew.WhereCondition);
            this.GridViewInv.Rebind();
        }

        private void call_java()
        {
            this.objBase.callJavascript(this.upWare, "divLoading_Warehouse");
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            warehouse_listNew.WhereCondition = "";
            base.Session["searchInv"] = null;
            foreach (GridColumn column in this.GridViewInv.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridViewInv.MasterTableView.FilterExpression = string.Empty;
            this.GridViewInv.MasterTableView.Rebind();
        }

        private void DDPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridBindInv(this.CompanyID, this.UserID, this.PageSize, 1, "suppliername", "desc", "false");
        }

        public void GridBindInv(int CompanyID, int UserID, int PageSize, int PageNumber, string SortedBy, string SortDirection, string para)
        {
            string columnNames = GetColumnNamesFromDatabase();
            HashSet<string> visibleColumns = new HashSet<string>(columnNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

            string[] targetColumns = { "InventoryCode", "InventoryName", "Cost", "SupplierName", "UnitPrice", "Description", "CreatedDate", "Archived", "AvailableQuantity", "Location", "FriendlyName", "Color", "StockType", "Weight" };
            DataSet dataSet = InventoryBasePage.Select_Inventory_Select_Estimate(CompanyID, PageSize, PageNumber, SortedBy, SortDirection, para);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (string columnName in targetColumns)
                {
                    GridColumn gridColumn = GridViewInv.MasterTableView.Columns.FindByUniqueName(columnName);
                    if (gridColumn != null)
                    {
                        gridColumn.Visible = visibleColumns.Contains(columnName);
                    }
                }

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (dataSet.Tables[0].Columns.Contains("SupplierName"))
                    {
                        row["SupplierName"] = this.objBase.SpecialDecode(row["SupplierName"].ToString());
                    }
                    if (dataSet.Tables[0].Columns.Contains("Description"))
                    {
                        row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
                    }
                    if (dataSet.Tables[0].Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                }
            }

            this.GridViewInv.DataSource = dataSet;
            this.GridViewInv.Visible = true;

            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.GridViewInv.AllowCustomPaging = false;
                return;
            }

            this.GridViewInv.AllowCustomPaging = true;
            this.GridViewInv.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }


        private void GridStateLoad()
        {
            this.cmnDate.GridStateLoadNew("job", "jobWarehouse", this.GridViewInv, "no");
        }

        private void GridStateSave()
        {
            this.cmnDate.GridStateSaveNew("job", "jobWarehouse", this.GridViewInv);
        }

        protected void GridViewInv_ItemCommand(object sender, GridCommandEventArgs e)
        {
            int num=0;
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                warehouse_listNew.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                int num1 = 0;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    num1 = Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "cost" || commandArgument.Second.ToString().ToLower() == "unitprice"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Pls_Enter_Only_Number"), "msg-fail", this.plhErrorMessage);
                    }
                    else
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
                else if ((int)dataRowArray.Length > 0 && (commandArgument.First.ToString().ToLower() == "nofilter" || item.Text == ""))
                {
                    for (int i = 0; i < this.dtsearchInv.Rows.Count; i++)
                    {
                        if (this.dtsearchInv.Rows[i][0].ToString() == commandArgument.Second.ToString())
                        {
                            this.dtsearchInv.Rows.Remove(this.dtsearchInv.Rows[i]);
                        }
                    }
                }
                base.Session["searchInv"] = this.dtsearchInv;
                foreach (DataRow dataRow in this.dtsearchInv.Rows)
                {
                    if (dataRow["filter"].ToString().ToLower() != "nofilter" && warehouse_listNew.WhereCondition != "")
                    {
                        warehouse_listNew.WhereCondition = string.Concat(warehouse_listNew.WhereCondition, " and ");
                    }
                    if (dataRow["ColumnName"].ToString().ToLower() == "cost")
                    {
                        empty1 = dataRow["FilterText"].ToString();
                        object[] str1 = new object[] { "round(a.", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                        empty = string.Concat(str1);
                    }
                    else if (dataRow["ColumnName"].ToString().ToLower() == "description" || dataRow["ColumnName"].ToString().ToLower() == "inventorycode" || dataRow["ColumnName"].ToString().ToLower() == "inventoryname")
                    {
                        empty1 = dataRow["FilterText"].ToString();
                        empty = string.Concat("a.", dataRow["ColumnName"].ToString());
                    }
                    else
                    {
                        empty = dataRow["ColumnName"].ToString();
                        empty1 = dataRow["FilterText"].ToString();
                    }
                    string lower = dataRow["filter"].ToString().ToLower();
                    string str2 = lower;
                    if (lower == null)
                    {
                        continue;
                    }
    //                if (< PrivateImplementationDetails >{ B729CE83 - 281E-4939 - B299 - 0AD9FF224B5B}.$$method0x600000b - 1 == null)
				//{

    //                < PrivateImplementationDetails >{ B729CE83 - 281E-4939 - B299 - 0AD9FF224B5B}.$$method0x600000b - 1 = new Dictionary<string, int>(10)
    //                {
    //                    { "startswith", 0 },
    //                    { "endswith", 1 },
    //                    { "contains", 2 },
    //                    { "doesnotcontain", 3 },
    //                    { "equalto", 4 },
    //                    { "notequalto", 5 },
    //                    { "greaterthan", 6 },
    //                    { "greaterthanorequalto", 7 },
    //                    { "lessthan", 8 },
    //                    { "lessthanorequalto", 9 }
    //                };
    //                }
    //                if (!< PrivateImplementationDetails >{ B729CE83 - 281E-4939 - B299 - 0AD9FF224B5B}.$$method0x600000b - 1.TryGetValue(str2, out num))
				//{
    //                    continue;
    //                }
                    switch (num)
                    {
                        case 0:
                            {
                                string whereCondition = warehouse_listNew.WhereCondition;
                                string[] strArrays = new string[] { whereCondition, " ", empty, " like '%", empty1, "%'" };
                                warehouse_listNew.WhereCondition = string.Concat(strArrays);
                                continue;
                            }
                        case 1:
                            {
                                string whereCondition1 = warehouse_listNew.WhereCondition;
                                string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", empty1, "'" };
                                warehouse_listNew.WhereCondition = string.Concat(strArrays1);
                                continue;
                            }
                        case 2:
                            {
                                string whereCondition2 = warehouse_listNew.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " like '%", empty1, "%'" };
                                warehouse_listNew.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                        case 3:
                            {
                                string whereCondition3 = warehouse_listNew.WhereCondition;
                                string[] strArrays3 = new string[] { whereCondition3, " ", empty, " not like '%", empty1, "%'" };
                                warehouse_listNew.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        case 4:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str3 = warehouse_listNew.WhereCondition;
                                    string[] strArrays4 = new string[] { str3, " ", empty, " = ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays4);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition4 = warehouse_listNew.WhereCondition;
                                    string[] strArrays5 = new string[] { whereCondition4, " ", empty, " = '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays5);
                                    continue;
                                }
                            }
                        case 5:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str4 = warehouse_listNew.WhereCondition;
                                    string[] strArrays6 = new string[] { str4, " ", empty, " != ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays6);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition5 = warehouse_listNew.WhereCondition;
                                    string[] strArrays7 = new string[] { whereCondition5, " ", empty, " != '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays7);
                                    continue;
                                }
                            }
                        case 6:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str5 = warehouse_listNew.WhereCondition;
                                    string[] strArrays8 = new string[] { str5, " ", empty, " > ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays8);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition6 = warehouse_listNew.WhereCondition;
                                    string[] strArrays9 = new string[] { whereCondition6, " ", empty, " > '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays9);
                                    continue;
                                }
                            }
                        case 7:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str6 = warehouse_listNew.WhereCondition;
                                    string[] strArrays10 = new string[] { str6, " ", empty, " >= ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays10);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition7 = warehouse_listNew.WhereCondition;
                                    string[] strArrays11 = new string[] { whereCondition7, " ", empty, " >= '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays11);
                                    continue;
                                }
                            }
                        case 8:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str7 = warehouse_listNew.WhereCondition;
                                    string[] strArrays12 = new string[] { str7, " ", empty, " < ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays12);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition8 = warehouse_listNew.WhereCondition;
                                    string[] strArrays13 = new string[] { whereCondition8, " ", empty, " < '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays13);
                                    continue;
                                }
                            }
                        case 9:
                            {
                                if (dataRow["ColumnName"].ToString().ToLower() == "cost" || dataRow["ColumnName"].ToString().ToLower() == "unitprice" || dataRow["ColumnName"].ToString().ToLower() == "isarchived")
                                {
                                    string str8 = warehouse_listNew.WhereCondition;
                                    string[] strArrays14 = new string[] { str8, " ", empty, " <= ", empty1 };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays14);
                                    continue;
                                }
                                else
                                {
                                    string whereCondition9 = warehouse_listNew.WhereCondition;
                                    string[] strArrays15 = new string[] { whereCondition9, " ", empty, " <= '", empty1, "'" };
                                    warehouse_listNew.WhereCondition = string.Concat(strArrays15);
                                    continue;
                                }
                            }
                        default:
                            {
                                continue;
                            }
                    }
                }
                this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, 1, warehouse_listNew.SortedBy, warehouse_listNew.sortdirection, warehouse_listNew.WhereCondition);
                this.GridViewInv.Rebind();
            }
        }

        protected void GridViewInv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewInv.AllowCustomPaging = true;
            this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, warehouse_listNew.SortedBy, warehouse_listNew.sortdirection, warehouse_listNew.WhereCondition);
        }

        protected void GridViewInv_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            warehouse_listNew.SortedBy = e.SortExpression;
            warehouse_listNew.sortdirection = e.NewSortOrder.ToString();
            if (warehouse_listNew.sortdirection.ToLower() == "ascending")
            {
                warehouse_listNew.sortdirection = "ASC";
            }
            else if (warehouse_listNew.sortdirection.ToLower() != "descending")
            {
                warehouse_listNew.sortdirection = "ASC";
            }
            else
            {
                warehouse_listNew.sortdirection = "DESC";
            }
            this.GridViewInv.CurrentPageIndex = 0;
            this.GridBindInv(this.CompanyID, this.UserID, this.GridViewInv.PageSize, this.GridViewInv.CurrentPageIndex + 1, warehouse_listNew.SortedBy, warehouse_listNew.sortdirection, "");
        }

        public void Insert_activity_history(int CompanyID, long EstimateID, long EstimateItemID)
        {
            DateTime now;
            if (string.Compare(this.MainType, "add", true) != 0)
            {
                if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
                {
                    string empty = string.Empty;
                    if (this.modulename == "estimates")
                    {
                        foreach (DataRow row in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else if (this.modulename == "jobs")
                    {
                        foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow["rownumber"].ToString();
                        }
                        this.objnotes.ModuleName = "job";
                        this.objnotes.Item_number = empty;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (this.modulename == "invoice")
                    {
                        foreach (DataRow row1 in Notes.select_item_number_for_Activity_History(this.InvoiceID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (this.modulename == "orders")
                    {
                        foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                    }
                    this.objnotes.ModuleID = EstimateID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objJava;
                    now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                }
                return;
            }
            long num = (long)0;
            if (!this.modulename.Contains("job"))
            {
                num = (!this.modulename.Contains("invoice") ? EstimateID : this.InvoiceID);
            }
            else
            {
                num = this.jobID;
            }
            string str = "W";
            string str1 = "Warehouse Item";
            string empty1 = string.Empty;
            foreach (DataRow row2 in Notes.select_item_Title_for_Activity_History(CompanyID, num, EstimateItemID, str).Rows)
            {
                empty1 = row2["itemtitle"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] == null && !(base.Request.Params["FrmAddAnItem"] == "Y"))
            {
                string empty2 = string.Empty;
                if (this.modulename == "estimates")
                {
                    foreach (DataRow dataRow2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                    {
                        empty2 = dataRow2["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                else if (this.modulename == "jobs")
                {
                    foreach (DataRow row3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "job", (long)0).Rows)
                    {
                        empty2 = row3["jobnumber"].ToString();
                    }
                    this.objnotes.Job_type = str1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = empty2;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                }
                else if (this.modulename == "invoice")
                {
                    foreach (DataRow dataRow3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "invoice", (long)0).Rows)
                    {
                        empty2 = dataRow3["invoicenumber"].ToString();
                    }
                    this.objnotes.Invoice_type = str1;
                    this.objnotes.Invoice_number = empty2;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                }
                else if (this.modulename == "orders")
                {
                    foreach (DataRow row4 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                    {
                        empty2 = row4["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                this.objnotes.ModuleID = EstimateID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            string str2 = string.Empty;
            if (this.modulename == "estimates")
            {
                foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                {
                    str2 = dataRow4["rownumber"].ToString();
                }
                this.objnotes.Item_title = empty1;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                this.objnotes.Item_number = str2;
                this.objnotes.Estimate_type = str1;
            }
            else if (this.modulename == "jobs")
            {
                foreach (DataRow row5 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                {
                    str2 = row5["rownumber"].ToString();
                }
                this.objnotes.Item_title = empty1;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                this.objnotes.Item_number = str2;
                this.objnotes.Job_type = str1;
            }
            else if (this.modulename == "invoice")
            {
                foreach (DataRow dataRow5 in Notes.select_item_number_for_Activity_History(this.InvoiceID, EstimateItemID, this.modulename).Rows)
                {
                    str2 = dataRow5["rownumber"].ToString();
                }
                this.objnotes.Item_title = empty1;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                this.objnotes.Item_number = str2;
                this.objnotes.Invoice_type = str1;
            }
            else if (this.modulename == "orders")
            {
                foreach (DataRow row6 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                {
                    str2 = row6["rownumber"].ToString();
                }
                this.objnotes.Item_title = empty1;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                this.objnotes.Item_number = str2;
                this.objnotes.Estimate_type = str1;
            }
            this.objnotes.ModuleID = EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass2 = this.objnotes;
            commonClass _commonClass2 = this.objJava;
            now = DateTime.Now;
            _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
            this.objnotes.CompanyID = CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        protected void OnClick_WarehouseInsert(object sender, EventArgs e)
        {
            long estimateBookletItemID = (long)0;
            string empty = string.Empty;
            if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                if (base.Request.Params["subedit"] == null || !(base.Request.Params["subedit"].ToString().ToLower() == "y"))
                {
                    if(!string.IsNullOrEmpty(this.hid_InventoryNo.Value))
                    {
                        this.WarehouseItem_Update(this.EstimateItemID, (long)0, "");
                    }
                }
                else if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
                {
                    estimateBookletItemID = this.EstimateBookletItemID;
                    this.WarehouseItem_Update(this.EstimateItemID, estimateBookletItemID, this.ParentEstimateType);
                }
                else
                {
                    this.WarehouseItem_Update(this.EstimateItemID, this.ParentEstimateItemID, this.ParentEstimateType);
                }
            }
            else if (string.Compare(this.QueryType, "add", true) == 0 || this.frmcopyitem == "yes")
            {
                if (this.ParentEstimateItemID != (long)0)
                {
                    long parentEstimateItemID = (long)0;
                    bool flag = false;
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        flag = false;
                        parentEstimateItemID = this.ParentEstimateItemID;
                    }
                    else
                    {
                        flag = true;
                        parentEstimateItemID = (long)0;
                    }
                    DataTable dataTable = EstimatesBasePage.Estimate_SingleItem_Subitem_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        estimateBookletItemID = Convert.ToInt64(row["EstSPBWOUCitemID"].ToString());
                    }
                    foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                    {
                        this.EstTypeFromSP = dataRow["EstimateType"].ToString();
                        empty = dataRow["EstimateType"].ToString();
                    }
                    EstimatesBasePage.PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(this.CompanyID, estimateBookletItemID, empty, "W");
                    if (this.InvoiceID <= (long)0)
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "W", flag, parentEstimateItemID);
                    }
                    else
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "W", flag, parentEstimateItemID);
                    }
                    if (this.jobID > (long)0)
                    {
                        long estimateItemID = this.EstimateItemID;
                        long num = this.jobID;
                        commonClass _commonClass = this.objJava;
                        DateTime now = DateTime.Now;
                        JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                    }
                    if (this.InvoiceID > (long)0)
                    {
                        InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                    }
                    int num1 = 0;
                    if (base.Session["AccountCodeID"] != null)
                    {
                        num1 = Convert.ToInt32(base.Session["AccountCodeID"].ToString());
                    }
                    EstimatesBasePage.Estimate_Item_AccountCode_Insert(this.EstimateItemID, num1);
                    if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
                    {
                        estimateBookletItemID = this.EstimateBookletItemID;
                        this.WarehouseItem_Insert(this.EstimateItemID, estimateBookletItemID, this.EstTypeFromSP);
                    }
                    else
                    {
                        this.WarehouseItem_Insert(this.EstimateItemID, this.ParentEstimateItemID, this.EstTypeFromSP);
                    }
                    //Add inventory as a sub item
                    /*HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));*/
                    //existing code
                    //HttpResponse response = base.Response;
                    //object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_item_description.aspx?type=add&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&maintype=add", this.jID, this.InvID };
                    //response.Redirect(string.Concat(estimateID));
                }
                else
                {
                    long parentEstimateItemID1 = (long)0;
                    bool flag1 = false;
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        flag1 = false;
                        parentEstimateItemID1 = this.ParentEstimateItemID;
                    }
                    else
                    {
                        flag1 = true;
                        parentEstimateItemID1 = (long)0;
                    }
                    if (this.InvoiceID <= (long)0)
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "W", flag1, parentEstimateItemID1);
                    }
                    else
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "W", flag1, parentEstimateItemID1);
                    }
                    EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                    if (this.jobID > (long)0)
                    {
                        long estimateItemID1 = this.EstimateItemID;
                        long num2 = this.jobID;
                        commonClass _commonClass1 = this.objJava;
                        DateTime dateTime = DateTime.Now;
                        JobBasePage.EstimateItems_ProgressToJob(estimateItemID1, num2, false, Convert.ToDateTime(_commonClass1.Eprint_return_ActualDate_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true)));
                    }
                    if (this.InvoiceID > (long)0)
                    {
                        InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                    }
                    this.WarehouseItem_Insert(this.EstimateItemID, (long)0, "");
                }
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (string.Compare(this.QueryType, "add", true) == 0 || this.frmcopyitem == "yes")
            {
                if (this.ParentEstimateItemID == (long)0)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "W", false);
                }
                if (this.ParentEstimateItemID == (long)0 && (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0))
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "W");
                    string str = string.Empty;
                    foreach (DataRow row1 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        str = row1["StatusID"].ToString();
                    }
                    if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                    {
                        this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str), "job", this.EstimateItemID, (long)0);
                    }
                    this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    }
                    else if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i" || this.hdn_invStockReduce.Value.ToLower() == "yes")
                    {
                        this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    }
                    else if (string.Compare(this.modulename, "jobs", true) == 0 && this.ReduceStockType.ToString() == str.ToString())
                    {
                        this.summryCls.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    }
                }
                if (this.modulename == "jobs")
                {
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                    {
                        empty1 = dataRow1["PhraseText"].ToString();
                    }
                    foreach (DataRow row2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                    {
                        str1 = row2["PhraseText"].ToString();
                    }
                    EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty1, str1);
                }
            }
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "W", false);
                }
                if (this.IsProductCreated == 1)
                {
                    int num3 = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num3 = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num3 = 2;
                    }
                    DataTable dataTable1 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "W");
                    if (dataTable1.Rows.Count > 0)
                    {
                        dataTable1.Rows[0]["PricecatalogueID"].ToString();
                        if (num3 == 1 || num3 == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable1.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "W", num3);
                        }
                    }
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "W");
                    if (this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice")
                    {
                        this.summryCls.isrerun = true;
                        this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                        if (this.ReduceStockType.ToLower() == "e")
                        {
                            this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                        }
                        if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i")
                        {
                            this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                        }
                    }
                }
            }
            if (this.QueryType == "add" && this.ParentEstimateItemID == (long)0 && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "W") > (long)0)
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&parentesttype=W&maintype=edit&subitem=s", this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
            }
            string empty2 = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.modulename == "orders")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            if (empty2.ToLower() == "yes")
            {
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            HttpResponse response2 = base.Response;
            object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            response2.Redirect(string.Concat(estimateID2));
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridViewInv.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
        }

        protected void OnItemDataBound_GridViewInv(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["Cost"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Cost"), " (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
                item["UnitPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                HiddenField hiddenField = gridDataItem.FindControl("hid_InventoryID") as HiddenField;
                HiddenField hiddenField1 = gridDataItem.FindControl("hid_UnitPrice") as HiddenField;
                HiddenField hiddenField2 = gridDataItem.FindControl("hid_cost") as HiddenField;
                decimal num = InventoryBasePage.inventory_getPackedIn_qty(this.CompanyID, Convert.ToInt32(hiddenField.Value));
                decimal num1 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", Convert.ToInt64(hiddenField.Value)));
                LinkButton linkButton = gridDataItem.FindControl("lbl_InventoryName_val") as LinkButton;
                AttributeCollection attributes = linkButton.Attributes;
                object[] objArray = new object[] { "javascript:return Call_Estimate_Func('", Convert.ToInt32(hiddenField.Value), "','", linkButton.Text, "','I','", hiddenField1.Value, "','", num, "','", num1, "')" };
                attributes.Add("onclick", string.Concat(objArray));
                AttributeCollection attributeCollection = (gridDataItem.FindControl("lbl_InventoryCode") as LinkButton).Attributes;
                object[] objArray1 = new object[] { "javascript:return Call_Estimate_Func('", Convert.ToInt32(hiddenField.Value), "','", linkButton.Text, "','I','", hiddenField1.Value, "','", num, "','", num1, "')" };
                attributeCollection.Add("onclick", string.Concat(objArray1));
                gridDataItem["Cost"].Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField2.Value), 0, "", false, false, true);
                gridDataItem["UnitPrice"].Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField1.Value), 0, "", false, false, true);
            }
            GridTableView masterTableView = this.GridViewInv.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("DivbtnAddNewRecord");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                htmlControl.Visible = false;
            }
            else
            {
                htmlControl.Visible = true;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridViewInv.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridViewInv.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
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

        protected void OnRowDataBound_GridViewInv(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                HiddenField hiddenField = (HiddenField)e.Row.FindControl("hid_InventoryID");
                HiddenField hiddenField1 = (HiddenField)e.Row.FindControl("hid_UnitPrice");
                decimal num = InventoryBasePage.inventory_getPackedIn_qty(this.CompanyID, Convert.ToInt32(hiddenField.Value));
                decimal num1 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", Convert.ToInt64(hiddenField.Value)));
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lbl_InventoryName_val");
                AttributeCollection attributes = linkButton.Attributes;
                object[] objArray = new object[] { "javascript:return Call_Estimate_Func('", Convert.ToInt32(hiddenField.Value), "','", linkButton.Text, "','I','", hiddenField1.Value, "','", num, "','", num1, "')" };
                attributes.Add("onclick", string.Concat(objArray));
                AttributeCollection attributeCollection = ((LinkButton)e.Row.FindControl("lbl_InventoryCode")).Attributes;
                object[] objArray1 = new object[] { "javascript:return Call_Estimate_Func('", Convert.ToInt32(hiddenField.Value), "','", linkButton.Text, "','I','", hiddenField1.Value, "','", num, "','", num1, "')" };
                attributeCollection.Add("onclick", string.Concat(objArray1));
                Label label = (Label)e.Row.FindControl("lbl_cost_val");
                label.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["Cost"].ToString()), 0, "", false, false, true);
                Label label1 = (Label)e.Row.FindControl("lbl_unit_val");
                label1.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["Unitprice"].ToString()), 0, "", false, false, true);
            }
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            int resultId = 0;
            string connectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString(); 
            string query = "SELECT ViewID FROM tb_CustomizeView WHERE CompanyID = @CompanyID AND PageName = @PageName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", Convert.ToInt16(this.Session["CompanyID"]));
                    command.Parameters.AddWithValue("@PageName", "InventorySelectView");

                    connection.Open();
                    object result = command.ExecuteScalar();
                    resultId = Convert.ToInt32(result);
                }
            }
            HttpResponse response = base.Response;
            object[] value = new object[] { "../estimates/customviewinventory.aspx?type=edit&id=", resultId, "&cid=", Convert.ToInt16(this.Session["CompanyID"]) };
            response.Redirect(string.Concat(value));
        }

        private string GetColumnNamesFromDatabase()
        {
            string columnNames = string.Empty;

            string connectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            string query = "SELECT ColumnNames FROM tb_CustomizeView WHERE CompanyID = @CompanyID AND PageName = @PageName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", Convert.ToInt16(this.Session["CompanyID"]));
                    command.Parameters.AddWithValue("@PageName", "InventorySelectView");

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        columnNames = result.ToString();
                    }
                }
            }

            return columnNames;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "estimate";
            global.pgName = "";
            this.gloobj.setpagename("estimate");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (!base.IsPostBack)
            {
                this.GridViewInv.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Name");
                this.GridViewInv.Columns[3].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Cost"), this.commclass.GetCurrencyinRequiredFormate("", true));
                this.GridViewInv.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Supplier_Name");
                this.GridViewInv.Columns[5].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Unit_Price"), this.commclass.GetCurrencyinRequiredFormate("", true));
                this.GridViewInv.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Description");
                this.btnprevious.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.Button3.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.Label135.Text = this.objLanguage.GetLanguageConversion("Quantity_Require");
                this.img_UpdateDEscription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
                this.Button6.Text = this.objLanguage.GetLanguageConversion("Add");
                //string columnNames = GetColumnNamesFromDatabase();
                //string[] visibleColumns = columnNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Set the visibility of each column in the RadGrid based on the presence in the visibleColumns array
                //foreach (GridColumn column in GridViewInv.MasterTableView.Columns)
               // {
                 //   column.Visible = visibleColumns.Contains(column.UniqueName);
                //}

            }
            this.gloobj.setpagename("estimate");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["EstID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.QueryString["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["EstItemID"].ToString());
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            global.pgName = string.Empty;
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.tabtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx"))
            {
                this.tabtype = "estimate";
            }
            else
            {
                this.tabtype = "invoice";
            }
            if (base.Request.QueryString["esttype"] != null)
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                this.Select_Warehouse_Item();
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                this.modulename = "orders";
                this.submodulename = "order";
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
            {
                this.IsProductCreated = Convert.ToInt16(row["IsProductCreated"].ToString());
            }
            if (this.QueryType.ToString() == "edit")
            {
                if (!base.IsPostBack)
                {
                    this.Div_ItemDescn.Visible = true;
                    foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (dataRow["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_ItemDescn.Checked = false;
                        }
                        else
                        {
                            this.Chk_ItemDescn.Checked = true;
                        }
                    }
                }
                if (this.IsProductCreated == 1)
                {
                    this.Div_Productcatalogue.Visible = true;
                }
            }
            if (!base.IsPostBack)
            {
                warehouse_listNew.WhereCondition = "";
                warehouse_listNew.WhereConditionstore = "";
                warehouse_listNew.WhereConditionItem = "";
                base.Session["searchInv"] = null;
                base.Session["searchStore"] = null;
                base.Session["searchItem"] = this.defaultviewid;
                if (this.defaultsortedby == "")
                {
                    warehouse_listNew.SortedBy = "InventoryCode";
                    warehouse_listNew.SortedBystore = "ProductCode";
                    warehouse_listNew.SortedByItem = "ProductCode";
                }
                else
                {
                    warehouse_listNew.SortedBy = this.defaultsortedby;
                    warehouse_listNew.SortedBystore = this.defaultsortedby;
                    warehouse_listNew.SortedByItem = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    warehouse_listNew.sortdirection = "Desc";
                    warehouse_listNew.sortdirectionstore = "Desc";
                    warehouse_listNew.sortdirectionItem = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    warehouse_listNew.sortdirection = this.defaultsortdirection;
                    warehouse_listNew.sortdirectionstore = this.defaultsortdirection;
                    warehouse_listNew.sortdirectionItem = this.defaultsortdirection;
                }
                this.GridStateLoad();
            }
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    this.ParentEstimateType = base.Request.Params["parentesttype"].ToString();
                }
                if (base.Request.QueryString["sectionid"] != null)
                {
                    this.EstimateBookletItemID = Convert.ToInt64(base.Request.QueryString["sectionid"]);
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "Y";
                    this.Div_ItemDescn.Visible = false;
                }
                if (base.Request.QueryString["frm"] != null || base.Request.QueryString["frm"] == "yes")
                {
                    this.btnprevious.Visible = true;
                }
            }
            catch
            {
                this.subedit = "0";
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
        }

        private void Select_Warehouse_Item()
        {
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            if (!base.IsPostBack)
            {
                foreach (DataRow row in EstimateBasePage.Estimate_Warehouse_Item_Select_By_EstimateItemID(this.CompanyID, this.EstimateItemID).Rows)
                {
                    row["ItemTitle"].ToString();
                    row["ItemDescription"].ToString();
                    empty1 = row["WarehouseType"].ToString();
                    str1 = row["WarehouseTypeID"].ToString();
                    empty2 = row["Quantity"].ToString();
                    this.oldQuantity = row["Quantity"].ToString();
                    str2 = row["WareName"].ToString();
                    empty3 = row["UnitPrice"].ToString();
                    empty4 = row["PackedInQty"].ToString();
                    row["Tax"].ToString();
                    row["TaxID"].ToString();
                    str5 = row["EstWarehouseItemID"].ToString();
                    this.oldWareItemID = row["EstWarehouseItemID"].ToString();
                    str3 = string.Concat(str3, "WarehouseType»", empty1);
                    str3 = string.Concat(str3, "±WarehouseTypeID»", str1);
                    str3 = string.Concat(str3, "±Quantity»", empty2);
                    str3 = string.Concat(str3, "±WarehouseName»", str2);
                    str3 = string.Concat(str3, "±UnitPrice»", empty3);
                    str3 = string.Concat(str3, "±PackedInQty»", empty4);
                    str3 = string.Concat(str3, "±WarehouseItemID»", str5);
                    str3 = string.Concat(str3, "µ");
                }
                this.hid_ware_data.Value = str3;
                this.pnlWarehouseOnly.Visible = true;
            }
        }

        public void SetDDLValue(DropDownList ddl, string value)
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

        private void usrPaging_OnPageChange(int PageNumber)
        {
            this.GridBindInv(this.CompanyID, this.UserID, this.PageSize, PageNumber, "suppliername", "desc", "false");
        }

        private void WarehouseItem_Insert(long EstimateItemID, long ParentItemID, string ParentitemType)
        {
            int InventoryNo = Convert.ToInt32(this.hid_InventoryNo.Value);
            double num=0;
            string markUp = EstimatesBasePage.Warehouse_Markup(this.CompanyID, InventoryNo);
            if(!string.IsNullOrEmpty(markUp))
            {
                num= Convert.ToDouble(markUp);
            }
            string[] strArrays = this.hid_warehouse_save.Value.Split(new char[] { 'µ' });
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                string empty = string.Empty;
                long num1 = (long)0;
                if (strArrays[i].Length > 0)
                {
                    stringBuilder.Append(" Insert into [TABLE_EstWarehouseItem] (EstimateItemID,WarehouseType,WarehouseTypeID,Quantity,Quantity2,Quantity3,Quantity4,ItemTitle,UnitPrice,");
                    stringBuilder.Append(" Design,Delivery,Finishing,Notes,CreatedBy,ItemDescription,Markup,PackedInQty,ParentItemID,ParentItemType)");
                    stringBuilder.Append(string.Concat(" Values (", EstimateItemID, ","));
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        if (strArrays1[j].Length > 0)
                        {
                            if (strArrays2[0].Trim() == "WarehouseType")
                            {
                                stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                                empty = strArrays2[1].Trim();
                            }
                            else if (strArrays2[0].Trim() == "WarehouseID")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                num1 = Convert.ToInt64(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "Quantity")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                            }

                            else if (strArrays2[0].Trim() == "Quantity2")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                            }
                            else if (strArrays2[0].Trim() == "Quantity3")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                            }
                            else if (strArrays2[0].Trim() == "Quantity4")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                            }

                            else if (strArrays2[0].Trim() == "WarehouseName")
                            {
                                stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                            }
                            else if (strArrays2[0].Trim() == "UnitPrice")
                            {
                                stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                string str = "";
                                decimal num2 = Convert.ToDecimal(EstimatesBasePage.warehouse_perquantity_select(this.CompanyID, empty, num1));
                                stringBuilder.Append("' ',");
                                stringBuilder.Append("' ',");
                                stringBuilder.Append("' ',");
                                stringBuilder.Append("' ',");
                                stringBuilder.Append(string.Concat(base.Session["UserID"].ToString(), ", "));
                                object[] objArray = new object[] { "'", str, "',", num, "," };
                                stringBuilder.Append(string.Concat(objArray));
                                object[] parentItemID = new object[] { num2, ",", ParentItemID, ",'", ParentitemType, "');" };
                                stringBuilder.Append(string.Concat(parentItemID));
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                EstimatesBasePage.Estimate_Warehouse_Insert(this.CompanyID, stringBuilder.ToString(), EstimateItemID);
            }
        }

        private void WarehouseItem_Update(long EstimateItemID, long ParentEstimateItemID, string ParentEstimateType)
        {
            //Ticket 80178
            int InventoryNo = Convert.ToInt32(this.hid_InventoryNo.Value);
            double num = Convert.ToDouble(EstimatesBasePage.Warehouse_Markup(this.CompanyID, InventoryNo));
            string[] strArrays = this.hid_warehouse_save.Value.Split(new char[] { 'µ' });
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            long num1 = (long)0;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            long num4 = (long)0;
            decimal num5 = new decimal(0);
            int num6 = 0;

            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);

            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = new DataTable();
            dataTable = EstimateBasePage.job_card_info_select_by_estimateid(this.CompanyID, this.EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                empty1 = row["JobNumber"].ToString();
                str1 = row["InvoiceNumber"].ToString();
            }
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                if (strArrays[i].Length > 0)
                {
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        if (strArrays1[j].Length > 0)
                        {
                            if (strArrays2[0].Trim() == "WarehouseName")
                            {
                                strArrays2[1].Trim();
                            }
                            if (strArrays2[0].Trim() == "WarehouseType")
                            {
                                str = strArrays2[1].Trim();
                            }
                            else if (strArrays2[0].Trim() == "WarehouseID")
                            {
                                num1 = Convert.ToInt64(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "Quantity")
                            {
                                num2 = Convert.ToDecimal(strArrays2[1].Trim());
                            }

                            else if (strArrays2[0].Trim() == "UnitPrice")
                            {
                                num3 = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "PackedInQty")
                            {
                                num5 = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "WarehouseItemID")
                            {
                                num4 = Convert.ToInt64(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "IsDeleted" && !string.IsNullOrEmpty(strArrays2[1].Trim()))
                            {
                                num6 = Convert.ToInt32(strArrays2[1].Trim());
                            }

                            else if (strArrays2[0].Trim() == "Quantity2")
                            {
                                num11 = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "Quantity3")
                            {
                                num12 = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                            else if (strArrays2[0].Trim() == "Quantity4")
                            {
                                num13 = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                        }
                    }
                }
                stringBuilder.Append(string.Concat("IF ", num4, " != '0'"));
                stringBuilder.Append("BEGIN");
                stringBuilder.Append(" Update [TABLE_EstWarehouseItem] SET ");
                stringBuilder.Append(string.Concat("EstimateItemID = ", EstimateItemID, ","));
                stringBuilder.Append(string.Concat("WarehouseType = '", str, "',"));
                stringBuilder.Append(string.Concat("WarehouseTypeID = ", num1, ","));
                stringBuilder.Append(string.Concat("Quantity = ", num2, ","));

                stringBuilder.Append(string.Concat("Quantity2 = ", num11, ","));
                stringBuilder.Append(string.Concat("Quantity3 = ", num12, ","));
                stringBuilder.Append(string.Concat("Quantity4 = ", num13, ","));


                stringBuilder.Append(string.Concat("UnitPrice = ", num3, ","));
                stringBuilder.Append(string.Concat("PackedInQty = ", num5, ","));
                stringBuilder.Append(string.Concat("IsDeleted = ", num6, ","));
                stringBuilder.Append("Design = ' ',");
                stringBuilder.Append("Delivery = ' ',");
                stringBuilder.Append("Finishing = ' ',");
                stringBuilder.Append("Notes = ' ',");
                stringBuilder.Append(string.Concat("ModifiedBy = ", base.Session["UserID"].ToString(), ", "));
                stringBuilder.Append(string.Concat("ModifiedDate = '", DateTime.Now, "' "));
                stringBuilder.Append(string.Concat("where EstWarehouseItemID = ", num4, ";"));
                stringBuilder.Append("END ");
                stringBuilder.Append("ELSE ");
                stringBuilder.Append("BEGIN ");
                stringBuilder.Append(" Insert into [TABLE_EstWarehouseItem] (EstimateItemID,WarehouseType,WarehouseTypeID,Quantity,UnitPrice,");
                stringBuilder.Append(" ItemTitle,Design,Delivery,Finishing,Notes,CreatedBy,ItemDescription,Markup,PackedInQty,ParentItemID,ParentItemType,Quantity2,Quantity3,Quantity4)");
                stringBuilder.Append(string.Concat(" Values (", EstimateItemID, ","));
                stringBuilder.Append(string.Concat("'", str, "',"));
                stringBuilder.Append(string.Concat("'", num1, "',"));
                stringBuilder.Append(string.Concat(num2, ","));
                stringBuilder.Append(string.Concat(num3, ","));
                string str2 = "";
                stringBuilder.Append("' ',");
                stringBuilder.Append("' ',");
                stringBuilder.Append("' ',");
                stringBuilder.Append("' ',");
                stringBuilder.Append("' ',");
                stringBuilder.Append(string.Concat(base.Session["UserID"].ToString(), ", "));
                object[] parentEstimateItemID = new object[] { "'", str2, "',", num, ",", num5, ",", ParentEstimateItemID, ",'", ParentEstimateType, "','", num11, "','", num12, "','", num13, "'); " };
                stringBuilder.Append(string.Concat(parentEstimateItemID));
                stringBuilder.Append("END ");
                if (this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice")
                {
                    string empty2 = string.Empty;
                    if (this.modulename.ToLower() == "jobs")
                    {
                        empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
                    }
                    else if (this.modulename.ToLower() == "invoice")
                    {
                        empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
                    }
                    if (this.ReduceStockTypeForCancelled.ToLower() == "a")
                    {
                        if (num6 == 1)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(num1), "I", Convert.ToInt32(num2), "cancelled", EstimateItemID);
                            if (this.modulename.ToLower() == "jobs")
                            {
                                if (empty2.ToLower() != "yes")
                                {
                                    commonClass _commonClass = this.commclass;
                                    long num7 = Convert.ToInt64(num1);
                                    object[] estimateID = new object[] { "Stock Restored due to deletion of item: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='_blank' >", empty1, "</a>" };
                                    _commonClass.Insert_Activity_History_For_Inventory(num7, string.Concat(estimateID), this.UserID, Convert.ToInt32(num2), "r", new decimal(0));
                                }
                                else
                                {
                                    commonClass _commonClass1 = this.commclass;
                                    long num8 = Convert.ToInt64(num1);
                                    object[] objArray = new object[] { "Stock Restored due to deletion of item: <a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "' target='_blank' >", empty1, "</a>" };
                                    _commonClass1.Insert_Activity_History_For_Inventory(num8, string.Concat(objArray), this.UserID, Convert.ToInt32(num2), "r", new decimal(0));
                                }
                            }
                            if (this.modulename.ToLower() == "invoice")
                            {
                                if (empty2.ToLower() != "yes")
                                {
                                    commonClass _commonClass2 = this.commclass;
                                    long num9 = Convert.ToInt64(num1);
                                    object[] estimateID1 = new object[] { "Stock Restored due to deletion of item: <a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' target='_blank' >", str1, "</a>" };
                                    _commonClass2.Insert_Activity_History_For_Inventory(num9, string.Concat(estimateID1), this.UserID, Convert.ToInt32(num2), "r", new decimal(0));
                                }
                                else
                                {
                                    commonClass _commonClass3 = this.commclass;
                                    long num10 = Convert.ToInt64(num1);
                                    object[] objArray1 = new object[] { "Stock Restored due to deletion of item: <a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", this.EstimateID, "' target='_blank' >", str1, "</a>" };
                                    _commonClass3.Insert_Activity_History_For_Inventory(num10, string.Concat(objArray1), this.UserID, Convert.ToInt32(num2), "r", new decimal(0));
                                }
                            }
                        }
                    }
                    else if (this.ReduceStockTypeForCancelled.ToLower() == "p" && this.hdnStockReduce.Value.ToLower() == "yes")
                    {
                        this.summryCls.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, EstimateItemID, this.UserID);
                    }
                }
            }
            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                stringBuilder.Append(" declare @NewEstWareItem bigint ");
                stringBuilder.Append(string.Concat(" set @NewEstWareItem = (select top 1 EstWarehouseItemID from tb_EstWarehouseItem where EstimateItemID=", EstimateItemID, " order by EstWarehouseItemID desc) "));
                object[] estimateItemID = new object[] { " update tb_EstWarehouseItem set ItemDescription=(select top 1 ItemDescription from ( select top 2 ItemDescription,EstWarehouseItemID from tb_EstWarehouseItem where EstimateItemID=", EstimateItemID, " order by EstWarehouseItemID desc) as a order by EstWarehouseItemID) where EstWarehouseItemID=@NewEstWareItem and EstimateItemID=", EstimateItemID };
                stringBuilder.Append(string.Concat(estimateItemID));
                stringBuilder.Append(string.Concat(" update tb_EstWarehouseItem set Isdeleted=1 where EstimateItemID=", EstimateItemID, " and EstWarehouseItemID not in (@NewEstWareItem) "));
                EstimatesBasePage.Estimate_Warehouse_Insert(this.CompanyID, stringBuilder.ToString(), EstimateItemID);
            }
            EstimateCommonMethods.PCR_FormulaTags_Replace(EstimateItemID, "W");
        }
    }
}