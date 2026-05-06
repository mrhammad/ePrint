using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ePrint.usercontrol.Item;
using System.Configuration;
using System.Linq;
using System.IO;

namespace ePrint.orders
{
    public partial class order_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected UpdateProgress upProgress;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkOrderedit;

        //protected LinkButton btnclrFilters;

        //protected Label lblView;

        //protected HiddenField hdnAlphabet;

        //protected RadListBox RadListBox1;

        //protected Label lblArchive;

        //protected HtmlGenericControl divarchive;

        //protected Label lblUnArchive;

        //protected HtmlGenericControl divunarchive;

        //protected Label lblDelete;

        //protected HtmlGenericControl divDelete;

        //protected RadGrid GridView1;

        //protected LinkButton lnkOrderDelete;

        //protected LinkButton lnkOrderArchive;

        //protected LinkButton lnkOrderUnArchive;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hdnOrderID;

        //protected HiddenField hidGridCount;

        //protected HiddenField hdnOrderIds;

        //protected HiddenField hdnSelectedChkfrmGrid;

        //protected UpdatePanel updtehidnfield;

        //protected HiddenField editOrderViewID;

        //protected HiddenField hdnIDs;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private commonClass objJava = new commonClass();

        private BasePage objpage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        public string strImagepath;

        public string strSitepath;

        public int CompanyID;

        public int UserID;

        public string pg;

        public string DateFormat = string.Empty;

        public int defaultviewid;

        public int totalrec;

        private string para = string.Empty;

        public static string WhereCondition;

        public static string SortedBy;

        public static string sortdirection;

        private createViewClass objCreateView = new createViewClass();

        public string flag_estval = string.Empty;

        public string cellvalue_estval = string.Empty;

        public string cellvalue_estvalExcGst = string.Empty;

        public string flag_estvalExcGst = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string flag_estdate = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_orderstatus = string.Empty;

        public string flag_orderstatus = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string cellvalue_order = string.Empty;

        public string flag_order = string.Empty;

        public string cellvalue_greeting = string.Empty;

        public string flag_greeting = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;

        public string cellvalue_estimator = string.Empty;

        public string flag_estimator = string.Empty;

        public string cellvalue_custname = string.Empty;

        public string flag_custname = string.Empty;

        public string cellvalue_company = string.Empty;

        public string flag_company = string.Empty;

        public string cellvalue_sales = string.Empty;

        public string flag_sales = string.Empty;

        public string cellvalue_contactname = string.Empty;

        public string flag_contactname = string.Empty;

        public string cellvalue_Header = string.Empty;

        public string flag_Header = string.Empty;

        public string cellvalue_footer = string.Empty;

        public string flag_footer = string.Empty;

        public string cellvalue_comments = string.Empty;

        public string flag_comments = string.Empty;

        public string cellvalue_estTitle = string.Empty;

        public string flag_estTitle = string.Empty;

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_OrderBy = string.Empty;

        public string flag_OrderBy = string.Empty;

        public string cellvalue_Department = string.Empty;

        public string flag_Department = string.Empty;

        public string cellvalue_CompamyEmail = string.Empty;

        public string flag_CompamyEmail = string.Empty;

        public string cellvalue_ContactEmail = string.Empty;

        public string flag_ContactEmail = string.Empty;

        public string cellvalue_ContactPhone = string.Empty;

        public string flag_ContactPhone = string.Empty;

        public string cellvalue_CustomerOrderNumber = string.Empty;

        public string flag_CustomerOrderNumber = string.Empty;

        public string cellvalue_PaymentType = string.Empty;

        public string flag_PaymentType = string.Empty;

        public string cellvalue_DeliveryDate = string.Empty;

        public string flag_DeliveryDate = string.Empty;

        public string flag_ItemStatus = string.Empty;

        public string cellvalue_ItemStatus = string.Empty;

        public string flag_ItemTitle = string.Empty;

        public string cellvalue_ItemTitle = string.Empty;

        public string flag_StockStage = string.Empty;   ///modification by Bilal Stage 3

        public string cellvalue_StockStage = string.Empty;  ///modification by Bilal Stage 3

        public string flag_ItemAccCode = string.Empty;

        public string cellvalue_ItemAccCode = string.Empty;

        public string flag_ItemQTY = string.Empty;

        public string cellvalue_ItemQTY = string.Empty;

        public string flag_ItemValue_ExcTax = string.Empty;

        public string cellvalue_ItemValue_ExcTax = string.Empty;

        public string flag_ItemValue_IncTax = string.Empty;

        public string cellvalue_ItemValue_IncTax = string.Empty;

        public string flag_ItemTaxValue = string.Empty;

        public string cellvalue_ItemTaxValue = string.Empty;

        public string flag_ItemCostPriceExcMarkup = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup = string.Empty;

        public string flag_ItemMarkupValue = string.Empty;

        public string cellvalue_ItemMarkupValue = string.Empty;

        public string flag_ItemCostPriceIncMarkup = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup = string.Empty;

        public string flag_ItemProfitMarginPercentage = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage = string.Empty;

        public string flag_ItemProfitMarginValue = string.Empty;

        public string cellvalue_ItemProfitMarginValue = string.Empty;

        public string flag_ItemGrossProfitPercentage = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage = string.Empty;

        public string flag_ItemGrossProfitValue = string.Empty;

        public string cellvalue_ItemGrossProfitValue = string.Empty;

        public string flag_EventName = string.Empty;

        public string cellvalue_EventName = string.Empty;

        public string flag_EventCodeNumber = string.Empty;

        public string cellvalue_EventCodeNumber = string.Empty;

        public string flag_CampaignSignNumber = string.Empty;

        public string cellvalue_CampaignSignNumber = string.Empty;

        public string flag_IsApproved = string.Empty;

        public string cellvalue_IsApproved = string.Empty;

        public string flag_ItemMaterial = string.Empty;

        public string cellvalue_ItemMaterial = string.Empty;

        public string flag_EventVenue = string.Empty;

        public string cellvalue_EventVenue = string.Empty;

        public string flag_Height = string.Empty;

        public string cellvalue_Height = string.Empty;

        public string flag_Width = string.Empty;

        public string cellvalue_Width = string.Empty;

        public string flag_ItemDescription = string.Empty;

        public string cellvalue_ItemDescription = string.Empty;

        public string flag_ItemColour = string.Empty;

        public string cellvalue_ItemColour = string.Empty;

        public string flag_ItemSize = string.Empty;

        public string cellvalue_ItemSize = string.Empty;

        public string flag_ItemArtwork = string.Empty;

        public string cellvalue_ItemArtwork = string.Empty;

        public string flag_ItemDelivery = string.Empty;

        public string cellvalue_ItemDelivery = string.Empty;

        public string flag_ItemFinishing = string.Empty;

        public string cellvalue_ItemFinishing = string.Empty;

        public string flag_ItemProofs = string.Empty;

        public string cellvalue_ItemProofs = string.Empty;

        public string flag_ItemPacking = string.Empty;

        public string cellvalue_ItemPacking = string.Empty;

        public string flag_ItemNotes = string.Empty;

        public string cellvalue_ItemNotes = string.Empty;

        public string flag_ItemTermsInstructions = string.Empty;

        public string cellvalue_ItemTermsInstructions = string.Empty;

        public string cellvalue_quantity1 = string.Empty;

        public string flag_quantity1 = string.Empty;

        public string cellvalue_quantity2 = string.Empty;

        public string flag_quantity2 = string.Empty;

        public string cellvalue_quantity3 = string.Empty;

        public string flag_quantity3 = string.Empty;

        public string cellvalue_quantity4 = string.Empty;

        public string flag_quantity4 = string.Empty;

        public string cellvalue_costcentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_estdate = string.Empty;

        public string flag_orderno = string.Empty;

        public string cellvalue_orderno = string.Empty;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public string cellvalue_orderedfor = string.Empty;

        public string flag_orderedfor = string.Empty;

        private SummaryClass SummaryClassObj = new SummaryClass();

        public DataTable dt = new DataTable();

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string flag_validfor = string.Empty;

        public string cellvalue_validfor = string.Empty;

        public string cellvalue_DeliveryAddress = string.Empty;

        public string flag_DeliveryAddress = string.Empty;

        public string flag_DefaultTemplate = string.Empty;

        public string cellvalue_DefaultTemplate = string.Empty;

        public string flag_ChooseTemplate = string.Empty;

        public string cellvalue_ChooseTemplate = string.Empty;

        public string flag_DownloadTemplate = string.Empty;

        public string cellvalue_DownloadTemplate = string.Empty;

        public string flag_FTPStatus = string.Empty;

        public string cellvalue_FTPStatus = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        private DataTable dtsearch = new DataTable();

        public long EstNo;

        public string newdate = string.Empty;

        public static int PageSize;

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Archive_Row_Selection_Alert = string.Empty;

        public string Delete_Row_Selection_Alert = string.Empty;

        public string UnArchive_Row_Selection_Alert = string.Empty;

        public bool IsItemSelected;

        public string RecordsToDisplay = "";

        public string flag_MainItemSupplier = string.Empty;
        public string cellvalue_MainItemSupplier = string.Empty;
        //public bool IsGrouping;

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();
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



        public string flag_Archive = string.Empty;

        public string cellvalue_Archive = string.Empty;

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

        static order_view()
        {
            order_view.WhereCondition = string.Empty;
            order_view.SortedBy = string.Empty;
            order_view.sortdirection = string.Empty;
            order_view.ManageStockPermission = 0;
            order_view.PageSize = 50;
        }

        public order_view()
        {
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
        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridView1.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "ordereddate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    //if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    //{
                    //   this.GridView1.MasterTableView.Columns.Remove(gridBoundColumn);

                    //  GridTemplateColumn commentColumn = new GridTemplateColumn();
                    //  commentColumn.UniqueName = dt.Columns[i].ColumnName;
                    //  commentColumn.HeaderText = "Comments";
                    //  commentColumn.ItemTemplate = new CommentsTemplate();
                    //  gv.MasterTableView.Columns.Add(commentColumn);
                    //}
                }
                for (int j = 0; j < this.GridView1.Columns.Count; j++)
                {
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridView1.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_No");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_orderno = "true";
                        this.cellvalue_orderno = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Person");
                        this.flag_sales = "true";
                        this.cellvalue_sales = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordertitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_Title");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_estTitle = "true";
                        this.cellvalue_estTitle = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "company")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_company = "true";
                        this.cellvalue_company = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_No");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_orderstatus = "true";
                        this.cellvalue_orderstatus = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "validfor")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Valid_For");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_validfor = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Created_On");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate1 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate2 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate2 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate3 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate3 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate4 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate4 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate5")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate5 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate5 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordervalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Order_Value"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordereddate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_estdate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity1")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity1");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity1 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity2")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity2");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity2 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity2 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity3")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity3");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity3 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity3 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity4")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity4");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity4 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity4 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.flag_referredby = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "IsCompletlyConvertedToJob")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isarchive")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Order_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estvalExcGst = "true";
                        this.cellvalue_estvalExcGst = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Comments");
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedfor")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_For");
                        this.flag_orderedfor = "true";
                        this.cellvalue_orderedfor = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridView1.Columns[j].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Default Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Choose Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ChooseTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Download Default Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DownloadTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridView1.Columns[j].HeaderText = "Archive";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }





                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Status Days";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceStatusUpdate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_SinceStatusUpdate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.GridView1.Columns[j].HeaderText = "Email Days";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceEmailed = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_SinceEmailed = "true";
                    }

                    ///modification By Bilal Stage 3
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "stockstage")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Stock_Stage");
                        this.flag_StockStage = "true";
                        this.cellvalue_StockStage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "mainitemsupplier")
                    {
                        this.flag_MainItemSupplier = "true";
                        this.cellvalue_MainItemSupplier = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Main_Item_Supplier");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventname")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Name");
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Code_Number");
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Sign_Number");
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "approved")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Is_Approved");
                        this.flag_IsApproved = "true";
                        this.cellvalue_IsApproved = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                        this.flag_ItemMaterial = "true";
                        this.cellvalue_ItemMaterial = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventvenue")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Venue");
                        this.flag_EventVenue = "true";
                        this.cellvalue_EventVenue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_View");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedby")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_By");
                        this.flag_OrderBy = "true";
                        this.cellvalue_OrderBy = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "department")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.flag_CustomerOrderNumber = "true";
                        this.cellvalue_CustomerOrderNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paymenttype")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Type");
                        this.flag_PaymentType = "true";
                        this.cellvalue_PaymentType = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliveryaddress")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Address");
                        this.flag_DeliveryAddress = "true";
                        this.cellvalue_DeliveryAddress = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                }
            }

            for (int j = 0; j < this.GridView1.Columns.Count; j++)
            {


                if (this.GridView1.Columns[j].UniqueName.ToLower() == "defaulttemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Default Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DefaultTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_DefaultTemplate = "true";
                }

                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "choosetemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Choose Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_ChooseTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_ChooseTemplate = "true";
                }

                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "downloadtemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Download Default Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DownloadTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_DownloadTemplate = "true";
                }
                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridView1.Columns[j].HeaderText = "Archive";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
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

        public class CommentsTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                HyperLink hlEditComment = new HyperLink();
                hlEditComment.DataBinding += (s, e) =>
                {
                    GridDataItem item = (GridDataItem)container.NamingContainer;
                    hlEditComment.Text = DataBinder.Eval(item.DataItem, "Comments").ToString();
                    string estimateId = DataBinder.Eval(item.DataItem, "EstimateID").ToString();
                    hlEditComment.Attributes["onclick"] = $"openCommentPopup('{estimateId}', '{hlEditComment.Text}'); return false;";
                };
                container.Controls.Add(hlEditComment);
            }
        }
        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string newComment = hiddenCommentText.Value;
            int commentId = int.Parse(hiddenCommentId.Value);

            UpdateCommentInDatabase(commentId, newComment);

            GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, this.para);
            this.GridView1.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "orders/order_view.aspx"));
        }


        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            OrderBasePage.Order_Comments_Update(commentId, newComment);
        }

        public void bindRadlistStatus()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "webstoreorder");
            this.RadListBox1.DataSource = dataTable;
            this.RadListBox1.DataTextField = "StatusTitle";
            this.RadListBox1.DataValueField = "StatusID";
            this.RadListBox1.DataBind();
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            EstimateBasePage.Estimate_Delete(Convert.ToInt32(this.Session["companyid"]), Convert.ToInt64(this.hdnOrderID.Value));
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, this.para);
        }

        public void btnEditViewOrder_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../orders/customvieworder.aspx?type=edit&id=", this.editOrderViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("order_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("order_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            order_view.WhereCondition = "";
            this.Session["search_ord"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
            this.GridView1.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpCookie httpCookie = new HttpCookie("ckeEditviewID_order");
            httpCookie["Order_viewID"] = this.ddl_View.SelectedValue;
            base.Response.Cookies.Add(httpCookie);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "orders/order_view.aspx?viewid=", num1, "&index=", num };
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
            this.Session["search_ord"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && order_view.WhereCondition != "")
                {
                    order_view.WhereCondition = string.Concat(order_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "ordereddate" || dataRow["ColumnName"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                {
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                    object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                    empty = string.Concat(objArray);
                }
                else
                {
                    empty = dataRow["ColumnName"].ToString();
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                //             if (< PrivateImplementationDetails >{ 46D7F5E5 - DE22 - 4D3F - 8BD5 - A10016D9C228}.$$method0x600001a - 1 == null)
                //{

                //             < PrivateImplementationDetails >{ 46D7F5E5 - DE22 - 4D3F - 8BD5 - A10016D9C228}.$$method0x600001a - 1 = new Dictionary<string, int>(10)
                //             {
                //                 { "startswith", 0 },
                //                 { "endswith", 1 },
                //                 { "contains", 2 },
                //                 { "doesnotcontain", 3 },
                //                 { "equalto", 4 },
                //                 { "notequalto", 5 },
                //                 { "greaterthan", 6 },
                //                 { "greaterthanorequalto", 7 },
                //                 { "lessthan", 8 },
                //                 { "lessthanorequalto", 9 }
                //             };
                //             }
                //             if (!< PrivateImplementationDetails >{ 46D7F5E5 - DE22 - 4D3F - 8BD5 - A10016D9C228}.$$method0x600001a - 1.TryGetValue(str1, out num))
                //{
                //                 continue;
                //             }

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
                            string whereCondition = order_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            order_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = order_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            order_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "ordereddate" || dataRow["ColumnName"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = order_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string str2 = order_view.WhereCondition;
                                string[] strArrays3 = new string[] { str2, " ", empty, " like '%", str, "%'" };
                                order_view.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        }
                    case 3:
                        {
                            string whereCondition3 = order_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " not like '%", str, "%'" };
                            order_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str3 = order_view.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = ", str };
                                order_view.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                            else
                            {
                                string whereCondition4 = order_view.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " = '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str4 = order_view.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " != ", str };
                                order_view.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                            else
                            {
                                string whereCondition5 = order_view.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " != '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str5 = order_view.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " > ", str };
                                order_view.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                            else
                            {
                                string whereCondition6 = order_view.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " > '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str6 = order_view.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " >= ", str };
                                order_view.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                            else
                            {
                                string whereCondition7 = order_view.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " >= '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str7 = order_view.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " < ", str };
                                order_view.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                            else
                            {
                                string whereCondition8 = order_view.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " < '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "ordervalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str8 = order_view.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " <= ", str };
                                order_view.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                            else
                            {
                                string whereCondition9 = order_view.WhereCondition;
                                string[] strArrays16 = new string[] { whereCondition9, " ", empty, " <= '", str, "'" };
                                order_view.WhereCondition = string.Concat(strArrays16);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return order_view.WhereCondition;
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
                CommandTimeout = 0,
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
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("OrderedDate"))
                    {
                        row["OrderedDate"] = this.objJava.Eprint_return_Date_Before_View(row["OrderedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ActualDeliveryDate"))
                    {
                        row["ActualDeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate1"))
                    {
                        row["CustomDate1"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate2"))
                    {
                        row["CustomDate2"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate3"))
                    {
                        row["CustomDate3"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate4"))
                    {
                        row["CustomDate4"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate5"))
                    {
                        row["CustomDate5"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), CompanyID, UserID, false);
                    }
                    if (!row.Table.Columns.Contains("DeliveryDate"))
                    {
                        continue;
                    }
                    row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                }
            }
            _commonClass.closeConnection();
            this.GridView1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
            this.div_Main.Style.Add("display", "block");
            this.GridView1.AllowCustomPaging = true;
            this.GridView1.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }

        protected void GridView1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            e.Column.Visible = false;
            if (e.Column.IsBoundToFieldName("Date"))
            {
                (e.Column as GridDateTimeColumn).DataFormatString = "{0:D}";
            }
            else if (e.Column.IsBoundToFieldName("UnitPrice"))
            {
                (e.Column as GridNumericColumn).DataFormatString = "{0:C}";
            }
            if (e.Column is GridBoundColumn)
            {
                (e.Column as GridBoundColumn).FilterControlWidth = Unit.Pixel(100);
            }
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = base.ReplaceSingleQuote(item.Text);
                order_view.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "ordervalue" || commandArgument.Second.ToString().ToLower() == "estimatevalue_excgst" || commandArgument.Second.ToString().ToLower() == "quantity1" || commandArgument.Second.ToString().ToLower() == "quantity2" || commandArgument.Second.ToString().ToLower() == "quantity3" || commandArgument.Second.ToString().ToLower() == "quantity4"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Please enter only number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (this.Session["search_ord"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_ord"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_ord"];
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
                this.Session["search_ord"] = this.dtsearch;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                order_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
                this.GridView1.DataBind();
                //this.GridView1.Rebind();
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.SelectedValue), order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            order_view.SortedBy = e.SortExpression;
            order_view.sortdirection = e.NewSortOrder.ToString();
            if (order_view.sortdirection.ToLower() == "ascending")
            {
                order_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (order_view.sortdirection.ToLower() != "descending")
            {
                order_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                order_view.sortdirection = "DESC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, order_view.sortdirection, order_view.WhereCondition);
        }

        protected void lnkOrderArchive_OnClick(object sender, EventArgs e)
        {
            Int32 countZero = 0;
            string[] strArrays = this.hdnOrderIds.Value.Split(new char[] { ',' });

            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)Convert.ToInt32(strArray.Split(chrArray)[!this.IsItemSelected ? 0 : 2].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this job and it can not be deleted. Please contact support and request assistance" : "There is an error in one of the job(s) and can not be deleted. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);

                return;
            }

            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    OrderBasePage.Archive_Order(Convert.ToInt64(str.Split(chrArray)[0].ToString()), Convert.ToInt64(this.CompanyID));
                }
                else
                {
                    int companyID = this.CompanyID;
                    string str1 = strArrays[i];
                    char[] chrArray1 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Archive(companyID, (long)Convert.ToInt32(str1.Split(chrArray1)[2].ToString()), "order");
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkOrderDelete_OnClick(object sender, EventArgs e)
        {
            long num = (long)0;
            bool flag = false;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            string[] strArrays = this.hdnOrderIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (this.StockCancellationType.ToString().ToLower() == "a")
                {
                    if (!this.IsItemSelected)
                    {
                        SummaryClass summaryClassObj = this.SummaryClassObj;
                        string str = strArrays[i];
                        char[] chrArray = new char[] { '\u005F' };
                        long num1 = (long)Convert.ToInt32(str.Split(chrArray)[1].ToString());
                        int companyID = this.CompanyID;
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        summaryClassObj.Call_Inventory_Adjustment_Order("cancelled-stock-delete", num1, companyID, (long)Convert.ToInt32(str1.Split(chrArray1)[2].ToString()), this.UserID);
                    }
                    else
                    {
                        SummaryClass summaryClass = this.SummaryClassObj;
                        string str2 = strArrays[i];
                        char[] chrArray2 = new char[] { '\u005F' };
                        long num2 = (long)Convert.ToInt32(str2.Split(chrArray2)[1].ToString());
                        int companyID1 = this.CompanyID;
                        string str3 = strArrays[i];
                        char[] chrArray3 = new char[] { '\u005F' };
                        summaryClass.Call_Inventory_Adjustment_Order("cancelled-stock", num2, companyID1, (long)Convert.ToInt32(str3.Split(chrArray3)[2].ToString()), this.UserID);
                    }
                }
                if (!this.IsItemSelected)
                {
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    OrderBasePage.delete_Order(Convert.ToInt64(str4.Split(chrArray4)[0].ToString()), Convert.ToInt64(this.CompanyID), num);
                }
                else
                {
                    int companyID2 = this.CompanyID;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Delete(companyID2, (long)Convert.ToInt32(str5.Split(chrArray5)[2].ToString()), "order", flag);
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkOrderUnArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnOrderIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    EstimateBasePage.Estimate_UnArchive(companyID, Convert.ToInt64(str.Split(chrArray)[0].ToString()));
                }
                else
                {
                    int num = this.CompanyID;
                    string str1 = strArrays[i];
                    char[] chrArray1 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_UnArchive(num, (long)Convert.ToInt32(str1.Split(chrArray1)[2].ToString()), "order");
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, order_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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
            //foreach (GridItem item in GridView1.MasterTableView.Items)
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

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            string[] str;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridView1.Columns.Count; i++)
                {
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "ordernumber")
                    {
                        this.flag_orderno = "true";
                        this.cellvalue_orderno = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.MasterTableView.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.GridView1.MasterTableView.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ordervalue")
                    {
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ordereddate")
                    {
                        this.cellvalue_estdate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "validfor")
                    {
                        this.cellvalue_validfor = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderstatus")
                    {
                        this.cellvalue_orderstatus = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_orderstatus = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.cellvalue_AccountStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.cellvalue_status = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "order")
                    {
                        this.cellvalue_order = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_order = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "greeting")
                    {
                        this.cellvalue_greeting = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.cellvalue_estimator = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_custname = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "company")
                    {
                        this.cellvalue_company = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_company = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_sales = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactname")
                    {
                        this.cellvalue_contactname = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "header")
                    {
                        this.cellvalue_Header = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "footer")
                    {
                        this.cellvalue_footer = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_footer = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ordertitle")
                    {
                        this.cellvalue_estTitle = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimateid")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "iscompletlyconvertedtojob")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isarchived")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_estvalExcGst = "true";
                        this.cellvalue_estvalExcGst = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.cellvalue_ChooseTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.cellvalue_DownloadTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = true;
                            this.flag_costcentre = "true";
                            this.cellvalue_costcentre = this.GridView1.Columns[i].SortExpression.ToLower();
                        }
                        else
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = false;
                        }
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "backorder")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower().Trim() == "isaccountonhold")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower().Trim() == "isstockproduct")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedfor")
                    {
                        this.flag_orderedfor = "true";
                        this.cellvalue_orderedfor = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.flag_SinceStatusUpdate = "true";
                        this.cellvalue_SinceStatusUpdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.flag_SinceEmailed = "true";
                        this.cellvalue_SinceEmailed = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    ////modification By Bilal Stage 3
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "stockstage")
                    {
                        this.flag_StockStage = "true";
                        this.cellvalue_StockStage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "mainitemsupplier")
                    {
                        this.flag_MainItemSupplier = "true";
                        this.cellvalue_MainItemSupplier = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "approved")
                    {
                        this.flag_IsApproved = "true";
                        this.cellvalue_IsApproved = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "approved")
                    {
                        this.flag_EventVenue = "true";
                        this.cellvalue_EventVenue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedby")
                    {
                        this.flag_OrderBy = "true";
                        this.cellvalue_OrderBy = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "department")
                    {
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.flag_CustomerOrderNumber = "true";
                        this.cellvalue_CustomerOrderNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "paymenttype")
                    {
                        this.flag_PaymentType = "true";
                        this.cellvalue_PaymentType = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ftp")
                    {
                        this.flag_FTPStatus = "true";
                        this.cellvalue_FTPStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str1 = string.Concat("order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text);
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plhConvertJob");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plh_Error");
                PlaceHolder placeHolder3 = (PlaceHolder)e.Item.FindControl("plhBackOrder");
                PlaceHolder placeHolder4 = (PlaceHolder)e.Item.FindControl("plhHasReplenishItem");
                PlaceHolder placeHolder5 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder6 = (PlaceHolder)e.Item.FindControl("plh_stockproduct");
                string empty = string.Empty;
                string languageConversion = string.Empty;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string languageConversion1 = string.Empty;
                empty1 = string.Concat(this.strImagepath, "Attachment.PNG");
                empty2 = "Item with an attachment(s)";
                str2 = string.Concat(this.strImagepath, "liner_j_icon.png");
                empty3 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion1 = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                empty = string.Concat(this.strImagepath, "Stock-Icon.jpg");
                languageConversion = this.objLanguage.GetLanguageConversion("Stock_Product");


                // Start
                if (e.Item.OwnerTableView.Columns.FindByUniqueNameSafe("EstimateID") != null)
                {
                    string Error_Count = "0";


                    //Error_Count = getErrorCount(Convert.ToInt32(item["EstimateID"].Text));
                    if (Convert.ToInt32(Error_Count) <= 0)
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                    }
                    else
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                    }
                }
                else
                {
                    if (Convert.ToInt16(item["ErrorCount"].Text) <= 0)
                    {
                        placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                    }
                    else
                    {
                        placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                    }

                }
                // End

                if (Convert.ToInt16(item["BackOrder"].Text) != 1)
                {
                    placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                else
                {
                    placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "BackORder.png' border='0' title='Back Order' class='viewicon_margin' />")));
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls = placeHolder5.Controls;
                    str = new string[] { "<img src='", empty3, "'  title='", languageConversion1, "' class='viewicon_margin'  />" };
                    controls.Add(new LiteralControl(string.Concat(str)));
                }
                if (Convert.ToInt16(item["IsStockProduct"].Text) == 1)
                {
                    ControlCollection controlCollections = placeHolder5.Controls;
                    string[] strArrays = new string[] { "<img src='", empty, "'  title='", languageConversion, "' class='viewicon_margin'  />" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                }
                if (item["EstItemCoun"].Text == "0")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                else
                {
                    ControlCollection controls1 = placeHolder.Controls;
                    string[] strArrays1 = new string[] { "<img src='", empty1, "' title='", empty2, "' style='cursor:pointer;' class='viewicon_margin' />" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                if (item["IsDeletedJob"].Text != "0")
                {
                    ControlCollection controlCollections1 = placeHolder1.Controls;
                    str = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "><img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' /></a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(str)));
                }
                else if (item["IsCompletlyConvertedToJob"].Text != "1")
                {
                    ControlCollection controls2 = placeHolder1.Controls;
                    str = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "><img src='", this.strImagepath, "1t.gif' border='0'   style='width:0px' /></a>" };
                    controls2.Add(new LiteralControl(string.Concat(str)));
                }
                else if (!this.IsItemSelected)
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", str2, "' Title='Job Raised' class='viewicon_margin' />")));
                }
                else
                {
                    ControlCollection controlCollections2 = placeHolder1.Controls;
                    string[] strArrays2 = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[2].ToString(), "><img src='", str2, "' Title='Job Raised' class='viewicon_margin' /></a>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                if (Convert.ToInt16(item["HasReplenishItem"].Text) != 1)
                {
                    placeHolder4.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                else
                {
                    placeHolder4.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "replenishicon.png' border='0' title='Replenish Item' class='viewicon_margin' />")));
                }
                if (!this.IsItemSelected)
                {
                    TableCell tableCell = item["ordernumber"];
                    str = new string[] { "<a href=", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, ">", item["ordernumber"].Text, "</a>" };
                    tableCell.Text = string.Concat(str);
                }
                else
                {
                    TableCell item1 = item["ordernumber"];
                    str = new string[] { "<a href=", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "&EstItemID=", ((DataRowView)e.Item.DataItem)[1].ToString(), ">", item["ordernumber"].Text, "</a>" };
                    item1.Text = string.Concat(str);
                }
                if (this.flag_estval == "true")
                {
                    item[this.cellvalue_estval].Attributes.Add("align", "right");
                    item[this.cellvalue_estval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estval].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estval].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estval].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_estvalExcGst == "true")
                {
                    item[this.cellvalue_estvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_estvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estvalExcGst].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estvalExcGst].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estvalExcGst].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_estdate == "true")
                {
                    item[this.cellvalue_estdate].Attributes.Add("align", "center");
                    item[this.cellvalue_estdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate1 == "true")
                {
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }
                if (this.flag_validfor == "true")
                {
                    item[this.cellvalue_validfor].Attributes.Add("align", "right");
                    item[this.cellvalue_validfor].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_validfor].Style.Add("cursor", "pointer");
                    TableCell tableCell1 = item[this.cellvalue_validfor];
                    str = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_validfor].Text, "</div>" };
                    tableCell1.Text = string.Concat(str);
                }

                if (this.flag_DefaultTemplate == "true")
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}orders/templates_view1.aspx?sectionid={customerid}&sectionname=webstoreorder&type=Customer&page=webstoreorder&EstID={estimateId}&ordid={orderid}&GenPdf=all&customtype=preview";

                    //   string targetUrl = $"https://testlive.eprintsoftware.com/estimates/templates_view1.aspx?sectionid=17420&sectionname=Estimate&type=Customer&page=Estimate&EstID=28280&GenPdf=all";
                    //string targetUrl = $"https://yourwebsite.com/details?estimateId={estimateId}";

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
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}orders/templates_view1.aspx?sectionid={customerid}&sectionname=webstoreorder&type=Customer&page=webstoreorder&EstID={estimateId}&ordid={orderid}&GenPdf=all&customtype=choosetemp";

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
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}orders/templates_view1.aspx?sectionid={customerid}&sectionname=webstoreorder&type=Customer&page=webstoreorder&EstID={estimateId}&ordid={orderid}&GenPdf=all&customtype=download";

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
                    string estimateId = item["orderid"].Text;
                   
                    string type = "archive"; // or "unarchive", depending on your logic

                    string estimateitemid = string.Empty;
                    this.cellvalue_Archive = "archive";
                    if (this.IsItemSelected)
                    {
                        estimateitemid = item["EstimateitemID"].Text;
                    }

                    item[this.cellvalue_Archive].Attributes.Add("align", "center");
                    item[this.cellvalue_Archive].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_Archive].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_Archive].Controls.Clear();

                    // Create HyperLink control
                    HtmlGenericControl link = new HtmlGenericControl("a");
                    link.Attributes["href"] = "javascript:void(0);"; // prevent navigation
                    link.Attributes["onclick"] = $"CheckOne('{type}', '{estimateId}','{estimateitemid}');"; // call JS function
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








                if (this.flag_orderstatus == "true")
                {
                    item[this.cellvalue_orderstatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_orderstatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_orderstatus].ToolTip = item[this.cellvalue_orderstatus].Text;
                    TableCell item2 = item[this.cellvalue_orderstatus];
                    str = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_orderstatus].Text, "</div>" };
                    item2.Text = string.Concat(str);
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_AccountStatus];
                    str = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_AccountStatus].Text, "</div>" };
                    tableCell2.Text = string.Concat(str);
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    item[this.cellvalue_status].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                    item[this.cellvalue_status].ToolTip = item[this.cellvalue_status].Text;
                    TableCell item3 = item[this.cellvalue_status];
                    str = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_status].Text, "</div>" };
                    item3.Text = string.Concat(str);
                }
                if (this.flag_order == "true")
                {
                    item[this.cellvalue_order].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_order].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_order];
                    str = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_order].Text, "</div>" };
                    tableCell3.Text = string.Concat(str);
                }
                if (this.flag_greeting == "true")
                {
                    item[this.cellvalue_greeting].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_greeting].Style.Add("cursor", "pointer");
                    TableCell item4 = item[this.cellvalue_greeting];
                    str = new string[] { "<div style='width: ", this.type3, ";min-width: ", this.type3, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_greeting].Text, "</div>" };
                    item4.Text = string.Concat(str);
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                    TableCell tableCell4 = item[this.cellvalue_estimator];
                    str = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_estimator].Text, "</div>" };
                    tableCell4.Text = string.Concat(str);
                }
                if (this.flag_custname == "true")
                {
                    item[this.cellvalue_custname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_custname].Style.Add("cursor", "pointer");
                    item[this.cellvalue_custname].ToolTip = item[this.cellvalue_custname].Text;
                }
                if (this.flag_company == "true")
                {
                    item[this.cellvalue_company].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_company].Style.Add("cursor", "pointer");
                    item[this.cellvalue_company].ToolTip = item[this.cellvalue_company].Text;
                }
                if (this.flag_sales == "true")
                {
                    item[this.cellvalue_sales].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_sales].Style.Add("cursor", "pointer");
                    item[this.cellvalue_sales].ToolTip = item[this.cellvalue_sales].Text;
                    TableCell item5 = item[this.cellvalue_sales];
                    str = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_sales].Text, "</div>" };
                    item5.Text = string.Concat(str);
                }
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                    item[this.cellvalue_contactname].ToolTip = item[this.cellvalue_contactname].Text;
                }
                if (this.flag_Header == "true")
                {
                    item[this.cellvalue_Header].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Header].Style.Add("cursor", "pointer");
                    TableCell tableCell5 = item[this.cellvalue_Header];
                    str = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Header].Text, "</div>" };
                    tableCell5.Text = string.Concat(str);
                }
                if (this.flag_footer == "true")
                {
                    item[this.cellvalue_footer].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_footer].Style.Add("cursor", "pointer");
                    TableCell item6 = item[this.cellvalue_footer];
                    str = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_footer].Text, "</div>" };
                    item6.Text = string.Concat(str);
                }
                if (this.flag_estTitle == "true")
                {
                    item[this.cellvalue_estTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estTitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_estTitle].ToolTip = item[this.cellvalue_estTitle].Text;
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customeraccountnumber].ToolTip = item[this.cellvalue_customeraccountnumber].Text;
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                    item[this.cellvalue_paymentterms].ToolTip = item[this.cellvalue_paymentterms].Text;
                }
                if (this.flag_comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_comments, "EstimateID");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                    item[this.cellvalue_referredby].ToolTip = item[this.cellvalue_referredby].Text;
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_costcentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_costcentre].Style.Add("cursor", "pointer");
                }
                if (this.flag_orderedfor == "true")
                {
                    item[this.cellvalue_orderedfor].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_orderedfor].Style.Add("cursor", "pointer");
                    item[this.cellvalue_orderedfor].ToolTip = item[this.cellvalue_orderedfor].Text;
                }
                if (this.flag_quantity1 == "true")
                {
                    item[this.cellvalue_quantity1].Attributes.Add("align", "right");
                    TableCell tableCell6 = item[this.cellvalue_quantity1];
                    str = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity1].Text, "</div>" };
                    tableCell6.Text = string.Concat(str);
                }
                if (this.flag_quantity2 == "true")
                {
                    item[this.cellvalue_quantity2].Attributes.Add("align", "right");
                    TableCell item7 = item[this.cellvalue_quantity2];
                    str = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity2].Text, "</div>" };
                    item7.Text = string.Concat(str);
                }
                if (this.flag_quantity3 == "true")
                {
                    item[this.cellvalue_quantity3].Attributes.Add("align", "right");
                    TableCell tableCell7 = item[this.cellvalue_quantity3];
                    str = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity3].Text, "</div>" };
                    tableCell7.Text = string.Concat(str);
                }
                if (this.flag_quantity4 == "true")
                {
                    item[this.cellvalue_quantity4].Attributes.Add("align", "right");
                    TableCell item8 = item[this.cellvalue_quantity4];
                    str = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity4].Text, "</div>" };
                    item8.Text = string.Concat(str);
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell8 = item[this.cellvalue_ItemStatus];
                    str = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    tableCell8.Text = string.Concat(str);
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
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
                ///modification By Bilal Stage 3
                if (this.flag_StockStage == "true")
                {
                    item[this.cellvalue_StockStage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_StockStage].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemAccCode == "true")
                {
                    item[this.cellvalue_ItemAccCode].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemAccCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemAccCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY == "true")
                {
                    item[this.cellvalue_ItemQTY].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemQTY].Style.Add("cursor", "pointer");
                }
                if (this.flag_MainItemSupplier == "true")
                {
                    item[this.cellvalue_MainItemSupplier].Attributes.Add("align", "left");
                    item[this.cellvalue_MainItemSupplier].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_MainItemSupplier].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_ExcTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_IncTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTaxValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMarkupValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_EventName == "true")
                {
                    item[this.cellvalue_EventName].Attributes.Add("align", "left");
                    item[this.cellvalue_EventName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_EventName].Style.Add("cursor", "pointer");
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("align", "left");
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_EventCodeNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("align", "center");
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CampaignSignNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_IsApproved == "true")
                {
                    item[this.cellvalue_IsApproved].Attributes.Add("align", "center");
                    item[this.cellvalue_IsApproved].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    if (item[this.cellvalue_IsApproved].Text == "Approved")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Green;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Awaiting Approval")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Orange;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Awaiting First Approval")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Orange;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Awaiting Second Approval")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Orange;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Rejected")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Red;
                    }
                    item[this.cellvalue_IsApproved].Style.Add("cursor", "pointer");
                }
                if (this.flag_EventVenue == "true")
                {
                    item[this.cellvalue_EventVenue].Attributes.Add("align", "left");
                    item[this.cellvalue_EventVenue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_EventVenue].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemMaterial == "true")
                {
                    item[this.cellvalue_ItemMaterial].Attributes.Add("align", "left");
                    item[this.cellvalue_ItemMaterial].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMaterial].Style.Add("cursor", "pointer");
                }
                if (this.flag_Height == "true")
                {
                    item[this.cellvalue_Height].Attributes.Add("align", "right");
                    item[this.cellvalue_Height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Height].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Height].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Height].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_Width == "true")
                {
                    item[this.cellvalue_Width].Attributes.Add("align", "right");
                    item[this.cellvalue_Width].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Width].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Width].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Width].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemDescription == "true")
                {
                    if (item[this.cellvalue_ItemDescription].Text != "")
                    {
                        item[this.cellvalue_ItemDescription].ToolTip = item[this.cellvalue_ItemDescription].Text;
                    }
                    if (item[this.cellvalue_ItemDescription].Text.Length > 60)
                    {
                        item[this.cellvalue_ItemDescription].Text = item[this.cellvalue_ItemDescription].Text.Substring(0, 50);
                    }
                    item[this.cellvalue_ItemDescription].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemDescription].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemColour == "true")
                {
                    item[this.cellvalue_ItemColour].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemColour].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemSize == "true")
                {
                    item[this.cellvalue_ItemSize].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemSize].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemArtwork == "true")
                {
                    item[this.cellvalue_ItemArtwork].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemArtwork].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemDelivery == "true")
                {
                    item[this.cellvalue_ItemDelivery].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemDelivery].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemFinishing == "true")
                {
                    item[this.cellvalue_ItemFinishing].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemFinishing].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemProofs == "true")
                {
                    item[this.cellvalue_ItemProofs].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProofs].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemPacking == "true")
                {
                    item[this.cellvalue_ItemPacking].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemPacking].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemNotes == "true")
                {
                    item[this.cellvalue_ItemNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemNotes].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    item[this.cellvalue_ItemTermsInstructions].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTermsInstructions].Style.Add("cursor", "pointer");
                }
                if (this.flag_OrderBy == "true")
                {
                    item[this.cellvalue_OrderBy].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_OrderBy].Style.Add("cursor", "pointer");
                }
                if (this.flag_Department == "true")
                {
                    item[this.cellvalue_Department].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Department].Style.Add("cursor", "pointer");
                }
                if (this.flag_CompamyEmail == "true")
                {
                    item[this.cellvalue_CompamyEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CompamyEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactEmail == "true")
                {
                    item[this.cellvalue_ContactEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ContactEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactPhone == "true")
                {
                    item[this.cellvalue_ContactPhone].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ContactPhone].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomerOrderNumber == "true")
                {
                    item[this.cellvalue_CustomerOrderNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomerOrderNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_PaymentType == "true")
                {
                    item[this.cellvalue_PaymentType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_PaymentType].Style.Add("cursor", "pointer");
                }
                if (this.flag_DeliveryDate == "true")
                {
                    item[this.cellvalue_DeliveryDate].Attributes.Add("align", "center");
                    item[this.cellvalue_DeliveryDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_DeliveryDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_FTPStatus == "true")
                {
                    if (item[this.cellvalue_FTPStatus].Text == "Successful")
                    {
                        item[this.cellvalue_FTPStatus].Style.Add("background-color", "#01DA66");
                    }
                    else if (item[this.cellvalue_FTPStatus].Text == "Fail")
                    {
                        item[this.cellvalue_FTPStatus].Style.Add("background-color", "#E64557");
                    }
                    else
                    {
                        item[this.cellvalue_FTPStatus].Text = "N/A";
                    }
                }

            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_orderno == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_orderno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_orderno)] != null && this.Session[string.Concat("order_", this.cellvalue_orderno)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_custname == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_custname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_custname)] != null && this.Session[string.Concat("order_", this.cellvalue_custname)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }
                if (this.flag_sales == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_sales].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_sales)] != null && this.Session[string.Concat("order_", this.cellvalue_sales)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_referredby == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_referredby].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_referredby)] != null && this.Session[string.Concat("order_", this.cellvalue_referredby)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }
                if (this.flag_orderstatus == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_orderstatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_orderstatus)] != null && this.Session[string.Concat("order_", this.cellvalue_orderstatus)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_AccountStatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_AccountStatus)] != null && this.Session[string.Concat("order_", this.cellvalue_AccountStatus)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_status)] != null && this.Session[string.Concat("order_", this.cellvalue_status)].ToString() == "")
                    {
                        textBox6.Text = "";
                    }
                }
                if (this.flag_estTitle == "true")
                {
                    TextBox textBox7 = (e.Item as GridFilteringItem)[this.cellvalue_estTitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_estTitle)] != null && this.Session[string.Concat("order_", this.cellvalue_estTitle)].ToString() == "")
                    {
                        textBox7.Text = "";
                    }
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    TextBox textBox8 = (e.Item as GridFilteringItem)[this.cellvalue_customeraccountnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_customeraccountnumber)] != null && this.Session[string.Concat("order_", this.cellvalue_customeraccountnumber)].ToString() == "")
                    {
                        textBox8.Text = "";
                    }
                }
                if (this.flag_paymentterms == "true")
                {
                    TextBox item9 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("order_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        item9.Text = "";
                    }
                }
                if (this.flag_comments == "true")
                {
                    TextBox textBoxComments = (e.Item as GridFilteringItem)[this.cellvalue_comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_comments)] != null && this.Session[string.Concat("order_", this.cellvalue_comments)].ToString() == "")
                    {
                        textBoxComments.Text = "";
                    }
                }
                if (this.flag_costcentre == "true")
                {
                    TextBox textBox9 = (e.Item as GridFilteringItem)[this.cellvalue_costcentre].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_costcentre)] != null && this.Session[string.Concat("order_", this.cellvalue_costcentre)].ToString() == "")
                    {
                        textBox9.Text = "";
                    }
                }
                if (this.flag_estval == "true")
                {
                    gridFilteringItem[this.cellvalue_estval].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item10 = (e.Item as GridFilteringItem)[this.cellvalue_estval].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_estval)] != null && this.Session[string.Concat("order_", this.cellvalue_estval)].ToString() == "")
                    {
                        item10.Text = "";
                    }
                }
                if (this.flag_estvalExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_estvalExcGst].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox10 = (e.Item as GridFilteringItem)[this.cellvalue_estvalExcGst].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_estvalExcGst)] != null && this.Session[string.Concat("order_", this.cellvalue_estvalExcGst)].ToString() == "")
                    {
                        textBox10.Text = "";
                    }
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item11 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_createddate)] != null && this.Session[string.Concat("order_", this.cellvalue_createddate)].ToString() == "")
                    {
                        item11.Text = "";
                    }
                }
                if (this.flag_estdate == "true")
                {
                    gridFilteringItem[this.cellvalue_estdate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox11 = (e.Item as GridFilteringItem)[this.cellvalue_estdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_estdate)] != null && this.Session[string.Concat("order_", this.cellvalue_estdate)].ToString() == "")
                    {
                        textBox11.Text = "";
                    }
                }
                if (this.flag_validfor == "true")
                {
                    gridFilteringItem[this.cellvalue_validfor].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_validfor].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_validfor)] != null && this.Session[string.Concat("order_", this.cellvalue_validfor)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_IsApproved == "true")
                {
                    TextBox textBox12 = (e.Item as GridFilteringItem)[this.cellvalue_IsApproved].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_IsApproved)] != null && this.Session[string.Concat("order_", this.cellvalue_IsApproved)].ToString() == "")
                    {
                        textBox12.Text = "";
                    }
                }
                if (this.flag_ItemTitle == "true")
                {
                    TextBox item13 = (e.Item as GridFilteringItem)[this.cellvalue_ItemTitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemTitle)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemTitle)].ToString() == "")
                    {
                        item13.Text = "";
                    }
                }

                if (this.flag_SinceEmailed == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceEmailed].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_SinceEmailed)] != null && this.Session[string.Concat("order_", this.cellvalue_SinceEmailed)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_SinceStatusUpdate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceStatusUpdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_SinceStatusUpdate)] != null && this.Session[string.Concat("order_", this.cellvalue_SinceStatusUpdate)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                ///modification By Bilal Stage 3
                if (this.flag_StockStage == "true")
                {
                    TextBox item23 = (e.Item as GridFilteringItem)[this.cellvalue_StockStage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_StockStage)] != null && this.Session[string.Concat("order_", this.cellvalue_StockStage)].ToString() == "")
                    {
                        item23.Text = "";
                    }
                }
                if (this.flag_OrderBy == "true")
                {
                    TextBox textBox13 = (e.Item as GridFilteringItem)[this.cellvalue_OrderBy].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_OrderBy)] != null && this.Session[string.Concat("order_", this.cellvalue_OrderBy)].ToString() == "")
                    {
                        textBox13.Text = "";
                    }
                }
                if (this.flag_orderedfor == "true")
                {
                    TextBox item14 = (e.Item as GridFilteringItem)[this.cellvalue_orderedfor].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_orderedfor)] != null && this.Session[string.Concat("order_", this.cellvalue_orderedfor)].ToString() == "")
                    {
                        item14.Text = "";
                    }
                }
                if (this.flag_PaymentType == "true")
                {
                    TextBox textBox14 = (e.Item as GridFilteringItem)[this.cellvalue_PaymentType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_PaymentType)] != null && this.Session[string.Concat("order_", this.cellvalue_PaymentType)].ToString() == "")
                    {
                        textBox14.Text = "";
                    }
                }
                if (this.flag_CustomerOrderNumber == "true")
                {
                    TextBox item15 = (e.Item as GridFilteringItem)[this.cellvalue_CustomerOrderNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_CustomerOrderNumber)] != null && this.Session[string.Concat("order_", this.cellvalue_CustomerOrderNumber)].ToString() == "")
                    {
                        item15.Text = "";
                    }
                }
                if (this.flag_ItemQTY == "true")
                {
                    TextBox textBox15 = (e.Item as GridFilteringItem)[this.cellvalue_ItemQTY].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemQTY)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemQTY)].ToString() == "")
                    {
                        textBox15.Text = "";
                    }
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    TextBox item16 = (e.Item as GridFilteringItem)[this.cellvalue_ItemValue_ExcTax].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemValue_ExcTax)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemValue_ExcTax)].ToString() == "")
                    {
                        item16.Text = "";
                    }
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    TextBox textBox16 = (e.Item as GridFilteringItem)[this.cellvalue_ItemValue_IncTax].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemValue_IncTax)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemValue_IncTax)].ToString() == "")
                    {
                        textBox16.Text = "";
                    }
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    TextBox item17 = (e.Item as GridFilteringItem)[this.cellvalue_ItemTaxValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemTaxValue)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemTaxValue)].ToString() == "")
                    {
                        item17.Text = "";
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    TextBox textBox17 = (e.Item as GridFilteringItem)[this.cellvalue_ItemCostPriceExcMarkup].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemCostPriceExcMarkup)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemCostPriceExcMarkup)].ToString() == "")
                    {
                        textBox17.Text = "";
                    }
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_ItemMarkupValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemMarkupValue)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemMarkupValue)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    TextBox textBox18 = (e.Item as GridFilteringItem)[this.cellvalue_ItemCostPriceIncMarkup].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemCostPriceIncMarkup)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemCostPriceIncMarkup)].ToString() == "")
                    {
                        textBox18.Text = "";
                    }
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    TextBox item19 = (e.Item as GridFilteringItem)[this.cellvalue_ItemProfitMarginPercentage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemProfitMarginPercentage)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemProfitMarginPercentage)].ToString() == "")
                    {
                        item19.Text = "";
                    }
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    TextBox textBox19 = (e.Item as GridFilteringItem)[this.cellvalue_ItemProfitMarginValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemProfitMarginValue)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemProfitMarginValue)].ToString() == "")
                    {
                        textBox19.Text = "";
                    }
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_ItemGrossProfitPercentage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemGrossProfitPercentage)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemGrossProfitPercentage)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    TextBox textBox20 = (e.Item as GridFilteringItem)[this.cellvalue_ItemGrossProfitValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemGrossProfitValue)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemGrossProfitValue)].ToString() == "")
                    {
                        textBox20.Text = "";
                    }
                }
                if (this.flag_Height == "true")
                {
                    TextBox item21 = (e.Item as GridFilteringItem)[this.cellvalue_Height].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_Height)] != null && this.Session[string.Concat("order_", this.cellvalue_Height)].ToString() == "")
                    {
                        item21.Text = "";
                    }
                }
                if (this.flag_Width == "true")
                {
                    TextBox textBox21 = (e.Item as GridFilteringItem)[this.cellvalue_Width].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_Width)] != null && this.Session[string.Concat("order_", this.cellvalue_Width)].ToString() == "")
                    {
                        textBox21.Text = "";
                    }
                }
                if (this.flag_ItemSize == "true")
                {
                    TextBox item22 = (e.Item as GridFilteringItem)[this.cellvalue_ItemSize].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_ItemSize)] != null && this.Session[string.Concat("order_", this.cellvalue_ItemSize)].ToString() == "")
                    {
                        item22.Text = "";
                    }
                }
                if (this.flag_DeliveryDate == "true")
                {
                    gridFilteringItem[this.cellvalue_DeliveryDate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox22 = (e.Item as GridFilteringItem)[this.cellvalue_DeliveryDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("order_", this.cellvalue_DeliveryDate)] != null && this.Session[string.Concat("order_", this.cellvalue_DeliveryDate)].ToString() == "")
                    {
                        textBox22.Text = "";
                    }
                }
                if (this.flag_quantity1 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity2 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity3 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity4 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_MainItemSupplier == "true")
                {
                    gridFilteringItem[this.cellvalue_MainItemSupplier].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_ItemAccCode == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemAccCode].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_EventName == "true")
                {
                    gridFilteringItem[this.cellvalue_EventName].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    gridFilteringItem[this.cellvalue_EventCodeNumber].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    gridFilteringItem[this.cellvalue_CampaignSignNumber].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_IsApproved == "true")
                {
                    gridFilteringItem[this.cellvalue_IsApproved].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_ItemMaterial == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMaterial].HorizontalAlign = HorizontalAlign.Left;
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
                Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
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
            this.objBase.ReturnRoles_Privileges_Tabs("webstoreorder", "isview", "");
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.lblArchive.Text = this.objLanguage.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.lblUnArchive.Text = this.objLanguage.GetLanguageConversion("UnArchive_Selected");
            this.divunarchive.Style.Add("display", "none");
            if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divDelete.Visible = true;
            }
            else
            {
                this.divDelete.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
            }
            try
            {
                string str = base.Request.UrlReferrer.ToString();
                this.objBase.ReturnRoles_Privileges_Tabs("webstoreorder", "isview", str);
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
                this.editOrderViewID.Value = "";
            }
            for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridView1.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            global.pageName = "webstoreorder";
            this.gloobj.setpagename("webstoreorder");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "webstoreorder";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            base.Title = this.objLanguage.convert(global.pageTitle("eStore View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_view")));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            string str1 = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "webstoreorder_view");
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            if (str1 != "" && str1 != null)
            {
                this.defaultviewid = Convert.ToInt32(str1);
            }
            if (this.Session["OrdViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["OrdViewID"]);
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            order_view.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            if (order_view.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (!base.IsPostBack)
            {
                this.GridView1.PageSize = 50;
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
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str2 = string.Concat(this.pg, this.UserID, this.pg);
                this.Session["search_ord"] = null;
                this.Session[str2] = null;
            }
            int num3 = 0;
            num3 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            this.RecordsToDisplay = EstimatesBasePage.Views_RecordsToDisplay((long)this.defaultviewid);
            if (this.RecordsToDisplay.ToLower().ToString() == "live")
            {
                this.divunarchive.Style.Add("display", "none");
                this.divarchive.Style.Add("display", "block");
            }
            else if (this.RecordsToDisplay.ToLower().ToString() == "archive")
            {
                this.divunarchive.Style.Add("display", "block");
                this.divarchive.Style.Add("display", "none");
            }
            else if (this.RecordsToDisplay.ToLower().ToString() == "all")
            {
                this.divunarchive.Style.Add("display", "block");
                this.divarchive.Style.Add("display", "block");
            }
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, "webstoreorder");
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
                order_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    order_view.SortedBy = "OrderNumber";
                }
                else
                {
                    order_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    order_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    order_view.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            try
            {
                if (base.Request.QueryString["custom"] != null)
                {
                    string empty = string.Empty;
                    empty = base.Request.QueryString["custom"].ToString().Trim();
                    if (empty != "")
                    {
                        empty = base.ReplaceSingleQuote(empty);
                        this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, "customerid", "desc", empty);
                    }
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                string str3 = "";
                this.GridStateLoad();
                if (this.Session["search_ord"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_ord"];
                    str3 = this.FilterFunction(item);
                }
                order_view.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                this.GridView1.PageSize = order_view.PageSize;
                this.Session["OrdViewID"] = this.defaultviewid;
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, order_view.SortedBy, order_view.sortdirection, str3);
                this.GridStateLoad();
                this.GridView1.Rebind();
            }
            //if (!IsPostBack && this.IsGrouping)
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridView1, this.GroupByColumn);
            //}

            var column = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("SinceStatusCount");
            if (column != null)
            {
                column.Visible = false;
            }
            var column2 = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("SinceEmailCount");
            if (column2 != null)
            {
                column2.Visible = false;
            }
            var column3 = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("isAnyEmailed");
            if (column3 != null)
            {
                column3.Visible = false;
            }
            //if (this.GridView1.MasterTableView.GetColumn("SinceEmailCount") != null)
            //{
            //    this.GridView1.MasterTableView.GetColumn("SinceEmailCount").Visible = false;
            //}

            try
            {
                this.GridView1.MasterTableView.GetColumn("orderid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("custid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("iscompletlyconvertedtojob").Visible = false;
                this.GridView1.MasterTableView.GetColumn("estimateitemid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("isarchived").Visible = false;
                this.GridView1.MasterTableView.GetColumn("isdeletedjob").Visible = false;
                this.GridView1.MasterTableView.GetColumn("BackORder").Visible = false;
                this.GridView1.MasterTableView.GetColumn("HasReplenishItem").Visible = false;
                this.GridView1.MasterTableView.GetColumn("JOBID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsAccountOnHold").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsStockProduct").Visible = false;
                this.GridView1.MasterTableView.GetColumn("StatusColorCode").Visible = false;
            }
            catch (Exception exception)
            {
            }
            item_progress_to_job_from_order_view usercontrolItemItemSummaryProgressToJob = (item_progress_to_job_from_order_view)base.LoadControl("~/usercontrol/Item/item_progress_to_job_from_order_view.ascx");
            usercontrolItemItemSummaryProgressToJob.ID = "UcProgressToJob";
            //usercontrolItemItemSummaryProgressToJob.EstimateID = this.EstimateID;
            //usercontrolItemItemSummaryProgressToJob.Module = this.Module;
            //usercontrolItemItemSummaryProgressToJob.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
            //usercontrolItemItemSummaryProgressToJob.modulename = this.modulename;
            //usercontrolItemItemSummaryProgressToJob.submodulename = this.submodulename;
            //usercontrolItemItemSummaryProgressToJob.MainType = this.MainType;
            this.plhProgressToJob.Controls.Add(usercontrolItemItemSummaryProgressToJob);
            //item_progress_to_job_from_order_view usercontrolItemItemSummaryProgressToJob = (item_progress_to_job_from_order_view)base.LoadControl("~/usercontrol/Item/item_progress_to_job_from_order_view.ascx");
            //usercontrolItemItemSummaryProgressToJob.ID = "UcProgressToJob";
            ////usercontrolItemItemSummaryProgressToJob.EstimateID = this.EstimateID;
            ////usercontrolItemItemSummaryProgressToJob.Module = this.Module;
            ////usercontrolItemItemSummaryProgressToJob.Check_SpecialPrivilege = this.Check_SpecialPrivilege;
            ////usercontrolItemItemSummaryProgressToJob.modulename = this.modulename;
            ////usercontrolItemItemSummaryProgressToJob.submodulename = this.submodulename;
            ////usercontrolItemItemSummaryProgressToJob.MainType = this.MainType;
            //this.plhProgressToJob.Controls.Add(usercontrolItemItemSummaryProgressToJob);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (base.Request.UserAgent.Contains("AppleWebKit"))
            {
                base.Request.Browser.Adapters.Clear();
            }
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Notes note = new Notes();
            notesclass _notesclass = new notesclass();
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            int num = Convert.ToInt16(this.RadListBox1.SelectedValue);
            string[] strArrays = this.hdnSelectedChkfrmGrid.Value.Split(new char[] { ',' });
            string empty = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str1 = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                empty = string.Concat(empty, str1.Split(chrArray)[0].ToString(), ',');
                string str2 = strArrays[i];
                char[] chrArray1 = new char[] { '\u005F' };
                str = string.Concat(str, str2.Split(chrArray1)[2].ToString(), ',');
            }
            this.RadListBox1.ClearSelection();
            string str3 = "order";
            if (!(str != "") || num == 0 || !this.IsItemSelected)
            {
                if (empty != "" && num != 0)
                {
                    OrderBasePage.OrderOnCheck_Status_Update(this.CompanyID, empty, num, str3);
                    string[] strArrays1 = empty.Split(new char[] { ',' });
                    for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                    {
                        string empty1 = string.Empty;
                        string empty2 = string.Empty;
                        DataTable dataTable = OrderBasePage.Order_select(this.CompanyID, (long)Convert.ToInt32(strArrays1[j].ToString()));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            empty1 = row["StatusTitle"].ToString();
                            empty2 = row["OrderNo"].ToString();
                        }
                        _notesclass.Status_name = empty1;
                        _notesclass.Invoice_number = empty2;
                        _notesclass.ModuleName = "webstoreorder";
                        _notesclass.NotesType = Convert.ToString(Notes.NotesType.OrdChangeStatus);
                        this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                        _notesclass.ModuleID = (long)Convert.ToInt32(strArrays1[j].ToString());
                        _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        commonClass _commonClass = this.objJava;
                        DateTime now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        _notesclass.CompanyID = this.CompanyID;
                        _notesclass.UserID = this.UserID;
                        note.NotesAdd(_notesclass);

                        DataTable dt = EstimatesBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, (long)Convert.ToInt32(strArrays1[j].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["EstimateType"].ToString() == "X")
                                {
                                    if (commonClass.CheckFTPEnable())
                                    {
                                        string filePath = string.Empty;
                                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                                        var product = settings.FirstOrDefault(s => s.SectionName == "OnlineOrder");
                                        int _statusID = product.StatusValue;
                                        if (_statusID == num)
                                        {
                                            long priceCatalogurID = Convert.ToInt64(dr["PriceCatalogueID"].ToString());
                                            //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                                            DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                                            if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                                            {
                                                //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                                                if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                                                {
                                                    DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                    object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                                    //object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                                    filePath = string.Concat(secureDocEditablePath);
                                                }
                                                else
                                                {
                                                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                                }
                                                commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "OrderStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                            }
                                        }
                                    }

                                }

                            }

                        }
                    }
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                    this.hdnSelectedChkfrmGrid.Value = "";
                    this.GridView1.Rebind();
                }
                return;
            }
            EstimatesBasePage.EstimateItemsOnCheck_Status_Update(this.CompanyID, str, num, str3);
            string[] strArrays2 = str.Split(new char[] { ',' });
            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
            {
                string empty3 = string.Empty;
                long num1 = (long)0;
                string empty4 = string.Empty;
                DataTable dataTable1 = OrderBasePage.Order_select_Summary_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays2[k].ToString()));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    empty3 = dataRow["OrderStatusName"].ToString();
                    empty4 = dataRow["OrderItemNumber"].ToString();
                    num1 = Convert.ToInt64(dataRow["ModuleID"]);
                }
                _notesclass.Invoice_number = empty4;
                _notesclass.Status_name = empty3;
                _notesclass.ModuleName = "webstoreorder";
                _notesclass.NotesType = Convert.ToString(Notes.NotesType.OrdChangeStatus);
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                _notesclass.ModuleID = num1;
                _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                _notesclass.CompanyID = this.CompanyID;
                _notesclass.UserID = this.UserID;
                _notesclass.ItemID = (long)Convert.ToInt32(strArrays2[k].ToString());
                note.NotesAdd(_notesclass);

                string itemType = EstimatesBasePage.GetEstimateType_EstimateItemID((long)Convert.ToInt32(strArrays2[k].ToString()));
                if (itemType == "X")
                {
                    if (commonClass.CheckFTPEnable())
                    {
                        string filePath = string.Empty;
                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                        var product = settings.FirstOrDefault(s => s.SectionName == "OnlineOrder");
                        int _statusID = product.StatusValue;
                        if (_statusID == num)
                        {
                            long priceCatalogurID = EstimatesBasePage.GetPriceCatalogueIDByEstimateItemID((long)Convert.ToInt32(strArrays2[k].ToString()));
                            //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                            DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                            if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                            {
                                //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                                if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                                {
                                    DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(strArrays2[k].ToString()));
                                    object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                    //object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                    filePath = string.Concat(secureDocEditablePath);
                                }
                                else
                                {
                                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                }
                                commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "OrderStatus", "OnlineOrder", Convert.ToInt64(strArrays2[k].ToString()));
                            }
                        }
                    }

                }
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
            this.hdnSelectedChkfrmGrid.Value = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

            this.GridView1.Rebind();
        }

        public new void SetDDLValue(DropDownList ddl, string value)
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

        private string getErrorCount(int estimateid)
        {


            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_GetErrorCountForOrder");


            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, Convert.ToInt64(estimateid));

            dataSet = database.ExecuteDataSet(storedProcCommand);


            DataRow dr = dataSet.Tables[0].Rows[0];

            string errorCount = dr["ErrorCount"].ToString();


            return errorCount;
        }
    }
}
