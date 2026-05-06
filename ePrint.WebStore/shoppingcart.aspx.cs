using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
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


namespace ePrint.WebStore
{
    public partial class shoppingcart : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected HtmlGenericControl productAdded;

        //protected Label lblNotifyGprunDiscount;

        //protected LinkButton lnbDeleteSelected;

        //protected HiddenField hdnChecked;

        //protected HiddenField hdnSelfChecked;

        //protected HiddenField hdnCartID;

        //protected PlaceHolder plh_CartItems;

        //protected HtmlGenericControl div_ShoppingItems;

        //protected HtmlGenericControl div3;

        //protected Label lblgrandTotal;

        //protected Label lbl_grandTotal;

        //protected HtmlGenericControl div1;

        //protected HtmlGenericControl div_grandTotal;

        //protected Button btn_proceedCheckout;

        //protected Button btn_SaveAndStay;

        //protected Button btn_ContinueShopping;

        //protected Image img_AddtoCart;

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

        //protected HiddenField hdnAllowGroupRun;

        //protected HiddenField hdnCartItems;

        //protected HiddenField hid_TotalNoOfCartItems;

        //protected HiddenField hid_MultiplePrice;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ImagePath = ConnectionClass.ImagePath;

        public char KeySeparator;

        public int CompanyID;

        public string RewriteModule;

        public int ProductID;

        public long CartID;

        public long cardid;

        public long productid_new;

        public long StoreUserID;

        public static long AccountID;

        public string File = "bearing-souk.pdf";

        public string NewSessionID = string.Empty;

        public string strSitepath = string.Empty;

        public string StyleSheetPath = string.Empty;

        public string imageName = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string FileExtension = string.Empty;

        public string AccountType = "P";

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        public string VisibletoCart = string.Empty;

        public bool IsCartmandatory;

        public string HelpText = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string displayStyle = "style='display:block;'";

        public string displaySubTotal = "style='display:block;'";

        public string SystemName = string.Empty;

        public static string CatalogueName;

        public static string imagePath;

        public string isCartJobName = "0";

        public string isCartUnitPrice = "0";

        public string isCartTotal = "0";

        public string isCartSubtotal = "0";

        public string isCartGrandTotal = "0";

        public bool AllowGroupRun;

        public string strImagepath = BaseClass.imagePath();

        public bool IsSelectAllcartItems;

        public string Prod_NoMoreExists_MSG = string.Empty;

        public string Order_Deltd_Prod_Msg1 = string.Empty;

        public string Order_Deltd_Prod_Msg2 = string.Empty;

        public string Order_Deltd_Prod_Msg3 = string.Empty;

        public string Order_Deltd_Prod_Msg4 = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        public string StatusTitle = string.Empty;

        public string Category_ReqApproval_Msg = string.Empty;

        public string UserType = string.Empty;

        private string MeasurementValue = string.Empty;

        public string ApprovalSystem = string.Empty;

        public string ProductStockManagement = string.Empty;

        public bool IsMarkedAllForApprove;

        public string ApprovalType = string.Empty;

        public string CurrencySymbol = string.Empty;

        public bool ISCouponCodeEnabled;

        public string CouponCodeDisplay = "display:none;";

        public string IsEditableProduct = string.Empty;

        public int IsPdfGenerated;

        public string Pdfvalues = string.Empty;

        public string MainProductName = string.Empty;

        public long MainProductId;

        public bool IsZip2taxEnabled;

        public string deptScreenName = string.Empty;

        public string IsEnableHidePrice = string.Empty;

        public string SpendLimitData = string.Empty;

        public string IsSpendLimitEnable = string.Empty;

        public string PDFToURLPath = string.Empty;

        public string CartJobScreenName = string.Empty;

        public string CartJobScreenNameForAlert = string.Empty;

        public bool CartJobNameIsMandatory;

        public bool CartJobScreenNameShow;

        public bool IsStoreCredit = false;

        public bool IsEnableSubDetail = false;

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

        static shoppingcart()
        {
            shoppingcart.AccountID = (long)0;
            shoppingcart.CatalogueName = string.Empty;
            shoppingcart.imagePath = string.Empty;
        }

        public shoppingcart()
        {
        }

        public void GenerateCartList(DataTable dtCart)
        {
            object[] accountID;
            string[] languageConversion;
            string TaxDetail;
            try
            {
                this.plh_CartItems.Controls.Clear();
                this.plh_CartItems.Controls.Add(new LiteralControl("<table id='shippingCart_Table' class='shoppingCart_HeaderFooter' cellspacing='0' cellpadding='0' >"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<tr style='white-space: nowrap;'>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<th id='th_chkAll' style='width:2%;'>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_chk'>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='floatLeft'>"));
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox()
                {
                    ID = "chkAll"
                };
                htmlInputCheckBox.Attributes.Add("onclick", "javascript: checkall('shippingCart_Table',this.checked);allowgrouprun_calculations();Calculate_GrandTotal();Cart_Additional_Price();");
                if (!this.IsSelectAllcartItems)
                {
                    htmlInputCheckBox.Checked = false;
                }
                else
                {
                    htmlInputCheckBox.Checked = true;
                }
                this.plh_CartItems.Controls.Add(htmlInputCheckBox);
                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_chkAll_Img'>"));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.ImagePath, "ArrowDown.gif' id='img_actionsShow'class='DisplayBlock CursorPointer' onclick='show();' alt='' />")));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<img src='", this.ImagePath, "ArrowUP.GIF' id='img_actionsHide' class='DisplayNone CursorPointer' onclick='hide();' alt='' />")));
                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                this.plh_CartItems.Controls.Add(new LiteralControl("</th>"));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_Action'>&nbsp;", this.objLanguage.GetLanguageConversion("Action"), "</th>")));
                if (this.ApprovalType.ToLower() == "s")
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl("<th id='th_Approve'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<span>", this.objLanguage.GetLanguageConversion("Approve_Action"), "</span>")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</th>"));
                }
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_ProductName'>", this.objLanguage.GetLanguageConversion("Product_Name"), "</th>")));
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_orderedFor'>", this.objLanguage.GetLanguageConversion("Ordered_For"), "</th>")));
                if (!(ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg") || shoppingcart.AccountID != (long)267)
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_ProductDescription'>", this.objLanguage.GetLanguageConversion("Product_Description"), "</th>")));
                }
                else
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_ProductDescription'>", this.objLanguage.GetLanguageConversion("Product_Code"), "</th>")));
                }
                if (this.IsCampaignEnabled.ToLower() == "true")
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_CampaignName'>", this.objLanguage.GetLanguageConversion("Campaign_Name"), "</th>")));
                }
                if (this.CartJobScreenNameShow)
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_JobName' >", this.CartJobScreenName)));
                }
                else
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_JobName' style='display:none'>", this.CartJobScreenName)));
                }
                if (this.isCartJobName == "1")
                {
                    if (ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg" && shoppingcart.AccountID == (long)267)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<a href='javascript:void(0);' class='tooltip' title='If ordering a business card,you must enter the name of the person the card is for.'>"));
                        ControlCollection controls = this.plh_CartItems.Controls;
                        accountID = new object[] { "<img id='img_helpText'  src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px'  /></a>" };
                        controls.Add(new LiteralControl(string.Concat(accountID)));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</th>"));
                    }
                }
                else if (ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg" && shoppingcart.AccountID == (long)267)
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl("<a href='javascript:void();' class='tooltip' title='If ordering a business card,you must enter the name of the person the card is for.'>"));
                    ControlCollection controlCollections = this.plh_CartItems.Controls;
                    accountID = new object[] { "<img id='img_helpText'  src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' style='margin-left:10px;' class='CursorPointer marginLeft5px' /></a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(accountID)));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</th>"));
                }
                if (!(this.isCartUnitPrice == "1") || !(this.IsEnableHidePrice == "false"))
                {
                    ControlCollection controls1 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th id='th_UnitPrice' style='width:9%;' class='DisplayNone'>", this.objLanguage.GetLanguageConversion("Uni_Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    ControlCollection controlCollections1 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th id='th_UnitPrice' style='width:9%;'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                this.IsZip2taxEnabled = CartBasePage.Select_IsZip2taxEnabled(this.CompanyID, shoppingcart.AccountID);
                if (this.IsZip2taxEnabled != true)
                {
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<th id='th_TaxApplicable' style='width:9%;' class='DisplayNone'>Tax Applicable</th>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_TaxApplicable'>", "Tax Applicable", "</th>")));
                    }
                }
                else
                {
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<th id='th_TaxApplicable' style='width:9%;' class='DisplayNone'> </th>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_TaxApplicable'>", " ", "</th>")));
                    }
                }
                this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_Qty'>", this.objLanguage.GetLanguageConversion("Qty"), " </th>")));
                if (!this.ISCouponCodeEnabled)
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_discount' style='text-align: right;font-weight: bold;width: 9%;padding: 7px 2px 2px 5px;' class='DisplayNone'>", this.objLanguage.GetLanguageConversion("Discount"), " (%)</th>")));
                }
                else if (this.IsEnableHidePrice != "false")
                {
                    ControlCollection controls2 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th id='th_discount' style='text-align: right;font-weight: bold;width: 9%;padding: 7px 2px 2px 5px;' class='DisplayNone'>", this.objLanguage.GetLanguageConversion("Discount"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    ControlCollection controlCollections2 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th id='th_discount' style='text-align: right;font-weight: bold;width: 9%;padding: 7px 2px 2px 5px;'>", this.objLanguage.GetLanguageConversion("Discount"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</th>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (!(this.isCartTotal == "1") || !(this.IsEnableHidePrice == "false"))
                {
                    ControlCollection controls3 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<th id='th_Total' class='DisplayNone'>", this.objLanguage.GetLanguageConversion("Total"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</th></tr>" };
                    controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<th id='th_Total'>", "Total (ex. Tax)", "</th></tr>")));
                }
                if (this.cardid != (long)0)
                {
                    this.productAdded.Style.Add("display", "block");
                }
                int num = 0;
                short num1 = 0;
                int num2 = 0;
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in dtCart.Rows)
                {
                    DataTable dataCheck = CartBasePage.settings_Product_Matrix_EnableCheck(Convert.ToInt64(row["MainProductID"]));
                    if (dataCheck.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dataCheck.Rows[0]["IsEnableSubDetail"]))
                        {
                            IsEnableSubDetail = true;
                        }
                    }
                    else
                    {
                        IsEnableSubDetail = false;
                    }
                    IsStoreCredit = Convert.ToDouble(row["StoreCredit"]== System.DBNull.Value ? 0:row["StoreCredit"]) > 0 ? true : false; ;
                    if (!this.ISCouponCodeEnabled)
                    {
                        this.ISCouponCodeEnabled = Convert.ToBoolean(row["ISCouponCodeEnabled"]);
                    }
                    if (this.ISCouponCodeEnabled)
                    {
                        this.CouponCodeDisplay = "display:block;";
                    }
                    str = (Convert.ToBoolean(row["IsEditableProduct"].ToString()) || row["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(row["IsPrintReadyFile"]) ? "Style='display:block;float:left;'" : "Style='display:none;float:left;'");
                    empty = (num % 2 != 0 ? "changedTdColor_EvenNo" : "changedTdColor_OddNo");
                    if (Convert.ToInt64(row["MainProductID"]) == (long)0)
                    {
                        this.MainProductName = "";
                        this.MainProductId = (long)0;
                    }
                    else
                    {
                        this.MainProductName = CartBasePage.Select_MainProductName(Convert.ToInt64(row["MainProductID"]));
                        this.MainProductId = Convert.ToInt64(row["MainProductID"]);
                    }
                    if (Convert.ToBoolean(row["AllowGroupRun"].ToString()))
                    {
                        HiddenField hiddenField = this.hdnAllowGroupRun;
                        hiddenField.Value = string.Concat(hiddenField.Value, "CartItemID»", row["CartItemID"].ToString(), "±");
                    }
                    ControlCollection controlCollections3 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["ProductID"].ToString(), " id='hdnProductID_", row["CartItemID"].ToString(), "' >" };
                    controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controls4 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["AllowGroupRun"].ToString(), " id='hdnGroupRun_", row["CartItemID"].ToString(), "' >" };
                    controls4.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controlCollections4 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["Quantity"].ToString(), " id='hdnQuantity_", row["CartItemID"].ToString(), "' >" };
                    controlCollections4.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controls5 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["MatrixType"].ToString(), " id='hdnMatrixType_", row["CartItemID"].ToString(), "' >" };
                    controls5.Add(new LiteralControl(string.Concat(languageConversion)));
                    decimal num3 = new decimal(0);
                    num3 = (this.MeasurementValue != "In." ? Convert.ToDecimal(row["Quantity"]) * ((Convert.ToDecimal(row["Height"]) * Convert.ToDecimal(row["Width"])) / new decimal(1000000)) : Convert.ToDecimal(row["Quantity"]) * ((Convert.ToDecimal(row["Height"]) * Convert.ToDecimal(row["Width"])) / new decimal(144)));
                    ControlCollection controlCollections5 = this.plh_CartItems.Controls;
                    accountID = new object[] { "<input type='hidden' value=", num3, " id='hdnDimension_", row["CartItemID"].ToString(), "' >" };
                    controlCollections5.Add(new LiteralControl(string.Concat(accountID)));
                    ControlCollection controls6 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["CartItemID"].ToString(), " id='hdnCartItemID_", row["CartItemID"].ToString(), "' >" };
                    controls6.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controlCollections6 = this.plh_CartItems.Controls;
                    accountID = new object[] { "<input type='hidden' value=ctl00_ContentPlaceHolder1_lbl_unitPrice_", num, " id='hdnlblUnitPrice_", row["CartItemID"].ToString(), "' >" };
                    controlCollections6.Add(new LiteralControl(string.Concat(accountID)));
                    ControlCollection controls7 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["UnitPrice"].ToString(), " id='hdnbfrGPunitprice_", row["CartItemID"].ToString(), "' >" };
                    controls7.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controlCollections7 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["IsStockReplenish"].ToString(), " id='hdnisstockreplenishitem_", row["CartItemID"].ToString(), "' >" };
                    controlCollections7.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controls8 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["Order_Behalf_UserID"].ToString(), " id='hdnorderbehalfuser_", row["CartItemID"].ToString(), "' >" };
                    controls8.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controlCollections8 = this.plh_CartItems.Controls;
                    languageConversion = new string[] { "<input type='hidden' value=", row["Order_Behalf_DeptID"].ToString(), " id='hdnorderbehalfdept_", row["CartItemID"].ToString(), "' >" };
                    controlCollections8.Add(new LiteralControl(string.Concat(languageConversion)));
                    shoppingcart.CatalogueName = ConnectionClass.RemoveIllegalChars(row["CatalogueName"].ToString());
                    this.ProductID = Convert.ToInt32(row["ProductID"].ToString());
                    this.CartID = Convert.ToInt64(row["CartID"].ToString());
                    string str1 = string.Empty;
                    if (this.MainProductId == (long)0)
                    {
                        languageConversion = new string[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", row["ProductID"].ToString(), "&CartItemID=", row["CartItemID"].ToString(), "&type=ed" };
                        str1 = string.Concat(languageConversion);
                    }
                    else
                    {
                        accountID = new object[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", this.MainProductId, "&SubID=", row["ProductID"].ToString(), "&CartItemID=", row["CartItemID"].ToString(), "&type=ed" };
                        str1 = string.Concat(accountID);
                    }
                    Label label = new Label()
                    {
                        ID = string.Concat("lbl_CatrItemId_", num),
                        Text = row["CartItemID"].ToString()
                    };
                    label.Attributes.Add("style", "display:none");
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<tr class='", empty, "'>")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td id='td_checkbx' class='shoppingcart_BorderBottom'>"));
                    HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox()
                    {
                        ID = string.Concat("chkEachLine", row["CartItemID"].ToString()),
                        Value = row["CartID"].ToString()
                    };
                    htmlInputCheckBox1.Attributes.Add("onclick", string.Concat("javascript: allowgrouprun_calculations();CheckChanged('", htmlInputCheckBox1.ID, "');Calculate_GrandTotal();Cart_Additional_Price();"));
                    if (!this.IsSelectAllcartItems)
                    {
                        htmlInputCheckBox1.Checked = false;
                    }
                    else
                    {
                        htmlInputCheckBox1.Checked = true;
                    }
                    this.plh_CartItems.Controls.Add(htmlInputCheckBox1);
                    HiddenField hiddenField1 = new HiddenField()
                    {
                        ID = string.Concat("hdnProdDeltd_", row["CartItemID"].ToString())
                    };
                    HiddenField hiddenField2 = new HiddenField()
                    {
                        ID = string.Concat("hdnProductName_", row["CartItemID"].ToString())
                    };
                    HiddenField hiddenField3 = new HiddenField()
                    {
                        ID = string.Concat("hdnCtgryNotReqApproval_", row["CartItemID"].ToString()),
                        Value = Convert.ToString(OrderBasePage.Get_Catgry_IsApprovalNotRequired(Convert.ToInt64(row["ProductID"]))).ToLower()
                    };
                    HiddenField hiddenField4 = new HiddenField()
                    {
                        ID = string.Concat("hdnDeptNotReqApproval_", row["CartItemID"].ToString()),
                        Value = Convert.ToString(OrderBasePage.Get_Dept_IsApprovalNotRequired(Convert.ToInt64(row["DepartmentID"]))).ToLower()
                    };
                    if (CartBasePage.Product_Exists_Check(Convert.ToInt32(row["ProductID"])) != (long)0)
                    {
                        hiddenField1.Value = "true";
                        hiddenField2.Value = row["CatalogueName"].ToString();
                    }
                    else
                    {
                        hiddenField1.Value = "false";
                    }
                    this.plh_CartItems.Controls.Add(hiddenField1);
                    this.plh_CartItems.Controls.Add(hiddenField2);
                    this.plh_CartItems.Controls.Add(hiddenField3);
                    this.plh_CartItems.Controls.Add(hiddenField4);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    if (!(this.IsEditableProduct.ToLower() == "true") || Convert.ToInt64(row["TemplateImportID"]) <= (long)0)
                    {
                        ControlCollection controls9 = this.plh_CartItems.Controls;
                        //accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);' onclick=javascript:OnEditClick('", str1, "',", row["ProductID"].ToString(), ")><img id='img_Edit_", num, "' class='floatLeft paddingLeft5 img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit Item' alt=' '/></a>" };
                        if (this.IsEnableSubDetail) // Check if IsEnableSubDetail is true
                        {
                            accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);'> </a>" };
                        }
                        else
                        {
                            accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);' onclick=javascript:OnEditClick('", str1, "',", row["ProductID"].ToString(), ")><img id='img_Edit_", num, "' class='floatLeft paddingLeft5 img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit Item' alt=' '/></a>" };
                        }
                        controls9.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    else
                    {
                        ControlCollection controlCollections9 = this.plh_CartItems.Controls;
                        //accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);' onclick=javascript:OnEditClick('", str1, "',", row["ProductID"].ToString(), ")><img id='img_Edit_", num, "' class='floatLeft paddingLeft5 img_trash WS_Cursor_Style DisplayNone' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit Item' alt=' '/></a>" };
                        if (this.IsEnableSubDetail) // Check if IsEnableSubDetail is true
                        {
                            accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);'> </a>" };
                        }
                        else
                        {
                            accountID = new object[] { "<td id='td_actionfields' class='shoppingcart_BorderBottom'><div class='orderNo' style='width:110px;'><img id='img_trash_", num, "' class='floatLeft clearLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=erase.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Remove Item' alt=' ' onclick='javascript:delete_cartitems(\"", this.NewSessionID, "\",", row["CartItemID"].ToString(), ",", this.CartID, ",this.id);'/><a href='javascript:Void(0);' onclick=javascript:OnEditClick('", str1, "',", row["ProductID"].ToString(), ")><img id='img_Edit_", num, "' class='floatLeft paddingLeft5 img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit Item' alt=' '/></a>" };
                        }
                        controlCollections9.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    if ((row["ArtworkFile"].ToString().ToLower() == "y" || row["ArtworkFile"].ToString().ToLower() == "m") && (row["UploadFile"].ToString() != "" || row["UploadFile1"].ToString() != "" || row["UploadFile2"].ToString() != ""))
                    {
                        ControlCollection controls10 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<a ><img id='img_Edit_", num, "' onclick='openArtworkPopup(", row["CartItemID"].ToString(), ",", row["CartID"].ToString(), ") ' class='floatLeft img_trash WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/>" };
                        controls10.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    string empty2 = string.Empty;
                    if (row["PDFNameFromCart"].ToString() != "")
                    {
                        if (row["PreviewType"].ToString() == "" || row["PreviewType"].ToString() == "pdfimg" || row["PreviewType"].ToString() == "pdf")
                        {
                            empty2 = "pdf";
                            ControlCollection controlCollections10 = this.plh_CartItems.Controls;
                            accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", row["PDFNameFromCart"].ToString(), "\",", shoppingcart.AccountID, ",\"", empty2, "\");' ", str, "/></div>" };
                            controlCollections10.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    else if (row["PrintReadyFile"].ToString() != "" && Convert.ToBoolean(row["IsPrintReadyFile"]))
                    {
                        empty2 = "printready";
                        var PrintReadyFileWaterMark = row["PrintReadyFileWaterMark"].ToString();
                        var IsPrintReadyFileWaterMark = Convert.ToBoolean(row["IsPrintReadyFileWaterMark"]);
                        ControlCollection controls11 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<div class='floatLeft paddingLeft5' style='margin-left: -4px;'><img  id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", IsPrintReadyFileWaterMark == true ? PrintReadyFileWaterMark : row["PrintReadyFile"].ToString(), "\",", shoppingcart.AccountID, ",\"", empty2, "\");' ", str, "/></div>" };
                        controls11.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    if (row["ImageNameFromCart"].ToString() != "" && (row["PreviewType"].ToString() == "pdfimg" || row["PreviewType"].ToString() == "img"))
                    {
                        empty2 = "previewimage";
                        ControlCollection controlCollections11 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", row["ImageNameFromCart"].ToString(), "\",", shoppingcart.AccountID, ",\"", this.strSitepath, "\",\"", empty2, "\");' ", str, "/></div>" };
                        controlCollections11.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    if (row["IsStockReplenish"].ToString().ToLower() == "true")
                    {
                        ControlCollection controls12 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<span><img id='img_replenish_", num, "' style='padding-top:5px; padding-left: 2px;' class=' paddingright5' src='", this.strSitepath, "ImageHandler.ashx?ImageName=replenishicon.png&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' title='Replenish Item' alt=' '/></span>" };
                        controls12.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    this.plh_CartItems.Controls.Add(label);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    if (row["ProductImage"].ToString() != "")
                    {
                        accountID = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=", row["ProductImage"].ToString(), "&type=p&aid=", shoppingcart.AccountID, "&cid=", this.CompanyID };
                        this.productImage = string.Concat(accountID);
                    }
                    else
                    {
                        accountID = new object[] { this.strSitepath, "ImageHandler.ashx?ImageName=t_no_image_available.png&type=r&aid=", shoppingcart.AccountID, "&cid=", this.CompanyID };
                        this.productImage = string.Concat(accountID);
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    if (this.ApprovalType.ToLower() == "s")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td id='th_chkEachApprove'>"));
                        HtmlInputCheckBox htmlInputCheckBox2 = new HtmlInputCheckBox()
                        {
                            ID = string.Concat("chkEachApprove", row["CartItemID"].ToString())
                        };
                        htmlInputCheckBox2.Attributes.Add("style", "margin-left: 20px;");
                        if (!this.IsMarkedAllForApprove)
                        {
                            htmlInputCheckBox2.Checked = false;
                        }
                        else
                        {
                            htmlInputCheckBox2.Checked = true;
                        }
                        this.plh_CartItems.Controls.Add(htmlInputCheckBox2);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    }
                    Label label1 = new Label();
                    Label label2 = new Label();
                    Label label3 = new Label();
                    Label label4 = new Label();
                    label1.ID = string.Concat("lbl_productName_", num);
                    label2.ID = string.Concat("lbl_MainProductName_", num);
                    label3.ID = string.Concat("lbl_productDescription_", num);
                    label4.ID = string.Concat("lbl_orderedfor_", num);
                    label4.Style.Add("white-space", "nowrap");
                    label4.ToolTip = base.SpecialDecode(row["OrderedFor"].ToString());
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td class='productname_td shoppingcart_BorderBottom'>"));
                    int num4 = 0;
                    DataTable dataTable = CartBasePage.Select_CartAdditionalItems(Convert.ToInt64(row["CartItemID"]));
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                        {
                            break;
                        }
                        if (Convert.ToInt32(dataRow["OptionID"]) <= 0 && Convert.ToString(dataRow["WebOtherCostType"]) != "Decoration")
                        {
                            continue;
                        }
                        if (num4 == 0)
                        {
                            ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                            accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                            controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                            ControlCollection controls13 = this.plh_CartItems.Controls;
                            accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                            controls13.Add(new LiteralControl(string.Concat(accountID)));
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                            if (this.MainProductId != (long)0)
                            {
                                this.plh_CartItems.Controls.Add(label2);
                                this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                            }
                            this.plh_CartItems.Controls.Add(label1);
                            label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                            label2.Text = base.SpecialDecode(this.MainProductName);
                            if (row["MatrixType"].ToString().ToLower() == "g")
                            {
                                string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                                string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                                languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                                label1.Text = string.Concat(languageConversion);
                            }
                            this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                            ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                            accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                            controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                        Label label5 = new Label();
                        accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                        label5.ID = string.Concat(accountID);
                        label5.Text = base.SpecialDecode(dataRow["UserFriendlyName"].ToString().Trim());
                        this.plh_CartItems.Controls.Add(label5);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                        Label label6 = new Label();
                        var decoration = "";
                        if (Convert.ToString(dataRow["WebOtherCostType"]) == "Decoration")
                        {
                            string[] strSelectedValue = Convert.ToString(dataRow["SelectedValue"]).Split('¶');
                            decoration = strSelectedValue[0];
                        }
                        accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                        label6.ID = string.Concat(accountID);
                        label6.Text = decoration == "" ? dataRow["SelectedValue"].ToString().Trim() : decoration;
                        this.plh_CartItems.Controls.Add(label6);
                        this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                        Label label7 = new Label()
                        {
                            ID = string.Concat("lblPrice_", dataRow["CartAdditionalItemID"].ToString())
                        };
                        if (this.IsEnableHidePrice == "false")
                        {
                            label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalPrice"].ToString().Trim()), 2, "", false, false, true);
                        }
                        if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                        {
                            label7.Style.Add("display", "none");
                        }
                        if ((label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup") || (Convert.ToBoolean(row["IsDisplayAdditionalOptions"])))
                        {
                            label7.Style.Add("display", "none");
                        }
                        this.plh_CartItems.Controls.Add(label7);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                        num4++;
                    }

                    /////////////////////////////Decoration Work start /////////////////////////////Amin
                    //// DataTable dataTable = CartBasePage.Select_CartAdditionalItems(Convert.ToInt64(row["CartItemID"]));
                    //if (Convert.ToString(row["Decoration1_Name"]) != "" && Convert.ToDouble(row["Decoration1Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration1_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration1_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 1)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration1Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}

                    /////////dec2
                    //if (Convert.ToString(row["Decoration2_Name"]) != "" && Convert.ToDouble(row["Decoration2Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration2_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration2_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 2)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration2Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}
                    /////
                    //////////dec3//////////////
                    //if (Convert.ToString(row["Decoration3_Name"]) != "" && Convert.ToDouble(row["Decoration3Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration3_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration3_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 2)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration3Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}
                    /////
                    ///////////////Dec 4
                    //if (Convert.ToString(row["Decoration4_Name"]) != "" && Convert.ToDouble(row["Decoration4Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration4_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration4_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 2)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration4Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}
                    /////
                    ///////////////////Dec5
                    //if (Convert.ToString(row["Decoration5_Name"]) != "" && Convert.ToDouble(row["Decoration5Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration5_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration5_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 2)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration5Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}
                    /////
                    ///////////////dec6
                    //if (Convert.ToString(row["Decoration6_Name"]) != "" && Convert.ToDouble(row["Decoration6Cost"]) > 0)
                    //{
                    //    //if (Convert.ToInt32(dataRow["CheckCount"]) <= 0)
                    //    //{
                    //    //    break;
                    //    //}
                    //    //if (Convert.ToInt32(dataRow["OptionID"]) <= 0)
                    //    //{
                    //    //    continue;
                    //    //}
                    //    if (num4 == 0)
                    //    {
                    //        ControlCollection controlCollections12 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div id='plus_div_", num, "' class='plus_div'><img id='img_plus_", num, "' class='img_plus_minus' onclick='Onclick_img_plus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mplus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to see options selected for this Product'/>" };
                    //        controlCollections12.Add(new LiteralControl(string.Concat(accountID)));
                    //        ControlCollection controls13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "                                              <img id='img_minus_", num, "' class='img_minus' onclick='Onclick_img_minus(", num, ");' src='", this.strSitepath, "ImageHandler.ashx?ImageName=mminus.GIF&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' alt=' ' title='Click to hide details'/></div>" };
                    //        controls13.Add(new LiteralControl(string.Concat(accountID)));
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    //        if (this.MainProductId != (long)0)
                    //        {
                    //            this.plh_CartItems.Controls.Add(label2);
                    //            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                    //        }
                    //        this.plh_CartItems.Controls.Add(label1);
                    //        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                    //        label2.Text = base.SpecialDecode(this.MainProductName);
                    //        if (row["MatrixType"].ToString().ToLower() == "g")
                    //        {
                    //            string str2 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                    //            string str3 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                    //            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span style='padding-left: 15px;' class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str2, " </label><br/>&nbsp;&nbsp;&nbsp;&nbsp;<label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str3, " </label></span>" };
                    //            label1.Text = string.Concat(languageConversion);
                    //        }
                    //        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //        ControlCollection controlCollections13 = this.plh_CartItems.Controls;
                    //        accountID = new object[] { "<div  id='lbl_productDetails_div_", num, "' class='lbl_productDetails_div'><div id='divhide_", num, "'>" };
                    //        controlCollections13.Add(new LiteralControl(string.Concat(accountID)));
                    //    }
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='Othercost_div'>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostName'>"));
                    //    Label label5 = new Label();
                    //    accountID = new object[] { "lblOthercostName_", num, "_", num4 };
                    //    label5.ID = string.Concat(accountID);
                    //    label5.Text = base.SpecialDecode(row["Decoration6_Name"].ToString().Trim());
                    //    this.plh_CartItems.Controls.Add(label5);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostValue'>"));
                    //    Label label6 = new Label();
                    //    accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                    //    label6.ID = string.Concat(accountID);
                    //    label6.Text = row["Decoration6_Name"].ToString().Trim();
                    //    this.plh_CartItems.Controls.Add(label6);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='OthercostPrice'>"));
                    //    Label label7 = new Label()
                    //    {
                    //        ID = string.Concat("lblPrice_", 2)
                    //    };
                    //    if (this.IsEnableHidePrice == "false")
                    //    {
                    //        label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Decoration6Cost"].ToString().Trim()), 2, "", false, false, true);
                    //    }
                    //    //if (dataRow["ParentWebOtherCostID"].ToString() == "0" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup")
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    //if (label7.Text == "0.00" && dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "subgroup" && Convert.ToBoolean(row["IsDisplayAdditionalOptions"]))
                    //    //{
                    //    //    label7.Style.Add("display", "none");
                    //    //}
                    //    this.plh_CartItems.Controls.Add(label7);
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //    this.plh_CartItems.Controls.Add(new LiteralControl("</div><br/>"));
                    //    num4++;
                    //}
                    ///
                    /////////////////////////////End of Decoration   /////////////////////////////
                    if (num4 == 0)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                        if (this.MainProductId != (long)0)
                        {
                            this.plh_CartItems.Controls.Add(label2);
                            this.plh_CartItems.Controls.Add(new LiteralControl("</br>"));
                        }
                        this.plh_CartItems.Controls.Add(label1);
                        label1.Text = base.SpecialDecode(row["CatalogueName"].ToString());
                        label2.Text = base.SpecialDecode(this.MainProductName);
                        if (row["MatrixType"].ToString().ToLower() == "g")
                        {
                            string str4 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Width"].ToString()), 2, "", false, false, true);
                            string str5 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Height"].ToString()), 2, "", false, false, true);
                            languageConversion = new string[] { label1.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str4, " </label><br/><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str5, " </label></span>" };
                            label1.Text = string.Concat(languageConversion);
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td class='orderedfor_td shoppingcart_BorderBottom'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    this.plh_CartItems.Controls.Add(label4);
                    if (ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg" && shoppingcart.AccountID == (long)267)
                    {
                        string str6 = base.SpecialDecode(row["OrderedFor"].ToString());
                        label4.Text = str6.Replace("[Department]", "");
                    }
                    else if (this.deptScreenName != "")
                    {
                        label4.Text = base.SpecialDecode(row["OrderedFor"].ToString()).Replace("[Department]", string.Concat("[", this.deptScreenName, "]"));
                    }
                    else
                    {
                        label4.Text = base.SpecialDecode(row["OrderedFor"].ToString());
                    }
                    if (row["DeptAttn"] != null)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div style='white-space:nowrap' class='smallfont'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("For_the_attention_of")));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='smallfontgrey'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl(base.SpecialDecode(row["DeptAttn"].ToString())));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td class='productname_td shoppingcart_BorderBottom'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                    this.plh_CartItems.Controls.Add(label3);
                    label3.Text = base.SpecialDecode(row["ShortDescription"].ToString());
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    if (this.IsCampaignEnabled.ToLower() == "true")
                    {
                        Label label8 = new Label();
                        HiddenField hiddenField5 = new HiddenField()
                        {
                            ID = string.Concat("hdnCampaginManageID_", row["CartItemID"].ToString())
                        };
                        label8.ID = string.Concat("lbl_CampaignName_", row["CartItemID"].ToString());
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td style='width: 200px; text-align: left;' class='shoppingcart_BorderBottom'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='paddingLeft5'>"));
                        this.plh_CartItems.Controls.Add(label8);
                        label8.Text = base.SpecialDecode(row["EventName"].ToString());
                        ControlCollection controls14 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", row["ManageID"].ToString(), " id='hdnCampaginManageID_", row["CartItemID"].ToString(), "' >" };
                        controls14.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections14 = this.plh_CartItems.Controls;
                        languageConversion = new string[] { "<input type='hidden' value=", row["IsManageCampaignDeleted"].ToString(), " id='isManageCampaignDeleted_", row["CartItemID"].ToString(), "' >" };
                        controlCollections14.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    }
                    TextBox textBox = new TextBox()
                    {
                        ID = string.Concat("txt_jobName_", row["CartItemID"].ToString()),
                        Text = row["JobName"].ToString(),
                        CssClass = "ws_txtWidth240"
                    };
                    if(Convert.ToBoolean(row["IsShowJobName"]))
                    {
                        textBox.Attributes.Add("disabled", "disabled");
                        textBox.Style.Add("background-color", "#EBEBE4");
                    }
                    else
                    {
                        textBox.Attributes.Remove("disabled");
                    }
                    textBox.Style.Add("padding-left", "3px");
                    textBox.Style.Add("width", "200px");
                    if (this.isCartJobName == "1")
                    {
                        if (this.CartJobScreenNameShow)
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td class='jobNametd_width265 shoppingcart_BorderBottom'>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<td class='jobNametd_width265 shoppingcart_BorderBottom' style='display:none;'>"));
                        }
                    }
                    else if (this.CartJobScreenNameShow)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='jobNametd_width265 DisplayNone paddingLeft5'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='jobNametd_width265 DisplayNone paddingLeft5' style='display:none'>"));
                    }
                    this.plh_CartItems.Controls.Add(textBox);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    empty1 = string.Concat(empty1, row["CartItemID"].ToString(), "µ");
                    Label label9 = new Label()
                    {
                        ID = string.Concat("lbl_unitPrice_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["UnitPrice"].ToString()), 2, "", false, false, true)
                    };
                    if (!(this.isCartUnitPrice == "1") || !(this.IsEnableHidePrice == "false"))
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='shoppingcart_BorderBottom TextAlignRight clearTop paddingRight5'>"));
                    }
                    this.plh_CartItems.Controls.Add(label9);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    Label label10 = new Label();
                    if (this.IsZip2taxEnabled != true)
                    {
                        label10 = new Label()
                        {
                            ID = string.Concat("lbl_TaxApplicable_", num),
                            Text = string.Concat(row["SalesTaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["TaxRate"]), 2, "", false, false, true)), "%")
                        };
                    }
                    else
                    {
                        label10 = new Label()
                        {
                            ID = string.Concat("lbl_TaxApplicable_", num),
                            //Text = string.Concat(row["SalesTaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["TaxRate"]), 2, "", false, false, true)), "%")
                            Text = string.Concat("  ", "")
                        };
                    }
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='shoppingcart_BorderBottom TextAlignLeft clearTop paddingRight5' style='word-break:break-all; padding-left:13px'>"));
                    }
                    this.plh_CartItems.Controls.Add(label10);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    Label label11 = new Label()
                    {
                        ID = string.Concat("lbl_qty_", Convert.ToInt64(row["CartItemID"].ToString())),
                        Text = row["Quantity"].ToString(),
                        CssClass = "qty_td_lbl"
                    };
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td class='qty_td shoppingcart_BorderBottom' style='word-break:normal'>"));
                    this.plh_CartItems.Controls.Add(label11);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    Label label12 = new Label()
                    {
                        ID = string.Concat("lbl_Discount_", row["CartItemID"].ToString()),
                        Text = "0.00"
                    };
                    if (!this.ISCouponCodeEnabled)
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    }
                    else if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='shoppingcart_BorderBottom TextAlignRight clearTop paddingRight5'>"));
                    }
                    this.plh_CartItems.Controls.Add(label12);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    num2 = num2 + Convert.ToInt32(row["Quantity"].ToString());
                    Label str7 = new Label()
                    {
                        ID = string.Concat("lbl_tax_", Convert.ToInt64(row["CartItemID"].ToString()))
                    };
                    HiddenField hiddenField6 = new HiddenField()
                    {
                        ID = string.Concat("hdnlbl_tax_", Convert.ToInt64(row["CartItemID"].ToString()))
                    };
                    decimal num5 = Convert.ToDecimal(row["CartTax"].ToString());
                    str7.Text = num5.ToString();
                    this.plh_CartItems.Controls.Add(new LiteralControl("<td class='shoppingcart_BorderBottom TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    this.plh_CartItems.Controls.Add(str7);
                    this.plh_CartItems.Controls.Add(hiddenField6);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    Label label13 = new Label()
                    {
                        ID = string.Concat("lbl_subTotal_", Convert.ToInt64(row["CartItemID"].ToString()))
                    };
                    HiddenField hiddenField7 = new HiddenField()
                    {
                        ID = string.Concat("hdnlbl_subTotal_", Convert.ToInt64(row["CartItemID"].ToString()))
                    };
                    decimal num6 = Convert.ToDecimal(row["CartTotalPrice"].ToString());
                    label13.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num6), 2, "", false, false, true);
                    label13.Style.Add("float", "right");
                    if (!(this.isCartTotal == "1") || !(this.IsEnableHidePrice == "false"))
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='TextAlignRight clearTop paddingRight5 DisplayNone'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<td class='shoppingcart_BorderBottomNew'>"));
                    }
                    this.plh_CartItems.Controls.Add(label13);
                    this.plh_CartItems.Controls.Add(hiddenField7);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</tr>"));
                    num++;
                    num1 = (short)(num1 + 1);
                }
                this.hid_ItemsLength.Value = num.ToString();
                this.hdnCartItems.Value = empty1;
                this.hid_TotalNoOfCartItems.Value = num1.ToString();
                if (num == 0)
                {
                    this.div_ShoppingItems.Style.Add("display", "block");
                    this.grandTotal_div.Style.Add("display", "none");
                    this.Shoppingcard_div.Style.Add("height", "400px");
                    this.productAdded.Style.Add("display", "block");
                }
                if (dtCart.Rows.Count <= 0)
                {
                    if (this.ApprovalType.ToLower() != "s")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td align='left' colspan='10' id='td_NoCartItems'>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td align='left' colspan='11' id='td_NoCartItems'>"));
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div>", this.objLanguage.GetLanguageConversion("No_items_in_cart"), "</div>")));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));
                }
                else
                {
                    if (this.ApprovalType.ToLower() != "s")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td colspan='12' id='tableFooter' class='shoppingCart_HeaderFooter' >"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td colspan='13' id='tableFooter' class='shoppingCart_HeaderFooter' >"));
                    }
                    Label label14 = new Label()
                    {
                        ID = "lblTotaltaxID"
                    };
                    HiddenField hiddenField8 = new HiddenField()
                    {
                        ID = "hdnlblTotaltaxID"
                    };
                    Label label15 = new Label()
                    {
                        ID = "lblTotalPriceID"
                    };
                    HiddenField hiddenField9 = new HiddenField()
                    {
                        ID = "hdnlblTotalPriceID"
                    };
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    this.hid_TotalExTax.Value = num8.ToString();
                    this.hid_TotalIncTax.Value = (num7 + num8).ToString();
                    this.hid_TotalQty.Value = num2.ToString();
                    if (this.IsZip2taxEnabled != true) {
                        label14.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num7), 2, "", false, false, true);
                        TaxDetail = "Total Tax";
                    }
                    else
                    {
                        label14.Visible = false;
                        TaxDetail = "Tax To Be Calculated At Checkout";
                    }
                    label15.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num8), 2, "", false, false, true);
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='marginTop5px'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<br>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_StoreCredit' class=' floatLeft'>"));
                    Label labelStoreCredit = new Label()
                    {
                        ID = "lblStoreCredit",
                        Text = "Store Credit is: 50$"
                    };
                    if (!IsStoreCredit)
                    {
                        labelStoreCredit.Style.Add("display", "none");
                    }

                    this.plh_CartItems.Controls.Add(labelStoreCredit);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));

                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_subtotal_main' class='cart_additional_content_right'>"));
              
                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div id='div_CouponCode' style='white-space: nowrap; float: left;opacity: 1;padding-bottom: 2%;width: 60%;", this.CouponCodeDisplay, "'>")));
                    Label label16 = new Label()
                    {
                        ID = "lblCouponCode",
                        Text = this.objLanguage.GetLanguageConversion("Have_Coupon_Code")
                    };
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_lblCouponcode' style='white-space: nowrap; float: left;'>"));
                    this.plh_CartItems.Controls.Add(label16);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<br/>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_txtCouponcode' style='white-space: nowrap; float: left;position: relative;padding-top:1%;'>"));
                    TextBox textBox1 = new TextBox()
                    {
                        ID = "txt_CouponCode",
                        CssClass = "ws_txtWidth240"
                    };
                    textBox1.Style.Add("margin-left", "0");
                    this.plh_CartItems.Controls.Add(textBox1);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_btnCouponcode' style='white-space: nowrap; float: left;padding-left:2%;position: relative;top: -2px;padding-top:1%;'>"));
                    Button button = new Button()
                    {
                        ID = "btn_CouponCodeApplay",
                        CssClass = "x-btnpro Grey main",
                        Text = "Apply"
                    };
                    button.Style.Add("margin-left", "1px");
                    button.Style.Add("min-width", "150px");
                    button.OnClientClick = "javascript: ApplayCouponCode(); return false;";
                    this.plh_CartItems.Controls.Add(button);
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_ClearCouponCode' style='display: none;margin-top: 12%; float: left;text-decoration: underline;cursor: pointer;color:#10357f;' ><a href='#' style='color:#10357f;' onclick='javascript:ClearCouponCode(); return false;'> Clear </a></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<br />"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<table style='width: 90%;'><tr><td style='padding-top: 2px;'>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_CouponCode' style='white-space: nowrap; float: left;'>"));
                    Label label17 = new Label()
                    {
                        ID = "lblInvalidCouponCode",
                        Text = "Invalid CouponCode"
                    };
                    label17.Style.Add("color", "Red");
                    label17.Style.Add("display", "none");
                    this.plh_CartItems.Controls.Add(label17);
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));



                    //this.plh_CartItems.Controls.Add(new LiteralControl("<tr><td style='padding-top: 2px;'>"));
                    //this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_StoreCr  edit' style='white-space: nowrap; float: left;'>"));
                    //Label labelStoreCredit = new Label()
                    //{
                    //    ID = "lblStoreCredit",
                    //    Text = "Store Credit is: 50$"
                    //};
                    //if (!IsStoreCredit)
                    //{
                    //    labelStoreCredit.Style.Add("display", "none");
                    //}
                  
                    //this.plh_CartItems.Controls.Add(labelStoreCredit);
                    //this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                    //this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));



                    this.plh_CartItems.Controls.Add(new LiteralControl("</table>"));
                   
                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
             
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_subtotal_inner' class='Visibilityhidden' style='width:27.1%;'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("Price (ex. Tax)"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_SubTotal_Value' >"));
                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='totalcost_right Visibilityhidden' style='font-weight:bold;'", this.displaySubTotal, ">")));
                        this.plh_CartItems.Controls.Add(label15);
                        this.plh_CartItems.Controls.Add(hiddenField9);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div></div></div>"));
                    }
                    else
                    {
                        if (this.IsZip2taxEnabled != false)
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_subtotal_inner' style='width:27.1%;font-size: larger;'>"));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_subtotal_inner' style='width:27.1%;'>"));
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl("Price (ex. Tax)"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_SubTotal_Value' >"));
                        if (this.IsZip2taxEnabled != false)
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='totalcost_right' style='font-weight:bold;font-size: larger;'", this.displaySubTotal, ">")));
                        }
                        else
                        {
                            this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<div class='totalcost_right' style='font-weight:bold;'", this.displaySubTotal, ">")));
                        }
                        this.plh_CartItems.Controls.Add(label15);
                        this.plh_CartItems.Controls.Add(hiddenField9);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div></div></div>"));
                    }
                    if (this.isCartGrandTotal == "0")
                    {
                        this.div_grandTotal.Style.Add("display", "none");
                    }
                    int num9 = 0;
                    int num10 = 0;
                    int num11 = 0;
                    int num12 = 0;
                    int length = 0;
                    DataTable dataTable1 = CartBasePage.Select_CartAdditionalOptions(this.NewSessionID, this.StoreUserID, "");
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                    DataTable dataTable2 = CartBasePage.ShoppingCart_AdditionalOption_Select((long)this.CompanyID, shoppingcart.AccountID, "no");
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        DataSet dataSet = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(row1["WebOtherCostID"].ToString()));
                        DataTable item = dataSet.Tables[0];
                        foreach (DataRow dataRow1 in item.Rows)
                        {
                            dataRow1["WebOtherCostName"] = base.SpecialDecode(dataRow1["WebOtherCostName"].ToString());
                            dataRow1["Description"] = base.SpecialDecode(dataRow1["DEscription"].ToString());
                            dataRow1["UserFriendlyName"] = base.SpecialDecode(dataRow1["UserFriendlyName"].ToString());
                        }
                        DataTable item1 = dataSet.Tables[1];
                        foreach (DataRow row2 in item1.Rows)
                        {
                            row2["LAbel"] = base.SpecialDecode(row2["Label"].ToString());
                        }
                        Convert.ToInt64(row1["WebOtherCostID"].ToString());
                        num12++;
                        string empty3 = string.Empty;
                        foreach (DataRow dataRow2 in item.Rows)
                        {
                            this.MainCalculationtype = dataRow2["MainCalculationType"].ToString();
                            this.HelpText = dataRow2["Description"].ToString().Replace("\n", "<br>");
                            this.OtherCostName = dataRow2["UserFriendlyName"].ToString();
                            this.VisibletoCart = dataRow2["VisibletoCart"].ToString();
                            this.IsCartmandatory = Convert.ToBoolean(dataRow2["IsCartmandatory"]);
                            try
                            {
                                if (this.OtherCostName.Length <= 70)
                                {
                                    this.OtherCostName = this.OtherCostName.Trim();
                                }
                                else
                                {
                                    this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                                }
                            }
                            catch
                            {
                            }
                        }
                        int num13 = 0;
                        foreach (DataRow row3 in item1.Rows)
                        {
                            int num14 = 0;
                            int num15 = 0;
                            decimal num16 = new decimal(0);
                            decimal num17 = new decimal(0);
                            string empty4 = string.Empty;
                            if (this.MainCalculationtype.ToLower() == "q")
                            {
                                string str8 = row3["formula"].ToString();
                                string str9 = row3["Question"].ToString();
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content floatLeft width100p' align='right'>"));
                                if (this.IsEnableHidePrice != "false")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left' style='width:99%;'>"));
                                }
                                else
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                }
                                ControlCollection controls15 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblQuestion_", num9, "' > ", this.OtherCostName, "<br/>", str9, "</label>" };
                                controls15.Add(new LiteralControl(string.Concat(accountID)));
                                if (this.HelpText != "")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void();' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections15 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' /></a>" };
                                    controlCollections15.Add(new LiteralControl(string.Concat(accountID)));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle MainCalcType_Q_content_middle' style='white-space:nowrap;'>"));
                                ControlCollection controls16 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<br/><div class='paddingBottom5'><label id='lblPrice_", num9, "' >(", this.comm.GetCurrencyinRequiredFormate("0.00", true), ") </label><label id='lblQuestionID_", num9, "' class='DisplayNone'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num9, "'  class='DisplayNone'>", str8, " </label><label id='lblQuestionSortOrderNo_", num9, "' class='DisplayNone'>", num12, "</label>" };
                                controls16.Add(new LiteralControl(string.Concat(accountID)));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_Q_content_right'  align='right'>"));
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
                                    foreach (DataRow dataRow3 in dataTable1.Rows)
                                    {
                                        if (Convert.ToInt32(dataRow3["OptionID"]) != Convert.ToInt32(row1["WebOtherCostID"].ToString()))
                                        {
                                            continue;
                                        }
                                        num14 = Convert.ToInt32(dataRow3["OptionID"]);
                                        num15 = Convert.ToInt32(dataRow3["SelectedID"]);
                                        num16 = Convert.ToDecimal(dataRow3["MarkupValue"]);
                                        num17 = Convert.ToDecimal(dataRow3["TotalPrice"]);
                                        dataRow3["SelectedValue"].ToString();
                                        Convert.ToDecimal(dataRow3["SelectedPrice"]);
                                        Convert.ToDecimal(dataRow3["Markup"]);
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content floatLeft width100p' align='right'>"));
                                    if (num14 != Convert.ToInt32(row1["WebOtherCostID"].ToString()))
                                    {
                                        ControlCollection controlCollections16 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<input id='chkMultiple_", num10, "' class='DisplayNone' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Cart_Onchange_MultipleChoice(", num10, ");'/>" };
                                        controlCollections16.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls17 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<input id='chkMultiple_", num10, "' class='DisplayNone' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num10, ");'/>" };
                                        controls17.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    length = this.OtherCostName.Length;
                                    if (this.IsEnableHidePrice != "false")
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left' style='width:99%;'>"));
                                    }
                                    else
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_img_help'>"));
                                    ControlCollection controlCollections17 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<label id='lblMatrixName_", num10, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                    controlCollections17.Add(new LiteralControl(string.Concat(accountID)));
                                    if (this.HelpText != "")
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void();' class='tooltip' title='", this.HelpText, "'>")));
                                        ControlCollection controls18 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' /></a>" };
                                        controls18.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle MainCalcType_C_content_middle' style='white-space:nowrap;'>"));
                                    if (this.IsEnableHidePrice != "false")
                                    {
                                        ControlCollection controlCollections18 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<div><label class='paddingTop5 DisplayNone' id='lblMultipleID_", num10, "' >", row1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num10, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num10, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num10, "' class='DisplayNone'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num17, 0, "", false, false, true), "</label><label id='lblMultipleMarkupValue_", num10, "' class='DisplayNone'>", num16, "</label><label id='lblMultipleSortOrderNo_", num10, "' class='DisplayNone'>", num12, "</label>" };
                                        controlCollections18.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    else
                                    {
                                        ControlCollection controls19 = this.plh_CartItems.Controls;
                                        accountID = new object[] { "<div><label class='paddingTop5 DisplayNone' id='lblMultipleID_", num10, "' >", row1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num10, "' class='DisplayNone'></label><label id='lblMultipleMarkup_", num10, "' class='DisplayNone'></label><label id='lblMultiplePrice_", num10, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num17, 0, "", false, false, true), "</label><label id='lblMultipleMarkupValue_", num10, "' class='DisplayNone'>", num16, "</label><label id='lblMultipleSortOrderNo_", num10, "' class='DisplayNone'>", num12, "</label>" };
                                        controls19.Add(new LiteralControl(string.Concat(accountID)));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                    if (length <= 80)
                                    {
                                        if (this.IsEnableHidePrice != "false")
                                        {
                                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_C_content_right'style='width:99%;' >"));
                                        }
                                        else
                                        {
                                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_C_content_right' >"));
                                        }
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='MainCalcType_C_content_right_innerdiv' >"));
                                    }
                                    else
                                    {
                                        if (this.IsEnableHidePrice != "false")
                                        {
                                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_C_content_right'style='width:99%;' >"));
                                        }
                                        else
                                        {
                                            this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_C_content_right' >"));
                                        }
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='MainCalcType_C_content_right_innerdiv' >"));
                                    }
                                    length = 0;
                                    DropDownList dropDownList = new DropDownList()
                                    {
                                        ID = string.Concat("ddlMultiple_", num10)
                                    };
                                    dropDownList.Style.Add("margin-top", "-10px");
                                    dropDownList.CssClass = "dropDownMultiple250_right";
                                    dropDownList.Attributes.Add("onchange", "javascript:Cart_Additional_Price();");
                                    dropDownList.Attributes.Add("isRequired", this.IsCartmandatory.ToString());
                                    if (num14 != Convert.ToInt32(row1["WebOtherCostID"].ToString()))
                                    {
                                        this.comm.MultipleChoice_DropDownBind(item1, dropDownList, this.plh_CartItems, row3["CalculationType"].ToString());
                                    }
                                    else
                                    {
                                        this.MultipleChoice_DropDownBind(item1, dropDownList, this.plh_CartItems, row3["CalculationType"].ToString(), "edit", num15);
                                    }
                                    if (!this.IsCartmandatory)
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<span style='color: Red;padding-left:5px;'></span>"));
                                    }
                                    else
                                    {
                                        this.plh_CartItems.Controls.Add(new LiteralControl("<span style='color: Red;padding-left:5px;'>*</span>"));
                                    }
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                                    num10++;
                                }
                            }
                            else if (this.MainCalculationtype.ToLower() == "m" && num13 == 0)
                            {
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth'></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='price_table_content floatLeft width100p' align='right'>"));
                                row3["matrixType"].ToString();
                                if (this.IsEnableHidePrice != "false")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left' style='width:99%;'>"));
                                }
                                else
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_left'>"));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                                ControlCollection controlCollections19 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='MainCalcType_M_content_left'><input id='chkMatrix_", num11, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' onclick='Cart_Additional_Price();'/></div>" };
                                controlCollections19.Add(new LiteralControl(string.Concat(accountID)));
                                ControlCollection controls20 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<div class='lbl_terms_conditionsDiv'><label id='lblMatrixName_", num11, "' > ", base.SpecialDecode(this.OtherCostName), "</label>" };
                                controls20.Add(new LiteralControl(string.Concat(accountID)));
                                if (this.HelpText != "")
                                {
                                    this.plh_CartItems.Controls.Add(new LiteralControl(string.Concat("<a href='javascript:void(0)' class='tooltip' title='", this.HelpText, "'>")));
                                    ControlCollection controlCollections20 = this.plh_CartItems.Controls;
                                    accountID = new object[] { "<img id='img_help' src='", this.strSitepath, "ImageHandler.ashx?ImageName=icon_tooltip.gif&amp;type=r&amp;aid=", shoppingcart.AccountID, "&amp;cid=", this.CompanyID, "' /></a>" };
                                    controlCollections20.Add(new LiteralControl(string.Concat(accountID)));
                                }
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_middle MainCalcType_M_content_middle' style='white-space:nowrap;'><div class='paddingBottom5'>"));
                                ControlCollection controls21 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblMatrixID_", num11, "' class='DisplayNone'>", row1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num11, "' class='DisplayNone'>", row3["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup_", num11, "' class='DisplayNone'></label><label id='lblMatrixSortOrderNo_", num11, "' class='DisplayNone'>", num12, "</label>" };
                                controls21.Add(new LiteralControl(string.Concat(accountID)));
                                ControlCollection controlCollections21 = this.plh_CartItems.Controls;
                                accountID = new object[] { "<label id='lblMatrixPrice_", num11, "' >(", this.comm.GetCurrencyinRequiredFormate("0.00", true), ")</label></div>" };
                                controlCollections21.Add(new LiteralControl(string.Concat(accountID)));
                                this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                                this.plh_CartItems.Controls.Add(new LiteralControl("<div class='cart_additional_content_right MainCalcType_M_content_right'>"));
                                if (row3["matrixType"].ToString().ToLower() != "pricebands")
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
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='clearBoth clearTop'></div>"));
                    if (this.IsEnableHidePrice != "false")
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='floatLeft width100p' style='visibility:hidden'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='lbl_terms_conditionsDiv'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_TaxRate' style='font-weight:normal;'>"));
                        string languageConversion1 = string.Empty;
                        decimal num18 = new decimal(0);
                        long num19 = (long)0;
                        foreach (DataRow row4 in ProductBasePage.GetTaxDetails(this.CompanyID, this.StoreUserID).Rows)
                        {
                            num19 = Convert.ToInt64(row4["TaxID"]);
                            //languageConversion1 = "Total Tax";
                            languageConversion1 = TaxDetail;
                            num18 = Convert.ToDecimal(row4["TaxRate"].ToString());
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl(languageConversion1 ?? ""));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        ControlCollection controls22 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<div class='totalcost_right' id='div_lblTaxRate'><label id='lblTaxRate' class='DisplayNone'>", num18, "</label><label id='lblTaxID' class='DisplayNone'>", num19, "</label>" };
                        controls22.Add(new LiteralControl(string.Concat(accountID)));
                        this.plh_CartItems.Controls.Add(label14);
                        this.plh_CartItems.Controls.Add(hiddenField8);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                    }
                    else
                    {
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='floatLeft width100p'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div class='lbl_terms_conditionsDiv'>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("<div id='div_TaxRate' style='font-weight:normal;'>"));
                        string languageConversion2 = string.Empty;
                        decimal num20 = new decimal(0);
                        long num21 = (long)0;
                        foreach (DataRow dataRow4 in ProductBasePage.GetTaxDetails(this.CompanyID, this.StoreUserID).Rows)
                        {
                            num21 = Convert.ToInt64(dataRow4["TaxID"]);
                            //languageConversion2 = "Total Tax";
                            languageConversion2 = TaxDetail;
                            num20 = Convert.ToDecimal(dataRow4["TaxRate"].ToString());
                        }
                        this.plh_CartItems.Controls.Add(new LiteralControl(languageConversion2 ?? ""));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div>"));
                        ControlCollection controlCollections22 = this.plh_CartItems.Controls;
                        accountID = new object[] { "<div class='totalcost_right' id='div_lblTaxRate'><label id='lblTaxRate' class='DisplayNone'>", num20, "</label><label id='lblTaxID' class='DisplayNone'>", num21, "</label>" };
                        controlCollections22.Add(new LiteralControl(string.Concat(accountID)));
                        this.plh_CartItems.Controls.Add(label14);
                        this.plh_CartItems.Controls.Add(hiddenField8);
                        this.plh_CartItems.Controls.Add(new LiteralControl("</div></div>"));
                    }
                    this.plh_CartItems.Controls.Add(new LiteralControl("<div class='ClearDivTop20'></div>"));
                    this.plh_CartItems.Controls.Add(new LiteralControl("</td></tr>"));
                }
                this.plh_CartItems.Controls.Add(new LiteralControl("</table>"));
            }
            catch
            {
               
            }
        }

        public static void GeneratePdf()
        {
        }

        public void lnbDeleteSelected_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            this.hdnChecked.Value = this.hdnChecked.Value.Substring(0, this.hdnChecked.Value.Length - 1);
            this.hdnCartID.Value = this.hdnCartID.Value.Substring(0, this.hdnCartID.Value.Length - 1);
            string[] strArrays = this.hdnChecked.Value.Split(new char[] { ',' });
            string[] strArrays1 = this.hdnCartID.Value.Split(new char[] { ',' });
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                CartBasePage.Delete_CartItem_B2B(Convert.ToInt64(strArrays[i]), Convert.ToInt64(strArrays1[i]));
            }
            dataTable = CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID);
            this.Pdfvalues = "";
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                this.IsEditableProduct = row["IsEditableProduct"].ToString().ToLower();
                this.IsPdfGenerated = ProductBasePage.CheckPDF_Generated(Convert.ToInt32(row["TemplateImportID"]));
                if (this.IsEditableProduct.ToLower() == "true" && Convert.ToInt64(row["TemplateImportID"]) > (long)0)
                {
                    if (this.IsPdfGenerated == 0)
                    {
                        empty = "false";
                    }
                    else if (this.IsPdfGenerated == 1)
                    {
                        empty = "true";
                    }
                    else if (this.IsPdfGenerated == 2)
                    {
                        empty = "error";
                    }
                    if (this.Pdfvalues != "")
                    {
                        string[] pdfvalues = new string[] { this.Pdfvalues, ">>", this.IsEditableProduct, "_", empty, "_", row["CartItemId"].ToString() };
                        this.Pdfvalues = string.Concat(pdfvalues);
                    }
                    else
                    {
                        string[] isEditableProduct = new string[] { this.IsEditableProduct, "_", empty, "_", row["CartItemId"].ToString() };
                        this.Pdfvalues = string.Concat(isEditableProduct);
                    }
                }
                else if (this.Pdfvalues != "")
                {
                    this.Pdfvalues = string.Concat(this.Pdfvalues, ">>true_true_", row["CartItemId"].ToString());
                }
                else
                {
                    this.Pdfvalues = string.Concat("true_true_", row["CartItemId"].ToString());
                }
            }
            this.GenerateCartList(dataTable);
            this.lblSucess.Text = "Selected products deleted from your shopping cart";
            this.lblSucess.Visible = true;
            this.imgSucess.Visible = true;
        }

        public void Message_Display(string strMsg, string cssclass, PlaceHolder plh)
        {
            plh.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/message_display.ascx");
            plh.Controls.Add(userControl);
            Timer timer = (Timer)userControl.FindControl("TimerMessage");
            Label label = (Label)userControl.FindControl("lblMessage");
            ((Panel)userControl.FindControl("pnlMessage")).CssClass = cssclass;
            timer.Interval = 5000;
            label.Text = strMsg;
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

            this.CurrencySymbol = this.comm.GetCurrencyinRequiredFormate("", true);

            DataTable dataTable = new DataTable();
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "Default.aspx'></a><span Class='floatLeft' ></span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx'>", this.objLanguage.GetLanguageConversion("Product_List"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft' href ='", BaseClass.SitePath, "shoppingcart.aspx'></a>", this.objLanguage.GetLanguageConversion("Shopping_Cart") };
            label.Text = string.Concat(sitePath);
            this.lblSucess.Text = this.objLanguage.GetLanguageConversion("No_items_in_cart");
            this.btn_ContinueShopping.Text = this.objLanguage.GetLanguageConversion("Back_to_Products");
            this.btn_proceedCheckout.Text = this.objLanguage.GetLanguageConversion("Proceed_to_Checkout");
            this.Prod_NoMoreExists_MSG = this.objLanguage.GetLanguageConversion("Prod_NoMoreExists_MSG");
            this.Order_Deltd_Prod_Msg1 = this.objLanguage.GetLanguageConversion("Multiple_Products");
            this.Order_Deltd_Prod_Msg2 = this.objLanguage.GetLanguageConversion("Deleted_Product_Proceed_To_CheckOut_Msg");
            this.Order_Deltd_Prod_Msg3 = this.objLanguage.GetLanguageConversion("Deleted_Product_Proceed_To_CheckOut_Msg_Single");
            this.Order_Deltd_Prod_Msg4 = this.objLanguage.GetLanguageConversion("Single_Product");
            this.Category_ReqApproval_Msg = this.objLanguage.GetLanguageConversion("Category_ApprovalNot_Req_ShoppingCart_Validation_Msg");
            this.deptScreenName = base.Return_ApprovalRegistration_Settings("deptscreenname");
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
                shoppingcart.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.RewriteModule != null && ConnectionClass.RewriteModule != "")
            {
                this.RewriteModule = ConnectionClass.RewriteModule;
            }
            base.Title = commonclass.pageTitle("Cart", Convert.ToInt32(this.CompanyID), Convert.ToInt32(shoppingcart.AccountID));
            DataTable dataTable1 = ProductBasePage.Setting_SpendLimit_Select(shoppingcart.AccountID, (long)this.CompanyID);
            if (dataTable1.Rows.Count <= 0)
            {
                this.IsSpendLimitEnable = "false";
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable1.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();
                    this.IsSpendLimitEnable = row["IsSpendlimitEnabled"].ToString();
                }
            }
            if (ConnectionClass.ImagePath != null)
            {
                shoppingcart.imagePath = ConnectionClass.ImagePath.ToString();
            }
            if (ConnectionClass.ProductImagePath != null)
            {
                this.productImagePath = ConnectionClass.ProductImagePath;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                this.StyleSheetPath = ConnectionClass.StyleSheetPath;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                this.UserType = LoginBasePage.UserTypeCheck(this.StoreUserID);
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
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
            if (!base.IsPostBack)
            {
                CartBasePage.DeliveryCostAdjustments_CartItems();
                dataTable = CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID);
                assignStoreCredit(0, dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    HtmlImage htmlImage = this.imgSucess;
                    object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=Ok-icon.png&amp;type=r&amp;aid=", shoppingcart.AccountID, " &amp;cid=", this.CompanyID };
                    htmlImage.Src = string.Concat(accountID);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.ISCouponCodeEnabled = Convert.ToBoolean(dataRow["ISCouponCodeEnabled"]);
                    }
                    if (base.Request.QueryString["ID"] != null)
                    {
                        if (base.Request.QueryString["ID"] != "0")
                        {
                            DataRow[] dataRowArray = dataTable.Select(string.Concat("CartID=", base.Request.QueryString["ID"].ToString()));
                            if ((int)dataRowArray.Length > 0)
                            {
                                Label label1 = this.lblSucess;
                                object[] objArray = new object[] { '\"', base.SpecialDecode(dataRowArray[0]["CatalogueName"].ToString()), '\"', this.objLanguage.GetLanguageConversion("Added_to_your_shopping_cart") };
                                label1.Text = string.Concat(objArray);
                                this.lblSucess.Visible = true;
                                this.imgSucess.Visible = true;
                            }
                        }
                        else
                        {
                            this.lblSucess.Visible = false;
                            this.imgSucess.Visible = false;
                        }
                    }
                }
            }
            DataTable dataTable2 = CartBasePage.default_settings(Convert.ToInt32(this.CompanyID), Convert.ToInt32(shoppingcart.AccountID));
            if (dataTable2.Rows.Count > 0)
            {
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    this.IsSelectAllcartItems = Convert.ToBoolean(row1["Is_Select_AllCartItems"]);
                    this.CartJobScreenNameShow = Convert.ToBoolean(row1["CartJobNameShow"]);
                    this.CartJobScreenName = Convert.ToString(row1["CartJobScreenName"]);
                    this.CartJobNameIsMandatory = Convert.ToBoolean(row1["CartJobNameIsMandatory"]);
                    this.CartJobScreenNameForAlert = base.SpecialEncode(Convert.ToString(row1["CartJobScreenName"]));
                }
            }
            if (!this.CartJobScreenNameShow)
            {
                this.btn_SaveAndStay.Style.Add("display", "none");
            }
            CartBasePage.DeliveryCostAdjustments_CartItems();
            dataTable = CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID);
            foreach (DataRow dataRow1 in dataTable.Rows)
            {
                string empty = string.Empty;
                this.ISCouponCodeEnabled = Convert.ToBoolean(dataRow1["ISCouponCodeEnabled"]);
                this.IsEditableProduct = dataRow1["IsEditableProduct"].ToString().ToLower();
                this.IsPdfGenerated = ProductBasePage.CheckPDF_Generated(Convert.ToInt32(dataRow1["TemplateImportID"]));
                if (this.IsEditableProduct.ToLower() == "true" && Convert.ToInt64(dataRow1["TemplateImportID"]) > (long)0)
                {
                    if (this.IsPdfGenerated == 0)
                    {
                        empty = "false";
                    }
                    else if (this.IsPdfGenerated == 1)
                    {
                        empty = "true";
                    }
                    else if (this.IsPdfGenerated == 2)
                    {
                        empty = "error";
                    }
                    if (this.Pdfvalues != "")
                    {
                        string[] pdfvalues = new string[] { this.Pdfvalues, ">>", this.IsEditableProduct, "_", empty, "_", dataRow1["CartItemId"].ToString() };
                        this.Pdfvalues = string.Concat(pdfvalues);
                    }
                    else
                    {
                        string[] isEditableProduct = new string[] { this.IsEditableProduct, "_", empty, "_", dataRow1["CartItemId"].ToString() };
                        this.Pdfvalues = string.Concat(isEditableProduct);
                    }
                }
                else if (this.Pdfvalues != "")
                {
                    this.Pdfvalues = string.Concat(this.Pdfvalues, ">>true_true_", dataRow1["CartItemId"].ToString());
                }
                else
                {
                    this.Pdfvalues = string.Concat("true_true_", dataRow1["CartItemId"].ToString());
                }
                if (dataRow1["IsSpendlimitEnabled"].ToString().ToLower() != "true")
                {
                    continue;
                }
                if (this.SpendLimitData != "")
                {
                    object[] spendLimitData = new object[] { this.SpendLimitData, dataRow1["CartItemId"], "±", dataRow1["contactID"], "±", dataRow1["SpendLimitAmount"], "±", dataRow1["AmountSpent"], "±", dataRow1["carttotalprice"], "µ" };
                    this.SpendLimitData = string.Concat(spendLimitData);
                }
                else
                {
                    decimal spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]);
                    if (Convert.ToBoolean(dataRow1["EnableRollOver"]))
                    {


                        switch (dataRow1["SpendLimitPeriod"].ToString())
                        {
                            case "Month":

                                DateTime dtToM = DateTime.Now;
                                DateTime startM = this.comm.Eprint_return_ActualDate_Before_View(dataRow1["RollOverStart"].ToString(), this.CompanyID, Convert.ToInt32(StoreUserID), false);
                                var firstDayOfMonth = new DateTime(startM.Year, startM.Month, 1);
                                var lastDayOfMonth = DateTime.DaysInMonth(dtToM.Year, dtToM.Month);
                                var endOfMonth = new DateTime(dtToM.Year, dtToM.Month, lastDayOfMonth);
                                var dif = GetMonthDifference(firstDayOfMonth, endOfMonth) + 1;

                                spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (dif == 0 ? 1 : dif);

                                //if (dataRow1["RollOverLimit"].ToString() == "Unlimited")
                                //{
                                //    DateTime dtTo = DateTime.Now;
                                //    DateTime start = Convert.ToDateTime(dataRow1["RollOverStart"]);
                                //    var firstDayOfMonth = new DateTime(start.Year, start.Month, 1);
                                //    var lastDayOfMonth = dtTo.AddMonths(1).AddDays(-1);
                                //    var dif = GetMonthDifference(firstDayOfMonth, lastDayOfMonth);

                                //    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (dif == 0 ? 1 : dif);
                                //}
                                //if (dataRow1["RollOverLimit"].ToString() == "To end of financial year")
                                //{
                                //    DateTime dtTo = DateTime.Now;
                                //    DateTime start = Convert.ToDateTime(dataRow1["FiscalFrom"]);
                                //    var firstDayOfMonth = new DateTime(start.Year, start.Month, 1);
                                //    var lastDayOfMonth = dtTo.AddMonths(1).AddDays(-1);
                                //    var dif = GetMonthDifference(firstDayOfMonth, lastDayOfMonth);

                                //    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (dif == 0 ? 1 : dif);
                                //}
                                //if (dataRow1["RollOverLimit"].ToString() == "To end of calendar year")
                                //{
                                //    DateTime dtTo = DateTime.Now;
                                //    DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                                //    var firstDayOfMonth = new DateTime(start.Year, start.Month, 1);
                                //    var lastDayOfMonth = dtTo.AddMonths(1).AddDays(-1);
                                //    var dif = GetMonthDifference(firstDayOfMonth, lastDayOfMonth);

                                //    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (dif == 0 ? 1 : dif);
                                //}
                                break;
                            case "Week":
                                if (dataRow1["RollOverLimit"].ToString() == "Unlimited")
                                {
                                    DateTime end = DateTime.Now;
                                    DateTime start = Convert.ToDateTime(dataRow1["RollOverStart"]);
                                    start = start.StartOfWeek(DayOfWeek.Monday);

                                    end = end.StartOfWeek(DayOfWeek.Sunday);
                                    int weeks = Convert.ToInt32((end - start).TotalDays / 7);

                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (weeks == 0 ? 1 : weeks);
                                }
                                if (dataRow1["RollOverLimit"].ToString() == "To end of financial year")
                                {

                                    DateTime end = DateTime.Now;
                                    DateTime start = Convert.ToDateTime(dataRow1["FiscalFrom"]);
                                    start = start.StartOfWeek(DayOfWeek.Monday);

                                    end = end.StartOfWeek(DayOfWeek.Sunday);
                                    int weeks = Convert.ToInt32((end - start).TotalDays / 7);

                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (weeks == 0 ? 1 : weeks);
                                }
                                if (dataRow1["RollOverLimit"].ToString() == "To end of calendar year")
                                {


                                    DateTime end = DateTime.Now;
                                    DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                                    start = start.StartOfWeek(DayOfWeek.Monday);

                                    end = end.StartOfWeek(DayOfWeek.Sunday);
                                    int weeks = Convert.ToInt32((end - start).TotalDays / 7);

                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (weeks == 0 ? 1 : weeks);
                                }

                                break;

                            case "Day":
                                if (dataRow1["RollOverLimit"].ToString() == "Unlimited")
                                {


                                    DateTime end = DateTime.Now;
                                    DateTime start = Convert.ToDateTime(dataRow1["RollOverStart"]);

                                    int day = Convert.ToInt32((end - start).TotalDays);

                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (day == 0 ? 1 : day);
                                }
                                if (dataRow1["RollOverLimit"].ToString() == "To end of financial year")
                                {

                                    DateTime end = DateTime.Now;
                                    DateTime start = Convert.ToDateTime(dataRow1["FiscalFrom"]);

                                    int day = Convert.ToInt32((end - start).TotalDays);

                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (day == 0 ? 1 : day);

                                }
                                if (dataRow1["RollOverLimit"].ToString() == "To end of calendar year")
                                {
                                    DateTime end = DateTime.Now;
                                    DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                                    int day = Convert.ToInt32((end - start).TotalDays);
                                    spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (day == 0 ? 1 : day);

                                }

                                break;
                            case "Calendar Year":

                                DateTime endc = DateTime.Now;
                                DateTime startc = new DateTime(Convert.ToDateTime(dataRow1["RollOverStart"]).Year, 1, 1);

                                int year1 = CalculateYears(startc, endc);

                                spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (year1 == 0 ? 1 : year1);

                                break;
                            case "Financial Year":

                                DateTime FiscalFrom = Convert.ToDateTime(dataRow1["FiscalFrom"]);
                                DateTime endf = DateTime.Now;
                                DateTime startf = new DateTime(Convert.ToDateTime(dataRow1["RollOverStart"]).Year, FiscalFrom.Month, FiscalFrom.Day);

                                int yearf = CalculateYears(startf, endf);

                                spendlimitAmountRollOver = Convert.ToDecimal(dataRow1["SpendLimitAmount"]) * (yearf == 0 ? 1 : yearf);


                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }


                    }
                    object[] item = new object[] { dataRow1["CartItemId"], "±", dataRow1["contactID"], "±", spendlimitAmountRollOver, "±", dataRow1["AmountSpent"], "±", dataRow1["carttotalprice"], "µ" };
                    this.SpendLimitData = string.Concat(item);

                }
            }
            if (this.comm.GetDisplayValue("isCartJobName", shoppingcart.AccountID) != "true")
            {
                this.isCartJobName = "0";
            }
            else
            {
                this.isCartJobName = "1";
            }
            if (this.comm.GetDisplayValue("isCartUnitPrice", shoppingcart.AccountID) != "true")
            {
                this.isCartUnitPrice = "0";
            }
            else
            {
                this.isCartUnitPrice = "1";
            }
            if (this.comm.GetDisplayValue("isCartTotal", shoppingcart.AccountID) != "true")
            {
                this.isCartTotal = "0";
            }
            else
            {
                this.isCartTotal = "1";
            }
            if (this.comm.GetDisplayValue("isCartSubtotal", shoppingcart.AccountID) != "true")
            {
                this.isCartSubtotal = "0";
            }
            else
            {
                this.isCartSubtotal = "1";
            }
            if (this.comm.GetDisplayValue("isCartGrandTotal", shoppingcart.AccountID) != "true")
            {
                this.isCartGrandTotal = "0";
            }
            else
            {
                this.isCartGrandTotal = "1";
            }
            if (this.isCartSubtotal == "0")
            {
                this.displaySubTotal = "style='display:none;'";
                this.displayStyle = "style='display:none;'";
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && shoppingcart.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            if (this.Session["ApprovalSystem"] == null)
            {
                this.ApprovalSystem = "false";
            }
            else if (this.Session["ApprovalSystem"].ToString().ToLower() != "on")
            {
                this.ApprovalSystem = "false";
            }
            else
            {
                this.ApprovalSystem = "true";
                this.IsMarkedAllForApprove = Convert.ToBoolean(base.Return_ApprovalSystem_Settings("is_markall_items_selfapproval"));
                this.ApprovalType = base.Return_ApprovalSystem_Settings("approvaltype");
            }
            this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(shoppingcart.AccountID);
            if (!base.IsPostBack)
            {
                if (base.Request.Params["ID"] != null)
                {
                    this.cardid = (long)Convert.ToInt32(base.Request.Params["ID"]);
                }
                if (base.Request.Params["PID"] != null)
                {
                    this.productid_new = (long)Convert.ToInt32(base.Request.Params["PID"]);
                }
                if (this.cardid == (long)0)
                {
                    long productidNew = this.productid_new;
                    long num = (long)0;
                }
                this.NewSessionID = this.comm.UniqueID;
                this.GenerateCartList(dataTable);
            }

            if (base.Request.Params["type"] != null)
            {
                this.lblSucess.Text = "Proceed further to reorder your selected order";
                this.lblSucess.Visible = false;
                this.imgSucess.Visible = false;
            }
            if (base.Request.Params["CID"] == null)
            {
                this.btn_ContinueShopping.Attributes.Add("onclick", "javascript:return onclick_Checkout('shopping','ctl00_ContentPlaceHolder1_hdnChecked','0','');");
            }
            else
            {
                int num1 = Convert.ToInt32(base.Request.Params["CID"]);
                if (this.Session["SearchKey"] != null && this.Session["SearchKey"] != null)
                {
                    AttributeCollection attributes = this.btn_ContinueShopping.Attributes;
                    object[] str = new object[] { "javascript:return onclick_Checkout('shopping','ctl00_ContentPlaceHolder1_hdnChecked','", num1, "','", this.Session["SearchKey"].ToString(), "','false');" };
                    attributes.Add("onclick", string.Concat(str));
                }
                else if (this.Session["SearchKey"] != null)
                {
                    this.btn_ContinueShopping.Attributes.Add("onclick", string.Concat("javascript:return onclick_Checkout('shopping','ctl00_ContentPlaceHolder1_hdnChecked','", num1, "','','false');"));
                }
                else
                {
                    AttributeCollection attributeCollection = this.btn_ContinueShopping.Attributes;
                    object[] str1 = new object[] { "javascript:return onclick_Checkout('shopping','ctl00_ContentPlaceHolder1_hdnChecked','", num1, "','", this.Session["SearchKey"].ToString(), "','false');" };
                    attributeCollection.Add("onclick", string.Concat(str1));
                }
            }
            this.btn_proceedCheckout.Attributes.Add("onclick", string.Concat("javascript: var a = onclick_Checkout('checkout','ctl00_ContentPlaceHolder1_hdnChecked','','','", this.CartJobNameIsMandatory, "'); return a;"));
            if (!base.IsPostBack && this.Session["InsertOrder"] != null)
            {
                this.Session["InsertOrder"] = null;
            }
            if (this.IsEnableHidePrice == "true" || this.IsZip2taxEnabled != false)
            {
                this.div_grandTotal.Style.Add("display", "none");
            }
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static int CalculateYears(DateTime from, DateTime to)
        {

            int years = to.Year - from.Year;
            if (from < to.AddYears(-years)) years++;
            return years;
        }

        void assignStoreCredit(double TotalStoreCredit, DataTable dt)
        {
            string StoreCreditWithCartId = "";
            double StoreCreditValue = 0;
            StoreCreditValue = TotalStoreCredit;
            //if (TotalStoreCredit > ItemsCost)
            //{

            foreach (DataRow item in dt.Rows)
            {


                if (StoreCreditValue > 0)
                {
                    StoreCreditWithCartId = (StoreCreditWithCartId == "" ? "" : (StoreCreditWithCartId + "»")) + Convert.ToString(item["CartItemId"]) + "±" + ((TotalStoreCredit - Convert.ToDouble(item["CartTotalPrice"])) > 0 ? Convert.ToDouble(item["CartTotalPrice"]) : StoreCreditValue);
                    StoreCreditValue = StoreCreditValue - Convert.ToDouble(item["CartTotalPrice"]);
                }
                //else
                //{
                //    StoreCreditWithCartId = (StoreCreditWithCartId == "" ? "" : (StoreCreditWithCartId + "»")) + Convert.ToString(item["CartItemId"]) + "±" + (item["CartTotalPrice"]);

                //}

            }
            //}
            //else
            //{

            //}
        }
    }
}