using com.eprintsoftware.www;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

// test code

using iTextSharp.text.html.simpleparser;
using System.Linq;
using System.Net;
using System.Net.Mail;
using iTextSharp.tool.xml;

namespace nmsEmail
{
    public class storeEmail
    {
        private commonclass comm = new commonclass();

        private BaseClass objBase = new BaseClass();

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

        public string user_firstname = string.Empty;

        public string FirstName = string.Empty;

        public string LastName = string.Empty;

        public string MiddleName = string.Empty;

        public string Department = string.Empty;

        public string EmailID = string.Empty;

        public string Pwd = string.Empty;

        public string AccountName = string.Empty;

        public string loginLink = string.Empty;

        public string RejectedReason = string.Empty;

        public string CreatedDate = string.Empty;

        public string strSitepath = string.Empty;

        public long EmailToCustomerID;

        public string OrderTitle = string.Empty;

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

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public bool IsArtwork;

        public bool IsOrderPdf;

        public bool IsActive;

        public string SecureDocPath = ConnectionClass.SecureDocPath;

        public string SecureDocFilePath = ConnectionClass.SecureDocFilepath;

        public string SecureSitePath = ConnectionClass.SecureSitePath;

        public string ServerName = ConnectionClass.ServerName;

        public string OrderedByName = string.Empty;

        public string OrderedForName = string.Empty;

        public bool IsFromIndividualItems;

        public string OrderItemIds = string.Empty;

        public string Eventname = string.Empty;

        public string DeptScreenName = string.Empty;

        public string jobScreenName = "Job Name";

        public string CustomerOrderNo = string.Empty;

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
            if (TagEvent.ToLower() == "b2b user profile modification" || TagEvent.ToLower() == "b2b user profile modified approved" || TagEvent.ToLower() == "b2b user profile modified rejected")
            {
                dataTable = LoginBasePage.Select_UserDetail_For_Approval(StoreUserID);
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
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, TagEvent, EmailFor);
                string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                if ((int)strArrays.Length > 0)
                {
                    this.emailFrom = strArrays[0];
                    try
                    {
                        if (HttpContext.Current.Session["EmailID"] != null)
                        {
                            string str2 = HttpContext.Current.Session["EmailID"].ToString();
                            if (this.emailFrom != str2.Trim())
                            {
                                this.emailFrom = strArrays[1];
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.emailFrom = strArrays[0];
                    }
                }
                storeEmail.SendMailMessage(this.emailFrom, ToEmail, "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
            if (TagEvent.ToLower() == "b2b new user registration" || TagEvent.ToLower() == "new b2b contact registration" || TagEvent.ToLower() == "b2b new user registration approval pending")
            {
                dataTable = LoginBasePage.Select_UserDetail(StoreUserID);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.FirstName = dataRow["FirstName"].ToString();
                this.LastName = dataRow["Lastname"].ToString();
                this.EmailID = dataRow["Email"].ToString();
                this.Pwd = dataRow["Password"].ToString();
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, TagEvent, EmailFor);
                string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                if ((int)strArrays.Length > 0)
                {
                    this.emailFrom = strArrays[0];
                    try
                    {
                        if (HttpContext.Current.Session["EmailID"] != null)
                        {
                            string str = HttpContext.Current.Session["EmailID"].ToString();
                            if (this.emailFrom != str.Trim())
                            {
                                this.emailFrom = strArrays[1];
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.emailFrom = strArrays[0];
                    }
                }
                storeEmail.SendMailMessage(this.emailFrom, ToEmail, "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void B2BRejectsUserDetails_Email(long RegisterPendingUserID, int CompanyID, long AccountID, string TagEvent, string EmailFor, long StoreUserID, string ToEmail)
        {
            string sitePath = ConnectionClass.SitePath;
            DataTable dataTable = new DataTable();
            this.Company_ID = CompanyID;
            this.Account_ID = Convert.ToInt32(AccountID);
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            storeEmail.storeName = this.AccountName;
            this.TagBody = "";
            DataTable customerSelect = this.EmailToCustomer_Select(this.Company_ID, this.Account_ID, (long)0, TagEvent, EmailFor);
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                this.TagBody = row["Body"].ToString();
            }
            if (TagEvent.ToLower() == "b2b new user rejection")
            {
                dataTable = LoginBasePage.UserRegistrationDetails_Rejection(RegisterPendingUserID);
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, TagEvent, EmailFor);
                string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                if ((int)strArrays.Length > 0)
                {
                    this.emailFrom = strArrays[0];
                    try
                    {
                        if (HttpContext.Current.Session["EmailID"] != null)
                        {
                            string str = HttpContext.Current.Session["EmailID"].ToString();
                            if (this.emailFrom != str.Trim())
                            {
                                this.emailFrom = strArrays[1];
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.emailFrom = strArrays[0];
                    }
                }
                storeEmail.SendMailMessage(this.emailFrom, ToEmail, "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void emailOrdersDetails(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, string emailfor, long ApproverID, string ToEmail, string ApprovalType)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.Approver_Type = ApprovalType;
            BaseClass baseClass = new BaseClass();
            this.TagBody = "";
            string file = string.Empty;
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
                this.emailSubject = baseClass.SpecialDecode(row["Subject"].ToString());
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsOrderPdf = Convert.ToBoolean(row["IsOrderPdf"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable1 = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (TagEvent.ToLower().Trim() != "new b2b order")
                {
                    ToEmail = dataRow["OrderedByEmailID"].ToString();
                }
                storeEmail.storeName = dataRow["accountName"].ToString();
                this.CartItemID = Convert.ToInt32(dataRow["CartItemID"]);
                this.PriceCatalogueID = Convert.ToInt32(dataRow["PriceCatalogueID"]);
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
                    string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                    if ((int)strArrays.Length > 0)
                    {
                        this.emailFrom = strArrays[0];
                    }
                    //this.GeneratePDF(CompanyID, this.email_return_body);
                    //string file = "test1.pdf"; //Server.MapPath("test.pdf");
                    //string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test1.pdf");
                    //String html = "<div style=\"font-family: 'Microsoft YaHei';\"><a href='#last'>Bottom</a><h1 style='padding:1000px 0'>Hello World! Chinese<br/><br/><br/><br/><br/></h1><a name='last'> anchor link</a><div style='color: #0a0'>Test content</div></div>";

                    // attach PDF to the automated order email                    
                    if ((this.IsOrderPdf) && (TagEvent.ToLower().Trim() == "thank you for your order"))
                    {
                        string path = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        //string pdfName = "test1.pdf";
                        string OrderPdfFileName = string.Concat(CompanyID, this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), "_OrderPDF.pdf");
                        //string pdfName = dataRow["OrderItemID"] + "_OrderPDF.pdf";
                        //string pdfCreate = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", pdfName);
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", OrderPdfFileName, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                        file = Path.Combine(path, OrderPdfFileName);
                        String html = @"<p>" + this.email_return_body + "</p>";
                        Html2Pdf(html, file);
                    }

                    storeEmail.SendMailMessage(this.emailFrom, ToEmail.Trim(), "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
                    string[] strArrays1 = this.emailFrom.Trim().Split(new char[] { ',' });
                    if ((int)strArrays1.Length > 0)
                    {
                        this.emailFrom = strArrays1[0];
                    }
                    storeEmail.SendMailMessage(this.emailFrom, this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                    if (!string.IsNullOrEmpty(dataTable1.Rows[0]["TerritoryManagerEmailID"].ToString()))
                    {
                        storeEmail.SendMailMessage(this.emailFrom, dataTable1.Rows[0]["TerritoryManagerEmailID"].ToString().Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                    }
                }
            }
        }

        public void emailOrdersDetails_ItemNumbers(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, string emailfor, long ApproverID, string ToEmail, string ApprovalType, string OrderItems)
        {
            this.IsFromIndividualItems = true;
            this.OrderItemIds = OrderItems;
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.Approver_Type = ApprovalType;
            BaseClass baseClass = new BaseClass();
            this.TagBody = "";
            string file = string.Empty;
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
            if (TagEvent.ToLower().Trim() == "new order" || TagEvent.ToLower().Trim() == "back order")
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
            dataTable = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, emailfor);
            foreach (DataRow row in dataTable.Rows)
            {
                this.emailSubject = baseClass.SpecialDecode(row["Subject"].ToString());
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsOrderPdf = Convert.ToBoolean(row["IsOrderPdf"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable1 = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (TagEvent.ToLower().Trim() != "new b2b order")
                {
                    ToEmail = dataRow["OrderedByEmailID"].ToString();
                }
                storeEmail.storeName = dataRow["accountName"].ToString();
                this.CartItemID = Convert.ToInt32(dataRow["CartItemID"]);
                this.PriceCatalogueID = Convert.ToInt32(dataRow["PriceCatalogueID"]);
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
                if (this.IsActive && TagEvent.ToLower().Trim() != "new order" && TagEvent.ToLower().Trim() != "back order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, TagEvent, emailfor);
                    if (TagEvent.ToLower().Trim() == "thank you for your order" && dataTable.Rows.Count > 0)
                    {
                        this.emailFrom = dataTable.Rows[0]["marketingEmail"].ToString();
                    }
                    string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                    if ((int)strArrays.Length > 0)
                    {
                        this.emailFrom = strArrays[0];
                    }
                    //this.GeneratePDF(CompanyID, this.email_return_body);
                    if ((this.IsOrderPdf) && (TagEvent.ToLower().Trim() == "thank you for your order"))
                    {
                        string path = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string OrderPdfFileName = string.Concat(CompanyID, this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), "_OrderPDF.pdf");
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", OrderPdfFileName, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                        file = Path.Combine(path, OrderPdfFileName);
                        String html = @"<p>" + this.email_return_body + "</p>";
                        Html2Pdf(html, file);
                    }
                    storeEmail.SendMailMessage(this.emailFrom, ToEmail.Trim(), "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
                if (this.IsActive)
                {
                    if (TagEvent.ToLower().Trim() == "new order")
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
                        string[] strArrays1 = this.emailFrom.Trim().Split(new char[] { ',' });
                        if ((int)strArrays1.Length > 0)
                        {
                            this.emailFrom = strArrays1[0];
                        }
                        storeEmail.SendMailMessage(this.emailFrom, this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                        if (!string.IsNullOrEmpty(dataTable1.Rows[0]["TerritoryManagerEmailID"].ToString()))
                        {
                            storeEmail.SendMailMessage(this.emailFrom, dataTable1.Rows[0]["TerritoryManagerEmailID"].ToString().Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                        }
                    }
                    if (TagEvent.ToLower().Trim() == "back order")
                    {
                        //Take only approved products. KR added for ticket 71452
                        string[] strArr1 = OrderItems.Split(new char[] { ',' });
                        for (int a = 0; a < dataTable1.Rows.Count; a++)
                        {
                            Boolean isExist = false;
                            int count = 0;
                            for (int b = 0; b < strArr1.Length; b++)
                            {
                                DataRow dr = dataTable1.Rows[a];
                                if (Convert.ToString(dataTable1.Rows[a]["EstimateItemID"]) == Convert.ToString(strArr1[b]))
                                {
                                    isExist = true;
                                }
                                count = count + 1;
                                if (count == strArr1.Length && isExist == false)
                                {
                                    dr.Delete();
                                }
                            }
                        }
                        dataTable1.AcceptChanges();
                        this.email_return_body = "";
                        this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, "BackOrder", emailfor);
                        if (ConnectionClass.SystemName.ToLower() == "aviva" && ConnectionClass.NewOrderAdminEmailID != null)
                        {
                        }
                        if (customerSelectWebStore.Rows.Count > 0)
                        {
                            this.emailFrom = customerSelectWebStore.Rows[0]["marketingEmail"].ToString();
                        }
                        string[] strArrays2 = this.emailFrom.Trim().Split(new char[] { ',' });
                        if ((int)strArrays2.Length > 0)
                        {
                            this.emailFrom = strArrays2[0];
                        }
                        storeEmail.SendMailMessage(this.emailFrom, this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                    }
                }
            }
        }

        // attach PDF to the automated order email 
        public static void Html2Pdf(string html, string filename)
        {
            try
            {
                using (Stream fs = new FileStream(filename, FileMode.Create))
                {
                    using (Document doc = new Document(PageSize.A4))
                    {

                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                        }

                        doc.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        //private void GeneratePDF(int companyid, string emailbody)
        //{
        //    // test code2

        //    // end test code2

        //    // test code
        //    //Create a byte array that will eventually hold our final PDF
        //    //Byte[] bytes;

        //    ////Boilerplate iTextSharp setup here
        //    ////Create a stream that we can write to, in this case a MemoryStream
        //    //using (var ms = new MemoryStream())
        //    //{

        //    //    //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
        //    //    using (var doc = new Document())
        //    //    {

        //    //        //Create a writer that's bound to our PDF abstraction and our stream
        //    //        using (var writer = PdfWriter.GetInstance(doc, ms))
        //    //        {

        //    //            //Open the document for writing
        //    //            doc.Open();

        //    //            //Our sample HTML and CSS
        //    //            var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";

        //    //            var example_css = @".headline{font-size:200%}";

        //    //            /**************************************************
        //    //             * Example #1                                     *
        //    //             *                                                *
        //    //             * Use the built-in HTMLWorker to parse the HTML. *
        //    //             * Only inline CSS is supported.                  *
        //    //             * ************************************************/

        //    //            //Create a new HTMLWorker bound to our document
        //    //            using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
        //    //            {

        //    //                //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
        //    //                using (var sr = new StringReader(example_html))
        //    //                {

        //    //                    //Parse the HTML
        //    //                    htmlWorker.Parse(sr);
        //    //                }
        //    //            }

        //    //            /**************************************************
        //    //             * Example #2                                     *
        //    //             *                                                *
        //    //             * Use the XMLWorker to parse the HTML.           *
        //    //             * Only inline CSS and absolutely linked          *
        //    //             * CSS is supported                               *
        //    //             * ************************************************/

        //    //            //XMLWorker also reads from a TextReader and not directly from a string
        //    //            using (var srHtml = new StringReader(example_html))
        //    //            {

        //    //                //Parse the HTML
        //    //                try
        //    //                {
        //    //                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
        //    //                }
        //    //                catch (Exception ex)
        //    //                { 
        //    //                }

        //    //            }

        //    //            /**************************************************
        //    //             * Example #3                                     *
        //    //             *                                                *
        //    //             * Use the XMLWorker to parse HTML and CSS        *
        //    //             * ************************************************/

        //    //            //In order to read CSS as a string we need to switch to a different constructor
        //    //            //that takes Streams instead of TextReaders.
        //    //            //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
        //    //            using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
        //    //            {
        //    //                using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
        //    //                {

        //    //                    //Parse the HTML
        //    //                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
        //    //                }
        //    //            }


        //    //            doc.Close();
        //    //        }
        //    //    }

        //    //    //After all of the PDF "stuff" above is done and closed but **before** we
        //    //    //close the MemoryStream, grab all of the active bytes from the stream
        //    //    bytes = ms.ToArray();
        //    //}

        //    ////Now we just need to do something with those bytes.
        //    ////Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
        //    ////You could also write the bytes to a database in a varbinary() column (but please don't) or you
        //    ////could pass them to another function for further PDF processing.
        //    //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
        //    //System.IO.File.WriteAllBytes(testFile, bytes);

        //    //End test code

        //    //StringReader sr = new StringReader(emailbody.ToString());

        //    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    //using (MemoryStream memoryStream = new MemoryStream())
        //    //{
        //    //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        //    //    pdfDoc.Open();

        //    //    htmlparser.Parse(sr);
        //    //    pdfDoc.Close();

        //    //    byte[] bytes = memoryStream.ToArray();
        //    //    memoryStream.Close();
        //    //}

        //    //old code

        //    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
        //    // attachment
        //    //object[] secureDocPath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID, "\\pdf\\", str };
        //    //string str2 = string.Concat(secureDocPath);
        //    string pdfName = "test1.pdf";
        //    string pdfCreate = string.Concat(this.SecureDocPath, this.ServerName, "/", companyid, "/attachments/", pdfName);
        //    object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", companyid, "/attachments/", pdfName, "µ" };
        //    this.emailAttachment = string.Concat(secureDocPath);
        //    string path = string.Concat(this.emailAttachment, this.SecureDocPath, this.ServerName, "/", companyid, "/attachments/");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    //// test code

        //    //// end test code

        //    //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfCreate, FileMode.Create));
        //    //doc.Open();
        //    ////iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("Hi, \n This is globo technologies dated 29-6-2021 \n This is my pdf file");
        //    //iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(emailbody);
        //    //doc.Add(paragraph);
        //    //doc.Close();
        //}
        public void emailOrdersDetailsBackOrder(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, string emailfor, long ApproverID, string ToEmail, string ApprovalType)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.Approver_Type = ApprovalType;
            this.TagBody = "";
            string file = string.Empty;
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
            if (TagEvent.ToLower().Trim() == "back order")
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
                this.IsOrderPdf = Convert.ToBoolean(row["IsOrderPdf"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable1 = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (TagEvent.ToLower().Trim() != "new b2b order")
                {
                    ToEmail = dataRow["OrderedByEmailID"].ToString();
                }
                storeEmail.storeName = dataRow["accountName"].ToString();
                this.CartItemID = Convert.ToInt32(dataRow["CartItemID"]);
                this.PriceCatalogueID = Convert.ToInt32(dataRow["PriceCatalogueID"]);
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
                if (this.IsActive && TagEvent.ToLower().Trim() != "back order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, TagEvent, emailfor);
                    if (TagEvent.ToLower().Trim() == "thank you for your order" && dataTable.Rows.Count > 0)
                    {
                        this.emailFrom = dataTable.Rows[0]["marketingEmail"].ToString();
                    }
                    string[] strArrays = this.emailFrom.Trim().Split(new char[] { ',' });
                    if ((int)strArrays.Length > 0)
                    {
                        this.emailFrom = strArrays[0];
                    }

                    // attach PDF to the automated order email                    
                    if ((this.IsOrderPdf) && (TagEvent.ToLower().Trim() == "thank you for your order"))
                    {
                        string path = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string OrderPdfFileName = string.Concat(CompanyID, this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), "_OrderPDF.pdf");
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", OrderPdfFileName, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                        file = Path.Combine(path, OrderPdfFileName);
                        String html = @"<p>" + this.email_return_body + "</p>";
                        Html2Pdf(html, file);
                    }
                    storeEmail.SendMailMessage(this.emailFrom, ToEmail.Trim(), "", "", this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
                if (this.IsActive && TagEvent.ToLower().Trim() == "back order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, OrderID, StoreUserID, CompanyID, "BACKORDER", emailfor);
                    if (ConnectionClass.SystemName.ToLower() == "aviva" && ConnectionClass.NewOrderAdminEmailID != null)
                    {
                    }
                    if (customerSelectWebStore.Rows.Count > 0)
                    {
                        this.emailFrom = customerSelectWebStore.Rows[0]["marketingEmail"].ToString();
                    }
                    string[] strArrays1 = this.emailFrom.Trim().Split(new char[] { ',' });
                    if ((int)strArrays1.Length > 0)
                    {
                        this.emailFrom = strArrays1[0];
                    }
                    storeEmail.SendMailMessage(this.emailFrom, this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
            DateTime dateTime = DateTime.Now;
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
                Label2:
                    empty1 = str.ToString();
                }
                catch
                {
                    str1 = strDate;
                    return str1;
                }
            }

        Label1:
            str = dateTime.ToString();
            //goto Label2;
            return empty1;
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
            object[] keySeparator;
            string cartAdditionalOptionName;
            string[] currencyinRequiredFormate;
            IEnumerator enumerator;
            char[] chrArray;
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            string lower = string.Empty;
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
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select((long)this.Account_ID, (long)CompanyID);
            if (dataTable.Rows.Count <= 0)
            {
                lower = "false";
            }
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    lower = dataRow["EnableHidePrice"].ToString().ToLower();
                }
            }
            try
            {
                if (dtBody.Rows.Count > 0)
                {
                    this.OrderKey = dtBody.Rows[0]["OrderKey"].ToString();
                }
            }
            catch (Exception exception)
            {
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
            string str16 = string.Empty;

            string empty222 = string.Empty;
            string str222 = string.Empty;
            string empty223 = string.Empty;
            string str223 = string.Empty;
            string empty224 = string.Empty;
            string str224 = string.Empty;
            string empty225 = string.Empty;
            //string str225 = string.Empty;
            //string empty226 = string.Empty;

            foreach (DataRow row1 in CartBasePage.default_settings(CompanyID, this.Account_ID).Rows)
            {
                this.jobScreenName = baseClass.SpecialDecode(row1["cartjobScreenName"].ToString());
            }
            foreach (DataRow dataRow1 in dtEmail.Rows)
            {
                if (!dtEmail.Columns.Contains("EmailToCustomerID"))
                {
                    continue;
                }
                this.EmailToCustomerID = Convert.ToInt64(dataRow1["EmailToCustomerID"].ToString());
            }
            DataTable dataTable1 = OrderBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow row2 in OrderBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
                if (row2["IsItemNumber"].ToString() != "")
                {
                    empty15 = (row2["IsItemNumber"].ToString().ToLower() != "true" ? "false" : "true");
                }
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
                if (lower == "true")
                {
                    empty12 = "false";
                }
                else if (row2["IsTotalPrice"].ToString() != "")
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
                    str15 = (row2["IsItemCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsCustomerCode"].ToString() != "")
                {
                    empty16 = (row2["IsCustomerCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row2["IsUnitOfMeasure"].ToString() == "")
                {
                    continue;
                }
                str16 = (row2["IsUnitOfMeasure"].ToString().ToLower() != "true" ? "false" : "true");

                empty222 = (row2["IsItemDescription"].ToString().ToLower() != "true" ? "false" : "true");
                str222 = (row2["IsWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty223 = (row2["IsCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str223 = (row2["IsOrderedWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty224 = (row2["IsOrderedCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str224 = (row2["IsPerQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                empty225 = (row2["IsDimensions"].ToString().ToLower() != "true" ? "false" : "true");
                //str225 = (row2["IsWidth"].ToString().ToLower() != "true" ? "false" : "true");
                //empty226 = (row2["IsHeight"].ToString().ToLower() != "true" ? "false" : "true");
            }
            if (Type.ToLower().Trim() == "thank you for your order")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                this.TAXD = new decimal(0);
                string empty17 = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder1 = new StringBuilder();
                StringBuilder stringBuilder2 = new StringBuilder();
                StringBuilder stringBuilder3 = new StringBuilder();
                StringBuilder stringBuilder4 = new StringBuilder();
                this.TagBody = "";
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new object[] { sitePath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href='", this.orderLink, "'>Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow2 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    dataRow2["WebOtherCostName"] = baseClass.SpecialDecode(dataRow2["WebOtherCostName"].ToString());
                    storeEmail _storeEmail = this;
                    cartAdditionalOptionName = _storeEmail.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow2["WebOtherCostName"].ToString(), "- ", dataRow2["SelectedValue"].ToString(), "<br />" };
                    _storeEmail.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail1 = this;
                    _storeEmail1.Cart_AdditionalOptionValue = string.Concat(_storeEmail1.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail cartAdditionalOV = this;
                    cartAdditionalOV.Cart_Additional_OV = cartAdditionalOV.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true));
                    storeEmail _storeEmail2 = this;
                    cartAdditionalOptionName = _storeEmail2.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow2["WebOtherCostName"].ToString(), "- ", dataRow2["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail2.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                }
                foreach (DataRow row3 in dtEmail.Rows)
                {
                    this.emailSubject = row3["Subject"].ToString();
                    this.TagBody = row3["Body"].ToString();
                    DataTable dataTable2 = new DataTable();
                    DataTable dataTable3 = new DataTable();
                    foreach (DataRow dataRow3 in dtBody.Rows)
                    {
                        dataTable2 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow3["BillingAddressID"]));
                        dataTable3 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow3["ShippingAddressID"]));
                        storeEmail.storeName = dataRow3["accountName"].ToString();
                        storeEmail.order_No = dataRow3["OrderNo"].ToString();
                        this.Eventname = dataRow3["Eventname"].ToString();
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow3["CatalogueName"].ToString(), "Ð");
                        this.user_firstname = dataRow3["FirstName"].ToString();
                        this.OrderedByName = string.Concat(dataRow3["FirstName"].ToString(), " ", dataRow3["LastName"].ToString());
                        this.CustomerOrderNo = Convert.ToString(dataRow3["CustomerOrderNo"]);
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
                        this.Comments = baseClass.SpecialDecode(dataRow3["Comments"].ToString().Replace("\n", "<br />"));
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        this.OrderTitle = baseClass.SpecialDecode(dataRow3["orderTitle"].ToString());
                        int num = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable4 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow3["OrderItemID"]));
                        foreach (DataRow row4 in dataTable4.Rows)
                        {
                            if (row4["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, row4["UserFriendlyName"].ToString(), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row4["UserFriendlyName"].ToString()), "<br/>");
                                if (row4["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", row4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(row4["Question"].ToString()), ": ", row4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num++;
                        }
                        if (num == 0)
                        {
                            empty17 = "";
                        }
                        else if (str14 == "true")
                        {
                            empty17 = "<tr><td width='150px' valign='top'>Additional Items: </td>";
                            empty17 = string.Concat(empty17, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
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
                        if (empty17 != "")
                        {
                            //stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder.Append(empty17);
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
                                stringBuilder.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num4, 2, "", false, false, true), "</td></tr>"));
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
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
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
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow3["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow3["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow3["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow3["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow3["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder.Append("</table><br/>");
                            //stringBuilder.Append("</div>");
                            stringBuilder.Append("</div></div><div style='clear:both'></div>");
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
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num4, 2, "", false, false, true), "</td></tr>"));
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
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
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
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow3["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow3["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow3["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow3["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow3["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'></div>");
                        }
                    }
                    storeEmail tOTAL = this;
                    tOTAL.TOTAL = tOTAL.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL1 = this;
                    tOTAL1.TOTAL = tOTAL1.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                    if (lower == "true")
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", "");
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", "");
                    }
                    else
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    }
                    this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                    if (lower == "true")
                    {
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", "");
                    }
                    else
                    {
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                    }
                    this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                    this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    this.emailSubject = this.emailSubject.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(this.user_firstname));
                    this.emailSubject = this.emailSubject.Replace("\r\n", "");
                    this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                    if (lower == "true")
                    {
                        this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", "");
                        this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", "");
                    }
                    else
                    {
                        this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                        this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    }
                    this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                    this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                    this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", this.user_firstname);

                    this.TagBody = this.TagBody.Replace("[$CUSTOMER_ORDER_NUMBER$]", this.CustomerOrderNo);

                    this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                    this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                    this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                    this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    foreach (DataRow dataRow4 in dataTable2.Rows)
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
                    foreach (DataRow row5 in dataTable3.Rows)
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
                    enumerator = dtBody.Rows.GetEnumerator();
                    try
                    {
                        if (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            this.TAXD = Convert.ToDecimal(current["Taxprice"]);
                            num5 = num5 + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL + this.TAXD, 2, "", false, false, true));
                            this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, num5, 2, "", false, false, true))));
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays1 = empty1.Split(chrArray);
                    string pdfFile = storeEmail.Pdf_File;
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays2 = pdfFile.Split(chrArray);
                    string str17 = string.Empty;
                    if (empty1 != "")
                    {
                        for (int j = 0; j < (int)strArrays2.Length; j++)
                        {
                            if ((int)strArrays1.Length == (int)strArrays2.Length && strArrays1[j].ToString().Trim() != "")
                            {
                                string str18 = strArrays1[j].ToString();
                                chrArray = new char[] { '\u00A7' };
                                string[] strArrays3 = str18.Split(chrArray);
                                empty1 = strArrays3[0].ToString();
                                string str19 = strArrays3[1].ToString();
                                storeEmail.Pdf_File = strArrays2[j].ToString();
                                if (str19 != "et")
                                {
                                    keySeparator = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(keySeparator);
                                }
                                else if (EmailFor.ToLower() != "admin")
                                {
                                    keySeparator = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(keySeparator);
                                }
                                else
                                {
                                    keySeparator = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(keySeparator);
                                }
                            }
                        }
                    }
                    storeEmail.Pdf_File = "";
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                    if (lower != "false")
                    {
                        this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "");
                    }
                    else
                    {
                        this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    }
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", str17);
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
                    this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new object[] { sitePath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow5 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    storeEmail _storeEmail3 = this;
                    cartAdditionalOptionName = _storeEmail3.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow5["WebOtherCostName"].ToString(), "- ", dataRow5["SelectedValue"].ToString(), "<br />" };
                    _storeEmail3.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail4 = this;
                    _storeEmail4.Cart_AdditionalOptionValue = string.Concat(_storeEmail4.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail5 = this;
                    cartAdditionalOptionName = _storeEmail5.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow5["WebOtherCostName"].ToString(), "- ", dataRow5["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail5.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                    storeEmail cartAdditionalOV1 = this;
                    cartAdditionalOV1.Cart_Additional_OV = cartAdditionalOV1.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                DataTable dataTable5 = new DataTable();
                DataTable dataTable6 = new DataTable();
                foreach (DataRow row6 in dtEmail.Rows)
                {
                    this.emailSubject = row6["Subject"].ToString();
                    this.TagBody = row6["Body"].ToString();
                    foreach (DataRow dataRow6 in dtBody.Rows)
                    {
                        dataTable5 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow6["BillingAddressID"]));
                        dataTable6 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow6["ShippingAddressID"]));
                        this.AccountName = baseClass.SpecialDecode(dataRow6["accountName"].ToString());
                        storeEmail.order_No = dataRow6["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow6["createdBy"].ToString());
                        if (!this.IsFromIndividualItems)
                        {
                            storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow6["CatalogueName"].ToString(), "Ð");
                            if (dataRow6["PDFNameFromCart"].ToString() != "")
                            {
                                empty1 = string.Concat(empty1, dataRow6["PDFNameFromCart"].ToString(), "§etÐ");
                            }
                            else if (dataRow6["PrintReadyFile"].ToString().Trim().Length > 0)
                            {
                                empty1 = string.Concat(empty1, dataRow6["PrintReadyFile"].ToString(), "§prÐ");
                            }
                        }
                        else
                        {
                            string orderItemIds = this.OrderItemIds;
                            chrArray = new char[] { ',' };
                            if (Array.IndexOf<string>(orderItemIds.Split(chrArray), dataRow6["OrderItemID"].ToString()) > -1)
                            {
                                storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow6["CatalogueName"].ToString(), "Ð");
                                if (dataRow6["PDFNameFromCart"].ToString() != "")
                                {
                                    empty1 = string.Concat(empty1, dataRow6["PDFNameFromCart"].ToString(), "§etÐ");
                                }
                                else if (dataRow6["PrintReadyFile"].ToString().Trim().Length > 0)
                                {
                                    empty1 = string.Concat(empty1, dataRow6["PrintReadyFile"].ToString(), "§prÐ");
                                }
                            }
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow6["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow6["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = baseClass.SpecialDecode(dataRow6["Comments"].ToString().Replace("\n", "<br />"));
                        this.customerName = baseClass.SpecialDecode(string.Concat(dataRow6["FirstName"].ToString(), " ", dataRow6["LastName"].ToString()));
                        this.OrderTitle = baseClass.SpecialDecode(dataRow6["orderTitle"].ToString());
                        this.Eventname = dataRow6["Eventname"].ToString();
                        this.OrderedByName = string.Concat(dataRow6["FirstName"].ToString(), " ", dataRow6["LastName"].ToString());
                        if (Convert.ToInt64(dataRow6["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { dataRow6["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", dataRow6["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(dataRow6["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", dataRow6["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(dataRow6["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = dataRow6["Order_Behalf_UserID"].ToString();
                        }
                        int num10 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable7 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow6["OrderItemID"]));
                        foreach (DataRow row7 in dataTable7.Rows)
                        {
                            if (row7["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row7["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row7["UserFriendlyName"].ToString()), "<br/>");
                                if (row7["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", baseClass.SpecialDecode(row7["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(row7["Question"].ToString()), ": ", baseClass.SpecialDecode(row7["SelectedValue"].ToString()), "</div>" };
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
                            empty18 = "<tr><td width='150px' valign='top'>Additional Items: </td>";
                            empty18 = string.Concat(empty18, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        decimal num11 = Convert.ToDecimal(dataRow6["OrderItemTotalPrice"].ToString());
                        decimal num12 = Convert.ToDecimal(dataRow6["OrderItemTax"].ToString());
                        decimal num13 = num11;
                        decimal num14 = num13 + num12;
                        this.SUB_TOTAL = this.SUB_TOTAL + num11;
                        this.TAX_DETAILS = Convert.ToDecimal(dataRow6["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num13;
                        if (dataRow6["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow6["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (dataRow6["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow6["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (dataRow6["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow6["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (dataRow6["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow6["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (this.IsFromIndividualItems)
                        {
                            string orderItemIds1 = this.OrderItemIds;
                            chrArray = new char[] { ',' };
                            if (Array.IndexOf<string>(orderItemIds1.Split(chrArray), dataRow6["OrderItemID"].ToString()) <= -1)
                            {
                                continue;
                            }
                            if (empty18 != "")
                            {
                                stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                                stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (empty15 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["Order_Item_Number"].ToString()), "</td></tr>"));
                                }
                                if (str10 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CatalogueName"].ToString()), "</td></tr>"));
                                }
                                stringBuilder5.Append(empty18);
                                if (empty11 == "true")
                                {
                                    currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str11 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow6["Quantity"].ToString(), "</td></tr>"));
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
                                    currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str13 == "true")
                                {
                                    currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str15 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                                }
                                if (empty16 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CustomerCode"].ToString()), "</td></tr>"));
                                }
                                if (str16 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow6["SoldInPacksof"].ToString(), "</td></tr>"));
                                }

                                if (empty222 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow6["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                                }
                                if (str222 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMWeight"]), 2), "</td></tr>"));
                                }
                                if (empty223 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMMeasurement"]), 2), "</td></tr>"));
                                }
                                var orderedweight = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMWeight"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]); if (str223 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                                }
                                var OrderedCubicMeasurment = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMMeasurement"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]);
                                if (empty224 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                                }
                                if (str224 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["PerQuantity"]), 2), "</td></tr>"));
                                }
                                if (empty225 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                                }
                                //if (str225 == "true")
                                //{
                                //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow6["CBMWidth"].ToString(), "</td></tr>"));
                                //}
                                //if (empty226 == "true")
                                //{
                                //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow6["CBMHeight"].ToString(), "</td></tr>"));
                                //}


                                stringBuilder5.Append("</table><br/>");
                                stringBuilder5.Append("</div></div><div style='clear:both'>");
                            }
                            else
                            {
                                stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                                stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (empty15 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["Order_Item_Number"].ToString()), "</td></tr>"));
                                }
                                if (str10 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CatalogueName"].ToString()), "</td></tr>"));
                                }
                                if (empty11 == "true")
                                {
                                    currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str11 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow6["Quantity"].ToString(), "</td></tr>"));
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
                                    currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str13 == "true")
                                {
                                    currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                    stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                                }
                                if (str15 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                                }
                                if (empty16 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CustomerCode"].ToString()), "</td></tr>"));
                                }
                                if (str16 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow6["SoldInPacksof"].ToString(), "</td></tr>"));
                                }

                                if (empty222 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow6["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                                }
                                if (str222 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMWeight"]), 2), "</td></tr>"));
                                }
                                if (empty223 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMMeasurement"]), 2), "</td></tr>"));
                                }
                                var orderedweight = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMWeight"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]); if (str223 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                                }
                                var OrderedCubicMeasurment = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMMeasurement"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]);
                                if (empty224 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                                }
                                if (str224 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["PerQuantity"]), 2), "</td></tr>"));
                                }
                                if (empty225 == "true")
                                {
                                    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                                }
                                //if (str225 == "true")
                                //{
                                //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow6["CBMWidth"].ToString(), "</td></tr>"));
                                //}
                                //if (empty226 == "true")
                                //{
                                //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow6["CBMHeight"].ToString(), "</td></tr>"));
                                //}

                                stringBuilder5.Append("</table><br/>");
                                stringBuilder5.Append("</div></div><div style='clear:both'>");
                            }
                        }
                        else if (empty18 != "")
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["Order_Item_Number"].ToString()), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder5.Append(empty18);
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow6["Quantity"].ToString(), "</td></tr>"));
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
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow6["SoldInPacksof"].ToString(), "</td></tr>"));
                            }

                            if (empty222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow6["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMWeight"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMMeasurement"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow6["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow6["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder5.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["Order_Item_Number"].ToString()), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow6["Quantity"].ToString(), "</td></tr>"));
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
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow6["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow6["SoldInPacksof"].ToString(), "</td></tr>"));
                            }

                            if (empty222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow6["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMWeight"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow6["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow6["CBMMeasurement"]) / Convert.ToDouble(dataRow6["PerQuantity"])) * Convert.ToDouble(dataRow6["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow6["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                         
                            stringBuilder5.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    storeEmail tOTAL2 = this;
                    tOTAL2.TOTAL = tOTAL2.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL3 = this;
                    tOTAL3.TOTAL = tOTAL3.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
                if (lower == "true")
                {
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", "");
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", "");
                }
                else
                {
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.emailSubject = this.emailSubject.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                if (lower == "true")
                {
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", "");
                }
                else
                {
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                }
                this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                chrArray = new char[] { 'Ð' };
                string[] strArrays4 = empty1.Split(chrArray);
                string pdfFile1 = storeEmail.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays5 = pdfFile1.Split(chrArray);
                string empty19 = string.Empty;
                if (empty1 != "")
                {
                    for (int k = 0; k < (int)strArrays5.Length; k++)
                    {
                        if ((int)strArrays4.Length == (int)strArrays5.Length && strArrays4[k].ToString().Trim() != "")
                        {
                            string str20 = strArrays4[k].ToString();
                            chrArray = new char[] { '\u00A7' };
                            string[] strArrays6 = str20.Split(chrArray);
                            empty1 = strArrays6[0].ToString();
                            string str21 = strArrays6[1].ToString();
                            storeEmail.Pdf_File = strArrays5[k].ToString();
                            if (str21 != "et")
                            {
                                keySeparator = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                                empty19 = string.Concat(keySeparator);
                            }
                            else if (EmailFor.ToLower() != "admin")
                            {
                                keySeparator = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty19 = string.Concat(keySeparator);
                            }
                            else
                            {
                                keySeparator = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty19 = string.Concat(keySeparator);
                            }
                        }
                    }
                }
                storeEmail.Pdf_File = "";
                if (lower == "true")
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", "");
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                }
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                if (lower == "true")
                {
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                }
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder5.ToString());
                this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", baseClass.SpecialDecode(this.Cart_AdditionalOptionName));
                if (lower != "false")
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", baseClass.SpecialDecode(this.Cart_AdditionalOptionValue));
                }
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", baseClass.SpecialDecode(this.Cart_AdditionalOption));
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty19);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                foreach (DataRow dataRow7 in dataTable5.Rows)
                {
                    str1 = dataRow7["AddressLabel"].ToString();
                    empty2 = dataRow7["AddressLine1"].ToString();
                    str2 = dataRow7["AddressLine2"].ToString();
                    empty3 = dataRow7["Address2"].ToString();
                    str3 = dataRow7["Address3"].ToString();
                    empty4 = dataRow7["Address4"].ToString();
                    str4 = dataRow7["Country"].ToString();
                    empty5 = dataRow7["Phone"].ToString();
                    str5 = dataRow7["Fax"].ToString();
                }
                foreach (DataRow row8 in dataTable6.Rows)
                {
                    empty6 = row8["AddressLabel"].ToString();
                    str6 = row8["AddressLine1"].ToString();
                    empty7 = row8["AddressLine2"].ToString();
                    str7 = row8["Address2"].ToString();
                    empty8 = row8["Address3"].ToString();
                    str8 = row8["Address4"].ToString();
                    empty9 = row8["Country"].ToString();
                    str9 = row8["Phone"].ToString();
                    empty10 = row8["Fax"].ToString();
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
            else if (Type.ToLower().Trim() == "backorder")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                string empty20 = string.Empty;
                StringBuilder stringBuilder10 = new StringBuilder();
                StringBuilder stringBuilder11 = new StringBuilder();
                StringBuilder stringBuilder12 = new StringBuilder();
                StringBuilder stringBuilder13 = new StringBuilder();
                StringBuilder stringBuilder14 = new StringBuilder();
                this.TagBody = "";
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new object[] { sitePath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, this.Account_ID, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow8 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    storeEmail _storeEmail6 = this;
                    cartAdditionalOptionName = _storeEmail6.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow8["WebOtherCostName"].ToString(), "- ", dataRow8["SelectedValue"].ToString(), "<br />" };
                    _storeEmail6.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail7 = this;
                    _storeEmail7.Cart_AdditionalOptionValue = string.Concat(_storeEmail7.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow8["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail8 = this;
                    cartAdditionalOptionName = _storeEmail8.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, dataRow8["WebOtherCostName"].ToString(), "- ", dataRow8["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow8["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail8.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                    storeEmail cartAdditionalOV2 = this;
                    cartAdditionalOV2.Cart_Additional_OV = cartAdditionalOV2.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow8["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                DataTable dataTable8 = new DataTable();
                DataTable dataTable9 = new DataTable();
                foreach (DataRow row9 in dtEmail.Rows)
                {
                    this.emailSubject = row9["Subject"].ToString();
                    this.TagBody = row9["Body"].ToString();
                    foreach (DataRow dataRow9 in dtBody.Rows)
                    {
                        dataTable8 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow9["BillingAddressID"]));
                        dataTable9 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow9["ShippingAddressID"]));
                        this.AccountName = baseClass.SpecialDecode(dataRow9["accountName"].ToString());
                        storeEmail.order_No = dataRow9["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow9["createdBy"].ToString());
                        this.Eventname = dataRow9["Eventname"].ToString();
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow9["CatalogueName"].ToString(), "Ð");
                        if (dataRow9["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, dataRow9["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (dataRow9["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, dataRow9["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow9["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow9["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.OrderTitle = baseClass.SpecialDecode(dataRow9["orderTitle"].ToString());
                        this.Comments = dataRow9["Comments"].ToString().Replace("\n", "<br />");
                        this.customerName = string.Concat(dataRow9["FirstName"].ToString(), " ", dataRow9["LastName"].ToString());
                        this.OrderedByName = string.Concat(dataRow9["FirstName"].ToString(), " ", dataRow9["LastName"].ToString());
                        if (Convert.ToInt64(dataRow9["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { dataRow9["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", dataRow9["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(dataRow9["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", dataRow9["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(dataRow9["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = dataRow9["Order_Behalf_UserID"].ToString();
                        }
                        int num15 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable10 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow9["OrderItemID"]));
                        foreach (DataRow row10 in dataTable10.Rows)
                        {
                            if (row10["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row10["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row10["UserFriendlyName"].ToString()), "<br/>");
                                if (row10["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", baseClass.SpecialDecode(row10["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(row10["Question"].ToString()), ": ", baseClass.SpecialDecode(row10["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num15++;
                        }
                        if (num15 == 0)
                        {
                            empty20 = "";
                        }
                        else if (str14 == "true")
                        {
                            empty20 = "<tr><td width='150px' valign='top'>Additional Items: </td>";
                            empty20 = string.Concat(empty20, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        decimal num16 = Convert.ToDecimal(dataRow9["OrderItemTotalPrice"].ToString());
                        decimal num17 = Convert.ToDecimal(dataRow9["OrderItemTax"].ToString());
                        decimal num18 = num16;
                        decimal num19 = num18 + num17;
                        this.SUB_TOTAL = this.SUB_TOTAL + num16;
                        this.TAX_DETAILS = Convert.ToDecimal(dataRow9["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num18;
                        if (dataRow9["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow9["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (dataRow9["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow9["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (dataRow9["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow9["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (dataRow9["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow9["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (empty20 != "")
                        {
                            stringBuilder10.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            if (!Convert.ToBoolean(dataRow9["OrderItemBackOrder"]))
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CatalogueName"].ToString()), "</td></tr>"));
                                }
                            }
                            else
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CatalogueName"].ToString()), "&nbsp;*BACK ORDER*</td></tr>"));
                                }
                            }
                            stringBuilder10.Append(empty20);
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["JobName"].ToString()), "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["Quantity"].ToString()), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow9["SoldInPacksof"].ToString(), "</td></tr>"));
                            }
                            if (empty222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow9["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow9["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow9["CBMWeight"]) / Convert.ToDouble(dataRow9["PerQuantity"])) * Convert.ToDouble(dataRow9["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow9["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow9["CBMMeasurement"]) / Convert.ToDouble(dataRow9["PerQuantity"])) * Convert.ToDouble(dataRow9["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow9["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow9["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow9["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            stringBuilder10.Append("</table><br/>");
                            stringBuilder10.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder10.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            if (!Convert.ToBoolean(dataRow9["OrderItemBackOrder"]))
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CatalogueName"].ToString()), "</td></tr>"));
                                }
                            }
                            else
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CatalogueName"].ToString()), "&nbsp;*BACK ORDER*</td></tr>"));
                                }
                            }
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["JobName"].ToString()), "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow9["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow9["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", dataRow9["SoldInPacksof"].ToString(), "</td></tr>"));
                            }
                            if (empty222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", dataRow9["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(dataRow9["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow9["CBMWeight"]) / Convert.ToDouble(dataRow9["PerQuantity"])) * Convert.ToDouble(dataRow9["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(dataRow9["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(dataRow9["CBMMeasurement"]) / Convert.ToDouble(dataRow9["PerQuantity"])) * Convert.ToDouble(dataRow9["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(dataRow9["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow9["CBMLength"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow9["CBMWidth"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow9["CBMHeight"]), 2), " ", dataTable1.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            stringBuilder10.Append("</table><br/>");
                            stringBuilder10.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    storeEmail tOTAL4 = this;
                    tOTAL4.TOTAL = tOTAL4.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL5 = this;
                    tOTAL5.TOTAL = tOTAL5.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
                if (lower == "true")
                {
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", "");
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", "");
                }
                else
                {
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.emailSubject = this.emailSubject.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                if (lower == "true")
                {
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", "");
                }
                else
                {
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                }
                this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                chrArray = new char[] { 'Ð' };
                string[] strArrays7 = empty1.Split(chrArray);
                string pdfFile2 = storeEmail.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays8 = pdfFile2.Split(chrArray);
                string empty21 = string.Empty;
                if (empty1 != "")
                {
                    for (int l = 0; l < (int)strArrays8.Length; l++)
                    {
                        if ((int)strArrays7.Length == (int)strArrays8.Length && strArrays7[l].ToString().Trim() != "")
                        {
                            string str22 = strArrays7[l].ToString();
                            chrArray = new char[] { '\u00A7' };
                            string[] strArrays9 = str22.Split(chrArray);
                            empty1 = strArrays9[0].ToString();
                            string str23 = strArrays9[1].ToString();
                            storeEmail.Pdf_File = strArrays8[l].ToString();
                            if (str23 != "et")
                            {
                                keySeparator = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                                empty21 = string.Concat(keySeparator);
                            }
                            else if (EmailFor.ToLower() != "admin")
                            {
                                keySeparator = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty21 = string.Concat(keySeparator);
                            }
                            else
                            {
                                keySeparator = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty21 = string.Concat(keySeparator);
                            }
                        }
                    }
                }
                storeEmail.Pdf_File = "";
                if (lower == "true")
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", "");
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                }
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$CUSTOMER_NAME$]", baseClass.SpecialDecode(this.customerName));
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                if (lower == "true")
                {
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                }
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder10.ToString());
                this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                if (lower != "false")
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                }
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty21);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                foreach (DataRow dataRow10 in dataTable8.Rows)
                {
                    str1 = dataRow10["AddressLabel"].ToString();
                    empty2 = dataRow10["AddressLine1"].ToString();
                    str2 = dataRow10["AddressLine2"].ToString();
                    empty3 = dataRow10["Address2"].ToString();
                    str3 = dataRow10["Address3"].ToString();
                    empty4 = dataRow10["Address4"].ToString();
                    str4 = dataRow10["Country"].ToString();
                    empty5 = dataRow10["Phone"].ToString();
                    str5 = dataRow10["Fax"].ToString();
                }
                foreach (DataRow row11 in dataTable9.Rows)
                {
                    empty6 = row11["AddressLabel"].ToString();
                    str6 = row11["AddressLine1"].ToString();
                    empty7 = row11["AddressLine2"].ToString();
                    str7 = row11["Address2"].ToString();
                    empty8 = row11["Address3"].ToString();
                    str8 = row11["Address4"].ToString();
                    empty9 = row11["Country"].ToString();
                    str9 = row11["Phone"].ToString();
                    empty10 = row11["Fax"].ToString();
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
                StringBuilder stringBuilder15 = new StringBuilder();
                QueryString queryString = new QueryString()
                {
                    { "userID", this.StoreUser_ID.ToString() },
                    { "AccountID", this.Account_ID.ToString() }
                };
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                this.loginLink = string.Concat(sitePath, "userregisterapproval.aspx", queryString1.ToString());
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to Approve the User</a>");
                foreach (DataRow dataRow11 in dtBody.Rows)
                {
                    string str24 = new string('*', dataRow11["Password"].ToString().Length);
                    stringBuilder15.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["MiddleName"].ToString()), "</td></tr>"));
                    if (this.DeptScreenName != "")
                    {
                        currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>", this.DeptScreenName, ":</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["Department"].ToString()), "</td></tr>" };
                        stringBuilder15.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else
                    {
                        stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["Department"].ToString()), "</td></tr>"));
                    }
                    currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["HomeAddressLine1"].ToString()), "<br/>", baseClass.SpecialDecode(dataRow11["HomeAddressLine2"].ToString()), "<br/>", baseClass.SpecialDecode(dataRow11["HomeAddressLine3"].ToString()), "<br/>", baseClass.SpecialDecode(dataRow11["HomeAddressLine4"].ToString()), "<br/>", baseClass.SpecialDecode(dataRow11["AddressLine2"].ToString()), "</td></tr>" };
                    stringBuilder15.Append(string.Concat(currencyinRequiredFormate));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["HomeCountry"].ToString()), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", baseClass.SpecialDecode(dataRow11["HomeTelephone"].ToString()), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", dataRow11["Fax"].ToString(), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", dataRow11["Email"].ToString(), "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", str24, "</td></tr>"));
                    stringBuilder15.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", dataRow11["DesignatedApproverEmail"].ToString().Replace(",", "<br/>"), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", dataRow11["FirstName"].ToString());
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", dataRow11["LastName"].ToString());
                    this.emailFrom = dataRow11["Email"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder15.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "new b2b contact registration")
            {
                StringBuilder stringBuilder16 = new StringBuilder();
                string empty22 = string.Empty;
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(sitePath, "login.aspx?id=", this.Account_ID);
                }
                else
                {
                    this.loginLink = string.Concat(sitePath, "login.aspx?id=", this.Account_ID);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
                foreach (DataRow row12 in dtBody.Rows)
                {
                    stringBuilder16.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(row12["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(row12["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(row12["MiddleName"].ToString()), "</td></tr>"));
                    if (this.DeptScreenName != "")
                    {
                        currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>", this.DeptScreenName, ":</td><td valign='top'>", baseClass.SpecialDecode(row12["Department"].ToString()), "</td></tr>" };
                        stringBuilder16.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else
                    {
                        stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(row12["Department"].ToString()), "</td></tr>"));
                    }
                    currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(row12["HomeAddressLine1"].ToString()), "<br/>", row12["HomeAddressLine2"].ToString(), "<br/>", row12["HomeAddressLine3"].ToString(), "<br/>", row12["HomeAddressLine4"].ToString(), "<br/>", row12["AddressLine2"].ToString(), "</td></tr>" };
                    stringBuilder16.Append(string.Concat(currencyinRequiredFormate));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(row12["HomeCountry"].ToString()), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", row12["HomeTelephone"].ToString(), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top' colspan='3'>", row12["Fax"].ToString(), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", row12["Email"].ToString(), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", row12["Password"].ToString(), "</td></tr>"));
                    stringBuilder16.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", row12["DesignatedApproverEmail"].ToString().Replace(",", "<br/>"), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$CONTACT_EMAIL$]", row12["Email"].ToString());
                    this.TagBody = this.TagBody.Replace("[$CONTACT_PASSWORD$]", row12["Password"].ToString());
                    empty22 = string.Concat(baseClass.SpecialDecode(row12["FirstName"].ToString()), " ", baseClass.SpecialDecode(row12["LastName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$CONTACT_NAME$]", empty22);
                    this.emailFrom = row12["DesignatedApproverEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_NAME$]", empty22);
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder16.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modification")
            {
                StringBuilder stringBuilder17 = new StringBuilder();
                QueryString queryString2 = new QueryString()
                {
                    { "userID", this.StoreUser_ID.ToString() },
                    { "AccountID", this.Account_ID.ToString() }
                };
                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                this.loginLink = string.Concat(sitePath, "userprofileapproval.aspx", queryString3.ToString());
                this.loginLink = string.Concat("<a href=", this.loginLink, ">click here to approve the user profile modification</a>");
                foreach (DataRow dataRow12 in dtBody.Rows)
                {
                    string str25 = new string('*', dataRow12["Password"].ToString().Length);
                    stringBuilder17.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Home Address:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["AddressLabel"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address1:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Address1"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address2:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Address2"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address3:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Address3"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address4:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Address4"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address5:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Address5"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(dataRow12["Country"].ToString()), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Telephone:</td><td valign='top'>", dataRow12["Telephone"].ToString(), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", dataRow12["Fax"].ToString(), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", dataRow12["EmailID"].ToString(), "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", str25, "</td></tr>"));
                    stringBuilder17.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", dataRow12["DesignatedApprovedEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", dataRow12["FirstName"].ToString());
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", dataRow12["LastName"].ToString());
                    this.emailFrom = dataRow12["EmailID"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_PROFILE_FIELDS$]", stringBuilder17.ToString());
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modified approved")
            {
                StringBuilder stringBuilder18 = new StringBuilder();
                foreach (DataRow row13 in dtBody.Rows)
                {
                    stringBuilder18.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(row13["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(row13["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Home Address:</td><td valign='top'>", baseClass.SpecialDecode(row13["AddressLabel"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address1:</td><td valign='top'>", baseClass.SpecialDecode(row13["Address1"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address2:</td><td valign='top'>", baseClass.SpecialDecode(row13["Address2"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address3:</td><td valign='top'>", baseClass.SpecialDecode(row13["Address3"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address4:</td><td valign='top'>", baseClass.SpecialDecode(row13["Address4"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address5:</td><td valign='top'>", baseClass.SpecialDecode(row13["Address5"].ToString()), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", row13["Country"].ToString(), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Telephone:</td><td valign='top'>", row13["Telephone"].ToString(), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", row13["Fax"].ToString(), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", row13["EmailID"].ToString(), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", row13["Password"].ToString(), "</td></tr>"));
                    stringBuilder18.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", row13["DesignatedApprovedEmail"].ToString(), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(row13["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(row13["LastName"].ToString()));
                    this.emailFrom = row13["DesignatedApprovedEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_PROFILE_FIELDS$]", stringBuilder18.ToString());
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b user profile modified rejected")
            {
                foreach (DataRow dataRow13 in dtBody.Rows)
                {
                    this.emailFrom = dataRow13["DesignatedApprovedEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$REJECT_REASON$]", baseClass.SpecialDecode(this.RejectedReason));
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower() == "b2b new user registration approval pending")
            {
                StringBuilder stringBuilder19 = new StringBuilder();
                foreach (DataRow row14 in dtBody.Rows)
                {
                    stringBuilder19.Append("<table border='1' cellpadding='3' cellspacing='0' style='font-family:arial;font-size:12px'>");
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>First Name:</td><td valign='top'>", baseClass.SpecialDecode(row14["FirstName"].ToString()), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Last Name:</td><td valign='top'>", baseClass.SpecialDecode(row14["Lastname"].ToString()), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Middle Name:</td><td valign='top'>", baseClass.SpecialDecode(row14["MiddleName"].ToString()), "</td></tr>"));
                    if (this.DeptScreenName != "")
                    {
                        currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>", this.DeptScreenName, ":</td><td valign='top'>", baseClass.SpecialDecode(row14["Department"].ToString()), "</td></tr>" };
                        stringBuilder19.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else
                    {
                        stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Department:</td><td valign='top'>", baseClass.SpecialDecode(row14["Department"].ToString()), "</td></tr>"));
                    }
                    currencyinRequiredFormate = new string[] { "<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Address:</td><td valign='top'>", baseClass.SpecialDecode(row14["HomeAddressLine1"].ToString()), "<br/>", baseClass.SpecialDecode(row14["HomeAddressLine2"].ToString()), "<br/>", baseClass.SpecialDecode(row14["HomeAddressLine3"].ToString()), "<br/>", baseClass.SpecialDecode(row14["HomeAddressLine4"].ToString()), "<br/>", baseClass.SpecialDecode(row14["AddressLine2"].ToString()), "</td></tr>" };
                    stringBuilder19.Append(string.Concat(currencyinRequiredFormate));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Country:</td><td valign='top'>", baseClass.SpecialDecode(row14["HomeCountry"].ToString()), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Contact No:</td><td valign='top'>", baseClass.SpecialDecode(row14["HomeTelephone"].ToString()), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Fax:</td><td valign='top'>", row14["Fax"].ToString(), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Email:</td><td valign='top'>", row14["Email"].ToString(), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Password:</td><td valign='top'>", row14["Password"].ToString(), "</td></tr>"));
                    stringBuilder19.Append(string.Concat("<tr style='height: 25px'><td valign='top' width='100px' style='font-weight:bold'>Approver Email:</td><td valign='top'>", row14["DesignatedApproverEmail"].ToString().Replace(",", "<br/>"), "</td></tr></table>"));
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(row14["FirstName"].ToString()));
                    this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", baseClass.SpecialDecode(row14["LastName"].ToString()));
                    this.emailFrom = row14["DesignatedApproverEmail"].ToString();
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ALL_REGISTRATION_FIELDS$]", stringBuilder19.ToString());
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "new b2b order")
            {
                this.TAX_DETAILS = new decimal(0);
                this.SUB_TOTAL = new decimal(0);
                this.TOTAL = new decimal(0);
                string empty23 = string.Empty;
                StringBuilder stringBuilder20 = new StringBuilder();
                StringBuilder stringBuilder21 = new StringBuilder();
                StringBuilder stringBuilder22 = new StringBuilder();
                StringBuilder stringBuilder23 = new StringBuilder();
                StringBuilder stringBuilder24 = new StringBuilder();
                StringBuilder stringBuilder25 = new StringBuilder();
                this.TagBody = "";
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow14 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    storeEmail _storeEmail9 = this;
                    cartAdditionalOptionName = _storeEmail9.Cart_AdditionalOptionName;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(dataRow14["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(dataRow14["SelectedValue"].ToString()), "<br />" };
                    _storeEmail9.Cart_AdditionalOptionName = string.Concat(currencyinRequiredFormate);
                    storeEmail _storeEmail10 = this;
                    _storeEmail10.Cart_AdditionalOptionValue = string.Concat(_storeEmail10.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow14["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail11 = this;
                    cartAdditionalOptionName = _storeEmail11.Cart_AdditionalOption;
                    currencyinRequiredFormate = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(dataRow14["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(dataRow14["SelectedValue"].ToString()), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow14["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail11.Cart_AdditionalOption = string.Concat(currencyinRequiredFormate);
                    storeEmail cartAdditionalOV3 = this;
                    cartAdditionalOV3.Cart_Additional_OV = cartAdditionalOV3.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow14["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                foreach (DataRow row15 in dtEmail.Rows)
                {
                    this.emailSubject = row15["Subject"].ToString();
                    this.TagBody = row15["Body"].ToString();
                    DataTable dataTable11 = new DataTable();
                    DataTable dataTable12 = new DataTable();
                    foreach (DataRow dataRow15 in dtBody.Rows)
                    {
                        dataTable11 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow15["BillingAddressID"]));
                        dataTable12 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow15["ShippingAddressID"]));
                        this.AccountName = dataRow15["accountName"].ToString();
                        storeEmail.order_No = dataRow15["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow15["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow15["CatalogueName"].ToString(), "Ð");
                        this.Eventname = dataRow15["Eventname"].ToString();
                        this.user_firstname = dataRow15["FirstName"].ToString();
                        if (dataRow15["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, dataRow15["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (dataRow15["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, dataRow15["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow15["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow15["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = baseClass.SpecialDecode(dataRow15["Comments"].ToString().Replace("\n", "<br />"));
                        this.customerName = baseClass.SpecialDecode(string.Concat(dataRow15["FirstName"].ToString(), " ", dataRow15["LastName"].ToString()));
                        this.OrderTitle = baseClass.SpecialDecode(dataRow15["orderTitle"].ToString());
                        if (Convert.ToInt64(dataRow15["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { dataRow15["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", dataRow15["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(dataRow15["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", dataRow15["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(dataRow15["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = dataRow15["Order_Behalf_UserID"].ToString();
                        }
                        int num20 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable13 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow15["OrderItemID"]));
                        foreach (DataRow row16 in dataTable13.Rows)
                        {
                            if (row16["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row16["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(row16["UserFriendlyName"].ToString()), "<br/>");
                                if (row16["Question"].ToString() == "")
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", baseClass.SpecialDecode(row16["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                                else
                                {
                                    currencyinRequiredFormate = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", baseClass.SpecialDecode(row16["Question"].ToString()), ": ", baseClass.SpecialDecode(row16["SelectedValue"].ToString()), "</div>" };
                                    this.additionalProductDetails = string.Concat(currencyinRequiredFormate);
                                }
                            }
                            num20++;
                        }
                        if (num20 == 0)
                        {
                            empty23 = "";
                        }
                        else if (str14 == "true")
                        {
                            empty23 = "<tr><td width='150px' valign='top'>Additional Items: </td>";
                            empty23 = string.Concat(empty23, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
                        }
                        decimal num21 = Convert.ToDecimal(dataRow15["OrderItemTotalPrice"].ToString());
                        decimal num22 = Convert.ToDecimal(dataRow15["OrderItemTax"].ToString());
                        decimal num23 = num21;
                        decimal num24 = num23 + num22;
                        this.SUB_TOTAL = this.SUB_TOTAL + num21;
                        this.TAX_DETAILS = Convert.ToDecimal(dataRow15["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num23;
                        if (dataRow15["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow15["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (dataRow15["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow15["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (dataRow15["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow15["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (dataRow15["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(dataRow15["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (empty23 != "")
                        {
                            stringBuilder20.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder20.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty15 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["Order_Item_Number"].ToString()), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder20.Append(empty23);
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["JobName"].ToString()), "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow15["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num24, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            stringBuilder20.Append("</table><br/>");
                            stringBuilder20.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder20.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder20.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty15 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["Order_Item_Number"].ToString()), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow15["JobName"].ToString()), "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow15["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num24, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: <td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder20.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: <td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            if (str13 == "true")
                            {
                                currencyinRequiredFormate = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable1.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder20.Append(string.Concat(currencyinRequiredFormate));
                            }
                            stringBuilder20.Append("</table><br/>");
                            stringBuilder20.Append("</div></div><div style='clear:both'>");
                        }
                        this.emailFrom = dataRow15["EmailID"].ToString();
                    }
                    foreach (DataRow dataRow16 in dataTable11.Rows)
                    {
                        str1 = dataRow16["AddressLabel"].ToString();
                        empty2 = dataRow16["AddressLine1"].ToString();
                        str2 = dataRow16["AddressLine2"].ToString();
                        empty3 = dataRow16["Address2"].ToString();
                        str3 = dataRow16["Address3"].ToString();
                        empty4 = dataRow16["Address4"].ToString();
                        str4 = dataRow16["Country"].ToString();
                        empty5 = dataRow16["Phone"].ToString();
                        str5 = dataRow16["Fax"].ToString();
                    }
                    foreach (DataRow row17 in dataTable12.Rows)
                    {
                        empty6 = row17["AddressLabel"].ToString();
                        str6 = row17["AddressLine1"].ToString();
                        empty7 = row17["AddressLine2"].ToString();
                        str7 = row17["Address2"].ToString();
                        empty8 = row17["Address3"].ToString();
                        str8 = row17["Address4"].ToString();
                        empty9 = row17["Country"].ToString();
                        str9 = row17["Phone"].ToString();
                        empty10 = row17["Fax"].ToString();
                    }
                    storeEmail tOTAL6 = this;
                    tOTAL6.TOTAL = tOTAL6.TOTAL + this.Cart_Additional_OV;
                    storeEmail tOTAL7 = this;
                    tOTAL7.TOTAL = tOTAL7.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                    if (lower == "true")
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", "");
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", "");
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", "");
                    }
                    else
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
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
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                    this.emailSubject = this.emailSubject.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(this.user_firstname));
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
                    this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                }
                if (this.Approver_Type != "u")
                {
                    this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    this.orderLink = string.Concat(sitePath, "orderapproval.aspx?OrdKey=", this.OrderKey);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to View & Approve the order</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                chrArray = new char[] { 'Ð' };
                string[] strArrays10 = empty1.Split(chrArray);
                string pdfFile3 = storeEmail.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays11 = pdfFile3.Split(chrArray);
                string empty24 = string.Empty;
                if (empty1 != "")
                {
                    for (int m = 0; m < (int)strArrays11.Length; m++)
                    {
                        if ((int)strArrays10.Length == (int)strArrays11.Length && strArrays10[m].ToString().Trim() != "")
                        {
                            string str26 = strArrays10[m].ToString();
                            chrArray = new char[] { '\u00A7' };
                            string[] strArrays12 = str26.Split(chrArray);
                            empty1 = strArrays12[0].ToString();
                            string str27 = strArrays12[1].ToString();
                            storeEmail.Pdf_File = strArrays11[m].ToString();
                            if (str27 != "et")
                            {
                                keySeparator = new object[] { empty24, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=pr'>", storeEmail.Pdf_File, "</a></div>" };
                                empty24 = string.Concat(keySeparator);
                            }
                            else if (EmailFor.ToLower() != "admin")
                            {
                                keySeparator = new object[] { empty24, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty24 = string.Concat(keySeparator);
                            }
                            else
                            {
                                keySeparator = new object[] { empty24, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", storeEmail.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                                empty24 = string.Concat(keySeparator);
                            }
                        }
                    }
                }
                storeEmail.Pdf_File = "";
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", baseClass.SpecialDecode(this.customerName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", baseClass.SpecialDecode(storeEmail.order_No));
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", baseClass.SpecialDecode(this.orderDate));
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", baseClass.SpecialDecode(this.RequiredBy));
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder20.ToString());
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty24);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY_EMAIL$]", this.emailFrom);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", baseClass.SpecialDecode(this.Comments));
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                if (lower != "false")
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                }
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", baseClass.SpecialDecode(this.user_firstname));
                if (lower == "true")
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", "");
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", "");
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", "");
                }
                else
                {
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                }
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "b2b user order approval")
            {
                this.TagBody = "";
                foreach (DataRow dataRow17 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow17["Subject"].ToString();
                    this.TagBody = dataRow17["Body"].ToString();
                    foreach (DataRow row18 in dtBody.Rows)
                    {
                        this.AccountName = baseClass.SpecialDecode(row18["accountName"].ToString());
                        storeEmail.order_No = baseClass.SpecialDecode(row18["OrderNo"].ToString());
                        this.OrderKey = baseClass.SpecialDecode(row18["OrderKey"].ToString());
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row18["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.emailFrom = row18["ApproverEmail"].ToString();
                        this.OrderedByName = string.Concat(row18["FirstName"].ToString(), " ", row18["LastName"].ToString());
                        this.Eventname = row18["Eventname"].ToString();
                        if (Convert.ToInt64(row18["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { row18["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", row18["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(row18["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", row18["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(row18["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = row18["Order_Behalf_UserID"].ToString();
                        }
                    }
                }
                this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "b2b user order rejection")
            {
                this.TagBody = "";
                foreach (DataRow dataRow18 in dtEmail.Rows)
                {
                    this.emailSubject = baseClass.SpecialDecode(dataRow18["Subject"].ToString());
                    this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    this.TagBody = dataRow18["Body"].ToString();
                    foreach (DataRow row19 in dtBody.Rows)
                    {
                        this.AccountName = baseClass.SpecialDecode(row19["accountName"].ToString());
                        storeEmail.order_No = row19["OrderNo"].ToString();
                        this.OrderKey = row19["OrderKey"].ToString();
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row19["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RejectedReason = row19["RejectReason"].ToString();
                        this.emailFrom = row19["ApproverEmail"].ToString();
                        this.OrderedByName = string.Concat(row19["FirstName"].ToString(), " ", row19["LastName"].ToString());
                        this.Eventname = row19["Eventname"].ToString();
                        if (Convert.ToInt64(row19["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { row19["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, " for the attention of ", row19["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(row19["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", row19["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(row19["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = row19["Order_Behalf_UserID"].ToString();
                        }
                    }
                }
                this.orderLink = string.Concat(sitePath, "order.aspx?OrdKey=", this.OrderKey);
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$ORDER_ID$]", storeEmail.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$REJECT_REASON$]", baseClass.SpecialDecode(this.RejectedReason));
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            else if (Type.ToLower().Trim() == "b2b new user rejection")
            {
                this.TagBody = "";
                foreach (DataRow dataRow19 in dtEmail.Rows)
                {
                    this.emailSubject = baseClass.SpecialDecode(dataRow19["Subject"].ToString());
                    this.TagBody = dataRow19["Body"].ToString();
                    foreach (DataRow row20 in dtBody.Rows)
                    {
                        this.EmailID = row20["EmailID"].ToString();
                        this.Pwd = row20["Password"].ToString();
                        this.RejectedReason = row20["RejectedReason"].ToString();
                        this.CreatedDate = this.comm.Eprint_return_Date_Before_View(row20["CreatedDate"].ToString(), CompanyID, this.UserID, false);
                        this.emailFrom = row20["DesignatedApproverEmail"].ToString();
                    }
                }
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$STORE$]", baseClass.SpecialDecode(storeEmail.storeName));
                this.TagBody = this.TagBody.Replace("[$EMAIL_ID$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_REGISTRATION$]", this.CreatedDate);
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
            BaseClass baseClass = new BaseClass();
            string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
            string str1 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
            string str2 = from;
            string empty = string.Empty;
            long num = (long)0;
            if (HttpContext.Current.Session["userID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["userID"].ToString());
            }
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
            try
            {
                empty = storeEmail.storeName;
            }
            catch
            {
                empty = "support@eprintsoftware.com";
            }
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
            sqlCommand.Parameters.AddWithValue("@ReplyTo", baseClass.SpecialDecode(str3));
            sqlCommand.Parameters.AddWithValue("@ToEmails", baseClass.SpecialDecode(to));
            sqlCommand.Parameters.AddWithValue("@CCEmails", baseClass.SpecialDecode(cc));
            sqlCommand.Parameters.AddWithValue("@BCCEmails", baseClass.SpecialDecode(bcc));
            sqlCommand.Parameters.AddWithValue("@EmailSubject", baseClass.SpecialDecode(subject));
            sqlCommand.Parameters.AddWithValue("@EmailBody", baseClass.SpecialDecode(body));
            sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
            sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
            sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
            SqlParameterCollection parameters = sqlCommand.Parameters;
            DateTime now = DateTime.Now;
            parameters.AddWithValue("@CreatedOn", now.ToString());
            sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
            sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
            sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
            sqlCommand.Parameters.AddWithValue("@StoreName", baseClass.SpecialDecode(storeEmail.storeName));
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