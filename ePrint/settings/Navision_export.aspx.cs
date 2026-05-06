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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class Navision_export : BaseClass, IRequiresSessionState
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

        public Navision_export()
        {
        }

        public DataTable AddBlankRow(DataTable dtMain, string MatchingColumnName)
        {
            if (dtMain.Rows.Count <= 0)
            {
                return dtMain;
            }
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            object[] objArray = new object[dtMain.Columns.Count];
            for (int i = 0; i < dtMain.Columns.Count; i++)
            {
                dataTable.Columns.Add(dtMain.Columns[i].ToString(), typeof(string));
                objArray[i] = "";
            }
            string empty = string.Empty;
            int num = 0;
            foreach (DataRow row in dtMain.Rows)
            {
                if (empty != row[MatchingColumnName].ToString() && num > 0)
                {
                    dataTable.Rows.Add(objArray);
                }
                dataTable.ImportRow(row);
                num++;
                empty = row[MatchingColumnName].ToString();
            }
            return dataTable;
        }

        protected void btn_JobExport_Click(object sender, EventArgs e)
        {
            string str = "01/01/1900";
            string str1 = "12/31/2100";
            if (this.rdoJobByDateRange.Checked)
            {
                if (this.txJobFromDate.Text.Length > 0)
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txJobFromDate.Text);
                }
                if (this.txJobToDate.Text.Length > 0)
                {
                    str1 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txJobToDate.Text);
                }
            }
            bool flag = false;
            if (this.rdoJobFrom.Checked)
            {
                flag = true;
            }
            DataSet jobData = this.GetJobData(flag, str, str1, Convert.ToInt64(this.ddlJobStatus.SelectedValue));
            foreach (DataRow row in jobData.Tables[0].Rows)
            {
                foreach (DataColumn column in jobData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());
                    if (!(column.ColumnName.ToString().ToLower() == "hyperlink1") && !(column.ColumnName.ToString().ToLower() == "hyperlink2"))
                    {
                        continue;
                    }
                    row[column.ColumnName] = HttpUtility.HtmlDecode(row[column.ColumnName].ToString());
                }
            }
            DataTable dataTable = new DataTable();
            //dataTable = this.AddBlankRow(jobData.Tables[0], "jobno");
            dataTable = jobData.Tables[0];
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Myob" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Myob" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Myob/Myob_Invoice_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".csv" };
            string str2 = string.Concat(secureDocPath2);
            Export export = new Export();
            export.Save_ExportedDetails_InPath(jobData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_CSV_Web(dataTable, "Job.csv");

            // start
            DataTable dataTable1 = new DataTable();

            dataTable1 = jobData.Tables[0];

            String strDownloadFileName = "Job.csv";

            Byte[] myData = csvBytesWriter(ref dataTable1);

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment; filename=" + strDownloadFileName);
            Response.BinaryWrite(myData);  // Binary data - see myData -  
            Response.End();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SQL.ExecuteNonQuery((new commonClass()).strConnection, CommandType.Text, "update tb_job set IsExported=0;");
        }

        public DataSet GetJobData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID), new SqlParameter("@Sitepath", this.strSitepath) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Navision_export_Job", sqlParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["DateFormat"].ToString();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Navision_Export")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Navision Export", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateTimeForFileName = DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss");
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Navision_Export");
            this.rdoJobFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
            this.rdoJobAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.rdoJobByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
            this.btn_JobExport.Text = this.objLanguage.GetLanguageConversion("Export");
            if (base.Request.QueryString["reset"] == null)
            {
                this.btnReset.Visible = false;
            }
            else
            {
                this.btnReset.Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_new(this.ddlJobStatus, this.CompanyID, string.Concat("--", this.objLanguage.GetLanguageConversion("Select"), "--"), "job");
            }
            if (!base.IsPostBack)
            {
                TextBox textBox = this.txJobFromDate;
                commonClass _commonClass = this.comm;
                DateTime now = DateTime.Now;
                textBox.Text = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox1 = this.txJobToDate;
                commonClass _commonClass1 = this.comm;
                DateTime dateTime = DateTime.Now;
                textBox1.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);
                this.txJobFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txJobToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }
        }

        public byte[] csvBytesWriter(ref DataTable dTable)
        {

            //--------Columns Name---------------------------------------------------------------------------

            StringBuilder sb = new StringBuilder();
            int intClmn = dTable.Columns.Count;

            int i = 0;
            for (i = 0; i <= intClmn - 1; i += 1)
            {
                sb.Append(dTable.Columns[i].ColumnName.ToString() );
                if (i == intClmn - 1)
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(",");
                }
            }
            sb.Append(Environment.NewLine);

            //--------Data By  Columns---------------------------------------------------------------------------

            // declare this outside the loop!
            char[] csvTokens = new[] { '\"', ',', '\n', '\r' };

            // inside the loop


            foreach (DataRow row in dTable.Rows)
            {
                int ir = 0;
                for (ir = 0; ir <= intClmn - 1; ir += 1)
                {
                    if (row[ir].ToString().IndexOfAny(csvTokens) >= 0)
                    {
                        row[ir] = "\"" + row[ir].ToString().Replace("\"", "\"\"") + "\"";
                    }

                    sb.Append(row[ir].ToString());
                    if (ir == intClmn - 1)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(",");
                    }

                }
                sb.Append(Environment.NewLine);
            }

            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());

        }
    }
}