using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using RKLib.ExportData;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class QuickbookAccounting_Online : System.Web.UI.Page
    {
        public string VersionNumber = ConnectionClass.VersionNumber;



        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        private commonClass comm = new commonClass();

        public string DateFormat = string.Empty;

        public string ServerName = ConnectionClass.ServerName;

        public string DateTimeForFileName = string.Empty;

        public string quickbooksAPIPath = string.Empty;

        public string Pgtype = string.Empty;

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

        public QuickbookAccounting_Online()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["DateFormat"].ToString();

            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("QuickBooks Accounting Online", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateTimeForFileName = DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss");


            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.gloobj.setpagename("setting");
            this.Pgtype = "setting";
            //string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            //base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Accounting_Export")));
            base.Title = this.objLanguage.convert(global.pageTitle("Accounting Export", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateFormat = this.Session["Dateformat"].ToString();
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            //SqlCommand sqlCommand = new SqlCommand("PC_Quickbooks_ConnectKey_Select")
            //{
            //    Connection = sqlConnection,
            //    CommandType = CommandType.StoredProcedure
            //};
            //sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            //sqlCommand.Parameters.AddWithValue("@System_Name", EprintConfigurationManager.AppSettings["HostName"].ToString());
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.CompanyID), new SqlParameter("@System_Name", EprintConfigurationManager.AppSettings["HostName"].ToString()) };

            DataSet dataSet = new DataSet();
            dataSet = SQL.ExecuteDataset(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString(), CommandType.StoredProcedure, "PC_Quickbooks_ConnectKey_Select", sqlParameter);

            string key = "";
            string secret = "";
            string environment = "";
            string redirectURL = "";


            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                key = row["QuickbooksClientID"].ToString();
                secret = row["QuickbooksClientSecret"].ToString();
                environment = row["AppEnvironment"].ToString();
                redirectURL = row["QuickbooksAPI"].ToString();
            }
            //string str = (string)sqlCommand.ExecuteScalar();
            object[] objArray = new object[] { EprintConfigurationManager.AppSettings["QuickbooksAPI"].ToString(), "?key=", key, "&uid=", this.UserID, "&secret=", secret, "&environment=", environment, "&redirectURL=", redirectURL };
            this.quickbooksAPIPath = string.Concat(objArray);

        }
    }
}