using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
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
    public partial class ShoppingCart : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected HtmlGenericControl div_NavigationID;

        //protected HiddenField hdnChecked;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected HtmlGenericControl productAdded;

        //protected Label lblNotifyGprunDiscount;

        //protected PlaceHolder plh_CartItems;

        //protected HtmlGenericControl div_ShoppingItems;

        //protected Label lblgrandTotal;

        //protected Label lbl_grandTotal;

        //protected HtmlGenericControl div_grandTotal;

        //protected Button btn_proceedCheckout;

        //protected HtmlGenericControl grandTotal_div;

        //protected HtmlGenericControl Shoppingcard_div;

        //protected HiddenField hid_ItemsLength;

        //protected HiddenField hid_finalSave;

        //protected HiddenField hid_TotalExTax;

        //protected HiddenField hid_TotalIncTax;

        //protected HiddenField hid_TotalQty;

        //protected HiddenField hid_QuestionLenght;

        //protected HiddenField hid_MultipleLenght;

        //protected HiddenField hid_MatrixLenght;

        //protected HiddenField hid_SaveToAdditionalItems;

        //protected HiddenField hdnCartItemCount;

        //protected HiddenField hdnJobScreenNAmeForAlert;

        //protected HiddenField hid_MultiplePrice;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public char KeySeparator;

        public bool IsCartmandatory;

        public int CompanyID;

        public int ProductID;

        public long CartID;

        public long cardid;

        public long productid_new;

        public long StoreUserID;

        public static long AccountID;

        public long CartItemID;

        public int Orderid;

        public string NewSessionID = string.Empty;

        public string strSitepath = string.Empty;

        public string imageName = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string FileExtension = string.Empty;

        public string AccountType = string.Empty;

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        public string HelpText = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string displayStyle = "style='display:block;'";

        public string displaySubTotal = "style='display:block;'";

        public string StatusTitle = string.Empty;

        public string SystemName = string.Empty;

        public static string CatalogueName;

        public static string imagePath;

        public string isCartJobName = "0";

        public string isCartUnitPrice = "0";

        public string isCartTotal = "0";

        public string isCartSubtotal = "0";

        public string isCartGrandTotal = "0";

        public string Order_Deltd_Prod_Msg1 = string.Empty;

        public string Order_Deltd_Prod_Msg2 = string.Empty;

        public string Order_Deltd_Prod_Msg3 = string.Empty;

        public string Order_Deltd_Prod_Msg4 = string.Empty;

        private string MeasurementValue = string.Empty;

        public string ProductStockManagement = string.Empty;

        public string OrderKey = string.Empty;

        public string isCheckOrderInfoPublic = string.Empty;

        public string isCheckAddressInfo = string.Empty;

        public bool ISCouponCodeEnabled;

        public string CouponCodeDisplay = "style='display:none;'";

        public string MainProductName = string.Empty;

        public long MainProductId;

        public string PDFToURLPath = string.Empty;

        public string CartJobScreenName = string.Empty;

        public string CartJobScreenNameForAlert = string.Empty;

        public bool CartJobNameIsMandatory;

        public bool CartJobScreenNameShow;

        protected Random rGen;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

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

        static ShoppingCart()
        {
            ShoppingCart.AccountID = (long)0;
            ShoppingCart.CatalogueName = string.Empty;
            ShoppingCart.imagePath = string.Empty;
        }

        public ShoppingCart()
        {
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

        public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type, string ActionType, int SelectedID)
        {
            if (Type != "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "Label";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            else
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["SelectedID"]) == SelectedID)
                    {
                        ddlMutiple.SelectedIndex = num;
                    }
                    num++;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] languageConversion;
            this.OrderKey = this.GenPassWithCap(12);
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            this.btn_proceedCheckout.Text = this.objLanguage.GetLanguageConversion("Proceed_To_Checkout");
            if (this.Session["ProductStockManagement"] != null)
            {
                this.ProductStockManagement = this.Session["ProductStockManagement"].ToString().Trim().ToLower();
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                ShoppingCart.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Cart", Convert.ToInt32(this.CompanyID), Convert.ToInt32(ShoppingCart.AccountID));
            if (ConnectionClass.ImagePath != null)
            {
                ShoppingCart.imagePath = ConnectionClass.ImagePath.ToString();
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                this.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.SystemName != null)
            {
                this.SystemName = ConnectionClass.SystemName.ToLower().Trim();
            }
            if (this.Session["StatusTitle"] != null)
            {
                this.StatusTitle = this.Session["StatusTitle"].ToString();
            }
            if (this.Session["IsPPW"] != null && this.Session["IsPPW"].ToString() == "1")
            {
                this.IsPPW = "1";
            }
            if (base.Request.Params["type"] != null)
            {
                this.productAdded.Style.Add("display", "block");
                this.lblSucess.Text = "Proceed further to ReOrder your selected Order";
            }
            if (base.Request.Params["OrderID"] != null)
            {
                this.Orderid = Convert.ToInt32(base.Request.Params["OrderID"]);
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            this.AccountType = this.comm.return_AccountType((long)this.CompanyID, ShoppingCart.AccountID);
            DataTable dataTable = new DataTable();
            dataTable = CartBasePage.eStore_Visibility_Settings_Select(this.CompanyID, Convert.ToInt32(ShoppingCart.AccountID));
            foreach (DataRow row in dataTable.Rows)
            {
                this.CartJobNameIsMandatory = Convert.ToBoolean(row["CartJobNameIsMandatory"]);
                this.CartJobScreenNameShow = Convert.ToBoolean(row["CartJobNameShow"]);
                this.CartJobScreenName = row["CartJobScreenName"].ToString();
                this.CartJobScreenNameForAlert = base.SpecialEncode(row["CartJobScreenName"].ToString());
            }
            if (!this.CartJobScreenNameShow)
            {
                this.isCartJobName = "0";
            }
            else
            {
                this.isCartJobName = "1";
            }
            if (this.comm.GetDisplayValue("isCartUnitPrice", ShoppingCart.AccountID) != "true")
            {
                this.isCartUnitPrice = "0";
            }
            else
            {
                this.isCartUnitPrice = "1";
            }
            if (this.comm.GetDisplayValue("isCartTotal", ShoppingCart.AccountID) != "true")
            {
                this.isCartTotal = "0";
            }
            else
            {
                this.isCartTotal = "1";
            }
            if (this.comm.GetDisplayValue("isCartSubtotal", ShoppingCart.AccountID) != "true")
            {
                this.isCartSubtotal = "0";
            }
            else
            {
                this.isCartSubtotal = "1";
            }
            if (this.comm.GetDisplayValue("isCartGrandTotal", ShoppingCart.AccountID) != "true")
            {
                this.isCartGrandTotal = "0";
            }
            else
            {
                this.isCartGrandTotal = "1";
            }
            if (this.Session["StoreUserID"] != null)
            {
                if (this.comm.GetDisplayValue("IsHome", ShoppingCart.AccountID) != "true")
                {
                    this.lbl_home.Visible = false;
                    this.lbl_spliter.Visible = false;
                }
                else
                {
                    this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(ShoppingCart.AccountID), 0);
                    this.lbl_home.Visible = true;
                    this.lbl_spliter.Visible = true;
                }
                this.isCheckOrderInfoPublic = this.comm.GetDisplayValue("isCheckOrderInfoPublic", ShoppingCart.AccountID).ToLower().Trim();
                this.isCheckAddressInfo = this.comm.GetDisplayValue("isCheckAddressInfo", ShoppingCart.AccountID).ToLower().Trim();
            }
            else if (this.AccountType != "x")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else if (this.comm.GetDisplayValue("IsHome", ShoppingCart.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(ShoppingCart.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.isCartSubtotal == "0")
            {
                this.displaySubTotal = "style='display:none;'";
                this.displayStyle = "style='display:none;'";
            }
            if (this.Session["StoreUserID"] == null && this.AccountType.ToLower() == "p" || this.CompanyID == 0 && ShoppingCart.AccountID == (long)0)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                }
            }
            HtmlImage htmlImage = this.imgSucess;
            object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=i_msg-success.gif&amp;type=r&amp;aid=", ShoppingCart.AccountID, " &amp;cid=", this.CompanyID };
            htmlImage.Src = string.Concat(accountID);
            if (!base.IsPostBack)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    if (base.Request.Params["ID"] != null)
                    {
                        this.cardid = (long)Convert.ToInt32(base.Request.Params["ID"]);
                    }
                    if (base.Request.Params["PID"] != null)
                    {
                        this.productid_new = (long)Convert.ToInt32(base.Request.Params["PID"]);
                    }
                }
                else
                {
                    if (RewriteContext.Current.Params["ID"] != null)
                    {
                        string str = RewriteContext.Current.Params["ID"].ToString();
                        char[] keySeparator = new char[] { this.KeySeparator };
                        this.cardid = (long)Convert.ToInt32(str.Split(keySeparator)[1]);
                    }
                    if (RewriteContext.Current.Params["PID"] != null)
                    {
                        this.productid_new = (long)Convert.ToInt32(RewriteContext.Current.Params["PID"].ToString());
                    }
                }
                if (this.cardid == (long)0)
                {
                    long productidNew = this.productid_new;
                    long num = (long)0;
                }
                this.NewSessionID = this.comm.UniqueID;
            }
            this.Order_Deltd_Prod_Msg1 = this.objLanguage.GetLanguageConversion("Multiple_Products");
            this.Order_Deltd_Prod_Msg2 = this.objLanguage.GetLanguageConversion("Deleted_Product_Proceed_To_CheckOut_Msg");
            this.Order_Deltd_Prod_Msg3 = this.objLanguage.GetLanguageConversion("Deleted_Product_Proceed_To_CheckOut_Msg_Single");
            this.Order_Deltd_Prod_Msg4 = this.objLanguage.GetLanguageConversion("Single_Product");
            try
            {
                if (this.cardid != (long)0)
                {
                    this.productAdded.Style.Add("display", "block");
                    foreach (DataRow dataRow in CartBasePage.Select_CartItems(this.NewSessionID, "label", this.StoreUserID).Rows)
                    {
                        this.lblSucess.Text = string.Concat(base.SpecialDecode(dataRow["CatalogueName"].ToString()), this.objLanguage.GetLanguageConversion("added_to_your_shopping_cart"));
                        ShoppingCart.CatalogueName = ConnectionClass.RemoveIllegalChars(dataRow["CatalogueName"].ToString());
                    }
                }
                DataTable dataTable1 = CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID);
                IEnumerator enumerator = dataTable1.Rows.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        this.ISCouponCodeEnabled = Convert.ToBoolean(current["ISCouponCodeEnabled"]);
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
                if (this.ISCouponCodeEnabled)
                {
                    this.CouponCodeDisplay = "style='display:block;border-left: none;border-right: none;'";
                }
                this.plh_CartItems.Controls.Add(new LiteralControl("<table id='shippingCart_Table' class='ShoppingCart_HeaderFooter' cellspacing='0' cellpadding='0'>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<tr><th></th><th></th>"));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignLeft fontBold' style='min-width:80px' >", this.objLanguage.GetLanguageConversion("Product_Name"), "</th>")));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignLeft fontBold' style='min-width:100px'>", this.objLanguage.GetLanguageConversion("Product_Description"), "</th>")));
                if (this.isCartJobName != "1")
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignLeft fontBold displayNone'  >", this.objLanguage.GetLanguageConversion("Job_Name"), "</th>")));
                }
                else
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignLeft fontBold' style='width: 120px;r'>", this.CartJobScreenName, "</th>")));
                }
                if (this.isCartUnitPrice != "1")
                {
                    ControlCollection controls = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='textalignRight fontBold displayNone'  style='min-width:100px' >", this.objLanguage.GetLanguageConversion("Unit_Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    ControlCollection controlCollections = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='textalignRight fontBold' style='min-width:100px;'>", this.objLanguage.GetLanguageConversion("Unit_Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='fontBold' style='width:110px;'>", this.objLanguage.GetLanguageConversion("Tax_Applicable"), " </th>")));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignRight fontBold' style='min-width:80px;'>", this.objLanguage.GetLanguageConversion("Qty"), " </th>")));
                if (!this.ISCouponCodeEnabled)
                {
                    ControlCollection controls1 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='textalignRight fontBold displayNone'>", this.objLanguage.GetLanguageConversion("Discount"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    ControlCollection controlCollections1 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='textalignRight fontBold' style='border-bottom: none;width:88px;'>", this.objLanguage.GetLanguageConversion("Discount"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (this.isCartTotal != "1")
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignRight fontBold displayNone'>Tax(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>")));
                    ControlCollection controls2 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='displayNone' style='text-align:center;min-width:100px'>", this.objLanguage.GetLanguageConversion("Total_ex_Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th></tr>" };
                    controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    ControlCollection controlCollections2 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th class='textalignRight fontBold displayNone'>", this.objLanguage.GetLanguageConversion("Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th class='textalignRight fontBold' style='width:102px;padding-left:4px'>", this.objLanguage.GetLanguageConversion("Total_ex_Tax"), "</th></tr>")));
                }
                if (this.cardid != (long)0)
                {
                    this.productAdded.Style.Add("display", "block");
                    foreach (DataRow row1 in CartBasePage.Select_CartItems(this.NewSessionID, "label", this.StoreUserID).Rows)
                    {
                        this.lblSucess.Text = string.Concat(base.SpecialDecode(row1["CatalogueName"].ToString()), this.objLanguage.GetLanguageConversion("added_to_your_shopping_cart"));
                        ShoppingCart.CatalogueName = ConnectionClass.RemoveIllegalChars(row1["CatalogueName"].ToString());
                    }
                }
                int num1 = 0;
                int num2 = 0;
                string empty = string.Empty;
                //if (!base.IsPostBack)
                //{
                    this.hdnCartItemCount.Value = Convert.ToString(dataTable1.Rows.Count);
                    string empty1 = string.Empty;
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        if (Convert.ToInt64(dataRow1["MainProductID"]) != (long)0)
                        {
                            this.MainProductName = CartBasePage.Select_MainProductName(Convert.ToInt64(dataRow1["MainProductID"]));
                            this.MainProductId = Convert.ToInt64(dataRow1["MainProductID"]);
                        }
                        empty = (num1 % 2 != 0 ? "changedTdColor_EvenNo" : "changedTdColor_OddNo");
                        empty1 = (dataRow1["PDFNameFromCart"].ToString() != "" || dataRow1["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(dataRow1["IsPrintReadyFile"]) ? "Style='display:block;float:left;'" : "Style='display:none;float:left;'");
                        this.ProductID = Convert.ToInt32(dataRow1["ProductID"].ToString());
                        this.CartID = Convert.ToInt64(dataRow1["CartID"].ToString());
                        this.CartItemID = Convert.ToInt64(dataRow1["CartItemID"].ToString());
                        Label label = new Label()
                        {
                            ID = string.Concat("lbl_CatrItemId_", num1),
                            Text = dataRow1["CartItemID"].ToString()
                        };
                        label.Attributes.Add("style", "display:none");
                        ControlCollection controls3 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<tr class='", empty, "'><td class='td_imgtrash'><div class='floatLeft'><img id='img_trash_", num1, "' class='img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", this.CartID, ",this.id,", this.CartItemID, ");'/></div>" };
                        controls3.Add(new LiteralControl(string.Concat(accountID)));
                        string str1 = string.Empty;
                        if (dataRow1["PrintReadyFile"].ToString() != "")
                        {
                            str1 = "printready";
                            if (ConnectionClass.ServerName.ToLower() == "creativeatlanta" || ConnectionClass.ServerName.ToLower() == "creativeapproach")
                            {
                                ControlCollection controlCollections3 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='floatLeft'><img  id='img_Pdf_", num1, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Template / Print Ready Requirement' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", dataRow1["PrintReadyFile"].ToString(), "\",", ShoppingCart.AccountID, ",\"", str1, "\");' ", empty1, "/></div>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            else
                            {
                                ControlCollection controls4 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='floatLeft'><img  id='img_Pdf_", num1, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", dataRow1["PrintReadyFile"].ToString(), "\",", ShoppingCart.AccountID, ",\"", str1, "\");' ", empty1, "/></div>" };
                                controls4.Add(new LiteralControl(string.Concat(accountID)));
                            }
                        }
                        else if (dataRow1["PDFNameFromCart"].ToString() != "")
                        {
                            if (dataRow1["PreviewType"].ToString() == "" || dataRow1["PreviewType"].ToString() == "pdfimg" || dataRow1["PreviewType"].ToString() == "pdf")
                            {
                                str1 = "pdf";
                                ControlCollection controlCollections4 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='floatLeft'><img  id='img_Pdf_", num1, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", dataRow1["PDFNameFromCart"].ToString(), "\",", ShoppingCart.AccountID, ",\"", str1, "\");' ", empty1, "/></div>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            if (dataRow1["ImageNameFromCart"].ToString() != "" && (dataRow1["PreviewType"].ToString() == "pdfimg" || dataRow1["PreviewType"].ToString() == "img"))
                            {
                                str1 = "previewimage";
                                ControlCollection controls5 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num1, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", dataRow1["ImageNameFromCart"].ToString(), "\",", ShoppingCart.AccountID, ",\"", this.strSitepath, "\",\"", str1, "\");' ", empty1, "/></div>" };
                                controls5.Add(new LiteralControl(string.Concat(accountID)));
                            }
                        }
                        if (dataRow1["UploadFile"].ToString() != "" || dataRow1["UploadFile1"].ToString() != "" || dataRow1["UploadFile2"].ToString() != "")
                        {
                            ControlCollection controlCollections5 = this.plh_CartItems.Controls;
                            accountID = new object[] { "<a ><img id='img_Edit_", num1, "' onclick='openArtworkPopup(", dataRow1["CartItemID"].ToString(), ",", dataRow1["CartID"].ToString(), ") ' class='img_trash WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        this.plh_CartItems.Controls.Add(label);
                        HiddenField hiddenField = new HiddenField()
                        {
                            ID = string.Concat("hdnProdDeltd_", dataRow1["CartItemID"].ToString())
                        };
                        HiddenField hiddenField1 = new HiddenField()
                        {
                            ID = string.Concat("hdnProductName_", dataRow1["CartItemID"].ToString())
                        };
                        if (CartBasePage.Product_Exists_Check(Convert.ToInt32(dataRow1["ProductID"])) != (long)0)
                        {
                            hiddenField.Value = "true";
                            hiddenField1.Value = dataRow1["CatalogueName"].ToString();
                        }
                        else
                        {
                            hiddenField.Value = "false";
                        }
                        this.plh_CartItems.Controls.Add(hiddenField);
                        this.plh_CartItems.Controls.Add(hiddenField1);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        if (dataRow1["ProductImage"].ToString() != "")
                        {
                            accountID = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", dataRow1["ProductImage"].ToString(), "&type=p&aid=", ShoppingCart.AccountID, "&cid=", this.CompanyID };
                            this.productImage = string.Concat(accountID);
                        }
                        else
                        {
                            accountID = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=t_no_image_available.png&type=r&aid=", ShoppingCart.AccountID, "&cid=", this.CompanyID };
                            this.productImage = string.Concat(accountID);
                        }
                        Image image = new Image()
                        {
                            ID = string.Concat("img_product_", num1),
                            ImageUrl = this.productImage,
                            AlternateText = " ",
                            CssClass = "selected_img_td"
                        };
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='selected_img_td'>"));
                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                        {
                            ControlCollection controls6 = this.plh_CartItems.Controls;
                            accountID = new object[] { this.strSitepath, "products/productdetails.aspx?ID=", this.ProductID, "&amp;type=0" };
                            controls6.Add(new LiteralControl(string.Concat("<a href='", base.ResolveUrl(string.Concat(accountID)), "'></a>")));
                        }
                        else
                        {
                            ControlCollection controlCollections6 = this.plh_CartItems.Controls;
                            accountID = new object[] { this.strSitepath, "products/", ConnectionClass.RemoveIllegalChars(dataRow1["CatalogueName"].ToString()), ConnectionClass.KeySeparator, this.ProductID, ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                            controlCollections6.Add(new LiteralControl(string.Concat("<a href='", base.ResolveUrl(string.Concat(accountID)), "'></a>")));
                        }
                        this.plh_CartItems.Controls.Add(image);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='displayNone'>"));
                        HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox()
                        {
                            ID = string.Concat("chkEachLine", dataRow1["CartItemID"].ToString()),
                            Value = dataRow1["CartID"].ToString()
                        };
                        htmlInputCheckBox.Attributes.Add("display", "none");
                        this.plh_CartItems.Controls.Add(htmlInputCheckBox);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        ControlCollection controls7 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", dataRow1["ProductID"].ToString(), " id='hdnProductID_", dataRow1["CartItemID"].ToString(), "' >" };
                        controls7.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections7 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", dataRow1["AllowGroupRun"].ToString(), " id='hdnGroupRun_", dataRow1["CartItemID"].ToString(), "' >" };
                        controlCollections7.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls8 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", dataRow1["Quantity"].ToString(), " id='hdnQuantity_", dataRow1["CartItemID"].ToString(), "' >" };
                        controls8.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections8 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", dataRow1["CartItemID"].ToString(), " id='hdnCartItemID_", dataRow1["CartItemID"].ToString(), "' >" };
                        controlCollections8.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls9 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", dataRow1["MatrixType"].ToString(), " id='hdnMatrixType_", dataRow1["CartItemID"].ToString(), "' >" };
                        controls9.Add(new LiteralControl(string.Concat(languageConversion)));
                        decimal num3 = new decimal(0);
                        num3 = (this.MeasurementValue != "In." ? Convert.ToDecimal(dataRow1["Quantity"]) * ((Convert.ToDecimal(dataRow1["Height"]) * Convert.ToDecimal(dataRow1["Width"])) / new decimal(1000000)) : Convert.ToDecimal(dataRow1["Quantity"]) * ((Convert.ToDecimal(dataRow1["Height"]) * Convert.ToDecimal(dataRow1["Width"])) / new decimal(144)));
                        ControlCollection controlCollections9 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<input type='hidden' value=", num3, " id='hdnDimension_", dataRow1["CartItemID"].ToString(), "' >" };
                        controlCollections9.Add(new LiteralControl(string.Concat(accountID)));
                        ControlCollection controls10 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<input type='hidden' value=ctl00_ContentPlaceHolder1_lbl_unitPrice_", num1, " id='hdnlblUnitPrice_", dataRow1["CartItemID"].ToString(), "' >" };
                        controls10.Add(new LiteralControl(string.Concat(accountID)));
                        ControlCollection controlCollections10 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<input type='hidden' value=ctl00_ContentPlaceHolder1_lbl_subTotal_", num1, " id='hdnlblsubtotalID_", dataRow1["CartItemID"].ToString(), "' >" };
                        controlCollections10.Add(new LiteralControl(string.Concat(accountID)));
                        ControlCollection controls11 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<input type='hidden' value=ctl00_ContentPlaceHolder1_lbl_qty_", num1, " id='hdnlblQtyID_", dataRow1["CartItemID"].ToString(), "' >" };
                        controls11.Add(new LiteralControl(string.Concat(accountID)));
                        Label label1 = new Label()
                        {
                            ID = string.Concat("lbl_productName_", num1),
                            Text = base.SpecialDecode(dataRow1["CatalogueName"].ToString())
                        };
                        Label label2 = new Label()
                        {
                            ID = string.Concat("lbl_MainproductName_", num1)
                        };
                        if (Convert.ToInt64(dataRow1["MainProductID"]) != (long)0)
                        {
                            label2.Text = base.SpecialDecode(this.MainProductName);
                        }
                        if (dataRow1["MatrixType"].ToString().ToLower() == "g")
                        {
                            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Width"].ToString()), 2, "", false, false, true);
                            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Height"].ToString()), 2, "", false, false, true);
                            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                            label1.Text = string.Concat(languageConversion);
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='productname_td' data-label='" + this.objLanguage.GetLanguageConversion("Product_Name") + "'>"));
                        int num4 = 0;
                        DataTable dataTable2 = CartBasePage.Select_CartAdditionalItems(Convert.ToInt64(dataRow1["CartItemID"]));
                        foreach (DataRow row2 in dataTable2.Rows)
                        {
                            if (Convert.ToInt32(row2["CheckCount"]) <= 0)
                            {
                                break;
                            }
                            if (Convert.ToInt32(row2["OptionID"]) <= 0)
                            {
                                continue;
                            }
                            if (num4 == 0)
                            {
                                ControlCollection controlCollections11 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div id='plus_div_", num1, "' class='plus_div'><img id='img_plus_", num1, "' class='img_plus_minus' onclick='Onclick_img_plus(", num1, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                                controlCollections11.Add(new LiteralControl(string.Concat(accountID)));
                                ControlCollection controls12 = this.plh_CartItems.Controls;
                                accountID = new object[] { "                                              <img id='img_minus_", num1, "' class='img_minus' onclick='Onclick_img_minus(", num1, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                                controls12.Add(new LiteralControl(string.Concat(accountID)));
                                if (this.MainProductId != (long)0)
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                                    this.plh_CartItems.Controls.Add(label2);
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                                this.plh_CartItems.Controls.Add(label1);
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div id='lbl_productDetails_div_", num1, "' class='lbl_productDetails_div'><div id='divhide_", num1, "'>" };
                                controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                            }
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                            Label label3 = new Label();
                            accountID = new object[] { "lblOthercostName_", num1, "_", num4 };
                            label3.ID = string.Concat(accountID);
                            label3.Text = base.SpecialDecode(row2["UserFriendlyName"].ToString().Trim());
                            this.plh_CartItems.Controls.Add(label3);
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                            Label label4 = new Label();
                            accountID = new object[] { "lblSelectedValue_", num1, "_", num4 };
                            label4.ID = string.Concat(accountID);
                            label4.Text = base.SpecialDecode(row2["SelectedValue"].ToString().Trim());
                            this.plh_CartItems.Controls.Add(label4);
                            this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                            Label label5 = new Label()
                            {
                                ID = string.Concat("lblPrice_", row2["CartAdditionalItemID"].ToString()),
                                Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["TotalPrice"].ToString().Trim()), 2, "", false, false, true)
                            };
                            if (row2["ParentWebOtherCostID"].ToString() == "0" && row2["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                            {
                                label5.Style.Add("display", "none");
                            }
                            this.plh_CartItems.Controls.Add(label5);
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div><br />"));
                            num4++;
                        }
                        if (num4 == 0)
                        {
                            if (this.MainProductId != (long)0)
                            {
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                                this.plh_CartItems.Controls.Add(label2);
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                            this.plh_CartItems.Controls.Add(label1);
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label6 = new Label()
                        {
                            ID = string.Concat("lbl_productDescritpion_", num1),
                            Text = base.SpecialDecode(dataRow1["ShortDescription"].ToString())
                        };
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='productdescription_td' data-label='" + this.objLanguage.GetLanguageConversion("Product_Description") + "'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                        this.plh_CartItems.Controls.Add(label6);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        TextBox textBox = new TextBox()
                        {
                            ID = string.Concat("txt_jobName_", num1),
                            Text = dataRow1["JobName"].ToString()
                        };
                        textBox.Style.Add("width", "110px");
                        textBox.Style.Add("margin-right", "5px");
                        if (this.isCartJobName != "1")
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td class='displayNone'>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td>"));
                        }
                        this.plh_CartItems.Controls.Add(textBox);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label7 = new Label()
                        {
                            ID = string.Concat("lbl_unitPrice_", num1),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["UnitPrice"].ToString()), 2, "", false, false, true),
                            CssClass = "unitprice_Content_Label"
                        };
                        if (this.isCartUnitPrice != "1")
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td class='displayNone'>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td data-label='" + this.objLanguage.GetLanguageConversion("Unit_Price") + "'>"));
                        }
                        this.plh_CartItems.Controls.Add(label7);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label8 = new Label()
                        {
                            ID = string.Concat("lbl_TaxApplicable_", num1),
                            Text = string.Concat(base.SpecialDecode(dataRow1["TaxName"].ToString()), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow1["Tax"]), 2, "", false, false, true)), "%")
                        };
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td data-label='"+this.objLanguage.GetLanguageConversion("Tax_Applicable") +"'>"));
                        this.plh_CartItems.Controls.Add(label8);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label9 = new Label()
                        {
                            ID = string.Concat("lbl_qty_", num1),
                            Text = dataRow1["Quantity"].ToString(),
                            CssClass = "unitprice_Content_Label"
                        };
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td style='width:auto' data-label='" + this.objLanguage.GetLanguageConversion("Qty") + "'>"));
                        this.plh_CartItems.Controls.Add(label9);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label10 = new Label()
                        {
                            ID = string.Concat("lbl_CouponDiscount_", dataRow1["CartItemID"].ToString()),
                            Text = "0.00",
                            CssClass = "unitprice_Content_Label"
                        };
                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<td ", this.CouponCodeDisplay, ">")));
                        this.plh_CartItems.Controls.Add(label10);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        num2 = num2 + Convert.ToInt32(dataRow1["Quantity"].ToString());
                        Label str4 = new Label()
                        {
                            ID = string.Concat("lbl_tax_", num1)
                        };
                        decimal num5 = Convert.ToDecimal(dataRow1["CartTax"].ToString());
                        str4.Text = num5.ToString();
                        str4.CssClass = "unitprice_Content_Label";
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='displayNone'>"));
                        this.plh_CartItems.Controls.Add(str4);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        Label label11 = new Label()
                        {
                            ID = string.Concat("lbl_subTotal_", num1)
                        };
                        decimal num6 = Convert.ToDecimal(dataRow1["CartTotalPrice"].ToString());
                        label11.CssClass = "unitprice_Content_Label";
                        label11.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num6), 2, "", false, false, true);
                        if (this.isCartTotal != "1")
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td class='displayNone'>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td data-label='" + this.objLanguage.GetLanguageConversion("Total_ex_Tax") + "'>"));
                        }
                        this.plh_CartItems.Controls.Add(label11);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</tr>"));
                        num1++;
                    }
                    this.hid_ItemsLength.Value = num1.ToString();
                    if (num1 == 0)
                    {
                        this.div_ShoppingItems.Style.Add("display", "none");
                        this.grandTotal_div.Style.Add("display", "none");
                        this.Shoppingcard_div.Style.Add("height", "400px");
                        this.productAdded.Style.Add("display", "block");
                    }
                    if (this.ISCouponCodeEnabled && this.CartJobScreenNameShow)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td colspan='10' id='tableFooter' class='ShoppingCart_HeaderFooter' align='right'>"));
                    }
                    else if (this.ISCouponCodeEnabled || this.CartJobScreenNameShow)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td colspan='9' id='tableFooter' class='ShoppingCart_HeaderFooter' align='right'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td colspan='8' id='tableFooter' class='ShoppingCart_HeaderFooter' align='right'>"));
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div style='float:right;width:4.5%;'>"));
                    Label label12 = new Label()
                    {
                        ID = "lblTotaltaxID"
                    };
                    Label label13 = new Label()
                    {
                        ID = "lblTotalPriceID"
                    };
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    for (int i = 0; i <= num1 - 1; i++)
                    {
                        Label label14 = (Label)this.div_ShoppingItems.FindControl(string.Concat("lbl_tax_", i));
                        Label label15 = (Label)this.div_ShoppingItems.FindControl(string.Concat("lbl_subTotal_", i));
                        num7 = num7 + Convert.ToDecimal(label14.Text);
                        num8 = num8 + Convert.ToDecimal(label15.Text);
                    }
                    this.hid_TotalExTax.Value = num8.ToString();
                    this.hid_TotalIncTax.Value = (num7 + num8).ToString();
                    this.hid_TotalQty.Value = num2.ToString();
                    label12.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num7), 2, "", false, false, true);
                    label13.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num8), 2, "", false, false, true);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='SubRembold' ><div style='white-space:nowrap;' class='totalcost_left' ", this.displaySubTotal, ">")));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_New"), ":")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='totalcost_right' ", this.displaySubTotal, ">")));
                    this.plh_CartItems.Controls.Add(label13);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='btnContinueShopping' class='marginTop5'>"));
                    Button button = new Button()
                    {
                        ID = "btn_ContinueShopping",
                        Text = this.objLanguage.GetLanguageConversion("Add_More_Items"),
                        CssClass = "WS_Buttons_Style"
                    };
                    button.Attributes.Add("onclick", "javascript:var a=onclick_Checkoutshp('shopping');if(a==false)loadingimage(this.id,'div_btneditsaveprocess');return a;");
                    this.plh_CartItems.Controls.Add(button);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_btneditsaveprocess' class='displayNone textalignCenter WS_Buttons_Style'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<img src='", ShoppingCart.imagePath, "radimg1.gif' alt='loading' border='0' >")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    if (this.isCartGrandTotal == "0")
                    {
                        this.div_grandTotal.Style.Add("display", "none");
                    }
                    int num9 = 0;
                    int num10 = 0;
                    int num11 = 0;
                    int num12 = 0;
                    int length = 0;
                    DataTable dataTable3 = CartBasePage.Select_CartAdditionalOptions(this.NewSessionID, this.StoreUserID, "");
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                    DataTable dataTable4 = CartBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, ShoppingCart.AccountID, "no");
                    foreach (DataRow dataRow2 in dataTable4.Rows)
                    {
                        DataSet dataSet = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataRow2["WebOtherCostID"].ToString()));
                        DataTable item = dataSet.Tables[0];
                        DataTable item1 = dataSet.Tables[1];
                        foreach (DataRow row3 in item1.Rows)
                        {
                            row3["Label"] = base.SpecialDecode(row3["Label"].ToString());
                        }
                        Convert.ToInt64(dataRow2["WebOtherCostID"].ToString());
                        num12++;
                        string empty2 = string.Empty;
                        foreach (DataRow dataRow3 in item.Rows)
                        {
                            this.MainCalculationtype = dataRow3["MainCalculationType"].ToString();
                            this.HelpText = dataRow3["Description"].ToString().Replace("\n", "<br>");
                            this.OtherCostName = dataRow3["UserFriendlyName"].ToString();
                            this.IsCartmandatory = Convert.ToBoolean(dataRow3["IsCartmandatory"]);
                            try
                            {
                                this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                            }
                            catch
                            {
                            }
                        }
                        int num13 = 0;
                        foreach (DataRow row4 in item1.Rows)
                        {
                            int num14 = 0;
                            int num15 = 0;
                            decimal num16 = new decimal(0);
                            decimal num17 = new decimal(0);
                            string empty3 = string.Empty;
                            if (this.MainCalculationtype.ToLower() == "q")
                            {
                                string str5 = row4["formula"].ToString();
                                string str6 = row4["Question"].ToString();
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content_new' align='right'>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                ControlCollection controls13 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblQuestion_", num9, "' > ", this.OtherCostName, "<br/>", str6, "</label>" };
                                controls13.Add(new LiteralControl(string.Concat(accountID)));
                                if (this.HelpText != "")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void();' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' class='cart_details_HelpTextImage' border='0' /></a>" };
                                    controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle cart_details_BorderGrey2px'>"));
                                ControlCollection controls14 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<br/><div><label id='lblPrice_", num9, "' >(", this.comm.GetCurrencyinRequiredFormate("0.00", true), ") </label><label id='lblQuestionID_", num9, "' class='displayNone'>", dataRow2["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num9, "' class='displayNone'>", str5, " </label><label id='lblQuestionSortOrderNo_", num9, "' class='displayNone'>", num12, "</label>" };
                                controls14.Add(new LiteralControl(string.Concat(accountID)));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right'  align='right'>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<input id='txtQuestion_", num9, "' onkeyup='Cart_Additional_Price();' onblur='Cart_Additional_Price();' class='txtStyle' type='text' maxlength='7' />")));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div><br/>"));
                                num9++;
                            }
                            else if (this.MainCalculationtype.ToLower() == "c")
                            {
                                if (num13 == 0)
                                {
                                    foreach (DataRow dataRow4 in dataTable3.Rows)
                                    {
                                        if (Convert.ToInt32(dataRow4["OptionID"]) != Convert.ToInt32(dataRow2["WebOtherCostID"].ToString()))
                                        {
                                            continue;
                                        }
                                        num14 = Convert.ToInt32(dataRow4["OptionID"]);
                                        num15 = Convert.ToInt32(dataRow4["SelectedID"]);
                                        num16 = Convert.ToDecimal(dataRow4["MarkupValue"]);
                                        num17 = Convert.ToDecimal(dataRow4["TotalPrice"]);
                                        dataRow4["SelectedValue"].ToString();
                                        Convert.ToDecimal(dataRow4["SelectedPrice"]);
                                        Convert.ToDecimal(dataRow4["Markup"]);
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content_new' >"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'>"));
                                    if (num14 != Convert.ToInt32(dataRow2["WebOtherCostID"].ToString()))
                                    {
                                        ControlCollection controlCollections14 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<input id='chkMultiple_", num10, "' class='displayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Cart_Onchange_MultipleChoice(", num10, ");'/>" };
                                        controlCollections14.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls15 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<input id='chkMultiple_", num10, "' class='displayNone' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num10, ");'/>" };
                                        controls15.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                    ControlCollection controlCollections15 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<label id='lblMatrixName_", num10, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                    controlCollections15.Add(new LiteralControl(string.Concat(accountID)));
                                    if (this.HelpText != "")
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void();' class='tooltip' title='", this.HelpText, "'>")));
                                        ControlCollection controls16 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' class='cart_details_HelpTextImage' border='0' /></a>" };
                                        controls16.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle'>"));
                                    ControlCollection controlCollections16 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<div><label id='lblMultipleID_", num10, "' class='displayNone'>", dataRow2["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num10, "' class='displayNone'></label><label id='lblMultipleMarkup_", num10, "' class='displayNone'></label><label id='lblMultiplePrice_", num10, "'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num17, 0, "", false, false, true), "</label><label id='lblMultipleMarkupValue_", num10, "' class='displayNone'>", num16, "</label><label id='lblMultipleSortOrderNo_", num10, "' class='displayNone'>", num12, "</label>" };
                                    controlCollections16.Add(new LiteralControl(string.Concat(accountID)));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                    if (length <= 80)
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right'>"));
                                    }
                                    else
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right'>"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num10),
                                        CssClass = "dropDownMultiple250_right"
                                    };
                                    dropDownList.Attributes.Add("onchange", "javascript:Cart_Additional_Price();");
                                    dropDownList.Attributes.Add("isRequired", this.IsCartmandatory.ToString());
                                    if (num14 != Convert.ToInt32(dataRow2["WebOtherCostID"].ToString()))
                                    {
                                        this.MultipleChoice_DropDownBind(item1, dropDownList, this.plh_CartItems, row4["CalculationType"].ToString(), "edit", num15);
                                    }
                                    else
                                    {
                                        this.comm.MultipleChoice_DropDownBind(item1, dropDownList, this.plh_CartItems, row4["CalculationType"].ToString());
                                    }
                                    if (this.IsCartmandatory)
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<span class='starspan_public'>*</span>"));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    num10++;
                                }
                            }
                            else if (this.MainCalculationtype.ToLower() == "m" && num13 == 0)
                            {
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content'>"));
                                row4["matrixType"].ToString();
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' >"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                ControlCollection controls17 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='cartoptions_CheckBox_Div'><input id='chkMatrix_", num11, "' class='displayBlock' type='checkbox' title='", this.OtherCostName, "' onclick='Cart_Additional_Price();'/></div>" };
                                controls17.Add(new LiteralControl(string.Concat(accountID)));
                                ControlCollection controlCollections17 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='cartoptions_Name_Div'><label id='lblMatrixName_", num11, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                controlCollections17.Add(new LiteralControl(string.Concat(accountID)));
                                if (this.HelpText != "")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0)' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controls18 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", ShoppingCart.AccountID, "&amp;cid=", this.CompanyID, "' class='cart_details_HelpTextImage' border='0' /></a>" };
                                    controls18.Add(new LiteralControl(string.Concat(accountID)));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle'><div>"));
                                ControlCollection controlCollections18 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblMatrixID_", num11, "' class='displayNone'>", dataRow2["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num11, "' class='displayNone'>", row4["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num11, "' class='displayNone'></label><label id='lblMatrixSortOrderNo_", num11, "' class='displayNone'>", num12, "</label>" };
                                controlCollections18.Add(new LiteralControl(string.Concat(accountID)));
                                ControlCollection controls19 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblMatrixPrice_", num11, "' >(", this.comm.GetCurrencyinRequiredFormate("0.00", true), ")</label></div>" };
                                controls19.Add(new LiteralControl(string.Concat(accountID)));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right displayNone'>"));
                                if (row4["matrixType"].ToString().ToLower() != "pricebands")
                                {
                                    DropDownList dropDownList1 = new DropDownList();
                                    this.comm.MultipleChoice_DropDownBind(item1, dropDownList1, this.plh_CartItems, "matrix");
                                    dropDownList1.ID = string.Concat("ddlMatrix_", num11);
                                    dropDownList1.CssClass = "dropDownMultiple250";
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                num11++;
                            }
                            num13++;
                        }
                    }
                    this.hid_QuestionLenght.Value = num9.ToString();
                    this.hid_MultipleLenght.Value = num10.ToString();
                    this.hid_MatrixLenght.Value = num11.ToString();
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='marginTop5'></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='cartoptions_Tax_MainDiv'></div><div class='total_Right' ", this.displayStyle, "><div class='totalcost_left'>")));
                    string empty4 = string.Empty;
                    decimal num18 = new decimal(0);
                    long num19 = (long)0;
                    foreach (DataRow row5 in ProductBasePage.Tax_Bind(this.CompanyID).Rows)
                    {
                        num19 = Convert.ToInt64(row5["TaxID"]);
                        row5["TaxName"].ToString();
                        num18 = Convert.ToDecimal(row5["TaxRate"].ToString());
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Total_Tax"), ":")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    ControlCollection controlCollections19 = this.plh_CartItems.Controls;
                    accountID = new object[] { "<div class='totalcost_right'><label id='lblTaxRate' class='displayNone'>", num18, "</label><label id='lblTaxID' class='displayNone'>", num19, "</label>" };
                    controlCollections19.Add(new LiteralControl(string.Concat(accountID)));
                    this.plh_CartItems.Controls.Add(label12);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</table>"));
                //}
                if (this.ISCouponCodeEnabled)
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_CouponCode' style='white-space: nowrap; float: left;opacity: 1;width: 60%;margin-left:1%'>"));
                    Label label16 = new Label()
                    {
                        ID = "lblCouponCode",
                        Text = "Provide your coupon code here"
                    };
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_lblCouponcode' style='white-space: nowrap; float: left;'>"));
                    this.plh_CartItems.Controls.Add(label16);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<br/>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_txtCouponcode' style='white-space: nowrap; float: left;'>"));
                    TextBox textBox1 = new TextBox()
                    {
                        ID = "txt_CouponCode",
                        CssClass = "ws_txtWidth240"
                    };
                    textBox1.Style.Add("margin-left", "0");
                    this.plh_CartItems.Controls.Add(textBox1);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_btnCouponcode' style='white-space: nowrap; float: left;padding-left:2%;position: relative;top: 0px;'>"));
                    Button button1 = new Button()
                    {
                        ID = "btn_CouponCodeApply",
                        CssClass = "WS_Buttons_Style",
                        Text = "Apply"
                    };
                    button1.Style.Add("margin-left", "1px");
                    button1.Style.Add("min-width", "150px");
                    button1.OnClientClick = "javascript: ApplyCouponCode(); return false;";
                    this.plh_CartItems.Controls.Add(button1);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_ClearCouponCode' style='display: none;float:left;padding-left: 1%;text-decoration: underline;cursor: pointer;color:#10357f;' ><a href='#' style='color:#10357f;' onclick='javascript:ClearCouponCode(); return false;'> Clear </a></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<br />"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<table style='width: 90%;'><tr><td style='padding-top: 2px;'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_InvalidCouponCode' style='display: none;white-space: nowrap; float: left;'>"));
                    Label label17 = new Label()
                    {
                        ID = "lblInvalidCouponCode",
                        Text = "Invalid CouponCode"
                    };
                    label17.Style.Add("color", "Red");
                    this.plh_CartItems.Controls.Add(label17);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</table>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                }
            }
            catch
            {
            }
        }
    }
}