using com.eprintsoftware.www;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace nmsEmail
{
    public class storeEmail
    {
        private commonclass comm = new commonclass();

        public static string order_No;

        public static string Pdf_File;

        public static string storeName;

        public static string StoreNameB2bRegistration;

        public static string donotreplay;

        public string RequiredBy = string.Empty;

        public string Comments = string.Empty;

        public string TagBody = string.Empty;

        public string orderDate = string.Empty;

        public string orderLink = string.Empty;

        public string eprintDocument = string.Empty;

        public string EmailEnable = string.Empty;

        public string productDetails = string.Empty;

        public string additionalProductDetails = string.Empty;

        public string emailFrom = string.Empty;

        public string emailTo = string.Empty;

        public string emailBCC = string.Empty;

        public string emailCC = string.Empty;

        public string emailSubject = string.Empty;

        public string emailBody = string.Empty;

        public string emailAttachment = string.Empty;

        public string email_return_body = string.Empty;

        public string customerName = string.Empty;

        public string FirstName = string.Empty;

        public string LastName = string.Empty;

        public string MiddleName = string.Empty;

        public string Department = string.Empty;

        public string EmailID = string.Empty;

        public string Pwd = string.Empty;

        public string AccountName = string.Empty;

        public string loginLink = string.Empty;

        public string RejectedReason = string.Empty;

        public string strSitepath = string.Empty;

        public string OrderedByName = string.Empty;

        public string OrderedForName = string.Empty;

        public long EmailToCustomerID;

        public string Cart_AdditionalOptionName = string.Empty;

        public string Cart_AdditionalOptionValue = string.Empty;

        public string Cart_AdditionalOption = string.Empty;

        public string StoreURL = string.Empty;

        public string FileExtention = string.Empty;

        public string OrderKey = string.Empty;

        public int Company_ID;

        public int Account_ID;

        public int StoreUser_ID;

        public int UserID;

        public int Approver_ID;

        public int PriceCatalogueID;

        public int CartItemID;

        public string Approver_Type = string.Empty;

        private decimal SUB_TOTAL;

        private decimal TAX_DETAILS;

        private decimal TOTAL;

        private decimal TAXD;

        public decimal Cart_Additional_OV;

        public bool IsArtwork;

        public bool IsActive;

        public string SecureDocPath = ConnectionClass.SecureDocPath;

        public string SecureDocFilePath = ConnectionClass.SecureDocFilepath;

        public string SecureSitePath = ConnectionClass.SecureSitePath;

        public string ServerName = ConnectionClass.ServerName;

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public string AdditionalOption = string.Empty;

        public string jobScreenName = "Job Name";

        public string DeptScreenName = string.Empty;

        static storeEmail()
        {
            storeEmail.order_No = string.Empty;
            storeEmail.Pdf_File = string.Empty;
            storeEmail.storeName = string.Empty;
            storeEmail.donotreplay = "donotreply@eprintsoftware.com";
        }

        public storeEmail()
        {
        }

        public virtual DataTable accounts_getAccountDetails(int accountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getAccountDetails");
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void B2BProfileApprovalDetails_Email(long StoreUserID, int CompanyID, long AccountID, string TagEvent, string EmailFor, long ApproverID, string ToEmail)
        {
            string sitePath = ConnectionClass.SitePath;
            DataTable dataTable = new DataTable();
            this.Company_ID = CompanyID;
            this.Account_ID = Convert.ToInt32(AccountID);
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            storeEmail.storeName = this.AccountName;
            this.Approver_ID = Convert.ToInt32(ApproverID);
            this.TagBody = "";
            DataTable customerSelect = this.EmailToCustomer_Select(this.Company_ID, this.Account_ID, (long)0, TagEvent, EmailFor);
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                this.TagBody = row["Body"].ToString();
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.FirstName = dataRow["FirstName"].ToString();
                this.LastName = dataRow["Lastname"].ToString();
                this.EmailID = dataRow["EmailID"].ToString();
                this.Pwd = dataRow["Password"].ToString();
                string str = dataRow["RejectedReason"].ToString();
                string str1 = str;
                this.Pwd = str;
                this.RejectedReason = str1;
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, TagEvent, EmailFor);
                storeEmail.SendMailMessage(this.emailFrom, ToEmail, this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void B2BRegisterDetails_Email(long StoreUserID, int CompanyID, long AccountID, string TagEvent, string EmailFor, long ApproverID, string ToEmail)
        {
            string sitePath = ConnectionClass.SitePath;
            DataTable dataTable = new DataTable();
            this.Company_ID = CompanyID;
            this.Account_ID = Convert.ToInt32(AccountID);
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            storeEmail.storeName = this.AccountName;
            this.Approver_ID = Convert.ToInt32(ApproverID);
            this.TagBody = "";
            DataTable customerSelect = this.EmailToCustomer_Select(this.Company_ID, this.Account_ID, (long)0, TagEvent, EmailFor);
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                this.TagBody = row["Body"].ToString();
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.FirstName = dataRow["FirstName"].ToString();
                this.LastName = dataRow["Lastname"].ToString();
                this.EmailID = dataRow["Email"].ToString();
                this.Pwd = dataRow["Password"].ToString();
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, TagEvent, EmailFor);
                storeEmail.SendMailMessage(this.emailFrom, ToEmail, this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void emailOrdersDetails(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, string emailfor, long ApproverID, string ToEmail, string ApprovalType)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.Approver_Type = ApprovalType;
            this.TagBody = "";
            if (ConnectionClass.FileExtension != null)
            {
                this.eprintDocument = ConnectionClass.eprintDocument;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.EmailEnable = ConnectionClass.EmailEnable;
            }
            if (TagEvent.ToLower().Trim() == "new order")
            {
                emailfor = "Admin";
            }
            else if (TagEvent.ToLower().Trim() != "new b2b order")
            {
                emailfor = "Customer";
            }
            else
            {
                emailfor = "Approver";
            }
            DataTable dataTable = new DataTable();
            dataTable = (TagEvent.ToLower().Trim() == "new b2b order" || TagEvent.ToLower().Trim() == "b2b user order rejection" || TagEvent.ToLower().Trim() == "b2b user order approval" ? this.EmailToCustomer_Select(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, emailfor) : OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, emailfor));
            foreach (DataRow row in dataTable.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable1 = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (TagEvent.ToLower().Trim() != "new b2b order")
                {
                    ToEmail = dataRow["EmailID"].ToString();
                }
                storeEmail.storeName = dataRow["accountName"].ToString();
                if (this.IsArtwork)
                {
                    if (dataRow["UploadFile"].ToString() != "")
                    {
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                    }
                    if (dataRow["UploadFile1"].ToString() != "")
                    {
                        object[] objArray = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile1"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray);
                    }
                    if (dataRow["UploadFile2"].ToString() != "")
                    {
                        object[] secureDocPath1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile2"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath1);
                    }
                    if (dataRow["PrintReadyFile"].ToString().Trim().Length > 0)
                    {
                        object[] objArray1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\", CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray1);
                    }
                    if (dataRow["PDFNameFromCart"].ToString() != "")
                    {
                        if (emailfor != "Admin")
                        {
                            object[] secureDocPath2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(secureDocPath2);
                        }
                        else
                        {
                            object[] objArray2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(objArray2);
                        }
                    }
                }
                if (!(dataRow["PDFNameFromCart"].ToString() != "") || !(emailfor == "Admin"))
                {
                    continue;
                }
                DataTable editableTemplateImageurl = new DataTable();
                editableTemplateImageurl = OrderBasePage.Get_EditableTemplate_Imageurl(this.PriceCatalogueID, this.CartItemID);
                foreach (DataRow row1 in editableTemplateImageurl.Rows)
                {
                    if (!Convert.ToBoolean(row1["IsFromPdf"].ToString()))
                    {
                        if (row1["ImageUrl"].ToString() == "")
                        {
                            continue;
                        }
                        object[] secureDocPath3 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", row1["ImageUrl"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath3);
                    }
                    else
                    {
                        string str = row1["OriginalImageName"].ToString();
                        str = str.Replace(".png", ".pdf").Replace(".PNG", ".pdf");
                        object[] objArray3 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", row1["ImageUrl"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray3);
                        object[] secureDocPath4 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", str, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath4);
                    }
                }
            }
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                if (this.IsActive && TagEvent.ToLower().Trim() != "new order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, TagEvent, emailfor);
                    if (TagEvent.ToLower().Trim() == "thank you for your order" && dataTable.Rows.Count > 0)
                    {
                        this.emailFrom = dataTable.Rows[0]["marketingEmail"].ToString();
                    }
                    storeEmail.SendMailMessage(this.emailFrom.Trim(), ToEmail.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
                this.IsActive = false;
                DataTable customerSelectWebStore = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Admin");
                if (customerSelectWebStore.Rows.Count > 0)
                {
                    this.emailTo = customerSelectWebStore.Rows[0]["AdminTo"].ToString();
                    this.emailCC = customerSelectWebStore.Rows[0]["AdminCc"].ToString();
                    this.emailBCC = customerSelectWebStore.Rows[0]["AdminBcc"].ToString();
                }
                foreach (DataRow dataRow1 in customerSelectWebStore.Rows)
                {
                    this.IsActive = Convert.ToBoolean(dataRow1["IsActive"].ToString());
                }
                if (this.IsActive && TagEvent.ToLower().Trim() == "new order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, "NEWORDER", emailfor);
                    if (ConnectionClass.SystemName.ToLower() == "aviva" && ConnectionClass.NewOrderAdminEmailID != null)
                    {
                    }
                    if (customerSelectWebStore.Rows.Count > 0)
                    {
                        this.emailFrom = customerSelectWebStore.Rows[0]["marketingEmail"].ToString();
                    }
                    storeEmail.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
            }
        }

        public virtual DataTable EmailToCustomer_Select(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailFor)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailToCustomer_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@EmailToCustomerID", DbType.Int64, EmailToCustomerID);
            database.AddInParameter(storedProcCommand, "@TagEvent", DbType.String, TagEvent);
            database.AddInParameter(storedProcCommand, "@EmailFor", DbType.String, EmailFor);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
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
                        EprintService eprintService = new EprintService();
                        if (IsSystemGenerated)
                        {
                            dateTime = Convert.ToDateTime(eprintService.ReturnCurrentDateTimeByTimeZoneID(dateTime, sqlDataReader["timezonekey"].ToString()));
                        }
                        upper = sqlDataReader["dateformat"].ToString().ToUpper();
                    }
                    _commonclass.closeConnection();
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
                    //Label2:
                    //	empty1 = str.ToString();
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
            goto Label2;

        Label2:
            return empty1 = str.ToString();
        }

        public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView)
        {
            int scale = 0;
            int num = 0;
            DataTable dataTable = this.Price_For_Whole_Pack_Select(CompanyID);
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

        public string Eprint_ReturnFinal_Formated_Amount(int CompanyID, int UserID, decimal Amount, int Scale, string CalculationUnit, bool IsQuantity, bool isAddDecimalPlacesToQty, bool isView, bool IsShowCurrencySymbol, bool HideMinusSymbol)
        {
            int scale = 0;
            int num = 0;
            DataTable dataTable = this.Price_For_Whole_Pack_Select(Convert.ToInt32(CompanyID));
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
                if (!HideMinusSymbol)
                {
                    return num1.ToString();
                }
                return num1.ToString().Replace("-", "");
            }
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-es");
            string str1 = string.Concat("{0:", str, "}");
            object[] objArray = new object[] { num1 };
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

        public virtual DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_price_for_pack_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public string ReplaceAllTags(DataTable dtEmail, DataTable dtBody, long OrderID, long StoreUserID, int CompanyID, string Type, string EmailFor)
        {
            string str;
            object[] orderKey;
            string cartAdditionalOptionName;
            string[] currencyinRequiredFormate;
            char[] chrArray;
            string empty = string.Empty;

            BaseClass baseClass = new BaseClass();
            this.DeptScreenName = (new BaseClass()).Return_ApprovalRegistration_Settings("deptscreenname");
            if (ConnectionClass.PublicDocPath != null)
            {
                empty = ConnectionClass.PublicDocPath.ToString();
            }
            empty = empty.Replace("document/", "");
            string imageHandlerPath = ConnectionClass.ImageHandlerPath;
            string sitePath = ConnectionClass.SitePath;
            string empty1 = string.Empty;
            foreach (DataRow row in this.accounts_getAccountDetails(this.Account_ID).Rows)
            {
                this.StoreURL = row["StoreURL"].ToString();
                this.FileExtention = row["FileExtention"].ToString();
                storeEmail.storeName = row["accountName"].ToString();
            }
            foreach (DataRow dataRow in this.Select_OrderItems(OrderID, (long)this.StoreUser_ID).Rows)
            {
                this.OrderKey = dataRow["OrderKey"].ToString();
            }
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            string empty12 = string.Empty;
            string str12 = string.Empty;
            string empty13 = string.Empty;
            string str13 = string.Empty;
            string empty14 = string.Empty;
            string str14 = string.Empty;
            string empty15 = string.Empty;
            string str15 = string.Empty;
            string empty16 = string.Empty;

            string empty222 = string.Empty;
            string str222 = string.Empty;
            string empty223 = string.Empty;
            string str223 = string.Empty;
            string empty224 = string.Empty;
            string str224 = string.Empty;
            string empty225 = string.Empty;

            foreach (DataRow row1 in CartBasePage.eStore_Visibility_Settings_Select(CompanyID, this.Account_ID).Rows)
            {
                this.jobScreenName = baseClass.SpecialDecode(row1["CartJobScreenName"].ToString());
            }
            foreach (DataRow dataRow1 in dtEmail.Rows)
            {
                if (!dtEmail.Columns.Contains("EmailToCustomerID"))
                {
                    continue;
                }
                this.EmailToCustomerID = Convert.ToInt64(dataRow1["EmailToCustomerID"].ToString());
            }
            DataTable dataTable = OrderBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow row2 in OrderBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
                if (row2["IsProductName"].ToString() != "")
                {
                    str10 = (row2["IsProductName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsJobName"].ToString() != "")
                {
                    empty11 = (row2["IsJobName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsQuantity"].ToString() != "")
                {
                    str11 = (row2["IsQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsTotalPrice"].ToString() != "")
                {
                    empty12 = (row2["IsTotalPrice"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsOrderedWidth"].ToString() != "")
                {
                    str12 = (row2["IsOrderedWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsOrderedHeight"].ToString() != "")
                {
                    empty13 = (row2["IsOrderedHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsProductWidth"].ToString() != "")
                {
                    str13 = (row2["IsProductWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsProductHeight"].ToString() != "")
                {
                    empty14 = (row2["IsProductHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsAdditionalOption"].ToString() != "")
                {
                    str14 = (row2["IsAdditionalOption"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsItemCode"].ToString() != "")
                {
                    empty15 = (row2["IsItemCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsCustomerCode"].ToString() != "")
                {
                    str15 = (row2["IsCustomerCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsUnitOfMeasure"].ToString() == "")
                {
                    continue;
                }
                empty16 = (row2["IsUnitOfMeasure"].ToString().ToLower() != "true" ? "false" : "true");

                empty222 = (row2["IsItemDescription"].ToString().ToLower() != "true" ? "false" : "true");
                str222 = (row2["IsWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty223 = (row2["IsCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str223 = (row2["IsOrderedWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty224 = (row2["IsOrderedCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str224 = (row2["IsPerQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                empty225 = (row2["IsDimensions"].ToString().ToLower() != "true" ? "false" : "true");

            }
            if (Type.ToLower().Trim() == "thank you for your order")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                this.TAXD = new decimal(0);
                string str16 = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder1 = new StringBuilder();
                StringBuilder stringBuilder2 = new StringBuilder();
                StringBuilder stringBuilder3 = new StringBuilder();
                StringBuilder stringBuilder4 = new StringBuilder();
                this.TagBody = "";
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    orderKey = new object[] { sitePath, "order.aspx?OrdKey=", this.OrderKey, "&AccountID=", this.Account_ID };
                    this.orderLink = string.Concat(orderKey);
                }
                else
                {
                    orderKey = new object[] { sitePath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(orderKey);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow2 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail = this;
                    cartAdditionalOptionName = _storeEmail.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(dataRow2["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(dataRow2["SelectedValue"].ToString()), "<br />" };
                    _storeEmail.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail1 = this;
                    _storeEmail1.Cart_AdditionalOptionValue = string.Concat(_storeEmail1.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail cartAdditionalOV = this;
                    cartAdditionalOV.Cart_Additional_OV = cartAdditionalOV.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true));
                    storeEmail _storeEmail2 = this;
                    cartAdditionalOptionName = _storeEmail2.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(dataRow2["WebOtherCostName"].ToString()), "- ", dataRow2["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail2.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                }
                foreach (DataRow row3 in dtEmail.Rows)
                {
                    this.emailSubject = row3["Subject"].ToString();
                    this.TagBody = row3["Body"].ToString();
                    DataTable dataTable1 = new DataTable();
                    DataTable dataTable2 = new DataTable();
                    foreach (DataRow dataRow3 in dtBody.Rows)
                    {
                        dataTable1 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(dataRow3["BillingAddressID"]));
                        dataTable2 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(dataRow3["ShippingAddressID"]));
                        storeEmail.storeName = dataRow3["accountName"].ToString();
                        storeEmail.order_No = dataRow3["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow3["CatalogueName"].ToString(), "Ð");
                        if (dataRow3["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, dataRow3["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (dataRow3["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, dataRow3["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow3["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow3["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = baseClass.SpecialDecode(dataRow3["Comments"].ToString());
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        this.OrderedByName = string.Concat(dataRow3["FirstName"].ToString(), " ", dataRow3["LastName"].ToString());
                        if (Convert.ToInt64(dataRow3["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { dataRow3["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", dataRow3["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(dataRow3["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", dataRow3["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(dataRow3["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = dataRow3["Order_Behalf_UserID"].ToString();
                        }
                        int num = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable3 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow3["OrderItemID"]));
                        foreach (DataRow row4 in dataTable3.Rows)
                        {
                            if (row4["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row4["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row4["UserFriendlyName"].ToString()), "<br/>");
                                if (row4["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", baseClass.SpecialDecode(row4["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(row4["Question"].ToString()), ": ", baseClass.SpecialDecode(row4["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num++;
                        }
                        if (num == 0)
                        {
                            str16 = "";
                        }
                        else if (str14 == "true")
                        {
                            str16 = "<tr><td width='150px' valign='top'><b>Additional Items: </b></td>";
                            str16 = string.Concat(str16, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        if (dataRow3["ProductImage"].ToString() == "")
                        {
                            str = "m_no_image_available.jpeg";
                        }
                        else
                        {
                            str = dataRow3["ProductImage"].ToString().Remove(0, 2);
                            str = string.Concat("m_", str);
                        }
                        decimal num1 = Convert.ToDecimal(dataRow3["OrderItemTotalPrice"].ToString());
                        decimal num2 = Convert.ToDecimal(dataRow3["OrderItemTax"].ToString());
                        decimal num3 = num1;
                        decimal num4 = num3 + num2;
                        this.SUB_TOTAL = this.SUB_TOTAL + num1;
                        this.TAX_DETAILS = Convert.ToDecimal(dataRow3["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num3;
                        if (dataRow3["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow3["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (dataRow3["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow3["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (dataRow3["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow3["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (dataRow3["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow3["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (str16 != "")
                        {
                            stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder.Append(str16);
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow3["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num4, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }

                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow3["SoldInPacksof"].ToString(), "</td></tr>"));
                            }


                            if (empty222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow3["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow3["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow3["CBMWeight"]) / Convert.ToDouble(dataRow3["PerQuantity"])) * Convert.ToDouble(dataRow3["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow3["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow3["CBMMeasurement"]) / Convert.ToDouble(dataRow3["PerQuantity"])) * Convert.ToDouble(dataRow3["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow3["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow3["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow3["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }


                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow3["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num4, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }

                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow3["SoldInPacksof"].ToString(), "</td></tr>"));
                            }


                            if (empty222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow3["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow3["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow3["CBMWeight"]) / Convert.ToDouble(dataRow3["PerQuantity"])) * Convert.ToDouble(dataRow3["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow3["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow3["CBMMeasurement"]) / Convert.ToDouble(dataRow3["PerQuantity"])) * Convert.ToDouble(dataRow3["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow3["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow3["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow3["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow3["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }

                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    storeEmail tOTAL = this;
                    tOTAL.TOTAL = tOTAL.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL1 = this;
                    tOTAL1.TOTAL = tOTAL1.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("\r\n", "");
                    this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                    this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                    this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.TagBody = this.TagBody.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                    this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                    this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                    foreach (DataRow dataRow4 in dataTable1.Rows)
                    {
                        str1 = dataRow4["AddressLabel"].ToString();
                        empty2 = dataRow4["AddressLine1"].ToString();
                        str2 = dataRow4["AddressLine2"].ToString();
                        empty3 = dataRow4["Address2"].ToString();
                        str3 = dataRow4["Address3"].ToString();
                        empty4 = dataRow4["Address4"].ToString();
                        str4 = dataRow4["Country"].ToString();
                        empty5 = dataRow4["Phone"].ToString();
                        str5 = dataRow4["Fax"].ToString();
                    }
                    foreach (DataRow row5 in dataTable2.Rows)
                    {
                        empty6 = row5["AddressLabel"].ToString();
                        str6 = row5["AddressLine1"].ToString();
                        empty7 = row5["AddressLine2"].ToString();
                        str7 = row5["Address2"].ToString();
                        empty8 = row5["Address3"].ToString();
                        str8 = row5["Address4"].ToString();
                        empty9 = row5["Country"].ToString();
                        str9 = row5["Phone"].ToString();
                        empty10 = row5["Fax"].ToString();
                    }
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLABEL$]", str1);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE1$]", empty2);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE2$]", str2);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE3$]", empty3);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE4$]", str3);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE5$]", empty4);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSCOUNTRY$]", str4);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSTELEPHONE$]", empty5);
                    this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSFAX$]", str5);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLABEL$]", empty6);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE1$]", str6);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE2$]", empty7);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE3$]", str7);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE4$]", empty8);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE5$]", str8);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSCOUNTRY$]", empty9);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSTELEPHONE$]", str9);
                    this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSFAX$]", empty10);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLABEL$]", str1);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE1$]", empty2);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE2$]", str2);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE3$]", empty3);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE4$]", str3);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE5$]", empty4);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSCOUNTRY$]", str4);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSTELEPHONE$]", empty5);
                    this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSFAX$]", str5);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLABEL$]", empty6);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE1$]", str6);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE2$]", empty7);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE3$]", str7);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE4$]", empty8);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE5$]", str8);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSCOUNTRY$]", empty9);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSTELEPHONE$]", str9);
                    this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSFAX$]", empty10);
                    currencyinRequiredFormate = new string[] { this.comm.GetCurrencyinRequiredFormate("", true) ?? "" };
                    string[] strArrays = this.Cart_AdditionalOptionValue.Split(currencyinRequiredFormate, StringSplitOptions.None);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    for (int i = 0; i <= (int)strArrays.Length - 1; i++)
                    {
                        if (i == 1)
                        {
                            num6 = Convert.ToDecimal(strArrays[1].Remove(strArrays[1].Length - 6, 6));
                        }
                        else if (i == 2)
                        {
                            num7 = Convert.ToDecimal(strArrays[2].Remove(strArrays[2].Length - 6, 6));
                        }
                        else if (i == 3)
                        {
                            num8 = Convert.ToDecimal(strArrays[3].Remove(strArrays[3].Length - 6, 6));
                        }
                        else if (i == 4)
                        {
                            num9 = Convert.ToDecimal(strArrays[4].Remove(strArrays[4].Length - 6, 6));
                        }
                        num5 = ((num6 + num7) + num8) + num9;
                    }
                    foreach (DataRow dataRow5 in dtBody.Rows)
                    {
                        this.TAXD = Convert.ToDecimal(dataRow5["TAX"]);
                        num5 = num5 + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)) + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAXD, 2, "", false, false, true));
                        this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, num5, 2, "", false, false, true))));
                    }
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays1 = empty1.Split(chrArray);
                    string pdfFile = storeEmail.Pdf_File;
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays2 = pdfFile.Split(chrArray);
                    string empty17 = string.Empty;
                    for (int j = 0; j < (int)strArrays2.Length; j++)
                    {
                        if ((int)strArrays1.Length == (int)strArrays2.Length && strArrays1[j].ToString().Trim() != "")
                        {
                            string str17 = strArrays1[j].ToString();
                            chrArray = new char[] { '\u00A7' };
                            string[] strArrays3 = str17.Split(chrArray);
                            empty1 = strArrays3[0].ToString();
                            string str18 = strArrays3[1].ToString();
                            storeEmail.Pdf_File = strArrays2[j].ToString();
                            if (str18 != "et")
                            {
                                orderKey = new object[] { empty17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                                empty17 = string.Concat(orderKey);
                            }
                            else if (EmailFor.ToLower() != "admin")
                            {
                                orderKey = new object[] { empty17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty17 = string.Concat(orderKey);
                            }
                            else
                            {
                                orderKey = new object[] { empty17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty17 = string.Concat(orderKey);
                            }
                        }
                    }
                    storeEmail.Pdf_File = "";
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", baseClass.SpecialDecode(this.Cart_AdditionalOptionName));
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty17);
                    this.TagBody = this.TagBody.Replace("\r\n", "");
                }
            }
            else if (Type.ToLower().Trim() == "neworder")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                string empty18 = string.Empty;
                StringBuilder stringBuilder5 = new StringBuilder();
                StringBuilder stringBuilder6 = new StringBuilder();
                StringBuilder stringBuilder7 = new StringBuilder();
                StringBuilder stringBuilder8 = new StringBuilder();
                StringBuilder stringBuilder9 = new StringBuilder();
                this.TagBody = "";
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    orderKey = new object[] { sitePath, "order.aspx?OrdKey=", this.OrderKey, "&AccountID=", this.Account_ID };
                    this.orderLink = string.Concat(orderKey);
                }
                else
                {
                    orderKey = new object[] { sitePath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(orderKey);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow row6 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail3 = this;
                    cartAdditionalOptionName = _storeEmail3.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(row6["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row6["SelectedValue"].ToString()), "<br />" };
                    _storeEmail3.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail4 = this;
                    _storeEmail4.Cart_AdditionalOptionValue = string.Concat(_storeEmail4.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail5 = this;
                    cartAdditionalOptionName = _storeEmail5.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(row6["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row6["SelectedValue"].ToString()), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail5.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                    storeEmail cartAdditionalOV1 = this;
                    cartAdditionalOV1.Cart_Additional_OV = cartAdditionalOV1.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                DataTable dataTable4 = new DataTable();
                DataTable dataTable5 = new DataTable();
                foreach (DataRow dataRow6 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow6["Subject"].ToString();
                    this.TagBody = dataRow6["Body"].ToString();
                    foreach (DataRow row7 in dtBody.Rows)
                    {
                        dataTable4 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(row7["BillingAddressID"]));
                        dataTable5 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(row7["ShippingAddressID"]));
                        this.AccountName = row7["accountName"].ToString();
                        storeEmail.order_No = row7["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row7["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, row7["CatalogueName"].ToString(), "Ð");
                        if (row7["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, row7["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (row7["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, row7["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row7["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row7["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = row7["Comments"].ToString();
                        this.customerName = string.Concat(row7["FirstName"].ToString(), " ", row7["LastName"].ToString());
                        this.OrderedByName = string.Concat(row7["FirstName"].ToString(), " ", row7["LastName"].ToString());
                        if (Convert.ToInt64(row7["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { row7["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", row7["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(row7["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", row7["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(row7["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = row7["Order_Behalf_UserID"].ToString();
                        }
                        int num10 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable6 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row7["OrderItemID"]));
                        foreach (DataRow dataRow7 in dataTable6.Rows)
                        {
                            if (dataRow7["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow7["UserFriendlyName"].ToString(), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow7["UserFriendlyName"].ToString(), "<br/>");
                                if (dataRow7["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", dataRow7["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", dataRow7["Question"].ToString(), ": ", dataRow7["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num10++;
                        }
                        if (num10 == 0)
                        {
                            empty18 = "";
                        }
                        else if (str14 == "true")
                        {
                            empty18 = "<tr><td width='150px' valign='top'><b>Additional Items: </b></td>";
                            empty18 = string.Concat(empty18, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        decimal num11 = Convert.ToDecimal(row7["OrderItemTotalPrice"].ToString());
                        decimal num12 = Convert.ToDecimal(row7["OrderItemTax"].ToString());
                        decimal num13 = num11;
                        decimal num14 = num13 + num12;
                        this.SUB_TOTAL = this.SUB_TOTAL + num11;
                        this.TAX_DETAILS = Convert.ToDecimal(row7["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num13;
                        if (row7["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row7["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (row7["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row7["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (row7["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row7["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (row7["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row7["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (empty18 != "")
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(row7["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder5.Append(empty18);
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row7["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row7["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num14, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", row7["SoldInPacksof"].ToString(), "</td></tr>"));
                            }


                            if (empty222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row7["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row7["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row7["CBMWeight"]) / Convert.ToDouble(row7["PerQuantity"])) * Convert.ToDouble(row7["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row7["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row7["CBMMeasurement"]) / Convert.ToDouble(row7["PerQuantity"])) * Convert.ToDouble(row7["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row7["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row7["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row7["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }


                            stringBuilder9.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(row7["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row7["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row7["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num14, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", baseClass.SpecialDecode(row7["SoldInPacksof"].ToString()), "</td></tr>"));
                            }


                            if (empty222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row7["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row7["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row7["CBMWeight"]) / Convert.ToDouble(row7["PerQuantity"])) * Convert.ToDouble(row7["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row7["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row7["CBMMeasurement"]) / Convert.ToDouble(row7["PerQuantity"])) * Convert.ToDouble(row7["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row7["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row7["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row7["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row7["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }


                            stringBuilder9.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    storeEmail tOTAL2 = this;
                    tOTAL2.TOTAL = tOTAL2.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL3 = this;
                    tOTAL3.TOTAL = tOTAL3.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
                this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.emailSubject = this.emailSubject.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                chrArray = new char[] { 'Ð' };
                string[] strArrays4 = empty1.Split(chrArray);
                string pdfFile1 = storeEmail.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays5 = pdfFile1.Split(chrArray);
                string empty19 = string.Empty;
                for (int k = 0; k < (int)strArrays5.Length; k++)
                {
                    if ((int)strArrays4.Length == (int)strArrays5.Length && strArrays4[k].ToString().Trim() != "")
                    {
                        string str19 = strArrays4[k].ToString();
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays6 = str19.Split(chrArray);
                        empty1 = strArrays6[0].ToString();
                        string str20 = strArrays6[1].ToString();
                        storeEmail.Pdf_File = strArrays5[k].ToString();
                        if (str20 != "et")
                        {
                            orderKey = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(orderKey);
                        }
                        else if (EmailFor.ToLower() != "admin")
                        {
                            orderKey = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(orderKey);
                        }
                        else
                        {
                            orderKey = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(orderKey);
                        }
                    }
                }
                storeEmail.Pdf_File = "";
                this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder5.ToString());
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty19);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                foreach (DataRow row8 in dataTable4.Rows)
                {
                    str1 = row8["AddressLabel"].ToString();
                    empty2 = row8["AddressLine1"].ToString();
                    str2 = row8["AddressLine2"].ToString();
                    empty3 = row8["Address2"].ToString();
                    str3 = row8["Address3"].ToString();
                    empty4 = row8["Address4"].ToString();
                    str4 = row8["Country"].ToString();
                    empty5 = row8["Phone"].ToString();
                    str5 = row8["Fax"].ToString();
                }
                foreach (DataRow dataRow8 in dataTable5.Rows)
                {
                    empty6 = dataRow8["AddressLabel"].ToString();
                    str6 = dataRow8["AddressLine1"].ToString();
                    empty7 = dataRow8["AddressLine2"].ToString();
                    str7 = dataRow8["Address2"].ToString();
                    empty8 = dataRow8["Address3"].ToString();
                    str8 = dataRow8["Address4"].ToString();
                    empty9 = dataRow8["Country"].ToString();
                    str9 = dataRow8["Phone"].ToString();
                    empty10 = dataRow8["Fax"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLABEL$]", str1);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE1$]", empty2);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE2$]", str2);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE3$]", empty3);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE4$]", str3);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSLINE5$]", empty4);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSCOUNTRY$]", str4);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSTELEPHONE$]", empty5);
                this.emailSubject = this.emailSubject.Replace("[$INVOICE_ADDRESSFAX$]", str5);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLABEL$]", empty6);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE1$]", str6);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE2$]", empty7);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE3$]", str7);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE4$]", empty8);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSLINE5$]", str8);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSCOUNTRY$]", empty9);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSTELEPHONE$]", str9);
                this.emailSubject = this.emailSubject.Replace("[$DELIVERY_ADDRESSFAX$]", empty10);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLABEL$]", str1);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE1$]", empty2);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE2$]", str2);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE3$]", empty3);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE4$]", str3);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSLINE5$]", empty4);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSCOUNTRY$]", str4);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSTELEPHONE$]", empty5);
                this.TagBody = this.TagBody.Replace("[$INVOICE_ADDRESSFAX$]", str5);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLABEL$]", empty6);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE1$]", str6);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE2$]", empty7);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE3$]", str7);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE4$]", empty8);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSLINE5$]", str8);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSCOUNTRY$]", empty9);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSTELEPHONE$]", str9);
                this.TagBody = this.TagBody.Replace("[$DELIVERY_ADDRESSFAX$]", empty10);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b new user registration")
            {
                StringBuilder stringBuilder10 = new StringBuilder();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    orderKey = new object[] { sitePath, "userregisterapproval.aspx?userID=", this.StoreUser_ID, "&AccountID=", this.Account_ID };
                    this.loginLink = string.Concat(orderKey);
                }
                else
                {
                    orderKey = new object[] { sitePath, "userregisterapproval", ConnectionClass.KeySeparator, this.StoreUser_ID, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.loginLink = string.Concat(orderKey);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to Approve the User</a>");
                foreach (DataRow row9 in dtBody.Rows)
                {
                    stringBuilder10.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(row9["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(row9["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(row9["MiddleName"].ToString()), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(row9["Department"].ToString()), "</td></tr>"));
                    currencyinRequiredFormate = new string[] { row9["HomeAddressLine1"].ToString(), "</br>", row9["HomeAddressLine2"].ToString(), "</br>", row9["HomeAddressLine3"].ToString(), "</br>", row9["HomeAddressLine4"].ToString(), "</br>", row9["AddressLine2"].ToString() };
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(string.Concat(currencyinRequiredFormate)), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(row9["HomeCountry"].ToString()), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", baseClass.SpecialDecode(row9["HomeTelephone"].ToString()), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", row9["Fax"].ToString(), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", row9["Email"].ToString(), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", row9["Password"].ToString(), "</td></tr>"));
                    stringBuilder10.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", row9["DesignatedApproverEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(row9["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(row9["LastName"].ToString()));
                    this.emailFrom = row9["Email"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder10.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "new b2b contact registration")
            {
                StringBuilder stringBuilder11 = new StringBuilder();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(sitePath, storeEmail.storeName.Replace(" ", "%20"));
                }
                else
                {
                    this.loginLink = string.Concat(sitePath, storeEmail.storeName.Replace(" ", "%20"));
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
                foreach (DataRow dataRow9 in dtBody.Rows)
                {
                    stringBuilder11.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow9["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow9["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow9["MiddleName"].ToString()), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(dataRow9["Department"].ToString()), "</td></tr>"));
                    currencyinRequiredFormate = new string[] { dataRow9["HomeAddressLine1"].ToString(), "</br>", dataRow9["HomeAddressLine2"].ToString(), "</br>", dataRow9["HomeAddressLine3"].ToString(), "</br>", dataRow9["HomeAddressLine4"].ToString(), "</br>", dataRow9["AddressLine2"].ToString() };
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(string.Concat(currencyinRequiredFormate)), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", dataRow9["HomeCountry"].ToString(), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", dataRow9["HomeTelephone"].ToString(), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top' colspan='3'>", dataRow9["Fax"].ToString(), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", dataRow9["Email"].ToString(), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", dataRow9["Password"].ToString(), "</td></tr>"));
                    stringBuilder11.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", dataRow9["DesignatedApproverEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$CONTACT_EMAIL$]", dataRow9["Email"].ToString());
                    this.TagBody = this.TagBody.Replace("[$CONTACT_PASSWORD$]", dataRow9["Password"].ToString());
                    this.emailFrom = dataRow9["DesignatedApproverEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder11.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modification")
            {
                StringBuilder stringBuilder12 = new StringBuilder();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    orderKey = new object[] { sitePath, "/userprofileapproval.aspx?userID=", this.StoreUser_ID, "&AccountID=", this.Account_ID };
                    this.loginLink = string.Concat(orderKey);
                }
                else
                {
                    orderKey = new object[] { sitePath, "/userprofileapproval", ConnectionClass.KeySeparator, this.StoreUser_ID, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.loginLink = string.Concat(orderKey);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">click here to approve the user profile modification</a>");
                foreach (DataRow row10 in dtBody.Rows)
                {
                    stringBuilder12.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(row10["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(row10["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Home Address:</td><td valign='top'>", baseClass.SpecialDecode(row10["AddressLabel"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address1:</td><td valign='top'>", baseClass.SpecialDecode(row10["Address1"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address2:</td><td valign='top'>", baseClass.SpecialDecode(row10["Address2"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address3:</td><td valign='top'>", baseClass.SpecialDecode(row10["Address3"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address4:</td><td valign='top'>", baseClass.SpecialDecode(string.Concat(row10["Address4"].ToString(), "</td></tr>"))));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address5:</td><td valign='top'>", baseClass.SpecialDecode(row10["Address5"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(row10["Country"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Telephone:</td><td valign='top'>", baseClass.SpecialDecode(row10["Telephone"].ToString()), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", row10["Fax"].ToString(), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", row10["EmailID"].ToString(), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", row10["Password"].ToString(), "</td></tr>"));
                    stringBuilder12.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", row10["DesignatedApprovedEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(row10["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(row10["LastName"].ToString()));
                    this.emailFrom = row10["EmailID"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", storeEmail.storeName);
                this.TagBody = this.TagBody.Replace("[$ALL_PROFILE_FIELDS$]", stringBuilder12.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modified approved")
            {
                StringBuilder stringBuilder13 = new StringBuilder();
                foreach (DataRow dataRow10 in dtBody.Rows)
                {
                    stringBuilder13.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Home Address:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["AddressLabel"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address1:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Address1"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address2:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Address2"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address3:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Address3"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address4:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Address4"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address5:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Address5"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(dataRow10["Country"].ToString()), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Telephone:</td><td valign='top'>", dataRow10["Telephone"].ToString(), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", dataRow10["Fax"].ToString(), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", dataRow10["EmailID"].ToString(), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", dataRow10["Password"].ToString(), "</td></tr>"));
                    stringBuilder13.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", dataRow10["DesignatedApprovedEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(dataRow10["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(dataRow10["LastName"].ToString()));
                    this.emailFrom = dataRow10["DesignatedApprovedEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_PROFILE_FIELDS$]", stringBuilder13.ToString());
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modified rejected")
            {
                foreach (DataRow row11 in dtBody.Rows)
                {
                    this.emailFrom = row11["DesignatedApprovedEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$REJECT_REASON$]", this.RejectedReason);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b new user registration approval pending")
            {
                StringBuilder stringBuilder14 = new StringBuilder();
                foreach (DataRow dataRow11 in dtBody.Rows)
                {
                    stringBuilder14.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["MiddleName"].ToString()), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["Department"].ToString()), "</td></tr>"));
                    currencyinRequiredFormate = new string[] { dataRow11["HomeAddressLine1"].ToString(), "</br>", dataRow11["HomeAddressLine2"].ToString(), "</br>", dataRow11["HomeAddressLine3"].ToString(), "</br>", dataRow11["HomeAddressLine4"].ToString(), "</br>", dataRow11["AddressLine2"].ToString() };
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(string.Concat(currencyinRequiredFormate)), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", dataRow11["HomeCountry"].ToString(), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", dataRow11["HomeTelephone"].ToString(), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", dataRow11["Fax"].ToString(), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", dataRow11["Email"].ToString(), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", dataRow11["Password"].ToString(), "</td></tr>"));
                    stringBuilder14.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", dataRow11["DesignatedApproverEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(dataRow11["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(dataRow11["LastName"].ToString()));
                    this.emailFrom = dataRow11["DesignatedApproverEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder14.ToString());
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "new b2b order")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                string empty20 = string.Empty;
                StringBuilder stringBuilder15 = new StringBuilder();
                this.TagBody = "";
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow row12 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail6 = this;
                    cartAdditionalOptionName = _storeEmail6.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(row12["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row12["SelectedValue"].ToString()), "<br />" };
                    _storeEmail6.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail7 = this;
                    _storeEmail7.Cart_AdditionalOptionValue = string.Concat(_storeEmail7.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row12["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail8 = this;
                    cartAdditionalOptionName = _storeEmail8.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(row12["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row12["SelectedValue"].ToString()), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row12["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail8.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                    storeEmail cartAdditionalOV2 = this;
                    cartAdditionalOV2.Cart_Additional_OV = cartAdditionalOV2.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row12["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                foreach (DataRow dataRow12 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow12["Subject"].ToString();
                    this.TagBody = dataRow12["Body"].ToString();
                    foreach (DataRow row13 in dtBody.Rows)
                    {
                        this.AccountName = row13["accountName"].ToString();
                        storeEmail.order_No = row13["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row13["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, row13["CatalogueName"].ToString(), "Ð");
                        if (row13["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, row13["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (row13["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, row13["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row13["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row13["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = row13["Comments"].ToString();
                        this.customerName = string.Concat(row13["FirstName"].ToString(), " ", row13["LastName"].ToString());
                        this.OrderedByName = string.Concat(row13["FirstName"].ToString(), " ", row13["LastName"].ToString());
                        if (Convert.ToInt64(row13["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { row13["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", row13["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(row13["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", row13["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(row13["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = row13["Order_Behalf_UserID"].ToString();
                        }
                        int num15 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable7 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row13["OrderItemID"]));
                        foreach (DataRow dataRow13 in dataTable7.Rows)
                        {
                            if (dataRow13["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(dataRow13["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow13["UserFriendlyName"].ToString(), "<br/>");
                                if (dataRow13["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", baseClass.SpecialDecode(dataRow13["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(dataRow13["Question"].ToString()), ": ", baseClass.SpecialDecode(dataRow13["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num15++;
                        }
                        if (num15 == 0)
                        {
                            empty20 = "";
                        }
                        else
                        {
                            empty20 = "<tr><td width='150px' valign='top'><b>Additional Items: </b></td>";
                            empty20 = string.Concat(empty20, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        decimal num16 = Convert.ToDecimal(row13["OrderItemTotalPrice"].ToString());
                        decimal num17 = Convert.ToDecimal(row13["OrderItemTax"].ToString());
                        decimal num18 = num16;
                        decimal num19 = num18 + num17;
                        this.SUB_TOTAL = this.SUB_TOTAL + num16;
                        this.TAX_DETAILS = Convert.ToDecimal(row13["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num18;
                        if (empty20 != "")
                        {
                            stringBuilder15.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder15.Append(string.Concat("<div id='div_right' style='float:left;width:100%;'><table><tr><td width='150px' valign='top'><b>Product Name: </b></td><td valign='top'>", baseClass.SpecialDecode(row13["CatalogueName"].ToString()), "</td></tr>"));
                            stringBuilder15.Append(empty20);
                            currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'><b>", this.jobScreenName, ": </b></td><td valign='top'>", baseClass.SpecialDecode(row13["JobName"].ToString()), "</td></tr>" };
                            stringBuilder15.Append(string.Concat(currencyinRequiredFormate));
                            stringBuilder15.Append(string.Concat("<tr><td width='150px' valign='top'><b>Quantity(s): </b></td><td valign='top'>", baseClass.SpecialDecode(row13["Quantity"].ToString()), "</td></tr>"));
                            stringBuilder15.Append(string.Concat("<tr><td width='100px' valign='top'><b>Total Price(inc.Tax): </b><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr></table><br/>"));
                            stringBuilder15.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder15.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder15.Append(string.Concat("<div id='div_right' style='float:left;width:100%;'><table><tr><td width='150px' valign='top'><b>Product Name: </b></td><td valign='top'>", baseClass.SpecialDecode(row13["CatalogueName"].ToString()), "</td></tr>"));
                            currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'><b>", this.jobScreenName, ": </b></td><td valign='top'>", baseClass.SpecialDecode(row13["JobName"].ToString()), "</td></tr>" };
                            stringBuilder15.Append(string.Concat(currencyinRequiredFormate));
                            stringBuilder15.Append(string.Concat("<tr><td width='150px' valign='top'><b>Quantity(s): </b></td><td valign='top'>", baseClass.SpecialDecode(row13["Quantity"].ToString()), "</td></tr>"));
                            stringBuilder15.Append(string.Concat("<tr><td width='150px' valign='top'><b>Total Price(inc.Tax): </b><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr></table><br/>"));
                            stringBuilder15.Append("</div></div><div style='clear:both'>");
                        }
                        this.emailFrom = row13["EmailID"].ToString();
                    }
                }
                if (this.Approver_Type != "u")
                {
                    orderKey = new object[] { sitePath, "order.aspx?OrderID=", OrderID, "&UserID=", StoreUserID, "&AccountID=", this.Account_ID };
                    this.orderLink = string.Concat(orderKey);
                }
                else
                {
                    orderKey = new object[] { sitePath, "orderapproval.aspx?OrderID=", OrderID, "&UserID=", StoreUserID, "&AccountID=", this.Account_ID };
                    this.orderLink = string.Concat(orderKey);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to login and review orders</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                chrArray = new char[] { 'Ð' };
                string[] strArrays7 = empty1.Split(chrArray);
                string pdfFile2 = storeEmail.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays8 = pdfFile2.Split(chrArray);
                string empty21 = string.Empty;
                for (int l = 0; l < (int)strArrays8.Length; l++)
                {
                    if ((int)strArrays7.Length == (int)strArrays8.Length && strArrays7[l].ToString().Trim() != "")
                    {
                        string str21 = strArrays7[l].ToString();
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays9 = str21.Split(chrArray);
                        empty1 = strArrays9[0].ToString();
                        string str22 = strArrays9[1].ToString();
                        storeEmail.Pdf_File = strArrays8[l].ToString();
                        if (str22 != "et")
                        {
                            orderKey = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(orderKey);
                        }
                        else if (EmailFor.ToLower() != "admin")
                        {
                            orderKey = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(orderKey);
                        }
                        else
                        {
                            orderKey = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(orderKey);
                        }
                    }
                }
                storeEmail.Pdf_File = "";
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", baseClass.SpecialDecode(this.customerName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder15.ToString());
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty21);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "b2b user order approval")
            {
                this.TagBody = "";
                foreach (DataRow row14 in dtEmail.Rows)
                {
                    this.emailSubject = row14["Subject"].ToString();
                    this.TagBody = row14["Body"].ToString();
                    foreach (DataRow dataRow14 in dtBody.Rows)
                    {
                        this.AccountName = dataRow14["accountName"].ToString();
                        storeEmail.order_No = dataRow14["OrderNo"].ToString();
                        this.OrderKey = dataRow14["OrderKey"].ToString();
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow14["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.emailFrom = dataRow14["ApproverEmail"].ToString();
                    }
                }
                orderKey = new object[] { sitePath, "order.aspx?OrdKey=", this.OrderKey, "&AccountID=", this.Account_ID };
                this.orderLink = string.Concat(orderKey);
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "b2b user order rejection")
            {
                this.TagBody = "";
                foreach (DataRow row15 in dtEmail.Rows)
                {
                    this.emailSubject = row15["Subject"].ToString();
                    this.TagBody = row15["Body"].ToString();
                    foreach (DataRow dataRow15 in dtBody.Rows)
                    {
                        this.AccountName = dataRow15["accountName"].ToString();
                        storeEmail.order_No = dataRow15["OrderNo"].ToString();
                        this.OrderKey = dataRow15["OrderKey"].ToString();
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow15["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RejectedReason = dataRow15["RejectReason"].ToString();
                        this.emailFrom = dataRow15["ApproverEmail"].ToString();
                    }
                }
                orderKey = new object[] { sitePath, "order.aspx?OrdKey=", this.OrderKey, "&AccountID=", this.Account_ID };
                this.orderLink = string.Concat(orderKey);
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$REJECT_REASON$]", baseClass.SpecialDecode(this.RejectedReason));
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            return this.TagBody;
        }

        public virtual DataTable Select_OrderAdditionalItems(long OrderItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalItems");
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderAdditionalOptions(long StoreUserID, long OrderID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalOptions");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.String, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderItems");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml)
        {
            string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
            string str1 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
            long num = (long)0;
            if (HttpContext.Current.Session["StoreUserID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["StoreUserID"].ToString());
            }
            string empty = string.Empty;
            string str2 = from;
            if (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() == "1")
            {
                from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
            }
            else if (str2.Trim().Length <= 0)
            {
                from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
            }
            else
            {
                from = str2;
            }
            string str3 = string.Concat("<", str2, ">");
            SqlConnection sqlConnection = new SqlConnection(str1);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ServerName", str);
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(HttpContext.Current.Session["companyID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@DBID", 0);
            sqlCommand.Parameters.AddWithValue("@FromEmail", from);
            sqlCommand.Parameters.AddWithValue("@ReplyTo", str3);
            sqlCommand.Parameters.AddWithValue("@ToEmails", to);
            sqlCommand.Parameters.AddWithValue("@CCEmails", cc);
            sqlCommand.Parameters.AddWithValue("@BCCEmails", bcc);
            sqlCommand.Parameters.AddWithValue("@EmailSubject", subject);
            sqlCommand.Parameters.AddWithValue("@EmailBody", body);
            sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
            sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
            sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
            SqlParameterCollection parameters = sqlCommand.Parameters;
            DateTime now = DateTime.Now;
            parameters.AddWithValue("@CreatedOn", now.ToString());
            sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
            sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
            sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
            sqlCommand.Parameters.AddWithValue("@StoreName", storeEmail.storeName);
            sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public virtual DataTable StoreUser_select(long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_StoreUser_select");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}