using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using System.Linq;

namespace ePrint.Delivery
{
    public partial class delivery_view : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private commonClass cmnClass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public int CompanyID;

        public int UserID;

        private string para = "";

        public int totalrec;

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        private createViewClass objCreateView = new createViewClass();

        public int defaultviewid;

        public string cellvalue_createddate = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_deliverydate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string cellvalue_posted = string.Empty;

        public string flag_posted = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string cellvalue_deliveryaddress = string.Empty;

        public string cellvalue_addresslabel = string.Empty;

        public string cellvalue_estimatenumber = string.Empty;

        public string flag_customername = string.Empty;

        public string flag_deliveryaddress = string.Empty;

        public string flag_addresslabel = string.Empty;

        public string flag_estimatenumber = string.Empty;

        public string cellvalue_consignmentnotenumber = string.Empty;

        public string flag_consignmentnotenumber = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_jobnumber = string.Empty;

        public string flag_jobnumber = string.Empty;

        public string cellvalue_customerordernumber = string.Empty;

        public string flag_customerordernumber = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_jobtitle = string.Empty;

        public string flag_comments = string.Empty;

        public string cellvalue_comments = string.Empty;

        public string flag_jobtitle = string.Empty;

        public string cellvalue_accountingcode = string.Empty;

        public string flag_accountingcode = string.Empty;

        public string cellvalue_deliveryno = string.Empty;

        public string flag_deliveryno = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;

        public DataTable dt = new DataTable();

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string pg;

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public static int PageSize;

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long DeliveryStatusID;

        public string ServerName = string.Empty;

        public languageClass objLangClass = new languageClass();

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

        static delivery_view()
        {
            delivery_view.WhereCondition = string.Empty;
            delivery_view.sortdirection = string.Empty;
            delivery_view.SortedBy = string.Empty;
            delivery_view.PageSize = 50;
        }

        public delivery_view()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewDelivery.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    //if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    //{
                    //    this.GridViewDelivery.MasterTableView.Columns.Remove(gridBoundColumn);

                    //   GridTemplateColumn commentColumn = new GridTemplateColumn();
                    //  commentColumn.UniqueName = dt.Columns[i].ColumnName;
                    //  commentColumn.HeaderText = "Comments";
                    //  commentColumn.ItemTemplate = new CommentsTemplate();
                    // gv.MasterTableView.Columns.Add(commentColumn);
                    // }
                }
                for (int j = 1; j < this.GridViewDelivery.Columns.Count; j++)
                {
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewDelivery.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "deliverynumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                        this.cellvalue_deliveryno = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_deliveryno = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Name").ToString();
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "orderno")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Order_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(13);
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "posted")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Posted").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(6);
                        this.flag_posted = "true";
                        this.cellvalue_posted = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "status")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("status").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "jobnumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }



                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Default Template";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Archive";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Choose Template";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ChooseTemplate = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }

                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Download Default Template";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DownloadTemplate = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }


                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "consignmentnumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Consignment_Note_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(15);
                        this.flag_consignmentnotenumber = "true";
                        this.cellvalue_consignmentnotenumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Date").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.cellvalue_deliverydate = this.GridViewDelivery.Columns[j].SortExpression;
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Created_On").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.cellvalue_createddate = this.GridViewDelivery.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customdate1")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate1 = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate1 = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customdate2")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate2 = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate2 = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customdate3")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate3 = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate3 = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customdate4")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate4 = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate4 = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customdate5")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate5 = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate5 = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridViewDelivery.Columns[j].Visible = false;
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridViewDelivery.Columns[j].Visible = false;
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Payment_Terms").ToString();
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "jobtitle")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title").ToString();
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Comments").ToString();
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "accountingcode")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Accounting_Code").ToString();
                        this.flag_accountingcode = "true";
                        this.cellvalue_accountingcode = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "deliveryaddress")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Delivery Address";
                        this.flag_deliveryaddress = "true";
                        this.cellvalue_deliveryaddress = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Status Days";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceStatusUpdate = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_SinceStatusUpdate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Email Days";
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceEmailed = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                        this.flag_SinceEmailed = "true";
                    }
                    // AddressLabel
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "addresslabel")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Address Label";
                        this.flag_addresslabel = "true";
                        this.cellvalue_addresslabel = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = "Estimate No./Order No.";
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                        this.flag_estimatenumber = "true";
                        this.cellvalue_estimatenumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                }
            }


            for (int j = 0; j < this.GridViewDelivery.Columns.Count; j++)
            {


                if (this.GridViewDelivery.Columns[j].UniqueName.ToLower() == "defaulttemplate")
                {
                    this.GridViewDelivery.Columns[j].HeaderText = "Default Template";
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DefaultTemplate = this.GridViewDelivery.Columns[j].UniqueName.ToLower();
                    this.flag_DefaultTemplate = "true";
                }

                else if (this.GridViewDelivery.Columns[j].UniqueName.ToLower() == "choosetemplate")
                {
                    this.GridViewDelivery.Columns[j].HeaderText = "Choose Template";
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_ChooseTemplate = this.GridViewDelivery.Columns[j].UniqueName.ToLower();
                    this.flag_ChooseTemplate = "true";
                }

                else if (this.GridViewDelivery.Columns[j].UniqueName.ToLower() == "downloadtemplate")
                {
                    this.GridViewDelivery.Columns[j].HeaderText = "Download Default Template";
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DownloadTemplate = this.GridViewDelivery.Columns[j].UniqueName.ToLower();
                    this.flag_DownloadTemplate = "true";
                }

                else if (this.GridViewDelivery.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridViewDelivery.Columns[j].HeaderText = "Archive";
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
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
                    string deliveryId = DataBinder.Eval(item.DataItem, "DeliveryID").ToString();
                    hlEditComment.Attributes["onclick"] = $"openCommentPopup('{deliveryId}', '{hlEditComment.Text}'); return false;";
                };
                container.Controls.Add(hlEditComment);
            }
        }
        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string newComment = hiddenCommentText.Value;
            int commentId = int.Parse(hiddenCommentId.Value);

            UpdateCommentInDatabase(commentId, newComment);

            GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, this.GridViewDelivery.CurrentPageIndex + 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, this.para);
            this.GridViewDelivery.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "Delivery/delivery_view.aspx"));
        }


        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            DeliveryBasePage.Delivery_Comments_Update(commentId, newComment);
        }

        public void bindRadlistStatus()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "delivery");
            this.RadListBox1.DataSource = dataTable;
            this.RadListBox1.DataTextField = "StatusTitle";
            this.RadListBox1.DataValueField = "StatusID";
            this.RadListBox1.DataBind();
        }

        public void btnEditViewDelivery_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../delivery/customviewdelivery.aspx?type=edit&id=", this.editDeliveryViewID.Value, "&cid=", this.CompanyID };
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
                this.Session[string.Concat("delivery_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("delivery_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            delivery_view.WhereCondition = "";
            this.Session["search_del"] = null;
            foreach (GridColumn column in this.GridViewDelivery.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridViewDelivery.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
            this.GridViewDelivery.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpCookie httpCookie = new HttpCookie("ckeEditviewID_Delivery");
            httpCookie["Delivery_viewID"] = this.ddl_View.SelectedValue;
            base.Response.Cookies.Add(httpCookie);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "Delivery/delivery_view.aspx?viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
        }

        public string DeliveryItem_StausChanges_CheckAndUpdate(string DeliveryIDs, int StatusID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            int num1 = 0;
            bool flag = false;
            long num2 = (long)0;
            long num3 = (long)0;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            DeliveryIDs = DeliveryIDs.Substring(0, DeliveryIDs.Length - 1);
            string[] strArrays = DeliveryIDs.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str2 = strArrays[i];
                if (this.Session["ProductStockManagement"] == null)
                {
                    empty = "true";
                }
                else if (this.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
                {
                    if (StatusID.ToString() != ConnectionClass.DeliveryStatusID.ToString())
                    {
                        empty = "true";
                    }
                    else
                    {
                        this.Session["Counter"] = null;
                        int num4 = 0;
                        DataTable dataTable = DeliveryBasePage.deliveryitem_select(this.CompanyID, Convert.ToInt64(str2));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            num3 = Convert.ToInt64(row["DeliveryItemID"].ToString());
                            str1 = row["DeliveryNumber"].ToString();
                            Convert.ToInt64(row["ItemID"].ToString());
                            string str3 = row["ItemType"].ToString();
                            string str4 = row["Quantity"].ToString();
                            row["Description"].ToString();
                            empty2 = row["status"].ToString();
                            if (!(str3.ToLower() == "c") && !(str3.ToLower() == "x"))
                            {
                                continue;
                            }
                            if (empty2 == StatusID.ToString())
                            {
                                empty = string.Concat(empty, "false");
                            }
                            else
                            {
                                BaseClass baseClass = new BaseClass();
                                foreach (DataRow dataRow in baseClass.StockReductionForDeliveryItemNew(num3).Rows)
                                {
                                    num2 = Convert.ToInt64(dataRow["PriceCatalogueID"].ToString());
                                    long num5 = Convert.ToInt64(dataRow["EstimateItemID"].ToString());
                                    str = dataRow["DrawStockFrom"].ToString();
                                    num = Convert.ToInt32(dataRow["Quantity"].ToString());
                                    num1 = Convert.ToInt32(this.objBase.ReplaceSingleQuote(str4));
                                    bool flag1 = false;
                                    bool flag2 = false;
                                    if (str.Trim().ToLower() == "o")
                                    {
                                        str = "s";
                                        flag2 = true;
                                    }
                                    bool flag3 = false;
                                    if (str3.ToLower() == "x")
                                    {
                                        flag3 = Convert.ToBoolean(dataRow["IsstockReplenish"]);
                                    }
                                    if (str.ToLower() == "s" || str.ToLower() == "o" || str.ToLower() == "a" || str.ToLower() == "m")
                                    {
                                        if (str.ToLower() == "s")
                                        {
                                            if (str3.ToLower() == "x" && flag3.ToString().ToLower() == "true")
                                            {
                                                flag1 = true;
                                            }
                                            else if (str3.ToLower() == "x" && flag3.ToString().ToLower() != "true")
                                            {
                                                flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("self¶", num3.ToString()), num1, num, num5, flag2);
                                            }
                                            else if (str3.ToLower() == "c")
                                            {
                                                flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("self¶", num3.ToString()), num1, num, num5, flag2);
                                            }
                                        }
                                        else if (str.ToLower() == "o")
                                        {
                                            this.Session["Counter"] = num4.ToString();
                                            num4++;
                                            if (str3.ToLower() == "x" && flag3.ToString().ToLower() == "true")
                                            {
                                                flag1 = true;
                                            }
                                            else if (str3.ToLower() == "x" && flag3.ToString().ToLower() != "true")
                                            {
                                                flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, (long)0, num2, string.Concat("other¶", num3.ToString()), num1, num, num5, flag2);
                                            }
                                            else if (str3.ToLower() == "c")
                                            {
                                                flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, (long)0, num2, string.Concat("other¶", num3.ToString()), num1, num, num5, flag2);
                                            }
                                        }
                                        else if (str.ToLower() != "a")
                                        {
                                            if (str.ToLower() == "m")
                                            {
                                                if (str3.ToLower() == "x" && flag3.ToString().ToLower() == "true")
                                                {
                                                    flag1 = true;
                                                }
                                                else if (str3.ToLower() == "x" && flag3.ToString().ToLower() != "true")
                                                {
                                                    flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("multiple¶", num3.ToString()), num1, num, num5, flag2);
                                                }
                                                else if (str3.ToLower() == "c")
                                                {
                                                    flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("multiple¶", num3.ToString()), num1, num, num5, flag2);
                                                }
                                            }
                                        }
                                        else if (str3.ToLower() == "x" && flag3.ToString().ToLower() == "true")
                                        {
                                            flag1 = true;
                                        }
                                        else if (str3.ToLower() == "x" && flag3.ToString().ToLower() != "true")
                                        {
                                            flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("additional option¶", num3.ToString()), num1, num, num5, flag2);
                                        }
                                        else if (str3.ToLower() == "c")
                                        {
                                            flag1 = baseClass.IsDeliveryItemStatusChanges((long)this.CompanyID, num2, (long)0, string.Concat("additional option¶", num3.ToString()), num1, num, num5, flag2);
                                        }
                                        if (!flag1)
                                        {
                                            empty = string.Concat(empty, "false");
                                        }
                                        else
                                        {
                                            empty = string.Concat(empty, "true,");
                                            if (this.Session["IsUpdateKingsQty"] == null)
                                            {
                                                flag = false;
                                            }
                                            else
                                            {
                                                if (this.Session["IsUpdateKingsQty"].ToString() != "true")
                                                {
                                                    continue;
                                                }
                                                flag = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        empty = string.Concat(empty, "true");
                                    }
                                }
                            }
                        }
                    }
                }
                if (!empty.Contains("false"))
                {
                    DeliveryBasePage.DeliveryOnCheck_Status_Update(this.CompanyID, str2, StatusID, "DeliveryNote");
                    if (flag)
                    {
                        if (str.ToLower() == "o")
                        {
                            this.objBase.UpdateKingsQtySent(num2, num);
                        }
                        else if (str.ToLower() != "m")
                        {
                            this.objBase.UpdateKingsQtySent(num2, num1);
                        }
                        else if (this.Session["PriceCatalogueID_othermultiple"] != null)
                        {
                            this.objBase.UpdateKingsQtySent(Convert.ToInt64(this.Session["PriceCatalogueID_othermultiple"].ToString()), num);
                        }
                    }
                }
                else
                {
                    empty1 = string.Concat(empty1, str1, ",");
                }
            }
            return empty1;
        }

        public string DeliveryItem_Stock_Reduction(string DeliveryIDs, int StatusID)
        {
            string empty = string.Empty;
            if (this.Session["ProductStockManagement"] != null && this.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
            {
                BaseClass baseClass = new BaseClass();
                string str = string.Empty;
                if (baseClass.Return_StockManagementSettings("SR_WhenStockReduced") == "d" && baseClass.Return_StockManagementSettings("SR_JobStatusID") == StatusID.ToString())
                {
                    DeliveryIDs = DeliveryIDs.Substring(0, DeliveryIDs.Length - 1);
                    string[] strArrays = DeliveryIDs.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        string str1 = strArrays[i];
                        this.Session["CounterKit"] = null;
                        int num = 0;
                        string empty1 = string.Empty;
                        this.hdn_KitStockValues.Value = "";
                        string empty2 = string.Empty;
                        DataTable dataTable = DeliveryBasePage.deliveryitem_select(this.CompanyID, Convert.ToInt64(str1));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            long num1 = Convert.ToInt64(row["DeliveryItemID"].ToString());
                            Convert.ToInt64(row["ItemID"].ToString());
                            string str2 = row["ItemType"].ToString();
                            string str3 = row["Quantity"].ToString();
                            row["Description"].ToString();
                            empty2 = row["DeliveryNumber"].ToString();
                            string empty3 = string.Empty;
                            if (!(str2.ToLower() == "c") && !(str2.ToLower() == "x"))
                            {
                                continue;
                            }
                            foreach (DataRow dataRow in baseClass.StockReductionForDeliveryItem(num1).Rows)
                            {
                                long num2 = Convert.ToInt64(dataRow["PriceCatalogueID"].ToString());
                                long num3 = Convert.ToInt64(dataRow["PriceCatalogueID2"].ToString());
                                long num4 = Convert.ToInt64(dataRow["EstimateItemID"].ToString());
                                string str4 = dataRow["DrawStockFrom"].ToString();
                                int num5 = Convert.ToInt32(dataRow["Quantity"].ToString());
                                int num6 = Convert.ToInt32(this.objBase.ReplaceSingleQuote(str3));
                                bool flag = false;
                                if (str2.ToLower() == "x")
                                {
                                    flag = Convert.ToBoolean(dataRow["IsstockReplenish"]);
                                }
                                if (str4.ToLower() != "s" && str4.ToLower() != "a" && str4.ToLower() != "m")
                                {
                                    if (str4.ToLower() != "o")
                                    {
                                        continue;
                                    }
                                    this.Session["CounterKit"] = num.ToString();
                                    num++;
                                    string str5 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                                    string str6 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                    if (!(str2.ToLower() == "x") || !(flag.ToString().ToLower() != "true"))
                                    {
                                        baseClass.StockAllocation_Others((long)this.CompanyID, num3, num5, string.Concat(str5, "¶", num1.ToString()), Convert.ToBoolean(str6), num4, "Job", new decimal(0), (long)this.UserID);
                                        empty1 = string.Concat(empty1, baseClass.IsDeliveryItemStatusChanges_Kit((long)this.CompanyID, (long)0, num2, "other", num6, num5, num4), ",");
                                        HiddenField hdnKitStockValues = this.hdn_KitStockValues;
                                        object[] objArray = new object[] { "other~", num2, "~", num4, "~", num5, "~", empty1 };
                                        hdnKitStockValues.Value = string.Concat(objArray);
                                    }
                                    else
                                    {
                                        baseClass.StockAllocation_Others((long)this.CompanyID, num3, num5, string.Concat(str5, "¶", num1.ToString()), Convert.ToBoolean(str6), num4, "Job", new decimal(0), (long)this.UserID);
                                        empty1 = string.Concat(empty1, baseClass.IsDeliveryItemStatusChanges_Kit((long)this.CompanyID, (long)0, num2, "other", num6, num5, num4), ",");
                                        HiddenField hiddenField = this.hdn_KitStockValues;
                                        object[] objArray1 = new object[] { "other~", num2, "~", num4, "~", num5, "~", empty1 };
                                        hiddenField.Value = string.Concat(objArray1);
                                    }
                                }
                                else if (num6 > num5)
                                {
                                    empty = string.Concat(empty, empty2, ",");
                                }
                                else
                                {
                                    if (this.objBase.DeliveryItemID_Reduction_Check(num1))
                                    {
                                        continue;
                                    }
                                    if (str4.ToLower() == "s")
                                    {
                                        if (str2.ToLower() == "x" && flag.ToString().ToLower() != "true")
                                        {
                                            empty3 = baseClass.StockReductionProcess((long)this.CompanyID, num2, (long)0, string.Concat("self¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                        }
                                        else if (str2.ToLower() == "c")
                                        {
                                            empty3 = baseClass.StockReductionProcess((long)this.CompanyID, num2, (long)0, string.Concat("self¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                        }
                                    }
                                    else if (str4.ToLower() != "a")
                                    {
                                        if (str4.ToLower() == "m")
                                        {
                                            if (str2.ToLower() == "x" && flag.ToString().ToLower() != "true")
                                            {
                                                empty3 = baseClass.StockReductionProcess((long)this.CompanyID, num2, (long)0, string.Concat("multiple¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                            }
                                            else if (str2.ToLower() == "c")
                                            {
                                                empty3 = baseClass.StockReductionProcess((long)this.CompanyID, num2, (long)0, string.Concat("multiple¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                            }
                                        }
                                    }
                                    else if (str2.ToLower() == "x" && flag.ToString().ToLower() != "true")
                                    {
                                        empty3 = baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num2, string.Concat("additional option¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                    }
                                    else if (str2.ToLower() == "c")
                                    {
                                        empty3 = baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num2, string.Concat("additional option¶", num1.ToString()), num6, num4, "DeliveryItem", (long)this.UserID, new decimal(0));
                                    }
                                    if (!(empty3 == this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available")) && !(empty3 == this.objLanguage.GetLanguageConversion("No_Stock_Available")))
                                    {
                                        continue;
                                    }
                                    empty = string.Concat(empty, empty2, ",");
                                }
                            }
                        }
                        if (this.hdn_KitStockValues.Value != "" && this.hdn_KitStockValues.Value != null)
                        {
                            string[] strArrays1 = this.hdn_KitStockValues.Value.ToString().Split(new char[] { '~' });
                            string str7 = strArrays1[0];
                            long num7 = Convert.ToInt64(strArrays1[1].ToString());
                            long num8 = Convert.ToInt64(strArrays1[2].ToString());
                            int num9 = Convert.ToInt32(strArrays1[3].ToString());
                            if (!strArrays1[4].ToLower().Contains("false"))
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num7, "other", num9, num8, "DeliveryItem", (long)this.UserID, new decimal(0));
                            }
                            else
                            {
                                empty = string.Concat(empty, empty2, ",");
                            }
                        }
                    }
                }
            }
            return empty;
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                Convert.ToInt32(row["Roundoff"].ToString());
            }
            this.Session["search_del"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && delivery_view.WhereCondition != "")
                {
                    delivery_view.WhereCondition = string.Concat(delivery_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.cmnClass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
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
                            string whereCondition = delivery_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            delivery_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = delivery_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if ( dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = delivery_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                delivery_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string whereCondition2 = delivery_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " like '%", str, "%'" };
                                delivery_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }

                          
                        }
                    case 3:
                        {
                            string str2 = delivery_view.WhereCondition;
                            string[] strArrays3 = new string[] { str2, " ", empty, " not like '%", str, "%'" };
                            delivery_view.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 4:
                        {
                            string whereCondition3 = delivery_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " = '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 5:
                        {
                            string str3 = delivery_view.WhereCondition;
                            string[] strArrays5 = new string[] { str3, " ", empty, " != '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition4 = delivery_view.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition4, " ", empty, " > '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 7:
                        {
                            string str4 = delivery_view.WhereCondition;
                            string[] strArrays7 = new string[] { str4, " ", empty, " >= '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition5 = delivery_view.WhereCondition;
                            string[] strArrays8 = new string[] { whereCondition5, " ", empty, " < '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays8);
                            continue;
                        }
                    case 9:
                        {
                            string str5 = delivery_view.WhereCondition;
                            string[] strArrays9 = new string[] { str5, " ", empty, " <= '", str, "'" };
                            delivery_view.WhereCondition = string.Concat(strArrays9);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return delivery_view.WhereCondition;
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

            para = (para.Contains("Consignment Number") && !para.Contains("[Consignment Number]")) ? para.Replace("Consignment Number", "[Consignment Number]") : para;
            para = (para.Contains("Carrier Information") && !para.Contains("[Carrier Information]")) ? para.Replace("Carrier Information", "[Carrier Information]") : para;
            para = (para.Contains("Consignee Url") && !para.Contains("[Consignee Url]")) ? para.Replace("Consignee Url", "[Consignee Url]") : para;

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
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
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
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = base.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("customerid"))
                    {
                        row["customerid"] = base.SpecialDecode(row["customerid"].ToString());
                    }
                    if (row.Table.Columns.Contains("consignmentnumber"))
                    {
                        row["consignmentnumber"] = base.SpecialDecode(row["consignmentnumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = base.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("orderno"))
                    {
                        row["orderno"] = base.SpecialDecode(row["orderno"].ToString());
                    }
                    if (row.Table.Columns.Contains("jobnumber"))
                    {
                        row["jobnumber"] = base.SpecialDecode(row["jobnumber"].ToString());
                    }
                    if (!row.Table.Columns.Contains("jobtitle"))
                    {
                        continue;
                    }
                    row["jobtitle"] = base.SpecialDecode(row["jobtitle"].ToString());
                }
            }
            _commonClass.closeConnection();
            this.GridViewDelivery.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewDelivery);
                this.div_Main.Style.Add("display", "block");
                this.GridViewDelivery.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridViewDelivery);
            this.div_Main.Style.Add("display", "block");
            this.GridViewDelivery.AllowCustomPaging = true;
            this.GridViewDelivery.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewDelivery, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewDelivery);
        }

        protected void GridViewDelivery_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewDelivery_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                string empty = string.Empty;
                string empty1 = string.Empty;
                item.Text = base.SpecialEncode(item.Text);
                delivery_view.WhereCondition = "";
                if (this.Session["search_del"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_del"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_del"];
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
                this.Session["search_del"] = this.dtsearch;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                delivery_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
                this.GridViewDelivery.DataBind();
                //this.GridViewDelivery.Rebind();
            }
        }

        protected void GridViewDelivery_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewDelivery.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, this.GridViewDelivery.CurrentPageIndex + 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
        }

        protected void GridViewDelivery_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            delivery_view.SortedBy = e.SortExpression;
            delivery_view.sortdirection = e.NewSortOrder.ToString();
            if (delivery_view.sortdirection.ToLower() == "ascending")
            {
                delivery_view.sortdirection = "ASC";
                this.GridViewDelivery.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (delivery_view.sortdirection.ToLower() != "descending")
            {
                delivery_view.sortdirection = "ASC";
                this.GridViewDelivery.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                delivery_view.sortdirection = "DESC";
                this.GridViewDelivery.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridViewDelivery.CurrentPageIndex = 0;
            HttpSessionState session = this.Session;
            object[] num = new object[] { 1, "±", Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), "±", e.SortExpression, "±", delivery_view.sortdirection, "±false" };
            session["delivery"] = string.Concat(num);
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, this.GridViewDelivery.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, delivery_view.sortdirection, delivery_view.WhereCondition);
        }

        protected void lnkDelveryArchive_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidDelveryID.Value))
            {
                string[] strArrays = this.hidDelveryID.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i]))
                    {
                        DeliveryBasePage.Delivery_Make_Archive(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
                base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Archived_Successfully"), "successfulMsg", this.plhMessage);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
                this.GridViewDelivery.Rebind();
            }
        }

        protected void lnkDelveryCopy_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidDelveryID.Value))
            {
                string[] strArrays = this.hidDelveryID.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string.IsNullOrEmpty(strArrays[i]);
                }
            }
            base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Copied_Successfully"), "successfulMsg", this.plhMessage);
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
            this.GridViewDelivery.Rebind();
        }

        protected void lnkDelveryDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidDelveryID.Value))
            {
                string[] strArrays = this.hidDelveryID.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrays[i]))
                    {
                        DeliveryBasePage.delivery_delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
                base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Deleted_Successfully"), "successfulMsg", this.plhMessage);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, delivery_view.WhereCondition);
                this.GridViewDelivery.Rebind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridViewDelivery.FilterMenu;
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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
            //foreach (GridItem item in GridViewDelivery.MasterTableView.Items)
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

        protected void OnRowDataBound_GridViewDelivery(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewDelivery.Columns.Count; i++)
                {
                    if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "deliverynumber")
                    {
                        this.cellvalue_deliveryno = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                        this.flag_deliveryno = "true";
                    }
                    if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewDelivery.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_deliverydate = "true";
                        this.cellvalue_deliverydate = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "posted")
                    {
                        this.flag_posted = "true";
                        this.cellvalue_posted = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "consignmentnumber")
                    {
                        this.flag_consignmentnotenumber = "true";
                        this.cellvalue_consignmentnotenumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }

                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.cellvalue_ChooseTemplate = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.cellvalue_DownloadTemplate = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "orderno")
                    {
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "jobtitle")
                    {
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "accountingcode")
                    {
                        this.flag_accountingcode = "true";
                        this.cellvalue_accountingcode = this.GridViewDelivery.Columns[i].SortExpression;
                    }

                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.flag_SinceStatusUpdate = "true";
                        this.cellvalue_SinceStatusUpdate = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.flag_SinceEmailed = "true";
                        this.cellvalue_SinceEmailed = this.GridViewDelivery.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_estimatenumber = "true";
                        this.cellvalue_estimatenumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str = string.Concat("delivery_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_Error");
                string empty = string.Empty;
                string languageConversion = string.Empty;
                empty = string.Concat(this.strImagepath, "Attachment.PNG");
                languageConversion = this.objLangClass.GetLanguageConversion("Item_With_Attachment");
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
                    string[] strArrays = new string[] { "<img src='", empty, "' title='", languageConversion, "' style='cursor:pointer;' class='viewicon_margin' />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                TableCell tableCell = item["DeliveryNumber"];
                string[] str1 = new string[] { "<a style='color:#10357F;' href=", this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["DeliveryNumber"].Text, "</a>" };
                tableCell.Text = string.Concat(str1);
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
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
                if (this.flag_posted == "true")
                {
                    item[this.cellvalue_posted].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_posted].Style.Add("cursor", "pointer");
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customername].ToolTip = item[this.cellvalue_customername].Text;
                }
                if (this.flag_consignmentnotenumber == "true")
                {
                    item[this.cellvalue_consignmentnotenumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_consignmentnotenumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    item[this.cellvalue_status].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                    item[this.cellvalue_status].ToolTip = item[this.cellvalue_status].Text;
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

                if (this.flag_jobnumber == "true")
                {
                    item[this.cellvalue_jobnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_jobnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_customerordernumber == "true")
                {
                    item[this.cellvalue_customerordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customerordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                    item[this.cellvalue_paymentterms].ToolTip = item[this.cellvalue_paymentterms].Text;
                }
                if (this.flag_jobtitle == "true")
                {
                    item[this.cellvalue_jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_jobtitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_jobtitle].ToolTip = item[this.cellvalue_jobtitle].Text;
                }



                if (this.flag_DefaultTemplate == "true")
                {
                    string estimateId = item["DeliveryID"].Text;
                    string customerid = item["custid"].Text;

                    string targetUrl = $"{this.strSitepath}delivery/templates_view1.aspx?sectionid={customerid}&sectionname=DeliveryNote&type=Customer&page=Note&EstID={estimateId}&customtype=preview";


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
                    string estimateId = item["DeliveryID"].Text;
                    string customerid = item["custid"].Text;

                    string targetUrl = $"{this.strSitepath}delivery/templates_view1.aspx?sectionid={customerid}&sectionname=DeliveryNote&type=Customer&page=Note&EstID={estimateId}&customtype=choosetemp";

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
                    string estimateId = item["DeliveryID"].Text;
                    string customerid = item["custid"].Text;

                    string targetUrl = $"{this.strSitepath}delivery/templates_view1.aspx?sectionid={customerid}&sectionname=DeliveryNote&type=Customer&page=Note&EstID={estimateId}&customtype=download";

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
                    string estimateId = item["DeliveryID"].Text;

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








                if (this.flag_comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_comments, "DeliveryID");
                    
                }


                if (this.flag_accountingcode == "true")
                {
                    item[this.cellvalue_accountingcode].Attributes.Add("align", "right");
                    item[this.cellvalue_accountingcode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_accountingcode].Style.Add("cursor", "pointer");
                    item[this.cellvalue_accountingcode].ToolTip = item[this.cellvalue_accountingcode].Text;
                }
                if (this.flag_estimatenumber == "true")
                {
                    item[this.cellvalue_estimatenumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estimatenumber].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_deliveryno == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_deliveryno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_deliveryno)] != null && this.Session[string.Concat("delivery_", this.cellvalue_deliveryno)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_posted == "true")
                {
                    TextBox item1 = (e.Item as GridFilteringItem)[this.cellvalue_posted].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_posted)] != null && this.Session[string.Concat("delivery_", this.cellvalue_posted)].ToString() == "")
                    {
                        item1.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_status)] != null && this.Session[string.Concat("delivery_", this.cellvalue_status)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }
                if (this.flag_customername == "true")
                {
                    TextBox item2 = (e.Item as GridFilteringItem)[this.cellvalue_customername].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_customername)] != null && this.Session[string.Concat("delivery_", this.cellvalue_customername)].ToString() == "")
                    {
                        item2.Text = "";
                    }
                }
                if (this.flag_jobnumber == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_jobnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_jobnumber)] != null && this.Session[string.Concat("delivery_", this.cellvalue_jobnumber)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_customerordernumber == "true")
                {
                    TextBox item3 = (e.Item as GridFilteringItem)[this.cellvalue_customerordernumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_customerordernumber)] != null && this.Session[string.Concat("delivery_", this.cellvalue_customerordernumber)].ToString() == "")
                    {
                        item3.Text = "";
                    }
                }
                if (this.flag_consignmentnotenumber == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_consignmentnotenumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_consignmentnotenumber)] != null && this.Session[string.Concat("delivery_", this.cellvalue_consignmentnotenumber)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }
                if (this.flag_paymentterms == "true")
                {
                    TextBox item4 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("delivery_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        item4.Text = "";
                    }
                }

                if (this.flag_SinceEmailed == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceEmailed].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_SinceEmailed)] != null && this.Session[string.Concat("delivery_", this.cellvalue_SinceEmailed)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_SinceStatusUpdate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceStatusUpdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_SinceStatusUpdate)] != null && this.Session[string.Concat("delivery_", this.cellvalue_SinceStatusUpdate)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_jobtitle == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_jobtitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_jobtitle)] != null && this.Session[string.Concat("delivery_", this.cellvalue_jobtitle)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_comments == "true")
                {
                    TextBox textBoxcomments = (e.Item as GridFilteringItem)[this.cellvalue_comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_comments)] != null && this.Session[string.Concat("delivery_", this.cellvalue_comments)].ToString() == "")
                    {
                        textBoxcomments.Text = "";
                    }
                }
                if (this.flag_accountingcode == "true")
                {
                    gridFilteringItem[this.cellvalue_accountingcode].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item5 = (e.Item as GridFilteringItem)[this.cellvalue_accountingcode].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_accountingcode)] != null && this.Session[string.Concat("delivery_", this.cellvalue_accountingcode)].ToString() == "")
                    {
                        item5.Text = "";
                    }
                }
                if (this.flag_deliverydate == "true")
                {
                    gridFilteringItem[this.cellvalue_deliverydate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_deliverydate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_deliverydate)] != null && this.Session[string.Concat("delivery_", this.cellvalue_deliverydate)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item6 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_createddate)] != null && this.Session[string.Concat("delivery_", this.cellvalue_createddate)].ToString() == "")
                    {
                        item6.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomDate1].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("delivery_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomDate2].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("delivery_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomDate3].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("delivery_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomDate4].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("delivery_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomDate5].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("delivery_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_estimatenumber == "true")
                {
                    TextBox item7 = (e.Item as GridFilteringItem)[this.cellvalue_estimatenumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("delivery_", this.cellvalue_estimatenumber)] != null && this.Session[string.Concat("delivery_", this.cellvalue_estimatenumber)].ToString() == "")
                    {
                        item7.Text = "";
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
                Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridViewDelivery.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridViewDelivery.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
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
            this.lnkDeliveryedit.Text = this.objLangClass.GetLanguageConversion("Edit_View");
            this.GridViewDelivery.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_records_to_display");
            this.lblArchive.Text = this.objLangClass.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLangClass.GetLanguageConversion("Detele_Selected");
            this.Archive_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLangClass.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.objBase.ReturnRoles_Privileges_Tabs("deliverynote", "isview", "");
            if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.DivdivDropdownlist.Visible = true;
            }
            else
            {
                this.DivdivDropdownlist.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            long deliveryStatusID = ConnectionClass.DeliveryStatusID;
            this.DeliveryStatusID = ConnectionClass.DeliveryStatusID;
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
            }
            for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridViewDelivery.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            global.pageName = "deliverynote";
            global.pgName = "";
            this.gloobj.setpagename("deliverynote");
            this.pg = "deliverynote";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            languageClass _languageClass = new languageClass();
            base.Title = _languageClass.convert(global.pageTitle("Delivery Note View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Delivery_Note_View")));
            string str = this.cmnClass.UserSetting_Selete(this.CompanyID, this.UserID, "delivery_note_view");
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.Session["DelViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["DelViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewDelivery.PageSize = 50;
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView("deliverynote", this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
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
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, "deliverynote");
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
                delivery_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    delivery_view.SortedBy = "DeliveryNumber";
                }
                else
                {
                    delivery_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    delivery_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    delivery_view.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str1 = string.Concat(this.pg, this.UserID, this.pg);
                this.Session["search_del"] = null;
                this.Session[str1] = null;
            }
            if (!base.IsPostBack && base.Request.Params["su"] != null)
            {
                if (base.Request.Params["su"].ToString().ToLower() == "in")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Saved_Successfully"), "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "up")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Updated_Successfully"), "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "de")
                {
                    base.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_Note_Deleted_Successfully"), "successfulMsg", this.plhMessage);
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
                if (this.Session["search_del"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_del"];
                    str2 = this.FilterFunction(item);
                }
                this.Session["DelViewID"] = this.defaultviewid;
                delivery_view.PageSize = this.cmnClass.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridViewDelivery);
                this.GridViewDelivery.PageSize = delivery_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, delivery_view.SortedBy, delivery_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridViewDelivery.Rebind();
            }
            var column = this.GridViewDelivery.MasterTableView.Columns.FindByUniqueNameSafe("SinceStatusCount");
            if (column != null)
            {
                column.Visible = false;
            }
            var column2 = this.GridViewDelivery.MasterTableView.Columns.FindByUniqueNameSafe("SinceEmailCount");
            if (column2 != null)
            {
                column2.Visible = false;
            }
            var column3 = this.GridViewDelivery.MasterTableView.Columns.FindByUniqueNameSafe("isAnyEmailed");
            if (column3 != null)
            {
                column3.Visible = false;
            }
            //if (!IsPostBack && this.IsGrouping)
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridViewDelivery, this.GroupByColumn);
            //}
            try
            {
                this.GridViewDelivery.MasterTableView.GetColumn("DeliveryID").Visible = false;
                this.GridViewDelivery.MasterTableView.GetColumn("custid").Visible = false;
                this.GridViewDelivery.MasterTableView.GetColumn("StatusColorCode").Visible = false;

            }
            catch (Exception exception)
            {
            }
            this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            int num = Convert.ToInt16(this.RadListBox1.SelectedValue);
            if (this.ServerName.ToLower() == "dmc" || this.ServerName.ToLower() == "dmc2")
            {
                if ((long)num != this.DeliveryStatusID)
                {
                    this.hdnStatus.Value = "true";
                }
                flag = true;
            }
            else
            {
                this.hdnStatus.Value = "true";
                flag = false;
            }
            if (this.hdnStatus.Value.ToLower() == "true")
            {
                string str = this.hdnSelectedChkfrmGrid.Value.ToString();
                string[] strArrays = str.Split(new char[] { ',' });

                this.RadListBox1.ClearSelection();
                string str1 = "DeliveryNote";
                string empty = string.Empty;
                if (str != "" && num != 0)
                {
                    string empty1 = string.Empty;
                    if (flag)
                    {
                        empty1 = this.DeliveryItem_StausChanges_CheckAndUpdate(str, num);
                        if (empty1 == "" || empty1 == null)
                        {
                            this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                        }
                        else
                        {
                            empty1 = empty1.Substring(0, empty1.Length - 1);
                            this.objBase.Message_Display(string.Concat("Status cannot be changed for these Delivery Numbers ", empty1), "msg-fail", this.plhMessage);
                        }
                    }
                    else
                    {
                        DeliveryBasePage.DeliveryOnCheck_Status_Update(this.CompanyID, str, num, str1);
                        this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                    }
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        this.cmnClass.SendInternalMailOnModuleStatusChange(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), num, "delivery");

                    }
                    this.hdnSelectedChkfrmGrid.Value = "";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                    this.GridViewDelivery.Rebind();
                    return;
                }
            }
            else if ((this.ServerName.ToLower() == "dmc" || this.ServerName.ToLower() == "dmc2") && (long)num == this.DeliveryStatusID)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ShowPopUp();", true);
            }
        }
    }
}

