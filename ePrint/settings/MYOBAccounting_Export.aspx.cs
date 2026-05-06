using System;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;

using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using nmsCommon;
using ExportSettings;
using FileExport;

namespace ePrint.settings
{
    public partial class MYOBAccounting_Export : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_Loading ucLoading;

        //protected RadWindowManager RadWindowManager1;

        //protected LinkButton lnkCallXeroApi;

        public string Pgtype = string.Empty;

        private Global gloobj = new Global();

        private commonClass cmncls = new commonClass();

        private ExportSetting expset = new ExportSetting();

        private DbExportSetting Dbexpset = new DbExportSetting();

        private ExportTODrive ExpTODrive = new ExportTODrive();

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass cmnclass = new commonClass();

        public string myobapiPath = string.Empty;

        public int CompanyID;

        public int UserID;

        public string DateFormat = string.Empty;

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

        public MYOBAccounting_Export()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.gloobj.setpagename("setting");
            this.Pgtype = "setting";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Myob_Accounting_Export")));
            base.Title = this.objLanguage.convert(global.pageTitle("MYOB Accounting", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
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
            object[] objArray = new object[] { ConfigurationManager.AppSettings["MyObAPI"].ToString(), "?key=", str, "&uid=", this.UserID };
            this.myobapiPath = string.Concat(objArray);
        }
    }
}