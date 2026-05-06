using ePrint.WebStore;
using nmsConnection;
using Printcenter.BusinessAccessLayer.Orders;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using ShipEngine.ApiClient.Api;
using ShipEngine.ApiClient.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Renci.SshNet;
using FluentFTP;

namespace nmsCommon
{
    public class commonclass
    {
        public SqlConnection conn;

        public string connectionStringName = "CRMConnectionString";

        public string strConnection;

        private string _UniqueID = string.Empty;

        private static byte[] bytes;

        public string UniqueID
        {
            get
            {
                HttpSessionState session = HttpContext.Current.Session;
                if (session["UniqueID"] != null)
                {
                    this._UniqueID = session.SessionID.ToString();
                }
                return this._UniqueID;
            }
        }

        static commonclass()
        {
            commonclass.bytes = Encoding.ASCII.GetBytes("ZeroCool");
        }

        public commonclass()
        {
            try
            {
                this.strConnection = EprintConfigurationManager.ConnectionStrings[this.connectionStringName].ToString();
            }
            catch
            {
            }
            this.conn = new SqlConnection(this.strConnection);
        }

        public void closeConnection()
        {
            this.conn.Close();
        }

        public string date_Check_new(string DateFormat, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (DateFormat == "mm/dd/yyyy")
                {
                    if (DateFormat == "dd/mm/yyyy")
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
                if (DateFormat == "dd/mm/yyyy")
                {
                    if (DateFormat == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormat == "mm/dd/yyyy")
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

        public static string Decrypt(string cryptedString)
        {
            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(commonclass.bytes, commonclass.bytes), CryptoStreamMode.Read);
            return (new StreamReader(cryptoStream)).ReadToEnd();
        }

        public static string Encrypt(string originalString)
        {
            if (string.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(commonclass.bytes, commonclass.bytes), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(originalString);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
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

        public DateTime Eprint_return_ActualDate_Before_View(string strDate, int companyID, int userID, bool IsSystemGenerated)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            DateTime dateTime = DateTime.Parse(strDate);
            if (HttpContext.Current.Session["ERD_timezonekey"] == null || HttpContext.Current.Session["ERD_dateformat"] == null)
            {
                commonclass _commonclass = new commonclass();
                SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                    HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                }
                _commonclass.closeConnection();
            }
            if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
            {
                if (IsSystemGenerated)
                {
                    dateTime = Convert.ToDateTime(commonclass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
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
                        commonclass _commonclass = new commonclass();
                        SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonclass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                        sqlCommand.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                            HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                        }
                        _commonclass.closeConnection();
                    }
                    if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
                    {
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(commonclass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
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
            //goto Label2;
            return "";
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
                        commonclass _commonclass = new commonclass();
                        SqlCommand sqlCommand = new SqlCommand("PC_Eprint_return_Date_Before_View", _commonclass.openConnection())
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
                        sqlCommand.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            HttpContext.Current.Session["ERD_timezonekey"] = sqlDataReader["timezonekey"].ToString();
                            HttpContext.Current.Session["ERD_dateformat"] = sqlDataReader["dateformat"].ToString().ToUpper();
                        }
                        _commonclass.closeConnection();
                    }
                    if (HttpContext.Current.Session["ERD_timezonekey"] != null && HttpContext.Current.Session["ERD_dateformat"] != null)
                    {
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(commonclass.ReturnCurrentDateTimeByTimeZoneID(dateTime, HttpContext.Current.Session["ERD_timezonekey"].ToString()));
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

        public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView)
        {
            int scale = 0;
            int num = 0;
            DataTable dataTable = ProductBasePage.default_price_for_pack_select(CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    num = Convert.ToInt32(row["Roundoff"].ToString());
                }
            }
            scale = num;
            if (Scale > 0)
            {
                scale = Scale;
            }
            if (IsQuantity && !isAddDecimalPlacesToQty)
            {
                return Math.Round(Amount, 0, MidpointRounding.AwayFromZero).ToString();
            }
            string str = string.Concat("N", scale.ToString());
            decimal num1 = Math.Round(Amount, scale, MidpointRounding.AwayFromZero);
            if (!isView)
            {
                return num1.ToString();
            }
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
            string str1 = string.Concat("{0:", str, "}");
            object[] objArray = new object[] { num1 };
            return string.Format(cultureInfo, str1, objArray);
        }

        public string GetAddressLabelByKey(string AddressKey)
        {
            HttpSessionState session = HttpContext.Current.Session;
            Hashtable hashtables = new Hashtable();
            Hashtable item = new Hashtable();
            if (session["StoreUserID"] == null || session["StoreUserID"] == null)
            {
                commonclass _commonclass = new commonclass();
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_GetAddressLabelByKey", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (session["CompanyID"] == null || session["CompanyID"] == null)
                {
                    sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
                }
                dataTable.Load(sqlCommand.ExecuteReader());
                foreach (DataRow row in dataTable.Rows)
                {
                    hashtables.Add(row["AddresslKey"].ToString().ToLower(), row["AddressValue"].ToString());
                    item.Add(row["AddresslKey"].ToString().ToLower(), row["isRequired"].ToString());
                }
                _commonclass.closeConnection();
            }
            else if (session["ClientAddressLabels"] != null)
            {
                hashtables = (Hashtable)session["ClientAddressLabels"];
                item = (Hashtable)session["ClientAddressMandatory"];
            }
            else
            {
                commonclass _commonclass1 = new commonclass();
                DataTable dataTable1 = new DataTable();
                SqlCommand sqlCommand1 = new SqlCommand("PC_GetAddressLabelByKey", _commonclass1.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (session["CompanyID"] == null || session["CompanyID"] == null)
                {
                    sqlCommand1.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
                }
                else
                {
                    sqlCommand1.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
                }
                dataTable1.Load(sqlCommand1.ExecuteReader());
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    hashtables.Add(dataRow["AddresslKey"].ToString().ToLower(), dataRow["AddressValue"].ToString());
                    item.Add(dataRow["AddresslKey"].ToString().ToLower(), dataRow["isRequired"].ToString());
                }
                session["ClientAddressLabels"] = hashtables;
                session["ClientAddressMandatory"] = item;
                _commonclass1.closeConnection();
            }
            string str = hashtables[AddressKey.ToLower()].ToString();
            if (str.Length == 0)
            {
                AddressKey = string.Concat(char.ToUpper(AddressKey[0]), AddressKey.Substring(1));
                str = AddressKey;
            }
            return str;
        }

        public string GetCurrencyinRequiredFormate(string Amount, bool isSignRequired)
        {
            return string.Concat(ConnectionClass.CurrencySymbol, Amount);
        }

        public string GetDisplayValue(string tabName, long AccountID)
        {
            DataTable displaySettings;
            HttpSessionState session = HttpContext.Current.Session;
            string empty = string.Empty;
            try
            {
                if (session["StoreUserID"] == null || session["StoreUserID"] == null)
                {
                    displaySettings = CMSBasePage.GetDisplaySettings(AccountID);
                    if (displaySettings.Rows.Count > 0)
                    {
                        empty = (tabName == "CommentsDefaultValue" || tabName == "OrderTitleText" || tabName == "OrderNumberText" || tabName == "DeliveryRequiredByText" || tabName == "CommentsText" || tabName == "OrderTitleValue" || tabName == "OrderNumberValue" || tabName == "OrderInformationHeading" || tabName == "AddressInformationHeading" || tabName == "OrderConfirmationHeading" || tabName == "PaymentInformationHeading" || tabName == "ExampleNoteValue" || tabName == "OrderNumber_HelpText" || tabName == "DelReqBy_HelpText" ? displaySettings.Rows[0][tabName].ToString() : displaySettings.Rows[0][tabName].ToString().ToLower());
                    }
                }
                else if (session["eStoreDisplaySetting"] == null || session["eStoreDisplaySetting"] == null)
                {
                    displaySettings = CMSBasePage.GetDisplaySettings(AccountID);
                    if (displaySettings.Rows.Count > 0)
                    {
                        empty = (tabName == "CommentsDefaultValue" || tabName == "OrderTitleText" || tabName == "OrderNumberText" || tabName == "DeliveryRequiredByText" || tabName == "CommentsText" || tabName == "OrderTitleValue" || tabName == "OrderNumberValue" || tabName == "OrderInformationHeading" || tabName == "AddressInformationHeading" || tabName == "OrderConfirmationHeading" || tabName == "PaymentInformationHeading" || tabName == "ExampleNoteValue" || tabName == "OrderNumber_HelpText" || tabName == "DelReqBy_HelpText" || tabName == "CostCentreText" ? displaySettings.Rows[0][tabName].ToString() : displaySettings.Rows[0][tabName].ToString().ToLower());
                    }
                }
                else
                {
                    displaySettings = (DataTable)session["eStoreDisplaySetting"];
                    if (displaySettings.Rows.Count > 0)
                    {
                        empty = (tabName == "CommentsDefaultValue" || tabName == "OrderTitleText" || tabName == "OrderNumberText" || tabName == "DeliveryRequiredByText" || tabName == "CommentsText" || tabName == "OrderTitleValue" || tabName == "OrderNumberValue" || tabName == "OrderInformationHeading" || tabName == "AddressInformationHeading" || tabName == "OrderConfirmationHeading" || tabName == "PaymentInformationHeading" || tabName == "ExampleNoteValue" || tabName == "OrderNumber_HelpText" || tabName == "DelReqBy_HelpText" || tabName == "CostCentreText" ? displaySettings.Rows[0][tabName].ToString() : displaySettings.Rows[0][tabName].ToString().ToLower());
                    }
                }
            }
            catch
            {
                empty = "true";
            }
            return empty;
        }

        public int GetIsRightBanner(int CompanyID, long AccountID)
        {
            return LoginBasePage.GetIsRightBanner(CompanyID, AccountID);
        }

        public string GetMandatoryByKey(string AddressKey)
        {
            string empty = string.Empty;
            try
            {
                HttpSessionState session = HttpContext.Current.Session;
                Hashtable hashtables = new Hashtable();
                if (session["StoreUserID"] == null || session["StoreUserID"] == null)
                {
                    commonclass _commonclass = new commonclass();
                    DataTable dataTable = new DataTable();
                    SqlCommand sqlCommand = new SqlCommand("PC_GetAddressLabelByKey", _commonclass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (session["CompanyID"] == null || session["CompanyID"] == null)
                    {
                        sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(ConnectionClass.CompanyID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@CompanyID", Convert.ToInt64(session["CompanyID"]));
                    }
                    dataTable.Load(sqlCommand.ExecuteReader());
                    foreach (DataRow row in dataTable.Rows)
                    {
                        hashtables.Add(row["AddresslKey"].ToString().ToLower(), row["isRequired"].ToString());
                    }
                    _commonclass.closeConnection();
                }
                else
                {
                    hashtables = (Hashtable)session["ClientAddressMandatory"];
                }
                empty = hashtables[AddressKey.ToLower()].ToString();
            }
            catch
            {
            }
            return empty;
        }

        public bool IsPrivate_SystemName()
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            long num1 = (long)0;
            bool flag = false;
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                num = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                num1 = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SystemName != null)
            {
                empty = ConnectionClass.SystemName.ToString().ToLower().Trim();
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)num, num1).Rows)
            {
                str = row["accountType"].ToString().ToLower().Trim();
            }
            if (empty == "ppw" && str == "p")
            {
                flag = true;
            }
            return flag;
        }

        public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type)
        {
            if (Type == "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
                return;
            }
            ddlMutiple.DataSource = dtMul;
            ddlMutiple.DataTextField = "Label";
            ddlMutiple.DataValueField = "FormulaNew";
            ddlMutiple.DataBind();
            plhPriceCalculator.Controls.Add(ddlMutiple);
        }

        public void MultipleChoice_DropDownBind_Edit(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type, string ddlText)
        {
            if (Type == "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                (new BaseClass()).SetDDLText(ddlMutiple, ddlText);
                plhPriceCalculator.Controls.Add(ddlMutiple);
                return;
            }
            ddlMutiple.DataSource = dtMul;
            ddlMutiple.DataTextField = "Label";
            ddlMutiple.DataValueField = "FormulaNew";
            ddlMutiple.DataBind();
            (new BaseClass()).SetDDLText(ddlMutiple, ddlText);
            plhPriceCalculator.Controls.Add(ddlMutiple);
        }

        public SqlConnection openConnection()
        {
            this.conn.Open();
            return this.conn;
        }

        public static string pageTitle(string title, int companyID, int AccountID)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)companyID, (long)AccountID).Rows)
            {
                empty = baseClass.SpecialDecode(row["accountName"].ToString());
            }
            if (empty == "")
            {
                empty = "ePrint Software";
            }
            return string.Concat(empty, ": ", title);
        }

        public string ReplaceAllBlankSpace(string OriginalString)
        {
            return OriginalString.Replace(" ", "_");
        }

        public string return_AccountID(string WebAccountType)
        {
            string empty = string.Empty;
            if (WebAccountType.ToLower() == "private")
            {
                HttpSessionState session = HttpContext.Current.Session;
                empty = (session["AccountID"] == null || session["AccountID"] == null ? "0" : session["AccountID"].ToString());
            }
            return empty;
        }

        public string return_AccountType(long CompanyID, long AccountID)
        {
            string empty = string.Empty;
            foreach (DataRow row in LoginBasePage.Select_AccountDetails(CompanyID, AccountID).Rows)
            {
                empty = row["accountType"].ToString();
            }
            return empty;
        }

        public string return_CompanyID(string WebAccountType)
        {
            HttpSessionState session = HttpContext.Current.Session;
            string str = "0";
            if (WebAccountType.ToLower() != "private")
            {
                if (WebAccountType.ToLower() == "public")
                {
                    DataTable dataTable = LoginBasePage.Select_AccountDetails((long)0, Convert.ToInt64(ConnectionClass.AccountID));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        str = row["CompanyID"].ToString();
                    }
                    str = str.ToString();
                }
            }
            else if (session["StoreUserID"] != null && session["StoreUserID"] != null)
            {
                DataTable dataTable1 = LoginBasePage.StoreUser_select(Convert.ToInt64(session["StoreUserID"]));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    str = dataRow["CompanyID"].ToString();
                }
            }
            else if (session["AccountID"] == null || session["AccountID"] == null)
            {
                str = "0";
            }
            else
            {
                DataTable companyIDByAccountID = LoginBasePage.GetCompanyIDByAccountID(Convert.ToInt64(session["AccountID"]));
                foreach (DataRow row1 in companyIDByAccountID.Rows)
                {
                    str = row1["CompanyID"].ToString();
                }
            }
            session["CompanyID"] = str;
            return str;
        }

        public static string ReturnCurrentDateTimeByTimeZoneID(DateTime dt, string TimeZoneID)
        {
            DateTime dateTime = dt;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID);
            DateTime dateTime1 = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, timeZoneInfo);
            return dateTime1.ToString();
        }

        public decimal ReturnExact2Decimal(decimal Amount)
        {
            Amount = Amount * new decimal(100);
            string[] strArrays = Amount.ToString().Split(new char[] { '.' });
            decimal num = new decimal(0);
            num = Convert.ToDecimal(strArrays[0]);
            Amount = num / new decimal(100);
            return Amount;
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

        public int DeliveryCost(string val)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var apiKey = "TEST_ZGn5dvAvosGMcTQzhWspvMR+EtGyqei/7303CSei+OU";

            var carriersApi = new CarriersApi();
            var carrier = carriersApi.CarriersGet(val, apiKey);
            var shipment = new AddressValidatingShipment
            {
                Confirmation = AddressValidatingShipment.ConfirmationEnum.None,
                CarrierId = null,
                ServiceCode = null,

                Packages = new List<ShipmentPackage>
                {
                    new ShipmentPackage
                    {
                        Weight = new Weight(8, Weight.UnitEnum.Ounce),
                        Dimensions = new Dimensions(Dimensions.UnitEnum.Inch, 5, 5, 5)
                    }
                }
            };
            shipment.ShipFrom = new AddressDTO("John Doe", "5551234567", "Acme Corp.", "100 Main St.", null, null, "Austin", "TX", "78610", "US");

            shipment.ShipTo = new AddressDTO("John Doe", "5551234567", "Acme Corp.", "100 Main St.", null, null, "Houston", "TX", "77002", "US");

            var rate = ChooseRate(shipment, carrier, apiKey);
            return Convert.ToInt32(rate.ShippingAmount.Amount);
        }

        static Rate ChooseRate(AddressValidatingShipment shipment, Carrier carrier, string apiKey)
        {
            var selectedRate = new Rate();
            var ratesApi = new RatesApi();
            var rateShipmentRequest = new RateShipmentRequest(shipment: shipment, rateOptions: new RateRequest(new List<string> { carrier.CarrierId }));
            var rates = ratesApi.RatesRateShipment(rateShipmentRequest, apiKey).RateResponse.Rates;

            for (var i = 0; i < rates.Count; i++)
            {
                selectedRate = rates[0];
            }

            return selectedRate;
        }

        public string ReplaceSplSymbol(string inputstring)
        {
            string empty = string.Empty;
            return (new Regex("[;\\\\/:*?\"<>|&'@#+^!%~`$,\\s]")).Replace(inputstring, "_");
        }

        public static bool CheckFTPEnable()
        {
            DataTable _item = EprintConfigurationManager.GetAppSettings();
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
            var settings = Orders.GetFtpSettings(companyId);
            if (settings != null)
            {
                return new FtpSettingsModel
                {
                    FtpAddress = settings.FtpAddress,
                    Username = settings.Username,
                    Port = settings.Port,
                    EncryptedPassword = commonclass.Decrypt(settings.EncryptedPassword),
                    RootFolder = settings.RootFolder,
                    FileTransferProtocol = settings.FileTransferProtocol
                };
            }
            return null;
        }

        public static void UploadFileToSftp(FtpSettingsModel ftpSettings, string localFilePath, string folder, string prefix, int CompanyID, long PriceCatalogueID, string expectedActionName, long EstimateItemID)
        {
            string FTPSource = string.Empty;
            if (expectedActionName.ToLower().Contains("job"))
            {
                FTPSource = "jobs";
            }
            else if (expectedActionName.ToLower().Contains("order"))
            {
                FTPSource = "order";
            }
            else if (expectedActionName.ToLower().Contains("invoice"))
            {
                FTPSource = "invoice";
            }
            var prefixSettings = Orders.GetFtpPrefixSettings(CompanyID);
            DataTable dataTable6 = commonclass.Get_ProductFileByType(PriceCatalogueID, CompanyID);
            string fileName = Path.GetFileName(localFilePath);
            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
            {
                fileName = dataTable6.Rows[0]["FileName"].ToString();
            }
            //string prefixedFileName = (prefix ?? "") + fileName;
            string finalFileName = fileName;
            string prefixAfterReplacingTags = commonclass.ReplaceFtpTagsFromProc(prefix, CompanyID, PriceCatalogueID, EstimateItemID, folder);
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
            folder = folder != null ? folder.TrimEnd('/') : "";
            string remotePath = string.Format("/{0}/{1}/{2}",ftpSettings.RootFolder, folder, finalFileName).Replace("//", "/");
            commonclass _common = new commonclass();
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
                        Orders.SaveFtpLogs(CompanyID, PriceCatalogueID, EstimateItemID, TimeStamp, ftpStatus, folder, fileName, ftpErrorMessage);
                        Orders.SaveEstimateItemFTPAddress(CompanyID, EstimateItemID, ftpSettings.FtpAddress, processSuccessful ? "Successful" : "Fail", FTPSource);
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
                                catch (Exception ex)
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
                        Orders.SaveFtpLogs(CompanyID, PriceCatalogueID, EstimateItemID, TimeStamp,
                                                     ftpStatus, folder, fileName, ftpErrorMessage);

                        Orders.SaveEstimateItemFTPAddress(CompanyID, EstimateItemID, ftpSettings.FtpAddress,
                                                                   processSuccessful ? "Successful" : "Fail", FTPSource);

                        _common.SendFTPEmails(CompanyID, PriceCatalogueID, EstimateItemID,
                                              processSuccessful ? "FTP Success Emails" : "FTP Failure Emails", fileName);

                        if (client.IsConnected)
                            client.Disconnect();
                    }
                }
            }

        }
        public void SendFTPEmails(int companyID, long ProductCatalogueID, long EstimateItemID, string TemplateType, string PrintFile)
        {
            bool flag = false;
            bool flag1 = false;
            DataTable dataTable = new DataTable();
            int num = 0;
            int num1 = 0;
            int num3 = 0;
            dataTable = Orders.GetFTPEmailTemplate(companyID, TemplateType);
            bool flag2 = false;
            foreach (DataRow dataRow1 in dataTable.Rows)
            {
                //flag = Convert.ToBoolean(dataRow1["ISEnabled"]);
                if (dataRow1["IsFromWebStore"].ToString().ToLower() != "no")
                {
                    flag2 = true;
                }
                num3 = Convert.ToInt32(EstimateItemID);
                DataTable dataTable1 = Orders.GetFTPEmailTags(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID, EstimateItemID);


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
                dataTable2 = Orders.Jobs_EmailStatus_select(Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), 0, (long)num3);
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
                str = this.ReplaceFTPEmailTags(dataTable1, dataRow1["EmailTo"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID, PrintFile);
                empty2 = this.ReplaceFTPEmailTags(dataTable1, dataRow1["Subject"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID, PrintFile);
                str2 = this.ReplaceFTPEmailTags(dataTable1, dataRow1["Body"].ToString(), Convert.ToInt32(dataTable.Rows[0]["CompanyID"].ToString()), ProductCatalogueID, PrintFile);
                str2 = string.Concat(str2, " ", dataRow1["FooterText"].ToString());
                nmsEmail.EmailClass.SendMailMessage(empty, str, empty1, str1, empty2, str2, empty3, true);
            }
        }
        private string ReplaceFTPEmailTags(DataTable dt, string body, int CompanyID, long ProductCatalogueID, string PrintFile)
        {
            commonclass _commonClass = new commonclass();
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
                    string sitePath = ConnectionClass.SitePath;
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
        public static DataTable Get_ProductFileByType(long PriceCatalogueID, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            commonclass _commonClass = new commonclass();
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
        public static DataTable GetAttachmentByEstimateItemID(long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            commonclass _commonClass = new commonclass();
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
        public static void UploadPrintReadyFileToSftp(int companyId, string priceCatalogueId, string filePath, string expectedActionName, string sectionName, long EstimateItemID)
        {
            var routeSettings = Orders.LoadFtpRouteSettings(companyId);
            object product = null;

            foreach (var s in routeSettings)
            {
                var section = s.GetType().GetProperty("SectionName").GetValue(s, null) as string;
                if (section == sectionName)
                {
                    product = s;
                    break;
                }
            }

            if (product != null)
            {
                var actionName = product.GetType().GetProperty("ActionName").GetValue(product, null) as string;
                if (actionName == expectedActionName)
                {
                    DataTable catalogueData = Orders.Settings_Product_Catalogue_Select(companyId, Convert.ToInt32(priceCatalogueId));
                    if (catalogueData != null && catalogueData.Rows.Count > 0)
                    {
                        string ftpFolderId = catalogueData.Rows[0]["FTPFolderID"] != DBNull.Value ? catalogueData.Rows[0]["FTPFolderID"].ToString() : null;
                        string prefix = catalogueData.Rows[0]["Prefix"] != DBNull.Value ? catalogueData.Rows[0]["Prefix"].ToString() : null;
                        string ftpFolderName = catalogueData.Rows[0]["FolderName"] != DBNull.Value ? catalogueData.Rows[0]["FolderName"].ToString() : null;

                        if (!string.IsNullOrEmpty(ftpFolderId) && ftpFolderId != "0")
                        {
                            FtpSettingsModel ftpSettings = commonclass.GetFtpSettingsIfConfigured(companyId, Convert.ToInt32(priceCatalogueId));
                            if (ftpSettings != null)
                            {
                                commonclass.UploadFileToSftp(ftpSettings, filePath, ftpFolderName, prefix, companyId, Convert.ToInt64(priceCatalogueId), expectedActionName, EstimateItemID);
                            }
                        }
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

            var conn = new SqlConnection((new commonclass()).strConnection);
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
                        input = input.Replace("{EstimateNumber}", reader["EstimateNumber"] != DBNull.Value ? reader["EstimateNumber"].ToString() : "");
                        input = input.Replace("{OrderNumber}", reader["OrderNumber"] != DBNull.Value ? reader["OrderNumber"].ToString() : "");
                        input = input.Replace("{JobNumber}", reader["JobNumber"] != DBNull.Value ? reader["JobNumber"].ToString() : "");
                        input = input.Replace("{Quantity}", reader["Quantity"] != DBNull.Value ? reader["Quantity"].ToString() : "");

                        string storeName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : "";
                        storeName = storeName.Replace(' ', '.');
                        input = input.Replace("{StoreName}", storeName);
                    }
                }
            }

            return input;
        }

    }
}