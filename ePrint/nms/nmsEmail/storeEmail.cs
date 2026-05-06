using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
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
    public class storeEmail
    {
        private commonClass comm = new commonClass();

        private AccountsBaseClass objacc = new AccountsBaseClass();

        private CompanyBasePage objcomp = new CompanyBasePage();

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

        public string EmailID = string.Empty;

        public string Pwd = string.Empty;

        public string AccountName = string.Empty;

        public string loginLink = string.Empty;

        public string Cart_AdditionalOptionName = string.Empty;

        public string Cart_AdditionalOptionValue = string.Empty;

        public string Cart_AdditionalOption = string.Empty;

        public string Consignee_URL = string.Empty;

        public string ConsignmentNote_Number = string.Empty;

        public string StoreURL = string.Empty;

        public string FileExtention = string.Empty;

        public string OrderKey = string.Empty;

        public int Company_ID;

        public int Account_ID;

        public int StoreUser_ID;

        public int UserType_ID;

        public int UserID;

        private decimal SUB_TOTAL;

        private decimal TAX_DETAILS;

        private decimal TOTAL;

        public bool IsArtwork;

        public bool IsActive;

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public long EmailToCustomerID;

        public string Eventname = string.Empty;

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

        public void emailB2BRegisterDetails(long StoreUserID, int CompanyID, long AccountID, string TagEvent)
        {
            global.filePath();
            this.Company_ID = CompanyID;
            this.Account_ID = Convert.ToInt32(AccountID);
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.TagBody = "";
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.Company_ID, this.Account_ID, (long)0, TagEvent, "Customer");
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                this.TagBody = row["Body"].ToString();
            }
            DataTable dataTable = CompanyBasePage.StoreUser_select(StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.FirstName = dataRow["FirstName"].ToString().Trim();
                this.LastName = dataRow["LastName"].ToString().Trim();
                this.EmailID = dataRow["EmailID"].ToString().Trim();
                this.Pwd = dataRow["Password"].ToString().Trim();
                this.AccountName = dataRow["CompanyName"].ToString();
                this.emailFrom = dataRow["marketingEmail"].ToString();
                storeEmail.StoreNameB2bRegistration = dataRow["accountname"].ToString();
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on")
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, (long)0, (long)0, CompanyID, "B2BContactRegistration");
                storeEmail.SendMailMessage(this.emailFrom, this.EmailID, this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void emailInvalidLoginDetail(string EmailList, string IPAddress, string Username, long CompanyID, string SystemURL)
        {
            this.EmailEnable = ConnectionClass.EmailEnable;
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Unauth_Access_EmailBody_Details(CompanyID);
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Subject"].ToString();
                str = row["Body"].ToString();
                empty1 = row["FooterText"].ToString();
            }
            empty = empty.Replace("[$IPAddress$]", IPAddress).Replace("[$UserName$]", Username).Replace("[$SystemURL$]", SystemURL);
            str = string.Concat(str.Replace("[$IPAddress$]", IPAddress).Replace("[$UserName$]", Username).Replace("[$SystemURL$]", SystemURL), "<br/><br/> ", empty1);
            string[] strArrays = EmailList.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                if (this.EmailEnable.ToLower().Trim() == "on")
                {
                    //string str2 = "support@eprintsoftware.com";
                    string str2 = "support@hexicomsoftware.com";
                    storeEmail.storeName = "Support Team";
                    string str3 = "emaillogs@hexicomsoftware.com";
                    storeEmail.SendMailMessage(str2, str1, str3, this.emailCC.Trim(), empty, str, this.emailAttachment, true);
                }
            }
        }

        public void emailOrdersDetails(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent)
        {
            string str = global.filePath();
            string str1 = global.SecureDocPath();
            string serverName = ConnectionClass.ServerName;
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.TagBody = "";
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.Company_ID, Convert.ToInt32(this.Account_ID), (long)0, TagEvent, "Customer");
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable = WebstoreBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.emailTo = dataRow["EmailID"].ToString();
                this.emailFrom = dataRow["marketingEmail"].ToString();
                storeEmail.storeName = dataRow["accountName"].ToString();
                if (!this.IsArtwork)
                {
                    continue;
                }
                if (dataRow["UploadFile"].ToString() != "")
                {
                    object[] accountID = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(accountID);
                }
                if (dataRow["UploadFile1"].ToString() != "")
                {
                    object[] objArray = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile1"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(objArray);
                }
                if (dataRow["UploadFile2"].ToString() != "")
                {
                    object[] accountID1 = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile2"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(accountID1);
                }
                if (dataRow["PDFNameFromCart"].ToString() == "")
                {
                    continue;
                }
                object[] objArray1 = new object[] { this.emailAttachment, str1, serverName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                this.emailAttachment = string.Concat(objArray1);
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags(customerSelect, dataTable, OrderID, StoreUserID, CompanyID, "ORDERSHIPPING");
                storeEmail.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public void emailOrdersDetails_Item(long StoreUserID, long OrderID, int CompanyID, int AccountID, string TagEvent, long EstimateItemID)
        {
            string str = global.filePath();
            string str1 = global.SecureDocPath();
            string serverName = ConnectionClass.ServerName;
            this.Company_ID = CompanyID;
            this.Account_ID = AccountID;
            this.StoreUser_ID = Convert.ToInt32(StoreUserID);
            this.TagBody = "";
            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.Company_ID, Convert.ToInt32(this.Account_ID), (long)0, TagEvent, "Customer");
            foreach (DataRow row in customerSelect.Rows)
            {
                this.emailSubject = row["Subject"].ToString();
                this.IsArtwork = Convert.ToBoolean(row["IsArtwork"].ToString());
                this.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
            }
            DataTable dataTable = WebstoreBasePage.Select_OrderItems(OrderID, StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.emailTo = dataRow["EmailID"].ToString();
                this.emailFrom = dataRow["marketingEmail"].ToString();
                storeEmail.storeName = dataRow["accountName"].ToString();
                if (!this.IsArtwork)
                {
                    continue;
                }
                if (dataRow["UploadFile"].ToString() != "")
                {
                    object[] accountID = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(accountID);
                }
                if (dataRow["UploadFile1"].ToString() != "")
                {
                    object[] objArray = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile1"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(objArray);
                }
                if (dataRow["UploadFile2"].ToString() != "")
                {
                    object[] accountID1 = new object[] { this.emailAttachment, str, "\\document\\store\\", this.Account_ID, "\\", dataRow["UploadFile2"].ToString(), "µ" };
                    this.emailAttachment = string.Concat(accountID1);
                }
                if (dataRow["PDFNameFromCart"].ToString() == "")
                {
                    continue;
                }
                object[] objArray1 = new object[] { this.emailAttachment, str1, serverName, "\\store\\", this.Account_ID, "\\Pdf\\", dataRow["PDFNameFromCart"].ToString(), "µ" };
                this.emailAttachment = string.Concat(objArray1);
            }
            this.EmailEnable = ConnectionClass.EmailEnable;
            if (this.EmailEnable.ToLower().Trim() == "on" && this.IsActive)
            {
                this.email_return_body = "";
                this.email_return_body = this.ReplaceAllTags_Item(customerSelect, dataTable, OrderID, StoreUserID, CompanyID, "ORDERSHIPPING");
                storeEmail.SendMailMessage(this.emailFrom.Trim(), this.emailTo.Trim(), this.emailBCC.Trim(), this.emailCC.Trim(), this.emailSubject, this.email_return_body, this.emailAttachment, true);
            }
        }

        public string ReplaceAllTags(DataTable dtEmail, DataTable dtBody, long OrderID, long StoreUserID, int CompanyID, string Type)
        {
            string str;
            string[] storeURL;
            global.filePath();
            string str1 = global.sitePath();
            string empty = string.Empty;
            string empty1 = string.Empty;
            BaseClass baseClass = new BaseClass();
            foreach (DataRow row in AccountsBaseClass.accounts_getAccountDetails(this.Account_ID).Rows)
            {
                this.StoreURL = row["StoreURL"].ToString();
                this.FileExtention = row["FileExtention"].ToString();
                empty1 = row["accountType"].ToString();
            }
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            foreach (DataRow dataRow in dtEmail.Rows)
            {
                this.EmailToCustomerID = Convert.ToInt64(dataRow["EmailToCustomerID"].ToString());
            }
            foreach (DataRow row1 in WebstoreBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
                if (row1["IsProductName"].ToString() != "")
                {
                    empty2 = (row1["IsProductName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsJobName"].ToString() != "")
                {
                    str2 = (row1["IsJobName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsQuantity"].ToString() != "")
                {
                    empty3 = (row1["IsQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsTotalPrice"].ToString() != "")
                {
                    str3 = (row1["IsTotalPrice"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsOrderedWidth"].ToString() != "")
                {
                    empty4 = (row1["IsOrderedWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsOrderedHeight"].ToString() != "")
                {
                    str4 = (row1["IsOrderedHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsProductWidth"].ToString() != "")
                {
                    empty5 = (row1["IsProductWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsProductHeight"].ToString() != "")
                {
                    str5 = (row1["IsProductHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsAdditionalOption"].ToString() == "")
                {
                    continue;
                }
                empty6 = (row1["IsAdditionalOption"].ToString().ToLower() != "true" ? "false" : "true");
            }
            foreach (DataRow dataRow1 in WebstoreBasePage.Select_OrderItems(OrderID, (long)this.StoreUser_ID).Rows)
            {
                this.OrderKey = dataRow1["OrderKey"].ToString();
            }
            if (Type.ToLower().Trim() == "ordershipping")
            {
                string lower = string.Empty;
                string str6 = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                DataTable dataTable = SettingsBasePage.Setting_SpendLimit_Select((long)this.Account_ID, (long)CompanyID);
                if (dataTable.Rows.Count <= 0)
                {
                    lower = "false";
                }
                else
                {
                    foreach (DataRow row2 in dataTable.Rows)
                    {
                        lower = row2["EnableHidePrice"].ToString().ToLower();
                    }
                }
                this.additionalProductDetails = "";
                this.TagBody = "";
                if (empty1.ToLower() == "p")
                {
                    this.orderLink = string.Concat(this.StoreURL, "/order.aspx?OrdKey=", this.OrderKey);
                }
                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.orderLink = string.Concat(this.StoreURL, "/order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    storeURL = new string[] { this.StoreURL, "/order", ConnectionClass.KeySeparator, this.OrderKey, this.FileExtention };
                    this.orderLink = string.Concat(storeURL);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click to view details</a>");
                foreach (DataRow dataRow2 in WebstoreBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail = this;
                    string cartAdditionalOptionName = _storeEmail.Cart_AdditionalOptionName;
                    string[] strArrays = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(dataRow2["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(dataRow2["SelectedValue"].ToString()), "<br />" };
                    _storeEmail.Cart_AdditionalOptionName = string.Concat(strArrays);
                    storeEmail _storeEmail1 = this;
                    _storeEmail1.Cart_AdditionalOptionValue = string.Concat(_storeEmail1.Cart_AdditionalOptionValue, "$", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["SelectedPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail2 = this;
                    string cartAdditionalOption = _storeEmail2.Cart_AdditionalOption;
                    string[] strArrays1 = new string[] { cartAdditionalOption, baseClass.SpecialDecode(dataRow2["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(dataRow2["SelectedValue"].ToString()), ": $", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow2["SelectedPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail2.Cart_AdditionalOption = string.Concat(strArrays1);
                }
                foreach (DataRow row3 in WebstoreBasePage.Select_ConsignmentNote(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail3 = this;
                    _storeEmail3.Consignee_URL = string.Concat(_storeEmail3.Consignee_URL, row3["ConsigneeUrl"].ToString(), ",");
                    storeEmail _storeEmail4 = this;
                    _storeEmail4.ConsignmentNote_Number = string.Concat(_storeEmail4.ConsignmentNote_Number, row3["Consignmentnumber"].ToString(), ",");
                }
                this.Consignee_URL = baseClass.SpecialDecode(this.Consignee_URL);
                this.ConsignmentNote_Number = baseClass.SpecialDecode(this.ConsignmentNote_Number);
                foreach (DataRow dataRow3 in dtEmail.Rows)
                {
                    this.emailSubject = dataRow3["Subject"].ToString();
                    this.TagBody = dataRow3["Body"].ToString();
                    foreach (DataRow row4 in dtBody.Rows)
                    {
                        storeEmail.storeName = row4["accountName"].ToString();
                        storeEmail.order_No = row4["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(row4["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, row4["CatalogueName"].ToString(), ",");
                        empty = string.Concat(empty, row4["PDFNameFromCart"].ToString(), ",");
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(row4["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(row4["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = row4["Comments"].ToString().Replace("\n", "<br />");
                        this.UserID = Convert.ToInt32(row4["createdBy"].ToString());
                        this.Eventname = row4["Eventname"].ToString();
                        int num = 0;
                        DataTable dataTable1 = WebstoreBasePage.Select_OrderAdditionalItems(Convert.ToInt64(row4["OrderItemID"]));
                        foreach (DataRow dataRow4 in dataTable1.Rows)
                        {
                            if (dataRow4["MainCalculationType"].ToString() == "m")
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(dataRow4["UserFriendlyName"].ToString()), "<br/>");
                            }
                            else
                            {
                                this.additionalProductDetails = string.Concat(this.additionalProductDetails, baseClass.SpecialDecode(dataRow4["UserFriendlyName"].ToString()), "<br/>");
                                if (dataRow4["Question"].ToString() == "")
                                {
                                    storeURL = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", dataRow4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(storeURL);
                                }
                                else
                                {
                                    storeURL = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", dataRow4["Question"].ToString(), ": ", dataRow4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(storeURL);
                                }
                            }
                            num++;
                        }
                        if (num == 0)
                        {
                            str6 = "";
                        }
                        else if (empty6 == "true")
                        {
                            str6 = "<tr><td width='150px' valign='top'><b>Additional Items: </b></td>";
                            str6 = string.Concat(str6, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
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
                        decimal num3 = num1 + num2;
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
                        this.SUB_TOTAL = this.SUB_TOTAL + num1;
                        this.TAX_DETAILS = Convert.ToDecimal(row4["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num3;
                        if (str6 != "")
                        {
                            stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(row4["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder.Append(str6);
                            if (str2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Job Name: </td><td valign='top'>", baseClass.SpecialDecode(row4["JobName"].ToString()), "</td></tr>"));
                            }
                            if (empty3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity (s): </td><td valign='top'>", row4["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (lower == "false" && str3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price (inc. Tax): <td valign='top'>", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num3, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (str4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: <td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (empty4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: <td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (str5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Height: <td valign='top'>", this.ProductHeight, "</td></tr>"));
                            }
                            if (empty5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Width: <td valign='top'>", this.ProductWidth, "</td></tr>"));
                            }
                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(row4["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (str2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Job Name: </td><td valign='top'>", baseClass.SpecialDecode(row4["JobName"].ToString()), "</td></tr>"));
                            }
                            if (empty3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity (s): </td><td valign='top'>", row4["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (lower == "fasle" && str3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price (inc. Tax): <td valign='top'>", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num3, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (str4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: <td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (empty4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: <td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (str5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Height: <td valign='top'>", this.ProductHeight, "</td></tr>"));
                            }
                            if (empty5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Width: <td valign='top'>", this.ProductWidth, "</td></tr>"));
                            }
                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    if (lower != "false")
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", "");
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", "");
                    }
                    else
                    {
                        this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)));
                        this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    }
                    this.emailSubject = this.emailSubject.Replace("[$STORE$]", storeEmail.storeName);
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", this.Comments);
                    if (lower != "false")
                    {
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", "");
                    }
                    else
                    {
                        this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true)));
                    }
                    this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$ConsigneeURL$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$Consignment Note Number$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    this.emailSubject = this.emailSubject.Replace("\r\n", "");
                    this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays2 = empty.Split(chrArray);
                    string pdfFile = storeEmail.Pdf_File;
                    chrArray = new char[] { ',' };
                    string[] strArrays3 = pdfFile.Split(chrArray);
                    string empty7 = string.Empty;
                    for (int i = 0; i < (int)strArrays3.Length; i++)
                    {
                        empty = strArrays2[i].ToString();
                        storeEmail.Pdf_File = strArrays3[i].ToString();
                        object[] accountID = new object[] { empty7, "<div><a href='", str1, "EmailPdf.aspx?File=", empty, "&Account=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                        empty7 = string.Concat(accountID);
                    }
                    storeEmail.Pdf_File = "";
                    if (lower != "false")
                    {
                        this.Cart_AdditionalOptionValue = "";
                        this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", "");
                        this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", "");
                    }
                    else
                    {
                        this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)));
                        this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    }
                    this.TagBody = this.TagBody.Replace("[$STORE$]", storeEmail.storeName);
                    this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                    this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true)));
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty7);
                    this.TagBody = this.TagBody.Replace("[$ConsigneeURL$]", this.Consignee_URL);
                    this.TagBody = this.TagBody.Replace("[$Consignment Note Number$]", this.ConsignmentNote_Number);
                    this.TagBody = this.TagBody.Replace("[$CAMPAIGN_NAME$]", this.Eventname);
                    this.TagBody = this.TagBody.Replace("\r\n", "");
                }
            }
            if (Type.ToLower().Trim() == "b2bcontactregistration")
            {
                StringBuilder stringBuilder1 = new StringBuilder();
                if (empty1.ToLower() == "p")
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login.aspx?id=", this.Account_ID);
                }
                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login.aspx");
                }
                else
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
                this.EmailID = this.EmailID.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.Pwd = this.Pwd.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", storeEmail.StoreNameB2bRegistration);
                this.emailSubject = this.emailSubject.Replace("[$STORE_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$PERSONAL_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                this.TagBody = this.TagBody.Replace("[$STORE$]", storeEmail.StoreNameB2bRegistration);
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$USER_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$URL$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$CONTACT_NAME$]", this.FirstName + " " + this.LastName);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            return this.TagBody;
        }

        public string ReplaceAllTags_Item(DataTable dtEmail, DataTable dtBody, long OrderID, long StoreUserID, int CompanyID, string Type)
        {
            string str;
            global.filePath();
            string str1 = global.sitePath();
            string empty = string.Empty;
            string empty1 = string.Empty;
            BaseClass baseClass = new BaseClass();
            foreach (DataRow row in AccountsBaseClass.accounts_getAccountDetails(this.Account_ID).Rows)
            {
                this.StoreURL = row["StoreURL"].ToString();
                this.FileExtention = row["FileExtention"].ToString();
                empty1 = row["accountType"].ToString();
            }
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            foreach (DataRow dataRow in dtEmail.Rows)
            {
                this.EmailToCustomerID = Convert.ToInt64(dataRow["EmailToCustomerID"].ToString());
            }
            foreach (DataRow row1 in WebstoreBasePage.Select_ProductDetailsTag(CompanyID, this.Account_ID, this.EmailToCustomerID).Rows)
            {
                if (row1["IsProductName"].ToString() != "")
                {
                    empty2 = (row1["IsProductName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsJobName"].ToString() != "")
                {
                    str2 = (row1["IsJobName"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsQuantity"].ToString() != "")
                {
                    empty3 = (row1["IsQuantity"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsTotalPrice"].ToString() != "")
                {
                    str3 = (row1["IsTotalPrice"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsOrderedWidth"].ToString() != "")
                {
                    empty4 = (row1["IsOrderedWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsOrderedHeight"].ToString() != "")
                {
                    str4 = (row1["IsOrderedHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsProductWidth"].ToString() != "")
                {
                    empty5 = (row1["IsProductWidth"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsProductHeight"].ToString() != "")
                {
                    str5 = (row1["IsProductHeight"].ToString().ToLower() != "true" ? "false" : "true");
                }
                if (row1["IsAdditionalOption"].ToString() == "")
                {
                    continue;
                }
                empty6 = (row1["IsAdditionalOption"].ToString().ToLower() != "true" ? "false" : "true");
            }
            foreach (DataRow dataRow1 in WebstoreBasePage.Select_OrderItems(OrderID, (long)this.StoreUser_ID).Rows)
            {
                this.OrderKey = dataRow1["OrderKey"].ToString();
            }
            if (Type.ToLower().Trim() == "ordershipping")
            {
                string str6 = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                this.additionalProductDetails = "";
                this.TagBody = "";
                if (empty1.ToLower() == "p")
                {
                    this.orderLink = string.Concat(this.StoreURL, "/order.aspx?OrdKey=", this.OrderKey);
                }
                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.orderLink = string.Concat(this.StoreURL, "/order.aspx?OrdKey=", this.OrderKey);
                }
                else
                {
                    string[] storeURL = new string[] { this.StoreURL, "/order", ConnectionClass.KeySeparator, this.OrderKey, this.FileExtention };
                    this.orderLink = string.Concat(storeURL);
                }
                this.orderLink = string.Concat("<a href=", this.orderLink, ">Click to view details</a>");
                foreach (DataRow row2 in WebstoreBasePage.Select_OrderAdditionalOptions(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail = this;
                    string cartAdditionalOptionName = _storeEmail.Cart_AdditionalOptionName;
                    string[] strArrays = new string[] { cartAdditionalOptionName, baseClass.SpecialDecode(row2["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row2["SelectedValue"].ToString()), "<br />" };
                    _storeEmail.Cart_AdditionalOptionName = string.Concat(strArrays);
                    storeEmail _storeEmail1 = this;
                    _storeEmail1.Cart_AdditionalOptionValue = string.Concat(_storeEmail1.Cart_AdditionalOptionValue, "$", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row2["SelectedPrice"].ToString()), 2, "", false, false, true), "<br />");
                    storeEmail _storeEmail2 = this;
                    string cartAdditionalOption = _storeEmail2.Cart_AdditionalOption;
                    string[] strArrays1 = new string[] { cartAdditionalOption, baseClass.SpecialDecode(row2["WebOtherCostName"].ToString()), "- ", baseClass.SpecialDecode(row2["SelectedValue"].ToString()), ": $", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row2["SelectedPrice"].ToString()), 2, "", false, false, true), "<br />" };
                    _storeEmail2.Cart_AdditionalOption = string.Concat(strArrays1);
                }
                foreach (DataRow dataRow2 in WebstoreBasePage.Select_ConsignmentNote(StoreUserID, OrderID).Rows)
                {
                    storeEmail _storeEmail3 = this;
                    _storeEmail3.Consignee_URL = string.Concat(_storeEmail3.Consignee_URL, dataRow2["ConsigneeUrl"].ToString(), ",");
                    storeEmail _storeEmail4 = this;
                    _storeEmail4.ConsignmentNote_Number = string.Concat(_storeEmail4.ConsignmentNote_Number, dataRow2["Consignmentnumber"].ToString(), ",");
                }
                this.Consignee_URL = baseClass.SpecialDecode(this.Consignee_URL);
                this.ConsignmentNote_Number = baseClass.SpecialDecode(this.ConsignmentNote_Number);
                foreach (DataRow row3 in dtEmail.Rows)
                {
                    this.emailSubject = row3["Subject"].ToString();
                    this.TagBody = row3["Body"].ToString();
                    foreach (DataRow dataRow3 in dtBody.Rows)
                    {
                        storeEmail.storeName = dataRow3["accountName"].ToString();
                        storeEmail.order_No = dataRow3["OrderNo"].ToString();
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        storeEmail.Pdf_File = string.Concat(storeEmail.Pdf_File, dataRow3["CatalogueName"].ToString(), ",");
                        empty = string.Concat(empty, dataRow3["PDFNameFromCart"].ToString(), ",");
                        this.orderDate = this.comm.Eprint_return_Date_Before_View(dataRow3["OrderDate"].ToString(), CompanyID, this.UserID, false);
                        this.RequiredBy = this.comm.Eprint_return_Date_Before_View(dataRow3["RequiredBy"].ToString(), CompanyID, this.UserID, false);
                        this.Comments = dataRow3["Comments"].ToString().Replace("\n", "<br />");
                        this.UserID = Convert.ToInt32(dataRow3["createdBy"].ToString());
                        int num = 0;
                        DataTable dataTable = WebstoreBasePage.Select_OrderAdditionalItems(Convert.ToInt64(dataRow3["OrderItemID"]));
                        foreach (DataRow row4 in dataTable.Rows)
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
                                    string[] strArrays2 = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic;font-size:10px;'>", row4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(strArrays2);
                                }
                                else
                                {
                                    string[] strArrays3 = new string[] { "<div>", this.additionalProductDetails, "</div><div style='padding-left:10px;font-style:italic; font-size:10px;'>", row4["Question"].ToString(), ": ", row4["SelectedValue"].ToString(), "</div>" };
                                    this.additionalProductDetails = string.Concat(strArrays3);
                                }
                            }
                            num++;
                        }
                        if (num == 0)
                        {
                            str6 = "";
                        }
                        else if (empty6 == "true")
                        {
                            str6 = "<tr><td width='150px' valign='top'><b>Additional Items: </b></td>";
                            str6 = string.Concat(str6, "<td valign='top'>", this.additionalProductDetails, "</td></tr>");
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
                        decimal num3 = num1 + num2;
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
                        this.SUB_TOTAL = this.SUB_TOTAL + num1;
                        this.TAX_DETAILS = Convert.ToDecimal(dataRow3["TaxRate"].ToString());
                        this.TOTAL = this.TOTAL + num3;
                        if (str6 != "")
                        {
                            stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            stringBuilder.Append(str6);
                            if (str2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Job Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>"));
                            }
                            if (empty3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity (s): </td><td valign='top'>", dataRow3["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (str3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='100px' valign='top'>Total Price (inc. Tax): <td valign='top'>", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num3, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (str4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: <td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (empty4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: <td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (str5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Height: <td valign='top'>", this.ProductHeight, "</td></tr>"));
                            }
                            if (empty5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Width: <td valign='top'>", this.ProductWidth, "</td></tr>"));
                            }
                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
                        }
                        else
                        {
                            stringBuilder.Append("<div style='clear:both'><div id='div_main' style='float:left;width:100%'><div id='div_left' style='float:left;'></div>");
                            stringBuilder.Append("<div id='div_right' style='float:left;width:100%;'><table>");
                            if (empty2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["CatalogueName"].ToString()), "</td></tr>"));
                            }
                            if (str2 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Job Name: </td><td valign='top'>", baseClass.SpecialDecode(dataRow3["JobName"].ToString()), "</td></tr>"));
                            }
                            if (empty3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Quantity (s): </td><td valign='top'>", dataRow3["Quantity"].ToString(), "</td></tr>"));
                            }
                            if (str3 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Total Price (inc. Tax): <td valign='top'>", this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, num3, 2, "", false, false, true), "</td></tr>"));
                            }
                            if (str4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Height: <td valign='top'>", this.OrderHeight, "</td></tr>"));
                            }
                            if (empty4 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Ordered Width: <td valign='top'>", this.OrderWidth, "</td></tr>"));
                            }
                            if (str5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Height: <td valign='top'>", this.ProductHeight, "</td></tr>"));
                            }
                            if (empty5 == "true")
                            {
                                stringBuilder.Append(string.Concat("<tr><td width='150px' valign='top'>Product Width: <td valign='top'>", this.ProductWidth, "</td></tr>"));
                            }
                            stringBuilder.Append("</table><br/>");
                            stringBuilder.Append("</div></div><div style='clear:both'>");
                        }
                    }
                    this.emailSubject = this.emailSubject.Replace("[$SUB_TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)));
                    this.emailSubject = this.emailSubject.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.emailSubject = this.emailSubject.Replace("[$STORE$]", storeEmail.storeName);
                    this.emailSubject = this.emailSubject.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.emailSubject = this.emailSubject.Replace("[$ORDER_LINK$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.emailSubject = this.emailSubject.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.emailSubject = this.emailSubject.Replace("[$COMMENT$]", this.Comments);
                    this.emailSubject = this.emailSubject.Replace("[$TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true)));
                    this.emailSubject = this.emailSubject.Replace("[$PRODUCT_DETAILS$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONNAME$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTIONVALUE$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$CART_ADDITIONALOPTION$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$ConsigneeURL$]", "*");
                    this.emailSubject = this.emailSubject.Replace("[$Consignment Note Number$]", "*");
                    this.emailSubject = this.emailSubject.Replace("\r\n", "");
                    this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays4 = empty.Split(chrArray);
                    string pdfFile = storeEmail.Pdf_File;
                    chrArray = new char[] { ',' };
                    string[] strArrays5 = pdfFile.Split(chrArray);
                    string empty7 = string.Empty;
                    for (int i = 0; i < (int)strArrays5.Length; i++)
                    {
                        empty = strArrays4[i].ToString();
                        storeEmail.Pdf_File = strArrays5[i].ToString();
                        object[] accountID = new object[] { empty7, "<div><a href='", str1, "EmailPdf.aspx?File=", empty, "&Account=", this.Account_ID, "'>", storeEmail.Pdf_File, "</a></div>" };
                        empty7 = string.Concat(accountID);
                    }
                    storeEmail.Pdf_File = "";
                    this.TagBody = this.TagBody.Replace("[$SUB_TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.SUB_TOTAL, 2, "", false, false, true)));
                    this.TagBody = this.TagBody.Replace("[$TAX_DETAILS$]", string.Concat(Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TAX_DETAILS, 2, "", false, false, true)), "%"));
                    this.TagBody = this.TagBody.Replace("[$STORE$]", storeEmail.storeName);
                    this.TagBody = this.TagBody.Replace("[$ORDERNO$]", storeEmail.order_No);
                    this.TagBody = this.TagBody.Replace("[$ORDER_LINK$]", this.orderLink);
                    this.TagBody = this.TagBody.Replace("[$DATE_OF_ORDER$]", this.orderDate);
                    this.TagBody = this.TagBody.Replace("[$REQUIRED_BY$]", this.RequiredBy);
                    this.TagBody = this.TagBody.Replace("[$COMMENT$]", this.Comments);
                    this.TagBody = this.TagBody.Replace("[$TOTAL$]", Convert.ToString(this.comm.Eprint_ReturnFinal_Formated_Amount(this.Company_ID, this.UserID, this.TOTAL, 2, "", false, false, true)));
                    this.TagBody = this.TagBody.Replace("[$PRODUCT_DETAILS$]", stringBuilder.ToString());
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONNAME$]", this.Cart_AdditionalOptionName);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTIONVALUE$]", this.Cart_AdditionalOptionValue);
                    this.TagBody = this.TagBody.Replace("[$CART_ADDITIONALOPTION$]", this.Cart_AdditionalOption);
                    this.TagBody = this.TagBody.Replace("[$ARTWORK_FILE_PATH$]", empty7);
                    this.TagBody = this.TagBody.Replace("[$ConsigneeURL$]", this.Consignee_URL);
                    this.TagBody = this.TagBody.Replace("[$Consignment Note Number$]", this.ConsignmentNote_Number);
                    this.TagBody = this.TagBody.Replace("\r\n", "");
                }
            }
            if (Type.ToLower().Trim() == "b2bcontactregistration")
            {
                StringBuilder stringBuilder1 = new StringBuilder();
                if (empty1.ToLower() == "p")
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login.aspx?id=", this.Account_ID);
                }
                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login.aspx");
                }
                else
                {
                    this.loginLink = string.Concat(this.StoreURL, "/login", ConnectionClass.FileExtension);
                }
                this.loginLink = string.Concat("<a href=", this.loginLink, ">Click here to login</a>");
                this.EmailID = this.EmailID.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.Pwd = this.Pwd.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$STORE$]", storeEmail.StoreNameB2bRegistration);
                this.emailSubject = this.emailSubject.Replace("[$STORE_LINK$]", "*");
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.emailSubject = this.emailSubject.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.emailSubject = this.emailSubject.Replace("[$PERSONAL_DETAILS$]", "*");
                this.emailSubject = this.emailSubject.Replace(", ,", ", ");
                this.TagBody = this.TagBody.Replace("[$STORE$]", storeEmail.StoreNameB2bRegistration);
                this.TagBody = this.TagBody.Replace("[$STORE_LINK$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$CONTACT_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$CONTACT_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$USER_EMAIL$]", this.EmailID);
                this.TagBody = this.TagBody.Replace("[$USER_PASSWORD$]", this.Pwd);
                this.TagBody = this.TagBody.Replace("[$URL$]", this.loginLink);
                this.TagBody = this.TagBody.Replace("[$CONTACT_NAME$]", this.FirstName + " " + this.LastName);
                this.TagBody = this.TagBody.Replace("\r\n", "");
            }
            return this.TagBody;
        }

        public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml)
        {
            string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
            string str1 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
            string str2 = from;
            string empty = string.Empty;
            BaseClass baseClass = new BaseClass();
            if (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() == "1")
            {
                from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
            }
            else if (HttpContext.Current.Session["email"] != null)
            {
                from = HttpContext.Current.Session["email"].ToString();
            }
            if (string.IsNullOrEmpty(from))
            {
                //from = "support@eprintsoftware.com";
                from = "support@hexicomsoftware.com";
            }
            string str3 = string.Concat("<", str2, ">");
            try
            {
                empty = storeEmail.storeName;
            }
            catch
            {
                //empty = "support@eprintsoftware.com";
                empty = "support@hexicomsoftware.com";
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
            sqlCommand.Parameters.AddWithValue("@FromEmail", baseClass.SpecialDecode(from));
            sqlCommand.Parameters.AddWithValue("@ReplyTo", baseClass.SpecialDecode(str3));
            sqlCommand.Parameters.AddWithValue("@ToEmails", baseClass.SpecialDecode(to));
            sqlCommand.Parameters.AddWithValue("@CCEmails", baseClass.SpecialDecode(cc));
            sqlCommand.Parameters.AddWithValue("@BCCEmails", baseClass.SpecialDecode(bcc));
            sqlCommand.Parameters.AddWithValue("@EmailSubject", baseClass.SpecialDecode(subject));
            sqlCommand.Parameters.AddWithValue("@EmailBody", baseClass.SpecialDecode(body));
            sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
            sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
            sqlCommand.Parameters.AddWithValue("@CreatedBY", long.Parse(HttpContext.Current.Session["userID"].ToString()));
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
    }
}