using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Services;
using System.Linq;
using System.Text;

namespace ePrint.Estimates
{
    public partial class Proofs : BaseClass, IRequiresSessionState
    {

        private int CompanyID;
        private BaseClass objBass = new BaseClass();
        //public static string SortedBy;

        //public string DateFormat = string.Empty;

        //private DataTable dtsearch = new DataTable();

        //public static int PageSize;

        //public string EstimateID = string.Empty;

        //private DataTable dtArtwork = new DataTable();

        //public int ViewID;

        //public string VersionNumber = ConnectionClass.VersionNumber;

        //public string Archive_Row_Selection_Alert = string.Empty;

        //public string Delete_Row_Selection_Alert = string.Empty;

        //public string UnArchive_Row_Selection_Alert = string.Empty;

        //public bool IsItemSelected;

        //public string RecordsToDisplay = "";
        public static int PageSize;
        private Global gloobj = new Global();

        private string EstimateItem_number = string.Empty;

        private string Estimate_number = string.Empty;
        private BaseClass objBase = new BaseClass();
        public string pg;
        public string cellvalue_custordernumber = string.Empty;
        public int ViewID;
        private createViewClass objCreateView = new createViewClass();
        public int defaultviewid;
        public DataTable dt = new DataTable();
        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;
        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;
        public bool IsItemSelected;
        private DataTable dtsearch = new DataTable();
        public int UserID;
        public string DateFormat = string.Empty;
        private commonClass objJava = new commonClass();
        public string Archive_Row_Selection_Alert = string.Empty;
        public string Delete_Row_Selection_Alert = string.Empty;
        private notesclass objnotes = new notesclass();
        private Notes objN = new Notes();
        private long ModuleID;
        public string RecordsToDisplay = "";

        public string cellvalue_salesperson = string.Empty;
        public string flag_salesperson = string.Empty;

        public string cellvalue_estimatenumber = string.Empty;
        public string flag_estimatenumber = string.Empty;

        public string cellvalue_proofnumber = string.Empty;
        public string flag_proofnumber = string.Empty;

        public string cellvalue_itemtitle = string.Empty;
        public string flag_itemtitle = string.Empty;

        public string cellvalue_jobtitle = string.Empty;
        public string flag_jobtitle = string.Empty;

        public string cellvalue_proofstatus = string.Empty;
        public string flag_proofstatus = string.Empty;

        public string cellvalue_file = string.Empty;
        public string flag_file = string.Empty;

        public string cellvalue_proofdate = string.Empty;
        public string flag_proofdate = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;

        public string cellvalue_jobnumber = string.Empty;
        public string flag_jobnumber = string.Empty;

        public string cellvalue_customername = string.Empty;
        public string flag_customername = string.Empty;

        public string cellvalue_actualproofdate = string.Empty;
        public string flag_actualproofdate = string.Empty;

        public string cellvalue_filestatus = string.Empty;
        public string flag_filestatus = string.Empty;

        public string cellvalue_contactname = string.Empty;
        public string flag_contactname = string.Empty;

        public string cellvalue_proofapprovaldate = string.Empty;
        public string flag_proofapprovaldate = string.Empty;

        public string cellvalue_proofitemstatus = string.Empty;
        public string flag_proofitemstatus = string.Empty;

        public string cellvalue_deliverydate = string.Empty;
        public string flag_deliverydate = string.Empty;

        public string cellvalue_artworkdate = string.Empty;
        public string flag_artworkdate = string.Empty;

        public string cellvalue_creationdate = string.Empty;
        public string flag_creationdate = string.Empty;

        public string cellvalue_estimator = string.Empty;
        public string flag_estimator = string.Empty;

        public string cellvalue_productiondate = string.Empty;
        public string flag_productiondate = string.Empty;

        public string cellvalue_proofcomments = string.Empty;
        public string flag_proofcomments = string.Empty;
        //public bool IsGrouping;

        //public string GroupByColumn = string.Empty;
        public string FilterDateType = string.Empty;
        public string FilterDateRange = string.Empty;


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

        static Proofs()
        {


            Proofs.PageSize = 50;
        }



        public void AddBoundColumns(DataTable dt, RadGrid gv/*, List<string> selectedColumns*/)
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
                    //gridBoundColumn.Visible = false;
                    if (this.GridView1.Columns[i].HeaderText == "ProofItemID")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    if (this.GridView1.Columns[i].HeaderText == "EstimateNumber")
                    {
                        this.GridView1.Columns[i].HeaderText = "Estimate Number";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "ItemTitleValue")
                    {
                        this.GridView1.Columns[i].HeaderText = "Item Title";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "ItemTitleValue")
                    {
                        this.GridView1.Columns[i].HeaderText = "Item Title";
                    }

                    if (this.GridView1.Columns[i].HeaderText == "JobNumber")
                    {
                        this.GridView1.Columns[i].HeaderText = "Job Number";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "CustomerName")
                    {
                        this.GridView1.Columns[i].HeaderText = "Customer Name";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "ContactName")
                    {
                        this.GridView1.Columns[i].HeaderText = "Contact Name";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "ActualProofDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Actual Proof Date";
                    }
                    if (this.GridView1.Columns[i].HeaderText == "ActualProofApprovalDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Actual Proof Approval Date";
                    }

                    if (this.GridView1.Columns[i].HeaderText == "CustomerComments")
                    {
                        this.GridView1.Columns[i].HeaderText = "Customer Comments";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "SupplierComments")
                    {
                        this.GridView1.Columns[i].HeaderText = "Supplier Comments";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProofNumber")
                    {
                        this.GridView1.Columns[i].HeaderText = "Proof Number";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "CreationDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Creation Date";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProofStatus")
                    {
                        this.GridView1.Columns[i].HeaderText = "Proof Status";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProofItemStatus")
                    {
                        this.GridView1.Columns[i].HeaderText = "Proof Item Status";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "Salesperson")
                    {
                        this.GridView1.Columns[i].HeaderText = "Sales Person";
                    }

                    else if (this.GridView1.Columns[i].HeaderText == "ArtworkDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Artwork Date";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "DeliveryDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Delivery Date";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProofDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Proof Date";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProductionDate")
                    {
                        this.GridView1.Columns[i].HeaderText = "Production Date";
                    }
                    else if (this.GridView1.Columns[i].HeaderText == "ProofComments")
                    {
                        this.GridView1.Columns[i].HeaderText = "Proof Comments";
                    }
                }

                for (int j = 0; j < this.GridView1.Columns.Count; j++)
                {
                    this.GridView1.Columns[j].CurrentFilterFunction = GridKnownFunction.Contains;
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridView1.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number_Order_Number");
                        //this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        //this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        //this.GridView1.Columns[j].ItemStyle.Wrap = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Title");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;

                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridView1.Columns[j].HeaderText = "Archive";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "qty1")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Qty1");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].Visible = false;
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "descriptionvalue")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "artworkvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Artwork";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "colourvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Colour";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "sizevalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Size";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "materialvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Material";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliveryvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Delivery";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "finishingvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = "Finishing";
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = "Proof Number";

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "jobtitle")
                    {
                        this.GridView1.Columns[j].HeaderText = "Job Title";

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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimateitemid")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "companyid")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimateid")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = "Proof Number";

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "filestatus")
                    {
                        this.GridView1.Columns[j].HeaderText = "File Status";


                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "suppliercomments")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customercomments")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofid")
                    {
                        this.GridView1.Columns[j].Visible = false;

                    }
                    //foreach (var st in selectedColumns)
                    //{
                    //    if (this.GridView1.Columns[j].SortExpression.ToLower() == st.ToLower())
                    //    {
                    //        this.GridView1.Columns[j].Visible = true;
                    //        break;
                    //    }
                    //}
                }

            }

            for (int j = 0; j < this.GridView1.Columns.Count; j++)
            {
               if (this.GridView1.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridView1.Columns[j].HeaderText = "Archive Item";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_Archive = "true";
                }
            }

            for (int i = 0; i < gv.MasterTableView.Columns.Count; i++)
            {
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
                Image img = new Image
                {
                    ImageUrl = _imageUrl,
                    AlternateText = "Default Template",
                    Width = Unit.Pixel(16),
                    Height = Unit.Pixel(16)
                };
                container.Controls.Add(img);
            }
        }

        //public void bindRadlistStatus()
        //{
        //    this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
        //    DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "estimate");
        //    this.RadListBox1.DataSource = dataTable;
        //    this.RadListBox1.DataTextField = "StatusTitle";
        //    this.RadListBox1.DataValueField = "StatusID";
        //    this.RadListBox1.DataBind();
        //}

        //protected void btn_Delete(object sender, EventArgs e)
        //{
        //    EstimateBasePage.Estimate_Delete(Convert.ToInt32(this.Session["companyid"]), Convert.ToInt64(this.hdnEstimateID.Value));
        //    this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, SortedBy, sortdirection, this.para);
        //}
        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, "proof", ViewID, SortedBy, SortDirection, para);
            if (empty.Trim().ToLower().Contains("'1/1/1900'"))
            {
                empty = empty.Replace("and  DateAdd(d,0,DateDiff(d,0,ProofDate)) = '1/1/1900'", "");
            }
            if (empty.Trim().Contains("and  ProofNumber like '%%'"))
            {
                empty = empty.Replace("and  ProofNumber like '%%'", "");
            }

            if (empty.Trim().Contains("and  JobTitle like '%%'"))
            {
                empty = empty.Replace("and  JobTitle like '%%'", "");
            }
            if (empty.Trim().Contains("and  [File] like '%%'"))
            {
                empty = empty.Replace("and  [File] like '%%'", "");
            }
            if (empty.Trim().Contains("and  FileStatus like '%%'"))
            {
                empty = empty.Replace("and  FileStatus like '%%'", "");
            }
            if (empty.Trim().Contains("and  ItemTitleValue like '%%'"))
            {
                empty = empty.Replace("and  ItemTitleValue like '%%'", "");
            }
            if (empty.Trim().Contains("and  EstimateNumber like '%%'"))
            {
                empty = empty.Replace("and  EstimateNumber like '%%'", "");
            }
            if (empty.Trim().Contains("and  JobNumber like '%%'"))
            {
                empty = empty.Replace("and  JobNumber like '%%'", "");
            }
            if (empty.Trim().Contains("and  ApprovalStatus like '%%'"))
            {
                empty = empty.Replace("and  ApprovalStatus like '%%'", "");
            }
            if (empty.Trim().Contains("and  ProofComments like '%%'"))
            {
                empty = empty.Replace("and  ProofComments like '%%'", "");
            }
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
            //if (item.Columns.Contains("FileName"))
            //{
            //    foreach (DataRow dr in item.Rows)
            //    {
            //        string fileName = string.Empty;
            //        fileName = dr["FileName"].ToString();
            //        if (!string.IsNullOrEmpty(fileName))
            //        {
            //            List<string> names = fileName.Split(',').ToList<string>();
            //            string _html = string.Empty;
            //            foreach (var a in names)
            //            {
            //                _html += "<ul><li>" + a + "</li></ul>";
            //            }
            //            dr["FileName"] = _html;
            //        }
            //    }
            //}

            string str = "";
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("CreationDate"))
                    {
                        row["CreationDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreationDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ActualProofDate"))
                    {
                        row["ActualProofDate"] = this.objJava.Eprint_return_Date_Before_View(row["ActualProofDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ActualProofApprovalDate"))
                    {
                        row["ActualProofApprovalDate"] = this.objJava.Eprint_return_Date_Before_View(row["ActualProofApprovalDate"].ToString(), CompanyID, UserID, false);
                    }

                    if (row.Table.Columns.Contains("ArtworkDate"))
                    {
                        row["ArtworkDate"] = this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProofDate"))
                    {
                        row["ProofDate"] = this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProductionDate"))
                    {
                        row["ProductionDate"] = this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), CompanyID, UserID, false);
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

                    if (row.Table.Columns.Contains("ProofComments"))
                    {
                        string proofComments = row["ProofComments"].ToString();
                        string result = proofComments.Replace("$", "<br>");
                        string[] splitString = result.Split(new string[] { "<br>" }, StringSplitOptions.None);
                        StringBuilder finalDescription = new StringBuilder();

                        foreach (string segment in splitString)
                        {
                            int segmentLength = 40;

                            if (segment.Length > segmentLength)
                            {
                                string[] segments = SplitByLength(segment, segmentLength);
                                foreach (var smallSegment in segments)
                                {
                                    finalDescription.Append(smallSegment).Append("<br>");
                                }
                            }
                            else
                            {
                                finalDescription.Append(segment).Append("<br>");
                            }
                        }
                        string finalDesc = finalDescription.ToString().TrimEnd("<br>".ToCharArray());
                        row["ProofComments"] = finalDesc;
                    }

                    if (!row.Table.Columns.Contains("IsArchive"))
                    {
                        continue;
                    }
                    if (row["IsArchived"].ToString() == "1")
                    {
                        this.lblArchive.Visible = false;
                        str = string.Concat(str, row["IsArchived"].ToString());
                    }
                    if (row["IsArchived"].ToString() == "0")
                    {
                        str = string.Concat(str, row["IsArchived"].ToString());
                    }
                    if (!str.Contains("1") || !str.Contains("0"))
                    {
                        continue;
                    }
                    this.lblArchive.Visible = true;
                    //this.lblDelete.Visible = true;

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

        private string[] SplitByLength(string input, int maxLength)
        {
            List<string> segments = new List<string>();
            string[] words = input.Split(' ');

            StringBuilder currentSegment = new StringBuilder();
            foreach (string word in words)
            {
                if (currentSegment.Length + word.Length > maxLength)
                {
                    segments.Add(currentSegment.ToString().Trim());
                    currentSegment.Clear();
                }
                currentSegment.Append(word).Append(" ");
            }

            if (currentSegment.Length > 0)
            {
                segments.Add(currentSegment.ToString().Trim());
            }

            return segments.ToArray();
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
        protected void clrFilters_Click(object sender, EventArgs e)
        {
            Proofs.WhereCondition = "";
            this.Session["search_proof"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, Proofs.SortedBy, Proofs.sortdirection, Proofs.WhereCondition);
            this.GridView1.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "estimates/Proofs.aspx?viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
        }
        public void btnEditView_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            int _id = 0;
            if (!string.IsNullOrEmpty(this.edit_estViewID.Value))
            {
                _id = int.Parse(this.edit_estViewID.Value);
            }
            object[] value = new object[] { "../estimates/CustomViewProof.aspx?type=edit&id=", _id, "&cid=", Convert.ToInt16(this.Session["CompanyID"]) };
            response.Redirect(string.Concat(value));
        }

        protected void lnkProofArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                DataTable dataTable1 = EstimatesBasePage.proof_select_summary_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.EstimateItem_number = dataRow["ProofItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(dataRow["ModuleID"]);
                }
                this.objnotes.Item_number = this.EstimateItem_number;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemArchived);
                this.objnotes.ItemID = (long)Convert.ToInt32(strArrays[i].ToString());
                EstimatesBasePage.ProofItem_Archive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                this.objnotes.ModuleName = "Proof";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Proof_Archived_Successfully"), "successfulMsg", this.plhMessage);

            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, Proofs.SortedBy, Proofs.sortdirection, Proofs.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkProofDelete_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            Int32 countZero = 0;
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)Convert.ToInt32(strArrays[i].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this proof and it can not be deleted. Please contact support and request assistance" : "There is an error in one of the proof(s) and can not be deleted. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);

                return;
            }

            //string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                EstimatesBasePage.ProofItem_Delete(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), "proof", flag);
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Proof_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, Proofs.SortedBy, Proofs.sortdirection, Proofs.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.objBase.ReturnRoles_Privileges_Tabs("proofs", "isview", "");
            this.CompanyID = int.Parse(this.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.lblArchive.Text = this.objLanguage.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");

            if (objBase.GetUserRolePrivilege("proofs", "isdelete") == "true")
            {
                this.divDelete.Visible = true;
            }
            else
            {
                this.divDelete.Visible = false;
            }

            if (objBase.GetUserRolePrivilege("proofs", "isarchive") == "true")
            {
                this.divarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
            }
            
            global.pageName = "Proofs";
            global.pgName = "";
            this.gloobj.setpagename("Proofs");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "Proofs";
            this.DateFormat = this.Session["Dateformat"].ToString();
            int customizeViewCount = this.objCreateView.PageCustomizeCount(this.CompanyID, "proof");
            if (!base.IsPostBack)
            {
                //this.bindRadlistStatus();
                //this.hdnSelectedChkfrmGrid.Value = "";
                this.edit_estViewID.Value = "";
                this.hdnIDs.Value = "";
            }
            if (customizeViewCount == 0)
            {
                Proofs.InsertCustomizeView(this.CompanyID, this.UserID);
            }
            DataTable dt = this.objCreateView.GetdefaultviewID(this.CompanyID, "proof");
            if (this.Session["ProofViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["ProofViewID"]);
            }
            if (this.defaultviewid == 0)
            {
                DataTable defaultview = this.objCreateView.GetdefaultviewID(this.CompanyID, "proof");
                if (defaultview.Rows.Count != 0)
                {
                    foreach (DataRow dataRow in defaultview.Rows)
                    {
                        this.defaultviewid = Convert.ToInt32(dataRow["ViewID"].ToString());
                    }
                }
            }

            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }


            //for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            //{
            //    AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
            //    string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridView1.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "');" };
            //    attributes.Add("onclick", string.Concat(clientID));
            //}
            if (!base.IsPostBack)
            {
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView("proof", this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
                    int num1 = 0;
                    while (num1 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num1].Value != this.ViewID.ToString())
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
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, "proof");
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow dataRow in this.dt.Rows)
                        {
                            this.defaultviewid = Convert.ToInt32(dataRow["ViewID"].ToString());
                        }
                    }
                    this.objCreateView.BindCustomView("proof", this.CompanyID, this.ddl_View);
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
                    //this.ddl_View.Items.Insert(0, new ListItem("Default View", ""));
                    //this.ddl_View.SelectedIndex = 0;
                    //this.ddl_View.SelectedValue = "Default View";
                    //this.lblView.Text = "Default View";
                }
                else
                {
                    this.objCreateView.BindCustomView("proof", this.CompanyID, this.ddl_View, this.defaultviewid);
                    int num3 = 0;
                    while (num3 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num3].Value != this.defaultviewid.ToString())
                        {
                            num3++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num3].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }

            }
            int num4 = 0;
            num4 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num4, this.CompanyID, "proof");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row1 in this.dt.Rows)
                {
                    this.defaultsortedby = row1["SortedBy"].ToString();
                    this.defaultsortdirection = row1["SortDirection"].ToString();
                    //83
                    //this.IsGrouping = String.IsNullOrEmpty(row1["isGrouping"].ToString()) ? false : Convert.ToBoolean(row1["isGrouping"].ToString());

                    //this.IsGrouping = (row1["ColumnNames"].ToString().Contains(row1["GroupByColumn"].ToString()) && !String.IsNullOrEmpty(row1["isGrouping"].ToString())) ? Convert.ToBoolean(row1["isGrouping"].ToString()) : false;
                    //this.GroupByColumn = row1["GroupByColumn"].ToString();
                    this.FilterDateType = row1["FilterDateType"].ToString();
                    this.FilterDateRange = row1["FilterDateRange"].ToString();
                }
            }

            if (!base.IsPostBack)
            {
                Proofs.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    Proofs.SortedBy = "ProofNumber";
                }
                else
                {
                    Proofs.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    Proofs.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    Proofs.sortdirection = this.defaultsortdirection;
                }
                this.GridView1.PageSize = 50;
                long num = Convert.ToInt64(base.Request.Params["estid"]);

            }
            base.Title = this.objLanguage.convert(global.pageTitle("Proofs", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            languageClass _languageClass = new languageClass();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", "Proof View"));
            //base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_View")));
            BaseClass baseClass1 = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass1.ApplyTimeZone(now.ToString()));
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "proof_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
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
                        this.GridBind(CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, Proofs.SortedBy, Proofs.sortdirection, empty);
                    }
                }
            }
            catch
            {
            }
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            this.RecordsToDisplay = EstimatesBasePage.Views_RecordsToDisplay((long)this.defaultviewid);
            //if (this.RecordsToDisplay.ToLower().ToString() == "live")
            //{
            //    this.divunarchive.Style.Add("display", "none");
            //    this.divarchive.Style.Add("display", "block");
            //}
            //else if (this.RecordsToDisplay.ToLower().ToString() == "archive")
            //{
            //    this.divunarchive.Style.Add("display", "block");
            //    this.divarchive.Style.Add("display", "none");
            //}
            //else if (this.RecordsToDisplay.ToLower().ToString() == "all")
            //{
            //    this.divunarchive.Style.Add("display", "block");
            //    this.divarchive.Style.Add("display", "block");
            //}
            try
            {
                if (!base.IsPostBack)
                {


                    string str2 = "";
                    if (this.Session["search_proof"] != null)
                    {
                        DataTable item = (DataTable)this.Session["search_proof"];
                        str2 = this.FilterFunction(item);
                    }
                    this.Session["ProofViewID"] = this.defaultviewid;
                    this.ViewID = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
                    Proofs.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                    this.GridView1.PageSize = Proofs.PageSize;
                    //this.GridBind(this.GridView1.PageSize, 1, this.CompanyID, 0, this.ViewID, this.defaultviewid);
                    this.GridBind(CompanyID, this.UserID, this.GridView1.PageSize, 1, this.ViewID, Proofs.SortedBy, Proofs.sortdirection, str2);
                    this.GridStateLoad();
                    this.GridView1.Rebind();
                }
                //if (!IsPostBack && this.IsGrouping)
                //{
                //    // Example: Group by "Employee Name" header text
                //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
                //    this.ApplyGroupingByFieldName(this.GridView1, this.GroupByColumn);
                //}
            }
            catch (Exception exception)
            {
            }
         

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

            try
            {
                this.GridView1.MasterTableView.GetColumn("jobid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("Cust_ID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("SalesPersonID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("StatusColorCode").Visible = false;

            }
            catch (Exception ex)
            {

            }
        }
        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }
        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }
        public static void InsertCustomizeView(int companyID, int userID)
        {
            SqlCommand sqlCommand = new SqlCommand("[PC_CustomizeViewIfNotExist]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.ExecuteNonQuery();
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
            this.Session["search_proof"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && Proofs.WhereCondition != "")
                {
                    Proofs.WhereCondition = string.Concat(Proofs.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "artworkdate" || dataRow["Columnname"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                    //empty = string.Concat("CONVERT(VARCHAR,", dataRow["ColumnName"].ToString(), ",103)");

                }
                else
                {
                    empty = dataRow["ColumnName"].ToString();
                    if (empty.ToString().ToLower() == "file")
                    {
                        empty = "[File]";
                    }
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                //             if (< PrivateImplementationDetails >{ 4D412C83 - 4704 - 44CF - 88AD - 5137B9E4F995}.$$method0x600001b - 1 == null)
                //{

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

                //             }
                //             if (!< PrivateImplementationDetails >{ 4D412C83 - 4704 - 44CF - 88AD - 5137B9E4F995}.$$method0x600001b - 1.TryGetValue(str1, out num))
                //{
                //                 continue;
                //             }

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = Proofs.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            Proofs.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = Proofs.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            Proofs.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "estimatedate" || dataRow["Columnname"].ToString().ToLower() == "artworkdate" || dataRow["Columnname"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "approvaldate" || dataRow["Columnname"].ToString().ToLower() == "productiondate" || dataRow["Columnname"].ToString().ToLower() == "completiondate" || dataRow["Columnname"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = Proofs.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string str2 = Proofs.WhereCondition;
                                string[] strArrays3 = new string[] { str2, " ", empty, " like '%", str, "%'" };
                                Proofs.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        }
                    case 3:
                        {
                            string whereCondition3 = Proofs.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " not like '%", str, "%'" };
                            Proofs.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str3 = Proofs.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = ", str };
                                Proofs.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                            else
                            {
                                string whereCondition4 = Proofs.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " = '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str4 = Proofs.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " != ", str };
                                Proofs.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                            else
                            {
                                string whereCondition5 = Proofs.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " != '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str5 = Proofs.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " > ", str };
                                Proofs.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                            else
                            {
                                string whereCondition6 = Proofs.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " > '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str6 = Proofs.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " >= ", str };
                                Proofs.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                            else
                            {
                                string whereCondition7 = Proofs.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " >= '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str7 = Proofs.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " < ", str };
                                Proofs.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                            else
                            {
                                string whereCondition8 = Proofs.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " < '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str8 = Proofs.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " <= ", str };
                                Proofs.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                            else
                            {
                                string whereCondition9 = Proofs.WhereCondition;
                                string[] strArrays16 = new string[] { whereCondition9, " ", empty, " <= '", str, "'" };
                                Proofs.WhereCondition = string.Concat(strArrays16);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return Proofs.WhereCondition;
        }

        protected void lnkEstimateNumber_Click(object sender, EventArgs e)
        {
            //addCommentsAndChangeStatus.Style.Add("display", "block");
            //LinkButton linkButton = (LinkButton)sender;
            //SqlCommand sqlCommand = new SqlCommand("PC_EstimateItemDetailProof_Get", (new commonClass()).openConnection())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};

            //sqlCommand.Parameters.AddWithValue("@EstimateItemID", Convert.ToInt32(linkButton.CommandArgument.ToString()));
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //if (sqlDataReader.Read())
            //{
            //    this.txtSupplierComments.Text = sqlDataReader["SupplierComments"].ToString();
            //    this.txtCustomerComments.Text = sqlDataReader["CustomerComments"].ToString();

            //    //base.SetDDLValue(this.ddlEmailTemplateType, sqlDataReader["TemplateType"].ToString().ToLower().Trim());
            //    //this.objBass.SetDDLValue(this.ddlProofStatus, sqlDataReader["ProofStatus"].ToString());
            //    if (sqlDataReader["ProofStatus"].ToString() == "Rejected")
            //    {
            //        this.ddlProofStatus.SelectedIndex = 2;
            //    }
            //    else if (sqlDataReader["ProofStatus"].ToString() == "Approved")
            //    {
            //        this.ddlProofStatus.SelectedIndex = 1;
            //    }
            //    else
            //    {
            //        this.ddlProofStatus.SelectedIndex = 0;
            //    }
            //    this.hdnEstimateItemID.Value = linkButton.CommandArgument.ToString();

            //}

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            //SqlCommand sqlCommand = new SqlCommand("PC_EstimateItemDetailProof_Save", (new commonClass()).openConnection())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};

            //sqlCommand.Parameters.Add("@EstimateItemId", Convert.ToInt32(hdnEstimateItemID.Value));
            //sqlCommand.Parameters.Add("@SupplierComments", this.txtSupplierComments.Text);
            //sqlCommand.Parameters.Add("@CustomerComments", this.txtCustomerComments.Text);
            //sqlCommand.Parameters.Add("@ProofStatus", ddlProofStatus.SelectedItem.Value);




            //sqlCommand.ExecuteNonQuery();

            //this.GridBind(this.GridView1.PageSize, 1);

            //this.GridView1.Rebind();
            //this.txtSupplierComments.Text = "";
            //this.txtCustomerComments.Text = "";
            //addCommentsAndChangeStatus.Style.Add("display", "none");
        }

        protected void GridView1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string[] languageConversion;
            DateTime now;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridView1.Columns.Count; i++)
                {
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_estimatenumber = "true";
                        this.cellvalue_estimatenumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofnumber")
                    {
                        this.flag_proofnumber = "true";
                        this.cellvalue_proofnumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofcomments")
                    {
                        this.flag_proofcomments = "true";
                        this.cellvalue_proofcomments = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtitlevalue")
                    {
                        this.flag_itemtitle = "true";
                        this.cellvalue_itemtitle = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "jobtitle")
                    {
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofstatus")
                    {
                        this.flag_proofstatus = "true";
                        this.cellvalue_proofstatus = this.GridView1.Columns[i].SortExpression.ToLower();
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

                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "creationdate")
                    {
                        this.flag_creationdate = "true";
                        this.cellvalue_creationdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "file")
                    {
                        this.flag_file = "true";
                        this.cellvalue_file = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "actualproofdate")
                    {
                        this.flag_actualproofdate = "true";
                        this.cellvalue_actualproofdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "filestatus")
                    {
                        this.flag_filestatus = "true";
                        this.cellvalue_filestatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactname")
                    {
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "actualproofapprovaldate")
                    {
                        this.flag_proofapprovaldate = "true";
                        this.cellvalue_proofapprovaldate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofitemstatus")
                    {
                        this.flag_proofitemstatus = "true";
                        this.cellvalue_proofitemstatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_deliverydate = "true";
                        this.cellvalue_deliverydate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "artworkdate")
                    {
                        this.flag_artworkdate = "true";
                        this.cellvalue_artworkdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofdate")
                    {
                        this.flag_proofdate = "true";
                        this.cellvalue_proofdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "productiondate")
                    {
                        this.flag_productiondate = "true";
                        this.cellvalue_productiondate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;

                string str = string.Empty;
                string empty1 = string.Empty;

                string empty2 = string.Empty;

                string str2 = string.Empty;
                empty = ((DataRowView)e.Item.DataItem)[3].ToString();
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                htmlInputCheckBox.Value = ((DataRowView)e.Item.DataItem)[0].ToString();

                string ProofID = item["ProofID"].Text;
                string EstimateID = item["EstimateID"].Text;
                string EstimateItemID = item["EstimateItemID"].Text;
                str2 = "" + this.strSitepath + "Proofs/Proof_summary.aspx?estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&ProofID=" + ProofID + "";
                string type = string.Empty;
                string jobID = string.Empty;
                if (this.flag_estimatenumber == "true")
                {

                    item[this.cellvalue_estimatenumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_estimatenumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_proofnumber == "true")
                {

                    item[this.cellvalue_proofnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_proofnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_itemtitle == "true")
                {

                    item[this.cellvalue_itemtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_itemtitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_jobtitle == "true")
                {

                    item[this.cellvalue_jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_jobtitle].Style.Add("cursor", "pointer");
                }



                if (this.flag_proofstatus == "true")
                {

                    item[this.cellvalue_proofstatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_proofstatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_proofstatus].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line

                }


                if (this.flag_SinceEmailed == "true")
                {
                    item[this.cellvalue_SinceEmailed].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceEmailed"].Text) >= Convert.ToInt32(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceEmailed"].Text != "0")
                            item[this.cellvalue_SinceEmailed].Style.Add("background-color", "#E64557"); // Add this line

                    if (item["isAnyEmailed"].Text == "0")
                        item[this.cellvalue_SinceEmailed].Text = "N/A";
                    item[this.cellvalue_SinceEmailed].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_SinceEmailed].Style.Add("cursor", "pointer");
                }
                if (this.flag_SinceStatusUpdate == "true")
                {
                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceStatusUpdate"].Text) >= Convert.ToInt32(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceStatusUpdate"].Text != "0")
                            item[this.cellvalue_SinceStatusUpdate].Style.Add("background-color", "#E64557"); // Add this line

                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_SinceStatusUpdate].Style.Add("cursor", "pointer");
                }


                if (this.flag_creationdate == "true")
                {
                    item[this.cellvalue_creationdate].Attributes.Add("align", "center");
                    item[this.cellvalue_creationdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_creationdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_file == "true")
                {

                    item[this.cellvalue_file].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_file].Style.Add("cursor", "pointer");
                }
                if (this.flag_proofcomments == "true")
                {
                    item[this.cellvalue_proofcomments].Style.Add("white-space", "nowrap");
                    item[this.cellvalue_proofcomments].Style.Add("overflow", "hidden");
                    item[this.cellvalue_proofcomments].Style.Add("text-overflow", "ellipsis");
                }
                if (this.flag_jobnumber == "true")
                {

                    item[this.cellvalue_jobnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_jobnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_customername == "true")
                {

                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_actualproofdate == "true")
                {

                    item[this.cellvalue_actualproofdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_actualproofdate].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate1 == "true")
                {
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }


                if (this.flag_filestatus == "true")
                {

                    item[this.cellvalue_filestatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_filestatus].Style.Add("cursor", "pointer");
                    if (item[this.cellvalue_filestatus].Text == "Approved")
                    {
                        item[this.cellvalue_filestatus].Style.Add("background-color", "#01DA66");
                    }
                    if (item[this.cellvalue_filestatus].Text == "Rejected")
                    {
                        item[this.cellvalue_filestatus].Style.Add("background-color", "#E64557");
                    }
                }

                if (this.flag_Archive == "true") // Using flag_DownloadTemplate
                {
                    string estimateId = item["EstimateID"].Text;

                    string ProofIDx = item["ProofID"].Text;
                    
                    string estimateitemid = string.Empty;

                    //string proofitemid = item["id"].Text; ;

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
                    link.Attributes["onclick"] = $"CheckOne('archive', '{((DataRowView)e.Item.DataItem)[0].ToString()}','{estimateitemid}');"; // call JS function
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

                if (this.flag_contactname == "true")
                {

                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                }
                if (this.flag_proofapprovaldate == "true")
                {

                    item[this.cellvalue_proofapprovaldate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_proofapprovaldate].Style.Add("cursor", "pointer");
                }
                if (this.flag_proofitemstatus == "true")
                {

                    item[this.cellvalue_proofitemstatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str2, "');"));
                    item[this.cellvalue_proofitemstatus].Style.Add("cursor", "pointer");
                }

                if (this.flag_salesperson == "true")
                {
                    var salesPerson = item[this.cellvalue_salesperson].Text;
                    if (salesPerson == "&nbsp;")
                    {
                        salesPerson = "";
                    }
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_salesperson].Text = "-";
                        item[this.cellvalue_salesperson].Attributes.Add("align", "center");

                    }
                    else
                    {
                        jobID = item["JobId"].Text;
                        type = "SalesPerson";
                        salesPerson = string.IsNullOrEmpty(salesPerson) == true ? "Select Sales Person" : salesPerson;
                        item[this.cellvalue_salesperson].Text = salesPerson;
                        item[this.cellvalue_salesperson].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnSalesPersonClick(" + jobID + ", " + item["SalesPersonId"].Text + "," + item["Cust_ID"].Text + ",'" + type + "')"));
                        item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                        item[this.cellvalue_salesperson].Attributes.Add("align", "center");

                    }

                }
                if (this.flag_estimator == "true")
                {
                    var salesPerson = item[this.cellvalue_estimator].Text;
                    if (salesPerson == "&nbsp;")
                    {
                        salesPerson = "";
                    }
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_estimator].Text = "-";
                        item[this.cellvalue_estimator].Attributes.Add("align", "center");

                    }
                    else
                    {
                        jobID = item["JobId"].Text;
                        type = "estimator";
                        salesPerson = string.IsNullOrEmpty(salesPerson) == true ? "Select Estimator" : salesPerson;
                        item[this.cellvalue_estimator].Text = salesPerson;
                        item[this.cellvalue_estimator].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_estimator].Attributes.Add("onclick", string.Concat("javascript:OnSalesPersonClick(" + jobID + ", " + item["SalesPersonId"].Text + "," + item["Cust_ID"].Text + ",'" + type + "')"));
                        item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                        item[this.cellvalue_estimator].Attributes.Add("align", "center");
                    }

                }
                if (this.flag_deliverydate == "true")
                {
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_deliverydate].Attributes.Add("align", "left");
                        item[this.cellvalue_deliverydate].Text = "-";
                    }
                    else
                    {
                        item[this.cellvalue_deliverydate].Attributes.Add("align", "left");

                        item[this.cellvalue_deliverydate].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_deliverydate].Attributes.Add("onclick",
                           string.Concat("javascript:OnDeliveryDateClick('",
                           item[this.cellvalue_deliverydate].Text, "'," + item["JobID"].Text + " );"/*lcs(this,'" + this.DateFormat +"');"*/));

                        item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                    }

                    //if (this.DateTypeSelected == "" || this.DateTypeSelected == "Delivey")
                    //{
                    //    try
                    //    {
                    //        string str4 = string.Empty;
                    //        string empty5 = string.Empty;
                    //        int days = 0;
                    //        TimeSpan timeSpan = new TimeSpan();
                    //        str4 = DateTime.Now.ToString();
                    //        item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));

                    //        commonClass _commonClass = this.objJava;
                    //        now = DateTime.Now;
                    //        _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CheckIntegerNull(this.CompanyID), CheckIntegerNull(this.UserID), true);
                    //        now = this.objJava.Eprint_return_ActualDate_Before_View(str4, this.CompanyID, this.UserID, true);
                    //        DateTime dateTime = CheckDateTimeNull(now.ToShortDateString());
                    //        now = CheckDateTimeNull(item[this.cellvalue_deliverydate].Text);
                    //        DateTime dateTime1 = CheckDateTimeNull(now.ToShortDateString());
                    //        timeSpan = dateTime1 - dateTime;
                    //        days = timeSpan.Days;
                    //        if (days > 0)
                    //        {
                    //            DataRow[] dataRowArray2 = this.dtColor.Select(string.Concat("Days>= ", days));
                    //            if ((int)dataRowArray2.Length > 0)
                    //            {
                    //                empty5 = dataRowArray2[0]["color"].ToString();
                    //            }
                    //            item.BackColor = ColorTranslator.FromHtml(empty5);
                    //        }
                    //        else if (days == 0)
                    //        {
                    //            DataRow[] dataRowArray3 = this.dtColor.Select("[optionType]= 'On same day'");
                    //            if ((int)dataRowArray3.Length > 0)
                    //            {
                    //                empty5 = dataRowArray3[0]["color"].ToString();
                    //            }
                    //            item.BackColor = ColorTranslator.FromHtml(empty5);
                    //        }
                    //        else if (days < 0)
                    //        {
                    //            DataRow[] dataRowArray4 = this.dtColor.Select("[optionType]= 'elapsed'");
                    //            if ((int)dataRowArray4.Length > 0)
                    //            {
                    //                empty5 = dataRowArray4[0]["color"].ToString();
                    //            }
                    //            item.BackColor = ColorTranslator.FromHtml(empty5);
                    //        }
                    //        //deliveryDate = string.IsNullOrEmpty(deliveryDate) == true ? "Set Delivery Date" : deliveryDate;
                    //        //item[this.cellvalue_deliverydate].Text = deliveryDate;
                    //        item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}
                }
                if (this.flag_artworkdate == "true")
                {
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_artworkdate].Attributes.Add("align", "left");
                        item[this.cellvalue_artworkdate].Text = "-";
                    }
                    else
                    {
                        item[this.cellvalue_artworkdate].Attributes.Add("align", "left");
                        item[this.cellvalue_artworkdate].Attributes.Add("class", "hyperlinkStyle");

                        item[this.cellvalue_artworkdate].Attributes.Add("onclick",
                        string.Concat("javascript:OnArtworkDateClick('",
                        item[this.cellvalue_artworkdate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                        item[this.cellvalue_artworkdate].Style.Add("cursor", "pointer");
                    }

                }
                if (this.flag_proofdate == "true")
                {
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_proofdate].Attributes.Add("align", "left");
                        item[this.cellvalue_proofdate].Text = "-";
                    }
                    else
                    {
                        item[this.cellvalue_proofdate].Attributes.Add("align", "left");
                        item[this.cellvalue_proofdate].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_proofdate].Attributes.Add("onclick",
                         string.Concat("javascript:OnProofDateClick('",
                         item[this.cellvalue_proofdate].Text, "'," + item["JobID"].Text + " );"));
                        item[this.cellvalue_proofdate].Style.Add("cursor", "pointer");
                    }

                }

                if (this.flag_productiondate == "true")
                {
                    if (item["JobId"].Text == "&nbsp;")
                    {
                        item[this.cellvalue_productiondate].Attributes.Add("align", "left");
                        item[this.cellvalue_productiondate].Text = "-";
                    }
                    else
                    {
                        item[this.cellvalue_productiondate].Attributes.Add("align", "left");
                        item[this.cellvalue_productiondate].Attributes.Add("class", "hyperlinkStyle");
                        //item[this.cellvalue_productiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                        item[this.cellvalue_productiondate].Attributes.Add("onclick",
                        string.Concat("javascript:OnProductionDateClick('",
                        item[this.cellvalue_productiondate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                        item[this.cellvalue_productiondate].Style.Add("cursor", "pointer");
                    }
                }

                //TableCell item1 = item["EstimateNumber"];
                //languageConversion = new string[] { "<a href=", this.strSitepath, "Proofs/Proof_summary.aspx?estid=", empty, "&EstItemID=", ((DataRowView)e.Item.DataItem)[2].ToString(), "&ProofID=", ((DataRowView)e.Item.DataItem)[5].ToString(), ">", item["estimatenumber"].Text, "</a>" };
                //item1.Text = string.Concat(languageConversion);





            }

            //if (e.Item is GridGroupHeaderItem groupHeader)
            //{
            //    // Make the whole "Est. Status: Completed" text bold and 14px
            //    groupHeader.Font.Bold = true;
            //    groupHeader.Font.Size = FontUnit.Point(14);

            //}
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            Proofs.SortedBy = e.SortExpression;
            Proofs.sortdirection = e.NewSortOrder.ToString();
            if (Proofs.sortdirection.ToLower() == "ascending")
            {
                Proofs.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (Proofs.sortdirection.ToLower() != "descending")
            {
                Proofs.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                Proofs.sortdirection = "DESC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, CheckIntegerNull(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, Proofs.sortdirection, Proofs.WhereCondition);
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

        protected void GridView1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {

        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, CheckIntegerNull(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), Proofs.SortedBy, Proofs.sortdirection, Proofs.WhereCondition);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {

            //if (e.CommandName == "RowClick" && e.Item is GridDataItem)
            //{
            //    GridDataItem dataItem = (GridDataItem)e.Item;

            //    string empty = string.Empty;
            //    string ProofID = dataItem["ProofID"].Text;
            //    string EstimateID = dataItem["EstimateID"].Text;
            //    string EstimateItemID = dataItem["EstimateItemID"].Text;
            //    Response.Redirect("" + this.strSitepath + "Proofs/Proof_summary.aspx?estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&ProofID=" + ProofID + "");

            //}
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                Proofs.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "estimatenumber" || commandArgument.Second.ToString().ToLower() == "proofnumber" || commandArgument.Second.ToString().ToLower() == "itemtitlevalue" || commandArgument.Second.ToString().ToLower() == "jobtitle" || commandArgument.Second.ToString().ToLower() == "filestatus" || commandArgument.Second.ToString().ToLower() == "proofdate" || commandArgument.Second.ToString().ToLower() == "file"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = item.Text;
                }
                if (this.Session["search_proof"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_proof"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_proof"];
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
                this.Session["search_proof"] = this.dtsearch;
                Proofs.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, Proofs.SortedBy, Proofs.sortdirection, Proofs.WhereCondition);
                this.GridView1.Rebind();
            }
        }
        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("proofs_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("proofs_", ColName.ToLower())] = "";
        }
    }
}
