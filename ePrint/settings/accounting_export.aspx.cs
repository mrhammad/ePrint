using ExportSettings;
using FileExport;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class accounting_export : BaseClass, IRequiresSessionState
    {
        public string Pgtype = string.Empty;

        private Global gloobj = new Global();

        private commonClass cmncls = new commonClass();

        private ExportSetting expset = new ExportSetting();

        private DbExportSetting Dbexpset = new DbExportSetting();

        private ExportTODrive ExpTODrive = new ExportTODrive();

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass cmnclass = new commonClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CompanyID;

        public int UserID;

        public string MethodType = string.Empty;

        public string ModuleType = string.Empty;

        public int PageSize = 10000;

        public int PageIndex = 1;

        public string AccountingExport = ConnectionClass.AccountingExport;

        public bool IsFirstTime;

        public string DateFormat = string.Empty;

        public string[] day;

        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string year = string.Empty;

        public string pagename = string.Empty;

        public string ExportType = string.Empty;

        public string AccountingType = string.Empty;

        private string QueryType = string.Empty;

        public string newdate = string.Empty;

        public string xerotype = "1";

        public bool XeroOnlyItemTitle = ConnectionClass.XeroOnlyItemTitle;

        public string XeroAccountingCodeMode = ConnectionClass.XeroAccountingCodeMode;

        public string ConnectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();

        public string XeroAPI = EprintConfigurationManager.AppSettings["XeroAPI"].ToString();

        public string xeroapiPath = string.Empty;

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

        public accounting_export()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.gloobj.setpagename("setting");
            this.Pgtype = "setting";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Accounting_Export")));
            base.Title = this.objLanguage.convert(global.pageTitle("Accounting Export", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateFormat = this.Session["Dateformat"].ToString();
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Xero_ConnectKey_Select")
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
            string str = (string)sqlCommand.ExecuteScalar();
            object[] objArray = new object[] { EprintConfigurationManager.AppSettings["XeroAPI"].ToString(), "?key=", str, "&uid=", this.UserID };
            this.xeroapiPath = string.Concat(objArray);
        }
    }
}