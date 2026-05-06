using nmsCommon;
using nmsConnection;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.SessionState;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;

namespace nmsEmail
{
    public class EmailClass
    {
        private commonclass comm = new commonclass();

        private ConnectionClass objcon = new ConnectionClass();

        private loginclass objlogin = new loginclass();

        public static string order_No;

        public static string storeName;

        public static string donotreplay;

        public string RequiredBy = string.Empty;

        public string Comments = string.Empty;

        public string TagBody = string.Empty;

        public string orderDate = string.Empty;

        public string orderLink = string.Empty;

        public string strSitepath = string.Empty;

        public string eprintDocument = string.Empty;

        public string EmailEnable = string.Empty;

        public string productDetails = string.Empty;

        public string additionalProductDetails = string.Empty;

        public string additionalProductDetails_Email = string.Empty;

        public string emailFrom = string.Empty;

        public string emailTo = string.Empty;

        public string emailBCC = string.Empty;

        public string emailCC = string.Empty;

        public string emailSubject = string.Empty;

        public string emailBody = string.Empty;

        public string emailAttachment = string.Empty;

        public string email_return_body = string.Empty;

        public string customerName = string.Empty;

        public string emailfor = string.Empty;

        public string AccountName = string.Empty;

        public string Cart_AdditionalOptionName = string.Empty;

        public string Cart_AdditionalOptionValue = string.Empty;

        public string Cart_AdditionalOption = string.Empty;

        public string JOB_REFCODE = string.Empty;

        public string FirstName = string.Empty;

        public string LastName = string.Empty;

        public string EmailID = string.Empty;

        public long EmailToCustomerID;

        public string Pwd = string.Empty;

        public string ContactName = string.Empty;

        public string loginLink = string.Empty;

        public string loginSubject = string.Empty;

        public string OrderKey = string.Empty;

        public int Company_ID;

        public int Account_ID;

        public int UserID;

        public long StoreUser_ID;

        public long DefaultBillingID;

        private decimal SUB_TOTAL;

        private decimal TAX_DETAILS;

        private decimal TOTAL;

        private decimal TAXD;

        public decimal Cart_Additional_OV;

        public bool IsArtwork;

        public bool IsOrderPdf;

        public bool IsActive;

        public string SecureDocPath = ConnectionClass.SecureDocPath;

        public string SecureDocFilepath = string.Empty;

        public string SecureSitePath = ConnectionClass.SecureSitePath;

        public string ServerName = ConnectionClass.ServerName;

        public static string Pdf_File;

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public string OrderTitle = string.Empty;

        public string jobScreenName = "Job Name";

        public string DeptScreenName = string.Empty;

        public string OrderedByName = string.Empty;

        public string OrderedForName = string.Empty;

        static EmailClass()
        {
            EmailClass.order_No = string.Empty;
            EmailClass.storeName = string.Empty;
            EmailClass.donotreplay = "donotreply@eprintsoftware.com";
            EmailClass.Pdf_File = string.Empty;
        }

        public EmailClass()
        {
        }

        public void emailOrdersDetails(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = StoreUserID;
            this.TagBody = "";
            string file = string.Empty;
            if (ConnectionClass.FileExtension != null)
            {
                this.eprintDocument = ConnectionClass.eprintDocument;
            }
            if (ConnectionClass.SecureDocFilepath != null)
            {
                this.SecureDocFilepath = ConnectionClass.SecureDocFilepath;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.EmailEnable = ConnectionClass.EmailEnable;
            }
            if (TagEvent.ToLower().Trim() != "new order")
            {
                this.emailfor = "Customer";
            }
            else
            {
                this.emailfor = "Admin";
            }
            DataTable customerSelectWebStore = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, this.emailfor);
            foreach (DataRow row in customerSelectWebStore.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsOrderPdf = Convert.ToBoolean(row["IsOrderPdf"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.emailTo = dataRow["EmailID"].ToString();
                this.emailFrom = dataRow["marketingEmail"].ToString();
                EmailClass.storeName = dataRow["accountName"].ToString();
                if (this.IsArtwork)
                {
                    if (dataRow["UploadFile"].ToString() != "")
                    {
                        object[] secureDocFilepath = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocFilepath);
                    }
                    if (dataRow["UploadFile1"].ToString() != "")
                    {
                        object[] objArray = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile1"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray);
                    }
                    if (dataRow["UploadFile2"].ToString() != "")
                    {
                        object[] secureDocFilepath1 = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile2"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocFilepath1);
                    }
                    if (dataRow["PrintReadyFile"].ToString().Trim().Length > 0)
                    {
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\", CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                    }
                    if (dataRow["PDFNameFromCart"].ToString() != "")
                    {
                        if (this.emailfor != "Admin")
                        {
                            object[] secureDocPath1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(secureDocPath1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(objArray1);
                        }
                    }
                }
                if (!(dataRow["PDFNameFromCart"].ToString() != "") || !(this.emailfor == "Admin"))
                {
                    continue;
                }
                DataTable editableTemplateImageurl = new DataTable();
                editableTemplateImageurl = OrderBasePage.Get_EditableTemplate_Imageurl(Convert.ToInt32(dataRow["ProductID"]), Convert.ToInt32(dataRow["CartItemID"]));
                foreach (DataRow row1 in editableTemplateImageurl.Rows)
                {
                    if (!Convert.ToBoolean(row1["IsFromPdf"].ToString()))
                    {
                        if (row1["ImageUrl"].ToString() == "")
                        {
                            continue;
                        }
                        object[] secureDocPath2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", row1["ImageUrl"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath2);
                    }
                    else
                    {
                        string str = row1["OriginalImageName"].ToString();
                        str = str.Replace(".png", ".pdf").Replace(".PNG", ".pdf");
                        object[] objArray2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", row1["ImageUrl"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray2);
                        object[] secureDocPath3 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", str, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath3);
                    }
                }
            }
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                if (this.IsActive && TagEvent.ToLower().Trim() == "thank you for your order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "ORDERCONFIRM", this.emailfor);

                    // attach PDF to the automated order email                    
                    if ((this.IsOrderPdf) && (TagEvent.ToLower().Trim() == "thank you for your order"))
                    {
                        string path = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string OrderPdfFileName = string.Concat(CompanyID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), "_OrderPDF.pdf");

                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", OrderPdfFileName, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                        file = Path.Combine(path, OrderPdfFileName);
                        String html = @"<p>" + this.email_return_body + "</p>";
                        Html2Pdf(html, file);
                    }
                    EmailClass.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
                this.IsActive = false;
                DataTable customerSelectWebStore1 = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Admin");
                foreach (DataRow dataRow1 in customerSelectWebStore1.Rows)
                {
                    this.IsActive = Convert.ToBoolean(dataRow1["IsActive"].ToString());
                }
                if (this.IsActive && TagEvent.ToLower().Trim() == "new order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "NEWORDER", this.emailfor);
                    if (ConnectionClass.SystemName.ToLower() == "aviva" && ConnectionClass.NewOrderAdminEmailID != null)
                    {
                    }
                    if (customerSelectWebStore1.Rows.Count > 0)
                    {
                        this.emailTo = customerSelectWebStore1.Rows[0]["AdminTo"].ToString();
                        this.emailCC = customerSelectWebStore1.Rows[0]["AdminCc"].ToString();
                        this.emailBCC = customerSelectWebStore1.Rows[0]["AdminBcc"].ToString();
                    }
                    EmailClass.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
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
                        doc.Add(new Chunk(""));
                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                            //XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StringReader("<p>helloworld</p>"));
                        }

                        doc.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void emailOrdersDetailsBackOrder(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = StoreUserID;
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
            if (TagEvent.ToLower().Trim() != "back order")
            {
                this.emailfor = "Customer";
            }
            else
            {
                this.emailfor = "Admin";
            }
            DataTable customerSelectWebStore = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, this.emailfor);
            foreach (DataRow row in customerSelectWebStore.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsOrderPdf = Convert.ToBoolean(row["IsOrderPdf"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.emailTo = dataRow["EmailID"].ToString();
                this.emailFrom = dataRow["marketingEmail"].ToString();
                EmailClass.storeName = dataRow["accountName"].ToString();
                if (this.IsArtwork)
                {
                    if (dataRow["UploadFile"].ToString() != "")
                    {
                        object[] secureDocFilepath = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocFilepath);
                    }
                    if (dataRow["UploadFile1"].ToString() != "")
                    {
                        object[] objArray = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile1"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(objArray);
                    }
                    if (dataRow["UploadFile2"].ToString() != "")
                    {
                        object[] secureDocFilepath1 = new object[] { this.emailAttachment, this.SecureDocFilepath, this.ServerName, "\\store\\", this.Account_ID, "\\artwork\\", dataRow["UploadFile2"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocFilepath1);
                    }
                    if (dataRow["PrintReadyFile"].ToString().Trim().Length > 0)
                    {
                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\", CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString(), "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                    }
                    if (dataRow["PDFNameFromCart"].ToString() != "")
                    {
                        if (this.emailfor != "Admin")
                        {
                            object[] secureDocPath1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(secureDocPath1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", dataRow["PDFNameFromCart"].ToString(), "µ" };
                            this.emailAttachment = string.Concat(objArray1);
                        }
                    }
                }
                if (!(dataRow["PDFNameFromCart"].ToString() != "") || !(this.emailfor == "Admin"))
                {
                    continue;
                }
                DataTable editableTemplateImageurl = new DataTable();
                editableTemplateImageurl = OrderBasePage.Get_EditableTemplate_Imageurl(Convert.ToInt32(dataRow["ProductID"]), Convert.ToInt32(dataRow["CartItemID"]));
                foreach (DataRow row1 in editableTemplateImageurl.Rows)
                {
                    object[] secureDocPath2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", row1["ImageUrl"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(secureDocPath2);
                }
            }
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                if (this.IsActive && TagEvent.ToLower().Trim() == "thank you for your order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "ORDERCONFIRM", this.emailfor);

                    // attach PDF to the automated order email                    
                    if ((this.IsOrderPdf) && (TagEvent.ToLower().Trim() == "thank you for your order"))
                    {
                        string path = string.Concat(this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string OrderPdfFileName = string.Concat(CompanyID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), "_OrderPDF.pdf");

                        object[] secureDocPath = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "/", CompanyID, "/attachments/", OrderPdfFileName, "µ" };
                        this.emailAttachment = string.Concat(secureDocPath);
                        file = Path.Combine(path, OrderPdfFileName);
                        String html = @"<p>" + this.email_return_body + "</p>";
                        Html2Pdf(html, file);
                    }
                    EmailClass.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
                this.IsActive = false;
                DataTable customerSelectWebStore1 = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Admin");
                foreach (DataRow dataRow1 in customerSelectWebStore1.Rows)
                {
                    this.IsActive = Convert.ToBoolean(dataRow1["IsActive"].ToString());
                }
                if (this.IsActive && TagEvent.ToLower().Trim() == "back order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "BACKORDER", this.emailfor);
                    if (ConnectionClass.SystemName.ToLower() == "aviva" && ConnectionClass.NewOrderAdminEmailID != null)
                    {
                    }
                    if (customerSelectWebStore1.Rows.Count > 0)
                    {
                        this.emailTo = customerSelectWebStore1.Rows[0]["AdminTo"].ToString();
                        this.emailCC = customerSelectWebStore1.Rows[0]["AdminCc"].ToString();
                        this.emailBCC = customerSelectWebStore1.Rows[0]["AdminBcc"].ToString();
                    }
                    EmailClass.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
            }
        }

        public void emailPassword(int StoreUserID, int CompanyID, int AccountID, string TagEvent)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailFrom = "donotreply@eprintsoftware.com";
            this.TagBody = "";
            if (ConnectionClass.FileExtension != null)
            {
                this.EmailEnable = ConnectionClass.EmailEnable;
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)CompanyID, (long)AccountID).Rows)
            {
                this.AccountName = row["accountName"].ToString();
            }
            DataTable customerSelectWebStore = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Customer");
            foreach (DataRow dataRow in customerSelectWebStore.Rows)
            {
                this.emailSubject = dataRow["Subject"].ToString();
                this.TagBody = dataRow["Body"].ToString();
                this.IsActive = Convert.ToBoolean(dataRow["IsActive"].ToString());
                this.emailFrom = dataRow["marketingEmail"].ToString();
            }
            DataTable dataTable = LoginBasePage.StoreUser_select(Convert.ToInt64(StoreUserID));
            foreach (DataRow row1 in dataTable.Rows)
            {
                this.emailTo = row1["EmailID"].ToString().Trim();
            }
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = this.ReplaceAllTags(dataTable, customerSelectWebStore, Convert.ToInt64(StoreUserID), (long)0, CompanyID, "PASSWORD", "");
                EmailClass.SendMailMessage(this.emailFrom, this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void emailRegisterDetails(int StoreUserID, int CompanyID, int AccountID, string TagEvent)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.TagBody = "";
            if (ConnectionClass.FileExtension != null)
            {
                this.EmailEnable = ConnectionClass.EmailEnable;
            }
            DataTable customerSelectWebStore = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Customer");
            foreach (DataRow row in customerSelectWebStore.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.TagBody = row["Body"].ToString();
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                this.emailFrom = row["marketingEmail"].ToString();
            }
            DataTable dataTable = LoginBasePage.StoreUser_select(Convert.ToInt64(StoreUserID));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.FirstName = dataRow["FirstName"].ToString().Trim();
                this.LastName = dataRow["LastName"].ToString().Trim();
                this.EmailID = dataRow["EmailID"].ToString().Trim();
                this.Pwd = dataRow["Password"].ToString().Trim();
                this.DefaultBillingID = Convert.ToInt64(dataRow["DefaultBillingID"].ToString());
            }
            foreach (DataRow row1 in LoginBasePage.Select_AccountDetails((long)CompanyID, (long)AccountID).Rows)
            {
                this.AccountName = row1["accountName"].ToString();
            }
            DataTable dataTable1 = OrderBasePage.Select_BillingShipping_Address((long)StoreUserID, "", this.DefaultBillingID);
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, Convert.ToInt64(StoreUserID), (long)0, CompanyID, "NEWUSER", "");
                EmailClass.SendMailMessage(this.emailFrom, this.EmailID, this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public string ReplaceAllTags(DataTable dtEmail, DataTable dtBody, long OrderID, long StoreUserID, int CompanyID, string Type, string EmailFor)
        {
            string str;
            string[] keySeparator;
            string cartAdditionalOptionName;
            char[] chrArray;
            string[] currencyinRequiredFormate;
            object[] accountID;
            BaseClass baseClass = new BaseClass();
            this.DeptScreenName = (new BaseClass()).Return_ApprovalRegistration_Settings("deptscreenname");
            if (ConnectionClass.FileExtension != null)
            {
                this.eprintDocument = ConnectionClass.eprintDocument;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            string empty = string.Empty;
            if (ConnectionClass.PublicDocPath != null)
            {
                empty = ConnectionClass.PublicDocPath.ToString();
            }
            empty = empty.Replace("document/", "");
            string empty1 = string.Empty;
            DataTable dataTable = OrderBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow row in OrderBasePage.Select_OrderItems(OrderID, this.StoreUser_ID).Rows)
            {
                this.OrderKey = row["OrderKey"].ToString();
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

            foreach (DataRow dataRow in CartBasePage.eStore_Visibility_Settings_Select(CompanyID, this.Account_ID).Rows)
            {
                this.jobScreenName = baseClass.SpecialDecode(dataRow["CartJobScreenName"].ToString());
            }
            foreach (DataRow row1 in dtEmail.Rows)
            {
                if (!dtEmail.Columns.Contains("EmailToCustomerID"))
                {
                    continue;
                }
                this.EmailToCustomerID = Convert.ToInt64(row1["EmailToCustomerID"].ToString());
            }
            foreach (DataRow dataRow1 in OrderBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
                if (dataRow1["IsItemNumber"].ToString() != "")
                {
                    empty15 = (dataRow1["IsItemNumber"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsProductName"].ToString() != "")
                {
                    str10 = (dataRow1["IsProductName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsJobName"].ToString() != "")
                {
                    empty11 = (dataRow1["IsJobName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsQuantity"].ToString() != "")
                {
                    str11 = (dataRow1["IsQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsTotalPrice"].ToString() != "")
                {
                    empty12 = (dataRow1["IsTotalPrice"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsOrderedWidth"].ToString() != "")
                {
                    str12 = (dataRow1["IsOrderedWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsOrderedHeight"].ToString() != "")
                {
                    empty13 = (dataRow1["IsOrderedHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsProductWidth"].ToString() != "")
                {
                    str13 = (dataRow1["IsProductWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsProductHeight"].ToString() != "")
                {
                    empty14 = (dataRow1["IsProductHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsAdditionalOption"].ToString() != "")
                {
                    str14 = (dataRow1["IsAdditionalOption"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsItemCode"].ToString() != "")
                {
                    str15 = (dataRow1["IsItemCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsCustomerCode"].ToString() != "")
                {
                    empty16 = (dataRow1["IsCustomerCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsUnitOfMeasure"].ToString() == "")
                {
                    continue;
                }
                str16 = (dataRow1["IsUnitOfMeasure"].ToString().ToLower() != "true" ? "false" : "true");

                empty222 = (dataRow1["IsItemDescription"].ToString().ToLower() != "true" ? "false" : "true");
                str222 = (dataRow1["IsWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty223 = (dataRow1["IsCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str223 = (dataRow1["IsOrderedWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty224 = (dataRow1["IsOrderedCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str224 = (dataRow1["IsPerQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                empty225 = (dataRow1["IsDimensions"].ToString().ToLower() != "true" ? "false" : "true");

            }
            if (Type.ToLower().Trim() == "password")
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.strSitepath, "login.aspx");
                }
                else
                {
                    this.loginLink = string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href='", this.loginLink, "'>Click here to login</a>");
                EmailClass.storeName = this.AccountName;
                foreach (DataRow row2 in dtEmail.Rows)
                {
                    this.EmailID = row2["EmailID"].ToString().Trim();
                    this.Pwd = row2["Password"].ToString().Trim();
                    this.ContactName = string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString());
                }
                this.emailSubject = this.emailSubject.Replace("[$URL$]", this.loginLink);
                this.emailSubject = this.emailSubject.Replace("[$USER_EMAIL$]", this.EmailID);
                this.emailSubject = this.emailSubject.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", this.AccountName);
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_NAME$]", this.ContactName);
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.TagBody = this.TagBody.Replace("[$URL$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$USER_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$STORE$]", this.AccountName);
                this.TagBody = this.TagBody.Replace("[$CONTACT_NAME$]", this.ContactName);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            if (Type.ToLower().Trim() == "orderconfirm")
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
                    this.orderLink = string.Concat(this.strSitepath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new string[] { this.strSitepath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href='", this.orderLink, "'>Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow dataRow2 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    EmailClass emailClass = this;
                    cartAdditionalOptionName = emailClass.Cart_AdditionalOptionName;
                    keySeparator = new string[] { cartAdditionalOptionName, dataRow2["WebOtherCostName"].ToString(), "- ", dataRow2["SelectedValue"].ToString(), "<br />" };
                    emailClass.Cart_AdditionalOptionName = string.Concat(keySeparator);
                    EmailClass emailClass1 = this;
                    emailClass1.Cart_AdditionalOptionValue = string.Concat(emailClass1.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    EmailClass cartAdditionalOV = this;
                    cartAdditionalOV.Cart_Additional_OV = cartAdditionalOV.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true));
                    EmailClass emailClass2 = this;
                    cartAdditionalOptionName = emailClass2.Cart_AdditionalOption;
                    keySeparator = new string[] { cartAdditionalOptionName, dataRow2["WebOtherCostName"].ToString(), "- ", dataRow2["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    emailClass2.Cart_AdditionalOption = string.Concat(keySeparator);
                }
                string str17 = string.Empty;
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = new DataTable();
                foreach (DataRow row3 in dtEmail.Rows)
                {
                    this.emailSubject = row3["Subject"].ToString();
                    this.TagBody = row3["Body"].ToString();
                    foreach (DataRow dataRow3 in dtBody.Rows)
                    {
                        dataTable1 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(dataRow3["BillingAddressID"]));
                        dataTable2 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(dataRow3["ShippingAddressID"]));
                        EmailClass.storeName = dataRow3["accountName"].ToString();
                        EmailClass.order_No = dataRow3["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow3["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow3["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = dataRow3["Comments"].ToString();
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        this.FirstName = dataRow3["FirstName"].ToString();
                        this.OrderTitle = baseClass.SpecialDecode(dataRow3["orderTitle"].ToString());
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
                        EmailClass.Pdf_File = string.Concat(EmailClass.Pdf_File, dataRow3["CatalogueName"].ToString(), "Ð");
                        if (dataRow3["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, dataRow3["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (dataRow3["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, dataRow3["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        chrArray = new char[] { 'Ð' };
                        string[] strArrays = empty1.Split(chrArray);
                        string pdfFile = EmailClass.Pdf_File;
                        chrArray = new char[] { 'Ð' };
                        string[] strArrays1 = pdfFile.Split(chrArray);
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            if ((int)strArrays.Length == (int)strArrays1.Length && strArrays[i].ToString().Trim() != "")
                            {
                                string str18 = strArrays[i].ToString();
                                chrArray = new char[] { '\u00A7' };
                                string[] strArrays2 = str18.Split(chrArray);
                                empty1 = strArrays2[0].ToString();
                                string str19 = strArrays2[1].ToString();
                                EmailClass.Pdf_File = strArrays1[i].ToString();
                                if (str19 != "et")
                                {
                                    accountID = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", EmailClass.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(accountID);
                                }
                                else if (EmailFor.ToLower() != "admin")
                                {
                                    accountID = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(accountID);
                                }
                                else
                                {
                                    accountID = new object[] { str17, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                                    str17 = string.Concat(accountID);
                                }
                            }
                        }
                        EmailClass.Pdf_File = "";
                        int num = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable3 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow3["OrderItemID"]));
                        foreach (DataRow row4 in dataTable3.Rows)
                        {
                            this.additionalProductDetails = string.Concat(this.additionalProductDetails, row4["UserFriendlyName"].ToString(), "<br/>");
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
                            stringBuilder.Append("<div style='clear:both'></div><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", dataRow3["Order_Item_Number"].ToString(), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", dataRow3["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            stringBuilder.Append(empty17);
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
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
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: </td><td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: </td><td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }

                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
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
                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Number: </td><td valign='top'>", dataRow3["Order_Item_Number"].ToString(), "</td></tr>"));
                            }
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", dataRow3["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
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
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: </td><td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: </td><td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }

                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
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
                            stringBuilder.Append("</div></div><div style='clear:both'></div>");
                        }
                    }
                    EmailClass tOTAL = this;
                    tOTAL.TOTAL = tOTAL.TOTAL + this.Cart_Additional_OV;
                    EmailClass tOTAL1 = this;
                    tOTAL1.TOTAL = tOTAL1.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.emailSubject = this.emailSubject.Replace("[$STORE$]", EmailClass.storeName);
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", EmailClass.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", this.Comments);
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                    this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("\r\n", "");
                    this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.TagBody = this.TagBody.Replace("[$STORE$]", EmailClass.storeName);
                    this.TagBody = this.TagBody.Replace("[$ORDERNO$]", EmailClass.order_No);
                    this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                    this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                    this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", this.FirstName);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", str17);
                    this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                    this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                    this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                    keySeparator = new string[] { this.comm.GetCurrencyinRequiredFormate("", true) ?? "" };
                    string[] strArrays3 = this.Cart_AdditionalOptionValue.Split(keySeparator, StringSplitOptions.None);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    for (int j = 0; j <= (int)strArrays3.Length - 1; j++)
                    {
                        if (j == 1)
                        {
                            num6 = Convert.ToDecimal(strArrays3[1].Remove(strArrays3[1].Length - 6, 6));
                        }
                        else if (j == 2)
                        {
                            num7 = Convert.ToDecimal(strArrays3[2].Remove(strArrays3[2].Length - 6, 6));
                        }
                        else if (j == 3)
                        {
                            num8 = Convert.ToDecimal(strArrays3[3].Remove(strArrays3[3].Length - 6, 6));
                        }
                        else if (j == 4)
                        {
                            num9 = Convert.ToDecimal(strArrays3[4].Remove(strArrays3[4].Length - 6, 6));
                        }
                        num5 = ((num6 + num7) + num8) + num9;
                    }
                    foreach (DataRow dataRow4 in dtBody.Rows)
                    {
                        this.TAXD = Convert.ToDecimal(dataRow4["TAX"]);
                        num5 = num5 + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)) + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAXD, 2, "", false, false, true));
                        this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, num5, 2, "", false, false, true))));
                    }
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    foreach (DataRow row5 in dataTable1.Rows)
                    {
                        str1 = row5["AddressLabel"].ToString();
                        empty2 = row5["AddressLine1"].ToString();
                        str2 = row5["AddressLine2"].ToString();
                        empty3 = row5["Address2"].ToString();
                        str3 = row5["Address3"].ToString();
                        empty4 = row5["Address4"].ToString();
                        str4 = row5["Country"].ToString();
                        empty5 = row5["Phone"].ToString();
                        str5 = row5["Fax"].ToString();
                    }
                    foreach (DataRow dataRow5 in dataTable2.Rows)
                    {
                        empty6 = dataRow5["AddressLabel"].ToString();
                        str6 = dataRow5["AddressLine1"].ToString();
                        empty7 = dataRow5["AddressLine2"].ToString();
                        str7 = dataRow5["Address2"].ToString();
                        empty8 = dataRow5["Address3"].ToString();
                        str8 = dataRow5["Address4"].ToString();
                        empty9 = dataRow5["Country"].ToString();
                        str9 = dataRow5["Phone"].ToString();
                        empty10 = dataRow5["Fax"].ToString();
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
            }
            if (Type.ToLower().Trim() == "neworder")
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
                    this.orderLink = string.Concat(this.strSitepath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new string[] { this.strSitepath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow row6 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    EmailClass emailClass3 = this;
                    cartAdditionalOptionName = emailClass3.Cart_AdditionalOptionName;
                    keySeparator = new string[] { cartAdditionalOptionName, row6["WebOtherCostName"].ToString(), "- ", row6["SelectedValue"].ToString(), "<br />" };
                    emailClass3.Cart_AdditionalOptionName = string.Concat(keySeparator);
                    EmailClass emailClass4 = this;
                    emailClass4.Cart_AdditionalOptionValue = string.Concat(emailClass4.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    EmailClass emailClass5 = this;
                    cartAdditionalOptionName = emailClass5.Cart_AdditionalOption;
                    keySeparator = new string[] { cartAdditionalOptionName, row6["WebOtherCostName"].ToString(), "- ", row6["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    emailClass5.Cart_AdditionalOption = string.Concat(keySeparator);
                    EmailClass cartAdditionalOV1 = this;
                    cartAdditionalOV1.Cart_Additional_OV = cartAdditionalOV1.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                string empty19 = string.Empty;
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
                        EmailClass.order_No = row7["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row7["createdBy"].ToString());
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row7["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row7["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.OrderTitle = baseClass.SpecialDecode(row7["orderTitle"].ToString());
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
                        EmailClass.Pdf_File = string.Concat(EmailClass.Pdf_File, row7["CatalogueName"].ToString(), "Ð");
                        if (row7["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, row7["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (row7["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, row7["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        int num10 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable6 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row7["OrderItemID"]));
                        foreach (DataRow dataRow7 in dataTable6.Rows)
                        {
                            this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow7["UserFriendlyName"].ToString(), "<br/>");
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
                            stringBuilder5.Append("<div style='clear:both'></div><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row7["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            stringBuilder5.Append(empty18);
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row7["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row7["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num14, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: </td><td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: </td><td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
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

                            stringBuilder5.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'></div>");
                        }
                        else
                        {
                            stringBuilder5.Append("<div style='clear:both'></div><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row7["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row7["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row7["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num14, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Height: </td><td class='tags_valigntop'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td class='tagswidth'>Ordered Width: </td><td class='tags_valigntop'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row7["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
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


                            stringBuilder5.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'></div>");
                        }
                    }
                    EmailClass tOTAL2 = this;
                    tOTAL2.TOTAL = tOTAL2.TOTAL + this.Cart_Additional_OV;
                    EmailClass tOTAL3 = this;
                    tOTAL3.TOTAL = tOTAL3.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
                chrArray = new char[] { 'Ð' };
                string[] strArrays4 = empty1.Split(chrArray);
                string pdfFile1 = EmailClass.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays5 = pdfFile1.Split(chrArray);
                for (int k = 0; k < (int)strArrays5.Length; k++)
                {
                    if ((int)strArrays4.Length == (int)strArrays5.Length && strArrays4[k].ToString().Trim() != "")
                    {
                        string str20 = strArrays4[k].ToString();
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays6 = str20.Split(chrArray);
                        empty1 = strArrays6[0].ToString();
                        string str21 = strArrays6[1].ToString();
                        EmailClass.Pdf_File = strArrays5[k].ToString();
                        if (str21 != "et")
                        {
                            accountID = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", EmailClass.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(accountID);
                        }
                        else if (EmailFor.ToLower() != "admin")
                        {
                            accountID = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(accountID);
                        }
                        else
                        {
                            accountID = new object[] { empty19, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                            empty19 = string.Concat(accountID);
                        }
                    }
                }
                EmailClass.Pdf_File = "";
                this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", EmailClass.storeName);
                this.emailSubject = this.emailSubject.Replace("[$CUSTOMER_NAME$]", this.customerName);
                this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", EmailClass.order_No);
                this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", this.Comments);
                this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.TagBody = this.TagBody.Replace("[$STORE$]", EmailClass.storeName);
                this.TagBody = this.TagBody.Replace("[$CUSTOMER_NAME$]", this.customerName);
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", EmailClass.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder5.ToString());
                this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty19);
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
            if (Type.ToLower().Trim() == "backorder")
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
                    this.orderLink = string.Concat(this.strSitepath, "order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    keySeparator = new string[] { this.strSitepath, "order", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.FileExtension };
                    this.orderLink = string.Concat(keySeparator);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow row9 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    EmailClass emailClass6 = this;
                    cartAdditionalOptionName = emailClass6.Cart_AdditionalOptionName;
                    keySeparator = new string[] { cartAdditionalOptionName, row9["WebOtherCostName"].ToString(), "- ", row9["SelectedValue"].ToString(), "<br />" };
                    emailClass6.Cart_AdditionalOptionName = string.Concat(keySeparator);
                    EmailClass emailClass7 = this;
                    emailClass7.Cart_AdditionalOptionValue = string.Concat(emailClass7.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row9["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    EmailClass emailClass8 = this;
                    cartAdditionalOptionName = emailClass8.Cart_AdditionalOption;
                    keySeparator = new string[] { cartAdditionalOptionName, row9["WebOtherCostName"].ToString(), "- ", row9["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row9["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    emailClass8.Cart_AdditionalOption = string.Concat(keySeparator);
                    EmailClass cartAdditionalOV2 = this;
                    cartAdditionalOV2.Cart_Additional_OV = cartAdditionalOV2.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row9["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                string empty21 = string.Empty;
                DataTable dataTable7 = new DataTable();
                DataTable dataTable8 = new DataTable();
                foreach (DataRow dataRow9 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow9["Subject"].ToString();
                    this.TagBody = dataRow9["Body"].ToString();
                    foreach (DataRow row10 in dtBody.Rows)
                    {
                        dataTable7 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(row10["BillingAddressID"]));
                        dataTable8 = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(row10["ShippingAddressID"]));
                        this.AccountName = row10["accountName"].ToString();
                        EmailClass.order_No = row10["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row10["createdBy"].ToString());
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row10["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row10["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = row10["Comments"].ToString();
                        this.customerName = string.Concat(row10["FirstName"].ToString(), " ", row10["LastName"].ToString());
                        this.OrderedByName = string.Concat(row10["FirstName"].ToString(), " ", row10["LastName"].ToString());
                        if (Convert.ToInt64(row10["OrderBehalfDeptID"]) > (long)0)
                        {
                            if (this.DeptScreenName != "")
                            {
                                currencyinRequiredFormate = new string[] { row10["Order_Behalf_DeptID"].ToString(), " [", this.DeptScreenName, "] for the attention of ", row10["Order_Behalf_UserID"].ToString() };
                                this.OrderedForName = string.Concat(currencyinRequiredFormate);
                            }
                            else
                            {
                                this.OrderedForName = string.Concat(row10["Order_Behalf_DeptID"].ToString(), " [Department] for the attention of ", row10["Order_Behalf_UserID"].ToString());
                            }
                        }
                        else if (Convert.ToInt64(row10["OrderBehalfUserID"]) <= (long)0)
                        {
                            this.OrderedForName = this.OrderedByName;
                        }
                        else
                        {
                            this.OrderedForName = row10["Order_Behalf_UserID"].ToString();
                        }
                        this.OrderTitle = baseClass.SpecialDecode(row10["orderTitle"].ToString());
                        int num15 = 0;
                        this.additionalProductDetails = "";
                        EmailClass.Pdf_File = string.Concat(EmailClass.Pdf_File, row10["CatalogueName"].ToString(), "Ð");
                        if (row10["PDFNameFromCart"].ToString() != "")
                        {
                            empty1 = string.Concat(empty1, row10["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (row10["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty1 = string.Concat(empty1, row10["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        DataTable dataTable9 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row10["OrderItemID"]));
                        foreach (DataRow dataRow10 in dataTable9.Rows)
                        {
                            this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow10["UserFriendlyName"].ToString(), "<br/>");
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
                        decimal num16 = Convert.ToDecimal(row10["OrderItemTotalPrice"].ToString());
                        decimal num17 = Convert.ToDecimal(row10["OrderItemTax"].ToString());
                        decimal num18 = num16;
                        decimal num19 = num18 + num17;
                        this.SUB_TOTAL = this.SUB_TOTAL + num16;
                        this.TAX_DETAILS = Convert.ToDecimal(row10["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num18;
                        if (row10["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row10["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (row10["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row10["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (row10["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row10["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (row10["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row10["ProductWidth"]), 2, "", false, false, true);
                            if (this.ProductWidth == "0.00")
                            {
                                this.ProductWidth = "";
                            }
                        }
                        if (empty20 != "")
                        {
                            stringBuilder10.Append("<div style='clear:both'></div><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            if (!Convert.ToBoolean(row10["IsBackOrder"]))
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row10["CatalogueName"].ToString(), "</td></tr>"));
                                }
                            }
                            else
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row10["CatalogueName"].ToString(), "&nbsp;</td></tr>"));
                                }
                            }
                            stringBuilder10.Append(empty20);
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row10["JobName"].ToString()), "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row10["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: </td><td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: </td><td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td valign='top'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td valign='top'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row10["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row10["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", row10["SoldInPacksof"].ToString(), "</td></tr>"));
                            }

                            if (empty222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row10["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row10["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row10["CBMWeight"]) / Convert.ToDouble(row10["PerQuantity"])) * Convert.ToDouble(row10["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row10["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row10["CBMMeasurement"]) / Convert.ToDouble(row10["PerQuantity"])) * Convert.ToDouble(row10["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row10["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row10["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row10["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }

                            stringBuilder10.Append("</table><br/>");
                            stringBuilder10.Append("</div></div><div style='clear:both'></div>");
                        }
                        else
                        {
                            stringBuilder10.Append("<div style='clear:both'></div><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            if (!Convert.ToBoolean(row10["IsBackOrder"]))
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<td width='150px' valign='top'>Product Name: </td><td valign='top'>", row10["CatalogueName"].ToString(), "</td></tr>"));
                                }
                            }
                            else
                            {
                                stringBuilder10.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                                if (str10 == "true")
                                {
                                    stringBuilder10.Append(string.Concat("<td width='150px' valign='top'>Product Name: </td><td valign='top'>", row10["CatalogueName"].ToString(), "&nbsp;</td></tr>"));
                                }
                            }
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", baseClass.SpecialDecode(row10["JobName"].ToString()), "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row10["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price(inc.Tax): </td><td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num19, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (empty13 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: </td><td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (str12 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: </td><td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (empty14 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td valign='top'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): </td><td valign='top'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder10.Append(string.Concat(keySeparator));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", baseClass.SpecialDecode(row10["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", baseClass.SpecialDecode(row10["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (str16 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", row10["SoldInPacksof"].ToString(), "</td></tr>"));
                            }


                            if (empty222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row10["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row10["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row10["CBMWeight"]) / Convert.ToDouble(row10["PerQuantity"])) * Convert.ToDouble(row10["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row10["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row10["CBMMeasurement"]) / Convert.ToDouble(row10["PerQuantity"])) * Convert.ToDouble(row10["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row10["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder10.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row10["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row10["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row10["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }

                            stringBuilder10.Append("</table><br/>");
                            stringBuilder10.Append("</div></div><div style='clear:both'></div>");
                        }
                    }
                    EmailClass tOTAL4 = this;
                    tOTAL4.TOTAL = tOTAL4.TOTAL + this.Cart_Additional_OV;
                    EmailClass tOTAL5 = this;
                    tOTAL5.TOTAL = tOTAL5.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
                chrArray = new char[] { 'Ð' };
                string[] strArrays7 = empty1.Split(chrArray);
                string pdfFile2 = EmailClass.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays8 = pdfFile2.Split(chrArray);
                for (int l = 0; l < (int)strArrays8.Length; l++)
                {
                    if ((int)strArrays7.Length == (int)strArrays8.Length && strArrays7[l].ToString().Trim() != "")
                    {
                        string str22 = strArrays7[l].ToString();
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays9 = str22.Split(chrArray);
                        empty1 = strArrays9[0].ToString();
                        string str23 = strArrays9[1].ToString();
                        EmailClass.Pdf_File = strArrays8[l].ToString();
                        if (str23 != "et")
                        {
                            accountID = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", EmailClass.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(accountID);
                        }
                        else if (EmailFor.ToLower() != "admin")
                        {
                            accountID = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(accountID);
                        }
                        else
                        {
                            accountID = new object[] { empty21, "<div><a href='", empty, "EmailPdf.aspx?File=", empty1, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et_admin&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                            empty21 = string.Concat(accountID);
                        }
                    }
                }
                EmailClass.Pdf_File = "";
                this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", EmailClass.storeName);
                this.emailSubject = this.emailSubject.Replace("[$CUSTOMER_NAME$]", this.customerName);
                this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", EmailClass.order_No);
                this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", this.Comments);
                this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                this.TagBody = this.TagBody.Replace("[$STORE$]", EmailClass.storeName);
                this.TagBody = this.TagBody.Replace("[$CUSTOMER_NAME$]", this.customerName);
                this.TagBody = this.TagBody.Replace("[$ORDERNO$]", EmailClass.order_No);
                this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true))));
                this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder10.ToString());
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty21);
                this.TagBody = this.TagBody.Replace("[$ORDER_TITLE$]", this.OrderTitle);
                this.TagBody = this.TagBody.Replace("[$ORDERED_FOR$]", this.OrderedForName);
                this.TagBody = this.TagBody.Replace("[$ORDERED_BY$]", this.OrderedByName);
                foreach (DataRow row11 in dataTable7.Rows)
                {
                    str1 = row11["AddressLabel"].ToString();
                    empty2 = row11["AddressLine1"].ToString();
                    str2 = row11["AddressLine2"].ToString();
                    empty3 = row11["Address2"].ToString();
                    str3 = row11["Address3"].ToString();
                    empty4 = row11["Address4"].ToString();
                    str4 = row11["Country"].ToString();
                    empty5 = row11["Phone"].ToString();
                    str5 = row11["Fax"].ToString();
                }
                foreach (DataRow dataRow11 in dataTable8.Rows)
                {
                    empty6 = dataRow11["AddressLabel"].ToString();
                    str6 = dataRow11["AddressLine1"].ToString();
                    empty7 = dataRow11["AddressLine2"].ToString();
                    str7 = dataRow11["Address2"].ToString();
                    empty8 = dataRow11["Address3"].ToString();
                    str8 = dataRow11["Address4"].ToString();
                    empty9 = dataRow11["Country"].ToString();
                    str9 = dataRow11["Phone"].ToString();
                    empty10 = dataRow11["Fax"].ToString();
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
            if (Type.ToLower().Trim() == "newuser")
            {
                StringBuilder stringBuilder15 = new StringBuilder();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.strSitepath, "login.aspx");
                }
                else
                {
                    this.loginLink = string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href='", this.loginLink, "'>Click here to login</a>");
                this.EmailID = this.EmailID.Replace("[$USER_EMAIL$]", this.EmailID);
                this.Pwd = this.Pwd.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.AccountName = this.AccountName.Replace("[$STORE$]", this.AccountName);
                EmailClass.storeName = this.AccountName;
                this.emailSubject = this.emailSubject.Replace("[$STORE_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$STORE_NAME$]", this.AccountName);
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", this.AccountName);
                this.emailSubject = this.emailSubject.Replace("[$USER_FIRSTNAME$]", this.FirstName);
                this.emailSubject = this.emailSubject.Replace("[$USER_LASTNAME$]", this.LastName);
                this.emailSubject = this.emailSubject.Replace("[$USER_EMAIL$]", this.EmailID);
                this.emailSubject = this.emailSubject.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$EMAIL_ADDRESS$]", this.EmailID);
                this.emailSubject = this.emailSubject.Replace("[$PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$STORE_NAME$]", this.AccountName);
                this.TagBody = this.TagBody.Replace("[$STORE$]", this.AccountName);
                this.TagBody = this.TagBody.Replace("[$USER_FIRSTNAME$]", this.FirstName);
                this.TagBody = this.TagBody.Replace("[$USER_LASTNAME$]", this.LastName);
                this.TagBody = this.TagBody.Replace("[$USER_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$EMAIL_ADDRESS$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            return this.TagBody;
        }

        public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml)
        {
            BaseClass baseClass = new BaseClass();
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
            string str4 = "0";
            str4 = (HttpContext.Current.Session["companyID"] == null || !(HttpContext.Current.Session["companyID"].ToString() != "") ? ConnectionClass.CompanyID : HttpContext.Current.Session["companyID"].ToString());
            SqlConnection sqlConnection = new SqlConnection(str1);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ServerName", str);
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(str4));
            sqlCommand.Parameters.AddWithValue("@DBID", 0);
            sqlCommand.Parameters.AddWithValue("@FromEmail", from);
            sqlCommand.Parameters.AddWithValue("@ReplyTo", str3);
            sqlCommand.Parameters.AddWithValue("@ToEmails", to);
            sqlCommand.Parameters.AddWithValue("@CCEmails", cc);
            sqlCommand.Parameters.AddWithValue("@BCCEmails", bcc);
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
            sqlCommand.Parameters.AddWithValue("@StoreName", baseClass.SpecialDecode(EmailClass.storeName));
            sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}