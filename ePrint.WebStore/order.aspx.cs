using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Preflight;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class order : BaseClass, IRequiresSessionState
    {
        //protected HiddenField hid_MultiplePrice;

        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lblOrderNo;

        //protected Label lbl_OrderNo;

        //protected Label lblname;

        //protected Label lbl_name;

        //protected Label lblatnfor;

        //protected HtmlGenericControl spnattn;

        //protected Label lblOrderDate;

        //protected Label lbl_OrderDate;

        //protected Label lblemail;

        //protected Label lbl_email;

        //protected Label lblOrderTitle;

        //protected Label lbl_OrderTitle;

        //protected Label lbl_Orderedby;

        //protected Label lblUserRefOrderNo;

        //protected Label lbl_UserRefOrderNo;

        //protected Label lblordbyemail;

        //protected Label lbl_Orderedbyemail;

        //protected Label lblDelivery;

        //protected Label lblDeliveryDate;

        //protected Label lblstatus;

        //protected HtmlTableCell tdlblStatus;

        //protected Label lbl_Status;

        //protected System.Web.UI.WebControls.Image RejectImage;

        //protected HtmlTableCell tdStatus;

        //protected Label Label2;

        //protected Label lblCostcenter;

        //protected Label Label3;

        //protected Label lbl_ConsignmentNoteNumber;

        //protected HtmlTableRow TrCost;

        //protected Label Label1;

        //protected HtmlGenericControl Div_CouponCode;

        //protected Label lblCouponCode;

        //protected HtmlGenericControl Divlbl_CouponCode;

        //protected Label lblPayment;

        //protected HtmlGenericControl div_paymentmode;

        //protected Label lbl_Payment;

        //protected Label lblConsigneeurl;

        //protected Label lbl_BliingAddressID;

        //protected Label lbl_BliingAddress;

        //protected HtmlGenericControl order_billingAddress;

        //protected Label lbl_ShippingAddressID;

        //protected HtmlGenericControl divShippingAddress;

        //protected Label lbl_ShippingAddress;

        //protected HtmlGenericControl divDeliveryAddress;

        //protected HtmlInputCheckBox checkAll;

        //protected HtmlGenericControl HeaderCheckbox;

        //protected HtmlTableCell orderreference;

        //protected HtmlTableCell productdesc;

        //protected HtmlTableCell qty;

        //protected HtmlTableCell CampaignSignNumber;

        //protected HtmlTableCell Campaign_Td;

        //protected HtmlTableCell tdStaus;

        //protected HtmlTableCell tdApprovedStaus;

        //protected HtmlTableCell ItemMaterial;

        //protected Label lblJobname;

        //protected HtmlGenericControl divJobName;

        //protected HtmlTableCell JobName;

        //protected HtmlTableCell tdBeUser;

        //protected HtmlTableCell tdBeDept;

        //protected HtmlTableCell tdUnitprice;

        //protected HtmlTableCell tdTaxApplicable;

        //protected HtmlTableCell td_CouponCodeDiscount;

        //protected Label lblTotal;

        //protected HtmlTableCell tdTotal;

        //protected PlaceHolder plhorder;

        //protected HiddenField hdnOrderItemID;

        //protected Label lbl_subTotal_cost;

        //protected PlaceHolder plhOrdAddOptionsPrice;

        //protected Label lbl_TaxValue;

        //protected HtmlGenericControl div1;

        //protected HtmlGenericControl div3;

        //protected Label lbl_grandTotal_cost;

        //protected HtmlGenericControl div4;

        //protected Label lbl_subTotal;

        //protected PlaceHolder plhOrdAddOptions;

        //protected Label lbl_tax;

        //protected HtmlGenericControl div5;

        //protected Label lbl_grandTotal;

        //protected HtmlGenericControl div6;

        //protected Label lblpwd;

        //protected HtmlGenericControl div2;

        //protected Label Label5;

        //protected TextBox txtApproverPassword;

        //protected Label lblReqiPassword;

        //protected HtmlGenericControl DivApproverPassword;

        //protected Button btn_Reject;

        //protected Button btn_Approve;

        //protected HtmlGenericControl divButtons;

        //protected Label lblDis;

        //protected TextBox txtReason;

        //protected RequiredFieldValidator RequiredlstDepartment;

        //protected Button btnOk;

        //protected RadWindow RadWindow2;

        //protected HtmlGenericControl Order_area;

        //protected HiddenField hdnActionType;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        public commonclass comm = new commonclass();

        private BaseClass objBase = new BaseClass();

        private storeEmail objEmail = new storeEmail();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBaseClass = new BaseClass();

        public int CompanyID;

        public int ProductID;

        public long CartID;

        public long StoreUserID;

        public long ReferenceUserID;

        public long ApproverID;

        public long UserGettingApproved;

        public long OrderID;

        public static long AccountID;

        private string NewSessionID = string.Empty;

        public string imageName = string.Empty;

        public string ToEmail = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string strSitepath = string.Empty;
        public string SecureDocPath = string.Empty;
        public string ServerName = string.Empty;

        public string Address = string.Empty;

        public string OrderKey = string.Empty;

        public bool IsZip2taxEnabled;

        public string SystemName = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public static string imagePath;

        public string IsPPW = string.Empty;

        public bool IsPPW_SystemName;

        public string OrdID = string.Empty;

        public int Orderid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string UserType = string.Empty;

        public string approvalType = string.Empty;

        public string RequirePassword = string.Empty;

        public string AccountName = string.Empty;

        public string consignementnum = string.Empty;

        public string consigneeurl = string.Empty;

        public string strImagepath = BaseClass.imagePath();

        public string OrderBehalfUserIDs = string.Empty;

        public string OrderBehalfDeptIDs = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        private string MeasurementValue = string.Empty;

        public string StatusName = string.Empty;

        public bool IsBackOrder;

        public string PaymentMode_Style = string.Empty;

        private string ModuleItemnumber = string.Empty;

        public string PageFrom = string.Empty;

        public bool Is_Only_User_Orders;

        public bool Is_Only_User_DepartmentOrders;

        public bool IsCumulative;

        public bool ISCouponCodeApplied;

        public long MainProductId;

        public string IsEnableHidePrice = string.Empty;

        public string PDFToURLPath = string.Empty;

        public bool CartJobScreenNameShow;

        public string CartJobScreenName = string.Empty;
        private string approvalEmails = string.Empty;
        public int User_ID;

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

        static order()
        {
            order.AccountID = (long)0;
            order.imagePath = string.Empty;
        }

        public order()
        {
        }

        public class Attachment
        {
            public string AttachmentName { get; set; }
            public string AttachmentPath { get; set; }
            public string OriginalAttachmentName { get; set; }
            public int AttachmentId { get; set; }
        }

        private List<Attachment> GetAttachmentsFromDataSource()
        {
            List<Attachment> att;
            DataTable dt = OrderBasePage.etimates_attachment_select(this.CompanyID,this.User_ID,"",(int)this.OrderID, "webstoreorder");
            if (dt != null)
            {

                att = new List<Attachment>();

                foreach (DataRow row in dt.Rows)
                {
                    Attachment attachment = new Attachment
                    {
                        AttachmentName = row["FileName"].ToString(),
                        AttachmentId = Convert.ToInt32(row["AttachmentID"]),
                        OriginalAttachmentName= row["OriginalFileName"].ToString(),
                    
                        
                };
                    object[] objArray3 = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", row["OriginalFileName"].ToString(), "&type=a&aid=", order.AccountID, "&cid=", this.CompanyID };
                    attachment.AttachmentPath = string.Concat(objArray3);
                    att.Add(attachment);

                    //object[] objArray3 = new object[] { this.strSitepath, this.ServerName, "/", this.CompanyID, "/attachments/", attachment.AttachmentPath };
                    //attachment.AttachmentPath = string.Concat(objArray3);
                    //att.Add(attachment);
                }

                //        att = dt.AsEnumerable()
                //.Select(row => new Attachment
                //{
                //    AttachmentName = row.Field<string>("FileName"),
                //    AttachmentPath = row.Field<string>("OriginalFileName")
                //    //AttachmentId = row.Field<string>("AttachmentID")
                //})
                //.ToList();
            }
            else
            {
                att = null;
            }
            return att;
        }

        protected void deletelink_click(object sender, EventArgs e)
        {
            LinkButton deleteLink = (LinkButton)sender;
            long attachmentid = Convert.ToInt64(deleteLink.CommandArgument);
            OrderBasePage.etimates_attachment_delete(this.CompanyID, attachmentid);

        }

        protected void attachmentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            List<Attachment> attachments = GetAttachmentsFromDataSource();
            // Bind the attachment data to the GridView
            attachmentGridView.DataSource = attachments;
            attachmentGridView.DataBind();
        }
        protected void fileUploadControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.fp_artwork.HasFile)
                {
                    
                    string str1 = this.comm.ReplaceAllBlankSpace(this.fp_artwork.FileName);
                    string fileExtension = Path.GetExtension(str1).ToLower();

                    // Define the allowed file extensions
                    string[] notallowedExtensions = { ".exe", ".msi", ".dll", ".jar" }; // Add the extensions you want to allow

                    // Check if the file extension is in the list of allowed extensions
                    if (!notallowedExtensions.Contains(fileExtension))
                    {
                        FileUpload fpArtwork1 = this.fp_artwork;
                        object[] objArray3 = new object[] { ConnectionClass.SecureDocFilepath, this.ServerName, "/store/", order.AccountID, "/artwork/", str1 };
                        fpArtwork1.SaveAs(string.Concat(objArray3));
                        string FileName = this.objBase.ReplaceSingleQuote(fpArtwork1.FileName);
                        string OriginalAttachFileName = "";
                        if (FileName.Trim() != "")
                        {
                            string[] strArrays = fp_artwork.FileName.ToString().Trim().Split(new char[] { '.' });
                            string[] estNo = new string[] { strArrays[0], "_", null, null, null, null, null };
                            Guid guid = Guid.NewGuid();
                            estNo[2] = guid.ToString().Substring(0, 5);
                            estNo[3] = "_";
                            estNo[4] = this.orderreference.InnerHtml;
                            estNo[5] = ".";
                            estNo[6] = strArrays[(int)strArrays.Length - 1];
                            FileName = string.Concat(estNo);
                        }
                        OriginalAttachFileName = fpArtwork1.FileName;
                        OrderBasePage.etimates_attachment_insert(CompanyID, 0, "", 0, FileName, (int)this.OrderID, "webstoreorder", this.User_ID, false, OriginalAttachFileName, "", false);

                        lblValidationMessage.Text = "File uploaded successfully.";
                        lblValidationMessage.Visible = true;
                        base.Response.Redirect(string.Concat(this.strSitepath, "order.aspx?OrdKey=", this.OrderKey));
                    }
                    else
                    {
                        lblValidationMessage.Text = "File with Extension "+ fileExtension +" is not allowed.";
                        lblValidationMessage.Visible = true;
                    }
                }
                else
                {
                    lblValidationMessage.Text = "No file selected.";
                    lblValidationMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblValidationMessage.Text = "An error occurred: " + ex.Message;
                lblValidationMessage.Visible = true;
            }
        }
        protected void btn_Approve_Click(object sender, EventArgs e)
        {
           
            saveApproverComments(this.OrderID, this.txtComments.Text.ToString(),this.lbl_OrderTitle.Value,this.lbl_UserRefOrderNo.Value);

            if (this.ReferenceUserID != (long)0)
            {
                this.StoreUserID = this.ReferenceUserID;
            }
            this.RequirePassword = base.Return_ApprovalSystem_Settings("requirepwd");
            this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
            string isReapproval = base.Return_ApprovalSystem_Settings("reapproval");

            if (this.approvalType == "u")
            {
                string str = "approve";
                string[] strArrays = this.hdnOrderItemID.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays[i]));
                }
                this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1);
                this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Approval", "Customer", (long)0, this.ToEmail, this.approvalType);
                this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "New Order", "Admin", (long)0, "no approval", this.approvalType, this.hdnOrderItemID.Value);
                base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str));
                return;
            }
            if (this.RequirePassword == "True")
            {
                if (LoginBasePage.ExistanceOfPassword(Convert.ToInt64(this.Session["StoreUserID"]), this.txtApproverPassword.Text) == (long)0)
                {
                    this.lblReqiPassword.Visible = true;
                    this.RadWindow2.Visible = false;
                    return;
                }
                string str1 = "approve";
                string[] strArrays1 = this.hdnOrderItemID.Value.Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                {
                    OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str1, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays1[j]));
                }
                this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1);
                this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Approval", "Customer", (long)0, this.ToEmail, this.approvalType);
                this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "New Order", "Admin", (long)0, "no approval", this.approvalType);
                base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str1));
                return;
            }


            // start 

            if (this.approvalType == "da" && isReapproval.ToLower() == "true") // if approval type is da and reapproval requied
            {

                string str3 = "approve";
                string[] strArrays3 = this.hdnOrderItemID.Value.Split(new char[] { ',' });
                for (int k = 0; k < (int)strArrays3.Length - 1; k++)
                {
                    //OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str2, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays2[k]));
                    Int64 estimateid = getEstimateIDFromEstimateItem(Convert.ToInt64(strArrays3[k]));

                    string isDeptOrMain = approveForDepartment(estimateid);

                    if (isDeptOrMain == "DepartmentApproval")
                    {
                        if (k == strArrays3.Length - 2)
                        {
                            //Do somthin with the last iteration
                            updateDepartmentBit(estimateid);
                        }
                        string newEmail = changeApprovalEmail(estimateid);
                        this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrder.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), newEmail, str3);
                    }
                    else
                    {
                        OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str3, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays3[k]));
                        this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1);

                    }

                }

                this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Approval", "Customer", (long)0, this.ToEmail, this.approvalType);

                if (!this.IsBackOrder)
                {
                    this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "New Order", "Admin", (long)0, "no approval", this.approvalType, this.hdnOrderItemID.Value);
                }
                else
                {
                    this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "Back Order", "Admin", (long)0, "no approval", this.approvalType, this.hdnOrderItemID.Value);
                }

                base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str3));

                return;
            }

            // end

            string str2 = "approve";
            string[] strArrays2 = this.hdnOrderItemID.Value.Split(new char[] { ',' });
            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
            {
                OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str2, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays2[k]));
            }
            this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1);
            this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Approval", "Customer", (long)0, this.ToEmail, this.approvalType);
            if (!this.IsBackOrder)
            {
                this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "New Order", "Admin", (long)0, "no approval", this.approvalType, this.hdnOrderItemID.Value);
            }
            else
            {
                this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "Back Order", "Admin", (long)0, "no approval", this.approvalType, this.hdnOrderItemID.Value);
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str2));
        }

        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            saveApproverComments(this.OrderID, this.txtComments.Text.ToString(), this.lbl_OrderTitle.Value, this.lbl_UserRefOrderNo.Value);
            this.RadWindow2.Visible = false;
            this.lblReqiPassword.Visible = false;
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        this.RadWindow2.Visible = true;
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_showArtwork", "javascript:get_background_onreject();", true);
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(Convert.ToInt64(this.Session["StoreUserID"]), this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        return;
                    }
                    this.txtReason.Text = "";
                    this.RadWindow2.Visible = true;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_showArtwork", "javascript:get_background_onreject();", true);
                    return;
                }
                this.RadWindow2.Visible = true;
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "_showArtwork", "javascript:get_background_onreject();", true);
            }
        }

        protected void btnApprPassword_Click(object sender, EventArgs e)
        {
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ReferenceUserID != (long)0)
            {
                this.StoreUserID = this.ReferenceUserID;
            }
            string[] strArrays = this.hdnOrderItemID.Value.Split(new char[] { ',' });
            this.RequirePassword = base.Return_ApprovalSystem_Settings("requirepwd");
            this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
            string empty = string.Empty;
            empty = (this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1) != "," ? this.hdnOrderItemID.Value : this.hdnOrderItemID.Value.Substring(0, this.hdnOrderItemID.Value.Length - 1));
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_OrderItems_ForStock(Convert.ToInt64(this.OrderID), this.StoreUserID, empty);
            foreach (DataRow row in dataTable.Rows)
            {
                long num = Convert.ToInt64(row["ProductID"]);
                Convert.ToInt32(row["Quantity"]);
                Convert.ToDecimal(row["UnitPrice"]);
                long num1 = Convert.ToInt64(row["EstimateItemID"]);
                Convert.ToInt64(row["OrderItemID"]);
                foreach (DataRow dataRow in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                {
                    if (dataRow["DrawStockFrom"].ToString().ToLower() == "s")
                    {
                        baseClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", num1, "Job", this.StoreUserID, "a");
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        baseClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "other", num1, "Job", this.StoreUserID, "a");
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() != "a")
                    {
                        if (dataRow["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            continue;
                        }
                        baseClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", num1, "Job", this.StoreUserID, "a");
                    }
                    else
                    {
                        baseClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "additional option", num1, "Job", this.StoreUserID, "a");
                    }
                }
            }
            if (this.approvalType == "u")
            {
                string str = "reject";
                if (this.txtReason.Text != "")
                {
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays[i]));
                    }
                    this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Rejection", "Customer", (long)0, this.ToEmail, this.approvalType);
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str));
                }
            }
            else
            {
                string str1 = "reject";
                if (this.txtReason.Text != "" || this.txtReason.Text == "")
                {
                    for (int j = 0; j < (int)strArrays.Length - 1; j++)
                    {
                        OrderBasePage.Reject_OrderItem(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str1, this.ApproverID, this.UserGettingApproved, Convert.ToInt64(strArrays[j]));
                    }
                    this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order.AccountID), "B2B User Order Rejection", "Customer", (long)0, this.ToEmail, this.approvalType);
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx?Po=1&Type=", str1));
                    return;
                }
            }
        }

        public void Logout(long Account_ID)
        {
            HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
            if (item != null)
            {
                commonclass _commonclass = new commonclass();
                SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                sqlCommand.ExecuteNonQuery();
                _commonclass.closeConnection();
                base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
            }
            base.Response.Cookies["ResumeSessionID"].Expires = DateTime.Now.AddDays(-1);
            this.Session["StoreUserID"] = "";
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            if (Account_ID != (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "logout.aspx?id=", Account_ID));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //newkk.Attributes.Add("onClick", "return false;");
            //lnkEdit_Ship.Attributes.Add("onClick", "return false;");
            //lnkEdit_Bill.Attributes.Add("onClick", "return false;");

            object[] accountID;
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            string empty = string.Empty;
            string str = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_app");
            string str1 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_dept");
            string str2 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_users_user");
            string str3 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_app");
            string str4 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_dept");
            string str5 = base.Return_ApprovalOrderingProcess_Settings("allow_order_behalf_depts_user");
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/myorder.aspx'>", this.objLanguage.GetLanguageConversion("Orders"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft' href ='", BaseClass.SitePath, "order.aspx'></a>", this.objLanguage.GetLanguageConversion("Orders_Details"), "<span Class='floatLeft'>&nbsp;</span>" };
            label.Text = string.Concat(sitePath);
            this.btnOk.Text = this.objLanguage.GetLanguageConversion("OK");
            this.btn_Approve.Attributes.Add("onclick", "javascript:return Validate('Approve');");
            this.btn_Reject.Attributes.Add("onclick", "javascript:return Validate('Reject');");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                order.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select(order.AccountID, (long)this.CompanyID);
            if (dataTable.Rows.Count <= 0)
            {
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();

                    // CostCentreText added on 07-12-2017 by shehzad ahmed
                    if (Convert.ToString(row["CostCentreText"]) != string.Empty)
                    {
                        Label2.Text = Convert.ToString(row["CostCentreText"]);
                    }
                    else
                    {
                        Label2.Text = "Cost Centre";
                    }
                }
            }
            base.Title = commonclass.pageTitle("Order details", Convert.ToInt32(this.CompanyID), Convert.ToInt32(order.AccountID));
            if (EprintConfigurationManager.AppSettings["ImagePath"] != null)
            {
                order.imagePath = EprintConfigurationManager.AppSettings["ImagePath"].ToString();
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                this.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }

            if (ConnectionClass.SecureDocPath == null)
            {
                this.SecureDocPath = "";
            }
            else
            {
                this.SecureDocPath = ConnectionClass.SecureDocPath;
            }
            if (ConnectionClass.ServerName == null)
            {
                this.ServerName = "";
            }
            else
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            this.Session["RedirectToApproverOrderPage"] = null;
            this.Session["RedirectToUserOrderPage"] = null;
            DataTable dataTable1 = OrderBasePage.OrderMangerOptions_Select(Convert.ToInt32(this.CompanyID), Convert.ToInt32(order.AccountID));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (!Convert.ToBoolean(dataRow["Is_Only_User_Orders"]))
                {
                    this.Is_Only_User_Orders = false;
                }
                if (!Convert.ToBoolean(dataRow["Is_Only_User_DepartmentOrders"]))
                {
                    this.Is_Only_User_DepartmentOrders = false;
                }
                else
                {
                    this.Is_Only_User_DepartmentOrders = true;
                }
            }
            this.PageFrom = "order";
            this.DivApproverPassword.Visible = false;
            if (this.Session["IsPPW"] != null && this.Session["IsPPW"].ToString() == "1")
            {
                this.IsPPW = "1";
            }
            if (this.IsPPW == "1")
            {
                this.IsPPW_SystemName = true;
            }
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            string displayValue = this.comm.GetDisplayValue("OrderTitleText", order.AccountID);
            this.lblOrderTitle.Text = displayValue;
            string displayValue1 = this.comm.GetDisplayValue("OrderNumberText", order.AccountID);
            this.lblUserRefOrderNo.Text = displayValue1;
            string displayValue2 = this.comm.GetDisplayValue("DeliveryRequiredByText", order.AccountID);
            this.lblDelivery.Text = displayValue2;
            if (this.comm.GetDisplayValue("isCheckOrderTitle", order.AccountID) != "true")
            {
                this.lblOrderTitle.Style.Add("display", "none");
                this.lbl_OrderTitle.Style.Add("display", "none");
            }
            else
            {
                this.lblOrderTitle.Style.Add("display", "block");
                this.lbl_OrderTitle.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckOrderNumber", order.AccountID) != "true")
            {
                this.lblUserRefOrderNo.Style.Add("display", "none");
                this.lbl_UserRefOrderNo.Style.Add("display", "none");
            }
            else
            {
                this.lblUserRefOrderNo.Style.Add("display", "block");
                this.lbl_UserRefOrderNo.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", order.AccountID) != "true")
            {
                this.lblDelivery.Style.Add("display", "none");
                this.lblDeliveryDate.Style.Add("display", "none");
            }
            else
            {
                this.lblDelivery.Style.Add("display", "block");
                this.lblDeliveryDate.Style.Add("display", "block");
            }
            if (base.Request.Params["OrdKey"] != null)
            {
                this.OrderKey = base.Request.Params["OrdKey"].ToString().Trim();
            }
            if (this.OrderKey != null && this.OrderKey != "")
            {
                DataTable dataTable2 = OrderBasePage.Select_OrderID(this.OrderKey);
                if (dataTable2.Rows.Count > 0)
                {
                    if (this.Session["StoreUserID"] == null || this.Session["AccountID"] == null)
                    {
                        order.AccountID = Convert.ToInt64(dataTable2.Rows[0]["AccountID"]);
                        this.Session["fromEmail"] = base.Request.Url.ToString();
                        base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", order.AccountID));
                    }
                    else if (this.Session["AccountID"].ToString() == dataTable2.Rows[0]["AccountID"].ToString())
                    {
                        bool flag = false;
                        DataTable dataTable3 = LoginBasePage.StoreUser_select(Convert.ToInt64(this.Session["StoreUserID"]));
                        if (dataTable3.Rows.Count > 0)
                        {
                            flag = Convert.ToBoolean(dataTable3.Rows[0]["IsMainApprover"]);
                        }
                        if (!flag && this.Session["StoreUserID"].ToString() != dataTable2.Rows[0]["StoreUserID"].ToString() && this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
                        {
                            this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
                            this.objBaseClass.Assign_ApprovalSystemSettings_ForAccount(Convert.ToInt64(this.Session["AccountID"]));
                            this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                            if (this.approvalType == "u")
                            {
                                this.Session["fromEmail"] = base.Request.Url.ToString();
                                this.Logout(Convert.ToInt64(dataTable2.Rows[0]["AccountID"]));
                            }
                            else if (this.approvalType == "a" || this.approvalType == "da")
                            {
                                if (this.UserType.ToLower() == "u")
                                {
                                    if (this.Is_Only_User_Orders)
                                    {
                                        this.Session["fromEmail"] = base.Request.Url.ToString();
                                        this.Logout(Convert.ToInt64(dataTable2.Rows[0]["AccountID"]));
                                    }
                                    else if (Convert.ToInt64(dataTable2.Rows[0]["DepartmentID"]) != Convert.ToInt64(this.Session["DeptID"]) && this.Is_Only_User_DepartmentOrders)
                                    {
                                        this.Session["fromEmail"] = base.Request.Url.ToString();
                                        this.Logout(Convert.ToInt64(dataTable2.Rows[0]["AccountID"]));
                                    }
                                }
                                if (this.approvalType == "a" && this.UserType.ToLower() == "d")
                                {
                                    if (this.Is_Only_User_Orders)
                                    {
                                        this.Session["fromEmail"] = base.Request.Url.ToString();
                                        this.Logout(Convert.ToInt64(dataTable2.Rows[0]["AccountID"]));
                                    }
                                    else if (Convert.ToInt64(dataTable2.Rows[0]["DepartmentID"]) != Convert.ToInt64(this.Session["DeptID"]) && this.Is_Only_User_DepartmentOrders)
                                    {
                                        this.Session["fromEmail"] = base.Request.Url.ToString();
                                        this.Logout(Convert.ToInt64(dataTable2.Rows[0]["AccountID"]));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        order.AccountID = Convert.ToInt64(dataTable2.Rows[0]["AccountID"]);
                        this.Logout((long)0);
                        this.Session["fromEmail"] = base.Request.Url.ToString();
                        base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", order.AccountID));
                    }
                }
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && order.AccountID == (long)0)
            {
                this.Session["fromEmail"] = base.Request.Url.ToString();
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            if (!string.IsNullOrEmpty(this.Session["StoreUserID"].ToString()))
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                this.ApproverID = this.StoreUserID;
            }
            this.UserType = LoginBasePage.UserTypeCheck(this.StoreUserID);
            this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
            if (base.Request.Params["OrderID"] != null)
            {
                this.Orderid = Convert.ToInt32(base.Request.Params["OrderID"]);
            }
            if (base.Request.Params["UserID"] != null)
            {
                this.ReferenceUserID = (long)Convert.ToInt32(base.Request.Params["UserID"]);
                this.UserGettingApproved = this.ReferenceUserID;
            }
            if (this.ReferenceUserID != (long)0)
            {
                this.StoreUserID = this.ReferenceUserID;
            }
            if (this.Orderid != 0)
            {
                this.OrdID = this.Orderid.ToString();
            }
            else if (this.OrderKey.Contains("-JOB") || this.OrderKey.Contains("-INV"))
            {
                this.OrdID = this.OrderKey;
                if (!this.OrderKey.ToString().ToLower().Contains("job"))
                {
                    this.PageFrom = "invoice";
                }
                else
                {
                    this.PageFrom = "job";
                }
            }
            else
            {
                foreach (DataRow row1 in OrderBasePage.Select_OrderID(this.OrderKey).Rows)
                {
                    this.OrdID = row1["OrderID"].ToString();
                }
            }
            var checkprocessed = 0;
            this.NewSessionID = this.comm.UniqueID;
            if (this.StoreUserID != (long)0)
            {
                int num = 0;
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = 0;
                decimal num5 = new decimal(0);
                string empty1 = string.Empty;
                long num6 = (long)0;
                DataTable dataTable4 = new DataTable();
                if (!string.IsNullOrEmpty(this.OrdID) && this.OrdID.ToString().Trim() != "0")
                {
                    dataTable4 = OrderBasePage.Select_OrderItems(this.OrdID, this.StoreUserID);
                }
                decimal num7 = new decimal(0);
                foreach (DataRow dataRow1 in dataTable4.Rows)
                {
                    if (this.ISCouponCodeApplied)
                    {
                        continue;
                    }
                    this.ISCouponCodeApplied = Convert.ToBoolean(dataRow1["ISCouponCodeApplied"]);
                }
                foreach (DataRow row2 in dataTable4.Rows)
                {
                    if (row2["ApproveStatus"].ToString() == "0")
                    {
                        checkprocessed = 1;
                    }

                    this.Session["BillingAddressID"] = Convert.ToInt64(row2["BillingAddressID"]);
                    this.Session["ShippingAddressID"] = Convert.ToInt64(row2["ShippingAddressID"]);
                    if (!base.IsPostBack)
                    {
                        this.txtComments.Text = Convert.ToString(row2["ApproverComments"]);
                    }

                    Convert.ToInt32(row2["ItemsCount"].ToString());
                    if (Convert.ToBoolean(row2["IsCumulativePricing"]))
                    {
                        this.IsCumulative = true;
                    }
                    if (Convert.ToInt64(row2["MainProductID"]) == (long)0)
                    {
                        this.MainProductId = (long)0;
                    }
                    else
                    {
                        this.MainProductId = Convert.ToInt64(row2["MainProductID"]);
                    }
                    Convert.ToInt64(row2["TaxID"]);
                    if (row2["IsBackOrder"].ToString() == "1")
                    {
                        this.IsBackOrder = true;
                    }
                    this.OrderID = Convert.ToInt64(row2["OrderID"]);
                    this.ToEmail = row2["EmailID"].ToString();
                    empty = (row2["PDFNameFromCart"].ToString() != "" || row2["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(row2["IsPrintReadyFile"]) ? "Style='display:block;float:left;'" : "Style='display:none;float:left;'");
                    num4 = Convert.ToInt32(row2["createdBy"].ToString());
                    Convert.ToDecimal(row2["Tax"]);
                    if (Convert.ToInt64(row2["OrderBehalfDeptID"]) > (long)0)
                    {
                        string str6 = base.Return_ApprovalRegistration_Settings("deptscreenname");
                        if (str6 != "")
                        {
                            this.lbl_name.Text = base.SpecialDecode(string.Concat(row2["Order_Behalf_DeptID"].ToString(), " [", str6, "] "));
                        }
                        else
                        {
                            this.lbl_name.Text = base.SpecialDecode(string.Concat(row2["Order_Behalf_DeptID"].ToString(), " [Department] "));
                        }
                        this.lbl_email.Text = base.SpecialDecode(row2["OrderBehalfUserIDEmail"].ToString());
                        this.lblatnfor.Text = string.Concat(" ", row2["Order_Behalf_UserID"].ToString());
                        this.spnattn.Style.Add("display", "block");
                        this.lblemail.Style.Add("display", "none");
                        this.lbl_email.Style.Add("display", "none");
                        this.spnattn.Style.Add("white-space", "nowrap");
                    }
                    else if (Convert.ToInt64(row2["OrderBehalfUserID"]) <= (long)0)
                    {
                        this.lbl_name.Text = base.SpecialDecode(string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString()));
                    }
                    else
                    {
                        this.lbl_name.Text = base.SpecialDecode(row2["Order_Behalf_UserID"].ToString());
                        this.lbl_email.Text = base.SpecialDecode(row2["OrderBehalfUserIDEmail"].ToString());
                    }
                    this.lbl_name.Style.Add("white-space", "nowrap");
                    this.lbl_Orderedby.Text = base.SpecialDecode(string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString()));
                    this.lbl_Orderedbyemail.Text = base.SpecialDecode(row2["EmailID"].ToString());
                    this.lbl_OrderNo.Text = row2["OrderNo"].ToString();
                    this.btn_Reject.CommandArgument = row2["OrderNo"].ToString();
                    this.btn_Approve.CommandArgument = row2["OrderNo"].ToString();
                    if(!string.IsNullOrEmpty(row2["createdBy1"].ToString()))
                    {
                        this.User_ID = int.Parse(row2["createdBy1"].ToString());
                    }
                    else
                    {
                        this.User_ID = 0;
                    }
                    if (this.Session["ApprovalSystem"] != null)
                    {
                        if (this.Session["ApprovalSystem"].ToString() != "on")
                        {
                            this.divButtons.Visible = false;
                        }
                        else
                        {
                            int orderItems = OrderBasePage.GetOrderItems(this.OrderID);
                            this.RequirePassword = this.objBaseClass.Return_ApprovalSystem_Settings("requirepwd");
                            if (this.approvalType != "s")
                            {
                                if (this.RequirePassword == "True")
                                {
                                    this.DivApproverPassword.Visible = true;
                                }
                                if (this.UserType == "u")
                                {
                                    this.divButtons.Visible = false;
                                    this.DivApproverPassword.Visible = false;
                                }
                                else if (base.Request.Params["OrdKey"] == null)
                                {
                                    if (this.approvalType == "u")
                                    {
                                        this.divButtons.Visible = false;
                                        this.DivApproverPassword.Visible = false;
                                    }
                                    else if (orderItems <= 0)
                                    {
                                        this.divButtons.Visible = false;
                                        this.DivApproverPassword.Visible = false;
                                    }
                                    else
                                    {
                                        this.divButtons.Visible = true;
                                    }
                                }
                                else if (this.approvalType == "u")
                                {
                                    this.divButtons.Visible = false;
                                    this.DivApproverPassword.Visible = false;
                                }
                                else if (orderItems <= 0)
                                {
                                    this.divButtons.Visible = false;
                                    this.DivApproverPassword.Visible = false;
                                }
                                else
                                {
                                    if (this.UserType == "d" && Convert.ToInt64(this.Session["StoreUserID"]) == Convert.ToInt64(row2["StoreUserID"]))
                                    {
                                        this.divButtons.Visible = false;
                                        this.DivApproverPassword.Visible = false;
                                    }
                                    if (this.UserType == "m")
                                    {
                                        this.divButtons.Visible = true;
                                    }
                                }
                            }
                            else if (orderItems <= 0)
                            {
                                this.divButtons.Visible = false;
                                this.DivApproverPassword.Visible = false;
                            }
                            else
                            {
                                this.divButtons.Visible = true;
                            }
                        }
                    }
                    this.Orderid = Convert.ToInt32(row2["orderitemID"]);
                    if (row2["PaymentType"].ToString() != this.objLanguage.GetLanguageConversion("Braintree_Credit_Card"))
                    {
                        this.lbl_Payment.Text = row2["PaymentType"].ToString();
                    }
                    else
                    {
                        this.lbl_Payment.Text = this.objLanguage.GetLanguageConversion("Credit_Card");
                    }
                    this.lbl_OrderDate.Text = this.comm.Eprint_return_Date_Before_View(row2["OrderDate"].ToString(), this.CompanyID, num4, false);
                    this.lblDeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(row2["RequiredBy"].ToString(), this.CompanyID, num4, false);
                    this.lblCostcenter.Text = base.SpecialDecode(row2["CostCentreName"].ToString());
                    if (this.ISCouponCodeApplied)
                    {
                        this.td_CouponCodeDiscount.Style.Add("display", "block");
                        this.Div_CouponCode.Style.Add("display", "block");
                        this.Divlbl_CouponCode.Style.Add("display", "block");
                        Label label1 = this.lblCouponCode;
                        sitePath = new string[] { base.SpecialDecode(row2["UserFriendlyName"].ToString()), "(", base.SpecialDecode(row2["CouponCode"].ToString()), ") - ", base.SpecialDecode(row2["CouponCodeDiscount"].ToString()) };
                        label1.Text = string.Concat(sitePath);
                    }
                    if (this.IsEnableHidePrice == "true")
                    {
                        this.td_CouponCodeDiscount.Style.Add("display", "none");
                        this.Div_CouponCode.Style.Add("display", "none");
                        this.Divlbl_CouponCode.Style.Add("display", "none");
                    }
                    if (!base.IsPostBack)
                    {
                        this.lbl_OrderTitle.Value = base.SpecialDecode(row2["OrderTitle"].ToString());
                        this.lbl_UserRefOrderNo.Value = base.SpecialDecode(row2["UserRefOrderNo"].ToString());
                    }
                    DataTable dataTable5 = OrderBasePage.Order_Status(Convert.ToInt64(row2["OrderID"]), Convert.ToInt64(row2["EstimateID"].ToString()));
                    if (dataTable5.Rows.Count > 0)
                    {
                        this.StatusName = base.SpecialDecode(dataTable5.Rows[0]["UserFriendlyName"].ToString());
                    }
                    this.tdlblStatus.Attributes.Add("style", "display:none;");
                    this.tdStatus.Attributes.Add("style", "display:none;");
                    if (this.Session["ApprovalSystem"] == null)
                    {
                        foreach (DataRow dataRow2 in dataTable5.Rows)
                        {
                            this.lbl_Status.Text = base.SpecialDecode(dataRow2["UserFriendlyName"].ToString());
                            this.StatusName = this.lbl_Status.Text;
                        }
                    }
                    else if (this.Session["ApprovalSystem"].ToString() != "on")
                    {
                        foreach (DataRow row3 in dataTable5.Rows)
                        {
                            this.lbl_Status.Text = base.SpecialDecode(row3["UserFriendlyName"].ToString());
                            this.StatusName = this.lbl_Status.Text;
                        }
                    }
                    else if (row2["ApproveStatus"].ToString() == "0")
                    {
                        if (row2["ScheduleType"].ToString() != "Change Status")
                        {
                            this.lbl_Status.Text = this.objLanguage.GetLanguageConversion("Awaiting_Approval");
                            this.lbl_Status.Font.Italic = true;
                            this.lbl_Status.ForeColor = Color.Gray;
                        }
                        else
                        {
                            foreach (DataRow dataRow3 in dataTable5.Rows)
                            {
                                this.lbl_Status.Text = base.SpecialDecode(dataRow3["UserFriendlyName"].ToString());
                                this.StatusName = this.lbl_Status.Text;
                            }
                        }
                    }
                    else if (row2["ApproveStatus"].ToString() != "2")
                    {
                        foreach (DataRow row4 in dataTable5.Rows)
                        {
                            this.lbl_Status.Text = base.SpecialDecode(row4["UserFriendlyName"].ToString());
                            this.StatusName = this.lbl_Status.Text;
                        }
                    }
                    else
                    {
                        this.lbl_Status.Text = this.objLanguage.GetLanguageConversion("Rejected");
                        this.lbl_Status.ForeColor = Color.Red;
                        DataTable dataTable6 = OrderBasePage.Select_OrderItems(this.OrdID, this.StoreUserID);
                        if (dataTable6.Rows.Count > 0)
                        {
                            foreach (DataRow dataRow4 in dataTable6.Rows)
                            {
                                this.RejectImage.Visible = true;
                                this.RejectImage.ToolTip = row2["RejectReason"].ToString();
                            }
                        }
                    }
                    empty1 = row2["ConsignmentNumber"].ToString();
                    if (empty1 == "")
                    {
                        this.lbl_ConsignmentNoteNumber.Text = "Pending";
                        this.consignementnum = "Pending";
                    }
                    else
                    {
                        this.lbl_ConsignmentNoteNumber.Text = base.SpecialDecode(empty1.ToString());
                        this.consignementnum = base.SpecialDecode(empty1.ToString());
                    }
                    this.consigneeurl = base.SpecialDecode(row2["consigneeurl"].ToString());
                    this.Return_address(this.StoreUserID, "", num6, Convert.ToInt64(row2["BillingAddressID"]), out this.Address);
                    this.lbl_BliingAddress.Text = base.SpecialDecode(this.Address);
                    this.Return_address(this.StoreUserID, "", num6, Convert.ToInt64(row2["ShippingAddressID"]), out this.Address);
                    this.lbl_ShippingAddress.Text = base.SpecialDecode(this.Address);
                    if (this.lbl_BliingAddress.Text == "")
                    {
                        this.order_billingAddress.Attributes.Add("style", "display:none");
                    }
                    if (this.lbl_ShippingAddress.Text == "")
                    {
                        this.divShippingAddress.Attributes.Add("style", "display:none");
                    }
                    if (this.comm.GetDisplayValue("isCheckInvoiceInfo", order.AccountID) != "true")
                    {
                        this.order_billingAddress.Style.Add("display", "none");
                    }
                    else
                    {
                        this.order_billingAddress.Style.Add("display", "block");
                        if (this.lbl_BliingAddress.Text == "")
                        {
                            this.order_billingAddress.Style.Add("display", "none");
                        }
                    }
                    if (this.comm.GetDisplayValue("isCheckDeliveryInfo", order.AccountID) != "true")
                    {
                        this.divDeliveryAddress.Style.Add("display", "none");
                    }
                    else
                    {
                        this.divDeliveryAddress.Style.Add("display", "block");
                        if (this.lbl_ShippingAddress.Text == "")
                        {
                            this.divDeliveryAddress.Style.Add("display", "none");
                        }
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<tr class='b_productName_tr'>"));
                    string empty2 = string.Empty;
                    this.plhorder.Controls.Add(new LiteralControl("<td id='td_checkbx' class='shoppingcart_BorderBottom' >"));
                    if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
                    {
                        if (this.approvalType.ToLower() == "s")
                        {
                            this.HeaderCheckbox.Attributes.CssStyle.Add("display", "block");
                            this.plhorder.Controls.Add(new LiteralControl("<div class='ItemCheckbox'>"));
                            HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox()
                            {
                                ID = string.Concat("chkEachLine", row2["OrderItemID"].ToString()),
                                Checked = true
                            };
                            if (row2["ApproveStatus"].ToString() != "0")
                            {
                                htmlInputCheckBox.Checked = false;
                                htmlInputCheckBox.Disabled = true;
                            }
                            htmlInputCheckBox.Value = row2["OrderItemID"].ToString();
                            htmlInputCheckBox.Attributes.Add("onclick", string.Concat("javascript:CheckChanged('", htmlInputCheckBox.ID, "');"));
                            this.plhorder.Controls.Add(htmlInputCheckBox);
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (this.UserType != "u")
                        {
                            if (base.Request.Params["OrdKey"] == null)
                            {
                                if (this.approvalType != "u")
                                {
                                    this.HeaderCheckbox.Attributes.CssStyle.Add("display", "block");
                                    this.plhorder.Controls.Add(new LiteralControl("<div class='ItemCheckbox'>"));
                                    HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox()
                                    {
                                        ID = string.Concat("chkEachLine", row2["OrderItemID"].ToString()),
                                        Checked = true
                                    };
                                    if (row2["ApproveStatus"].ToString() != "0")
                                    {
                                        htmlInputCheckBox1.Checked = false;
                                        htmlInputCheckBox1.Disabled = true;
                                    }
                                    htmlInputCheckBox1.Value = row2["OrderItemID"].ToString();
                                    htmlInputCheckBox1.Attributes.Add("onclick", string.Concat("javascript:CheckChanged('", htmlInputCheckBox1.ID, "');"));
                                    this.plhorder.Controls.Add(htmlInputCheckBox1);
                                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                }
                                else if (!base.IsPostBack)
                                {
                                    HiddenField hiddenField = this.hdnOrderItemID;
                                    hiddenField.Value = string.Concat(hiddenField.Value, row2["OrderItemID"].ToString(), ',');
                                }
                            }
                            else if (this.approvalType != "u")
                            {
                                if (this.UserType != "d" && Convert.ToInt64(this.Session["StoreUserID"]) != Convert.ToInt64(row2["StoreUserID"]))
                                {
                                    this.HeaderCheckbox.Attributes.CssStyle.Add("display", "block");
                                    this.plhorder.Controls.Add(new LiteralControl("<div class='ItemCheckbox'>"));
                                    HtmlInputCheckBox htmlInputCheckBox2 = new HtmlInputCheckBox()
                                    {
                                        ID = string.Concat("chkEachLine", row2["OrderItemID"].ToString()),
                                        Checked = true
                                    };
                                    if (row2["ApproveStatus"].ToString() != "0")
                                    {
                                        htmlInputCheckBox2.Checked = false;
                                        htmlInputCheckBox2.Disabled = true;
                                    }
                                    htmlInputCheckBox2.Value = row2["OrderItemID"].ToString();
                                    htmlInputCheckBox2.Attributes.Add("onclick", string.Concat("javascript:CheckChanged('", htmlInputCheckBox2.ID, "');"));
                                    this.plhorder.Controls.Add(htmlInputCheckBox2);
                                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            else if (!base.IsPostBack)
                            {
                                HiddenField hiddenField1 = this.hdnOrderItemID;
                                hiddenField1.Value = string.Concat(hiddenField1.Value, row2["OrderItemID"].ToString(), ',');
                            }
                        }
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<div>"));
                    string empty3 = string.Empty;
                    if (row2["PDFNameFromCart"].ToString() != "")
                    {
                        if (row2["PreviewType"].ToString() == "" || row2["PreviewType"].ToString() == "pdfimg" || row2["PreviewType"].ToString() == "pdf")
                        {
                            empty3 = "pdf";
                            ControlCollection controls = this.plhorder.Controls;
                            accountID = new object[] { "<img  id='img_Pdf_", num, "' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_Open(\"", row2["PDFNameFromCart"].ToString(), "\",", order.AccountID, ",\"", empty3, "\");' ", empty, "/>" };
                            controls.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    else if (row2["PrintReadyFile"].ToString() != "")
                    {
                        empty3 = "printready";
                        ControlCollection controlCollections = this.plhorder.Controls;
                        accountID = new object[] { "<img  id='img_Pdf_", num, "' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' onclick='javascript:Pdf_Open(\"", row2["PrintReadyFile"].ToString(), "\",", this.CompanyID, ",\"", empty3, "\");' ", empty, "/>" };
                        controlCollections.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    if (row2["ImageNameFromCart"].ToString() != "" && (row2["PreviewType"].ToString() == "pdfimg" || row2["PreviewType"].ToString() == "img"))
                    {
                        empty3 = "previewimage";
                        ControlCollection controls1 = this.plhorder.Controls;
                        accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", row2["ImageNameFromCart"].ToString(), "\",", order.AccountID, ",\"", this.strSitepath, "\",\"", empty3, "\");' ", empty, "/></div>" };
                        controls1.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    string empty4 = string.Empty;
                    if (row2["OrderKey"] != null)
                    {
                        if (this.MainProductId == (long)0)
                        {
                            accountID = new object[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", row2["ProductID"].ToString(), "&CartItemID=", row2["CartItemID"].ToString(), "&OrdKey=", row2["OrderKey"].ToString(), "&type=ed&OrderItemId=", row2["OrderItemID"], "&Store_UserID=", row2["StoreUserID"].ToString(), "&OrderMode=edit", "&OrderId=", row2["OrderId"].ToString() };
                            empty4 = string.Concat(accountID);
                        }
                        else
                        {
                            accountID = new object[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", this.MainProductId, "&SubID=", row2["ProductID"].ToString(), "&CartItemID=", row2["CartItemID"].ToString(), "&OrdKey=", row2["OrderKey"].ToString(), "&type=ed&OrderItemId=", row2["OrderItemID"], "&Store_UserID=", row2["StoreUserID"].ToString(), "&OrderMode=edit", "&OrderId=", row2["OrderId"].ToString() };
                            empty4 = string.Concat(accountID);
                        }
                        if (row2["ApproveStatus"].ToString() == "0")
                        {
                            ControlCollection controlCollections1 = this.plhorder.Controls;
                            accountID = new object[] { "<a href=", empty4, "><img id='img_Edit_", num, "' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit' alt=' '/></a>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    if (row2["UploadFile"].ToString() != "")
                    {
                        ControlCollection controls2 = this.plhorder.Controls;
                        accountID = new object[] { "<a ><img id='img_attachment_", num, "' onclick=Javascript:openArtworkPopup(", row2["CartItemID"].ToString(), ",", row2["OrderItemID"].ToString(), ",'", this.OrdID, "','", this.PageFrom, "') class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                        controls2.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_OrderReference_td' style='padding-top: 3px;text-align:center;padding-left:4px;' class='Td15'>"));
                    Label label2 = new Label()
                    {
                        ID = string.Concat("OrderReference_", num)
                    };
                    this.ModuleItemnumber = row2["OrderNo"].ToString();
                    if (this.ModuleItemnumber.Contains("INV"))
                    {
                        label2.Text = row2["Invoice_Item_Number"].ToString();
                    }
                    else if (!this.ModuleItemnumber.Contains("JOB"))
                    {
                        label2.Text = row2["Order_Item_Number"].ToString();
                    }
                    else
                    {
                        label2.Text = row2["Job_Item_Number"].ToString();
                    }
                    this.plhorder.Controls.Add(label2);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productName_td' style='padding-left:7px;'>"));
                    Label label3 = new Label()
                    {
                        ID = string.Concat("lblproductName_", num),
                        Text = base.SpecialDecode(row2["CatalogueName"].ToString())
                    };
                    if (row2["MatrixType"].ToString().ToLower() == "g")
                    {
                        string str7 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderedWidth"].ToString()), 2, "", false, false, true);
                        string str8 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderedHeight"].ToString()), 2, "", false, false, true);
                        sitePath = new string[] { label3.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str7, " </label><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str8, " </label></span>" };
                        label3.Text = string.Concat(sitePath);
                    }
                    this.plhorder.Controls.Add(label3);
                    int num8 = 0;
                    foreach (DataRow row5 in OrderBasePage.Select_OrderAdditionalItems((long)this.Orderid).Rows)
                    {
                        if (Convert.ToInt32(row5["CheckCount"]) <= 0)
                        {
                            break;
                        }
                        if (Convert.ToInt32(row5["OptionID"]) <= 0)
                        {
                            continue;
                        }
                        if (num8 == 0)
                        {
                            this.plhorder.Controls.Add(new LiteralControl(string.Concat("<br/><div class='marginTop5px'><Strong><label><i>", this.objLanguage.GetLanguageConversion("Additional_Items"), "</i></label></Strong></div>")));
                        }
                        this.plhorder.Controls.Add(new LiteralControl("<div>"));
                        Label label4 = new Label();
                        accountID = new object[] { "lblAdditionalName_", num, "_", num8 };
                        label4.ID = string.Concat(accountID);
                        label4.Text = base.SpecialDecode(row5["UserFriendlyName"].ToString().Trim());
                        label4.Style.Add("font-size", "12px");
                        label4.Style.Add("font-weight", "bold");
                        label4.Style.Add("color", "#696969");
                        this.plhorder.Controls.Add(label4);
                        this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        if (row5["MainCalculationType"].ToString().ToLower() == "c")
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                            Label label5 = new Label();
                            accountID = new object[] { "lblSelectedValue_", num, "_", num8 };
                            label5.ID = string.Concat(accountID);
                            label5.Text = row5["SelectedValue"].ToString().Trim();
                            label5.Attributes.Add("style", "padding-left:6px; font-size:11px;");
                            this.plhorder.Controls.Add(label5);
                            this.plhorder.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        num8++;
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productDescription_td' style='padding-top: 3px;padding-left:4px;' class='Td15'>"));
                    Label label6 = new Label()
                    {
                        ID = string.Concat("lblproductDescription_", num),
                        Text = base.SpecialDecode(row2["Description"].ToString())
                    };
                    this.plhorder.Controls.Add(label6);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='text-align:center;padding:3px 10px 0px 10px;padding-left:4px;'>"));
                    Label label7 = new Label()
                    {
                        ID = string.Concat("lbldeliverydate_", num),
                        Text = this.comm.Eprint_return_Date_Before_View(row2["ActualDeliveryDate"].ToString(), this.CompanyID, num4, false)
                    };
                    if (label7.Text == "")
                    {
                        label7.Text = "N/A";
                    }
                    this.plhorder.Controls.Add(label7);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td style='padding-top:3px;text-align:right;padding-left:4px;word-break:normal'>"));
                    Label label8 = new Label()
                    {
                        ID = string.Concat("lblproductQty_", num)
                    };
                    if (row2["Quantity"].ToString() != "")
                    {
                        label8.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["Quantity"].ToString()), 0, "", true, false, true);
                    }
                    this.plhorder.Controls.Add(label8);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(order.AccountID);
                    if (this.IsCampaignEnabled.ToLower() == "true")
                    {
                        this.Campaign_Td.Visible = true;
                        this.CampaignSignNumber.Visible = true;
                        this.plhorder.Controls.Add(new LiteralControl("<td style='padding-top:3px;text-align:center;padding-left:4px;'; >"));
                        Label label9 = new Label()
                        {
                            ID = string.Concat("lblCampaignSignNumber_", num),
                            Text = row2["CampaignSignNumber"].ToString()
                        };
                        this.plhorder.Controls.Add(label9);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        this.plhorder.Controls.Add(new LiteralControl("<td style='padding:3px 0px 0px 10px;padding-left:4px;'>"));
                        Label label10 = new Label()
                        {
                            ID = string.Concat("lblcampaignName_", num),
                            Text = base.SpecialDecode(row2["EventName"].ToString())
                        };
                        this.plhorder.Controls.Add(label10);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    DataTable dataTable7 = CartBasePage.default_settings(Convert.ToInt32(this.CompanyID), Convert.ToInt32(order.AccountID));
                    if (dataTable7.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow5 in dataTable7.Rows)
                        {
                            this.CartJobScreenNameShow = Convert.ToBoolean(dataRow5["CartJobNameShow"]);
                            this.CartJobScreenName = Convert.ToString(dataRow5["CartJobScreenName"]);
                        }
                    }
                    if (this.IsCampaignEnabled == "False")
                    {
                        this.productdesc.Style.Add("width", "25%");
                        this.ItemMaterial.Style.Add("width", "14%");
                        if (this.CartJobScreenNameShow)
                        {
                            this.JobName.Style.Add("width", "11%");
                        }
                        else
                        {
                            this.JobName.Style.Add("display", "none");
                        }
                    }
                    else if (this.CartJobScreenNameShow)
                    {
                        this.JobName.Style.Add("width", "11%");
                    }
                    else
                    {
                        this.JobName.Style.Add("display", "none");
                    }
                    this.lblJobname.Text = this.CartJobScreenName;
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_OrderStatus_td' style='padding-top:3px;text-align: left;word-wrap:break-word;padding-left:4px;'>"));
                    Label gray = new Label()
                    {
                        ID = string.Concat("lblStatus", num),
                        Text = base.SpecialDecode(row2["ItemStatusTitle"].ToString())
                    };
                    gray.Font.Italic = true;
                    gray.ForeColor = Color.Gray;
                    this.plhorder.Controls.Add(gray);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    if (this.Session["ApprovalSystem"].ToString() == "on")
                    {
                        this.tdApprovedStaus.Visible = true;
                        this.plhorder.Controls.Add(new LiteralControl("<td style='padding-top:3px;text-align: left;padding-left:4px;'>"));
                        Label languageConversion = new Label()
                        {
                            ID = string.Concat("lblApproved_", num)
                        };
                        if (row2["ApproveStatus"].ToString() == "0")
                        {
                            languageConversion.Text = this.objLanguage.GetLanguageConversion("Awaiting_Approval");
                        }
                        else if (row2["ApproveStatus"].ToString() != "1")
                        {
                            languageConversion.Text = this.objLanguage.GetLanguageConversion("Rejected");
                        }
                        else
                        {
                            languageConversion.Text = "Approved";
                        }
                        this.plhorder.Controls.Add(languageConversion);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='text-align:left;padding-left: 4px;'>"));
                    Label label11 = new Label()
                    {
                        ID = string.Concat("lblItemMaterial", num),
                        Text = base.SpecialDecode(row2["ItemMaterial"].ToString())
                    };
                    this.plhorder.Controls.Add(label11);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    if (this.CartJobScreenNameShow)
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productJobName_td width4p' style='padding-left: 4px;'>"));
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productJobName_td width4p' style='padding-left: 4px; display:none'>"));
                    }
                    Label label12 = new Label()
                    {
                        ID = string.Concat("lblProductJobName_", num),
                        Text = row2["JobName1"].ToString()
                    };
                    this.plhorder.Controls.Add(label12);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    decimal num9 = new decimal(0);
                    if (row2["Quantity"].ToString() != "")
                    {
                        if (Convert.ToDecimal(row2["Quantity"].ToString()) != new decimal(0))
                        {
                            num9 = (!this.IsCumulative || Convert.ToInt32(row2["PID"].ToString()) == 0 ? Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()) / Convert.ToDecimal(row2["Quantity"].ToString()) : Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()) / Convert.ToDecimal(this.SimpleMatrixCumulativePriceingQty(Convert.ToInt32(row2["Quantity"].ToString()), Convert.ToInt32(row2["PID"].ToString()))));
                        }
                        else
                        {
                            num9 = Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString());
                        }
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd DisplayNone' style='padding:3px 0px 0px 10px;padding-left:4px;'>"));
                        Label label13 = new Label()
                        {
                            ID = string.Concat("lblproductPrice_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num9, 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label13);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        this.tdUnitprice.Style.Add("display", "none");
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='padding:3px 0px 0px 10px;padding-left:4px;'>"));
                        Label label14 = new Label()
                        {
                            ID = string.Concat("lblproductPrice_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num9, 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label14);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.IsZip2taxEnabled = CartBasePage.Select_IsZip2taxEnabled(Convert.ToInt32(this.CompanyID), Convert.ToInt32(order.AccountID));
                    if (this.IsEnableHidePrice != "false")
                    {
                        if (this.IsZip2taxEnabled != true)
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTaxAppplicableTd DisplayNone'>"));
                            Label label15 = new Label()
                            {
                                ID = string.Concat("lblTaxApplicable_", num),
                                Text = string.Concat(row2["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                            };
                            this.plhorder.Controls.Add(label15);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            this.tdTaxApplicable.Style.Add("display", "none");
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTaxAppplicableTd DisplayNone'>"));
                            Label label15 = new Label()
                            {
                                ID = string.Concat("lblTaxApplicable_", num),
                                Text = string.Concat(" Sales Tax", " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                            };
                            this.plhorder.Controls.Add(label15);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            this.tdTaxApplicable.Style.Add("display", "none");
                        }
                    }
                    else
                    {
                        if (this.IsZip2taxEnabled != true)
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTaxAppplicableTd'>"));
                            Label label16 = new Label()
                            {
                                ID = string.Concat("lblTaxApplicable_", num),
                                Text = string.Concat(row2["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                            };
                            this.plhorder.Controls.Add(label16);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTaxAppplicableTd'>"));
                            Label label16 = new Label()
                            {
                                ID = string.Concat("lblTaxApplicable_", num),
                                Text = string.Concat(" Sales Tax", " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                            };
                            this.plhorder.Controls.Add(label16);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    if (this.ISCouponCodeApplied)
                    {
                        if (this.IsEnableHidePrice != "false")
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='padding:3px 0px 0px 10px;text-align:right;display:none;padding-left:4px;'>"));
                            Label label17 = new Label()
                            {
                                ID = string.Concat("lblDiscount_", row2["CartItemID"].ToString()),
                                Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                            };
                            this.plhorder.Controls.Add(label17);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='padding:3px 0px 0px 10px;text-align:right;padding-left:4px;'>"));
                            Label label18 = new Label()
                            {
                                ID = string.Concat("lblDiscount_", row2["CartItemID"].ToString()),
                                Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                            };
                            this.plhorder.Controls.Add(label18);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        if (this.CartJobScreenNameShow)
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3 DisplayNone' style='padding-left:4px;'>"));
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3 DisplayNone' style='padding-left:4px;'>"));
                        }
                        Label label19 = new Label()
                        {
                            ID = string.Concat("lblproductTotal_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()), 2, "", false, false, true)
                        };
                        if (Convert.ToInt32(row2["ApproveStatus"]) != 2)
                        {
                            num1 = num1 + Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString());
                            num3 = num3 + Convert.ToDecimal(row2["OrderItemTax"].ToString());
                        }
                        this.plhorder.Controls.Add(label19);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        this.tdTotal.Style.Add("display", "none");
                    }
                    else
                    {
                        if (this.CartJobScreenNameShow)
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3' style='padding-left:4px;'"));
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3' style='width:16%;'"));
                        }
                        Label label20 = new Label()
                        {
                            ID = string.Concat("lblproductTotal_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()), 2, "", false, false, true)
                        };
                        if (Convert.ToInt32(row2["ApproveStatus"]) != 2)
                        {
                            num1 = num1 + Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString());
                            num3 = num3 + Convert.ToDecimal(row2["OrderItemTax"].ToString());
                        }
                        this.plhorder.Controls.Add(label20);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsEnableHidePrice != "true")
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productTotal_td1 width4p' style='padding-left:4px;'><div class='DisplayNone'>"));
                        Label label21 = new Label()
                        {
                            ID = string.Concat("lblproductTax_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTax"].ToString()), 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label21);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productTotal_td1 width4p DisplayNone' style='padding-left:4px;'><div class='DisplayNone'>"));
                        Label label22 = new Label()
                        {
                            ID = string.Concat("lblproductTax_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTax"].ToString()), 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label22);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (str.ToLower() != "y" && str1.ToLower() != "y" && str2.ToLower() != "y" && str3.ToLower() != "y" && str4.ToLower() != "y" && str5.ToLower() != "y")
                    {
                        this.tdBeDept.Visible = false;
                        this.tdBeUser.Visible = false;
                    }
                    else if (base.Request.Params["OrdKey"] != null)
                    {
                        if (base.Request.Params["OrdKey"].ToString().Contains("-JOB") || base.Request.Params["OrdKey"].ToString().Contains("-INV"))
                        {
                            this.tdBeDept.Visible = false;
                            this.tdBeUser.Visible = false;
                        }
                        else
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<td class='paddingTop3' style='display:none'>"));
                            Label label23 = new Label()
                            {
                                ID = string.Concat("lblBehalfUser_", num),
                                Text = row2["Order_Behalf_UserID"].ToString()
                            };
                            this.plhorder.Controls.Add(label23);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                            this.plhorder.Controls.Add(new LiteralControl("<td class='paddingTop3' style='display:none'>"));
                            Label label24 = new Label()
                            {
                                ID = string.Concat("lblBehalfDept_", num),
                                Text = row2["Order_Behalf_DeptID"].ToString()
                            };
                            this.plhorder.Controls.Add(label24);
                            this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</tr><div class='clearBoth'></div>"));
                    num++;
                    num7 = Convert.ToDecimal(row2["Taxprice"].ToString());
                }
                int num10 = 0;
                decimal num11 = new decimal(0);
                foreach (DataRow row6 in OrderBasePage.Select_OrderAdditionalOptions(this.StoreUserID, this.OrderID.ToString()).Rows)
                {
                    if (!this.OrderKey.ToString().ToLower().Contains("job") && !this.OrderKey.ToString().ToLower().Contains("inv") && this.OrderID != (long)0)
                    {
                        if (this.IsEnableHidePrice != "false")
                        {
                            this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                            ControlCollection controlCollections2 = this.plhOrdAddOptions.Controls;
                            accountID = new object[] { "<label class='Visibilityhidden' id='lblOrderAddValue_", num10, "'> ", row6["SelectedValue"].ToString(), "</label><br/>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(accountID)));
                            this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                            ControlCollection controls3 = this.plhOrdAddOptionsPrice.Controls;
                            accountID = new object[] { "<label class='Visibilityhidden' id='lblOrderAddPrice_", num10, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                            controls3.Add(new LiteralControl(string.Concat(accountID)));
                            this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                        }
                        else
                        {
                            this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                            ControlCollection controlCollections3 = this.plhOrdAddOptions.Controls;
                            accountID = new object[] { "<label id='lblOrderAddValue_", num10, "'> ", row6["SelectedValue"].ToString(), "</label><br/>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(accountID)));
                            this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                            this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                            ControlCollection controls4 = this.plhOrdAddOptionsPrice.Controls;
                            accountID = new object[] { "<label id='lblOrderAddPrice_", num10, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row6["TotalPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                            controls4.Add(new LiteralControl(string.Concat(accountID)));
                            this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    num11 = num11 + Convert.ToDecimal(row6["TotalPrice"].ToString());
                    num2 = num2 + Convert.ToDecimal(row6["OrderAdditionalTaxValue"]);
                    num10++;
                }
                this.lbl_subTotal_cost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num1, 2, "", false, false, true);
                num5 = (this.OrderKey.ToString().ToLower().Contains("job") || this.OrderKey.ToString().ToLower().Contains("inv") ? num7 + num2 : num3 + num2);
                this.lbl_tax.Text = this.objLanguage.GetLanguageConversion("Total_Tax");
                this.lbl_TaxValue.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num5, 2, "", false, false, true);
                this.lbl_grandTotal_cost.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num5) + num11, 2, "", false, false, true));
                this.Session["fromEmail"] = "";
            }
            if (this.comm.GetDisplayValue("isCheckPaymentInfo", order.AccountID) == "false" && this.lbl_Payment.Text.Trim().Length == 0)
            {
                this.PaymentMode_Style = "display: none;";
                this.div_paymentmode.Style.Add("display", "none");
            }
            string str9 = (new BaseClass()).Return_ApprovalOrderingProcess_Settings("showcostcenters");
            if (str9.Trim().ToLower() == "false" || str9.Trim().ToLower() == "")
            {
                this.TrCost.Style.Add("display", "none");
            }
            if (this.PageFrom == "job" || this.PageFrom == "invoice")
            {
                this.divButtons.Visible = false;
                this.DivApproverPassword.Visible = false;
            }
            if (this.IsEnableHidePrice == "true")
            {
                this.lbl_subTotal.Style.Add("display", "none");
                this.lbl_tax.Style.Add("display", "none");
                this.lbl_grandTotal.Style.Add("display", "none");
                this.lbl_subTotal_cost.Style.Add("display", "none");
                this.lbl_TaxValue.Style.Add("display", "none");
                this.lbl_grandTotal_cost.Style.Add("display", "none");
                this.div3.Style.Add("display", "none");
                this.div4.Style.Add("display", "none");
                this.div5.Style.Add("display", "none");
                this.div6.Style.Add("display", "none");
            }








            this.lblAddressBill1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lblAddressBill2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lblAddressBill3.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lblAddressBill4.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblAddressBill5.Text = this.comm.GetAddressLabelByKey("Address5");

            this.Page.Header.DataBind();
            this.lblNewAddress.Text = this.objLanguage.GetLanguageConversion("New_Address");
            this.lblEditAddress.Text = this.objLanguage.GetLanguageConversion("Edit_Address");
            this.lblCountry.Text = this.objLanguage.GetLanguageConversion("Country");
            this.lblTelephone.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lblFax.Text = this.objLanguage.GetLanguageConversion("Fax");
            this.lblcopyDeladdress.Text = this.objLanguage.GetLanguageConversion("Copy_the_above_to_Invoice_Address");
            this.lblcopyInvaddress.Text = this.objLanguage.GetLanguageConversion("Copy_the_above_to_Delivery_Address");
            this.btnSave_Bill.Text = this.objLanguage.GetLanguageConversion("Save_And_Use_This_Address");
            this.btnSave_Ship.Text = this.objLanguage.GetLanguageConversion("Save_And_Use_This_Address");
            this.btn_Update_bill.Text = this.objLanguage.GetLanguageConversion("Update");
            this.btn_Update_Ship.Text = this.objLanguage.GetLanguageConversion("Update");
            this.lblAddressBook.Text = this.objLanguage.GetLanguageConversion("Address_book");
            this.spn_ListAllAdddress.InnerText = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.lblAddressBook1.Text = this.objLanguage.GetLanguageConversion("Address_Book");
            this.spn_ListAllAdddress1.InnerText = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.lblAddress_Label.Text = this.objLanguage.GetLanguageConversion("Address_Label");
            this.lnlExample_Note.Text = this.objLanguage.GetLanguageConversion("Example_Note_For_Address");

            OrderBasePage.company_country_select(this.ddlCountry);

            //this.ucAddressInfo.ButtonClick_Ship += new EventHandler(this.ucAddressInfo_ButtonClick_Ship);
            //this.ucAddressInfo.ButtonClick_Bill += new EventHandler(this.ucAddressInfo_ButtonClick_Bill);
            this.ButtonSaveClick_Bill += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Bill);
            this.ButtonSaveClick_Ship += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Ship);
            this.ButtonUpdateClick_Bill += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Bill);
            this.ButtonUpdateClick_Ship += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Ship);

            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                order.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, order.AccountID).Rows)
            {
                this.AccountType = row["accountType"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());

            }

            // Fetch attachment data from your data source, e.g., a database
            if (!IsPostBack)
            {
                List<Attachment> attachments = GetAttachmentsFromDataSource();
                // Bind the attachment data to the GridView
                attachmentGridView.DataSource = attachments;
                attachmentGridView.DataBind();
            }
            if(checkprocessed==1)
                attachmentGridView.Columns[1].Visible = false;
            else
                attachmentGridView.Columns[1].Visible = true;

            this.OriginalStoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            if (!base.IsPostBack)
            {
                this.ApprovalSystem_OrderingProcess();
            }
        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShipping_Address(AddressID).Rows)
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

        public void StockAllocation_OnApprove(long Orderid, long StoreUserID, string ItemIDs)
        {
            DataTable dataTable = OrderBasePage.Select_OrderItems_ForStock(Convert.ToInt64(Orderid), StoreUserID, ItemIDs);
            foreach (DataRow row in dataTable.Rows)
            {
                long num = Convert.ToInt64(row["ProductID"]);
                int num1 = Convert.ToInt32(row["Quantity"]);
                decimal num2 = Convert.ToDecimal(row["UnitPrice"]);
                long num3 = Convert.ToInt64(row["EstimateItemID"]);
                long num4 = Convert.ToInt64(row["OrderItemID"]);
                BaseClass baseClass = new BaseClass();
                string str = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                string str1 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                string str2 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                if (!(Convert.ToBoolean(row["IsStockReplenish"]).ToString().ToLower() != "true") || !(str == "a"))
                {
                    continue;
                }
                foreach (DataRow dataRow in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                {
                    if (dataRow["DrawStockFrom"].ToString().ToLower() == "s")
                    {
                        baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str1, "self", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        baseClass.StockAllocation_Others((long)this.CompanyID, num, num1, str1, Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                    }
                    else if (dataRow["DrawStockFrom"].ToString().ToLower() != "a")
                    {
                        if (dataRow["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            continue;
                        }
                        foreach (DataRow row1 in OrderBasePage.OtherMultipleProductDetails_Select(num, num1, true).Rows)
                        {
                            baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(row1["KitItemID"].ToString()), num, num1, str1, "multiple", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                        }
                    }
                    else
                    {
                        baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str1, "additional option", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID, Convert.ToInt64(Orderid), num4);
                    }
                }
            }
        }

        private Int64 getEstimateIDFromEstimateItem(Int64 estimateItemID)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            string query = "select * from tb_EstimateItem where EstimateItemID =  " + estimateItemID;
            SqlCommand cmd = new SqlCommand(query);
            dataSet = database.ExecuteDataSet(cmd);
            DataRow dr = dataSet.Tables[0].Rows[0];
            Int64 estimateid = Convert.ToInt64(dr["EstimateID"]);
            return estimateid;

        }

        private string approveForDepartment(Int64 estimateID)
        {
            string toreturn = "";

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            string query = "select * from tb_Estimate where EstimateID =  " + estimateID;
            SqlCommand cmd = new SqlCommand(query);
            dataSet = database.ExecuteDataSet(cmd);
            DataRow dr = dataSet.Tables[0].Rows[0];
            //Int64 estimateid = Convert.ToInt64(dr["EstimateID"]);

            string isDepartmentApproval = "";
            string isMainApproval = "";
            string isTwoWayOrNot = "";

            isDepartmentApproval = Convert.ToString(dr["DepartmentApproval"]);
            isMainApproval = Convert.ToString(dr["MainApproval"]);
            this.approvalEmails = Convert.ToString(dr["ApprovalEmails"]);
            isTwoWayOrNot = Convert.ToString(dr["IsTwoWayApproval"]);

            if (isDepartmentApproval == "0" && isTwoWayOrNot == "1")
            {
                toreturn = "DepartmentApproval";
            }
            else
            {
                toreturn = "MainApproval";
            }


            return toreturn;

        }

        private void updateDepartmentBit(Int64 estimateID)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            string query = "Update tb_Estimate set DepartmentApproval = '1' where EstimateID =  " + estimateID;
            SqlCommand cmd = new SqlCommand(query);
            database.ExecuteNonQuery(cmd);
        }

        private string changeApprovalEmail(Int64 estimateID)
        {
            string emailToUpdate = "";
            string[] newApproverEmail = this.approvalEmails.Split(',');
            if (newApproverEmail.Length > 1)
            {
                emailToUpdate = newApproverEmail[0];
            }


            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            string query = "Update tb_Estimate set ApproverEmail = " + "'" + emailToUpdate + "'" + " where EstimateID =  " + estimateID;
            SqlCommand cmd = new SqlCommand(query);
            database.ExecuteNonQuery(cmd);

            return emailToUpdate;

        }



        //-------------------------------

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            int a = 123;
        }

        protected void lnkEdit_Bill_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                }
            }
        }

        protected void lnkEdit_Bill_Click_new(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                }
            }
        }

        protected void lnkChooseBillAddress_Click(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdGrd_bill_Choose.DataSource = dataTable;
            this.rdGrd_bill_Choose.DataBind();
            this.grd_Search_bill.Text = string.Empty;
        }

        protected void rdGrd_bill_Choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["BillingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() == base.Session["BillingAddressID"].ToString())
                {
                    e.Item.Selected = true;
                    return;
                }
                e.Item.Selected = false;
            }
        }

        protected void rdgrd_ship_choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["ShippingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() != base.Session["ShippingAddressID"].ToString())
                {
                    e.Item.Selected = false;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
        }

        protected void rdgrd_ship_choose_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.rdgrd_ship_choose.DataSource = base.Session["AddressGrid"];
            this.rdGrd_bill_Choose.DataSource = base.Session["AddressGrid"];
        }



        private OrderBasePage objOrder = new OrderBasePage();



        public long BillingAddressID;

        public long ShippingAddressID;



        private string users_change_addresses_app;

        private string users_change_addresses_dept;

        private string users_change_addresses_user;

        private string users_select_addresses_app;

        private string users_select_addresses_dept;

        private string users_select_addresses_user;

        private string users_edit_addresses_app;

        private string users_edit_addresses_dept;

        private string users_edit_addresses_user;

        private string users_add_addresses_app;

        private string users_add_addresses_dept;

        private string users_add_addresses_user;

        // save new address
        private string users_new_add_addresses_app;

        private string users_new_add_addresses_dept;

        private string users_new_add_addresses_user;


        private string MainApprover;

        private string DeptApprover;

        private string users_select_Department_address_MainApp;

        private string users_select_Department_address_DeptApp;

        private string users_select_Department_address_AllUser;

        private string users_addnew_address_notsaved_mainapp;

        private string users_addnew_address_notsaved_deptapp;

        private string users_addnew_address_notsaved_alluser;

        private DateTime CreatedDate;

        public int UserID;

        public long OriginalStoreUserID;


        public void ApprovalSystem_OrderingProcess()
        {
            DataSet dataSet = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.MainApprover = "False";
            }
            else
            {
                this.MainApprover = dataSet.Tables[0].Rows[0]["MainApprover"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count <= 0)
            {
                this.DeptApprover = "";
            }
            else
            {
                this.DeptApprover = dataSet.Tables[1].Rows[0]["DeptApprover"].ToString();
            }
            this.users_select_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_app");
            this.users_select_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_dept");
            this.users_select_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_user");
            this.users_add_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_app");
            this.users_add_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_dept");
            this.users_add_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_user");

            // save new address
            this.users_new_add_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_app");
            this.users_new_add_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_dept");
            this.users_new_add_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_user");

            this.users_select_Department_address_MainApp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_mainapp");
            this.users_select_Department_address_DeptApp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_deptapp");
            this.users_select_Department_address_AllUser = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_alluser");
            this.users_addnew_address_notsaved_mainapp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_mainapp");
            this.users_addnew_address_notsaved_deptapp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_deptapp");
            this.users_addnew_address_notsaved_alluser = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_alluser");
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_app.ToLower().Trim() != "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() != "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_user.ToLower().Trim() != "y" && this.users_select_addresses_user.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_app.ToLower().Trim() != "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() != "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_MainApp.ToLower().Trim() != "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_AllUser.ToLower().Trim() != "y" && this.users_select_Department_address_AllUser.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_MainApp.ToLower().Trim() != "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = false;
            //    this.tdChooseAddress1.Visible = false;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_app.ToLower().Trim() == "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_user.ToLower().Trim() == "y" && this.users_select_addresses_user.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_app.ToLower().Trim() == "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_MainApp.ToLower().Trim() == "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "false" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() == "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_AllUser.ToLower().Trim() == "y" && this.users_select_Department_address_AllUser.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_MainApp.ToLower().Trim() == "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            //if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() == "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            //{
            //    this.tdChooseAddress.Visible = true;
            //    this.tdChooseAddress1.Visible = true;
            //}
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_app.ToLower().Trim() != "y" && this.users_add_addresses_app.ToLower() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() != "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_user.ToLower().Trim() != "y" && this.users_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_app.ToLower().Trim() != "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() != "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_app.ToLower().Trim() == "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() == "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_user.ToLower().Trim() == "y" && this.users_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_app.ToLower().Trim() == "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() == "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            // save new address
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_new_add_addresses_user.ToLower().Trim() == "y" && this.users_new_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                //this.tdChooseAddress.Visible = true;
                //this.tdChooseAddress1.Visible = true;
                //this.tdEditAddress.Visible = true;
                //this.tdEditAddress1.Visible = true;
            }
        }

        protected void btnSave_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Bill(sender, e);
        }

        protected void btnSave_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Ship(sender, e);
        }

        protected void btnUpdate_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Bill(sender, e);
        }

        protected void btnUpdate_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Ship(sender, e);
        }

        protected void grd_Search_bill_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.objBase.SpecialEncode(this.grd_Search_bill.Text));
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdGrd_bill_Choose.DataSource = dataTable;
            this.rdGrd_bill_Choose.DataBind();
        }

        protected void grd_Search_ship_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.grd_Search_ship.Text);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
        }


        protected void lnkChooseShipAddress_Click(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
            this.grd_Search_ship.Text = string.Empty;
        }



        protected void lnkEdit_Ship_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["ShippingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                }
            }
        }

        protected void lnkOrderDate_bill_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Bill(sender, e);
            this.grd_Search_bill.Text = string.Empty;
        }

        protected void lnkOrderDate_ship_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Ship(sender, e);
            this.grd_Search_ship.Text = string.Empty;
        }

        public event EventHandler ButtonClick_Bill;

        public event EventHandler ButtonClick_Ship;

        public event EventHandler ButtonSaveClick_Bill;

        public event EventHandler ButtonSaveClick_Ship;

        public event EventHandler ButtonUpdateClick_Bill;

        public event EventHandler ButtonUpdateClick_Ship;


        //protected void ucAddressInfo_ButtonClick_Bill(object sender, EventArgs e)
        //{
        //    string str = ((LinkButton)sender).CommandArgument.ToString();
        //    this.Session["BillingAddressID"] = str;
        //    if (this.Session["BillingAddressID"] != null)
        //    {
        //        this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
        //    }
        //    this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
        //    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog3();", true);
        //    this.rdgrd_bill.Rebind();
        //    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        //}

        //protected void ucAddressInfo_ButtonClick_Ship(object sender, EventArgs e)
        //{
        //    string str = ((LinkButton)sender).CommandArgument.ToString();
        //    this.Session["ShippingAddressID"] = str;
        //    if (this.Session["ShippingAddressID"] != null)
        //    {
        //        this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
        //    }
        //    this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
        //    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog4();", true);
        //    this.rdgrd_ship.Rebind();
        //    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        //}

        protected void ucAddressInfo_ButtonSaveClick_Bill(object sender, EventArgs e)
        {
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.OriginalStoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), "",this.txt_fax_billing.Text.Trim(), this.ddlCountry.SelectedItem.Text.Trim(), 0, 0, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);

            updateInvoiceAddressId(this.OrderID, this.BillingAddressID);

            this.Session["BillingAddressID"] = this.BillingAddressID.ToString();
            if (!this.Chk_copy_to_deladdress.Checked)
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            else
            {
                this.Session["ShippingAddressID"] = this.BillingAddressID.ToString();
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog();", true);
            this.ApprovalSystem_OrderingProcess();
            if (this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y")
            {
                this.Session["TempSaveAddress_Bill"] = this.BillingAddressID;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonSaveClick_Ship(object sender, EventArgs e)
        {
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.ShippingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.OriginalStoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), "",this.txt_fax_billing.Text.Trim(), this.ddlCountry.SelectedItem.Text.Trim(), 0, 0, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            updateDeliveryAddressId(this.OrderID, this.ShippingAddressID);
            this.Session["ShippingAddressID"] = this.ShippingAddressID.ToString();
            if (!this.Chk_copy_to_invaddress.Checked)
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            else
            {
                this.Session["BillingAddressID"] = this.ShippingAddressID;
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            //this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog();", true);
            this.ApprovalSystem_OrderingProcess();
            if (this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y")
            {
                this.Session["TempSaveAddress_Ship"] = this.ShippingAddressID;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Bill(object sender, EventArgs e)
        {
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["BillingAddressID"]), "", "", base.SpecialEncode(this.txt_address_billing1.Text.Trim()), base.SpecialEncode(this.txt_address_billing2.Text.Trim()), base.SpecialEncode(this.txt_address_billing3.Text.Trim()), base.SpecialEncode(this.txt_address_billing4.Text.Trim()), base.SpecialEncode(this.txt_telephone_billing.Text.Trim()),"", base.SpecialEncode(this.txt_fax_billing.Text.Trim()), base.SpecialEncode(this.ddlCountry.SelectedItem.Text.Trim()), base.SpecialEncode(this.txtaddressLabelBilling.Text.Trim()), base.SpecialEncode(this.txt_address_billing5.Text.Trim()));
            if (!this.Chk_copy_to_deladdress.Checked)
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            else
            {
                this.Session["ShippingAddressID"] = Convert.ToInt64(this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:HideDialog();showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Ship(object sender, EventArgs e)
        {
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["ShippingAddressID"]), "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_telephone_billing.Text.Trim(),"" , this.txt_fax_billing.Text.Trim(), this.ddlCountry.SelectedItem.Text.Trim(), this.txtaddressLabelBilling.Text.Trim(), this.txt_address_billing5.Text.Trim());
            if (!this.Chk_copy_to_invaddress.Checked)
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            else
            {
                this.Session["BillingAddressID"] = Convert.ToInt64(this.Session["ShippingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:HideDialog();showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        }



        protected void GetAddressDetails(string Type, string Id)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(Id));
            if (Type == "bill")
            {
                DataTable dataTable1 = new DataTable();
                if (dataTable.Rows.Count > 0)
                {
                    dataTable1 = dataTable;
                }
                this.lbl_BliingAddress.Text = "";
                foreach (DataRow row in dataTable1.Rows)
                {
                    if (row["AddressLabel"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["AddressLabel"].ToString());
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                        Label label = this.lbl_BliingAddress;
                        string text = this.lbl_BliingAddress.Text;
                        char[] chrArray = new char[] { ',' };
                        label.Text = string.Concat(text.TrimEnd(chrArray), "<br/>");
                    }
                    if (row["AddressLine1"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["AddressLine1"].ToString());
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                        Label label1 = this.lbl_BliingAddress;
                        string str = this.lbl_BliingAddress.Text;
                        char[] chrArray1 = new char[] { ',' };
                        label1.Text = string.Concat(str.TrimEnd(chrArray1), "<br/>");
                    }
                    if (row["AddressLine2"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["AddressLine2"].ToString());
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                        Label label2 = this.lbl_BliingAddress;
                        string text1 = this.lbl_BliingAddress.Text;
                        char[] chrArray2 = new char[] { ',' };
                        label2.Text = string.Concat(text1.TrimEnd(chrArray2), "<br/>");
                    }
                    if (row["Address2"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["Address2"].ToString());
                        if (row["Address3"].ToString() != "" || row["Address4"].ToString() != "")
                        {
                            this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (row["Address3"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["Address3"].ToString());
                        if (row["Address4"].ToString() != "")
                        {
                            this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (row["Address4"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, row["Address4"].ToString());
                    }
                    if (row["Country"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, "<br/>", row["Country"].ToString());
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                        Label label3 = this.lbl_BliingAddress;
                        string str1 = this.lbl_BliingAddress.Text;
                        char[] chrArray3 = new char[] { ',' };
                        label3.Text = string.Concat(str1.TrimEnd(chrArray3), "<br/>");
                    }
                    if (row["Phone"].ToString() != "")
                    {
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, "<br/> T:&nbsp;", row["Phone"].ToString());
                        this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                        Label label4 = this.lbl_BliingAddress;
                        string text2 = this.lbl_BliingAddress.Text;
                        char[] chrArray4 = new char[] { ',' };
                        label4.Text = string.Concat(text2.TrimEnd(chrArray4), "<br/>");
                    }
                    if (row["Fax"].ToString() == "")
                    {
                        continue;
                    }
                    this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, "F:&nbsp", row["Fax"].ToString());
                    this.lbl_BliingAddress.Text = string.Concat(this.lbl_BliingAddress.Text, ",");
                    Label label5 = this.lbl_BliingAddress;
                    string str2 = this.lbl_BliingAddress.Text;
                    char[] chrArray5 = new char[] { ',' };
                    label5.Text = string.Concat(str2.TrimEnd(chrArray5), "<br/>");
                }
                this.lbl_BliingAddress.Text = base.SpecialDecode(this.lbl_BliingAddress.Text);
                if (this.lbl_BliingAddress.Text == "")
                {
                    this.lnkEdit_Bill.Attributes.Add("style", "display:none");
                    return;
                }
            }
            else if (Type == "ship")
            {
                DataTable dataTable2 = new DataTable();
                if (dataTable.Rows.Count > 0)
                {
                    dataTable2 = dataTable;
                }
                this.lbl_ShippingAddress.Text = "";
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    if (dataRow["AddressLabel"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["AddressLabel"].ToString());
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                        Label label6 = this.lbl_ShippingAddress;
                        string text3 = this.lbl_ShippingAddress.Text;
                        char[] chrArray6 = new char[] { ',' };
                        label6.Text = string.Concat(text3.TrimEnd(chrArray6), "<br/>");
                    }
                    if (dataRow["AddressLine1"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["AddressLine1"].ToString());
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                        Label label7 = this.lbl_ShippingAddress;
                        string str3 = this.lbl_ShippingAddress.Text;
                        char[] chrArray7 = new char[] { ',' };
                        label7.Text = string.Concat(str3.TrimEnd(chrArray7), "<br/>");
                    }
                    if (dataRow["AddressLine2"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["AddressLine2"].ToString());
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                        Label label8 = this.lbl_ShippingAddress;
                        string text4 = this.lbl_ShippingAddress.Text;
                        char[] chrArray8 = new char[] { ',' };
                        label8.Text = string.Concat(text4.TrimEnd(chrArray8), "<br/>");
                    }
                    if (dataRow["Address2"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["Address2"].ToString());
                        if (dataRow["Address3"].ToString() != "" || dataRow["Address4"].ToString() != "")
                        {
                            this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (dataRow["Address3"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["Address3"].ToString());
                        if (dataRow["Address4"].ToString() != "")
                        {
                            this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (dataRow["Address4"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, dataRow["Address4"].ToString());
                    }
                    if (dataRow["Country"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, "<br/>", dataRow["Country"].ToString());
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                        Label label9 = this.lbl_ShippingAddress;
                        string str4 = this.lbl_ShippingAddress.Text;
                        char[] chrArray9 = new char[] { ',' };
                        label9.Text = string.Concat(str4.TrimEnd(chrArray9), "<br/>");
                    }
                    if (dataRow["Phone"].ToString() != "")
                    {
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, "<br/> T:&nbsp;", dataRow["Phone"].ToString());
                        this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                        Label label10 = this.lbl_ShippingAddress;
                        string text5 = this.lbl_ShippingAddress.Text;
                        char[] chrArray10 = new char[] { ',' };
                        label10.Text = string.Concat(text5.TrimEnd(chrArray10), "<br/>");
                    }
                    if (dataRow["Fax"].ToString() == "")
                    {
                        continue;
                    }
                    this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, "F:&nbsp;", dataRow["Fax"].ToString());
                    this.lbl_ShippingAddress.Text = string.Concat(this.lbl_ShippingAddress.Text, ",");
                    Label label11 = this.lbl_ShippingAddress;
                    string str5 = this.lbl_ShippingAddress.Text;
                    char[] chrArray11 = new char[] { ',' };
                    label11.Text = string.Concat(str5.TrimEnd(chrArray11), "<br/>");
                }
                this.lbl_ShippingAddress.Text = base.SpecialDecode(this.lbl_ShippingAddress.Text);
                //this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
                if (this.lbl_ShippingAddress.Text == "")
                {
                    this.lnkEdit_Ship.Attributes.Add("style", "display:none");
                }
            }
        }


        [WebMethod]
        public static order_new lnkEdit_Bill_Click_Service(string name)
        {
            BaseClass baseClass = new BaseClass();
            //DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);

            order_new orr = new order_new();
            order or = new order();
            DataTable dataTable = or.returnData(name);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    orr.AddressLabel = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    orr.AddressLine1 = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    orr.AddressLine2 = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    orr.Address2 = baseClass.SpecialDecode(row["Address2"].ToString());
                    orr.Address3 = baseClass.SpecialDecode(row["Address3"].ToString());
                    orr.Address4 = baseClass.SpecialDecode(row["Address4"].ToString());
                    orr.Country = baseClass.SpecialDecode(row["Country"].ToString());
                    orr.phone = row["phone"].ToString();
                    orr.Fax = row["Fax"].ToString();
                }
            }
            return orr;
        }


        public DataTable returnData(string name)
        {
            if (name.ToLower() == "invoice")
            {
                BaseClass baseClass = new BaseClass();
                DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);

                return dataTable;
            }
            else
            {
                BaseClass baseClass = new BaseClass();
                DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["ShippingAddressID"]), (long)0);

                return dataTable;
            }

        }


        private void updateInvoiceAddressId(Int64 estimateID, Int64 addressID)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            string query = "Update tb_Estimate set InvoiceAddressID = " + addressID + " where EstimateID =  " + estimateID;
            SqlCommand cmd = new SqlCommand(query);
            database.ExecuteNonQuery(cmd);
        }

        private void updateDeliveryAddressId(Int64 estimateID, Int64 addressID)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            string query = "Update tb_Estimate set DeliveryAddress = " + addressID + " where EstimateID =  " + estimateID;
            SqlCommand cmd = new SqlCommand(query);
            database.ExecuteNonQuery(cmd);
        }


        private void saveApproverComments(Int64 estimateID, string approverComments,string orderTitle, string orderNumber)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            //string query = "Update tb_Estimate set ApproverComments = " + approverComments + " where EstimateID =  " + estimateID;
            //SqlCommand cmd = new SqlCommand(query);
            //database.ExecuteNonQuery(cmd);






            SqlConnection conn = new SqlConnection((new commonclass()).strConnection);
            conn.Open();
            string sql2 = "UPDATE tb_Estimate SET eStoreComments = @spent,EstimateTitle= @orderTitle ,OrderNumber=@orderNumber WHERE estimateid=@id";
            SqlCommand myCommand2 = new SqlCommand(sql2, conn);
            myCommand2.Parameters.AddWithValue("@spent", approverComments);
            myCommand2.Parameters.AddWithValue("@orderTitle", orderTitle);
            myCommand2.Parameters.AddWithValue("@orderNumber", orderNumber);
            myCommand2.Parameters.AddWithValue("@id", estimateID);
            myCommand2.ExecuteNonQuery();
            conn.Close();
            //try
            //{
            //    conn.Open();
            //    myCommand2.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex);
            //}
            //finally
            //{
            //    conn.Close();
            //}

        }
    }


    public class order_new
    {
        public string AddressLabel { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Country { get; set; }
        public string phone { get; set; }
        public string Fax { get; set; }
    }
}