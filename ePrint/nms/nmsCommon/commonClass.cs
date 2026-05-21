using ePrint.ePrintUtilities;
using MailChimp.Net.Models;
using ePrint.settings;
using ePrint.usercontrol;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsConnectionClass;
using nmsEmail;
using nmsView;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FluentFTP;

namespace nmsCommon
{
    public class commonClass : BasePage
    {
        public SqlConnection conn;

        public string connectionStringName = "CRMConnectionString";

        public string strConnection;

        private BasePage objpage = new BasePage();

        public Hashtable ht_UserSettings = new Hashtable();

        private static byte[] bytes;

        static commonClass()
        {
            commonClass.bytes = Encoding.ASCII.GetBytes("ZeroCool");
        }

        public commonClass()
        {
            try
            {
                this.strConnection = EprintConfigurationManager.ConnectionStrings[this.connectionStringName].ToString();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("error.aspx");
            }
            this.conn = new SqlConnection(this.strConnection);
        }

        public string accessRight(int companyId, int userId, int adminrights, string pg)
        {
            return (new BaseView()).CheckViewRight(pg, adminrights, companyId, userId);
        }

        public void addCustomizedField(string pg, int companyID, string databaseFieldName, string labelName, string inputBoxID, string inputType, string dataType, int isDisplayed, int isDefault, int isRequired, int isReadOnly, int orderNumber, string databaseName, string optionvalue, int maxLength, string fieldType, int decimalPlace, string optionType, int isDelete, int isNewRow, string screenName)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_AddCustomizedField", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@databaseFieldName", databaseFieldName);
            sqlCommand.Parameters.AddWithValue("@labelName", labelName);
            sqlCommand.Parameters.AddWithValue("@inputBoxID", inputBoxID);
            sqlCommand.Parameters.AddWithValue("@inputType", inputType);
            sqlCommand.Parameters.AddWithValue("@dataType", dataType);
            sqlCommand.Parameters.AddWithValue("@isDisplayed", isDisplayed);
            sqlCommand.Parameters.AddWithValue("@isDefault", isDefault);
            sqlCommand.Parameters.AddWithValue("@isRequired", isRequired);
            sqlCommand.Parameters.AddWithValue("@isReadOnly", isReadOnly);
            sqlCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            sqlCommand.Parameters.AddWithValue("@databaseName", databaseName);
            sqlCommand.Parameters.AddWithValue("@optionvalue", optionvalue);
            sqlCommand.Parameters.AddWithValue("@maxLength", maxLength);
            sqlCommand.Parameters.AddWithValue("@fieldType", fieldType);
            sqlCommand.Parameters.AddWithValue("@decimalPlace", decimalPlace);
            sqlCommand.Parameters.AddWithValue("@optionType", optionType);
            sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
            sqlCommand.Parameters.AddWithValue("@isNewRow", isNewRow);
            sqlCommand.Parameters.AddWithValue("@screenName", screenName);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public bool check_aliasfield_duplicacy(string alias, string pg, int aliasid, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_check_aliasfield_duplicacy", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@alias", alias);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@aliasid", aliasid);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable Get_Currency_Company(int companyID)
        {

            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_getCurrency", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", 0);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                dataTable.Load(sqlDataReader);
            }
            _commonClass.closeConnection();
            return dataTable;
        }

        public bool Check_Common_Access_Right_Add_Edit_Delete_View(int companyID, int userID, string pg, int sectionID, string Action)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "crm_common_Check_Add_Edit_Delete_View"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@sectionID", sectionID);
            sqlCommand.Parameters.AddWithValue("@Action", Action);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public int Check_MassDelete(int companyID, int userID, string pg, string Action)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "crm_common_Check_accessright_massdelete"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@Action", Action);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return 1;
            }
            return 0;
        }

        public bool check_uniquefield_duplicacy(string uniquefield, string pg, int uniquefieldid, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_check_uniquefield_duplicacy", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@uniquefield", uniquefield);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@uniquefieldid", uniquefieldid);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public bool check_viewname_duplicacy(string viewname, string pg, int viewvalueid, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_check_viewname_duplicacy", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@viewname", viewname);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@viewvalueid", viewvalueid);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public bool chk_IsDelete(int companyID, int sectionid, string pg)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "crm_Check_isDelete"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@sectionid", sectionid);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public int chkAccessRightAndIDExistOrNot(int userID, string sectionName, int sectionID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_check_accessright", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@companyid", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@sectionName", sectionName);
            sqlCommand.Parameters.AddWithValue("@sectionID", sectionID);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            return (int)sqlCommand.Parameters["ReturnValue"].Value;
        }

        public bool chkLabelNameExist(string pg, string LabelName, int companyiD)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_checklabelname", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@labelName", LabelName);
            sqlCommand.Parameters.AddWithValue("@companyID", companyiD);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public bool chkScreenNameExist(string pg, string ScreenName, int companyiD)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_checkscreenname", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@screenName", ScreenName);
            sqlCommand.Parameters.AddWithValue("@companyID", companyiD);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public void closeConnection()
        {
            if (this.conn.State != ConnectionState.Closed)
            {
                this.conn.Close();
            }
        }

        public void common_allsection_delete(int SectionID, int CompanyID, string Section)
        {
            commonClass _commonClass = new commonClass();
            object[] sectionID = new object[] { "crm_common_allsection_delete ", SectionID, ",", CompanyID, ",'", Section, "'" };
            string str = string.Concat(sectionID);
            (new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public int common_create_view(string pg, int companyid, string viewname, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9, string field10, string field11, string condition1, string condition2, string condition3, string condition4, string condition5, string operator1, string operator2, string operator3, string operator4, string operator5, string value1, string value2, string value3, string value4, string value5, int isdelete, int createuserid, int modifyuserid, string createdate, string modifydate, int ishide, int isdefault, string SortedField, string sortDirection)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "crm_common_create_view"
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@viewName", viewname);
            sqlCommand.Parameters.AddWithValue("@field1", field1);
            sqlCommand.Parameters.AddWithValue("@field2", field2);
            sqlCommand.Parameters.AddWithValue("@field3", field3);
            sqlCommand.Parameters.AddWithValue("@field4", field4);
            sqlCommand.Parameters.AddWithValue("@field5", field5);
            sqlCommand.Parameters.AddWithValue("@field6", field6);
            sqlCommand.Parameters.AddWithValue("@field7", field7);
            sqlCommand.Parameters.AddWithValue("@field8", field8);
            sqlCommand.Parameters.AddWithValue("@field9", field9);
            sqlCommand.Parameters.AddWithValue("@field10", field10);
            sqlCommand.Parameters.AddWithValue("@field11", field11);
            sqlCommand.Parameters.AddWithValue("@condition1", condition1);
            sqlCommand.Parameters.AddWithValue("@condition2", condition2);
            sqlCommand.Parameters.AddWithValue("@condition3", condition3);
            sqlCommand.Parameters.AddWithValue("@condition4", condition4);
            sqlCommand.Parameters.AddWithValue("@condition5", condition5);
            sqlCommand.Parameters.AddWithValue("@operator1", operator1);
            sqlCommand.Parameters.AddWithValue("@operator2", operator2);
            sqlCommand.Parameters.AddWithValue("@operator3", operator3);
            sqlCommand.Parameters.AddWithValue("@operator4", operator4);
            sqlCommand.Parameters.AddWithValue("@operator5", operator5);
            sqlCommand.Parameters.AddWithValue("@value1", value1);
            sqlCommand.Parameters.AddWithValue("@value2", value2);
            sqlCommand.Parameters.AddWithValue("@value3", value3);
            sqlCommand.Parameters.AddWithValue("@value4", value4);
            sqlCommand.Parameters.AddWithValue("@value5", value5);
            sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
            sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
            sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
            sqlCommand.Parameters.AddWithValue("@createdate", createdate);
            sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
            sqlCommand.Parameters.AddWithValue("@ishide", ishide);
            sqlCommand.Parameters.AddWithValue("@isDefault", isdefault);
            sqlCommand.Parameters.AddWithValue("@sortfield", SortedField);
            sqlCommand.Parameters.AddWithValue("@sortdirection", sortDirection);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            return (int)sqlCommand.Parameters["ReturnValue"].Value;
        }

        public void common_delete_View(string pg, int viewvalueID, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_delete_view", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@viewvalueID", viewvalueID);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void common_edit_view(string pg, int ViewValueID, int companyid, string viewname, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9, string field10, string field11, string condition1, string condition2, string condition3, string condition4, string condition5, string operator1, string operator2, string operator3, string operator4, string operator5, string value1, string value2, string value3, string value4, string value5, int isdelete, int createuserid, int modifyuserid, string createdate, string modifydate, int ishide, int isdefault, string SortedBy, string sortDirection)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = _commonClass.openConnection(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "crm_common_edit_view"
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@ViewValueID", ViewValueID);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@viewname", viewname);
            sqlCommand.Parameters.AddWithValue("@field1", field1);
            sqlCommand.Parameters.AddWithValue("@field2", field2);
            sqlCommand.Parameters.AddWithValue("@field3", field3);
            sqlCommand.Parameters.AddWithValue("@field4", field4);
            sqlCommand.Parameters.AddWithValue("@field5", field5);
            sqlCommand.Parameters.AddWithValue("@field6", field6);
            sqlCommand.Parameters.AddWithValue("@field7", field7);
            sqlCommand.Parameters.AddWithValue("@field8", field8);
            sqlCommand.Parameters.AddWithValue("@field9", field9);
            sqlCommand.Parameters.AddWithValue("@field10", field10);
            sqlCommand.Parameters.AddWithValue("@field11", field11);
            sqlCommand.Parameters.AddWithValue("@condition1", condition1);
            sqlCommand.Parameters.AddWithValue("@condition2", condition2);
            sqlCommand.Parameters.AddWithValue("@condition3", condition3);
            sqlCommand.Parameters.AddWithValue("@condition4", condition4);
            sqlCommand.Parameters.AddWithValue("@condition5", condition5);
            sqlCommand.Parameters.AddWithValue("@operator1", operator1);
            sqlCommand.Parameters.AddWithValue("@operator2", operator2);
            sqlCommand.Parameters.AddWithValue("@operator3", operator3);
            sqlCommand.Parameters.AddWithValue("@operator4", operator4);
            sqlCommand.Parameters.AddWithValue("@operator5", operator5);
            sqlCommand.Parameters.AddWithValue("@value1", value1);
            sqlCommand.Parameters.AddWithValue("@value2", value2);
            sqlCommand.Parameters.AddWithValue("@value3", value3);
            sqlCommand.Parameters.AddWithValue("@value4", value4);
            sqlCommand.Parameters.AddWithValue("@value5", value5);
            sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
            sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
            sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
            sqlCommand.Parameters.AddWithValue("@createdate", createdate);
            sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
            sqlCommand.Parameters.AddWithValue("@ishide", ishide);
            sqlCommand.Parameters.AddWithValue("@isDefault", isdefault);
            sqlCommand.Parameters.AddWithValue("@SortedBy", SortedBy);
            sqlCommand.Parameters.AddWithValue("@sortDirection", sortDirection);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void companyexpiredate(int companyid, int days)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_companyexpiredate", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@days", days);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public DataSet ConnectFile(string filename)
        {
            DataSet dataSet = new DataSet();
            string str = filename.Substring(filename.Length - 3, 3);
            if (str.ToLower() == "csv")
            {
                string str1 = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='text;HDR=Yes;FMT=Delimited';Data Source=";
                str1 = string.Concat(str1, base.Server.MapPath("../"), "tempupload/");
                OleDbConnection oleDbConnection = new OleDbConnection(str1);
                oleDbConnection.Open();
                string str2 = string.Concat("select * from [", filename.Replace('.', '#'), "]");
                (new OleDbDataAdapter(str2, oleDbConnection)).Fill(dataSet);
                oleDbConnection.Close();
            }
            else if (str.ToLower() == "xls")
            {
                DataTable oleDbSchemaTable = null;
                string[] strArrays = new string[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", base.Server.MapPath("../"), "tempupload/", filename, ";Extended Properties=Excel 8.0;" };
                OleDbConnection oleDbConnection1 = new OleDbConnection(string.Concat(strArrays));
                oleDbConnection1.Open();
                oleDbSchemaTable = oleDbConnection1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (oleDbSchemaTable == null)
                {
                    return null;
                }
                string[] strArrays1 = new string[oleDbSchemaTable.Rows.Count];
                int num = 0;
                foreach (DataRow row in oleDbSchemaTable.Rows)
                {
                    strArrays1[num] = row["TABLE_NAME"].ToString();
                    string str3 = string.Concat("select * from [", strArrays1[num].ToString().Trim(), "]");
                    (new OleDbDataAdapter(str3, oleDbConnection1)).Fill(dataSet);
                    num++;
                }
                oleDbConnection1.Close();
            }
            return dataSet;
        }

        public DataSet ConnectFileFixed(string filename)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string str = filename.Substring(filename.Length - 3, 3);
                if (str.ToLower() == "csv")
                {
                    string str1 = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='text;HDR=Yes;FMT=Delimited';Data Source=";
                    str1 = string.Concat(str1, base.Server.MapPath("../"), "tempupload/");
                    OleDbConnection oleDbConnection = new OleDbConnection(str1);
                    oleDbConnection.Open();
                    string str2 = string.Concat("select * from [", filename.Replace('.', '#'), "]");
                    (new OleDbDataAdapter(str2, oleDbConnection)).Fill(dataSet);
                    oleDbConnection.Close();
                }
                else if (str.ToLower() == "xls")
                {
                    string[] excelSheetNames = this.GetExcelSheetNames(filename);
                    string[] strArrays = new string[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", base.Server.MapPath("../"), "tempupload/", filename, ";Extended Properties=Excel 8.0;" };
                    OleDbConnection oleDbConnection1 = new OleDbConnection(string.Concat(strArrays));
                    oleDbConnection1.Open();
                    string str3 = string.Concat("select * from [", excelSheetNames[0].ToString().Trim(), "]");
                    (new OleDbDataAdapter(str3, oleDbConnection1)).Fill(dataSet);
                    oleDbConnection1.Close();
                }
            }
            catch (Exception exception)
            {
                string message = exception.Message;
            }
            return dataSet;
        }

        public SqlDataReader customizeFieldDetail(string pg, int CustomizeID, int userID, int companyID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_customizefielddetail", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            _commonClass.closeConnection();
            return sqlDataReader;
        }

        public string date_Check_new(string DateFormat, string txtvalue, int CompanyID)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (DateFormat.ToLower() == "mm/dd/yyyy")
                {
                    if (DateFormat.ToLower() == "dd/mm/yyyy")
                    {
                        string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays1);
                    }
                    else if (DateFormat.ToLower() == "mm/dd/yyyy")
                    {
                        string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays2);
                    }
                }
                if (DateFormat.ToLower() == "dd/mm/yyyy")
                {
                    if (DateFormat.ToLower() == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormat.ToLower() == "mm/dd/yyyy")
                    {
                        string[] strArrays4 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays4);
                    }
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        public string Date_Format(string date)
        {
            if (!(date == "01/01/1900") && !(date == "1/1/1900"))
            {
                return date;
            }
            return "";
        }

        public static string Decrypt(string cryptedString)
        {
            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(commonClass.bytes, commonClass.bytes), CryptoStreamMode.Read);
            return (new StreamReader(cryptoStream)).ReadToEnd();
        }

        public void delete_company(int companyid)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_delete_company", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void DeleteThis(int companyID, int id, string email)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_user_delete", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", id);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }

        public SqlDataReader displaysetting(string pg, int companyId)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_displaysetting", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader dtrAssignToUser(int companyID, int userID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_AssignToUser", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader dtrCommon(int companyID, string tablename, string fieldname)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_fromgiventable", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrCountry()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_country", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrCurrency()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_currency", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrGroup(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_usergroup", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader dtrGroupUser(int companyID, int userID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_usergroup_in_asssignPanel", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrHearFrom()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_hearfrom", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrIndustry(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_industry", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrInputType()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_inputtype", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrLanguage()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_language", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrLeadsource(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_leadsource", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrLeadstatus(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_leadstatus", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrRating(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_rating", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrSalutation(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_salutation", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrTimeZone()
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_timezone", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand.ExecuteReader();
        }

        public SqlDataReader dtrusertype(int companyID)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_usertype", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            return sqlCommand.ExecuteReader();
        }

        public void edit_secondadmin(int id, string companyname, string firstname, string lastname, string email, string password, string address1, string address2, string city, string country, string zip)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_update_second_second", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@companyname", companyname);
            sqlCommand.Parameters.AddWithValue("@firstname", firstname);
            sqlCommand.Parameters.AddWithValue("@lastname", lastname);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@password", password);
            sqlCommand.Parameters.AddWithValue("@address1", address1);
            sqlCommand.Parameters.AddWithValue("@address2", address2);
            sqlCommand.Parameters.AddWithValue("@city", city);
            sqlCommand.Parameters.AddWithValue("@country", country);
            sqlCommand.Parameters.AddWithValue("@zip", zip);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }

        public void editCustomizedField(int companyID, string pg, int customizeid, string labelName, string inputType, string dataType, string optionvalue, int maxLength, string fieldType, int decimalPlace, string optionType, int isDelete, int isNewRow, int isDisplayed, int isRequired, int isReadOnly, string screenName)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_EditCustomizedField", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@customizeid", customizeid);
            sqlCommand.Parameters.AddWithValue("@labelName", labelName);
            sqlCommand.Parameters.AddWithValue("@inputType", inputType);
            sqlCommand.Parameters.AddWithValue("@dataType", dataType);
            sqlCommand.Parameters.AddWithValue("@optionvalue", optionvalue);
            sqlCommand.Parameters.AddWithValue("@maxLength", maxLength);
            sqlCommand.Parameters.AddWithValue("@fieldType", fieldType);
            sqlCommand.Parameters.AddWithValue("@decimalPlace", decimalPlace);
            sqlCommand.Parameters.AddWithValue("@optionType", optionType);
            sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
            sqlCommand.Parameters.AddWithValue("@isNewRow", isNewRow);
            sqlCommand.Parameters.AddWithValue("@isDisplayed", isDisplayed);
            sqlCommand.Parameters.AddWithValue("@isRequired", isRequired);
            sqlCommand.Parameters.AddWithValue("@isReadOnly", isReadOnly);
            sqlCommand.Parameters.AddWithValue("@screenName", screenName);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public static string Encrypt(string originalString)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                if (string.IsNullOrEmpty(originalString))
                {
                    throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
                }
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(commonClass.bytes, commonClass.bytes), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(originalString);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                streamWriter.Flush();
            }
            catch
            {
            }
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public string eprint_checkdateformat_returnonlymmddyyyy(string DateFormat, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (Convert.ToInt32(strArrays[0].ToString()) > 12)
                {
                    string[] str = new string[] { strArrays[1].ToString(), "/", strArrays[0].ToString(), "/", strArrays[2].ToString() };
                    txtvalue = string.Concat(str);
                }
                else if (Convert.ToInt32(strArrays[1].ToString()) > 12)
                {
                    string[] str1 = new string[] { strArrays[0].ToString(), "/", strArrays[1].ToString(), "/", strArrays[2].ToString() };
                    txtvalue = string.Concat(str1);
                }
                else if (DateFormat == "dd/mm/yyyy")
                {
                    string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays1);
                }
                else if (DateFormat == "mm/dd/yyyy")
                {
                    string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays2);
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        public decimal Eprint_GetminimumCost_ComparedtoCostwithMarkup(decimal costprice, decimal markup, decimal minimumcost, out decimal CostexMarkup_forsummary, out decimal MinimumCostMarkup, ref decimal PressSetupCharge)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            num = (costprice + ((costprice * markup) / new decimal(100))) + PressSetupCharge;
            if (minimumcost <= num)
            {
                num1 = num;
                MinimumCostMarkup = markup;
                CostexMarkup_forsummary = costprice;
            }
            else
            {
                num1 = minimumcost;
                MinimumCostMarkup = new decimal(0);
                CostexMarkup_forsummary = minimumcost;
                PressSetupCharge = new decimal(0);
            }
            return num1;
        }

        public decimal Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(decimal costprice, decimal markup, decimal minimumcost, out decimal CostexMarkup_forsummary, out decimal MinimumCostMarkup, ref decimal PressSetupCharge)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            num = (costprice + ((costprice * markup) / new decimal(100))) + PressSetupCharge;
            if (minimumcost == new decimal(0))
            {
                num1 = num;
                MinimumCostMarkup = markup;
                CostexMarkup_forsummary = costprice;
            }
            else if (minimumcost <= num)
            {
                num1 = num;
                MinimumCostMarkup = markup;
                CostexMarkup_forsummary = costprice;
            }
            else
            {
                num1 = minimumcost;
                MinimumCostMarkup = new decimal(0);
                CostexMarkup_forsummary = minimumcost;
                PressSetupCharge = new decimal(0);
            }
            return num1;
        }

        public decimal Eprint_GetminimumCost_ComparedtoMarkup(decimal costprice, decimal markup, decimal minimumcost, decimal SetupCharge, decimal customcol2, string custcol2)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            num1 = (costprice * markup) / new decimal(100);
            if (minimumcost > ((costprice + num1) + SetupCharge))
            {
                num1 = new decimal(0);
            }
            return num1;
        }

        public DateTime Eprint_return_ActualDate_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            DateTime dateTime = DateTime.Parse(strDate);
            if (HttpContext.Current.Session["ERD_timezonekey"] == null || HttpContext.Current.Session["ERD_dateformat"] == null)
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                    HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                }
                _commonClass.closeConnection();
            }
            if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
            {
                if (IsSystemGenerated)
                {
                    dateTime = Convert.ToDateTime(commonClass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
                }
                HttpContext.Current.Session["ERD_dateformat"].ToString().ToUpper();
            }
            return dateTime;
        }

        public string Eprint_return_Date_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            DateTime dateTime;
            string str;
            string str1;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string upper = string.Empty;
            if (strDate.Length > 0)
            {
                try
                {
                    empty = DateTime.Parse(strDate).ToShortDateString();
                }
                catch
                {
                    try
                    {
                        string[] strArrays = new string[5];
                        char[] chrArray = new char[] { '/' };
                        strArrays[0] = strDate.Split(chrArray)[1];
                        strArrays[1] = "/";
                        char[] chrArray1 = new char[] { '/' };
                        strArrays[2] = strDate.Split(chrArray1)[0];
                        strArrays[3] = "/";
                        char[] chrArray2 = new char[] { '/' };
                        strArrays[4] = strDate.Split(chrArray2)[2];
                        str1 = string.Concat(strArrays);
                        return str1;
                    }
                    catch
                    {
                        str1 = strDate;
                        return str1;
                    }
                }
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    dateTime = DateTime.Parse(strDate);
                    if (HttpContext.Current.Session["ERD_timezonekey"] == null || HttpContext.Current.Session["ERD_dateformat"] == null)
                    {
                        commonClass _commonClass = new commonClass();
                        SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonClass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                        sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                        sqlCommand.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                            HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                        }
                        _commonClass.closeConnection();
                    }
                    if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
                    {
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(commonClass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
                        }
                        upper = HttpContext.Current.Session["ERD_dateformat"].ToString().ToUpper();
                    }
                    string str2 = dateTime.Hour.ToString();
                    string str3 = dateTime.Minute.ToString();
                    string str4 = dateTime.Second.ToString();
                    string str5 = dateTime.Day.ToString();
                    string str6 = dateTime.Month.ToString();
                    string str7 = dateTime.Year.ToString().Substring(2);
                    string str8 = dateTime.Year.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = string.Concat("0", str2);
                    }
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    str = "";
                    string str9 = upper;
                    string str10 = str9;
                    if (str9 != null)
                    {
                        switch (str10)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str5, "/", str6, "/", str8, "-", str2, str3 };
                                    str = string.Concat(strArrays1);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays2 = new string[] { str5, "-", str6, "-", str8, "-", str2, str3 };
                                    str = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays3 = new string[] { str2, str3, "-", str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays3);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays4 = new string[] { str2, str3, "/", str5, "/", str6, "-", str8 };
                                    str = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays5 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays5);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str8 };
                                    str = string.Concat(strArrays6);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str5, "/", str6, "/", str8 };
                                    str = string.Concat(strArrays7);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays8 = new string[] { str6, "/", str5, "/", str8 };
                                    str = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays9 = new string[] { str5, "-", str6, "-", str8 };
                                    str = string.Concat(strArrays9);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays10 = new string[] { str5, "/", str6, "/", str7 };
                                    str = string.Concat(strArrays10);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays11 = new string[] { str6, "/", str5, "/", str7 };
                                    str = string.Concat(strArrays11);
                                    break;
                                }
                            default:
                                {
                                    goto Label1;
                                }
                        }
                    }
                    else
                    {
                        goto Label1;
                    }
                Label2:
                    empty1 = str.ToString();
                }
                catch
                {
                    str1 = strDate;
                    return str1;
                }
            }
            return empty1;
        Label1:
            str = dateTime.ToString();
            goto Label44;
        Label44:
            string s = "";

            return string.Empty;
        }

        public string Eprint_return_DateTime_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            string str;
            int num;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string upper = string.Empty;
            if (strDate.Length > 0)
            {
                empty = DateTime.Parse(strDate).ToShortDateString();
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(strDate);
                    if (HttpContext.Current.Session["ERD_timezonekey"] == null || HttpContext.Current.Session["ERD_dateformat"] == null)
                    {
                        commonClass _commonClass = new commonClass();
                        SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonClass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                        sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                        sqlCommand.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                            HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                        }
                        _commonClass.closeConnection();
                    }
                    if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
                    {
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(commonClass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
                        }
                        upper = HttpContext.Current.Session["ERD_dateformat"].ToString().ToUpper();
                    }
                    string str1 = dateTime.Hour.ToString();
                    if (Convert.ToInt16(str1) == 0)
                    {
                        num = 12;
                    }
                    else
                    {
                        num = (Convert.ToInt16(str1) > 12 ? Convert.ToInt16(str1) - 12 : (int)Convert.ToInt16(str1));
                    }
                    string str2 = Convert.ToString(num);
                    string str3 = dateTime.Minute.ToString();
                    string str4 = dateTime.Second.ToString();
                    string str5 = dateTime.Day.ToString();
                    string str6 = dateTime.Month.ToString();
                    string str7 = dateTime.Year.ToString().Substring(2);
                    string str8 = (Convert.ToInt16(str1) >= 12 ? "PM" : "AM");
                    string str9 = dateTime.Year.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = string.Concat("0", str2);
                    }
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str8.Length == 1)
                    {
                        str8 = string.Concat("0", str8);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    string str10 = "";
                    string str11 = upper;
                    string str12 = str11;
                    if (str11 != null)
                    {
                        switch (str12)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays = new string[] { str5, "/", str6, "/", str9, "-", str2, str3 };
                                    str10 = string.Concat(strArrays);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str5, "-", str6, "-", str9, "-", str2, str3 };
                                    str10 = string.Concat(strArrays1);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays2 = new string[] { str2, str3, "-", str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays3 = new string[] { str2, str3, "/", str5, "/", str6, "-", str9 };
                                    str10 = string.Concat(strArrays3);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays4 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays5 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str9 };
                                    str10 = string.Concat(strArrays5);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str5, "/", str6, "/", str9, " ", str2, ":", str3, ":", str4, " ", str8 };
                                    str10 = string.Concat(strArrays6);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str6, "/", str5, "/", str9, " ", str2, ":", str3, ":", str4, " ", str8 };
                                    str10 = string.Concat(strArrays7);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays8 = new string[] { str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays9 = new string[] { str5, "/", str6, "/", str7 };
                                    str10 = string.Concat(strArrays9);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays10 = new string[] { str6, "/", str5, "/", str7 };
                                    str10 = string.Concat(strArrays10);
                                    break;
                                }
                            default:
                                {
                                    str10 = dateTime.ToString();
                                    empty1 = str10.ToString();
                                    return empty1;
                                }
                        }
                    }
                    else
                    {
                        str10 = dateTime.ToString();
                        empty1 = str10.ToString();
                        return empty1;
                    }
                    empty1 = str10.ToString();
                    return empty1;
                }
                catch
                {
                    str = strDate;
                }
                return str;
            }
            return empty1;
        }

        public string Eprint_return_DateTime_Before_View_For_AlertNotifications(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            string str;
            int num;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            if (strDate.Length > 0)
            {
                empty = DateTime.Parse(strDate).ToShortDateString();
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(strDate);
                    commonClass _commonClass = new commonClass();
                    SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonClass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                    sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                    sqlCommand.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        if (!IsSystemGenerated)
                        {
                            continue;
                        }
                        dateTime = Convert.ToDateTime(commonClass.ReturnCurrentDateTimeByTimeZoneID(dateTime, sqlDataReader["timezonekey"].ToString()));
                    }
                    _commonClass.closeConnection();
                    str1 = "MM/DD/YYYY";
                    string str2 = dateTime.Hour.ToString();
                    if (Convert.ToInt16(str2) == 0)
                    {
                        num = 12;
                    }
                    else
                    {
                        num = (Convert.ToInt16(str2) > 12 ? Convert.ToInt16(str2) - 12 : (int)Convert.ToInt16(str2));
                    }
                    string str3 = Convert.ToString(num);
                    string str4 = dateTime.Minute.ToString();
                    string str5 = dateTime.Second.ToString();
                    string str6 = dateTime.Day.ToString();
                    string str7 = dateTime.Month.ToString();
                    dateTime.Year.ToString().Substring(2);
                    string str8 = (Convert.ToInt16(str2) >= 12 ? "PM" : "AM");
                    string str9 = dateTime.Year.ToString();
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str8.Length == 1)
                    {
                        str8 = string.Concat("0", str8);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    if (str7.Length == 1)
                    {
                        str7 = string.Concat("0", str7);
                    }
                    string str10 = "";
                    string str11 = str1;
                    string str12 = str11;
                    if (str11 == null)
                    {
                        str10 = dateTime.ToString();
                        empty1 = str10.ToString();
                        return empty1;
                    }
                    else if (str12 == "DD/MM/YYYY-HHMM")
                    {
                        string[] strArrays = new string[] { str6, "/", str7, "/", str9, "-", str3, str4 };
                        str10 = string.Concat(strArrays);
                    }
                    else if (str12 == "DD-MM-YYYY-HHMM")
                    {
                        string[] strArrays1 = new string[] { str6, "-", str7, "-", str9, "-", str3, str4 };
                        str10 = string.Concat(strArrays1);
                    }
                    else if (str12 == "HH:MM/MM/DD/YYYY")
                    {
                        string[] strArrays2 = new string[] { str3, ":", str4, "/", str6, "/", str7, "/", str9 };
                        str10 = string.Concat(strArrays2);
                    }
                    else
                    {
                        if (str12 != "MM/DD/YYYY")
                        {
                            str10 = dateTime.ToString();
                            empty1 = str10.ToString();
                            return empty1;
                        }
                        string[] strArrays3 = new string[] { str7, "/", str6, "/", str9, " ", str3, ":", str4, ":", str5, " ", str8 };
                        str10 = string.Concat(strArrays3);
                    }
                    empty1 = str10.ToString();
                    return empty1;
                }
                catch
                {
                    str = strDate;
                }
                return str;
            }
            return empty1;
        }

        public string Eprint_return_DateTime_Before_View_OnlyHoursandMinute(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            string str;
            int num;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string upper = string.Empty;
            if (strDate.Length > 0)
            {
                empty = DateTime.Parse(strDate).ToShortDateString();
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(strDate);
                    if (HttpContext.Current.Session["ERD_timezonekey"] == null || HttpContext.Current.Session["ERD_dateformat"] == null)
                    {
                        commonClass _commonClass = new commonClass();
                        SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonClass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
                        sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                        sqlCommand.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                            HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                        }
                        _commonClass.closeConnection();
                    }
                    if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
                    {
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(commonClass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
                        }
                        upper = HttpContext.Current.Session["ERD_dateformat"].ToString().ToUpper();
                    }
                    string str1 = dateTime.Hour.ToString();
                    if (Convert.ToInt16(str1) == 0)
                    {
                        num = 12;
                    }
                    else
                    {
                        num = (Convert.ToInt16(str1) > 12 ? Convert.ToInt16(str1) - 12 : (int)Convert.ToInt16(str1));
                    }
                    string str2 = Convert.ToString(num);
                    string str3 = dateTime.Minute.ToString();
                    string str4 = dateTime.Second.ToString();
                    string str5 = dateTime.Day.ToString();
                    string str6 = dateTime.Month.ToString();
                    string str7 = dateTime.Year.ToString().Substring(2);
                    string str8 = (Convert.ToInt16(str1) >= 12 ? "PM" : "AM");
                    string str9 = dateTime.Year.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = string.Concat("0", str2);
                    }
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str8.Length == 1)
                    {
                        str8 = string.Concat("0", str8);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    string str10 = "";
                    string str11 = upper;
                    string str12 = str11;
                    if (str11 != null)
                    {
                        switch (str12)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays = new string[] { str5, "/", str6, "/", str9, "-", str2, str3 };
                                    str10 = string.Concat(strArrays);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str5, "-", str6, "-", str9, "-", str2, str3 };
                                    str10 = string.Concat(strArrays1);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays2 = new string[] { str2, str3, "-", str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays3 = new string[] { str2, str3, "/", str5, "/", str6, "-", str9 };
                                    str10 = string.Concat(strArrays3);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays4 = new string[] { str2, ":", str3, "-", str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays5 = new string[] { str2, ":", str3, "/", str5, "/", str6, "/", str9 };
                                    str10 = string.Concat(strArrays5);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str5, "/", str6, "/", str9, " ", str2, ":", str3, " ", str8 };
                                    str10 = string.Concat(strArrays6);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str6, "/", str5, "/", str9, " ", str2, ":", str3, " ", str8 };
                                    str10 = string.Concat(strArrays7);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays8 = new string[] { str5, "-", str6, "-", str9 };
                                    str10 = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays9 = new string[] { str5, "/", str6, "/", str7 };
                                    str10 = string.Concat(strArrays9);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays10 = new string[] { str6, "/", str5, "/", str7 };
                                    str10 = string.Concat(strArrays10);
                                    break;
                                }
                            default:
                                {
                                    str10 = dateTime.ToString();
                                    empty1 = str10.ToString();
                                    return empty1;
                                }
                        }
                    }
                    else
                    {
                        str10 = dateTime.ToString();
                        empty1 = str10.ToString();
                        return empty1;
                    }
                    empty1 = str10.ToString();
                    return empty1;
                }
                catch
                {
                    str = strDate;
                }
                return str;
            }
            return empty1;
        }

        public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView)
        {
            int scale = 0;
            scale = 2;
            if (Scale > 0)
            {
                scale = Scale;
            }
            if (IsQuantity && !isAddDecimalPlacesToQty)
            {
                return Math.Round(Amount, 0, MidpointRounding.AwayFromZero).ToString();
            }
            string str = string.Concat("N", scale.ToString());
            decimal num = Math.Round(Amount, scale, MidpointRounding.AwayFromZero);
            if (!isView)
            {
                return num.ToString();
            }
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
            string str1 = string.Concat("{0:", str, "}");
            object[] objArray = new object[] { num };
            return string.Format(cultureInfo, str1, objArray);
        }

        public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView, bool IsShowCurrencySymbol, bool HideMinusSymbol)
        {
            int scale = 0;
            scale = 2;
            if (Scale > 0)
            {
                scale = Scale;
            }
            if (IsQuantity && !isAddDecimalPlacesToQty)
            {
                return Math.Round(Amount, 0, MidpointRounding.AwayFromZero).ToString();
            }
            string str = string.Concat("N", scale.ToString());
            decimal num = Math.Round(Amount, scale, MidpointRounding.AwayFromZero);
            if (!isView)
            {
                if (!HideMinusSymbol)
                {
                    return num.ToString();
                }
                return num.ToString().Replace("-", "");
            }
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
            string str1 = string.Concat("{0:", str, "}");
            object[] objArray = new object[] { num };
            string str2 = string.Format(cultureInfo, str1, objArray);
            if (!IsShowCurrencySymbol)
            {
                if (!HideMinusSymbol)
                {
                    return str2;
                }
                return str2.Replace("-", "");
            }
            if (!HideMinusSymbol)
            {
                return string.Format("{0:c}", Convert.ToDecimal(str2));
            }
            return string.Format("{0:c}", Convert.ToDecimal(str2)).Replace("-", "");
        }

        public string Eprint_ReturnFinal_Formated_Amount_byRoundOff(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView, int roundoff)
        {
            int scale = 0;
            scale = roundoff;
            if (Scale > 0)
            {
                scale = Scale;
            }
            if (IsQuantity && !isAddDecimalPlacesToQty)
            {
                return Math.Round(Amount, 0, MidpointRounding.AwayFromZero).ToString();
            }
            string str = string.Concat("N", scale.ToString());
            decimal num = Math.Round(Amount, scale, MidpointRounding.AwayFromZero);
            if (!isView)
            {
                return num.ToString();
            }
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
            string str1 = string.Concat("{0:", str, "}");
            object[] objArray = new object[] { num };
            return string.Format(cultureInfo, str1, objArray);
        }

        public void extend_company_expairedate(int companyid, int days)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_extend_companyexpiredate", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@days", days);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public string GetAddressLabelByKey(string AddressKey)
        {
            Hashtable hashtables = new Hashtable();
            if (this.Session["ClientAddressLabels"] != null)
            {
                hashtables = (Hashtable)this.Session["ClientAddressLabels"];
            }
            else
            {
                commonClass _commonClass = new commonClass();
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_GetAddressLabelByKey", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(this.Session["CompanyID"]));
                dataTable.Load(sqlCommand.ExecuteReader());
                foreach (DataRow row in dataTable.Rows)
                {
                    hashtables.Add(row["AddresslKey"].ToString().ToLower(), row["AddressValue"].ToString());
                }
                this.Session["ClientAddressLabels"] = hashtables;
                _commonClass.closeConnection();
            }
            string str = hashtables[AddressKey].ToString();
            if (str.Length == 0)
            {
                str = AddressKey;
            }
            return str;
        }

        public string GetCurrency_Symbol(int CompanyID, int UserID)
        {
            string empty = string.Empty;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_getCurrency", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@userID", UserID);
            sqlCommand.ExecuteNonQuery();
            empty = sqlCommand.ExecuteScalar().ToString();
            _commonClass.closeConnection();
            string currencySymbol = "$";
            RegionInfo regionInfo = new RegionInfo(empty);
            if (regionInfo.CurrencySymbol != null)
            {
                currencySymbol = regionInfo.CurrencySymbol;
            }
            return currencySymbol;
        }

        public string GetCurrencyinRequiredFormate(string Amount, bool isSignRequired)
        {
            if (Amount.IndexOf("-", 0) <= -1)
            {
                return string.Concat(ConnectionClass.CurrencySymbol, Amount);
            }
            string[] strArrays = Amount.Split(new char[] { '-' });
            return string.Concat(Amount[0], ConnectionClass.CurrencySymbol, strArrays[1]);
        }

        public string GetSpecificCurrencyinRequiredFormate(string Amount, bool isSignRequired)
        {
            if (Amount.IndexOf("-", 0) <= -1)
            {
                return string.Concat(ConnectionClass.CurrencySymbol, Amount);
            }
            return string.Concat(ConnectionClass.CurrencySymbol, Amount);
        }

        public string[] GetExcelSheetNames(string excelFile)
        {
            OleDbConnection oleDbConnection = null;
            DataTable oleDbSchemaTable = null;
            string[] strArrays = new string[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", base.Server.MapPath("../"), "tempupload/", excelFile, ";Extended Properties=Excel 8.0;" };
            oleDbConnection = new OleDbConnection(string.Concat(strArrays));
            oleDbConnection.Open();
            oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (oleDbSchemaTable == null)
            {
                return null;
            }
            string[] str = new string[oleDbSchemaTable.Rows.Count];
            int num = 0;
            foreach (DataRow row in oleDbSchemaTable.Rows)
            {
                str[num] = row["TABLE_NAME"].ToString();
                num++;
            }
            return str;
        }

        public DataTable GetFileNameonDocType(string DocType, int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_On_DocType");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, id);
            database.AddInParameter(storedProcCommand, "@DocType", DbType.String, DocType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public bool GetGroupLeader(int companyID, int userID)
        {
            bool flag = false;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_select_usergroup_leader", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@isLeader", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            flag = Convert.ToBoolean(sqlCommand.Parameters["@isLeader"].Value);
            _commonClass.closeConnection();
            return flag;
        }

        public string getName(int Id, int companyId, string pg)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_get_name", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string str = "";
            while (sqlDataReader.Read())
            {
                str = sqlDataReader["name"].ToString();
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
            return str;
        }

        public void GetTagHelper(ref ArrayList TagName, ref ArrayList TagValue, ref ArrayList TagType)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_select_Taghelper", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlDataReader.Read())
            {
                TagName.Add(sqlDataReader["tagname"].ToString());
                TagValue.Add(sqlDataReader["tagvalue"].ToString());
                TagType.Add(sqlDataReader["tagtype"].ToString());
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
        }

        public void GridStateLoadNew(string Section, string UniqueName, RadGrid Grid, string custom)
        {
            if (this.Session[string.Concat(Section, UniqueName)] != null)
            {
                GridSettingsPersister gridSettingsPersister = new GridSettingsPersister(Grid);
                string item = (string)this.Session[string.Concat(Section, UniqueName)];
                gridSettingsPersister.LoadSettings(item);
                if (custom.ToLower() != "yes")
                {
                    Grid.Rebind();
                }
            }
        }

        public void GridStateSaveNew(string Section, string UniqueName, RadGrid Grid)
        {
            GridSettingsPersister gridSettingsPersister = new GridSettingsPersister(Grid);
            this.Session[string.Concat(Section, UniqueName)] = gridSettingsPersister.SaveSettings();
        }

        public void InitializeDropDown(DropDownList[] ddlArray, string[] ddlItems, string[] ddlItemsValue)
        {
            try
            {
                for (int i = 0; i <= (int)ddlArray.Length - 1; i++)
                {
                    for (int j = 0; j <= (int)ddlItems.Length - 1; j++)
                    {
                        ddlArray[i].Items.Add(ddlItems[j]);
                        ddlArray[i].Items[j].Value = ddlItemsValue[j];
                    }
                }
            }
            catch
            {
            }
        }

        public void Insert_Activity_History_For_Inventory(long InventoryID, string Description, int UserID, decimal Quantity, string ActionType, decimal FinalQuantity)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_insert_Activity_History_For_Inventory", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@InventoryID", InventoryID);
            sqlCommand.Parameters.AddWithValue("@Description", Description);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType);
            sqlCommand.Parameters.AddWithValue("@FinalQuantity", FinalQuantity);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }
        public void Insert_Activity_History_For_InventoryNew(long InventoryID, string Description, int UserID, decimal Quantity, string ActionType, decimal FinalQuantity, long EstimateItemID)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_insert_Activity_History_For_InventoryNew", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@InventoryID", InventoryID);
            sqlCommand.Parameters.AddWithValue("@Description", Description);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType);
            sqlCommand.Parameters.AddWithValue("@FinalQuantity", FinalQuantity);
            sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }
        //public void UpdateActivityHistoryForInventory(long InventoryID, string Description, int UserID, decimal Quantity, string ActionType, decimal FinalQuantity)
        public void UpdateActivityHistoryForInventory(long EstimateItemID, decimal Quantity, string ActionType)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_UpdateActivityHistoryForInventory", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            //sqlCommand.Parameters.AddWithValue("@InventoryID", InventoryID);
            //sqlCommand.Parameters.AddWithValue("@Description", Description);
            //sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            //sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
            //sqlCommand.Parameters.AddWithValue("@ActionType", ActionType);
            //sqlCommand.Parameters.AddWithValue("@FinalQuantity", FinalQuantity);
            sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
            sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }
        public string InventoryStockReductionType(int CompanyID, string type)
        {
            string empty = string.Empty;
            string str = string.Empty;
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Settings_inventoryStockReduction_Select((long)CompanyID);
            if (dataTable.Rows != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (type.ToLower() != "reduction")
                    {
                        if (row["CanceledJob"].ToString() == "a")
                        {
                            str = "a";
                        }
                        if (row["CanceledJob"].ToString() == "n")
                        {
                            str = "n";
                        }
                        if (row["CanceledJob"].ToString() != "p")
                        {
                            continue;
                        }
                        str = "p";
                    }
                    else
                    {
                        if (row["StockReduces"].ToString() == "e")
                        {
                            empty = "e";
                        }
                        if (row["StockReduces"].ToString() == "j")
                        {
                            empty = row["JobStatusChange"].ToString();
                        }
                        if (row["StockReduces"].ToString() != "i")
                        {
                            continue;
                        }
                        empty = "i";
                    }
                }
            }
            if (type.ToLower() == "reduction")
            {
                return empty;
            }
            return str;
        }

        public int ISInventoryReduced__OnJobCancellation_Select(long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_ISInventoryReduced__OnJobCancellation_Select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public void ISInventoryReduced__OnJobCancellation_Update(long EstimateID, int IsReduced)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_ISInventoryReduced__OnJobCancellation_Update");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@IsReduced", DbType.Int32, IsReduced);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void issues_status(int id, string status, int companyid)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_issues_status", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@status", status);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public string ItemDescriptionToPO_DN(int CompanyID, long EstimateItemID, string PageType, ref string RtnNotes)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            foreach (DataRow row in (new commonClass()).Select_itemDescriptions((long)CompanyID, EstimateItemID).Rows)
            {
                empty1 = row["Estimatetype"].ToString();
                if (row["IsItemTitle"].ToString() == "True" && row["ItemTitleValue"].ToString().Length > 0)
                {
                    empty = string.Concat(row["ItemTitleLabel"].ToString(), ":", row["ItemTitleValue"].ToString());
                }
                if (row["IsDescription"].ToString() == "True" && row["DescriptionValue"].ToString().Length > 0)
                {
                    string str2 = empty;
                    string[] strArrays = new string[] { str2, "\n", row["DescriptionLabel"].ToString(), ":", row["DescriptionValue"].ToString() };
                    empty = string.Concat(strArrays);
                }
                if (row["IsArtwork"].ToString() == "True" && row["ArtworkValue"].ToString().Length > 0)
                {
                    string str3 = empty;
                    string[] strArrays1 = new string[] { str3, "\n", row["ArtworkLabel"].ToString(), ":", row["ArtworkValue"].ToString() };
                    empty = string.Concat(strArrays1);
                }
                if (row["IsColour"].ToString() == "True" && row["ColourValue"].ToString().Length > 0)
                {
                    string str4 = empty;
                    string[] strArrays2 = new string[] { str4, "\n", row["ColourLabel"].ToString(), ":", row["ColourValue"].ToString() };
                    empty = string.Concat(strArrays2);
                }
                if (row["IsSize"].ToString() == "True" && row["SizeValue"].ToString().Length > 0)
                {
                    string str5 = empty;
                    string[] strArrays3 = new string[] { str5, "\n", row["SizeLabel"].ToString(), ":", row["SizeValue"].ToString() };
                    empty = string.Concat(strArrays3);
                }
                if (row["IsMaterial"].ToString() == "True" && row["MaterialValue"].ToString().Length > 0)
                {
                    string str6 = empty;
                    string[] strArrays4 = new string[] { str6, "\n", row["MaterialLabel"].ToString(), ":", row["MaterialValue"].ToString() };
                    empty = string.Concat(strArrays4);
                    str = row["MaterialValue"].ToString();
                }
                if (row["IsDelivery"].ToString() == "True" && row["DeliveryValue"].ToString().Length > 0)
                {
                    string str7 = empty;
                    string[] strArrays5 = new string[] { str7, "\n", row["DeliveryLabel"].ToString(), ":", row["DeliveryValue"].ToString() };
                    empty = string.Concat(strArrays5);
                }
                if (row["IsFinishing"].ToString() == "True" && row["FinishingValue"].ToString().Length > 0)
                {
                    string str8 = empty;
                    string[] strArrays6 = new string[] { str8, "\n", row["FinishingLabel"].ToString(), ":", row["FinishingValue"].ToString() };
                    empty = string.Concat(strArrays6);
                }
                if (row["IsPacking"].ToString() == "True" && row["PackingValue"].ToString().Length > 0)
                {
                    string str9 = empty;
                    string[] strArrays7 = new string[] { str9, "\n", row["PackingLabel"].ToString(), ":", row["PackingValue"].ToString() };
                    empty = string.Concat(strArrays7);
                }
                if (row["IsProofs"].ToString() == "True" && row["ProofsValue"].ToString().Length > 0)
                {
                    string str10 = empty;
                    string[] strArrays8 = new string[] { str10, "\n", row["ProofsLabel"].ToString(), ":", row["ProofsValue"].ToString() };
                    empty = string.Concat(strArrays8);
                }
                if (row["IsNotes"].ToString() == "True" && row["NotesValue"].ToString().Length > 0)
                {
                    string str11 = empty;
                    string[] strArrays9 = new string[] { str11, "\n", row["NotesLabel"].ToString(), ":", row["NotesValue"].ToString() };
                    empty = string.Concat(strArrays9);
                    empty2 = string.Concat(row["NotesLabel"].ToString(), ":", row["NotesValue"].ToString());
                }
                if (row["IsInstructions"].ToString() == "True" && row["InstructionsValue"].ToString().Length > 0)
                {
                    string str12 = empty;
                    string[] strArrays10 = new string[] { str12, "\n", row["InstructionsLabel"].ToString(), ":", row["InstructionsValue"].ToString() };
                    empty = string.Concat(strArrays10);
                }
                for (int i = 1; i < 26; i++)
                {
                    if (row[string.Concat("isCustomDescription", i)].ToString() == "True" && row[string.Concat("CustomDescriptionValue", i)].ToString().Length > 0)
                    {
                        string str13 = empty;
                        string[] strArrays11 = new string[] { str13, "\n", row[string.Concat("CustomDescriptionLabel", i)].ToString(), ":", row[string.Concat("CustomDescriptionValue", i)].ToString() };
                        empty = string.Concat(strArrays11);
                    }
                }
                if (!(PageType == "Purchase") || !(row["EstimateOtherCostName"].ToString() != ""))
                {
                    continue;
                }
                string[] strArrays12 = row["EstimateOtherCostName"].ToString().Split(new char[] { '~' });
                empty = string.Concat(empty, "\nDescription: ");
                for (int j = 0; j <= (int)strArrays12.Length - 1; j++)
                {
                    if (strArrays12[j] != "")
                    {
                        empty = string.Concat(empty, strArrays12[j], "\n");
                    }
                }
            }
            if (PageType == "DeliveryNote")
            {
                str1 = empty;
            }
            else if (PageType == "Purchase")
            {
                if (empty1 == "O")
                {
                    str1 = empty;
                }
                else if (empty1 != "C")
                {
                    str1 = (empty1 != "X" ? str : empty);
                }
                else
                {
                    str1 = empty;
                }
                RtnNotes = empty2;
            }
            return str1;
        }

        public void notes_Add(int companyId, string noteType, int noteTypeId, string description, string createDate, string modifiedDate, int createUserId, int modifyUserId, int isDelete)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_notes_add", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
            sqlCommand.Parameters.AddWithValue("@noteType", noteType);
            sqlCommand.Parameters.AddWithValue("@noteTypeId", noteTypeId);
            sqlCommand.Parameters.AddWithValue("@description", description);
            sqlCommand.Parameters.AddWithValue("@createDate", createDate);
            sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
            sqlCommand.Parameters.AddWithValue("@createUserID", createUserId);
            sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserId);
            sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void notes_Edit(int notesId, int companyId, string noteType, int noteTypeId, string description, string createDate, string modifiedDate, int createUserId, int modifyUserId, int isDelete)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_notes_edit", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@notesId", notesId);
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
            sqlCommand.Parameters.AddWithValue("@noteType", noteType);
            sqlCommand.Parameters.AddWithValue("@noteTypeId", noteTypeId);
            sqlCommand.Parameters.AddWithValue("@description", description);
            sqlCommand.Parameters.AddWithValue("@createDate", createDate);
            sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
            sqlCommand.Parameters.AddWithValue("@createUserID", createUserId);
            sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserId);
            sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public SqlConnection openConnection()
        {
            if (this.conn.State != ConnectionState.Open)
            {
                this.conn.Open();
            }

            return this.conn;
        }

        public bool performinvoicecheck(int CompanyID, string Module, string Eventname)
        {
            commonClass _commonClass = new commonClass();
            bool flag = false;
            SqlCommand sqlCommand = new SqlCommand("PC_IsArchive_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Module", Module);
            sqlCommand.Parameters.AddWithValue("@Companyid", Convert.ToInt16(CompanyID));
            sqlCommand.Parameters.AddWithValue("@Event", Eventname);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    flag = bool.Parse(sqlDataReader["isarchive"].ToString());
                }
            }
            _commonClass.closeConnection();
            return flag;
        }

        public Int32 getLockUnlockStatus(int CompanyID, string Module, string Eventname)
        {
            commonClass _commonClass = new commonClass();
            Int32 statusId = 0;
            SqlCommand sqlCommand = new SqlCommand("PC_IsArchive_Lock_Unlock_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Module", Module);
            sqlCommand.Parameters.AddWithValue("@Companyid", Convert.ToInt16(CompanyID));
            sqlCommand.Parameters.AddWithValue("@Event", Eventname);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    statusId = Int32.Parse(sqlDataReader["StatusID"].ToString());
                }
            }
            _commonClass.closeConnection();
            return statusId;
        }

        public void ReadText_Email_File(string FileName, ref string MailMessage, ref string Subject)
        {
            string empty = string.Empty;
            FileName = string.Concat(base.Server.MapPath("../ECRM/"), "EmailText/", FileName);
            if (File.Exists(FileName))
            {
                StreamReader streamReader = new StreamReader(FileName);
                empty = streamReader.ReadToEnd();
                streamReader.Close();
            }
            string[] strArrays = empty.Split(new char[] { '\u00B0' });
            Subject = strArrays[0].ToString();
            MailMessage = strArrays[1].ToString();
        }

        public string[] ReadText_InsertQuery_File()
        {
            string empty = string.Empty;
            string str = string.Concat(base.Server.MapPath("../ECRM_BETA/DataBase/"), "insertQuery.txt");
            if (File.Exists(str))
            {
                StreamReader streamReader = new StreamReader(str);
                empty = streamReader.ReadToEnd();
                streamReader.Close();
            }
            return empty.Split(new char[] { ';' });
        }

        public string ReadText_Script_File()
        {
            string empty = string.Empty;
            string str = string.Concat(base.Server.MapPath("../ECRM/"), "a.txt");
            if (File.Exists(str))
            {
                StreamReader streamReader = new StreamReader(str);
                empty = streamReader.ReadToEnd();
                streamReader.Close();
            }
            return empty;
        }

        private string ReplaceAllTags(DataTable dt, string ModuleName, string body, int companyid)
        {
            commonClass _commonClass = new commonClass();
            string str = body;
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                if (ModuleName.Trim().ToLower() == "job" || ModuleName.Trim().ToLower() == "jobcard")
                {
                    str = str.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    str = str.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    str = str.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    str = str.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    str = str.Replace("[$SupplierContactMiddleName$]", item["SupplierContactMiddleName"].ToString());
                    str = str.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    str = str.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    str = str.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["JobDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$JobHeader$]", item["JobHeader"].ToString());
                    str = str.Replace("[$JobFooter$]", item["JobFooter"].ToString());
                    str = str.Replace("[$ConsigneeURL$]", item["ConsigneeUrl"].ToString());
                    str = str.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());

                    str= Utilities.ReplaceConsigneeUrlTags(item, str);

                    str = str.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, Convert.ToInt32(this.Session["UserID"].ToString()), Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
                }
            }
            return str;
        }
        private string ReplaceInternalEmailTags(DataTable dt, DataTable dt1, string ModuleName, string body, int companyid, bool IsWebStore)
        {
            commonClass _commonClass = new commonClass();
            string str = body;
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                DataRow item1 = dt1.Rows[0];
                if (ModuleName.Trim().ToLower() == "job")
                {
                    string jobURL = string.Empty;
                    if (IsWebStore)
                    {
                        jobURL = string.Concat(global.sitePath(), "jobs/job_order_summary.aspx?frm=view&ordid=" + item["EstimateID"].ToString() + "&estid=" + item["EstimateID"].ToString() + "&jID=" + item["JobID"].ToString() + "");
                    }
                    else
                    {
                        jobURL = string.Concat(global.sitePath(), "Jobs/job_summary_reeng.aspx?estid=" + item["EstimateID"].ToString() + "&jID=" + item["JobID"].ToString() + "");
                    }
                    str = str.Replace("[$Estimator$]", item["EstimatorEmail"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$InternalJobURL$]", "<a href='" + jobURL + "'>" + jobURL + "</a>");


                    str = str.Replace("[$EstimateNumber$]", item1["EstimateNumber"].ToString());
                    str = str.Replace("[$JobNumber$]", item1["JobNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", item1["JobTitle"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item1["JobDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item1["JobCompletionDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobOrderNumber$]", item1["JobOrderNumber"].ToString());
                    str = str.Replace("[$SalesPerson$]", item1["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item1["SalesPersonEmail"].ToString());
                    str = str.Replace("[$JobHeader$]", item1["JobHeader"].ToString());
                    str = str.Replace("[$JobFooter$]", item1["JobFooter"].ToString());
                    str = str.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item1["JobValue"].ToString()), 0, "", false, false, true));
                    str = str.Replace("[$Consignment Note Number$]", item1["ConsignmentNumber"].ToString());
                    //str = str.Replace("[$ConsigneeURL$]", item1["ConsigneeUrl"].ToString());

                    str = Utilities.ReplaceConsigneeUrlTags(item1, str);

                    str = str.Replace("[$SupplierName$]", item1["SupplierName"].ToString());
                    str = str.Replace("[$SupplierContactFirstName$]", item1["SupplierContactFirstName"].ToString());
                    str = str.Replace("[$SupplierContactMiddleName$]", item1["SupplierContactMiddleName"].ToString());
                    str = str.Replace("[$SupplierContactLastName$]", item1["SupplierContactLastName"].ToString());
                    str = str.Replace("[$SupplierContactFullName$]", item1["SupplierContactFullName"].ToString());
                    str = str.Replace("[$EstimateNumber$]", item1["EstimateNumber"].ToString());
                    str = str.Replace("[$JobNumber$]", item1["JobNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", item1["JobTitle"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item1["JobDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item1["JobCompletionDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobOrderNumber$]", item1["JobOrderNumber"].ToString());
                    str = str.Replace("[$SalesPerson$]", item1["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item1["SalesPersonEmail"].ToString());
                    str = str.Replace("[$JobHeader$]", item1["JobHeader"].ToString());
                    str = str.Replace("[$JobFooter$]", item1["JobFooter"].ToString());
                    str = str.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item1["JobValue"].ToString()), 0, "", false, false, true));

                }
                else if (ModuleName.Trim().ToLower() == "estimate")
                {
                    string estimateURL = string.Concat(global.sitePath(), "estimates/estimate_summary_reeng.aspx?estid=" + item["EstimateID"].ToString() + "");
                    str = str.Replace("[$Estimator$]", item["EstimatorEmail"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$InternalEstimateURL$]", "<a href='" + estimateURL + "'>" + estimateURL + "</a>");

                    str = str.Replace("[$EstimateTitle$]", item1["EstimateTitle"].ToString());
                    str = str.Replace("[$EstimateNumber$]", item1["EstimateNumber"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimateDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimatedArtwork"].ToString(), companyid, 0, false));
                    str = str.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimatedDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$ValidFor$]", item1["ValidFor"].ToString());
                    str = str.Replace("[$SalesPerson$]", item1["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item1["SalesPersonEmail"].ToString());
                    str = str.Replace("[$EstimateHeader$]", item1["EstimateHeader"].ToString());
                    str = str.Replace("[$EstimateFooter$]", item1["EstimateFooter"].ToString());
                    str = str.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item1["EstimateValue"].ToString()), 0, "", false, false, true));
                    str = str.Replace("[$EstimateTitle$]", item1["EstimateTitle"].ToString());
                    str = str.Replace("[$EstimateNumber$]", item1["EstimateNumber"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimateDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimatedArtwork"].ToString(), companyid, 0, false));
                    str = str.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item1["EstimatedDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$ValidFor$]", item1["ValidFor"].ToString());
                    str = str.Replace("[$SalesPerson$]", item1["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item1["SalesPersonEmail"].ToString());
                    str = str.Replace("[$EstimateHeader$]", item1["EstimateHeader"].ToString());
                    str = str.Replace("[$EstimateFooter$]", item1["EstimateFooter"].ToString());
                    str = str.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item1["EstimateValue"].ToString()), 0, "", false, false, true));

                    str = Utilities.ReplaceConsigneeUrlTags(item1, str);

                }
                else if (ModuleName.Trim().ToLower() == "delivery")
                {
                    string estimateURL = string.Concat(global.sitePath(), "Delivery/delivery_add.aspx?type=edit&id=" + item["DeliveryID"].ToString() + "");
                    str = str.Replace("[$Estimator$]", item["EstimatorEmail"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$InternalDeliveryURL$]", "<a href='" + estimateURL + "'>" + estimateURL + "</a>");

                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$DeliveryHeader$]", item1["DeliveryHeader"].ToString());
                    str = str.Replace("[$DeliveryFooter$]", item1["DeliveryFooter"].ToString());
                    str = str.Replace("[$DeliveryNumber$]", item1["DeliveryNumber"].ToString());
                    str = str.Replace("[$RefNo$]", item1["RefNo"].ToString());
                    str = str.Replace("[$OrderNumber$]", item1["OrderNumber"].ToString());
                    str = str.Replace("[$CarrierName$]", item1["CarrierName"].ToString());
                    str = str.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item1["DeliveryDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$ShippedTo$]", item1["ShippedTo"].ToString());
                    // ConsignmentNumber AND ConsigneeUrl
                    //str = str.Replace("[$ConsigneeURL$]", item1["ConsigneeUrl"].ToString());
                    str = str.Replace("[$Consignment Note Number$]", item1["ConsignmentNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", item1["JobTitle"].ToString());

                    str = str.Replace("[$CustomerContactFirstName$]", item1["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item1["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item1["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$DeliveryHeader$]", item1["DeliveryHeader"].ToString());
                    str = str.Replace("[$DeliveryFooter$]", item1["DeliveryFooter"].ToString());
                    str = str.Replace("[$DeliveryNumber$]", item1["DeliveryNumber"].ToString());
                    str = str.Replace("[$RefNo$]", item1["RefNo"].ToString());
                    str = str.Replace("[$OrderNumber$]", item1["OrderNumber"].ToString());
                    str = str.Replace("[$CarrierName$]", item1["CarrierName"].ToString());
                    str = str.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item1["DeliveryDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$ShippedTo$]", item1["ShippedTo"].ToString());
                    // ConsignmentNumber AND ConsigneeUrl
                    //str = str.Replace("[$ConsigneeURL$]", item1["ConsigneeUrl"].ToString());

                    str = Utilities.ReplaceConsigneeUrlTags(item1, str);

                    str = str.Replace("[$Consignment Note Number$]", item1["ConsignmentNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", Convert.ToString(item1["JobTitle"]));
                }
                else if (ModuleName.Trim().ToLower() == "proof")
                {
                    string estimateURL = string.Concat(global.sitePath(), "Proofs/Proof_summary.aspx?estid=" + item["EstimateID"].ToString() + "&ProofID=" + item["ProofID"].ToString() + "");
                    str = str.Replace("[$Estimator$]", item["EstimatorEmail"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$InternalProofURL$]", "<a href='" + estimateURL + "'>" + estimateURL + "</a>");
                    str = str.Replace("[$EstimateOrJobname$]", item1["EstimateTitle"].ToString());

                    str = str.Replace("[$CustomerContactName$]", item1["CustomerContactFullName"].ToString());
                    str = str.Replace("[$JobNumber$]", item1["JobNumber"].ToString());

                    int proofID = int.Parse(item["ProofID"].ToString());
                    int _estimateID = int.Parse(item["EstimateID"].ToString());
                    string proofNo = EstimateBasePage.Get_Proof_Number(proofID);
                    if (!string.IsNullOrEmpty(proofNo))
                    {
                        str = str.Replace("[$ProofNumber$]", proofNo);
                    }
                    str = str.Replace("[$CustomerName$]", item1["CustomerName"].ToString());
                    str = str.Replace("[$EstimateNumber$]", item1["EstimateNumber"].ToString());
                    str = str.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());


                }
            }
            return str;
        }

        private string ReplaceFTPEmailTags(DataTable dt, string body, int CompanyID, long ProductCatalogueID,string PrintFile)
        {
            commonClass _commonClass = new commonClass();
            string str = body;
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                string printReadyFileLink = string.Empty;
                if (str.Contains("[$PrintReadyFileLink$]"))
                {
                    QueryString queryString2 = new QueryString()
                        {
                            { "doctype", "pr" },
                            { "pid", Convert.ToString(ProductCatalogueID) }
                        };
                    QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                    string sitePath = global.sitePath();
                    string[] docLink = new string[] { "<a href='", sitePath, "DocManager.ashx", queryString3.ToString().Trim(), "'  target='_blank'>", PrintFile, "</a>" };
                    printReadyFileLink = string.Concat(docLink);
                }
              

                str = str.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                str = str.Replace("[$CustomerContactFirstName$]", item["ContactFirstName"].ToString());
                str = str.Replace("[$CustomerContactLastName$]", item["ContactLastName"].ToString());
                str = str.Replace("[$CustomerContactFullName$]", item["ContactFullName"].ToString());
                str = str.Replace("[$CustomerContactEmail$]", item["ContactEmail"].ToString());
                str = str.Replace("[$ORDER_TITLE$]", item["OrderTitle"].ToString());
                str = str.Replace("[$ORDERNO$]", item["OrderNumber"].ToString());
                //str = str.Replace("[$PRODUCT_DETAILS$]", item["ProductDetails"].ToString());
                string productDetails = item["ProductDetails"].ToString().Replace(",", "<br/>");
                str = str.Replace("[$PRODUCT_DETAILS$]", productDetails);
                str = str.Replace("[$REQUIRED_BY$]", _commonClass.Eprint_return_Date_Before_View(item["RequiredBy"].ToString(), CompanyID, 0, false));
                str = str.Replace("[$STORE$]", item["StoreName"].ToString());
                str = str.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                str = str.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                str = str.Replace("[$InvoiceNumber$]", item["InvoiceNumber"].ToString());
                str = str.Replace("[$InvoiceTitle$]", item["InvoiceTitle"].ToString());
                str = str.Replace("[$OrderDate$]", _commonClass.Eprint_return_Date_Before_View(item["OrderDate"].ToString(), CompanyID, 0, false));
                str = str.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), CompanyID, 0, false));
                str = str.Replace("[$SalesPerson$]", item["SalePerson"].ToString());
                str = str.Replace("[$SalesPersonEmail$]", item["SalePersonEmail"].ToString());
                str = str.Replace("[$PDFPath$]", "");
                string currentTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                str = str.Replace("[$TimeStamp$]", currentTimestamp);
                str = str.Replace("[$TargetFTPAddress$]", item["FtpAddress"].ToString());
                str = str.Replace("[$PrintReadyFileLink$]", printReadyFileLink);

            }
            return str;
        }
        private string ReplaceAllTagsFor_DeliveryAlertEmails(DataTable dt, string ModuleName, string body, int companyid)
        {
            commonClass _commonClass = new commonClass();
            string str = body;
            int num = 0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt32(this.Session["UserID"]);
            }
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                if (ModuleName.Trim().ToLower() == "delivery")
                {
                    str = str.Replace("[$DeliveryNumber$]", item["Deliverynumber"].ToString());
                    str = str.Replace("[$JobRefNumber$]", item["JobRefNumber"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    str = str.Replace("[$DelHeader$]", item["DelHeader"].ToString());
                    str = str.Replace("[$DelFooter$]", item["DelFooter"].ToString());
                    //str = str.Replace("[$ConsigneeURL$]", item["ConsigneeUrl"].ToString());

                    str = Utilities.ReplaceConsigneeUrlTags(item, str);

                    // Job Title added on 16-11-2017 by shehzad ahmed
                    str = str.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    str = str.Replace("[$JobNumber$]", item["JobRefNumber"].ToString());
                    str = str.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());
                    str = str.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), companyid, 0, false));
                    // tags added on 10-19-2020 by Zeeshans
                    str = str.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    str = str.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    str = str.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    str = str.Replace("[$SupplierContactMiddleName$]", item["SupplierContactMiddleName"].ToString());
                    str = str.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    str = str.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    str = str.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$JobHeader$]", item["JobHeader"].ToString());
                    str = str.Replace("[$JobFooter$]", item["JobFooter"].ToString());
                    str = str.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, num, Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
                    str = str.Replace("[$ItemNumber$]", item["Number"].ToString());
                    str = str.Replace("[$ItemTitle$]", item["ItemTitle"].ToString());
                    str = str.Replace("[$ItemValueIncTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, num, Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
                    //Basharat-- Ticket 78185
                    str = str.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
                }
            }
            return str;
        }

        public string ReplaceAllTagsFor_ProofsAlertEmails(DataTable dt, string body)
        {
            commonClass _commonClass = new commonClass();
            string str = body;

            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];

                str = str.Replace("[$EstimateOrJobname$]", item["JobTitle"].ToString());
                str = str.Replace("[$Itemtitle$]", item["JobTitle"].ToString());
                str = str.Replace("[$Quantity$]", item["QTY1"].ToString());
                str = str.Replace("[$Material$]", item["MaterialValue"].ToString());
                str = str.Replace("[$Size$]", item["SizeValue"].ToString());
                str = str.Replace("[$Colour$]", item["ColourValue"].ToString());
                str = str.Replace("[$Finishing$]", item["FinishingValue"].ToString());

            }
            return str;
        }
        private string ReplaceAllTagsForJobAlertEmails(DataTable dt, string ModuleName, string body, int companyid)
        {
            commonClass _commonClass = new commonClass();
            string str = body;
            int num = 0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt32(this.Session["UserID"]);
            }
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                if (ModuleName.Trim().ToLower() == "job")
                {
                    str = str.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    str = str.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    str = str.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    str = str.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    str = str.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    str = str.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    str = str.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    str = str.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    str = str.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    str = str.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    str = str.Replace("[$SupplierContactMiddleName$]", item["SupplierContactMiddleName"].ToString());
                    str = str.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    str = str.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    str = str.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["JobDelivery"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), companyid, 0, false));
                    str = str.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
                    str = str.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    str = str.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    str = str.Replace("[$JobHeader$]", item["JobHeader"].ToString());
                    str = str.Replace("[$JobFooter$]", item["JobFooter"].ToString());

                    str = Utilities.ReplaceConsigneeUrlTags(item, str);

                    str = str.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());
                    str = str.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(companyid, num, Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
                    str = str.Replace("[$ItemNumber$]", item["Number"].ToString());
                    str = str.Replace("[$ItemTitle$]", item["ItemTitle"].ToString());
                    str = str.Replace("[$ItemValueIncTax$]", item["JobValue"].ToString());
                }
            }
            return str;
        }

        public string replaceLineBreak(string str)
        {
            return str.Replace("\n", "<br>");
        }

        public string ReplaceSingleAndDoubleQuote(string OriginalString)
        {
            return OriginalString.Replace("'", "`").Replace("\"", "``");
        }

        public string replaceSpecialCharacter(string mystring)
        {
            char[] chars;
            string empty = string.Empty;
            string str = string.Empty;
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            byte[] bytes = aSCIIEncoding.GetBytes(mystring);
            for (int i = 0; i <= (int)bytes.Length - 1; i++)
            {
                if ((bytes[i] <= 64 || bytes[i] >= 91) && (bytes[i] <= 96 || bytes[i] >= 123) && (bytes[i] <= 47 || bytes[i] >= 58))
                {
                    chars = aSCIIEncoding.GetChars(bytes);
                    str = string.Concat(str, chars[i].ToString());
                    empty = (bytes[i] == 45 || bytes[i] == 95 ? string.Concat(empty, str) : string.Concat(empty, str.Replace(str, "°")));
                }
                else
                {
                    chars = aSCIIEncoding.GetChars(bytes);
                    empty = string.Concat(empty, chars[i].ToString());
                }
            }
            return empty;
        }

        public string ReplaceSplSymbol(string inputstring)
        {
            string empty = string.Empty;
            return (new Regex("[;\\\\/:*?\"<>|&'@#+^!%~`$,\\s]")).Replace(inputstring, "_");
        }

        public string return_Date_Before_Insert(string strDate, int companyID, int userID)
        {
            string str;
            try
            {
                DateTime dateTime = DateTime.Parse(strDate);
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_getTimeZoneDetails", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string str1 = "";
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                while (sqlDataReader.Read())
                {
                    str1 = sqlDataReader["operator"].ToString().ToLower().Trim();
                    str1 = (str1 != "+" ? "+" : "-");
                    num = int.Parse(string.Concat(str1, sqlDataReader["hourDiff"].ToString()));
                    num1 = int.Parse(string.Concat(str1, sqlDataReader["minDiff"].ToString()));
                    num2 = int.Parse(string.Concat(str1, sqlDataReader["secDiff"].ToString()));
                    try
                    {
                        num3 = int.Parse(string.Concat(str1, sqlDataReader["serverhour"].ToString()));
                        num4 = int.Parse(string.Concat(str1, sqlDataReader["servermin"].ToString()));
                        num5 = int.Parse(string.Concat(str1, sqlDataReader["serversec"].ToString()));
                    }
                    catch
                    {
                    }
                }
                _commonClass.closeConnection();
                dateTime = dateTime.AddHours((double)num);
                dateTime = dateTime.AddMinutes((double)num1);
                dateTime = dateTime.AddSeconds((double)num2);
                dateTime = dateTime.AddHours((double)num3);
                dateTime = dateTime.AddMinutes((double)num4);
                dateTime = dateTime.AddSeconds((double)num5);
                str = dateTime.ToString();
            }
            catch
            {
                str = strDate;
            }
            return str;
        }

        public string return_Date_Before_Insert1(string strDate, int companyID, int userID)
        {
            string str;
            try
            {
                string[] strArrays = strDate.Split(new char[] { '/' });
                string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                strDate = string.Concat(strArrays1);
                str = strDate;
            }
            catch
            {
                str = strDate;
            }
            return str;
        }

        public string return_Date_Before_View(string strDate, int companyID, int userID)
        {
            string str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            if (strDate.Length > 0)
            {
                empty = DateTime.Parse(strDate).ToShortDateString();
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(strDate);
                    commonClass _commonClass = new commonClass();
                    SqlCommand sqlCommand = new SqlCommand("crm_common_getTimeZoneDetails", _commonClass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                    sqlCommand.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    string str1 = "";
                    string str2 = "";
                    int num = 0;
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    int num5 = 0;
                    while (sqlDataReader.Read())
                    {
                        str1 = sqlDataReader["operator"].ToString().ToLower().Trim();
                        num = int.Parse(string.Concat(str1, sqlDataReader["hourDiff"].ToString()));
                        num1 = int.Parse(string.Concat(str1, sqlDataReader["minDiff"].ToString()));
                        num2 = int.Parse(string.Concat(str1, sqlDataReader["secDiff"].ToString()));
                        try
                        {
                            num3 = int.Parse(string.Concat(str1, sqlDataReader["serverhour"].ToString()));
                            num4 = int.Parse(string.Concat(str1, sqlDataReader["servermin"].ToString()));
                            num5 = int.Parse(string.Concat(str1, sqlDataReader["serversec"].ToString()));
                        }
                        catch
                        {
                        }
                        str2 = sqlDataReader["datetimeformat"].ToString().ToUpper().Trim();
                    }
                    _commonClass.closeConnection();
                    dateTime = dateTime.AddHours((double)num);
                    dateTime = dateTime.AddMinutes((double)num1);
                    dateTime = dateTime.AddSeconds((double)num2);
                    dateTime = dateTime.AddHours((double)num3);
                    dateTime = dateTime.AddMinutes((double)num4);
                    dateTime = dateTime.AddSeconds((double)num5);
                    string str3 = dateTime.Hour.ToString();
                    string str4 = dateTime.Minute.ToString();
                    string str5 = dateTime.Second.ToString();
                    string str6 = dateTime.Day.ToString();
                    string str7 = dateTime.Month.ToString();
                    string str8 = dateTime.Year.ToString().Substring(2);
                    string str9 = dateTime.Year.ToString();
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    if (str7.Length == 1)
                    {
                        str7 = string.Concat("0", str7);
                    }
                    string str10 = "";
                    string str11 = str2;
                    string str12 = str11;
                    if (str11 != null)
                    {
                        switch (str12)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays = new string[] { str6, "/", str7, "/", str9 };
                                    str10 = string.Concat(strArrays);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays1);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays2 = new string[] { str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays3 = new string[] { str6, "/", str7, "-", str9 };
                                    str10 = string.Concat(strArrays3);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays4 = new string[] { str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays5 = new string[] { str6, "/", str7, "/", str9 };
                                    str10 = string.Concat(strArrays5);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str6, "/", str7, "/", str9 };
                                    str10 = string.Concat(strArrays6);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str7, "/", str6, "/", str9 };
                                    str10 = string.Concat(strArrays7);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays8 = new string[] { str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays9 = new string[] { str6, "/", str7, "/", str8 };
                                    str10 = string.Concat(strArrays9);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays10 = new string[] { str7, "/", str6, "/", str8 };
                                    str10 = string.Concat(strArrays10);
                                    break;
                                }
                            default:
                                {
                                    str10 = dateTime.ToString();
                                    empty1 = str10.ToString();
                                    return empty1;
                                }
                        }
                    }
                    else
                    {
                        str10 = dateTime.ToString();
                        empty1 = str10.ToString();
                        return empty1;
                    }
                    empty1 = str10.ToString();
                    return empty1;
                }
                catch
                {
                    str = strDate;
                }
                return str;
            }
            return empty1;
        }

        public string return_DateTime_Before_View(string strDate, int companyID, int userID)
        {
            string str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            if (strDate.Length > 0)
            {
                empty = DateTime.Parse(strDate).ToShortDateString();
            }
            if ((empty != "01/01/1900") & (empty != "1/1/1900"))
            {
                try
                {
                    DateTime dateTime = DateTime.Parse(strDate);
                    commonClass _commonClass = new commonClass();
                    SqlCommand sqlCommand = new SqlCommand("crm_common_getTimeZoneDetails", _commonClass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                    sqlCommand.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    string str1 = "";
                    string str2 = "";
                    int num = 0;
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    int num5 = 0;
                    while (sqlDataReader.Read())
                    {
                        str1 = sqlDataReader["operator"].ToString().ToLower().Trim();
                        num = int.Parse(string.Concat(str1, sqlDataReader["hourDiff"].ToString()));
                        num1 = int.Parse(string.Concat(str1, sqlDataReader["minDiff"].ToString()));
                        num2 = int.Parse(string.Concat(str1, sqlDataReader["secDiff"].ToString()));
                        try
                        {
                            num3 = int.Parse(string.Concat(str1, sqlDataReader["serverhour"].ToString()));
                            num4 = int.Parse(string.Concat(str1, sqlDataReader["servermin"].ToString()));
                            num5 = int.Parse(string.Concat(str1, sqlDataReader["serversec"].ToString()));
                        }
                        catch
                        {
                        }
                        str2 = sqlDataReader["datetimeformat"].ToString().ToUpper().Trim();
                    }
                    _commonClass.closeConnection();
                    dateTime = dateTime.AddHours((double)num);
                    dateTime = dateTime.AddMinutes((double)num1);
                    dateTime = dateTime.AddSeconds((double)num2);
                    dateTime = dateTime.AddHours((double)num3);
                    dateTime = dateTime.AddMinutes((double)num4);
                    dateTime = dateTime.AddSeconds((double)num5);
                    string str3 = dateTime.Hour.ToString();
                    string str4 = dateTime.Minute.ToString();
                    string str5 = dateTime.Second.ToString();
                    string str6 = dateTime.Day.ToString();
                    string str7 = dateTime.Month.ToString();
                    string str8 = dateTime.Year.ToString().Substring(2);
                    string str9 = dateTime.Year.ToString();
                    if (str3.Length == 1)
                    {
                        str3 = string.Concat("0", str3);
                    }
                    if (str4.Length == 1)
                    {
                        str4 = string.Concat("0", str4);
                    }
                    if (str5.Length == 1)
                    {
                        str5 = string.Concat("0", str5);
                    }
                    if (str6.Length == 1)
                    {
                        str6 = string.Concat("0", str6);
                    }
                    if (str7.Length == 1)
                    {
                        str7 = string.Concat("0", str7);
                    }
                    string str10 = "";
                    string str11 = str2;
                    string str12 = str11;
                    if (str11 != null)
                    {
                        switch (str12)
                        {
                            case "DD/MM/YYYY-HHMM":
                                {
                                    string[] strArrays = new string[] { str6, "/", str7, "/", str9, "-", str3, str4 };
                                    str10 = string.Concat(strArrays);
                                    break;
                                }
                            case "DD-MM-YYYY-HHMM":
                                {
                                    string[] strArrays1 = new string[] { str6, "-", str7, "-", str9, "-", str3, str4 };
                                    str10 = string.Concat(strArrays1);
                                    break;
                                }
                            case "HHMM-DD-MM-YYYY":
                                {
                                    string[] strArrays2 = new string[] { str3, str4, "-", str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays2);
                                    break;
                                }
                            case "HHMM/DD/MM/YYYY":
                                {
                                    string[] strArrays3 = new string[] { str3, str4, "/", str6, "/", str7, "-", str9 };
                                    str10 = string.Concat(strArrays3);
                                    break;
                                }
                            case "HH:MM-DD-MM-YYYY":
                                {
                                    string[] strArrays4 = new string[] { str3, ":", str4, "-", str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays4);
                                    break;
                                }
                            case "HH:MM/MM/DD/YYYY":
                                {
                                    string[] strArrays5 = new string[] { str3, ":", str4, "/", str6, "/", str7, "/", str9 };
                                    str10 = string.Concat(strArrays5);
                                    break;
                                }
                            case "DD/MM/YYYY":
                                {
                                    string[] strArrays6 = new string[] { str6, "/", str7, "/", str9 };
                                    str10 = string.Concat(strArrays6);
                                    break;
                                }
                            case "MM/DD/YYYY":
                                {
                                    string[] strArrays7 = new string[] { str7, "/", str6, "/", str9 };
                                    str10 = string.Concat(strArrays7);
                                    break;
                                }
                            case "DD-MM-YYYY":
                                {
                                    string[] strArrays8 = new string[] { str6, "-", str7, "-", str9 };
                                    str10 = string.Concat(strArrays8);
                                    break;
                                }
                            case "DD/MM/YY":
                                {
                                    string[] strArrays9 = new string[] { str6, "/", str7, "/", str8 };
                                    str10 = string.Concat(strArrays9);
                                    break;
                                }
                            case "MM/DD/YY":
                                {
                                    string[] strArrays10 = new string[] { str7, "/", str6, "/", str8 };
                                    str10 = string.Concat(strArrays10);
                                    break;
                                }
                            default:
                                {
                                    str10 = dateTime.ToString();
                                    empty1 = str10.ToString();
                                    return empty1;
                                }
                        }
                    }
                    else
                    {
                        str10 = dateTime.ToString();
                        empty1 = str10.ToString();
                        return empty1;
                    }
                    empty1 = str10.ToString();
                    return empty1;
                }
                catch
                {
                    str = strDate;
                }
                return str;
            }
            return empty1;
        }

        public string return_Event_DateTime_Before_View(string strDate, int companyID, int userID)
        {
            DateTime dateTime;
            string str;
            string str1;
            try
            {
                dateTime = DateTime.Parse(strDate);
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_getTimeZoneDetails", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string str2 = "";
                string str3 = "";
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                while (sqlDataReader.Read())
                {
                    str2 = sqlDataReader["operator"].ToString().ToLower().Trim();
                    num = int.Parse(string.Concat(str2, sqlDataReader["hourDiff"].ToString()));
                    num1 = int.Parse(string.Concat(str2, sqlDataReader["minDiff"].ToString()));
                    num2 = int.Parse(string.Concat(str2, sqlDataReader["secDiff"].ToString()));
                    try
                    {
                        num3 = int.Parse(string.Concat(str2, sqlDataReader["serverhour"].ToString()));
                        num4 = int.Parse(string.Concat(str2, sqlDataReader["servermin"].ToString()));
                        num5 = int.Parse(string.Concat(str2, sqlDataReader["serversec"].ToString()));
                    }
                    catch
                    {
                    }
                    str3 = sqlDataReader["datetimeformat"].ToString().ToUpper().Trim();
                }
                _commonClass.closeConnection();
                dateTime = dateTime.AddHours((double)num);
                dateTime = dateTime.AddMinutes((double)num1);
                dateTime = dateTime.AddSeconds((double)num2);
                dateTime = dateTime.AddHours((double)num3);
                dateTime = dateTime.AddMinutes((double)num4);
                dateTime = dateTime.AddSeconds((double)num5);
                string str4 = dateTime.Hour.ToString();
                string str5 = dateTime.Minute.ToString();
                string str6 = dateTime.Second.ToString();
                string str7 = dateTime.Day.ToString();
                string str8 = dateTime.Month.ToString();
                string str9 = dateTime.Year.ToString().Substring(2);
                string str10 = dateTime.Year.ToString();
                if (str4.Length == 1)
                {
                    str4 = string.Concat("0", str4);
                }
                if (str5.Length == 1)
                {
                    str5 = string.Concat("0", str5);
                }
                if (str6.Length == 1)
                {
                    str6 = string.Concat("0", str6);
                }
                if (str7.Length == 1)
                {
                    str7 = string.Concat("0", str7);
                }
                if (str8.Length == 1)
                {
                    str8 = string.Concat("0", str8);
                }
                str = "";
                string str11 = str3;
                string str12 = str11;
                if (str11 != null)
                {
                    switch (str12)
                    {
                        case "DD/MM/YYYY-HHMM":
                            {
                                string[] strArrays = new string[] { str7, "/", str8, "/", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays);
                                break;
                            }
                        case "DD-MM-YYYY-HHMM":
                            {
                                string[] strArrays1 = new string[] { str7, "-", str8, "-", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays1);
                                break;
                            }
                        case "HHMM-DD-MM-YYYY":
                            {
                                string[] strArrays2 = new string[] { str7, "-", str8, "-", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays2);
                                break;
                            }
                        case "HHMM/DD/MM/YYYY":
                            {
                                string[] strArrays3 = new string[] { str7, "/", str8, "-", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays3);
                                break;
                            }
                        case "HH:MM-DD-MM-YYYY":
                            {
                                string[] strArrays4 = new string[] { str7, "-", str8, "-", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays4);
                                break;
                            }
                        case "HH:MM/MM/DD/YYYY":
                            {
                                string[] strArrays5 = new string[] { str8, "/", str7, "/", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays5);
                                break;
                            }
                        case "DD/MM/YYYY":
                            {
                                string[] strArrays6 = new string[] { str7, "/", str8, "/", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays6);
                                break;
                            }
                        case "MM/DD/YYYY":
                            {
                                string[] strArrays7 = new string[] { str8, "/", str7, "/", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays7);
                                break;
                            }
                        case "DD-MM-YYYY":
                            {
                                string[] strArrays8 = new string[] { str7, "-", str8, "-", str10, "-", str4, ":", str5 };
                                str = string.Concat(strArrays8);
                                break;
                            }
                        case "DD/MM/YY":
                            {
                                string[] strArrays9 = new string[] { str7, "/", str8, "/", str9, "-", str4, ":", str5 };
                                str = string.Concat(strArrays9);
                                break;
                            }
                        case "MM/DD/YY":
                            {
                                string[] strArrays10 = new string[] { str8, "/", str7, "/", str9, "-", str4, ":", str5 };
                                str = string.Concat(strArrays10);
                                break;
                            }
                        default:
                            {
                                goto Label0;
                            }
                    }
                }
                else
                {
                    goto Label0;
                }
            Label1:
                str1 = str.ToString();
            }
            catch
            {
                str1 = strDate;
            }
            return str1;
        Label0:
            str = dateTime.ToString();
            goto Label44;
        Label44:
            string s = "";

            return string.Empty;
        }

        public string return_Event_Time_Before_View(string strDate, int companyID, int userID)
        {
            string str;
            try
            {
                DateTime dateTime = DateTime.Parse(strDate);
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_getTimeZoneDetails", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string str1 = "";
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                while (sqlDataReader.Read())
                {
                    str1 = sqlDataReader["operator"].ToString().ToLower().Trim();
                    num = int.Parse(string.Concat(str1, sqlDataReader["hourDiff"].ToString()));
                    num1 = int.Parse(string.Concat(str1, sqlDataReader["minDiff"].ToString()));
                    num2 = int.Parse(string.Concat(str1, sqlDataReader["secDiff"].ToString()));
                    try
                    {
                        num3 = int.Parse(string.Concat(str1, sqlDataReader["serverhour"].ToString()));
                        num4 = int.Parse(string.Concat(str1, sqlDataReader["servermin"].ToString()));
                        num5 = int.Parse(string.Concat(str1, sqlDataReader["serversec"].ToString()));
                    }
                    catch
                    {
                    }
                    sqlDataReader["datetimeformat"].ToString().ToUpper().Trim();
                }
                _commonClass.closeConnection();
                dateTime = dateTime.AddHours((double)num);
                dateTime = dateTime.AddMinutes((double)num1);
                dateTime = dateTime.AddSeconds((double)num2);
                dateTime = dateTime.AddHours((double)num3);
                dateTime = dateTime.AddMinutes((double)num4);
                dateTime = dateTime.AddSeconds((double)num5);
                string str2 = dateTime.Hour.ToString();
                string str3 = dateTime.Minute.ToString();
                if (str2.Length == 1)
                {
                    str2 = string.Concat("0", str2);
                }
                if (str3.Length == 1)
                {
                    str3 = string.Concat("0", str3);
                }
                str = string.Concat(str2, ":", str3).ToString();
            }
            catch
            {
                str = strDate;
            }
            return str;
        }

        public string return_regional_datetimeformat(string strDate, int companyID)
        {
            string str;
            try
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_regional_datetimeformat", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@datevalue", strDate);
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    strDate = sqlDataReader["datevalue"].ToString();
                }
                _commonClass.closeConnection();
                str = strDate;
            }
            catch
            {
                str = strDate;
            }
            return str;
        }

        public static string ReturnCurrentDateTimeByTimeZoneID(DateTime dt, string TimeZoneID)
        {
            DateTime dateTime = dt;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID);
            DateTime dateTime1 = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, timeZoneInfo);
            return dateTime1.ToString();
        }

        public int returnCustomizedFieldOrder(int companyID, string sectionName)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_select_maxOrderOfCustomizedField", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@sectionName", sectionName);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
            return (int)sqlCommand.Parameters["ReturnValue"].Value;
        }

        public string ReturnFilterExpression(string Section, string UniqueName, RadGrid Grid)
        {
            string empty = string.Empty;
            GridSettingsPersister gridSettingsPersister = new GridSettingsPersister(Grid);
            string item = (string)this.Session[string.Concat(Section, UniqueName)];
            return Grid.MasterTableView.FilterExpression;
        }

        public int returnGroupEnabled(int companyID, int userID)
        {
            int num;
            try
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_isGroupEnabled", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                sqlCommand.ExecuteNonQuery();
                int num1 = 0;
                num1 = int.Parse(sqlCommand.ExecuteScalar().ToString());
                _commonClass.closeConnection();
                num = num1;
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public string returnMyCurrency(string strCurrency, int companyID, int userID)
        {
            double num = double.Parse(strCurrency);
            return string.Format("{0:c}", num).Replace("$", "").Replace("£", "");
        }

        public string returnMyCurrency_forHeader(string strCurrency)
        {
            return string.Concat(strCurrency, " (", Convert.ToString(this.Session["currency"]), ")");
        }

        public string returnMyCurrency_showsymbol(string strCurrency, int companyID, int userID)
        {
            string str;
            try
            {
                double num = double.Parse(strCurrency);
                string str1 = "";
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_getCurrency", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                sqlCommand.ExecuteNonQuery();
                str1 = sqlCommand.ExecuteScalar().ToString();
                _commonClass.closeConnection();
                str = (str1 != "USD" ? string.Concat(str1, " ", string.Format("{0:c}", num).Replace("$", "").Replace("£", "")) : string.Concat("US$ ", string.Format("{0:c}", num).Replace("$", "").Replace("£", "")));
            }
            catch
            {
                str = strCurrency;
            }
            return str;
        }

        public int ReturnPageSize(string Section, string UniqueName, RadGrid Grid)
        {
            GridSettingsPersister gridSettingsPersister = new GridSettingsPersister(Grid);
            string item = (string)this.Session[string.Concat(Section, UniqueName)];
            return Grid.MasterTableView.PageSize;
        }

        public bool Secondadmin_login(string username, string password1)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_check_Secondadmin", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@username", username);
            sqlCommand.Parameters.AddWithValue("@password", password1);
            sqlCommand.ExecuteNonQuery();
            int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            _commonClass.closeConnection();
            if (value > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable Select_itemDescriptions(long CompanyID, long estItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_ItemDescriptions");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EtsimateItemID", DbType.Int32, estItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        // Ticket #9300 System template tags required

        public DataTable Select_ProductSubitem_Details(long CompanyID, long estItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_price_catalogue_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, estItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Job_ProductSubitem_EstimateItemIds_select(long JobId, long EstimateId, long estimateitemid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Job_ProductSubitem_EstimateItemIds_select");
            database.AddInParameter(storedProcCommand, "@JobId", DbType.Int32, JobId);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateId);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, estimateitemid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        // Ticket #9188 added new job template tags PaperCost, PressCost , Guillotine and AdditionalItemCost  

        public DataTable Job_PaperPressGuillotineItem_Costs_Details(int companyId, long estimateItemId, string estimatetype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Job_PaperPressGuillotineItem_Costs_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, estimateItemId);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, estimatetype);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable estimate_othercost_item_select(int companyId, long estimateItemId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_othercost_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, estimateItemId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        //Ticket #8063 Multi Mail - delivery note number field showing multiple numbers
        public DataTable Select_itemDescriptionsByDeliveryId(long CompanyID, long estItemID, string deliveryId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_ItemDescriptionsByDeliveryId");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EtsimateItemID", DbType.Int32, estItemID);
            database.AddInParameter(storedProcCommand, "@DeliveryNumber", DbType.String, deliveryId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void SelectViewName(string pg, DropDownList ddlleadviewname, int companyID, int userID, int ViewValueID)
        {
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_select_viewname", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@companyID", companyID);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@ViewValueID", ViewValueID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ddlleadviewname.Items.Add(baseClass.SpecialDecode(sqlDataReader["viewname"].ToString()));
                ddlleadviewname.Items[ddlleadviewname.Items.Count - 1].Value = sqlDataReader["ViewValueID"].ToString();
            }
            _commonClass.closeConnection();
        }

        public bool sendEmail(string tEmail, string fEmail, string subject, string Body)
        {
            bool flag;
            MailMessage mailMessage = new MailMessage()
            {
                To = tEmail,
                From = fEmail,
                Subject = subject,
                Body = Body,
                BodyFormat = MailFormat.Html,
                Priority = MailPriority.High
            };
            try
            {
                SmtpMail.Send(mailMessage);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void SendMailOnDeliveryStatusChange(long companyID, long DeliveryID, long DeliveryStatusID, string Module)
        {
            if (DeliveryID > (long)0 && DeliveryStatusID > (long)0)
            {
                bool flag = false;
                bool flag1 = false;
                DataTable dataTable = DeliveryBasePage.Delivery_EmailAuto_DeliveryStatus_Item(DeliveryStatusID, "AUTDeliveryEmail", "mailstatus", DeliveryID, companyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    flag = Convert.ToBoolean(row["ISEnabled"]);
                    int num = 0;
                    if (!flag)
                    {
                        continue;
                    }
                    DataTable dataTable1 = new DataTable();
                    dataTable1 = DeliveryBasePage.Delivery_EmailStatus_select(Convert.ToInt32(companyID), Convert.ToInt32(DeliveryStatusID), Convert.ToInt64(DeliveryID));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        if (dataTable1.Rows.Count < 1)
                        {
                            continue;
                        }
                        num = Convert.ToInt32(dataRow["Deliveryid"].ToString());
                        flag1 = Convert.ToBoolean(dataRow["IsEmailSent"]);
                    }
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = DeliveryBasePage.Delivery_EmailAuto_DeliveryStatus_Item(DeliveryStatusID, "AUTDeliveryEmail", "tomailaddress", DeliveryID, companyID);
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        str = row1["ToEmail"].ToString();
                    }
                    if (dataTable.Rows.Count != 1)
                    {
                        DataTable dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select_Item_delivery(Convert.ToInt32(companyID), Convert.ToInt64(DeliveryID));
                        foreach (DataRow dataRow1 in dataTable.Rows)
                        {
                            if ((long)num == DeliveryID || flag1)
                            {
                                continue;
                            }
                            empty = "donotreply@eprintsoftware.com";
                            empty1 = row["BCC"].ToString();
                            str1 = row["CC"].ToString();
                            empty2 = this.ReplaceAllTagsFor_DeliveryAlertEmails(dataTable3, Module, row["Subject"].ToString(), Convert.ToInt32(companyID));
                            str2 = this.ReplaceAllTagsFor_DeliveryAlertEmails(dataTable3, Module, row["Body"].ToString(), Convert.ToInt32(companyID));
                            str2 = string.Concat(str2, " ", row["FooterText"].ToString());//kr ticket 34
                            BaseClass.SendMailMessage_DeliveryStatusChange(empty, str, empty1, str1, empty2, str2, "", true, Convert.ToInt32(DeliveryStatusID), Convert.ToInt32(DeliveryID));
                        }
                    }
                    else
                    {
                        if (DeliveryID == (long)num || flag1)
                        {
                            continue;
                        }
                        DataTable dataTable4 = SettingsBasePage.settings_titlecode_fortemplate_select_Item_delivery(Convert.ToInt32(companyID), Convert.ToInt64(DeliveryID));
                        empty = "donotreply@eprintsoftware.com";
                        empty1 = row["BCC"].ToString();
                        str1 = row["CC"].ToString();
                        empty2 = this.ReplaceAllTagsFor_DeliveryAlertEmails(dataTable4, Module, row["Subject"].ToString(), Convert.ToInt32(companyID));
                        str2 = this.ReplaceAllTagsFor_DeliveryAlertEmails(dataTable4, Module, row["Body"].ToString(), Convert.ToInt32(companyID));
                        str2 = string.Concat(str2, " ", row["FooterText"].ToString());//kr ticket 34
                        BaseClass.SendMailMessage_DeliveryStatusChange(empty, str, empty1, str1, empty2, str2, "", true, Convert.ToInt32(DeliveryStatusID), Convert.ToInt32(DeliveryID));
                    }
                }
            }
        }

        public void SendMailOnJobStatusChange(int companyID, long EstimateID, int ddlStatusID, string Module)
        {
            bool flag = false;
            bool flag1 = false;
            if (Module.ToLower() == "job")
            {
                DataTable dataTable = new DataTable();
                int num = 0;
                int num1 = 0;
                DataTable accountID = new DataTable();
                accountID = JobBasePage.GetAccountID(companyID, EstimateID);
                foreach (DataRow row in accountID.Rows)
                {
                    num = Convert.ToInt32(row["accountid"]);
                    num1 = Convert.ToInt32(row["OrderID"]);
                }
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(companyID, num, (long)0, "Order Shipping", "Customer");
                foreach (DataRow dataRow in customerSelect.Rows)
                {
                    if (ddlStatusID != Convert.ToInt32(dataRow["StatusID"].ToString()))
                    {
                        continue;
                    }
                    long num2 = (long)0;
                    foreach (DataRow row1 in OrderBasePage.Order_select(companyID, (long)num1).Rows)
                    {
                        num2 = Convert.ToInt64(row1["StoreUserID"]);
                    }
                    storeEmail _storeEmail = new storeEmail();
                    _storeEmail.emailOrdersDetails(num2, (long)num1, companyID, Convert.ToInt32(num), "Order Shipping");
                }
                int num3 = 0;
                dataTable = JobBasePage.Jobs_EmailAutoJobStatus(ddlStatusID, "AUTJobEmail", "mailstatus", EstimateID, companyID);
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (dataRow1["IsFromWebStore"].ToString().ToLower() != "no")
                    {
                        continue;
                    }
                    flag = Convert.ToBoolean(dataRow1["ISEnabled"]);
                    if (Convert.ToInt32(dataRow1["JobID"].ToString()) > 0)
                    {
                        num3 = Convert.ToInt32(dataRow1["JobID"].ToString());
                    }
                    if (!flag)
                    {
                        continue;
                    }
                    DataTable dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select(companyID, (long)num3, "job");
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    string empty3 = string.Empty;
                    int num4 = 0;
                    int num5 = 0;
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = JobBasePage.Jobs_EmailStatus_select(companyID, ddlStatusID, (long)num3);
                    foreach (DataRow row2 in dataTable2.Rows)
                    {
                        if (dataTable2.Rows.Count < 1)
                        {
                            continue;
                        }
                        num5 = Convert.ToInt32(row2["JobID"].ToString());
                        flag1 = Convert.ToBoolean(row2["IsEmailSent"]);
                    }
                    DataTable dataTable3 = new DataTable();
                    dataTable3 = JobBasePage.Jobs_EmailAutoJobStatus(ddlStatusID, "AUTJobEmail", "tomailaddress", EstimateID, companyID);
                    foreach (DataRow dataRow2 in dataTable3.Rows)
                    {
                        str = dataRow2["ToEmail"].ToString();
                        num4 = Convert.ToInt32(dataRow2["JobID"].ToString());
                    }
                    if (dataTable.Rows.Count != 1)
                    {
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            if (num5 <= 0 || flag1)
                            {
                                if (flag1)
                                {
                                    continue;
                                }
                                empty = "donotreply@eprintsoftware.com";
                                empty1 = dataRow1["BCC"].ToString();
                                str1 = dataRow1["CC"].ToString();
                                empty2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Subject"].ToString(), companyID);
                                str2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Body"].ToString(), companyID);
                                BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num4);
                            }
                            else
                            {
                                if (num5 == num4)
                                {
                                    continue;
                                }
                                empty = "donotreply@eprintsoftware.com";
                                empty1 = dataRow1["BCC"].ToString();
                                str1 = dataRow1["CC"].ToString();
                                empty2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Subject"].ToString(), companyID);
                                str2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Body"].ToString(), companyID);
                                BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num4);
                            }
                        }
                    }
                    else
                    {
                        if (num4 == num5)
                        {
                            continue;
                        }
                        empty = "donotreply@eprintsoftware.com";
                        empty1 = dataRow1["BCC"].ToString();
                        str1 = dataRow1["CC"].ToString();
                        empty2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Subject"].ToString(), companyID);
                        str2 = this.ReplaceAllTags(dataTable1, Module, dataRow1["Body"].ToString(), companyID);
                        BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num4);
                    }
                }
            }
        }
        public void SendInternalMailOnModuleStatusChange(int companyID, long EstimateID, int ddlStatusID, string Module)
        {
            bool flag = false;
            bool flag1 = false;
            DataTable dataTable = new DataTable();
            DataTable dataTable3 = new DataTable();
            int num = 0;
            int num1 = 0;
            int num3 = 0;
            if (Module.ToLower() == "job")
            {
                dataTable = JobBasePage.Jobs_EmailAutoJobStatus(ddlStatusID, "InternalJobAlert", "mailstatus", EstimateID, companyID);
                if (dataTable.Rows.Count > 0)
                {
                    dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select(companyID, Convert.ToInt64(dataTable.Rows[0]["JobID"]), Module.ToLower(), "");
                }
            }
            else if (Module.ToLower() == "estimate")
            {
                dataTable = JobBasePage.Jobs_EmailAutoJobStatus(ddlStatusID, "InternalEstimateAlert", "mailstatus", EstimateID, companyID);
                if (dataTable.Rows.Count > 0)
                {
                    dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select(companyID, EstimateID, Module.ToLower(), "");
                }
            }
            else if (Module.ToLower() == "delivery")
            {
                dataTable = DeliveryBasePage.Internal_Delivery_Email_Select(ddlStatusID, companyID, "InternalDeliveryAlert", Convert.ToInt32(EstimateID));
                if (dataTable.Rows.Count > 0)
                {
                    dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select(companyID, Convert.ToInt32(EstimateID), "note", "");
                }
            }
            else if (Module.ToLower() == "proof")
            {
                dataTable = EstimateBasePage.Internal_Proof_Email_Select(ddlStatusID, companyID, "InternalProofAlert", Convert.ToInt32(EstimateID));
            }
            bool flag2 = false;
            foreach (DataRow dataRow1 in dataTable.Rows)
            {
                flag = Convert.ToBoolean(dataRow1["ISEnabled"]);
                if (dataRow1["IsFromWebStore"].ToString().ToLower() != "no")
                {
                    flag2 = true;
                }
                if (Convert.ToInt32(dataRow1["JobID"].ToString()) > 0)
                {
                    num3 = Convert.ToInt32(dataRow1["JobID"].ToString());
                }
                if (!flag)
                {
                    continue;
                }
                DataTable dataTable1 = SettingsBasePage.settings_get_internal_email_template_values(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), EstimateID, Module.ToLower());

                if (Module.ToLower() == "proof")
                {
                    dataTable3 = SettingsBasePage.settings_proof_template_select(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), Convert.ToInt32(dataTable1.Rows[0]["EstimateID"]), "");

                }

                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                int num4 = 0;
                int num5 = 0;
                DataTable dataTable2 = new DataTable();
                dataTable2 = JobBasePage.Jobs_EmailStatus_select(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ddlStatusID, (long)num3);
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    if (dataTable2.Rows.Count < 1)
                    {
                        continue;
                    }
                    num5 = Convert.ToInt32(row2["JobID"].ToString());
                    flag1 = Convert.ToBoolean(row2["IsEmailSent"]);
                }
                if (flag1)
                {
                    continue;
                }
                empty = "donotreply@eprintsoftware.com";
                empty1 = dataRow1["BCC"].ToString();
                str1 = dataRow1["CC"].ToString();
                str = this.ReplaceInternalEmailTags(dataTable1, dataTable3, Module, dataRow1["EmailTo"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), flag2);
                empty2 = this.ReplaceInternalEmailTags(dataTable1, dataTable3, Module, dataRow1["Subject"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), flag2);
                str2 = this.ReplaceInternalEmailTags(dataTable1, dataTable3, Module, dataRow1["Body"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), flag2);
                str2 = string.Concat(str2, " ", dataRow1["FooterText"].ToString());
                BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num3);
            }
        }
        public void SendFTPEmails(int companyID, long ProductCatalogueID, long EstimateItemID, string TemplateType,string PrintFile)
        {
            bool flag = false;
            bool flag1 = false;
            DataTable dataTable = new DataTable();
            int num = 0;
            int num1 = 0;
            int num3 = 0;
            dataTable = SettingsBasePage.GetFTPEmailTemplate(companyID, TemplateType);
            bool flag2 = false;
            foreach (DataRow dataRow1 in dataTable.Rows)
            {
                //flag = Convert.ToBoolean(dataRow1["ISEnabled"]);
                if (dataRow1["IsFromWebStore"].ToString().ToLower() != "no")
                {
                    flag2 = true;
                }
                num3 = Convert.ToInt32(EstimateItemID);
                //if (Convert.ToInt32(dataRow1["JobID"].ToString()) > 0)
                //{
                //    num3 = Convert.ToInt32(dataRow1["JobID"].ToString());
                //}
                //if (!flag)
                //{
                //    continue;
                //}
                DataTable dataTable1 = SettingsBasePage.GetFTPEmailTags(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID, EstimateItemID);


                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                int num4 = 0;
                int num5 = 0;
                DataTable dataTable2 = new DataTable();
                dataTable2 = JobBasePage.Jobs_EmailStatus_select(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), 0, (long)num3);
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    if (dataTable2.Rows.Count < 1)
                    {
                        continue;
                    }
                    num5 = Convert.ToInt32(row2["JobID"].ToString());
                    flag1 = Convert.ToBoolean(row2["IsEmailSent"]);
                }
                if (flag1)
                {
                    continue;
                }
                empty = "donotreply@eprintsoftware.com";
                empty1 = dataRow1["BCC"].ToString();
                str1 = dataRow1["CC"].ToString();
                if (TemplateType == "FTP Failure Emails")
                {
                    string additionalEmail = "support@hexicomsoftware.com";
                    if (!string.IsNullOrEmpty(str1))
                    {
                        str1 += "," + additionalEmail;
                    }
                    else
                    {
                        str1 = additionalEmail;
                    }
                }
                str = this.ReplaceFTPEmailTags(dataTable1, dataRow1["EmailTo"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID,PrintFile);
                empty2 = this.ReplaceFTPEmailTags(dataTable1, dataRow1["Subject"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID,PrintFile);
                str2 = this.ReplaceFTPEmailTags(dataTable1, dataRow1["Body"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID,PrintFile);
                str2 = string.Concat(str2, " ", dataRow1["FooterText"].ToString());
                BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, 0, num3);
            }
        }

        public void NewMailOnJobStatusChange(int companyID, long EstimateID, int ddlStatusID, string Module)
        {
            bool flag = false;
            bool flag1 = false;
            if (Module.ToLower() == "job")
            {
                DataTable dataTable = new DataTable();
                int num = 0;
                int num1 = 0;
                DataTable accountID = new DataTable();
                accountID = JobBasePage.GetAccountID(companyID, EstimateID);
                foreach (DataRow row in accountID.Rows)
                {
                    num = Convert.ToInt32(row["accountid"]);
                    num1 = Convert.ToInt32(row["OrderID"]);
                }
                DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(companyID, num, (long)0, "Order Shipping", "Customer");
                foreach (DataRow dataRow in customerSelect.Rows)
                {
                    if (ddlStatusID != Convert.ToInt32(dataRow["StatusID"].ToString()))
                    {
                        continue;
                    }
                    long num2 = (long)0;
                    foreach (DataRow row1 in OrderBasePage.Order_select(companyID, (long)num1).Rows)
                    {
                        num2 = Convert.ToInt64(row1["StoreUserID"]);
                    }
                    storeEmail _storeEmail = new storeEmail();
                    _storeEmail.emailOrdersDetails(num2, (long)num1, companyID, Convert.ToInt32(num), "Order Shipping");
                }

            }
        }

        public void SendMailOnJobStatusChange_Item(int companyID, long EstimateID, int ddlStatusID, string Module, long EstimateItemID, long ModuleID)
        {
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            if (Module.ToLower() == "job")
            {
                if (ModuleID != (long)0)
                {
                    flag2 = true;
                    if (EstimateID == ModuleID)
                    {
                        foreach (DataRow row in JobBasePage.JobItem_EstimateItemID_Select(EstimateID, "spiltoff").Rows)
                        {
                            ModuleID = Convert.ToInt64(row["JobID"]);
                        }
                    }
                }
                else
                {
                    foreach (DataRow dataRow in JobBasePage.JobItem_EstimateItemID_Select(EstimateItemID, "jobmain").Rows)
                    {
                        ModuleID = Convert.ToInt64(dataRow["JobID"]);
                    }
                    flag2 = false;
                }
                DataTable dataTable = new DataTable();
                if (!flag2)
                {
                    long estimateItemID = (long)0;
                    dataTable = JobBasePage.Jobs_EmailAutoJobStatus_Item(ddlStatusID, "AUTJobEmail", "mailstatus", ModuleID, companyID, EstimateItemID);
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (row1["IsFromWebStore"].ToString().ToLower() != "no")
                        {
                            continue;
                        }
                        flag = Convert.ToBoolean(row1["ISEnabled"]);
                        if (Convert.ToInt32(row1["JobID"].ToString()) > 0)
                        {
                            estimateItemID = EstimateItemID;
                        }
                        if (!flag)
                        {
                            continue;
                        }
                        DataTable dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select_Item(companyID, EstimateItemID);
                        string empty = string.Empty;
                        string str = string.Empty;
                        string empty1 = string.Empty;
                        string str1 = string.Empty;
                        string empty2 = string.Empty;
                        string str2 = string.Empty;
                        string empty3 = string.Empty;
                        int num = 0;
                        int num1 = 0;
                        DataTable dataTable2 = new DataTable();
                        dataTable2 = JobBasePage.Jobs_EmailStatus_select(companyID, ddlStatusID, estimateItemID);
                        foreach (DataRow dataRow1 in dataTable2.Rows)
                        {
                            if (dataTable2.Rows.Count < 1)
                            {
                                continue;
                            }
                            num1 = Convert.ToInt32(dataRow1["JobID"].ToString());
                            flag1 = Convert.ToBoolean(dataRow1["IsEmailSent"]);
                        }
                        DataTable dataTable3 = new DataTable();
                        dataTable3 = JobBasePage.Jobs_EmailAutoJobStatus_Item(ddlStatusID, "AUTJobEmail", "tomailaddress", ModuleID, companyID, EstimateItemID);
                        foreach (DataRow row2 in dataTable3.Rows)
                        {
                            str = row2["ToEmail"].ToString();
                            num = Convert.ToInt32(EstimateItemID);
                        }
                        if (dataTable.Rows.Count != 1)
                        {
                            foreach (DataRow dataRow2 in dataTable.Rows)
                            {
                                if (num1 <= 0 || flag1)
                                {
                                    if (flag1)
                                    {
                                        continue;
                                    }
                                    empty = "donotreply@eprintsoftware.com";
                                    empty1 = row1["BCC"].ToString();
                                    str1 = row1["CC"].ToString();
                                    empty2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Subject"].ToString(), companyID);
                                    str2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Body"].ToString(), companyID);
                                    str2 = string.Concat(str2, " ", row1["FooterText"].ToString());
                                    BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num);
                                }
                                else
                                {
                                    if (num1 == num)
                                    {
                                        continue;
                                    }
                                    empty = "donotreply@eprintsoftware.com";
                                    empty1 = row1["BCC"].ToString();
                                    str1 = row1["CC"].ToString();
                                    empty2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Subject"].ToString(), companyID);
                                    str2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Body"].ToString(), companyID);
                                    str2 = string.Concat(str2, " ", row1["FooterText"].ToString());
                                    BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num);
                                }
                            }
                        }
                        else
                        {
                            if (num == num1)
                            {
                                continue;
                            }
                            empty = "donotreply@eprintsoftware.com";
                            empty1 = row1["BCC"].ToString();
                            str1 = row1["CC"].ToString();
                            empty2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Subject"].ToString(), companyID);
                            str2 = this.ReplaceAllTagsForJobAlertEmails(dataTable1, Module, row1["Body"].ToString(), companyID);
                            str2 = string.Concat(str2, " ", row1["FooterText"].ToString());
                            BaseClass.SendMailMessageJobStatusChange(empty, str, empty1, str1, empty2, str2, empty3, true, ddlStatusID, num);
                        }
                    }
                }
                else
                {
                    foreach (DataRow row3 in JobBasePage.JobItem_EstimateItemID_Select(ModuleID, "items").Rows)
                    {
                        long estimateItemID1 = (long)0;
                        dataTable = JobBasePage.Jobs_EmailAutoJobStatus_Item(ddlStatusID, "AUTJobEmail", "mailstatus", ModuleID, companyID, Convert.ToInt64(row3["EstimateItemID"]));
                        foreach (DataRow dataRow3 in dataTable.Rows)
                        {
                            if (dataRow3["IsFromWebStore"].ToString().ToLower() != "no")
                            {
                                continue;
                            }
                            flag = Convert.ToBoolean(dataRow3["ISEnabled"]);
                            if (Convert.ToInt32(dataRow3["JobID"].ToString()) > 0)
                            {
                                estimateItemID1 = EstimateItemID;
                            }
                            if (!flag)
                            {
                                continue;
                            }
                            DataTable dataTable4 = SettingsBasePage.settings_titlecode_fortemplate_select_Item(companyID, Convert.ToInt64(row3["EstimateItemID"]));
                            string str3 = string.Empty;
                            string empty4 = string.Empty;
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            string empty6 = string.Empty;
                            string str6 = string.Empty;
                            int num2 = 0;
                            int num3 = 0;
                            DataTable dataTable5 = new DataTable();
                            dataTable5 = JobBasePage.Jobs_EmailStatus_select(companyID, ddlStatusID, estimateItemID1);
                            foreach (DataRow row4 in dataTable5.Rows)
                            {
                                if (dataTable5.Rows.Count < 1)
                                {
                                    continue;
                                }
                                num3 = Convert.ToInt32(row4["JobID"].ToString());
                                flag1 = Convert.ToBoolean(row4["IsEmailSent"]);
                            }
                            DataTable dataTable6 = new DataTable();
                            dataTable6 = JobBasePage.Jobs_EmailAutoJobStatus_Item(ddlStatusID, "AUTJobEmail", "tomailaddress", ModuleID, companyID, Convert.ToInt64(row3["EstimateItemID"]));
                            foreach (DataRow dataRow4 in dataTable6.Rows)
                            {
                                empty4 = dataRow4["ToEmail"].ToString();
                                num2 = Convert.ToInt32(row3["EstimateItemID"]);
                            }
                            if (dataTable.Rows.Count != 1)
                            {
                                foreach (DataRow row5 in dataTable.Rows)
                                {
                                    if (num3 <= 0 || flag1)
                                    {
                                        if (flag1)
                                        {
                                            continue;
                                        }
                                        str3 = "donotreply@eprintsoftware.com";
                                        str4 = dataRow3["BCC"].ToString();
                                        empty5 = dataRow3["CC"].ToString();
                                        str5 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Subject"].ToString(), companyID);
                                        empty6 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Body"].ToString(), companyID);
                                        empty6 = string.Concat(empty6, " ", dataRow3["FooterText"].ToString());
                                        BaseClass.SendMailMessageJobStatusChange(str3, empty4, str4, empty5, str5, empty6, str6, true, ddlStatusID, num2);
                                    }
                                    else
                                    {
                                        if (num3 == num2)
                                        {
                                            continue;
                                        }
                                        str3 = "donotreply@eprintsoftware.com";
                                        str4 = dataRow3["BCC"].ToString();
                                        empty5 = dataRow3["CC"].ToString();
                                        str5 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Subject"].ToString(), companyID);
                                        empty6 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Body"].ToString(), companyID);
                                        empty6 = string.Concat(empty6, " ", dataRow3["FooterText"].ToString());
                                        BaseClass.SendMailMessageJobStatusChange(str3, empty4, str4, empty5, str5, empty6, str6, true, ddlStatusID, num2);
                                    }
                                }
                            }
                            else
                            {
                                if (num2 == num3)
                                {
                                    continue;
                                }
                                str3 = "donotreply@eprintsoftware.com";
                                str4 = dataRow3["BCC"].ToString();
                                empty5 = dataRow3["CC"].ToString();
                                str5 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Subject"].ToString(), companyID);
                                empty6 = this.ReplaceAllTagsForJobAlertEmails(dataTable4, Module, dataRow3["Body"].ToString(), companyID);
                                empty6 = string.Concat(empty6, " ", dataRow3["FooterText"].ToString());
                                BaseClass.SendMailMessageJobStatusChange(str3, empty4, str4, empty5, str5, empty6, str6, true, ddlStatusID, num2);
                            }
                        }
                    }
                }
            }
        }

        public string Settings_inventoryStockReduction_CancelledJob(long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_inventoryStockReduction_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            DataRow[] dataRowArray = dataTable.Select();
            if (dataTable.Rows.Count <= 0)
            {
                return " ";
            }
            return dataRowArray[0]["CanceledJob"].ToString();
        }

        public string Settings_inventoryStockReduction_Select(long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_inventoryStockReduction_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            DataRow[] dataRowArray = dataTable.Select();
            if (dataTable.Rows.Count <= 0)
            {
                return " ";
            }
            string str = dataRowArray[0]["StockReduces"].ToString();
            if (str != "j")
            {
                return str;
            }
            return dataRowArray[0]["JobStatusChange"].ToString();
        }

        public string settings_paperMeasurementType(int companyID)
        {
            string str;
            string empty = string.Empty;
            try
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("pc_settings_paperMeasurementType", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    empty = sqlDataReader["paperType"].ToString();
                }
                _commonClass.closeConnection();
                str = empty;
            }
            catch
            {
                str = empty;
            }
            return str;
        }

        public string Split_ItemDescription_fordescription(string strData)
        {
            string empty = string.Empty;
            string[] strArrays = strData.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (i == 1)
                {
                    if (strArrays[i] != "")
                    {
                        empty = this.strItemDesc(strArrays[i]);
                    }
                    if (empty != "")
                    {
                        char[] chrArray = new char[] { ':' };
                        empty = empty.Split(chrArray)[1];
                    }
                }
            }
            return empty.ToString();
        }

        public string strItemDesc(string strArray_0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] strArrays = strArray_0.Split(new char[] { '»' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (i == 2 && string.Compare(strArrays[3].ToString(), "true", true) == 0 && !string.IsNullOrEmpty(strArrays[2].ToString()))
                    {
                        stringBuilder.AppendFormat("{0}: {1} \n", strArrays[1].ToString(), strArrays[2].ToString());
                    }
                }
            }
            catch
            {
            }
            return stringBuilder.ToString();
        }

        public void suspend_company(int companyid)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_suspend_company", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void tabdisplaysettings(int companyID, string tabname, bool isactive)
        {
            commonClass _commonClass = new commonClass();
            object[] objArray = new object[] { "crm_tabdisplaysettings_secadmin ", companyID, ",", tabname, ",", isactive };
            string str = string.Concat(objArray);
            (new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public string ToRemoveDecimalPlacesIfZero(string Amount)
        {
            bool flag = false;
            if (Amount.Contains("."))
            {
                int num = Amount.IndexOf(".") + 1;
                while (num < Amount.Length)
                {
                    if (Amount.Substring(num, 1) != "0")
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                        num++;
                    }
                }
            }
            if (flag)
            {
                try
                {
                    Amount = Amount.Substring(0, Amount.IndexOf("."));
                }
                catch
                {
                }
            }
            return Amount;
        }

        public void update_companytype(long CompanyID, long EstimateID, string compnaytype)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_Estimate_Prospect_Convert_To_Customer", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyId", CompanyID);
            sqlCommand.Parameters.AddWithValue("@EstimateId", EstimateID);
            sqlCommand.Parameters.AddWithValue("@CompanyType", compnaytype);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void update_LastViewDate(string pg, int id)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_update_lastviewdate", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
        }

        public void updateCustomizedLeadFieldLayout(string pg, ArrayList fieldid, ArrayList isdisplay, ArrayList isrequired, ArrayList isreadonly, ArrayList screenName, ArrayList OrderNumber, int companyID)
        {
            string empty = string.Empty;
            for (int i = 0; i < fieldid.Count; i++)
            {
                int item = (int)fieldid[i];
                int num = (int)isdisplay[i];
                int item1 = (int)isrequired[i];
                int num1 = (int)isreadonly[i];
                empty = screenName[i].ToString();
                int num2 = int.Parse(OrderNumber[i].ToString().Trim());
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_updatecustomizelayout", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@pg", pg);
                sqlCommand.Parameters.AddWithValue("@companyID", companyID);
                sqlCommand.Parameters.AddWithValue("@CustomizeID", item);
                sqlCommand.Parameters.AddWithValue("@is_displayed", num);
                sqlCommand.Parameters.AddWithValue("@is_required", item1);
                sqlCommand.Parameters.AddWithValue("@is_readonly", num1);
                sqlCommand.Parameters.AddWithValue("@screenName", empty);
                sqlCommand.Parameters.AddWithValue("@orderNumber", num2);
                sqlCommand.ExecuteNonQuery();
                _commonClass.closeConnection();
            }
        }

        public void UpdateNumber(int companyid, int createdUserID, int modifiedUserID, int startinFrom, int increment, string prefix, string type, string CreatedDate)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_updateNumbers", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@companyID", companyid);
            sqlCommand.Parameters.Add("@CreatedUserID", createdUserID);
            sqlCommand.Parameters.Add("@ModifiedUserID", modifiedUserID);
            sqlCommand.Parameters.Add("@startingFrom", startinFrom);
            sqlCommand.Parameters.Add("@increment", increment);
            sqlCommand.Parameters.Add("@prefix", prefix);
            sqlCommand.Parameters.Add("@type", type);
            sqlCommand.Parameters.Add("@CreatedDate", CreatedDate);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }

        public void UpdateTheme(int companyid, string ImageFolder, string theme)
        {
            SqlCommand sqlCommand = new SqlCommand("crm_updateTheme", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@companyID", companyid);
            sqlCommand.Parameters.Add("@ImageFolder", ImageFolder);
            sqlCommand.Parameters.Add("@theme", theme);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }

        public void UserSetting_Insert(int CompanyID, int UserID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_UserSettings_Select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            dataTable.Load(sqlCommand.ExecuteReader());
            foreach (DataRow row in dataTable.Rows)
            {
                this.ht_UserSettings.Add(row["KeyName"].ToString(), row["KeyValue"].ToString());
            }
            string htUserSettings = string.Concat("UserSetting", UserID);
            this.Session[htUserSettings] = this.ht_UserSettings;
            _commonClass.closeConnection();
        }

        public string UserSetting_Selete(int CompanyID, int UserID, string KeyName)
        {
            string str = string.Concat("UserSetting", UserID);
            if (this.Session[str] != null)
            {
                this.ht_UserSettings = (Hashtable)this.Session[str];
            }
            string empty = string.Empty;
            if (this.ht_UserSettings == null || this.ht_UserSettings.Count == 0)
            {
                this.UserSetting_Insert(CompanyID, UserID);
                if (this.ht_UserSettings.ContainsKey(KeyName))
                {
                    empty = this.ht_UserSettings[KeyName].ToString();
                }
            }
            else if (this.ht_UserSettings.ContainsKey(KeyName))
            {
                empty = this.ht_UserSettings[KeyName].ToString();
            }
            return empty;
        }

        public void UserSetting_Update(int CompanyID, int UserID, string KeyName, string KeyValue)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("[PC_UserSettings_Update]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@KeyName", KeyName);
            sqlCommand.Parameters.AddWithValue("@KeyValue", KeyValue);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            string htUserSettings = string.Concat("UserSetting", UserID);
            if (this.Session[htUserSettings] != null)
            {
                this.ht_UserSettings = (Hashtable)this.Session[htUserSettings];
            }
            this.ht_UserSettings[KeyName] = KeyValue;
            this.Session[htUserSettings] = this.ht_UserSettings;
        }

        public int UserSettings_Select_onKeyname(int CompanyID, int UserID, string KeyName)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            SqlCommand sqlCommand = new SqlCommand("PC_UserSettings_Select_onKeyname", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt16(this.Session["CompanyID"]));
            sqlCommand.Parameters.AddWithValue("@KeyName", "purchases_view");
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    num = int.Parse(sqlDataReader["KeyValue"].ToString());
                }
            }
            _commonClass.closeConnection();
            return num;
        }

        public DataSet usertype_viewall(int companyID, string sortField, string letter1)
        {
            if (letter1 == null | (letter1 == ""))
            {
                letter1 = "XX";
            }
            commonClass _commonClass = new commonClass();
            object[] objArray = new object[] { "crm_common_usertype_viewall ", companyID, ",", sortField, ",", letter1 };
            string str = string.Concat(objArray);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            return dataSet;
        }

        public static bool CheckProofPermission()
        {
            DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
            DataTable _item = appSettingsAndConnectionString.Tables[0];
            bool Isproof = false;
            foreach (DataRow dr in _item.Rows)
            {
                if (dr["IsProof"].ToString().ToLower() == "true")
                {
                    Isproof = true;
                }
                else
                {
                    Isproof = false;
                }
            }
            return Isproof;
        }
        public static bool CheckFTPEnable()
        {
            DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
            DataTable _item = appSettingsAndConnectionString.Tables[0];
            bool isFTP = false;
            foreach (DataRow dr in _item.Rows)
            {
                if (dr["IsFTPEnable"].ToString().ToLower() == "true")
                {
                    isFTP = true;
                }
                else
                {
                    isFTP = false;
                }
            }
            return isFTP;
        }
        public static FtpSettingsModel GetFtpSettingsIfConfigured(int companyId, int priceCatalogueId)
        {
            var settings = SettingsBasePage.GetFtpSettings(companyId);
            if (settings != null)
            {
                return new FtpSettingsModel
                {
                    FtpAddress = settings.FtpAddress,
                    Username = settings.Username,
                    Port = settings.Port,
                    EncryptedPassword = commonClass.Decrypt(settings.EncryptedPassword),
                    RootFolder = settings.RootFolder,
                    FileTransferProtocol = settings.FileTransferProtocol
                };
            }
            return null;
        }

        public static void UploadFileToSftp(FtpSettingsModel ftpSettings, string localFilePath, string folder, string prefix, int CompanyID, long PriceCatalogueID,string expectedActionName, long EstimateItemID = 0)
        {
            string FTPSource = string.Empty;
            if(expectedActionName.ToLower().Contains("job"))
            {
                FTPSource = "jobs";
            }
            else if(expectedActionName.ToLower().Contains("order"))
            {
                FTPSource = "order";
            }
            else if(expectedActionName.ToLower().Contains("invoice"))
            {
                FTPSource = "invoice";
            }
            var prefixSettings = SettingsBasePage.GetFtpPrefixSettings(CompanyID);
            DataTable dataTable6 = commonClass.Get_ProductFileByType(PriceCatalogueID, CompanyID);
            string fileName = Path.GetFileName(localFilePath);
            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
            {
                fileName = dataTable6.Rows[0]["FileName"].ToString();
            }
            string finalFileName = fileName;
            string prefixAfterReplacingTags = commonClass.ReplaceFtpTagsFromProc(prefix, CompanyID, PriceCatalogueID, EstimateItemID, folder);
            string prefixedFileName = (prefixAfterReplacingTags ?? "") + fileName;
            if (prefixSettings != null)
            {
                switch (prefixSettings.PrefixSelectedMode)
                {
                    case 1: // Prefix
                        finalFileName = (prefixAfterReplacingTags ?? "") + fileName;
                        break;

                    case 2: // Overwrite
                        finalFileName = (prefixAfterReplacingTags ?? "") + Path.GetExtension(fileName);
                        break;

                    case 0: // None
                    default:
                        finalFileName = fileName;
                        break;
                }
            }
            else
            {
                finalFileName = fileName;
            }
            string remotePath = $"/{ftpSettings.RootFolder}/{folder?.TrimEnd('/')}/{finalFileName}".Replace("//", "/");
            commonClass _common = new commonClass();
            DateTime TimeStamp = DateTime.Now;
            if (ftpSettings.FileTransferProtocol.Equals("SFTP", StringComparison.OrdinalIgnoreCase))
            {
                using (var sftp = new SftpClient(ftpSettings.FtpAddress, ftpSettings.Port, ftpSettings.Username, ftpSettings.EncryptedPassword))
                {
                    string ftpStatus = "Failure";
                    string ftpErrorMessage = string.Empty;
                    bool processSuccessful = false;

                    try
                    {
                        try
                        {
                            sftp.Connect();
                        }
                        catch
                        {
                            ftpErrorMessage = "Unable to connect to SFTP server.";
                        }

                        if (string.IsNullOrEmpty(ftpErrorMessage))
                        {
                            sftp.OperationTimeout = TimeSpan.FromMinutes(10);

                            if (!File.Exists(localFilePath))
                            {
                                ftpErrorMessage = "File not found.";
                            }
                            else
                            {
                                try
                                {
                                    using (var fileStream = new FileStream(localFilePath, FileMode.Open))
                                    {
                                        sftp.UploadFile(fileStream, remotePath, true);
                                    }

                                    ftpStatus = "Success";
                                    processSuccessful = true;
                                }
                                catch
                                {
                                    ftpErrorMessage = "Unable to upload (write) file to SFTP server.";
                                }
                            }
                        }
                    }
                    catch
                    {
                        ftpErrorMessage = "Unexpected error during FTP process.";
                    }
                    finally
                    {
                        SettingsBasePage.SaveFtpLogs(CompanyID, PriceCatalogueID, EstimateItemID, TimeStamp, ftpStatus, folder, fileName, ftpErrorMessage);
                        EstimateBasePage.SaveEstimateItemFTPAddress(CompanyID, EstimateItemID, ftpSettings.FtpAddress, processSuccessful ? "Successful" : "Fail", FTPSource);
                        _common.SendFTPEmails(CompanyID, PriceCatalogueID, EstimateItemID, processSuccessful ? "FTP Success Emails" : "FTP Failure Emails", fileName);

                        if (sftp.IsConnected)
                        {
                            sftp.Disconnect();
                        }
                    }
                }

            }
            else if (ftpSettings.FileTransferProtocol.Equals("FTPS", StringComparison.OrdinalIgnoreCase))
            {
                using (var client = new FtpClient(ftpSettings.FtpAddress, new NetworkCredential(ftpSettings.Username, ftpSettings.EncryptedPassword)))
                {
                    string ftpStatus = "Failure";
                    string ftpErrorMessage = string.Empty;
                    bool processSuccessful = false;

                    try
                    {
                        try
                        {
                            client.Port = ftpSettings.Port;

                            // --- FTPS configuration ---
                            client.Config.EncryptionMode = (ftpSettings.Port == 990)
                                ? FtpEncryptionMode.Implicit
                                : FtpEncryptionMode.Explicit;

                            client.Config.DataConnectionType = FtpDataConnectionType.PASV;
                            //client.Config.ValidateAnyCertificate = true; // TODO: replace with proper cert validation
                            //client.Config.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                            client.ValidateCertificate += (control, e) => { e.Accept = true; };
                            client.Connect();
                        }
                        catch
                        {
                            ftpErrorMessage = "Unable to connect to FTPS server.";
                        }

                        if (string.IsNullOrEmpty(ftpErrorMessage))
                        {
                            client.Config.ConnectTimeout = 15000;    // 15 sec connect timeout
                            client.Config.ReadTimeout = 15000;       // 15 sec read timeout
                            client.Config.DataConnectionConnectTimeout = 15000;  // time to establish data connection
                            client.Config.DataConnectionReadTimeout = 600000;    // time to wait for data during transfer (10 min)


                            if (!File.Exists(localFilePath))
                            {
                                ftpErrorMessage = "File not found.";
                            }
                            else
                            {
                                try
                                {
                                    client.UploadFile(localFilePath, remotePath, FtpRemoteExists.Overwrite, true);

                                    ftpStatus = "Success";
                                    processSuccessful = true;
                                }
                                catch(Exception ex)
                                {
                                    ftpErrorMessage = "Unable to upload (write) file to FTPS server.";
                                }
                            }
                        }
                    }
                    catch
                    {
                        ftpErrorMessage = "Unexpected error during FTPS process.";
                    }
                    finally
                    {
                        SettingsBasePage.SaveFtpLogs(CompanyID, PriceCatalogueID, EstimateItemID, TimeStamp,
                                                     ftpStatus, folder, fileName, ftpErrorMessage);

                        EstimateBasePage.SaveEstimateItemFTPAddress(CompanyID, EstimateItemID, ftpSettings.FtpAddress,
                                                                   processSuccessful ? "Successful" : "Fail", FTPSource);

                        _common.SendFTPEmails(CompanyID, PriceCatalogueID, EstimateItemID,
                                              processSuccessful ? "FTP Success Emails" : "FTP Failure Emails", fileName);

                        if (client.IsConnected)
                            client.Disconnect();
                    }
                }
            }
        }
        public static string ReplaceFtpTagsFromProc(string input, int companyId, long priceCatalogueId, long estimateItemId, string selectedFtpFolder)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Replace system tags
            input = input.Replace("{Date}", DateTime.Now.ToString("dd.MM.yy"));
            input = input.Replace("{Time}", DateTime.Now.ToString("HH.mm.ss"));
            input = input.Replace("{SelectedFTPFolder}", selectedFtpFolder ?? string.Empty);

            var conn = new SqlConnection((new commonClass()).strConnection);
            using (var cmd = new SqlCommand("GetFtpPrefixTags", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompanyID", companyId);
                cmd.Parameters.AddWithValue("@PriceCatalogueID", priceCatalogueId);
                cmd.Parameters.AddWithValue("@EstimateItemID", estimateItemId);

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Replace available tags from DB result
                        input = input.Replace("{EstimateNumber}", reader["EstimateNumber"]?.ToString() ?? "");
                        input = input.Replace("{OrderNumber}", reader["OrderNumber"]?.ToString() ?? "");
                        input = input.Replace("{JobNumber}", reader["JobNumber"]?.ToString() ?? "");
                        input = input.Replace("{Quantity}", reader["Quantity"]?.ToString() ?? "");

                        string storeName = reader["CompanyName"]?.ToString() ?? "";
                        storeName = storeName.Replace(' ', '.');
                        input = input.Replace("{StoreName}", storeName);
                    }
                }
            }

            return input;
        }
        public static string CopyPrintReadyFile(string secureDocPath, string serverName, int companyId, string printReadyFileName, string destinationFolderName)
        {
            string basePath = Path.Combine(secureDocPath, serverName, companyId.ToString());
            string printReadyFilePath = Path.Combine(basePath, "Product", "PrintReady", printReadyFileName);

            // Ensure base directory exists
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            if (File.Exists(printReadyFilePath))
            {
                string destinationPath = Path.Combine(basePath, destinationFolderName);

                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                string destinationFilePath = Path.Combine(destinationPath, printReadyFileName);
                File.Copy(printReadyFilePath, destinationFilePath, true);
            }
            return printReadyFilePath;
        }

        public static void UploadPrintReadyFileToSftp(int companyId, string priceCatalogueId, string filePath, string expectedActionName, string sectionName, long EstimateItemID)
        {
            var routeSettings = SettingsBasePage.LoadFtpRouteSettings(companyId);
            var product = routeSettings.FirstOrDefault(s => s.SectionName == sectionName);

            if (product?.ActionName == expectedActionName)
            {
                DataTable catalogueData = WebstoreBasePage.Settings_Product_Catalogue_Select(companyId, Convert.ToInt32(priceCatalogueId));
                if (catalogueData != null && catalogueData.Rows.Count > 0)
                {
                    string ftpFolderId = catalogueData.Rows[0]["FTPFolderID"]?.ToString();
                    string prefix = catalogueData.Rows[0]["Prefix"]?.ToString();
                    string ftpFolderName = catalogueData.Rows[0]["FolderName"]?.ToString();

                    if (!string.IsNullOrEmpty(ftpFolderId) && ftpFolderId != "0")
                    {
                        FtpSettingsModel ftpSettings = commonClass.GetFtpSettingsIfConfigured(companyId, Convert.ToInt32(priceCatalogueId));
                        if (ftpSettings != null)
                        {
                            commonClass.UploadFileToSftp(ftpSettings, filePath, ftpFolderName, prefix, companyId, Convert.ToInt64(priceCatalogueId), expectedActionName, EstimateItemID);
                        }
                    }
                }
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public void InsertFtpFieldByModule(string ModuleName)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_AddFtpFieldByModule", this.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Module", ModuleName);
            sqlCommand.ExecuteNonQuery();
            this.closeConnection();
        }
        public static DataTable GetAttachmentByEstimateItemID(long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_GetAttachmentByEstimateItemID", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@EstimateItemID", @EstimateItemID);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                dataTable.Load(sqlDataReader);
            }
            _commonClass.closeConnection();
            return dataTable;
        }
        public static DataTable Get_ProductFileByType(long PriceCatalogueID,long CompanyID)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_SelectProductFileByType", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@PriceCatalogueID", PriceCatalogueID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                dataTable.Load(sqlDataReader);
            }
            _commonClass.closeConnection();
            return dataTable;
        }
        public string setDateAfterAddedDay(int CompanyID, string DateType)
        {
            string date = string.Empty;
            DataTable dt = SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID);
            string DateFormat = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_regionalsettings_select(CompanyID).Rows)
            {
                DateFormat = row["DateFormat"].ToString();
            }
            int NoOfDaysAddedForCompletion = 0;
            int NoOfDaysAddedForArtwork = 0;
            int NoOfDaysAddedForDelivery = 0;
            int NoOfDaysAddedForProof = 0;
            int NoOfDaysAddedForApproval = 0;
            int NoOfDaysAddedForProduction = 0;

            if (DateType == "ArtworkDate")
            {
                NoOfDaysAddedForArtwork = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedArtwork"]);
            }
            if (DateType == "DeliveryDate")
            {
                NoOfDaysAddedForDelivery = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedDelivery"]);
            }
            if (DateType == "CompletionDate")
            {
                NoOfDaysAddedForCompletion = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedCompletion"]);
            }
            if (DateType == "ProofDate")
            {
                NoOfDaysAddedForProof = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProof"]);
            }
            if (DateType == "ApprovalDate")
            {
                NoOfDaysAddedForApproval = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedApproval"]);
            }
            if (DateType == "ProductionDate")
            {
                NoOfDaysAddedForProduction = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProduction"]);
            }
            int WorkingDaysFrom = Convert.ToInt32(dt.Rows[0]["WorkingDaysFrom"]);
            int WorkingDaysTo = Convert.ToInt32(dt.Rows[0]["WorkingDaysTo"]);

            var myList = new List<KeyValuePair<string, int>>();
            myList.Add(new KeyValuePair<string, int>("Sunday", 1));
            myList.Add(new KeyValuePair<string, int>("Monday", 2));
            myList.Add(new KeyValuePair<string, int>("Tuesday", 3));
            myList.Add(new KeyValuePair<string, int>("Wednesday", 4));
            myList.Add(new KeyValuePair<string, int>("Thursday", 5));
            myList.Add(new KeyValuePair<string, int>("Friday", 6));
            myList.Add(new KeyValuePair<string, int>("Saturday", 7));

            List<string> lst = new List<string>();

            if (WorkingDaysFrom < WorkingDaysTo)
            {
                for (int i = WorkingDaysFrom; i <= WorkingDaysTo; i++)
                {
                    foreach (var val in myList)
                    {
                        if (val.Value == i)
                        {
                            if (lst.Contains(val.Key) == false)
                                lst.Add(val.Key);
                        }
                    }
                }
            }
            else if (WorkingDaysFrom > WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (val.Value < WorkingDaysFrom && val.Value > WorkingDaysTo)
                    {

                    }
                    else
                    {
                        if (lst.Contains(val.Key) == false)
                            lst.Add(val.Key);
                    }
                }
            }
            else if (WorkingDaysFrom == WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (lst.Contains(val.Key) == false)
                        lst.Add(val.Key);
                }
            }

            if (Boolean.Parse(dt.Rows[0]["IsDefaultCompletion"].ToString()) == true && DateType == "CompletionDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForCompletion, lst, DateFormat).ToString());
            }
            else if (Boolean.Parse(dt.Rows[0]["IsDefaultArtwork"].ToString()) == true && DateType == "ArtworkDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForArtwork, lst, DateFormat).ToString());
            }
            else if (Boolean.Parse(dt.Rows[0]["IsDefaultDelivery"].ToString()) == true && DateType == "DeliveryDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForDelivery, lst, DateFormat).ToString());
            }
            else if (Boolean.Parse(dt.Rows[0]["IsDefaultProof"].ToString()) == true && DateType == "ProofDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForProof, lst, DateFormat).ToString());
            }
            else if (Boolean.Parse(dt.Rows[0]["IsDefaultApproval"].ToString()) == true && DateType == "ApprovalDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForApproval, lst, DateFormat).ToString());
            }
            else if (Boolean.Parse(dt.Rows[0]["IsDefaultProduction"].ToString()) == true && DateType == "ProductionDate")
            {
                date = eprint_checkdateformat_returnonlymmddyyyy(DateFormat, AddDaysToDate(NoOfDaysAddedForProduction, lst, DateFormat).ToString());
            }
            else
            {
                date = "1/1/1900";
            }
            return date;
        }
        public DateTime AddDaysToDate(int NoOfDaysToBeAdded, List<string> lst, string DateFormat)
        {
            int count = 0;
            DateTime dt = new DateTime();
            string dateFormat = DateFormat.Replace("mm", "MM");
            dt = Convert.ToDateTime(eprint_checkdateformat_returnonlymmddyyyy(DateFormat, DateTime.Now.ToString(dateFormat)));
            while (count < NoOfDaysToBeAdded)
            {
                dt = dt.AddDays(1);
                string day = dt.DayOfWeek.ToString();
                if (lst.Contains(day))
                {
                    count = count + 1;
                }
            }
            return dt;
        }
    }
}