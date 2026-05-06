using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using DMCOrdersImport;
using System.Configuration;
using nmsConnectionClass;

namespace ePrint.Import_Order
{
    public partial class import_order : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private commonClass commclass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public string DateFormat = "mm/dd/yyyy";

        public string Type = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        private DateTime EventStartDate;

        private DateTime EventEndDate;

        public string AccountType = string.Empty;

        public string Comments = string.Empty;

        public string IswebStore = string.Empty;

        public long OrderImportID;

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

        public import_order()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {           
            string fileName = this.fileuploadBrowseFile.FileName;
            string str = Guid.NewGuid().ToString();
            string str1 = string.Concat(str, fileName);
            if (this.fileuploadBrowseFile.HasFile)
            {
                object[] secureDocPath = new object[] { this.SecureDocPath, "//", ConnectionClass.ServerName, "//", this.CompanyID, "//eStoreOrder" };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, "//", ConnectionClass.ServerName, "//", this.CompanyID, "//eStoreOrder" };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                object[] secureDocPath1 = new object[] { this.SecureDocPath, "//", ConnectionClass.ServerName, "//", this.CompanyID, "//eStoreOrder//", this.AccountID };
                if (!Directory.Exists(string.Concat(secureDocPath1)))
                {
                    object[] objArray1 = new object[] { this.SecureDocPath, "//", ConnectionClass.ServerName, "//", this.CompanyID, "//eStoreOrder//", this.AccountID };
                    Directory.CreateDirectory(string.Concat(objArray1));
                }
                object[] secureDocPath2 = new object[] { this.SecureDocPath, "//", ConnectionClass.ServerName, "//", this.CompanyID, "//eStoreOrder//", this.AccountID, "//", str1 };
                string str2 = string.Concat(secureDocPath2);
                if (!File.Exists(str2))
                {
                    this.fileuploadBrowseFile.SaveAs(str2);
                    Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                    DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_ImportOrder_Insert]");
                    database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, this.CompanyID);
                    database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, this.AccountID);
                    database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, this.UserID);
                    database.AddInParameter(storedProcCommand, "@IsImported", DbType.Int32, 0);
                    database.AddInParameter(storedProcCommand, "@FileName", DbType.String, str1);
                    database.AddInParameter(storedProcCommand, "@ActualFileName", DbType.String, fileName);
                    database.AddInParameter(storedProcCommand, "@Comments", DbType.String, this.Comments);
                    database.ExecuteNonQuery(storedProcCommand);
                }
            }
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Import_Order_Saved_Successfully"), "msg-success", this.plhMessage);

            // embed order import           
            try
            {
                string ServerName = ConfigurationManager.AppSettings["ServerName"];
                string UserId = ConfigurationManager.AppSettings["UserId"];
                string Password = ConfigurationManager.AppSettings["Password"];
                string FilePath = ConfigurationManager.AppSettings["FilePath"];
                string connectionString = (new commonClass()).conn.ConnectionString;
                string systemName = Convert.ToString(ConnectionClass.ServerName);

                DMCOrdersImport.Program p = new DMCOrdersImport.Program(ServerName, UserId, Password, FilePath, connectionString, systemName);
                DMCOrdersImportProcess.Program orderProcess = new DMCOrdersImportProcess.Program(ServerName, UserId, Password, connectionString);
                Response.Redirect("import_order.aspx");
            }
            catch (Exception ex)
            { throw ex; }
           
            
        }

        public virtual DataTable grdImportHistory_BindGrid()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImportOrder_Select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, this.AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Comments"] = this.objBase.SpecialDecode(row["Comments"].ToString());
            }
            return dataTable;
        }

        protected void grdImportHistory_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Label label = (Label)e.Item.FindControl("lblItemDateImported");
                    label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, false);
                    Label red = (Label)e.Item.FindControl("lblItemStatus");
                    if (red.Text.ToLower() == "pending")
                    {
                        red.ForeColor = Color.Red;
                    }
                    else if (red.Text.ToLower() == "success")
                    {
                        red.ForeColor = Color.Green;
                    }
                    else if (red.Text.ToLower() == "failed")
                    {
                        red.ForeColor = Color.Orange;
                    }
                }
            }
            catch
            {
            }
        }

        protected void lnkDownLoadDefault_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            FileInfo fileInfo = new FileInfo(string.Concat(this.SecureDocPath, "//eStoreOrderSampleFile//SamplesheetImportOrder.csv"));
            if (!fileInfo.Exists)
            {
                base.Response.Write("This file does not exist");
                return;
            }
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
            base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            base.Response.ContentType = "text/csv";
            base.Response.WriteFile(fileInfo.FullName);
            base.Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.lnkDownloadFile.Text = this.objLanguage.GetLanguageConversion("Download_File");
            this.rfvFileUpload.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Select_File_Name_For_Import");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Upload_Only_Csv_Type_Files");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Import_Orders")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = global.pageTitle(this.objLanguage.GetLanguageConversion("Import_Orders"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Import_Orders");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            this.DateFormat = this.Session["DateFormat"].ToString();
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();
        }
    }
}