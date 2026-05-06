using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public class FtpSettingsModel
    {
        public string FtpAddress { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public int Port { get; set; }
        public string RootFolder { get; set; }
        public string FileTransferProtocol { get; set; }

    }

    public class FtpPrefixSettingsModel
    {
        public int ID { get; set; }
        public int PrefixSelectedMode { get; set; }
    }

    public class FtpRouteSetting
    {
        public string SectionName { get; set; }
        public string ActionName { get; set; }
        public int StatusValue { get; set; }
        public bool IsSelected { get; set; }
    }
    public partial class ConfirmBeforeOrder : BaseClass, IRequiresSessionState
    {
        //protected HiddenField hid_MultiplePrice;

        //protected System.Web.UI.ScriptManager sm1;

        //protected HiddenField hdnDeptID;

        //protected HtmlGenericControl li_payment;

        //protected HtmlGenericControl wizard;

        //protected Label lblOrderConfoHeader;

        //protected HtmlTableRow tr_OrderConfoHeader;

        //protected Label lblOrderDate;

        //protected Label lbl_OrderDate;

        //protected Label Label7;

        //protected Label lblorderedforname;

        //protected Label lblforattention;

        //protected HtmlGenericControl div_attnfor;

        //protected Label lblOrderTitle;

        //protected HtmlGenericControl div_OrderTitle;

        //protected Label lbl_OrderTitle;

        //protected HtmlGenericControl div_OrderTitle1;

        //protected Label lblemail;

        //protected Label lblorderedforemail;

        //protected Label lblUserRefOrderNo;

        //protected Label lbl_UserRefOrderNo;

        //protected HtmlGenericControl div_OrderNo;

        //protected Label lblPayment;

        //protected Label lbl_Payment;

        //protected HtmlGenericControl div_PaymentType;

        //protected Label Label3;

        //protected Label lblDeliveryDate;

        //protected HtmlGenericControl div_DeliveryRequiredby;

        //protected Label Label1;

        //protected Label lblCostcenter;

        //protected HtmlGenericControl DivCostCenter;

        //protected Label Label2;

        //protected Label lblCouponCode;

        //protected HtmlGenericControl DivCouponCode;

        //protected Label lblname;

        //protected Label lbl_name;

        //protected HtmlGenericControl Div7;

        //protected Label Label9;

        //protected Label lbl_email;

        //protected HtmlGenericControl Div9;

        //protected HtmlGenericControl div_orderedfor;

        //protected Label lbl_BliingAddressID;

        //protected Label lbl_BliingAddress;

        //protected HtmlGenericControl order_billingAddress;

        //protected Label lbl_ShippingAddressID;

        //protected Label lbl_ShippingAddress;

        //protected HtmlGenericControl shipping_billingaddress;

        //protected PlaceHolder plhorder_Header;

        //protected PlaceHolder plhorder;

        //protected Label lbl_subTotal;

        //protected PlaceHolder plhOrdAddOptions;

        //protected HtmlGenericControl divOrdAddOptions;

        //protected Label lbl_tax;

        //protected HtmlGenericControl div3;

        //protected Label lbl_grandTotal;

        //protected HtmlGenericControl div5;

        //protected Label lbl_subTotal_cost;

        //protected PlaceHolder plhOrdAddOptionsPrice;

        //protected Label lbl_TaxValue;

        //protected HtmlGenericControl div1;

        //protected Label lbl_grandTotal_cost;

        //protected HtmlGenericControl div4;

        //protected HtmlGenericControl Order_area;

        //protected CheckBox chk_terms_conditions;

        //protected Label lbl_terms_conditions;

        //protected HtmlGenericControl div_confirmOrder;

        //protected Button Button1;

        //protected Button btn_confirm;

        //protected HtmlGenericControl div_confirm;

        //protected Button Button2;

        //protected Button btn_PaymentInfo;

        //protected Image Image1;

        //protected HtmlGenericControl div_Payment;

        //protected HiddenField hdn_EstimateID;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        private commonclass comm = new commonclass();

        private BaseClass objBc = new BaseClass();

        private storeEmail Objemail = new storeEmail();

        public languageClass objLanguage = new languageClass();

        public bool IsBackOrder;

        public string BCKORDERTYPE = string.Empty;

        public string NEWORDER = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CompanyID;

        public long CartID;

        public long StoreUserID;

        public long OrderID;

        public int ProductID;

        public long ClientID;

        public int UserID;

        public decimal TotalPrice;

        public decimal Tax;

        public decimal OrderShipping;

        public static long AccountID;

        public char KeySeparator;

        private string NewSessionID = string.Empty;

        public string imageName = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string strSitepath = string.Empty;

        public string StyleSheetPath = string.Empty;

        public string eprintDocument = string.Empty;

        public string FileExtension = string.Empty;

        public string Address = string.Empty;

        public string OrderKey = string.Empty;

        public string IsTerms = string.Empty;

        public string DateFormat = string.Empty;

        public string SystemName = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public static string imagePath;

        public bool IsPPW_SystemName;

        public string isLoginInfo = "1";

        private DateTime OrderDate;

        public string PaymentStep = string.Empty;

        public string isPaymentInfo = "1";

        public string strImagepath = BaseClass.imagePath();

        public string ApproverEmail = string.Empty;

        public long DepartmentID;

        public string UserType = string.Empty;

        public int AvailableQuantity;

        private string Prod_Id = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        private string MeasurementValue = string.Empty;

        public string Approval_Type = string.Empty;

        public bool IsCumulative;

        public bool ISCouponCodeEnabled;

        public string CouponCodeDisplay = "display:none;";

        public string isCheckPaymentInfo = string.Empty;

        public string MainProductName = string.Empty;

        public long MainProductId;

        public string deptScreenName = string.Empty;

        public string IsEnableHidePrice = string.Empty;

        public string PDFToURLPath = string.Empty;

        public bool CartJobScreenNameShow;

        public string CartJobScreenName = string.Empty;

        protected Random rGen;

        public string isTwoWayApproval = string.Empty;

        private string ApprovalEmails = string.Empty;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public bool isCheckOrderTitle = true;
        public bool isCheckOrderNumber = true;
        public bool isCheckDeliveryRequiredBy_1 = true;
        public bool isCheckCooments = true;
        public bool ShowCostCenters = true;
        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static ConfirmBeforeOrder()
        {
            ConfirmBeforeOrder.AccountID = (long)0;
            ConfirmBeforeOrder.imagePath = string.Empty;
        }

        public ConfirmBeforeOrder()
        {
        }

        protected void btn_confirm_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            bool flag = OrderBasePage.Fetch_Stock_Mgmt_Exists((long)this.CompanyID);
            if (this.Session["MultipleCartID"] != null)
            {
                DataSet dataSet = OrderBasePage.Select_OrderItems_BeforeOrder(this.StoreUserID, this.Session["MultipleCartID"].ToString());
                DataTable item = dataSet.Tables[0];
                if (item.Rows.Count > 0)
                {
                    foreach (DataRow row in item.Rows)
                    {
                        if (!(row["IsStockItem"].ToString().ToLower() == "true") || !(row["MainBackOrder"].ToString().ToLower() == "true") || !(row["AvailableQuantity"].ToString() != "") && row["AvailableQuantity"] == null || !(row["Quantity"].ToString() != "") && row["Quantity"] == null || !(row["IsBackOrder"].ToString() == "1") || !(row["AvailableQuantity"].ToString() != ""))
                        {
                            continue;
                        }
                        if (row["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            if (Convert.ToInt32(row["AvailableQuantity"].ToString()) >= Convert.ToInt32(row["Quantity"].ToString()) || !flag)
                            {
                                continue;
                            }
                            this.IsBackOrder = true;
                            ConfirmBeforeOrder confirmBeforeOrder = this;
                            confirmBeforeOrder.Prod_Id = string.Concat(confirmBeforeOrder.Prod_Id, row["ProductID"].ToString(), "$");
                        }
                        else
                        {
                            DataTable dataTable = OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(row["ProductID"]), Convert.ToInt16(row["Quantity"]), true);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (Convert.ToInt32(dataRow["AvailableQuantity"].ToString()) >= Convert.ToInt32(row["Quantity"].ToString()) || !flag)
                                {
                                    continue;
                                }
                                this.IsBackOrder = true;
                                ConfirmBeforeOrder confirmBeforeOrder1 = this;
                                confirmBeforeOrder1.Prod_Id = string.Concat(confirmBeforeOrder1.Prod_Id, row["ProductID"].ToString(), "$");
                            }
                        }
                    }
                }
            }
            bool deptIsApprovalNotRequired = false;
            if (this.hdnDeptID.Value.Trim() != "")
            {
                deptIsApprovalNotRequired = OrderBasePage.Get_Dept_IsApprovalNotRequired(Convert.ToInt64(this.hdnDeptID.Value));
            }
            this.Session["DeptNotReqApproval"] = deptIsApprovalNotRequired;
            DataSet adminBackORDSelectIsActiveType = OrderBasePage.EmailToAdminBackORD_SelectIsActiveType((long)this.CompanyID);
            DataTable item1 = adminBackORDSelectIsActiveType.Tables[0];
            if (item1.Rows.Count > 0 && flag)
            {
                foreach (DataRow row1 in item1.Rows)
                {
                    this.BCKORDERTYPE = row1["IsActive"].ToString();
                }
            }
            DataSet adminSelectIsActiveType = OrderBasePage.EmailToAdmin_SelectIsActiveType((long)this.CompanyID);
            DataTable dataTable1 = adminSelectIsActiveType.Tables[0];
            if (dataTable1.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    this.NEWORDER = dataRow1["IsActive"].ToString();
                }
            }
            string str = string.Empty;
            DataTable dataTable2 = new DataTable();
            if (this.Session["InsertOrder"] != null)
            {
                dataTable2 = (DataTable)this.Session["InsertOrder"];
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                    str = dataTable2.Rows[0]["DesignatedApproverEmail"].ToString();
                }
            }
            string lower = string.Empty;
            if (this.Session["CatgoryNotReqApproval"] != null)
            {
                lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
            }
            if (this.Session["ApprovalSystem"] == null)
            {
                this.OrderPayment(true);
            }
            else
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.OrderPayment(true);
                    return;
                }
                string str1 = base.Return_ApprovalSystem_Settings("approvaltype");
                string str2 = base.Return_ApprovalSystem_Settings("approvalreqfororder");
                string str3 = base.Return_ApprovalSystem_Settings("newordersapprove");
                decimal num = Convert.ToDecimal(this.lbl_subTotal_cost.Text.Trim());
                decimal num1 = Convert.ToDecimal(this.lbl_TaxValue.Text.Trim());
                decimal num2 = num + num1;
                if (str1.ToLower() == "s")
                {
                    if (!(str2 != "") || !(str2 != "0"))
                    {
                        this.ApproverEmail = this.Session["EmailID"].ToString();
                        this.OrderPayment(false);
                        return;
                    }
                    if (num2 <= Convert.ToInt64(str2))
                    {
                        this.OrderPayment(true);
                        return;
                    }
                    this.ApproverEmail = this.Session["EmailID"].ToString();
                    this.OrderPayment(false);
                    return;
                }
                if (deptIsApprovalNotRequired)
                {
                    this.OrderPayment(true);
                    return;
                }
                if (lower != "false")
                {
                    this.OrderPayment(true);
                    return;
                }
                if (str3.ToString().Trim().ToLower() != "true")
                {
                    this.OrderPayment(true);
                    return;
                }
                if (str1 == "u")
                {
                    if (!(str2 != "") || !(str2 != "0"))
                    {
                        this.ApproverEmail = str;
                        this.OrderPayment(false);
                        return;
                    }
                    if (num2 <= Convert.ToInt64(str2))
                    {
                        this.OrderPayment(true);
                        return;
                    }
                    this.ApproverEmail = str;
                    this.OrderPayment(false);
                    return;
                }
                if (str1 != "u")
                {
                    if (this.UserType != "u")
                    {
                        if (this.UserType != "d")
                        {
                            this.OrderPayment(true);
                            return;
                        }
                        if (str1 != "da")
                        {
                            if (str1 != "a")
                            {
                                this.OrderPayment(true);
                                return;
                            }
                            string empty1 = string.Empty;
                            string empty2 = string.Empty;
                            DataSet dataSet1 = new DataSet();
                            dataSet1 = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                            DataTable item2 = new DataTable();
                            item2 = dataSet1.Tables[0];
                            foreach (DataRow row2 in item2.Rows)
                            {
                                empty1 = row2["email"].ToString();
                                string.Concat(row2["contactID"].ToString(), "~", row2["email"].ToString());
                            }
                            if (!(str2 != "") || !(str2 != "0"))
                            {
                                this.ApproverEmail = empty1;
                                this.OrderPayment(false);
                                return;
                            }
                            if (num2 <= Convert.ToInt64(str2))
                            {
                                this.OrderPayment(true);
                                return;
                            }
                            this.ApproverEmail = empty1;
                            this.OrderPayment(false);
                            return;
                        }
                        if (base.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                        {
                            this.OrderPayment(true);
                            return;
                        }
                        string empty3 = string.Empty;
                        string empty4 = string.Empty;
                        DataSet dataSet2 = new DataSet();
                        dataSet2 = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                        DataTable dataTable3 = new DataTable();
                        dataTable3 = dataSet2.Tables[0];
                        foreach (DataRow dataRow2 in dataTable3.Rows)
                        {
                            empty3 = dataRow2["email"].ToString();
                            string.Concat(dataRow2["contactID"].ToString(), "~", dataRow2["email"].ToString());
                        }
                        if (!(str2 != "") || !(str2 != "0"))
                        {
                            this.ApproverEmail = empty3;
                            changeApprerEmail();
                            this.OrderPayment(false);
                            return;
                        }
                        if (num2 <= Convert.ToInt64(str2))
                        {
                            this.OrderPayment(true);
                            return;
                        }
                        this.ApproverEmail = empty3;
                        changeApprerEmail();
                        this.OrderPayment(false);
                        return;
                    }
                    foreach (DataRow row3 in LoginBasePage.Select_DeptDetail_For_StoreUser(ConfirmBeforeOrder.AccountID, this.StoreUserID).Rows)
                    {
                        this.DepartmentID = Convert.ToInt64(row3["DeptID"].ToString());
                    }
                    string str4 = string.Empty;
                    string empty5 = string.Empty;
                    DataSet dataSet3 = new DataSet();
                    dataSet3 = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                    DataTable item3 = new DataTable();
                    item3 = dataSet3.Tables[0];
                    DataTable dataTable4 = new DataTable();
                    dataTable4 = dataSet3.Tables[1];
                    if (str1 == "a")
                    {
                        foreach (DataRow dataRow3 in item3.Rows)
                        {
                            str4 = dataRow3["email"].ToString();
                            empty5 = string.Concat(dataRow3["contactID"].ToString(), "~", dataRow3["email"].ToString());
                        }
                        if (!(str2 != "") || !(str2 != "0"))
                        {
                            this.ApproverEmail = str4;
                            changeApprerEmail();
                            this.OrderPayment(false);
                            return;
                        }
                        if (num2 <= Convert.ToInt64(str2))
                        {
                            this.OrderPayment(true);
                            return;
                        }
                        this.ApproverEmail = str4;
                        changeApprerEmail();
                        this.OrderPayment(false);
                        return;
                    }
                    if (str1 != "da")
                    {
                        this.OrderPayment(true);
                        return;
                    }
                    foreach (DataRow row4 in item3.Rows)
                    {
                        if (!(row4["email"].ToString() != "") || row4["email"].ToString() == null)
                        {
                            continue;
                        }
                        str4 = string.Concat(row4["email"].ToString(), ",");
                        empty5 = string.Concat(row4["contactID"].ToString(), "~", row4["email"].ToString(), ",");
                    }
                    foreach (DataRow dataRow4 in dataTable4.Rows)
                    {
                        str4 = string.Concat(str4, dataRow4["email"].ToString(), ",");
                        string[] strArrays = new string[] { empty5, dataRow4["contactID"].ToString(), "~", dataRow4["email"].ToString(), "," };
                        empty5 = string.Concat(strArrays);
                    }
                    if (!(str2 != "") || !(str2 != "0"))
                    {
                        this.ApproverEmail = str4;
                        changeApprerEmail();
                        this.OrderPayment(false);
                        return;
                    }
                    if (num2 <= Convert.ToInt64(str2))
                    {
                        this.OrderPayment(true);
                        return;
                    }
                    this.ApproverEmail = str4;
                    changeApprerEmail();
                    this.OrderPayment(false);
                    return;
                }
            }
        }

        protected void btn_PaymentInfo_OnClick(object sender, EventArgs e)
        {
            this.Session["PaymentInfo"] = "0";
            HttpResponse response = base.Response;
            string[] strArrays = new string[] { this.strSitepath, "payment_information.aspx?Tp=", this.lbl_subTotal_cost.Text.Trim(), "&Tx=", this.lbl_TaxValue.Text.Trim() };
            response.Redirect(string.Concat(strArrays));
        }

        public string GenPassWithCap(int i)
        {
            this.rGen = new Random();
            int num = 0;
            string str = "";
            for (int i1 = 0; i1 <= i; i1++)
            {
                num = this.rGen.Next(0, 60);
                str = string.Concat(str, this.strCharacters[num]);
            }
            return str;
        }

        private void Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType, string RequiredDate, string Comments, string OrderTitle, string OrderNo, string strMultipleCartID, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long DeptID, string orderbehalftype, long OrderForUserID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (ClientID == (long)0)
            {
                DataTable dataTable = LoginBasePage.StoreUser_select_by_Conditions(OrderForUserID, orderbehalftype, DeptID);
                if (dataTable.Rows.Count > 0)
                {
                    ClientID = Convert.ToInt64(dataTable.Rows[0]["ClientID"].ToString());
                }
            }
            this.TotalPrice = new decimal(0);
            this.Tax = new decimal(0);
            this.OrderShipping = new decimal(0);
            foreach (DataRow row in CartBasePage.Select_MultipleCartItems(CookieID, "", StoreUserID, strMultipleCartID).Rows)
            {
                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                this.Tax = this.Tax + Convert.ToDecimal(row["CartTax"]);
                this.OrderShipping = this.OrderShipping + Convert.ToDecimal(row["CartShipping"]);
            }
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.OrderDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            string str1 = this.comm.date_Check_new(this.DateFormat, this.objBc.ReplaceSingleQuote(RequiredDate.ToString()));

            long num = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, ConfirmBeforeOrder.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(str1), Comments, this.OrderKey, OrderTitle, OrderNo, this.ApproverEmail, OrderForUserID, DeptID, CostCentreID, StoreUserID, orderbehalftype, IsApproved, "", "", (long)0, this.isTwoWayApproval, "0", "0", this.ApprovalEmails);
            this.OrderID = num;
            this.hdn_EstimateID.Value = this.OrderID.ToString();
            DataTable dataTable1 = CartBasePage.Select_MultipleCartItems(CookieID, "", StoreUserID, strMultipleCartID);
            int index = 0;
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                bool flag = false;
                if (!string.IsNullOrEmpty(this.Prod_Id))
                {
                    string[] strArrays = this.Prod_Id.Split(new char[] { '$' });
                    int num1 = 0;
                    while (num1 < (int)strArrays.Length)
                    {
                        if (strArrays[num1].ToString() != dataRow["ProductID"].ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                bool isApproved = IsApproved;
                if (!IsApproved && this.Approval_Type.ToLower() == "s" && this.Session["SelfApproval_ItemID"] != null && this.Session["SelfApproval_ItemID"].ToString().Trim() != "")
                {
                    string[] strArrays1 = this.Session["SelfApproval_ItemID"].ToString().Split(new char[] { ',' });
                    int num2 = 0;
                    while (num2 < (int)strArrays1.Length - 1)
                    {
                        if (strArrays1[num2].ToString() != dataRow["CartItemID"].ToString())
                        {
                            num2++;
                        }
                        else
                        {
                            isApproved = true;
                            break;
                        }
                    }
                }
                // category not require approval               
                if (Convert.ToBoolean(dataRow["IsApprovalNotRequired"]))
                {
                    isApproved = true;
                }

                OrderBasePage.Insert_OrderItemDetails_MIS(Convert.ToInt64(dataRow["CartItemID"].ToString()), flag, num, (long)this.CompanyID, isApproved, StoreUserID, this.ApproverEmail, ClientID, dataTable1.Rows.Count);
                object[] secureDocPath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString() };
                empty = string.Concat(secureDocPath);
                if (dataRow["PrintReadyFile"].ToString() != "")
                {
                    object[] objArray = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(objArray)))
                    {
                        object[] secureDocPath1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(secureDocPath1));
                    }
                    if (File.Exists(empty))
                    {
                        object[] objArray1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        string str2 = string.Concat(objArray1);
                        if (!Directory.Exists(str2))
                        {
                            Directory.CreateDirectory(str2);
                        }
                        File.Copy(empty, string.Concat(str2, dataRow["PrintReadyFile"].ToString()), true);
                    }

                }
                if (commonclass.CheckFTPEnable())
                {
                    string filePath = string.Empty;
                    DataTable dt = OrderBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, (long)Convert.ToInt32(this.OrderID));
                    DataTable dataTable6 = commonclass.Get_ProductFileByType(Convert.ToInt64(dataRow["ProductID"].ToString()), this.CompanyID);
                    if (!string.IsNullOrEmpty(dataTable6.Rows[0]["PrintReadyFile"].ToString()))
                    {
                        if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                        {
                            DataTable _attachment = commonclass.GetAttachmentByEstimateItemID(Convert.ToInt64(dt.Rows[index]["EstimateItemID"].ToString()));
                            object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                            //string EditableTemplatePath = string.Empty;
                            //DataTable _item = EprintConfigurationManager.GetAppSettings();
                            //foreach (DataRow dr in _item.Rows)
                            //{
                            //    EditableTemplatePath = dr["EditableTemplatePath"].ToString();
                            //}
                            //object[] editableTemplatePath = new object[] { EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                            filePath = string.Concat(secureDocEditablePath);
                        }
                        else
                        {
                            string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                            filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                        }
                        commonclass.UploadPrintReadyFileToSftp(this.CompanyID, dataRow["ProductID"].ToString(), filePath, "OrderCreation", "OnlineOrder", Convert.ToInt64(dt.Rows[index]["EstimateItemID"].ToString()));
                    }
                   
                }

                index++;
                if (dataRow["ReportFileName"] == null && !(dataRow["ReportFileName"].ToString() != ""))
                {
                    continue;
                }
                object[] secureDocPath2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["ReportFileName"].ToString() };
                str = string.Concat(secureDocPath2);
                object[] objArray2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                if (!Directory.Exists(string.Concat(objArray2)))
                {
                    object[] secureDocPath3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    Directory.CreateDirectory(string.Concat(secureDocPath3));
                }
                if (!File.Exists(str))
                {
                    continue;
                }
                object[] objArray3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                string str3 = string.Concat(objArray3);
                if (!Directory.Exists(str3))
                {
                    Directory.CreateDirectory(str3);
                }
                File.Copy(str, string.Concat(str3, dataRow["ReportFileName"].ToString()), true);
            }
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num, (long)this.CompanyID, StoreUserID, (long)dataTable1.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num);

            //this.MoveEditableImageFilesToAttachmentsFolder();
        }

        private void MoveEditableImageFilesToAttachmentsFolder()
        {
            try
            {
                string imagePathFromFrontEnd = EprintConfigurationManager.AppSettings["PDFFrom"].ToString();
                string editableProductImagesPathSource = string.Concat(imagePathFromFrontEnd, this.CompanyID, "\\", "Images");
                string attachmentsPathDestination = string.Concat(EprintConfigurationManager.AppSettings["SecureDocPath"],
                    ConnectionClass.ServerName, "\\", this.CompanyID, "\\", "attachments");

                CopyFilesIfNotExists(editableProductImagesPathSource, attachmentsPathDestination);
            }
            catch (Exception)
            {
            }
        }
        private static void CopyFilesIfNotExists(string sourceFolder, string destinationFolder)
        {
            //if (!Directory.Exists(destinationFolder))
            //{
            //    Directory.CreateDirectory(destinationFolder);
            //}

            string[] sourceFiles = Directory.GetFiles(sourceFolder);

            foreach (var filePath in sourceFiles)
            {
                string fileName = Path.GetFileName(filePath);
                string destFilePath = Path.Combine(destinationFolder, fileName);
                try
                {
                    // ePrint.Webstore.ePrintUtilities.Utilities.WriteLog("File Name : " + Convert.ToString(fileName));

                    if (!File.Exists(destFilePath))
                    {
                        //ePrint.Webstore.ePrintUtilities.Utilities.WriteLog("Moving file as it does not exist : " + Convert.ToString(fileName));
                        File.Copy(filePath, destFilePath);
                    }
                    else
                    {
                        //ePrint.Webstore.ePrintUtilities.Utilities.WriteLog("file exist already: " + Convert.ToString(fileName));
                        continue;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void OrderPayment(bool IsApproved)
        {
            char[] chrArray;
            string[] strArrays;
            int i;
            string[] str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            if (this.Session["MultipleCartID"] != null)
            {
                empty = this.Session["MultipleCartID"].ToString();
            }
            bool deptIsApprovalNotRequired = OrderBasePage.Get_Dept_IsApprovalNotRequired(Convert.ToInt64(this.hdnDeptID.Value));
            string lower = string.Empty;
            if (this.Session["CatgoryNotReqApproval"] != null)
            {
                lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
            }
            if (this.Session["InsertOrder"] != null)
            {
                DataTable item = (DataTable)this.Session["InsertOrder"];
                if (item != null)
                {
                    foreach (DataRow row in item.Rows)
                    {
                        empty1 = row["DesignatedApproverEmail"].ToString();
                        if (row["PaymentType"].ToString() == "PayPal")
                        {
                            if (row["PaymentType"].ToString() != "PayPal")
                            {
                                continue;
                            }
                            this.Session["BillingAddress"] = row["InvoiceAddressID"].ToString();
                            this.Session["ShippingAddress"] = row["DeliveryAddressID"].ToString();
                            this.Session["RequiredDate"] = row["RequiredBy"].ToString();
                            this.Session["Comments"] = row["Comments"].ToString();
                            this.Session["OrderTitle"] = row["OrderTitle"].ToString();
                            this.Session["UserRefOrderNo"] = row["OrderNumber"].ToString();
                            this.Session["PP_CostCentreID"] = row["CostCentreID"].ToString();
                            this.Session["PP_DeptID"] = row["DeptID"].ToString();
                            this.Session["PP_orderbehalftype"] = row["orderbehalftype"].ToString();
                            this.Session["PP_OrderForUserID"] = row["OrderForUserID"].ToString();
                            this.Session["PP_IsApproved"] = IsApproved;
                            this.Session["PP_ApproverEmail"] = this.ApproverEmail;
                            if (!ConnectionClass.IsAdvancePayPal)
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "checkout_paypal.aspx"));
                            }
                            else
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "advanced_paypalapi.aspx"));
                            }
                        }
                        else
                        {
                            if (!(row["OrderID"].ToString() == "") && !(row["OrderID"].ToString() == "0"))
                            {
                                continue;
                            }
                            this.Insert_Order(row["SessionKey"].ToString(), Convert.ToInt64(row["StoreUserID"]), Convert.ToInt64(row["InvoiceAddressID"]), Convert.ToInt64(row["DeliveryAddressID"]), Convert.ToInt64(row["ClientID"]), row["IsOrdered"].ToString(), row["PaymentType"].ToString(), row["RequiredBy"].ToString(), row["Comments"].ToString(), row["OrderTitle"].ToString(), row["OrderNumber"].ToString(), empty, (long)0, (long)0, IsApproved, Convert.ToInt64(row["CostCentreID"]), Convert.ToInt64(row["DeptID"]), row["orderbehalftype"].ToString(), Convert.ToInt64(row["OrderForUserID"]));
                            DataTable dataTable = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_EstimateID.Value), this.StoreUserID);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                this.OrderKey = dataRow["OrderKey"].ToString();
                                long num = Convert.ToInt64(dataRow["ProductID"]);
                                int num1 = Convert.ToInt32(dataRow["Quantity"]);
                                decimal num2 = Convert.ToDecimal(dataRow["UnitPrice"]);
                                long num3 = Convert.ToInt64(dataRow["EstimateItemID"]);
                                long num4 = Convert.ToInt64(dataRow["OrderItemID"]);
                                bool flag = Convert.ToBoolean(dataRow["IsStockReplenish"]);
                                BaseClass baseClass = new BaseClass();
                                baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                string str1 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                                string str2 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && baseClass.Return_ApprovalSystem_Settings("approvaltype").ToLower() == "s")
                                {
                                    IsApproved = Convert.ToBoolean(dataRow["ApproveStatus"]);
                                }
                                if (flag.ToString().ToLower() == "true")
                                {
                                    continue;
                                }
                                foreach (DataRow row1 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    if (row1["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str1, "self", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                    }
                                    else if (row1["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass.StockAllocation_Others((long)this.CompanyID, num, num1, str1, Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                    }
                                    else if (row1["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row1["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow dataRow1 in OrderBasePage.OtherMultipleProductDetails_Select(num, num1, true).Rows)
                                        {
                                            baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow1["KitItemID"].ToString()), num, num1, str1, "multiple", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                        }
                                    }
                                    else
                                    {
                                        baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str1, "additional option", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID, Convert.ToInt64(this.hdn_EstimateID.Value), num4);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.Session["Insert_CreditCardDetails"] != null)
            {
                DataTable item1 = (DataTable)this.Session["Insert_CreditCardDetails"];
                if (item1 != null)
                {
                    foreach (DataRow row2 in item1.Rows)
                    {
                        OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_EstimateID.Value), row2["HolderName"].ToString(), "", Convert.ToInt64(row2["CardNumber"]), row2["CardType"].ToString(), row2["Verification"].ToString(), Convert.ToInt32(row2["Month"]), Convert.ToInt32(row2["Year"]));
                        ConfirmBeforeOrder.AccountID = (long)Convert.ToInt32(row2["AccountID"]);
                    }
                }
            }
            this.OrderID = Convert.ToInt64(this.hdn_EstimateID.Value);
            string str3 = base.Return_ApprovalSystem_Settings("approvaltype");
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                    }
                }
                else
                {
                    string str4 = base.Return_ApprovalSystem_Settings("approvalreqfororder");
                    string str5 = this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                    decimal num5 = Convert.ToDecimal(this.lbl_subTotal_cost.Text.Trim());
                    decimal num6 = Convert.ToDecimal(this.lbl_TaxValue.Text.Trim());
                    decimal num7 = num5 + num6;
                    if (str3.ToLower() == "s")
                    {
                        if (!(str4 != "") || !(str4 != "0"))
                        {
                            if (this.IsBackOrder)
                            {
                                if (this.BCKORDERTYPE.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                }
                            }
                            else if (this.NEWORDER.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                            }
                            if (IsApproved.ToString().Trim().ToLower() != "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str3);
                            }
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        }
                        else if (num7 <= Convert.ToInt64(str4))
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                            if (this.IsBackOrder)
                            {
                                if (this.BCKORDERTYPE.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                }
                            }
                            else if (this.NEWORDER.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                            }
                        }
                        else
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str3);
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        }
                    }
                    else if (deptIsApprovalNotRequired)
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                        }
                    }
                    else if (lower != "false")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                        }
                    }
                    else if (str3 != "u")
                    {
                        if (str3 != "u")
                        {
                            if (this.UserType == "u")
                            {
                                foreach (DataRow dataRow2 in LoginBasePage.Select_DeptDetail_For_StoreUser(ConfirmBeforeOrder.AccountID, this.StoreUserID).Rows)
                                {
                                    this.DepartmentID = Convert.ToInt64(dataRow2["DeptID"].ToString());
                                }
                                string empty2 = string.Empty;
                                string empty3 = string.Empty;
                                DataSet dataSet = new DataSet();
                                dataSet = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                                DataTable dataTable1 = new DataTable();
                                dataTable1 = dataSet.Tables[0];
                                DataTable dataTable2 = new DataTable();
                                dataTable2 = dataSet.Tables[1];
                                if (str3 == "a")
                                {
                                    foreach (DataRow row3 in dataTable1.Rows)
                                    {
                                        empty2 = row3["email"].ToString();
                                        empty3 = string.Concat(row3["contactID"].ToString(), "~", row3["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty3.Split(chrArray);


                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str6 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays1 = str6.Split(chrArray);
                                        if (strArrays1[0].ToString() != "" && strArrays1[0].ToString() != null)
                                        {
                                            if (str5.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else if (!(str4 != "") || !(str4 != "0"))
                                            {
                                                if (this.IsBackOrder)
                                                {
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str3);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            }
                                            else if (num7 <= Convert.ToInt64(str4))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str3);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            }
                                        }
                                    }
                                }
                                else if (str3 != "da")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                    }
                                }
                                else
                                {
                                    foreach (DataRow dataRow3 in dataTable1.Rows)
                                    {
                                        if (!(dataRow3["email"].ToString() != "") || dataRow3["email"].ToString() == null)
                                        {
                                            continue;
                                        }
                                        empty2 = string.Concat(dataRow3["email"].ToString(), ",");
                                        empty3 = string.Concat(dataRow3["contactID"].ToString(), "~", dataRow3["email"].ToString(), ",");
                                    }
                                    foreach (DataRow row4 in dataTable2.Rows)
                                    {
                                        empty2 = string.Concat(empty2, row4["email"].ToString(), ",");
                                        str = new string[] { empty3, row4["contactID"].ToString(), "~", row4["email"].ToString(), "," };
                                        empty3 = string.Concat(str);
                                    }
                                    chrArray = new char[] { ',' };
                                    string[] strArrays2 = empty3.Split(chrArray);
                                    int num8 = 0;
                                    strArrays = strArrays2;

                                    int j = 0;
                                    if (this.isTwoWayApproval == "1" && strArrays.Length > 2)
                                    {
                                        j = 1;
                                    }
                                    else
                                    {
                                        j = 0;
                                    }

                                    for (i = j; i < (int)strArrays.Length; i++)
                                    {
                                        string str7 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays3 = str7.Split(chrArray);
                                        if (strArrays3[0].ToString() != "" && strArrays3[0].ToString() != null)
                                        {
                                            if (str5.ToString().Trim().ToLower() != "true")
                                            {
                                                if (num8 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                    if (this.IsBackOrder)
                                                    {
                                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                        }
                                                    }
                                                    else if (this.NEWORDER.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                            }
                                            else if (!(str4 != "") || !(str4 != "0"))
                                            {
                                                if (this.IsBackOrder && num8 == 0 && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str3);
                                                if (num8 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                }
                                            }
                                            else if (num7 > Convert.ToInt64(str4))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str3);
                                                if (num8 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                }
                                            }
                                            else if (num8 == 0)
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                        }
                                        num8++;
                                    }
                                }
                            }
                            else if (this.UserType != "d")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                }
                            }
                            else if (str3 == "da")
                            {
                                if (base.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                    }
                                }
                                else
                                {
                                    string empty4 = string.Empty;
                                    string empty5 = string.Empty;
                                    DataSet dataSet1 = new DataSet();
                                    dataSet1 = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                                    DataTable item2 = new DataTable();
                                    item2 = dataSet1.Tables[0];
                                    foreach (DataRow dataRow4 in item2.Rows)
                                    {
                                        dataRow4["email"].ToString();
                                        empty5 = string.Concat(dataRow4["contactID"].ToString(), "~", dataRow4["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty5.Split(chrArray);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str8 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays4 = str8.Split(chrArray);
                                        if (strArrays4[0].ToString() != "" && strArrays4[0].ToString() != null)
                                        {
                                            if (str5.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else if (!(str4 != "") || !(str4 != "0"))
                                            {
                                                if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str3);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            }
                                            else if (num7 <= Convert.ToInt64(str4))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str3);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (str3 != "a")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                }
                            }
                            else
                            {
                                string empty6 = string.Empty;
                                string empty7 = string.Empty;
                                DataSet dataSet2 = new DataSet();
                                dataSet2 = LoginBasePage.ApproversEmail_Select(ConfirmBeforeOrder.AccountID, this.DepartmentID);
                                DataTable dataTable3 = new DataTable();
                                dataTable3 = dataSet2.Tables[0];
                                foreach (DataRow row5 in dataTable3.Rows)
                                {
                                    row5["email"].ToString();
                                    empty7 = string.Concat(row5["contactID"].ToString(), "~", row5["email"].ToString());
                                }
                                chrArray = new char[] { ',' };
                                strArrays = empty7.Split(chrArray);
                                for (i = 0; i < (int)strArrays.Length; i++)
                                {
                                    string str9 = strArrays[i];
                                    chrArray = new char[] { '~' };
                                    string[] strArrays5 = str9.Split(chrArray);
                                    if (strArrays5[0].ToString() != "" && strArrays5[0].ToString() != null)
                                    {
                                        if (str5.ToString().Trim().ToLower() != "true")
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                            }
                                        }
                                        else if (!(str4 != "") || !(str4 != "0"))
                                        {
                                            if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                            }
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str3);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                        }
                                        else if (num7 <= Convert.ToInt64(str4))
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                                            }
                                        }
                                        else
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str3);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (str5.ToString().Trim().ToLower() != "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                        }
                    }
                    else if (!(str4 != "") || !(str4 != "0"))
                    {
                        if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                        }
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", (long)0, empty1, str3);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                    }
                    else if (num7 <= Convert.ToInt64(str4))
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Back Order", "Admin", (long)0, "no approval", str3);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New Order", "Admin", (long)0, "no approval", str3);
                        }
                    }
                    else
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", (long)0, empty1, str3);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "Thank you for your order", "Customer", (long)0, "", str3);
                    }
                }
            }
            var storeCredit = Convert.ToDouble(Session["StoreCredit"]);
            if (storeCredit > 0)
            {
                CartBasePage.Update_StoreCredit(StoreUserID, storeCredit);

            }
            Session["StoreCredit"] = null;
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            this.Session["BillingAddress"] = null;
            this.Session["ShippingAddress"] = null;
            this.Session["RequiredDate"] = null;
            this.Session["Comments"] = null;
            this.Session["OrderTitle"] = null;
            this.Session["UserRefOrderNo"] = null;
            this.Session["PP_CostCentreID"] = null;
            this.Session["PP_DeptID"] = "";
            this.Session["PP_orderbehalftype"] = null;
            this.Session["PP_OrderForUserID"] = null;
            this.Session["PP_IsApproved"] = null;
            this.Session["PP_ApproverEmail"] = null;
            this.Session["CatgoryNotReqApproval"] = null;
            this.Session["DeptNotReqApproval"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            str = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(str));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            char[] keySeparator;
            string[] languageConversion;
            object[] accountID;
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            this.wizard.Attributes.Add("style", "width: 100%; padding-left: 8px; visibility: visible;");
            ((System.Web.UI.WebControls.Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "checkout.aspx'></a> ", this.objLanguage.GetLanguageConversion("Checkout"));
            string str = "style='display:block;'";
            string str1 = "style='display:block;'";
            this.deptScreenName = base.Return_ApprovalRegistration_Settings("deptscreenname");
            this.btn_confirm.Text = this.objLanguage.GetLanguageConversion("Confirm_Order");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Back");
            this.Button2.Text = this.objLanguage.GetLanguageConversion("Back");
            this.btn_PaymentInfo.Text = this.objLanguage.GetLanguageConversion("Continue");
            if (this.Session["PaymentStep"] != null && (this.Session["PaymentStep"].ToString() != null || this.Session["PaymentStep"].ToString() != ""))
            {
                this.PaymentStep = this.Session["PaymentStep"].ToString();
            }
            if (this.Session["ConfirmBeforeOrdernew"] == null || this.Session["ConfirmBeforeOrdernew"].ToString() == "")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "CheckOut.aspx"));
            }
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                this.Approval_Type = base.Return_ApprovalSystem_Settings("approvaltype");
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:FourthStep();", true);
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                ConfirmBeforeOrder.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            DataTable dataDelivery = CartBasePage.Check_Delivery_Cart();
            if (dataDelivery.Rows.Count > 0)
            {
                foreach (DataRow row in dataDelivery.Rows)
                {
                    if (Convert.ToBoolean(row["IsDeliveryCost"]))
                    {
                        this.Session["MultipleCartID"] = string.Concat(this.Session["MultipleCartID"].ToString(), ',', row["CartItemID"].ToString());
                    }
                }
            }
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select(ConfirmBeforeOrder.AccountID, (long)this.CompanyID);
            if (dataTable.Rows.Count <= 0)
            {
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();
                }
            }
            base.Title = commonclass.pageTitle("Order details", Convert.ToInt32(this.CompanyID), Convert.ToInt32(ConfirmBeforeOrder.AccountID));
            if (EprintConfigurationManager.AppSettings["imagePath"] != null)
            {
                ConfirmBeforeOrder.imagePath = EprintConfigurationManager.AppSettings["imagePath"].ToString();
            }
            if (EprintConfigurationManager.AppSettings["productImagePath"] != null)
            {
                this.productImagePath = EprintConfigurationManager.AppSettings["productImagePath"];
            }
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }
            if (EprintConfigurationManager.AppSettings["StyleSheetPath"] != null)
            {
                this.StyleSheetPath = EprintConfigurationManager.AppSettings["StyleSheetPath"];
            }
            if (EprintConfigurationManager.AppSettings["eprintDocument"] != null)
            {
                this.eprintDocument = EprintConfigurationManager.AppSettings["eprintDocument"];
            }
            if (this.Session["StoreUserID"] == null)
            {
                this.Session["fromEmail"] = base.Request.Url.ToString();
                base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
            }
            else
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (EprintConfigurationManager.AppSettings["FileExtension"] != null)
            {
                this.FileExtension = EprintConfigurationManager.AppSettings["FileExtension"].ToString();
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.SystemName != null)
            {
                this.SystemName = ConnectionClass.SystemName.ToLower().Trim();
            }
            if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            if (this.comm.GetDisplayValue("isCheckLoginRegister", ConfirmBeforeOrder.AccountID) == "false")
            {
                this.isLoginInfo = "0";
            }
            string displayValue = this.comm.GetDisplayValue("OrderTitleText", ConfirmBeforeOrder.AccountID);
            this.lblOrderTitle.Text = displayValue;
            string costCenterText = this.comm.GetDisplayValue("CostCentreText", ConfirmBeforeOrder.AccountID);
            this.Label1.Text = costCenterText;
            string displayValue1 = this.comm.GetDisplayValue("OrderNumberText", ConfirmBeforeOrder.AccountID);
            this.lblUserRefOrderNo.Text = displayValue1;
            string displayValue2 = this.comm.GetDisplayValue("DeliveryRequiredByText", ConfirmBeforeOrder.AccountID);
            this.Label3.Text = displayValue2;
            if (this.comm.GetDisplayValue("isCBOOrderNumber", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_OrderNo.Style.Add("display", "none");
            }
            else if (this.comm.GetDisplayValue("isCheckOrderNumber", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_OrderNo.Style.Add("display", "none");
            }
            else
            {
                this.div_OrderNo.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCBOOrderTitle", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_OrderTitle.Style.Add("display", "none");
                this.div_OrderTitle1.Style.Add("display", "none");
            }
            else if (this.comm.GetDisplayValue("isCheckOrderTitle", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_OrderTitle.Style.Add("display", "none");
                this.div_OrderTitle1.Style.Add("display", "none");
            }
            else
            {
                this.div_OrderTitle.Style.Add("display", "block");
                this.div_OrderTitle1.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_DeliveryRequiredby.Style.Add("display", "none");
            }
            else
            {
                this.div_DeliveryRequiredby.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCBOPaymentType", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.div_PaymentType.Style.Add("display", "none");
            }
            else
            {
                this.div_PaymentType.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckInvoiceInfo", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.order_billingAddress.Style.Add("display", "none");
            }
            else
            {
                this.order_billingAddress.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryInfo", ConfirmBeforeOrder.AccountID) != "true")
            {
                this.shipping_billingaddress.Style.Add("display", "none");
            }
            else
            {
                this.shipping_billingaddress.Style.Add("display", "block");
            }
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (this.comm.GetDisplayValue("isCBOUnitPrice", ConfirmBeforeOrder.AccountID) == "false")
            {
                str = "style='display:none;'";
            }
            if (this.comm.GetDisplayValue("isCBOTotal", ConfirmBeforeOrder.AccountID) == "false")
            {
                str1 = "style='display:none;'";
            }
            if (this.comm.GetDisplayValue("isCBOSubtotal", ConfirmBeforeOrder.AccountID) == "false")
            {
                this.lbl_subTotal.Style.Add("display", "none");
                this.lbl_subTotal_cost.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCBOTotalTax", ConfirmBeforeOrder.AccountID) == "false")
            {
                this.lbl_tax.Style.Add("display", "none");
                this.lbl_TaxValue.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCBOGrandTotal", ConfirmBeforeOrder.AccountID) == "false")
            {
                this.lbl_grandTotal.Style.Add("display", "none");
                this.lbl_grandTotal_cost.Style.Add("display", "none");
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                if (RewriteContext.Current.Params["OrdKey"] != null)
                {
                    string str2 = RewriteContext.Current.Params["OrdKey"].ToString();
                    keySeparator = new char[] { this.KeySeparator };
                    this.OrderKey = str2.Split(keySeparator)[1].ToString();
                }
            }
            else if (base.Request.Params["OrdKey"] != null)
            {
                this.OrderKey = base.Request.Params["OrdKey"].ToString();
            }
            foreach (DataRow dataRow in LoginBasePage.Select_AccountDetails((long)this.CompanyID, ConfirmBeforeOrder.AccountID).Rows)
            {
                this.AccountType = dataRow["accountType"].ToString();
                this.DateFormat = dataRow["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(dataRow["createdBy"].ToString());
                this.ISCouponCodeEnabled = Convert.ToBoolean(dataRow["ISCouponCodeEnabled"]);
                if (!this.ISCouponCodeEnabled)
                {
                    continue;
                }
                this.CouponCodeDisplay = "display:block;";
            }
            this.NewSessionID = this.comm.UniqueID;
            this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(ConfirmBeforeOrder.AccountID);
            if (!base.IsPostBack)
            {
                if (this.StoreUserID != (long)0)
                {
                    int num = 0;
                    decimal num1 = new decimal(0);
                    decimal num2 = new decimal(0);
                    string empty3 = string.Empty;
                    long num3 = (long)0;
                    DataTable dataTable1 = CartBasePage.default_settings(Convert.ToInt32(this.CompanyID), Convert.ToInt32(ConfirmBeforeOrder.AccountID));
                    if (dataTable1.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in dataTable1.Rows)
                        {
                            this.CartJobScreenNameShow = Convert.ToBoolean(row1["CartJobNameShow"]);
                            this.CartJobScreenName = Convert.ToString(row1["CartJobScreenName"]);
                        }
                    }
                    this.plhorder_Header.Controls.Add(new LiteralControl("<table class='h_tablewidth'>"));
                    this.plhorder_Header.Controls.Add(new LiteralControl("<tr>"));
                    this.plhorder_Header.Controls.Add(new LiteralControl("<td class='h_qtytd' style='width:6%;min-width:75px'>"));
                    this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td class='h_productnametd' style='white-space: nowrap;'><strong>", this.objLanguage.GetLanguageConversion("Product_Name"), " </strong>")));
                    this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    if (this.Approval_Type.ToLower() == "s")
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td style='min-width:101px;white-space: nowrap;' class='h_productSelfApptd' ><strong>", this.objLanguage.GetLanguageConversion("Approved"), " </strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsCampaignEnabled.ToLower() != "true")
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td  class='h_productdescwithoutcampaigntd' style='white-space: nowrap;'><strong>", this.objLanguage.GetLanguageConversion("Product_Description"), " </strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td  class='h_productdesctd' style='white-space: nowrap;'><strong>", this.objLanguage.GetLanguageConversion("Product_Description"), " </strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsCampaignEnabled.ToLower() == "true")
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td  class='h_campaigntd' style='white-space: nowrap;'><strong>", this.objLanguage.GetLanguageConversion("Campaign_Name"), " </strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.CartJobScreenNameShow)
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td class='h_jobnametd' style='white-space: nowrap;'><strong>", this.CartJobScreenName, "</strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td class='h_jobnametd' style='white-space: nowrap; display:none;'><strong>", this.CartJobScreenName, "</strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        ControlCollection controls = this.plhorder_Header.Controls;
                        languageConversion = new string[] { "<td class='DisplayNone' style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'", str, "><strong>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                        controls.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        ControlCollection controlCollections = this.plhorder_Header.Controls;
                        languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'", str, "><strong>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                        controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td class='DisplayNone' style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:left;min-width:101px;white-space: nowrap;' ><strong>", " Tax Applicable", "</strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:left;min-width:101px;white-space: nowrap;' ><strong>", " Tax Applicable", "</strong>")));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhorder_Header.Controls.Add(new LiteralControl(string.Concat("<td style='white-space: nowrap;' class='h_qtytd'><strong>", this.objLanguage.GetLanguageConversion("Qty"), " </strong>")));
                    this.plhorder_Header.Controls.Add(new LiteralControl("</td >"));
                    if (this.ISCouponCodeEnabled)
                    {
                        if (this.IsEnableHidePrice != "false")
                        {
                            ControlCollection controls1 = this.plhorder_Header.Controls;
                            languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;' class='DisplayNone'><strong>", this.objLanguage.GetLanguageConversion("Discount"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                            controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            ControlCollection controlCollections1 = this.plhorder_Header.Controls;
                            languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'><strong>", this.objLanguage.GetLanguageConversion("Discount"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    if (this.IsEnableHidePrice != "false")
                    {
                        str1 = "style='display:none;'";
                        if (this.CartJobScreenNameShow)
                        {
                            ControlCollection controls2 = this.plhorder_Header.Controls;
                            languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;display:none;'><strong>", "Total (ex. Tax)", " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                            controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                            this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                        }
                        else
                        {
                            ControlCollection controlCollections2 = this.plhorder_Header.Controls;
                            languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'", str1, "><strong>", "Total (ex. Tax)", " (", this.comm.GetCurrencyinRequiredFormate("", true), ") </strong>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                            this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    else if (this.CartJobScreenNameShow)
                    {
                        ControlCollection controls3 = this.plhorder_Header.Controls;
                        languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'", str1, "><strong>", "Total (ex. Tax)", " </strong>" };
                        controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        ControlCollection controlCollections3 = this.plhorder_Header.Controls;
                        languageConversion = new string[] { "<td style='height: 20px;margin: 10px 0px 0px 15px;padding: 4px 0px 0px 5px;background-color: #FFF;border-top: solid 1px #444;border-left: solid 0px #CCC;border-bottom: solid 1px;text-align:right;min-width:101px;white-space: nowrap;'", str1, "><strong>", "Total (ex. Tax)", " </strong>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhorder_Header.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhorder_Header.Controls.Add(new LiteralControl("</tr>"));
                    if (this.Session["MultipleCartID"] != null)
                    {
                        DataSet dataSet = OrderBasePage.Select_OrderItems_BeforeOrder(this.StoreUserID, this.Session["MultipleCartID"].ToString());
                        foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                        {
                            this.CartID = Convert.ToInt64(dataRow1["CartID"]);
                            if (Convert.ToBoolean(dataRow1["IsCumulativePricing"]))
                            {
                                this.IsCumulative = true;
                            }
                            if (Convert.ToBoolean(dataRow1["IsCouponCodeApplied"]) && this.ISCouponCodeEnabled)
                            {
                                this.DivCouponCode.Style.Add("display", "block");
                                System.Web.UI.WebControls.Label label = this.lblCouponCode;
                                languageConversion = new string[] { base.SpecialDecode(dataRow1["UserFriendlyName"].ToString()), "(", base.SpecialDecode(dataRow1["CouponCode"].ToString()), ") - ", base.SpecialDecode(dataRow1["CouponCodeDiscount"].ToString()) };
                                label.Text = string.Concat(languageConversion);
                            }
                            string str3 = string.Empty;
                            str3 = (dataRow1["PDFNameFromCart"].ToString() != "" || dataRow1["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(dataRow1["IsPrintReadyFile"]) && Convert.ToBoolean(dataRow1["ForcePrintReadyFile"]) ? "Style='display:block;float:left;'" : "Style='display:none;float:left;'");
                            if (Convert.ToInt64(dataRow1["MainProductID"]) == (long)0)
                            {
                                this.MainProductName = "";
                                this.MainProductId = (long)0;
                            }
                            else
                            {
                                this.MainProductName = CartBasePage.Select_MainProductName(Convert.ToInt64(dataRow1["MainProductID"]));
                                this.MainProductId = Convert.ToInt64(dataRow1["MainProductID"]);
                            }
                            if (this.Session["OrderBehalfType"].ToString().ToLower() == "u" || this.Session["OrderBehalfType"].ToString().ToLower() == "d")
                            {
                                DataTable item = (DataTable)this.Session["InsertOrder"];
                                if (item.Rows.Count <= 0)
                                {
                                    this.lblorderedforname.Text = base.SpecialDecode(string.Concat(dataRow1["FirstName"].ToString(), " ", dataRow1["LastName"].ToString()));
                                    this.lblorderedforemail.Text = base.SpecialDecode(dataRow1["EmailID"].ToString());
                                    foreach (DataRow row2 in LoginBasePage.Select_DeptDetail_For_StoreUser(ConfirmBeforeOrder.AccountID, this.StoreUserID).Rows)
                                    {
                                        this.hdnDeptID.Value = row2["DeptID"].ToString();
                                    }
                                }
                                else
                                {
                                    DataTable dataTable2 = new DataTable();
                                    if (item.Rows[0]["OrderBehalfType"].ToString().ToLower() != "d")
                                    {
                                        dataTable2 = OrderBasePage.Select_DeptOrUser_Name(Convert.ToInt64(item.Rows[0]["OrderForUserID"]), (long)0);
                                    }
                                    else
                                    {
                                        dataTable2 = OrderBasePage.Select_DeptOrUser_Name(Convert.ToInt64(item.Rows[0]["OrderForUserID"]), Convert.ToInt64(item.Rows[0]["DeptID"]));
                                        this.hdnDeptID.Value = item.Rows[0]["DeptID"].ToString();
                                    }
                                    foreach (DataRow dataRow2 in dataTable2.Rows)
                                    {
                                        this.div_orderedfor.Style.Add("display", "block");
                                        if (this.Session["OrderBehalfType"].ToString().ToLower() != "d")
                                        {
                                            this.lblorderedforname.Text = base.SpecialDecode(dataRow2["FirstName"].ToString());
                                            this.lblorderedforemail.Text = base.SpecialDecode(dataRow2["email"].ToString());
                                            this.hdnDeptID.Value = dataRow2["DeptID"].ToString();
                                        }
                                        else
                                        {
                                            if (ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg" && ConfirmBeforeOrder.AccountID == (long)267)
                                            {
                                                this.lblorderedforname.Text = base.SpecialDecode(string.Concat(dataRow2["DeptName"].ToString(), "</br>"));
                                            }
                                            else if (this.deptScreenName != "")
                                            {
                                                this.lblorderedforname.Text = string.Concat(base.SpecialDecode(dataRow2["DeptName"].ToString()), " [", this.deptScreenName, "]");
                                            }
                                            else
                                            {
                                                this.lblorderedforname.Text = string.Concat(base.SpecialDecode(dataRow2["DeptName"].ToString()), " [Department]");
                                            }
                                            this.div_attnfor.Style.Add("display", "block");
                                            this.lblforattention.Text = string.Concat(" ", base.SpecialDecode(dataRow2["firstname"].ToString()));
                                            this.lblemail.Style.Add("display", "none");
                                            this.lblorderedforemail.Style.Add("display", "none");
                                            this.div_attnfor.Style.Add("white-space", "nowrap");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                this.lblorderedforname.Text = base.SpecialDecode(string.Concat(dataRow1["FirstName"].ToString(), " ", dataRow1["LastName"].ToString()));
                                this.lblorderedforemail.Text = base.SpecialDecode(dataRow1["EmailID"].ToString());
                                foreach (DataRow row3 in LoginBasePage.Select_DeptDetail_For_StoreUser(ConfirmBeforeOrder.AccountID, this.StoreUserID).Rows)
                                {
                                    this.hdnDeptID.Value = row3["DeptID"].ToString();
                                }
                            }
                            this.lbl_name.Text = base.SpecialDecode(string.Concat(dataRow1["FirstName"].ToString(), " ", dataRow1["LastName"].ToString()));
                            this.lbl_email.Text = base.SpecialDecode(dataRow1["EmailID"].ToString());
                            this.plhorder.Controls.Add(new LiteralControl("<tr class='tr_tablesetup'>"));
                            this.plhorder.Controls.Add(new LiteralControl("<td style='width:3%;'>"));
                            string empty4 = string.Empty;
                            if (dataRow1["PDFNameFromCart"].ToString() != "")
                            {
                                if (dataRow1["PreviewType"].ToString() == "" || dataRow1["PreviewType"].ToString() == "pdfimg" || dataRow1["PreviewType"].ToString() == "pdf")
                                {
                                    empty4 = "pdf";
                                    ControlCollection controls4 = this.plhorder.Controls;
                                    accountID = new object[] { "<img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", ConfirmBeforeOrder.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_Open(\"", dataRow1["PDFNameFromCart"].ToString(), "\",", ConfirmBeforeOrder.AccountID, ",\"", empty4, "\");' ", str3, "/>" };
                                    controls4.Add(new LiteralControl(string.Concat(accountID)));
                                }
                            }
                            else if (dataRow1["PrintReadyFile"].ToString() != "")
                            {
                                var PrintReadyFileWaterMark = dataRow1["PrintReadyFileWaterMark"].ToString();
                                var IsPrintReadyFileWaterMark = Convert.ToBoolean(dataRow1["IsPrintReadyFileWaterMark"]);

                                empty4 = "printready";
                                ControlCollection controlCollections4 = this.plhorder.Controls;
                                accountID = new object[] { "<img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", ConfirmBeforeOrder.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' onclick='javascript:Pdf_Open(\"", IsPrintReadyFileWaterMark == true ? PrintReadyFileWaterMark : dataRow1["PrintReadyFile"].ToString(), "\",", this.CompanyID, ",\"", empty4, "\");' ", str3, "/>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            if (dataRow1["ImageNameFromCart"].ToString() != "" && (dataRow1["PreviewType"].ToString() == "pdfimg" || dataRow1["PreviewType"].ToString() == "img"))
                            {
                                empty4 = "previewimage";
                                ControlCollection controls5 = this.plhorder.Controls;
                                accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", ConfirmBeforeOrder.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", dataRow1["ImageNameFromCart"].ToString(), "\",", ConfirmBeforeOrder.AccountID, ",\"", this.strSitepath, "\",\"", empty4, "\");' ", str3, "/></div>" };
                                controls5.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            if (dataRow1["UploadFile"].ToString() != "" || dataRow1["UploadFile1"].ToString() != "" || dataRow1["UploadFile2"].ToString() != "")
                            {
                                ControlCollection controlCollections5 = this.plhorder.Controls;
                                accountID = new object[] { "<a ><img id='img_Edit_", num, "' onclick='openArtworkPopup(", dataRow1["CartItemID"].ToString(), ",", dataRow1["CartID"].ToString(), ") ' class='floatLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", ConfirmBeforeOrder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/>" };
                                controlCollections5.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            this.plhorder.Controls.Add(new LiteralControl("<td class='tr_productnametd'>"));
                            System.Web.UI.WebControls.Label label1 = new System.Web.UI.WebControls.Label();
                            System.Web.UI.WebControls.Label label2 = new System.Web.UI.WebControls.Label();
                            label1.ID = string.Concat("lblproductName_", num);
                            label1.Text = base.SpecialDecode(dataRow1["CatalogueName"].ToString());
                            label2.Text = base.SpecialDecode(this.MainProductName);
                            if (dataRow1["MatrixType"].ToString().ToLower() == "g")
                            {
                                string str4 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Width"].ToString()), 2, "", false, false, true);
                                string str5 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Height"].ToString()), 2, "", false, false, true);
                                languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str4, " </label><br/><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str5, " </label></span>" };
                                label1.Text = string.Concat(languageConversion);
                            }
                            if (this.MainProductId != (long)0)
                            {
                                this.plhorder.Controls.Add(label2);
                                this.plhorder.Controls.Add(new LiteralControl("</br>"));
                            }
                            this.plhorder.Controls.Add(label1);
                            int num4 = 0;
                            DataTable dataTable3 = CartBasePage.Select_CartAdditionalItems(Convert.ToInt64(dataRow1["CartItemID"]));
                            foreach (DataRow dataRow3 in dataTable3.Rows)
                            {
                                if (Convert.ToInt32(dataRow3["CheckCount"]) <= 0)
                                {
                                    break;
                                }
                                if (Convert.ToInt32(dataRow3["OptionID"]) <= 0 && Convert.ToString(dataRow3["WebOtherCostType"]) != "Decoration")
                                {
                                    continue;
                                }
                                System.Web.UI.WebControls.Label label3 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblAdditionalName_", num, num4)
                                };
                                label3.Style.Add("padding-left", "0px");
                                label3.Style.Add("font-size", "12px");
                                label3.Style.Add("font-weight", "bold");
                                label3.Style.Add("color", "#696969");
                                if (num4 == 0)
                                {
                                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<br/><div class='marginTop5px'><Strong><label><i>", this.objLanguage.GetLanguageConversion("Additional_Items"), "</i></label></Strong></div>")));
                                }
                                label3.Text = string.Concat(base.SpecialDecode(dataRow3["UserFriendlyName"].ToString()), "</br>");
                                this.plhorder.Controls.Add(label3);
                                if (dataRow3["MainCalculationType"].ToString().ToLower() == "c")
                                {
                                    var decoration = "";
                                    if (Convert.ToString(dataRow3["WebOtherCostType"]) == "Decoration")
                                    {
                                        string[] strSelectedValue = Convert.ToString(dataRow3["SelectedValue"]).Split('¶');
                                        decoration = strSelectedValue[0];
                                    }


                                    this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                    System.Web.UI.WebControls.Label label4 = new System.Web.UI.WebControls.Label();
                                    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                                    label4.ID = string.Concat(accountID);
                                    label4.Text = decoration == "" ? dataRow3["SelectedValue"].ToString().Trim() : decoration;
                                    label4.Attributes.Add("style", "padding-left:20px; font-size:11px; ");
                                    this.plhorder.Controls.Add(label4);
                                    this.plhorder.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                }
                                num4++;
                            }
                            if (num4 == 0)
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                this.plhorder.Controls.Add(label1);
                                this.plhorder.Controls.Add(new LiteralControl("</div>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("</div></div>"));
                            }
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            if (this.Approval_Type.ToLower() == "s")
                            {
                                if (this.Session["SelfApproval_ItemID"] == null)
                                {
                                    this.plhorder.Controls.Add(new LiteralControl("<td style='padding-left: 25px; padding-top: 5px;'>No</td>"));
                                }
                                else if (this.Session["SelfApproval_ItemID"].ToString().Trim() == "")
                                {
                                    this.plhorder.Controls.Add(new LiteralControl("<td style='padding-left: 25px; padding-top: 5px;'>No</td>"));
                                }
                                else
                                {
                                    string empty5 = string.Empty;
                                    string str6 = this.Session["SelfApproval_ItemID"].ToString();
                                    keySeparator = new char[] { ',' };
                                    string[] strArrays = str6.Split(keySeparator);
                                    int num5 = 0;
                                    while (num5 < (int)strArrays.Length - 1)
                                    {
                                        if (strArrays[num5].ToString() != dataRow1["CartItemID"].ToString())
                                        {
                                            empty5 = "<td style='padding-left: 5px; padding-top: 5px;'>No</td>";
                                            num5++;
                                        }
                                        else
                                        {
                                            empty5 = "<td style='padding-left: 5px; padding-top: 5px;'>Yes</td>";
                                            break;
                                        }
                                    }
                                    this.plhorder.Controls.Add(new LiteralControl(empty5));
                                }
                            }
                            if (this.IsCampaignEnabled.ToLower() != "true")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_productdesc_campaign_td'>"));
                                System.Web.UI.WebControls.Label label5 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductDescription_", num),
                                    Text = base.SpecialDecode(dataRow1["Description"].ToString())
                                };
                                this.plhorder.Controls.Add(label5);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_productdesctd'>"));
                                System.Web.UI.WebControls.Label label6 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductDescription_", num),
                                    Text = base.SpecialDecode(dataRow1["Description"].ToString())
                                };
                                this.plhorder.Controls.Add(label6);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (this.IsCampaignEnabled.ToLower() == "true")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_campaign_td'>"));
                                System.Web.UI.WebControls.Label label7 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblCampaignName_", num),
                                    Text = base.SpecialDecode(dataRow1["EventName"].ToString())
                                };
                                this.plhorder.Controls.Add(label7);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (this.CartJobScreenNameShow)
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_jobnametd'>"));
                                System.Web.UI.WebControls.Label str7 = new System.Web.UI.WebControls.Label();
                                this.plhorder.Controls.Add(new LiteralControl("<div class='b_overflow_jobname'>"));
                                str7.ID = string.Concat("lblProductJobName_", num);
                                str7.Text = dataRow1["JobName"].ToString();
                                str7.Style.Add("word-break", "keep-all");
                                str7.Style.Add("white-space", "pre-wrap");
                                this.plhorder.Controls.Add(str7);
                                this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_jobnametd' style='display:none;'>"));
                                System.Web.UI.WebControls.Label label8 = new System.Web.UI.WebControls.Label();
                                this.plhorder.Controls.Add(new LiteralControl("<div class='b_overflow_jobname'>"));
                                label8.ID = string.Concat("lblProductJobName_", num);
                                label8.Text = dataRow1["JobName"].ToString();
                                label8.Style.Add("word-break", "keep-all");
                                label8.Style.Add("white-space", "pre-wrap");
                                this.plhorder.Controls.Add(label8);
                                this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (this.IsEnableHidePrice != "false")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_unitpricetd DisplayNone'>"));
                                System.Web.UI.WebControls.Label label9 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductPrice_", num),
                                    Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["UnitPrice"].ToString()), 2, "", false, false, true)
                                };
                                this.plhorder.Controls.Add(label9);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_unitpricetd'>"));
                                System.Web.UI.WebControls.Label label10 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductPrice_", num),
                                    Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["UnitPrice"].ToString()), 2, "", false, false, true)
                                };
                                this.plhorder.Controls.Add(label10);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (this.IsEnableHidePrice != "false")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_TaxApplicable DisplayNone'>"));
                                System.Web.UI.WebControls.Label label11 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("TaxApplicable_", num),
                                    Text = string.Concat(dataRow1["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Tax"]), 2, "", false, false, true)), "%")
                                };
                                this.plhorder.Controls.Add(label11);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_TaxApplicable'>"));
                                System.Web.UI.WebControls.Label label12 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("TaxApplicable_", num),
                                    Text = string.Concat(dataRow1["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Tax"]), 2, "", false, false, true)), "%")
                                };
                                this.plhorder.Controls.Add(label12);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            this.plhorder.Controls.Add(new LiteralControl("<td class='tr_qtytd' style='word-break:normal'>"));
                            this.plhorder.Controls.Add(new LiteralControl("<div>"));
                            System.Web.UI.WebControls.Label label13 = new System.Web.UI.WebControls.Label()
                            {
                                ID = string.Concat("lblproductQty_", num),
                                Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Quantity"].ToString()), 0, "", true, false, true)
                            };
                            this.plhorder.Controls.Add(label13);
                            this.plhorder.Controls.Add(new LiteralControl("</div"));
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            if (this.ISCouponCodeEnabled)
                            {
                                if (this.IsEnableHidePrice != "false")
                                {
                                    this.plhorder.Controls.Add(new LiteralControl("<td class='tr_unitpricetd DisplayNone'>"));
                                    this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                    System.Web.UI.WebControls.Label label14 = new System.Web.UI.WebControls.Label()
                                    {
                                        ID = string.Concat("lblDiscount_", dataRow1["CartItemID"].ToString()),
                                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                                    };
                                    this.plhorder.Controls.Add(label14);
                                    this.plhorder.Controls.Add(new LiteralControl("</div"));
                                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                                }
                                else
                                {
                                    this.plhorder.Controls.Add(new LiteralControl("<td class='tr_unitpricetd'>"));
                                    this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                    System.Web.UI.WebControls.Label label15 = new System.Web.UI.WebControls.Label()
                                    {
                                        ID = string.Concat("lblDiscount_", dataRow1["CartItemID"].ToString()),
                                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                                    };
                                    this.plhorder.Controls.Add(label15);
                                    this.plhorder.Controls.Add(new LiteralControl("</div"));
                                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                                }
                            }
                            if (this.IsEnableHidePrice != "false")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_totalpricetd DisplayNone'>"));
                                this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                System.Web.UI.WebControls.Label label16 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductTotal_", num),
                                    Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["UnitPrice"].ToString()) * Convert.ToDecimal(dataRow1["Quantity"].ToString()), 2, "", false, false, true)
                                };
                                num1 = num1 + (Convert.ToDecimal(dataRow1["UnitPrice"].ToString()) * Convert.ToDecimal(dataRow1["Quantity"].ToString()));
                                this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                this.plhorder.Controls.Add(label16);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='tr_totalpricetd'>"));
                                this.plhorder.Controls.Add(new LiteralControl("<div>"));
                                System.Web.UI.WebControls.Label label17 = new System.Web.UI.WebControls.Label()
                                {
                                    ID = string.Concat("lblproductTotal_", num),
                                    Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["UnitPrice"].ToString()) * Convert.ToDecimal(dataRow1["Quantity"].ToString()), 2, "", false, false, true)
                                };
                                num1 = num1 + (Convert.ToDecimal(dataRow1["UnitPrice"].ToString()) * Convert.ToDecimal(dataRow1["Quantity"].ToString()));
                                this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                this.plhorder.Controls.Add(label17);
                                this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (this.IsEnableHidePrice != "false")
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td class='DisplayNone'><div class='DisplayNone'>"));
                            }
                            else
                            {
                                this.plhorder.Controls.Add(new LiteralControl("<td><div class='DisplayNone'>"));
                            }
                            decimal num6 = Convert.ToDecimal(dataRow1["UnitPrice"].ToString()) * Convert.ToDecimal(dataRow1["Quantity"].ToString());
                            decimal num7 = Convert.ToDecimal(dataRow1["Tax"]);
                            num2 = num2 + (num6 * (num7 / new decimal(100)));
                            System.Web.UI.WebControls.Label label18 = new System.Web.UI.WebControls.Label()
                            {
                                ID = string.Concat("lblproductTax_", num),
                                Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Tax"].ToString()), 2, "", false, false, true)
                            };
                            this.plhorder.Controls.Add(label18);
                            this.plhorder.Controls.Add(new LiteralControl("</td></tr>"));
                            num++;
                        }
                        this.plhorder.Controls.Add(new LiteralControl("</table><div class='clearBoth'></div>"));
                        int num8 = 0;
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        decimal num11 = new decimal(0);
                        foreach (DataRow row5 in dataSet.Tables[0].Rows)
                        {
                            num11 = Convert.ToDecimal(row5["Tax"]);
                        }
                        foreach (DataRow row4 in dataSet.Tables[1].Rows)
                        {
                            if (this.IsEnableHidePrice != "false")
                            {
                                this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                                ControlCollection controls6 = this.plhOrdAddOptions.Controls;
                                accountID = new object[] { "<label class='floatRight Visibilityhidden' id='lblOrderAddValue_", num8, "'> ", row4["SelectedValue"].ToString(), "</label><br/>" };
                                controls6.Add(new LiteralControl(string.Concat(accountID)));
                                this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                                ControlCollection controlCollections6 = this.plhOrdAddOptionsPrice.Controls;
                                accountID = new object[] { "<label class='Visibilityhidden' id='lblOrderAddPrice_", num8, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row4["SelectedPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                                controlCollections6.Add(new LiteralControl(string.Concat(accountID)));
                                this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                            }
                            else
                            {
                                this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                                ControlCollection controls7 = this.plhOrdAddOptions.Controls;
                                accountID = new object[] { "<label class='floatRight' id='lblOrderAddValue_", num8, "'> ", row4["SelectedValue"].ToString(), "</label><br/>" };
                                controls7.Add(new LiteralControl(string.Concat(accountID)));
                                this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                                this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                                ControlCollection controlCollections7 = this.plhOrdAddOptionsPrice.Controls;
                                accountID = new object[] { "<label id='lblOrderAddPrice_", num8, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row4["SelectedPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                                controlCollections7.Add(new LiteralControl(string.Concat(accountID)));
                                this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                            }
                            num9 = num9 + Convert.ToDecimal(row4["SelectedPrice"]);
                            if (num11 == 0)
                            {
                                num10 = num10 + (Convert.ToDecimal(row4["SelectedPrice"]) * (Convert.ToDecimal(row4["cartAdditionalTaxPercentage"]) / new decimal(100)));
                            }
                            else
                            {
                                num10 = num10 + (Convert.ToDecimal(row4["SelectedPrice"]) * (num11 / new decimal(100)));
                            }
                            num8++;
                        }
                        string checkboxValue = Session["CheckboxValue"] as string;
                        if (checkboxValue == "1")
                        {
                            // Disable the dropdown if the checkbox value is "1"
                            this.ddlTest.Enabled = false;
                        }
                        else
                        {
                            DataTable dtShipSettings = OrderBasePage.PC_select_DeliveryCost_Settings(this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID));
                            foreach (DataRow row1 in dtShipSettings.Rows)
                            {
                                if (Convert.ToInt32(row1["IsEnableDC"]) != 1)
                                {
                                    this.ddlTest.Visible = false;
                                    this.DeliveryCostPrice.Style.Add("display", "none");
                                    this.DeliveryCost.Style.Add("display", "none");
                                }
                                else
                                {
                                    CartBasePage.Delete_ShipRates(this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID));
                                    this.BindShipEngineDrop(this.StoreUserID);
                                }
                            }
                        }
                        num11 = num2 + num10;
                        this.lbl_subTotal_cost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num1, 2, "", false, false, true);
                        this.lbl_TaxValue.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num11, 2, "", false, false, true);
                        this.lbl_grandTotal_cost.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num11) + num9, 2, "", false, false, true));
                        this.Session["GrandTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num11) + num9, 2, "", false, false, true);
                        foreach (DataRow dataRow4 in dataSet.Tables[2].Rows)
                        {
                            this.IsTerms = dataRow4["IsTerms"].ToString().ToLower();
                            if (dataRow4["IsTerms"].ToString().ToLower() != "true")
                            {
                                continue;
                            }
                            this.div_confirmOrder.Style.Add("display", "block");
                            this.lbl_terms_conditions.Text = dataRow4["TermsAndCondition"].ToString();
                        }
                        if (this.Session["InsertOrder"] != null)
                        {
                            DataTable item1 = (DataTable)this.Session["InsertOrder"];
                            if (item1 != null)
                            {
                                foreach (DataRow row5 in item1.Rows)
                                {
                                    this.Return_address(this.StoreUserID, "", num3, Convert.ToInt64(row5["InvoiceAddressID"]), out this.Address);
                                    this.lbl_BliingAddress.Text = base.SpecialDecode(this.Address);
                                    this.Return_address(this.StoreUserID, "", num3, Convert.ToInt64(row5["DeliveryAddressID"]), out this.Address);
                                    this.lbl_ShippingAddress.Text = base.SpecialDecode(this.Address);
                                    this.lbl_UserRefOrderNo.Text = base.SpecialDecode(row5["OrderNumber"].ToString());
                                    this.lbl_OrderTitle.Text = base.SpecialDecode(row5["OrderTitle"].ToString());
                                    System.Web.UI.WebControls.Label lblOrderDate = this.lbl_OrderDate;
                                    commonclass _commonclass = this.comm;
                                    DateTime now = DateTime.Now;
                                    lblOrderDate.Text = _commonclass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                                    this.lbl_Payment.Text = row5["PaymentType"].ToString();
                                    this.lblDeliveryDate.Text = row5["RequiredBy"].ToString();
                                    this.lblCostcenter.Text = base.SpecialDecode(row5["CostCentreName"].ToString());
                                    lblComments.Text = base.SpecialDecode(row5["Comments"].ToString());
                                }
                            }
                        }
                        if (this.lbl_BliingAddress.Text == "")
                        {
                            this.order_billingAddress.Attributes.Add("style", "display:none");
                        }
                        if (this.lbl_ShippingAddress.Text == "")
                        {
                            this.shipping_billingaddress.Attributes.Add("style", "display:none");
                        }
                    }
                }
                this.isCheckPaymentInfo = this.comm.GetDisplayValue("isCheckPaymentInfo", ConfirmBeforeOrder.AccountID);
                if (this.comm.GetDisplayValue("isCheckPaymentInfo", ConfirmBeforeOrder.AccountID) != "false")
                {
                    this.div_confirm.Attributes.Add("style", "display:none");
                    this.div_Payment.Attributes.Add("style", "display:block; float: left; width: 100%; margin: 10px 0px 14px 8px;");
                    this.li_payment.Attributes.Add("style", "display:block; margin: 0px 0px 0px 1px;");
                }
                else
                {
                    this.isPaymentInfo = "0";
                    this.div_confirm.Attributes.Add("style", "display:block; float: left; width: 100%; margin: 0px 0px 0px 8px;");
                    this.div_Payment.Attributes.Add("style", "display:none");
                    this.li_payment.Attributes.Add("style", "display:none;");
                }
                this.lbl_tax.Text = "Total Tax";
                string paragraphText = "";
                StringBuilder stringBuilder = new StringBuilder();
                DataTable errdata = CartBasePage.Select_ShipEngine_ErrDetail(ConfirmBeforeOrder.AccountID.ToString());
                foreach (DataRow row2 in errdata.Rows)
                {
                    string errdesc = row2["errdesc"].ToString();
                    stringBuilder.AppendLine(errdesc);
                }
                paragraphText = stringBuilder.ToString();
                ErrParagraph.InnerText = paragraphText;
            }
            string str8 = (new BaseClass()).Return_ApprovalOrderingProcess_Settings("showcostcenters");
            if (str8.Trim().ToLower() == "false" || str8.Trim().ToLower() == "")
            {
                this.DivCostCenter.Style.Add("display", "none");
            }
            if (this.hdnDeptID.Value.Trim() != "")
            {
                this.Session["DeptNotReqApproval"] = OrderBasePage.Get_Dept_IsApprovalNotRequired(Convert.ToInt64(this.hdnDeptID.Value));
            }
            if (this.IsEnableHidePrice == "true")
            {
                this.div1.Style.Add("display", "none");
                this.div5.Style.Add("display", "none");
                this.div3.Style.Add("display", "none");
                this.div4.Style.Add("display", "none");
                str1 = "style='display:none;'";
                this.lbl_subTotal.Style.Add("display", "none");
                this.lbl_subTotal_cost.Style.Add("display", "none");
                this.lbl_tax.Style.Add("display", "none");
                this.lbl_TaxValue.Style.Add("display", "none");
                this.lbl_grandTotal.Style.Add("display", "none");
                this.lbl_grandTotal_cost.Style.Add("display", "none");
            }

            //this.hdn_isOrderInformationAccessible.Value = "1";
            DataSet ds = OrderBasePage.approvalsystemsettings_getDetails(UserID, CompanyID, AccountID);
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                if (row["ShowCostCenters"].ToString().ToLower() != "true")
                {
                    this.ShowCostCenters = false;
                }
            }
            DataTable dt = OrderBasePage.settings_OrderingProcess_select(Convert.ToInt32(CompanyID), Convert.ToInt32(AccountID));
            foreach (DataRow dataRow in dt.Rows)
            {
                if (dataRow["isCheckOrderTitle"].ToString().ToLower() != "true")
                {
                    this.isCheckOrderTitle = false;
                }
                if (dataRow["isCheckOrderNumber"].ToString().ToLower() != "true")
                {
                    this.isCheckOrderNumber = false;
                }
                if (dataRow["isCheckDeliveryRequiredBy"].ToString().ToLower() != "true")
                {
                    this.isCheckDeliveryRequiredBy_1 = false;
                }
                if (dataRow["isCheckCooments"].ToString().ToLower() != "true")
                {
                    this.isCheckCooments = false;
                }
            }
            if (this.isCheckOrderTitle == false && this.isCheckOrderTitle == false && this.isCheckOrderNumber == false && this.isCheckDeliveryRequiredBy_1 == false && this.isCheckCooments == false)
            {
                //this.hdn_isOrderInformationAccessible.Value = "0";
                this.li3.Attributes.Add("style", "display:none");
                this.lblStep4.InnerText = "1";
                this.lblStep5.InnerText = "2";
                this.lblStep6.InnerText = "3";
            }
        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(AddressID)).Rows)
            {
                if (row["AddressLabel"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["AddressLabel"].ToString());
                    empty = string.Concat(empty, ",");
                    char[] chrArray = new char[] { ',' };
                    empty = string.Concat(empty.TrimEnd(chrArray), "<br/>");
                }
                if (row["AddressLine1"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["AddressLine1"].ToString());
                    empty = string.Concat(empty, ",");
                    char[] chrArray1 = new char[] { ',' };
                    empty = string.Concat(empty.TrimEnd(chrArray1), "<br/>");
                }
                if (row["AddressLine2"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["AddressLine2"].ToString());
                    empty = string.Concat(empty, ",");
                    char[] chrArray2 = new char[] { ',' };
                    empty = string.Concat(empty.TrimEnd(chrArray2), "<br/>");
                }
                if (row["Address2"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["Address2"].ToString());
                    if (row["Address3"].ToString().Trim().Length != 0 || row["Address4"].ToString().Trim().Length != 0)
                    {
                        empty = string.Concat(empty, ",&nbsp;");
                    }
                }
                if (row["Address3"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["Address3"].ToString());
                    if (row["Address4"].ToString() != "")
                    {
                        empty = string.Concat(empty, ",&nbsp;");
                    }
                }
                if (row["Address4"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, row["Address4"].ToString());
                }
                if (row["Country"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, "<br/>", row["Country"].ToString());
                    empty = string.Concat(empty, ",");
                    char[] chrArray3 = new char[] { ',' };
                    empty = string.Concat(empty.TrimEnd(chrArray3), "<br/>");
                }
                if (row["Phone"].ToString().Trim().Length != 0)
                {
                    empty = string.Concat(empty, "<br/> T:&nbsp;", row["Phone"].ToString());
                    empty = string.Concat(empty, ",");
                    char[] chrArray4 = new char[] { ',' };
                    empty = string.Concat(empty.TrimEnd(chrArray4), "<br/>");
                }
                if (row["Fax"].ToString().Trim().Length == 0)
                {
                    continue;
                }
                empty = string.Concat(empty, "F:&nbsp", row["Fax"].ToString());
                empty = string.Concat(empty, ",");
                char[] chrArray5 = new char[] { ',' };
                empty = string.Concat(empty.TrimEnd(chrArray5), "<br/>");
            }
            Address = empty;
        }

        public int SimpleMatrixCumulativePriceingQty(int qty, int ProductID)
        {
            int num;
            if (qty == 0)
            {
                return qty;
            }
            DataTable dataTable = ProductBasePage.Product_CatalogueQty_Select((long)ProductID);
            string[] strArrays = new string[dataTable.Rows.Count];
            string[] strArrays1 = new string[dataTable.Rows.Count];
            string[] strArrays2 = new string[dataTable.Rows.Count];
            string[] strArrays3 = new string[dataTable.Rows.Count];
            string[] strArrays4 = new string[dataTable.Rows.Count];
            int count = dataTable.Rows.Count;
            int num1 = 0;
            if (dataTable.Rows.Count > 0)
            {
                int num2 = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    strArrays.SetValue(row["FromQuantity"].ToString(), num2);
                    strArrays1.SetValue(row["ToQuantity"].ToString(), num2);
                    strArrays2.SetValue(row["Price"].ToString(), num2);
                    strArrays3.SetValue(row["SellingPrice"].ToString(), num2);
                    strArrays4.SetValue(row["Markup"].ToString(), num2);
                    num2++;
                }
            }
            int num3 = 0;
        Label1:
            while (num3 < (int)strArrays.Length)
            {
                try
                {
                    if (num3 == 0)
                    {
                        Convert.ToInt32(strArrays[num3].ToString());
                    }
                    if (qty <= Convert.ToInt32(strArrays[num3].ToString()))
                    {
                        num = Convert.ToInt32(strArrays[num3].ToString());
                    }
                    else if (qty >= Convert.ToInt32(strArrays[num3].ToString()) && qty <= Convert.ToInt32(strArrays1[num3].ToString()))
                    {
                        num = Convert.ToInt32(strArrays1[num3].ToString());
                    }
                    else if (qty > Convert.ToInt32(strArrays1[num3].ToString()) && qty < Convert.ToInt32(strArrays[num3 + 1].ToString()))
                    {
                        num = Convert.ToInt32(strArrays[num3 + 1].ToString());
                    }
                    else if (Convert.ToInt32(num3) != Convert.ToInt32((int)strArrays.Length - 1))
                    {
                        goto Label0;
                    }
                    else
                    {
                        num = Convert.ToInt32(strArrays[num3].ToString());
                    }
                }
                catch
                {
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        if (i == (int)strArrays1.Length - 1)
                        {
                            num1 = Convert.ToInt32(strArrays1[i]);
                        }
                    }
                    num = num1;
                }
                return num;
            }
            return qty;
        Label0:
            num3++;
            goto Label1;
        }

        public void BindShipEngineDrop(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            DataTable dtShipSettings = OrderBasePage.PC_select_DeliveryCost_Settings(this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID));
            foreach (DataRow row1 in dtShipSettings.Rows)
            {
                if (Convert.ToInt32(row1["IsEnableShipEngine"]) != 1)
                {
                    dataTable = CartBasePage.Select_NonShipRates_Detail();
                }
                else
                {
                    dataTable = CartBasePage.Select_ShipRates_Detail(this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID));
                }
            }
            //DataTable dataTable = CartBasePage.Select_ShipRates_Detail();
            this.ddlTest.DataSource = dataTable;
            this.ddlTest.DataTextField = "label";
            this.ddlTest.DataValueField = "DeliveryCost";
            string num = "";
            foreach (DataRow row in dataTable.Rows)
            {
                num = row["CarrierID"].ToString();
            }
            base.SetDDLValue(this.ddlTest, num);
            this.ddlTest.CssClass = "dropDownMultiple150";
            this.ddlTest.Attributes.Add("onchange", string.Concat("javascript:DeliveryCost(", StoreUserID, ");"));
            this.ddlTest.DataBind();

        }

        private void changeApprerEmail()
        {

            // Start Two Way Approval email

            this.ApprovalEmails = this.ApproverEmail;

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_ApprovalSystemSettings_select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, ConfirmBeforeOrder.AccountID);
            dataSet = database.ExecuteDataSet(storedProcCommand);


            DataRow dr = dataSet.Tables[0].Rows[0];

            string approvalType = dr["approvalType"].ToString();
            string isReapproval = dr["reapproval"].ToString();

            if (approvalType == "da" && isReapproval == "True")
            {
                string[] newApproverEmail = this.ApproverEmail.Split(',');
                if (newApproverEmail.Length > 1)
                {
                    this.ApproverEmail = newApproverEmail[1];
                }

                this.isTwoWayApproval = "1";
            }
            else
            {
                this.isTwoWayApproval = "0";
            }


            // End Two Way Approval email
        }

    }
}