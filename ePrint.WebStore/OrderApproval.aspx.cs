using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class OrderApproval : System.Web.UI.Page, IRequiresSessionState
    {

        private BaseClass objBase = new BaseClass();

        public commonclass comm = new commonclass();

        private storeEmail objEmail = new storeEmail();

        public int CompanyID;

        public long StoreUserID;

        public long OrderID;

        public static long AccountID;

        public string ToEmail = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string Address = string.Empty;

        public string OrderKey = string.Empty;

        public static string imagePath;

        public string IsPPW = string.Empty;

        public bool IsPPW_SystemName;

        public string OrdID = string.Empty;

        public int Orderid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        public long UserGettingApproved;

        public string StatusName = string.Empty;

        private string MeasurementValue = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        public string strImagepath = BaseClass.imagePath();

        public string PaymentMode_Style = string.Empty;

        public string deptScreenName = string.Empty;

        public string IsEnableHidePrice = string.Empty;

        public bool CartJobScreenNameShow;

        public string CartJobScreenName = string.Empty;

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

        static OrderApproval()
        {
            OrderApproval.AccountID = (long)0;
            OrderApproval.imagePath = string.Empty;
        }

        public OrderApproval()
        {
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            string str = "approve";
            string str1 = "u";
            string[] strArrays = this.hdnOrderItemID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                OrderBasePage.Reject_Order(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str, this.StoreUserID, Convert.ToInt64(strArrays[i]));
            }
            this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(OrderApproval.AccountID), "B2B User Order Approval", "Customer", (long)0, this.ToEmail, str1);
            this.objEmail.emailOrdersDetails_ItemNumbers(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(OrderApproval.AccountID), "New Order", "Admin", (long)0, "no approval", str1, this.hdnOrderItemID.Value);
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(base.Request.QueryString.ToString());
            nameValueCollection.Set("type", "approved");
            string absolutePath = base.Request.Url.AbsolutePath;
            string str2 = string.Concat("?", nameValueCollection.ToString());
            base.Response.Redirect(string.Concat(absolutePath, str2));
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string str = "reject";
            string str1 = "u";
            BaseClass baseClass = new BaseClass();
            string[] strArrays = this.hdnOrderItemID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                long num = Convert.ToInt64(this.OrderID);
                long storeUserID = this.StoreUserID;
                long num1 = Convert.ToInt64(strArrays[i]);
                foreach (DataRow row in OrderBasePage.Select_OrderItems_ForStock(num, storeUserID, num1.ToString()).Rows)
                {
                    long num2 = Convert.ToInt64(row["ProductID"]);
                    Convert.ToInt32(row["Quantity"]);
                    Convert.ToDecimal(row["UnitPrice"]);
                    long num3 = Convert.ToInt64(row["EstimateItemID"]);
                    Convert.ToInt64(row["OrderItemID"]);
                    foreach (DataRow dataRow in baseClass.ProductStockType_Select((long)this.CompanyID, num2).Rows)
                    {
                        if (dataRow["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass.StockCancellationProcess((long)this.CompanyID, num2, (long)0, "self", num3, "Job", this.StoreUserID, "a");
                        }
                        else if (dataRow["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass.StockCancellationProcess((long)this.CompanyID, (long)0, num2, "other", num3, "Job", this.StoreUserID, "a");
                        }
                        else if (dataRow["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (dataRow["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            baseClass.StockCancellationProcess((long)this.CompanyID, num2, (long)0, "multiple", num3, "Job", this.StoreUserID, "a");
                        }
                        else
                        {
                            baseClass.StockCancellationProcess((long)this.CompanyID, num2, (long)0, "additional option", num3, "Job", this.StoreUserID, "a");
                        }
                    }
                }
                OrderBasePage.Reject_Order(this.btn_Reject.CommandArgument, this.txtReason.Text.Trim(), str, this.StoreUserID, Convert.ToInt64(strArrays[i]));
            }
            this.objEmail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(OrderApproval.AccountID), "B2B User Order Rejection", "Customer", (long)0, this.ToEmail, str1);
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(base.Request.QueryString.ToString());
            nameValueCollection.Set("type", "rejected");
            string absolutePath = base.Request.Url.AbsolutePath;
            string str2 = string.Concat("?", nameValueCollection.ToString());
            base.Response.Redirect(string.Concat(absolutePath, str2));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] accountID;
            this.lblDis.Text = this.objLanguage.GetLanguageConversion("Reject_Reason");
            this.btnOk.Text = this.objLanguage.GetLanguageConversion("OK");
            string empty = string.Empty;
            if (base.Request.Params["UserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Request.Params["UserID"].ToString());
            }
            if (base.Request.Params["OrderID"] != null)
            {
                this.Orderid = Convert.ToInt32(base.Request.Params["OrderID"].ToString());
            }
            if (base.Request.Params["OrdKey"] != null)
            {
                DataTable dataTable = OrderBasePage.Select_OrderID(base.Request.Params["OrdKey"].ToString());
                foreach (DataRow row in dataTable.Rows)
                {
                    this.Orderid = Convert.ToInt32(row["OrderID"].ToString());
                    this.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                }
            }
            this.deptScreenName = (new BaseClass()).Return_ApprovalRegistration_Settings("deptscreenname");
            this.btn_Approve.Attributes.Add("onclick", "javascript:return Validate('Approve');");
            this.btn_Reject.Attributes.Add("onclick", "javascript:return OpenRadwindow('Reject');");
            this.tdStatus.Visible = false;
            this.tdlblStatus.Visible = false;
            if (base.Request.Params["type"] != null && base.Request.Params["type"] != "")
            {
                if (base.Request.Params["type"].ToString() == "approved")
                {
                    this.divMsg.Style.Add("display", "block");
                    this.lblSucess.Text = "Order Items approved successfully";
                    this.imgSucess.Style.Add("display", "block");
                }
                if (base.Request.Params["type"].ToString() == "rejected")
                {
                    this.divMsg.Style.Add("display", "block");
                    this.lblSucess.Text = "Order Items rejected successfully";
                    this.imgSucess.Style.Add("display", "block");
                }
            }
            foreach (DataRow dataRow in this.StoreUser_select(this.StoreUserID).Rows)
            {
                this.CompanyID = Convert.ToInt32(dataRow["CompanyID"].ToString());
                OrderApproval.AccountID = Convert.ToInt64(dataRow["AccountID"].ToString());
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            DataTable dataTable1 = ProductBasePage.Setting_SpendLimit_Select(OrderApproval.AccountID, (long)this.CompanyID);
            if (dataTable1.Rows.Count <= 0)
            {
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.IsEnableHidePrice = row1["EnableHidePrice"].ToString().ToLower();
                }
            }
            if (this.Orderid != 0)
            {
                this.OrdID = this.Orderid.ToString();
            }
            else if (this.OrderKey.Contains("-JOB") || this.OrderKey.Contains("-INV"))
            {
                this.OrdID = this.OrderKey;
            }
            else
            {
                foreach (DataRow dataRow1 in OrderBasePage.Select_OrderID(this.OrderKey).Rows)
                {
                    this.OrdID = dataRow1["OrderID"].ToString();
                }
            }
            if (this.StoreUserID != (long)0)
            {
                int num = 0;
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = 0;
                decimal num5 = new decimal(0);
                long num6 = (long)0;
                string str = string.Empty;
                long num7 = (long)0;
                DataTable dataTable2 = OrderBasePage.Select_OrderItems(this.OrdID, this.StoreUserID);
                decimal num8 = new decimal(0);
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    num6 = Convert.ToInt64(row2["TaxID"]);
                    this.ToEmail = row2["EmailID"].ToString();
                    empty = (row2["PDFNameFromCart"].ToString() == "" ? "Style='display:none;float:left;'" : "Style='display:block;float:left;'");
                    if (Convert.ToInt64(row2["OrderBehalfDeptID"]) > (long)0)
                    {
                        if (this.deptScreenName != "")
                        {
                            this.lbl_name.Text = this.objBase.SpecialDecode(string.Concat(row2["Order_Behalf_DeptID"].ToString(), " [", this.deptScreenName, "] "));
                        }
                        else
                        {
                            this.lbl_name.Text = this.objBase.SpecialDecode(string.Concat(row2["Order_Behalf_DeptID"].ToString(), " [Department] "));
                        }
                        this.lbl_email.Text = this.objBase.SpecialDecode(row2["OrderBehalfUserIDEmail"].ToString());
                        this.lblatnfor.Text = string.Concat(" ", row2["Order_Behalf_UserID"].ToString());
                        this.spnattn.Style.Add("display", "block");
                        this.lblemail.Style.Add("display", "none");
                        this.lbl_email.Style.Add("display", "none");
                        this.spnattn.Style.Add("white-space", "nowrap");
                    }
                    else if (Convert.ToInt64(row2["OrderBehalfUserID"]) <= (long)0)
                    {
                        this.lbl_name.Text = this.objBase.SpecialDecode(string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString()));
                    }
                    else
                    {
                        this.lbl_name.Text = this.objBase.SpecialDecode(row2["Order_Behalf_UserID"].ToString());
                        this.lbl_email.Text = this.objBase.SpecialDecode(row2["OrderBehalfUserIDEmail"].ToString());
                    }
                    this.lbl_name.Style.Add("white-space", "nowrap");
                    this.lbl_Orderedby.Text = this.objBase.SpecialDecode(string.Concat(row2["FirstName"].ToString(), " ", row2["LastName"].ToString()));
                    this.lbl_Orderedbyemail.Text = this.objBase.SpecialDecode(row2["EmailID"].ToString());
                    this.lbl_OrderNo.Text = row2["OrderNo"].ToString();
                    this.btn_Reject.CommandArgument = row2["OrderNo"].ToString();
                    this.btn_Approve.CommandArgument = row2["OrderNo"].ToString();
                    num4 = Convert.ToInt32(row2["createdBy"].ToString());
                    Convert.ToDecimal(row2["Tax"]);
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
                    this.lblCostcenter.Text = this.objBase.SpecialDecode(row2["CostCentreName"].ToString());
                    this.lbl_OrderTitle.Text = this.objBase.SpecialDecode(row2["OrderTitle"].ToString());
                    this.lbl_UserRefOrderNo.Text = this.objBase.SpecialDecode(row2["UserRefOrderNo"].ToString());
                    this.OrderID = Convert.ToInt64(row2["OrderID"]);
                    if (OrderBasePage.GetOrderItems(this.OrderID) <= 0)
                    {
                        this.divButtons.Style.Add("display", "none");
                    }
                    else
                    {
                        this.divButtons.Style.Add("display", "block");
                    }
                    DataTable dataTable3 = OrderBasePage.Order_Status(Convert.ToInt64(row2["OrderID"]), Convert.ToInt64(row2["EstimateID"].ToString()));
                    if (row2["IsApproved"].ToString() == "0" && row2["IsRejected"].ToString() == "0")
                    {
                        this.lbl_Status.Text = this.objLanguage.GetLanguageConversion("Awaiting_Approval");
                        this.lbl_Status.Style.Add("font-style", "italic");
                        this.lbl_Status.Style.Add("color", "Gray");
                    }
                    else if (!(row2["IsApproved"].ToString() == "0") || !(row2["IsRejected"].ToString() == "1"))
                    {
                        foreach (DataRow dataRow2 in dataTable3.Rows)
                        {
                            this.lbl_Status.Text = this.objBase.SpecialDecode(dataRow2["UserFriendlyName"].ToString());
                            this.StatusName = this.lbl_Status.Text;
                            this.lbl_Status.Style.Add("font-style", "normal");
                            this.lbl_Status.Style.Add("color", "#000000");
                        }
                    }
                    else
                    {
                        this.lbl_Status.Text = this.objLanguage.GetLanguageConversion("Rejected");
                        this.lbl_Status.Style.Add("font-style", "normal");
                        this.lbl_Status.Style.Add("color", "Red");
                    }
                    str = row2["ConsignmentNumber"].ToString();
                    if (str == "")
                    {
                        this.lbl_ConsignmentNoteNumber.Text = "Pending";
                    }
                    else
                    {
                        this.lbl_ConsignmentNoteNumber.Text = this.objBase.SpecialDecode(str.ToString());
                    }
                    num7 = Convert.ToInt64(row2["ContactID"]);
                    this.Return_address(this.StoreUserID, "", num7, Convert.ToInt64(row2["BillingAddressID"]), out this.Address);
                    this.lbl_BliingAddress.Text = this.objBase.SpecialDecode(this.Address);
                    this.Return_address(this.StoreUserID, "", num7, Convert.ToInt64(row2["ShippingAddressID"]), out this.Address);
                    this.lbl_ShippingAddress.Text = this.objBase.SpecialDecode(this.Address);
                    this.plhorder.Controls.Add(new LiteralControl("<tr class='b_productName_tr'>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td>"));
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
                    string str1 = "pdf";
                    ControlCollection controls = this.plhorder.Controls;
                    accountID = new object[] { "<div style='width:50px;'><img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", OrderApproval.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_Open(\"", row2["PDFNameFromCart"].ToString(), "\",", OrderApproval.AccountID, ",\"", str1, "\");' ", empty, "/></div>" };
                    controls.Add(new LiteralControl(string.Concat(accountID)));
                    string empty1 = string.Empty;
                    if (row2["OrderKey"] != null)
                    {
                        accountID = new object[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", row2["ProductID"].ToString(), "&CartItemID=", row2["CartItemID"].ToString(), "&OrdKey=", row2["OrderKey"].ToString(), "&type=ed&OrderItemId=", row2["OrderItemID"], "&Store_UserID=", row2["StoreUserID"].ToString(), "&OrderMode=edit&IsUserdesignated=1" };
                        empty1 = string.Concat(accountID);
                        if (row2["ApproveStatus"].ToString() == "0")
                        {
                            ControlCollection controlCollections = this.plhorder.Controls;
                            accountID = new object[] { "<a href=", empty1, "><img id='img_Edit_", num, "' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", OrderApproval.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit' alt=' '/></a>" };
                            controlCollections.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_OrderReference_td' style='padding-left: 0.32%;padding-top: 3px;' class='Td15'>"));
                    Label label = new Label()
                    {
                        ID = string.Concat("OrderReference_", num),
                        Text = this.objBase.SpecialDecode(row2["Order_Item_Number"].ToString())
                    };
                    this.plhorder.Controls.Add(label);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productName_td' style='padding-right:5px; padding-left:3px;'>"));
                    Label label1 = new Label()
                    {
                        ID = string.Concat("lblproductName_", num),
                        Text = this.objBase.SpecialDecode(row2["CatalogueName"].ToString())
                    };
                    if (row2["MatrixType"].ToString().ToLower() == "g")
                    {
                        string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderedWidth"].ToString()), 2, "", false, false, true);
                        string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderedHeight"].ToString()), 2, "", false, false, true);
                        string[] text = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                        label1.Text = string.Concat(text);
                    }
                    this.plhorder.Controls.Add(label1);
                    int num9 = 0;
                    foreach (DataRow row3 in OrderBasePage.Select_OrderAdditionalItems((long)this.Orderid).Rows)
                    {
                        if (Convert.ToInt32(row3["CheckCount"]) <= 0)
                        {
                            break;
                        }
                        if (Convert.ToInt32(row3["OptionID"]) <= 0)
                        {
                            continue;
                        }
                        if (num9 == 0)
                        {
                            this.plhorder.Controls.Add(new LiteralControl(string.Concat("<br/><div class='marginTop5px'><Strong><label><i>", this.objLanguage.GetLanguageConversion("Additional_Items"), "</i></label></Strong></div>")));
                        }
                        this.plhorder.Controls.Add(new LiteralControl("<div>"));
                        Label label2 = new Label();
                        accountID = new object[] { "lblAdditionalName_", num, "_", num9 };
                        label2.ID = string.Concat(accountID);
                        label2.Text = this.objBase.SpecialDecode(row3["UserFriendlyName"].ToString().Trim());
                        label2.Style.Add("font-size", "12px");
                        label2.Style.Add("font-weight", "bold");
                        label2.Style.Add("color", "#696969");
                        this.plhorder.Controls.Add(label2);
                        this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        if (row3["MainCalculationType"].ToString().ToLower() == "c")
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                            Label label3 = new Label();
                            accountID = new object[] { "lblSelectedValue_", num, "_", num9 };
                            label3.ID = string.Concat(accountID);
                            label3.Text = row3["SelectedValue"].ToString().Trim();
                            label3.Attributes.Add("style", "padding-left:6px; font-size:11px;");
                            this.plhorder.Controls.Add(label3);
                            this.plhorder.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        num9++;
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productDescription_td' style='padding-top:4px;padding-left:6px;'>"));
                    Label label4 = new Label()
                    {
                        ID = string.Concat("lblproductDescription_", num),
                        Text = this.objBase.SpecialDecode(row2["Description"].ToString())
                    };
                    this.plhorder.Controls.Add(label4);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd Td15' style='text-align:center;padding:3px 10px 0px 10px;'>"));
                    Label label5 = new Label()
                    {
                        ID = string.Concat("lbldeliverydate_", num),
                        Text = this.comm.Eprint_return_Date_Before_View(row2["ActualDeliveryDate"].ToString(), this.CompanyID, num4, false)
                    };
                    if (label5.Text == "")
                    {
                        label5.Text = "N/A";
                    }
                    this.plhorder.Controls.Add(label5);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productQty_td' style='word-break:normal' >"));
                    Label label6 = new Label()
                    {
                        ID = string.Concat("lblproductQty_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["Quantity"].ToString()), 0, "", true, false, true)
                    };
                    this.plhorder.Controls.Add(label6);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(OrderApproval.AccountID);
                    if (this.IsCampaignEnabled.ToLower() == "true")
                    {
                        this.Campaign_Td.Visible = true;
                        this.CampaignSignNumber.Visible = true;
                        this.plhorder.Controls.Add(new LiteralControl("<td style='padding:3px 0px 0px 0px;text-align:center'; >"));
                        Label label7 = new Label()
                        {
                            ID = string.Concat("lblCampaignSignNumber_", num),
                            Text = row2["CampaignSignNumber"].ToString()
                        };
                        this.plhorder.Controls.Add(label7);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                        this.plhorder.Controls.Add(new LiteralControl("<td style='padding:3px 0px 0px 10px'>"));
                        Label label8 = new Label()
                        {
                            ID = string.Concat("lblcampaignName_", num),
                            Text = this.objBase.SpecialDecode(row2["EventName"].ToString())
                        };
                        this.plhorder.Controls.Add(label8);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    DataTable dataTable4 = CartBasePage.default_settings(Convert.ToInt32(this.CompanyID), Convert.ToInt32(OrderApproval.AccountID));
                    if (dataTable4.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow3 in dataTable4.Rows)
                        {
                            this.CartJobScreenNameShow = Convert.ToBoolean(dataRow3["CartJobNameShow"]);
                            this.CartJobScreenName = Convert.ToString(dataRow3["CartJobScreenName"]);
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
                    this.lblJobName.Text = this.CartJobScreenName;
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productDescription_td' style='padding-left: 1%; padding-top:3px;text-align: left;'>"));
                    Label gray = new Label()
                    {
                        ID = string.Concat("lblStatus", num),
                        Text = row2["ItemStatusTitle"].ToString()
                    };
                    gray.Font.Italic = true;
                    gray.ForeColor = Color.Gray;
                    this.plhorder.Controls.Add(gray);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.tdApprovedStaus.Visible = true;
                    this.plhorder.Controls.Add(new LiteralControl("<td style='padding-left:1%; padding-top:3px;text-align: left;'>"));
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
                    this.plhorder.Controls.Add(new LiteralControl("<td class='OrderItemTotalPriceTd' style='text-align:left;padding-left: 10px;'>"));
                    Label label9 = new Label()
                    {
                        ID = string.Concat("lblItemMaterial", num),
                        Text = this.objBase.SpecialDecode(row2["ItemMaterial"].ToString())
                    };
                    this.plhorder.Controls.Add(label9);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    if (this.CartJobScreenNameShow)
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productJobName_td' style='padding-left:10px;'>"));
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productJobName_td' style='display:none;'>"));
                    }
                    Label label10 = new Label()
                    {
                        ID = string.Concat("lblProductJobName_", num),
                        Text = row2["JobName1"].ToString()
                    };
                    label10.Style.Add("text-align", "left");
                    this.plhorder.Controls.Add(label10);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productTotal_td1'><div class='DisplayNone'>"));
                    Label label11 = new Label()
                    {
                        ID = string.Concat("lblproductTax_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTax"].ToString()), 2, "", false, false, true)
                    };
                    this.plhorder.Controls.Add(label11);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    decimal num10 = new decimal(0);
                    if (row2["Quantity"].ToString() != "")
                    {
                        num10 = (Convert.ToDecimal(row2["Quantity"].ToString()) != new decimal(0) ? Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()) / Convert.ToDecimal(row2["Quantity"].ToString()) : Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()));
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productPrice_td DisplayNone'>"));
                        Label label12 = new Label()
                        {
                            ID = string.Concat("lblproductPrice_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num10, 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label12);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productPrice_td'>"));
                        Label label13 = new Label()
                        {
                            ID = string.Concat("lblproductPrice_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num10, 2, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label13);
                        this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3 DisplayNone' style='padding-left:13px;'>"));
                        Label label14 = new Label()
                        {
                            ID = string.Concat("lblTaxApplicable_", num),
                            Text = string.Concat(row2["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                        };
                        num2 = num2 + Convert.ToDecimal(row2["OrderItemTax"]);
                        this.plhorder.Controls.Add(label14);
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td align='left' class='paddingTop3' style='padding-left:13px;'>"));
                        Label label15 = new Label()
                        {
                            ID = string.Concat("lblTaxApplicable_", num),
                            Text = string.Concat(row2["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TaxRate"]), 2, "", false, false, true)), "%")
                        };
                        num2 = num2 + Convert.ToDecimal(row2["OrderItemTax"]);
                        this.plhorder.Controls.Add(label15);
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3 DisplayNone'>"));
                        Label label16 = new Label()
                        {
                            ID = string.Concat("lblproductTotal_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()), 2, "", false, false, true)
                        };
                        num1 = num1 + Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString());
                        this.plhorder.Controls.Add(label16);
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td align='right' class='paddingTop3'>"));
                        Label label17 = new Label()
                        {
                            ID = string.Concat("lblproductTotal_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString()), 2, "", false, false, true)
                        };
                        num1 = num1 + Convert.ToDecimal(row2["OrderItemTotalPrice"].ToString());
                        this.plhorder.Controls.Add(label17);
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td></tr><div class='clearBoth'></div>"));
                    num++;
                    num8 = Convert.ToDecimal(row2["Taxprice"].ToString());
                }
                int num11 = 0;
                decimal num12 = new decimal(0);
                DataTable dataTable5 = OrderBasePage.Select_OrderAdditionalOptions(this.StoreUserID, this.OrderID.ToString());
                foreach (DataRow row4 in dataTable5.Rows)
                {
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div style='padding-right:60px;' class='additionalDiv_padding_4px_0px'>"));
                        ControlCollection controls1 = this.plhOrdAddOptions.Controls;
                        accountID = new object[] { "<label class='Visibilityhidden' id='lblOrderAddValue_", num11, "'> ", row4["SelectedValue"].ToString(), "</label><br/>" };
                        controls1.Add(new LiteralControl(string.Concat(accountID)));
                        this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                        ControlCollection controlCollections1 = this.plhOrdAddOptionsPrice.Controls;
                        accountID = new object[] { "<label class='Visibilityhidden' id='lblOrderAddPrice_", num11, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row4["TotalPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(accountID)));
                        this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plhOrdAddOptions.Controls.Add(new LiteralControl("<div style='padding-right:60px;' class='additionalDiv_padding_4px_0px'>"));
                        ControlCollection controls2 = this.plhOrdAddOptions.Controls;
                        accountID = new object[] { "<label id='lblOrderAddValue_", num11, "'> ", row4["SelectedValue"].ToString(), "</label><br/>" };
                        controls2.Add(new LiteralControl(string.Concat(accountID)));
                        this.plhOrdAddOptions.Controls.Add(new LiteralControl("</div>"));
                        this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("<div class='additionalDiv_padding_4px_0px'>"));
                        ControlCollection controlCollections2 = this.plhOrdAddOptionsPrice.Controls;
                        accountID = new object[] { "<label id='lblOrderAddPrice_", num11, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row4["TotalPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(accountID)));
                        this.plhOrdAddOptionsPrice.Controls.Add(new LiteralControl("</div>"));
                    }
                    num12 = num12 + Convert.ToDecimal(row4["TotalPrice"]);
                    num3 = num3 + Convert.ToDecimal(row4["OrderAdditionalTaxValue"]);
                    num11++;
                }
                this.lbl_subTotal_cost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num1, 2, "", false, false, true);
                num5 = (this.OrderKey.ToString().ToLower().Contains("job") || this.OrderKey.ToString().ToLower().Contains("inv") ? num8 + num3 : num2 + num3);
                string empty2 = string.Empty;
                foreach (DataRow dataRow4 in ProductBasePage.GetTaxDetailsByTaxID(this.CompanyID, num6).Rows)
                {
                    Convert.ToInt64(dataRow4["TaxID"].ToString());
                    dataRow4["TaxName"].ToString();
                    Convert.ToDecimal(dataRow4["TaxRate"].ToString());
                }
                this.lbl_tax.Text = this.objLanguage.GetLanguageConversion("Total_Tax");
                this.lbl_TaxValue.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num5, 2, "", false, false, true);
                this.lbl_grandTotal_cost.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num5) + num12, 2, "", false, false, true));
                this.Session["fromEmail"] = "";
            }
            if (this.comm.GetDisplayValue("isCheckPaymentInfo", OrderApproval.AccountID) == "false" && this.lbl_Payment.Text.Trim().Length == 0)
            {
                this.PaymentMode_Style = "display: none;";
                this.div_paymentmode.Style.Add("display", "none");
            }
            ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
            ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
            if (this.IsEnableHidePrice == "true")
            {
                this.tdunitprice.Style.Add("display", "none");
                this.tdtotalprice.Style.Add("display", "none");
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
        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShipping_Address(AddressID).Rows)
            {
                string[] strArrays = row["Address"].ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        if (i == 0 && strArrays[0].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[0], "<br/>");
                        }
                        if (i == 1 && strArrays[1].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[1], "<br/>");
                        }
                        if (i == 2 && strArrays[2].Length >= 2)
                        {
                            empty = (strArrays[3].Length >= 2 || strArrays[4].Length >= 2 ? string.Concat(empty, strArrays[2], ",") : string.Concat(empty, strArrays[2]));
                        }
                        if (i == 3 && strArrays[3].Length >= 2)
                        {
                            empty = (strArrays[4].Length < 2 ? string.Concat(empty, strArrays[3]) : string.Concat(empty, strArrays[3], ","));
                        }
                        if (i == 4 && strArrays[4].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[4]);
                        }
                        if (i == 5 && strArrays[5].Length >= 2)
                        {
                            empty = string.Concat(empty, "<br/>", strArrays[5], "<br/>");
                        }
                        if (i == 6 && strArrays[6].Length >= 2)
                        {
                            empty = string.Concat(empty, "<br/>T:&nbsp; ", strArrays[6], "<br/>");
                        }
                        if (i == 7 && strArrays[7].Length >= 2)
                        {
                            empty = (strArrays[6].Length != 1 ? string.Concat(empty, "F:&nbsp;", strArrays[7], "<br/>") : string.Concat(empty, "<br/>F:&nbsp; ", strArrays[7], "<br/>"));
                        }
                    }
                }
            }
            Address = empty;
        }

        public DataTable StoreUser_select(long StoreUserID)
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