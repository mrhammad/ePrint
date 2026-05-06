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

namespace nmsEmail
{
    public class EmailClass : BaseClass
    {
        private commonclass comm = new commonclass();

        private ConnectionClass objcon = new ConnectionClass();

        private loginclass objlogin = new loginclass();

        private BaseClass objBase = new BaseClass();

        public static string order_No;

        public static string storeName;

        public static string Pdf_File;

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

        public string Pwd = string.Empty;

        public string ContactName = string.Empty;

        public string loginLink = string.Empty;

        public string loginSubject = string.Empty;

        public string OrderKey = string.Empty;

        public long EmailToCustomerID;

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

        public bool IsActive;

        public string SecureDocPath = ConnectionClass.SecureDocPath;

        public string SecureDocFilePath = ConnectionClass.SecureDocFilepath;

        public string SecureSitePath = ConnectionClass.SecureSitePath;

        public string ServerName = ConnectionClass.ServerName;

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public string jobScreenName = "Job Name";

        static EmailClass()
        {
            EmailClass.order_No = string.Empty;
            EmailClass.storeName = string.Empty;
            EmailClass.Pdf_File = string.Empty;
            EmailClass.donotreplay = "donotreply@eprintsoftware.com";
        }

        public EmailClass()
        {
        }

        public void emailOrdersDetails(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, long ApproverID, string ToEmail)
        {
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.emailAttachment = "";
            this.StoreUser_ID = StoreUserID;
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
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.emailTo = base.SpecialDecode(dataRow["EmailID"].ToString());
                this.emailFrom = base.SpecialDecode(dataRow["marketingEmail"].ToString());
                EmailClass.storeName = dataRow["accountName"].ToString();
                if (!this.IsArtwork)
                {
                    continue;
                }
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
                if (dataRow["PDFNameFromCart"].ToString() == "")
                {
                    continue;
                }
                object[] secureDocPath2 = new object[] { this.emailAttachment, this.SecureDocPath, this.ServerName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                this.emailAttachment = string.Concat(secureDocPath2);
            }
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                if (this.IsActive && TagEvent.ToLower().Trim() == "thank you for your order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "ORDERCONFIRM");
                    EmailClass.SendMailMessage(this.emailFrom.Trim(), base.SpecialEncode(this.emailTo.Trim()), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
                }
                this.IsActive = false;
                DataTable customerSelectWebStore1 = OrderBasePage.EmailToCustomer_Select_WebStore(CompanyID, Convert.ToInt32(AccountID), (long)0, TagEvent, "Admin");
                foreach (DataRow row1 in customerSelectWebStore1.Rows)
                {
                    this.IsActive = Convert.ToBoolean(row1["IsActive"].ToString());
                }
                if (this.IsActive && TagEvent.ToLower().Trim() == "new order")
                {
                    this.email_return_body = "";
                    this.email_return_body = this.ReplaceAllTags(customerSelectWebStore, dataTable, OrderID, StoreUserID, CompanyID, "NEWORDER");
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
                this.emailTo = base.SpecialDecode(row1["EmailID"].ToString().Trim());
            }
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = this.ReplaceAllTags(dataTable, customerSelectWebStore, Convert.ToInt64(StoreUserID), (long)0, CompanyID, "PASSWORD");
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
            DataTable dataTable1 = OrderBasePage.Select_BillingShipping_Address(this.DefaultBillingID);
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = this.ReplaceAllTags(dataTable, dataTable1, Convert.ToInt64(StoreUserID), (long)0, CompanyID, "NEWUSER");
                EmailClass.SendMailMessage(this.emailFrom, this.EmailID, this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public string ReplaceAllTags(DataTable dtEmail, DataTable dtBody, long OrderID, long StoreUserID, int CompanyID, string Type)
        {
            string str;
            string[] keySeparator;
            string cartAdditionalOptionName;
            char[] chrArray;
            object[] accountID;
            string empty = string.Empty;
            string empty1 = string.Empty;
            if (ConnectionClass.PublicDocPath != null)
            {
                empty1 = ConnectionClass.PublicDocPath.ToString();
            }
            empty1 = empty1.Replace("document/", "");
            if (ConnectionClass.FileExtension != null)
            {
                this.eprintDocument = ConnectionClass.eprintDocument;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
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

            string empty222 = string.Empty;
            string str222 = string.Empty;
            string empty223 = string.Empty;
            string str223 = string.Empty;
            string empty224 = string.Empty;
            string str224 = string.Empty;
            string empty225 = string.Empty;
            //string str225 = string.Empty;
            //string empty226 = string.Empty;

            foreach (DataRow dataRow in CartBasePage.default_settings(CompanyID, this.Account_ID).Rows)
            {
                this.jobScreenName = this.objBase.SpecialDecode(dataRow["cartjobScreenName"].ToString());
            }
            if (Type.ToLower().Trim() == "new order")
            {
                this.emailfor = "Admin";
            }
            else if (Type.ToLower().Trim() != "new b2b order")
            {
                this.emailfor = "Customer";
            }
            else
            {
                this.emailfor = "Approver";
            }
            foreach (DataRow row1 in dtEmail.Rows)
            {
                if (!dtEmail.Columns.Contains("EmailToCustomerID"))
                {
                    continue;
                }
                this.EmailToCustomerID = Convert.ToInt64(row1["EmailToCustomerID"].ToString());
            }
            DataTable dataTable = OrderBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow dataRow1 in OrderBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
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
                    empty15 = (dataRow1["IsItemCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsCustomerCode"].ToString() != "")
                {
                    str15 = (dataRow1["IsCustomerCode"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (dataRow1["IsUnitOfMeasure"].ToString() == "")
                {
                    continue;
                }
                empty16 = (dataRow1["IsUnitOfMeasure"].ToString().ToLower() != "true" ? "false" : "true");

                empty222 = (dataRow1["IsItemDescription"].ToString().ToLower() != "true" ? "false" : "true");
                str222 = (dataRow1["IsWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty223 = (dataRow1["IsCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str223 = (dataRow1["IsOrderedWeight"].ToString().ToLower() != "true" ? "false" : "true");
                empty224 = (dataRow1["IsOrderedCubicMeasurment"].ToString().ToLower() != "true" ? "false" : "true");
                str224 = (dataRow1["IsPerQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                empty225 = (dataRow1["IsDimensions"].ToString().ToLower() != "true" ? "false" : "true");
                //str225 = (dataRow1["IsWidth"].ToString().ToLower() != "true" ? "false" : "true");
                //empty226 = (dataRow1["IsHeight"].ToString().ToLower() != "true" ? "false" : "true");
            }
            if (Type.ToLower().Trim() == "password")
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.strSitepath, "login.aspx?id=", this.Account_ID);
                }
                else
                {
                    this.loginLink = string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
                EmailClass.storeName = this.AccountName;
                foreach (DataRow row2 in dtEmail.Rows)
                {
                    this.EmailID = row2["EmailID"].ToString().Trim();
                    this.Pwd = row2["Password"].ToString().Trim();
                    this.ContactName = string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString());
                }
                foreach (DataRow dataRow2 in dtBody.Rows)
                {
                    this.TagBody = dataRow2["Body"].ToString().Trim();
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
                string str16 = string.Empty;
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
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click here to view details</a>");
                this.Cart_AdditionalOptionName = "";
                this.Cart_AdditionalOptionValue = "";
                this.Cart_AdditionalOption = "";
                this.Cart_Additional_OV = new decimal(0);
                foreach (DataRow row3 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    EmailClass emailClass = this;
                    cartAdditionalOptionName = emailClass.Cart_AdditionalOptionName;
                    keySeparator = new string[] { cartAdditionalOptionName, row3["WebOtherCostName"].ToString(), "- ", row3["SelectedValue"].ToString(), "<br />" };
                    emailClass.Cart_AdditionalOptionName = string.Concat(keySeparator);
                    EmailClass emailClass1 = this;
                    emailClass1.Cart_AdditionalOptionValue = string.Concat(emailClass1.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row3["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    EmailClass cartAdditionalOV = this;
                    cartAdditionalOV.Cart_Additional_OV = cartAdditionalOV.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row3["TotalPrice"].ToString()), 2, "", false, false, true));
                    EmailClass emailClass2 = this;
                    cartAdditionalOptionName = emailClass2.Cart_AdditionalOption;
                    keySeparator = new string[] { cartAdditionalOptionName, row3["WebOtherCostName"].ToString(), "- ", row3["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row3["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    emailClass2.Cart_AdditionalOption = string.Concat(keySeparator);
                }
                foreach (DataRow dataRow3 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow3["Subject"].ToString();
                    this.TagBody = dataRow3["Body"].ToString();
                    foreach (DataRow row4 in dtBody.Rows)
                    {
                        EmailClass.storeName = row4["accountName"].ToString();
                        EmailClass.order_No = row4["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row4["createdBy"].ToString());
                        EmailClass.Pdf_File = string.Concat(EmailClass.Pdf_File, row4["CatalogueName"].ToString(), "Ð");
                        if (row4["PDFNameFromCart"].ToString() != "")
                        {
                            empty = string.Concat(empty, row4["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (row4["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty = string.Concat(empty, row4["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row4["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row4["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = row4["Comments"].ToString();
                        this.UserID = Convert.ToInt32(row4["createdBy"].ToString());
                        int num = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable1 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row4["OrderItemID"]));
                        foreach (DataRow dataRow4 in dataTable1.Rows)
                        {
                            if (dataRow4["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow4["UserFriendlyName"].ToString(), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, dataRow4["UserFriendlyName"].ToString(), "<br/>");
                                if (dataRow4["Question"].ToString() == "")
                                {
                                    keySeparator = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", dataRow4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(keySeparator);
                                }
                                else
                                {
                                    keySeparator = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", dataRow4["Question"].ToString(), ": ", dataRow4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(keySeparator);
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
                        if (row4["ProductImage"].ToString() == "")
                        {
                            str = "m_no_image_available.jpeg";
                        }
                        else
                        {
                            str = row4["ProductImage"].ToString().Remove(0, 2);
                            str = string.Concat("m_", str);
                        }
                        decimal num1 = Convert.ToDecimal(row4["OrderItemTotalPrice"].ToString());
                        decimal num2 = Convert.ToDecimal(row4["OrderItemTax"].ToString());
                        decimal num3 = num1;
                        decimal num4 = num3 + num2;
                        this.SUB_TOTAL = this.SUB_TOTAL + num1;
                        this.TAX_DETAILS = Convert.ToDecimal(row4["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num3;
                        if (row4["OrderedHeight"].ToString() != "")
                        {
                            this.OrderHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row4["OrderedHeight"]), 2, "", false, false, true);
                            if (this.OrderHeight == "0.00")
                            {
                                this.OrderHeight = "";
                            }
                        }
                        if (row4["OrderedWidth"].ToString() != "")
                        {
                            this.OrderWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row4["OrderedWidth"]), 2, "", false, false, true);
                            if (this.OrderWidth == "0.00")
                            {
                                this.OrderWidth = "";
                            }
                        }
                        if (row4["ProductHeight"].ToString() != "")
                        {
                            this.ProductHeight = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row4["ProductHeight"]), 2, "", false, false, true);
                            if (this.ProductHeight == "0.00")
                            {
                                this.ProductHeight = "";
                            }
                        }
                        if (row4["ProductWidth"].ToString() != "")
                        {
                            this.ProductWidth = this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, Convert.ToDecimal(row4["ProductWidth"]), 2, "", false, false, true);
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
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row4["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            stringBuilder.Append(str16);
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", this.objBase.SpecialDecode(row4["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row4["Quantity"].ToString(), "</td></tr>"));
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
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }

                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", base.SpecialDecode(row4["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", base.SpecialDecode(row4["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", row4["SoldInPacksof"].ToString(), "</td></tr>"));
                            }

                            if (empty222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row4["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row4["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row4["CBMWeight"]) / Convert.ToDouble(row4["PerQuantity"])) * Convert.ToDouble(row4["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row4["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row4["CBMMeasurement"]) / Convert.ToDouble(row4["PerQuantity"])) * Convert.ToDouble(row4["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row4["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row4["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row4["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", row4["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", row4["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", row4["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", this.objBase.SpecialDecode(row4["JobName"].ToString()), "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", row4["Quantity"].ToString(), "</td></tr>"));
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
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder.Append(string.Concat(keySeparator));
                            }

                            if (empty15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", base.SpecialDecode(row4["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", base.SpecialDecode(row4["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Unit of Measure: </td><td valign='top'>", row4["SoldInPacksof"].ToString(), "</td></tr>"));
                            }

                            if (empty222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Item Description: </td><td valign='top'>", row4["ItemDescr"].ToString().Replace("\r\n", "</br>"), "</td></tr>"));
                            }
                            if (str222 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Weight: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["CBMWeight"]), 2), "</td></tr>"));
                            }
                            if (empty223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Cubic Measurment: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["CBMMeasurement"]), 2), "</td></tr>"));
                            }
                            var orderedweight = Convert.ToInt32(row4["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row4["CBMWeight"]) / Convert.ToDouble(row4["PerQuantity"])) * Convert.ToDouble(row4["Quantity"]); if (str223 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Weight: </td><td valign='top'>", Math.Round(orderedweight, 2), "</td></tr>"));
                            }
                            var OrderedCubicMeasurment = Convert.ToInt32(row4["PerQuantity"]) == 0 ? 0 : (Convert.ToDouble(row4["CBMMeasurement"]) / Convert.ToDouble(row4["PerQuantity"])) * Convert.ToDouble(row4["Quantity"]);
                            if (empty224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Cubic Measurment: </td><td valign='top'>", Math.Round(OrderedCubicMeasurment, 2), "</td></tr>"));
                            }
                            if (str224 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Per Quantity: </td><td valign='top'>", Math.Round(Convert.ToDouble(row4["PerQuantity"]), 2), "</td></tr>"));
                            }
                            if (empty225 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(row4["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(row4["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(row4["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", row4["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", row4["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
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
                    keySeparator = new string[] { this.comm.GetCurrencyinRequiredFormate("", true) ?? "" };
                    string[] strArrays = this.Cart_AdditionalOptionValue.Split(keySeparator, StringSplitOptions.None);
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
                    foreach (DataRow row5 in dtBody.Rows)
                    {
                        this.TAXD = Convert.ToDecimal(row5["TAX"]);
                        num5 = num5 + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)) + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAXD, 2, "", false, false, true));
                        this.TagBody = this.TagBody.Replace("[$TOTAL$]", string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, num5, 2, "", false, false, true))));
                    }
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays1 = empty.Split(chrArray);
                    string pdfFile = EmailClass.Pdf_File;
                    chrArray = new char[] { 'Ð' };
                    string[] strArrays2 = pdfFile.Split(chrArray);
                    string empty17 = string.Empty;
                    if (empty != "")
                    {
                        for (int j = 0; j < (int)strArrays2.Length; j++)
                        {
                            if ((int)strArrays1.Length == (int)strArrays2.Length && strArrays1[j].ToString().Trim() != "")
                            {
                                string str17 = strArrays1[j].ToString();
                                chrArray = new char[] { '\u00A7' };
                                string[] strArrays3 = str17.Split(chrArray);
                                empty = strArrays3[0].ToString();
                                string str18 = strArrays3[1].ToString();
                                EmailClass.Pdf_File = strArrays2[j].ToString();
                                if (str18 != "et")
                                {
                                    accountID = new object[] { empty17, "<div><a href='", empty1, "EmailPdf.aspx?File=", empty, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", EmailClass.Pdf_File, "</a></div>" };
                                    empty17 = string.Concat(accountID);
                                }
                                else
                                {
                                    accountID = new object[] { empty17, "<div><a href='", empty1, "EmailPdf.aspx?File=", empty, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                                    empty17 = string.Concat(accountID);
                                }
                            }
                        }
                    }
                    EmailClass.Pdf_File = "";
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty17);
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
                foreach (DataRow dataRow5 in OrderBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID.ToString()).Rows)
                {
                    EmailClass emailClass3 = this;
                    cartAdditionalOptionName = emailClass3.Cart_AdditionalOptionName;
                    keySeparator = new string[] { cartAdditionalOptionName, dataRow5["WebOtherCostName"].ToString(), "- ", dataRow5["SelectedValue"].ToString(), "<br />" };
                    emailClass3.Cart_AdditionalOptionName = string.Concat(keySeparator);
                    EmailClass emailClass4 = this;
                    emailClass4.Cart_AdditionalOptionValue = string.Concat(emailClass4.Cart_AdditionalOptionValue, this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true), "<br />");
                    EmailClass emailClass5 = this;
                    cartAdditionalOptionName = emailClass5.Cart_AdditionalOption;
                    keySeparator = new string[] { cartAdditionalOptionName, dataRow5["WebOtherCostName"].ToString(), "- ", dataRow5["SelectedValue"].ToString(), ": ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    emailClass5.Cart_AdditionalOption = string.Concat(keySeparator);
                    EmailClass cartAdditionalOV1 = this;
                    cartAdditionalOV1.Cart_Additional_OV = cartAdditionalOV1.Cart_Additional_OV + Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow5["TotalPrice"].ToString()), 2, "", false, false, true));
                }
                DataTable dataTable2 = new DataTable();
                DataTable dataTable3 = new DataTable();
                foreach (DataRow row6 in dtEmail.Rows)
                {
                    this.emailSubject = row6["Subject"].ToString();
                    this.TagBody = row6["Body"].ToString();
                    foreach (DataRow dataRow6 in dtBody.Rows)
                    {
                        dataTable2 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow6["BillingAddressID"]));
                        dataTable3 = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(dataRow6["ShippingAddressID"]));
                        this.AccountName = dataRow6["accountName"].ToString();
                        EmailClass.order_No = dataRow6["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow6["createdBy"].ToString());
                        EmailClass.Pdf_File = string.Concat(EmailClass.Pdf_File, dataRow6["CatalogueName"].ToString(), "Ð");
                        if (dataRow6["PDFNameFromCart"].ToString() != "")
                        {
                            empty = string.Concat(empty, dataRow6["PDFNameFromCart"].ToString(), "§etÐ");
                        }
                        else if (dataRow6["PrintReadyFile"].ToString().Trim().Length > 0)
                        {
                            empty = string.Concat(empty, dataRow6["PrintReadyFile"].ToString(), "§prÐ");
                        }
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow6["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow6["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = dataRow6["Comments"].ToString();
                        this.customerName = string.Concat(dataRow6["FirstName"].ToString(), " ", dataRow6["LastName"].ToString());
                        int num10 = 0;
                        this.additionalProductDetails = "";
                        DataTable dataTable4 = OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow6["OrderItemID"]));
                        foreach (DataRow row7 in dataTable4.Rows)
                        {
                            if (row7["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, row7["UserFriendlyName"].ToString(), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, row7["UserFriendlyName"].ToString(), "<br/>");
                                if (row7["Question"].ToString() == "")
                                {
                                    keySeparator = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", row7["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(keySeparator);
                                }
                                else
                                {
                                    keySeparator = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", row7["Question"].ToString(), ": ", row7["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(keySeparator);
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
                        if (empty18 != "")
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", dataRow6["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            stringBuilder5.Append(empty18);
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", this.objBase.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
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
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", base.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", base.SpecialDecode(dataRow6["CustomerCode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
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
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow6["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow6["CBMHeight"].ToString(), "</td></tr>"));
                            //}


                            stringBuilder9.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder5.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder5.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (str10 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", dataRow6["CatalogueName"].ToString(), "</td></tr>"));
                            }
                            if (empty11 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>", this.jobScreenName, ": </td><td valign='top'>", this.objBase.SpecialDecode(dataRow6["JobName"].ToString()), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str11 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity(s): </td><td valign='top'>", dataRow6["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (empty12 == "true")
                            {
                                keySeparator = new string[] { "<tr><td width='150px' valign='top'>Total Price(inc.Tax): <td valign='top'>", this.comm.GetCurrencyinRequiredFormate("", true), " ", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num14, 2, "", false, false, true), "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
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
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Height(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductHeight, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (str13 == "true")
                            {
                                keySeparator = new string[] { "<tr><td class='tagswidth'>Product Width(", dataTable.Rows[0]["PaperMeasure"].ToString(), "): <td class='tags_valigntop'>", this.ProductWidth, "</td></tr>" };
                                stringBuilder5.Append(string.Concat(keySeparator));
                            }
                            if (empty15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Item Code: </td><td valign='top'>", base.SpecialDecode(dataRow6["ItemCode"].ToString()), "</td></tr>"));
                            }
                            if (str15 == "true")
                            {
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Customer Code: </td><td valign='top'>", base.SpecialDecode(dataRow6["Customercode"].ToString()), "</td></tr>"));
                            }
                            if (empty16 == "true")
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
                                stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Dimensions: </td><td valign='top'>", "Length: ", Math.Round(Convert.ToDouble(dataRow6["CBMLength"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Width: ", Math.Round(Convert.ToDouble(dataRow6["CBMWidth"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), " Height: ", Math.Round(Convert.ToDouble(dataRow6["CBMHeight"]), 2), " ", dataTable.Rows[0]["PaperMeasure"].ToString(), "</td></tr>"));
                            }
                            //if (str225 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Width: </td><td valign='top'>", dataRow6["CBMWidth"].ToString(), "</td></tr>"));
                            //}
                            //if (empty226 == "true")
                            //{
                            //    stringBuilder5.Append(string.Concat("<tr><td width='150px' valign='top'>Height: </td><td valign='top'>", dataRow6["CBMHeight"].ToString(), "</td></tr>"));
                            //}

                            stringBuilder9.Append("</table><br/>");
                            stringBuilder5.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    EmailClass tOTAL2 = this;
                    tOTAL2.TOTAL = tOTAL2.TOTAL + this.Cart_Additional_OV;
                    EmailClass tOTAL3 = this;
                    tOTAL3.TOTAL = tOTAL3.TOTAL + ((this.TOTAL * this.TAX_DETAILS) / new decimal(100));
                }
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
                this.emailSubject = this.emailSubject.Replace("\r\n", "");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                chrArray = new char[] { 'Ð' };
                string[] strArrays4 = empty.Split(chrArray);
                string pdfFile1 = EmailClass.Pdf_File;
                chrArray = new char[] { 'Ð' };
                string[] strArrays5 = pdfFile1.Split(chrArray);
                string empty19 = string.Empty;
                if (empty != "")
                {
                    for (int k = 0; k < (int)strArrays5.Length; k++)
                    {
                        if ((int)strArrays4.Length == (int)strArrays5.Length && strArrays4[k].ToString().Trim() != "")
                        {
                            string str19 = strArrays4[k].ToString();
                            chrArray = new char[] { '\u00A7' };
                            string[] strArrays6 = str19.Split(chrArray);
                            empty = strArrays6[0].ToString();
                            string str20 = strArrays6[1].ToString();
                            EmailClass.Pdf_File = strArrays5[k].ToString();
                            if (str20 != "et")
                            {
                                accountID = new object[] { empty19, "<div><a href='", empty1, "EmailPdf.aspx?File=", empty, "&Account=", this.Account_ID, "&CompanyID=", CompanyID, "&type=pr'>", EmailClass.Pdf_File, "</a></div>" };
                                empty19 = string.Concat(accountID);
                            }
                            else
                            {
                                accountID = new object[] { empty19, "<div><a href='", empty1, "EmailPdf.aspx?File=", empty, "&AccountName=", EmailClass.storeName, "&CompanyID=", CompanyID, "&type=et&accountid=", this.Account_ID, "'>", EmailClass.Pdf_File, "</a></div>" };
                                empty19 = string.Concat(accountID);
                            }
                        }
                    }
                }
                EmailClass.Pdf_File = "";
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
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty19);
                foreach (DataRow dataRow7 in dataTable2.Rows)
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
                foreach (DataRow row8 in dataTable3.Rows)
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
            if (Type.ToLower().Trim() == "newuser")
            {
                StringBuilder stringBuilder10 = new StringBuilder();
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.strSitepath, "login.aspx?id=", this.Account_ID);
                }
                else
                {
                    this.loginLink = string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
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
            string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
            string str1 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
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
            long num = (long)0;
            if (HttpContext.Current.Session["StoreUserID"] != null && HttpContext.Current.Session["StoreUserID"].ToString() != "")
            {
                num = long.Parse(HttpContext.Current.Session["StoreUserID"].ToString());
            }
            long num1 = (long)0;
            if (HttpContext.Current.Session["companyID"] != null && HttpContext.Current.Session["companyID"].ToString() != "")
            {
                num1 = long.Parse(HttpContext.Current.Session["companyID"].ToString());
            }
            SqlConnection sqlConnection = new SqlConnection(str1);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ServerName", str);
            sqlCommand.Parameters.AddWithValue("@CompanyID", num1);
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
            sqlCommand.Parameters.AddWithValue("@StoreName", EmailClass.storeName);
            sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

    }
}