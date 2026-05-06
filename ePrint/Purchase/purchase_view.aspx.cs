using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using ePrint.Delivery;
using System.Linq;

namespace ePrint.Purchases
{
    public partial class purchase_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected UpdateProgress upProgress;

        //protected usercontrol_settings_loading_ascx ucLoading;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkPurchaseedit;

        //protected LinkButton btnclrFilters;

        //protected Label lblView;

        //protected RadListBox RadListBox1;

        //protected Panel pnlActionMenu;

        //protected Label lblArchive;

        //protected Label lblDelete;

        //protected HtmlGenericControl DivdivDropdownlist;

        //protected Label lblCreateNewPO;

        //protected RadGrid GridViewpurchase;

        //protected LinkButton lnkPODelete;

        //protected LinkButton lnkPOArchive;

        //protected LinkButton lnkPOCopy;

        //protected HiddenField hidGridCount;

        //protected HiddenField hidDeletePO;

        //protected HiddenField hdnStatus;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hdnSelectedChkfrmGrid;

        //protected UpdatePanel updtehidnfield;

        //protected Label StatusChangeNote;

        //protected Button btnYes;

        //protected Button btnNo;

        //protected RadWindow DeliveryStatus;

        //protected RadWindowManager Radwinmanagercatalogue;

        //protected Label lbl_POCopyMsg;

        //protected Button POCopy_btnyes;

        //protected Button POCopy_btnno;

        protected RadWindow Radwin_POCopy = new RadWindow();

        //protected RadWindowManager Radwinmanager_POCopy_Confirmation;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField editPurchaseViewID;

        protected HiddenField hdnPOCopyValue = new HiddenField();

        //protected HiddenField hdnIDs;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass cmnClass = new commonClass();

        public languageClass objLangClass = new languageClass();

        private createViewClass objCreateView = new createViewClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath;

        public int totalrec;

        public int CompanyID;

        public int UserID;

        private string para = "";

        public string newdate = string.Empty;

        public int defaultviewid;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public DataTable dt = new DataTable();

        private string pg = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string cellvalue_deliverydate = string.Empty;

        public string cellvalue_podate = string.Empty;

        public string cellvalue_poprice = string.Empty;

        public string cellvalue_goodsreceived = string.Empty;

        public string cellvalue_Comments = string.Empty;

        public string cellvalue_Description = string.Empty;

        public string cellvalue_Jobtitle = string.Empty;
        public string cellvalue_JobStatus = string.Empty;
        public string cellvalue_SupplierQuoteNumber = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;


        public string cellvalue_PurValExcGst = string.Empty;

        public string flag_PurValExcGst = string.Empty;

        public string flag_createddate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string flag_podate = string.Empty;

        public string flag_poprice = string.Empty;

        public string flag_goodsreceived = string.Empty;

        public string flag_Comments = string.Empty;

        public string flag_Description = string.Empty;

        public string flag_Jobtitle = string.Empty;
        public string flag_JobStatus = string.Empty;

        public string flag_SupplierQuoteNumber = string.Empty;

        public string cellvalue_suppliername = string.Empty;

        public string flag_suppliername = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_pono = string.Empty;

        public string flag_pono = string.Empty;

        public string flag_jobnumber = string.Empty;

        public string cellvalue_jobnumber = string.Empty;

        public string flag_estimatenumber = string.Empty;

        public string cellvalue_estimatenumber = string.Empty;

        public string flag_notes = string.Empty;

        public string flag_deliveryto = string.Empty;

        public string cellvalue_notes = string.Empty;

        public string cellvalue_deliveryto = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        public long New_PurchaseID;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public static int PageSize;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long PurchaseStatusID;

        public string ServerName = string.Empty;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public int ViewID;

        public string Archive_Row_Selection_Alert = string.Empty;

        public string Delete_Row_Selection_Alert = string.Empty;

        public string UnArchive_Row_Selection_Alert = string.Empty;
        //public bool IsGrouping;

        public string flag_DefaultTemplate = string.Empty;

        public string cellvalue_DefaultTemplate = string.Empty;

        public string flag_ChooseTemplate = string.Empty;

        public string cellvalue_ChooseTemplate = string.Empty;

        public string flag_DownloadTemplate = string.Empty;

        public string cellvalue_DownloadTemplate = string.Empty;
        public string flag_Archive = string.Empty;

        public string cellvalue_Archive = string.Empty;

        public string flag_CustomDate1 = string.Empty;

        public string cellvalue_CustomDate1 = string.Empty;

        public string flag_CustomDate2 = string.Empty;

        public string cellvalue_CustomDate2 = string.Empty;

        public string flag_CustomDate3 = string.Empty;

        public string cellvalue_CustomDate3 = string.Empty;

        public string flag_CustomDate4 = string.Empty;

        public string cellvalue_CustomDate4 = string.Empty;

        public string flag_CustomDate5 = string.Empty;

        public string cellvalue_CustomDate5 = string.Empty;
        public string customDatetitle1 = string.Empty;
        public string customDatetitle2 = string.Empty;
        public string customDatetitle3 = string.Empty;
        public string customDatetitle4 = string.Empty;
        public string customDatetitle5 = string.Empty;


        //public string GroupByColumn = string.Empty;
        public string FilterDateType = string.Empty;
        public string FilterDateRange = string.Empty;

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

        static purchase_view()
        {
            purchase_view.WhereCondition = string.Empty;
            purchase_view.sortdirection = string.Empty;
            purchase_view.SortedBy = string.Empty;
            purchase_view.PageSize = 50;
        }

        public purchase_view()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewpurchase.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "podate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    else if (dt.Columns[i].ColumnName.ToLower() == "estimatevalue_excgst" || dt.Columns[i].ColumnName.ToLower() == "poprice")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Int32");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    //else if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    //{
                    //   this.GridViewpurchase.MasterTableView.Columns.Remove(gridBoundColumn);

                    //  GridTemplateColumn commentColumn = new GridTemplateColumn();
                    //  commentColumn.UniqueName = dt.Columns[i].ColumnName;
                    //  commentColumn.HeaderText = "Comments";
                    //  commentColumn.ItemTemplate = new CommentsTemplate();
                    //  gv.MasterTableView.Columns.Add(commentColumn);
                    //}
                }
                for (int j = 1; j < this.GridViewpurchase.Columns.Count; j++)
                {
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewpurchase.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "pono")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("PO_No"), ".");
                        this.flag_pono = "true";
                        this.cellvalue_pono = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "goodsreceived")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Goods_Received");
                        this.flag_goodsreceived = "true";
                        this.cellvalue_goodsreceived = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "suppliername")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Supplier_Name");
                        this.GridViewpurchase.Columns[j].ItemStyle.Width = Unit.Pixel(220);
                        this.GridViewpurchase.Columns[j].ItemStyle.Wrap = false;
                        this.flag_suppliername = "true";
                        this.cellvalue_suppliername = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "status")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Status");
                        this.GridViewpurchase.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Created_On");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "podate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("PO_Date");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_podate = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_podate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customdate1")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate1 = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate1 = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customdate2")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate2 = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate2 = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customdate3")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate3 = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate3 = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customdate4")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate4 = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate4 = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customdate5")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate5 = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate5 = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "poprice")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("PO_Price"), " (", this.cmnClass.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_poprice = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_poprice = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "jobtitle")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title");
                        this.cellvalue_Jobtitle = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Jobtitle = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "jobstatus")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Status");
                        this.cellvalue_JobStatus = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_JobStatus = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "supplierquotenumber")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Supplier_Quote_Number");
                        this.cellvalue_SupplierQuoteNumber = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_SupplierQuoteNumber = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "description")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Description");
                        this.cellvalue_Description = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Description = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Comments");
                        this.cellvalue_Comments = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Comments = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Default Template";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Choose Template";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ChooseTemplate = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Download Default Template";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DownloadTemplate = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Archive";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }



                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridViewpurchase.Columns[j].Visible = false;
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Purchase_Value_Exc_Tax"), " (", this.cmnClass.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_PurValExcGst = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_PurValExcGst = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customername")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Name");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridViewpurchase.Columns[j].Visible = false;
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Payment_Terms");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "jobnumber")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Number");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Estimate_Number_Order_Number");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_estimatenumber = "true";
                        this.cellvalue_estimatenumber = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "notes")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Notes");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.GridViewpurchase.Columns[j].ItemStyle.Width = Unit.Pixel(220);
                        this.flag_notes = "true";
                        this.cellvalue_notes = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "reqdate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Delivery Date";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_deliverydate = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_deliverydate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Status Days";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceStatusUpdate = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_SinceStatusUpdate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Email Days";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceEmailed = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                        this.flag_SinceEmailed = "true";
                    }

                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "deliveryaddress")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = "Delivery To";
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.GridViewpurchase.Columns[j].ItemStyle.Width = Unit.Pixel(220);
                        this.flag_deliveryto = "true";
                        this.cellvalue_deliveryto = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                }

            }

            for (int j = 0; j < this.GridViewpurchase.Columns.Count; j++)
            {


                if (this.GridViewpurchase.Columns[j].UniqueName.ToLower() == "defaulttemplate")
                {
                    this.GridViewpurchase.Columns[j].HeaderText = "Default Template";
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DefaultTemplate = this.GridViewpurchase.Columns[j].UniqueName.ToLower();
                    this.flag_DefaultTemplate = "true";
                }

                else if (this.GridViewpurchase.Columns[j].UniqueName.ToLower() == "choosetemplate")
                {
                    this.GridViewpurchase.Columns[j].HeaderText = "Choose Template";
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_ChooseTemplate = this.GridViewpurchase.Columns[j].UniqueName.ToLower();
                    this.flag_ChooseTemplate = "true";
                }

                else if (this.GridViewpurchase.Columns[j].UniqueName.ToLower() == "downloadtemplate")
                {
                    this.GridViewpurchase.Columns[j].HeaderText = "Download Default Template";
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DownloadTemplate = this.GridViewpurchase.Columns[j].UniqueName.ToLower();
                    this.flag_DownloadTemplate = "true";
                }
                else if (this.GridViewpurchase.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridViewpurchase.Columns[j].HeaderText = "Archive";
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    this.flag_Archive = "true";
                }
            }


            for (int i = 0; i < gv.MasterTableView.Columns.Count; i++)
                {
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "defaulttemplate")
                    {
                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "defaulttemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "previewpdf.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "choosetemplate")
                    {
                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "choosetemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "template-select.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "downloadtemplate")
                    {

                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "downloadtemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "download-pdf.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "archive")
                    {

                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "archive";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "archive.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
            }



            
        }

        public class ImageTemplate : ITemplate
        {
            private string _imageUrl;

            public ImageTemplate(string imageUrl)
            {
                _imageUrl = imageUrl;
            }

            public void InstantiateIn(Control container)
            {
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                {
                    ImageUrl = _imageUrl,
                    AlternateText = "",
                    Width = Unit.Pixel(16),
                    Height = Unit.Pixel(16)
                };
                container.Controls.Add(img);
            }
        }

        public class CommentsTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                HyperLink hlEditComment = new HyperLink();
                hlEditComment.DataBinding += (s, e) =>
                {
                    GridDataItem item = (GridDataItem)container.NamingContainer;
                    hlEditComment.Text = DataBinder.Eval(item.DataItem, "Comments").ToString();
                    string purchaseId = DataBinder.Eval(item.DataItem, "PurchaseID").ToString();
                    hlEditComment.Attributes["onclick"] = $"openCommentPopup('{purchaseId}', '{hlEditComment.Text}'); return false;";
                };
                container.Controls.Add(hlEditComment);
            }
        }
        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string newComment = hiddenCommentText.Value;
            int commentId = int.Parse(hiddenCommentId.Value);

            UpdateCommentInDatabase(commentId, newComment);

            GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, this.GridViewpurchase.CurrentPageIndex + 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, this.para);
            this.GridViewpurchase.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "Purchase/purchase_view.aspx"));
        }


        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            PurchaseBasePage.Purchase_Comments_Update(commentId , newComment);
        }

        public void bindRadlistStatus()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "purchase");
            this.RadListBox1.DataSource = dataTable;
            this.RadListBox1.DataTextField = "StatusTitle";
            this.RadListBox1.DataValueField = "StatusID";
            this.RadListBox1.DataBind();
        }

        public void btnEditViewPurchase_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../purchase/customviewpurchase.aspx?type=edit&id=", this.editPurchaseViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        protected void btnYes_Onclick(object sender, EventArgs e)
        {
            this.hdnStatus.Value = "true";
            this.RadListBox1_SelectedIndexChanged(sender, e);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:RadWinClose1();", true);
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("purchase_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("purchase_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            purchase_view.WhereCondition = "";
            this.Session["search_pur"] = null;
            foreach (GridColumn column in this.GridViewpurchase.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridViewpurchase.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
            this.GridViewpurchase.MasterTableView.Rebind();
        }

        protected void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpCookie httpCookie = new HttpCookie("ckeEditviewID_purchase");
            httpCookie["Purchase_viewID"] = this.ddl_View.SelectedValue;
            base.Response.Cookies.Add(httpCookie);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "Purchase/purchase_view.aspx?viewid=", num1, "&index=", num };
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
            this.Session["search_pur"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && purchase_view.WhereCondition != "")
                {
                    purchase_view.WhereCondition = string.Concat(purchase_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "podate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.cmnClass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                {
                    str = dataRow["FilterText"].ToString().Trim();
                    object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                    empty = string.Concat(objArray);
                }
                else
                {
                    empty = dataRow["ColumnName"].ToString();
                    str = dataRow["FilterText"].ToString().Trim();
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                //if (<PrivateImplementationDetails>{E2BB33D1-29E3-43DC-BBB6-6593917DCB74}.$$method0x6000016-1 == null)
                //{
                //    <PrivateImplementationDetails>{E2BB33D1-29E3-43DC-BBB6-6593917DCB74}.$$method0x6000016-1 = new Dictionary<string, int>(10)
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
                //if (!<PrivateImplementationDetails>{E2BB33D1-29E3-43DC-BBB6-6593917DCB74}.$$method0x6000016-1.TryGetValue(str1, out num))
                //{
                //    continue;
                //}

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
                            string whereCondition = purchase_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            purchase_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = purchase_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            purchase_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {

                            if (dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = purchase_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string whereCondition2 = purchase_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " like '%", str, "%'" };
                                purchase_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                           
                        }
                    case 3:
                        {
                            string str2 = purchase_view.WhereCondition;
                            string[] strArrays3 = new string[] { str2, " ", empty, " not like '%", str, "%'" };
                            purchase_view.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition3 = purchase_view.WhereCondition;
                                string[] strArrays4 = new string[] { whereCondition3, " ", empty, " =", str };
                                purchase_view.WhereCondition = string.Concat(strArrays4);
                                continue;
                            }
                            else
                            {
                                string str3 = purchase_view.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition4 = purchase_view.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " != ", str };
                                purchase_view.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                            else
                            {
                                string str4 = purchase_view.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " != '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition5 = purchase_view.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " > ", str };
                                purchase_view.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                            else
                            {
                                string str5 = purchase_view.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " > '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition6 = purchase_view.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " >= ", str };
                                purchase_view.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                            else
                            {
                                string str6 = purchase_view.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " >= '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition7 = purchase_view.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " < ", str };
                                purchase_view.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                            else
                            {
                                string str7 = purchase_view.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " < '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "poprice" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                            {
                                string whereCondition8 = purchase_view.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " <= ", str };
                                purchase_view.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                            else
                            {
                                string str8 = purchase_view.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " <= '", str, "'" };
                                purchase_view.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return purchase_view.WhereCondition;
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

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para);
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
                        row["CreatedDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("PODate"))
                    {
                        row["PODate"] = this.cmnClass.Eprint_return_Date_Before_View(row["PODate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate1"))
                    {
                        row["CustomDate1"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate2"))
                    {
                        row["CustomDate2"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate3"))
                    {
                        row["CustomDate3"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate4"))
                    {
                        row["CustomDate4"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate5"))
                    {
                        row["CustomDate5"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("SupplierName"))
                    {
                        row["SupplierName"] = base.SpecialDecode(row["SupplierName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Description"))
                    {
                        row["Description"] = base.SpecialDecode(row["Description"].ToString());
                    }
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = base.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("JobTitle"))
                    {
                        row["JobTitle"] = base.SpecialDecode(row["JobTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = base.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("Comments"))
                    {
                        row["Comments"] = base.SpecialDecode(row["Comments"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerName"))
                    {
                        row["CustomerName"] = base.SpecialDecode(row["CustomerName"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = base.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("estimatenumber"))
                    {
                        row["estimatenumber"] = base.SpecialDecode(row["estimatenumber"].ToString());
                    }
                    if (!row.Table.Columns.Contains("JobNumber"))
                    {
                        continue;
                    }
                    row["JobNumber"] = base.SpecialDecode(row["JobNumber"].ToString());
                }
            }
            _commonClass.closeConnection();
            this.GridViewpurchase.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewpurchase);
                this.div_Main.Style.Add("display", "block");
                this.GridViewpurchase.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridViewpurchase);
            this.div_Main.Style.Add("display", "block");
            this.GridViewpurchase.AllowCustomPaging = true;
            this.GridViewpurchase.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewpurchase, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewpurchase);
        }

        protected void GridViewpurchase_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewpurchase_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = base.SpecialEncode(item.Text);
                purchase_view.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "poprice" || commandArgument.Second.ToString().ToLower() == "estimatevalue_excgst"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Pls Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text.Trim();
                    }
                }
                if (this.Session["search_pur"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_pur"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_pur"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(second);
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                this.Session["search_pur"] = this.dtsearch;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                purchase_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
                this.GridViewpurchase.DataBind();
                //this.GridViewpurchase.Rebind();
            }
        }

        protected void GridViewpurchase_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewpurchase.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, this.GridViewpurchase.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
        }

        protected void GridViewpurchase_OnSorting(object sender, GridSortCommandEventArgs e)
        {
            purchase_view.SortedBy = e.SortExpression;
            purchase_view.sortdirection = e.NewSortOrder.ToString();
            if (purchase_view.sortdirection.ToLower() == "ascending")
            {
                purchase_view.sortdirection = "ASC";
                this.GridViewpurchase.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (purchase_view.sortdirection.ToLower() != "descending")
            {
                purchase_view.sortdirection = "ASC";
                this.GridViewpurchase.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                purchase_view.sortdirection = "DESC";
                this.GridViewpurchase.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridViewpurchase.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, this.GridViewpurchase.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, purchase_view.sortdirection, purchase_view.WhereCondition);
        }

        protected void lnkPOArchive_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidDeletePO.Value))
            {
                string[] strArrays = this.hidDeletePO.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i]))
                    {
                        PurchaseBasePage purchaseBasePage = new PurchaseBasePage();
                        purchaseBasePage.Purchase_Make_Archive(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
                base.Message_Display(this.objLangClass.GetLanguageConversion("Purchases_Archive_Successfully"), "successfulMsg", this.plhMessage);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
                this.GridViewpurchase.Rebind();
            }
        }

        protected void lnkPOCopy_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidDeletePO.Value))
            {
                long num = (long)0;
                string empty = string.Empty;
                string str = string.Empty;
                string[] strArrays = this.hidDeletePO.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i]))
                    {
                        num = Convert.ToInt64(strArrays[i]);
                        if (this.hdnPOCopyValue.Value == "yes")
                        {
                            this.New_PurchaseID = PurchaseBasePage.Purchase_Make_Copy(this.CompanyID, Convert.ToInt64(strArrays[i]), 1);
                        }
                        if (this.hdnPOCopyValue.Value == "no")
                        {
                            this.New_PurchaseID = PurchaseBasePage.Purchase_Make_Copy(this.CompanyID, Convert.ToInt64(strArrays[i]), 0);
                        }
                        DataTable dataTable = PurchaseBasePage.purchase_select(this.CompanyID, Convert.ToInt64(strArrays[i]));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            empty = row["PONO"].ToString();
                        }
                        DataTable dataTable1 = PurchaseBasePage.purchase_select(this.CompanyID, Convert.ToInt64(this.New_PurchaseID));
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            str = dataRow["PONO"].ToString();
                        }
                        this.objnotes.new_PO_number = str;
                        this.objnotes.ModuleName = "purchase";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POCopied);
                        this.objnotes.ModuleID = num;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass = this.cmnClass;
                        DateTime now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        this.objnotes.Po_number = empty;
                        this.objnotes.ModuleName = "purchase";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.PONewCopied);
                        this.objnotes.ModuleID = this.New_PurchaseID;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass1 = this.objnotes;
                        commonClass _commonClass1 = this.cmnClass;
                        DateTime dateTime = DateTime.Now;
                        _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                    }
                }
            }
            object[] languageConversion = new object[] { this.objLangClass.GetLanguageConversion("Purchase_Copied_Successfully"), ", <a href='../purchase/purchase_add.aspx?type=edit&id=", this.New_PurchaseID, "'>", this.objLangClass.GetLanguageConversion("Please_Click_Here_To_View"), "</a>" };
            base.Message_Display(string.Concat(languageConversion), "successfulMsg", this.plhMessage);
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
            this.GridViewpurchase.Rebind();
        }

        protected void lnkPODelete_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hidDeletePO.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (!string.IsNullOrEmpty(strArrays[i]))
                {
                    PurchaseBasePage.purchase_delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                }
            }
            base.Message_Display(this.objLangClass.GetLanguageConversion("Purchases_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, purchase_view.WhereCondition);
            this.GridViewpurchase.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridViewpurchase.FilterMenu;
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
            //foreach (GridItem item in GridViewpurchase.MasterTableView.Items)
            //{
            //    if (item is GridGroupHeaderItem groupHeader)
            //    {
            //        string text = groupHeader.DataCell.Text;

            //        int colonIndex = text.IndexOf(':');
            //        if (colonIndex > -1 && colonIndex + 1 < text.Length)
            //        {
            //            string justValue = text.Substring(colonIndex + 1).Trim(); // e.g., "08/04/2025"
            //            groupHeader.DataCell.Text = justValue;
            //        }
            //    }
            //}
        }

        protected void OnRowDataBound_GridViewpurchase(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < this.GridViewpurchase.Columns.Count; i++)
                {
                    if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "pono")
                    {
                        this.cellvalue_pono = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                        this.flag_pono = "true";
                    }
                    if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "podate")
                    {
                        this.flag_podate = "true";
                        this.cellvalue_podate = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "poprice")
                    {
                        this.flag_poprice = "true";
                        this.cellvalue_poprice = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "goodsreceived")
                    {
                        this.flag_goodsreceived = "true";
                        this.cellvalue_goodsreceived = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "jobtitle")
                    {
                        this.cellvalue_Jobtitle = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Jobtitle = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "description")
                    {
                        this.cellvalue_Description = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Description = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.cellvalue_Comments = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Comments = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.cellvalue_PurValExcGst = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_PurValExcGst = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.cellvalue_status = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_status = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_customername = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_customername = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.cellvalue_paymentterms = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_paymentterms = "true";
                    }

                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.cellvalue_ChooseTemplate = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.cellvalue_DownloadTemplate = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }



                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "suppliername")
                    {
                        this.cellvalue_suppliername = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_suppliername = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.cellvalue_jobnumber = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_jobnumber = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.cellvalue_estimatenumber = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_estimatenumber = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "notes")
                    {
                        this.cellvalue_notes = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_notes = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "reqdate")
                    {
                        this.cellvalue_deliverydate = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_deliverydate = "true";
                    }

                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.flag_SinceStatusUpdate = "true";
                        this.cellvalue_SinceStatusUpdate = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.flag_SinceEmailed = "true";
                        this.cellvalue_SinceEmailed = this.GridViewpurchase.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "deliveryaddress")
                    {
                        this.cellvalue_deliveryto = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_deliveryto = "true";
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str = string.Concat("purchase_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_Error");
                string empty = string.Empty;
                string empty1 = string.Empty;
                empty = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                if (Convert.ToInt16(item["ErrorCount"].Text) <= 0)
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                }
                if (item["EstItemCoun"].Text == "0")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                else
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", empty, "' title='", empty1, "' style='cursor:pointer;' class='viewicon_margin' />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                TableCell tableCell = item["PONo"];
                string[] str1 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["PONo"].Text, "</a>" };
                tableCell.Text = string.Concat(str1);
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_podate == "true")
                {
                    item[this.cellvalue_podate].Attributes.Add("align", "center");
                    item[this.cellvalue_podate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_podate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate1 == "true")
                {
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }
                if (this.flag_poprice == "true")
                {
                    item[this.cellvalue_poprice].Attributes.Add("align", "right");
                    item[this.cellvalue_poprice].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_poprice].Style.Add("cursor", "pointer");
                    item[this.cellvalue_poprice].Text = this.cmnClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_poprice].Text.ToString()), 0, "", false, false, true);
                }
                if (this.flag_PurValExcGst == "true")
                {
                    item[this.cellvalue_PurValExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_PurValExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_PurValExcGst].Style.Add("cursor", "pointer");
                    item[this.cellvalue_PurValExcGst].Text = this.cmnClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_PurValExcGst].Text.ToString()), 0, "", false, false, true);
                }
                if (this.flag_goodsreceived == "true")
                {
                    item[this.cellvalue_goodsreceived].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_goodsreceived].Style.Add("cursor", "pointer");
                    item[this.cellvalue_goodsreceived].ToolTip = item["goodsreceived"].Text;
                }



                if (this.flag_DefaultTemplate == "true")
                {
                    string estimateId = item["PurchaseID"].Text;
                    string customerid = item["custid"].Text;
                 
                    string targetUrl = $"{this.strSitepath}purchase/templates_view1.aspx?sectionid={customerid}&sectionname=Purchase&type=Supplier&page=Purchase&EstID={estimateId}&customtype=preview";


                    item[this.cellvalue_DefaultTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_DefaultTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_DefaultTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_DefaultTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_self", // Opens in new tab
                        ToolTip = "Click to display default PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = string.Concat(this.strImagepath, "previewpdf.png"),
                        AlternateText = "Preview",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_DefaultTemplate].Controls.Add(link);
                }

                if (this.flag_ChooseTemplate == "true") // Using flag_ChooseTemplate
                {
                    string estimateId = item["PurchaseID"].Text;
                    string customerid = item["custid"].Text;
                   
                    string targetUrl = $"{this.strSitepath}purchase/templates_view1.aspx?sectionid={customerid}&sectionname=Purchase&type=Supplier&page=Purchase&EstID={estimateId}&customtype=choosetemp";

                    item[this.cellvalue_ChooseTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_ChooseTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_ChooseTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_ChooseTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_self", // Opens in a new tab
                        ToolTip = "Click to choose PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}template-select.png",
                        AlternateText = "View Order",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_ChooseTemplate].Controls.Add(link);
                }

                if (this.flag_DownloadTemplate == "true") // Using flag_DownloadTemplate
                {
                    string estimateId = item["PurchaseID"].Text;
                    string customerid = item["custid"].Text;
                  
                    string targetUrl = $"{this.strSitepath}purchase/templates_view1.aspx?sectionid={customerid}&sectionname=Purchase&type=Supplier&page=Purchase&EstID={estimateId}&customtype=download";

                    item[this.cellvalue_DownloadTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_DownloadTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_DownloadTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_DownloadTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_blank", // Opens in a new tab
                        ToolTip = "Click to download PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}download-pdf.png", // Assuming download icon
                        AlternateText = "Download PDF",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_DownloadTemplate].Controls.Add(link);
                }

                if (this.flag_Archive == "true") // Using flag_DownloadTemplate
                {
                    string estimateId = item["PurchaseID"].Text;

                    string type = "archive"; // or "unarchive", depending on your logic

                    string estimateitemid = string.Empty;

                    this.cellvalue_Archive = "archive";

                    //if (this.IsItemSelected)
                    //{
                    //    estimateitemid = item["EstimateitemID"].Text;
                    //}

                    item[this.cellvalue_Archive].Attributes.Add("align", "center");
                    item[this.cellvalue_Archive].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_Archive].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_Archive].Controls.Clear();

                    // Create HyperLink control
                    HtmlGenericControl link = new HtmlGenericControl("a");
                    link.Attributes["href"] = "javascript:void(0);"; // prevent navigation
                    link.Attributes["onclick"] = $"CheckOne('{type}', '{estimateId}','{0}');"; // call JS function
                    link.Attributes["title"] = "Click to Archive";

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}archive.png", // Assuming download icon
                        AlternateText = "Archive the item",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_Archive].Controls.Add(link);
                }





                if (this.flag_Comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_Comments, "PurchaseID");
                }
                if (this.flag_Description == "true")
                {
                    item[this.cellvalue_Description].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Description].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Description].ToolTip = item["Description"].Text;
                    item[this.cellvalue_Description].Text = string.Concat("<div style='width:100px;overflow:hidden;max-height: 15px;height:15px;'>", item["Description"].Text, "</div>");
                }
                if (this.flag_Jobtitle == "true")
                {
                    item[this.cellvalue_Jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Jobtitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Jobtitle].ToolTip = item["jobtitle"].Text;
                    item[this.cellvalue_Jobtitle].Text = string.Concat("<div style='width:120px;overflow:hidden;max-height: 15px;height:15px;'>", item["jobtitle"].Text, "</div>");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    item[this.cellvalue_status].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                    item[this.cellvalue_status].ToolTip = item["status"].Text;
                }
                if (this.flag_suppliername == "true")
                {
                    item[this.cellvalue_suppliername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_suppliername].Style.Add("cursor", "pointer");
                    item[this.cellvalue_suppliername].ToolTip = item["suppliername"].Text;
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customername].ToolTip = item["customername"].Text;
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                    item[this.cellvalue_paymentterms].ToolTip = item["paymentterms"].Text;
                }
                if (this.flag_jobnumber == "true")
                {
                    item[this.cellvalue_jobnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_jobnumber].Style.Add("cursor", "pointer");
                }

                if (this.flag_SinceEmailed == "true")
                {
                    item[this.cellvalue_SinceEmailed].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceEmailed"].Text) >= Convert.ToInt32(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceEmailed"].Text != "0")
                            item[this.cellvalue_SinceEmailed].Style.Add("background-color", "#E64557"); // Add this line

                    if (item["isAnyEmailed"].Text == "0")
                        item[this.cellvalue_SinceEmailed].Text = "N/A";
                    item[this.cellvalue_SinceEmailed].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceEmailed].Style.Add("cursor", "pointer");
                }
                if (this.flag_SinceStatusUpdate == "true")
                {
                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceStatusUpdate"].Text) >= Convert.ToInt32(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceStatusUpdate"].Text != "0")
                            item[this.cellvalue_SinceStatusUpdate].Style.Add("background-color", "#E64557"); // Add this line

                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceStatusUpdate].Style.Add("cursor", "pointer");
                }


                if (this.flag_estimatenumber == "true")
                {
                    item[this.cellvalue_estimatenumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estimatenumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_notes == "true")
                {
                    item[this.cellvalue_notes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_notes].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_pono == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_pono].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_pono)] != null && this.Session[string.Concat("purchase_", this.cellvalue_pono)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox item1 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_status)] != null && this.Session[string.Concat("purchase_", this.cellvalue_status)].ToString() == "")
                    {
                        item1.Text = "";
                    }
                }
                if (this.flag_Description == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_Description].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_Description)] != null && this.Session[string.Concat("purchase_", this.cellvalue_Description)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }
                if (this.flag_SinceEmailed == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceEmailed].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_SinceEmailed)] != null && this.Session[string.Concat("purchase_", this.cellvalue_SinceEmailed)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_SinceStatusUpdate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceStatusUpdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_SinceStatusUpdate)] != null && this.Session[string.Concat("purchase_", this.cellvalue_SinceStatusUpdate)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("purchase_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("purchase_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("purchase_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("purchase_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("purchase_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_suppliername == "true")
                {
                    TextBox item2 = (e.Item as GridFilteringItem)[this.cellvalue_suppliername].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_suppliername)] != null && this.Session[string.Concat("purchase_", this.cellvalue_suppliername)].ToString() == "")
                    {
                        item2.Text = "";
                    }
                }
                if (this.flag_Jobtitle == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_Jobtitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_Jobtitle)] != null && this.Session[string.Concat("purchase_", this.cellvalue_Jobtitle)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_goodsreceived == "true")
                {
                    TextBox item3 = (e.Item as GridFilteringItem)[this.cellvalue_goodsreceived].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_goodsreceived)] != null && this.Session[string.Concat("purchase_", this.cellvalue_goodsreceived)].ToString() == "")
                    {
                        item3.Text = "";
                    }
                }
                if (this.flag_customername == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_customername].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_customername)] != null && this.Session[string.Concat("purchase_", this.cellvalue_customername)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }
                if (this.flag_Comments == "true")
                {
                    TextBox item4 = (e.Item as GridFilteringItem)[this.cellvalue_Comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_Comments)] != null && this.Session[string.Concat("purchase_", this.cellvalue_Comments)].ToString() == "")
                    {
                        item4.Text = "";
                    }
                }
                if (this.flag_paymentterms == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("purchase_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_poprice == "true")
                {
                    gridFilteringItem[this.cellvalue_poprice].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item5 = (e.Item as GridFilteringItem)[this.cellvalue_poprice].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_poprice)] != null && this.Session[string.Concat("purchase_", this.cellvalue_poprice)].ToString() == "")
                    {
                        item5.Text = "";
                    }
                }
                if (this.flag_PurValExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_PurValExcGst].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_PurValExcGst].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_PurValExcGst)] != null && this.Session[string.Concat("purchase_", this.cellvalue_PurValExcGst)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item6 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_createddate)] != null && this.Session[string.Concat("purchase_", this.cellvalue_createddate)].ToString() == "")
                    {
                        item6.Text = "";
                    }
                }
                if (this.flag_podate == "true")
                {
                    gridFilteringItem[this.cellvalue_podate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_podate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_podate)] != null && this.Session[string.Concat("purchase_", this.cellvalue_podate)].ToString() == "")
                    {
                        textBox6.Text = "";
                    }
                }
                if (this.flag_jobnumber == "true")
                {
                    gridFilteringItem[this.cellvalue_jobnumber].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item7 = (e.Item as GridFilteringItem)[this.cellvalue_jobnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_jobnumber)] != null && this.Session[string.Concat("purchase_", this.cellvalue_jobnumber)].ToString() == "")
                    {
                        item7.Text = "";
                    }
                }
                if (this.flag_notes == "true")
                {
                    gridFilteringItem[this.cellvalue_notes].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item8 = (e.Item as GridFilteringItem)[this.cellvalue_notes].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_notes)] != null && this.Session[string.Concat("purchase_", this.cellvalue_notes)].ToString() == "")
                    {
                        item8.Text = "";
                    }
                }
                if (this.flag_estimatenumber == "true")
                {
                    gridFilteringItem[this.cellvalue_estimatenumber].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item9 = (e.Item as GridFilteringItem)[this.cellvalue_estimatenumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("purchase_", this.cellvalue_estimatenumber)] != null && this.Session[string.Concat("purchase_", this.cellvalue_estimatenumber)].ToString() == "")
                    {
                        item9.Text = "";
                    }
                }
            }

            //if (e.Item is GridGroupHeaderItem groupHeader)
            //{
            //    // Make the whole "Est. Status: Completed" text bold and 14px
            //    groupHeader.Font.Bold = true;
            //    groupHeader.Font.Size = FontUnit.Point(14);

            //}

            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridViewpurchase.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridViewpurchase.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        private void ApplyGridGrouping(RadGrid grid, string fieldName, string headerText)
        {
            grid.MasterTableView.GroupByExpressions.Clear();
            grid.GroupingEnabled = true;
            grid.MasterTableView.GroupsDefaultExpanded = true;

            GridGroupByExpression groupByExpr = new GridGroupByExpression();
            GridGroupByField groupByField = new GridGroupByField
            {
                FieldName = fieldName,
                HeaderText = headerText,
                HeaderValueSeparator = ": " // Optional formatting
            };

            groupByExpr.SelectFields.Add(groupByField);
            groupByExpr.GroupByFields.Add(groupByField);

            grid.MasterTableView.GroupByExpressions.Add(groupByExpr);
            grid.Rebind();
        }



        protected void ApplyGroupingByHeaderTextDynamic1(Telerik.Web.UI.RadGrid grid, string headerTextToGroupBy)
        {
            // Find the column with matching header text
            GridColumn groupColumn = grid.MasterTableView.Columns
                .OfType<GridColumn>()
                .FirstOrDefault(c => c.HeaderText == headerTextToGroupBy);

            if (groupColumn != null)
            {
                // Clear existing groupings
                grid.MasterTableView.GroupByExpressions.Clear();

                // Create new grouping expression
                GridGroupByExpression groupByExpr = new GridGroupByExpression();
                GridGroupByField groupByField = new GridGroupByField();

                groupByField.FieldName = groupColumn.UniqueName; // or groupColumn.DataField
                groupByField.HeaderText = headerTextToGroupBy;

                groupByExpr.SelectFields.Add(groupByField);
                groupByExpr.GroupByFields.Add(groupByField);

                // Apply grouping
                grid.MasterTableView.GroupByExpressions.Add(groupByExpr);

                // Rebind the grid
                grid.Rebind();
            }
            else
            {
                throw new ArgumentException($"No column found with header text: {headerTextToGroupBy}");
            }
        }

        protected void ApplyGroupingByFieldName(RadGrid grid, string fieldNameToGroupBy)
        {
            // Verify grid is ready
            if (grid.MasterTableView == null ||
                (grid.MasterTableView.Columns.Count == 0 && !grid.MasterTableView.AutoGenerateColumns))
            {
                return;
                //   throw new InvalidOperationException("Grid must have columns before applying grouping.");
            }

            // Find the column by field name (checking both DataField and UniqueName)
            GridColumn groupColumn = FindColumnByFieldName(grid.MasterTableView, fieldNameToGroupBy);

            if (groupColumn == null)
            {
                return;
                // throw new ArgumentException($"Column with field name '{fieldNameToGroupBy}' not found.");
            }

            // Get the header text (fallback to field name if no header text)
            string headerText = !string.IsNullOrEmpty(groupColumn.HeaderText)
                ? groupColumn.HeaderText
                : fieldNameToGroupBy;

            // Apply grouping
            ApplyGridGrouping(grid, fieldNameToGroupBy, headerText);
        }

        private GridColumn FindColumnByFieldName(GridTableView tableView, string fieldName)
        {
            // First try exact match on DataField (for bound columns)
            var column = tableView.Columns
                .OfType<GridColumn>()
                .FirstOrDefault(c =>
                    (c is GridBoundColumn boundCol &&
                     string.Equals(boundCol.DataField, fieldName, StringComparison.OrdinalIgnoreCase)) ||
                    string.Equals(c.UniqueName, fieldName, StringComparison.OrdinalIgnoreCase));

            // If not found and auto-generate columns is on, we might need to check the generated columns
            if (column == null && tableView.AutoGenerateColumns)
            {
                // For auto-generated columns, the UniqueName typically matches the field name
                column = tableView.Columns
                    .OfType<GridColumn>()
                    .FirstOrDefault(c => string.Equals(c.UniqueName, fieldName, StringComparison.OrdinalIgnoreCase));
            }

            return column;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lnkPurchaseedit.Text = this.objLangClass.GetLanguageConversion("Edit_View");
            this.GridViewpurchase.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Archive_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.lblArchive.Text = this.objLangClass.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLangClass.GetLanguageConversion("Detele_Selected");
            this.lblCreateNewPO.Text = this.objLangClass.GetLanguageConversion("Create_New_PO");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            long purchaseStatusID = ConnectionClass.PurchaseStatusID;
            this.PurchaseStatusID = ConnectionClass.PurchaseStatusID;
            this.objBase.ReturnRoles_Privileges_Tabs("purchases", "isview", "");
            if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.DivdivDropdownlist.Visible = true;
            }
            else
            {
                this.DivdivDropdownlist.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
                
            }
            else
            {
                this.divarchive.Visible = false;
               
            }
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
                this.hdnIDs.Value = "";
            }
            for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridViewpurchase.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            global.pageName = "purchase";
            global.pgName = "";
            this.gloobj.setpagename("purchase");
            this.strImagepath = global.imagePath();
            this.pg = "purchase";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            base.Title = this.objLanguage.convert(global.pageTitle("Purchase View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_View")));
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            string str = this.cmnClass.UserSetting_Selete(this.CompanyID, this.UserID, "purchases_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.Session["PurViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["PurViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewpurchase.PageSize = 50;
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
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
            int num3 = 0;
            num3 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, this.pg);
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow dataRow in this.dt.Rows)
                {
                    this.defaultsortedby = dataRow["SortedBy"].ToString();
                    this.defaultsortdirection = dataRow["SortDirection"].ToString();
                    //83
                    //this.IsGrouping = String.IsNullOrEmpty(dataRow["isGrouping"].ToString()) ? false : Convert.ToBoolean(dataRow["isGrouping"].ToString());

                    //this.IsGrouping = (dataRow["ColumnNames"].ToString().Contains(dataRow["GroupByColumn"].ToString()) && !String.IsNullOrEmpty(dataRow["isGrouping"].ToString())) ? Convert.ToBoolean(dataRow["isGrouping"].ToString()) : false;
                    //this.GroupByColumn = dataRow["GroupByColumn"].ToString();
                    this.FilterDateType = dataRow["FilterDateType"].ToString();
                    this.FilterDateRange = dataRow["FilterDateRange"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                purchase_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    purchase_view.SortedBy = "PONo";
                }
                else
                {
                    purchase_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    purchase_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    purchase_view.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str1 = string.Concat(this.pg, this.UserID, this.pg);
                this.Session["search_pur"] = null;
                this.Session[str1] = null;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["su"] == null)
                {
                    if (base.Request.Params["suc"] != null)
                    {
                        if (base.Request.Params["suc"].ToString().ToLower() == "d")
                        {
                            base.Message_Display(this.objLangClass.GetLanguageConversion("Purchase_Delete_Sucessfully"), "successfulMsg", this.plhMessage);
                        }
                        else if (base.Request.Params["suc"].ToString().ToLower() == "a")
                        {
                            base.Message_Display(this.objLangClass.GetLanguageConversion("Purchase_Archived_Successfully"), "successfulMsg", this.plhMessage);
                        }
                        else if (base.Request.Params["suc"].ToString().ToLower() == "cop")
                        {
                            long num4 = Convert.ToInt64(base.Request.Params["id"]);
                            object[] languageConversion = new object[] { this.objLangClass.GetLanguageConversion("Inventory_Item_Copied_Successfully"), " <a href='../purchase/purchase_add.aspx?type=edit&id=", num4, "'>", this.objLangClass.GetLanguageConversion("Please_Click_Here_To_View"), "</a>" };
                            base.Message_Display(string.Concat(languageConversion), "successfulMsg", this.plhMessage);
                        }
                    }
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "in")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Purchase_Saved_Successfully"), "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "up")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Purchase_Updated_Successfully"), "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "de")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Purchase_Deleted_Successfully"), "successfulMsg", this.plhMessage);
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.cmnClass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.cmnClass.functionCheckChange());
            }
            if (!base.IsPostBack)
            {
                string str2 = "";
                this.GridStateLoad();
                if (this.Session["search_pur"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_pur"];
                    str2 = this.FilterFunction(item);
                }
                this.Session["PurViewID"] = this.defaultviewid;
                purchase_view.PageSize = this.cmnClass.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridViewpurchase);
                this.GridViewpurchase.PageSize = purchase_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, purchase_view.SortedBy, purchase_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridViewpurchase.Rebind();
            }
            var column = this.GridViewpurchase.MasterTableView.Columns.FindByUniqueNameSafe("SinceStatusCount");
            if (column != null)
            {
                column.Visible = false;
            }
            var column2 = this.GridViewpurchase.MasterTableView.Columns.FindByUniqueNameSafe("SinceEmailCount");
            if (column2 != null)
            {
                column2.Visible = false;
            }
            var column3 = this.GridViewpurchase.MasterTableView.Columns.FindByUniqueNameSafe("isAnyEmailed");
            if (column3 != null)
            {
                column3.Visible = false;
            }
            //if (!IsPostBack && this.IsGrouping )
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridViewpurchase, this.GroupByColumn);
            //}
            try
            {
                this.GridViewpurchase.MasterTableView.GetColumn("PurchaseID").Visible = false;
                this.GridViewpurchase.MasterTableView.GetColumn("custid").Visible = false;
                this.GridViewpurchase.MasterTableView.GetColumn("StatusColorCode").Visible = false;
            }
            catch (Exception exception)
            {
            }
            this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
            this.Radwin_POCopy.Title = this.objLanguage.convert(global.pageTitle("Purchase Copy", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            int num = Convert.ToInt16(this.RadListBox1.SelectedValue);
            if (this.ServerName.ToLower() != "dmc" && this.ServerName.ToLower() != "dmc2")
            {
                this.hdnStatus.Value = "true";
            }
            else if ((long)num != this.PurchaseStatusID)
            {
                this.hdnStatus.Value = "true";
            }
            if (this.hdnStatus.Value.ToLower() == "true")
            {
                string str = this.hdnSelectedChkfrmGrid.Value.ToString();
                this.RadListBox1.ClearSelection();
                string str1 = "Purchase";
                if (str != "" && num != 0)
                {
                    PurchaseBasePage.PurchaseOnCheck_Status_Update(this.CompanyID, str, num, str1);
                    this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                    this.hdnSelectedChkfrmGrid.Value = "";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                    this.GridViewpurchase.Rebind();
                    return;
                }
            }
            else if ((this.ServerName.ToLower() == "dmc" || this.ServerName.ToLower() == "dmc2") && (long)num == this.PurchaseStatusID)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ShowPopUp();", true);
            }
        }
    }
}