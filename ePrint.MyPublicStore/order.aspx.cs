using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore
{
    public partial class order : BaseClass, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lblOrderNo;

        //protected Label lbl_OrderNo;

        //protected Label lblname;

        //protected Label lbl_name;

        //protected Label lblemail;

        //protected Label lbl_email;

        //protected Label lblUserRefOrderNo;

        //protected Label lbl_UserRefOrderNo;

        //protected Label lblOrderTitle;

        //protected Label lbl_OrderTitle;

        //protected Label lblPayment;

        //protected HtmlGenericControl div_Paymentmode;

        //protected Label lbl_Payment;

        //protected Label lblOrderDate;

        //protected Label lbl_OrderDate;

        //protected Label lbldeliverydate;

        //protected Label lbl_DeliveryDate;

        //protected Label lblStatus;

        //protected Label lbl_Status;

        //protected Label lblConsignmentNoteNumber;

        //protected Label lbl_ConsignmentNoteNumber;

        //protected Label lblCouponCode;

        //protected Label lblCoupon_Code;

        //protected HtmlGenericControl Div_CouponCode;

        //protected Label lblConsigneeurl;

        //protected Label lbl_ShippingAddressID;

        //protected HtmlGenericControl divShippingAddress;

        //protected Label lbl_ShippingAddress;

        //protected HtmlGenericControl Order_ShippingAddress;

        //protected Label lbl_BliingAddressID;

        //protected Label lbl_BliingAddress;

        //protected HtmlGenericControl order_billingAddress;

        //protected PlaceHolder plhorder;

        //protected Label lbl_subTotal;

        //protected PlaceHolder plhOrdAddOptions;

        //protected Label lbl_tax;

        //protected Label lbl_grandTotal;

        //protected Label lbl_subTotal_cost;

        //protected PlaceHolder plhOrdAddOptionsPrice;

        //protected Label lbl_TaxValue;

        //protected Label lbl_grandTotal_cost;

        //protected HtmlGenericControl Order_area;

        //protected System.Web.UI.ScriptManager SM;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        public commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public char KeySeparator;

        public int CompanyID;

        public int ProductID;

        public long CartID;

        public long StoreUserID;

        public long OrderID;

        public static long AccountID;

        private string NewSessionID = string.Empty;

        public string imageName = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string Address = string.Empty;

        public string OrderKey = string.Empty;

        public string SystemName = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public static string imagePath;

        public string IsPPW = string.Empty;

        public bool IsPPW_SystemName;

        private string MeasurementValue = string.Empty;

        public string OrdID = string.Empty;

        public string isCBOOrderTitle = "1";

        public string HideAddress = string.Empty;

        public string consigneeurl = string.Empty;

        public bool IsCumulative;

        public bool ISCouponCodeEnabled;

        public bool IsCouponCodeApplied;

        public string CouponCodeDiscount = string.Empty;

        public string PDFToURLPath = string.Empty;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] text;
            object[] accountID;
            string empty = string.Empty;
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                order.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
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
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
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
            if (this.comm.GetDisplayValue("IsHome", order.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(this.CompanyID, Convert.ToInt32(order.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.comm.GetDisplayValue("isCheckInvoiceInfo", order.AccountID) == "false")
            {
                this.order_billingAddress.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryInfo", order.AccountID) == "false")
            {
                this.Order_ShippingAddress.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckAddressInfo", order.AccountID) == "false")
            {
                this.HideAddress = "yes";
                this.order_billingAddress.Style.Add("display", "none");
                this.Order_ShippingAddress.Style.Add("display", "none");
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                if (RewriteContext.Current.Params["OrdKey"] != null)
                {
                    string str = RewriteContext.Current.Params["OrdKey"].ToString();
                    char[] keySeparator = new char[] { this.KeySeparator };
                    this.OrderKey = str.Split(keySeparator)[1].ToString();
                }
            }
            else if (base.Request.Params["OrdKey"] != null)
            {
                this.OrderKey = base.Request.Params["OrdKey"].ToString();
            }
            foreach (DataRow row in OrderBasePage.Select_OrderID(this.OrderKey, this.StoreUserID).Rows)
            {
                this.OrdID = row["OrderID"].ToString();
            }
            this.NewSessionID = this.comm.UniqueID;
            if (!base.IsPostBack && this.StoreUserID != (long)0)
            {
                int num = 0;
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = 0;
                decimal num5 = new decimal(0);
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                string str4 = string.Empty;
                int num6 = 0;
                string empty5 = string.Empty;
                long num7 = (long)0;
                DataTable dataTable = OrderBasePage.Select_OrderItems(this.OrdID, this.StoreUserID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.ISCouponCodeEnabled = Convert.ToBoolean(dataRow["ISCouponCodeEnabled"]);
                    if (this.IsCouponCodeApplied)
                    {
                        continue;
                    }
                    str3 = dataRow["UserFriendlyName"].ToString();
                    empty4 = dataRow["CouponCode"].ToString();
                    this.IsCouponCodeApplied = Convert.ToBoolean(dataRow["IsCouponCodeApplied"]);
                    str4 = dataRow["CouponCodeDiscount"].ToString();
                }
                if (this.IsCouponCodeApplied)
                {
                    empty1 = "style='width:214px;'";
                    empty2 = "style='width:100px;'";
                    empty3 = "style='width:248px;'";
                    str2 = "style='width:94px;'";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "myFunction", "OrderCouponStyle();", true);
                }
                if (this.IsCouponCodeApplied)
                {
                    this.Div_CouponCode.Style.Add("display", "block");
                    Label lblCouponCode = this.lblCoupon_Code;
                    text = new string[] { base.SpecialDecode(str3), "(", base.SpecialDecode(empty4), ") - ", str4 };
                    lblCouponCode.Text = string.Concat(text);
                }
                decimal num8 = new decimal(0);
                this.plhorder.Controls.Add(new LiteralControl("<table class='b_productName_table'>"));
                this.plhorder.Controls.Add(new LiteralControl("<tr>"));
                this.plhorder.Controls.Add(new LiteralControl("<td id='h_productName'></td>"));
                this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td id='h_productName'><strong>", this.objLanguage.GetLanguageConversion("Product_Name"), " </strong></td>")));
                this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td id='h_productDescription'><strong>", this.objLanguage.GetLanguageConversion("Product_Description"), " </strong></td>")));
                ControlCollection controls = this.plhorder.Controls;
                string[] languageConversion = new string[] { "<td id='h_productPrice2'><strong>", this.objLanguage.GetLanguageConversion("Unit_Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></td>" };
                controls.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td id='h_TaxApplicable'><strong>", this.objLanguage.GetLanguageConversion("Tax_applicable"), " </strong></td>")));
                this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td id='h_productQty'><strong>", this.objLanguage.GetLanguageConversion("Qty"), " </strong></td>")));
                if (this.IsCouponCodeApplied)
                {
                    ControlCollection controlCollections = this.plhorder.Controls;
                    string[] strArrays = new string[] { "<td id='h_productCouponCodeDiscount' style='width:85px;'><strong>", this.objLanguage.GetLanguageConversion("Discount"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></td>" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                }
                ControlCollection controls1 = this.plhorder.Controls;
                string[] languageConversion1 = new string[] { "<td id='h_productTotal'><strong>", this.objLanguage.GetLanguageConversion("Total_ex_Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></td>" };
                controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
                this.plhorder.Controls.Add(new LiteralControl("</tr>"));
                foreach (DataRow row1 in dataTable.Rows)
                {
                    this.IsCumulative = Convert.ToBoolean(row1["IsCumulativePricing"].ToString());
                    empty = (row1["PDFNameFromCart"].ToString() != "" || row1["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(row1["IsPrintReadyFile"]) ? "Style='display:block;float:left;'" : "Style='display:none;float:left;'");
                    num4 = Convert.ToInt32(row1["createdBy"].ToString());
                    Convert.ToDecimal(row1["Tax1"]);
                    this.lbl_name.Text = base.SpecialDecode(string.Concat(row1["FirstName"].ToString(), " ", row1["LastName"].ToString()));
                    this.lbl_email.Text = base.SpecialDecode(row1["EmailID"].ToString());
                    this.lbl_OrderNo.Text = base.SpecialDecode(row1["OrderNo"].ToString());
                    if (row1["PaymentType"].ToString() != this.objLanguage.GetLanguageConversion("Braintree_Credit_Card"))
                    {
                        this.lbl_Payment.Text = row1["PaymentType"].ToString();
                    }
                    else
                    {
                        this.lbl_Payment.Text = this.objLanguage.GetLanguageConversion("Credit_Card");
                    }
                    this.lbl_OrderDate.Text = this.comm.Eprint_return_Date_Before_View(row1["OrderDate"].ToString(), this.CompanyID, num4, false);
                    this.lbl_DeliveryDate.Text = this.comm.Eprint_return_Date_Before_View(row1["Requiredby"].ToString(), this.CompanyID, num4, false);
                    num6 = Convert.ToInt32(row1["orderitemID"]);
                    this.lbl_OrderTitle.Text = base.SpecialDecode(row1["OrderTitle"].ToString());
                    this.lbl_UserRefOrderNo.Text = base.SpecialDecode(row1["UserRefOrderNo"].ToString());
                    this.OrderID = Convert.ToInt64(row1["OrderID"]);
                    DataTable dataTable1 = OrderBasePage.Order_Status(Convert.ToInt64(row1["OrderID"]), Convert.ToInt64(row1["EstimateID"].ToString()));
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        this.lbl_Status.Text = base.SpecialDecode(dataRow1["UserFriendlyName"].ToString());
                    }
                    empty5 = base.SpecialDecode(row1["ConsignmentNumber"].ToString());
                    if (empty5 == "")
                    {
                        this.lbl_ConsignmentNoteNumber.Text = "Pending";
                    }
                    else
                    {
                        this.lbl_ConsignmentNoteNumber.Text = empty5.ToString();
                    }
                    this.consigneeurl = row1["consigneeUrl"].ToString();
                    num7 = Convert.ToInt64(row1["ContactID"]);
                    this.Return_address(this.StoreUserID, "", num7, Convert.ToInt64(row1["BillingAddressID"]), out this.Address);
                    this.lbl_BliingAddress.Text = base.SpecialDecode(this.Address);
                    this.Return_address(this.StoreUserID, "", num7, Convert.ToInt64(row1["ShippingAddressID"]), out this.Address);
                    this.lbl_ShippingAddress.Text = base.SpecialDecode(this.Address);
                    if (this.lbl_BliingAddress.Text == "")
                    {
                        this.order_billingAddress.Attributes.Add("style", "display:none");
                    }
                    if (this.lbl_ShippingAddress.Text == "")
                    {
                        this.divShippingAddress.Attributes.Add("style", "display:none");
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<tr class='b_productName_tr' >"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_PDF_td' >"));
                    this.plhorder.Controls.Add(new LiteralControl("<div class='divicon'>"));
                    string str5 = string.Empty;
                    if (row1["PrintReadyFile"].ToString() != "")
                    {
                        str5 = "printready";
                        if (ConnectionClass.ServerName.ToLower() == "creativeatlanta" || ConnectionClass.ServerName.ToLower() == "creativeapproach")
                        {
                            ControlCollection controlCollections1 = this.plhorder.Controls;
                            accountID = new object[] { "<img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Template / Print Ready Requirement' alt=' ' border='0' onclick='javascript:Pdf_Open(\"", row1["PrintReadyFile"].ToString(), "\",", order.AccountID, ",\"", str5, "\");' ", empty, "/>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        else
                        {
                            ControlCollection controls2 = this.plhorder.Controls;
                            accountID = new object[] { "<img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' border='0' onclick='javascript:Pdf_Open(\"", row1["PrintReadyFile"].ToString(), "\",", order.AccountID, ",\"", str5, "\");' ", empty, "/>" };
                            controls2.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    else if (row1["PDFNameFromCart"].ToString() != "")
                    {
                        if (row1["PreviewType"].ToString() == "" || row1["PreviewType"].ToString() == "pdfimg" || row1["PreviewType"].ToString() == "pdf")
                        {
                            str5 = "pdf";
                            ControlCollection controlCollections2 = this.plhorder.Controls;
                            accountID = new object[] { "<img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' border='0' onclick='javascript:Pdf_Open(\"", row1["PDFNameFromCart"].ToString(), "\",", order.AccountID, ",\"", str5, "\");' ", empty, "/>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        if (row1["ImageNameFromCart"].ToString() != "" && (row1["PreviewType"].ToString() == "pdfimg" || row1["PreviewType"].ToString() == "img"))
                        {
                            str5 = "previewimage";
                            ControlCollection controls3 = this.plhorder.Controls;
                            accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", row1["ImageNameFromCart"].ToString(), "\",", order.AccountID, ",\"", this.strSitepath, "\",\"", str5, "\");'/></div>" };
                            controls3.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    if (row1["UploadFile"].ToString() != "" || row1["UploadFile1"].ToString() != "" || row1["UploadFile2"].ToString() != "")
                    {
                        ControlCollection controlCollections3 = this.plhorder.Controls;
                        accountID = new object[] { "<a ><img id='img_Edit_", num, "' onclick=Javascript:openArtworkPopup(", row1["CartItemID"].ToString(), ",", row1["OrderItemID"].ToString(), ",'", this.OrdID, "') class='floatLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", order.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productName_td_order' ", empty1, "><div style='width:200px;'>")));
                    Label label = new Label()
                    {
                        ID = string.Concat("lblproductName_", num),
                        Text = base.SpecialDecode(row1["CatalogueName"].ToString())
                    };
                    if (row1["MatrixType"].ToString().ToLower() == "g")
                    {
                        string str6 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["OrderedWidth"].ToString()), 2, "", false, false, true);
                        string str7 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["OrderedHeight"].ToString()), 2, "", false, false, true);
                        text = new string[] { label.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str6, " </label><br/><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str7, " </label></span>" };
                        label.Text = string.Concat(text);
                    }
                    this.plhorder.Controls.Add(label);
                    int num9 = 0;
                    foreach (DataRow row2 in OrderBasePage.Select_OrderAdditionalItems(Convert.ToInt64(num6)).Rows)
                    {
                        if (Convert.ToInt32(row2["CheckCount"]) <= 0)
                        {
                            break;
                        }
                        if (Convert.ToInt32(row2["OptionID"]) <= 0)
                        {
                            continue;
                        }
                        if (num9 == 0)
                        {
                            this.plhorder.Controls.Add(new LiteralControl(string.Concat("<br/><div class='marginTop5'><Strong><label><i>", this.objLanguage.GetLanguageConversion("Additional_Items"), "</i></label></Strong></div>")));
                        }
                        this.plhorder.Controls.Add(new LiteralControl("<div>"));
                        Label label1 = new Label();
                        accountID = new object[] { "lblOthercostName_", num, "_", num9 };
                        label1.ID = string.Concat(accountID);
                        label1.Text = base.SpecialDecode(row2["UserFriendlyName"].ToString().Trim());
                        this.plhorder.Controls.Add(label1);
                        this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        if (row2["MainCalculationType"].ToString().ToLower() == "c")
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<div class='Order_paddingLeft5'>"));
                            Label label2 = new Label();
                            accountID = new object[] { "lblSelectedValue_", num, "_", num9 };
                            label2.ID = string.Concat(accountID);
                            label2.Text = base.SpecialDecode(row2["SelectedValue"].ToString().Trim());
                            label2.Attributes.Add("style", "padding-left:6px; font-size:11px;");
                            this.plhorder.Controls.Add(label2);
                            this.plhorder.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        num9++;
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productDescription_td_order' ", empty3, "><div style='width:200px;'>")));
                    Label label3 = new Label()
                    {
                        ID = string.Concat("lblproductDescription_", num),
                        Text = base.SpecialDecode(row1["description"].ToString())
                    };
                    this.plhorder.Controls.Add(label3);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productPrice_td' ", empty2, "><div style='width:90px;float:right'")));
                    decimal num10 = new decimal(0);
                    if (row1["Quantity"].ToString() != "")
                    {
                        if (Convert.ToDecimal(row1["Quantity"].ToString()) != new decimal(0))
                        {
                            num10 = (!this.IsCumulative || Convert.ToInt32(row1["ProductId"].ToString()) == 0 ? Convert.ToDecimal(row1["SubTotal"].ToString()) / Convert.ToDecimal(row1["Quantity"].ToString()) : Convert.ToDecimal(row1["SubTotal"].ToString()) / Convert.ToDecimal(this.SimpleMatrixCumulativePriceingQty(Convert.ToInt32(row1["Quantity"].ToString()), Convert.ToInt32(row1["ProductId"].ToString()))));
                        }
                        else
                        {
                            num10 = Convert.ToDecimal(row1["SubTotal"].ToString());
                        }
                    }
                    Label label4 = new Label()
                    {
                        ID = string.Concat("lblproductPrice_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num10, 2, "", false, false, true)
                    };
                    this.plhorder.Controls.Add(label4);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_TaxApplicable_td_order'><div style='width:110px;'>"));
                    Label label5 = new Label()
                    {
                        ID = string.Concat("lblTaxApplicable_", num),
                        Text = string.Concat(row1["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["TaxRate"]), 2, "", false, false, true)), "%")
                    };
                    this.plhorder.Controls.Add(label5);
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productQty_td_order'><div style='width:66px;float:right'>"));
                    Label label6 = new Label()
                    {
                        ID = string.Concat("lblproductQty_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Quantity"].ToString()), 0, "", true, false, true)
                    };
                    this.plhorder.Controls.Add(label6);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    if (this.IsCouponCodeApplied)
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<td class='b_productQty_td_order'><div style='90px'>"));
                        Label label7 = new Label()
                        {
                            ID = string.Concat("lblCouponCodeDiscount_", num),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label7);
                        this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    }
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productTotal_td_order' ", str2, "><div style='width: 94px;float:right'>")));
                    Label label8 = new Label()
                    {
                        ID = string.Concat("lblproductTotal_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["SubTotal"].ToString()), 2, "", false, false, true)
                    };
                    num1 = num1 + Convert.ToDecimal(row1["SubTotal"].ToString());
                    num3 = num3 + Convert.ToDecimal(row1["OrderItemTax"]);
                    this.plhorder.Controls.Add(label8);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productTotal_td1'><div class='displayNone'>"));
                    Label label9 = new Label()
                    {
                        ID = string.Concat("lblproductTax_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["OrderItemTax"].ToString()), 2, "", false, false, true)
                    };
                    this.plhorder.Controls.Add(label9);
                    this.plhorder.Controls.Add(new LiteralControl("</td></tr>"));
                    num++;
                    num8 = Convert.ToDecimal(row1["tax"].ToString());
                }
                this.plhorder.Controls.Add(new LiteralControl("</table>"));
                int num11 = 0;
                decimal num12 = new decimal(0);
                foreach (DataRow dataRow2 in OrderBasePage.Select_OrderAdditionalOptions(this.StoreUserID, this.OrderID).Rows)
                {
                    ControlCollection controls4 = this.plhOrdAddOptions.Controls;
                    accountID = new object[] { "<label id='lblOrderAddValue_", num11, "'> ", dataRow2["SelectedValue"].ToString(), "</label><br/>" };
                    controls4.Add(new LiteralControl(string.Concat(accountID)));
                    ControlCollection controlCollections4 = this.plhOrdAddOptionsPrice.Controls;
                    accountID = new object[] { "<label id='lblOrderAddPrice_", num11, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow2["TotalPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(accountID)));
                    num12 = num12 + Convert.ToDecimal(dataRow2["TotalPrice"]);
                    num2 = num2 + Convert.ToDecimal(dataRow2["OrderAdditionalTaxValue"]);
                    num11++;
                }
                this.lbl_subTotal_cost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num1, 2, "", false, false, true);
                num5 = (this.OrderKey.ToLower().Contains("-inv") || this.OrderKey.ToLower().Contains("-job") ? num8 + num2 : num3 + num2);
                this.lbl_TaxValue.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num5, 2, "", false, false, true);
                this.lbl_grandTotal_cost.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num5) + num12, 2, "", false, false, true));
                this.Session["fromEmail"] = "";
            }
            string displayValue = this.comm.GetDisplayValue("OrderTitleText", order.AccountID);
            this.lblOrderTitle.Text = string.Concat(displayValue, ":");
            string displayValue1 = this.comm.GetDisplayValue("OrderNumberText", order.AccountID);
            this.lblUserRefOrderNo.Text = string.Concat(displayValue1, ":");
            string displayValue2 = this.comm.GetDisplayValue("DeliveryRequiredByText", order.AccountID);
            this.lbldeliverydate.Text = string.Concat(displayValue2, ":");
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
            if (this.comm.GetDisplayValue("isCBOOrderTitle", order.AccountID) == "false")
            {
                this.isCBOOrderTitle = "0";
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
            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", order.AccountID) == "true")
            {
                this.lbldeliverydate.Style.Add("display", "block");
                this.lbl_DeliveryDate.Style.Add("display", "block");
                return;
            }
            this.lbldeliverydate.Style.Add("display", "none");
            this.lbl_DeliveryDate.Style.Add("display", "none");
        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(AddressID)).Rows)
            {
                if (Convert.ToInt64(row["AddressID"].ToString()) != AddressID)
                {
                    continue;
                }
                string[] strArrays = row["Address"].ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        if (i != 6)
                        {
                            empty = (i != 7 ? string.Concat(empty, strArrays[i], "<br/>") : string.Concat(empty, "F: ", strArrays[i], "<br/>"));
                        }
                        else
                        {
                            empty = string.Concat(empty, "T: ", strArrays[i], "<br/>");
                        }
                    }
                }
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
    }
}