using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;

using System.Collections;
using System.Collections.Specialized;
using System.Data;

using System.Web.Profile;
using System.Web.SessionState;

using System.Web.UI.HtmlControls;

using Telerik.Web.UI;
namespace ePrint.Jobs
{
    public partial class UpdateJobStatusWithScanner : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private BasePage objpage = new BasePage();

        public static BaseClass objBase;

        private commonClass commclass = new commonClass();

        private Global gloobj = new Global();

        private DataTable dtsearch = new DataTable();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private WebstoreBasePage objPro = new WebstoreBasePage();

        private SettingsBasePage objSetting = new SettingsBasePage();

        public languageClass objlang = new languageClass();

        public static int CompanyID;

        public static int UserID;

        public int AccountID;

        public int count;

        public int PageSize = 10000;

        public int PageNumber;

        public int PageIndex = 1;

        public int totalrec;

        public int sortcount;

        public int publicAccountCnt;

        public string action = "add";

        public string para = "";

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string SecureVirtualPath = string.Empty;

        public static string whereCondition;

        public static string sortdirection;

        public static string sortedBy;

        public string colorformat = string.Empty;

        public string companyType = "Customer";

        public long PriceCatalogueGroupID;

        public string PriceCatalogueGroup = string.Empty;

        public string ServerName = string.Empty;

        public string SecDocumentSitePath = string.Empty;

        public static long catID;

        public string AddStatus = string.Empty;

        public string DeleteStatus = string.Empty;

        private bool flag;

        private bool Err_flag = true;

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

        static UpdateJobStatusWithScanner()
        {
            UpdateJobStatusWithScanner.objBase = new BaseClass();
            UpdateJobStatusWithScanner.CompanyID = 0;
            UpdateJobStatusWithScanner.UserID = 0;
            UpdateJobStatusWithScanner.whereCondition = string.Empty;
            UpdateJobStatusWithScanner.sortdirection = string.Empty;
            UpdateJobStatusWithScanner.sortedBy = string.Empty;
            UpdateJobStatusWithScanner.catID = (long)0;
        }

        public UpdateJobStatusWithScanner()
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/UpdateJobStatusWithScanner.aspx?&mode=add"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        WebstoreBasePage.productGroup_Delete(Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            //this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0, (long)0);
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/UpdateJobStatusWithScanner.aspx?suc=del&mode=add"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {               
                //if (txtEstimateItemID.Text != "" && txtJobStatus.Text != "")
                //txtJobStatus.Text = "2775";
                if (txtJobItemStatus.Text != "")
                {                  
                    string str = txtJobItemStatus.Text;
                    string[] values = str.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                        if (values[i] != "" && values[i].ToLower().Contains("job-"))
                        {
                            string jobItem = "";
                            int StatusId = 0;
                            int estimateItemID = 0;
                            jobItem = Convert.ToString(values[i].Trim());
                            //StatusId = Convert.ToInt32(txtJobStatus.Text);

                            if (Session["dt"] != null)
                            {
                                DataTable dt = new DataTable();
                                dt = (DataTable)Session["dt"];
                                DataTable dataTable = WebstoreBasePage.JobItem_Select(CompanyID, jobItem, StatusId);
                                if (dataTable != null && dataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        DataRow row1 = dt.NewRow();

                                        row1["JobId"] = Convert.ToInt32(row["JobId"].ToString());
                                        row1["JobItemNumber"] = base.SpecialEncode(row["JobItemNumber"].ToString());
                                        row1["JOBItemStatusID"] = Convert.ToInt32(row["JOBItemStatusID"].ToString());
                                        row1["ItemStatusTitle"] = Convert.ToString(row["ItemStatusTitle"].ToString());
                                        row1["JOBItemStatusID"] = Convert.ToInt32(row["JOBItemStatusID"].ToString());
                                        row1["EstimateItemID"] = Convert.ToInt32(row["EstimateItemID"].ToString());

                                        estimateItemID = Convert.ToInt32(row["EstimateItemID"].ToString());
                                        row1["EstimateID"] = Convert.ToInt32(row["EstimateID"].ToString());

                                        // new columns
                                        row1["DateTime"] = Convert.ToString(DateTime.Now);
                                        row1["CustomerName"] = Convert.ToString(row["CustomerName"]);
                                        row1["ItemTitle"] = Convert.ToString(row["ItemTitle"]);

                                        dt.Rows.Add(row1);
                                        dt.AcceptChanges();
                                        Session["dt"] = dt;
                                        //ClrTextboxes();
                                    }
                                }
                                else
                                {                                  
                                    UpdateJobStatusWithScanner.objBase.Message_Display("Scanned Job Item No and status not found", "msg-fail", this.plhMessage);
                                    ClrTextboxes();
                                }

                            }
                            else
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add(new DataColumn("JobId", typeof(int)));
                                dt.Columns.Add(new DataColumn("JobItemNumber", typeof(string)));
                                dt.Columns.Add(new DataColumn("JOBItemStatusID", typeof(int)));
                                dt.Columns.Add(new DataColumn("ItemStatusTitle", typeof(string)));
                                dt.Columns.Add(new DataColumn("EstimateItemID", typeof(int)));
                                dt.Columns.Add(new DataColumn("EstimateID", typeof(int)));
                                // new columns
                                dt.Columns.Add(new DataColumn("DateTime", typeof(string)));
                                dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                                dt.Columns.Add(new DataColumn("ItemTitle", typeof(string)));

                                Session["dt"] = dt;

                                DataTable dataTable = WebstoreBasePage.JobItem_Select(CompanyID, jobItem, StatusId);
                                if (dataTable != null)
                                {
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dataTable.Rows)
                                        {
                                            DataRow row1 = dt.NewRow();

                                            row1["JobId"] = Convert.ToInt32(row["JobId"].ToString());
                                            row1["JobItemNumber"] = base.SpecialEncode(row["JobItemNumber"].ToString());
                                            row1["JOBItemStatusID"] = Convert.ToInt32(row["JOBItemStatusID"].ToString());
                                            row1["ItemStatusTitle"] = Convert.ToString(row["ItemStatusTitle"].ToString());
                                            row1["JOBItemStatusID"] = Convert.ToInt32(row["JOBItemStatusID"].ToString());
                                            row1["EstimateItemID"] = Convert.ToInt32(row["EstimateItemID"].ToString());
                                            estimateItemID = Convert.ToInt32(row["EstimateItemID"].ToString());
                                            row1["EstimateID"] = Convert.ToInt32(row["EstimateID"].ToString());
                                            // new columns
                                            row1["DateTime"] = Convert.ToString(DateTime.Now);
                                            row1["CustomerName"] = Convert.ToString(row["CustomerName"]);
                                            row1["ItemTitle"] = Convert.ToString(row["ItemTitle"]);

                                            dt.Rows.Add(row1);
                                            dt.AcceptChanges();
                                            Session["dt"] = dt;
                                            //ClrTextboxes();
                                        }
                                    }
                                    else
                                    {                                        
                                        UpdateJobStatusWithScanner.objBase.Message_Display("Scanned Job Item No and status not found", "msg-fail", this.plhMessage);
                                        ClrTextboxes();
                                    }
                                }
                            }
                        }
                        else if (values[i] != "" ) // else if (values[i] != "" && values[i].ToLower().Contains("js-"))
                        {
                            string jobItemStatusTitle = "";
                            int statusid = 0;
                            string statustitle = "";
                            jobItemStatusTitle = Convert.ToString(values[i].Trim());
                            // test code comment it later
                            //jobItemStatusTitle = jobItemStatusTitle.ToLower().Replace("js-", "").Trim();
                            //jobItemStatusTitle = jobItemStatusTitle.ToLower().Replace("-", " ").Trim();

                            DataTable statusTable = WebstoreBasePage.JobItemStatus_Select(CompanyID, jobItemStatusTitle);
                            if (statusTable.Rows.Count > 0)
                            {
                                foreach (DataRow row in statusTable.Rows)
                                {
                                    //DataRow row1 = dt.NewRow();

                                    statusid = Convert.ToInt32(row["StatusID"].ToString());
                                    statustitle = base.SpecialEncode(row["StatusTitle"].ToString());

                                    //dt.Rows.Add(row1);
                                    //dt.AcceptChanges();
                                    //Session["dt"] = dt;
                                    //item_summary itemSummary = new item_summary();
                                    DataTable tblFinal = new DataTable();
                                    tblFinal.Columns.Add(new DataColumn("JobId", typeof(int)));
                                    tblFinal.Columns.Add(new DataColumn("JobItemNumber", typeof(string)));
                                    tblFinal.Columns.Add(new DataColumn("JOBItemStatusID", typeof(int)));
                                    tblFinal.Columns.Add(new DataColumn("ItemStatusTitle", typeof(string)));
                                    tblFinal.Columns.Add(new DataColumn("EstimateItemID", typeof(int)));
                                    tblFinal.Columns.Add(new DataColumn("EstimateID", typeof(int)));
                                    // new columns
                                    tblFinal.Columns.Add(new DataColumn("DateTime", typeof(string)));
                                    tblFinal.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                                    tblFinal.Columns.Add(new DataColumn("ItemTitle", typeof(string)));

                                    // history
                                    DataTable tblSave = new DataTable();
                                    tblSave.Columns.Add(new DataColumn("JobId", typeof(int)));
                                    tblSave.Columns.Add(new DataColumn("JobItemNumber", typeof(string)));
                                    tblSave.Columns.Add(new DataColumn("JOBItemStatusID", typeof(int)));
                                    tblSave.Columns.Add(new DataColumn("ItemStatusTitle", typeof(string)));
                                    tblSave.Columns.Add(new DataColumn("EstimateItemID", typeof(int)));
                                    tblSave.Columns.Add(new DataColumn("EstimateID", typeof(int)));
                                    tblSave.Columns.Add(new DataColumn("DateTime", typeof(string)));
                                    tblSave.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                                    tblSave.Columns.Add(new DataColumn("ItemTitle", typeof(string)));

                                    DataTable dt = new DataTable();
                                    if (Session["dt"] != null)
                                    {
                                        dt = (DataTable)Session["dt"];

                                        if (dt.Rows.Count > 0)
                                        {
                                            //history
                                            DataView dv = new DataView(dt);
                                            dv.RowFilter = "JOBItemStatusID = 0 AND ItemStatusTitle = '' ";
                                            DataTable tblSaveFinal = dv.ToTable();
                                            foreach (DataRow r in tblSaveFinal.Rows)
                                            {
                                                DataRow rowSave = tblSave.NewRow();
                                                rowSave["JobId"] = Convert.ToInt32(r["JobId"].ToString());
                                                rowSave["JobItemNumber"] = base.SpecialEncode(r["JobItemNumber"].ToString());
                                                // history
                                                if ((r["JOBItemStatusID"].ToString() != "0") && (r["ItemStatusTitle"].ToString() != ""))
                                                {
                                                    //rowSave["JOBItemStatusID"] = Convert.ToInt32(rw["JOBItemStatusID"].ToString());
                                                    //rowSave["ItemStatusTitle"] = Convert.ToString(rw["ItemStatusTitle"].ToString());
                                                }
                                                else
                                                {
                                                    rowSave["JOBItemStatusID"] = statusid;
                                                    rowSave["ItemStatusTitle"] = statustitle;
                                                }

                                                rowSave["EstimateItemID"] = Convert.ToInt32(r["EstimateItemID"].ToString());
                                                rowSave["EstimateID"] = Convert.ToInt32(r["EstimateID"].ToString());
                                                // new columns
                                                rowSave["DateTime"] = Convert.ToString(r["DateTime"]);
                                                rowSave["CustomerName"] = Convert.ToString(r["CustomerName"]);
                                                rowSave["ItemTitle"] = Convert.ToString(r["ItemTitle"]);

                                                tblSave.Rows.Add(rowSave);
                                                tblSave.AcceptChanges();

                                                bool isSave = false;
                                                item_summary itemSummary = new item_summary();
                                                isSave = itemSummary.EstJobInvIduvidualItemStatuS_Update(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(rowSave["EstimateItemID"].ToString()), Convert.ToInt32(rowSave["EstimateID"].ToString()), Convert.ToInt32(rowSave["JOBItemStatusID"].ToString()), "job");
                                                if (isSave)
                                                {
                                                    UpdateJobStatusWithScanner.objBase.Message_Display("All scanned job items status updated successfully", "msg-success", this.plhMessage);
                                                    //ClrTextboxes();                                                    
                                                }
                                            }

                                            foreach (DataRow rw in dt.Rows)
                                            {
                                                DataRow rowfinal = tblFinal.NewRow();

                                                rowfinal["JobId"] = Convert.ToInt32(rw["JobId"].ToString());
                                                rowfinal["JobItemNumber"] = base.SpecialEncode(rw["JobItemNumber"].ToString());
                                                // history
                                                if ((rw["JOBItemStatusID"].ToString() != "0") && (rw["ItemStatusTitle"].ToString() != ""))
                                                {
                                                    rowfinal["JOBItemStatusID"] = Convert.ToInt32(rw["JOBItemStatusID"].ToString());                                         
                                                    rowfinal["ItemStatusTitle"] = Convert.ToString(rw["ItemStatusTitle"].ToString());  
                                                }
                                                else
                                                {
                                                    rowfinal["JOBItemStatusID"] = statusid;
                                                    rowfinal["ItemStatusTitle"] = statustitle;                                      
                                                }
                                                
                                                rowfinal["EstimateItemID"] = Convert.ToInt32(rw["EstimateItemID"].ToString());
                                                rowfinal["EstimateID"] = Convert.ToInt32(rw["EstimateID"].ToString());
                                                // new columns
                                                rowfinal["DateTime"] = Convert.ToString(rw["DateTime"]);
                                                rowfinal["CustomerName"] = Convert.ToString(rw["CustomerName"]);
                                                rowfinal["ItemTitle"] = Convert.ToString(rw["ItemTitle"]);

                                                tblFinal.Rows.Add(rowfinal);
                                                tblFinal.AcceptChanges();
                                                //itemSummary.EstJobInvIduvidualItemStatuS_Update(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(row["EstimateItemID"].ToString()), Convert.ToInt32(row["EstimateID"].ToString()), Convert.ToInt32(row["JOBItemStatusID"].ToString()), "job");
                                                Session["dt"] = tblFinal;
                                            }
                                        }
                                    }
                                    //ClrTextboxes();
                                }
                            }
                            else
                            {                               
                                UpdateJobStatusWithScanner.objBase.Message_Display("Scanned Job Item No and status not found", "msg-fail", this.plhMessage);
                                ClrTextboxes();
                            }
                            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), 0, 0);
                            ClrTextboxes();
                            //SaveAll();
                        }
                    }
                }
                else
                {
                    UpdateJobStatusWithScanner.objBase.Message_Display("Please Scan Job Item No and it's status", "msg-fail", this.plhMessage);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        private void ClrTextboxes()
        {
            txtJobItemStatus.Text = "";
            txtJobStatus.Text = "";
            txtJobItemStatus.Focus();
            //Session["dt"] = null;
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), 0, 0);

        }
        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridView1.MasterTableView.Rebind();
        }

        public void gridBinding(int CompanyID, long estimateItemID, long StatusId)
        {
           
            //DataTable dataTable = WebstoreBasePage.ProductCatalogueGroup_SelectViewAll(CompanyID, (long)0, "");
            DataTable dt = new DataTable();
            DataTable finaltable = new DataTable();
            if (Session["dt"] != null)
            {
                dt = (DataTable)Session["dt"];
                DataView dvFinal = dt.DefaultView;
                dvFinal.Sort = "DateTime desc";
                finaltable = dvFinal.ToTable();
            }
            else
            {
               
            }
            this.GridView1.DataSource = finaltable;
            //this.GridView1.DataBind();
            this.GridView1.Rebind();
        }

        private void GridStateLoad()
        {
            this.commclass.GridStateLoadNew("setting", "JobItemStatus", this.GridView1, "no");
        }

        private void GridStateSave()
        {
            this.commclass.GridStateSaveNew("setting", "JobItemStatus", this.GridView1);
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            //this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), 0, 0);
            DataTable table = (DataTable)Session["dt"];
            
            this.GridView1.DataSource =table;
        }
               
        protected void lnkloadCatagory_click(object sender, EventArgs e)
        {
            this.GridView1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Category_Copied_Successfully"), "msg-success", this.plhMessage_Delete);
        }

        protected override void OnInit(EventArgs e)
        {
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.SecureVirtualPath != null)
            {
                this.SecureVirtualPath = ConnectionClass.SecureVirtualPath;
            }
            this.SecDocumentSitePath = this.SecureSitePath;
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
            this.GridView1.Columns[1].HeaderText = "Additional Options Group Name";
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            GridTableView masterTableView = this.GridView1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                QueryString queryString = new QueryString()
            {
                { "catagoryName", ((DataRowView)e.Item.DataItem)[2].ToString() }
            };
                string str = string.Concat(this.strSitepath, "ProductCatalogue/UpdateJobStatusWithScanner.aspx?&mode=edit");
                Label label = (Label)e.Item.FindControl("lblgroupname");
                label.Text = UpdateJobStatusWithScanner.objBase.SpecialDecode(label.Text);
                try
                {
                    this.PriceCatalogueGroupID = (long)Convert.ToInt32(((DataRowView)e.Item.DataItem)[0].ToString());
                }
                catch
                {
                }
                str = string.Concat(str, "&GroupID=", this.PriceCatalogueGroupID);
                GridDataItem item = (GridDataItem)e.Item;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.txtJobId.Text = "";
            this.txtJobItemStatus.Focus();
            //txtJobId.Attributes.Add("onkeypress", "return handleEnter('" + txtJobId.ClientID + "', event)");

            BaseClass baseClass = new BaseClass();
            this.gloobj.setpagename("UpdateJobStatusWithScanner");
            UpdateJobStatusWithScanner.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            UpdateJobStatusWithScanner.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Navigation_Path(string.Concat("<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator' style=text-decoration:underline>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>"), "&nbsp;>&nbsp;Scanning");
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue Category", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(UpdateJobStatusWithScanner.CompanyID, "colour");
            this.GridView1.MasterTableView.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Job_Item_No");
            this.GridView1.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Job_Item_Status");
            this.GridView1.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Date_Time");
            this.GridView1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Customer_Name");
            this.GridView1.MasterTableView.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Item_Title");

            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Load_Job");
            UpdateJobStatusWithScanner.sortdirection = "asc";
            if (base.Request.Params["mode"] != null)
            {
                this.action = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit" && base.Request.Params["GroupID"] != null)
            {
                this.PriceCatalogueGroupID = Convert.ToInt64(base.Request.Params["GroupID"]);
            }
            if (this.hdn_addoption_mode.Value == "edit" && this.txtJobItemStatus.Text != "")
            {
                this.action = "edit";
            }
            if (this.hdn_addoption_groupid.Value != "")
            {
                this.PriceCatalogueGroupID = (long)Convert.ToInt32(this.hdn_addoption_groupid.Value);
            }
            this.btnDelete.Attributes.Add("onclick", "javascript:return CallDelete();");

            // Scanning function
            if (!IsPostBack && Session["dt"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("JobId", typeof(int)));
                dt.Columns.Add(new DataColumn("JobItemNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("JOBItemStatusID", typeof(int)));
                dt.Columns.Add(new DataColumn("ItemStatusTitle", typeof(string)));
                dt.Columns.Add(new DataColumn("EstimateItemID", typeof(int)));
                dt.Columns.Add(new DataColumn("EstimateID", typeof(int)));
                // new columns
                dt.Columns.Add(new DataColumn("DateTime", typeof(string)));
                dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemTitle", typeof(string)));
                Session["dt"] = dt;
            }
            if (!base.IsPostBack)
            {  
                this.GridStateLoad();
                this.txtJobItemStatus.Focus();
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "in")
                    {
                        UpdateJobStatusWithScanner.objBase.Message_Display("Additional Options Group saved successfully", "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "del")
                    {
                        //base.Message_Display("Additional Options Group deleted successfully", "msg-success", this.plhMessage_Delete);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "up")
                    {
                        UpdateJobStatusWithScanner.objBase.Message_Display("Additional Options Group updated successfully", "msg-success", this.plhMessage);
                    }
                }
               
            }
           
            ImageButton imageButton = (ImageButton)base.Master.FindControl("ImageButton1");
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), 195350, 2775);
            //AttributeCollection attributes = this.Select.Attributes;
            //object[] priceCatalogueGroupID = new object[] { "javascript:openPopUp1('", this.PriceCatalogueGroupID, "','", this.action, "','", UpdateJobStatusWithScanner.objBase.SpecialEncode(this.PriceCatalogueGroup), "');" };
            //attributes.Add("onclick", string.Concat(priceCatalogueGroupID));
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() != "add")
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueGroupID)] = null;
                }
                else if (!base.IsPostBack)
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueGroupID)] = null;
                    return;
                }
            }
        }

        protected void btnSaveStay_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        protected void SaveAll()
        {
            try
            {
                bool result = false;
                item_summary itemSummary = new item_summary();
                DataTable dt = new DataTable();
                if (Session["dt"] != null)
                {
                    dt = (DataTable)Session["dt"];

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {

                            result = itemSummary.EstJobInvIduvidualItemStatuS_Update(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(row["EstimateItemID"].ToString()), Convert.ToInt32(row["EstimateID"].ToString()), Convert.ToInt32(row["JOBItemStatusID"].ToString()), "job");
                        }
                    }
                }
                if (result)
                {
                    UpdateJobStatusWithScanner.objBase.Message_Display("All scanned job items status updated successfully", "msg-success", this.plhMessage);
                    ClrTextboxes();
                    //txtJobItemStatus.Text = "";
                    //txtJobStatus.Text = "";
                    //txtJobItemStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

    }
   
}